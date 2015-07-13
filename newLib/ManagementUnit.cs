using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LIS.DAL;
using VNS.Libs;
using SubSonic;

namespace VNS.Libs
{
    public class ManagementUnit
    {

        public static DataTable TestType;
        public static DataTable DataControl;
        public static DataTable Device;
        public static DataTable AssemblyReport;
        public static DataTable UserControlRelation;
        public static DataTable FormControl;
        public static DataTable StandardTest;
        public static DataTable TestGroupRelation, TestGroupList;

        private static readonly DataTable dtManagementUnit = GetSystemParametersTable();

        public static string gv_sParentBranchName =Utility.sDbnull(dtManagementUnit.Rows[0][SysManagementUnit.Columns.SParentBranchName]);
        public static string gv_sBranchName =
            Utility.sDbnull(dtManagementUnit.Rows[0][SysManagementUnit.Columns.SName]);
        public static string gv_sAddress =
            Utility.sDbnull(dtManagementUnit.Rows[0][SysManagementUnit.Columns.SAddress]);
        public static string gv_sPhone =
            Utility.sDbnull(dtManagementUnit.Rows[0][SysManagementUnit.Columns.SPhone]);
        public static string gv_sHotPhone =
            Utility.sDbnull(dtManagementUnit.Rows[0][SysManagementUnit.Columns.SHotPhone]);
    

        private static DataTable GetSystemParametersTable()
        {
            try
            {
                return new Select().From(SysManagementUnit.Schema.Name).ExecuteDataSet().Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        static ManagementUnit()
        {
            try
            {
                TestGroupRelation = new Select(TTestgroupList.Schema.Name + ".*", TTestgroupDtl.Columns.TestDataId).From(TTestgroupList.Schema.Name).
                                LeftOuterJoin(TTestgroupDtl.TestGroupIdColumn,TTestgroupList.TestGroupIdColumn).
                                ExecuteDataSet().Tables[0];
                TestGroupList = new Select().From(TTestgroupList.Schema.Name).OrderAsc(TTestgroupList.Columns.TestGroupOrder).ExecuteDataSet().Tables[0];
            }
            catch (Exception)
            {
            }

            try
            {
                StandardTest = new Select().From(LStandardTest.Schema.Name).Where(LStandardTest.Columns.DataView).
                    IsEqualTo(true).OrderAsc(LStandardTest.Columns.DataSequence).ExecuteDataSet().Tables[0];
            }
            catch (Exception)
            {
            }

            try
            {
                UserControlRelation =
                    new Select("*").From(LUserFormControl.Schema.Name).LeftOuterJoin(LFormControl.ControlIdColumn,
                                                                                     LUserFormControl.ControlIdColumn).
                        ExecuteDataSet().Tables[0];
            }
            catch
            {
            }

            try
            {
                FormControl = new Select().From(LFormControl.Schema.Name).ExecuteDataSet().Tables[0];
            }
            catch
            {
            }

            try
            {
                AssemblyReport =
                    new Select().From(LAssemblyReport.Schema.Name).ExecuteDataSet().Tables[0];
            }
            catch
            {
            }

            try
            {
                var myDataSet = SPs.SpGetPreloadedLists().GetDataSet();
                TestType = myDataSet.Tables[0];
                DataControl = myDataSet.Tables[1];
                Device = myDataSet.Tables[2];
            }
            catch
            {
            }
        }
    }
}
