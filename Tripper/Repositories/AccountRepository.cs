using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Tripper.Models;
using Tripper.Models.DataAccess;

namespace Tripper.Repositories
{
    public class AccountRepository
    {
        protected TripperContext context;
        public AccountRepository(TripperContext context)
        {
            this.context = context;
        }

        public Account GetUserById(ApplicationUserManager manager, string userId)
        {
            ApplicationUser user = manager.FindById(userId);
            Account account = context.Accounts.Where(x => x.UserId.Equals(userId.ToString())).Select(x => new Account
            {
                Id = x.Id.ToString(),
                CountryCode = x.CountryCode,
                CurrencyCode = x.CurrencyCode,
                FirstName = x.FirstName,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                LocaleCode = x.LocaleCode,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            }).FirstOrDefault();
            
            return account;
        }

        public void Edit(Account account)
        {
            AccountInfo accountInfo = context.Accounts.FirstOrDefault(x => x.Id.Equals(new Guid(account.Id)));
            if (accountInfo != null)
            {
                accountInfo.CountryCode = account.CountryCode;
                accountInfo.CurrencyCode = account.CurrencyCode;
                accountInfo.FirstName = account.FirstName;
                accountInfo.MiddleName = account.MiddleName;
                accountInfo.LastName = account.LastName;
                accountInfo.LocaleCode = account.LocaleCode;

                AspNetUser user = context.AspNetUsers.FirstOrDefault(x => x.Id.Equals(accountInfo.UserId));
                user.Email = account.Email;
                user.PhoneNumber = account.PhoneNumber;

                context.SaveChanges();
            }
            

        }
    }
}