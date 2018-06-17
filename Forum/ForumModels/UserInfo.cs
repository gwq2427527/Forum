using System;
using System.Data;
using System.Text;
using System.Runtime.Serialization;

namespace ForumModels
{
    [Serializable]
    public class UserInfo
    {

        private int _UserID;
        /// <summary>
        /// 表主键，用户ID
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

        private string _Name;
        /// <summary>
        /// QQ号
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        private string _NickName;
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName
        {
            get
            {
                return _NickName;
            }
            set
            {
                _NickName = value;
            }
        }

        private int _Sex;
        /// <summary>
        /// 性别（1，男，0，女）
        /// </summary>
        public int Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                _Sex = value;
            }
        }

        private DateTime _Birthday;
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday
        {
            get
            {
                return _Birthday;
            }
            set
            {
                _Birthday = value;
            }
        }

        private int _Star;
        /// <summary>
        /// 星座
        /// </summary>
        public int Star
        {
            get
            {
                return _Star;
            }
            set
            {
                _Star = value;
            }
        }

        private string _Email;
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        private string _Pwd;
        /// <summary>
        /// 感情情况
        /// </summary>
        public string Pwd
        {
            get
            {
                return _Pwd;
            }
            set
            {
                _Pwd = value;
            }
        }

        private string _Career;
        /// <summary>
        /// 职业
        /// </summary>
        public string Career
        {
            get
            {
                return _Career;
            }
            set
            {
                _Career = value;
            }
        }

        private string _Company;
        /// <summary>
        /// 公司名称
        /// </summary>
        public string Company
        {
            get
            {
                return _Company;
            }
            set
            {
                _Company = value;
            }
        }

        private string _Address;
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

        private string _Img;
        /// <summary>
        /// 
        /// </summary>
        public string Img
        {
            get
            {
                return _Img;
            }
            set
            {
                _Img = value;
            }
        }

        private int _Role;
        /// <summary>
        /// 用户类型
        /// </summary>
        public int Role
        {
            get
            {
                return _Role;
            }
            set
            {
                _Role = value;
            }
        }

        public override string ToString()
        {
            return this.Name + (this._Role == 1 ? " [Administrator]" : string.Empty);
        }

    }
}

