<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="js/layui/css/layui.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/css.css" />
    <style>
        .pup-up {
            display: none;
            position: absolute;
            top: 15%;
            left: 35%;
            width: 400px;
            padding: 50px;
            border: 1px solid #C0C0C0;
            background-color: white;
            z-index: 1;
            -webkit-box-shadow: 0px 3px 3px #c8c8c8;
            -moz-box-shadow: 0px 3px 3px #c8c8c8;
            box-shadow: 0px 3px 3px #c8c8c8;
            font-family: "微软雅黑";
        }
    </style>
    <script>
        function on() {
            document.getElementById("light").style.display = "block";
        }
        function close() {
            document.getElementById('light').style.display = 'none';
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="light" runat="server" class="pup-up">
            编&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 号：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            日&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 期：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            加班人员：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            部&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 门：<asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            开始时间：<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            时&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 长：<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            结束时间：<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            加班事由：<asp:Label ID="Label7" Style="word-break: break-all;" Width="300" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <table border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top">备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 注：</td>
                    <td valign="top">
                        <asp:Label ID="Label8" Style="word-break: break-all;" Width="300" runat="server" Text="Label"></asp:Label></td>
                </tr>
            </table>
            <button id="b1" style="position: absolute; left: 40%; bottom: 5%;" class="layui-btn layui-btn-primary layui-btn-sm" onclick="close()">关&nbsp; 闭</button>
        </div>
        <div class="div2">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True" OnSelectedIndexChanging="GridView1_SelectedIndexChanging">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Date_ID" HeaderText="任务编号" />
                    <asp:BoundField DataField="project_date" HeaderText="日期" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="name" HeaderText="姓名" />
                    <asp:BoundField DataField="project_time" HeaderText="时长(单位/小时)" DataFormatString="{0:t}" />
                    <asp:BoundField DataField="review" HeaderText="审核状态" />
                    <asp:CommandField ButtonType="Button" SelectText="详情" ShowSelectButton="True">
                        <ControlStyle CssClass="layui-btn layui-btn-primary layui-btn-sm" />
                    </asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <EmptyDataRowStyle BorderStyle="None" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" Height="35px" HorizontalAlign="Center" ForeColor="#333333" />
            </asp:GridView>
        </div>
        <div class="div6">
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="Date_ID">任务编号</asp:ListItem>
                <asp:ListItem Value="name">名字</asp:ListItem>
                <asp:ListItem Value="review">审核状态</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="查询全部" />
        </div>
    </form>
</body>
</html>
