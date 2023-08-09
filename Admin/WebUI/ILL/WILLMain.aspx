<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WILLMain" CodeFile="WILLMain.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>WILLMain</TITLE>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" runat="server">
			<TABLE width="100%" cellpadding="4" cellspacing="1" bgcolor="#f3f3f3">
				<TR class="lbGroupTitle">
					<TD width="33%" colSpan="2">
						<asp:label id="lblCapBib" runat="server" CssClass="lbGroupTitle">Thư viện đối tác</asp:label></TD>
					<TD width="33%" colSpan="2">
						<asp:label id="lblCapTranfer" runat="server" CssClass="lbGroupTitle">Yêu cầu đi</asp:label></TD>
					<TD width="34%" colSpan="2">
						<asp:label id="lblCapTemplate" runat="server" CssClass="lbGroupTitle">Yêu cầu đến</asp:label></TD>
				</TR>
				<TR class="lbFunctionTR">
					<TD align="center" colSpan="1" height="50" rowSpan="1" vAlign="middle">
						<asp:hyperlink id="imgCreateNewLib" runat="server" NavigateUrl="javascript:parent.Workform.location.href='WLibMan.aspx';parent.Sentform.location.href='Nothing.htm';">
							<img border="0" src="images/nhap_moi.gif">
						</asp:hyperlink></TD>
					<TD height="50">
						<asp:hyperlink id="lnkCreateNewLib" runat="server" NavigateUrl="javascript:parent.Workform.location.href='WLibMan.aspx';parent.Sentform.location.href='Nothing.htm';"> Nhập mới</asp:hyperlink><BR>
						<asp:label id="lblCreateNewLib" runat="server" CssClass="lbFunctionDetail"> Quản lý cơ sở dữ liệu các thư viện đối tác có quan hệ mượn/trả liên thư viện.</asp:label>
					</TD>
					<TD align="center" height="50">
						<asp:hyperlink id="imgCreateReq" runat="server" NavigateUrl="javascript:parent.Sentform.location.href='ORMan/WORCreateTaskBar.aspx';">
							<img border="0" src="images/tao_yeu_cau.gif">
						</asp:hyperlink></TD>
					<TD height="50">
						<asp:hyperlink id="lnkCreateReq" runat="server" NavigateUrl="javascript:parent.Sentform.location.href='ORMan/WORCreateTaskBar.aspx';">Tạo yêu cầu</asp:hyperlink><BR>
						<asp:label id="lblCreateReq" runat="server" CssClass="lbFunctionDetail">Tạo yêu cầu mượn liên thư viện.</asp:label>
					</TD>
					<TD align="center" height="50">
						<asp:hyperlink id="imgBibTemplate" runat="server" NavigateUrl="javascript:parent.Sentform.location.href='WRequestTaskBar.aspx?ReqType=1';"
							Target="Sentform">
							<img border="0" src="images/xu_ly_yeu_cau_02.gif">
						</asp:hyperlink></TD>
					<TD align="left" colSpan="1" height="50" rowSpan="1">
						<asp:hyperlink id="lnkInProcess" runat="server" NavigateUrl="javascript:parent.Sentform.location.href='WRequestTaskBar.aspx?ReqType=1';">Xử lý yêu cầu</asp:hyperlink><BR>
						<asp:label id="lblInProcess" runat="server" CssClass="lbFunctionDetail">Các thao tác xử lý một yêu cầu mượn liên thư viện gửi đến.</asp:label>
					</TD>
				</TR>
				<TR class="lbFunctionTR">
					<TD vAlign="middle" align="center" height="50"></TD>
					<TD height="50"></TD>
					<TD align="center" height="50">
						<asp:hyperlink id="imgOutProcessReg" runat="server" NavigateUrl="javascript:parent.Sentform.location.href='WRequestTaskBar.aspx?ReqType=2';"
							Target="Sentform">
							<img border="0" src="images/xu_ly_yeu_cau_01.gif">
						</asp:hyperlink></TD>
					<TD height="50">
						<asp:hyperlink id="lnkOutProcessReg" runat="server" NavigateUrl="javascript:parent.Sentform.location.href='WRequestTaskBar.aspx?ReqType=2';"
							Target="Sentform">Xử lý yêu cầu</asp:hyperlink><BR>
						<asp:label id="lblOutProcessReg" runat="server" CssClass="lbFunctionDetail">Các thao tác xử lý một yêu cầu mượn liên thư viện gửi đi.</asp:label></TD>
					<TD align="center" height="50"></TD>
					<TD align="left" height="50"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
