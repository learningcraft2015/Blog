using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJECT.Core.Utility;

using PROJECT.Core.Repository;
using PROJECT.Core.Models.ViewModels;
using PROJECT.Core.Helpers;



namespace PROJECT.Core.Repository
{
    public class UserRepository : Base
    {

        const string sp_UserViewModelSelect = "sps_UserViewModelSelect";
        const string sp_UserViewModelUpdate = "sps_UserViewModelUpdate";

        const string COLUMN_NAME_USERID = "UserId";
        const string COLUMN_NAME_REGISTRATIONID = "RegistrationId";
        const string COLUMN_NAME_USEREMAIL = "UserEmail";
        const string COLUMN_NAME_PASSWORD = "Password";
        const string COLUMN_NAME_PASSWORDSALT = "PasswordSalt";
        const string COLUMN_NAME_OLDPASSWORD = "OldPassword";
        const string COLUMN_NAME_CREATEDDATE = "CreatedDate";
        const string COLUMN_NAME_USERSTATUS = "UserStatus";
        const string COLUMN_NAME_ROLEID = "RoleId";
        const string COLUMN_NAME_ROLENAME = "RoleName";


        const string COLUMN_NAME_RESULT = "Result";
        const string COLUMN_NAME_FLAG = "Flag";

        const string COLUMN_NAME_PHOTONAME = "PhotoName";
        public List<UserViewModel> Select(int flag, UserViewModel entity)
        {
            var objEntityList = new List<UserViewModel>();

            try
            {


                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(sp_UserViewModelSelect))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, flag);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_USERID, DbType.Int32, entity.UserId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_USEREMAIL, DbType.String, entity.UserEmail);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_PASSWORD, DbType.String, entity.Password);

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ROLEID, DbType.Int32, entity.RoleId);

                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {

                        while (reader.Read())
                        {
                            UserViewModel objEntity = new UserViewModel();

                            objEntity.UserId = reader.GetColumnValue<Int32>(COLUMN_NAME_USERID);
                            objEntity.RegistrationId = reader.GetColumnValue<Int32>(COLUMN_NAME_REGISTRATIONID);
                            objEntity.RoleId = reader.GetColumnValue<Int16>(COLUMN_NAME_ROLEID);
                            objEntity.RoleName = reader.GetColumnValue<String>(COLUMN_NAME_ROLENAME);

                            objEntity.PhotoName = reader.GetColumnValue<String>(COLUMN_NAME_PHOTONAME);


                            objEntity.Password = reader.GetColumnValue<String>(COLUMN_NAME_PASSWORD);
                            objEntity.PasswordSalt = reader.GetColumnValue<String>(COLUMN_NAME_PASSWORDSALT);
                            objEntity.UserEmail = reader.GetColumnValue<String>(COLUMN_NAME_USEREMAIL);
                            objEntity.UserCreatedDate = reader.GetColumnValue<DateTime>(COLUMN_NAME_CREATEDDATE);
                            objEntity.UserStatus = (StatusEnum)reader.GetColumnValue<Int16>(COLUMN_NAME_USERSTATUS);

                            if (objEntity != null)
                            {
                                objEntityList.Add(objEntity);
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return objEntityList;
        }


        public UserViewModel Update(int flag, UserViewModel objEntity)
        {
            try
            {
                //
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(sp_UserViewModelUpdate))
                {

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, flag);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_USERID, DbType.Int32, objEntity.UserId);

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_OLDPASSWORD, DbType.String, objEntity.OldPassword);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_PASSWORDSALT, DbType.String, objEntity.PasswordSalt);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_PASSWORD, DbType.String, objEntity.Password);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ROLEID, DbType.Int16, objEntity.RoleId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_USEREMAIL, DbType.String, objEntity.UserEmail);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_USERSTATUS, DbType.Int16, objEntity.UserStatus);
                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, objEntity.Result);

                    objDB.ExecuteNonQuery(sprocCmd);
                    objEntity.Result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_RESULT));
                }
                //
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return objEntity;
        }
    }
}








