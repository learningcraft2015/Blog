using PROJECT.Core.Models.ViewModels;
using PROJECT.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT.Core.Helpers;
using MvcFlashMessages;
using System.Text;
using PROJECT.Core.Filters;

namespace PROJECT.Web.Controllers
{
    public class RoleUserAccessMapController : BaseController
    {
        // GET: UserAccess
        [UserAuthorized(ActionAccess = ActionUserAccessEnum.AdminOnly)]
        public ActionResult Index(Int16 RId = 0)
        {
            RoleUserAccessMapViewModel objEntity = new RoleUserAccessMapViewModel();

            RoleRepository objRoleRepository = new RoleRepository();

            objEntity.RId = RId;
            var objRoleEntity = objRoleRepository.Select(RoleFlags.SelectAllExcludeAdmin.GetHashCode(), new RoleViewModel() { });
            objEntity.RoleViewModelList = new SelectList(objRoleEntity, "RoleId", "RoleName");

            //
            RoleUserAccessMapRepository objRoleUserAccessMapRepository = new RoleUserAccessMapRepository();
            objEntity.RoleUserAccessMapList = new List<RoleUserAccessMapViewModel>();
            objEntity.RoleUserAccessMapList = objRoleUserAccessMapRepository.Select((RId == 0) ? RoleUserAccessMapFlags.SelectAll.GetHashCode() : RoleUserAccessMapFlags.SelectByRoleId.GetHashCode(), new RoleUserAccessMapViewModel()
            {

                RoleId = RId
            });
            if (objEntity.RoleUserAccessMapList.Count == 0)
            {

                this.Flash("Error", "No Role UserAccess");
            }

            return View(objEntity);
        }

        private string BuildCreateXmlInputStringRoleUserAccessMap(List<RoleUserAccessMapViewModel> objEntityList)
        {
            string strXml = string.Empty;
            StringBuilder sbXml = new StringBuilder("<BulkData>");
            //looping PaymentMileStone list

            foreach (RoleUserAccessMapViewModel item in objEntityList)
            {


                sbXml.Append("<SelectedRoleUserAccessMap>");

                sbXml.Append("<xmlUserAccessId>" + item.UserAccessId + "</xmlUserAccessId>");
                sbXml.Append("<xmlRoleId>" + item.RoleId + "</xmlRoleId>");
                sbXml.Append("<xmlAddPermission>" + ((item.AddPermission == false) ? "0" : "1") + "</xmlAddPermission>");
                sbXml.Append("<xmlEditPermission>" + ((item.EditPermission == false) ? "0" : "1") + "</xmlEditPermission>");
                sbXml.Append("<xmlViewPermission>" + ((item.ViewPermission == false) ? "0" : "1") + "</xmlViewPermission>");
                sbXml.Append("<xmlDeletePermission>" + ((item.DeletePermission == false) ? "0" : "1") + "</xmlDeletePermission>");


                sbXml.Append("</SelectedRoleUserAccessMap>");

            }
            sbXml.Append("</BulkData>");


            return sbXml.ToString();

        }
        [HttpPost]
        [UserAuthorized(ActionAccess = ActionUserAccessEnum.AdminOnly)]
        public ActionResult Index(RoleUserAccessMapViewModel objEntity)
        {
            RoleRepository objRoleRepository = new RoleRepository();
            RoleUserAccessMapRepository objRoleUserAccessMapRepository = new RoleUserAccessMapRepository();
            if (objEntity.RId <= 0)
            {
                ModelState.AddModelError("RId", "Select a role");
            }
            objEntity.RoleId = objEntity.RId;

            if (ModelState.IsValid)
            {


                objEntity.SelectedRoleUserAccessMap = BuildCreateXmlInputStringRoleUserAccessMap(objEntity.RoleUserAccessMapList);
                objRoleUserAccessMapRepository.Insert(objEntity);
                //selected location
                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
                    this.Flash("Success", "Role User Access updated successfully");

                    //reload all new setting
                    MenuHelpers.SetMenuByRoleMaster();
                    MenuHelpers.SetMenuByRoleMain();

                    return RedirectToAction("Index", new { RId = objEntity.RId });
                }
                else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {

                    this.Flash("Error", "Role User Access failed to update");
                }

            }

            var objRoleEntity = objRoleRepository.Select(RoleFlags.SelectAllExcludeAdmin.GetHashCode(), new RoleViewModel() { });
            objEntity.RoleViewModelList = new SelectList(objRoleEntity, "RoleId", "RoleName");

            //

            objEntity.RoleUserAccessMapList = new List<RoleUserAccessMapViewModel>();
            objEntity.RoleUserAccessMapList = objRoleUserAccessMapRepository.Select((objEntity.RoleId == 0) ? RoleUserAccessMapFlags.SelectAll.GetHashCode() : RoleUserAccessMapFlags.SelectByRoleId.GetHashCode(), new RoleUserAccessMapViewModel()
            {

                RoleId = objEntity.RoleId
            });
            if (objEntity.RoleUserAccessMapList.Count == 0)
            {

                this.Flash("Error", "No Role UserAccess");
            }

            return View(objEntity);
        }
    }
}