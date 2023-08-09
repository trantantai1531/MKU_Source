<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.clsWTreeView" CodeFile="clsWTreeView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>clsWTreeView</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" width="100%" cellpadding="2" cellspacing="0">
				<tr class="lbControlBar" height="30">
					<td>
						<asp:Label Runat="server" ID="lblDisplay">Hiển thị: </asp:Label>
						<asp:DropDownList Runat="server" ID="ddlEdataView" AutoPostBack="True">
							<asp:ListItem Selected="True" Value="0">Theo thư mục</asp:ListItem>
							<asp:ListItem Selected="True" Value="1">Theo trạng thái</asp:ListItem>
							<asp:ListItem Selected="True" Value="2">Theo định dạng</asp:ListItem>
							<asp:ListItem Selected="True" Value="3">Theo bộ sưu tập</asp:ListItem>
							<asp:ListItem Selected="True" Value="4">Tìm kiếm</asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
				<TR runat="server" id="TRSearch">
					<td>
						<table border="0" cellpadding="2" cellspacing="0" width="100%">
							<tr class="lbPageTitle">
								<td>
									<asp:Label runat="server" ID="lblSearch" CssClass="lbPageTitle">Tìm kiếm</asp:Label>
								</td>
							</tr>
							<TR>
								<TD height="5"></TD>
							</TR>
							<tr>
								<td>
									<asp:Label runat="server" ID="lblPath" CssClass="lbLabel"><u>Đ</u>ường dẫn:</asp:Label>
								</td>
							</tr>
							<tr>
								<td>
									<asp:TextBox id="txtPhysicalPath" runat="server" Width="168px"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Label runat="server" ID="lblStatus" CssClass="lbLabel"><u>T</u>rạng thái:</asp:Label>
								</td>
							</tr>
							<tr>
								<td>
									<asp:DropDownList id="ddlStatus" runat="server">
										<asp:ListItem Selected="True" Value="">--- Chọn trạng thái ---</asp:ListItem>
										<asp:ListItem Value="1">Được khai thác</asp:ListItem>
										<asp:ListItem Value="2">Đang xử lý</asp:ListItem>
										<asp:ListItem Value="3">Chờ duyệt</asp:ListItem>
										<asp:ListItem Value="4">Ngừng khai thác</asp:ListItem>
									</asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Label id="lblMediaType" runat="server" CssClass="lbLabel">Địn<u>h</u> dạng dữ liệu:</asp:Label>
								</td>
							</tr>
							<tr>
								<td>
									<asp:ListBox id="lstMediaType" runat="server" SelectionMode="Multiple">
										<asp:ListItem Value="1">Hình ảnh</asp:ListItem>
										<asp:ListItem Value="2">Video</asp:ListItem>
										<asp:ListItem Value="3">Âm thanh</asp:ListItem>
										<asp:ListItem Value="4">Văn bản</asp:ListItem>
										<asp:ListItem Value="5">Bản đồ ảnh</asp:ListItem>
										<asp:ListItem Value="6">Chương trình</asp:ListItem>
										<asp:ListItem Value="7">Khác</asp:ListItem>
									</asp:ListBox>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Label id="lblCollection" runat="server" CssClass="lbLabel"><u>B</u>ộ sưu tập:</asp:Label>
								</td>
							</tr>
							<TR>
								<TD>
									<asp:DropDownList id="ddlCollection" runat="server"></asp:DropDownList></TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblSecretLevel" runat="server" CssClass="lbLabel">Cấp độ <u>m</u>ật:</asp:Label></TD>
							</TR>
							<TR>
								<TD>
									<asp:DropDownList id="ddlSecretParam" runat="server">
										<asp:ListItem Value=">=">>=</asp:ListItem>
										<asp:ListItem Value="<="><=</asp:ListItem>
									</asp:DropDownList>&nbsp;
									<asp:DropDownList id="ddlSecretLevel" runat="server">
										<asp:ListItem Value="0">0</asp:ListItem>
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="9">9</asp:ListItem>
									</asp:DropDownList>
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:Label id="lblSize" runat="server" CssClass="lbLabel"><u>K</u>ích thước tệp:</asp:Label></TD>
							</TR>
							<TR>
								<TD>
									<asp:DropDownList id="ddlSizePara" runat="server">
										<asp:ListItem Value=">=">>=</asp:ListItem>
										<asp:ListItem Value="<="><=</asp:ListItem>
									</asp:DropDownList>&nbsp;
									<asp:TextBox id="txtSize" runat="server" Width="80px"></asp:TextBox>&nbsp;
									<asp:Label id="lblKB" runat="server" CssClass="lbLabel">KB</asp:Label></TD>
							</TR>
							<TR>
								<TD height="5"></TD>
							</TR>
							<TR>
								<TD>
									<asp:Button id="btnSearch" runat="server" Width="96px" Text="Tìm kiếm (s)" CssClass="lbButton"></asp:Button></TD>
							</TR>
						</table>
					</td>
				</TR>
			</table>
			<div style="LEFT:0px; POSITION:absolute; TOP:100px">
				<table border="0">
					<tr>
						<td>
							<font size="-2"><a style="FONT-SIZE:6pt;COLOR:silver;TEXT-DECORATION:none" href="http://www.treemenu.net/"
									target="_blank"></a></font>
						</td>
					</tr>
				</table>
			</div>
			<asp:Label Runat="server" ID="lblScript">
				<script>initializeDocument()</script>
			</asp:Label>
			<asp:dropdownlist ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0"></asp:ListItem>
				<asp:ListItem Value="1">Hình ảnh</asp:ListItem>
				<asp:ListItem Value="2">Video</asp:ListItem>
				<asp:ListItem Value="3">Âm thanh</asp:ListItem>
				<asp:ListItem Value="4">Văn bản</asp:ListItem>
				<asp:ListItem Value="5">Bản đồ ảnh</asp:ListItem>
				<asp:ListItem Value="6">Chương trình</asp:ListItem>
				<asp:ListItem Value="7">Khác</asp:ListItem>
				<asp:ListItem Value="8">Được khai thác</asp:ListItem>
				<asp:ListItem Value="9">Đang xử lý</asp:ListItem>
				<asp:ListItem Value="10">Chờ duyệt</asp:ListItem>
				<asp:ListItem Value="11">Ngừng khai thác</asp:ListItem>
				<asp:ListItem Value="12">Không rõ</asp:ListItem>
				<asp:ListItem Value="13">Không thuộc bộ sưu tập</asp:ListItem>
				<asp:ListItem Value="14">--- Chọn bộ sưu tập ---</asp:ListItem>
				<asp:ListItem Value="15">Bạn phải nhập dữ liệu kiểu số</asp:ListItem>
				<asp:ListItem Value="16">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="17">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="18">Chi tiết lỗi</asp:ListItem>
			</asp:dropdownlist>
		</form>
	</body>
</HTML>
