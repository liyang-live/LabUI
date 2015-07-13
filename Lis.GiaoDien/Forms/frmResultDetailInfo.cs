using System;
using System.Data;
using System.Windows.Forms;
using SubSonic;
using VNS.Libs;
using LIS.DAL;

namespace Vietbait.Lablink.TestInformation.UI.Forms
{
    public partial class frmResultDetailInfo : Form
    {
        //public DataRow drResultDetail;
        public action vAction = action.doNothing;
        public Janus.Windows.GridEX.GridEX grdResultDetail = new Janus.Windows.GridEX.GridEX();
        public DataTable m_dtResultDetail;
        public int vTestID;

        public frmResultDetailInfo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DataValid())
                {
                    return;
                }
                if (vAction==action.Insert)
                {
                    DataRow dr = m_dtResultDetail.NewRow();
                    dr[TResultDetail.Columns.TestDetailId] = -1;
                    dr[TResultDetail.Columns.TestId] = vTestID;
                    m_dtResultDetail.Rows.InsertAt(dr,0);
                    m_dtResultDetail.AcceptChanges();
                    grdResultDetail.MoveFirst();
                    //dr[TResultDetail.Columns.TestId] = Utility.Int32Dbnull(grdTestInfo.GetValue("Test_ID"));
                    //dr[TResultDetail.Columns.PatientId] = Utility.Int32Dbnull(grdPatients.GetValue("Patient_ID"));
                    //dr[TResultDetail.Columns.TestTypeId] = Utility.Int32Dbnull(grdTestInfo.GetValue("TestType_ID"));
                    //dr[TResultDetail.Columns.Barcode] = Utility.sDbnull(grdTestInfo.GetValue("Barcode"));
                }
                //drResultDetail[TResultDetail.Columns.ParaName] = txtPara_Name.Text;
                //drResultDetail[TResultDetail.Columns.NormalLevel] = txtNormal_Level.Text;
                //drResultDetail[TResultDetail.Columns.NormalLevelW] = txtNormal_LevelW.Text;
                //drResultDetail[TResultDetail.Columns.MeasureUnit] = txtMeasure_Unit.Text;
                //drResultDetail[TResultDetail.Columns.TestResult] = txtTest_Result.Text;
                //drResultDetail[TResultDetail.Columns.Note] = txtNote.Text;
                //drResultDetail[TResultDetail.Columns.DataSequence] = Utility.Int32Dbnull(txtSequence.Value);

                grdResultDetail.CurrentRow.Cells[TResultDetail.Columns.ParaName].Value = txtPara_Name.Text;
                grdResultDetail.CurrentRow.Cells[TResultDetail.Columns.NormalLevel].Value = txtNormal_Level.Text;
                grdResultDetail.CurrentRow.Cells[TResultDetail.Columns.NormalLevelW].Value = txtNormal_LevelW.Text;
                grdResultDetail.CurrentRow.Cells[TResultDetail.Columns.MeasureUnit].Value = txtMeasure_Unit.Text;
                grdResultDetail.CurrentRow.Cells[TResultDetail.Columns.TestResult].Value = txtTest_Result.Text;
                grdResultDetail.CurrentRow.Cells[TResultDetail.Columns.Note].Value = txtNote.Text;
                grdResultDetail.CurrentRow.Cells[TResultDetail.Columns.DataSequence].Value = Utility.Int32Dbnull(txtSequence.Value);
                vAction = action.ConfirmData; 
                Dispose();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private bool DataValid()
        {
            try
            {
                if (string.IsNullOrEmpty(txtPara_Name.Text))
                {
                    Utility.ShowMsg("Tên thông số không được để trắng");
                    txtPara_Name.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtTest_Result.Text))
                {
                    Utility.ShowMsg("Kết quả không được để trắng");
                    txtTest_Result.Focus();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                return false;
            }
        }

        private void frmResultDetailInfo_Load(object sender, EventArgs e)
        {
            switch (Utility.Int32Dbnull(grdResultDetail.GetValue(TResultDetail.Columns.TestDetailId), -1))
            {
                case -1:
                    Text = "THÊM THÔNG TIN KẾT QUẢ";
                    break;
                default:
                    Text = "CẬP NHẬT THÔNG TIN KẾT QUẢ";
                    break;
            }
            if (vAction != action.Insert)
            {
                txtPara_Name.Text = Utility.sDbnull(grdResultDetail.GetValue(TResultDetail.Columns.ParaName));
                txtNormal_Level.Text = Utility.sDbnull(grdResultDetail.GetValue(TResultDetail.Columns.NormalLevel));
                txtNormal_LevelW.Text = Utility.sDbnull(grdResultDetail.GetValue(TResultDetail.Columns.NormalLevelW));
                txtMeasure_Unit.Text = Utility.sDbnull(grdResultDetail.GetValue(TResultDetail.Columns.MeasureUnit));
                txtTest_Result.Text = Utility.sDbnull(grdResultDetail.GetValue(TResultDetail.Columns.TestResult));
                txtNote.Text = Utility.sDbnull(grdResultDetail.GetValue(TResultDetail.Columns.Note));
                txtSequence.Value = Utility.Int32Dbnull(grdResultDetail.GetValue(TResultDetail.Columns.DataSequence), 100);    
            }
            
        }

        private void frmResultDetailInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                btnSave.PerformClick();
            else if (e.KeyCode == Keys.Escape) Dispose();
        }
    }
}