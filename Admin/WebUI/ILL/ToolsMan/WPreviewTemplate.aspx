<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WPreviewTemplate" EnableViewStateMAC="False" EnableViewState="false" CodeFile="WPreviewTemplate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Xem trước khuôn dạng</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" rightmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tblPreview" width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr Class="lbPageTitle">
					<td width="100%">
						<asp:Label ID="lblMainTitle" Runat="server" CssClass="lbPageTitle"></asp:Label></td>
				</tr>
				<tr>
					<td width="100%">
						<asp:Label ID="lblOutMsg" Runat="server"></asp:Label></td>
				</tr>
				<tr>
					<td width="100%" align="center" bgcolor="#c0c0c0">
						<asp:Button ID="btnClose" Runat="server" Text="Đóng(o)" Width="73px"></asp:Button></td>
				</tr>
			</table>
			<asp:Label ID="lblContentDataText" Runat="server" Visible="False">Số định danh,Nhan đề hoặc nhan đề tạp chí,Tác giả,Nơi xuất bản,Nhà xuất bản,Tên tùng thư,Tập-Số,Năm xuất bản,Ngày xuất bản số,Tác giả bài trích,Trang,LCCN,ISBN,ISSN,Mã tài liệu,Cơ quan bảo trợ,Tên đơn vị,Địa chỉ(dòng 1),Địa chỉ(dòng 2),Hộp thư,Thành phố,Đường phố,Quốc gia,Mã bưu điện,Mã số yêu cầu,Ngày gửi,Ngày hết hạn,Điều kiện cho mựơn,Tên đọc giả,Số thẻ độc giả,Lý do từ chối,Lớp,Khoa,Khoá học,Nơi công tác,Địa chỉ nơi làm việc,Địa chỉ nhà riêng,Ngày nhận được,Ngày ghi mượn,Ngày hết hạn mượn,Số ngày trễ</asp:Label>
			<asp:Label ID="lblContentData" Runat="server" Visible="False">123,DGSoft, DGSoft, Tp. Hồ Chí Minh, Công ty DGSoft, Kho TV - Cty DGSoft, ĐB, 2014,01/04,Tinh Tế, Tr37,111 , 222, 333,TV000001,Cty DGSoft, Phòng eMicLib, Phòng eMicLib, Cty DGSoft, SC1, Tp. Hồ Chí Minh, Nguyễn Văn Trỗi, Việt Nam, 0TV, YC01, 01/04/2014,07/07/2014, Trả phí mượn, Yên Hạ, 053106504, Không có sách này, T5, CNTT, 2003-06, DGSoft, DGSoft, Từ Liêm - Tp. Hồ Chí Minh,05/05/2014,04/04/2014,09/09/2014,6 </asp:Label>
			<asp:Label ID="lblContentDataValue" Runat="server" Visible="False">CALLNUMBER,TITLE,AUTHOR,ADDRESSOFPUBLISHER,PUBLISHER,SERIESTITLENUMBER,VOLUMEISSUE,PUBLISHEDYEAR,PUBLISHEDDATE,ARTICLEAUTHOR,PAGINATION,NATIONALBIBNUMBER,ISBN,ISSN,ITEMCODE,SPONSORINGBODY,DELIVNAME,DELIVADDRESS1,DELIVADDRESS2,DELIVBOX,DELIVCITY,DELIVSTREET,DELIVCOUNTRY,DELIVCODE,REQUESTCODE,SHIPPEDDATE,DUEDATE,DELIVCONDITION,PATRONNAME,PATRONCODE,REASONDENIED,CLASS,FACULITY,GRADE,WORKINGPLACE,WORKINGADDRESS,ADDRESS,RETRIEVEDDATE,CHECKOUTDATE,EXPIREDDATE,OVERDUEDATE</asp:Label>
			<asp:Label ID="lblPackTemplate" Runat="server" Visible="False">Mẫu nhãn đóng gói</asp:Label>
			<asp:Label ID="lblDeniedTemplate" Runat="server" Visible="False">Khuôn dạng thư từ chối</asp:Label>
			<asp:Label ID="lblNoticeTemplate" Runat="server" Visible="False">Khuôn dạng thư thông báo</asp:Label>
			<asp:Label ID="lblOverdueTemplate" Runat="server" Visible="False">Khuôn dạng thông báo quá hạn</asp:Label>
			
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
