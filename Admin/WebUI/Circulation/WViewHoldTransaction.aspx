<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WViewHoldTransaction" CodeFile="WViewHoldTransaction.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Yêu cầu đặt chỗ</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0" onMouseOver="document.all.marMsg.stop()"
		onMouseOut="document.all.marMsg.start()">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<tr>
					<td align="left">
						<asp:Label ID="lblTitle" Runat="server" CssClass="main-group-form" Width="100%">Yêu cầu đặt chỗ</asp:Label>
					</td>
				</tr>

					<TR>
					<td>
						<asp:datagrid id="dgrOrderResult" runat="server" Width="100%" AutoGenerateColumns="False">
							<Columns>
                            
								<asp:TemplateColumn HeaderText="STT" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center">
									<HeaderStyle width="3%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblSTT" text='<%# DataBinder.Eval(Container.DataItem, "STT")%>' Runat="server">
										</asp:label>
									</ItemTemplate>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Tài liệu đặt chỗ" >
									<ItemTemplate>
										<asp:label ID="lblItemTitle" text='<%# DataBinder.Eval(Container.DataItem, "CONTENT")%>' Runat="server">
										</asp:label>
									</ItemTemplate>
								    <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Người đặt mượn" ItemStyle-VerticalAlign="Top">
									<HeaderStyle width="17%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblLoanner" text='<%# DataBinder.Eval(Container.dataItem,"FullName")%>' Runat="server">
										</asp:label>
									</ItemTemplate>

<ItemStyle VerticalAlign="Top" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center"></ItemStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Số thẻ" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center">
									<HeaderStyle width="8%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblCode" text='<%# DataBinder.Eval(Container.DataItem, "PatronCode")%>' Runat="server">
										</asp:label>
									</ItemTemplate>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Thời điểm" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center">
									<HeaderStyle width="8%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblCreatedDate" text='<%# DataBinder.Eval(Container.DataItem, "DateCreate")%>' Runat="server">
										</asp:label>
									</ItemTemplate>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<HeaderStyle width="0%"></HeaderStyle>
									<ItemTemplate>
										<asp:label ID="lblHidden" text='<%# DataBinder.Eval(Container.DataItem, "ID")%>' Runat="server" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Chọn" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top">
									<HeaderStyle width="5%" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                    <ItemStyle VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<input type = "checkbox" CssClass="lbCheckBox" ID="chkCheck" Runat="server" Enabled="True"></input>
                                        <label for="checkbox"></label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</TR>
                <tr>
                    <asp:DataGrid CssClass="table-control" ID="dtgResult" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateColumn HeaderText="STT">
                                <HeaderStyle Width="3%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"ID")%>'>
                                    </asp:Label>
                                    <asp:Label ID="lblSTT" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STT")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Bạn đọc">
                                <HeaderStyle  Width="16%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblPatronName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FullName")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Số thẻ">
                                <HeaderStyle  Width="7%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkPatronCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PatronCode")%>'>
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Nhan đề">
                                <HeaderStyle  Width="20%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lnkTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Content")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ĐKCB" Visible="false">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <%--<asp:Label ID="lblCopyNumber" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"CopyNumber")%>'>
                                    </asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Thời điểm đặt chỗ">
                                <HeaderStyle  Width="12%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateCreate")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="false" SortExpression="TIMEOUTDATE" HeaderText="Thời điểm hết lượt">
                                <HeaderStyle  Width="12%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblTimeOutDate" runat="server" Text='<%--<%# DataBinder.Eval(Container.dataItem,"TimeOutDate")%>--%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Hiệu lực tới ngày">
                                <HeaderStyle  Width="12%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblExpiredDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateExpire")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="false" HeaderText="Trạng th&#225;i">
                                <HeaderStyle Width="12%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblStatusDisplay" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="False" HeaderText="Trạng th&#225;i">
                                <HeaderStyle Width="5%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Visible="False" Text='<%--<%# DataBinder.Eval(Container.dataItem,"InTurn")%>--%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="R&#250;t lượt" Visible="false">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" CommandName="btnOutTurn" ID="btnOutTurn" ImageUrl="../../Images/button.gif"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Chuyển lượt" Visible="false">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" CommandName="btnChangeTurn" ImageUrl="../../images/gia.gif" ID="btnChangeTurn"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Xo&#225;" HeaderStyle-Width="5%">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" Text="<img src='../images/delete.gif' border='0'>" CommandName="Delete"
                                        CausesValidation="false" ID="lnkdtgDelete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Position="TopAndBottom" CssClass="lbGridPager" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                </tr>
				<tr align="center">
					<td>
						<asp:button id="btnDeleteOrder" Runat="server" Text="Xoá yêu cầu(d)" Width="108px"></asp:button>
						<asp:button id="btnClose" Runat="server" Text="Đóng(o)" Width="64px"></asp:button></td>
				</tr>
				<asp:label Visible="False" Runat="server" ID="lblLabel1">ĐKCB rỗi:&nbsp;</asp:label>
				<asp:label Visible="False" Runat="server" ID="lblLabel2">Tất cả các ĐKCB đều bận</asp:label>
				<asp:label Visible="False" Runat="server" ID="lblMsg1">Bạn phải nhập dữ liệu kiểu số!</asp:label>
				<asp:label Visible="False" Runat="server" ID="lblMsg2">Bạn chưa nhập số giây!</asp:label>
				<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
					<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
					<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
					<asp:ListItem Value="2">ĐKCB rỗi:&nbsp;</asp:ListItem>
					<asp:ListItem Value="3">Tất cả các ĐKCB đều bận</asp:ListItem>
					<asp:ListItem Value="4">Sai kiểu dữ liệu (số)</asp:ListItem>
					<asp:ListItem Value="5">Bạn chưa nhập thời gian chờ (giây)</asp:ListItem>
					<asp:ListItem Value="6">Tài liệu:</asp:ListItem>
					<asp:ListItem Value="7">đang được</asp:ListItem>
					<asp:ListItem Value="8">đặt mượn vào thời điểm </asp:ListItem>
					<asp:ListItem Value="9">Hiện tại không có yêu cầu đặt mượn nào.</asp:ListItem>
				</asp:DropDownList>
			</TABLE>
		</form>
	</body>
</HTML>
