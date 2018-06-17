using ForumBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Forum
{
    public partial class Index : System.Web.UI.Page
    {
        public List<ForumModels.Type> _List = new List<ForumModels.Type>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _List = new TypeManager().GetTyps();

                Session["TName"] = null;
            }
        }

        public string SubString(string content)
        {
            string str = string.Empty;
            if (content.Length > 100)
            {
                str = content.Substring(0, 50);
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