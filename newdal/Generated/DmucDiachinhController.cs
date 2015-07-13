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
    /// Controller class for dmuc_diachinh
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class DmucDiachinhController
    {
        // Preload our schema..
        DmucDiachinh thisSchemaLoad = new DmucDiachinh();
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
        public DmucDiachinhCollection FetchAll()
        {
            DmucDiachinhCollection coll = new DmucDiachinhCollection();
            Query qry = new Query(DmucDiachinh.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DmucDiachinhCollection FetchByID(object MaDiachinh)
        {
            DmucDiachinhCollection coll = new DmucDiachinhCollection().Where("ma_diachinh", MaDiachinh).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public DmucDiachinhCollection FetchByQuery(Query qry)
        {
            DmucDiachinhCollection coll = new DmucDiachinhCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object MaDiachinh)
        {
            return (DmucDiachinh.Delete(MaDiachinh) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object MaDiachinh)
        {
            return (DmucDiachinh.Destroy(MaDiachinh) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string MaDiachinh,string TenDiachinh,string MaCha,short? SttHthi,byte? LoaiDiachinh,string MotaThem)
	    {
		    DmucDiachinh item = new DmucDiachinh();
		    
            item.MaDiachinh = MaDiachinh;
            
            item.TenDiachinh = TenDiachinh;
            
            item.MaCha = MaCha;
            
            item.SttHthi = SttHthi;
            
            item.LoaiDiachinh = LoaiDiachinh;
            
            item.MotaThem = MotaThem;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string MaDiachinh,string TenDiachinh,string MaCha,short? SttHthi,byte? LoaiDiachinh,string MotaThem)
	    {
		    DmucDiachinh item = new DmucDiachinh();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.MaDiachinh = MaDiachinh;
				
			item.TenDiachinh = TenDiachinh;
				
			item.MaCha = MaCha;
				
			item.SttHthi = SttHthi;
				
			item.LoaiDiachinh = LoaiDiachinh;
				
			item.MotaThem = MotaThem;
				
	        item.Save(UserName);
	    }
    }
}
