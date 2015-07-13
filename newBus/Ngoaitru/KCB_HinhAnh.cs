using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Transactions;
using System.Windows.Forms;
using SubSonic;
using System.IO;
using VNS.Libs;
using VNS.HIS.DAL;
using System.Transactions;
using NLog;
namespace VNS.HIS.BusRule.Classes
{
   public class KCB_HinhAnh
   {
       private Logger log;
       public KCB_HinhAnh()
       {
           log = LogManager.GetCurrentClassLogger();
       }
       /// <summary>
       /// ham
       /// </summary>
       /// <param name="objChidinhclsChitiet"></param>
       /// <returns></returns>
       public ActionResult PerformActionUpdate(KcbChidinhclsChitiet objChidinhclsChitiet)
       {
           try
           {
               using (var scope = new TransactionScope())
               {
                   using (var sp = new SharedDbConnectionScope())
                   {
                       SqlQuery qAssignDetail =
                             new Select().From(KcbChidinhclsChitiet.Schema).Where(KcbChidinhclsChitiet.Columns.IdChitietchidinh).IsEqualTo
                                 (objChidinhclsChitiet.IdChitietchidinh);
                       KcbChidinhclsChitiet objoldAssignDetail = qAssignDetail.ExecuteSingle<KcbChidinhclsChitiet>();
                       if (string.IsNullOrEmpty(objChidinhclsChitiet.ImgPath1))
                       {
                           objChidinhclsChitiet.ImgPath1 = objoldAssignDetail.ImgPath1;

                       }
                       if (string.IsNullOrEmpty(objChidinhclsChitiet.ImgPath2))
                       {
                           objChidinhclsChitiet.ImgPath2 = objoldAssignDetail.ImgPath2;

                       }
                       new Update(KcbChidinhclsChitiet.Schema)
                            .Set(KcbChidinhclsChitiet.Columns.KetLuan).EqualTo(objChidinhclsChitiet.KetLuan)
                            .Set(KcbChidinhclsChitiet.Columns.DeNghi).EqualTo(objChidinhclsChitiet.DeNghi)
                            //.Set(KcbChidinhclsChitiet.Columns.TrangThaiXacNhanCLS).EqualTo(objChidinhclsChitiet.TrangThaiXacNhanCLS)
                            .Set(KcbChidinhclsChitiet.Columns.KetQua).EqualTo(objChidinhclsChitiet.KetQua)
                            .Set(KcbChidinhclsChitiet.Columns.ImgPath1).EqualTo(objChidinhclsChitiet.ImgPath1)
                            .Set(KcbChidinhclsChitiet.Columns.ImgPath2).EqualTo(objChidinhclsChitiet.ImgPath2)
                             .Set(KcbChidinhclsChitiet.Columns.ImgPath3).EqualTo(objChidinhclsChitiet.ImgPath3)
                            .Set(KcbChidinhclsChitiet.Columns.ImgPath4).EqualTo(objChidinhclsChitiet.ImgPath4)
                            
                             //.Set(KcbChidinhclsChitiet.Columns.VungKs).EqualTo(objChidinhclsChitiet.VungKs)
                             .Set(KcbChidinhclsChitiet.Columns.NgayThuchien).EqualTo(objChidinhclsChitiet.NgayThuchien)
                             .Set(KcbChidinhclsChitiet.Columns.NguoiThuchien).EqualTo(objChidinhclsChitiet.NguoiThuchien)
                            .Where(KcbChidinhclsChitiet.Columns.IdChitietchidinh).IsEqualTo(objChidinhclsChitiet.IdChitietchidinh).Execute();
                   }
                   scope.Complete();
                   log.Info("Luu thong tin cua hinh ah thanh cong");
                   return ActionResult.Success;
               }
           }catch(Exception exception)
           {
               log.Error("loi luu hinh anh :"+exception.ToString());
               return ActionResult.Error;
           }
          
       }
       /// <summary>
       /// ham thực hiện việc cạp nhập thông tin của update
       /// </summary>
       /// <param name="objChidinhclsChitiet"></param>
       /// <param name="AceeptStatus"></param>
       /// <returns></returns>
       public ActionResult PerformActionUpdate(KcbChidinhclsChitiet objChidinhclsChitiet,bool xacnhan)
       {
           try
           {
               using (var scope = new TransactionScope())
               {
                   using (var sp = new SharedDbConnectionScope())
                   {
                       SqlQuery qAssignDetail =
                           new Select().From(KcbChidinhclsChitiet.Schema).Where(KcbChidinhclsChitiet.Columns.IdChitietchidinh).IsEqualTo
                               (objChidinhclsChitiet.IdChitietchidinh);
                       KcbChidinhclsChitiet objoldAssignDetail = qAssignDetail.ExecuteSingle<KcbChidinhclsChitiet>();
                       if(string.IsNullOrEmpty( objChidinhclsChitiet.ImgPath1))
                       {
                           objChidinhclsChitiet.ImgPath1 = objoldAssignDetail.ImgPath1;

                       }
                       if (string.IsNullOrEmpty(objChidinhclsChitiet.ImgPath2))
                       {
                           objChidinhclsChitiet.ImgPath2 = objoldAssignDetail.ImgPath2;

                       }
                       new Update(KcbChidinhclsChitiet.Schema)
                           .Set(KcbChidinhclsChitiet.Columns.KetLuan).EqualTo(objChidinhclsChitiet.KetLuan)
                           .Set(KcbChidinhclsChitiet.Columns.DeNghi).EqualTo(objChidinhclsChitiet.DeNghi)
                           .Set(KcbChidinhclsChitiet.Columns.TrangThai).EqualTo(objChidinhclsChitiet.TrangThai)
                           .Set(KcbChidinhclsChitiet.Columns.KetQua).EqualTo(objChidinhclsChitiet.KetQua)
                           .Set(KcbChidinhclsChitiet.Columns.ImgPath1).EqualTo(objChidinhclsChitiet.ImgPath1)
                           .Set(KcbChidinhclsChitiet.Columns.ImgPath2).EqualTo(objChidinhclsChitiet.ImgPath2)
                            .Set(KcbChidinhclsChitiet.Columns.ImgPath3).EqualTo(objChidinhclsChitiet.ImgPath3)
                           .Set(KcbChidinhclsChitiet.Columns.ImgPath4).EqualTo(objChidinhclsChitiet.ImgPath4)
                           
                           //.Set(KcbChidinhclsChitiet.Columns.VungKs).EqualTo(objChidinhclsChitiet.VungKs)
                           .Set(KcbChidinhclsChitiet.Columns.NgayThuchien).EqualTo(objChidinhclsChitiet.NgayThuchien)
                           .Set(KcbChidinhclsChitiet.Columns.NguoiThuchien).EqualTo(objChidinhclsChitiet.NguoiThuchien)
                           .Where(KcbChidinhclsChitiet.Columns.IdChitietchidinh).IsEqualTo(objChidinhclsChitiet.IdChitietchidinh).
                           Execute();
                       //if (xacnhan) 
                           UpdateXacNhanDaThucHien((int)objChidinhclsChitiet.IdChitietchidinh, (int)objChidinhclsChitiet.TrangThai, (int)objChidinhclsChitiet.TrangthaiXacnhan);
                   }
                   scope.Complete();
                   return ActionResult.Success;
               }
           }
           catch (Exception exception)
           {
               return ActionResult.Error;
           }

       }
       public ActionResult UpdateXacNhanDaThucHien(int IdChitietchidinh, int TrangThai, int TrangthaiXacnhan)
       {
           try
           {
               using (var scope = new TransactionScope())
               {
                   using (var sps = new SharedDbConnectionScope())
                   {

                       new Update(KcbChidinhclsChitiet.Schema)

                            .Set(KcbChidinhclsChitiet.Columns.TrangThai).EqualTo(TrangThai)
                            .Set(KcbChidinhclsChitiet.Columns.TrangthaiXacnhan).EqualTo(TrangthaiXacnhan)
                            .Set(KcbChidinhclsChitiet.Columns.NgayThuchien).EqualTo(globalVariables.SysDate)
                            .Set(KcbChidinhclsChitiet.Columns.NguoiThuchien).EqualTo(globalVariables.UserName)
                            .Where(KcbChidinhclsChitiet.Columns.IdChitietchidinh).IsEqualTo(IdChitietchidinh).
                            Execute();
                   }
                   scope.Complete();
                   return ActionResult.Success;
               }
           }
           catch (Exception exception)
           {
               return ActionResult.Error;
           }

       }

