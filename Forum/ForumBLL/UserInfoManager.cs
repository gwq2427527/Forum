using ForumDAL;
using ForumModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ForumBLL
{
    public class UserInfoManager
    {
        UserInfoService uis = new UserInfoService();

        /// <summary>
        /// 检查用户名是否已经存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CheckUserName(string userName)
        {
            return uis.CheckUserName(userName);
        }

        /// <summary>
        /// 获取个人信息
        /// </summary>
        /// <returns></returns>
        public bool GetInfo(string name)
        {
            DataTable dt = uis.GetInfo(name);
            UserInfo ui = null;
            if (dt.Rows.Count > 0)
            {
                ui = new UserInfo();
                foreach (DataRow dr in dt.Rows)
                {
                    ui.Name = dr["Name"].ToString();
                }
            }
            return ui == null ? false : true;
        }
        /// <summary>
        /// 修改方法信息的方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(UserInfo entity, bool isUpdatePwd)
        {
            return uis.UpdateUserInfo(entity, isUpdatePwd);
        }
        /// <summary>
        /// 修改图像
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateImg(string imgName)
        {
            int leng = imgName.IndexOf(".");
            string img = imgName.Substring(0, leng);
            return uis.UpdateImg(img);
        }
        /// <summary>
        /// 根据ID获得实体信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoByID(string name, string pwd)
        {
            DataTable dt = uis.GetUserInfoByID(name, pwd);
            UserInfo ui = null;
            if (dt.Rows.Count > 0)
            {
                ui = new UserInfo();
                foreach (DataRow dr in dt.Rows)
                {
                    ui.UserID = Convert.ToInt32(dr["UserID"]);
                    ui.Name = dr["Name"].ToString();
                    ui.NickName = dr["NickName"].ToString();
                    ui.Sex = int.Parse(dr["Sex"].ToString());
                    DateTime time = Convert.ToDateTime(dr["Birthday"].ToString());
                    ui.Birthday = Convert.ToDateTime(time.ToString("yyyy年MM月dd日"));
                    ui.Star = Convert.ToInt32(dr["Star"]);
                    ui.Email = (dr["Email"]).ToString();
                    ui.Pwd = dr["Pwd"].ToString();
                    ui.Career = dr["Career"].ToString();
                    ui.Company = dr["Company"].ToString();
                    ui.Address = dr["Address"].ToString();
                    ui.Img = dr["Img"].ToString();
                    ui.Role = Convert.ToInt32(dr["Role"]);
                }
            }
            return ui;
        }

        /// <summary>
        /// 添加表数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool AddUserInfo(UserInfo entity)
        {
            return uis.AddUserInfo(entity);
        }

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoByID(int ID)
        {
            DataSet ds = uis.GetUserInfoByID(ID);
            UserInfo entity = null;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        entity = new UserInfo();
                        entity.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                        entity.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                        entity.Sex = int.Parse(ds.Tables[0].Rows[0]["Sex"].ToString());
                        entity.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                        entity.Pwd = ds.Tables[0].Rows[0]["Pwd"].ToString();
                    }
                }
            }
            return entity;
        }
    }
}
