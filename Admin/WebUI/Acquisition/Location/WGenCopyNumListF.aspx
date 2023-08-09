<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WGenCopyNumListF" CodeFile="WGenCopyNumListF.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Danh sách đăng ký cá biệt</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="5" topmargin="5">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Tạo danh sách đăng ký cá biệt</h1>
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Thư viện :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLibrary" runat="server" AutoPostBack="True"></asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Kho :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLocation" runat="server"></asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Giá sách :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtShelf" runat="server" Width=""></asp:TextBox>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Từ ĐKCB :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txttoCopyNum" runat="server"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Đến ĐKCB :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtfromCopyNum" runat="server"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Số ĐKCB / trang :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCopyNum1Page" runat="server" Width="">20</asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>



                <div class="row-detail ClearFix">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnGenList" runat="server" Text="Tạo danh sách(t)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" runat="server" Text="Đặt lại(r)" Width=""></asp:Button>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:DropDownList ID="ddlLabelNote" runat="server" Visible="False" Width="0px">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="3">Dữ liệu không phải kiểu số</asp:ListItem>
            <asp:ListItem Value="4">----- Chọn -----</asp:ListItem>
            <asp:ListItem Value="5">Số ĐKCB/trang phải lớn hơn 0</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
