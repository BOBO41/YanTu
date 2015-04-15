/**  版本信息模板在安装目录下，可自行修改。
* MessageUser.cs
*
* 功 能： N/A
* 类 名： MessageUser
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/3/2 16:31:13   N/A    初版
*
* 




*/

using System;

namespace WebSite.Admin.Model
{
	/// <summary>
	/// MessageUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MessageUser
	{
		public MessageUser()
		{}
		#region Model
		private int _mid;
		private int _uid;
		private int _status;
		/// <summary>
		/// 
		/// </summary>
		public int MID
		{
			set{ _mid=value;}
			get{return _mid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UID
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

