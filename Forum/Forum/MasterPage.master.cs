using ForumBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public List<ForumModels.Type> _TypeList;
    protected void Page_Load(object sender, EventArgs e)
    {
        _TypeList = new TypeManager().GetTyps();
    }

    public string GetTypeName()
    {
        if (Session["TName"] != null) return Session["TName"].ToString();
        else return "Home";
    }


}
