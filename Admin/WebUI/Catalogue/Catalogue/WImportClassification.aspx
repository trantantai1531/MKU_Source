<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WImportClassification" CodeFile="WImportClassification.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 TRansitional//EN">
<HTML>
	<HEAD>
		<title>WImport</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tblMain" width="100%" border="0" cellpadding="2" cellspacing="0">
				<TR class="lbPageTitle">
					<TD colSpan="2">
						<asp:label id="lblTitle" runat="server" cssclass="lbPageTitle">Nhập bản ghi dữ liệu phân loại từ tệp (ISO 2709)</asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="40%">
						<asp:label id="lblFileName" runat="server"><u>T</u>ên tệp:</asp:label></TD>
					<TD align="left">
						<INPUT id="filAttach" type="file" size="23" name="filAttach" runat="server" class="lbTextBox"></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblFrom" runat="server">Từ biểu <u>g</u>hi:</asp:label></TD>
					<TD align="left">
						<asp:textbox id="txtLRange" runat="server" Width="168px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblTo" runat="server">Tới biểu gh<u>i</u>:</asp:label></TD>
					<TD align="left">
						<asp:textbox id="txtRRange" runat="server" Width="168px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblCodeTable" runat="server"><u>B</u>ảng mã chữ Việt của tệp nguồn:</asp:label></TD>
					<TD align="left">
						<asp:dropdownlist id="ddlEncode" runat="server" Width="80px">
							<asp:ListItem></asp:ListItem>
							<asp:ListItem Value="TCVN">TCVN</asp:ListItem>
							<asp:ListItem Value="VNI">VNI</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblPattern" runat="server">Kh<u>u</u>ôn dạng:</asp:label></TD>
					<TD align="left">
						<asp:dropdownlist id="ddlPattern" runat="server" Width="136px">
							<asp:ListItem Value="1">MARC 21 (raw)</asp:ListItem>
							<asp:ListItem Value="2">Tagget</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<tr>
					<td></td>
					<td>
						<asp:label runat="server" id="lblSubField">Chỉ định <u>n</u>hãn trường con:</asp:label>&nbsp;
						<asp:textbox runat="server" id="txtSubField" Width="32px">$</asp:textbox>&nbsp;
						<asp:label runat="server" id="lblFieldTer">Kết thúc tr<u>ư</u>ờng:</asp:label>&nbsp;
						<asp:textbox runat="server" id="txtFieldTer" Width="32px">#</asp:textbox>&nbsp;
						<asp:label runat="server" id="lblRecTer">Kết thúc bản <u>g</u>hi:</asp:label>&nbsp;
						<asp:textbox runat="server" id="txtRecTer" Width="32px">#</asp:textbox>
					</td>
				</tr>
				<TR class="lbControlBar">
					<TD></TD>
					<TD align="left">
						<asp:button id="btnImport" runat="server" Width="80px" Text="Nhập(p)"></asp:button></TD>
				</TR>
				<tr>
					<td colSpan="2">&nbsp;
					</td>
				</tr>
				<tr>
					<td colSpan="2">&nbsp;
					</td>
				</tr>
				<tr>
					<td colSpan="2">&nbsp;
						<asp:dropdownlist id="ddlLabel" Width="0" Height="0" Visible="False" Runat="server">
							<asp:ListItem Value="0">Biểu ghi nhập vào phải là dữ liệu kiểu số! </asp:ListItem>
							<asp:ListItem Value="1">Sai kiểu dữ liệu (số)!</asp:ListItem>
							<asp:ListItem Value="2">Biểu ghi đầu phải nhỏ hơn hoặc bằng biểu ghi cuối!</asp:ListItem>
							<asp:ListItem Value="3">Biểu ghi nhập vào nằm ngoài khoảng giới hạn số biểu ghi trong tệp nhập khẩu!</asp:ListItem>
							<asp:ListItem Value="4">Bạn phải nhập vào đường dẫn của tệp trước khi nhập khẩu!</asp:ListItem>
							<asp:ListItem Value="5">Nội dung tệp rỗng hoặc sai cấu trúc!</asp:ListItem>
							<asp:ListItem Value="6">Nhập khẩu dữ liệu: </asp:ListItem>
							<asp:ListItem Value="7">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="8">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="9">Nhập bản ghi dữ liệu phân loại từ tệp (ISO 2709)</asp:ListItem>
							<asp:ListItem Value="10">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
							<asp:ListItem Value="11">do đã tồn tại những chỉ số như thế trong database.</asp:ListItem>
							<asp:ListItem Value="12">do lỗi khi thực hiện</asp:ListItem>
							<asp:ListItem Value="13">Tệp không đúng cấu trúc!</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<TR>
					<TD align="center" colSpan="2"><br>
						<asp:label id="lblSuccess" runat="server" Visible="False">Nhập khẩu thành công!</asp:label>
						<asp:label id="lblFail" runat="server" Visible="False">Nhập khẩu thất bại!</asp:label>
						<asp:label id="lblTotal" runat="server" Visible="False"> Tổng số bản ghi đã nhập khẩu:</asp:label>
						<asp:label id="lblCount" runat="server" cssClass="lbAmount" Visible="False"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
		<script language = javascript>
			document.forms[0].filAttach.focus();
		</script>
	</body>
</HTML>
