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
    /// Controller class for L_ObjectType
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class LObjectTypeController
    {
        // Preload our schema..
        LObjectType thisSchemaLoad = new LObjectType();
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
        public LObjectTypeCollection FetchAll()
        {
            LObjectTypeCollection coll = new LObjectTypeCollection();
            Query qry = new Query(LObjectType.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public LObjectTypeCollection FetchByID(object Id)
        {
            LObjectTypeCollection coll = new LObjectTypeCollection().Where("ID", Id).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public LObjectTypeCollection FetchByQuery(Query qry)
        {
            LObjectTypeCollection coll = new LObjectTypeCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object Id)
        {
            return (LObjectType.Delete(Id) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object Id)
        {
            return (LObjectType.Destroy(Id) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(string SName,string SDesc)
	    {
		    LObjectType item = new LObjectType();
		    
            item.SName = SName;
            
            item.SDesc = SDesc;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(short Id,string SName,string SDesc)
	    {
		    LObjectType item = new LObjectType();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.Id = Id;
				
			item.SName = SName;
				
			item.SDesc = SDesc;
				
	        item.Save(UserName);
	    }
    }
}
