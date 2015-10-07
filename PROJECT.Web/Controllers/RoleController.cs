using PROJECT.Core.Models.ViewModels;
using PROJECT.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PROJECT.Core.Helpers;
using MvcFlashMessages;
using PROJECT.Core.Filters;

namespace PROJECT.Web.Controllers
{

    public class RoleController : BaseController
    {

        [UserAuthorized(ActionAccess = ActionUserAccessEnum.AdminOnly)]

        public ActionResult Index()
        {

            //
            var objRoleRepository = new RoleRepository();
            List<RoleViewModel> objEntityList = objRoleRepository.Select(RoleFlags.SelectAll.GetHashCode(), new RoleViewModel() { });
            if (objEntityList.Count == 0)
            {

                this.Flash("Info", "No Roles");
            }

            return View(objEntityList);
        }

        [UserAuthorized(ActionAccess = ActionUserAccessEnum.AdminOnly)]
        public ActionResult Create()
        {
            return View();
        }


        [UserAuthorized(ActionAccess = ActionUserAccessEnum.AdminOnly)]
        [HttpPost]
        public ActionResult Create(RoleViewModel objEntity)
        {
            RoleRepository objRoleRepository = new RoleRepository();

            //objFormCollection
            if (ModelState.IsValid)
            {
                objEntity.RoleName = objEntity.RoleName.Trim();
                objEntity.ShortName = objEntity.ShortName.Trim();

                objEntity.CreatedBy = 1;//admin


                objRoleRepository.Insert(objEntity);
                //selected location
                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
                    this.Flash("Success", "Role added successfully");

                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {

                    this.Flash("Error", "Role failed to add");
                }
                else if (objEntity.Result == ResultFlags.Duplicate.GetHashCode())
                {
                    this.Flash("Warning", "Role failed to add");

                }
            }



            return View(objEntity);
        }



        [UserAuthorized(ActionAccess = ActionUserAccessEnum.AdminOnly)]
        [HttpGet]
        public ActionResult Edit(Int16 id)
        {
            RoleRepository objRoleRepository = new RoleRepository();

            var objEntity = new RoleViewModel();

            objEntity = objRoleRepository.Select(RoleFlags.SelectByID.GetHashCode(), new RoleViewModel()
            {
                RoleId = id
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
        public ActionResult Edit(Int16 id, RoleViewModel objEntity)
        {
            var objRoleRepository = new RoleRepository();

            if (ModelState.IsValid)
            {
                // objEntity.Name = objEntity.Name.Trim();

                objEntity.RoleId = id;
                objEntity.ModifiedDate = DateTime.Now;

                objEntity.ModifiedBy = 1;//admin

                objEntity = objRoleRepository.Update(RoleFlags.UpdateByID.GetHashCode(), objEntity);
                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
                    this.Flash("success", "Role Details updated successfully");

                    //reload all new setting
                    MenuHelpers.SetMenuByRoleMaster();
                    MenuHelpers.SetMenuByRoleMain();

                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {

                    this.Flash("error", "Role Details failed to Update");
                }
                else if (objEntity.Result == ResultFlags.Duplicate.GetHashCode())
                {

                    this.Flash("warning", "Role Name is Already Exist");
                }
            }


            return View(objEntity);

        }



        [UserAuthorized(ActionAccess = ActionUserAccessEnum.AdminOnly)]
        public ActionResult Delete(Int16 id)
        {


            var objRoleRepository = new RoleRepository();
            int result = 0;
            result = objRoleRepository.Delete(RoleFlags.DeleteByID.GetHashCode(), new RoleViewModel()
            {
                RoleId = id
            });
            if (result == ResultFlags.Success.GetHashCode())
            {
                this.Flash("success", "Role Delete successfully ");
                return RedirectToAction("Index");
            }
            else if (result == ResultFlags.Failure.GetHashCode())
            {
                this.Flash("error", "Faild to Delete Role");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}