using System;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ForumModels
{
    [Serializable]
    public class Posts
    {

        private int _Id;
        /// <summary>
        /// 表主键ID
        /// </summary>
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        private int _TypeId;
        /// <summary>
        /// 表主键ID
        /// </summary>
        public int TypeId
        {
            get
            {
                return _TypeId;
            }
            set
            {
                _TypeId = value;
            }
        }

        private int _FromId;
        /// <summary>
        /// 说说内容
        /// </summary>
        public int FromId
        {
            get
            {
                return _FromId;
            }
            set
            {
                _FromId = value;
            }
        }

        private string _Subject;
        /// <summary>
        /// 主题
        /// </summary>
        public string Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                _Subject = value;
            }
        }

        private string _Contents;
        /// <summary>
        /// 说说内容
        /// </summary>
        public string Contents
        {
            get
            {
                return _Contents;
            }
            set
            {
                _Contents = value;
            }
        }

        private int _CommentNum;
        /// <summary>
        /// 评论数量
        /// </summary>
        public int CommentNum
        {
            get
            {
                return _CommentNum;
            }
            set
            {
                _CommentNum = value;
            }
        }

        private DateTime _AppTime;
        /// <summary>
        /// 说说发表时间
        /// </summary>
        public DateTime AppTime
        {
            get
            {
                return _AppTime;
            }
            set
            {
                _AppTime = value;
            }
        }

    }
}

