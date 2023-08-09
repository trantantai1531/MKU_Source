<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFieldModify" CodeFile="WMarcFieldModify.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WMarcFieldModify</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <style>
            textarea.lbTextBox {
                    border: 1px solid #7a7a85;
                }
        </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" onload="parent.document.getElementById('frmMain').setAttribute('rows','*,39');">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="3" width="100%" border="0">
				<TR>
					<TD colspan="2" class="lbPageTitle" align="center"><asp:Label id="lblMainTitle" runat="server" CssClass="lbPageTitle">Sửa trường biên mục</asp:Label>
						|
						<asp:Hyperlink id="lnkCreate" runat="server">Tạo mới trường biên mục</asp:Hyperlink></TD>
				</TR>
				<TR>
					<TD width="40%" align="right">
						<asp:Label id="lblFieldCode" runat="server"><U>N</U>hãn trường:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtFieldCode" runat="server" Width="300"></asp:TextBox>
						<asp:Label id="lblMan1" runat="server" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc phải nhập dữ liệu">(*)</asp:Label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblVietFieldName" runat="server">Tên trường (Việt):</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtVietFieldName" runat="server" Width="300"></asp:TextBox>
						<asp:Label id="lblMan2" runat="server" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc phải nhập dữ liệu">(*)</asp:Label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblFieldName" runat="server">Tên <U>t</U>rường (Anh):</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtFieldName" runat="server" Width="300"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblIndicators" runat="server"><U>C</U>hỉ định dữ liệu thứ nhất:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtIndicators" runat="server" TextMode="MultiLine" Width="370px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblVietIndicators" runat="server">C<U>h</U>ỉ định dữ liệu thứ hai:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtVietIndicators" runat="server" TextMode="MultiLine" Width="370px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblDescription" runat="server"><U>G</U>iải thích (cách nhập liệu):</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtDescription" runat="server" TextMode="MultiLine" Width="370px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblAuthorityControl" runat="server"><U>S</U>ử dụng từ điển tham chiếu:</asp:Label></TD>
					<TD>
						<asp:DropdownList id="ddlAuthorityControl" runat="server"></asp:DropdownList></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblFieldType" runat="server"><U>K</U>iểu trường:</asp:Label></TD>
					<TD>
						<asp:DropdownList id="ddlMarcFieldTypes" runat="server"></asp:DropdownList>
						<asp:Button ID="btnConfigureAttachDataField" runat="server" text="Đặt cấu hình(u)" Width="120px"></asp:Button>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblLength" runat="server">Độ <U>d</U>ài:</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtLength" runat="server" Width="80px">0</asp:TextBox>&nbsp;
						<asp:Label id="lblComment" runat="server">(0: không giới hạn)</asp:Label>&nbsp; 
						&nbsp;
						<asp:CheckBox id="chkRepeatable" runat="server" CssClass="lbCheckBox" Text="Lặp"></asp:CheckBox>
						<asp:CheckBox id="chkMandatory" runat="server" CssClass="lbCheckBox" Text="Bắt buộc"></asp:CheckBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblFunction" runat="server">Chức năn<U>g</U>:</asp:Label></TD>
					<TD>
						<asp:DropdownList id="ddlMarcFunctions" runat="server"></asp:DropdownList>
						<input type="hidden" runat="Server" id="txtPhysicalPath" NAME="txtPhysicalPath">
						<input type="hidden" runat="Server" id="txtURL" NAME="txtURL"> <input type="hidden" runat="Server" id="txtAllowedFileExt" NAME="txtAllowedFileExt">
						<input type="hidden" runat="Server" id="txtDeniedFileExt" NAME="txtDeniedFileExt">
						<input type="hidden" runat="Server" id="txtMaxsize" value="0" NAME="txtMaxsize">
						<input type="hidden" runat="Server" id="txtPrefix" NAME="txtPrefix"> <input type="hidden" runat="Server" id="txtLogo" NAME="txtLogo">
						<input type="hidden" runat="Server" id="txtLinkTypeID" NAME="txtLinkTypeID"> <input type="hidden" runat="Server" id="txtFieldID" NAME="txtFieldID">
						<input type="hidden" runat="Server" id="txtFunctionID" NAME="txtFunctionID">
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chọn</asp:ListItem>
				<asp:ListItem Value="1">Toàn bộ dữ liệu của trường này sẽ mất!</asp:ListItem>
				<asp:ListItem Value="2">Kiểu dữ liệu này chỉ được áp dụng cho trường 856 và 956!</asp:ListItem>
				<asp:ListItem Value="3">Không áp dụng cho kiểu dữ liệu này!</asp:ListItem>
				<asp:ListItem Value="4">Cập nhật trường biên mục</asp:ListItem>
				<asp:ListItem Value="5">thành công!</asp:ListItem>
				<asp:ListItem Value="6">Giá trị trường rỗng</asp:ListItem>
				<asp:ListItem Value="7">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="8">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="9">Sai định dạng dữ liệu (số)!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
