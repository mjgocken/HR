using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HR.EF.Models
{
    [Table("DEPARTMENTS")]
    public partial class Department
    {
        public Department()
        {
            Employments = new HashSet<Employment>();
        }

        [Key]
        [Column("DEPARTMENT_GUID")]
        [StringLength(32)]
        public string DepartmentGuid { get; set; }
        [Required]
        [Column("DEPARTMENT_NAME")]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        [Required]
        [Column("LOCATION_GUID")]
        [StringLength(32)]
        public string LocationGuid { get; set; }
        [Column("MANAGER_GUID")]
        [StringLength(32)]
        public string ManagerGuid { get; set; }
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

        [ForeignKey(nameof(LocationGuid))]
        [InverseProperty(nameof(Location.Departments))]
        public virtual Location LocationGu { get; set; }
        [ForeignKey(nameof(ManagerGuid))]
        [InverseProperty(nameof(Employee.Departments))]
        public virtual Employee ManagerGu { get; set; }
        [InverseProperty(nameof(Employment.DepartmentGu))]
        public virtual ICollection<Employment> Employments { get; set; }
    }
}
