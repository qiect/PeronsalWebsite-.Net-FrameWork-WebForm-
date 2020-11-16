//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using PersonSite.Model;

namespace PersonSite.DAL
{
	public partial class T_AdDAL
	{
        public T_Ad Add
			(T_Ad rP_Ad)
		{
				string sql ="INSERT INTO T_Ads (Name, PositionId, AdType, TextAdText, TextAdUrl, PicAdImgUrl, PicAdUrl, CodeAdHTML)  output inserted.Id VALUES (@Name, @PositionId, @AdType, @TextAdText, @TextAdUrl, @PicAdImgUrl, @PicAdUrl, @CodeAdHTML)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@Name", ToDBValue(rP_Ad.Name)),
						new SqlParameter("@PositionId", ToDBValue(rP_Ad.PositionId)),
						new SqlParameter("@AdType", ToDBValue(rP_Ad.AdType)),
						new SqlParameter("@TextAdText", ToDBValue(rP_Ad.TextAdText)),
						new SqlParameter("@TextAdUrl", ToDBValue(rP_Ad.TextAdUrl)),
						new SqlParameter("@PicAdImgUrl", ToDBValue(rP_Ad.PicAdImgUrl)),
						new SqlParameter("@PicAdUrl", ToDBValue(rP_Ad.PicAdUrl)),
						new SqlParameter("@CodeAdHTML", ToDBValue(rP_Ad.CodeAdHTML)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetById(newId);
		}

        public int DeleteById(int id)
		{
            string sql = "DELETE T_Ads WHERE Id = @Id";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", id)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(T_Ad rP_Ad)
        {
            string sql =
                "UPDATE T_Ads " +
                "SET " +
			" Name = @Name" 
                +", PositionId = @PositionId" 
                +", AdType = @AdType" 
                +", TextAdText = @TextAdText" 
                +", TextAdUrl = @TextAdUrl" 
                +", PicAdImgUrl = @PicAdImgUrl" 
                +", PicAdUrl = @PicAdUrl" 
                +", CodeAdHTML = @CodeAdHTML" 
               
            +" WHERE Id = @Id";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@Id", rP_Ad.Id)
					,new SqlParameter("@Name", ToDBValue(rP_Ad.Name))
					,new SqlParameter("@PositionId", ToDBValue(rP_Ad.PositionId))
					,new SqlParameter("@AdType", ToDBValue(rP_Ad.AdType))
					,new SqlParameter("@TextAdText", ToDBValue(rP_Ad.TextAdText))
					,new SqlParameter("@TextAdUrl", ToDBValue(rP_Ad.TextAdUrl))
					,new SqlParameter("@PicAdImgUrl", ToDBValue(rP_Ad.PicAdImgUrl))
					,new SqlParameter("@PicAdUrl", ToDBValue(rP_Ad.PicAdUrl))
					,new SqlParameter("@CodeAdHTML", ToDBValue(rP_Ad.CodeAdHTML))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public T_Ad GetById(int id)
        {
            string sql = "SELECT * FROM T_Ads WHERE Id = @Id";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@Id", id)))
			{
				if (reader.Read())
				{
					return ToModel(reader);
				}
				else
				{
					return null;
				}
       		}
        }
		
		public T_Ad ToModel(SqlDataReader reader)
		{
			T_Ad rP_Ad = new T_Ad();

			rP_Ad.Id = (int)ToModelValue(reader,"Id");
			rP_Ad.Name = (string)ToModelValue(reader,"Name");
			rP_Ad.PositionId = (int)ToModelValue(reader,"PositionId");
			rP_Ad.AdType = (int)ToModelValue(reader,"AdType");
			rP_Ad.TextAdText = (string)ToModelValue(reader,"TextAdText");
			rP_Ad.TextAdUrl = (string)ToModelValue(reader,"TextAdUrl");
			rP_Ad.PicAdImgUrl = (string)ToModelValue(reader,"PicAdImgUrl");
			rP_Ad.PicAdUrl = (string)ToModelValue(reader,"PicAdUrl");
			rP_Ad.CodeAdHTML = (string)ToModelValue(reader,"CodeAdHTML");
			return rP_Ad;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM T_Ads";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<T_Ad> GetPagedData(int minrownum,int maxrownum)
		{
			var list = new List<T_Ad>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by Id) rownum FROM T_Ads) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				while(reader.Read())
				{
					list.Add(ToModel(reader));
				}				
			}
			return list;
		}
		
		public IEnumerable<T_Ad> GetAll()
		{
			var list = new List<T_Ad>();
			string sql = "SELECT * FROM T_Ads";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				while(reader.Read())
				{
					list.Add(ToModel(reader));
				}				
			}
			return list;
		}
		
		public object ToDBValue(object value)
		{
			if(value==null)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}
		
		public object ToModelValue(SqlDataReader reader,string columnName)
		{
			if(reader.IsDBNull(reader.GetOrdinal(columnName)))
			{
				return null;
			}
			else
			{
				return reader[columnName];
			}
		}
	}
}
