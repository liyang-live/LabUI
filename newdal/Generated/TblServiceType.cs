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
	/// Strongly-typed collection for the TblServiceType class.
	/// </summary>
    [Serializable]
	public partial class TblServiceTypeCollection : ActiveList<TblServiceType, TblServiceTypeCollection>
	{	   
		public TblServiceTypeCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>TblServiceTypeCollection</returns>
		public TblServiceTypeCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                TblServiceType o = this[i];
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
	/// This is an ActiveRecord class which wraps the tbl_ServiceType table.
	/// </summary>
	[Serializable]
	public partial class TblServiceType : ActiveRecord<TblServiceType>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public TblServiceType()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public TblServiceType(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public TblServiceType(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public TblServiceType(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("tbl_ServiceType", TableType.Table, DataService.GetInstance("ORM"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
				colvarId.ColumnName = "ID";
				colvarId.DataType = DbType.Int16;
				colvarId.MaxLength = 0;
				colvarId.AutoIncrement = true;
				colvarId.IsNullable = false;
				colvarId.IsPrimaryKey = true;
				colvarId.IsForeignKey = false;
				colvarId.IsReadOnly = false;
				colvarId.DefaultSetting = @"";
				colvarId.ForeignKeyTableName = "";
				schema.Columns.Add(colvarId);
				
				TableSchema.TableColumn colvarSName = new TableSchema.TableColumn(schema);
				colvarSName.ColumnName = "sName";
				colvarSName.DataType = DbType.String;
				colvarSName.MaxLength = 50;
				colvarSName.AutoIncrement = false;
				colvarSName.IsNullable = false;
				colvarSName.IsPrimaryKey = false;
				colvarSName.IsForeignKey = false;
				colvarSName.IsReadOnly = false;
				colvarSName.DefaultSetting = @"";
				colvarSName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSName);
				
				TableSchema.TableColumn colvarSDesc = new TableSchema.TableColumn(schema);
				colvarSDesc.ColumnName = "sDesc";
				colvarSDesc.DataType = DbType.String;
				colvarSDesc.MaxLength = 100;
				colvarSDesc.AutoIncrement = false;
				colvarSDesc.IsNullable = true;
				colvarSDesc.IsPrimaryKey = false;
				colvarSDesc.IsForeignKey = false;
				colvarSDesc.IsReadOnly = false;
				colvarSDesc.DefaultSetting = @"";
				colvarSDesc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSDesc);
				
				TableSchema.TableColumn colvarIntSTT = new TableSchema.TableColumn(schema);
				colvarIntSTT.ColumnName = "intSTT";
				colvarIntSTT.DataType = DbType.Int16;
				colvarIntSTT.MaxLength = 0;
				colvarIntSTT.AutoIncrement = false;
				colvarIntSTT.IsNullable = false;
				colvarIntSTT.IsPrimaryKey = false;
				colvarIntSTT.IsForeignKey = false;
				colvarIntSTT.IsReadOnly = false;
				colvarIntSTT.DefaultSetting = @"";
				colvarIntSTT.ForeignKeyTableName = "";
				schema.Columns.Add(colvarIntSTT);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ORM"].AddSchema("tbl_ServiceType",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("Id")]
		[Bindable(true)]
		public short Id 
		{
			get { return GetColumnValue<short>(Columns.Id); }
			set { SetColumnValue(Columns.Id, value); }
		}
		  
		[XmlAttribute("SName")]
		[Bindable(true)]
		public string SName 
		{
			get { return GetColumnValue<string>(Columns.SName); }
			set { SetColumnValue(Columns.SName, value); }
		}
		  
		[XmlAttribute("SDesc")]
		[Bindable(true)]
		public string SDesc 
		{
			get { return GetColumnValue<string>(Columns.SDesc); }
			set { SetColumnValue(Columns.SDesc, value); }
		}
		  
		[XmlAttribute("IntSTT")]
		[Bindable(true)]
		public short IntSTT 
		{
			get { return GetColumnValue<short>(Columns.IntSTT); }
			set { SetColumnValue(Columns.IntSTT, value); }
		}
		
		#endregion
		
		
			
		
		//no foreign key tables defined (0)
		
		
		
		//no ManyToMany tables defined (0)
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varSName,string varSDesc,short varIntSTT)
		{
			TblServiceType item = new TblServiceType();
			
			item.SName = varSName;
			
			item.SDesc = varSDesc;
			
			item.IntSTT = varIntSTT;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(short varId,string varSName,string varSDesc,short varIntSTT)
		{
			TblServiceType item = new TblServiceType();
			
				item.Id = varId;
			
				item.SName = varSName;
			
				item.SDesc = varSDesc;
			
				item.IntSTT = varIntSTT;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn SNameColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn SDescColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn IntSTTColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string Id = @"ID";
			 public static string SName = @"sName";
			 public static string SDesc = @"sDesc";
			 public static string IntSTT = @"intSTT";
						
		}
		#endregion
		
		#region Update PK Collections
		
        #endregion
    
        #region Deep Save
		
        #endregion
	}
}