       string path = Application.StartupPath;
       /// <summary>
       /// hmf thực hiện trả lại thông tin của đường dẫn
       /// </summary>
       /// <param name="v_PatientCode"></param>
       /// <param name="v_Patient_Id"></param>
       /// <returns></returns>
       public string GetPathImageRadio(string v_PatientCode,string v_Patient_Id)
       {
           string ServerPath = GetImageServerPath();
           ServerPath +="\\"+v_Patient_Id+"\\" + v_PatientCode;

           return ServerPath;
       }
       public string GetPathOpenFile(int FileOrder)
       {
           string sPathName =path+@"\Path\ImgPath.txt";
           string sPath = "C:";
           if (File.Exists(sPathName))
           {
             sPath = System.IO.File.ReadAllLines(sPathName)[FileOrder];
           }
           return sPath;
       }
       public void SavePathOpenFile1(string sPathFile)
       {
           string sPathName = path+@"\Path\ImgPath.txt";
           //string FileOpen = "";
           string sPath1 = "C:";
           if (File.Exists(sPathName))
           {
               sPath1 = System.IO.File.ReadAllLines(sPathName)[1];
           }
           string[] lines = {sPathFile, sPath1};
           //System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);
           if (File.Exists(sPathName))
           {
               System.IO.File.WriteAllLines(sPathName, lines);
           }
           else
           {
               System.IO.File.WriteAllLines(sPathName, lines);
           }
       }
       /// <summary>
       /// hàm thực hiện ghi thông tin vào file text
       /// </summary>
       /// <param name="sPathFile"></param>
       public void SavePathOpenFile2(string sPathFile)
       {
           string sPathName =path+@"\Path\ImgPath.txt";
           //string FileOpen = "";
           string sPath1 = "C:";
           if(File.Exists(sPathName))
           {
               sPath1=System.IO.File.ReadAllLines(sPathName)[0];
           }
           string[] lines = { sPath1,sPathFile };
           //System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);
           if (File.Exists(sPathName))
           {
               System.IO.File.WriteAllLines(sPathName, lines);  
           }
           else
           {
               System.IO.File.WriteAllLines(sPathName, lines);
           }
       }

