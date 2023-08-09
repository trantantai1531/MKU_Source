<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCheckPatronCodeCI" EnableViewStateMAC="False" CodeFile="WCheckPatronCodeCI.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCheckPatronCode</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" oncontextmenu="return false;">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR class="lblPageTitle">
					<TD colSpan="2">
						<asp:label id="lblPageTitle" runat="server" Width="100%" CssClass="lbPageTitle">Thông tin bạn đọc</asp:label></TD>
				</TR>
				<tr>
					<td height="5">
					</td>
				</tr>
				<TR vAlign="top">
					<TD width="105" vAlign="middle" align="center"><IMG id="imgPatronImage" alt="" src="../../Images/Card/Empty.gif" runat="server"></TD>
					<TD align="left">
						<asp:label id="lblFullName" runat="server" CssClass="lbSubFormTitle" Width="100%"></asp:label>&nbsp;&nbsp;<asp:hyperlink id="lnkDetailInfor" runat="server" CssClass="lbLinkFunction">Thông tin chi tiết</asp:hyperlink>&nbsp;|&nbsp;<asp:hyperlink id="lnkLoanHistory" runat="server" CssClass="lbLinkFunction">Lịch sử mượn</asp:hyperlink>&nbsp;
						<li>
							<asp:label id="lblDOBlb" runat="server">Ngày sinh: </asp:label>&nbsp; <b>
								<asp:label id="lblDOB" runat="server"></asp:label><b>
									<li>
										<asp:label id="lblValidDatelb" runat="server">Ngày cấp thẻ: </asp:label>&nbsp; <b>
											<asp:label id="lblValidDate" runat="server"></asp:label></b>
									<li>
										<asp:label id="lblExpiredDatelb" runat="server">Ngày hết hạn thẻ: </asp:label>&nbsp;
										<b>
											<asp:label id="lblExpiredDate" runat="server"></asp:label></b>
									<li>
										<asp:label id="lblPatronGrouplb" runat="server">Nhóm: </asp:label>&nbsp; <b>
											<asp:label id="lblPatronGroup" runat="server"></asp:label></b>
									<li>
										<asp:label id="lblDebtlb" runat="server">Nợ: </asp:label>
										<b>
											<asp:label id="lblDebt" runat="server"></asp:label></b>
										<asp:hyperlink id="lnkRenew" runat="server" CssClass="lbLinkFunction">&nbsp;Gia hạn thẻ</asp:hyperlink>
								</b></b>
						</li>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2">&nbsp;</TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="99%" border="0" align="right">
				<TR>
					<TD colspan="2">
						<asp:label id="lblLoanHome" CssClass="lbSubFormTitle" Runat="server" Width="100%" Visible="False">Danh sách ấn phẩm đang mượn</asp:label></TD>
				<TR>
					<TD colSpan="2">
						<asp:DataGrid id="dtgResult" runat="server" Width="100%" AutoGenerateColumns="False" AlternatingItemStyle-CssClass="lbGridAlterCell"
							HeaderStyle-CssClass="lbGridHeader" ItemStyle-CssClass="lbGridItem" HeaderStyle-HorizontalAlign="Center">
							<Columns>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:label id="lblCopyNumber" text='<%# DataBinder.Eval(Container.dataItem,"CopyNumber") %>' Runat="server">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" HeaderText="Chọn">
									<ItemTemplate>
										<asp:CheckBox ID="chkCopyNumber" Runat="server" CssClass="lbCheckBox"></asp:CheckBox>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn HeaderText="Nhan đề" DataField="TITLE"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="ĐKCB" DataField="CopyNumber" ItemStyle-Width="8%"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Ngày mượn" DataField="CheckOutDate"
									ItemStyle-Width="13%"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Ngày trả" DataField="DueDate" ItemStyle-Width="10%"></asp:BoundColumn>
								<asp:BoundColumn HeaderText="Ghi chú" DataField="Note" ItemStyle-Width="18%"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<asp:Button id="btnCheckIn" runat="server" Text="Ghi trả(i)" Visible="False" Width="73px"></asp:Button></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<asp:label id="lblLocation" runat="server" Width="100%" CssClass="lbSubFormTitle">Các kho bạn đọc có quyền mượn trả: </asp:label></TD>
				</TR>
			</TABLE>
			<asp:label id="lblJavascript" runat="server"></asp:label>
			<input type="hidden" id="hidPatronCode" runat="server"> <input type="hidden" id="hidCopyNumber" runat="server">
			<input type="hidden" id="hidCheckInDate" runat="server"> <input type="hidden" id="hidAutoPaidFees" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Số thẻ không tồn tại</asp:ListItem>
				<asp:ListItem Value="3">Thẻ đã hết hạn</asp:ListItem>
				<asp:ListItem Value="4">Hết hạn ngạch</asp:ListItem>
				<asp:ListItem Value="5">Thẻ đang bị khoá</asp:ListItem>
				<asp:ListItem Value="6">Trả ấn phẩm thành công</asp:ListItem>
				<asp:ListItem Value="7">Lỗi trong quá trình trả ấn phẩm</asp:ListItem>
				<asp:ListItem Value="8">Quá hạn: </asp:ListItem>
				<asp:ListItem Value="9">(d)</asp:ListItem>
				<asp:ListItem Value="10">Hạn trả mở</asp:ListItem>
				<asp:ListItem Value="11">(h)</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
