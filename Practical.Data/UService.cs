using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Practical.Data
{
    public class UService: BaseEntity
    {

        [Display(Name = "Service Name")]
        [Required(ErrorMessage = "Service Name is Required")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Name { get; set; }
        public ICollection<UserService> UserServices { get; set; }
    }
}
