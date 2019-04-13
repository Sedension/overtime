<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="js/layui/css/layui.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="css/css.css" />
<style> 
  .white_content { 
      display: none;  
      position: absolute;  
      top: 25%; 
      left: 25%;  
      width: 400px;  
      height: 400px;  
      padding: 50px;  
      border: 1px solid #C0C0C0;  
      background-color: white;  z-index:1;
      -webkit-box-shadow:0px 3px 3px #c8c8c8 ;
      -moz-box-shadow:0px 3px 3px #c8c8c8 ;
      box-shadow:0px 3px 3px #c8c8c8 ;
  }  
</style> 
    <script>
        function on()
        {
            document.getElementById("light").style.display = "block";
        }
    </script>
</head> 
<body> 
    <form id="form1" runat="server">
<a href="javascript:void(0)" onclick="on();">点击这里打开窗口</a>
        
<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

<div id="light" runat="server" class="white_content"> 
    This is the lightbox content. 
</div>
<div class="div2">

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
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
    </form>
</body> 
</html> 
