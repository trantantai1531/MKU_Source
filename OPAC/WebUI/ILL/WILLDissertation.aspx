<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibOPAC.WebUI.OPAC.WILLDissertation" Codebehind="WILLDissertation.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WILLDissertation</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body topmargin="0" leftmargin="0" onload="ResetCtlValue();ChangeFontType();document.forms[0].txtAuthor.focus();">
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
								<td width="115" background="../Images/ImgViet/title_bg.gif" align="left" style="WIDTH: 118px"><asp:label id="lblTitleIllDissertation" CssClass="lbTitleHeader" Runat="server">ILL</asp:label></td>
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
					<td colspan="2">
						<asp:Label Runat="server" ID="lblMainTitle" CssClass="lbPageTitle" Width="100%">Yêu cầu mượn Luận án/Luận văn</asp:Label>
					</td>
				</tr>
				<tr>
					<td align="right" width="20%">
						<asp:Label Runat="server" ID="lblAuthor"><U>T</U>ác giả:</asp:Label>
					</td>
					<td width="80%">
						<asp:TextBox Width="400" Runat="server" id="txtAuthor"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:Label Runat="server" ID="lblTitle"><U>N</U>han đề:</asp:Label>
					</td>
					<td>
						<asp:TextBox Width="400" Runat="server" id="txtTitle"></asp:TextBox>
					</td>
				</tr>
				<TR>
					<TD align="right">
						<asp:Label id="lblSponsoringBody" Runat="server">Cơ quan bảo vệ:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtSponsoringBody" Runat="server" Width="400"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblVerification" Runat="server">Cấp luận án:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtVerification" Runat="server" Width="400"></asp:TextBox></TD>
				</TR>
				<tr>
					<td align="right">
						<asp:Label Runat="server" ID="lblPubDate">Thời gian bảo vệ:</asp:Label>
					</td>
					<td>
						<asp:TextBox Width="400" Runat="server" id="txtPubDate"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:Label Runat="server" ID="lblFoundAtLib">Tìm thấy tại th<U>ư</U> viện:</asp:Label>
					</td>
					<td>
						<asp:TextBox Width="400" Runat="server" id="txtFoundAt"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:Label Runat="server" ID="lblOtherInfor">Thông tin khá<U>c</U>:</asp:Label>
					</td>
					<td>
						<asp:TextBox Width="400" Runat="server" id="txtOtherInfor"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:Label Runat="server" ID="lblExpireDate">Hạn cần mư<U>ợ</U>n:</asp:Label>
					</td>
					<td>
						<asp:TextBox Width="100" Runat="server" id="txtExpireDate"></asp:TextBox>&nbsp;
						<asp:hyperlink id="lnkCal" runat="server" NavigateUrl="#">Lịch</asp:hyperlink>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:Label Runat="server" ID="lblCardNum">Số th<U>ẻ</U>:</asp:Label>
					</td>
					<td>
						<asp:TextBox Width="400" Runat="server" id="txtCardNum"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:Label Runat="server" ID="lblPassword"><U>M</U>ật khẩu:</asp:Label>
					</td>
					<td>
						<asp:TextBox Width="400" Runat="server" id="txtPassword" TextMode="Password"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:Label Runat="server" ID="lblMaxCost"><U>P</U>hí tối đa:</asp:Label>
					</td>
					<td>
						<asp:TextBox Width="150" Runat="server" id="txtMaxCost"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td align="right">
						<asp:Label Runat="server" ID="lblCurrency"><U>Đ</U>ơn vị tiền tệ:</asp:Label>
					</td>
					<td>
						<asp:dropdownlist id="ddlCurrency" runat="server"></asp:dropdownlist>
					</td>
				</tr>
				<tr>
					<td>
					</td>
					<td>
						<asp:Button Runat="server" ID="btnPostRequest" Text="Gửi yêu cầu(g)"></asp:Button>&nbsp;
						<asp:Button Runat="server" ID="btnReset" Text="Đặt lại(r)"></asp:Button>
						<INPUT type="hidden" id="hidReset" name="hidReset" runat="server" value="0">
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:Label id="lblMsg1" Runat="server" Visible="False">Nhan đề</asp:Label>
						<asp:Label id="lblMsg2" Runat="server" Visible="False">Số thẻ</asp:Label>
						<asp:Label id="lblMsg3" Runat="server" Visible="False">Mật khẩu</asp:Label>
						<asp:Label id="lblMsg4" Runat="server" Visible="False">Giá trị trường</asp:Label>
						<asp:Label id="lblMsg5" Runat="server" Visible="False">không hợp lệ</asp:Label>
						<asp:Label id="lblMsgInvalidDate" Runat="server" Visible="False">Ngày tháng không hợp lệ</asp:Label>
						<asp:Label id="lblMsgInvalidNumber" runat="server" Visible="False">Không phải là số!</asp:Label><asp:Label id="lblMsgCreateSuccess" runat="server" Visible="False">Yêu cầu đã được gửi!</asp:Label>
						<asp:Label id="lblMsgCreateFail" runat="server" Visible="False">Lập yêu cầu có lỗi! Số thẻ hoặc mật khẩu không đúng!</asp:Label>
						<asp:Label id="lblDisOtherInfor" runat="server" Visible="False">Tìm thấy tại:</asp:Label>
						<asp:Label ID="lblOver" Runat="server" Visible="False">Bạn đã đặt mượn hết hạn ngạch cho phép.</asp:Label>
						<asp:Label ID="lblError" Runat="server" Visible="False">Lập yêu cầu không thành công.</asp:Label>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
