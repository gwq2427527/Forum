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
    public partial class PostsDetail : System.Web.UI.Page
    {
        public int? _PId;
        public DataSet Pds = null;

        public DataSet PCds = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            _PId = int.Parse(Request.QueryString["pid"]);

            if (_PId.HasValue)
            {
                Pds = new PostsManager().GetPostsByID(_PId.Value);

                PCds = new PostsCommentManager().GetPostsComment(_PId.Value);
            }
        }

        public string GetContent()
        {
            string content = string.Empty;
            if (Pds != null)
            {
                if (Pds.Tables.Count > 0)
                {
                    if (Pds.Tables[0].Rows.Count > 0)
                    {
                        content = Pds.Tables[0].Rows[0]["Contents"].ToString();
                    }
                }

            }
            return content;
        }
        public string GetNum()
        {
            string num = string.Empty;
            if (Pds != null)
            {
                if (Pds.Tables.Count > 0)
                {
                    if (Pds.Tables[0].Rows.Count > 0)
                    {
                        num = PCds.Tables[0].Rows[0]["CommentNum"].ToString();
                    }
                }
            }
            return num;
        }

        public string GetSubject()
        {
            string name = string.Empty;
            if (Pds != null)
            {
                if (Pds.Tables.Count > 0)
                {
                    if (Pds.Tables[0].Rows.Count > 0)
                    {
                        name = Pds.Tables[0].Rows[0]["Subject"].ToString();
                    }
                }
            }
            return name;
        }


        public string GetName()
        {
            string name = string.Empty;
            if (Pds != null)
            {
                if (Pds.Tables.Count > 0)
                {
                    if (Pds.Tables[0].Rows.Count > 0)
                    {
                        UserInfo ui = new UserInfoManager().GetUserInfoByID(int.Parse(Pds.Tables[0].Rows[0]["FromId"].ToString()));
                        if (ui != null)
                        {
                            name = ui.Name;
                        }
                    }
                }
            }
            return name;
        }

        protected void btnSay_Click(object sender, EventArgs e)
        {
            string content = this.txtAre.Value.Trim();
            if (content.Length == 0)
            {
                Page.RegisterStartupScript("", "<script>alert('Please write your comments');location.href=location.href;</script>");
                return;
            }
            if (_PId.HasValue)
            {
                PostsComment entity = new PostsComment()
                {
                    UserID = (Session["UserInfo"] as UserInfo).UserID,
                    PostsId = _PId.Value,
                    Conent = content,
                    CreateTime = DateTime.Now
                };
                if (new PostsCommentManager().AddPostsComment(entity))
                {
                    Page.RegisterStartupScript("", "<script>alert('The comment was added successfully');location.href=location.href;</script>");
                }
                else
                {
                    Page.RegisterStartupScript("", "<script>alert('The comment was added successfully');location.href=location.href;</script>");
                    return;
                }
            }

        }
        /// <summary>
        /// 收藏按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSC_Click(object sender, EventArgs e)
        {
            if (_PId.HasValue)
            {
                Collection entity = new Collection()
                {
                    UserID = (Session["UserInfo"] as UserInfo).UserID,
                    PostsId = _PId.Value,
                    CreateTime = DateTime.Now
                };
                if (  new CollectionManager().AddCollection(entity))
                {
                    Page.RegisterStartupScript("", "<script>alert('Successful');location.href=location.href;</script>");
                }
                else
                {
                    Page.RegisterStartupScript("", "<script>alert('Failed');;location.href=location.href;</script>");
                    return;
                }
            }
        }


        /// <summary>
        /// 是否已收藏该贴
        /// </summary>
        /// <returns></returns>
        public bool IsCollection()
        {
            return new CollectionManager().IsCollection((Session["UserInfo"] as UserInfo).UserID, _PId.Value);
        }

        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            if (new CollectionManager().DeleteCollection((Session["UserInfo"] as UserInfo).UserID, _PId.Value))
            {
                Page.RegisterStartupScript("", "<script>alert('Cancel collection success');location.href=location.href;</script>");
            }
        }
    }
}