//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonSite.Model
{	
	[Serializable()]
	public class T_Channel
	{	
			public int Id
			{
				get;
				set;
			}
			public int? ParentId
			{
				get;
				set;
			}
			public string Name
			{
				get;
				set;
			}
	}
}
