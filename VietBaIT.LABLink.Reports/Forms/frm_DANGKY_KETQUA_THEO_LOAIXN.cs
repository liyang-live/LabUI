using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using  SubSonic;
using System.Windows.Forms;
using VNS.Libs;


namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frm_DANGKY_KETQUA_THEO_LOAIXN : Form
    {
        public frm_DANGKY_KETQUA_THEO_LOAIXN()
        {
            InitializeComponent();
        }
        /// <summary>
        /// khai báo DataTable
        /// </summary>
        private DataTable dataResult;

        #region Method
        private void LoadTestTypeCombobox()
        {
            var dt = new DataTable("TestType");
            string display = "Display";
            dt.Columns.Add(display);
            string value = "Value";
            dt.Columns.Add(value);

            // 1 Huyet hoc
            var dr = dt.NewRow();
            dr[display] = "Huyết Học";
            dr[value] = "1";
            dt.Rows.Add(dr);

            //2 Hoa Sinh
            dr = dt.NewRow();
            dr[display] = "Hóa Sinh";
            dr[value] = "3";
            dt.Rows.Add(dr);

            //3 Nuoc Tieu
            dr = dt.NewRow();
            dr[display] = "Nước Tiểu";
            dr[value] = "2,9";
            dt.Rows.Add(dr);

            //4 Dong cam mau
            dr = dt.NewRow();
            dr[display] = "Đông Cầm Máu";
            dr[value] = "10";
            dt.Rows.Add(dr);

            // 5 Dien giai - mien dich  
            dr = dt.NewRow();
            dr[display] = "Điện Giải - Miễn Dịch";
            dr[value] = "5,8";
            dt.Rows.Add(dr);

            // 6 Vi Sinh - Ky Sinh Trung  
            dr = dt.NewRow();
            dr[display] = "Vi Sinh - Ký Sinh Trùng";
            dr[value] = "7";
            dt.Rows.Add(dr);

            dt.AcceptChanges();

            cboTestType.DataSource = dt;
            cboTestType.DisplayMember = display;
            cboTestType.ValueMember = value;
        }
       
        #endregion

        #region Event
        private void cmdINPHIEU_Click(object sender, EventArgs e)
        {
            try
            {
                //dataResult =
                //    SPs.SpYhhqDangKyKetQuaTheoTestType(dtpFromDate.Value.Date, dtpToDate.Value.Date,
                //                                       cboTestType.SelectedValue.ToString()).GetDataSet().Tables[0];
                //if (dataResult.Rows.Count < 1)
                //{
                //    Utility.ShowMsg("Không có dữ liệu để in");
                //}
                //else
                //{
                //    string s = "";
                //    if (dtpFromDate.Value.Date == dtpToDate.Value.Date)
                //    {
                //        s = string.Format("{0}Ngày {1}", s, dtpFromDate.Value.ToString("dd/MM/yyyy"));
                //    }
                //    else
                //    {
                //        s = string.Format("{0}{1}", s,
                //                          string.Format("Từ ngày {0} đến ngày {1}",
                //                                        dtpFromDate.Value.ToString("dd/MM/yyyy"),
                //                                        dtpToDate.Value.ToString("dd/MM/yyyy")));
                //    }
                //    switch (cboTestType.Text)
                //    {
                //        case "Hóa Sinh":
                //            var crpt1 = new crpt_DangKy_KetQua_HoaSinh();
                //            var oForm1 = new frmPrintPreview("In Báo Cáo", crpt1, true, true);
                //            crpt1.SetDataSource(dataResult);
                //            crpt1.DataDefinition.FormulaFields["Formula_1"].Text = "";
                //            crpt1.SetParameterValue("ParentBranchName",ManagementUnit.gv_sParentBranchName);
                //            crpt1.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
                //            crpt1.SetParameterValue("fromDateToDate", s);
                //            oForm1.crptViewer.ReportSource = crpt1;
                //            oForm1.ShowDialog();
                //            oForm1.Dispose();
                //            break;
                //        case "Huyết Học":
                //            var crpt2 = new crpt_DangKy_KetQua_HuyetHoc1();
                //            var oForm2 = new frmPrintPreview("In Báo Cáo", crpt2, true, true);
                //            crpt2.SetDataSource(dataResult);
                //            crpt2.DataDefinition.FormulaFields["Formula_1"].Text = "";
                //            crpt2.SetParameterValue("ParentBranchName", ManagementUnit.gv_sParentBranchName);
                //            crpt2.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
                //            crpt2.SetParameterValue("fromDateToDate", s);
                //            oForm2.crptViewer.ReportSource = crpt2;
                //            oForm2.ShowDialog();
                //            oForm2.Dispose();
                //            break;
                //        case "Nước Tiểu":
                //            var crpt3 = new crpt_DangKy_KetQua_NuocTieu();
                //            var oForm3 = new frmPrintPreview("In Báo Cáo", crpt3, true, true);
                //            crpt3.SetDataSource(dataResult);
                //            crpt3.DataDefinition.FormulaFields["Formula_1"].Text = "";
                //            crpt3.SetParameterValue("ParentBranchName", ManagementUnit.gv_sParentBranchName);
                //            crpt3.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
                //            crpt3.SetParameterValue("fromDateToDate", s);
                //            oForm3.crptViewer.ReportSource = crpt3;
                //            oForm3.ShowDialog();
                //            oForm3.Dispose();
                //            break;
                //        case "Đông Cầm Máu":
                //            var crpt4 = new crpt_DangKy_KetQua_DongCamMau();
                //            var oForm4 = new frmPrintPreview("In Báo Cáo", crpt4, true, true);
                //            crpt4.SetDataSource(dataResult);
                //            crpt4.DataDefinition.FormulaFields["Formula_1"].Text = "";
                //            crpt4.SetParameterValue("ParentBranchName",ManagementUnit.gv_sParentBranchName);
                //            crpt4.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
                //            crpt4.SetParameterValue("fromDateToDate", s);
                //            oForm4.crptViewer.ReportSource = crpt4;
                //            oForm4.ShowDialog();
                //            oForm4.Dispose();
                //            break;
                //        case "Điện Giải - Miễn Dịch":
                //            var crpt5 = new crpt_DangKy_KetQua_DienGiaiMienDich();
                //            var oForm5 = new frmPrintPreview("In Báo Cáo", crpt5, true, true);
                //            crpt5.SetDataSource(dataResult);
                //            crpt5.DataDefinition.FormulaFields["Formula_1"].Text = "";
                //            crpt5.SetParameterValue("ParentBranchName", ManagementUnit.gv_sParentBranchName);
                //            crpt5.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
                //            crpt5.SetParameterValue("fromDateToDate", s);
                //            oForm5.crptViewer.ReportSource = crpt5;
                //            oForm5.ShowDialog();
                //            oForm5.Dispose();
                //            break;
                //        case "Vi Sinh - Ký Sinh Trùng":
                //            var crpt6 = new crpt_DangKy_KetQua_VisinhKySinhTrung();
                //            var oForm6 = new frmPrintPreview("In Báo Cáo", crpt6, true, true);
                //            crpt6.SetDataSource(dataResult);
                //            crpt6.DataDefinition.FormulaFields["Formula_1"].Text = "";
                //            crpt6.SetParameterValue("ParentBranchName", ManagementUnit.gv_sParentBranchName);
                //            crpt6.SetParameterValue("BranchName", ManagementUnit.gv_sBranchName);
                //            crpt6.SetParameterValue("fromDateToDate", s);
                //            oForm6.crptViewer.ReportSource = crpt6;
                //            oForm6.ShowDialog();
                //            oForm6.Dispose();
                //            break;
                //    }
                //}
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.ToString());
            }
        }

        private void frm_DANGKY_KETQUA_THEO_LOAIXN_Load(object sender, EventArgs e)
        {
            // Load dữ liệu combobox 
            LoadTestTypeCombobox();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
           Dispose();
        }

        private void frm_DANGKY_KETQUA_THEO_LOAIXN_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
                {
                    case Keys.F3:
                        cmdINPHIEU.PerformClick();
                        break;
                    case Keys.Escape:
                        cmdExit.PerformClick();
                        break;
                }
         }
        #endregion
    }
}
