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
    public class RoleRepository : Base
    {
        private const string SPS_ROLEVIEWMODELSELECT = "sps_RoleViewModelSelect";
        private const string SPS_ROLEVIEWMODELINSERT = "sps_RoleViewModelInsert";
        private const string SPS_ROLEVIEWMODELUPDATE = "sps_RoleViewModelUpdate";
        private const string SPS_ROLEVIEWMODELDELETE = "sps_RoleViewModelDelete";

        private const string COLUMN_NAME_ROLE_ID = "RoleId";
        private const string COLUMN_NAME_ROLE_NAME = "RoleName";
        private const string COLUMN_NAME_SHORT_NAME = "ShortName";
        private const string COLUMN_NAME_ROLE_STATUS = "RoleStatus";

        private const string COLUMN_NAME_SORT_ORDER = "SortOrder";

        private const string COLUMN_NAME_CREATED_DATE = "CreatedDate";
        private const string COLUMN_NAME_CREATED_BY = "CreatedBy";
        private const string COLUMN_NAME_MODIFIED_DATE = "ModifiedDate";
        private const string COLUMN_NAME_MODIFIED_BY = "ModifiedBy";




        private const string COLUMN_NAME_RESULT = "Result";
        private const string COLUMN_NAME_FLAG = "Flag";

        public List<RoleViewModel> Select(int Flag, RoleViewModel objEntity)
        {
            var objEntityList = new List<RoleViewModel>();
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_ROLEVIEWMODELSELECT))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ROLE_ID, DbType.Int32, objEntity.RoleId);

                    using (IDataReader reader = objDB.ExecuteReader(sprocCmd))
                    {
                        while (reader.Read())
                        {
                            var objEntityViewModel = new RoleViewModel();


                            objEntityViewModel.RoleId = reader.GetColumnValue<Int16>(COLUMN_NAME_ROLE_ID);
                            objEntityViewModel.RoleName = reader.GetColumnValue<string>(COLUMN_NAME_ROLE_NAME);
                            objEntityViewModel.ShortName = reader.GetColumnValue<string>(COLUMN_NAME_SHORT_NAME);

                            objEntityViewModel.RoleStatus = (StatusEnum)reader.GetColumnValue<Int16>(COLUMN_NAME_ROLE_STATUS);

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
        public RoleViewModel Update(int Flag, RoleViewModel objEntity)
        {
            try
            {

                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_ROLEVIEWMODELUPDATE))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ROLE_ID, DbType.Int32, objEntity.RoleId);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ROLE_NAME, DbType.String, objEntity.RoleName);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_SHORT_NAME, DbType.String, objEntity.ShortName);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ROLE_STATUS, DbType.Int32, objEntity.RoleStatus);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_SORT_ORDER, DbType.Int16, objEntity.SortOrder);

                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_MODIFIED_DATE, DbType.DateTime, objEntity.ModifiedDate);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_MODIFIED_BY, DbType.Int32, objEntity.ModifiedBy);



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
        public RoleViewModel Insert(RoleViewModel objEntity)
        {


            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_ROLEVIEWMODELINSERT))
                {


                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ROLE_NAME, DbType.String, objEntity.RoleName);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_SHORT_NAME, DbType.String, objEntity.ShortName);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ROLE_STATUS, DbType.Int16, objEntity.RoleStatus);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_SORT_ORDER, DbType.Int16, objEntity.SortOrder);



                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_CREATED_BY, DbType.Int32, objEntity.CreatedBy);


                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_ROLE_ID, DbType.Int32, objEntity.RoleId);
                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, objEntity.Result);
                    objDB.ExecuteNonQuery(sprocCmd);
                    objEntity.RoleId = Convert.ToInt16(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_ROLE_ID));
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
        public int Delete(int Flag, RoleViewModel objEntity)
        {
            int result = 0;
            try
            {
                Database objDB = base.GetDatabase();
                // Create a suitable command type and add the required parameter.
                using (DbCommand sprocCmd = objDB.GetStoredProcCommand(SPS_ROLEVIEWMODELDELETE))
                {
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_FLAG, DbType.Int32, Flag);
                    objDB.AddInParameter(sprocCmd, COLUMN_NAME_ROLE_ID, DbType.Int32, objEntity.RoleId);
                    objDB.AddOutParameter(sprocCmd, COLUMN_NAME_RESULT, DbType.Int32, result);
                    objDB.ExecuteNonQuery(sprocCmd);
                    result = Convert.ToInt32(objDB.GetParameterValue(sprocCmd, COLUMN_NAME_RESULT));
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
    }
}
