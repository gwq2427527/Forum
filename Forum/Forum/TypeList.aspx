<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="TypeList.aspx.cs" Inherits="Forum.TypeList" %>

<%@ Register Assembly="XiaoHan" Namespace="XiaoHan.Web.Controls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".cen_anpList_p").width("18px");
        });

        function delType(typeId, obj) {
            if (confirm("Do you want to delete")) {
                $.get("/Ajax.aspx?action=delType&tid=" + typeId, function (res) {
                    if (res == "1") {
                        alert("S");
                        location.reload();
                    } else {
                        alert("F" + res);
                    }
                });
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cen" runat="server">
    <div style="margin-bottom: 15px; margin-top: -10px;">
        <label class="label label-info" style="padding: 10px 10px;">Category</label>

         <label class="label label-info" style="padding: 10px 10px;"><a href="AddType.aspx" style="color:#FFF;">Add new category</a></label>
    </div>
    <div>
        <ul class="list">
            <%
                if (Types != null && Types.Count > 0)
                {
                    for (int i = 0; i < Types.Count; i++)
                    {
                        ForumModels.Type entity = Types[i];
            %>
            <li>
                <a href="AddType.aspx?tid=<%= entity.ID %>">
                    <%= entity.Name %>
                </a>
                <% if (this.LoginUser != null && this.LoginUser.Role == 1)
                   { %>
                <span style="margin: 0px 20px; display: inline-block"><a href="javascript:delType('<%=entity.ID %>', this)">Delete</a> </span>
                <%} %>
                <span><%= string.Format("{0:yyyy-MM-dd HH:mm:ss}", entity.CreateTime) %> </span>
            </li>
            <%
                    }
                }
                else
                { %>
            <li>No data</li>
            <%   } %>
        </ul>
    </div>
    <div style="clear: both"></div>
    <div class="anp">
        <cc1:AspNetPager ID="anpList" runat="server" PageSize="10" DisplayMode="BeautyMode" TotalFormat="Total {0} Page / {1} Records" />
    </div>
    <script>
        (function () {
            var toEn = function (items) {
                for (var i in items) {
                    var txt = $(items[i]).text();
                    var newTxt;
                    if (txt == "首 页") {
                        newTxt = "First";
                    } else if (txt == "上一页") {
                        newTxt = "Prev";
                    } else if (txt == "下一页") {
                        newTxt = "Next";
                    } else if (txt == "尾 页") {
                        newTxt = "Last";
                    } else continue;
                    $(items[i]).text(newTxt);
                }
            };
            toEn($(".anp span"));
            toEn($(".anp a"));
        })();
    </script>
    <div style="clear: both"></div>
</asp:Content>
