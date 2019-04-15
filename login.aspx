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

        .auto-style1 {
            height: 42px;
        }
    </style>
</head>
<body background="img/bg1.gif">
    <form id="form1" runat="server">
        <center><div class="div">
   <p class="p">加班管理系统</p>
    <table width="400" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="135" colspan="2" align="center" valign="middle" class="auto-style1">
      帐号：<asp:TextBox ID="TextBox1" runat="server" onkeyup="if(isNaN(value))execCommand('undo')" onfocus="if (value =='请输入数字'){value =''}" onblur="if (value ==''){value='请输入数字'}" value="请输入数字"  MaxLength="10"></asp:TextBox><br />
      密码：<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox><br />
      </td>
  </tr>
  </table>
<br />
        <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click"></asp:Button>&nbsp&nbsp&nbsp<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="重置" />
&nbsp;</div>
    </form>
</body>
</html>
