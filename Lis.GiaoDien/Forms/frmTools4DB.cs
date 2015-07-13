using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VNS.Libs;
using SubSonic;
using LIS.DAL;

namespace Vietbait.TestInformation.UI
{
    public partial class frmTools4DB : Form
    {
        private DataTable dtTestInfo,dtResultDetail;

        public frmTools4DB()
        {
            InitializeComponent();
        }

        private void frmTools4DB_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    btnSearch .PerformClick();
                    break;
                case Keys.Escape:
                    btnExit.PerformClick();
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                dtTestInfo =
                    new Select(TTestInfo.Schema.Name + ".*","(YEAR(GETDATE()) - " + LPatientInfo.Columns.YearBirth + " +1) AS Age",
                               LPatientInfo.Columns.PatientName,TTestTypeList.Columns.TestTypeName).From(TTestInfo.Schema.Name).InnerJoin(
                                   LPatientInfo.PatientIdColumn, TTestInfo.PatientIdColumn).InnerJoin(
                                       TTestTypeList.TestTypeIdColumn, TTestInfo.TestTypeIdColumn).Where(
                                           TTestInfo.Columns.Barcode).Like("%" + txtBarcode.Text + "%").
                        And(TTestInfo.Columns.TestDate).IsBetweenAnd(dtpDateFrom.Value.Date,dtpDateTo.Value.AddDays(1).AddSeconds(-1)).
                        ExecuteDataSet().Tables[0];
                
                grdTestInfo.DataSource = dtTestInfo;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void frmTools4DB_Load(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }

        private void grdTestInfo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    DeleteAllTestId(Utility.Int32Dbnull(grdTestInfo.GetValue(TTestInfo.Columns.TestId), -1));
                    break;
                    
            }
        }

        private void DeleteAllTestId( Int32 Test_ID)
        {
            try
            {
                if (!Utility.AcceptQuestion("Thực hiện xóa","Thông báo",true)) return;

                Query myQuery;

                myQuery = TResultDetail.CreateQuery().WHERE(TTestInfo.Columns.TestId,Test_ID);
                myQuery.QueryType = QueryType.Delete;
                myQuery.Execute();

                myQuery = TTestInfo.CreateQuery().WHERE(TTestInfo.Columns.TestId, Test_ID);
                myQuery.QueryType = QueryType.Delete;
                myQuery.Execute();

                grdTestInfo.CurrentRow.Delete();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void grdTestInfo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dtResultDetail =
                    new Select().From(TResultDetail.Schema.Name).Where(TResultDetail.Columns.TestId).IsEqualTo(
                        Utility.Int32Dbnull(grdTestInfo.GetValue(TTestInfo.Columns.TestId), -1)).ExecuteDataSet().
                        Tables[0];
                grdResultDetail.DataSource = dtResultDetail;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }
    }
}
