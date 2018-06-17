<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="PostsDetail.aspx.cs" Inherits="Forum.PostsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cen" runat="server">
    <div style="margin-bottom:15px; margin-left:-10px;">
        <label class="label label-info" style="padding:10px 10px;" >Details</label>
    </div>
    <div>
        <div style="color:#fff; width:200px; height:40px; line-height:40px; font-size:18px; font-weight:900; margin:0 auto; border-radius:5px; background-color:#4178B0; text-align:center; margin-bottom:10px;">
            <span>
                <%= GetSubject() %>
            </span>
        </div>
        <div style="border-radius: 3px; background-color: #EEEEEE;">
            <span style="padding: 20px 10px; width: 100%; height: 100%; display: block;"><%= GetContent()%></span>
            <ul class="pul" style="color: gray; width: 100%; height: 30px;">
                <li><span style="float: left; margin-left: 16px;">
                    <%
                        if (Session["UserInfo"] != null)
                        {
                            if (IsCollection())
                            {
                    %>
                    <asp:Button ID="btnCancle" runat="server" Text="Delete from favorite list" BorderStyle="None" Style="color: #208cf3" OnClick="btnCancle_Click" />
                    <%
                            }
                            else
                            { 
                    %>

                    <asp:Button ID="btnSC" runat="server" Text="Add to favorite list" BorderStyle="None" Style="color: #208cf3" OnClick="btnSC_Click" />

                    <%   
                            }
                        } %>

                </span><span style="float: right; margin-right: 50px;">From:&nbsp;&nbsp;<span style="color: #c126f6"><%=GetName() %></span></span></li>
            </ul>
        </div>
    </div>
    <%
        if (PCds != null)
        {
            if (PCds.Tables.Count > 0)
            {
                if (PCds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < PCds.Tables[0].Rows.Count; i++)
                    {                                  
    %>
    <div style="border-radius: 3px; background-color: #EEEEEE; margin-bottom: 20px;">
        <span style="margin-left: 60px; padding-top: 15px; display: block;"><%= PCds.Tables[0].Rows[i]["Conent"].ToString() %>
        </span>
        <ul class="pul" style="color: gray; width: 100%; height: 30px;">
            <li><span style="float: right; margin-right: 60px; font-size: 12px;">From:&nbsp;&nbsp;<span style="color: #38f6aa; margin-right: 3px;"><%= PCds.Tables[0].Rows[i]["Name"].ToString()%></span>&nbsp;[<%= PCds.Tables[0].Rows[i]["CreateTime"]  %>]&nbsp;|&nbsp;&nbsp;<%=i+1 %></span></li>
        </ul>
    </div>
    <%
                    }
                }
            }
        }
    %>
    <%
        if (Session["UserInfo"] != null)
        {
    %>
    <div style="border-radius: 3px; background-color: #EEEEEE; margin-bottom: 20px;">
        <textarea class="form-control" style="width:100%" rows="10" runat="server" id="txtAre"></textarea>
        <asp:Button ID="btnSay" runat="server" Text="Submit" class="btn btn-success" Style="margin-left: 100px; margin-bottom: 20px; margin-top: 15px;" OnClick="btnSay_Click" />
    </div>
    <%
        }
        else
        {
    %>
    <div style="border-radius: 3px; background-color: #EEEEEE; margin-bottom: 20px; padding: 10px 10px;">
        <span>You have to<a href="LoginUser.aspx" style="margin: 0px 6px;">Login</a>OR<a href="UserRegistered.aspx" style="margin: 0px 6px;">Register</a></span>
    </div>
    <%
        }
    %>
</asp:Content>
