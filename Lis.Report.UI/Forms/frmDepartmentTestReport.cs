using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Janus.Windows.GridEX;
using LIS.DAL;
using VNS.Libs;


namespace VietBaIT.LABLink.Reports.Forms
{
    public partial class frmDepartmentTestReport : Form
    {
        private DataTable dtResultDetail, dtDoctor, dtDepartment;
        private int colResultFrom = 2;
        private int colResultTo = 1;
        private string colTotalName = "colTotal";

        public frmDepartmentTestReport()
        {
            InitializeComponent();
        }

        private void frmDepartmentTestReport_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.F3:
                    btnSearch.PerformClick();
                    break;
                case Keys.F4:
                    btnExcel.PerformClick();
                    break;
                case Keys.Escape:
                    btnExit.PerformClick();
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cboReportType.SelectedIndex)
                {
                    case 0:
                        dtResultDetail =
                            SPs.SpGetResultDetailByDepartment(dtmFrom.Value.ToShortDateString(), dtmTo.Value.ToShortDateString()).GetDataSet().Tables[0];
                        break;
                    case 1:
                        dtResultDetail =
                            SPs.SpGetResultDetailByDoctor(dtmFrom.Value.ToShortDateString(),dtmTo.Value.ToShortDateString()).GetDataSet().Tables[0];
                        break;
                }


                if (dtResultDetail.Columns.Count < 2)
                {
                    Utility.ShowMsg("Không tìm thấy kết quả 1");
                    return;
                }

                colResultTo = dtResultDetail.Columns.Count;
                AddTotalColumn(ref dtResultDetail);
                switch (cboReportType.SelectedIndex)
                {
                    case 0: 
                        GenerateGridExColumn(dtResultDetail, dtDepartment, LDepartment.Columns.Id, LDepartment.Columns.SName);
                        break;
                    case 1:
                        GenerateGridExColumn(dtResultDetail, dtDoctor, LUser.Columns.UserId, LUser.Columns.UserName);
                        break;
                }
                
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
            }
        }

        private void GenerateGridExColumn(DataTable dtResult, DataTable dtList, string colId, string colName)
        {
            grdResultDetail.RootTable.Columns.Clear();
            foreach (DataColumn dc in dtResult.Columns)
            {
                grdResultDetail.RootTable.Columns.Add(dc.ColumnName);
            }
            int colCount = grdResultDetail.RootTable.Columns.Count - 1;
            grdResultDetail.RootTable.Columns[0].Caption = "Tên Thông Số";
            grdResultDetail.RootTable.Columns[colCount].Caption = "Tổng";

            for (int i = colResultFrom; i < colResultTo; i++)
            {
                grdResultDetail.RootTable.Columns[i].Caption = GetValueDatatable(dtList,grdResultDetail.RootTable.Columns[i].Caption, 
                                                                                colId,colName,"None").ToString();
            }

            grdResultDetail.RootTable.Columns[colTotalName].CellStyle.BackColor = Color.FromArgb(255, 255, 128);
            grdResultDetail.RootTable.Columns[TTestTypeList.Columns.TestTypeName].Visible = false;
            grdResultDetail.RootTable.Groups.Add(TTestTypeList.Columns.TestTypeName);
            grdResultDetail.RootTable.Groups[0].GroupPrefix = string.Empty;

            grdResultDetail.DataSource = dtResultDetail;
        }

        private object GetValueDatatable(DataTable vTable, string vComparedValue, string vCompraredColumn, string vResultColumn, object opt)
        {
            try
            {
                DataRow dr = vTable.Select(vCompraredColumn + "=" + vComparedValue)[0];
                return dr[vResultColumn];
            }
            catch (Exception)
            {
                return opt;
            }
        }

        private void AddTotalColumn(ref DataTable dtResult)
        {
            dtResult.Columns.Add(colTotalName, typeof (Int32));
            foreach (DataRow dr in dtResult.Rows)
            {
                Int32 vTotal = 0;
                for (int i = colResultFrom; i < colResultTo; i++)
                {
                    vTotal += Utility.Int32Dbnull(dr[i], 0);
                }
                dr[colTotalName] = vTotal;
            }
        }

        private void frmDepartmentTestReport_Load(object sender, EventArgs e)
        {
            try
            {
                dtDepartment = new SubSonic.Select().From(LDepartment.Schema.Name).ExecuteDataSet().Tables[0];
                dtDoctor = new SubSonic.Select().From(LUser.Schema.Name).ExecuteDataSet().Tables[0];
                cboReportType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Utility.ShowMsg(ex.Message);
                this.Dispose();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
