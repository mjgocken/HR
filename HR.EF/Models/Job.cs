using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HR.EF.Models
{
    [Table("JOBS")]
    public partial class Job
    {
        public Job()
        {
            Employments = new HashSet<Employment>();
        }

        [Key]
        [Column("JOB_GUID")]
        [StringLength(32)]
        public string JobGuid { get; set; }
        [Required]
        [Column("JOB_TITLE")]
        [StringLength(35)]
        public string JobTitle { get; set; }
        [Column("MIN_SALARY")]
        public int? MinSalary { get; set; }
        [Column("MAX_SALARY")]
        public int? MaxSalary { get; set; }
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

        [InverseProperty(nameof(Employment.JobGu))]
        public virtual ICollection<Employment> Employments { get; set; }
    }
}
