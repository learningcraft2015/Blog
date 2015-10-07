using Microsoft.Practices.EnterpriseLibrary.Data;
using PROJECT.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using PROJECT.Core.Utility;
using PROJECT.Core.Helpers;


namespace PROJECT.Core.Repository
{
    public class UserAccessRepository : Base
    {
        private const string SPS_USERACCESSVIEWMODELSELECT = "sps_UserAccessViewModelSelect";
        private const string SPS_USERACCESSVIEWMODELMENUSELECT = "sps_UserAccessViewModelMenuSelect";
        private const string SPS_USERACCESSVIEWMODELINSERT = "sps_UserAccessViewModelInsert";
        private const string SPS_USERACCESSVIEWMODELUPDATE = "sps_UserAccessViewModelUpdate";
        private const string SPS_USERACCESSVIEWMODELDELETE = "sps_UserAccessViewModelDelete";

        private const string COLUMN_NAME_USERACCESS_ID = "UserAccessId";
        private const string COLUMN_NAME_PARENT_ID = "ParentId";
        private const string COLUMN_NAME_ROLE_ID = "RoleId";
        private const string COLUMN_NAME_USERACCESS_TITLE = "UserAccessTitle";

        private const string COLUMN_NAME_URL = "Url";
        private const string COLUMN_NAME_CSSCLASS = "CssClass";


        private const string COLUMN_NAME_USERACCESS_STATUS = "UserAccessStatus";
        private const string COLUMN_NAME_SORT_ORDER = "SortOrder";
        private const string COLUMN_NAME_CREATED_DATE = "CreatedDate";
        private const string COLUMN_NAME_CREATED_BY = "CreatedBy";
        private const string COLUMN_NAME_MODIFIED_DATE = "ModifiedDate";
        private const string COLUMN_NAME_MODIFIED_BY = "ModifiedBy";

        private const string COLUMN_NAME_ADDPERMISSION = "AddPermission";
        private const string COLUMN_NAME_EDITPERMISSION = "EditPermission";
        private const string COLUMN_NAME_VIEWPERMISSION = "ViewPermission";
        private const string COLUMN_NAME_DELETEPERMISSION = "DeletePermission";


        private const string COLUMN_NAME_RESULT = "Result";
        private const string COLUMN_NAME_FLAG = "Flag";

