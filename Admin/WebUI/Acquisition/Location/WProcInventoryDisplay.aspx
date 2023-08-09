<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WProcInventoryDisplay" CodeFile="WProcInventoryDisplay.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WProcInventoryDisplay</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<TR>
					<TD><asp:label id="lblHeader" runat="server" Width="100%" CssClass="lbPageTitle">Số liệu xếp giá trong kho </asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblCapLib" runat="server" Font-Bold="True">Thư viện:</asp:label>&nbsp;<asp:label id="lblLib" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblCapLoc" runat="server" Font-Bold="True">Kho:</asp:label>&nbsp;<asp:label id="lblLoc" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label>&nbsp;&nbsp;&nbsp;
						<asp:label id="lblCapShelf" runat="server" Font-Bold="True">Giá sách:</asp:label>&nbsp;<asp:label id="lblShelf" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<table width="100%" border="0">
							<tr>
								<td width="50%"><asp:label id="lblCapSumItem" runat="server">Số đầu ấn phẩm:</asp:label>&nbsp;
									<asp:label id="lblSumItem" runat="server" Font-Bold="True">0</asp:label></td>
								<td><asp:label id="lblCapCountInUsed" runat="server">Số bản đang cho mượn:</asp:label>&nbsp;
									<asp:hyperlink id="lnkInUsed" runat="server" Font-Bold="True">0</asp:hyperlink></td>
							</tr>
							<TR>
								<TD><asp:label id="lblCapSumCopy" runat="server">Số bản ấn phẩm:</asp:label>&nbsp;
									<asp:label id="lblSumCopy" runat="server" Font-Bold="True">0</asp:label></TD>
								<TD><asp:label id="lblCapCountLocked" runat="server">Số bản đang khóa:</asp:label>&nbsp;
									<asp:hyperlink id="lnkLocked" runat="server" Font-Bold="True">0</asp:hyperlink></TD>
							</TR>
							<TR>
								<TD colSpan="2"><asp:label id="lblCapLastLiquid" runat="server">Lần kiểm kê cuối:</asp:label>&nbsp;
									<asp:label id="lblLastLiquid" runat="server" Font-Bold="True"></asp:label></TD>
							</TR>
						</table>
						<asp:hyperlink id="lnkCheckAll" runat="server" CssClass="lbLinkFunction">Chọn tất </asp:hyperlink>&nbsp;
						<asp:hyperlink id="lnkUnCheckAll" runat="server" CssClass="lbLinkFunction">Bỏ tất </asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:image id="imgLocked" runat="server" ImageUrl="../../Images/lock.gif"></asp:image>&nbsp;<asp:label id="lblLocked" runat="server">Đang khoá</asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:image id="imgOnhold" runat="server" ImageUrl="../../Images/loan.gif"></asp:image>&nbsp;<asp:label id="lblOnHold" runat="server">Đang cho mượn</asp:label></TD>
				</TR>
				<tr>
					<td><asp:datagrid id="dtgResult" runat="server" Width="100%" PageSize="20" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateColumn HeaderText="Trạng th&#225;i">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="chkCopyID" runat="server" Visible ='<%#Not cbool(DataBinder.Eval(Container.dataItem,"InUsed")) %>'>
										</asp:CheckBox>
										<input type =hidden id="hidCopyID" runat =server value ='<%# DataBinder.Eval(Container.dataItem,"ID") %>'>
										<asp:Label ID="lblCopyID" Runat =server Visible =False text ='<%# DataBinder.Eval(Container.dataItem,"ID") %>'>
										</asp:Label>
										<asp:Image ID="imgStatusLock" Runat="server" Visible='<%# not cbool(DataBinder.Eval(Container.dataItem,"InCirculation")) %>' ImageUrl="../../Images/lock.gif" >
										</asp:Image>
										<asp:Image ID="imgStatusInUsed" Runat="server" Visible='<%# cbool(DataBinder.Eval(Container.dataItem,"InUsed")) %>' ImageUrl="../../Images/loan.gif" >
										</asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Thư viện">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblSelectLibrary" Text='<%# DataBinder.Eval(Container.DataItem, "LibName") %>' Runat="server" />
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox runat="server" id="txtSelectLibID" Visible=False Text='<%# DataBinder.Eval(Container.DataItem, "LibID") %>'/>
										<asp:DropDownList id="ddlSelectLibrary" AutoPostBack="True" OnSelectedIndexChanged="PopulateLocationDropDownList" runat="server" Enabled='<%# NOT DataBinder.Eval(Container.dataItem,"InUsed") %>'>
										</asp:DropDownList>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Kho">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblSelectLocation" Text='<%# DataBinder.Eval(Container.DataItem, "LocName") %>' Runat=server />
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox runat="server" id="txtSelectLocID" Visible=False Text='<%# DataBinder.Eval(Container.DataItem, "LocationID") %>'/>
										<asp:DropDownList id="ddlSelectLocation" DataTextField="Symbol" DataValueField="ID" runat="server" Enabled='<%# NOT DataBinder.Eval(Container.DataItem, "InUsed") %>' CssClass ="lbDropdownlist" />
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Shelf" HeaderText="Gi&#225; s&#225;ch">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CopyNumber" HeaderText="ĐKCB">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CallNumber" HeaderText="Số định danh">
									<HeaderStyle Width="8px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Volume" Visible="false" HeaderText="Tập">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CONTENT" ReadOnly="True" HeaderText="Th&#244;ng tin chi tiết">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ACQUIREDDATE" ReadOnly="True" HeaderText="Ng&#224;y bổ sung">
									<HeaderStyle Width="8%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Price" ReadOnly="True" HeaderText="Gi&#225; tiền">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="UseCount" ReadOnly="True" HeaderText="Số lượt mượn">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DATELASTUSED" ReadOnly="True" HeaderText="Ng&#224;y mượn cuối">
									<HeaderStyle Width="8%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Note" HeaderText="Ghi ch&#250;">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src=&quot;../../images/Update.gif&quot; border=&quot;0&quot;&gt;"
									CancelText="&lt;img src=&quot;../../images/Cancel.gif&quot; border=&quot;0&quot;&gt;" EditText="&lt;img src=&quot;../../images/Edit.gif&quot; border=&quot;0&quot;&gt;">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:EditCommandColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid><input id="txtLibID" type="hidden" name="txtLibID" runat="server">
						&nbsp;&nbsp;<input id="txtLocIDdgr" type="hidden" name="txtLocIDdgr" runat="server">&nbsp;
						<input id="txtAction" type="hidden" name="txtAction" runat="server">&nbsp; <input id="txtReasonID" type="hidden" value="0" name="txtReasonID" runat="server">&nbsp;
						<asp:label id="lblExisting" runat="server" Visible="False">Đăng ký cá biệt đang tồn tại !</asp:label><asp:label id="lblJS" runat="server" Visible="False"></asp:label></td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlLabel" Width="0" Visible="False" Runat="server">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">ĐKCB đã được khóa!</asp:ListItem>
				<asp:ListItem Value="3">ĐKCB đã được mở!</asp:ListItem>
				<asp:ListItem Value="4">Đã ghi nhận việc huỷ bỏ ĐKCB!</asp:ListItem>
				<asp:ListItem Value="5">Bạn không đựơc cấp quyền sử dụng tính năng này</asp:ListItem>
				<asp:ListItem Value="6">Khoá đăng ký cá biệt</asp:ListItem>
				<asp:ListItem Value="7">Mở khoá đăng ký cá biệt</asp:ListItem>
				<asp:ListItem Value="8">Huỷ đăng ký cá biệt</asp:ListItem>
				<asp:ListItem Value="9">Cập nhật đăng ký cá biệt</asp:ListItem>
				<asp:ListItem Value="10">Thư viện</asp:ListItem>
				<asp:ListItem Value="11">Kho</asp:ListItem>
				<asp:ListItem Value="12">ĐKCB</asp:ListItem>
				<asp:ListItem Value="13">Không tìm thấy dữ liệu!!!</asp:ListItem>
				<asp:ListItem Value="14">Có lỗi trong quá trình huỷ ĐKCB, tồn tại ít nhất 1 ĐKCB đang nằm trong quá trình xử lý!</asp:ListItem>
			</asp:dropdownlist><input id="hidCountID" type="hidden" value="0" name="hidCountID" runat="server">
			<input id="hidTotalCopyIDs" type="hidden" name="hidTotalCopyIDs" runat="server">
		</form>
	</body>
</HTML>
