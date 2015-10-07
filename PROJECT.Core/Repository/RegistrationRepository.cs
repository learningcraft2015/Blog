using PROJECT.Core.Models.ViewModels;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROJECT.Core.Utility;
using PROJECT.Core.Helpers;

namespace PROJECT.Core.Repository
{
    public class RegistrationRepository : Base
    {
        const string SP_RegistrationViewModelInsert = "sps_RegistrationViewModelInsert";
        const string SP_RegistrationViewModelSelect = "sps_RegistrationViewModelSelect";
        const string SP_RegistrationViewModelDelete = "sps_RegistrationViewModelDelete";
        const string SP_RegistrationViewModelUpdate = "sps_RegistrationViewModelUpdate";

        const string PARAM_FLAG = "Flag";
        const string PARAM_REGISTRATIONID = "RegistrationId";
        const string PARAM_USERID = "UserId";
        const string PARAM_ROLEID = "RoleId";
        const string PARAM_FIRSTNAME = "FirstName";
        const string PARAM_LASTNAME = "LastName";
        const string PARAM_PHOTONAME = "PhotoName";

        const string PARAM_DATEOFBIRTH = "DateOfBirth";
        const string PARAM_GENDER = "Gender";

        const string PARAM_COUNTRYID = "CountryId";
        const string PARAM_STATEID = "StateId";

        const string PARAM_LOCATION = "Location";
        const string PARAM_MOBILENUMBER = "MobileNumber";
        const string PARAM_EMAIL = "UserEmail";
        const string PARAM_PASSWORD = "Password";
        const string PARAM_PASSWORDSALT = "PasswordSalt";
        const string PARAM_RESULT = "Result";
        const string PARAM_STATUS = "Status";
        const string COLUMN_NAME_CREATED_DATE = "CreatedDate";
        const string COLUMN_NAME_CREATED_BY = "CreatedBy";


