/**  版本信息模板在安装目录下，可自行修改。
* LandAttributeValue.cs
*
* 功 能： N/A
* 类 名： LandAttributeValue
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/1/16 10:25:23   N/A    初版
*
* 




*/

using System;

namespace WebSite.Area.Model
{
	/// <summary>
	/// LandAttributeValue:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LandAttributeValue
	{
		public LandAttributeValue()
		{}
		#region Model
		private int _lavid;
		private int? _lid;
		private int? _laid;
		private int? _emplid;
		private string _lavalue;
		private DateTime? _addtime;
		/// <summary>
		/// 
		/// </summary>
		public int LAVId
		{
			set{ _lavid=value;}
			get{return _lavid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LId
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LAId
		{
			set{ _laid=value;}
			get{return _laid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmplId
		{
			set{ _emplid=value;}
			get{return _emplid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LAValue
		{
			set{ _lavalue=value;}
			get{return _lavalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

