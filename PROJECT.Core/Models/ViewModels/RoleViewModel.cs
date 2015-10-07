using PROJECT.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Core.Models.ViewModels
{
    public class RoleViewModel : BaseViewModel
    {
        [ScaffoldColumn(false)]
        public Int16 RoleId { get; set; }
        [Required]
        [Display(Name = "Role Name")]

        [StringLength(25)]
        public string RoleName { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Short Name")]
        public string ShortName { get; set; }


        [Required]
        [Range(1, 5, ErrorMessage = "Select a valid status")]
        [Display(Name = "Status")]
        public StatusEnum RoleStatus { get; set; }
        [Range(1, Int16.MaxValue)]
        [DataAnnotationsExtensions.Integer]
        [Display(Name = "Sort Order")]
        public Int16 SortOrder { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }
        [ScaffoldColumn(false)]
        public int CreatedBy { get; set; }
        [ScaffoldColumn(false)]
        public DateTime ModifiedDate { get; set; }
        [ScaffoldColumn(false)]
        public int ModifiedBy { get; set; }




    }
}
