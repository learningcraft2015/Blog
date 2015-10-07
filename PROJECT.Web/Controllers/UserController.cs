using PROJECT.Core.Filters;
using PROJECT.Core.Helpers;
using PROJECT.Core.Models.ViewModels;
using PROJECT.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcFlashMessages;
using PROJECT.Core.Models;
using System.Text;
using System.IO;

namespace PROJECT.Web.Controllers
{


    public class UserController : BaseController
    {





        #region UserSection

        public ActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        public ActionResult UnAuthorized()
        {
            this.Flash("Error", "UnAuthorized User");
            return View();
        }
        [UserAuthorized(ActionAccess = ActionUserAccessEnum.Default)]
        public ActionResult Dashboard()
        {
            return View();
        }

        [UserAuthorized(ActionAccess = ActionUserAccessEnum.Default)]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [UserAuthorized(ActionAccess = ActionUserAccessEnum.Default)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(UserChangePasswordViewModel objEntity)
        {
            int result = 0;
            UserRepository objUserRepository = new UserRepository();
            if (ModelState.IsValid)
            {

                objEntity.NewPassword = objEntity.NewPassword.Trim();
                objEntity.OldPassword = objEntity.OldPassword.Trim();
                objEntity.UserEmail = SessionWrapper.UserAccount.UserEmail;

                result = ValidateUserChangePassword(objEntity);


                if (result == ResultFlags.Success.GetHashCode())
                {
                    this.Flash("Success", "Password updated successfully");


                    AccountRepository.Logout();
                    return RedirectToAction("Login", "User");


                }
                else if (result == ResultFlags.Failure.GetHashCode())
                {
                    this.Flash("Error", "Password failed to update");


                }
                else if (result == ResultFlags.OldPasswordMismatch.GetHashCode())
                {
                    this.Flash("Warning", "Old password and new password cannot be same");


                }


            }
            return View(objEntity);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginViewModel objEntity)
        {

            if (ModelState.IsValid)
            {
                objEntity.UserEmail = objEntity.UserEmail.Trim();
                objEntity.Password = objEntity.Password.Trim();

                if (ValidateUser(objEntity) == LoginResultEnum.Success.GetHashCode())
                {
                    return RedirectToAction("Dashboard", "User");

                }
                else if (ValidateUser(objEntity) == LoginResultEnum.Unauthorized.GetHashCode())
                {
                    this.Flash("Error", "Unauthorized access to user accounts");
                }

                else
                {
                    this.Flash("Error", "We didn't recognize the username or password you entered. Please try again");


                }

            }
            return View(objEntity);
        }


        private int ValidateUserChangePassword(UserChangePasswordViewModel objEntity)
        {
            int result = 0;
            AccountRepository objAccountRepository = new AccountRepository();
            var objUserRepository = new UserRepository();
            var objLoginUserViewModel = objAccountRepository.GetUserDetailsforLogin(UserFlags.UserSignIn.GetHashCode(), new UserLoginViewModel() { UserEmail = objEntity.UserEmail });

            if (objLoginUserViewModel != null)
            {
                if (PasswordHelpers.Validate(objLoginUserViewModel.Password, objLoginUserViewModel.PasswordSalt, objEntity.NewPassword))
                {
                    result = ResultFlags.OldPasswordMismatch.GetHashCode();

                }
                else
                {
                    PasswordHelpers.HashedPassword objHashedPassword = PasswordHelpers.Generate(objEntity.NewPassword);
                    var objNewUserViewModel = new UserViewModel()
                     {
                         UserId = SessionWrapper.UserAccount.UserId,
                         UserEmail = SessionWrapper.UserAccount.UserEmail,
                         PasswordSalt = objHashedPassword.Salt,
                         Password = objHashedPassword.Password
                     };



                    objNewUserViewModel = objUserRepository.Update(UserFlags.UpdatePasswordByID.GetHashCode(), objNewUserViewModel);
                    result = objNewUserViewModel.Result;


                }


            }


            return result;

        }
        private int ValidateUser(UserLoginViewModel objEntity)
        {
            int isResult = LoginResultEnum.Failure.GetHashCode();
            AccountRepository objAccountRepository = new AccountRepository();
            var objUserViewModel = objAccountRepository.GetUserDetailsforLogin(UserFlags.UserSignIn.GetHashCode(), objEntity);
            if (objUserViewModel != null)
            {
                if (objUserViewModel.RoleId != RoleUserDefinedEnum.Admin.GetHashCode())
                {


                    if (PasswordHelpers.Validate(objUserViewModel.Password, objUserViewModel.PasswordSalt, objEntity.Password))
                    {
                        isResult = AccountRepository.Login(objUserViewModel);

                    }
                }
                else
                {
                    isResult = LoginResultEnum.Unauthorized.GetHashCode();
                }


            }


            return isResult;

        }


        [UserAuthorized(ActionAccess = ActionUserAccessEnum.Default)]
        public ActionResult Logout()
        {

            AccountRepository.Logout();
            return RedirectToAction("Index", "Home");
        }


        #endregion



        /// <summary>
        /// Registration Section
        /// </summary>
        /// <returns></returns>
        #region RegistrationSection



        public ActionResult Register()
        {

            var objEntity = new RegistrationViewModel();


            objEntity.DateOfBirth = DateTime.Now;
            return View(objEntity);
        }
        [HttpPost]
        public ActionResult Register(RegistrationViewModel objEntity)
        {
            RegistrationRepository objRegistrationRepository = new RegistrationRepository();
            string fileName = string.Empty;

            if (ModelState.IsValid)
            {
                #region FileUpload

                if (objEntity.UploadPhoto != null)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(objEntity.UploadPhoto.FileName);
                    objEntity.PhotoName = fileName;

                }
                else
                {
                    objEntity.PhotoName = string.Empty;
                }



                #endregion

                objEntity.RoleId = (Int16)RoleUserDefinedEnum.User.GetHashCode();


                PasswordHelpers.HashedPassword objHashedPassword = PasswordHelpers.Generate(objEntity.Password);

                objEntity.Password = objHashedPassword.Password;

                objEntity.PasswordSalt = objHashedPassword.Salt;


                objEntity.Status = StatusEnum.Active.GetHashCode();


                objRegistrationRepository.Insert(objEntity);

                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
                    this.Flash("success", "Registration created successfully ");

                    #region FileUpload

                    //file name
                    if (objEntity.PhotoName != null)
                    {
                        string path = Path.Combine(Server.MapPath(ApplicationConstant.UPLOADED_USER_PHOTO_PATH), fileName);
                        // WebImage.Save()
                        objEntity.UploadPhoto.SaveAs(path);
                    }



                    #endregion
                    //return RedirectToAction("Index");
                    return RedirectToAction("Login", "User");

                }
                else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {
                    this.Flash("Error", "Failed to create account");

                    return RedirectToAction("Index");
                }
                else if (objEntity.Result == ResultFlags.Duplicate.GetHashCode())
                {
                    this.Flash("Warning", "It already exist");

                }
            }




