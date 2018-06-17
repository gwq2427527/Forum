<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="AddType.aspx.cs" Inherits="Forum.AddType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //验证客户输入的信息是否合法
        function checkForm() {
            var tn = $("#cen_txtTypeName").val().trim(),
                desc = $("#cen_txtAre").val();
            if (tn.length == 0) {
                alert("Categoty name can not be empty");
            } else if (desc.length == 0) {
                alert("Please enter the description！");
            } else {
                return true;
            }
            return false;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cen" runat="server">
    <div style="margin-bottom: 15px; margin-left: -10px;">
        <label class="label label-info" style="padding: 10px 10px;">Edit category</label>
    </div>
    <div class="form-horizontal">
        <div class="form-group" style="display: block; height: 40px; margin-bottom: 15px;">
            <label class="col-sm-2 control-label" id="lblUserName" runat="server">Category</label>
            <div class="col-sm-6">
                <input type="text" class="form-control" style="width: 300px;" id="txtTypeName" runat="server" placeholder="Please enter the category name" />
                <span id="spanTypeNameDesc"></span>
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label for="inputPassword" class="col-sm-2 control-label" id="lblPwd" runat="server">Description</label>
            <div class="col-sm-6">
                <textarea class="form-control" cols="110" rows="10" runat="server" placeholder="Please enter the description" id="txtAre"></textarea>
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label class="col-sm-2 control-label"></label>
            <asp:Button ID="btnReg" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnReg_Click" OnClientClick="return checkForm()" />
        </div>
    </div>
</asp:Content>
