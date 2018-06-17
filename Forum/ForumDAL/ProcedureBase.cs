using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ZJun.Framework;

namespace ForumDAL
{
    public abstract class ProcedureBase
    {
        private string _procName;
        /// <summary>
        /// 获取存储过程名称
        /// </summary>
        public string ProcName
        {
            get { return _procName; }
        }

        private int? _returnValue;
        /// <summary>
        /// 获取或设置存储过程的返回值
        /// </summary>
        public int? ReturnValue
        {
            get { return _returnValue; }
            set { _returnValue = value; }
        }

        public ProcedureBase(string procName)
        {
            _procName = procName;
        }

        public virtual DataSet ToDataSet()
        {
            DataSet ds;
            SqlParameter[] ps = this.GetParameters();
            using (DbAccess db = new DbAccess())
            {
                ds = db.ExecuteDataSet(_procName, CommandType.StoredProcedure, ps);
                this.LoadOutputValues(ps);
            }
            return ds;
        }
        
        protected abstract SqlParameter[] GetParameters();

        protected abstract void LoadOutputValues(SqlParameter[] ps);

    }
}
