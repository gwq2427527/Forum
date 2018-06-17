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
    public partial class WebForm5 : System.Web.UI.Page
    {
        public string _tid;
        protected void Page_Load(object sender, EventArgs e)
        {           
            _tid = Request.QueryString["tid"] ?? string.Empty;
            if (!IsPostBack)
            {
                if ((Session["UserInfo"] as UserInfo).Sex == 1)
                {
                    this.Man.Checked = true;
                }
                else
                {
                    this.Woman.Checked = true;
                }
                if (!string.IsNullOrEmpty(_tid))
                {
                    if (_tid == "1")
                    {
                        Session["TName"] = "Modify Personal Information";
                        this.lblPwd.Visible = false;
                        this.Pwd.Visible = false;
                        this.lblSurePwd.Visible = false;
                        this.surePwd.Visible = false;
                        this.lblnewPwd.Visible = false;
                        this.newPwd.Visible = false;

                        this.lblUserName.Visible = true;
                        this.UserName.Visible = true;
                        this.sex.Visible = true;
                        this.Man.Visible = true;
                        this.Woman.Visible = true;
                        this.lblEmail.Visible = true;
                        this.Email.Visible = true;
                        this.lblAddress.Visible = true;
                        this.Address.Visible = true;
                        this.Label1.Visible = true;
                        this.Label2.Visible = true;


                        UserInfo entity = Session["UserInfo"] as UserInfo;

                        this.Man.Checked = entity.Sex == 1 ? true : this.Woman.Checked = true;

                        this.Email.Value = entity.Email;
                        this.Address.Value = entity.Address;
                        this.UserName.Value = entity.Name;
                    }
                    else
                    {
                        Session["TName"] = "Modify Personal Information";
                        this.lblUserName.Visible = false;
                        this.UserName.Visible = false;
                        this.sex.Visible = false;
                        this.Man.Visible = false;
                        this.Woman.Visible = false;
                        this.lblEmail.Visible = false;
                        this.Email.Visible = false;
                        this.lblAddress.Visible = false;
                        this.Address.Visible = false;
                        this.Label1.Visible = false;
                        this.Label2.Visible = false;

                        this.lblPwd.Visible = true;
                        this.Pwd.Visible = true;
                        this.lblSurePwd.Visible = true;
                        this.surePwd.Visible = true;
                        this.lblnewPwd.Visible = true;
                        this.newPwd.Visible = true;


                    }
                }
            }

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            if (_tid == "1")//修改用户信息
            {
                if (Session["UserInfo"] != null)
                {
                    UserInfo entity = Session["UserInfo"] as UserInfo;
                    entity.Sex = this.Man.Checked ? 1 : 0;
                    entity.Email = this.Email.Value.Trim();
                    entity.Address = this.Address.Value.Trim();
                    if (new UserInfoManager().UpdateUserInfo(entity, false))
                    {
                        Page.RegisterStartupScript("", "<script>alert('Modify the information successfully');location.href='Index.aspx'</script>");
                    }
                    else
                    {
                        Page.RegisterStartupScript("", "<script>alert('Modify information failed')</script>");
                    }
                }
            }
            else //修改密码
            {
                if (Session["UserInfo"] != null)
                {
                    UserInfo entity = Session["UserInfo"] as UserInfo;

                    string oldPwd = this.Pwd.Value.Trim();
                    string newPwd = this.newPwd.Value.Trim();
                    string surePwd = this.surePwd.Value.Trim();

                    if (!oldPwd.Equals(entity.Pwd))
                    {
                        Page.RegisterStartupScript("", "<script>alert('Old password is incorrect')</script>");
                    }
                    else if (newPwd != surePwd)
                    {
                        Page.RegisterStartupScript("", "<script>alert('Enter the new password and confirm the password does not match! please enter again...')</script>");
                    }
                    else
                    {
                        if (newPwd.Length < 6 || newPwd.Length > 20)
                        {
                            Page.RegisterStartupScript("", "<script>alert('Password length can not be less than 6 characters, and no more than 20 characters! please enter again...')</script>");
                        }
                        else
                        {
                            entity.Pwd = newPwd;
                            if (new UserInfoManager().UpdateUserInfo(entity, true))
                            {
                                Session["UserInfo"] = null;
                                Page.RegisterStartupScript("", "<script>alert('Password has been updated! please login again');location.href='LoginUser.aspx';</script>");
                            }
                            else
                            {
                                Page.RegisterStartupScript("", "<script>alert('Change password failed! please enter again')</script>");
                            }
                        }
                    }
                }
            }
        }
    }
}