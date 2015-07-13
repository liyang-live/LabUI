using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LIS.DAL;
 using VNS.Libs;
using SubSonic;
namespace VNS.HIS.UI.DANHMUC
{
    public partial class frm_themmoi_baocao : Form
    {
        #region Khai bao bien
        public SysReport objReport;
        public action m_enAct = action.Insert;
        public Janus.Windows.GridEX.GridEX grdList;
        public DataTable dt_data = new DataTable();
      
        #endregion

        public frm_themmoi_baocao()
        {
            InitializeComponent();
            Utility.loadIconToForm(this);
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void GetData()
        {
            try
            {
                if (objReport == null) return;
                txtMa.Text = objReport.MaBaocao;
                cboNhom.SelectedIndex =Utility.GetSelectedIndex(cboNhom, objReport.MaNhom);
                txtTieude.Text = objReport.TieuDe;
                txtTenFileRieng.Text = objReport.FileRieng;
                txtTenFileMacDinh.Text = objReport.FileChuan;
                txtMoTa.Text = objReport.MoTa;
            }
            catch (Exception ex) { }
        }

        private void frm_themmoi_baocao_Load(object sender, EventArgs e)
        {

            //DataTable dtbaocao =
            //    new Select().From(SysReport.Schema.Name)
            //        .Where(SysReport.Columns.MaNhom)
            //        .IsEqualTo("BAOCAO")
            //        .ExecuteDataSet()
            //        .Tables[0];
            //DataBinding.BindDataCombox(cboNhom, dtbaocao, "ID", "BAOCAO");
            cboNhom.SelectedIndex = 0;
            if (m_enAct == Libs.action.Update) GetData();
            txtMa.Focus();
        }

        private bool CheckValidData()
        {
            SysReport obj = null;
            if (string.IsNullOrEmpty(txtMa.Text))
            {
                Utility.ShowMsg("Chưa nhập mã báo cáo", "Thông báo", MessageBoxIcon.Information);
                txtMa.Focus();
                txtMa.SelectAll();
                return false;
            }
            if (string.IsNullOrEmpty(txtTieude.Text))
            {
                Utility.ShowMsg("Chưa nhập tiêu đề báo cáo", "Thông báo", MessageBoxIcon.Information);
                txtTieude.Focus();
                txtTieude.SelectAll();
                return false;
            }
            if (cboNhom.Items.Count <= 0)
            {
                Utility.ShowMsg("Chưa khởi tạo danh mục nhóm báo cáo", "Thông báo", MessageBoxIcon.Information);
                cboNhom.Focus();
                return false;
            }
            if (txtTenFileMacDinh.Text.Trim() == "")
            {
                Utility.ShowMsg("Chưa nhập tên file chuẩn", "Thông báo", MessageBoxIcon.Information);
                txtTenFileMacDinh.Focus();
                txtMa.SelectAll();
                return false;
            }
            if (objReport.IsNew)
            {
                obj = new SysReportController().FetchByID(txtMa.Text).FirstOrDefault();
                if (obj != null)
                {
                    Utility.ShowMsg("Mã báo cáo đã tồn tại. Chọn mã khác", "Thông báo", MessageBoxIcon.Information);
                    txtMa.Focus();
                    txtMa.SelectAll();
                    return false;
                }
            }
            else
            {
                obj = new Select().From(SysReport.Schema).Where(SysReport.Columns.MaBaocao).IsEqualTo(Utility.DoTrim(txtMa.Text))
                    .And(SysReport.Columns.MaBaocao).IsNotEqualTo(objReport.MaBaocao).ExecuteSingle<SysReport>();
                if (obj != null)
                {
                    Utility.ShowMsg("Mã báo cáo đã tồn tại. Chọn mã khác", "Thông báo", MessageBoxIcon.Information);
                    txtMa.Focus();
                    txtMa.SelectAll();
                    return false;
                }
            }
            return true;
        }

        private void InsertData()
        {
            try
            {
                objReport.MaBaocao = Utility.DoTrim(txtMa.Text);
                objReport.MaNhom = cboNhom.SelectedItem.ToString();
                objReport.TieuDe = Utility.DoTrim(txtTieude.Text);
                objReport.FileRieng = Utility.DoTrim(txtTenFileRieng.Text);
                objReport.FileChuan = Utility.DoTrim(txtTenFileMacDinh.Text);
                objReport.MoTa = Utility.DoTrim(txtMoTa.Text);
                objReport.NgayTao = globalVariables.SysDate;
                objReport.NguoiTao = globalVariables.UserName;
                objReport.IsNew = true;
                objReport.Save();
                m_enAct = action.Update;
                txtMa.Enabled = false;
                DataRow newitem = dt_data.NewRow();
                Utility.FromObjectToDatarow(objReport, ref newitem);
                newitem["ten_nhombaocao"] = cboNhom.Text;
                dt_data.Rows.Add(newitem);
                dt_data.AcceptChanges();
                Utility.GonewRowJanus(grdList, SysReport.Columns.MaBaocao, objReport.MaBaocao);
                if (chkThemlientuc.Checked)
                    ResetControls();
            }
            catch (Exception ex)
            {
                
                Utility.ShowMsg(ex.ToString(),"Thông báo");
            }
        }

        private void UpdateData()
        {
            try
            {
                new Update(SysReport.Schema)
                    .Set(SysReport.Columns.MaBaocao).EqualTo(txtMa.Text)
                    .Set(SysReport.Columns.MaNhom).EqualTo(cboNhom.SelectedItem.ToString())
                    .Set(SysReport.Columns.TieuDe).EqualTo(Utility.DoTrim(txtTieude.Text))
                    .Set(SysReport.Columns.FileRieng).EqualTo(Utility.DoTrim(txtTenFileRieng.Text))
                    .Set(SysReport.Columns.FileChuan).EqualTo(Utility.DoTrim(txtTenFileMacDinh.Text))
                    .Set(SysReport.Columns.MoTa).EqualTo(Utility.DoTrim(txtMoTa.Text))
                    .Set(SysReport.Columns.NgaySua).EqualTo(globalVariables.SysDate)
                    .Set(SysReport.Columns.NguoiSua).EqualTo(globalVariables.UserName)
                    .Where(SysReport.Columns.MaBaocao).IsEqualTo(objReport.MaBaocao).Execute();

                DataRow newitem = dt_data.Select(SysReport.Columns.MaBaocao + "='" + objReport.MaBaocao + "'")[0];
                objReport.MaBaocao = Utility.DoTrim(txtMa.Text);
                objReport.MaNhom = cboNhom.SelectedValue.ToString();
                objReport.TieuDe = Utility.DoTrim(txtTieude.Text);
                objReport.FileRieng = Utility.DoTrim(txtTenFileRieng.Text);
                objReport.FileChuan = Utility.DoTrim(txtTenFileMacDinh.Text);
                objReport.MoTa = Utility.DoTrim(txtMoTa.Text);
                objReport.NgayTao = globalVariables.SysDate;
                objReport.NguoiTao = globalVariables.UserName;
                Utility.FromObjectToDatarow(objReport, ref newitem);
                newitem["ten_nhombaocao"] = cboNhom.Text;
                dt_data.AcceptChanges();
                Utility.GonewRowJanus(grdList, SysReport.Columns.MaBaocao, objReport.MaBaocao);
                if (chkThemlientuc.Checked)
                    ResetControls();
                else
                    this.Close();
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.ToString(),"Thong Bao");
            }
        }

        private void ResetControls()
        {
            foreach(Control ctr in grpControl.Controls)
            {
                if (ctr is Janus.Windows.GridEX.EditControls.EditBox)
                {
                    ctr.Text = "";
                }
            }
            m_enAct = action.Insert;
            objReport = new SysReport();
            txtMa.Enabled = true;
            txtMa.Focus();
        }

        private void PerformAction()
        {
            switch (m_enAct)
            {
                case action.Insert:
                    InsertData();
                    break;
                case action.Update:
                    UpdateData();
                    break;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (CheckValidData())
                PerformAction();
        }


        private void frm_themmoi_baocao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)cmdExit.PerformClick();
            if(e.KeyCode==Keys.S&&e.Control)cmdSave.PerformClick();
            if (e.KeyCode == Keys.Enter) SendKeys.Send("{TAB}");
            if (e.KeyCode == Keys.F5) ResetControls();

        }

        private void cmdThemMoi_Click(object sender, EventArgs e)
        {
            ResetControls();
        }
    }
}
