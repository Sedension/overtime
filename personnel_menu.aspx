<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personnel_menu.aspx.cs" Inherits="personnel_menu" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title></title>
<link href="js/layui/css/layui.css" rel="stylesheet" />
</head>
<body class="layui-layout-body">
<form id="form1" runat="server">
<div class="layui-layout layui-layout-admin">
  <div class="layui-header">
    <div class="layui-logo"><h2>加班管理系统<h2></div>
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
                <a href="javascript:(0)"  onclick="showMenu('personnel.aspx')">加班任务明细</a>
            </li>
            <li class="layui-nav-item">
                <a href="javascript:(0)"  onclick="showMenu('login.aspx')">加班项目登记</a>
            </li>
             <li class="layui-nav-item">
                <a href="javascript:(0)"  onclick="showMenu('login.aspx')">加班项目申请</a>
            </li>
             <li class="layui-nav-item">
                <a href="javascript:(0)"  onclick="showMenu('login.aspx')">加班数据统计</a>
            </li>
        </ul>
    </div>
    </div>
  
  <div class="layui-body" style="bottom:0px">
    <!-- 内容主体区域 -->
    <div>

        <iframe id="ifm" src="admin.aspx"  frameborder="0" scrolling="no" width="100%" onload="this.height=700">

        <%--<iframe id="ifm" src="default.aspx" frameborder="0" width="100%" height="480" style="margin:0px 0px 0px 10px">--%>

        </iframe>

    </div>
  </div>
</div>
</form>
    <script src="js/layui/layui.js"></script> 
    <script>
        layui.use('element', function (){
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
                iframe.height = height;
                console.log(height);
            } catch (ex) { }
        }
        window.setInterval("reinitIframe()", 200);
    </script>
</body>
</html>
