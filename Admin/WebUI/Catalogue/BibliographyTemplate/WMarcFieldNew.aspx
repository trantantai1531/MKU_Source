<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFieldNew" CodeFile="WMarcFieldNew.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WMarcFieldNew</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="3" width="100%" border="0">
				<tr>
					<td class="lbPageTitle" align="center" colSpan="2"><asp:label id="lblTitle" runat="server" CssClass="lbPageTitle">Thêm trường biên mục</asp:label></td>
				</tr>
				<TR>
					<TD align="right" width="40%"><asp:label id="lblFieldCode" runat="server" CssClass="lbLabel"><u>N</u>hãn trường:</asp:label></TD>
					<TD><asp:textbox Width="260px" id="txtFieldCode" runat="server" CssClass="lbTextbox"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblVietFieldName" runat="server" CssClass="lbLabel">Tên trường (V<u>i</u>ệt):</asp:label></TD>
					<TD><asp:textbox Width="260px" id="txtVietFieldName" runat="server" CssClass="lbTextbox"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblFieldName" runat="server" CssClass="lbLabel"><U>T</U>ên trường (Anh):</asp:label></TD>
					<TD><asp:textbox Width="260px" id="txtFieldName" runat="server" CssClass="lbTextbox"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblVietIndicators" runat="server" CssClass="lbLabel"><U>C</U>hỉ định dữ liệu thứ nhất:</asp:label></TD>
					<TD><asp:textbox id="txtVietIndicators" runat="server" TextMode="MultiLine" CssClass="lbTextbox"
							Width="370px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblIndicators" runat="server" CssClass="lbLabel">C<U>h</U>ỉ định dữ liệu thứ hai:</asp:label></TD>
					<TD><asp:textbox id="txtIndicators" runat="server" TextMode="MultiLine" CssClass="lbTextbox" Width="370px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblDescription" runat="server" CssClass="lbLabel">G<U>i</U>ải thích (cách nhập liệu)</asp:label></TD>
					<TD><asp:textbox id="txtDescription" runat="server" TextMode="MultiLine" CssClass="lbTextbox" Width="370px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblAuthorityControl" runat="server" CssClass="lbLabel"><U>S</U>ử dụng từ điển tham chiếu:</asp:label></TD>
					<TD><asp:dropdownlist id="ddlAuthorityControl" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblFieldType" runat="server" CssClass="lbLabel"><U>K</U>iểu trường:</asp:label></TD>
					<TD><asp:dropdownlist id="ddlMarcFieldTypes" runat="server"></asp:dropdownlist><asp:button id="btnConfigureAttachDataField" runat="server" text="Đặt cấu hình(u)" CssClass="lbButton"></asp:button></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblLength" runat="server" CssClass="lbLabel">Độ <U>d</U>ài:</asp:label></TD>
					<TD><asp:textbox id="txtLength" runat="server" CssClass="lbTextbox" Width="80px"></asp:textbox><asp:label id="lblComment" runat="server" CssClass="lbLabel">(0: không giới hạn)</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:checkbox id="chkRepeatable" runat="server" Text="Lặp" CssClass="lbCheckbox"></asp:checkbox><asp:checkbox id="chkMandatory" runat="server" Text="Bắt buộc" CssClass="lbCheckbox"></asp:checkbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblFunction" runat="server" CssClass="lbLabel">Chức năn<U>g<U>:</asp:label></TD>
					<TD><asp:dropdownlist id="ddlMarcFunctions" runat="server"></asp:dropdownlist><INPUT id="txtPhysicalPath" type="hidden" runat="Server">
						<INPUT id="txtURL" type="hidden" runat="Server"> <INPUT id="txtAllowedFileExt" type="hidden" runat="Server">
						<INPUT id="txtDeniedFileExt" type="hidden" runat="Server"> <INPUT id="txtMaxSize" type="hidden" value="0" runat="Server">
						<INPUT id="txtPrefix" type="hidden" runat="Server"> <INPUT id="txtLogo" type="hidden" runat="Server">
						<INPUT id="txtLinkTypeID" type="hidden" name="txtLinkTypeID" runat="Server">
					</TD>
				</TR>
			</TABLE>

			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">---------- Chọn ----------</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="3">Tạo mới trường biên mục:</asp:ListItem>
				<asp:ListItem Value="4">Kiểu dữ liệu này chỉ được áp dụng cho trường 856 và 956!</asp:ListItem>
				<asp:ListItem Value="5">Bạn chưa nhập nhãn trường hoặc nhãn trường không tồn tại!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
