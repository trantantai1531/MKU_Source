<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WRequestList"
    CodeFile="WRequestList.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Các yêu cầu đang xử lý</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body onkeydown="return microsoftKeyPress();" leftmargin="0" topmargin="0" onload="parent.document.getElementById('frmMain').setAttribute('rows','*,28'); if(document.forms[0].hidHasItem.value>0) {if (eval(document.forms[0].rdoRequest[0])){document.forms[0].rdoRequest[0].click();} else if (eval(document.forms[0].rdoRequest)){document.forms[0].rdoRequest.click();}}">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div class="center-form">
            <div class="main-body ClearFix">
                <div class="content-form">
                    <div class="main-form">
                        <div class="ClearFix main-page">
                            <h1 class="main-head-form">
                                Yêu cầu đến</h1>
                        </div>
                        <div class="two-column ClearFix">
                            <div class="two-column-form">
                                <div class="row-detail">
                                    <asp:Label ID="lblMainTitle" runat="server" CssClass="lbPageTitle">Các yêu cầu đang xử lý: </asp:Label>
                                </div>
                                <asp:Label ID="lblFilter" runat="server" CssClass="lbPageTitle" Visible="False">Kết quả lọc theo yêu cầu mua</asp:Label>
                                <asp:Label ID="Label1" runat="server" CssClass="lbAmount" Font-Size="13pt"></asp:Label>
                                <asp:Label ID="lblProcess" runat="server" CssClass="lbAmount" Font-Size="13pt"></asp:Label>
                                <asp:Label ID="lblAmount" runat="server" CssClass="lbAmount" Visible="False" Font-Size="13pt"></asp:Label>
                            </div>
                            <div class="two-column-form">
                                <div class="row-detail">
                                    <div class="row-detail">
                                        <asp:Label ID="lblStatus" runat="server" ForeColor="black"><U>T</U>hư mục: </asp:Label>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblFilterTotal" runat="server" Visible="False" ForeColor="white">Tổng số: </asp:Label>
                                                <asp:Label ID="lblFilterAmount" runat="server" CssClass="lbAmount" Visible="False">
                            
                                                </asp:Label>
                                                <asp:Label ID="lblRecord" runat="server" Visible="False"> bản ghi.</asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="input-control row-detail">
                            <div class="table-form">
                                <asp:DataGrid ID="dgtRequest" runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateColumn>
                                            <HeaderStyle Width="5%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRadio" runat="server">
											<%# DataBinder.Eval(Container.dataItem,"rdoRequest")%>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Thông tin về ấn phẩm / Bạn đọc" SortExpression="Title">
                                            <HeaderStyle Width="50%" ForeColor="#444"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                <asp:HyperLink runat="server" ID="lnkTitle" CssClass="lbLinkFunction" NavigateUrl="#">
											<%# DataBinder.Eval(Container.DataItem, "FileName")%>
                                                </asp:HyperLink>
                                                <asp:Label ID="lblCustomer" runat="server" Text='<%# "<BR><I>" & ddlLabel.Items(0).text & "</I>" & DataBinder.Eval(Container.DataItem, "Customer") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Ngày tạo yêu cầu" SortExpression="CREATEDDATE">
                                            <HeaderStyle Width="15%" ForeColor="#444"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CREATEDDATE")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Trạng thái" SortExpression="Status">
                                            <HeaderStyle Width="13%" ForeColor="#444"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatusDisplay" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Phương thức nhận file" SortExpression="EMode">
                                            <HeaderStyle Width="17%" ForeColor="#444"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblMode" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"RequestID") %>'
                                                    runat="server">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn Visible="False">
                                            <HeaderStyle Width="13%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatusTemp" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status") %>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn Visible="False">
                                            <HeaderStyle Width="17%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblModeTemp" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"EMode")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn Visible="False">
                                            <HeaderStyle Width="17%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblCreatedDateTemp" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"CREATEDDATE_")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn Visible="False">
                                            <HeaderStyle Width="17%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblExpiredDateTemp" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"EXPIREDDATE_")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn Visible="False">
                                            <HeaderStyle Width="17%"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblExpiredDate" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"EXPIREDDATE")%>'>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
                                </asp:DataGrid>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <table id="Table1" cellspacing="0" cellpadding="2" width="100%" border="0">
        <tr class="lbPageTitle">
            <td>
                <%--<asp:label id="lblMainTitle" Runat="server" CssClass="lbPageTitle">Các yêu cầu đang xử lý: </asp:label>--%>
                <%-- <asp:label id="lblFilter" Runat="server" CssClass="lbPageTitle" Visible="False">Kết quả lọc theo yêu cầu mua</asp:label>--%>
                <%--   <asp:label id="lblProcess" Runat="server" CssClass="lbAmount" Font-Size="13pt"></asp:label>
                    <asp:label id="lblAmount" Runat="server" CssClass="lbAmount" Visible="False" Font-Size="13pt"></asp:label>
                --%>
            </td>
            <td align="right">
                <%--  <asp:label id="lblStatus" Runat="server" ForeColor="white"><U>T</U>hư mục: </asp:label>--%>
                <%--  <asp:dropdownlist id="ddlStatus" Runat="server" AutoPostBack="True">
                            
                        </asp:dropdownlist>
                        <asp:label id="lblFilterTotal" Runat="server" Visible="False" ForeColor="white">Tổng số: </asp:label>
                        <asp:label id="lblFilterAmount" Runat="server" CssClass="lbAmount" Visible="False">
                            
                        </asp:label>
                        <asp:label id="lblRecord" Runat="server" Visible="False"> bản ghi.</asp:label>--%>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <%--<asp:datagrid id="dgtRequest" Runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:Label ID="lblRadio" Runat="server">
											<%# DataBinder.Eval(Container.dataItem,"rdoRequest")%>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Thông tin về ấn phẩm / Bạn đọc" SortExpression="Title">
									<HeaderStyle Width="50%" ForeColor="#444"></HeaderStyle>
									<ItemTemplate>
										<asp:Label ID="lblTitle" Runat="server"></asp:Label>
										<asp:HyperLink Runat="server" ID="lnkTitle" CssClass="lbLinkFunction" NavigateUrl="#">
											<%# DataBinder.Eval(Container.DataItem, "FileName")%>
										</asp:HyperLink>
										<asp:label ID="lblCustomer" Runat="server" Text='<%# "<BR><I>" & ddlLabel.Items(0).text & "</I>" & DataBinder.Eval(Container.DataItem, "Customer") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Ngày tạo yêu cầu" SortExpression="CREATEDDATE">
									<HeaderStyle Width="15%" ForeColor="#444"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label ID="lblDate" Runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CREATEDDATE")%>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Trạng thái" SortExpression="Status">
									<HeaderStyle Width="13%" ForeColor="#444"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label ID="lblStatusDisplay" Runat="server"></asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Phương thức nhận file" SortExpression="EMode">
									<HeaderStyle Width="17%" ForeColor="#444"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label ID="lblMode" Runat="server"></asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"RequestID") %>' Runat="server">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<HeaderStyle Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label ID="lblStatusTemp" Runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Status") %>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<HeaderStyle Width="17%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label ID="lblModeTemp" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"EMode")%>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<HeaderStyle Width="17%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label ID="lblCreatedDateTemp" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"CREATEDDATE_")%>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<HeaderStyle Width="17%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label ID="lblExpiredDateTemp" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"EXPIREDDATE_")%>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<HeaderStyle Width="17%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:label ID="lblExpiredDate" Runat="server" text='<%# DataBinder.Eval(Container.dataItem,"EXPIREDDATE")%>'>
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>--%>
            </td>
        </tr>
    </table>
    <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
        <asp:ListItem Value="0">Người đặt: </asp:ListItem>
        <asp:ListItem Value="1">Xóa</asp:ListItem>
        <asp:ListItem Value="2">Gửi thông điệp</asp:ListItem>
        <asp:ListItem Value="3">Gửi file</asp:ListItem>
        <asp:ListItem Value="4">Gửi thư từ chối</asp:ListItem>
        <asp:ListItem Value="5">Gửi hoá đơn</asp:ListItem>
        <asp:ListItem Value="6">Đổi trạng thái</asp:ListItem>
        <asp:ListItem Value="7">In nhãn đóng gói</asp:ListItem>
        <asp:ListItem Value="8">Gửi thư nhắc trả tiền</asp:ListItem>
        <asp:ListItem Value="9">Chuyển sang thư mục thích hợp</asp:ListItem>
        <asp:ListItem Value="10">Chuyển sang yêu cầu huỷ</asp:ListItem>
        <asp:ListItem Value="11">Các yêu cầu đang xử lý</asp:ListItem>
        <asp:ListItem Value="12">(hết hạn)</asp:ListItem>
        <asp:ListItem Value="13">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
        <asp:ListItem Value="14">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="15">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="16">trong:</asp:ListItem>
    </asp:DropDownList>
    <input id="hidRequestID" type="hidden" runat="server" name="hidRequestID">
    <input id="hidColSort" type="hidden" name="hidColSort" runat="server">
    <input id="hidHasItem" runat="server" type="hidden" name="hidHasItem">
    </form>
</body>
</html>
