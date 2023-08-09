<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFieldCreate" CodeFile="WMarcFieldCreate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WMarcFieldCreate</title>
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
					<TD colspan="2" class="lbPageTitle" align="center"><asp:Label id="lblMainTitle" runat="server" CssClass="lbPageTitle">Tạo mới trường biên mục</asp:Label>
						|
						<asp:HyperLink id="lnkModify" runat="server" CssClass="lbLinkFunction">Sửa trường biên mục</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD width="40%" align="right">
						<asp:Label CssClass="lbLabel" id="lblFieldCode" runat="server"><U>N</U>hãn trường:</asp:Label></TD>
					<TD>
						<asp:TextBox CssClass="lbTextBox" id="txtFieldCode" runat="server" Width="300"></asp:TextBox>
						<asp:Label id="lblMan1" runat="server" CssClass="lbLabel" ForeColor="Red" Font-Bold="True"
							ToolTip="Trường bắt buộc phải nhập dữ liệu">(*)</asp:Label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label CssClass="lbLabel" id="lblVietFieldName" runat="server"><U>T</U>ên trường:</asp:Label></TD>
					<TD>
						<asp:TextBox CssClass="lbTextBox" id="txtVietFieldName" runat="server" Width="300"></asp:TextBox>
						<asp:Label id="lblMan2" runat="server" CssClass="lbLabel" ForeColor="Red" Font-Bold="True"
							ToolTip="Trường bắt buộc phải nhập dữ liệu">(*)</asp:Label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label CssClass="lbLabel" id="lblFieldName" runat="server">Tên <U>t</U>rường (Anh):</asp:Label></TD>
					<TD>
						<asp:TextBox CssClass="lbTextBox" id="txtFieldName" runat="server" Width="300"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label CssClass="lbLabel" id="lblIndicators" runat="server"><U>C</U>hỉ định dữ liệu thứ nhất:</asp:Label></TD>
					<TD>
						<asp:TextBox CssClass="lbTextBox" id="txtIndicators" runat="server" TextMode="MultiLine" Width="370px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label CssClass="lbLabel" id="lblVietIndicators" runat="server">C<U>h</U>ỉ định dữ liệu thứ hai:</asp:Label></TD>
					<TD>
						<asp:TextBox CssClass="lbTextBox" id="txtVietIndicators" runat="server" TextMode="MultiLine"
							Width="370px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label CssClass="lbLabel" id="lblDescription" runat="server"><U>G</U>iải thích (cách nhập liệu):</asp:Label></TD>
					<TD>
						<asp:TextBox CssClass="lbTextBox" id="txtDescription" runat="server" TextMode="MultiLine" Width="370px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label CssClass="lbLabel" id="lblAuthorityControl" runat="server"><U>S</U>ử dụng từ điển tham chiếu:</asp:Label></TD>
					<TD>
						<asp:DropdownList id="ddlAuthorityControl" runat="server"></asp:DropdownList></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label CssClass="lbLabel" id="lblFieldType" runat="server"><U>K</U>iểu trường:</asp:Label></TD>
					<TD>
						<asp:DropdownList id="ddlMarcFieldTypes" runat="server"></asp:DropdownList>
						<asp:Button CssClass="lbButton" ID="btnConfigureAttachDataField" runat="server" text="Đặt cấu hình(f)"
							Width="112px"></asp:Button>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label CssClass="lbLabel" id="lblLength" runat="server">Độ <U>d</U>ài:</asp:Label></TD>
					<TD>
						<asp:TextBox CssClass="lbTextBox" id="txtLength" runat="server" Width="80px" MaxLength="5">0</asp:TextBox>&nbsp;
						<asp:Label id="lblComment" runat="server" CssClass="lbLabel">(0: không giới hạn)</asp:Label>&nbsp; 
						&nbsp;
						<asp:CheckBox id="chkRepeatable" runat="server" CssClass="lbCheckBox" Text="Lặp"></asp:CheckBox>
						<asp:CheckBox id="chkMandatory" runat="server" CssClass="lbCheckBox" Text="Bắt buộc"></asp:CheckBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label CssClass="lbLabel" id="lblFunction" runat="server">Chức năn<U>g</U>:</asp:Label></TD>
					<TD>
						<asp:DropdownList id="ddlMarcFunctions" runat="server"></asp:DropdownList>
						<input type="hidden" runat="Server" id="txtPhysicalPath" NAME="txtPhysicalPath">
						<input type="hidden" runat="Server" id="txtURL" NAME="txtURL"> <input type="hidden" runat="Server" id="txtAllowedFileExt" NAME="txtAllowedFileExt">
						<input type="hidden" runat="Server" id="txtDeniedFileExt" NAME="txtDeniedFileExt">
						<input type="hidden" runat="Server" id="txtMaxsize" value="0" NAME="txtMaxsize">
						<input type="hidden" runat="Server" id="txtPrefix" NAME="txtPrefix"> <input type="hidden" runat="Server" id="txtLogo" NAME="txtLogo">
						<input type="hidden" runat="Server" id="txtLinkTypeID" NAME="txtLinkTypeID" value="1"> <input type="hidden" runat="Server" id="txtFieldID" NAME="txtFieldID">
						<input type="hidden" runat="Server" id="txtFunctionID" NAME="txtFunctionID">
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chọn</asp:ListItem>
				<asp:ListItem Value="1">Toàn bộ dữ liệu của trường này sẽ mất!</asp:ListItem>
				<asp:ListItem Value="2">Kiểu dữ liệu này chỉ được áp dụng cho trường 856 và 956!</asp:ListItem>
				<asp:ListItem Value="3">Bạn chưa nhập nhãn trường hoặc nhãn trường không tồn tại!</asp:ListItem>
				<asp:ListItem Value="4">Tạo mới trường</asp:ListItem>
				<asp:ListItem Value="5">thành công!</asp:ListItem>
				<asp:ListItem Value="6">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="7">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="8">Sai định dạng dữ liệu (số)!</asp:ListItem>
				<asp:ListItem Value="9">Nhãn trường đã tồn tại trong CSDL!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
