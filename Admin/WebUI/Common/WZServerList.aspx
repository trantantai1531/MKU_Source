<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Common.WZServerList" CodeFile="WZServerList.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Danh sách máy chủ Z39.50</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="2" cellspacing="1">
				<tr class="lbPageTitle">
					<td align="center">
					    <h1 class="main-group-form"><asp:Label id="lblHeader" runat="server" CssClass="lbPageTitle">Danh sách Z39.50 Server</asp:Label></h1>
					</td>
				</tr>
				<TR>
					<TD align="right">
						<asp:Button id="btnClose" runat="server" Text="Ðóng(d)" Width="70px"></asp:Button></TD>
				</TR>
				<tr>
					<td align="center">
						<asp:DataGrid id="dtgZDbs" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyField="Z3950ServerID">
							<Columns>
								<asp:BoundColumn DataField="Name" HeaderText="T&#234;n thư viện">
									<HeaderStyle Wrap="False"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Host" HeaderText="Đường dẫn">
									<HeaderStyle Wrap="False"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Port" HeaderText="Port">
									<HeaderStyle Wrap="False"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Account" HeaderText="Tài khoản">
									<HeaderStyle Wrap="False"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Password" HeaderText="Mật khẩu">
									<HeaderStyle Wrap="False"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DBName" HeaderText="Tên Database">
									<HeaderStyle Wrap="False"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Description" HeaderText="Mô tả">
									<HeaderStyle Wrap="False"></HeaderStyle>
									<ItemStyle Wrap="False"></ItemStyle>
								</asp:BoundColumn>
                                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src='../../images/update.gif' border='0'&gt;"
                                    HeaderText="Sửa" CancelText="&lt;img src='../../images/cancel.gif' border='0'&gt;"
                                    EditText="&lt;img src='../../images/edit2.gif' border='0'&gt;">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:EditCommandColumn>
                                <asp:ButtonColumn Text="&lt;img src='../../images/delete.gif' border='0'&gt;" HeaderText="Xo&#225;"
                                    CommandName="Delete">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonColumn>
								<asp:HyperLinkColumn Text="&lt;Img src='../images/select.jpg' border='0'&gt;" DataNavigateUrlField="LoadBack"
									HeaderText="Chọn">
									<ItemStyle Width="8%"></ItemStyle>
								</asp:HyperLinkColumn>
							</Columns>
						</asp:DataGrid>
					</td>
				</tr>
                <tr>
                    <td align="center">
                        <br />
                        <h1 class="main-group-form"><asp:Label id="LabelNew" runat="server" CssClass="lbPageTitle">Thêm mới thư viện Z39.50 Server</asp:Label></h1>
                    </td>
                </tr>
			</table>
            
            <div class="three-column">
                <div class="three-column-form">
                    <div class="row-detail">
                        <p>Tên thư viện</p>
                        <div class="input-control">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="three-column-form">
                    <div class="row-detail">
                        <p>Đường dẫn</p>
                        <div class="input-control">
                            <asp:TextBox ID="txtHost" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="three-column-form">
                    <div class="row-detail">
                        <p>Port</p>
                        <div class="input-control">
                            <asp:TextBox ID="txtPort" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="three-column">
                <div class="three-column-form">
                    <div class="row-detail">
                        <p>Tài khoản</p>
                        <div class="input-control">
                            <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="three-column-form">
                    <div class="row-detail">
                        <p>Mật khẩu</p>
                        <div class="input-control">
                            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="three-column-form">
                    <div class="row-detail">
                        <p>Tên Database</p>
                        <div class="input-control">
                            <asp:TextBox ID="txtDBName" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="two-column">
                <div class="two-column-form">
                    <div class="row-detail">
                        <p>Mô tả</p>
                        <div class="input-control">
                            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="two-column-form">
                    <div class="row-detail" style="text-align:right;">
                        <p>&nbsp;</p>
                        <div class="button-control">
                            <asp:Button ID="btnNew" runat="server" Text="Thêm mới" />
                        </div>
                    </div>
                    
                </div>
            </div>
			<asp:dropdownlist id="ddlLabelNote" runat="server" Visible="False" Height="0" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
			</asp:dropdownlist>
            <asp:DropDownList ID="ddlLabel" runat="server" Visible="False">
                <asp:ListItem Value="0">Thêm mới thành công</asp:ListItem>
                <asp:ListItem Value="1">Thêm mới thất bại</asp:ListItem>
                <asp:ListItem Value="2">Cập nhật thành công</asp:ListItem>
                <asp:ListItem Value="4">Cập nhật thất bại</asp:ListItem>
            </asp:DropDownList>
		</form>
	</body>
</HTML>
