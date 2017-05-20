using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tripper.Models.DataAccess;

namespace Tripper.Models
{
    public class TripperContext: DbContext
    {
        public TripperContext() 
            : base("name=DbConnection") 
        {
        }

        public virtual DbSet<AccountInfo> Accounts { get; set; }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
    }
}