using System;
using System.Data;
using System.Data.SqlClient;

namespace ForumDAL
{
    /// <summary>
    /// 
    /// </summary>
    public class PagerProc : ProcedureBase
    {

        private int _pageSize;
        /// <summary>
        /// 
        /// </summary>
        public int pageSize
        {
            get{ return _pageSize; }
            set{ _pageSize = value; }
        }

        private int _pageIndex;
        /// <summary>
        /// 
        /// </summary>
        public int pageIndex
        {
            get{ return _pageIndex; }
            set{ _pageIndex = value; }
        }

        private string _uniqueField;
        /// <summary>
        /// 
        /// </summary>
        public string uniqueField
        {
            get{ return _uniqueField; }
            set{ _uniqueField = value; }
        }

        private string _uniqueFieldType;
        /// <summary>
        /// 
        /// </summary>
        public string uniqueFieldType
        {
            get{ return _uniqueFieldType; }
            set{ _uniqueFieldType = value; }
        }

        private string _fields;
        /// <summary>
        /// 
        /// </summary>
        public string fields
        {
            get{ return _fields; }
            set{ _fields = value; }
        }

        private string _tables;
        /// <summary>
        /// 
        /// </summary>
        public string tables
        {
            get{ return _tables; }
            set{ _tables = value; }
        }

        private string _where;
        /// <summary>
        /// 
        /// </summary>
        public string where
        {
            get{ return _where; }
            set{ _where = value; }
        }

        private string _group;
        /// <summary>
        /// 
        /// </summary>
        public string group
        {
            get{ return _group; }
            set{ _group = value; }
        }

        private string _order;
        /// <summary>
        /// 
        /// </summary>
        public string order
        {
            get{ return _order; }
            set{ _order = value; }
        }

        private int _recordsCount;
        /// <summary>
        /// 
        /// </summary>
        public int recordsCount
        {
            get{ return _recordsCount; }
            set{ _recordsCount = value; }
        }
        
        public PagerProc() : base("P_ZJPager") { }

        protected override SqlParameter[] GetParameters()
        {
            SqlParameter[] ps = new SqlParameter[11];

            ps[0] = new SqlParameter("@pageSize", SqlDbType.Int, 10);
            ps[0].Value = _pageSize;

            ps[1] = new SqlParameter("@pageIndex", SqlDbType.Int, 10);
            ps[1].Value = _pageIndex;

            ps[2] = new SqlParameter("@uniqueField", SqlDbType.NVarChar, 36);
            ps[2].Value = _uniqueField;

            ps[3] = new SqlParameter("@uniqueFieldType", SqlDbType.NVarChar, 20);
            ps[3].Value = _uniqueFieldType;

            ps[4] = new SqlParameter("@fields", SqlDbType.NVarChar, 1000);
            ps[4].Value = _fields;

            ps[5] = new SqlParameter("@tables", SqlDbType.NVarChar, 200);
            ps[5].Value = _tables;

            ps[6] = new SqlParameter("@where", SqlDbType.NVarChar, 1000);
            ps[6].Value = _where;

            ps[7] = new SqlParameter("@group", SqlDbType.NVarChar, 200);
            ps[7].Value = _group;

            ps[8] = new SqlParameter("@order", SqlDbType.NVarChar, 200);
            ps[8].Value = _order;

            ps[9] = new SqlParameter("@recordsCount", SqlDbType.Int, 10);
            ps[9].Direction = ParameterDirection.Output;

            ps[10] = new SqlParameter("@returnValue", SqlDbType.Int);
            ps[10].Direction = ParameterDirection.ReturnValue;
            return ps;
        }

        protected override void LoadOutputValues(SqlParameter[] ps)
        {
            _recordsCount = (int)ps[9].Value;
            base.ReturnValue = (int)ps[10].Value;
        }
    }
}