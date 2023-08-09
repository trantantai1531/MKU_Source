<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WSetSysParam"
    CodeFile="WSetSysParam.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSetSysParam</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/assert/systemparam.css" rel="stylesheet" />
    <style>
         .lbCheckBox > input
        {
            border: 1px solid #c7c7c7;
            height: 16px;
            margin-bottom: 10px;
            margin-left: 3px;
            margin-top: -10px;
            width: 18px;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px;
    margin-bottom: 0px;">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div class="center-form">
            <div class="content-form">
                <h1 class="main-head-form">
                    XEM VÀ THAY ĐỐI GIÁ TRỊ CỦA CÁC THAM SỐ HỆ THỐNG</h1>
                <br />
                <div class="ClearFix main-page">
                    <div class="input-control">
                        <div class="table-form">
                            <asp:Table ID="tblParams" CssClass="table-control" runat="server" Width="100%" CellPadding="1"
                                CellSpacing="1" BorderWidth="1">
                            </asp:Table>
                        </div>
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnUpdate" CssClass="form-btn" runat="server" Width="96px" Text="Cập nhật(u)">
                                </asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnReset" CssClass="form-btn" runat="server" Width="80px" Text="Đặt lại(r)">
                                </asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input type="hidden" id="hidAlterParams" runat="server"/>
        <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Tham số</asp:ListItem>
            <asp:ListItem Value="3">Giá trị</asp:ListItem>
            <asp:ListItem Value="4">Mô tả</asp:ListItem>
            <asp:ListItem Value="5">Bạn không được quyền truy cập vào chức năng này!</asp:ListItem>
            <asp:ListItem Value="6">Bạn chưa nhập giá trị cần thay đổi!</asp:ListItem>
            <asp:ListItem Value="7">Cập nhật thành công!</asp:ListItem>
            <asp:ListItem Value="8">Lỗi trong quá trình cập nhật dữ liệu!</asp:ListItem>
        </asp:DropDownList>
    </div>
    </form>
</body>
</html>
