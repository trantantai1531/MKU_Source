<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORMan" CodeFile="WORMan.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Yêu cầu đi</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body onkeydown="return microsoftKeyPress();" leftMargin="0" topMargin="0" onload="if(document.forms[0].hidHasItem.value>0) {if (eval('document.forms[0].rdoRequest[0]')){document.forms[0].rdoRequest[0].click();} else if (eval('document.forms[0].rdoRequest')){document.forms[0].rdoRequest.click();}}">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR class="lbPageTitle">
					<TD>
						<asp:HyperLink id="lnkOutGoingReq" runat="server" CssClass="lbLinkFunction" Font-Size="13pt" NavigateUrl="#">Yêu cầu đi</asp:HyperLink>&nbsp;<asp:label id="lblMainTitle" Runat="server" CssClass="lbPageTitle">Các yêu cầu đang xử lý: </asp:label><asp:label id="lblFilter" Runat="server" CssClass="lbPageTitle" Visible="False">Kết quả lọc theo yêu cầu đi</asp:label><asp:label id="lblProcess" Runat="server" CssClass="lbAmount" Font-Size="13pt"></asp:label><asp:label id="lblAmount" Runat="server" CssClass="lbAmount" Visible="False" Font-Size="13pt"></asp:label></TD>
					<td align="right"><asp:label id="lblStatus" Runat="server" ForeColor="White"><u>T</u>hư mục: </asp:label><asp:dropdownlist id="ddlStatus" Runat="server" AutoPostBack="True"></asp:dropdownlist><asp:label id="lblFilterTotal" Runat="server" Visible="False">Tổng số: </asp:label><asp:label id="lblFilterAmount" Runat="server" CssClass="lbAmount" Visible="False"></asp:label><asp:label id="lblRecord" Runat="server" Visible="False"> bản ghi.</asp:label></td>
				</TR>
				<TR>
					<TD colSpan="2"><asp:datagrid id="dgtRequest" Runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblRadio" Runat="server">
											<%# DataBinder.Eval(Container.dataItem,"rdoRequest")%>
										</asp:Label>
										<asp:HyperLink Runat="server" ID="lnkHistory"></asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="RequestID" HeaderText="Mã số">
									<HeaderStyle Width="10%" ForeColor="#ffffe1"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink ID="lnkRequestID" Runat="server" CssClass="lbLinkFunction">
											<%# DataBinder.Eval(Container.dataItem,"RequestID")%>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="LibrarySymbol" HeaderText="Nơi nhận">
									<HeaderStyle Width="10%" ForeColor="#ffffe1"></HeaderStyle>
									<ItemTemplate>
										<asp:HyperLink ID="lblLibrarySymbol" Runat="server">
											<%# DataBinder.Eval(Container.dataItem,"LibrarySymbol")%>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Priority" HeaderText="Ưu tiên">
									<HeaderStyle Width="10%" ForeColor="#ffffe1"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblPriority" Runat="server"></asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="ServiceType" HeaderText="Kiểu">
									<HeaderStyle Width="10%" ForeColor="#ffffe1"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblServiceType" Runat="server"></asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="CREATEDDATE" HeaderText="Ngày tạo">
									<HeaderStyle Width="15%" ForeColor="#ffffe1"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label ID="lblDate" Runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CREATEDDATE") & "<BR><font color=""red"">" & DataBinder.Eval(Container.DataItem, "REQUESTDATE") & "</font>"%>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Title" HeaderText="Nhan đề / Bạn đọc">
									<HeaderStyle Width="30%" ForeColor="#ffffe1"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Hyperlink ID="lnkTitle" Runat="server">
											<%# "<B>" & DataBinder.Eval(Container.DataItem, "Title") & "</B><BR>" & DataBinder.Eval(Container.DataItem, "PatronName")%>
										</asp:Hyperlink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Status" HeaderText="Trạng thái">
									<HeaderStyle Width="17%" ForeColor="#ffffe1"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label ID="lblStatusDisplay" Runat="server"></asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label ID="lblStatusTemp" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:Label ID="lblPriorityID" Runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "Priority") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:Label ID="lblServiceTypeID" Runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "ServiceType") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:Label ID="lblNom" Runat="server" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "Nom") %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<tr>
					<td colSpan="2">
						<INPUT id="hidRequestID" type="hidden" runat="server" NAME="hidRequestID"> <INPUT id="hidColSort" type="hidden" name="hidColSort" runat="server">
					</td>
				</tr>
			</TABLE>
			<input id="hidHasItem" runat="server" type="hidden">
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Duyệt/Sửa lại</asp:ListItem>
				<asp:ListItem Value="3">Nhân bản</asp:ListItem>
				<asp:ListItem Value="4">Gửi yêu cầu</asp:ListItem>
				<asp:ListItem Value="5">Huỷ bỏ yêu cầu</asp:ListItem>
				<asp:ListItem Value="6">Sửa chữa</asp:ListItem>
				<asp:ListItem Value="7">Lịch sử yêu cầu</asp:ListItem>
				<asp:ListItem Value="8">Từ chối yêu cầu</asp:ListItem>
				<asp:ListItem Value="9">Trả lời thông báo điều kiện</asp:ListItem>
				<asp:ListItem Value="10">Gửi tiếp</asp:ListItem>
				<asp:ListItem Value="11">Nhận được</asp:ListItem>
				<asp:ListItem Value="12">Gia hạn</asp:ListItem>
				<asp:ListItem Value="13">Đổi trạng thái</asp:ListItem>
				<asp:ListItem Value="14">Thông báo cho bạn đọc</asp:ListItem>
				<asp:ListItem Value="15">Hoàn trả</asp:ListItem>
				<asp:ListItem Value="16">Báo mất</asp:ListItem>
				<asp:ListItem Value="17">Gửi thông điệp</asp:ListItem>
				<asp:ListItem Value="18">Hỏi trạng thái</asp:ListItem>
				<asp:ListItem Value="19">Xóa</asp:ListItem>
				<asp:ListItem Value="20">Chuyển sang thư mục thích hợp</asp:ListItem>
				<asp:ListItem Value="21">Định vị ấn phẩm</asp:ListItem>
				<asp:ListItem Value="22">Thông báo quá hạn</asp:ListItem>
				<asp:ListItem Value="23">Các yêu cầu đang xử lý</asp:ListItem>
				<asp:ListItem Value="24">(hết hạn)</asp:ListItem>
				<asp:ListItem Value="25">Thường</asp:ListItem>
				<asp:ListItem Value="26">Gấp</asp:ListItem>
				<asp:ListItem Value="27">Mượn</asp:ListItem>
				<asp:ListItem Value="28">Sao chép</asp:ListItem>
				<asp:ListItem Value="29">Bạn không được quyền truy cập vào tính năng này!</asp:ListItem>
				<asp:ListItem Value="30">Lưu trữ</asp:ListItem>
				<asp:ListItem Value="31">Chi phí</asp:ListItem>
				<asp:ListItem Value="32">Khác</asp:ListItem>
			</asp:DropDownList>
			<asp:DropDownList ID="ddlStatusToolTip" Runat="server" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Không cung cấp</asp:ListItem>
				<asp:ListItem Value="1">Chờ giải quyết</asp:ListItem>
				<asp:ListItem Value="2">Đang xử lý</asp:ListItem>
				<asp:ListItem Value="3">Chuyển tiếp</asp:ListItem>
				<asp:ListItem Value="4">Có điều kiện</asp:ListItem>
				<asp:ListItem Value="5">Chờ duyệt huỷ bỏ</asp:ListItem>
				<asp:ListItem Value="6">Huỷ bỏ</asp:ListItem>
				<asp:ListItem Value="7">Đã gửi</asp:ListItem>
				<asp:ListItem Value="8">Đã nhận được</asp:ListItem>
				<asp:ListItem Value="9">Chờ duyệt gia hạn</asp:ListItem>
				<asp:ListItem Value="10">Không nhận được thông báo quá hạn</asp:ListItem>
				<asp:ListItem Value="11">Quá hạn gia hạn</asp:ListItem>
				<asp:ListItem Value="12">Quá hạn</asp:ListItem>
				<asp:ListItem Value="13">Đã hoàn trả</asp:ListItem>
				<asp:ListItem Value="14">Đã nhận lại</asp:ListItem>
				<asp:ListItem Value="15">Đòi lại</asp:ListItem>
				<asp:ListItem Value="16">Mất</asp:ListItem>
				<asp:ListItem Value="17">Không rõ</asp:ListItem>
				<asp:ListItem Value="18">Xem xét</asp:ListItem>
				<asp:ListItem Value="19">Bạn đọc khởi tạo</asp:ListItem>
				<asp:ListItem Value="20">Mới</asp:ListItem>
				<asp:ListItem Value="21">Hoàn thành</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
