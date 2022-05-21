using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HR.EF.Models
{
    [Table("LOCATIONS")]
    public partial class Location
    {
        public Location()
        {
            Departments = new HashSet<Department>();
        }

        [Key]
        [Column("LOCATION_GUID")]
        [StringLength(32)]
        public string LocationGuid { get; set; }
        [Required]
        [Column("STREET_ADDRESS")]
        [StringLength(40)]
        public string StreetAddress { get; set; }
        [Column("POSTAL_CODE")]
        [StringLength(12)]
        public string PostalCode { get; set; }
        [Required]
        [Column("CITY")]
        [StringLength(30)]
        public string City { get; set; }
        [Column("STATE_PROVINCE")]
        [StringLength(25)]
        public string StateProvince { get; set; }
        [Required]
        [Column("COUNTRY_GUID")]
        [StringLength(32)]
        public string CountryGuid { get; set; }
        [Column("CREATED_ID")]
        [StringLength(30)]
        public string CreatedId { get; set; }
        [Column("CREATED_DATE", TypeName = "DATE")]
        public DateTime? CreatedDate { get; set; }
        [Column("UPDATED_ID")]
        [StringLength(30)]
        public string UpdatedId { get; set; }
        [Column("UPDATED_DATE", TypeName = "DATE")]
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(CountryGuid))]
        [InverseProperty(nameof(Country.Locations))]
        public virtual Country CountryGu { get; set; }
        [InverseProperty(nameof(Department.LocationGu))]
        public virtual ICollection<Department> Departments { get; set; }
    }
}
