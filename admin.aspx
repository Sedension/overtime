<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" type="text/css" href="css/css.css" />
</head>
<body>
    <form id="form1" runat="server">
        <%--弹出层--%>
       <div id="div" style="border:solid 5px;padding:10px;width:600px;z-index:1001; 
        position:absolute; display:none;top:50%; left:10%;margin:-50px;">
            <div style="padding:3px 15px 3px 15px;text-align:left;vertical-align:middle;" >
                <div>
                   弹出层，平时在隐藏状态，这里可以放控件，加载数据，操作数据等。
                </div>
            </div>
       </div>
       <div class="div2">

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Date_ID" HeaderText="任务编号" />
                    <asp:BoundField DataField="project_date" HeaderText="日期" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="personnel_name" HeaderText="加班人员" />
                    <asp:BoundField DataField="start_time" HeaderText="开始时间" />
                    <asp:BoundField DataField="project_time" HeaderText="时长(单位/小时)" DataFormatString="{0:t}" />
                    <asp:BoundField DataField="end_time" HeaderText="结束时间" />
                    <asp:BoundField DataField="review" HeaderText="审核状态" />
                </Columns>
                  <EditRowStyle BackColor="#999999" />
                  <EmptyDataRowStyle BorderStyle="None" />
                  <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"  />
                  <RowStyle BackColor="#F7F6F3" Height="35px" HorizontalAlign="Center" ForeColor="#333333"/>
                  <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
        </div>
        <div class="div6">
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="Date_ID">任务编号</asp:ListItem>
            <asp:ListItem Value="personnel_name">加班人员</asp:ListItem>
            <asp:ListItem Value="review">审核状态</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询" />
      <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="查询全部" />
      <asp:Button ID="Button3" runat="server" Text="Button" />
    </div>
    </form>
</body>
</html>
