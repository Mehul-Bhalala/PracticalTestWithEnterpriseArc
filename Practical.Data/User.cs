using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Data
{
    public class User:BaseEntity
    {
        

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is Required")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string FullName { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UserService> UserServices { get; set; }
    }
}
