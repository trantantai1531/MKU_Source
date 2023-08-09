<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WFilterPeriodicalForRegister" CodeFile="WFilterPeriodicalForRegister.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WFilterPeriodicalForRegister</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link runat="server" href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Đăng ký</h1>
            <div class="main-form">
            <div class="two-column ClearFix">
                <div class="two-column-form">
                    <div class="row-detail">
                        <p>Ngày phát hành :<asp:HyperLink CssClass="lbLinkFunction" ID="lnkIssuedDate" runat="server">Lịch</asp:HyperLink></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtIssuedDate" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Nước xuất bản :
                            <asp:HyperLink CssClass="lbLinkFunction" ID="lnkPubCountry" runat="server">Từ điển</asp:HyperLink></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtPubCountry" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Ngôn ngữ :
                            <asp:HyperLink CssClass="lbLinkFunction" ID="lnkPubLanguage" runat="server">Từ điển</asp:HyperLink></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtPubLanguage" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="two-column-form">
                    <div class="row-detail">
                        <p>Định kỳ :</p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlRegularity" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Tên nhóm :</p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlGroup" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row-detail">
                <div class="button-control">
                    <div class="button-form">
                        <asp:Button ID="btnSearch" runat="server" Text="Tìm(s)" Width=""></asp:Button>
                    </div>
                    <div class="button-form">
                        <asp:Button ID="btnReset" runat="server" Text="Đặt lại(r)" Width=""></asp:Button>
                    </div>
                </div>
            </div>
            <div class="row-detail">
                <div class="table-form">
                    <div class="table-control">
                        <asp:DataGrid ID="dtgResult" runat="server" Width="100%" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateColumn Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ItemID") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:HyperLinkColumn DataNavigateUrlField="ItemID" DataNavigateUrlFormatString="javascript:OpenRegForm({0})"
                                    DataTextField="TITLE" HeaderText="Nhan đề">
                                    <ItemStyle CssClass="lbLinkFunction"></ItemStyle>
                                </asp:HyperLinkColumn>
                                <asp:BoundColumn DataField="Received" HeaderText="Đăng k&#253;">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </div>
            </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ (dd/mm/yyyy)</asp:ListItem>
            <asp:ListItem Value="3">Bạn chưa nhập điều kiện tìm kiếm</asp:ListItem>
            <asp:ListItem Value="4">---------- Chọn ----------</asp:ListItem>
            <asp:ListItem Value="5">Không tìm thấy ấn phẩm nào cần đăng ký!</asp:ListItem>
            <asp:ListItem Value="6">Bạn không được cấp quyền sử dụng chức năng này.</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtIssuedDate.focus();
    </script>
</body>
</html>
