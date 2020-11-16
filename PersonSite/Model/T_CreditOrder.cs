//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonSite.Model
{	
	[Serializable()]
	public class T_CreditOrder
	{	
			public int Id
			{
				get;
				set;
			}
			public Guid UserId
			{
				get;
				set;
			}
			public int CreditCount
			{
				get;
				set;
			}
			public string Status
			{
				get;
				set;
			}
	}
}
