using PROJECT.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;


namespace PROJECT.Core.Models.ViewModels
{
    public class RegistrationUpdateViewModel : BaseViewModel
    {


        [ScaffoldColumn(false)]
        public int RegistrationId { get; set; }

        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        [ScaffoldColumn(false)]
        public int UserTypeId { get; set; }

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





        [Required(ErrorMessage = "Enter your date of birth")]
        [DisplayName("Date of Birth")]

        public DateTime DateOfBirth { get; set; }


        [Range(1, int.MaxValue, ErrorMessage = "Select gender")]
        [DisplayName("Gender")]
        public GenderEnum Gender { get; set; }


        public int CountryId { get; set; }
        public int StateId { get; set; }


        [Required(ErrorMessage = "Enter Location")]
        [DisplayName("Location")]
        [StringLength(50)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Enter Mobile Number")]
        [DataAnnotationsExtensions.Numeric]
        [DisplayName("Mobile Number")]
        [StringLength(50)]
        public string MobileNumber { get; set; }



        [ScaffoldColumn(false)]
        public int Status { get; set; }

    }


}

