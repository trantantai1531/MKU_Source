<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.GetReferences" CodeFile="WGetReferences.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WGetReference</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <asp:Label ID="lblMainTitle" runat="server" CssClass="main-group-form">Tra cứu từ điển tham chiếu</asp:Label>
            <div class="main-form">
                <div class="row-detail">
                    <div class="input-control">
                        <div class="input-form">
                            <asp:ListBox ID="lstEntries" CssClass="text-input" runat="server" Height="200px" Width=""></asp:ListBox>
                        </div>
                    </div>
                </div>
                
                <div class="button-control">
                <div class="button-form">
                    <asp:Button ID="btnSelect" runat="server" CssClass="lbButton" Text="Chọn (s)"></asp:Button>
                    
                </div>
                    <div class="button-form">
                        <asp:Button ID="btnClose" runat="server" CssClass="lbButton" Text="Đóng (c)"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Tra cứu từ điển tham chiếu</asp:ListItem>
            <asp:ListItem Value="3">Không có mục từ nào thoả mãn điều kiện tìm kiếm</asp:ListItem>
            <asp:ListItem Value="4">Từ điển tham chiếu của mục từ trên không tồn tại</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
