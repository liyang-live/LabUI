using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using SubSonic;

namespace VietBaIT.LABLink.Reports.Class
{
   public class cls_SignInfor
    {

        #region "Khai bao bien"
        public string mv_TEN_BIEUBC = "";
        public string mv_TEN_DOITUONG = "";
        public int mv_CHIEU_RONG = 0;
        public int mv_CHIEU_DAI = 0;
        public int mv_TOADO_DOC = 0;
        public int mv_TOADO_NGANG = 0;
        public string mv_FONT_CHU = "Arial";
        public int mv_CO_CHU = 12;
        public string mv_KIEU_CHU = "Regular";
        public string mv_NOI_DUNG = "";
        public string mv_MA_DVIQLY = "";
        
        public System.DateTime mv_NGAY_CAPNHAT = new System.DateTime();
        private bool exists = false;
        #endregion
        #region "Properties"
        public bool _TonTai
        {
            get { return exists; }
        }
        #endregion
        #region "Cac ham khoi tao"
        public cls_SignInfor()
        {
            exists = false;
        }
        //ham nay se thuc hien lay thong tin tren server ve
        public cls_SignInfor(string sv_sBieuMau, string sv_sDonVi, DataTable ReportSourceTable)
        {
            exists = true;
            SqlCommand cmdNguoiKy = new SqlCommand();
            string strSQL = "Select * from tbl_Trinhky Where ReportName = N'" + sv_sBieuMau + "'";
            DataTable dtbNguoiKy = new DataTable();
            try
            {
               
                    dtbNguoiKy =new Select().From("tbl_Trinhky").Where("ReportName").IsEqualTo(sv_sBieuMau)
                            .ExecuteDataSet().Tables[0];

                
                if (dtbNguoiKy.Rows.Count > 0) exists = true;

            }
            catch (Exception ex)
            {
                exists = false;
            }
            if (exists == false) return;


            try
            {
                if (dtbNguoiKy.Rows.Count > 0)
                {
                    //gan cac thong tin co duoc vao bien
                    mv_TEN_BIEUBC = (string)dtbNguoiKy.Rows[0]["ReportName"];
                    try
                    {
                        mv_TEN_DOITUONG = (string)dtbNguoiKy.Rows[0]["ObjectName"];
                    }
                    catch (Exception ex)
                    {
                        mv_TEN_DOITUONG = " ";
                    }

                    mv_FONT_CHU = (string)dtbNguoiKy.Rows[0]["Font_Name"];
                    mv_CO_CHU = (int)dtbNguoiKy.Rows[0]["Font_Size"];
                    mv_KIEU_CHU = (string)dtbNguoiKy.Rows[0]["Font_Stype"];
                    try
                    {
                        
                        mv_NOI_DUNG = (string)dtbNguoiKy.Rows[0]["ObjectContent"];
                        
                    }
                    catch (Exception ex)
                    {
                        mv_NOI_DUNG = " ";
                    }
                }
                else
                {
                    exists = false;
                }
            }
            catch (Exception ex)
            {
                exists = false;
            }

        }

        private string AppendAtPosition(string baseString, int position, string[] character)
        {
            var a = baseString.Split(' ');
            for (int i = 0; i < character.Length; i++)
            {
                a[position] = character[i];
                position++;
            }

            return string.Join(" ", a);
        }

