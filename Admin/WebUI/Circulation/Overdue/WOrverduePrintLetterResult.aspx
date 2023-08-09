<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WOrverduePrintLetterResult" EnableViewState="False" EnableViewStateMac="False" CodeFile="WOrverduePrintLetterResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Hệ thống thư viện điện tử</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style type="text/css" media="print">
        P.breakhere {page-break-before: always}
  
         @page {
             size: auto; /* auto is the initial value */
             margin: 7mm; /* this affects the margin in the printer settings */
         }

        @media print {
            html, body {
                height: 99%;
            }
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <table id="PrintLetter" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td width="100%">
                    <asp:Label ID="lblPrintLetter" Width="100%" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="dgr" runat="server">
                        <PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid></td>
            </tr>
        </table>
        <asp:Label ID="lblError" runat="server" Visible="False">Không tìm thấy bạn đọc nào mượn ấn phẩm quá hạn</asp:Label><asp:Label ID="lblSequency" runat="server" Visible="False">Số thứ tự</asp:Label><asp:Label ID="lblItemCode" runat="server" Visible="False">Mã tài liệu</asp:Label><asp:Label ID="lblCopyNumber" runat="server" Visible="False">Mã xếp giá</asp:Label><asp:Label ID="lblItemTitle" runat="server" Visible="False">Nhan đề</asp:Label><asp:Label ID="lblCheckOutDate" runat="server" Visible="False">Ngày mượn</asp:Label><asp:Label ID="lblCheckInDate" runat="server" Visible="False">Ngày trả</asp:Label><asp:Label ID="lblOverDueDate" runat="server" Visible="False">Số ngày quá hạn</asp:Label><asp:Label ID="lblPenati" runat="server" Visible="False">Tiền phạt</asp:Label><asp:Label ID="lblLibrary" runat="server" Visible="False">Thư viện</asp:Label><asp:Label ID="lblStore" runat="server" Visible="False">Kho</asp:Label><asp:Label ID="lblNote" runat="server" Visible="False">Ghi chú</asp:Label><asp:DropDownList ID="ddlLabel" Width="0" runat="server" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">In thư thông báo quá hạn</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
