using ForumBLL;
using ForumModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class Ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string res = string.Empty;
            string action = Request.QueryString["action"];
            if (action == "checkUserName") // 检查用户名是否已经存在
            {
                string userName = Request.QueryString["name"];
                if (!string.IsNullOrEmpty(userName))
                {
                    bool isExists = new ForumBLL.UserInfoManager().CheckUserName(userName);
                    res = isExists ? "1" : "0";
                }
            }
            else if (action == "delPost") // 删除贴子
            {
                string postIdStr = Request.QueryString["id"];
                int postId;
                if (string.IsNullOrEmpty(postIdStr) || !int.TryParse(postIdStr, out postId))
                {
                    res = "Parameter is incorrect!";
                }
                else if (Session["UserInfo"] == null || (Session["UserInfo"] as UserInfo).Role != 1)
                {
                    res = "Permission denied!";
                }
                else
                {
                    bool isOk = new ForumBLL.PostsManager().DelPost(postId);
                    if (isOk) res = "1";
                    else res = "unknown error";
                }

            }
            else if (action == "delType")
            {
                string id = Request.QueryString["tid"];
                int typeId;
                if (string.IsNullOrEmpty(id) || !int.TryParse(id, out typeId))
                {
                    res = "Parameter is incorrect!";
                }
                else if (Session["UserInfo"] == null || (Session["UserInfo"] as UserInfo).Role != 1)
                {
                    res = "Permission denied!";
                }
                else
                {
                    if (new PostsManager().GetPostsByTypeID(typeId) > 0)
                    {
                        res = "Can not be delete";
                    }
                    else
                    {
                        bool isOk = new ForumBLL.TypeManager().DelType(typeId);
                        if (isOk) res = "1";
                        else res = "unknown error";
                    }
                }
            }
            Response.Write(res);
            Response.End();
        }
    }
}