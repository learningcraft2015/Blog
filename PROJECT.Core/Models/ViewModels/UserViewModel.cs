using PROJECT.Core.Models.ViewModels;
using System;
using System.ComponentModel.DataAnnotations;
using PROJECT.Core.Helpers;

namespace PROJECT.Core.Models.ViewModels
{
    public class UserViewModel : BaseViewModel
    {

        public int UserId { get; set; }
        public int RegistrationId { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public Int16 RoleId { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public string PasswordSalt { get; set; }
        [Display(Name = "User Email")]
        public string UserEmail { get; set; }
        [Display(Name = "Created Date")]
        public DateTime UserCreatedDate { get; set; }
        [Range(1, Int16.MaxValue)]
        [Display(Name = "Status")]
        public StatusEnum UserStatus { get; set; }

        public string PhotoName { get; set; }
    }
}
