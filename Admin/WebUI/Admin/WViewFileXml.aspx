<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WViewFileXml" CodeFile="WViewFileXml.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WViewFileXml</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px;">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body set-log-mod">
                <div class="content-form">
                    <div class="main-group-form" style="  text-align: center;padding: 4px 10px 10px;">
                        <asp:HyperLink ID="lnkLanguageEditor" runat="server" style="color:white;" CssClass="lbGroupTitle" ForeColor="white">Xem tất cả</asp:HyperLink>
                        <span style="color:white;  font-size: 20px;margin-left: 10px; vertical-align: middle">Danh sách các trang trong thư mục</span>
                    </div>
                    <div class="table-form">
                        <asp:Table ID="tblResult" runat="server" Width="100%" CellPadding="2" CellSpacing="1"></asp:Table>
                        <input id="hidFilexml" type="hidden" name="hidFilexml" runat="server"/>
                    </div>
                </div>

            </div>
        </div>

        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0px">
            <asp:ListItem Value="0">Chọn file</asp:ListItem>
            <asp:ListItem Value="1">Tên file</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="3">Cập nhật nội dung</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
