<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WAddPatron" CodeFile="WAddPatron.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WAddPatron</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
 
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody" style="margin-left: 20px">
            <h2 class="main-head-form">Kiểm tra thông tin bạn đọc</h2>
            <div class="main-form">
                <div class="two-column">
                    <div class="two-column-form">
                        <div class="row-detail two-column ClearFix">
                            <div style="width:49.5%; display:inline-block;">
                                <asp:Label ID="lblPatronGroup" runat="server">Nhó<U>m</U>: </asp:Label><asp:HyperLink ID="lnkViewPatronGroup" runat="server">Xem</asp:HyperLink><span style="color: red;">(*)</span>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlPatronGroup" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div style="width:49.5%; display:inline-block;">
                                <asp:Label ID="lblCode" runat="server"><U>S</U>ố thẻ: <span style="color:red;">(*)</span></asp:Label>
                                <div class="input-control">
                                    <div class="input-form">
                                        <asp:TextBox CssClass="text-input" ID="txtCode" runat="server" Width="" MaxLength="20"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail two-column ClearFix">
                            <div style="width:49.5%; display:inline-block;">
                                <asp:Label ID="lblValidDate" runat="server"><U>N</U>gày cấp thẻ: <span style="color:red;">(*)</span></asp:Label>
                                <div class="input-control">
                                    <div class="input-form">
                                        <asp:TextBox CssClass="text-input" ID="txtValidDate" runat="server" Width="248px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div style="width:49.5%; display:inline-block;">
                                <asp:Label ID="lblExpiredDate" runat="server"><U>N</U>gày hết hạn thẻ: </asp:Label>
                                <div class="input-control">
                                    <div class="input-form">
                                        <asp:TextBox CssClass="text-input" ID="txtExpiredDate" runat="server" Width="248px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <asp:Label ID="lblFullName" runat="server">Họ <U>t</U>ên bạn đọc: <span style="color:red;">(*)</span></asp:Label>
                            <div class="input-control">
                                <div class="input-form" style="width: 32.7%; display: inline-block;">
                                    <asp:TextBox CssClass="text-input" ID="txtFirstName" runat="server" Width=""></asp:TextBox>
                                </div>
                                <div class="input-form" style="width: 30%; display: inline-block;">
                                    <asp:TextBox CssClass="text-input" ID="txtMiddleName" runat="server" Width=""></asp:TextBox>
                                </div>
                                <div class="input-form" style="width: 30%; display: inline-block;">
                                    <asp:TextBox CssClass="text-input" ID="txtLastName" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="two-column-form">

                        <div class="row-detail">
                            <asp:Label ID="lblWorkPlace" runat="server">Địa <U>c</U>hỉ nơi làm việc: </asp:Label>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtWorkPlace" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <asp:Label ID="lblTelephone" runat="server">Đ<U>i</U>ện thoại: </asp:Label>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtTelephone" runat="server" Width="248px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <asp:Label ID="lblEmail" runat="server"><U>E</U>mail: </asp:Label>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtEmail" runat="server" Width="248px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnInsert" runat="server" Text="Nhập(u)" Width=""></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnReset" runat="server" Text="Đặt lại(r)" Width=""></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Không tồn tại hồ sơ bạn đọc với số thẻ:</asp:ListItem>
            <asp:ListItem Value="3">Ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="4">Bạn chưa nhập đủ các thông tin bắt buộc</asp:ListItem>
            <asp:ListItem Value="5">Nhập mới hồ sơ bạn đọc</asp:ListItem>
            <asp:ListItem Value="6">thành công!</asp:ListItem>
            <asp:ListItem Value="7">Số thẻ bạn đọc đã tồn tại trong CSDL!</asp:ListItem>
            <asp:ListItem Value="8">Ngày cấp thẻ phải nhỏ hơn ngày hết hạn thẻ!</asp:ListItem>
            <asp:ListItem Value="9">Email không hợp lệ.</asp:ListItem>
            <asp:ListItem Value="10">Sai kiểu dữ liệu.</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtCode.focus();
    </script>
</body>
</html>
