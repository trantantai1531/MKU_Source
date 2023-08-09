<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCatPatternFichAddField" validateRequest="false" CodeFile="WCatPatternFichAddField.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Emiclib - Phân hệ biên mục - Thêm trường vào khuôn dạng phích</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE CELLPADDING="1" CELLSPACING="0" BORDER="0" WIDTH="100%">
				<TR Class="lbPageTitle">
					<TD VALIGN="top" COLSPAN="5">
						<asp:Label ID="lblMainTitle" Runat="server" Width="100%" CssClass="lbPageTitle main-head-form">
							Thêm trường vào khuôn dạng phích</asp:Label></TD>
				
				</TR>
				<tr Class="lbSubformTitle">
					<TD VALIGN="top" COLSPAN="5">
						<asp:Label ID="lblSpecificField" Runat="server" Width="100%" CssClass="lbSubformTitle main-group-form">
							<b>Trường đặc biệt</b></asp:Label></TD>
				
				</tr>
				<TR>
					<TD VALIGN="top" ALIGN="right">
						<asp:Label ID="lblSpecTag" Runat="server">
							<b>Tên t<u>r</u>ường: </b>
						</asp:Label>
					</TD>
					<TD VALIGN="top" colspan="4">
						<asp:DropDownList ID="ddlSpceTag" Runat="server">
							<asp:ListItem VALUE="<$id$>" Selected="True">ID</asp:ListItem>
							<asp:ListItem VALUE="<$001$>">Mã tài liệu</asp:ListItem>
							<asp:ListItem VALUE="<$907$>">Ảnh bìa</asp:ListItem>
							<asp:ListItem VALUE="<$911$>">Người biên mục</asp:ListItem>
							<asp:ListItem VALUE="<$912$>">Người kiểm tra</asp:ListItem>
							<asp:ListItem VALUE="<$925$>">Vật mang tin</asp:ListItem>
							<asp:ListItem VALUE="<$926$>">Độ mật</asp:ListItem>
							<asp:ListItem VALUE="<$927$>">Dạng tài liệu</asp:ListItem>
						</asp:DropDownList>
					</TD>
				</TR>
				<TR >
					<TD>&nbsp;</TD>
					<TD VALIGN="top" colspan="4">
						<asp:Button ID="btnAddSpecTag" Runat="server" Text="Tạo trường(g)"></asp:Button>
					</TD>
				</TR>
				<tr Class="lbSubformTitle">
					<td VALIGN="top" COLSPAN="5">
						<asp:Label  ID="lblNormalTag" Runat="server" Width="100%" cssClass="lbSubformTitle  main-group-form">
							<b>Trường thường</b></asp:Label></td>
					
				</tr>
				<TR>
					<TD VALIGN="top" ALIGN="right">
						<asp:Label ID="lblTagName" Runat="server">
							<b><u>N</u>hãn trường: </b>
						</asp:Label>
					</TD>
					<TD VALIGN="top" colspan="4">
						<asp:TextBox ID="txtTagCode" Runat="server" Width="80"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD VALIGN="top" ALIGN="right">
						<asp:Label ID="lblPropertie" Runat="server" Width="100%">
							<b>Các thuộc tính: </b>
						</asp:Label>
					</TD>
					<TD VALIGN="top" colspan="4">
						<asp:CheckBox ID="ckbUpper" Runat="server" Text="I<u>n</u> hoa"></asp:CheckBox>
					</TD>
				</TR>
				<TR>
					<TD VALIGN="top" ALIGN="right">&nbsp;
						
					</TD>
					<TD VALIGN="top">
						<asp:CheckBox ID="ckbFixedVal" Runat="server" Text="<u>G</u>iá trị cố định"></asp:CheckBox>
					</TD>
					<TD COLSPAN="3">
						<asp:TextBox ID="txtFixedVal" Runat="server" Width="80"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD VALIGN="top" ALIGN="right">&nbsp;
						
					</TD>
					<TD VALIGN="top">
						<asp:CheckBox ID="ckbSerialFormat" Runat="server" Text="Đánh <U>s</U>ố thứ tự"></asp:CheckBox>
					</TD>
					<TD valign="top">
						<asp:DropDownList ID="ddlSerialFormat" Runat="server">
							<asp:ListItem value="A" Selected="True">A, B, C, D,...</asp:ListItem>
							<asp:ListItem value="a">a, b, c, d,...</asp:ListItem>
							<asp:ListItem value="I">I, II, III, IV,...</asp:ListItem>
							<asp:ListItem value="i">i, ii, iii, iv,...</asp:ListItem>
							<asp:ListItem value="1">1, 2, 3, 4,...</asp:ListItem>
						</asp:DropDownList>
					</TD>
					<TD VALIGN="top" colspan="2">
						<asp:RadioButton ID="rdbFromStart" Runat="server" Text="<U>T</U>ừ đầu" GroupName="SerialFormat" Checked="True"
							CssClass="lbRadio"></asp:RadioButton>&nbsp;&nbsp;
						<asp:RadioButton ID="rdbContinue" Runat="server" Text="<U>T</U>iếp tục" GroupName="SerialFormat"
							CssClass="lbRadio"></asp:RadioButton>
					</TD>
				</TR>
				<TR>
					<TD VALIGN="top" ALIGN="right"><asp:Label ID="lblParameters" Runat="server"><b>Các tham số:</b>
						</asp:Label>
					</TD>
					<TD VALIGN="top"><asp:Label ID="lblNormalSeparator" Runat="server"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<U>P</U>hân cách: </asp:Label>
					</TD>
					<TD>
						<asp:TextBox ID="txtNormalSeparator" Runat="server" Width="80"></asp:TextBox>
					</TD>
					<TD VALIGN="top"><asp:Label ID="lblReplacement" Runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tha<U>y</U> thế: </asp:Label>
					</TD>
					<TD VALIGN="top">
						<asp:TextBox ID="txtReplacement" Runat="server" Width="80"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD VALIGN="top" ALIGN="right">&nbsp;</TD>
					<TD VALIGN="top">
						<asp:Label ID="lblPrefix" Runat="server">	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ti<U>ề</U>n	tố:</asp:Label>
					<TD VALIGN="top">
						<asp:TextBox ID="txtPrefix" Runat="server" Width="80"></asp:TextBox>
					</TD>
					<TD VALIGN="top"><asp:Label ID="lblSuffix" Runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hậ<U>u</U> tố: </asp:Label>
					</TD>
					<TD>
						<asp:TextBox ID="txtSuffix" Runat="server" Width="80"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD VALIGN="top" ALIGN="right">&nbsp;</TD>
					<TD VALIGN="top"><asp:Label ID="lblCountFrom" Runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<U>L</U>ấy từ giá trị: </asp:Label>
					</TD>
					<TD>
						<asp:TextBox ID="txtCountFrom" Runat="server" Width="80"></asp:TextBox>
					</TD>
					<TD VALIGN="top"><asp:Label ID="lblCountTo" Runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<U>L</U>ấy tới giá trị:</asp:Label>
					<TD VALIGN="top">
						<asp:TextBox ID="txtCountTo" Runat="server" Width="80"></asp:TextBox>
					</TD>
				</TR>
				<TR >
					<TD colspan="1"></TD>
					<TD COLSPAN="4">
						<asp:Button ID="btnAddNormalTag" Runat="server" Text="Tạo trường (e)"></asp:Button>
					</TD>
				</TR>
				<tr Class="lbSubformTitle">
					<TD VALIGN="top" COLSPAN="5">
						<asp:Label ID="lblHolding" Runat="server" Width="100%" cssClass="lbSubformTitle main-group-form">
							<b>Xếp giá</b></asp:Label>
					</TD>
					
				</tr>
				<tr>
					<TD VALIGN="top" align="right">
						<asp:Label ID="lblHoldingType" Runat="server">
							<b><U>K</U>iểu hiển thị: </b>
						</asp:Label>
					</TD>
					
					<TD VALIGN="top">
						<asp:DropDownList ID="ddlHoldingType" Runat="server">
							<asp:ListItem Value="holding" Selected="True">Xếp giá</asp:ListItem>
							<asp:ListItem Value="holdingcomposite">Xếp giá tổng hợp</asp:ListItem>
						</asp:DropDownList></TD>
				</tr>
				<TR>
					<TD vAlign="top" align="right">
						<asp:Label ID="lblInicludeField" Runat="server">
							<b>In kèm: </b>
						</asp:Label>
					</TD>
					<TD valign="top">
						<asp:CheckBox ID="ckbIncludeFieldLib" Runat="server" Text="Tên thư <u>v</u>iện (viết tắt)"></asp:CheckBox>
					</TD>
					<TD valign="top">
						<asp:CheckBox ID="ckbIncludeFieldInv" Runat="server" Text="Tên kh<U>o</U>"></asp:CheckBox>
					</TD>
					<TD valign="top" colspan="2">
						<asp:CheckBox ID="ckbIncludeFieldShelf" Runat="server" Text="Tên gi<U>á</U>"></asp:CheckBox>
					</TD>
				</TR>
				<TR>
					<TD VALIGN="top" ALIGN="right">
						<asp:Label ID="lblInTag" Runat="server">
							<b>Các tham số: </b>
						</asp:Label>
					</TD>
					<TD VALIGN="top"><asp:Label ID="lblShelfSeparator" Runat="server"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<U>P</U>hân cách: </asp:Label>
					</TD>
					<TD>
						<asp:TextBox ID="txtShelfSeparator" Runat="server" Width="80"></asp:TextBox>
					</TD>
					<TD VALIGN="top"><asp:Label ID="lblShelfReplacement" Runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tha<U>y</U>	thế: </asp:Label>
					<TD VALIGN="top">
						<asp:TextBox ID="txtShelfReplacement" Runat="server" Width="80"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD VALIGN="top" ALIGN="right">&nbsp;</TD>
					<TD VALIGN="top">
						<asp:Label ID="lblShelfPrefix" Runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ti<u>ề</u>n tố: </asp:Label>
					<TD VALIGN="top">
						<asp:TextBox ID="txtShelfPrefix" Runat="server" Width="80"></asp:TextBox>
					</TD>
					<TD VALIGN="top">
						<asp:Label ID="lblShelfSuffix" Runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hậ<u>u</u> tố: </asp:Label>
					</TD>
					<TD>
						<asp:TextBox ID="txtShelfSuffix" Runat="server" Width="80"></asp:TextBox>
					</TD>
				</TR>
				<TR>
					<TD VALIGN="top" ALIGN="right">&nbsp;</TD>
					<TD VALIGN="top">
						<asp:Label ID="lblShelfFrom" Runat="server"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<U>L</U>ấy từ giá trị: </asp:Label>
					</TD>
					<TD>
						<asp:TextBox ID="txtShelfCountFrom" Runat="server" Width="80"></asp:TextBox>
					</TD>
					<TD VALIGN="top">
						<asp:Label ID="lblShelfTo" Runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<U>L</U>ấy tới giá trị: </asp:Label>
					<TD VALIGN="top">
						<asp:TextBox ID="txtShelfCountTo" Runat="server" Width="80"></asp:TextBox>
					</TD>
				</TR>
				<TR >
					<TD colspan="1"></TD>
					<TD COLSPAN="4">
						<asp:Button ID="btnAddShelfTag" Runat="server" Text="Tạo trường (n)"></asp:Button>
					</TD>
				</TR>
				<TR Class="lbPageTitle">
					<TD colspan="5" align="center">
						<asp:Button ID="btnClose" Runat="server" Text="Đóng (c)"></asp:Button>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script language = javascript>
			document.forms[0].txtTagCode.focus();
		</script>

	</body>
</HTML>
