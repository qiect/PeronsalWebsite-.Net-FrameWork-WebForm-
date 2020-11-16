//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonSite.Model
{	
	[Serializable()]
	public class T_UserInfo
	{	
			public Guid UserId
			{
				get;
				set;
			}
			public string QQ
			{
				get;
				set;
			}
			public string Status
			{
				get;
				set;
			}
			public Guid? VCode
			{
				get;
				set;
			}
			public int? Credit
			{
				get;
				set;
			}
	}
}
