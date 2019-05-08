<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>系统登录界面</title>
    <style>
        .div {
            height: 300px;
            width: 500px;
            position: absolute;
            top: 30%;
            left: 40%;
            background-color: beige;
        }

        .p {
            font-family: "楷体";
            font-size: 40px;
            font-weight: 800;
        }

        .table {
            height: 50px;
            width: 100%;
        }

        .table-l {
            float: left;
            width: 40%;
            text-align: right;
        }

        .table-r {
            float: right;
            width: 60%;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <center><div class="div">
   <p class="p">加班管理系统</p>
                <div class="table">
                <div class="table-l">帐号：</div>
                <div class="table-r">
<asp:TextBox ID="TextBox1" runat="server" onkeyup="if(isNaN(value))execCommand('undo')" onfocus="if (value =='请输入数字'){value =''}" onblur="if (value ==''){value='请输入数字'}" value="请输入数字"  MaxLength="10" Width="120px"></asp:TextBox>
                </div>
            </div>
                  <div class="table">
                <div class="table-l">密码：</div>
                <div class="table-r">
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="120px"></asp:TextBox>          
                </div>
            </div>
            <div class="table">
                <div class="table-l"><asp:Button ID="Button1" class="layui-btn layui-btn-primary layui-btn-sm" runat="server" Text="登录" OnClick="Button1_Click">     </asp:Button></div>
                <div class="table-r" style="text-align:center"><asp:Button ID="Button2" class="layui-btn layui-btn-primary layui-btn-sm" runat="server" OnClick="Button2_Click" Text="重置" /></div>
            </div>
</div>
    </form>
</body>
</html>
