using PROJECT.Core.Models.ViewModels;
using PROJECT.Core.Repository;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.Web.Mvc.Html;
using System.IO;

namespace PROJECT.Core.Helpers
{
    public static class ApplicationHelpers
    {
        public static string BuildBreadcrumbNavigation(this HtmlHelper helper)
        {
            string rootController = "Home";
            string rootAction = "Index";
            // optional condition: I didn't wanted it to show on home and account controller
            if (helper.ViewContext.RouteData.Values["controller"].ToString() == "Home" ||
                helper.ViewContext.RouteData.Values["controller"].ToString() == "Account")
            {
                return string.Empty;
            }


            if (SessionWrapper.UserAccount != null)
            {
                if (SessionWrapper.UserAccount.RoleId == RoleUserDefinedEnum.Admin.GetHashCode())
                {
                    rootController = "Admin";
                    rootAction = "Dashboard";
                }
                else if (true)
                {
                    rootController = "User";
                    rootAction = "Dashboard";
                }

            }
            StringBuilder breadcrumb = new StringBuilder("<div><ul class=\"breadcrumb\"><li>").Append(helper.ActionLink("Home", rootAction, rootController).ToHtmlString()).Append("</li>");


            breadcrumb.Append("<li>");
            breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["controller"].ToString(),
                                               "Index",
                                               helper.ViewContext.RouteData.Values["controller"].ToString()));
            breadcrumb.Append("</li>");

            if (helper.ViewContext.RouteData.Values["action"].ToString() != "Index")
            {
                breadcrumb.Append("<li>");
                breadcrumb.Append(helper.ActionLink(helper.ViewContext.RouteData.Values["action"].ToString(),
                                                    helper.ViewContext.RouteData.Values["action"].ToString(),
                                                    helper.ViewContext.RouteData.Values["controller"].ToString()));
                breadcrumb.Append("</li>");
            }

            return breadcrumb.Append("</ul></div>").ToString();
        }
        public static bool IsAuthenticatedByRole(RoleUserDefinedEnum RoleId)
        {
            bool result = false;
            int userId = 0;

            if (HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.User.Identity.AuthenticationType == "Forms")
            {
                userId = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                if (SessionWrapper.UserAccount != null)
                {
                    if (SessionWrapper.UserAccount.RoleId == RoleId.GetHashCode())
                    {
                        result = true;
                    }

                }
            }
            return result;
        }
        public static bool CheckRoleUserAccess(ActionUserAccessEnum objActionUserAccess)
        {
            bool isVisible = false;
            string objController = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString();
            string objAction = HttpContext.Current.Request.RequestContext.RouteData.Values["Action"].ToString();

            Int32 UserId = SessionWrapper.UserAccount.UserId;
            Int16 RoleId = SessionWrapper.UserAccount.RoleId;

            //Admin only case
            if (SessionWrapper.UserAccount.RoleId == RoleUserDefinedEnum.Admin.GetHashCode())
            {
                isVisible = true;
                return isVisible;
            }
            var objUserAccessRepository = new UserAccessRepository();
            var objUserAccessViewModel = objUserAccessRepository.Select(UserAccessFlags.SelectPermissionByUrlRoleId.GetHashCode(), RoleId,
               new UserAccessViewModel() { Url = objController }).FirstOrDefault();

            if (objUserAccessViewModel != null)
            {



                switch (objActionUserAccess)
                {
                    case ActionUserAccessEnum.Default:
                        break;
                    case ActionUserAccessEnum.Index:
                        {

                            if (objUserAccessViewModel.ViewPermission == true)
                            {
                                isVisible = true;
                            }


                            break;
                        }
                    case ActionUserAccessEnum.Details:
                        {
                            if (objUserAccessViewModel.ViewPermission == true)
                            {

                                isVisible = true;
                            }
                            break;
                        }
                    case ActionUserAccessEnum.Create:
                        {
                            if (objUserAccessViewModel.AddPermission == true)
                            {

                                isVisible = true;
                            }
                            break;
                        }
                    case ActionUserAccessEnum.Edit:
                        {
                            if (objUserAccessViewModel.EditPermission == true)
                            {

                                isVisible = true;
                            }
                            break;
                        }
                    case ActionUserAccessEnum.Delete:
                        {
                            if (objUserAccessViewModel.DeletePermission == true)
                            {
                                isVisible = true;
                            }
                            break;
                        }
                    case ActionUserAccessEnum.AdminOnly:
                        {
                            if (SessionWrapper.UserAccount.RoleId == RoleUserDefinedEnum.Admin.GetHashCode())
                            {
                                isVisible = true;
                            }
                            break;
                        }
                    default:
                        break;
                }
            }


            return isVisible;
        }





        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public static bool DeleteFile(String file)
        {
            try
            {
                System.IO.File.SetAttributes(file, FileAttributes.Normal);
                System.IO.File.Delete(file);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
