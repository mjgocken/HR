using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HR.EF.Models
{
    [Table("REGIONS")]
    public partial class Region
    {
        public Region()
        {
            Countries = new HashSet<Country>();
        }

        [Key]
        [Column("REGION_GUID")]
        [StringLength(32)]
        public string RegionGuid { get; set; }
        [Required]
        [Column("REGION_NAME")]
        [StringLength(25)]
        public string RegionName { get; set; }
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

        [InverseProperty(nameof(Country.RegionGu))]
        public virtual ICollection<Country> Countries { get; set; }
    }
}