        public RegistrationViewModel Insert(RegistrationViewModel objEntity)
        {


            try
            {
                Database objDB = base.GetDatabase();

                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_RegistrationViewModelInsert))
                {
                    objDB.AddInParameter(sprocCmd, PARAM_USERID, DbType.Int32, objEntity.UserId);
                    objDB.AddInParameter(sprocCmd, PARAM_ROLEID, DbType.Int32, objEntity.RoleId);
                    objDB.AddInParameter(sprocCmd, PARAM_FIRSTNAME, DbType.String, objEntity.FirstName);
                    objDB.AddInParameter(sprocCmd, PARAM_LASTNAME, DbType.String, objEntity.LastName);
                    objDB.AddInParameter(sprocCmd, PARAM_PHOTONAME, DbType.String, objEntity.PhotoName);

                    objDB.AddInParameter(sprocCmd, PARAM_DATEOFBIRTH, DbType.DateTime, objEntity.DateOfBirth);
                    objDB.AddInParameter(sprocCmd, PARAM_GENDER, DbType.Int32, objEntity.Gender.GetHashCode());

                    objDB.AddInParameter(sprocCmd, PARAM_COUNTRYID, DbType.Int32, objEntity.CountryId);
                    objDB.AddInParameter(sprocCmd, PARAM_STATEID, DbType.Int32, objEntity.StateId);


                    objDB.AddInParameter(sprocCmd, PARAM_LOCATION, DbType.String, objEntity.Location);
                    objDB.AddInParameter(sprocCmd, PARAM_EMAIL, DbType.String, objEntity.UserEmail);
                    objDB.AddInParameter(sprocCmd, PARAM_PASSWORD, DbType.String, objEntity.Password);

                    objDB.AddInParameter(sprocCmd, PARAM_PASSWORDSALT, DbType.String, objEntity.PasswordSalt);

                    objDB.AddInParameter(sprocCmd, PARAM_MOBILENUMBER, DbType.String, objEntity.MobileNumber);
                    objDB.AddInParameter(sprocCmd, PARAM_STATUS, DbType.Int32, objEntity.Status);

                    objDB.AddOutParameter(sprocCmd, PARAM_REGISTRATIONID, DbType.Int32, objEntity.RegistrationId);
                    objDB.AddOutParameter(sprocCmd, PARAM_RESULT, DbType.Int32, objEntity.Result);

                    objDB.ExecuteNonQuery(sprocCmd);

                    objEntity.RegistrationId = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, PARAM_REGISTRATIONID));
                    objEntity.Result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, PARAM_RESULT));


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objEntity;
        }

        public List<RegistrationViewModel> Select(int flag, RegistrationViewModel objEntity)
        {
            var objEntityList = new List<RegistrationViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_RegistrationViewModelSelect))
                {
                    objDB.AddInParameter(sprocCmd, PARAM_FLAG, DbType.Int32, flag);
                    objDB.AddInParameter(sprocCmd, PARAM_REGISTRATIONID, DbType.Int32, objEntity.RegistrationId);
                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new RegistrationViewModel();


                            objEntityViewModel.RegistrationId = reader.GetColumnValue<int>(PARAM_REGISTRATIONID);


                            objEntityViewModel.UserId = reader.GetColumnValue<int>(PARAM_USERID);

                            //objEntityViewModel.PasswordSalt = reader.GetColumnValue<String>(PARAM_PASSWORDSALT);

                            objEntityViewModel.RoleId = reader.GetColumnValue<Int16>(PARAM_ROLEID);

                            objEntityViewModel.FirstName = reader.GetColumnValue<String>(PARAM_FIRSTNAME);
                            objEntityViewModel.LastName = reader.GetColumnValue<String>(PARAM_LASTNAME);
                            objEntityViewModel.PhotoName = reader.GetColumnValue<String>(PARAM_PHOTONAME);


                            objEntityViewModel.DateOfBirth = reader.GetColumnValue<DateTime>(PARAM_DATEOFBIRTH);

                            objEntityViewModel.Gender = (GenderEnum)reader.GetColumnValue<Int16>(PARAM_GENDER);

                            objEntityViewModel.CountryId = reader.GetColumnValue<Int32>(PARAM_COUNTRYID);
                            objEntityViewModel.StateId = reader.GetColumnValue<Int32>(PARAM_STATEID);

                            objEntityViewModel.Location = reader.GetColumnValue<String>(PARAM_LOCATION);


                            objEntityViewModel.MobileNumber = reader.GetColumnValue<String>(PARAM_MOBILENUMBER);

                            //objEntityViewModel.UserEmail = reader.GetColumnValue<String>(PARAM_EMAIL);



                            if (objEntityViewModel != null)
                            {
                                objEntityList.Add(objEntityViewModel);
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


        public int Delete(int flag, RegistrationViewModel objEntity)
        {
            int result = 0;
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_RegistrationViewModelDelete))
                {
                    objDB.AddInParameter(sprocCmd, PARAM_FLAG, DbType.Int32, flag);
                    objDB.AddInParameter(sprocCmd, PARAM_REGISTRATIONID, DbType.Int32, objEntity.RegistrationId);
                    objDB.AddOutParameter(sprocCmd, PARAM_RESULT, DbType.Int32, result);
                    objDB.ExecuteNonQuery(sprocCmd);
                    result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, PARAM_RESULT));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return result;
        }


        public RegistrationViewModel Update(int flag, RegistrationViewModel objEntity)
        {
            try
            {
                //
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SP_RegistrationViewModelUpdate))
                {
                    objDB.AddInParameter(sprocCmd, PARAM_FLAG, DbType.Int32, flag);
                    objDB.AddInParameter(sprocCmd, PARAM_REGISTRATIONID, DbType.Int32, objEntity.RegistrationId);

                    objDB.AddInParameter(sprocCmd, PARAM_USERID, DbType.Int32, objEntity.UserId);
                    objDB.AddInParameter(sprocCmd, PARAM_FIRSTNAME, DbType.String, objEntity.FirstName);
                    objDB.AddInParameter(sprocCmd, PARAM_LASTNAME, DbType.String, objEntity.LastName);
                    objDB.AddInParameter(sprocCmd, PARAM_PHOTONAME, DbType.String, objEntity.PhotoName);


                    objDB.AddInParameter(sprocCmd, PARAM_DATEOFBIRTH, DbType.String, objEntity.DateOfBirth);
                    objDB.AddInParameter(sprocCmd, PARAM_GENDER, DbType.Int32, objEntity.Gender);

                    objDB.AddInParameter(sprocCmd, PARAM_COUNTRYID, DbType.Int32, objEntity.CountryId);
                    objDB.AddInParameter(sprocCmd, PARAM_STATEID, DbType.Int32, objEntity.StateId);

                    objDB.AddInParameter(sprocCmd, PARAM_LOCATION, DbType.String, objEntity.Location);
                    objDB.AddInParameter(sprocCmd, PARAM_MOBILENUMBER, DbType.String, objEntity.MobileNumber);


                    objDB.AddOutParameter(sprocCmd, PARAM_RESULT, DbType.Int32, objEntity.Result);

                    objDB.ExecuteNonQuery(sprocCmd);
                    objEntity.Result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, PARAM_RESULT));
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
