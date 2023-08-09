<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WCheckDebt" CodeFile="WCheckDebt.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCheckDebt</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellPadding="2" width="100%" border="0">
				<TR id="TR1" runat="server">
					<TD align="center"><asp:label id="lblInValidUser" CssClass="lbAmount" Visible="False" Runat="server">Bạn chưa đăng ký hoặc tài khoản của bạn tạm thời bị khoá</asp:label><asp:label id="lblTitle" CssClass="lbAmount" Visible="False" Runat="server">Những khoản cần thanh toán</asp:label></TD>
				</TR>
				<TR id="TR2" runat="server">
					<TD><asp:datagrid id="dgrResult" runat="server" AutoGenerateColumns="False" Width="100%">
							<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
							<ItemStyle CssClass="lbGridCell"></ItemStyle>
							<HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
							<EditItemStyle CssClass="lbGridEdit"></EditItemStyle>
							<Columns>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:Label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="">
									<HeaderStyle Width="5%"></HeaderStyle>
									<HeaderTemplate>
										<input class="lbCheckBox" type="checkbox" id="CheckAll" onclick="CheckAllItems('dgrResult','chkID',2);">
									</HeaderTemplate>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox CssClass="lbCheckBox" ID="chkID" Runat="server" Enabled="True"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Số tiền">
									<HeaderStyle Width="25%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblAmount" Text='<%# DataBinder.Eval(Container.DataItem, "Price") & " (" & DataBinder.Eval(Container.DataItem, "Currency") & ")"%>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Rate" HeaderText="Tỷ giá">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Thông tin ấn phẩm đã đặt">
									<HeaderStyle Width="60%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblSize" Text='<%# DataBinder.Eval(Container.DataItem, "Title") & " (" & DataBinder.Eval(Container.DataItem, "FileName") & ", " & CDbl(DataBinder.Eval(Container.DataItem, "FILESIZE")) & " bytes, " & DataBinder.Eval(Container.DataItem, "Price") &  " " & DataBinder.Eval(Container.DataItem, "Currency") & ")"%>' Runat="server" >
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR id="TR3" runat="server">
					<TD align="center"><asp:label id="lblUserDebt" CssClass="lbAmount" Runat="server"></asp:label>&nbsp;<asp:label id="lblDebt" CssClass="lbAmount" Runat="server"></asp:label><asp:label id="lblTemp1" CssClass="lbAmount" Visible="False" Runat="server">Số tiền bạn còn nợ:</asp:label><asp:label id="lblTemp2" CssClass="lbAmount" Visible="False" Runat="server">Số dư của bạn là:</asp:label></TD>
				</TR>
				<TR>
					<td align="center">
						<asp:Button Runat="server" ID="btnAdd" Text="Nhập thông tin (n)" Visible="False"></asp:Button>&nbsp;
						<asp:Button Runat="server" ID="btnClose" Text="Đóng (c)"></asp:Button>
					</td>
				</TR>
				<tr>
					<td><input id="hidRecordNum" type="hidden" runat="server"> <INPUT id="hidIDs" type="hidden" runat="server"><INPUT id="hidTotal" type="hidden" runat="server" value="0"><INPUT id="hidFiles" type="hidden" runat="server">
						<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
							<asp:ListItem Value="0">Thanh toán cho danh sách ấn phẩm điện tử sau:</asp:ListItem>
							<asp:ListItem Value="1">Phải chọn những yêu cầu cần thanh toán</asp:ListItem>
							<asp:ListItem Value="2">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
							<asp:ListItem Value="3">Mã lỗi</asp:ListItem>
							<asp:ListItem Value="4">Chi tiết lỗi</asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
