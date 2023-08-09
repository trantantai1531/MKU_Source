<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WSendPO" EnableViewStateMAC="False" EnableViewState="false" CodeFile="WSendPO.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSendPO</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="5" rightmargin="5">
		<form id="Form1" method="post" runat="server" style="margin-left:10px">
			<table width="99%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td width="100%" bgColor="#ffd999">
						<asp:label id="lblDownload1" Runat="server" Visible="False">Nếu hộp thoại tải file về không hiện ra bạn hãy nhấn&nbsp;</asp:label><asp:hyperlink id="lnkGetIt" Runat="server" Visible="False">vào đây</asp:hyperlink><asp:label id="lblDownload2" Runat="server" Visible="False">&nbsp;để lấy lại.</asp:label>
					</td>
				</tr>

				<tr>
					<td width="100%">
						<asp:Label ID="lblDisplay" Runat="server" Width="100%"></asp:Label></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlHeaderFooter" Runat="server" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="TITLE">Đơn duyệt mua ấn phẩm</asp:ListItem>
				<asp:ListItem Value="TITLE:UUPER">ĐƠN DUYỆT MUA ẤN PHẨM</asp:ListItem>
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
			</asp:DropDownList>
		    <input type="hidden" id="hdIDs" runat="server"/> <input type="hidden" id="hdTemplate" name="hdTemplate" runat="server" value="0"/>
			<asp:DropDownList ID="ddlPad" Runat="server" Visible="False" Height="0" Width="0">
				<asp:ListItem Value="btnPrint">In </asp:ListItem>
				<asp:ListItem Value="btnEdit">Sửa chữa</asp:ListItem>
				<asp:ListItem Value="btnEmail">Gửi thư</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Đã gửi thư tới các nhà cung cấp tương ứng</asp:ListItem>
				<asp:ListItem Value="3">Trong quá trình gửi thư có xuất hiện lỗi</asp:ListItem>
				<asp:ListItem Value="4">Gửi đơn đặt</asp:ListItem>
				<asp:ListItem Value="5">Xem chi tiết</asp:ListItem>
				<asp:ListItem Value="6">tại đây</asp:ListItem>
				<asp:ListItem Value="7">Có lỗi trong quá trình xuất file html sang file doc. Bạn chỉ có thể xem dưới dạng html !</asp:ListItem>
			</asp:DropDownList>
			<input id="hidAction" runat="server" type="hidden" NAME="hidAction">
			<input id="hidNameFile" runat="server" type="hidden" NAME="hidNameFile">
			<script language="javascript">
				if (document.forms[0].hidAction.value=='EMAIL') {
					if(eval(parent.workform))
						parent.workform.location.href = "WContractDetail.aspx?Pos=" + parseFloat(parent.taskbar.document.forms[0].txtCurrentID.value);
					else
						window.location.href = "WSendPOSearch.aspx";					
					}												
				if (document.forms[0].hidAction.value=='FILE') {					
					if(eval(parent.hiddenbase))
						parent.hiddenbase.location.href='../../Common/WSaveTempFile.aspx?ModuleID=4&FileName='+document.forms[0].hidNameFile.value;
					}
			</script>
		</form>
	</body>
</HTML>
