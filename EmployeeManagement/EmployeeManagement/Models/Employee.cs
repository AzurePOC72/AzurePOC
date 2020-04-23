using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="Name cannot exceed more than 50 characters.")]
        public string EmpName { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage ="Invaid email address.")]
        public string Email { get; set; }
    }
}
