<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WSearchPurchaseOrder" CodeFile="WSearchPurchaseOrder.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Libol60 - Search PurchaseOrder</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center" colspan="2">
						<asp:Label CssClass="lbPageTitle" id="lblPageTitle" runat="server" Width="100%">Tìm hợp đồng đặt mua ấn phẩm định kỳ</asp:Label></TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right" width="25%">
						<asp:Label id="lblContractNo" runat="server"><U>M</U>ã số hợp đồng: </asp:Label></TD>
					<TD>
						<asp:TextBox id="txtContractNo" runat="server" Width="280px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblContractName" runat="server"><U>T</U>ên hợp đồng: </asp:Label></TD>
					<TD>
						<asp:TextBox id="txtContractName" runat="server" Width="280px"></asp:TextBox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblFromDate" runat="server"><U>N</U>gày tạo hợp đồng từ: </asp:Label></TD>
					<TD>
						<asp:TextBox id="txtFromDate" runat="server" Width="80px"></asp:TextBox>&nbsp;
						<asp:HyperLink id="lnkFromDate" runat="server">Lịch</asp:HyperLink>&nbsp;
						<asp:Label id="lblToDate" runat="server">đế<U>n</U>: </asp:Label>
						<asp:TextBox id="txtToDate" runat="server" Width="80px"></asp:TextBox>&nbsp;
						<asp:HyperLink id="lnkToDate" runat="server">Lịch</asp:HyperLink></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblBudget" runat="server"><U>Q</U>uỹ: </asp:Label></TD>
					<TD>
						<asp:DropDownList id="ddlBudget" runat="server"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblVendor" runat="server">Nhà <U>c</U>ung cấp: </asp:Label></TD>
					<TD>
						<asp:DropDownList id="ddlVendor" runat="server"></asp:DropDownList></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
					<TD>
						<asp:Button id="btnSearch" runat="server" Width="60px" Text="Tìm(s)"></asp:Button>&nbsp;
						<asp:Button id="btnReset" runat="server" Width="88px" Text="Làm lại(r)"></asp:Button></TD>
				</TR>
				<TR>
					<TD colspan="2">
						<asp:Label id="lblResult" runat="server" CssClass="lbSubformTitle" Width="100%">Kết quả tìm kiếm</asp:Label></TD>
				</TR>
				<TR>
					<TD colspan="2">
						<asp:DataGrid id="dtgResult" runat="server" Width="100%" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateColumn HeaderText="Mã hợp đồng">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink Runat="server" ID="lnkContractCode">
											<%# DataBinder.Eval(Container.dataItem,"ReceiptNo") %>
										</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="POName" HeaderText="Tên hợp đồng"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">--------- Chọn ----------</asp:ListItem>
				<asp:ListItem Value="3">Không có hợp đồng thoả mãn điều kiện tìm kiếm</asp:ListItem>
				<asp:ListItem Value="4">Ngày tháng không hợp lệ</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
