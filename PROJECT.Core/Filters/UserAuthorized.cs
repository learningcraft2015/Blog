using PROJECT.Core.Helpers;
using System;
using System.Web.Mvc;
using PROJECT.Core.Repository;
using PROJECT.Core.Models.ViewModels;
using System.Web;
using System.Web.Routing;
using System.Linq;

namespace PROJECT.Core.Filters
{
    public class UserAuthorized : ActionFilterAttribute
    {

        public ActionUserAccessEnum ActionAccess { get; set; }


        public UserAuthorized()
        {
            ActionAccess = ActionUserAccessEnum.Default;

        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {


            var objController = filterContext.RouteData.Values["Controller"];
            var objAction = filterContext.RouteData.Values["Action"];
            int UserId = 0;





            if (HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.User.Identity.AuthenticationType == "Forms")
            {
                UserId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                if (SessionWrapper.UserAccount == null)
                {
                    var objAccountRepository = new AccountRepository();

                    if (objAccountRepository.SetAccountByUser(UserId))
                    {


                        if (ActionAccess != ActionUserAccessEnum.Default && ActionAccess != ActionUserAccessEnum.AdminOnly)
                        {
                            CheckRoleUserAccess(filterContext, new UserAccessViewModel() { Url = objController.ToString() }, SessionWrapper.UserAccount.RoleId);
                        }




                    }
                }
                else
                {

                    if (ActionAccess != ActionUserAccessEnum.Default && ActionAccess != ActionUserAccessEnum.AdminOnly)
                    {
                        CheckRoleUserAccess(filterContext, new UserAccessViewModel() { Url = objController.ToString() }, SessionWrapper.UserAccount.RoleId);
                    }
                }

            }
            else
            {
                RedirectUnAuthorizedUserLogin(filterContext);

            }
            base.OnActionExecuting(filterContext);
        }

        private void CheckRoleUserAccess(ActionExecutingContext filterContext, UserAccessViewModel objUserAccessViewModel, Int16 RoleId)
        {
            var objUserAccessRepository = new UserAccessRepository();
            objUserAccessViewModel = objUserAccessRepository.Select(UserAccessFlags.SelectPermissionByUrlRoleId.GetHashCode(), RoleId,
              objUserAccessViewModel).FirstOrDefault();

            if (objUserAccessViewModel != null)
            {



                switch (ActionAccess)
                {
                    case ActionUserAccessEnum.Default:
                        break;
                    case ActionUserAccessEnum.Index:
                        {

                            if (objUserAccessViewModel.ViewPermission != true && RoleId != RoleUserDefinedEnum.Admin.GetHashCode())
                            {
                                RedirectUnAuthorizedUserLogin(filterContext);
                            }


                            break;
                        }
                    case ActionUserAccessEnum.Details:
                        {
                            if (objUserAccessViewModel.ViewPermission != true && RoleId != RoleUserDefinedEnum.Admin.GetHashCode())
                            {
                                RedirectUnAuthorizedUserLogin(filterContext);
                            }
                            break;
                        }
                    case ActionUserAccessEnum.Create:
                        {
                            if (objUserAccessViewModel.AddPermission != true && RoleId != RoleUserDefinedEnum.Admin.GetHashCode())
                            {
                                RedirectUnAuthorizedUserLogin(filterContext);
                            }
                            break;
                        }
                    case ActionUserAccessEnum.Edit:
                        {
                            if (objUserAccessViewModel.EditPermission != true && RoleId != RoleUserDefinedEnum.Admin.GetHashCode())
                            {
                                RedirectUnAuthorizedUserLogin(filterContext);
                            }
                            break;
                        }
                    case ActionUserAccessEnum.Delete:
                        {
                            if (objUserAccessViewModel.DeletePermission != true && RoleId != RoleUserDefinedEnum.Admin.GetHashCode())
                            {
                                RedirectUnAuthorizedUserLogin(filterContext);
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            else
            {
                RedirectUnAuthorizedUserLogin(filterContext);
            }
        }

        private static void RedirectAdminLogin(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary{{ "controller", "Admin" },
                                          { "action", "Login" }
 
                                         });
        }

        private static void RedirectUserLogin(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary{{ "controller", "User" },
                                          { "action", "Login" }
 
                                         });
        }
        private static void RedirectUnAuthorizedUserLogin(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary{{ "controller", "User" },
                                          { "action", "UnAuthorized" }
 
                                         });


        }

    }
}
