<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WILLTechnical.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.WILLTechnical"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WILLTechnical</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body leftMargin="0" topMargin="0" MS_POSITIONING="GridLayout" onload="ResetCtlValue();ChangeFontType();document.forms[0].txtAuthor.focus();">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td>
						<table width="100" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td width="13" rowspan="2"><img border="0" src="../Images/ImgViet/title_01.gif" width="13" height="55"></td>
								<td height="15" colspan="2" style="WIDTH: 204px"><img border="0" src="../Images/ImgViet/title_02.gif" width="85" height="15"></td>
							</tr>
							<tr>
								<td width="40"><img border="0" src="../Images/ImgViet/title_03.gif" width="40" height="40"></td>
								<td width="115" background="../Images/ImgViet/title_bg.gif" align="left" style="WIDTH: 118px"><asp:label id="lblTitleIllTechnical" CssClass="lbTitleHeader" Runat="server">ILL</asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="2" height="10"></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="2" width="100%" border="0">
				<tr>
					<td colSpan="2"><asp:label CssClass="lbPageTitle" Width="100%" id="lblMainTitle" Runat="server"> Yêu cầu mượn Báo cáo kỹ thuật</asp:label></td>
				</tr>
				<tr>
					<td align="right" width="30%"><asp:label id="lblAuthor" Runat="server"> <U>T</U>ác giả:</asp:label></td>
					<td width="70%"><asp:textbox id="txtAuthor" Runat="server" Width="400"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblTitle" Runat="server">  <U>N</U>han đề:</asp:label></td>
					<td><asp:textbox id="txtTitle" Runat="server" Width="400"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblTimeAndLocation" Runat="server">Địa điểm và thời gian xuất bản:</asp:label></td>
					<td><asp:textbox id="txtTimeAndLocation" Runat="server" Width="400"></asp:textbox></td>
				</tr>
				<TR>
					<TD align="right">
						<asp:label id="lblSponsoringBody" Runat="server">Cơ quan ban hành:</asp:label></TD>
					<TD>
						<asp:textbox id="txtSponsoringBody" Runat="server" Width="400"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblReportNum" Runat="server">Báo cáo số:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtReportNum" Runat="server" Width="400"></asp:TextBox></TD>
				</TR>
				<tr>
					<td align="right"><asp:label id="lblFoundAtLib" Runat="server">Tìm thấy tại th<U>ư</U> viện:</asp:label></td>
					<td><asp:textbox id="txtFoundAt" Runat="server" Width="400"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblOtherInfor" Runat="server">Thông tin khá<U>c</U>:</asp:label></td>
					<td><asp:textbox id="txtOtherInfor" Runat="server" Width="400"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblExpireDate" Runat="server">Hạn cần mư<U>ợ</U>n:</asp:label></td>
					<td><asp:textbox id="txtExpireDate" Runat="server" Width="100"></asp:textbox>&nbsp;
						<asp:hyperlink id="lnkPubDate" runat="server" NavigateUrl="#">Lịch</asp:hyperlink></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblCardNum" Runat="server">Số th<U>ẻ</U>:</asp:label></td>
					<td><asp:textbox id="txtCardNum" Runat="server" Width="400"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblPassword" Runat="server"><U>M</U>ật khẩu:</asp:label></td>
					<td><asp:textbox id="txtPassword" Runat="server" Width="400" TextMode="Password"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblMaxCost" Runat="server"><U>P</U>hí tối đa:</asp:label></td>
					<td><asp:textbox id="txtMaxCost" Runat="server" Width="150"></asp:textbox></td>
				</tr>
				<tr>
					<td align="right"><asp:label id="lblCurrency" Runat="server"><U>Đ</U>ơn vị tiền tệ:</asp:label></td>
					<td>
						<asp:dropdownlist id="ddlCurrency" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td></td>
					<td><asp:button id="btnPostRequest" Runat="server" Text="Gửi yêu cầu(g)"></asp:button>&nbsp;
						<asp:button id="btnReset" Runat="server" Text="Đặt lại(r)"></asp:button>
						<INPUT type="hidden" id="hidReset" name="hidReset" runat="server" value="0">
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:label id="lblMsg1" Runat="server" Visible="False"> Nhan đề</asp:label>
						<asp:label id="lblMsg2" Runat="server" Visible="False">Số thẻ</asp:label>
						<asp:label id="lblMsg3" Runat="server" Visible="False">Mật khẩu</asp:label>
						<asp:Label id="lblMsgInvalidDate" Runat="server" Visible="False">Ngày tháng không hợp lệ</asp:Label>
						<asp:Label id="lblMsg4" Runat="server" Visible="False">Giá trị trường</asp:Label>
						<asp:Label id="lblMsg5" Runat="server" Visible="False">không hợp lệ</asp:Label>
						<asp:Label id="lblMsgInvalidNumber" runat="server" Visible="False">Không phải là số!</asp:Label><asp:Label id="lblMsgCreateSuccess" runat="server" Visible="False">Yêu cầu đã được gửi!</asp:Label>
						<asp:Label id="lblMsgCreateFail" runat="server" Visible="False">Lập yêu cầu có lỗi! Số thẻ hoặc mật khẩu không đúng!</asp:Label>
						<asp:Label id="lblDisOtherInfor" runat="server" Visible="False">Tìm thấy tại:</asp:Label>
						<asp:Label ID="lblOver" Runat="server" Visible="False">Bạn đã đặt mượn hết hạn ngạch cho phép.</asp:Label>
						<asp:Label ID="lblError" Runat="server" Visible="False">Lập yêu cầu không thành công.</asp:Label></td>
					</TD>
				</tr>
			</table>
		</form>
	</body>
</HTML>
