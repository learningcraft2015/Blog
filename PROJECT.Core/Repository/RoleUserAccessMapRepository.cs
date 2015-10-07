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
    public class RoleUserAccessMapRepository : Base
    {
        private const string SPS_ROLEUSERACCESSMAPVIEWMODELSELECT = "sps_RoleUserAccessMapViewModelSelect";
        private const string SPS_ROLEUSERACCESSMAPVIEWMODELINSERT = "sps_RoleUserAccessMapViewModelInsert";
        private const string SPS_ROLEUSERACCESSMAPVIEWMODELUPDATE = "sps_RoleUserAccessMapViewModelUpdate";
        private const string SPS_ROLEUSERACCESSMAPVIEWMODELDELETE = "sps_RoleUserAccessMapViewModelDelete";

        private const string COLUMN_NAME_USERACCESS_ID = "UserAccessId";
        private const string COLUMN_NAME_ROLE_ID = "RoleId";
        private const string COLUMN_NAME_USERACCESS_TITLE = "UserAccessTitle";

        private const string COLUMN_NAME_SELECTEDROLEUSERACCESSMAPXML = "SelectedRoleUserAccessMapXML";

        private const string COLUMN_NAME_ADDPERMISSION = "AddPermission";
        private const string COLUMN_NAME_EDITPERMISSION = "EditPermission";

        private const string COLUMN_NAME_VIEWPERMISSION = "ViewPermission";

        private const string COLUMN_NAME_DELETEPERMISSION = "DeletePermission";

        private const string COLUMN_NAME_RESULT = "Result";
        private const string COLUMN_NAME_FLAG = "Flag";

        public List<RoleUserAccessMapViewModel> Select(int Flag, RoleUserAccessMapViewModel objEntity)
        {
            var objEntityList = new List<RoleUserAccessMapViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_ROLEUSERACCESSMAPVIEWMODELSELECT))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_USERACCESS_ID, DbType.Int16, objEntity.UserAccessId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ROLE_ID, DbType.Int16, objEntity.RoleId);

                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new RoleUserAccessMapViewModel();


                            objEntityViewModel.UserAccessId = reader.GetColumnValue<Int16>(COLUMN_NAME_USERACCESS_ID);
                            //objEntityViewModel.RoleId = reader.GetColumnValue<Int16>(COLUMN_NAME_ROLE_ID);

                            objEntityViewModel.UserAccessTitle = reader.GetColumnValue<string>(COLUMN_NAME_USERACCESS_TITLE);
                            objEntityViewModel.AddPermission = reader.GetColumnValue<Boolean>(COLUMN_NAME_ADDPERMISSION);
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
        //public RoleUserAccessMapViewModel Edit(int Flag, RoleUserAccessMapViewModel objEntity)
        //{
        //    try
        //    {

        //        Database objDB = base.GetDatabase();
        //        // Create a suitable command type and add the required parameter.
        //        using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_RoleUserAccessMapVIEWMODELUPDATE))
        //        {
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_RoleUserAccessMap_ID, DbType.Int32, objEntity.RoleUserAccessMapId);
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_RoleUserAccessMap_NAME, DbType.String, objEntity.RoleUserAccessMapName);
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_SHORT_NAME, DbType.String, objEntity.ShortName);
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_RoleUserAccessMap_STATUS, DbType.Int32, objEntity.RoleUserAccessMapStatus);
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_SORT_ORDER, DbType.Int16, objEntity.SortOrder);

        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_MODIFIED_DATE, DbType.DateTime, objEntity.ModifiedDate);
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_MODIFIED_BY, DbType.Int32, objEntity.ModifiedBy);



        //            objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, objEntity.Result);
        //            objDB.ExecuteNonQuery(sprocCmd);
        //            objEntity.Result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_RESULT));
        //        }
        //        //
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
        public RoleUserAccessMapViewModel Insert(RoleUserAccessMapViewModel objEntity)
        {


            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_ROLEUSERACCESSMAPVIEWMODELINSERT))
                {

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ROLE_ID, DbType.Int32, objEntity.RoleId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_SELECTEDROLEUSERACCESSMAPXML, DbType.Xml, objEntity.SelectedRoleUserAccessMap);

                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, objEntity.Result);
                    objDB.ExecuteNonQuery(sprocCmd);

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
        //public int Delete(int Flag, RoleUserAccessMapViewModel objEntity)
        //{
        //    int result = 0;
        //    try
        //    {
        //        Database objDB = base.GetDatabase();
        //        // Create a suitable command type and add the required parameter.
        //        using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_RoleUserAccessMapVIEWMODELDELETE))
        //        {
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);
        //            objDB.AddInParameter(sprocCmd, COLUMN_NAME_RoleUserAccessMap_ID, DbType.Int32, objEntity.RoleUserAccessMapId);
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
