<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="UserRegistered.aspx.cs" Inherits="Forum.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //验证客户输入的信息是否合法
        function checkForm() {
            var un = $("#cen_UserName").val().trim(),
                pswd = $("#cen_Pwd").val(),
                email = $("#cen_Email").val().trim();
            if (un.length < 2 || un.length > 20) {
                alert("User name can not be less than 2 characters long and can not be more than 20 characters!");
            } else if ($("#spanUserNameDesc").attr("isOk") != "1") {
                alert($("#spanUserNameDesc").text());
            } else if (pswd.length < 6 || pswd.length > 20) {
                alert("Password length can not be less than 6 characters, and no more than 20 characters!");
            } else if (pswd != $("#cen_SurePwd").val()) {
                alert("Password Error");
            } else if ($("#cen_Address").val().trim().length == 0) {
                alert("Please enter your address");
            } else if (!zjValidator.isEmail(email)) {
                alert("Please input the correct email address!");
            } else {
                return true;
            }

            return false;
        }

        $(document).ready(function () {
            //判断输入的用户名是否有重复
            $("#cen_UserName").blur(function () {
                var un = $(this).val().trim();
                if (un.length >= 2) {
                    $.get("/ajax.aspx?action=checkUserName&name=" + encodeURI(un), function (res) {
                        console.log(res);
                        if (res == "1") { // exists
                            $("#spanUserNameDesc").html("This username already exists, please replace!").css("color", "red").attr("isOk", "0");
                        } else { // no exists
                            if (res == "0") $("#spanUserNameDesc").html("This username is available").css("color", "blue").attr("isOk", "1");
                            else $("#spanUserNameDesc").html("Network or server exception").css("color", "red").attr("isOk", "0");
                        }
                    });
                }
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cen" runat="server">
    <div style="margin-bottom: 15px; margin-left: -10px;">
        <label class="label label-info" style="padding: 10px 10px;">User Registration</label>
    </div>
    <div class="form-horizontal">
        <div class="form-group" style="display: block; height:40px; margin-bottom: 15px;">
            <label class="col-sm-2 control-label" id="lblUserName" runat="server">User Name</label>
            <div class="col-sm-6">
                <input type="text" class="form-control" style="width: 300px;" id="UserName" runat="server" placeholder="Please enter your user name" />
                <span id="spanUserNameDesc"></span>
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label for="inputPassword" class="col-sm-2 control-label" id="lblPwd" runat="server">Password</label>
            <div class="col-sm-6">
                <input type="password" class="form-control" style="width: 600px;" id="Pwd" runat="server" placeholder="Please enter your password" />
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label for="inputPassword" class="col-sm-2 control-label">Confirm Password</label>
            <div class="col-sm-6">
                <input type="password" class="form-control" style="width: 600px;" id="SurePwd" runat="server" placeholder="Please enter your password again" />
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label for="inputPassword" class="col-sm-2 control-label">Gender</label>
            <div class="col-sm-6">
                <input type="radio" name="sex" style="display: inline;" runat="server" id="Man" />
                <span>Male</span>&nbsp;&nbsp;&nbsp;
                <input type="radio" name="sex" style="display: inline;" id="Woman" runat="server" />
                <span>Female</span>
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label for="inputPassword" class="col-sm-2 control-label">Address</label>
            <div class="col-sm-6">
                <input type="text" class="form-control" style="width: 600px;" id="Address" runat="server" placeholder="Please enter your address" />
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label class="col-sm-2 control-label">Email</label>
            <div class="col-sm-6">
                <input type="text" class="form-control" style="width: 600px;" id="Email" runat="server" placeholder="Please enter your email" />
            </div>
        </div>
        <div class="form-group" style="display: block; margin-bottom: 15px;">
            <label class="col-sm-2 control-label"></label>
            <asp:Button ID="btnReg" runat="server" Text="Register" CssClass="btn btn-success" OnClick="btnReg_Click" OnClientClick="return checkForm()" />
        </div>
    </div>
</asp:Content>
