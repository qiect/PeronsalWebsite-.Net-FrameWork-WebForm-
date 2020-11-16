//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonSite.Model
{	
	[Serializable()]
	public class T_FilterWord
	{	
			public int Id
			{
				get;
				set;
			}
			public string WordPattern
			{
				get;
				set;
			}
			public string ReplaceWord
			{
				get;
				set;
			}
	}
}
