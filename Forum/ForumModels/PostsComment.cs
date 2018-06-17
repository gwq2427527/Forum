using System;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ForumModels
{
	[Serializable]
	public class PostsComment
	{

		private int _Id;
		/// <summary>
		/// 表主键
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

		private int _UserID;
		/// <summary>
		/// 我的ID号
		/// </summary>
		public int UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				_UserID = value;
			}
		}

        private int _PostsId;
		/// <summary>
		/// 访客ID号
		/// </summary>
        public int PostsId
		{
			get
			{
                return _PostsId;
			}
			set
			{
                _PostsId = value;
			}
		}

        private string _Conent;
		/// <summary>
		/// 访问时间
		/// </summary>
        public string Conent
		{
			get
			{
                return _Conent;
			}
			set
			{
                _Conent = value;
			}
		}
        private DateTime _CreateTime;
        /// <summary>
        /// 访问时间
        /// </summary>
        public DateTime CreateTime
        {
            get
            {
                return _CreateTime;
            }
            set
            {
                _CreateTime = value;
            }
        }

	}
}

