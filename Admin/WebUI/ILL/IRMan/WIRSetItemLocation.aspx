<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WIRSetItemLocation" CodeFile="WIRSetItemLocation.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Chi tiết về ấn phẩm được yêu cầu</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD colSpan="3"><asp:label id="lblPageTitle" runat="server" CssClass="lbPageTitle" Width="100%">Chi tiết về ấn phẩm được yêu cầu</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<asp:label id="lblToFind" runat="server">Đưa vào tìm</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:label id="lblContent" runat="server"></asp:label></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center" colSpan="3" rowSpan="1">
						<asp:button id="btnSearch" runat="server" Text="Tìm(t)" Width="70px"></asp:button>
						<asp:dropdownlist id="ddlLabel" Width="0" Runat="server">
							<asp:ListItem>Nhan đề</asp:ListItem>
							<asp:ListItem>Ấn bản</asp:ListItem>
							<asp:ListItem>Tác giả</asp:ListItem>
							<asp:ListItem>Cơ quan bảo trợ</asp:ListItem>
							<asp:ListItem>Nơi xuất bản</asp:ListItem>
							<asp:ListItem>Nhà xuất bản</asp:ListItem>
							<asp:ListItem>Năm xuất bản</asp:ListItem>
							<asp:ListItem>Bib ID</asp:ListItem>
							<asp:ListItem>Nhan đề bài trích</asp:ListItem>
							<asp:ListItem>Tác giả bài trích</asp:ListItem>
							<asp:ListItem>Số/Tập</asp:ListItem>
							<asp:ListItem>Ngày xuất bản số/tập</asp:ListItem>
							<asp:ListItem>Định vị trang</asp:ListItem>
							<asp:ListItem>Số định danh</asp:ListItem>
							<asp:ListItem>ISBN</asp:ListItem>
							<asp:ListItem>ISSN</asp:ListItem>
							<asp:ListItem>LCCN</asp:ListItem>
							<asp:ListItem>Tên/số hiệu tùng thư</asp:ListItem>
							<asp:ListItem>Các số hiệu khác</asp:ListItem>
							<asp:ListItem>Nguồn xác thực</asp:ListItem>
							<asp:ListItem>Không tìm thấy bản ghi biên mục nào.</asp:ListItem>
							<asp:ListItem>Rỗi</asp:ListItem>
							<asp:ListItem>Bận</asp:ListItem>
							<asp:ListItem>Chọn</asp:ListItem>
							<asp:ListItem>Liệt kê theo từng số</asp:ListItem>
							<asp:ListItem>Vol.</asp:ListItem>
							<asp:ListItem>Không tìm thấy bản ghi nào thoả mãn điều kiện tìm kiếm</asp:ListItem>
						</asp:dropdownlist>
					</TD>
				</TR>
				<TR>
					<TD align="left" colSpan="3"><asp:checkbox id="chkPerIssue" runat="server" Text="Liệt kê theo từng số" Checked="True" Visible="False"></asp:checkbox></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="3"><asp:datagrid id="dgtItem" runat="server" Width="100%" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateColumn>
									<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink ID="lnkSelect" Runat="server">
											<%# ddlLabel.Items(23).Text %>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Tình trạng">
									<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
									<ItemTemplate>
										<asp:Label Runat="server" ID="lblStatus"></asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Mô tả ấn phẩm">
									<ItemTemplate>
										<asp:Label Runat="server" ID="lblDescription"></asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:Label runat="server" ID="lblItemID" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabelNote" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được quyền truy cập vào chức năng này!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
