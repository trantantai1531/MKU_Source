<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WFilterPeriodicalForReceive" CodeFile="WFilterPeriodicalForReceive.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WFilterPeriodicalForReceive</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link runat="server" href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link runat="server" href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
		 <div id="divBody">
            <h1 class="main-head-form">Ghi nhận</h1>
             <div class="main-form">
            <div class="two-column ClearFix">
                <div class="two-column-form">
                    <div class="row-detail">
                        <p>Ngày phát hành : <asp:hyperlink id="lnkIssuedDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:hyperlink></p>
                        <div class="input-control">
                            <div class="input-form ">
<asp:textbox CssClass="text-input" id="txtIssuedDate" runat="server" Width=""></asp:textbox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Ngày nhận :<asp:hyperlink id="lnkReceivedDate" runat="server">Lịch</asp:hyperlink></p>
                        <div class="input-control">
                            <div class="input-form ">
                                						<asp:textbox CssClass="text-input" id="txtReceivedDate" runat="server" Width="88px"></asp:textbox>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="two-column-form">
                    <div class="row-detail">
                        <p>Kho :</p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:dropdownlist id="ddlLocation" runat="server"></asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row-detail">
                <div class="button-control">
                    <div class="button-form">
                       						<asp:Button id="btnSearch" runat="server" Width="" Text="Tìm kiếm(s)"></asp:Button>
                    </div>
                </div>
            </div>
             <div class="row-detail">
                 <div class="table-form">
                     <asp:DataGrid id="dtgResult" CssClass="table-control" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center"
							ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="lbGridHeader" ItemStyle-CssClass="lbGridCell"
							AlternatingItemStyle-CssClass="lbGridAlterCell" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
							<ItemStyle HorizontalAlign="Center" CssClass="lbGridCell"></ItemStyle>
							<HeaderStyle HorizontalAlign="Center" CssClass="lbGridHeader"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:label id="lblItemID" runat="server"></asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:HyperLinkColumn DataNavigateUrlField="URL" DataNavigateUrlFormatString="javascript:OpenRegForm('{0}')"
									DataTextField="TITLE" HeaderText="Nhan đề">
									<ItemStyle CssClass="lbLinkFunction"></ItemStyle>
								</asp:HyperLinkColumn>
								<asp:BoundColumn DataField="IssueNo" HeaderText="Số">
									<ItemStyle Width="20%"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Recevied" HeaderText="Nhận đủ">
									<ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:DataGrid>
                 </div>

             </div>
                 </div>
        </div>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ (dd/mm/yyyy)</asp:ListItem>
				<asp:ListItem Value="3">Bạn chưa nhập thông tin tìm kiếm !</asp:ListItem>
				<asp:ListItem Value="4">Không tìm thấy ấn phẩm nào cần ghi nhận</asp:ListItem>
				<asp:ListItem Value="5">Bạn không được cấp quyền sử dụng chức năng này.</asp:ListItem>
			</asp:DropDownList>
		</form>
		<script language="javascript">
			document.forms[0].txtIssuedDate.focus();
		</script>
	</body>
</HTML>
