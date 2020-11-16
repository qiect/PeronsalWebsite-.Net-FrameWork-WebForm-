//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PersonSite.Model
{	
	[Serializable()]
	public class T_Ad
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
			public int PositionId
			{
				get;
				set;
			}
			public int AdType
			{
				get;
				set;
			}
			public string TextAdText
			{
				get;
				set;
			}
			public string TextAdUrl
			{
				get;
				set;
			}
			public string PicAdImgUrl
			{
				get;
				set;
			}
			public string PicAdUrl
			{
				get;
				set;
			}
			public string CodeAdHTML
			{
				get;
				set;
			}
	}
}
