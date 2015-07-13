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
    /// Controller class for Sys_Administrator
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysAdministratorController
    {
        // Preload our schema..
        SysAdministrator thisSchemaLoad = new SysAdministrator();
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
        public SysAdministratorCollection FetchAll()
        {
            SysAdministratorCollection coll = new SysAdministratorCollection();
            Query qry = new Query(SysAdministrator.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysAdministratorCollection FetchByID(object PkSAdminID)
        {
            SysAdministratorCollection coll = new SysAdministratorCollection().Where("PK_sAdminID", PkSAdminID).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysAdministratorCollection FetchByQuery(Query qry)
        {
            SysAdministratorCollection coll = new SysAdministratorCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object PkSAdminID)
        {
            return (SysAdministrator.Delete(PkSAdminID) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object PkSAdminID)
        {
            return (SysAdministrator.Destroy(PkSAdminID) == 1);
        }
        
        
        
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(string PkSAdminID,string FpSBranchID)
        {
            Query qry = new Query(SysAdministrator.Schema);
            qry.QueryType = QueryType.Delete;
            qry.AddWhere("PkSAdminID", PkSAdminID).AND("FpSBranchID", FpSBranchID);
            qry.Execute();
            return (true);
        }        
       
    	
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string PkSAdminID,string FpSBranchID,string PkSCreator,string SPWD,int? IMonth,int? IYear,string Website,byte[] Logo)
	    {
		    SysAdministrator item = new SysAdministrator();
		    
            item.PkSAdminID = PkSAdminID;
            
            item.FpSBranchID = FpSBranchID;
            
            item.PkSCreator = PkSCreator;
            
            item.SPWD = SPWD;
            
            item.IMonth = IMonth;
            
            item.IYear = IYear;
            
            item.Website = Website;
            
            item.Logo = Logo;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(string PkSAdminID,string FpSBranchID,string PkSCreator,string SPWD,int? IMonth,int? IYear,string Website,byte[] Logo)
	    {
		    SysAdministrator item = new SysAdministrator();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.PkSAdminID = PkSAdminID;
				
			item.FpSBranchID = FpSBranchID;
				
			item.PkSCreator = PkSCreator;
				
			item.SPWD = SPWD;
				
			item.IMonth = IMonth;
				
			item.IYear = IYear;
				
			item.Website = Website;
				
			item.Logo = Logo;
				
	        item.Save(UserName);
	    }
    }
}
