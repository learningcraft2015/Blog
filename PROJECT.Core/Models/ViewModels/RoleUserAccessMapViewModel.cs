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
    public class RoleUserAccessMapViewModel : BaseViewModel
    {
        [ScaffoldColumn(false)]
        public Int16 UserAccessId { get; set; }
        [ScaffoldColumn(false)]
        // [Required(ErrorMessage = "Select a role")]

        public Int16? RoleId { get; set; }


        // [Required(ErrorMessage = "Select a role")]
        // [Range(1, Int16.MaxValue, ErrorMessage = "Select a role")]
        public Int16 RId { get; set; }

        [Display(Name = "User Access Title")]
        public string UserAccessTitle { get; set; }
        public bool AddPermission { get; set; }

        public bool EditPermission { get; set; }

        public bool ViewPermission { get; set; }

        public bool DeletePermission { get; set; }

        public string SelectedRoleUserAccessMap { get; set; }// checkbox

        public List<RoleUserAccessMapViewModel> RoleUserAccessMapList { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        [Display(Name = "Role Name")]

        public SelectList RoleViewModelList { get; set; }


    }
}
