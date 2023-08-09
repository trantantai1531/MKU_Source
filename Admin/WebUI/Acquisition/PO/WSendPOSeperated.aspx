<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WSendPOSeperated" CodeFile="WSendPOSeperated.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSendPOSeperated</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="4" cellspacing="0">
				<tr>
					<td width="100%" bgColor="#ffd999">
						<asp:label id="lblDownload1" Runat="server" Visible="False">Nếu hộp thoại tải file về không hiện ra bạn hãy nhấn&nbsp;</asp:label><asp:hyperlink id="lnkGetIt" Runat="server" Visible="False">vào đây</asp:hyperlink><asp:label id="lblDownload2" Runat="server" Visible="False">&nbsp;để lấy lại.</asp:label>
					</td>
				</tr>
				<tr>
					<td width="100%">
						<asp:Label ID="lblDisplay" Runat="server" Width="100%"></asp:Label></td>
				</tr>
				<tr class="lbControlBar">
					<td align="center" width="100%">
						<asp:Button ID="btnEdit" Runat="server" Text="Sửa chữa(m)" Width="90px"></asp:Button>
						<asp:Button ID="btnEmail" Runat="server" Text="Gửi thư(s)" Width="90px"></asp:Button>
						<asp:Button ID="btnPrint" Runat="server" Text="In(p)" Width="60px"></asp:Button>
						<asp:Button ID="btnSaveToFile" Runat="server" Text="Lưu vào file(f)" Width="130px"></asp:Button></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlCollumTitle" Runat="server" Visible="False">
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
				<asp:ListItem Value="<$SLG$>">SLG</asp:ListItem>
				<asp:ListItem Value="<$SUMAMOUNT$>">Tổng tiền</asp:ListItem>
				<asp:ListItem Value="<$STORE$>">Kho</asp:ListItem>
				<asp:ListItem Value="<$SUMLABEL$>">Tổng số:</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Đã gửi thư tới nhà cung cấp.</asp:ListItem>
				<asp:ListItem Value="3">Quá trình gửi thư có lỗi.</asp:ListItem>
				<asp:ListItem Value="4">Xem chi tiết</asp:ListItem>
				<asp:ListItem Value="5">Báo cáo phân kho.</asp:ListItem>
				<asp:ListItem Value="6">Có lỗi trong quá trình xuất file html sang file doc. Bạn chỉ có thể xem dưới dạng html !</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
