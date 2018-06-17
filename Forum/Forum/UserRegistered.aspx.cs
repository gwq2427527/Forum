using Forum.Common;
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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["TName"] = "User registration";
            }
        }

        /// <summary>
        /// 注册单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReg_Click(object sender, EventArgs e)
        {
            UserInfoManager um = new UserInfoManager();

            if (um.GetInfo(this.UserName.Value.Trim()))
            {
                Page.RegisterStartupScript("", "<script>alert('The user name you entered already exists. Please re-enter!')</script>");
                return;
            }
            UserInfo user = new UserInfo()
            {
                Name = this.UserName.Value.Trim(),
                Pwd = this.Pwd.Value.Trim(),
                Sex = this.Man.Checked ? 1 : 0,
                Email = this.Email.Value.Trim(),
                NickName = "",
                Address = this.Address.Value.Trim(),
                Birthday = DateTime.Parse("1993-02-02"),
                Star = 0,
                Career = "",
                Img = "",
                Company = "",
                Role = 0
            };
            try
            {
                if (um.AddUserInfo(user))
                {
                    if (user.Email.Length > 0) EmailHelper.SendEmail(user.Email, "Registration success,Thanks");
                    Page.RegisterStartupScript("", "<script>alert('registration success');location.href='Index.aspx';</script>");
                }
                else
                {
                    Page.RegisterStartupScript("", "<script>alert('Registration failed')</script>");
                }
            }
            catch (Exception ex)
            {
                Page.RegisterStartupScript("", "<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}