using ForumModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class Collect : System.Web.UI.Page
    {
        public DataTable dt = null;

        public UserInfo LoginUser;


        protected void Page_Load(object sender, EventArgs e)
        {

            this.LoginUser = this.GetUser();

            if (!IsPostBack)
            {
                // dt = new PostsManager().GetAllPosts().Tables[0];
                int recordsCount;
                Session["TName"] = "Collection list";
                dt = new ForumBLL.PostsManager().GetPageData(LoginUser != null ? LoginUser.UserID : 0, anpList.PageIndex, anpList.PageSize, out recordsCount);
                anpList.SetRecordCount(recordsCount);
            }

        }

        public UserInfo GetUser()
        {
            object o = Session["UserInfo"];
            if (o == null) return null;
            return o as UserInfo;
        }

        public string SubString(string content)
        {
            string str = string.Empty;
            if (content.Length > 50)
            {
                str = content.Substring(0, 30);
                str += "...";
            }
            else
            {
                str = content;
            }
            return str;
        }
    }
}