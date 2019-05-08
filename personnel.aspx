<%@ Page Language="C#" AutoEventWireup="true" CodeFile="personnel.aspx.cs" Inherits="personnel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title></title>
<link href="js/layui/css/layui.css" rel="stylesheet" />
<script src="js/layui/layui.js"></script>
<link href="css/css.css" rel="stylesheet" />
<style>
    .pup-up233 {
        display: none;
        position: absolute;
        top: 15%;
        left: 35%;
        width: 400px;
        padding: 50px;
        border: 1px solid #C0C0C0;
        background-color: white;
        -webkit-box-shadow: 0px 3px 3px #c8c8c8;
        -moz-box-shadow: 0px 3px 3px #c8c8c8;
        box-shadow: 0px 3px 3px #c8c8c8;
        font-family: "宋体";
        float: none;
    }

    .table {
        height: 30px;
        width: 100%;
    }
    .table-l {
        float: left;
    }
    .table-r {
        float: left;
    }
</style>
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
            elem: '#TextBox8'
            , type: 'time'
        });
        laydate.render({
            elem: '#TextBox6'
            , type: 'time'
        });
        laydate.render({
            elem: '#TextBox3'
            , type: 'date'
        });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="light" class="pup-up233">
            <div class="table">
                <div class="table-l">编号：</div>
                <div class="table-r">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="table">
                <div class="table-l">日期：</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-l">加班人员：</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-l">部门：</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-l">开始时间：</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-l">结束时间：</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-l">时长：</div>
                <div class="table-r">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="table1">
                <div class="table-l">加班事由：</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox9" runat="server" Height="80px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                </div>
            </div>
            <div class="table1">
                <div class="table-l">备注信息：</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox10" runat="server" Height="80px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                </div>
            </div>
            <div style="height: 50px; width: 100%; margin-top: 10%;">
                <div class="table-l">
                    <asp:Button ID="Button3" runat="server" Text="编辑" class="layui-btn layui-btn-primary layui-btn-sm" OnClick="Button3_Click" />
                </div>
                <div style="float: right; width: 80%; text-align: center">
                    <asp:Button ID="Button4" runat="server" Text="关闭" class="layui-btn layui-btn-primary layui-btn-sm" OnClick="Button4_Click" />
                </div>
            </div>
        </div>
        <div class="div2" id="light1" style="z-index: -1">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" EnableModelValidation="True" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnPageIndexChanging="GridView1_PageIndexChanging1" AllowPaging="True">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Date_ID" HeaderText="任务编号" />
                    <asp:BoundField DataField="project_date" HeaderText="日期" DataFormatString="{0:d}" />
                    <asp:BoundField DataField="project_time" HeaderText="时长(单位/分钟)" />
                    <asp:BoundField DataField="details" HeaderText="加班事由" />
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
            <div>
                <div class="table">
                    <div class="table-l">部门：</div>
                    <div class="table-r">
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="table">
                    <div class="table-l">加班人员：</div>
                    <div class="table-r">
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="table">
                    <div class="table-l">总加班时间(小时)：</div>
                    <div class="table-r">
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
                <div class="table">
                    <div class="table-l">总加班时间(天数)：</div>
                    <div class="table-r">
                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="div6">
            <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="宋体" Font-Size="10pt">
                <asp:ListItem Value="Date_ID">任务编号</asp:ListItem>
                <asp:ListItem Value="user_name">名字</asp:ListItem>
                <asp:ListItem Value="review">审核状态</asp:ListItem>
            </asp:DropDownList>
            <input type="text" id="ceshi" runat="server">
            &nbsp;<asp:Button ID="Button1" runat="server" class="layui-btn layui-btn-primary layui-btn-xs" OnClick="Button1_Click" Text="查询" />
            <asp:Button ID="Button2" runat="server" class="layui-btn layui-btn-primary layui-btn-xs" OnClick="Button2_Click" Text="查询全部" />
        </div>
    </form>
</body>
</html>
