<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WTemplate" CodeFile="WTemplate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WTemplate</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tblILLTemplate" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<tr>
					<td width="100%" colSpan="3">
						<asp:label id="lblMainTitle" CssClass="main-head-form" Width="100%" Runat="server"></asp:label></td>
				</tr>
				<TR>
					<td width="100%" colSpan="3">
						<asp:label id="lblBaspace" Runat="server"></asp:label></td>
				</TR>
				<tr>
					<td align="right" width="15%">
						<asp:label id="lblTemplate" Runat="server"><u>K</u>huôn dạng: </asp:label></td>
					<td width="75%">
						<asp:dropdownlist id="ddlTemplate" Runat="server"></asp:dropdownlist></td>
					<td width="10%"></td>
				<tr>
					<td align="right" width="15%">
						<asp:label id="lblCaption" Runat="server"><u>T</u>ên khuôn dạng: </asp:label></td>
					<td width="75%">
						<asp:textbox id="txtCaption" Width="100%" Runat="server"></asp:textbox></td>
					<td width="10%"></td>
				<tr>
					<td vAlign="top" align="right" width="15%">
						<asp:label id="lblContent" Runat="server"><u>N</u>ội dung: </asp:label></td>
					<td width="75%">
						<asp:textbox id="txtContent" Width="100%" style="border: 1px solid rgb(153, 153, 153);" Runat="server" Height="200px" Wrap="False" TextMode="MultiLine"></asp:textbox></td>
					<td width="10%"></td>
				<tr>
					<td vAlign="top" align="right" width="15%">
						<asp:label id="lblPickInformation" Runat="server">Chọn thông tin:   </asp:label></td>
					<td width="75%">
						<table id="tblPickInformation" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="15%"><asp:label id="lblItem" Runat="server">Ấ<u>n</u> phẩm</asp:label></td>
								<td width="10%"></td>
								<td width="15%"><asp:label id="lblDestination" Runat="server">Nơ<u>i</u> nhận</asp:label></td>
								<td width="10%"></td>
								<td width="15%"><asp:label id="lblRequest" Runat="server"><u>Y</u>êu cầu</asp:label></td>
								<td width="10%"></td>
								<td width="10%"><asp:label id="lblElse" Runat="server">K<u>h</u>ác</asp:label></td>
							</tr>
							<tr>
								<td width="15%"><asp:dropdownlist id="ddlItem" Runat="server"></asp:dropdownlist></td>
								<td width="10%"></td>
								<td width="15%"><asp:dropdownlist id="ddlDestination" Runat="server"></asp:dropdownlist></td>
								<td width="10%"></td>
								<td width="15%"><asp:dropdownlist id="ddlRequest" Runat="server"></asp:dropdownlist></td>
								<td width="10%"></td>
								<td width="10%"><asp:dropdownlist id="ddlElse" Runat="server">
										<asp:ListItem Value="" Selected="True"></asp:ListItem>
										<asp:ListItem Value="<$DD$>">Ngày</asp:ListItem>
										<asp:ListItem Value="<$MM$>">Tháng</asp:ListItem>
										<asp:ListItem Value="<$YYYY$>">Năm</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
					<td width="10%"></td>
				<tr class="lbControlBar">
					<td width="15%">
					<td colspan="2">
						<asp:button id="btnUpdate" Runat="server" Text="Cập nhật(u)" Width="95px"></asp:button>&nbsp;
						<asp:button id="btnPreview" Runat="server" Text="Xem trước(v)" Width="102px"></asp:button>&nbsp;
						<asp:button id="btnReset" Runat="server" Text="Làm lại(r)" Width="88px"></asp:button>&nbsp;
						<asp:button id="btnDelete" Runat="server" Text="Xoá(d)" Width="64px"></asp:button>
					</td>
				</tr>
			</table>
			<input id="hdType" type="hidden" name="hdType" runat="server"> 
			<!-- Common template --><asp:label id="lblPatron" Runat="server" Visible="False"><u>B</u>ạn đọc</asp:label><asp:label id="lblElseText" Runat="server" Visible="False">,Ngày,Tháng,Năm</asp:label><asp:label id="lblElseValue" Runat="server" Visible="False">,0,<$DD$>,<$MM$>,<$YYYY$></asp:label><asp:label id="lblItemText" Runat="server" Visible="False">,Số định danh,Nhan đề hoặc nhan đề tạp chí,Tác giả,Nơi xuất bản,Nhà xuất bản,Tên tùng thư,Tập-Số,Năm xuất bản,Ngày xuất bản số,Tác giả bài trích,Trang,LCCN,ISBN,ISSN,Mã tài liệu,Cơ quan bảo trợ</asp:label><asp:label id="lblItemValue" Runat="server" Visible="False">0,<$CALLNUMBER$>,<$TITLE$>,<$AUTHOR$>,<$ADDRESSOFPUBLISHER$>,<$PUBLISHER$>,<$SERIESTITLENUMBER$>,<$VOLUMEISSUE$>,<$PUBLISHEDYEAR$>,<$PUBLISHEDDATE$>,<$ARTICLEAUTHOR$>,<$PAGINATION$>,<$NATIONALBIBNUMBER$>,<$ISBN$>,<$ISSN$>,<$ITEMCODE$>,<$SPONSORINGBODY$></asp:label>
			<!-- Pack template --><asp:label id="lblPackTemplate" Runat="server" Visible="False">Soạn thảo mẫu đơn đóng gói</asp:label><asp:label id="lblPackDestinationText" Runat="server" Visible="False">,Tên đơn vị,Địa chỉ(dòng 1),Địa chỉ(dòng 2),Hộp thư,Thành phố,Đường phố,Quốc gia,Mã bưu điện</asp:label><asp:label id="lblPackDestinationValue" Runat="server" Visible="False">0,<$DELIVNAME$>,<$DELIVADDRESS1$>,<$DELIVADDRESS2$>,<$DELIVBOX$>,<$DELIVCITY$>,<$DELIVSTREET$>,<$DELIVCOUNTRY$>,<$DELIVCODE$></asp:label><asp:label id="lblPackRequestText" Runat="server" Visible="False">,Mã số yêu cầu,Ngày gửi,Ngày hết hạn,Điều kiện cho mựơn,Tên đọc giả,Số thẻ độc giả</asp:label>
			<asp:Label ID="lblPackRequestValue" Runat="server" Visible="False">0,<$REQUESTCODE$>,<$SHIPPEDDATE$>,<$DUEDATE$>,<$DELIVCONDITION$>,<$PATRONNAME$>,<$PATRONCODE$></asp:Label>
			<!-- Denided template --><asp:label id="lblDeniedTemplate" Runat="server" Visible="False">Soạn thảo mẫu thư từ chối</asp:label><asp:label id="lblDeniedPatronText" Runat="server" Visible="False">,Tên độc giả,Số thẻ</asp:label><asp:label id="lblDeniedPatronValue" Runat="server" Visible="False">0,<$PATRONNAME$>,<$PATRONCODE$></asp:label><asp:label id="lblDeniedRequetText" Runat="server" Visible="False">,Ngày tạo yêu cầu</asp:label><asp:label id="lblDeniedRequestValue" Runat="server" Visible="False">0,<$SHIPPEDDATE$></asp:label><asp:label id="lblDeniedElseText" Runat="server" Visible="False">,Ngày,Tháng,Năm,Lý do từ chối</asp:label>
			<asp:Label ID="lblDeniedElseValue" Runat="server" Visible="False">0,<$DD$>,<$MM$>,<$YYYY$>,<$REASONDENIED$></asp:Label>
			<!-- Notice template --><asp:label id="lblNoticeTemplate" Runat="server" Visible="False">Soạn thảo mẫu thư thông báo</asp:label><asp:label id="lblNoticePatronText" Runat="server" Visible="False">,Tên đọc giả,Số thẻ đọc giả,Lớp,Khoa,Khoá,Địa chỉ</asp:label><asp:label id="lblNoticePatronValue" Runat="server" Visible="False">0,<$PATRONNAME$>,<$PATRONCODE$>,<$CLASS$>,<$FACULITY$>,<$GRADE$>,<$WORKINGPLACE$></asp:label><asp:label id="lblNoticeRequestText" Runat="server" Visible="False">,Ngày tạo yêu cầu,Ngày nhận được</asp:label>
			<asp:Label ID="lblNoticeRequestValue" Runat="server" Visible="False">0,<$SHIPPEDDATE$>,<$RETRIEVEDDATE$></asp:Label>
			<!-- Overdue template --><asp:label id="lblOverduePatronText" Runat="server" Visible="False">,Tên đọc giả,Số thẻ đọc giả,Lớp,Khoa,Khoá,Địa chỉ </asp:label><asp:label id="lblOverduePatronValue" Runat="server" Visible="False">0,<$PATRONNAME$>,<$PATRONCODE$>,<$CLASS$>,<$FACULITY$>,<$GRADE$>,<$WORKINGPLACE$></asp:label><asp:label id="lblOverdueRequestText" Runat="server" Visible="False">,Ngày tạo yêu cầu,Ngày ghi mượn,Ngày hết hạn,Số ngày trễ</asp:label><asp:label id="lblOverdueRequestValue" Runat="server" Visible="False">0,<$SHIPPEDDATE$>,<$CHECKOUTDATE$>,<$EXPIREDDATE$>,<$OVERDUEDATE$></asp:label><asp:label id="lblOverdueTemplate" Runat="server" Visible="False">Soạn thảo mẫu đơn thư quá hạn</asp:label>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">---------- Tạo mới ----------</asp:ListItem>
				<asp:ListItem Value="3">Cập nhật khuôn dạng</asp:ListItem>
				<asp:ListItem Value="4">Xoá khuôn dạng</asp:ListItem>
				<asp:ListItem Value="5">Bạn chưa chọn khuôn dạng cần xoá!</asp:ListItem>
				<asp:ListItem Value="6">Bản ghi không được cập nhật nếu trường này không có giá trị!</asp:ListItem>
				<asp:ListItem Value="7">Tên khuôn dạng đã tồn tại trong CSDL!</asp:ListItem>
				<asp:ListItem Value="8">thành công</asp:ListItem>
				<asp:ListItem Value="9">Bạn có chắc chắn muốn xóa mẫu thư này không?</asp:ListItem>
			</asp:DropDownList>
		</form>
		<script language="javascript">
			document.forms[0].txtCaption.focus();
		</script>
	</body>
</HTML>
