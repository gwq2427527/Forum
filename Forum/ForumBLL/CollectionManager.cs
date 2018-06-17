using ForumDAL;
using ForumModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumBLL
{
    public class CollectionManager
    {
        public CollectionService cs = new CollectionService();
        /// <summary>
        /// 添加表数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddCollection(Collection entity)
        {
            return cs.AddCollection(entity);
        }

        /// <summary>
        /// 判断这个人是否收藏该贴
        /// </summary>
        /// <returns></returns>
        public bool IsCollection(int uid, int pid)
        {
            return cs.IsCollection(uid, pid);
        }

        /// <summary>
        /// 删除个人收藏贴
        /// </summary>
        /// <returns></returns>
        public bool DeleteCollection(int uid, int pid)
        {
            return cs.DeleteCollection(uid, pid);
        }
    }
}
