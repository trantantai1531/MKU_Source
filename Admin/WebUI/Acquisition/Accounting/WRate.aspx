<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WRate" CodeFile="WRate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Tỷ giá hạch toán</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Tỷ giá hạch toán</h1>
                <div class="row-detail">
                    <p>Đơn vị tiền tệ :</p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtUnitMoney" CssClass="text-input" runat="server" MaxLength="10"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Tỷ giá hạch toán :</p>
                    <div class="input-control">
                        <div class="input-form ">

                            <asp:TextBox ID="txtRate" CssClass="text-input" runat="server">1</asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnUpdate" runat="server" Text="Tạo mới(c)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" runat="server" Text="Làm lại(r)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:button id="btnClose" Runat="server" Text="Đóng(o)" Width=""></asp:button>
                        </div>
                    </div>
                </div>

                <div class="input-control row-detail">
                    <div class="table-form">
                        <asp:DataGrid ID="dtgContent" CssClass="table-control" runat="server" Width="100%" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn DataField="CurrencyCode" ReadOnly="True" HeaderText="Đơn vị tiền tệ">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Tỷ giá">
                                    <HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Rate") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtdtgRate" CssClass="lbTextBox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Rate") %>'>1</asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Thay đổi" ItemStyle-Width="8%">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="<image src ='../../Images/Edit2.gif' border=0 title='Sửa đổi'>"
                                            CommandName="Edit" CausesValidation="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkdtgUpdate" runat="server" Text="<Image src ='../../Images/update.gif' title='Cập nhật' border=0>"
                                            CommandName="Update"></asp:LinkButton>&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='../../Images/Cancel.gif' title='Thôi' border=0>"
                                            CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </div>
            </div>
        </div>

        <asp:DropDownList ID="ddlLabelNote" runat="server" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">Trường thông tin bắt buộc nhập!</asp:ListItem>
            <asp:ListItem Value="1">Kiểu dữ liệu không hợp lệ (số)</asp:ListItem>
            <asp:ListItem Value="2">Đơn vị tiền tệ này đã tồn tại trong CSDL hoặc lỗi trong quá trình xử lý!</asp:ListItem>
            <asp:ListItem Value="3">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="4">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="5">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="6">Tạo mới tiền tệ</asp:ListItem>
            <asp:ListItem Value="7">Cập nhật lại tỷ giá hách toán của tiền tệ</asp:ListItem>
            <asp:ListItem Value="8">Cập nhật thông tin thành công!</asp:ListItem>
        </asp:DropDownList>
        <input id="hidCurrencyCode" runat="server" name="hidCurrencyCode" type="hidden">
        <script language='javascript'>
            document.forms[0].txtUnitMoney.value = '';
            document.forms[0].txtUnitMoney.focus();
            document.forms[0].txtRate.value = '1';
        </script>
    </form>
</body>
</html>
