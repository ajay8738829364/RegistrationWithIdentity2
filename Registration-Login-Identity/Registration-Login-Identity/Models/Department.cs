using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registration_Login_Identity.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DeptName { get; set; }
        public DateTime? CreatedDate { get; set; }


    }
}
