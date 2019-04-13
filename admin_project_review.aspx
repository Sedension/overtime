<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_project_review.aspx.cs" Inherits="admin_book" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>书籍管理</title>
    <link rel="stylesheet" type="text/css" href="css/css.css" />
</head>
<body background="img/bg1.gif">
    <form id="form1" runat="server">
    <div class="div3">加班管理系统</div>
    <center><div class="div4">
              <asp:DropDownList ID="DropDownList1" runat="server" >
                  <asp:ListItem Value="book_id">编号</asp:ListItem>
                  <asp:ListItem Value="book_name">书名</asp:ListItem>
                  <asp:ListItem Value="book_author">作者</asp:ListItem>
                  <asp:ListItem Value="book_publishinghouse">出版社</asp:ListItem>
              </asp:DropDownList>
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
              <asp:Button ID="Button1" runat="server"  Text="查询" />
              <asp:Button ID="Button2" runat="server"  Text="查询全部" /> 
         </div>
        <div class="div1">

                <asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    <Nodes>
                        <asp:TreeNode NavigateUrl="~/admin.aspx" Text="加班项目管理" Value="加班项目管理"></asp:TreeNode>
                        <asp:TreeNode Text="加班项目审批" Value="加班项目审批"></asp:TreeNode>
                        <asp:TreeNode Text="加班项目发布" Value="加班项目发布"></asp:TreeNode>
                        <asp:TreeNode Text="加班人员管理" Value="加班人员管理"></asp:TreeNode>
                        <asp:TreeNode Text="加班数据统计" Value="加班数据统计"></asp:TreeNode>
                    </Nodes>
                    <NodeStyle Font-Names="Verdana" Font-Size="11pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Height="5px" />
                    <ParentNodeStyle Font-Bold="False" />
                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
                </asp:TreeView>
            </div>
        <div class="div2">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="编号" />
                    <asp:BoundField DataField="project_date" HeaderText="日期" />
                    <asp:BoundField DataField="personnel_name" HeaderText="加班人员" />
                    <asp:BoundField DataField="start_time" HeaderText="开始时间" />
                    <asp:BoundField DataField="project_time" HeaderText="时长(单位/小时)" />
                    <asp:BoundField DataField="end_time" HeaderText="结束时间" />
                    <asp:BoundField DataField="details" HeaderText="加班事由" />
                    <asp:BoundField DataField="remarks" HeaderText="备注" />
                    <asp:BoundField DataField="review" HeaderText="审核状态" />
                </Columns>
                  <EditRowStyle BackColor="#2461BF" />
                  <EmptyDataRowStyle BorderStyle="None" />
                  <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                  <PagerStyle BackColor="#2461BF" ForeColor="White"  />
                  <RowStyle BackColor="#EFF3FB" Height="35px" HorizontalAlign="Center"/>
                  <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />

            </asp:GridView>
        </div>
    </form>
</body>
</html>