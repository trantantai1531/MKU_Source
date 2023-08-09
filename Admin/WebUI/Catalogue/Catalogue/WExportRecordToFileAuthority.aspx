<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WExportRecordToFileAuthority" CodeFile="WExportRecordToFileAuthority.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WExportRecordAuthority</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="2" width="100%">
				<TR class="lbPageTitle">
					<TD colSpan="2">
						<asp:label id="lbPageTitle" runat="server" cssclass="lbPageTitle">Xuất khẩu bản ghi dữ liệu căn cứ (Authority)</asp:label></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblTerm" runat="server"><u>C</u>ó chứa xâu:</asp:label></TD>
					<TD>
						<asp:textbox id="txtTerm" runat="server" Width="123px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblReferenceI" runat="server">trong <u>d</u>ữ liệu:</asp:label></TD>
					<TD>
						<asp:dropdownlist id="ddlReference" Runat="server">
								<asp:ListItem Value="0">Mọi mục từ</asp:ListItem>
								<asp:ListItem Value="1">T&#234;n ri&#234;ng</asp:ListItem>
								<asp:ListItem Value="2">T&#234;n tập thể</asp:ListItem>
								<asp:ListItem Value="3">T&#234;n hội nghị</asp:ListItem>
								<asp:ListItem Value="4">Nhan đề thống nhất</asp:ListItem>
								<asp:ListItem Value="5">Thuật ngữ chủ điểm</asp:ListItem>
								<asp:ListItem Value="6">Địa danh</asp:ListItem>
								<asp:ListItem Value="7">Thuật ngữ thể loại/h&#236;nh thức</asp:ListItem>
								<asp:ListItem Value="8">Tiểu mục chung</asp:ListItem>
								<asp:ListItem Value="9">Tiểu mục địa l&#253;</asp:ListItem>
								<asp:ListItem Value="10">Tiểu mục ni&#234;n đại</asp:ListItem>
								<asp:ListItem Value="11">Tiểu mục h&#236;nh thức</asp:ListItem>
							</asp:dropdownlist>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="LblSource" runat="server"><u>N</u>guồn:</asp:label></TD>
					<TD>
						<asp:dropdownlist id="ddlSourceID" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right">
						<asp:label id="lblDateCreate" runat="server" Height="14px">Ngày hiệu đính cuối:</asp:label></TD>
					<TD>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td><asp:label id="lblFrom1" runat="server" Height="8px"><u>T</u>ừ:</asp:label></td>
								<td>&nbsp;
									<asp:label id="lblTo1" runat="server" Height="8px">Tớ<u>i</u>:</asp:label></td>
							</tr>
							<tr>
								<td><asp:textbox id="txtCataFrom" runat="server" Width="94px"></asp:textbox>
									<asp:HyperLink id="lnkCalFrom" runat="server">Lịch</asp:HyperLink></td>
								<td>&nbsp;
									<asp:textbox id="txtCataTo" runat="server" Width="94"></asp:textbox>
									<asp:HyperLink id="lnkCalTo" runat="server">Lịch</asp:HyperLink></td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right">
						<asp:label id="lblMfn" runat="server">Record ID:</asp:label></TD>
					<TD>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<asp:label id="lblFrom" runat="server"><u>T</u>ừ:</asp:label></td>
								<td>&nbsp;
									<asp:label id="lblTo" runat="server">T<u>ớ</u>i:</asp:label></td>
							</tr>
							<tr>
								<td><asp:textbox id="txtIDFrom" runat="server" Width="94px"></asp:textbox></td>
								<td>&nbsp;
									<asp:textbox id="txtIDTo" runat="server" Width="94"></asp:textbox></td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblMaxExp" runat="server"><u>G</u>iới hạn xuất bản (bản ghi):</asp:label></TD>
					<TD>
						<asp:textbox id="txtMaxExp" runat="server" Width="80px"></asp:textbox>&nbsp;<asp:checkbox id="chkExpAll" runat="server" text="T<u>o</u>àn bộ"></asp:checkbox>
					</TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblFormatType" runat="server"><u>K</u>huôn dạng:</asp:label></TD>
					<TD><asp:dropdownlist id="ddlFormat" runat="server">
							<asp:ListItem Value="0">MARC21(tagged)</asp:ListItem>
							<asp:ListItem Value="1">MARC21(raw)</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblCheckMarc21" runat="server">Ký tự điều khiển:</asp:label></TD>
					<TD>
						<asp:radiobutton id="optCheckMarc" runat="server" GroupName="controls" Text="Theo chuẩn M<u>A</u>RC 21" Checked="True"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblCheckIso" runat="server"><I>Chỉ áp dụng cho khuôn dạng MARC 21 (raw)</I></asp:label></TD>
					<TD>
						<asp:radiobutton id="optCheckIso" runat="server" GroupName="controls" Text="Th<u>e</u>o người dùng"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
					<TD>
						<asp:label id="lblSubField" runat="server">Chỉ định nhãn trường co<u>n</u>:</asp:label>&nbsp;<asp:textbox id="txtSubField" runat="server" Width="32px">$</asp:textbox>&nbsp;<asp:label id="lblFieldTer" runat="server">Kết thúc tr<u>ư</u>ờng:</asp:label>&nbsp;<asp:textbox id="txtFieldTer" runat="server" Width="32px">#</asp:textbox>&nbsp;<asp:label id="lblRecTer" runat="server">Kết thúc <u>b</u>ản ghi:</asp:label>&nbsp;<asp:textbox id="txtRecTer" runat="server" Width="32px">#</asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:button id="btnExport" runat="server" Text="Xuất khẩu(x)" Width="98px"></asp:button>&nbsp;
						<INPUT class="lbButton" id="btnReset" type="reset" value="Đặt lại(r)" name="btnReset" runat="server" Width="64px"></TD>
				</TR>
				<TR>
					<TD colSpan="2">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="2">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="2">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
				</TR>
				<TR>
					<TD colSpan="2"></TD>
				</TR>
				<TR>
					<TD colSpan="2">&nbsp;&nbsp;&nbsp; &nbsp;
						<asp:Label id="lblResult" runat="server" Visible="False" Font-Bold="True">Số bản ghi được xuất khẩu là:</asp:Label>&nbsp;
						<asp:Label id="lblCount" runat="server" CssClass="lbAmount" Visible="False"></asp:Label></TD>
				</TR>
				<TR>
					<TD colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblClick" runat="server" Visible="False" Font-Bold="True">Click</asp:label>&nbsp;
						<asp:hyperlink id="lnkLink" runat="server" CssClass="lbLinkFunction" Visible="false">vào đây</asp:hyperlink>&nbsp;
						<asp:label id="lblLinkTail" runat="server" Visible="False" Font-Bold="True">để lấy file về</asp:label></TD>
				</TR>
			</TABLE>
			<asp:dropdownlist id="ddlLabel" Width="0" Height="0" Visible="False" Runat="server">
				<asp:ListItem Value="0">Xuất khẩu được:</asp:ListItem>
				<asp:ListItem Value="1">Không có bản ghi nào thoả mãn điều kiện tìm kiếm!</asp:ListItem>
				<asp:ListItem Value="2">Không có bản ghi nào được xuất khẩu!</asp:ListItem>
				<asp:ListItem Value="3">Sai khuôn dạng dữ liệu (số)!</asp:ListItem>
				<asp:ListItem Value="4">Record ID nhập vào phải lớn hơn 0!</asp:ListItem>
				<asp:ListItem Value="5">Record ID đầu phải nhỏ hơn hoặc bằng Record ID cuối!</asp:ListItem>
				<asp:ListItem Value="6">Bạn phải nhập ít nhất một điều kiện tìm kiếm!</asp:ListItem>
				<asp:ListItem Value="7">Giới hạn xuất bản nhập vào phải là dữ liệu kiểu số!</asp:ListItem>
				<asp:ListItem Value="8">Giới hạn xuất bản nhập vào phải lớn hơn 0!</asp:ListItem>
				<asp:ListItem Value="9">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="10">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="11">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="12">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="13">Ngày hiệu đính cuối từ: phải nhỏ hơn hoặc bằng tới:</asp:ListItem>
			</asp:dropdownlist></form>
		<script language = javascript>
			document.forms[0].txtTerm.focus();
		</script>
	</body>
</HTML>
