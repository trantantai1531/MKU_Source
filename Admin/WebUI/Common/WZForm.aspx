<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Common.WZForm" CodeFile="WZForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Emiclib - Z39.50 Gateway</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD align="left" colSpan="3">
					     <h1 class="main-group-form"><asp:label id="lblMainTitle" cssclass="lbGroupTitle" runat="server" Width="100%">Emiclib - Z39.50 Gateway</asp:label></h1>
						
					</TD>
				</TR>
				<TR>
					<TD align="right" colSpan="2">
						<asp:label id="lblzServer" runat="server"><u>T</u>ên máy chủ Z39.50:</asp:label></TD>
					<TD><asp:textbox id="txtzServer" runat="server" Width="211px"></asp:textbox>&nbsp;
						<asp:hyperlink id="lnkZServerList" runat="server">Danh sách</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="2"><asp:label id="lblZPort" runat="server"><u>C</u>ổng dịch vụ:</asp:label></TD>
					<TD><asp:textbox id="txtZPort" runat="server" Width="77px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="2"><asp:label id="lblZDatabase" runat="server">Tên cơ sở <u>d</u>ữ liệu:</asp:label></TD>
					<TD><asp:textbox id="txtZDatabase" runat="server" Width="181px"></asp:textbox></TD>
				</TR>
				<TR class="lbPageTitle">
					<TD align="left" colSpan="3">
					      <h1 class="main-group-form"> <asp:label cssclass="lbGroupTitle" id="lblSubTitle" runat="server">Điều kiện tìm kiếm</asp:label></h1>
                       
					</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:DropDownList id="ddlFieldName1" runat="server" Width="125px" Height="24px">
							<asp:ListItem Value="@attr 1=1016" Selected="True">Mọi trường</asp:ListItem>
							<asp:ListItem Value="@attr 1=1">T&#225;c giả</asp:ListItem>
							<asp:ListItem Value="@attr 1=2">T&#225;c giả tập thể</asp:ListItem>
							<asp:ListItem Value="@attr 1=4">Nhan đề</asp:ListItem>
							<asp:ListItem Value="@attr 1=5">Nhan đề t&#249;ng thư</asp:ListItem>
							<asp:ListItem Value="@attr 1=7">ISBN</asp:ListItem>
							<asp:ListItem Value="@attr 1=8">ISSN</asp:ListItem>
							<asp:ListItem Value="@attr 1=13">Chỉ số DDC</asp:ListItem>
							<asp:ListItem Value="@attr 1=14">Chỉ số UDC</asp:ListItem>
							<asp:ListItem Value="@attr 1=16">Chỉ số LC</asp:ListItem>
							<asp:ListItem Value="@attr 1=21">Chủ đề</asp:ListItem>
							<asp:ListItem Value="@attr 1=29">Từ kho&#225;</asp:ListItem>
							<asp:ListItem Value="@attr 1=31">Năm xuất bản</asp:ListItem>
							<asp:ListItem Value="@attr 1=30">Nh&#224; xuất bản</asp:ListItem>
						</asp:DropDownList>
					</TD>
					<TD><asp:textbox id="txtFieldValue1" runat="server" Width="249px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:DropDownList id="ddlOperator2" runat="server" Width="86px" Height="24px">
							<asp:ListItem Value="@and">AND</asp:ListItem>
							<asp:ListItem Value="@or">OR</asp:ListItem>
							<asp:ListItem Value="@not">NOT</asp:ListItem>
						</asp:DropDownList>
					</TD>
					<TD>
						<asp:DropDownList id="ddlFieldName2" runat="server" Width="125px" Height="24px">
							<asp:ListItem Value="@attr 1=1016" Selected="True">Mọi trường</asp:ListItem>
							<asp:ListItem Value="@attr 1=1">T&#225;c giả</asp:ListItem>
							<asp:ListItem Value="@attr 1=2">T&#225;c giả tập thể</asp:ListItem>
							<asp:ListItem Value="@attr 1=4">Nhan đề</asp:ListItem>
							<asp:ListItem Value="@attr 1=5">Nhan đề t&#249;ng thư</asp:ListItem>
							<asp:ListItem Value="@attr 1=7">ISBN</asp:ListItem>
							<asp:ListItem Value="@attr 1=8">ISSN</asp:ListItem>
							<asp:ListItem Value="@attr 1=13">Chỉ số DDC</asp:ListItem>
							<asp:ListItem Value="@attr 1=14">Chỉ số UDC</asp:ListItem>
							<asp:ListItem Value="@attr 1=16">Chỉ số LC</asp:ListItem>
							<asp:ListItem Value="@attr 1=21">Chủ đề</asp:ListItem>
							<asp:ListItem Value="@attr 1=29">Từ kho&#225;</asp:ListItem>
							<asp:ListItem Value="@attr 1=31">Năm xuất bản</asp:ListItem>
							<asp:ListItem Value="@attr 1=30">Nh&#224; xuất bản</asp:ListItem>
						</asp:DropDownList>
					</TD>
					<TD><asp:textbox id="txtFieldValue2" runat="server" Width="249px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="1" rowSpan="1" style="HEIGHT: 19px">
						<asp:DropDownList id="ddlOperator3" runat="server" Width="86px" Height="24px">
							<asp:ListItem Value="@and">AND</asp:ListItem>
							<asp:ListItem Value="@or">OR</asp:ListItem>
							<asp:ListItem Value="@not">NOT</asp:ListItem>
						</asp:DropDownList>
					</TD>
					<TD style="HEIGHT: 19px">
						<asp:DropDownList id="ddlFieldName3" runat="server" Width="125px" Height="24px">
							<asp:ListItem Value="@attr 1=1016" Selected="True">Mọi trường</asp:ListItem>
							<asp:ListItem Value="@attr 1=1">T&#225;c giả</asp:ListItem>
							<asp:ListItem Value="@attr 1=2">T&#225;c giả tập thể</asp:ListItem>
							<asp:ListItem Value="@attr 1=4">Nhan đề</asp:ListItem>
							<asp:ListItem Value="@attr 1=5">Nhan đề t&#249;ng thư</asp:ListItem>
							<asp:ListItem Value="@attr 1=7">ISBN</asp:ListItem>
							<asp:ListItem Value="@attr 1=8">ISSN</asp:ListItem>
							<asp:ListItem Value="@attr 1=13">Chỉ số DDC</asp:ListItem>
							<asp:ListItem Value="@attr 1=14">Chỉ số UDC</asp:ListItem>
							<asp:ListItem Value="@attr 1=16">Chỉ số LC</asp:ListItem>
							<asp:ListItem Value="@attr 1=21">Chủ đề</asp:ListItem>
							<asp:ListItem Value="@attr 1=29">Từ kho&#225;</asp:ListItem>
							<asp:ListItem Value="@attr 1=31">Năm xuất bản</asp:ListItem>
							<asp:ListItem Value="@attr 1=30">Nh&#224; xuất bản</asp:ListItem>
						</asp:DropDownList>
					</TD>
					<TD style="HEIGHT: 19px"><asp:textbox id="txtFieldValue3" runat="server" Width="249px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="2"><asp:label id="lblDisplay" runat="server">Hiển thị:</asp:label></TD>
					<TD><asp:radiobutton id="optMARC" runat="server" Text="<u>M</u>ARC" GroupName="optDisplay"></asp:radiobutton>&nbsp;
						<asp:radiobutton id="optISBD" runat="server" Text="<u>I</u>SBD" Checked="True" GroupName="optDisplay"></asp:radiobutton>&nbsp;
						<asp:radiobutton id="optSimple" runat="server" Text="Đơn <u>g</u>iản " GroupName="optDisplay"></asp:radiobutton>&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
					<TD><asp:button id="btnSearch" runat="server" Text="Tìm kiếm(s)" Width="88px"></asp:button>&nbsp;
						<asp:button id="btnReset" runat="server" Text="Làm lại(r)" Width="88px"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
					<TD>
						<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
							<asp:ListItem Value="0">Nhan đề</asp:ListItem>
							<asp:ListItem Value="0">Nhan đề tùng thư</asp:ListItem>
							<asp:ListItem Value="0">Tác giả</asp:ListItem>
							<asp:ListItem Value="0">Tác giả tập thể</asp:ListItem>
							<asp:ListItem Value="0">Chủ đề</asp:ListItem>
							<asp:ListItem Value="0">ISBN</asp:ListItem>
							<asp:ListItem Value="0">ISBN</asp:ListItem>
							<asp:ListItem Value="0">Mọi trường</asp:ListItem>
						</asp:DropDownList>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabelZ" Runat="server" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Trường tìm kiếm còn rỗng !</asp:ListItem>
				<asp:ListItem Value="1">Cổng dịch vụ phải là số !</asp:ListItem>
				<asp:ListItem Value="2">Bạn chưa nhập tên máy chủ !</asp:ListItem>
				<asp:ListItem Value="3">Bạn chưa nhập cổng dịch vụ !</asp:ListItem>
				<asp:ListItem Value="4">Bạn chưa nhập tên cơ sở dữ liệu !</asp:ListItem>
			</asp:DropDownList>
			<script language="javascript">
				document.forms[0].txtzServer.focus();
			</script>
		</form>
	</body>
</HTML>
