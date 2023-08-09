<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WExportClassification" CodeFile="WExportClassification.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WExport Classification</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE width="100%" cellSpacing="0" cellPadding="2">
				<TR class="lbPageTitle">
					<TD colSpan="2">
						<asp:label runat="server" id="lblPageTitle" cssclass="lbPageTitle">Xuất khẩu bản ghi dữ liệu căn cứ (Classification)</asp:label></TD>
				</TR>
				<TR>
					<TD width="311" align="right">
						<asp:label runat="server" id="lblTerm"><u>C</u>hỉ số phân loại:</asp:label>
					</TD>
					<TD>
						<asp:DropDownList ID="ddlDisPlayEntry" Runat="server">
							<asp:ListItem Value="0">BBK</asp:ListItem>
							<asp:ListItem Value="1">DDC</asp:ListItem>
							<asp:ListItem Value="2">LOC</asp:ListItem>
							<asp:ListItem Value="3">NLM</asp:ListItem>
							<asp:ListItem Value="4">UDC</asp:ListItem>
						</asp:DropDownList>
					</TD>
				</TR>
				<TR>
					<TD align="right" valign="top">
						<asp:label runat="server" id="lblMfn"><u>R</u>ecord ID:</asp:label>
					</TD>
					<TD>
						<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td style="WIDTH: 102px">
									<asp:label runat="server" id="lblFrom"><u>T</u>ừ:</asp:label></td>
								<td>&nbsp;
									<asp:label runat="server" id="lblTo" Height="8px">Tớ<u>i</u>:</asp:label>
								</td>
							</tr>
							<tr>
								<td style="WIDTH: 102px">
									<asp:textbox runat="server" id="txtIDFrom" Width="94px"></asp:textbox></td>
								<td>&nbsp;
									<asp:textbox runat="server" id="txtIDTo" Width="94"></asp:textbox>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label runat="server" id="lblMaxExp"><u>G</u>iới hạn xuất bản(bản ghi):</asp:label>
					</TD>
					<TD>
						<asp:textbox runat="server" id="txtMaxExp" Width="94px"></asp:textbox>&nbsp;
						<asp:checkbox runat="server" id="chkExpAll" text="Toàn <u>b</u>ộ"></asp:checkbox>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label runat="server" id="lblCheckMarc21">Ký tự điều khiển:</asp:label></TD>
					<TD>
						<asp:RadioButton GroupName="controls" id="optCheckMarc" runat="server" Text="Theo chuẩn <u>M</u>ARC 21"></asp:RadioButton>
					</TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label runat="server" id="lblCheckIso">
							<I>Chỉ áp dụng cho khuôn dạng MARC 21 (raw)</I></asp:label>
					</TD>
					<TD>
						<asp:RadioButton runat="server" GroupName="controls" id="optCheckIso" Checked="True" Text="Theo người <u>d</u>ùng"></asp:RadioButton>
					</TD>
				</TR>
				<TR>
					<TD align="right"></TD>
					<TD>
						<asp:label runat="server" id="lblSubField">Chỉ định <u>n</u>hãn trường con:</asp:label>&nbsp;
						<asp:textbox runat="server" id="txtSubField" Width="32px">$</asp:textbox>&nbsp;
						<asp:label runat="server" id="lblFieldTer">Kết thúc tr<u>ư</u>ờng:</asp:label>&nbsp;
						<asp:textbox runat="server" id="txtFieldTer" Width="32px">#</asp:textbox>&nbsp;
						<asp:label runat="server" id="lblRecTer">Kết thúc bản <u>g</u>hi:</asp:label>&nbsp;
						<asp:textbox runat="server" id="txtRecTer" Width="32px">#</asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						<asp:button id="btnExport" runat="server" Text="Xuất khẩu(x)" Width="98px"></asp:button>&nbsp;
						<INPUT class="lbButton" id="btnReset" type="reset" value="Đặt lại(r)" name="btnReset" Width="60px"
							runat="server">
					</TD>
				</TR>
				<TR>
					<TD colspan="2" style="HEIGHT: 100px"><br>
						<br>
						<br>
						<P>&nbsp;</P>
						<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Label id="lblResult" runat="server" Visible="False" Font-Bold="True">Số bản ghi được xuất khẩu là:</asp:Label>
							<asp:Label id="lblCount" runat="server" Visible="False" CssClass="lbAmount"></asp:Label>
							<BR>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:Label id="lblClick" runat="server" Visible="False" Font-Bold="True">Click</asp:Label>&nbsp;
							<asp:HyperLink id="lnkLink" runat="server" Visible="False">vào đây</asp:HyperLink>&nbsp;
							<asp:Label id="lblLinkTail" runat="server" Visible="False" Font-Bold="True">để lấy file về</asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD colspan="2">
						<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
							<asp:ListItem Value="0">Xuất khẩu được:</asp:ListItem>
							<asp:ListItem Value="1">Không có bản ghi nào thoả mãn điều kiện tìm kiếm!</asp:ListItem>
							<asp:ListItem Value="2">Không có bản ghi nào được xuất khẩu!</asp:ListItem>
							<asp:ListItem Value="3">Sai khuôn dạng dữ liệu (số)!</asp:ListItem>
							<asp:ListItem Value="4">Record ID nhập vào phải lớn hơn 0!</asp:ListItem>
							<asp:ListItem Value="5">Record ID đầu phải nhỏ hơn hoặc bằng Record ID cuối!</asp:ListItem>
							<asp:ListItem Value="6">Bạn phải nhập ít nhất một điều kiện tìm kiếm!</asp:ListItem>
							<asp:ListItem Value="7">Giới hạn xuất bản nhập vào phải là dữ liệu kiểu số!</asp:ListItem>
							<asp:ListItem Value="8">Giới hạn xuất bản nhập vào phải lớn hơn 0!</asp:ListItem>
							<asp:ListItem Value="9">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="10">Chi tiết lỗi</asp:ListItem>
							<asp:ListItem Value="11">Record ID nhập vào phải là dữ liệu kiểu số! </asp:ListItem>
							<asp:ListItem Value="12">Record ID nhập vào phải lớn hơn 0!</asp:ListItem>
							<asp:ListItem Value="13">Record ID đầu phải nhỏ hơn hoặc bằng Record ID cuối!</asp:ListItem>
							<asp:ListItem Value="14">Bạn phải nhập ít nhất một điều kiện tìm kiếm!</asp:ListItem>
							<asp:ListItem Value="15">Giới hạn xuất bản nhập vào phải là dữ liệu kiểu số!</asp:ListItem>
							<asp:ListItem Value="16">Giới hạn xuất bản nhập vào phải lớn hơn 0!</asp:ListItem>
							<asp:ListItem Value="17">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
							<asp:ListItem Value="18">Sai khuôn dạng dữ liệu số!</asp:ListItem>
						</asp:DropDownList>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">
			document.forms[0].ddlDisPlayEntry.focus();
		</script>
	</body>
</HTML>
