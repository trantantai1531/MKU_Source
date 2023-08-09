<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WReportOnLoanCopy" CodeFile="WReportOnLoanCopy.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WReportOnLoanCppy</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="5" topmargin="0" rightmargin="5">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Thông tin ấn phẩm đang được mượn</h1>
            <div class="main-form">
                <div class="three-column ClearFix">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Số thẻ :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtPatronCode" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Mã tài liệu :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtItemCode" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Đăng ký cá biệt :</p>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtCopyNumber" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>
                                Mượn từ ngày :
                            <asp:HyperLink ID="lnkCheckOutDateFrom" runat="server">Lịch</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCheckOutDateFrom" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                Tới :
                            <asp:HyperLink ID="lnkCheckOutDateTo" runat="server">Lịch</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCheckOutDateTo" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tìm trong kho :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLocation" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Trả từ ngày :
                                <asp:HyperLink ID="lnkDueDateFrom" runat="server">Lịch</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCheckInDateFrom" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                Tới :
                            <asp:HyperLink ID="lnkDueDateTo" runat="server">Lịch</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCheckInDateTo" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="button-control" style="text-align: center">
                                <div class="button-form">
                                    <asp:Button ID="btnFind" runat="server" CssClass="lbButton" Text="Tìm(t)"></asp:Button>
                                </div>
                                <div class="button-form">
                                    <asp:Button ID="btnCancel" runat="server" CssClass="lbButton" Text="Đặt lại(d)"></asp:Button>
                                </div>
                                <div class="button-form">
                                    <asp:Button ID="btnExport" runat="server" Text="Xuất file(t)"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail" style="font-weight:bold;">
                    <asp:Label ID="lblTitleDataGrid" runat="server" CssClass="lbSubFormTitle">Danh sách ấn phẩm đang được mượn</asp:Label><asp:Label ID="lblTotallb" runat="server" Visible="False" CssClass="lbSubFormTitle">Tổng số:&nbsp;</asp:Label><asp:Label ID="lblTotal" runat="server" Font-Bold="true" Visible="False" CssClass="lbSubFormTitle"></asp:Label>
                </div>
                <div class="row-detail" style="text-align:center;">
                    <asp:Label ID="lblNothing" runat="server" Visible="False"> Không tồn tại dữ liệu thoả mãn điều kiện tìm kiếm</asp:Label>
                </div>
                <div class="ClearFix table-form">
                    <asp:DataGrid ID="dtgLoan" CssClass="table-control" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        Width="100%" PagerStyle-Mode="NumericPages" AllowCustomPaging="true">
                        <Columns>
                            <asp:TemplateColumn  HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="3%">
                                <ItemTemplate>
                                    <asp:Label ID="lblSTT" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Title" HeaderText="Nhan đề" HeaderStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CopyNumber" HeaderText="ĐKCB" HeaderStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn DataField="FullName" HeaderText="Họ và tên" HeaderStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn DataField="PatronCode" HeaderText="Mã số thẻ" HeaderStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn DataField="CheckOutDate" HeaderText="Ngày mượn" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" DataFormatString="{0:dd/MM/yyyy}">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CheckInDate" HeaderText="Hạn trả" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" DataFormatString="{0:dd/MM/yyyy}">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CataloguerNameCheckOut" HeaderText="Thủ thư quét ghi mượn" HeaderStyle-Width="15%"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn phải nhập dữ liệu kiểu số!</asp:ListItem>
            <asp:ListItem Value="3">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="4">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="5">Tất cả các kho</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script type="text/javascript">
        document.forms[0].txtPatronCode.focus();
    </script>
</body>
</html>
