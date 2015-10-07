using PROJECT.Core.Models.ViewModels;
using PROJECT.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROJECT.Core.Helpers;
using MvcFlashMessages;
using PROJECT.Core.Filters;

namespace PROJECT.Web.Controllers
{
    public class UserAccessController : BaseController
    {
        [UserAuthorized(ActionAccess = ActionUserAccessEnum.AdminOnly)]
        // GET: UserAccess
        public ActionResult Index()
        {

            //
            UserAccessRepository objUserAccessRepository = new UserAccessRepository();
            List<UserAccessViewModel> objEntityList = objUserAccessRepository.Select(UserAccessFlags.SelectAll.GetHashCode(), new UserAccessViewModel() { });
            if (objEntityList.Count == 0)
            {

                this.Flash("info", "No User Accesss");
            }

            return View(objEntityList);
        }

        [UserAuthorized(ActionAccess = ActionUserAccessEnum.AdminOnly)]
        public ActionResult Create()
        {

            return View();

        }

        [HttpPost]
        [UserAuthorized(ActionAccess = ActionUserAccessEnum.AdminOnly)]
        public ActionResult Create(UserAccessViewModel objEntity)
        {
            UserAccessRepository objUserAccessRepository = new UserAccessRepository();

            if (ModelState.IsValid)
            {
                objEntity.UserAccessTitle = objEntity.UserAccessTitle.Trim();
                objEntity.Url = objEntity.Url.Trim();
                objEntity.CssClass = objEntity.CssClass.Trim();

                objEntity.CreatedBy = 1;//admin

                objEntity = objUserAccessRepository.Insert(objEntity);


                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
                    //   Install-Package MvcFlashMessages
                    this.Flash("Success", "User Access Insert successfully");

                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {
                    this.Flash("Error", "Failed to Insert UserAccess");
                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Duplicate.GetHashCode())
                {
                    this.Flash("Warning", "UserAccess Name is Already Exist");
                    return RedirectToAction("Index");
                }
            }
            return View(objEntity);
        }

        [UserAuthorized(ActionAccess = ActionUserAccessEnum.AdminOnly)]

        [HttpGet]
        public ActionResult Edit(int id)
        {
            UserAccessRepository objUserAccessRepository = new UserAccessRepository();

            var objEntity = new UserAccessViewModel();

            objEntity = objUserAccessRepository.Select(RoleFlags.SelectByID.GetHashCode(), new UserAccessViewModel()
            {
                UserAccessId = (Int16)id
            }).FirstOrDefault();
            if (objEntity == null)
            {
                this.Flash("Error", "Failed to edit Role details");

                return RedirectToAction("Index");
            }




            return View(objEntity);
        }

        [HttpPost]
        [UserAuthorized(ActionAccess = ActionUserAccessEnum.AdminOnly)]
        public ActionResult Edit(int id, UserAccessViewModel objEntity)
        {
            var objUserAccessRepository = new UserAccessRepository();

            if (ModelState.IsValid)
            {
                // objEntity.Name = objEntity.Name.Trim();

                objEntity.UserAccessId = (Int16)id;


                objEntity = objUserAccessRepository.Update(RoleFlags.UpdateByID.GetHashCode(), objEntity);
                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
                    this.Flash("success", "UserAccess Details updated successfully");
                    //reload all new setting
                    MenuHelpers.SetMenuByRoleMaster();
                    MenuHelpers.SetMenuByRoleMain();
                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {

                    this.Flash("error", "UserAccess Details failed to Update");
                }

            }


            return View(objEntity);

        }
    }
}