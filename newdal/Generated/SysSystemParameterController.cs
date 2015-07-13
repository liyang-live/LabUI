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
    /// Controller class for Sys_SystemParameters
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class SysSystemParameterController
    {
        // Preload our schema..
        SysSystemParameter thisSchemaLoad = new SysSystemParameter();
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
        public SysSystemParameterCollection FetchAll()
        {
            SysSystemParameterCollection coll = new SysSystemParameterCollection();
            Query qry = new Query(SysSystemParameter.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysSystemParameterCollection FetchByID(object Id)
        {
            SysSystemParameterCollection coll = new SysSystemParameterCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public SysSystemParameterCollection FetchByQuery(Query qry)
        {
            SysSystemParameterCollection coll = new SysSystemParameterCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (SysSystemParameter.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (SysSystemParameter.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string FpSBranchID,string SName,string SDataType,string SValue,int IMonth,int IYear,short IStatus,string SDesc)
	    {
		    SysSystemParameter item = new SysSystemParameter();
		    
            item.FpSBranchID = FpSBranchID;
            
            item.SName = SName;
            
            item.SDataType = SDataType;
            
            item.SValue = SValue;
            
            item.IMonth = IMonth;
            
            item.IYear = IYear;
            
            item.IStatus = IStatus;
            
            item.SDesc = SDesc;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(long Id,string FpSBranchID,string SName,string SDataType,string SValue,int IMonth,int IYear,short IStatus,string SDesc)
	    {
		    SysSystemParameter item = new SysSystemParameter();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.FpSBranchID = FpSBranchID;
				
			item.SName = SName;
				
			item.SDataType = SDataType;
				
			item.SValue = SValue;
				
			item.IMonth = IMonth;
				
			item.IYear = IYear;
				
			item.IStatus = IStatus;
				
			item.SDesc = SDesc;
				
	        item.Save(UserName);
	    }
    }
}
