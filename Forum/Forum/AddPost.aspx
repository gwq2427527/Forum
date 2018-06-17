<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AddPost.aspx.cs" Inherits="Forum.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cen" runat="server">
    <div style="margin-bottom:15px; margin-left:-10px;">
        <label class="label label-info" style="padding:10px 10px;" >Add New Post</label>
    </div>
    <div class="form-horizontal">
        <div class="form-group" style="display:block; margin-bottom:15px;">
            <label class="col-sm-2 control-label">Title</label>
            <div class="col-sm-6">
                <input type="text" class="form-control" style="width:600px;" id="Subject" runat="server" placeholder="Please enter title" />
            </div>
        </div>
        <div class="form-group" style="display:block; margin-bottom:15px;">
            <label class="col-sm-2 control-label">Category</label>
            <div class="col-sm-6">
                <asp:DropDownList ID="ddlType" runat="server" class="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group" style="display:block; margin-bottom:15px;">
            <label for="inputPassword" class="col-sm-2 control-label">Content</label>
            <div class="col-sm-6">
                <textarea class="form-control" cols="110" rows="10" runat="server" id="txtAre"></textarea>
            </div>
        </div>
        <div class="form-group" style="display:block; margin-bottom:15px;">
            <label class="col-sm-2 control-label"></label>
            <asp:Button ID="btnAddPost" runat="server" Text="Sumbit" CssClass="btn btn-success" OnClick="btnAddPost_Click" />
        </div>
    </div>
</asp:Content>
 