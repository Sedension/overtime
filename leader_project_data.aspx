<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leader_project_data.aspx.cs" Inherits="leader_project_data" %>

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
            position: absolute;
            top: 15%;
            left: 35%;
            width: 400px;
            padding: 50px;
            font-family: "宋体";
            border: 5px;
        }

        .table {
            height: 50px;
            width: 100%;
        }

        .table1 {
            height: 80px;
            width: 100%;
        }

        .table-l {
            float: left;
            width: 30%;
            text-align: right;
        }

        .table-r {
            float: right;
            width: 70%;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="pup-up233">
            <div class="table">
                <div class="table-l">部门：</div>
                <div class="table-r">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="table">
                <div class="table-l">加班人员：</div>
                <div class="table-r">
                    <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="table">
                <div class="table-l">总加班时间(小时)：</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="table">
                <div class="table-l">总加班时间(天数)：</div>
                <div class="table-r">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

