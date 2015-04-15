/**  版本信息模板在安装目录下，可自行修改。
* CarInfo.cs
*
* 功 能： N/A
* 类 名： CarInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/23 17:54:01   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// CarInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CarInfo
	{
		public CarInfo()
		{}
		#region Model
		private int _carid;
		private string _carno;
		private decimal? _loadrepeat;
		private int? _cartype;
		private string _contacts;
		private string _phone;
		private int? _status;
		/// <summary>
		/// 
		/// </summary>
		public int CarId
		{
			set{ _carid=value;}
			get{return _carid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CarNo
		{
			set{ _carno=value;}
			get{return _carno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LoadRepeat
		{
			set{ _loadrepeat=value;}
			get{return _loadrepeat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CarType
		{
			set{ _cartype=value;}
			get{return _cartype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Contacts
		{
			set{ _contacts=value;}
			get{return _contacts;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

