<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WCreateInventory" CodeFile="WCreateInventory.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCreateInventory</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Khởi tạo kỳ kiểm kê</h1>

                <div class="row-detail">
                    <p>Tên kỳ kiểm kê :</p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox CssClass="text-input" ID="txtInventoryName" runat="server" Width=""></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row-detail">
                    <p>Ngày bắt đầu kiểm kê :<asp:HyperLink ID="lnkDate" runat="server">Lịch</asp:HyperLink></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox CssClass="text-input" ID="txtStartDate" runat="server" Width=""></asp:TextBox>

                        </div>
                    </div>
                </div>

                <div class="row-detail button-control">

                    <p>Người kiểm kê :</p>
                    <div class="input-control">
                        <div class="input-form control-disabled">
                            <asp:TextBox CssClass="text-input" ID="txtInputer" runat="server" Width=""></asp:TextBox>

                        </div>
                    </div>

                        </div>

                <div class="row-detail button-control">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnInit" CssClass="form-btn" runat="server" Text="Khởi tạo(c)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" CssClass="form-btn" runat="server" Text="Đặt lại(r)" Width="80"></asp:Button>

                        </div>
                    </div>
                </div>

            </div>
        </div>

        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi </asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="3">Thêm mới kỳ kiểm kê</asp:ListItem>
            <asp:ListItem Value="4">Bạn chưa nhập đủ thông tin cần thiết để khởi tạo kỳ kiểm kê</asp:ListItem>
            <asp:ListItem Value="5">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="6">Tạo mới thành công kỳ kiểm kê</asp:ListItem>
            <asp:ListItem Value="7">Tại một thời điểm chỉ có một kỳ kiểm kê duy nhất được kích hoạt. Hiện đã có một kỳ kiểm kê được kích hoạt, việc tạo mới không thành công.</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtInventoryName.focus();
    </script>
</body>
</html>
