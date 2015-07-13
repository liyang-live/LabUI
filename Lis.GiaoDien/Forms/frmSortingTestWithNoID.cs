using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VNS.Libs;
using LIS.DAL;
using SubSonic;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class frmSortingTestWithNoID : Form
    {
        private DataTable dtPatient, dtTestInfo;

        public frmSortingTestWithNoID()
        {
            InitializeComponent();
        }

        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            try
            {
                dtPatient = new Select(LPatientInfo.Schema.Name + ".*,(dbo.PatientSex(L_Patient_Info.Sex)) AS SexName," +
                                       "(Select Top 1 tti.Barcode From T_Test_Info tti Where tti.Patient_ID = Patient_ID) as Barcode").
                    From(LPatientInfo.Schema.Name).Where(LPatientInfo.Columns.Dateupdate).
                    IsBetweenAnd(dtpPatient.Value.Date,dtpPatient.Value.Date.AddDays(1).AddMilliseconds(-10)).
                    ExecuteDataSet().Tables[0];
                grdPatients.DataSource = dtPatient;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void btnSearchTest_Click(object sender, EventArgs e)
        {
            try
            {
                dtTestInfo = new Select(LPatientInfo.Schema.Name + ".*,(dbo.PatientSex(L_Patient_Info.Sex)) AS SexName",
                                       TTestInfo.Columns.Barcode, TTestTypeList.Columns.TestTypeName,TTestInfo.Columns.TestId).
                    From(TTestInfo.Schema.Name).LeftOuterJoin(LPatientInfo.PatientIdColumn, TTestInfo.PatientIdColumn).
                    LeftOuterJoin(TTestTypeList.TestTypeIdColumn, TTestInfo.TestTypeIdColumn).Where(LPatientInfo.Columns.Dateupdate).
                    IsBetweenAnd(dtpPatient.Value.Date, dtpPatient.Value.Date.AddDays(1).AddMilliseconds(-10)).
                    ExecuteDataSet().Tables[0];
                grdTestInfo.DataSource = dtTestInfo;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void frmSortingTestWithNoID_Load(object sender, EventArgs e)
        {
            btnSearchPatient.PerformClick();
            btnSearchTest.PerformClick();
        }

        private void frmSortingTestWithNoID_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                    case Keys.F3:
                    btnSearchPatient.PerformClick();
                    break;
                    case Keys.F4:
                    btnSearchTest.PerformClick();
                    break;
                    case Keys.Escape:
                   Dispose();
                    break;
            }
        }

        private void grdTestInfo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grdPatients.CurrentRow == null || grdTestInfo.CurrentRow == null) return;
                if (Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID")) == Utility.Int32Dbnull(grdTestInfo.GetValue("Patient_ID")))
                {
                    Utility.ShowMsg("Trùng bệnh nhân");
                    return;
                }
                if (Utility.AcceptQuestion(string.Format("Chuyển xét nghiệm {0} với Barcode {1} \n sang bệnh nhân {2}",Utility.sDbnull(grdTestInfo.GetValue("TestType_Name")),
                    Utility.sDbnull(grdTestInfo.GetValue("Barcode")),
                    Utility.sDbnull(grdPatients.GetValue("Patient_Name"))
                    ),"Thông báo",true))
                {
                    Int32 vPatientID = Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"));
                    Int32 vTestID = Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"));
                    new Update(TTestInfo.Schema.Name).Set(TTestInfo.Columns.PatientId).EqualTo(vPatientID).
                        Where(TTestInfo.Columns.TestId).IsEqualTo(vTestID).
                        Execute();
                    new Update(TResultDetail.Schema.Name).Set(TResultDetail.Columns.PatientId).EqualTo(vPatientID).
                        Where(TTestInfo.Columns.TestId).IsEqualTo(vTestID).
                        Execute();

                    grdTestInfo.CurrentRow.Cells["Patient_Name"].Value = grdPatients.CurrentRow.Cells["Patient_Name"].Value;
                    grdTestInfo.CurrentRow.Cells["Year_Birth"].Value = grdPatients.CurrentRow.Cells["Year_Birth"].Value;
                    grdTestInfo.CurrentRow.Cells["SexName"].Value = grdPatients.CurrentRow.Cells["SexName"].Value;
                    grdTestInfo.CurrentRow.Cells["Department_Name"].Value = grdPatients.CurrentRow.Cells["Department_Name"].Value;
                    grdTestInfo.CurrentRow.Cells["DateUpdate"].Value = grdPatients.CurrentRow.Cells["DateUpdate"].Value;
                    grdTestInfo.CurrentRow.Cells["Patient_ID"].Value = grdPatients.CurrentRow.Cells["Patient_ID"].Value;
                    grdTestInfo.UpdateData();
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        
    }
}
