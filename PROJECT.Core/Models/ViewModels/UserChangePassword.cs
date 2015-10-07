using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Models.ViewModels
{

    public class UserChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50)]
        [MinLength(3)]
        [Display(Name = "New Password")]

        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50)]
        [MinLength(3)]
        [Display(Name = "Confirm Password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public string UserEmail { get; set; }
    }
}
