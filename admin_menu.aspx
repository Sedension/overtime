<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_menu.aspx.cs" Inherits="admin_menu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理员界面</title>
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
                    <li class="layui-nav-item"><a href="javascript:(0)" onserverclick="loginOut" runat="server">退出登录</a></li>
                </ul>
            </div>
            <div class="layui-side layui-bg-black">
                <div class="layui-side-scroll">
                    <!-- 左侧导航区域 -->
                    <ul class="layui-nav layui-nav-tree" lay-filter="test">
                        <li class="layui-nav-item">
                            <a href="javascript:(0)" onclick="showMenu('admin.aspx')">项目管理</a>
                        </li>
                        <li class="layui-nav-item">
                            <a href="javascript:(0)" onclick="showMenu('admin_release.aspx')">项目发布</a>
                        </li>
                        <li class="layui-nav-item">
                            <a href="javascript:(0)" onclick="showMenu('admin_project_review.aspx')">项目审批</a>
                        </li>
                        <li class="layui-nav-item">
                            <a href="javascript:(0)" onclick="showMenu('admin_personnel.aspx')">人员管理</a>
                        </li>
                        <li class="layui-nav-item">
                            <a href="javascript:(0)" onclick="showMenu('admin_personnel_insert.aspx')">人员添加</a>
                        </li>
                        <li class="layui-nav-item">
                            <a href="javascript:(0)" onclick="showMenu('admin_project_data.aspx')">数据统计</a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="layui-body" style="bottom: 0px">
                <!-- 内容主体区域 -->
                <div>
                    <iframe id="ifm" src="admin.aspx" frameborder="0" scrolling="no" width="100%" onload="this.height=650"></iframe>
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
