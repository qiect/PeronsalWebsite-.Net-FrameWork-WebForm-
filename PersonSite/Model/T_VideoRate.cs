//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonSite.Model
{	
	[Serializable()]
	public class T_VideoRate
	{	
			public int Id
			{
				get;
				set;
			}
			public int VideoId
			{
				get;
				set;
			}
			public int Action
			{
				get;
				set;
			}
			public DateTime CreateDate
			{
				get;
				set;
			}
			public string IP
			{
				get;
				set;
			}
	}
}
