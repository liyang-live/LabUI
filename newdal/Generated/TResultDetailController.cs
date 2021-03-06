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
    /// Controller class for T_RESULT_DETAIL
    /// </summary>
    [System.ComponentModel.DataObject]
    public partial class TResultDetailController
    {
        // Preload our schema..
        TResultDetail thisSchemaLoad = new TResultDetail();
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
        public TResultDetailCollection FetchAll()
        {
            TResultDetailCollection coll = new TResultDetailCollection();
            Query qry = new Query(TResultDetail.Schema);
            coll.LoadAndCloseReader(qry.ExecuteReader());
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public TResultDetailCollection FetchByID(object TestDetailId)
        {
            TResultDetailCollection coll = new TResultDetailCollection().Where("TestDetail_ID", TestDetailId).Load();
            return coll;
        }
		
		[DataObjectMethod(DataObjectMethodType.Select, false)]
        public TResultDetailCollection FetchByQuery(Query qry)
        {
            TResultDetailCollection coll = new TResultDetailCollection();
            coll.LoadAndCloseReader(qry.ExecuteReader()); 
            return coll;
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public bool Delete(object TestDetailId)
        {
            return (TResultDetail.Delete(TestDetailId) == 1);
        }
        [DataObjectMethod(DataObjectMethodType.Delete, false)]
        public bool Destroy(object TestDetailId)
        {
            return (TResultDetail.Destroy(TestDetailId) == 1);
        }
        
        
    	
	    /// <summary>
	    /// Inserts a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
	    public void Insert(decimal? TestId,decimal? PatientId,int? TestTypeId,DateTime? TestDate,string TestSequence,int? DataSequence,string TestResult,string NormalLevelW,string NormalLevel,string MeasureUnit,string ParaName,short ParaStatus,string Note,bool? PrintData,string Barcode,int? UpdateNum,string TestDataId,decimal? DeviceId,short? IsNormal,int? SentStatus,DateTime? TestDateCreated)
	    {
		    TResultDetail item = new TResultDetail();
		    
            item.TestId = TestId;
            
            item.PatientId = PatientId;
            
            item.TestTypeId = TestTypeId;
            
            item.TestDate = TestDate;
            
            item.TestSequence = TestSequence;
            
            item.DataSequence = DataSequence;
            
            item.TestResult = TestResult;
            
            item.NormalLevelW = NormalLevelW;
            
            item.NormalLevel = NormalLevel;
            
            item.MeasureUnit = MeasureUnit;
            
            item.ParaName = ParaName;
            
            item.ParaStatus = ParaStatus;
            
            item.Note = Note;
            
            item.PrintData = PrintData;
            
            item.Barcode = Barcode;
            
            item.UpdateNum = UpdateNum;
            
            item.TestDataId = TestDataId;
            
            item.DeviceId = DeviceId;
            
            item.IsNormal = IsNormal;
            
            item.SentStatus = SentStatus;
            
            item.TestDateCreated = TestDateCreated;
            
	    
		    item.Save(UserName);
	    }
    	
	    /// <summary>
	    /// Updates a record, can be used with the Object Data Source
	    /// </summary>
        [DataObjectMethod(DataObjectMethodType.Update, true)]
	    public void Update(decimal TestDetailId,decimal? TestId,decimal? PatientId,int? TestTypeId,DateTime? TestDate,string TestSequence,int? DataSequence,string TestResult,string NormalLevelW,string NormalLevel,string MeasureUnit,string ParaName,short ParaStatus,string Note,bool? PrintData,string Barcode,int? UpdateNum,string TestDataId,decimal? DeviceId,short? IsNormal,int? SentStatus,DateTime? TestDateCreated)
	    {
		    TResultDetail item = new TResultDetail();
	        item.MarkOld();
	        item.IsLoaded = true;
		    
			item.TestDetailId = TestDetailId;
				
			item.TestId = TestId;
				
			item.PatientId = PatientId;
				
			item.TestTypeId = TestTypeId;
				
			item.TestDate = TestDate;
				
			item.TestSequence = TestSequence;
				
			item.DataSequence = DataSequence;
				
			item.TestResult = TestResult;
				
			item.NormalLevelW = NormalLevelW;
				
			item.NormalLevel = NormalLevel;
				
			item.MeasureUnit = MeasureUnit;
				
			item.ParaName = ParaName;
				
			item.ParaStatus = ParaStatus;
				
			item.Note = Note;
				
			item.PrintData = PrintData;
				
			item.Barcode = Barcode;
				
			item.UpdateNum = UpdateNum;
				
			item.TestDataId = TestDataId;
				
			item.DeviceId = DeviceId;
				
			item.IsNormal = IsNormal;
				
			item.SentStatus = SentStatus;
				
			item.TestDateCreated = TestDateCreated;
				
	        item.Save(UserName);
	    }
    }
}
