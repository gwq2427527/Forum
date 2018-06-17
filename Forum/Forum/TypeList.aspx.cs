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
    public partial class TypeList : System.Web.UI.Page
    {
        public List<ForumModels.Type> Types;

        public UserInfo LoginUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserInfo info = GetUser();
                if (info != null)
                {
                    if (info.Role != 1)
                    {
                        Page.RegisterStartupScript("", "<script>alert('Permission Denied');location.href='Lists.aspx'</script>");
                        return;
                    }
                }
                this.LoginUser = this.GetUser();
                Types = new TypeManager().GetTyps();

                Session["TName"] = "Category list";
            }
        }

        public UserInfo GetUser()
        {
            object o = Session["UserInfo"];
            if (o == null) return null;
            return o as UserInfo;
        }

    }
}