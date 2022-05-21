using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HR.EF.Models
{
    [Table("COUNTRIES")]
    public partial class Country
    {
        public Country()
        {
            Locations = new HashSet<Location>();
        }

        [Key]
        [Column("COUNTRY_GUID")]
        [StringLength(32)]
        public string CountryGuid { get; set; }
        [Required]
        [Column("COUNTRY_NAME")]
        [StringLength(40)]
        public string CountryName { get; set; }
        [Required]
        [Column("REGION_GUID")]
        [StringLength(32)]
        public string RegionGuid { get; set; }
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

        [ForeignKey(nameof(RegionGuid))]
        [InverseProperty(nameof(Region.Countries))]
        public virtual Region RegionGu { get; set; }
        [InverseProperty(nameof(Location.CountryGu))]
        public virtual ICollection<Location> Locations { get; set; }
    }
}
