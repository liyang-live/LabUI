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
	/// Strongly-typed collection for the TblRegServiceDetail class.
	/// </summary>
    [Serializable]
	public partial class TblRegServiceDetailCollection : ActiveList<TblRegServiceDetail, TblRegServiceDetailCollection>
	{	   
		public TblRegServiceDetailCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblRegServiceDetailCollection</returns>
		public TblRegServiceDetailCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblRegServiceDetail o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }
		
		
	}
	/// <summary>
	/// This is an ActiveRecord class which wraps the tbl_RegServiceDetail table.
	/// </summary>
	[Serializable]
	public partial class TblRegServiceDetail : ActiveRecord<TblRegServiceDetail>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblRegServiceDetail()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblRegServiceDetail(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblRegServiceDetail(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblRegServiceDetail(string columnName, object columnValue)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByParam(columnName,columnValue);
		}
		
		protected static void SetSQLProps() { GetTableSchema(); }
		
		#endregion
		
		#region Schema and Query Accessor	
		public static Query CreateQuery() { return new Query(Schema); }
		public static TableSchema.Table Schema
		{
			get
			{
				if (BaseSchema == null)
					SetSQLProps();
				return BaseSchema;
			}
		}
		
		private static void GetTableSchema() 
		{
			if(!IsSchemaInitialized)
			{
				//Schema declaration
				TableSchema.Table schema = new TableSchema.Table("tbl_RegServiceDetail", TableType.Table, DataService.GetInstance("ORM"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarRegID = new TableSchema.TableColumn(schema);
				colvarRegID.ColumnName = "RegID";
				colvarRegID.DataType = DbType.Int64;
				colvarRegID.MaxLength = 0;
				colvarRegID.AutoIncrement = false;
				colvarRegID.IsNullable = false;
				colvarRegID.IsPrimaryKey = true;
				colvarRegID.IsForeignKey = false;
				colvarRegID.IsReadOnly = false;
				colvarRegID.DefaultSetting = @"";
				colvarRegID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarRegID);
				
				TableSchema.TableColumn colvarTestID = new TableSchema.TableColumn(schema);
				colvarTestID.ColumnName = "TestID";
				colvarTestID.DataType = DbType.Int16;
				colvarTestID.MaxLength = 0;
				colvarTestID.AutoIncrement = false;
				colvarTestID.IsNullable = false;
				colvarTestID.IsPrimaryKey = true;
				colvarTestID.IsForeignKey = false;
				colvarTestID.IsReadOnly = false;
				colvarTestID.DefaultSetting = @"";
				colvarTestID.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTestID);
				
				TableSchema.TableColumn colvarFPrice = new TableSchema.TableColumn(schema);
				colvarFPrice.ColumnName = "fPrice";
				colvarFPrice.DataType = DbType.Currency;
				colvarFPrice.MaxLength = 0;
				colvarFPrice.AutoIncrement = false;
				colvarFPrice.IsNullable = false;
				colvarFPrice.IsPrimaryKey = false;
				colvarFPrice.IsForeignKey = false;
				colvarFPrice.IsReadOnly = false;
				colvarFPrice.DefaultSetting = @"";
				colvarFPrice.ForeignKeyTableName = "";
				schema.Columns.Add(colvarFPrice);
				
				TableSchema.TableColumn colvarNTime = new TableSchema.TableColumn(schema);
				colvarNTime.ColumnName = "nTime";
				colvarNTime.DataType = DbType.Int16;
				colvarNTime.MaxLength = 0;
				colvarNTime.AutoIncrement = false;
				colvarNTime.IsNullable = true;
				colvarNTime.IsPrimaryKey = false;
				colvarNTime.IsForeignKey = false;
				colvarNTime.IsReadOnly = false;
				colvarNTime.DefaultSetting = @"";
				colvarNTime.ForeignKeyTableName = "";
				schema.Columns.Add(colvarNTime);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ORM"].AddSchema("tbl_RegServiceDetail",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("RegID")]
		[Bindable(true)]
		public long RegID 
		{
			get { return GetColumnValue<long>(Columns.RegID); }
			set { SetColumnValue(Columns.RegID, value); }
		}
		  
		[XmlAttribute("TestID")]
		[Bindable(true)]
		public short TestID 
		{
			get { return GetColumnValue<short>(Columns.TestID); }
			set { SetColumnValue(Columns.TestID, value); }
		}
		  
		[XmlAttribute("FPrice")]
		[Bindable(true)]
		public decimal FPrice 
		{
			get { return GetColumnValue<decimal>(Columns.FPrice); }
			set { SetColumnValue(Columns.FPrice, value); }
		}
		  
		[XmlAttribute("NTime")]
		[Bindable(true)]
		public short? NTime 
		{
			get { return GetColumnValue<short?>(Columns.NTime); }
			set { SetColumnValue(Columns.NTime, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(long varRegID,short varTestID,decimal varFPrice,short? varNTime)
		{
			TblRegServiceDetail item = new TblRegServiceDetail();
			
			item.RegID = varRegID;
			
			item.TestID = varTestID;
			
			item.FPrice = varFPrice;
			
			item.NTime = varNTime;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(long varRegID,short varTestID,decimal varFPrice,short? varNTime)
		{
			TblRegServiceDetail item = new TblRegServiceDetail();
			
				item.RegID = varRegID;
			
				item.TestID = varTestID;
			
				item.FPrice = varFPrice;
			
				item.NTime = varNTime;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn RegIDColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn TestIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn FPriceColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn NTimeColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string RegID = @"RegID";
			 public static string TestID = @"TestID";
			 public static string FPrice = @"fPrice";
			 public static string NTime = @"nTime";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
