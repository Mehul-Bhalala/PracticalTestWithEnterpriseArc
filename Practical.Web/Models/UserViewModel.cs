using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Practical.Web.Models
{
    public class UserViewModel
    {
        [HiddenInput]
        public Int64 Id { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Service")]
        public string Service { get; set; }

        [Display(Name = "Active")]
        public bool Isactive { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
    }
}
