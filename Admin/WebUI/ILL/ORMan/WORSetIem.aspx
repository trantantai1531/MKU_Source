<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORSetIem" CodeFile="WORSetIem.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Chi tiết về ấn phẩm được yêu cầu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD colSpan="3"><asp:label id="lblPageTitle" runat="server" CssClass="lbPageTitle">Chi tiết về ấn phẩm được yêu cầu</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3">&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblToFind" runat="server">Đưa vào tìm</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"><asp:label id="lblContent" runat="server"></asp:label></TD>
				</TR>
				<TR class="lbControlBar">
					<TD align="center" colSpan="3" rowSpan="1">
						<asp:button id="btnSearch" runat="server" Text="Tìm(s)" Width="70px"></asp:button>&nbsp;
						<asp:button id="btnClose" runat="server" Text="Đóng(o)" Width="70px"></asp:button></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="3"><asp:checkbox id="chkPerIssue" runat="server" Text="Liệt kê theo từng số" Checked="True" Visible="False"></asp:checkbox></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="3"><asp:datagrid id="dgtItem" runat="server" Width="100%" AutoGenerateColumns="False">
							<Columns>
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
						</asp:datagrid></TD>
				</TR>
			</TABLE>
			<asp:dropdownlist id="ddlLabel" Width="0" Runat="server" Height="0" Visible="False">
				<asp:ListItem Value="0">Nhan đề</asp:ListItem>
				<asp:ListItem Value="1">Ấn bản</asp:ListItem>
				<asp:ListItem Value="2">Tác giả</asp:ListItem>
				<asp:ListItem Value="3">Cơ quan bảo trợ</asp:ListItem>
				<asp:ListItem Value="4">Nơi xuất bản</asp:ListItem>
				<asp:ListItem Value="5">Nhà xuất bản</asp:ListItem>
				<asp:ListItem Value="6">Năm xuất bản</asp:ListItem>
				<asp:ListItem Value="7">Bib ID</asp:ListItem>
				<asp:ListItem Value="8">Nhan đề bài trích</asp:ListItem>
				<asp:ListItem Value="9">Tác giả bài trích</asp:ListItem>
				<asp:ListItem Value="10">Số/Tập</asp:ListItem>
				<asp:ListItem Value="11">Ngày xuất bản số/tập</asp:ListItem>
				<asp:ListItem Value="12">Định vị trang</asp:ListItem>
				<asp:ListItem Value="13">Số định danh</asp:ListItem>
				<asp:ListItem Value="14">ISBN</asp:ListItem>
				<asp:ListItem Value="15">ISSN</asp:ListItem>
				<asp:ListItem Value="16">LCCN</asp:ListItem>
				<asp:ListItem Value="17">Tên/số hiệu tùng thư</asp:ListItem>
				<asp:ListItem Value="18">Các số hiệu khác</asp:ListItem>
				<asp:ListItem Value="19">Nguồn xác thực</asp:ListItem>
				<asp:ListItem Value="20">Không tìm thấy bản ghi biên mục nào.</asp:ListItem>
				<asp:ListItem Value="21">Rỗi</asp:ListItem>
				<asp:ListItem Value="22">Bận</asp:ListItem>
				<asp:ListItem Value="23">Chọn</asp:ListItem>
				<asp:ListItem Value="24">Liệt kê theo từng số</asp:ListItem>
				<asp:ListItem Value="25">Vol.</asp:ListItem>
				<asp:ListItem Value="26">Không tìm thấy bản ghi nào thoả mãn điều kiện tìm kiếm</asp:ListItem>
				<asp:ListItem Value="27">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="28">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="29">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
			</asp:dropdownlist>
		</form>
	</body>
</HTML>
