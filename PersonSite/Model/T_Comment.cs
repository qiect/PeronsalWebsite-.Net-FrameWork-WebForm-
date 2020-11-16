//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonSite.Model
{	
	[Serializable()]
	public class T_Comment
	{	
			public int Id
			{
				get;
				set;
			}
			public int ArticleId
			{
				get;
				set;
			}
			public DateTime PostDate
			{
				get;
				set;
			}
			public string Msg
			{
				get;
				set;
			}
			public bool IsVisible
			{
				get;
				set;
			}
	}
}