            return View(objEntity);
        }


        [UserAuthorized(ActionAccess = ActionUserAccessEnum.Default)]
        public ActionResult MyProfile(int id)
        {
            var objRegistrationRepository = new RegistrationRepository();
            RegistrationViewModel objEntity = null;
            objEntity = objRegistrationRepository.Select(RegistrationFlags.SelectByID.GetHashCode(), new RegistrationViewModel()
            {
                RegistrationId = id
            }).FirstOrDefault();
            if (objEntity == null)
            {
                this.Flash("Error", "Failed to show my profile");

                return RedirectToAction("Index");
            }



            return View(objEntity);
        }

        [UserAuthorized(ActionAccess = ActionUserAccessEnum.Default)]
        public ActionResult ProfileEdit(int id)
        {
            var objRegistrationRepository = new RegistrationRepository();

            var objEntity = new RegistrationViewModel();

            var objUpdateEntity = new RegistrationUpdateViewModel();

            objEntity = objRegistrationRepository.Select(RegistrationFlags.SelectByID.GetHashCode(), new RegistrationViewModel()
            {
                RegistrationId = id
            }).FirstOrDefault();
            if (objEntity == null)
            {
                this.Flash("Error", "Failed to edit profile details");

                return RedirectToAction("Dashboard");
            }



            objUpdateEntity.RegistrationId = objEntity.RegistrationId;
            objUpdateEntity.UserId = objEntity.UserId;
            objUpdateEntity.FirstName = objEntity.FirstName;
            objUpdateEntity.LastName = objEntity.LastName;
            objUpdateEntity.PhotoName = objEntity.PhotoName;

            objUpdateEntity.DateOfBirth = objEntity.DateOfBirth;
            objUpdateEntity.Gender = objEntity.Gender;

            objUpdateEntity.Location = objEntity.Location;
            objUpdateEntity.MobileNumber = objEntity.MobileNumber;


            return View(objUpdateEntity);
        }

