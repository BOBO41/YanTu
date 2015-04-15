/**  版本信息模板在安装目录下，可自行修改。
* OrgProviderInfo.cs
*
* 功 能： N/A
* 类 名： OrgProviderInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-30 19:03:04   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// OrgProviderInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrgProviderInfo
	{
		public OrgProviderInfo()
		{}
		#region Model
		private int _provid;
		private long? _orgid;
		private string _bankaccount;
		private string _bankname;
		private string _bankaddress;
		private string _manager;
		private string _managerphone;
		private string _providertype;
		private DateTime? _addtime;
		/// <summary>
		/// 
		/// </summary>
		public int ProvId
		{
			set{ _provid=value;}
			get{return _provid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? OrgId
		{
			set{ _orgid=value;}
			get{return _orgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BankAccount
		{
			set{ _bankaccount=value;}
			get{return _bankaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BankName
		{
			set{ _bankname=value;}
			get{return _bankname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BankAddress
		{
			set{ _bankaddress=value;}
			get{return _bankaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Manager
		{
			set{ _manager=value;}
			get{return _manager;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ManagerPhone
		{
			set{ _managerphone=value;}
			get{return _managerphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProviderType
		{
			set{ _providertype=value;}
			get{return _providertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

