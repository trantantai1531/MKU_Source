<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WACQsRequest" CodeFile="WACQsRequest.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Đặt mua ấn phẩm định kỳ</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD class="lbPageTitle" align="left" width="100%" colSpan="4">
						<asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle">Lập yêu cầu bổ sung ấn phẩm định kỳ</asp:label></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="5">&nbsp;</TD>
				</TR>
				<TR>
					<TD align="right" width="22%">
						<asp:label id="lblTitle" runat="server" Width="150px"><U>N</U>han đề: </asp:label>&nbsp;</TD>
					<TD width="50%" colSpan="2">
						<asp:textbox id="txtTitle" runat="server" Width="100%"></asp:textbox></TD>
					<TD><asp:Label ID="lblNote1" Runat="server" ForeColor="red" ToolTip="Trường bắt buộc">(*)</asp:Label>&nbsp;
						<asp:hyperlink id="lnkCheckExists" runat="server" Width="64px">Kiểm tra</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right" width="22%">
						<asp:label id="lblAuthor" runat="server" Width="150px"><U>T</U>ác giả:</asp:label>&nbsp;</TD>
					<TD colSpan="2">
						<asp:textbox id="txtAuthor" runat="server" Width="100%"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right" width="22%">
						<asp:label id="lblPublisher" runat="server" Width="150px">Nhà <U>x</U>uất bản:</asp:label>&nbsp;</TD>
					<TD colSpan="2">
						<asp:textbox id="txtPublisher" runat="server" Width="100%"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right" width="22%">
						<asp:label id="lblPubYear" runat="server" Width="150px">Năm x<U>u</U>ất bản:</asp:label>&nbsp;</TD>
					<TD colSpan="2">
						<asp:textbox id="txtPubYear" runat="server" Width="100%"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right" width="22%">
						<asp:label id="lblISSN" runat="server" Width="150px">IS<U>S</U>N:</asp:label>&nbsp;</TD>
					<TD width="18%">
						<asp:textbox id="txtISSN" runat="server" Width="91px"></asp:textbox></TD>
					<TD align="right" width="37%">
						<asp:label id="lblSerialCode" runat="server" Width="66px"><U>M</U>ã số:</asp:label>
						<asp:textbox id="txtSerialCode" runat="server" Width="76px"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right" width="22%">
						<asp:label id="lblLanguage" runat="server" Width="150px">Ng<u>ô</u>n ngữ:</asp:label>&nbsp;</TD>
					<TD colSpan="3">
						<asp:dropdownlist id="ddlLanguage" runat="server" Width="243px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right" width="22%">
						<asp:label id="lblCountry" runat="server" Width="150px">Nước xuất b<u>ả</u>n:</asp:label>&nbsp;</TD>
					<TD colSpan="3">
						<asp:dropdownlist id="ddlCountry" runat="server" Width="243px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right" width="22%">
						<asp:label id="lblRegularityCode" runat="server" Width="139px"><U>C</U>ấp định kỳ:</asp:label>&nbsp;</TD>
					<TD width="18%">
						<asp:dropdownlist id="ddlRegularityCode" runat="server"></asp:dropdownlist></TD>
					<TD align="right" width="37%">
						<asp:label id="lblIssues" runat="server" Width="54px">Số k<U>ỳ:</U></asp:label>
						<asp:textbox id="txtIssues" runat="server" Width="50px" MaxLength="4">1</asp:textbox>
						<asp:label id="lblIssuedPrice" runat="server" Width="59px">Giá l<u>ẻ</u>:</asp:label>
						<asp:textbox id="txtIssuePrice" runat="server" Width="71px" MaxLength="10">0</asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right" width="22%">
						<asp:label id="lblValidSubscribedDate" runat="server" Width="150px">Ngày bắt đầu <u>đ</u>ặt:</asp:label>&nbsp;</TD>
					<TD width="18%">
						<asp:textbox id="txtValidSubscribedDate" runat="server" Width="76px"></asp:textbox>&nbsp;
						<asp:hyperlink id="lnkValidSubscribedDate" runat="server" Width="38px">Lịch</asp:hyperlink></TD>
					<TD align="right" width="37%">
						<asp:label id="lblExpiredSubscribedDate" runat="server" Width="151px">Ngày <u>k</u>ết thúc đặt:</asp:label>
						<asp:textbox id="txtExpiredSubscribedDate" runat="server" Width="76px"></asp:textbox></TD>
					<TD>&nbsp;
						<asp:hyperlink id="lnkExpiredSubscribedDate" runat="server" Width="32px">Lịch</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right" width="22%" style="HEIGHT: 18px">
						<asp:label id="lblMedium" runat="server" Width="149px"><u>V</u>ật mang tin: </asp:label>&nbsp;</TD>
					<TD colSpan="3" style="HEIGHT: 18px">
						<asp:dropdownlist id="ddlMedium" runat="server" Width="158px"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right" width="22%">
						<asp:label id="lblRequestedCopies" runat="server" Width="150px">Số lượn<u>g</u></asp:label>&nbsp;</TD>
					<TD width="18%">
						<asp:textbox id="txtRequestedCopies" runat="server" Width="78px" MaxLength="4">1</asp:textbox></TD>
					<TD align="right" width="37%">
						<asp:label id="lblUnitPrice" runat="server" Width="63px">Đơn g<U>i</U>á: </asp:label>
						<asp:textbox id="txtUnitPrice" runat="server" Width="78px" MaxLength="10"></asp:textbox>
						<asp:dropdownlist id="ddlCurrency" runat="server" Width="55px"></asp:dropdownlist></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right" width="22%">
						<asp:label id="lblRequester" runat="server" Width="150px">Người <U>l</U>ập yêu cầu:</asp:label>&nbsp;</TD>
					<TD colSpan="2">
						<asp:textbox id="txtRequester" runat="server" Width="100%" Enabled="False"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right" width="22%">
						<asp:label id="lblNote" runat="server" Width="150px">G<U>h</U>i chú:</asp:label>&nbsp;</TD>
					<TD colSpan="2">
						<asp:textbox id="txtNote" runat="server" Width="100%"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right" width="22%">
						<asp:label id="lblUrgency" runat="server" Width="150px">Mức độ <u>q</u>uan trọng:</asp:label>&nbsp;</TD>
					<TD colSpan="3">
						<asp:dropdownlist id="ddlUrgency" runat="server" Width="150px">
							<asp:ListItem Value="1">Bình thường</asp:ListItem>
							<asp:ListItem Value="2">Cao</asp:ListItem>
							<asp:ListItem Value="3">Rất cao</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR Class="lbControlBar">
					<TD></TD>
					<TD colSpan="3">
						<asp:button id="btnInsert" runat="server" Width="115px" Text="Lập yêu cầu(u)"></asp:button>
						<asp:button id="btnReset" runat="server" Width="76px" Text="Đặt lại(r)"></asp:button>
						<asp:button id="btnZ3950" runat="server" Width="150px" Text="Tải về qua Z3950(z)"></asp:button>&nbsp;
					</TD>
				</TR>
			</TABLE>
			<INPUT id="txtRequestID" type="hidden" name="txtRequestID" runat="server"> <input id="hidLanguageISOCode" type="hidden" runat="server" name="hidLanguageISOCode">
			<input id="hidLanguageID" type="hidden" runat="server" name="hidLanguageID"> <input id="hidCountryISOCode" type="hidden" runat="server" NAME="hidCountryISOCode">
			<input id="hidCountryID" type="hidden" runat="server" NAME="hidCountryID">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Lỗi trong quá trình xử lý</asp:ListItem>
				<asp:ListItem Value="3">Cập nhật dữ liệu thành công</asp:ListItem>
				<asp:ListItem Value="4">Bản ghi không được cập nhật nếu giá trị trường này trống</asp:ListItem>
				<asp:ListItem Value="5">Sai kiểu dữ liệu (số)</asp:ListItem>
				<asp:ListItem Value="6">Cập nhật bản ghi có nhan đề: </asp:ListItem>
				<asp:ListItem Value="7">Sai kiểu dữ liệu ngày tháng</asp:ListItem>
				<asp:ListItem Value="8">Ngày bắt đầu đặt phải bé hơn ngày kết thúc đặt !</asp:ListItem>
				<asp:ListItem Value="9">Bạn không được cấp quyền sử dụng chức năng này.</asp:ListItem>
			</asp:DropDownList>
		</form>
		<script language="javascript">
			document.forms[0].txtTitle.focus();
		</script>
	</body>
</HTML>
