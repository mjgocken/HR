using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HR.EF.Models
{
    [Table("EMPLOYMENT")]
    public partial class Employment
    {
        public Employment()
        {
            EmploymentPays = new HashSet<EmploymentPay>();
        }

        [Key]
        [Column("EMPLOYMENT_GUID")]
        [StringLength(32)]
        public string EmploymentGuid { get; set; }
        [Required]
        [Column("EMPLOYEE_GUID")]
        [StringLength(32)]
        public string EmployeeGuid { get; set; }
        [Required]
        [Column("JOB_GUID")]
        [StringLength(32)]
        public string JobGuid { get; set; }
        [Required]
        [Column("DEPARTMENT_GUID")]
        [StringLength(32)]
        public string DepartmentGuid { get; set; }
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

        [ForeignKey(nameof(DepartmentGuid))]
        [InverseProperty(nameof(Department.Employments))]
        public virtual Department DepartmentGu { get; set; }
        [ForeignKey(nameof(EmployeeGuid))]
        [InverseProperty(nameof(Employee.Employments))]
        public virtual Employee EmployeeGu { get; set; }
        [ForeignKey(nameof(JobGuid))]
        [InverseProperty(nameof(Job.Employments))]
        public virtual Job JobGu { get; set; }
        [InverseProperty(nameof(EmploymentPay.EmploymentGu))]
        public virtual ICollection<EmploymentPay> EmploymentPays { get; set; }
    }
}
