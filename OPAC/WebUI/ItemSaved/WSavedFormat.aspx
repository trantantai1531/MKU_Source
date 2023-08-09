<%@ Page Language="vb" AutoEventWireup="false" EnableViewStateMAC="False" EnableViewState="false" Codebehind="WSavedFormat.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.WSavedFormat"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSavedFormat</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="ChangeFontType();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="1" cellPadding="1" width="100%">
				<tr>
					<td width="100%" colSpan="2">
						<table width="100%">
							<tr>
								<td align="left" width="80%">
									<asp:hyperlink id="lnkRoot1" Runat="server" NavigateUrl="../WShowresult.aspx">Trang tìm kiếm</asp:hyperlink>
									<asp:Label ID="lbspace" Runat="server">></asp:Label>
									<asp:hyperlink id="lnkRoot2" Runat="server">Danh sách</asp:hyperlink>
								</td>
								<td align="right"><asp:button id="btnAction" Runat="server" Text="Chọn(c)"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="left" width="50%" class="lbGroupTitle"><asp:label id="lbDocFormat" cssclass="lbGroupTitle" Runat="server">Khuôn dạng dữ liệu</asp:label></td>
					<td class="lbGroupTitle"><asp:label id="lbDestination" Runat="server" cssclass="lbGroupTitle">Đích</asp:label></td>
				</tr>
				<tr>
					<!-- document formats ----------->
					<td vAlign="top">
						<table width="100%">
							<tr>
								<td><asp:radiobutton id="optISBD" Runat="server" Checked="True" GroupName="optDisplay" Text="<u>I</u>SBD"></asp:radiobutton><br>
									<asp:radiobutton id="optMARC" Runat="server" GroupName="optDisplay" Text="<u>M</u>ARC"></asp:radiobutton><br>
									<asp:radiobutton id="optXML" Runat="server" GroupName="optDisplay" Text="<u>X</u>ML (MARC 21)"></asp:radiobutton><br>
									<asp:radiobutton id="optDCXML" Runat="server" GroupName="optDisplay" Text="<u>X</u>ML (DCMI)"></asp:radiobutton><br>
									<asp:radiobutton id="optISO" Runat="server" GroupName="optDisplay" Text="IS<u>O</u> 2709"></asp:radiobutton></td>
							</tr>
							<tr>
								<td>
									<table id="tboptISO" width="100%">
										<tr>
											<td width="15"></td>
											<td><asp:radiobutton id="optISOUNIMARC" Runat="server" GroupName="optISODisplay" Text="<u>U</u>NIMARC"></asp:radiobutton><br>
												<asp:radiobutton id="optISOUSMARC" Runat="server" GroupName="optISODisplay" Text="U<u>S</u>MARC"
													Checked="True"></asp:radiobutton><br>
												<asp:radiobutton id="optISOTVQG" Runat="server" GroupName="optISODisplay" Text="CDS/ISIS (<u>T</u>VQG)"></asp:radiobutton><br>
												<asp:radiobutton id="optISONACESTID" Runat="server" GroupName="optISODisplay" Text="CDS/ISIS (<u>N</u>ACESTID)"></asp:radiobutton></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
					<!-- destination saved ----------->
					<td vAlign="top" align="left"><asp:radiobutton id="optDesEmail" Runat="server" GroupName="optDestination" Text="<u>E</u>mail"></asp:radiobutton>&nbsp;&nbsp;
						<asp:textbox id="txtEmail" Runat="server" Width="240px"></asp:textbox><br>
						<asp:radiobutton id="optDesFile" Runat="server" GroupName="optDestination" Text="<u>F</u>ile"></asp:radiobutton><br>
						<asp:radiobutton id="optDesScreen" Runat="server" GroupName="optDestination" Text="Màn <u>h</u>ình"
							Checked="True"></asp:radiobutton></td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat=server Width=0 Visible=False Height=0>
				<asp:ListItem Value=0>Trường Email còn rỗng !</asp:ListItem>
				<asp:ListItem Value=1>Khuông dạng Email không chính xác ! (ví dụ: infor@tinhvan.com).</asp:ListItem>
			</asp:DropDownList>
			<input id="arrlistsaved" type="hidden" name="arrlistsaved" runat="server">
			<script language="javascript">
				if(!document.forms[0].optISO.checked)
					ShowHideTable(tboptISO,0);
			</script>
		</form>
	</body>
</HTML>
