<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_personnel_insert.aspx.cs" Inherits="admin_personnel_insert" %>

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
                <div class="table-left">帐号:</div>
                <div class="table-right">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-left">密码:</div>
                <div class="table-right">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-left">名字:</div>
                <div class="table-right">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-left">部门:</div>
                <div class="table-right">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-left">职位:</div>
                <div class="table-right">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table1">
                <div class="table-left">用户类别:</div>
                <div class="table-right">
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem Value="admin">admin</asp:ListItem>
                        <asp:ListItem>leader</asp:ListItem>
                        <asp:ListItem>personnel</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div style="height: 20px; width: 100%; margin-top: 10%;">
                <div class="table-left">
                    <asp:Button ID="Button2" runat="server" Text="添加" class="layui-btn layui-btn-primary layui-btn-sm" OnClick="Button2_Click" />
                </div>
                <div class="table-right-1">
                    <asp:Button ID="Button1" runat="server" Text="重置" class="layui-btn layui-btn-primary layui-btn-sm" OnClick="Button1_Click1" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>

