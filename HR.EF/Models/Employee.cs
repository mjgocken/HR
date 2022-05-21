using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HR.EF.Models
{
    [Table("EMPLOYEES")]
    public partial class Employee
    {
        public Employee()
        {
            Departments = new HashSet<Department>();
            Employments = new HashSet<Employment>();
        }

        [Key]
        [Column("EMPLOYEE_GUID")]
        [StringLength(32)]
        public string EmployeeGuid { get; set; }
        [Column("FIRST_NAME")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required]
        [Column("LAST_NAME")]
        [StringLength(25)]
        public string LastName { get; set; }
        [Required]
        [Column("EMAIL")]
        [StringLength(25)]
        public string Email { get; set; }
        [Column("PHONE_NUMBER")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
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

        [InverseProperty(nameof(Department.ManagerGu))]
        public virtual ICollection<Department> Departments { get; set; }
        [InverseProperty(nameof(Employment.EmployeeGu))]
        public virtual ICollection<Employment> Employments { get; set; }
    }
}
