using PROJECT.Core.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PROJECT.Core.Models.ViewModels
{
    public class UserAccessViewModel : BaseViewModel
    {
        [ScaffoldColumn(false)]
        public Int16 UserAccessId { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Parent")]
        [Required]
        public UserAccessParentIdEnum ParentId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "User Access Title")]
        public string UserAccessTitle { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Url")]
        public string Url { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Css Class")]
        public string CssClass { get; set; }

        [Range(1, Int16.MaxValue)]
        [DataAnnotationsExtensions.Integer]
        [Display(Name = "Sort Order")]
        public Int16 SortOrder { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Status")]
        public StatusEnum UserAccessStatus { get; set; }


        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }
        [ScaffoldColumn(false)]
        public int CreatedBy { get; set; }
        [ScaffoldColumn(false)]
        public DateTime ModifiedDate { get; set; }
        [ScaffoldColumn(false)]
        public int ModifiedBy { get; set; }


        public Int16 RoleId { get; set; }

        public bool AddPermission { get; set; }

        public bool EditPermission { get; set; }

        public bool ViewPermission { get; set; }

        public bool DeletePermission { get; set; }
    }
}