       public string GetImageServerPath()
       {
           SysConfigRadio objConfigRadio = SysConfigRadio.FetchByID(1);
           string ServerPath = "";
           if(objConfigRadio!=null)
           {
               //string sPathName 
               ServerPath= objConfigRadio.PathUNC;

           }
           else
           {
               Utility.ShowMsg("Bạn phải chưa khởi tạo Config, Bạn phải cấu hình hệ thống", "Thông báo");
               ServerPath = "";
           }
           return ServerPath;

       }
       
      
     
      
      
       public ActionResult UpdateSysConfigRadio(SysConfigRadio objConfigRadio)
       {
            try
           {
               using (var scope = new TransactionScope())
               {
                   using (var sp = new SharedDbConnectionScope())
                   {
                       SqlQuery q =
                           new SqlQuery().From(SysConfigRadio.Schema).Where(SysConfigRadio.Columns.SysId).IsEqualTo(1);
                       if(q.GetRecordCount()<=0)
                       {
                           objConfigRadio.IsNew = true;
                           objConfigRadio.Save();
                       }else
                       {
                           new Update(SysConfigRadio.Schema)
                               .Set(SysConfigRadio.PassWordColumn).EqualTo(objConfigRadio.PassWord)
                               .Set(SysConfigRadio.UserNameColumn).EqualTo(objConfigRadio.UserName)
                               .Set(SysConfigRadio.DomainColumn).EqualTo(objConfigRadio.Domain)
                               .Set(SysConfigRadio.PathUNCColumn).EqualTo(objConfigRadio.PathUNC)
                               .Where(SysConfigRadio.SysIdColumn).IsEqualTo(1).Execute();
                       }
                   }
                   scope.Complete();
                   return ActionResult.Success;
               }
           }
           catch (Exception exception)
            {
                return ActionResult.Error;
            }
       }
      
   }
}
