using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Models.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public String UserEmail { get; set; }
        [Required]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public String Password { get; set; }


    }
}
