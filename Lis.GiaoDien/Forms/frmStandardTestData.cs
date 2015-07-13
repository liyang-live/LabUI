using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Janus.Windows.EditControls;
using Janus.Windows.GridEX;
using SubSonic;
using VNS.Libs;
using LIS.DAL;

namespace Vietbait.Lablink.TestInformation.UI
{
    public partial class frmStandardTestData : Form
    {
        public DataTable dtResultDetail;
        public GridEXRow grwTestInfo;
        private DataTable dtStandardTest;

        public frmStandardTestData()
        {
            InitializeComponent();
        }

        private void frmStandardTestData_Load(object sender, EventArgs e)
        {
            Text = "ĐĂNG KÝ CHI TIẾT KẾT QUẢ - " + Utility.sDbnull(grwTestInfo.Cells["TestType_Name"].Value).ToUpper();
            txtBarcode.Text = Utility.sDbnull(grwTestInfo.Cells["Barcode"].Value);
            LoadStandardTest();
        }

        private void LoadStandardTest()
        {
            try
            {
                var myButtonSize = new Size(125, 40);
                var myImageSize = new Size(24, 24);
                var myPaddingSize = new Padding(1);
                Color myButtonBackColor = Color.WhiteSmoke;
                dtStandardTest =
                    new Select().From(LStandardTest.Schema.Name).Where(LStandardTest.Columns.TestTypeId).
                        IsEqualTo(Utility.Int32Dbnull(grwTestInfo.Cells["TestType_ID"].Value, -1)).And(LStandardTest.Columns.DataView).IsEqualTo(true).
                        OrderAsc(LStandardTest.Columns.DataSequence).ExecuteDataSet().Tables[0];
                foreach (DataRow dr in dtStandardTest.Rows)
                {
                    var btn = new UIButton();
                    btn.Size = myButtonSize;
                    btn.ImageSize = myImageSize;
                    btn.Padding = myPaddingSize;
                    btn.BackColor = myButtonBackColor;
                    btn.ImageList = imgAdminnistration;
                    btn.Text = dr[LStandardTest.Columns.DataName].ToString();
                    btn.Tag = dr[LStandardTest.Columns.TestDataId].ToString();
                    btn.ImageIndex = GetImageIndex(dr[LStandardTest.Columns.TestDataId].ToString());
                    btn.Click += BtnClick;
                    flpStandardTest.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void BtnClick(object sender, EventArgs e)
        {
            try
            {
                UIButton btn = (UIButton) sender;
                if (btn.ImageIndex == 2) Utility.ShowMsg("Thông số có kết quả. Không được hủy");
                else
                    if(btn.ImageIndex == 0)
                    {
                        DataRow dr = dtResultDetail.NewRow();
                        DataRow drStandardTest = Utility.GetDataRow(dtStandardTest, LStandardTest.Columns.TestDataId,
                                                                    btn.Tag);
                        dr[TResultDetail.Columns.TestDetailId] = -1;
                        dr[TResultDetail.Columns.ParaName] = drStandardTest[LStandardTest.Columns.DataName];
                        dr[TResultDetail.Columns.NormalLevel] = drStandardTest[LStandardTest.Columns.NormalLevel];
                        dr[TResultDetail.Columns.NormalLevelW] = drStandardTest[LStandardTest.Columns.NormalLevelW];
                        dr[TResultDetail.Columns.DataSequence] = drStandardTest[LStandardTest.Columns.DataSequence];
                        dr[TResultDetail.Columns.PrintData] = drStandardTest[LStandardTest.Columns.DataPrint];
                        dr[TResultDetail.Columns.MeasureUnit] = drStandardTest[LStandardTest.Columns.MeasureUnit];
                        dr[TResultDetail.Columns.TestDataId] = drStandardTest[LStandardTest.Columns.TestDataId];
                        dr[TResultDetail.Columns.PatientId] = Utility.Int32Dbnull(grwTestInfo.Cells["Patient_ID"].Value,-1);
                        dr[TResultDetail.Columns.TestTypeId] = Utility.Int32Dbnull(grwTestInfo.Cells["TestType_ID"].Value, -1);
                        dr[TResultDetail.Columns.TestId] = Utility.Int32Dbnull(grwTestInfo.Cells["Test_ID"].Value, -1);

                        //dr[TResultDetail.Columns.ParaStatus] = drStandardTest[LStandardTest.Columns.DataView];
                        dtResultDetail.Rows.Add(dr);
                        dtResultDetail.AcceptChanges();
                        btn.ImageIndex = 1;
                    }
                    else
                    {
                        DataRow delRow = Utility.GetDataRow(dtResultDetail, TResultDetail.Columns.TestDataId,
                                                                    btn.Tag);
                        dtResultDetail.Rows.Remove(delRow);
                        dtResultDetail.AcceptChanges();
                        btn.ImageIndex = 0;
                    }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private int GetImageIndex(string vTestData_ID)
        {
            try
            {
                foreach (DataRow dr in dtResultDetail.Rows)
                {
                    if (Utility.sDbnull(dr[TResultDetail.Columns.TestDataId]) == vTestData_ID)
                        if (Utility.Int32Dbnull(dr[TResultDetail.Columns.TestDetailId], -1) > 0)
                            return 2;
                        else return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private void frmStandardTestData_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                    case Keys.Escape:
                    Dispose();
                    break;
            }
        }
    }
}