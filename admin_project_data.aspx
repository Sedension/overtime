<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_project_data.aspx.cs" Inherits="admin_project_data" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="js/layui/css/layui.css" rel="stylesheet" />
    <script src="js/layui/layui.js"></script>
    <link href="css/css.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="new">
            <div class="table">
                <div class="table-left">部门：</div>
                <div class="table-right">
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="table">
                <div class="table-left">加班人员：</div>
                <div class="table-right">
                    <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="table">
                <div class="table-left">总加班时间(小时)：</div>
                <div class="table-right">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-left">总加班时间(天数)：</div>
                <div class="table-right">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
