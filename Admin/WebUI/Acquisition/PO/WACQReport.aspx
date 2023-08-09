<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WACQReport" CodeFile="WACQReport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WACQReport</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="100%"><asp:Label ID="lblDisplay" Width="100%" Runat="server"></asp:Label></td>
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
		</form>
	</body>
</HTML>
