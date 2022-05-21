using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HR.EF.Models
{
    [Keyless]
    public partial class VEmployment
    {
        [Required]
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
        [Required]
        [Column("EMPLOYMENT_GUID")]
        [StringLength(32)]
        public string EmploymentGuid { get; set; }
        [Column("START_START", TypeName = "DATE")]
        public DateTime? StartStart { get; set; }
        [Column("END_DATE", TypeName = "DATE")]
        public DateTime? EndDate { get; set; }
    }
}
