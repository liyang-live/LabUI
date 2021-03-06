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
	/// Strongly-typed collection for the SysUser class.
	/// </summary>
    [Serializable]
	public partial class SysUserCollection : ActiveList<SysUser, SysUserCollection>
	{	   
		public SysUserCollection() {}
        
        /// <summary>
		/// Filters an existing collection based on the set criteria. This is an in-memory filter
		/// Thanks to developingchris for this!
        /// </summary>
        /// <returns>SysUserCollection</returns>
		public SysUserCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                SysUser o = this[i];
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
	/// This is an ActiveRecord class which wraps the Sys_Users table.
	/// </summary>
	[Serializable]
	public partial class SysUser : ActiveRecord<SysUser>, IActiveRecord
	{
		#region .ctors and Default Settings
		
		public SysUser()
		{
		  SetSQLProps();
		  InitSetDefaults();
		  MarkNew();
		}
		
		private void InitSetDefaults() { SetDefaults(); }
		
		public SysUser(bool useDatabaseDefaults)
		{
			SetSQLProps();
			if(useDatabaseDefaults)
				ForceDefaults();
			MarkNew();
		}
        
		public SysUser(object keyID)
		{
			SetSQLProps();
			InitSetDefaults();
			LoadByKey(keyID);
		}
		 
		public SysUser(string columnName, object columnValue)
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
				TableSchema.Table schema = new TableSchema.Table("Sys_Users", TableType.Table, DataService.GetInstance("ORM"));
				schema.Columns = new TableSchema.TableColumnCollection();
				schema.SchemaName = @"dbo";
				//columns
				
				TableSchema.TableColumn colvarPkSuid = new TableSchema.TableColumn(schema);
				colvarPkSuid.ColumnName = "PK_sUID";
				colvarPkSuid.DataType = DbType.String;
				colvarPkSuid.MaxLength = 50;
				colvarPkSuid.AutoIncrement = false;
				colvarPkSuid.IsNullable = false;
				colvarPkSuid.IsPrimaryKey = true;
				colvarPkSuid.IsForeignKey = false;
				colvarPkSuid.IsReadOnly = false;
				colvarPkSuid.DefaultSetting = @"";
				colvarPkSuid.ForeignKeyTableName = "";
				schema.Columns.Add(colvarPkSuid);
				
				TableSchema.TableColumn colvarFpSBranchID = new TableSchema.TableColumn(schema);
				colvarFpSBranchID.ColumnName = "FP_sBranchID";
				colvarFpSBranchID.DataType = DbType.String;
				colvarFpSBranchID.MaxLength = 10;
				colvarFpSBranchID.AutoIncrement = false;
				colvarFpSBranchID.IsNullable = false;
				colvarFpSBranchID.IsPrimaryKey = true;
				colvarFpSBranchID.IsForeignKey = true;
				colvarFpSBranchID.IsReadOnly = false;
				colvarFpSBranchID.DefaultSetting = @"";
				
					colvarFpSBranchID.ForeignKeyTableName = "Sys_ManagementUnit";
				schema.Columns.Add(colvarFpSBranchID);
				
				TableSchema.TableColumn colvarSPwd = new TableSchema.TableColumn(schema);
				colvarSPwd.ColumnName = "sPwd";
				colvarSPwd.DataType = DbType.String;
				colvarSPwd.MaxLength = 50;
				colvarSPwd.AutoIncrement = false;
				colvarSPwd.IsNullable = true;
				colvarSPwd.IsPrimaryKey = false;
				colvarSPwd.IsForeignKey = false;
				colvarSPwd.IsReadOnly = false;
				colvarSPwd.DefaultSetting = @"";
				colvarSPwd.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSPwd);
				
				TableSchema.TableColumn colvarSFullName = new TableSchema.TableColumn(schema);
				colvarSFullName.ColumnName = "sFullName";
				colvarSFullName.DataType = DbType.String;
				colvarSFullName.MaxLength = 100;
				colvarSFullName.AutoIncrement = false;
				colvarSFullName.IsNullable = true;
				colvarSFullName.IsPrimaryKey = false;
				colvarSFullName.IsForeignKey = false;
				colvarSFullName.IsReadOnly = false;
				colvarSFullName.DefaultSetting = @"";
				colvarSFullName.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSFullName);
				
				TableSchema.TableColumn colvarSDepart = new TableSchema.TableColumn(schema);
				colvarSDepart.ColumnName = "sDepart";
				colvarSDepart.DataType = DbType.String;
				colvarSDepart.MaxLength = 100;
				colvarSDepart.AutoIncrement = false;
				colvarSDepart.IsNullable = true;
				colvarSDepart.IsPrimaryKey = false;
				colvarSDepart.IsForeignKey = false;
				colvarSDepart.IsReadOnly = false;
				colvarSDepart.DefaultSetting = @"";
				colvarSDepart.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSDepart);
				
				TableSchema.TableColumn colvarTDateCreated = new TableSchema.TableColumn(schema);
				colvarTDateCreated.ColumnName = "tDateCreated";
				colvarTDateCreated.DataType = DbType.DateTime;
				colvarTDateCreated.MaxLength = 0;
				colvarTDateCreated.AutoIncrement = false;
				colvarTDateCreated.IsNullable = true;
				colvarTDateCreated.IsPrimaryKey = false;
				colvarTDateCreated.IsForeignKey = false;
				colvarTDateCreated.IsReadOnly = false;
				colvarTDateCreated.DefaultSetting = @"";
				colvarTDateCreated.ForeignKeyTableName = "";
				schema.Columns.Add(colvarTDateCreated);
				
				TableSchema.TableColumn colvarISecurityLevel = new TableSchema.TableColumn(schema);
				colvarISecurityLevel.ColumnName = "iSecurityLevel";
				colvarISecurityLevel.DataType = DbType.Int16;
				colvarISecurityLevel.MaxLength = 0;
				colvarISecurityLevel.AutoIncrement = false;
				colvarISecurityLevel.IsNullable = true;
				colvarISecurityLevel.IsPrimaryKey = false;
				colvarISecurityLevel.IsForeignKey = false;
				colvarISecurityLevel.IsReadOnly = false;
				colvarISecurityLevel.DefaultSetting = @"";
				colvarISecurityLevel.ForeignKeyTableName = "";
				schema.Columns.Add(colvarISecurityLevel);
				
				TableSchema.TableColumn colvarSDesc = new TableSchema.TableColumn(schema);
				colvarSDesc.ColumnName = "sDesc";
				colvarSDesc.DataType = DbType.String;
				colvarSDesc.MaxLength = 255;
				colvarSDesc.AutoIncrement = false;
				colvarSDesc.IsNullable = true;
				colvarSDesc.IsPrimaryKey = false;
				colvarSDesc.IsForeignKey = false;
				colvarSDesc.IsReadOnly = false;
				colvarSDesc.DefaultSetting = @"";
				colvarSDesc.ForeignKeyTableName = "";
				schema.Columns.Add(colvarSDesc);
				
				TableSchema.TableColumn colvarDelegateUser = new TableSchema.TableColumn(schema);
				colvarDelegateUser.ColumnName = "DelegateUser";
				colvarDelegateUser.DataType = DbType.String;
				colvarDelegateUser.MaxLength = 50;
				colvarDelegateUser.AutoIncrement = false;
				colvarDelegateUser.IsNullable = true;
				colvarDelegateUser.IsPrimaryKey = false;
				colvarDelegateUser.IsForeignKey = false;
				colvarDelegateUser.IsReadOnly = false;
				colvarDelegateUser.DefaultSetting = @"";
				colvarDelegateUser.ForeignKeyTableName = "";
				schema.Columns.Add(colvarDelegateUser);
				
				BaseSchema = schema;
				//add this schema to the provider
				//so we can query it later
				DataService.Providers["ORM"].AddSchema("Sys_Users",schema);
			}
		}
		#endregion
		
		#region Props
		  
		[XmlAttribute("PkSuid")]
		[Bindable(true)]
		public string PkSuid 
		{
			get { return GetColumnValue<string>(Columns.PkSuid); }
			set { SetColumnValue(Columns.PkSuid, value); }
		}
		  
		[XmlAttribute("FpSBranchID")]
		[Bindable(true)]
		public string FpSBranchID 
		{
			get { return GetColumnValue<string>(Columns.FpSBranchID); }
			set { SetColumnValue(Columns.FpSBranchID, value); }
		}
		  
		[XmlAttribute("SPwd")]
		[Bindable(true)]
		public string SPwd 
		{
			get { return GetColumnValue<string>(Columns.SPwd); }
			set { SetColumnValue(Columns.SPwd, value); }
		}
		  
		[XmlAttribute("SFullName")]
		[Bindable(true)]
		public string SFullName 
		{
			get { return GetColumnValue<string>(Columns.SFullName); }
			set { SetColumnValue(Columns.SFullName, value); }
		}
		  
		[XmlAttribute("SDepart")]
		[Bindable(true)]
		public string SDepart 
		{
			get { return GetColumnValue<string>(Columns.SDepart); }
			set { SetColumnValue(Columns.SDepart, value); }
		}
		  
		[XmlAttribute("TDateCreated")]
		[Bindable(true)]
		public DateTime? TDateCreated 
		{
			get { return GetColumnValue<DateTime?>(Columns.TDateCreated); }
			set { SetColumnValue(Columns.TDateCreated, value); }
		}
		  
		[XmlAttribute("ISecurityLevel")]
		[Bindable(true)]
		public short? ISecurityLevel 
		{
			get { return GetColumnValue<short?>(Columns.ISecurityLevel); }
			set { SetColumnValue(Columns.ISecurityLevel, value); }
		}
		  
		[XmlAttribute("SDesc")]
		[Bindable(true)]
		public string SDesc 
		{
			get { return GetColumnValue<string>(Columns.SDesc); }
			set { SetColumnValue(Columns.SDesc, value); }
		}
		  
		[XmlAttribute("DelegateUser")]
		[Bindable(true)]
		public string DelegateUser 
		{
			get { return GetColumnValue<string>(Columns.DelegateUser); }
			set { SetColumnValue(Columns.DelegateUser, value); }
		}
		
		#endregion
		
		
		#region PrimaryKey Methods		
		
        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);
            
            SetPKValues();
        }
        
		
		public LIS.DAL.TblRolesForUserCollection TblRolesForUsers()
		{
			return new LIS.DAL.TblRolesForUserCollection().Where(TblRolesForUser.Columns.FpSBranchID, PkSuid).Load();
		}
		public LIS.DAL.TblRolesForUserCollection TblRolesForUsersFromSysUser()
		{
			return new LIS.DAL.TblRolesForUserCollection().Where(TblRolesForUser.Columns.SUID, PkSuid).Load();
		}
		#endregion
		
			
		
		#region ForeignKey Properties
		
		/// <summary>
		/// Returns a SysManagementUnit ActiveRecord object related to this SysUser
		/// 
		/// </summary>
		public LIS.DAL.SysManagementUnit SysManagementUnit
		{
			get { return LIS.DAL.SysManagementUnit.FetchByID(this.FpSBranchID); }
			set { SetColumnValue("FP_sBranchID", value.PkSBranchID); }
		}
		
		
		#endregion
		
		
		
		#region Many To Many Helpers
		
		 
		public LIS.DAL.SysManagementUnitCollection GetSysManagementUnitCollection() { return SysUser.GetSysManagementUnitCollection(this.PkSuid); }
		public static LIS.DAL.SysManagementUnitCollection GetSysManagementUnitCollection(string varPkSuid)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[Sys_ManagementUnit] INNER JOIN [tbl_RolesForUsers] ON [Sys_ManagementUnit].[PK_sBranchID] = [tbl_RolesForUsers].[FP_sBranchID] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID", SysUser.Schema.Provider.Name);
			cmd.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SysManagementUnitCollection coll = new SysManagementUnitCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveSysManagementUnitMap(string varPkSuid, SysManagementUnitCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID", SysUser.Schema.Provider.Name);
			cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SysManagementUnit item in items)
			{
				TblRolesForUser varTblRolesForUser = new TblRolesForUser();
				varTblRolesForUser.SetColumnValue("FP_sBranchID", varPkSuid);
				varTblRolesForUser.SetColumnValue("FP_sBranchID", item.GetPrimaryKeyValue());
				varTblRolesForUser.Save();
			}
		}
		public static void SaveSysManagementUnitMap(string varPkSuid, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID", SysUser.Schema.Provider.Name);
			cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					TblRolesForUser varTblRolesForUser = new TblRolesForUser();
					varTblRolesForUser.SetColumnValue("FP_sBranchID", varPkSuid);
					varTblRolesForUser.SetColumnValue("FP_sBranchID", l.Value);
					varTblRolesForUser.Save();
				}
			}
		}
		public static void SaveSysManagementUnitMap(string varPkSuid , string[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID", SysUser.Schema.Provider.Name);
			cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (string item in itemList) 
			{
				TblRolesForUser varTblRolesForUser = new TblRolesForUser();
				varTblRolesForUser.SetColumnValue("FP_sBranchID", varPkSuid);
				varTblRolesForUser.SetColumnValue("FP_sBranchID", item);
				varTblRolesForUser.Save();
			}
		}
		
		public static void DeleteSysManagementUnitMap(string varPkSuid) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID", SysUser.Schema.Provider.Name);
			cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
			DataService.ExecuteQuery(cmdDel);
		}
		
		 
		public LIS.DAL.SysRoleCollection GetSysRoleCollection() { return SysUser.GetSysRoleCollection(this.PkSuid); }
		public static LIS.DAL.SysRoleCollection GetSysRoleCollection(string varPkSuid)
		{
		    SubSonic.QueryCommand cmd = new SubSonic.QueryCommand("SELECT * FROM [dbo].[Sys_Roles] INNER JOIN [tbl_RolesForUsers] ON [Sys_Roles].[FP_sBranchID] = [tbl_RolesForUsers].[FP_sBranchID] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID", SysUser.Schema.Provider.Name);
			cmd.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
			IDataReader rdr = SubSonic.DataService.GetReader(cmd);
			SysRoleCollection coll = new SysRoleCollection();
			coll.LoadAndCloseReader(rdr);
			return coll;
		}
		
		public static void SaveSysRoleMap(string varPkSuid, SysRoleCollection items)
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID", SysUser.Schema.Provider.Name);
			cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (SysRole item in items)
			{
				TblRolesForUser varTblRolesForUser = new TblRolesForUser();
				varTblRolesForUser.SetColumnValue("FP_sBranchID", varPkSuid);
				varTblRolesForUser.SetColumnValue("FP_sBranchID", item.GetPrimaryKeyValue());
				varTblRolesForUser.Save();
			}
		}
		public static void SaveSysRoleMap(string varPkSuid, System.Web.UI.WebControls.ListItemCollection itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID", SysUser.Schema.Provider.Name);
			cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (System.Web.UI.WebControls.ListItem l in itemList) 
			{
				if (l.Selected) 
				{
					TblRolesForUser varTblRolesForUser = new TblRolesForUser();
					varTblRolesForUser.SetColumnValue("FP_sBranchID", varPkSuid);
					varTblRolesForUser.SetColumnValue("FP_sBranchID", l.Value);
					varTblRolesForUser.Save();
				}
			}
		}
		public static void SaveSysRoleMap(string varPkSuid , long[] itemList) 
		{
			QueryCommandCollection coll = new SubSonic.QueryCommandCollection();
			//delete out the existing
			 QueryCommand cmdDel = new QueryCommand("DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID", SysUser.Schema.Provider.Name);
			cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
			coll.Add(cmdDel);
			DataService.ExecuteTransaction(coll);
			foreach (long item in itemList) 
			{
				TblRolesForUser varTblRolesForUser = new TblRolesForUser();
				varTblRolesForUser.SetColumnValue("FP_sBranchID", varPkSuid);
				varTblRolesForUser.SetColumnValue("FP_sBranchID", item);
				varTblRolesForUser.Save();
			}
		}
		
		public static void DeleteSysRoleMap(string varPkSuid) 
		{
			QueryCommand cmdDel = new QueryCommand("DELETE FROM [tbl_RolesForUsers] WHERE [tbl_RolesForUsers].[FP_sBranchID] = @FP_sBranchID", SysUser.Schema.Provider.Name);
			cmdDel.AddParameter("@FP_sBranchID", varPkSuid, DbType.String);
			DataService.ExecuteQuery(cmdDel);
		}
		
		#endregion
		
        
        
		#region ObjectDataSource support
		
		
		/// <summary>
		/// Inserts a record, can be used with the Object Data Source
		/// </summary>
		public static void Insert(string varPkSuid,string varFpSBranchID,string varSPwd,string varSFullName,string varSDepart,DateTime? varTDateCreated,short? varISecurityLevel,string varSDesc,string varDelegateUser)
		{
			SysUser item = new SysUser();
			
			item.PkSuid = varPkSuid;
			
			item.FpSBranchID = varFpSBranchID;
			
			item.SPwd = varSPwd;
			
			item.SFullName = varSFullName;
			
			item.SDepart = varSDepart;
			
			item.TDateCreated = varTDateCreated;
			
			item.ISecurityLevel = varISecurityLevel;
			
			item.SDesc = varSDesc;
			
			item.DelegateUser = varDelegateUser;
			
		
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		
		/// <summary>
		/// Updates a record, can be used with the Object Data Source
		/// </summary>
		public static void Update(string varPkSuid,string varFpSBranchID,string varSPwd,string varSFullName,string varSDepart,DateTime? varTDateCreated,short? varISecurityLevel,string varSDesc,string varDelegateUser)
		{
			SysUser item = new SysUser();
			
				item.PkSuid = varPkSuid;
			
				item.FpSBranchID = varFpSBranchID;
			
				item.SPwd = varSPwd;
			
				item.SFullName = varSFullName;
			
				item.SDepart = varSDepart;
			
				item.TDateCreated = varTDateCreated;
			
				item.ISecurityLevel = varISecurityLevel;
			
				item.SDesc = varSDesc;
			
				item.DelegateUser = varDelegateUser;
			
			item.IsNew = false;
			if (System.Web.HttpContext.Current != null)
				item.Save(System.Web.HttpContext.Current.User.Identity.Name);
			else
				item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
		}
		#endregion
        
        
        
        #region Typed Columns
        
        
        public static TableSchema.TableColumn PkSuidColumn
        {
            get { return Schema.Columns[0]; }
        }
        
        
        
        public static TableSchema.TableColumn FpSBranchIDColumn
        {
            get { return Schema.Columns[1]; }
        }
        
        
        
        public static TableSchema.TableColumn SPwdColumn
        {
            get { return Schema.Columns[2]; }
        }
        
        
        
        public static TableSchema.TableColumn SFullNameColumn
        {
            get { return Schema.Columns[3]; }
        }
        
        
        
        public static TableSchema.TableColumn SDepartColumn
        {
            get { return Schema.Columns[4]; }
        }
        
        
        
        public static TableSchema.TableColumn TDateCreatedColumn
        {
            get { return Schema.Columns[5]; }
        }
        
        
        
        public static TableSchema.TableColumn ISecurityLevelColumn
        {
            get { return Schema.Columns[6]; }
        }
        
        
        
        public static TableSchema.TableColumn SDescColumn
        {
            get { return Schema.Columns[7]; }
        }
        
        
        
        public static TableSchema.TableColumn DelegateUserColumn
        {
            get { return Schema.Columns[8]; }
        }
        
        
        
        #endregion
		#region Columns Struct
		public struct Columns
		{
			 public static string PkSuid = @"PK_sUID";
			 public static string FpSBranchID = @"FP_sBranchID";
			 public static string SPwd = @"sPwd";
			 public static string SFullName = @"sFullName";
			 public static string SDepart = @"sDepart";
			 public static string TDateCreated = @"tDateCreated";
			 public static string ISecurityLevel = @"iSecurityLevel";
			 public static string SDesc = @"sDesc";
			 public static string DelegateUser = @"DelegateUser";
						
		}
		#endregion
		
		#region Update PK Collections
		
        public void SetPKValues()
        {
}
        #endregion
    
        #region Deep Save
		
        public void DeepSave()
        {
            Save();
            
}
        #endregion
	}
}
