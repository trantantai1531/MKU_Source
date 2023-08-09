<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WORServReport" CodeFile="WORServReport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WORServReport</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tblIRSerReport" borderColor="#c0c0c0" cellSpacing="1" cellPadding="0" width="100%"
				border="0">
				<tr class="lbPageTitle">
					<td width="100%">
						<asp:label id="lblMainTitle" Width="100%" CssClass="main-head-form" Runat="server">Báo cáo mức độ phục vụ</asp:label></td>
				</tr>
				<tr>
					<td align="center" width="100%">
						<table borderColor="#c0c0c0" cellSpacing="1" cellPadding="0" width="100%" border="0">
							<TBODY>
								<TR>
									<TD align="center"><asp:label id="lblRequestAddress" Runat="server" CssClass="lbGroupTitle" Width="100%">Nơi nhận yêu cầu</asp:label></TD>
									<TD align="center" colSpan="4" Class="lbGroupTitle"><asp:label id="lblTotal" Runat="server" CssClass="lbGroupTitle" Width="100%">Tổng số</asp:label></TD>
									<TD align="center" colSpan="4" Class="lbGroupTitle"><asp:label id="lblLen" Runat="server" CssClass="lbGroupTitle" Width="100%">Mượn/Có trả lại</asp:label></TD>
									<TD align="center" colSpan="4" Class="lbGroupTitle"><asp:label id="lblCopy" Runat="server" CssClass="lbGroupTitle" Width="100%">Sao chụp/Không trả lại</asp:label></TD>
								</TR>
								<tr valign="top">
									<td align="center" colSpan="1" width="10%">
									    <div class="table-form">
									        
									   
									    <asp:datagrid id="dgrLibName" Width="100%" Runat="server" AutoGenerateColumns="False">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="LibrarySymbol" HeaderText="Tên thư viện ILL">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
										</asp:datagrid> </div>
									</td>
									<td align="center" colSpan="4">
									     <div class="table-form">
									        
									    <asp:datagrid id="dgr1" Width="100%" Runat="server" AutoGenerateColumns="False">
											<FooterStyle Wrap="False"></FooterStyle>
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="inR1" HeaderText="Gửi đi">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="outR1" HeaderText="Đáp ứng">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="scaleR1" HeaderText="Tỉ lệ đáp ứng(%)">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="timeR1" HeaderText="Thời gian trả lời">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
										</asp:datagrid></div>
									</td>
									<td align="center" colSpan="4">
									    <div class="table-form">
									        
									    <asp:datagrid id="dgr2" Width="100%" Runat="server" AutoGenerateColumns="False">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="inR2" HeaderText="Gửi đi">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="outR2" HeaderText="Đáp ứng">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="scaleR2" HeaderText="Tỉ lệ đáp ứng (%)">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="timeR2" HeaderText="Thời gian trả lời">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
										</asp:datagrid></div>
									</td>
									<td align="center" colSpan="4">
									    <div class="table-form">
									       
									    <asp:datagrid id="dgr3" Width="100%" Runat="server" AutoGenerateColumns="False">
											<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="inR3" HeaderText="Gửi đi">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="outR3" HeaderText="Đáp ứng">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="scaleR3" HeaderText="Tỉ lệ đáp ứng (%)">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="timeR3" HeaderText="Thời gian trả lời">
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
										</asp:datagrid> </div>
									</td>
								</tr>
							</TBODY>
						</table>
					</td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền khai thác chức năng này.</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
