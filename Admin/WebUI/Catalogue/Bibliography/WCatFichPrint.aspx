<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCatPichPrint" CodeFile="WCatFichPrint.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCatPichPrint</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
      
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="3" width="100%" align="center" border="0">
				<TR Class="lbPageTitle">
					<TD colspan="2">
						<asp:label id="lblMainTitle" CssClass="lbPageTitle" Runat="server" Font-Bold="True">In phích</asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:label id="lblLimit" Runat="server">Giới hạn</asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblMFN" Runat="server">MFN: </asp:label></TD>
					<TD>
						<TABLE cellSpacing="2" cellPadding="0">
							<TR>
								<TD vAlign="top">
									<asp:label id="lblFrom" Runat="server">
										<i><u>T</u>ừ</i>
									</asp:label><br>
									<asp:textbox id="txtFrom" Runat="server" Width="60"></asp:textbox></TD>
								<TD vAlign="top"><asp:label id="lblTo" Runat="server">
										<i>Tớ<u>i</u></i>
									</asp:label><br>
									<asp:textbox id="txtTo" Runat="server" Width="60"></asp:textbox></TD>
								<TD vAlign="bottom"><asp:checkbox id="ckbNewItemOnly" Runat="server" Text="Chỉ in các bản ghi <u>m</u>ới"></asp:checkbox><br>
									<asp:checkbox id="ckbMultipleFiche" Runat="server" Text="In phích cho từng <u>k</u>ho"></asp:checkbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblCopyNumber" Runat="server">
							Đăng ký cá biệt: 
						</asp:label></TD>
					<TD>
						<TABLE cellSpacing="2" cellPadding="0">
							<TR>
								<TD vAlign="top"><asp:label id="lblFromCopyNumber" Runat="server" Font-Italic="True"><u>T</u>ừ:</asp:label><br>
									<asp:textbox id="txtFromCopyNumber" Runat="server" Width="60"></asp:textbox></TD>
								<TD vAlign="top">
									<asp:label id="lblToCopyNumber" Runat="server" Font-Italic="True">Tớ<u>i</u></asp:label><br>
									<asp:textbox id="txtToCopyNumber" Runat="server" Width="60"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblItemCode" Runat="server"><u>D</u>ạng tài liệu: </asp:label></TD>
					<TD>
						<asp:dropdownlist id="ddlItemType" Runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right">
						<asp:label id="lblLocate" Runat="server">Vị trí kho: </asp:label></TD>
					<TD vAlign="top">
						<TABLE cellSpacing="0" cellPadding="1" border="0">
							<TR>
								<TD vAlign="top">
									<asp:label id="lblLibrary" Runat="server" Font-Italic="True">Thư <u>v</u>iện:</asp:label><BR>
									<asp:dropdownlist id="ddlLibrary" Runat="server"></asp:dropdownlist></TD>
								<TD vAlign="top">
									<NOBR><asp:label id="lblLocation" Runat="server" Font-Italic="True">Kh<u>o</u>:</asp:label></NOBR><br>
									<asp:dropdownlist id="ddlLocation" Runat="server"></asp:dropdownlist>
									<input id="txtLocation" type="hidden" name="txtLocation" runat="server">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:label id="lblFormal" Runat="server">Hình thức</asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblFiche" Runat="server"><u>S</u>ố phích: </asp:label></TD>
					<TD>
						<asp:textbox id="txtFiche" Runat="server" Width="40">10</asp:textbox>&nbsp;&nbsp;&nbsp;
						<asp:label id="lblCollum" Runat="server">Số cộ<u>t</u>: </asp:label>
						<asp:textbox id="txtCollum" Runat="server" Width="40">1</asp:textbox>&nbsp;&nbsp;&nbsp;
						<asp:label id="lblSpace" Runat="server">Khoản<u>g</u> cách giữa các phích: </asp:label>
						<asp:textbox id="txtSpace" Runat="server" Width="40">0</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblFicheTemplate" Runat="server">Mẫu <u>p</u>hích: </asp:label></TD>
					<TD>
						<asp:dropdownlist id="ddlFicheTemplate" Runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right">
						<asp:label id="lblSortBy" Runat="server">Sắp <u>x</u>ếp theo: </asp:label></TD>
					<TD>
						<asp:textbox id="txtSortBy" Runat="server" Width="60"></asp:textbox>&nbsp;&nbsp;&nbsp;
						<asp:label id="lblExportWordFile" Runat="server">Xuất ra file <u>w</u>ord: </asp:label>
						<asp:checkbox id="ckbExportWordFile" Runat="server"></asp:checkbox></TD>
				</TR>
				<TR class="lbControlBar">
					<TD></TD>
					<TD>
						<asp:button id="btnMakeFiche" Runat="server" Text="In phích(p)" Width="88px"></asp:button>
						<asp:button id="btnReset" Runat="server" Text="Đặt lại(r)" Width="80px"></asp:button></TD>
				</TR>
				<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
					<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
					<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
					<asp:ListItem Value="2">------- Chọn -------</asp:ListItem>
					<asp:ListItem Value="3">Bạn phải chọn kho để in phích!</asp:ListItem>
					<asp:ListItem Value="4">Không tồn tại dữ liệu </asp:ListItem>
				</asp:DropDownList>
			</TABLE>
		</form>
	</body>
</HTML>
