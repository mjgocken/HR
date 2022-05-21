using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HR.EF.Models
{
    [Table("EMPLOYMENT_PAY")]
    [Index(nameof(EmploymentGuid), nameof(EffectiveDate), Name = "EMPLOYMENT_PAY_UK1", IsUnique = true)]
    public partial class EmploymentPay
    {
        [Key]
        [Column("EMPLOYMENT_PAY_GUID")]
        [StringLength(32)]
        public string EmploymentPayGuid { get; set; }
        [Required]
        [Column("EMPLOYMENT_GUID")]
        [StringLength(32)]
        public string EmploymentGuid { get; set; }
        [Column("EFFECTIVE_DATE", TypeName = "DATE")]
        public DateTime EffectiveDate { get; set; }
        [Column("SALARY", TypeName = "NUMBER(8,2)")]
        public decimal? Salary { get; set; }
        [Column("COMMISSION_PCT", TypeName = "NUMBER")]
        public decimal? CommissionPct { get; set; }
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

        [ForeignKey(nameof(EmploymentGuid))]
        [InverseProperty(nameof(Employment.EmploymentPays))]
        public virtual Employment EmploymentGu { get; set; }
    }
}
