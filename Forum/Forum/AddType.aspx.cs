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
    public partial class AddType : System.Web.UI.Page
    {
        public string _TID;
        protected void Page_Load(object sender, EventArgs e)
        {
            _TID = Request.QueryString["tid"];
            if (!IsPostBack)
            {
                UserInfo info = Session["UserInfo"] != null ? Session["UserInfo"] as UserInfo : null;
                if (info != null)
                {
                    if (info.Role != 1)
                    {
                        Page.RegisterStartupScript("", "<script>alert('Permission Denied');location.href='Lists.aspx'</script>");
                        return;
                    }
                }

                if (_TID != null)
                {
                    ForumModels.Type entity = new TypeManager().GetNameById(int.Parse(_TID));
                    this.txtTypeName.Value = entity.Name;
                    this.txtAre.Value = entity.Description;
                    Session["TName"] = "Edit category";
                }

            }
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            ForumModels.Type entity = new ForumModels.Type()
            {
                Name = this.txtTypeName.Value.Trim(),
                Description = this.txtAre.Value.Trim(),
                CreateTime = DateTime.Now
            };
            if (_TID != null)
            {
                entity.ID = int.Parse(_TID);
                if (new TypeManager().UpdateTypeInfo(entity))
                {
                    Page.RegisterStartupScript("", "<script>alert('S');location.href='TypeList.aspx'</script>");
                }
                else
                {
                    Page.RegisterStartupScript("", "<script>alert('F');</script>");
                }
            }
            else
            {
                if (new TypeManager().AddType(entity))
                {
                    Page.RegisterStartupScript("", "<script>alert('S');location.href='TypeList.aspx'</script>");
                }
                else
                {
                    Page.RegisterStartupScript("", "<script>alert('F');</script>");
                }
            }

        }
    }
}