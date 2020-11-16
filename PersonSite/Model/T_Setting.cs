//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonSite.Model
{	
	[Serializable()]
	public class T_Setting
	{	
			public int Id
			{
				get;
				set;
			}
			public string Name
			{
				get;
				set;
			}
			public string Value
			{
				get;
				set;
			}
	}
}
