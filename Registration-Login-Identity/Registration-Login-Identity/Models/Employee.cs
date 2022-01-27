using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Login_Identity.Models
{
    public class Employee
    {
        [Key]
        public int empId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string MobileNo{ get; set; }
        public string Gender { get; set; }
        [Required]
        public string Experience { get; set; }
      
        public DateTime? CreatedDate { get; set; }
        [ForeignKey("Id")]
        public virtual
            Department DeptId { get; set; }





    }
}
