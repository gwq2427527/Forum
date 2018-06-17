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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["TName"] = "User login";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string name = this.UserName.Value.Trim();
            string pwd = this.UserPwd.Value.Trim();

            UserInfo user = new UserInfoManager().GetUserInfoByID(name, pwd);
            if (user != null)
            {
                Session["UserInfo"] = user;
                Page.RegisterStartupScript("", "<script>alert('login successful');location.href='Index.aspx';</script>");
            }
            else
            {
                Page.RegisterStartupScript("", "<script>alert('login successful');location.href='Index.aspx';</script>");
            }

        }
    }
}