using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using LIS.DAL;
using SubSonic;

namespace Lis.LoadData
{
    public class PreloadedLists
    {
        public static DataTable TestType;
        public static DataTable DataControl;
        public static DataTable Device;
        public static DataTable AssemblyReport;
        public static DataTable UserControlRelation;
        public static DataTable FormControl;
        public static DataTable StandardTest;
        public static DataTable TestGroupRelation, TestGroupList;

        static PreloadedLists()
        {
            try
            {
                TestGroupRelation = new Select(TTestgroupList.Schema.Name + ".*", TTestgroupDtl.Columns.TestDataId).From(TTestgroupList.Schema.Name).
                                LeftOuterJoin(TTestgroupDtl.TestGroupIdColumn, TTestgroupList.TestGroupIdColumn).
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