        [HttpPost]
        [UserAuthorized(ActionAccess = ActionUserAccessEnum.Default)]

        public ActionResult ProfileEdit(int id, RegistrationUpdateViewModel objUpdateEntity)
        {
            var objRegistrationRepository = new RegistrationRepository();
            string fileName = string.Empty;
            string oldFileName = string.Empty;

            if (ModelState.IsValid)
            {
                #region FileUpload

                if (objUpdateEntity.UploadPhoto != null)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(objUpdateEntity.UploadPhoto.FileName);
                    oldFileName = objUpdateEntity.PhotoName;
                    objUpdateEntity.PhotoName = fileName;
                }


                #endregion
                objUpdateEntity.FirstName = objUpdateEntity.FirstName.Trim();
                objUpdateEntity.LastName = objUpdateEntity.LastName.Trim();
                objUpdateEntity.PhotoName = objUpdateEntity.PhotoName;

                objUpdateEntity.Location = objUpdateEntity.Location.Trim();
                objUpdateEntity.MobileNumber = objUpdateEntity.MobileNumber.Trim();
                objUpdateEntity.RegistrationId = id;

                var objEntity = new RegistrationViewModel()
                {
                    RegistrationId = objUpdateEntity.RegistrationId,
                    UserId = objUpdateEntity.UserId,
                    FirstName = objUpdateEntity.FirstName,
                    LastName = objUpdateEntity.LastName,
                    PhotoName = objUpdateEntity.PhotoName,

                    DateOfBirth = objUpdateEntity.DateOfBirth,
                    Gender = objUpdateEntity.Gender,

                    Location = objUpdateEntity.Location,
                    MobileNumber = objUpdateEntity.MobileNumber
                };

                objEntity = objRegistrationRepository.Update(RegistrationFlags.UpdateByID.GetHashCode(), objEntity);



                if (objEntity.Result == ResultFlags.Success.GetHashCode())
                {
                    #region FileUpload
                    //delete old file



                    //file name
                    if (objUpdateEntity.UploadPhoto != null)
                    {
                        if (!string.IsNullOrEmpty(objUpdateEntity.UploadPhoto.FileName))
                        {
                            ApplicationHelpers.DeleteFile(Path.Combine(Server.MapPath(ApplicationConstant.UPLOADED_USER_PHOTO_PATH), oldFileName));
                        }
                        string path = Path.Combine(Server.MapPath(ApplicationConstant.UPLOADED_USER_PHOTO_PATH), fileName);
                        // WebImage.Save()
                        objUpdateEntity.UploadPhoto.SaveAs(path);
                    }



                    #endregion


                    this.Flash("success", "My Profile updated successfully ");

                    //reload admin profile
                    SessionWrapper.UserAccount = null;
                    AccountRepository objAccountRepository = new AccountRepository();
                    objAccountRepository.SetAccountByUser(objEntity.UserId);

                    return RedirectToAction("Dashboard", "User");
                }
                else if (objEntity.Result == ResultFlags.Failure.GetHashCode())
                {
                    this.Flash("Error", "My Profile failed to update");


                }
                else if (objEntity.Result == ResultFlags.Duplicate.GetHashCode())
                {
                    this.Flash("Warning", "It already exist");


                }
            }



            return View(objUpdateEntity);
        }

        #endregion
    }
}