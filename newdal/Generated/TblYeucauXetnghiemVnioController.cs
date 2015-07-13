using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
// <auto-generated />
namespace LIS.DAL
{
    /// <summary>
    /// Controller class for tblYeucauXetnghiem_VNIO
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TblYeucauXetnghiemVnioController
    {
        // Preload our schema..
        TblYeucauXetnghiemVnio thisSchemaLoad = new TblYeucauXetnghiemVnio();
        private string userName = String.Empty;
        protected string UserName
        {
            get
            {
				if (userName.Length == 0) 
				{
    				if (System.Web.HttpContext.Current != null)
    				{
						userName=System.Web.HttpContext.Current.User.Identity.Name;
					}
					else
					{
						userName=System.Threading.Thread.CurrentPrincipal.Identity.Name;
					}
				}
				return userName;
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public TblYeucauXetnghiemVnioCollection FetchAll()
        {
            TblYeucauXetnghiemVnioCollection coll = new TblYeucauXetnghiemVnioCollection();
            Query qry = new Query(TblYeucauXetnghiemVnio.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TblYeucauXetnghiemVnioCollection FetchByID(object IdXetnghiem)
        {
            TblYeucauXetnghiemVnioCollection coll = new TblYeucauXetnghiemVnioCollection().Where("Id_Xetnghiem", IdXetnghiem).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TblYeucauXetnghiemVnioCollection FetchByQuery(Query qry)
        {
            TblYeucauXetnghiemVnioCollection coll = new TblYeucauXetnghiemVnioCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object IdXetnghiem)
        {
            return (TblYeucauXetnghiemVnio.Delete(IdXetnghiem) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object IdXetnghiem)
        {
            return (TblYeucauXetnghiemVnio.Destroy(IdXetnghiem) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(short? IdCanLamSangThucHien,short? ThucHienCho,short? TrangThaiThucHien,short? YeuCauXetNghiemId,long? Id,string MaBenhNhan,string Barcode,int? TestTypeId,string Sophieu,DateTime? TestDate,bool? IsTestName,bool? SendStatus)
	    {
		    TblYeucauXetnghiemVnio item = new TblYeucauXetnghiemVnio();
		    
            item.IdCanLamSangThucHien = IdCanLamSangThucHien;
            
            item.ThucHienCho = ThucHienCho;
            
            item.TrangThaiThucHien = TrangThaiThucHien;
            
            item.YeuCauXetNghiemId = YeuCauXetNghiemId;
            
            item.Id = Id;
            
            item.MaBenhNhan = MaBenhNhan;
            
            item.Barcode = Barcode;
            
            item.TestTypeId = TestTypeId;
            
            item.Sophieu = Sophieu;
            
            item.TestDate = TestDate;
            
            item.IsTestName = IsTestName;
            
            item.SendStatus = SendStatus;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(long IdXetnghiem,short? IdCanLamSangThucHien,short? ThucHienCho,short? TrangThaiThucHien,short? YeuCauXetNghiemId,long? Id,string MaBenhNhan,string Barcode,int? TestTypeId,string Sophieu,DateTime? TestDate,bool? IsTestName,bool? SendStatus)
	    {
		    TblYeucauXetnghiemVnio item = new TblYeucauXetnghiemVnio();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.IdXetnghiem = IdXetnghiem;
				
			item.IdCanLamSangThucHien = IdCanLamSangThucHien;
				
			item.ThucHienCho = ThucHienCho;
				
			item.TrangThaiThucHien = TrangThaiThucHien;
				
			item.YeuCauXetNghiemId = YeuCauXetNghiemId;
				
			item.Id = Id;
				
			item.MaBenhNhan = MaBenhNhan;
				
			item.Barcode = Barcode;
				
			item.TestTypeId = TestTypeId;
				
			item.Sophieu = Sophieu;
				
			item.TestDate = TestDate;
				
			item.IsTestName = IsTestName;
				
			item.SendStatus = SendStatus;
				
	        item.Save(UserName);
	    }
    }
}