        public UserAccessViewModel Insert(UserAccessViewModel objEntity)
        {


            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_USERACCESSVIEWMODELINSERT))
                {



                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_PARENT_ID, DbType.Int16, objEntity.ParentId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_USERACCESS_TITLE, DbType.String, objEntity.UserAccessTitle);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_URL, DbType.String, objEntity.Url);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CSSCLASS, DbType.String, objEntity.CssClass);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_SORT_ORDER, DbType.Int16, objEntity.SortOrder);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_USERACCESS_STATUS, DbType.Int16, objEntity.UserAccessStatus);


                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CREATED_BY, DbType.Int32, objEntity.CreatedBy);

                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_USERACCESS_ID, DbType.Int16, objEntity.UserAccessId);
                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, objEntity.Result);

                    objDB.ExecuteNonQuery(sprocCmd);

                    objEntity.UserAccessId = Convert.ToInt16(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_USERACCESS_ID));
                    objEntity.Result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_RESULT));
                }
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
        public List<UserAccessViewModel> Select(int Flag, UserAccessViewModel objEntity)
        {
            var objEntityList = new List<UserAccessViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_USERACCESSVIEWMODELSELECT))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_USERACCESS_ID, DbType.Int32, objEntity.UserAccessId);


                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new UserAccessViewModel();


                            objEntityViewModel.UserAccessId = reader.GetColumnValue<Int16>(COLUMN_NAME_USERACCESS_ID);
                            objEntityViewModel.ParentId = (UserAccessParentIdEnum)reader.GetColumnValue<Int16>(COLUMN_NAME_PARENT_ID);
                            objEntityViewModel.UserAccessTitle = reader.GetColumnValue<String>(COLUMN_NAME_USERACCESS_TITLE);
                            objEntityViewModel.Url = reader.GetColumnValue<String>(COLUMN_NAME_URL);
                            objEntityViewModel.CssClass = reader.GetColumnValue<String>(COLUMN_NAME_CSSCLASS);




                            objEntityViewModel.UserAccessStatus = (StatusEnum)reader.GetColumnValue<Int16>(COLUMN_NAME_USERACCESS_STATUS);

                            objEntityViewModel.SortOrder = reader.GetColumnValue<Int16>(COLUMN_NAME_SORT_ORDER);

                            objEntityViewModel.CreatedDate = reader.GetColumnValue<DateTime>(COLUMN_NAME_CREATED_DATE);
                            objEntityViewModel.CreatedBy = reader.GetColumnValue<Int32>(COLUMN_NAME_CREATED_BY);

                            objEntityViewModel.ModifiedDate = reader.GetColumnValue<DateTime>(COLUMN_NAME_MODIFIED_DATE);
                            objEntityViewModel.ModifiedBy = reader.GetColumnValue<Int32>(COLUMN_NAME_MODIFIED_BY);





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

        public List<UserAccessViewModel> Select(int Flag, Int16 RoleId, UserAccessViewModel objEntity)
        {
            var objEntityList = new List<UserAccessViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_USERACCESSVIEWMODELMENUSELECT))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ROLE_ID, DbType.Int32, RoleId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_URL, DbType.String, objEntity.Url);

                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new UserAccessViewModel();


                            objEntityViewModel.UserAccessId = reader.GetColumnValue<Int16>(COLUMN_NAME_USERACCESS_ID);
                            objEntityViewModel.ParentId = (UserAccessParentIdEnum)reader.GetColumnValue<Int16>(COLUMN_NAME_PARENT_ID);
                            objEntityViewModel.UserAccessTitle = reader.GetColumnValue<String>(COLUMN_NAME_USERACCESS_TITLE);
                            objEntityViewModel.Url = reader.GetColumnValue<String>(COLUMN_NAME_URL);
                            objEntityViewModel.CssClass = reader.GetColumnValue<String>(COLUMN_NAME_CSSCLASS);




                            objEntityViewModel.UserAccessStatus = (StatusEnum)reader.GetColumnValue<Int16>(COLUMN_NAME_USERACCESS_STATUS);

                            objEntityViewModel.SortOrder = reader.GetColumnValue<Int16>(COLUMN_NAME_SORT_ORDER);




                            objEntityViewModel.AddPermission = reader.GetColumnValue<bool>(COLUMN_NAME_ADDPERMISSION);
                            objEntityViewModel.EditPermission = reader.GetColumnValue<Boolean>(COLUMN_NAME_EDITPERMISSION);
                            objEntityViewModel.ViewPermission = reader.GetColumnValue<Boolean>(COLUMN_NAME_VIEWPERMISSION);

                            objEntityViewModel.DeletePermission = reader.GetColumnValue<Boolean>(COLUMN_NAME_DELETEPERMISSION);


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



        public UserAccessViewModel Update(int Flag, UserAccessViewModel objEntity)
        {
            try
            {

                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_USERACCESSVIEWMODELUPDATE))
                {

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_PARENT_ID, DbType.Int16, objEntity.ParentId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_USERACCESS_TITLE, DbType.String, objEntity.UserAccessTitle);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_URL, DbType.String, objEntity.Url);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CSSCLASS, DbType.String, objEntity.CssClass);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_SORT_ORDER, DbType.Int16, objEntity.SortOrder);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_USERACCESS_STATUS, DbType.Int16, objEntity.UserAccessStatus);

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_USERACCESS_ID, DbType.Int16, objEntity.UserAccessId);







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
        //public UserAccessViewModel Insert(UserAccessViewModel objEntity)
        //{


        //    try
        //    {
        //        Database objDB = base.GetDatabase();
        //        // Create a suitable command type and add the required parameter.
        //        using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_UserAccessVIEWMODELINSERT))
        //        {


        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_UserAccess_NAME, DbType.String, objEntity.UserAccessName);
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_SHORT_NAME, DbType.String, objEntity.ShortName);
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_UserAccess_STATUS, DbType.Int16, objEntity.UserAccessStatus);
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_SORT_ORDER, DbType.Int16, objEntity.SortOrder);



        //            objDB.AddOutParameter(sprocCmd, COLUMN_NAME_CREATED_BY, DbType.Int32, objEntity.CreatedBy);


        //            objDB.AddOutParameter(sprocCmd, COLUMN_NAME_UserAccess_ID, DbType.Int32, objEntity.UserAccessId);
        //            objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, objEntity.Result);
        //            objDB.ExecuteNonQuery(sprocCmd);
        //            objEntity.UserAccessId = Convert.ToInt16(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_UserAccess_ID));
        //            objEntity.Result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_RESULT));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //    }
        //    return objEntity;
        //}
        //public int Delete(int Flag, UserAccessViewModel objEntity)
        //{
        //    int result = 0;
        //    try
        //    {
        //        Database objDB = base.GetDatabase();
        //        // Create a suitable command type and add the required parameter.
        //        using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_UserAccessVIEWMODELDELETE))
        //        {
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_UserAccess_ID, DbType.Int32, objEntity.UserAccessId);
        //            objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, result);
        //            objDB.ExecuteNonQuery(sprocCmd);
        //            result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_RESULT));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //    }
        //    return result;
        //}
    }
}
