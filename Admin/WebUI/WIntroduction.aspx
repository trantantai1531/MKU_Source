<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.WIntroduction" CodeFile="WIntroduction.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIntroduction</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<BODY TOPMARGIN="0" LEFTMARGIN="0" bgcolor="#999999">
		<form id="Form1" method="post" runat="server">
			<CENTER>
				&nbsp;<p>
					<TABLE WIDTH="727" BORDER="0" CELLPADDING="0" CELLSPACING="0">
						<TR>
							<TD COLSPAN="3">
								<A HREF="Acquisition/WACQIndex.aspx"></A>
							</TD>
							<TD>
								<IMG SRC="images/topmodules_02.gif" WIDTH="33" HEIGHT="135"></TD>
							<TD COLSPAN="2" ROWSPAN="2">
								<A HREF="../OPAC/WIndex.aspx" target="new"><IMG SRC="images/topmodules_03.jpg" WIDTH="148" HEIGHT="186" BORDER="0" runat="server"
										id="imgOPAC"></A></TD>
							<TD COLSPAN="2" ROWSPAN="2">
								<A HREF="Patron/WIndex.aspx"><IMG SRC="images/topmodules_04.jpg" WIDTH="145" HEIGHT="186" BORDER="0" runat="server"
										id="imgPatron"></A></TD>
							<TD>
								<IMG SRC="images/topmodules_05.gif" WIDTH="27" HEIGHT="135"></TD>
							<TD COLSPAN="3">
								<A HREF="Edeliv/WMainIndex.aspx"></A>
							</TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="1" HEIGHT="135"></TD>
						</TR>
						<TR>
							<TD ROWSPAN="4">
								<IMG SRC="images/topmodules_07.gif" WIDTH="28" HEIGHT="275"></TD>
							<TD COLSPAN="3" ROWSPAN="3"><A href="Acquisition/WACQIndex.aspx"><IMG SRC="images/topmodules_01.jpg" WIDTH="185" HEIGHT="135" BORDER="0" runat="server"
										id="imgAcq"></A> <A HREF="ILL/WILLMainIndex.aspx"></A>
							</TD>
							<TD COLSPAN="3" ROWSPAN="3">
								<A HREF="Serial/WMainIndex.aspx"><IMG SRC="images/topmodules_09.jpg" WIDTH="190" HEIGHT="136" BORDER="0" runat="server"
										id="imgSerial"></A></TD>
							<TD ROWSPAN="4">
								<IMG SRC="images/topmodules_10.gif" WIDTH="26" HEIGHT="275"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="1" HEIGHT="51"></TD>
						</TR>
						<TR>
							<TD COLSPAN="4">
								<IMG SRC="images/topmodules_11.gif" WIDTH="293" HEIGHT="39"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="1" HEIGHT="39"></TD>
						</TR>
						<TR>
							<TD>
								<IMG SRC="images/topmodules_12.gif" WIDTH="78" HEIGHT="46"></TD>
							<TD COLSPAN="2" ROWSPAN="2">
								<A HREF="Admin/WMainIndex.aspx"><IMG SRC="images/topmodules_13.jpg" WIDTH="143" HEIGHT="185" BORDER="0" runat="server"
										id="imgAdmin"></A></TD>
							<TD>
								<IMG SRC="images/topmodules_14.gif" WIDTH="72" HEIGHT="46"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="1" HEIGHT="46"></TD>
						</TR>
						<TR>
							<TD>
								<IMG SRC="images/topmodules_15.gif" WIDTH="80" HEIGHT="139"></TD>
							<TD COLSPAN="3">
								<A HREF="Circulation/WIndex.aspx"><IMG SRC="images/topmodules_16.jpg" WIDTH="188" HEIGHT="139" BORDER="0" runat="server"
										id="imgCirculation"></A></TD>
							<TD COLSPAN="3">
								<A HREF="Catalogue/WMainFrame.aspx"><IMG SRC="images/topmodules_17.jpg" WIDTH="189" HEIGHT="139" BORDER="0" runat="server"
										id="imgCatalogue"></A></TD>
							<TD>
								<IMG SRC="images/topmodules_18.gif" WIDTH="73" HEIGHT="139"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="1" HEIGHT="139"></TD>
						</TR>
						<TR>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="28" HEIGHT="1"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="80" HEIGHT="1"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="77" HEIGHT="1"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="33" HEIGHT="1"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="78" HEIGHT="1"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="70" HEIGHT="1"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="73" HEIGHT="1"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="72" HEIGHT="1"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="27" HEIGHT="1"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="90" HEIGHT="1"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="73" HEIGHT="1"></TD>
							<TD>
								<IMG SRC="images/spacer.gif" WIDTH="26" HEIGHT="1"></TD>
							<TD></TD>
						</TR>
					</TABLE>
			</CENTER>
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Phân hệ Bổ sung</asp:ListItem>
				<asp:ListItem Value="1">Phân hệ Biên mục</asp:ListItem>
				<asp:ListItem Value="2">Phân hệ Mượn trả</asp:ListItem>
				<asp:ListItem Value="3">Phân hệ Sưu tập số</asp:ListItem>
				<asp:ListItem Value="4">Phân hệ Ấn phẩm định kỳ</asp:ListItem>
				<asp:ListItem Value="5">Phân hệ OPAC</asp:ListItem>
				<asp:ListItem Value="6">Phân hệ Ill</asp:ListItem>
				<asp:ListItem Value="7">Phân hệ Quản lý</asp:ListItem>
				<asp:ListItem Value="8">Phân hệ Bạn đọc</asp:ListItem>
			</asp:DropDownList>
		</form>
		</P>
	</BODY>
</HTML>
