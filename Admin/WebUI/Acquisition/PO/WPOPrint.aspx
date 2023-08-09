<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WPOPrint" EnableViewStateMac="False" EnableViewState="false" CodeFile="WPOPrint.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WPOPrint</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <style>
        .lbButton {
            margin-right: 10px;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td width="100%" bgcolor="#ffd999">
                    <asp:Label ID="lblDownload1" runat="server" Visible="False">Nếu hộp thoại tải file về không hiện ra bạn hãy nhấn&nbsp;</asp:Label><asp:HyperLink ID="lnkGetIt" runat="server" Visible="False">vào đây</asp:HyperLink><asp:Label ID="lblDownload2" runat="server" Visible="False">&nbsp;để lấy lại.</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDisplay" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnEdit" runat="server" Text="Sửa (s)"></asp:Button><asp:Button ID="btnPrint" runat="server" Text="In (i)"></asp:Button><asp:Button ID="btnEmail" runat="server" Text="Gửi Email(e)"></asp:Button></td>
            </tr>
        </table>
        <asp:DropDownList ID="ddlCollumTitle" runat="server" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="<$SEQUENCY$>">Số thứ tự</asp:ListItem>
            <asp:ListItem Value="<$TITLE$>">Nhan đề</asp:ListItem>
            <asp:ListItem Value="<$AUTHOR$>">Tác giả</asp:ListItem>
            <asp:ListItem Value="<$EDITION$>">Lần xuất bản</asp:ListItem>
            <asp:ListItem Value="<$PUBLISHER$>">Nhà xuất bản</asp:ListItem>
            <asp:ListItem Value="<$YEAR$>">Năm xuất bản</asp:ListItem>
            <asp:ListItem Value="<$ISBN$>">ISBN</asp:ListItem>
            <asp:ListItem Value="<$ISSN$>">ISSN</asp:ListItem>
            <asp:ListItem Value="<$LANGUAGE$>">Ngôn ngữ</asp:ListItem>
            <asp:ListItem Value="<$COUNTRY$>">Nước xuất bản</asp:ListItem>
            <asp:ListItem Value="<$FREQCODE$>">Cấp định kỳ</asp:ListItem>
            <asp:ListItem Value="<$ISSUES$>">Số kỳ</asp:ListItem>
            <asp:ListItem Value="<$ISSUEPRICE$>">Giá lẻ</asp:ListItem>
            <asp:ListItem Value="<$SERIACODE$>">Mã số</asp:ListItem>
            <asp:ListItem Value="<$VALDSUBSCRIBEDDATE$>">Ngày yêu cầu</asp:ListItem>
            <asp:ListItem Value="<$EXPIRESUBSCRIBEDDATE$>">Ngày dừng yêu cầu</asp:ListItem>
            <asp:ListItem Value="<$DOCUMENTTYPE$>">Kiểu tài liệu</asp:ListItem>
            <asp:ListItem Value="<$MEDIUM$>">Vật mang tin</asp:ListItem>
            <asp:ListItem Value="<$UNITPRICE$>">Đơn giá</asp:ListItem>
            <asp:ListItem Value="<$CURRENCY$>">Đơn vị tiền tệ</asp:ListItem>
            <asp:ListItem Value="<$REQUESTEDCOPIES$>">Số lượng yêu cầu</asp:ListItem>
            <asp:ListItem Value="<$ACCEPTEDCOPIES$>">Số lượng duyệt</asp:ListItem>
            <asp:ListItem Value="<$RETRIEVEDCOPIES$>">Số nhận được</asp:ListItem>
            <asp:ListItem Value="<$ERRONEUOS$>">Số lượng sai lệch</asp:ListItem>
            <asp:ListItem Value="<$MONEY$>">Tổng số tiền</asp:ListItem>
            <asp:ListItem Value="<$REQUESTER$>">Người yêu cầu</asp:ListItem>
            <asp:ListItem Value="<$URGENCY$>">Cấp độ mật</asp:ListItem>
            <asp:ListItem Value="<$NOTE$>">Ghi chú</asp:ListItem>
        </asp:DropDownList><asp:DropDownList ID="ddlLabel" runat="server" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Xem chi tiết</asp:ListItem>
            <asp:ListItem Value="3">tại đây</asp:ListItem>
            <asp:ListItem Value="4">Gửi thư thành công !</asp:ListItem>
            <asp:ListItem Value="5">Có lỗi trong quá trình gửi thư !</asp:ListItem>
            <asp:ListItem Value="6">Đơn đặt mua sách !</asp:ListItem>
            <asp:ListItem Value="7">Bạn hãy đánh địa chỉ email cần gửi tới:</asp:ListItem>
            <asp:ListItem Value="8">Địa chỉ email không đúng định dạng!</asp:ListItem>
            <asp:ListItem Value="9">Có lỗi trong quá trình xuất file html sang file doc. Bạn chỉ có thể xem dưới dạng html !</asp:ListItem>
        </asp:DropDownList><input id="hidToEmail" type="hidden" name="hidToEmail" runat="server">
        <input id="hdDisplay" type="hidden" name="hdDisplay" runat="server">
        <input id="txtCaption" name="txtCaption" type="hidden" value="<%=Request("txtCaption")%>" />
        <input id="txtSumCurrency" name="txtSumCurrency" type="hidden" value="<%=Request("txtSumCurrency")%>" />
        <input id="ddlSumCurrency" name="ddlSumCurrency" type="hidden" value="<%=Request("ddlSumCurrency")%>" />
        <input id="hdAccepted" name="hdAccepted" type="hidden" value="<%=Request("hdAccepted")%>" />
        <input id="ddlPublisher" name="ddlPublisher" type="hidden" value="<%=Request("ddlPublisher")%>" />
        <input id="ddlMedium" name="ddlMedium" type="hidden" value="<%=Request("ddlMedium")%>" />
        <input id="ddlMedia" name="ddlMedia" type="hidden" value="<%=Request("ddlMedia")%>" />
        <input id="ddlUrgency" name="ddlUrgency" type="hidden" value="<%=Request("ddlUrgency")%>" />
        <input id="txtFromDate" name="txtFromDate" type="hidden" value="<%=Request("txtFromDate")%>" />
        <input id="txtToDate" name="txtToDate" type="hidden" value="<%=Request("txtToDate")%>" />
        <input id="txtCurrency" name="txtCurrency" type="hidden" value="<%=Request("txtCurrency")%>" />
        <input id="ddlCurrency" name="ddlCurrency" type="hidden" value="<%=Request("ddlCurrency")%>" />
        <input id="ddlForm" name="ddlForm" type="hidden" value="<%=Request("ddlForm")%>" />
    </form>
</body>
</html>
