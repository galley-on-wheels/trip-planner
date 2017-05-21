namespace Tripper.Models.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountInfo")]
    public partial class AccountInfo
    {
        public Guid Id { get; set; }

        [StringLength(256)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string MiddleName { get; set; }

        [StringLength(256)]
        public string LastName { get; set; }

        [StringLength(128)]
        public string CountryCode { get; set; }

        [StringLength(128)]
        public string LocaleCode { get; set; }

        [StringLength(128)]
        public string CurrencyCode { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }
    }
}
