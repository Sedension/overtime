<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>系统登录界面</title>
    <link href="css/css.css" rel="stylesheet" />
    <style>
        .bg {
            background: url("image/login.jpg");
            /*该图片由Free-PhotosPixabay上发布*/
        }
        #login {
            position: absolute;
            padding: 50px;
            width: 250px;
            height: 400px;
            background-color: rgba(255,255,255,0.7);
            box-shadow: 5px 5px 50px silver;
            border-radius: 10px;
            top: 25%;
            left: 65%;
        }
        .login-table{
            height:50px;
            width:100%;
        }
        .login-text {
            height: 70px;
            color: #757c80;
            font-size: 24px;
            font-weight: bold;
            text-align: center;
        }
        .login-input {
            margin: 0 auto;
            width: 200px;
            padding: 0;
            border: 1px solid #dfebf2;
            background-color: #fff;
            border-radius: 4px;
        }

        .submit-left {
            margin-left:20px;
            float: left;
            width: 40%;
            text-align: center;
            height: 30px;
            background-color: #25c6ff;
            border-radius: 4px;
        }
        .submit-right {
            margin-right:20px;
            float: right;
            width: 40%;
            text-align: center;
            height: 30px;
            background-color: #25c6ff;
            border-radius: 4px;
        }
        .input{
               width:200px;
               border-style:none;
               outline:none;
        }
        .submit{
            background-color: #25c6ff;
            border-style:none;
            Color:white;
            height:30px;
            width:90px;
        }
    </style>
</head>
<body class="bg">
    <form id="form1" runat="server">
        <div id="login">
            <div class="login-text">加班管理系统</div>
            <div class="login-table">
                <div class="login-input">
                    <asp:TextBox ID="TextBox1" runat="server"  value="请输入数字账号" MaxLength="10" CssClass="input" ></asp:TextBox>
                </div>
            </div>
            <div class="login-table">
                <div class="login-input">
                    <asp:TextBox ID="TextBox2" runat="server"  CssClass="input" ></asp:TextBox>
                </div>
            </div>
            <div class="login-table">
                <div class="submit-left">
                    <asp:Button ID="Button1"  runat="server" Text="登录" OnClick="Button1_Click" CssClass="submit" ></asp:Button>
                </div>
                <div class="submit-right">
                    <asp:Button ID="Button2"  runat="server" OnClick="Button2_Click" Text="重置" CssClass="submit" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
