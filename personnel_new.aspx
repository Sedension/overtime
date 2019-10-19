<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personnel_new.aspx.cs" Inherits="personnel_new" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="js/layui/css/layui.css" rel="stylesheet" />
    <script src="js/layui/layui.js"></script>
    <link href="css/css.css" rel="stylesheet" />
    <script>
        function on() {
            document.getElementById("light").style.display = "block";
        }
        function close() {
            document.getElementById("light").style.display = "none";
        }
        layui.use('laydate', function () {
            var laydate = layui.laydate;
            //日期时间选择器
            laydate.render({
                elem: '#TextBox4'
                , type: 'time'
            });
            laydate.render({
                elem: '#TextBox5'
                , type: 'time'
            });
            laydate.render({
                elem: '#TextBox1'
                , type: 'date'
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="new">
            <div class="table">
                <div class="table-left">日期：</div>
                <div class="table-right">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-left">部门：</div>
                <div class="table-right">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="table">
                <div class="table-left">加班人员：</div>
                <div class="table-right">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="table">
                <div class="table-left">开始时间：</div>
                <div class="table-right">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-left">结束时间：</div>
                <div class="table-right">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table1">
                <div class="table-left">加班事由：</div>
                <div class="table-right">
                    <asp:TextBox ID="TextBox6" runat="server" Height="80px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                </div>
            </div>
            <div class="table1">
                <div class="table-left">备注信息：</div>
                <div class="table-right">
                    <asp:TextBox ID="TextBox7" runat="server" Height="80px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                </div>
            </div>
            <div style="height: 80px; width: 100%; margin-top: 10%;">
                <div class="table-left">
                    <asp:Button ID="Button2" runat="server" Text="提交" class="layui-btn layui-btn-primary layui-btn-sm" OnClick="Button2_Click" />
                </div>
                <div class="table-right-1">
                    <asp:Button ID="Button1" runat="server" Text="重置" class="layui-btn layui-btn-primary layui-btn-sm" OnClick="Button1_Click1" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
