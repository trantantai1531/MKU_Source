<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WSendPOClaim" CodeFile="WSendPOClaim.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSendPOClaim</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <style>
            .lbButton {
                margin-right: 10px
            }
        </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="100%"><asp:Label ID="lblDisplay" Runat="server" Width="100%"></asp:Label></td>
				</tr>
				<tr class="lbControlBar">
					<td width="100%" align="center"><asp:Button ID="btnPrint" Runat="server" Text="In (i)"></asp:Button><asp:Button ID="btnEmail" Runat="server" Text="Gửi thư(g)"></asp:Button><asp:Button id="btnSaveToFile" Runat="server" Text="Lưu vào file(f)"></asp:Button><asp:Button ID="btnEdit" Runat="server" Text="Sửa(s)"></asp:Button></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlHeaderFooter" Runat="server" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="TITLE">Đơn khiếu nại ấn phẩm</asp:ListItem>
				<asp:ListItem Value="TITLE:UUPER">ĐƠN KHIẾU NẠI ẤN PHẨM</asp:ListItem>
				<asp:ListItem Value="TODAY">01/01/2005</asp:ListItem>
				<asp:ListItem Value="TODAY:DD">01</asp:ListItem>
				<asp:ListItem Value="TODAY:MM">01</asp:ListItem>
				<asp:ListItem Value="TODAY:YYYY">2005</asp:ListItem>
				<asp:ListItem Value="TODAY:HH">2</asp:ListItem>
				<asp:ListItem Value="TODAY:MI">50</asp:ListItem>
				<asp:ListItem Value="TODAY:SS">12</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlCollumCaption" Runat="server" Visible="False" Width="0" Height="0">
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
				<asp:ListItem Value="<$LESS$>">Số lượng thiếu</asp:ListItem>
				<asp:ListItem Value="<$MUCH$>">Số lượng thừa</asp:ListItem>
			</asp:DropDownList>
			<input type="hidden" id="hdPOID" runat="server" name="hdPOID" value="0"> <input type="hidden" id="hdTemplateID" runat="server" name="hdTemplateID" value="0">
			<input type="hidden" id="hdUbound" runat="server" name="hdUbound" value="-1">
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Đã gửi thư tới nhà cung cấp.</asp:ListItem>
				<asp:ListItem Value="3">Quá trình gửi thư có lỗi.</asp:ListItem>
				<asp:ListItem Value="4">Xem chi tiết</asp:ListItem>
				<asp:ListItem Value="5">tại đây</asp:ListItem>
				<asp:ListItem Value="6">Thư khiếu nại !</asp:ListItem>
				<asp:ListItem Value="7">Có lỗi trong quá trình xuất file html sang file doc. Bạn chỉ có thể xem dưới dạng html !</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
