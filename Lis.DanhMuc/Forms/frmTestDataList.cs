using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using SubSonic;
using VNS.Libs;
using LIS.DAL; 

namespace VietBaIT.LABLink.List.UI
{
    public partial class frmTestDataList : Form
    {
        private DataTable dtTestDataList, dtTestType;

        public frmTestDataList()
        {
            InitializeComponent();
        }

        private void frmTestDataList_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTestData();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void LoadTestData()
        {
            dtTestDataList =
                new Select(LStandardTest.Schema.Name + ".*", TTestTypeList.Columns.TestTypeName).From(
                    LStandardTest.Schema.Name).LeftOuterJoin(TTestTypeList.TestTypeIdColumn,
                                                             LStandardTest.TestTypeIdColumn).OrderAsc(
                                                                 LStandardTest.Columns.DataSequence).
                    ExecuteDataSet().Tables[0];
            Utility.SetDataSourceForDataGridEx(grdTestData,dtTestDataList,true,false,"1=1","");
            //grdTestData.DataSource = dtTestDataList;
            //grdTestData.MoveFirst();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                var obj = new frmTestDataList_AU();
                obj.dtTestDataList = dtTestDataList;
                obj.dtTestType = dtTestType;
                obj.vAction = action.Insert;
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void frmTestDataList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                switch (e.KeyCode)
                {
                    case Keys.N:
                        cmdSave.PerformClick();
                        break;
                    case Keys.U:
                        cmdUpdate.PerformClick();
                        break;
                    case Keys.E:
                        grdTestData.GroupMode = GroupMode.Expanded;
                        grdTestData.Refetch();
                        break;
                    case Keys.C:
                        grdTestData.GroupMode = GroupMode.Collapsed;
                        grdTestData.Refetch();
                        break;
                }
            else
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        cmdExit.PerformClick();
                        break;
                    case Keys.Delete:
                        cmdDelete.PerformClick();
                        break;
                }
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdTestData.CurrentRow != null && grdTestData.CurrentRow.RowType == RowType.Record)
                {
                    //if (DDataControl.CreateQuery().WHERE(DDataControl.Columns.TestDataId, Utility.sDbnull(grdTestData.GetValue("TestData_ID"))).GetRecordCount() > 0 |
                    //   TResultDetail.CreateQuery().WHERE(TResultDetail.Columns.TestDataId, Utility.sDbnull(grdTestData.GetValue("TestData_ID"))).GetRecordCount() > 0)
                
                    if (DDataControl.CreateQuery().WHERE(DDataControl.Columns.TestDataId,Utility.sDbnull(grdTestData.GetValue("TestData_ID"))).GetRecordCount() > 0
                        )
                        Utility.ShowMsg(string.Format("{0} đang sử dụng. Không được xóa.",grdTestData.GetValue("TestData_ID")));
                    else
                    if (
                        Utility.AcceptQuestion(
                            string.Format("Xóa {0} của {1}", grdTestData.GetValue("Data_Name"),
                                          grdTestData.GetValue("TestType_Name")), "Thông báo", true))
                    {
                        new Delete().From(LStandardTest.Schema.Name).Where(LStandardTest.Columns.TestDataId).IsEqualTo(
                            grdTestData.GetValue("TestData_ID")).Execute();
                        grdTestData.CurrentRow.Delete();
                        grdTestData.UpdateData();
                        dtTestDataList.AcceptChanges();
                    }
                }
                    
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdTestData.CurrentRow == null || grdTestData.CurrentRow.RowType != RowType.Record) return;
                var obj = new frmTestDataList_AU();
                obj.dtTestDataList = dtTestDataList;
                obj.dtTestType = dtTestType;
                obj.vAction = action.Update;
                obj.drData = Utility.GetDataRow(dtTestDataList, LStandardTest.Columns.TestDataId,grdTestData.GetValue("TestData_ID"));
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdTestData_DoubleClick(object sender, EventArgs e)
        {
            cmdUpdate.PerformClick();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            Stream sw = null;
            try
            {
                var sd = new SaveFileDialog {Filter = "Excel File (*.xls)|*.xls"};
                if (sd.ShowDialog()== DialogResult.OK)
                {
                    sw = new FileStream(sd.FileName,FileMode.OpenOrCreate,FileAccess.ReadWrite);
                    GrdListExporter.Export(sw);
                    MessageBox.Show("Xuất dữ liệu thành công", "Thông Báo", MessageBoxButtons.OK);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi trong quá trình xuất dữ liệu", "Thông Báo", MessageBoxButtons.OK);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

        private void btnQuickReOrder_Click(object sender, EventArgs e)
        {
            string tempTestTypeId = grdTestData.GetValue("TestType_ID").ToString();
            var f = new frmQuickReorderTestSequence();
            f.TestTypeId = tempTestTypeId;
            f.ShowDialog();
            LoadTestData();
        }
    }
}