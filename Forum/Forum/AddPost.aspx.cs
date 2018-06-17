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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadType();
                if (Session["UserInfo"] == null)
                {
                    Page.RegisterStartupScript("", "<script>alert('You have to login first');location.href='Index.aspx';</script>");
                    return;
                }

                Session["TName"] = "ADD New Post";
            }
        }

        /// <summary>
        /// 加载所有分类
        /// </summary>
        public void LoadType()
        {
            List<ForumModels.Type> list = new TypeManager().GetTyps();
            if (list.Count > 0)
            {
                this.ddlType.DataSource = list;
                this.ddlType.DataValueField = "ID";
                this.ddlType.DataTextField = "Name";
                this.ddlType.DataBind();
            }
        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddPost_Click(object sender, EventArgs e)
        {
            string content = this.txtAre.Value.Trim();
            string subject = this.Subject.Value.Trim();
            if (subject.Length == 0)
            {
                Page.RegisterStartupScript("", "<script>alert('Can not be empty')</script>");
                return;
            }
            else if (content.Length == 0)
            {
                Page.RegisterStartupScript("", "<script>alert('Can not be empty')</script>");
                return;
            }
            Posts entity = new Posts()
            {
                TypeId = int.Parse(this.ddlType.SelectedValue),
                FromId = (Session["UserInfo"] as UserInfo).UserID,
                Contents = content,
                CommentNum = 0,
                Subject = subject,
                AppTime = DateTime.Now
            };
            if (new PostsManager().AddPosts(entity))
            {
                Page.RegisterStartupScript("", "<script>alert('S');location.href='Index.aspx';</script>");
            }
            else
            {
                Page.RegisterStartupScript("", "<script>alert('F');</script>");
            }
        }
    }
}