<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personnel_menu.aspx.cs" Inherits="personnel_menu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>员工界面</title>
    <link href="js/layui/css/layui.css" rel="stylesheet" />
</head>
<body class="layui-layout-body">
    <form id="form1" runat="server">
        <div class="layui-layout layui-layout-admin">
            <div class="layui-header">
                <div class="layui-logo">
                    <h2>加班管理系统</h2>
                </div>
                <!-- 头部区域 -->
                <ul class="layui-nav layui-layout-right">
                    <li class="layui-nav-item">
                        <a href="javascript:;">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </a>
                    </li>
                    <li class="layui-nav-item"><a href="javascript:(0)" onserverclick="LoginOut" runat="server">退出登录</a></li>
                </ul>
            </div>
            <div class="layui-side layui-bg-black">
                <div class="layui-side-scroll">
                    <!-- 左侧导航区域 -->
                    <ul class="layui-nav layui-nav-tree" lay-filter="test">
                        <li class="layui-nav-item">
                            <a href="javascript:(0)" onclick="showMenu('personnel.aspx')">信息汇总</a>
                        </li>
                        <li class="layui-nav-item">
                            <a href="javascript:(0)" onclick="showMenu('personnel_new.aspx')">项目登记</a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="layui-body" style="bottom: 0px">
                <!-- 内容主体区域 -->
                <div>
                    <iframe id="ifm" src="personnel.aspx" frameborder="0" scrolling="no" width="100%" onload="this.height=650"></iframe>
                </div>
            </div>
        </div>
    </form>
    <script src="js/layui/layui.js"></script>
    <script>
        layui.use('element', function () {
            var element = layui.element;
        });
        //显示菜单
        function showMenu(src) {
            document.getElementById("ifm").src = src;
        }
        function reinitIframe() {
            var iframe = document.getElementById("ifm");
            try {
                var bHeight = iframe.contentWindow.document.body.scrollHeight;
                var dHeight = iframe.contentWindow.document.documentElement.scrollHeight;
                var height = Math.max(bHeight, dHeight);
            } catch (ex) { }
        }
        window.setInterval("reinitIframe()", 200);
    </script>
</body>
</html>
