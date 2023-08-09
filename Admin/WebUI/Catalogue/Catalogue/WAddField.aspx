<%@ Reference Page="~/Catalogue/BibliographyTemplate/WMarcFieldProperties.aspx" %>

<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WAddField" CodeFile="WAddField.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Thêm trường biên mục</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <style>
        .lbButton:hover {
            background: #1D24FB none repeat scroll 0 0 !important;
            color: white !important;
            border-radius: 5px;
            border: 1px solid #024385;
        }

        .form-btn, .lbButton {
            background: #aacfea none repeat scroll 0 0;
            border-radius: 5px;
            border: 1px solid #aacfea;
            color: #2061a3;
            cursor: pointer;
            display: inline-block;
            padding: 5px 6px;
            vertical-align: top;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" onload="document.forms[0].txtPattern.focus();"
    onkeypress="if (window.event.keyCode == 13) {document.forms[0].btnSearch.click(); return false;}">
    <form id="Form1" method="post" runat="server">
        <table id="Table1" cellspacing="0" cellpadding="1" width="100%" border="0">
            <tr class="lbPageTitle">
                <td align="center">
                    <asp:Label ID="lblMainTitle" runat="server" CssClass="lbPageTitle">Thêm trường vào form biên mục</asp:Label></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="lblSearch" runat="server"><U>T</U>ên hoặc nhãn trường:</asp:Label>
                    <asp:TextBox ID="txtPattern" runat="server" Width="200px"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Text="Tìm(s)"></asp:Button>&nbsp;
						<asp:Button ID="btnClose" runat="server" Text="Đóng(o)"></asp:Button></td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="dtgMarcFields" runat="server" Width="100%" AutoGenerateColumns="False">
                        <Columns>
                            <asp:HyperLinkColumn Target="_self" DataNavigateUrlField="FCURL1" DataNavigateUrlFormatString="{0}" DataTextField="FieldCode"
                                HeaderText="Nhãn trường" ItemStyle-HorizontalAlign="center" ItemStyle-Width="100" ItemStyle-CssClass="lbLinkFunctionDetail"></asp:HyperLinkColumn>
                            <asp:BoundColumn DataField="VietFieldName" HeaderText="Tên trường"></asp:BoundColumn>
                            <asp:BoundColumn DataField="FieldName" HeaderText="Tên trường"></asp:BoundColumn>
                            <asp:BoundColumn DataField="OnClick" HeaderText="Chọn" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid></td>
            </tr>
            <tr class="lbControlBar">
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="Thêm(a)"></asp:Button></td>
            </tr>
        </table>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn chưa nhập điều kiện tìm kiếm!</asp:ListItem>
            <asp:ListItem Value="3">Trường không tồn tại!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
