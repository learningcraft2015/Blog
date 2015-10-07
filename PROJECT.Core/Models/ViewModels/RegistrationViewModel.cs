using PROJECT.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace PROJECT.Core.Models.ViewModels
{

    public class RegistrationViewModel : BaseViewModel
    {


        [ScaffoldColumn(false)]
        public int RegistrationId { get; set; }

        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        [ScaffoldColumn(false)]
        public Int16 RoleId { get; set; }

        [Required(ErrorMessage = "Enter your First Name")]
        [RegularExpression(@"[a-zA-Z ]*$", ErrorMessage = "Use alphabets only please")]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your Last Name")]
        [RegularExpression(@"[a-zA-Z ]*$", ErrorMessage = "Use alphabets only please")]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        //Install-Package DataAnnotationsExtensions.MVC3
        //[Required(ErrorMessage = "Please Upload File")]
        [DataAnnotationsExtensions.FileExtensions("png|jpg|jpeg|gif")] //"png|jpg|jpeg|gif|doc|docx|txt|rtf|pdf"
        [Display(Name = "Upload a file")]
        [ScaffoldColumn(false)]
        public HttpPostedFileBase UploadPhoto { get; set; }

        [ScaffoldColumn(false)]
        public string PhotoName { get; set; }

        public string Address { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        [Required(ErrorMessage = "Enter your date of birth")]
        [DisplayName("Date of Birth")]

        public DateTime DateOfBirth { get; set; }


        [Range(1, Int32.MaxValue, ErrorMessage = "Select gender")]
        [DisplayName("Gender")]
        public GenderEnum Gender { get; set; }

        [Required(ErrorMessage = "Enter Location")]
        [DisplayName("Location")]
        [StringLength(50)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Enter Mobile Number")]
        [DataAnnotationsExtensions.Numeric]
        [DisplayName("Mobile Number")]
        [StringLength(50)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Enter E-mail address")]

        [DataAnnotationsExtensions.Email]
        [DisplayName("E-mail")]
        [StringLength(50)]
        public string UserEmail { get; set; }



        [Required(ErrorMessage = "Enter a password")]
        [DisplayName("Password")]
        [MinLength(3)]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50)]
        [MinLength(3)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password does not match the confirm password.")]
        public string ConfirmPassword { get; set; }



        [ScaffoldColumn(false)]
        public string PasswordSalt { get; set; }

        [ScaffoldColumn(false)]
        public int Status { get; set; }



    }

}