        //ham nay se thuc hien lay thong tin tu file rpt
        public cls_SignInfor(CrystalDecisions.CrystalReports.Engine.FieldObject rpt, string sv_sDonVi, string baoCao, string pv_sContent)
        {
            exists = false;
            try
            {
                //gan cac thong tin co duoc vao bien
                mv_TEN_BIEUBC = baoCao;
                //rpt.ToString
                mv_TEN_DOITUONG = "txtNguoiKy1";
                mv_FONT_CHU = rpt.Font.Name;
                mv_CO_CHU = (int)rpt.Font.Size;
                switch (rpt.Font.Style)
                {
                    case FontStyle.Bold:
                        mv_KIEU_CHU = "Chữ đậm";
                        break;
                    case FontStyle.Italic:
                        mv_KIEU_CHU = "Chữ nghiêng";
                        break;
                    case FontStyle.Regular:
                        mv_KIEU_CHU = "Bình thường";
                        break;
                    default:
                        mv_KIEU_CHU = "Bình thường";
                        break;
                }
                mv_NOI_DUNG = pv_sContent.Replace("\"", "");
                mv_MA_DVIQLY = sv_sDonVi;
                mv_NGAY_CAPNHAT = new System.DateTime();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
        #region "Cac thu tuc"
        //thu tuc de gan toan bo thong tin cua doi tuong vao RPT
        public void setValueToRPT(ref CrystalDecisions.CrystalReports.Engine.FieldObject rpt)
        {
            //rpt.ToString = sv_TEN_BIEUBC       'La duy nhat cho 1 file trong CT
            //rpt.Height = mv_CHIEU_RONG      'Do rong cua o text
            //rpt.Width = mv_CHIEU_DAI        'chieu dai cua o text
            //rpt.Top = mv_TOADO_DOC          'toa do docn(y) cua o text
            //rpt.Left = mv_TOADO_NGANG       'toa do ngang cua o text(tinh trong section do)
            //rpt.Text = mv_NOI_DUNG     'Noi dung hien thi
            //don vi
            //ngay thay doi thong tin
            Font ft = null;
            try
            {
                switch (mv_KIEU_CHU.Trim().ToUpper())
                {
                    case "CHỮ ĐẬM":
                        ft = new Font(mv_FONT_CHU, mv_CO_CHU, FontStyle.Bold);
                        break;
                    case "CHỮ NGHIÊNG":
                        ft = new Font(mv_FONT_CHU, mv_CO_CHU, FontStyle.Italic);
                        break;
                    case "BÌNH THƯỜNG":
                        ft = new Font(mv_FONT_CHU, mv_CO_CHU, FontStyle.Regular);
                        break;
                    default:
                        ft = new Font(mv_FONT_CHU, mv_CO_CHU, FontStyle.Regular);
                        break;
                }
            }
            catch (Exception ex)
            {
                //font mac dinh
                ft = new Font("Arial", 13, FontStyle.Regular);
            }
            rpt.ApplyFont(ft);
            //Font: cho phep thay doi
        }
      
        //thu tuc de ghi cau hinh cua file RPT len Database
        public void updateRPTtoDB()
        {
            SqlQuery sqlQuery = new Select().From("tbl_Trinhky")
                .Where("ReportName").IsEqualTo(mv_TEN_BIEUBC);
            //string strSQL="select * from tbl_Trinhky"
            string strSQL = "";
            if (sqlQuery.GetRecordCount()>0)
            {
                strSQL = "Update tbl_TRINHKY set";
                strSQL += " ObjectName = N'" + mv_TEN_DOITUONG + "'";
                strSQL += " ,Font_Name = N'" + mv_FONT_CHU + "'";
                strSQL += " ,Font_Size = " + mv_CO_CHU;
                strSQL += " ,Font_Stype = N'" + mv_KIEU_CHU + "'";
                strSQL += " ,ObjectContent = N'" + mv_NOI_DUNG + "'";
                strSQL += " Where ReportName = N'" + mv_TEN_BIEUBC + "'";
                new SubSonic.InlineQuery().Execute(strSQL);
            }
            else
            {
                strSQL = "Insert Into tbl_TRINHKY(ReportName, ObjectName,  Font_Name, Font_Size, Font_Stype, ObjectContent)";
                strSQL += " Values(";
                strSQL += " N'" + mv_TEN_BIEUBC + "'";
                strSQL += " ,N'" + mv_TEN_DOITUONG + "'";
                strSQL += " ,N'" + mv_FONT_CHU + "'";
                strSQL += " ," + mv_CO_CHU;
                strSQL += " ,N'" + mv_KIEU_CHU + "'";
                strSQL += " ,N'" + mv_NOI_DUNG + "')";
               
                    new SubSonic.InlineQuery().Execute(strSQL);
                
                exists = true;

            }
           
        }
        #endregion
    }
}
