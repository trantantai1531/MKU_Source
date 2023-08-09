<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WLocPos" CodeFile="WLocPos.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WLocPos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
				<TR class="lbPageTitle">
					<td colSpan="2">
						<asp:label id="lblTitle" runat="server" CssClass="lbPageTitle" width="100%">Sơ đồ kho</asp:label></td>
				</TR>
				<TR>
					<td>
						<asp:image id="imgHasImg" Runat="server" ImageUrl="../../Images/showimg.gif"></asp:image>&nbsp;
						<asp:label id="lblHasImg" Runat="server">Đã có ảnh sơ đồ</asp:label>&nbsp;
						<asp:image id="imgNoImg" Runat="server" ImageUrl="../../Images/Cancel.gif"></asp:image>&nbsp;
						<asp:label id="lblNoImg" Runat="server">Chưa có ảnh sơ đồ</asp:label>&nbsp;&nbsp;&nbsp;</td>
					<td align="right" width="60%"><asp:label id="lblLibrary" runat="server"><u>T</u>hư viện:</asp:label>&nbsp;
						<asp:dropdownlist id="ddlLibrary" runat="server" AutoPostBack="True"></asp:dropdownlist></td>
				</TR>
				<tr>
					<td colSpan="2"><asp:datagrid id="dtgContent" runat="server" Width="100%" Height="48px" AutoGenerateColumns="False"
							PageSize="8" AllowPaging="True">
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="Symbol" ReadOnly="True" HeaderText="Kho">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Tệp ảnh">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ShowImg") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<input id="fldtgImageUpload" runat="server" name="fldtgImageUpLoad" type="file">
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Chiều d&#224;i(m)">
									<HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ImgWidthMetter") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="txtdtgImgWidthMetter" Width=100% CssClass="lbTextbox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ImgWidthMetter") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Chiều rộng(m)">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ImgHeightMetter") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="txtdtgImgHeightMetter" Width=100% CssClass="lbTextbox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ImgHeightMetter") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Tung độ(pixel)">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TopCoor") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="txtdtgTopCoor" Width=100% CssClass="lbTextbox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TopCoor") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Ho&#224;nh độ(pixel)">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
									<ItemTemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LeftCoor") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="txtdtgLeftCoor" Width=100% CssClass="lbTextbox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LeftCoor") %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Sửa">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton runat="server" Text="<image src ='../../Images/Edit2.gif' border=0 title='Sửa'>"
											CommandName="Edit" CausesValidation="false"></asp:LinkButton>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:LinkButton ID="lnkbtnUpdate" runat="server" Text="<Image src ='../../Images/update.gif' title='Sửa' border=0>"
											CommandName="Update"></asp:LinkButton>&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='../../Images/Cancel.gif' title='Thôi' border=0>"
											CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:ButtonColumn Text="&lt;Image src ='../../Images/Delete.gif' title='Xo&#225;' border=0&gt;" HeaderText="Xo&#225;"
									CommandName="Delete">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="LocID" ReadOnly="True" HeaderText="LocID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ImgURL" ReadOnly="True" HeaderText="ImgURL"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="imgHeight" ReadOnly="True" HeaderText="imgHeight"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="imgWidth" ReadOnly="True" HeaderText="imgWidth"></asp:BoundColumn>
							</Columns>
							<PagerStyle Position="Top"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</TABLE>
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td><asp:label id="lblHelp1" Runat="server" Visible="False"><b>Chiều dài, chiều rộng:</b> Kích thước trên thực tế của không gian trên sơ đồ.</asp:label><br>
						<asp:label id="lblHelp2" Runat="server" Visible="False"><b>Tung độ, hoành độ:</b> Toạ độ đỉnh (góc trên bên trái) của kho trên sơ đồ mặt bằng (tính từ góc trên bên trái của sơ đồ).</asp:label><br>
						<asp:label id="lblHelp3" Runat="server" Visible="False" Font-Italic="True">(Bạn có thể xác định 2 giá trị trên bằng cách bấm chuột vào điểm tương ứng trên sơ đồ mặt bằng)</asp:label></td>
				</tr>
				<tr>
					<td height="8">
					</td>
				</tr>
			</table>
			<div align="center"><input id="ipShowImage" runat="server" type="image" NAME="ipShowImage"></div>
			<asp:dropdownlist id="ddlLabelNote" runat="server" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Nhấn OK để khẳng định xoá phương thức này !</asp:ListItem>
				<asp:ListItem Value="1">Xem và chỉnh sửa sơ đồ mặt bằng</asp:ListItem>
				<asp:ListItem Value="2">Chưa có ảnh sơ đồ kho !</asp:ListItem>
				<asp:ListItem Value="3">Chiều dài hiện thời không khớp với chiều rộng nhập vào căn cứ theo tỷ lệ các cạnh của sơ đồ. Chiều dài hợp lý phải là </asp:ListItem>
				<asp:ListItem Value="4"> m.\nBạn có muốn cập nhật con số này không? Bấm \"OK\" để cập nhật. Bấm \"Cancel\" để giữ nguyên</asp:ListItem>
				<asp:ListItem Value="5">Chiều rộng hiện thời không khớp với chiều dài nhập vào căn cứ theo tỷ lệ các cạnh của sơ đồ. Chiều rộng hợp lý phải là </asp:ListItem>
				<asp:ListItem Value="6">Giá trị không hợp lệ!</asp:ListItem>
				<asp:ListItem Value="7">Xoá sơ đồ kho tại</asp:ListItem>
				<asp:ListItem Value="8">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="9">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="10">Tạo sơ đồ kho mới tại</asp:ListItem>
				<asp:ListItem Value="11">Cập nhật sơ đồ kho tại</asp:ListItem>
				<asp:ListItem Value="12">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
				<asp:ListItem Value="13">Trường giá trị còn rỗng!</asp:ListItem>
				<asp:ListItem Value="14">----- Chọn -----</asp:ListItem>
				<asp:ListItem Value="15">Bạn chưa tạo kho cho thư viện hiện hành!</asp:ListItem>
			</asp:dropdownlist>
			<input id="hidImgWidth" runat="server" name="hidImgWidth" type="hidden"> <input id="hidImgHeight" runat="server" name="hidImgHeight" type="hidden">
		</form>
	</body>
</HTML>
