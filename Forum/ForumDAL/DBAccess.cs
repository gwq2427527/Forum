using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ForumDAL
{
    public class DBAccess
    {
        public DataSet GetBookList(int PageIndex, int PageSize, out int recordCount, string tId)
        {
            //计算要查找的起始范围
            int startNum = 1;
            int endNum = 1;
            if (PageIndex > 0)
            {
                startNum = (PageIndex - 1) * PageSize + 1;
                endNum = PageIndex * PageSize;
            }
            //筛选
            string sx = "";
            //排序
            string orderBy = "order by PublishTime desc";
            //查询语句，添加rowNum字段
            if (tId != "0" && tId != null)
            {
                sx = " and TypeID=" + tId;
            }
            string cSql = "  select ROW_NUMBER() over(" + orderBy + ") rowNum,* from DailyRecord AA where 1=1 " + sx;

            string sql1 = "select * from DailyRecord";

            //返回要查找的数据
            string sql = "select  top " + PageSize + " * from  (" + cSql + ") TempBooks where rowNum between @startNum and @endNum ";

            SqlParameter[] para = new SqlParameter[]{  
               new SqlParameter("@startNum",startNum),
               new SqlParameter("@endNum",endNum)
           };
            //2条sql语句同时执行
            DataSet ds = DBHelper.GetDateSet(sql + cSql + sql1, CommandType.Text, para);
            //一共多少条记录数
            recordCount = ds.Tables[2].Rows.Count;
            return ds;

        }
    }
}