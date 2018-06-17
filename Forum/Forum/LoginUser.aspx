<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="LoginUser.aspx.cs" Inherits="Forum.WebForm1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cen" runat="server">
    <div style="margin-bottom:15px; margin-left:-10px;">
        <label class="label label-info" style="padding:10px 10px;" >User login</label>
    </div>
    <div class="logindiv">
    <ul>
        <li><span>User Name:</span><input type="text" class="form-control" runat="server" id="UserName" /></li>
        <li><span>Password:</span><input type="password" class="form-control" runat="server" id="UserPwd" /></li>
    </ul>
    <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-success" OnClick="btnLogin_Click"  />
</div>
</asp:Content>
