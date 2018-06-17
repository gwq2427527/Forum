using ForumBLL;
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
    public partial class Lists : System.Web.UI.Page
    {
        public DataTable dt = null;

        public UserInfo LoginUser;

        public string _tid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["tid"]) && string.IsNullOrEmpty(Request.QueryString["keywords"]))
                Response.Redirect("~/index.aspx", true);

            this.LoginUser = this.GetUser();

            if (!IsPostBack)
            {
                // dt = new PostsManager().GetAllPosts().Tables[0];
                int recordsCount;
                string keywords = Request.QueryString["keywords"] ?? string.Empty;
                string _tid = Request.QueryString["tid"] ?? string.Empty;
                if (!string.IsNullOrEmpty(_tid)) Session["TName"] = new TypeManager().GetNameById(int.Parse(_tid)).Name;
                else Session["TName"] = null;

                if (!string.IsNullOrEmpty(keywords)) { Session["TName"] = "Search results"; }

                dt = new ForumBLL.PostsManager().GetPageData(keywords.Trim(), _tid, anpList.PageIndex, anpList.PageSize, out recordsCount);
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