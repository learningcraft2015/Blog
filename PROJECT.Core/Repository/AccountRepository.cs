using PROJECT.Core.Helpers;
using PROJECT.Core.Models;
using PROJECT.Core.Models.ViewModels;
using System;
using System.Web.Security;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PROJECT.Core.Repository
{
    public class AccountRepository
    {
        private UserRepository _userRepository;
        private RoleRepository _roleRepository;
        private UserAccessRepository _userAccessRepository;
        public AccountRepository()
        {
            _userRepository = new UserRepository();
            _roleRepository = new RoleRepository();
            _userAccessRepository = new UserAccessRepository();
        }
        public UserAccountModel GetAccountByUser(UserViewModel objEntity)
        {
            UserAccountModel objUserAccount = new UserAccountModel();
            objUserAccount.UserId = objEntity.UserId;
            objUserAccount.RoleId = objEntity.RoleId;
            objUserAccount.RegistrationId = objEntity.RegistrationId;
            objUserAccount.PhotoName = objEntity.PhotoName;
            objUserAccount.UserEmail = objEntity.UserEmail;

            return objUserAccount;
        }
        public bool SetAccountByUser(int userID)
        {
            bool isSuccess = false;
            var userViewModel = new UserViewModel() { UserId = userID };
            var objUserViewModel = _userRepository.Select(UserFlags.SelectByID.GetHashCode(), userViewModel).FirstOrDefault();
            if (objUserViewModel != null)
            {
                SessionWrapper.UserAccount = new AccountRepository().GetAccountByUser(objUserViewModel);
                isSuccess = true;
            }
            return isSuccess;
        }

        public UserViewModel GetUserDetailsforLogin(int flag, UserLoginViewModel objEntity)
        {

            var objUserViewModel = new UserViewModel
            {
                UserEmail = objEntity.UserEmail


            };
            return _userRepository.Select(flag, objUserViewModel).FirstOrDefault();
        }
        public static void Logout()
        {
            FormsAuthentication.SignOut();
            SessionWrapper.UserAccount = null;
        }
        public static int Login(UserViewModel objUserViewModel)
        {
            int isResult = LoginResultEnum.Failure.GetHashCode();
            try
            {
                SessionWrapper.UserAccount = new AccountRepository().GetAccountByUser(objUserViewModel);

                FormsAuthentication.SetAuthCookie(Convert.ToString(objUserViewModel.UserId), false);
                isResult = LoginResultEnum.Success.GetHashCode();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return isResult;
        }


        public List<TextMenuModel> GetRolesForMenus(Int16 parentId)
        {
            List<TextMenuModel> objTextMenuList = new List<TextMenuModel>();

            try
            {
                StringBuilder sbRoleMenus = new StringBuilder();



                List<RoleViewModel> objRoleList = new List<RoleViewModel>();
                objRoleList = _roleRepository.Select(RoleFlags.SelectAll.GetHashCode(), new RoleViewModel());



                foreach (var roleItem in objRoleList)
                {
                    var objTextMenuModel = new TextMenuModel();
                    objTextMenuModel.RoleId = roleItem.RoleId;
                    objTextMenuModel.RoleName = roleItem.RoleName;
                    List<UserAccessViewModel> objUserAccessViewModelList = new List<UserAccessViewModel>();

                    if (sbRoleMenus.Length > 0)
                    {
                        sbRoleMenus.Remove(0, sbRoleMenus.Length);
                    }
                    objUserAccessViewModelList = _userAccessRepository.Select(UserAccessFlags.SelectAllMenuByRoleId.GetHashCode(), roleItem.RoleId, new UserAccessViewModel());


                    foreach (var userAccessItem in objUserAccessViewModelList)
                    {
                        if ((Int16)userAccessItem.ParentId == parentId)
                        {
                            sbRoleMenus.AppendFormat(@"<li><a class='ajax-link' href='/{0}'><i class='{1}'></i>&nbsp;<span>{2}</span></a></li>", userAccessItem.Url, userAccessItem.CssClass, userAccessItem.UserAccessTitle);

                        }

                    }
                    objTextMenuModel.Menu = sbRoleMenus.ToString();
                    objTextMenuList.Add(objTextMenuModel);

                }


            }

            catch (Exception ex)
            {
                throw ex;
            }
            return objTextMenuList;



        }
    }
}
