<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_personnel.aspx.cs" Inherits="admin_personnel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="js/layui/css/layui.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/css.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="div2">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True" DataKeyNames="user_id" OnPageIndexChanging="GridView1_PageIndexChanging1" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing1" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" PageSize="20">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="user_id" HeaderText="账号" ReadOnly="True" />
                    <asp:BoundField DataField="user_name" HeaderText="姓名" />
                    <asp:BoundField DataField="position" HeaderText="职位" />
                    <asp:BoundField DataField="department" HeaderText="部门" />
                    <asp:CommandField ButtonType="Button" ShowEditButton="True"></asp:CommandField>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
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
            <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="宋体" Font-Size="10pt">
                <asp:ListItem Value="user_id">账号</asp:ListItem>
                <asp:ListItem Value="user_name">姓名</asp:ListItem>
                <asp:ListItem Value="position">职位</asp:ListItem>
                <asp:ListItem Value="department">部门</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="Button1" runat="server" class="layui-btn layui-btn-primary layui-btn-xs" OnClick="Button1_Click" Text="查询" />
            <asp:Button ID="Button2" runat="server" class="layui-btn layui-btn-primary layui-btn-xs" OnClick="Button2_Click" Text="查询全部" />
        </div>
    </form>
</body>
</html>
