<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WTransferBudget" CodeFile="WTransferBudget.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WTransferBudget</title>
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
                <h1 class="main-head-form">Chuyển tiền</h1>
                <div class="row-detail">
                    <p>Quỹ nguồn :</p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlBudgetSrc" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Quỹ đích :</p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlBudgetDes" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Số tiền :</p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox CssClass="text-input" ID="txtMoney" runat="server">0</asp:TextBox>
                        </div>
                    </div>
                    <em>(tính theo đơn vị tiền tệ của quỹ nguồn)</em>
                </div>
                <div class="row-detail">
                    <p>Ngày tháng chuyển tiền : &nbsp; <asp:hyperlink id="lnkDateTran" Runat="server">Lịch</asp:hyperlink></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox CssClass="text-input" ID="txtDateTran" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Người quyết định :</p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox CssClass="text-input" ID="txtDecision" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnTransfer" runat="server" Text="Chuyển(t)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnReset" runat="server" Text="Làm lại(r)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabelNote" runat="server" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">Gi&#225; trị trường c&#242;n rỗng!</asp:ListItem>
            <asp:ListItem Value="1">Số kh&#244;ng hợp lệ!</asp:ListItem>
            <asp:ListItem Value="2">Khu&#244;n dạng ng&#224;y th&#225;ng kh&#244;ng hợp lệ</asp:ListItem>
            <asp:ListItem Value="3">Số tiền bạn cần chuyển lớn hơn số tiền m&#224; quỹ nguồn c&#243;. Bạn c&#243; muốn chuyển hết số tiền c&#242;n lại kh&#244;ng?</asp:ListItem>
            <asp:ListItem Value="4">Chuyển tiền sang quỹ</asp:ListItem>
            <asp:ListItem Value="5">Nhận tiền từ quỹ</asp:ListItem>
            <asp:ListItem Value="6">Tiền đ&#227; được chuyển</asp:ListItem>
            <asp:ListItem Value="7">Bạn kh&#244;ng thể chuyển tiền trong c&#249;ng một quỹ, bạn phải chọn quỹ nguồn kh&#225;c với quỹ đ&#237;ch.</asp:ListItem>
            <asp:ListItem Value="8">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="9">M&#227; lỗi</asp:ListItem>
            <asp:ListItem Value="10">Bạn kh&#244;ng được cấp quyền sử dụng t&#237;nh năng n&#224;y</asp:ListItem>
            <asp:ListItem Value="11">Chuyển tiền giữa c&#225;c quỹ</asp:ListItem>
            <asp:ListItem Value="12">Hiện tại quỹ kh&#244;ng c&#242;n tiền nữa !</asp:ListItem>
            <asp:ListItem Value="13">Số tiền chuyển phải lớn hơn 0</asp:ListItem>
            <asp:ListItem Value="14">Qũi nguồn hay quĩ đ&#237;ch kh&#244;ng hợp lệ(Bị kh&#243;a hoặc phong tỏa).</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
