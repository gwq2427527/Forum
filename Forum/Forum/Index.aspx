<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Forum.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cen" runat="server">
    <div>
        <div style="color: #66667B; width: 100%; height: 40px; line-height: 40px; font-size: 18px; font-weight: 900; margin: 0 auto; background-color: #E4E9F1; text-align: left; margin-bottom: 2px;">
            <span style="margin-left: 6px;">Category List
            </span>
        </div>
        <div style="border-radius: 3px; background-color: #EEEEEE; padding-top:10px;">
            <ul class="pul" style="color: gray; width: 100%;">
                <%
                    if (_List != null)
                    {
                        for (int i = 0; i < _List.Count; i++)
                        {
                %>
                <li style="height:70px;">
                    <span style="color: #2C588D; font-size: 16px; font-weight: 900; padding-top: 6px; margin-left: -20px; display: block;"><a href="Lists.aspx?tid=+<%= _List[i].ID %>"><%=  _List[i].Name %></a></span>
                    <span style="margin-left: -10px;"><%= SubString(_List[i].Description) %>
                    </span><span style="float: right; margin-right: 10px; margin-top: -15px;">The date of creation:&nbsp;&nbsp;<span style="color: #c126f6"><%= _List[i].CreateTime.ToString("yyyy-MM-dd") %></span></span>
                </li>
                <%
                        }
                    }
                %>
            </ul>
        </div>
    </div>

</asp:Content>
