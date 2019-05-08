<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_personnel_insert.aspx.cs" Inherits="admin_personnel_insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="js/layui/css/layui.css" rel="stylesheet" />
    <script src="js/layui/layui.js"></script>
    <link href="css/css.css" rel="stylesheet" />
    <style>
        .pup-up233 {
            position: absolute;
            top: 15%;
            left: 35%;
            width: 400px;
            padding: 50px;
            font-family: "宋体";
            border: 5px;
        }

        .table {
            height: 30px;
            width: 100%;
        }

        .table1 {
            height: 50px;
            width: 100%;
        }

        .table-l {
            float: left;
            width: 20%;
            text-align: right;
        }

        .table-r {
            float: right;
            width: 80%;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="pup-up233">
            <div class="table">
                <div class="table-l">帐号:</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-l">密码:</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-l">名字:</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-l">部门:</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-l">职位:</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table1">
                <div class="table-l">用户类别:</div>
                <div class="table-r">
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem Value="admin">admin</asp:ListItem>
                        <asp:ListItem>leader</asp:ListItem>
                        <asp:ListItem>personnel</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div style="height: 20px; width: 100%; margin-top: 10%;">
                <div class="table-l">
                    <asp:Button ID="Button2" runat="server" Text="添加" class="layui-btn layui-btn-primary layui-btn-sm" OnClick="Button2_Click" />
                </div>
                <div style="float: right; width: 80%; text-align: center">
                    <asp:Button ID="Button1" runat="server" Text="重置" class="layui-btn layui-btn-primary layui-btn-sm" OnClick="Button1_Click1" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>

