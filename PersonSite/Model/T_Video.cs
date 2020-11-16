//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonSite.Model
{	
	[Serializable()]
	public class T_Video
	{	
			public int Id
			{
				get;
				set;
			}
			public string Title
			{
				get;
				set;
			}
			public string Url
			{
				get;
				set;
			}
			public int DingCount
			{
				get;
				set;
			}
			public int CaiCount
			{
				get;
				set;
			}
	}
}
