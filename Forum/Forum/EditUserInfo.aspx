<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="EditUserInfo.aspx.cs" Inherits="Forum.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  <script type="text/javascript">
        //验证用户信息
        function checkForm() {
            var un = $("#cen_UserName").val().trim(),
                  email = $("#cen_Email").val().trim();
            if (un.length < 2 || un.length > 20) {
                alert("User name can not be less than 2 characters long and can not be more than 20 characters!");
            } else if ($("#cen_Address").val().trim().length == 0) {
                alert("Please enter an address!");
            } else if (!zjValidator.isEmail(email)) {
                alert("Please enter a correct email address!");
            } else {
                return true;
            }

            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cen" runat="server">
    <div style="margin-bottom: 15px; margin-left: -10px;">
        <label class="label label-info" style="padding: 10px 10px;">Edit</label>
    </div>
    <div class="form-horizontal">
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label class="col-sm-2 control-label" id="lblUserName" runat="server">User Name</label>
            <div class="col-sm-6">
                <input type="text" class="form-control" style="width: 300px;" id="UserName" readonly="readonly" runat="server" placeholder="Please enter your user name" />
                <span id="spanUserNameDesc"></span>
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label for="inputPassword" class="col-sm-2 control-label" id="lblPwd" runat="server">Old password </label>
            <div class="col-sm-6">
                <input type="password" class="form-control" style="width: 600px; float: left;" id="Pwd" runat="server" placeholder="Please enter old password" />
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label for="inputPassword" class="col-sm-2 control-label" runat="server" id="lblnewPwd">New Password</label>
            <div class="col-sm-6">
                <input type="password" class="form-control" style="width: 600px;" id="newPwd" runat="server" placeholder="Please enter new password" />
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label for="inputPassword" class="col-sm-2 control-label" runat="server" id="lblSurePwd">Confirm password</label>
            <div class="col-sm-6">
                <input type="password" class="form-control" style="width: 600px;" id="surePwd" runat="server" placeholder="Please enter new password again" />
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label for="inputPassword" class="col-sm-2 control-label" id="sex" runat="server">Gender</label>
            <div class="col-sm-6">
                <input type="radio" name="sex" style="display: inline;" runat="server" id="Man" />
                <asp:Label ID="Label1" runat="server" Text="Label"><span>Male</span>&nbsp;&nbsp;&nbsp;</asp:Label>
                <input type="radio" name="sex" style="display: inline;" id="Woman" runat="server" />
                <asp:Label ID="Label2" runat="server" Text="Label"><span>Female</span></asp:Label>
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label for="inputPassword" class="col-sm-2 control-label" runat="server" id="lblAddress">Addresss</label>
            <div class="col-sm-6">
                <input type="text" class="form-control" style="width: 600px;" id="Address" runat="server" placeholder="Please enter your address" />
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label class="col-sm-2 control-label" runat="server" id="lblEmail">Email</label>
            <div class="col-sm-6">
                <input type="text" class="form-control" style="width: 600px;" id="Email" runat="server" placeholder="Please enter your email" />
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label class="col-sm-2 control-label"></label>
            <asp:Button ID="btnReg" runat="server" Text="Save" CssClass="btn btn-success" OnClientClick="return checkForm()" OnClick="btnReg_Click" />
        </div>
    </div>
</asp:Content>