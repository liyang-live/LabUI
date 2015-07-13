using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using SubSonic;
using LIS.DAL; 
using VNS.Libs;
using System.Transactions;
namespace VietBaIT.LABLink.List.UI
{
    public partial class frm_BANGGIA : Form
    {
        public frm_BANGGIA()
        {
            InitializeComponent();
        }

        //void LoadDataCombobox()
        //{
        //    try
        //    {
        //        _dtTestTypeList = new TTestTypeListController().FetchAll().ToDataTable();
        //        DataBinding.BindDataCombox(cboTestTypeList, _dtTestTypeList, TTestTypeList.Columns.TestTypeId, TTestTypeList.Columns.TestTypeName);
        //    }
        //    catch (Exception)
        //    {
        //        Utility.ShowMsg("Có lỗi trong quá trình lấy thông tin combobox");                
        //    }
        //}
        private void frm_BANGGIA_Load(object sender, EventArgs e)
        {

            LoadTestTypeList();
        }

        private DataTable _dtTestTypeList;
        void LoadTestTypeList()
        {
            try
            {
                _dtTestTypeList = new Select().From(TTestTypeList.Schema).ExecuteDataSet().Tables[0];
                grdListTestType.DataSource = _dtTestTypeList;
            }
            catch (Exception)
            {
                Utility.ShowMsg("Có lỗi trong quá trình lấy TestTypeList");
               
            }
        }

        private int _TestTypeId = -1;
        private DataTable _dtDataControll;
        void LoadDataControl()
        {
            try
            {
                

                _dtDataControll = SPs.GetDataControlAndPrice(_TestTypeId).GetDataSet().Tables[0];

                grdDataControl.DataSource = _dtDataControll;
            }
            catch (Exception)
            {
                Utility.ShowMsg("Có lỗi trong quá trình lấy thông tin DataControl");
                throw;
            }
        }

        private string Abbreviation = "";
        private void grdListTestType_SelectionChanged(object sender, EventArgs e)
        {
            if(grdListTestType.CurrentRow != null)
            {
                if(grdListTestType.CurrentRow.RowType == RowType.Record)
                {
                    _TestTypeId =
                         Utility.Int32Dbnull(grdListTestType.CurrentRow.Cells[TTestTypeList.Columns.TestTypeId].Value, -1);
                    Abbreviation =
                        grdListTestType.CurrentRow.Cells[TTestTypeList.Columns.Abbreviation].Value.ToString();
                    if (!Exists())
                    {
                        LoadDataControl();                        
                    }
                    else
                    {
                         if(_dtDataControll != null)_dtDataControll.Clear();
                        nmrPrice.Value =
                            Utility.DecimaltoDbnull(
                                new Select(BangGium.Columns.Price).From(BangGium.Schema).Where(BangGium.Columns.TestTypeId).IsEqualTo(
                                    _TestTypeId).And(BangGium.Columns.TestDataId).IsEqualTo(-1).ExecuteScalar(), 0);
                    }
                               
                }
            }
           
        }

        private string _TestDataId = "-1";
        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var Scope = new TransactionScope())
                {
                    using (var dbScope = new SharedDbConnectionScope())
                    {
                        var exists = Exists();
                        if (exists)
                        {
                           
                            int record = new Update(BangGium.Schema).Set(BangGium.Columns.Price).EqualTo(nmrPrice.Value)
                                .Where(BangGium.Columns.TestTypeId).IsEqualTo(_TestTypeId).And(
                                    BangGium.Columns.TestDataId)
                                .IsEqualTo(-1).Execute();
                            if (record <= 0)
                            {
                                BangGium bangGium = new BangGium();
                                bangGium.TestTypeId = _TestTypeId;
                                bangGium.TestDataId = "-1";
                                bangGium.Price = Utility.DecimaltoDbnull(nmrPrice.Value, 0);
                                bangGium.IsNew = true;
                                bangGium.Save();
                            }
                        }
                        else
                        {
                            decimal price = Utility.DecimaltoDbnull(grdDataControl.CurrentRow.Cells["Price"].Value, 0);
                            nmrPrice.Value = price;

                            int record = new Update(BangGium.Schema).Set(BangGium.Columns.Price).EqualTo(nmrPrice.Value)
                                .Where(BangGium.Columns.TestTypeId).IsEqualTo(_TestTypeId)
                                .And(BangGium.Columns.TestDataId).IsEqualTo(_TestDataId).Execute();
                            if (record <= 0)
                            {
                                BangGium bangGium = new BangGium();
                                bangGium.TestTypeId = _TestTypeId;
                                bangGium.TestDataId = _TestDataId;
                                bangGium.Price = Utility.DecimaltoDbnull(nmrPrice.Value, 0);
                                bangGium.IsNew = true;
                                bangGium.Save();
                            }
                        }
                    }
                    Scope.Complete();
                    //Utility.ShowMsg("Lưu thông tin thành công.");
                }
 
            }
            catch (Exception)
            {
                Utility.ShowMsg("Có lỗi trong quá trình lưu thông tin");
                throw;
            }
        }

        private bool Exists()
        {
             tblSystemParameter =
                new Select().From(TblSystemParameter.Schema).Where(TblSystemParameter.Columns.SName).
                    IsEqualTo("TESTTYPEONLY").ExecuteSingle<TblSystemParameter>();
            bool exists = false;
            if (tblSystemParameter != null)
            {
                string[] testtypeonly = tblSystemParameter.SValue.Split(',');
                exists = testtypeonly.Contains(Abbreviation);
            }
            else
            {
                tblSystemParameter = new TblSystemParameter();
                tblSystemParameter.SValue = "HHOC,NTIEU";
                tblSystemParameter.SName = "TESTTYPEONLY";
                tblSystemParameter.SDataType = "nvarchar";
                tblSystemParameter.FpSBranchID = "THAIHA";
                tblSystemParameter.IMonth = 0;
                tblSystemParameter.IYear = 0;
                tblSystemParameter.IStatus = 1;
                tblSystemParameter.IsNew = true;
                tblSystemParameter.Save();
            }
            return exists;
        }

        private void grdDataControl_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if(grdDataControl.CurrentRow != null)
                {
                    if(grdDataControl.CurrentRow.RowType == RowType.Record)
                    {
                        _TestDataId =
                            Utility.sDbnull(grdDataControl.CurrentRow.Cells[LStandardTest.Columns.TestDataId].Value, -1);
                        nmrPrice.Value = Utility.DecimaltoDbnull(grdDataControl.CurrentRow.Cells["Price"].Value, 0);
 
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.ShowMsg("Có lỗi trong quá trình xử lý dữ liệu");
                
            }
        }

        private void grdDataControl_CellEdited(object sender, ColumnActionEventArgs e)
        {
            
        }

        private void grdDataControl_CellUpdated(object sender, ColumnActionEventArgs e)
        {
            cmdSave.PerformClick();
        }

        private void frm_BANGGIA_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.S)
                cmdSave.PerformClick();
        }


    }
}
