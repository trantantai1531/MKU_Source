<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WManagementArticle" CodeFile="WManagementArticle.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Cấu thành mục lục</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tblMenu" cellSpacing="0" cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="lbPageTitle" width="100%"><asp:label id="lblPageTitle" Runat="server" CssClass="lbPageTitle">Quản lý mục lục</asp:label></TD>
				</TR>
			</TABLE>
			<TABLE id="tblMain" cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TR>
					<TD align="center" colSpan="4"><asp:label id="lblTitle" Runat="server"></asp:label></TD>
				</TR>
				<TR vAlign="top">
					<TD align="right" width="20%"><asp:label id="lblName" Runat="server"><u>N</u>han đề: </asp:label></TD>
					<TD width="20%"><asp:textbox id="txtName" Runat="server" Width="230px"></asp:textbox></TD>
					<TD align="right" width="15%" rowSpan="2"><asp:label id="lblNote" Runat="server"><u>T</u>óm tắt: </asp:label></TD>
					<TD rowSpan="2"><asp:textbox id="txtNote" Runat="server" Width="280px" Rows="3" TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblAuthor" Runat="server"><u>T</u>ác giả: </asp:label></TD>
					<TD><asp:textbox id="txtAuthor" Runat="server" Width="160px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblSubject" Runat="server"><u>C</u>huyên đề: </asp:label></TD>
					<TD><asp:dropdownlist id="ddlSubject" Runat="server"></asp:dropdownlist>&nbsp;
						<asp:hyperlink id="lnkAdd" Runat="server" NavigateUrl="#">Thêm</asp:hyperlink></TD>
					<TD vAlign="top" align="right"><asp:label id="lblPage" Runat="server">T<u>r</u>ang: </asp:label></TD>
					<TD><asp:textbox id="txtPage" Runat="server" Width="100px"></asp:textbox>&nbsp;</TD>
				</TR>
				<tr>
					<td align="right"><asp:label id="lblDate" Runat="server"><u>N</u>gày nhập: </asp:label></td>
					<td><asp:textbox id="txtDate" Runat="server" Width="160px"></asp:textbox>&nbsp;<asp:hyperlink id="lnkCal" Runat="server" NavigateUrl="#">Lịch</asp:hyperlink></td>
					<td align="right"><asp:Label ID="lblFileAttach" Runat="server"><u>F</u>ile đính kèm:</asp:Label>
					</td>
					<td><asp:TextBox ID="FileAttach" Runat="server" Width="150px" readonly="True"></asp:TextBox>&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="lnkUpload" Runat="server">Browse...</asp:HyperLink></td>
				</tr>
				<tr>
					<td align="right" colspan="3">
					</td>
					<td  colspan="3"><asp:button id="btnDeleteFile" Runat="server" Width="78px" Text="Xoá File"></asp:button>
					</td>
				</tr>
				
				<tr>
					<td colspan="4" align="center">
						<asp:button id="btnInsert" Runat="server" Width="95px" Text="Cập nhật(a)"></asp:button>
						<asp:button id="btnReset" Runat="server" Width="85px" Text="Đặt lại(r)"></asp:button></td>
				</tr>
				<TR>
					<TD class="lbSubformTitle" width="100%" colSpan="4">&nbsp;
						<asp:label id="lblArticle" Runat="server" cssClass="lbSubformTitle">Các cấu thành mục lục</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:datagrid id="dgrResult" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
							<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn Visible="False" HeaderText="Số ID">
									<ItemStyle VerticalAlign="Top"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblIDdt" text='<%# DataBinder.Eval(Container.dataItem,"ID")%>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Nhan đề">
									<ItemStyle Width="20%" VerticalAlign="Top"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblNamedt" text='<%# DataBinder.Eval(Container.dataItem,"Name")%>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="T&#225;c giả">
									<HeaderStyle Width="15%"></HeaderStyle>
									<ItemStyle Width="15%" VerticalAlign="Top"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblAuthordt" text='<%# DataBinder.Eval(Container.dataItem,"Author")%>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								
								<asp:TemplateColumn HeaderText="Chuyên đề">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle Width="15%" VerticalAlign="Top"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblSubjectdt" text='<%# DataBinder.Eval(Container.dataItem,"Subject")%>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Ngày">
									<HeaderStyle Width="15%"></HeaderStyle>
									<ItemStyle Width="15%" VerticalAlign="Top"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblCreatedDate" text='<%# DataBinder.Eval(Container.dataItem,"CreatedDate")%>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Trang">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle Width="4%" VerticalAlign="Top"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblPagedt" text='<%# DataBinder.Eval(Container.dataItem,"Page")%>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Ghi ch&#250;">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle Width="24%" VerticalAlign="Top"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblNotedt" text='<%# DataBinder.Eval(Container.dataItem,"Note")%>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="File đính kèm">
									<HeaderStyle Width="15%"></HeaderStyle>
									<ItemTemplate>
										<a id="link" href="../FileUpload/<%# DataBinder.Eval(Container.dataItem,"ImageURL")%>"><asp:Label ID="lblImageURL" text='<%# DataBinder.Eval(Container.dataItem,"ImageURL")%>' Runat="server"></a>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Chọn">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" Width="4%" VerticalAlign="Top"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="chkIssueID" runat="server" CssClass="lbCheckBox"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Sửa">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:LinkButton runat="server" Text="<img src='../../images/Edit2.gif' border='0'>" CommandName="Edit"
											CausesValidation="false"></asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4">
					<asp:button id="btnDelete" Runat="server" Width="78px" Text="Xoá(x)"></asp:button><asp:button id="btnClose" Runat="server" Text="Đóng(d)"></asp:button></TD>
				</TR>
			</TABLE>
			<input id="hidIssueIDCount" type="hidden" value="0" runat="server"> <input id="hidIDtd" type="hidden" value="0" runat="server">
			<asp:dropdownlist id="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi:</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi:</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
				<asp:ListItem Value="3">Không tồn tại dữ liệu thoả mãn điều kiện tìm kiếm </asp:ListItem>
				<asp:ListItem Value="4">Dữ liệu không phải là kiểu số</asp:ListItem>
				<asp:ListItem Value="5">Cập nhật thông tin về cấu thành mục lục</asp:ListItem>
				<asp:ListItem Value="6">Xoá cấu thành mục lục</asp:ListItem>
				<asp:ListItem Value="7">Bạn chưa nhập đủ thông tin cần thiết</asp:ListItem>
				<asp:ListItem Value="8">Bạn phải chọn ít nhất một cấu thành mục lục!</asp:ListItem>
				<asp:ListItem Value="9">Sai kiểu dữ liệu ngày tháng</asp:ListItem>
			</asp:dropdownlist><input id="hidIssueID" type="hidden" runat="server">
			<asp:label id="lblLabel1" Runat="server" Visible="False">Bạn chưa nhập đủ thông tin cho một cấu thành mục lục</asp:label><asp:label id="lblLabel2" Runat="server" Visible="False">Bạn chưa chọn bản ghi cần xoá</asp:label>
			<input id="hid" type="hidden" name="hid" runat="server">
		</form>
	</body>
</HTML>
