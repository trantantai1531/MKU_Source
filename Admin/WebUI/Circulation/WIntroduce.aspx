<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WIntroduce" CodeFile="WIntroduce.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIntroduce</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE width="100%" cellpadding="4" cellspacing="1" bgcolor="#f3f3f3">
				<TR class="lbGroupTitle">
					<TD width="33%" colSpan="2"><asp:label id="lblCirculationTitle" runat="server" cssclass="lbGroupTitle">Mượn & trả</asp:label></TD>
					<TD width="33%" colSpan="2"><asp:label id="lblPatronTitle" runat="server" cssclass="lbGroupTitle">Bạn đọc</asp:label></TD>
					<TD width="34%" colSpan="2"><asp:label id="lblReportTitle" runat="server" cssclass="lbGroupTitle">Thống kê và lập lịch</asp:label></TD>
				</TR>
				<TR class="lbFunctionTR">
					<TD vAlign="middle" align="center" height="60" colSpan="1" rowSpan="1"><asp:imagebutton id="imgCheckOut" runat="server" ImageUrl="Images/index_ghi_muon.gif"></asp:imagebutton></TD>
					<TD vAlign="middle" height="60"><asp:hyperlink id="lnkCheckOut" runat="server" NavigateUrl="CheckOut/WCheckOutIndex.aspx"> Ghi mượn</asp:hyperlink><BR>
						<asp:label id="lblCheckOut" runat="server" CssClass="lbFunctionDetail">Thủ thư cho bạn đọc mượn ấn phẩm.</asp:label></TD>
					<TD vAlign="middle" align="center" height="60"><asp:imagebutton id="imgOverDue" runat="server" ImageUrl="Images/index_an_pham_qua_han.gif"></asp:imagebutton></TD>
					<TD vAlign="middle" height="60"><asp:hyperlink id="lnkOverDue" runat="server" NavigateUrl="Overdue/WOverdueList.aspx">Ấn phẩm giữ quá hạn</asp:hyperlink><br>
						<asp:label id="lblOverDue" runat="server" CssClass="lbFunctionDetail">Tra cứu, in hoặc gửi email thông báo về các ấn phẩm giữ quá hạn.</asp:label></TD>
					<TD vAlign="middle" align="center" height="60"><asp:imagebutton id="imgStat" runat="server" ImageUrl="Images/index_thong_ke.gif"></asp:imagebutton></TD>
					<TD vAlign="middle" align="left" colSpan="1" height="60" rowSpan="1"><asp:hyperlink id="lnkStat" runat="server" NavigateUrl="Statistic/WStatisticIndex.aspx"> Thống kê</asp:hyperlink><BR>
						<asp:label id="lblStat" runat="server" CssClass="lbFunctionDetail">Thống kê theo các tiêu chí liên quan đến quá trình mượn trả ấn phẩm.</asp:label></TD>
				</TR>
				<TR class="lbFunctionTR">
					<TD vAlign="middle" align="center" height="60"><asp:imagebutton id="imgCheckIn" runat="server" ImageUrl="Images/index_ghi_tra.gif"></asp:imagebutton></TD>
					<td vAlign="middle" colSpan="1" height="60" rowSpan="1"><asp:hyperlink id="lnkCheckIn" runat="server" NavigateUrl="CheckIn/WCheckInIndex.aspx">Ghi trả</asp:hyperlink><BR>
						<asp:label id="lblCheckIn" runat="server" CssClass="lbFunctionDetail"> Bạn đọc trả ấn phẩm cho thư viện.</asp:label></td>
					<TD vAlign="middle" align="center" height="60"><asp:imagebutton id="imgHoldTrans" runat="server" ImageUrl="Images/index_yeu_cau_giu_cho.gif"></asp:imagebutton></TD>
					<td vAlign="middle" colSpan="1" height="60" rowSpan="1"><asp:hyperlink id="lnkHoldTrans" runat="server" NavigateUrl="Hold/WHoldTransactionManage.aspx">Yêu cầu giữ chỗ</asp:hyperlink><BR>
						<asp:label id="lblHoldTrans" runat="server" CssClass="lbFunctionDetail">Tra cứu và xử lý các yêu cầu giữ chỗ.</asp:label></td>
					<TD vAlign="middle" align="center" colSpan="1" height="60" rowSpan="1"><asp:imagebutton id="imgMakeSchedule" runat="server" ImageUrl="Images/index_lap_lich.gif"></asp:imagebutton></TD>
					<td vAlign="middle" colSpan="1" height="60" rowSpan="1"><asp:hyperlink id="lnkMakeSchedule" runat="server" NavigateUrl="Policy/WScheduleView.aspx">Lập lịch</asp:hyperlink><BR>
						<asp:label id="lblMakeSchedule" runat="server" CssClass="lbFunctionDetail">Thiết đặt những ngày thư viện nghỉ phục vụ bạn đọc.</asp:label></td>
				</TR>
				<tr class="lbFunctionTR">
					<td vAlign="middle" align="center" height="60"><asp:imagebutton id="imgOnHold" runat="server" ImageUrl="Images/index_dang_muon.gif"></asp:imagebutton></td>
					<td vAlign="middle" colSpan="1" height="60" rowSpan="1"><asp:hyperlink id="lnkOnHold" runat="server" NavigateUrl="Statistic/WReportOnLoanCopy.aspx"> Ai đang mượn</asp:hyperlink><BR>
						<asp:label id="lblOnHold" runat="server" CssClass="lbFunctionDetail"> Tra cứu các ấn phẩm đang cho mượn.</asp:label></td>
					<td vAlign="middle" align="center" colSpan="1" height="60" rowSpan="1"><asp:imagebutton id="imgLockCard" runat="server" ImageUrl="Images/index_khoa_the.gif"></asp:imagebutton></td>
					<td vAlign="middle" colSpan="1" height="60" rowSpan="1"><asp:hyperlink id="lnkLockCard" runat="server" NavigateUrl="Policy/WLockCard.aspx"> Khoá thẻ</asp:hyperlink><BR>
						<asp:label id="lblWAcquisitionReportedFrame" runat="server" CssClass="lbFunctionDetail">Tạm khóa quyền mượn ấn phẩm thư viện của ban đọc trong một khoảng thời gian.</asp:label></td>
					<td vAlign="middle" align="center" height="60"><asp:imagebutton id="imgOverDueSendMail" runat="server" ImageUrl="Images/index_soan_thu_thong_bao.gif"></asp:imagebutton></td>
					<td vAlign="middle" colSpan="1" height="60" rowSpan="1"><asp:hyperlink id="lnkOverDueSendMail" runat="server" NavigateUrl="Overdue/WOverdueList.aspx">Soạn thư thông báo</asp:hyperlink><BR>
						<asp:label id="lblOverDueSendMail" runat="server" CssClass="lbFunctionDetail"> Soạn mẫu thư thông báo đòi sách quá hạn.</asp:label></td>
				</tr>
				<tr class="lbFunctionTR">
					<td vAlign="middle" align="center" colSpan="1" height="60" rowSpan="1"><asp:imagebutton id="imgLoaned" runat="server" ImageUrl="Images/index_tung_muon.gif"></asp:imagebutton></td>
					<td vAlign="middle" height="60"><asp:hyperlink id="lnkLoaned" runat="server" NavigateUrl="Statistic/WReportLoanCopy.aspx">Ai từng mượn</asp:hyperlink><br>
						<asp:label id="lblLoaned" runat="server" CssClass="lbFunctionDetail">Liệt kê những bạn đọc đã từng mượn sách của thư viện.</asp:label></td>
					<td vAlign="bottom" height="60"></td>
					<td vAlign="bottom" height="60"></td>
					<td vAlign="middle" align="center" height="60"><asp:imagebutton id="imgPhotocopyMan" runat="server" ImageUrl="Images/index_quan_ly_photo.gif"></asp:imagebutton></td>
					<td vAlign="middle" colSpan="1" height="60" rowSpan="1"><asp:hyperlink id="lnkPhotocopyMan" runat="server" NavigateUrl="Policy/WPhotocopyManagement.aspx"> Quản lý Photocopy</asp:hyperlink><BR>
						<asp:label id="lblPhotocopyMan" runat="server" CssClass="lbFunctionDetail"> Nhập, tra cứu, sửa đổi các yêu cầu photocopy các ấn phẩm.</asp:label>
						<P></P>
					</td>
				</tr>
				<tr class="lbFunctionTR">
					<td vAlign="middle" align="center" colSpan="1" height="60" rowSpan="1"><asp:imagebutton id="ImgPolicy" runat="server" ImageUrl="Images/index_chinh_sach_luu_thong.gif"></asp:imagebutton></td>
					<td vAlign="middle" height="60"><asp:hyperlink id="lnkPolicy" runat="server" NavigateUrl="Policy/WPolicyIndex.aspx">Chính sách lưu thông</asp:hyperlink><br>
						<asp:label id="lblPolicy" runat="server" CssClass="lbFunctionDetail">Thiết đặt các tham số chính sách lưu thông cho các dạng tài liệu khác nhau trong thư viện.</asp:label></td>
					<td vAlign="bottom" height="60"></td>
					<td vAlign="bottom" height="60"></td>
					<td vAlign="middle" align="center" height="60"><asp:imagebutton id="imgAccountMan" runat="server" ImageUrl="Images/index_quan_ly_tien_phat.gif"></asp:imagebutton></td>
					<td vAlign="middle" colSpan="1" height="60" rowSpan="1"><asp:hyperlink id="lnkAccountMan" runat="server" NavigateUrl="Accounting/WAccountManagement.aspx"> Quản lý tiền phạt</asp:hyperlink><BR>
						<asp:label id="lblAccountMan" runat="server" CssClass="lbFunctionDetail">Nhập mới, sửa đổi và báo cáo các giao dịch tiền phạt.</asp:label>
						<P></P>
					</td>
				</tr>
				<TR class="lbFunctionTR">
					<TD vAlign="middle" height="60" align="center">
						<asp:imagebutton id="ImgChangeType" runat="server" ImageUrl="Images/index_xem.gif"></asp:imagebutton></TD>
					<TD vAlign="bottom" height="60">
						<asp:hyperlink id="lnkChangeType" runat="server" NavigateUrl="Policy/WChangeLoanType.aspx">Xem và thay đổi dạng tài liệu (lưu thông)</asp:hyperlink><br>
						<asp:label id="lblChangeType" runat="server" CssClass="lbFunctionDetail">Xem và thay đổi dạng tài liệu (lưu thông) của các bản ấn phẩm.</asp:label></TD>
					<TD vAlign="bottom" height="60"></TD>
					<TD vAlign="bottom" height="60"></TD>
					<TD valign="middle" align="center" height="60"></TD>
					<TD valign="middle" height="60"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
