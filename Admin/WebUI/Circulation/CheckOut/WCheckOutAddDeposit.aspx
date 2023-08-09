<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WCheckOutAddDeposit.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WCheckOutAddDeposit" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCheckOutResult</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/style.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    
    <style type="text/css">
        .text-center
        {
            text-align:center;
            color: rgb(31, 97, 163) !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divBody">
            <h2 class="main-head-form text-center" style="color">Bạn đọc cần phải đặt cọc</h2>
            <div class="main-form">
                <div class="two-column">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Nhập tiền cọc (x1000) <asp:Literal ID="LiteralHoldingPrice" runat="server"></asp:Literal></p>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox ID="txtAmountDeposit" CssClass="text-input" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>&nbsp</p>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnAddDeposit" CssClass="lbButton" runat="server" Text="Nhập"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="display:none;">
            <asp:HiddenField ID="hidIsHighQuanlity" Value="1" runat="server" />
            <asp:Label ID="lblMsg1" runat="server" Visible="False">Đơn giá {0} đ/bản</asp:Label>
            <asp:Label ID="lblMsg8" runat="server" Visible="False">Thẻ bạn đọc chưa thuộc nhóm bạn đọc nào.</asp:Label>
            <asp:Label ID="lblMsg9" runat="server" Visible="False">Thẻ bạn đọc thuộc nhóm không cho phép mượn về.</asp:Label>
            <asp:Label ID="LabelHoldingLoanExist" runat="server" Text="ĐKCB đã có bạn đọc đăng ký trước"></asp:Label>
            <asp:Label ID="LabelLoanLocationExist" runat="server" Text="ĐKCB mà bạn đọc yêu cầu ghi mượn đã tồn tại"></asp:Label>
            <asp:Label ID="LabelItemNotExist" runat="server" Text="Sách không chính xác"></asp:Label>
            <asp:Label ID="LabelPatronCodeNotExist" runat="server" Text="Số thẻ bạn đọc không chính xác"></asp:Label>
            <asp:Label ID="LabelHoldingNotSupportForLoanLibrary" runat="server" Text="Ấn phẩm này thuộc kho mà cán bộ thư viện không có quyền quản lý"></asp:Label>
            <asp:Label ID="LabelPatronNotSupportForLoanLibrary" runat="server" Visible="False" Text="Bạn đọc không được mượn ấn phẩm tại những kho mà nhóm mình không được mượn."></asp:Label>
            <asp:Label ID="LabelPatronExpired" runat="server" Visible="False" Text="Thẻ bạn đọc đã hết hạn."></asp:Label>
            <asp:Label ID="LabelPatronNotExistGroup" runat="server" Visible="False" Text="Thẻ bạn đọc chưa thuộc nhóm bạn đọc nào."></asp:Label>
            <asp:Label ID="LabelPatronNotLoanHighQuanlity" runat="server" Visible="False" Text="Thẻ bạn đọc không được mượn sách chất lượng cao"></asp:Label>
            <asp:Label ID="LabelPatronNotHighQuanlity" runat="server" Visible="False" Text="Thẻ bạn đọc không thuộc nhóm chất lượng cao"></asp:Label>
            <asp:Label ID="LabelItemCountCopyNumberRequried" runat="server" Text="Tài liệu chỉ còn 1 bản phục vụ, chỉ được phép mượn đọc tại chổ, không được mượn về nhà"></asp:Label>
            <asp:Label ID="LabelQuota" runat="server" Text="Bạn đọc quá hạn ngạch cho phép mượn"></asp:Label>
            <asp:Label ID="LabelCopyNumberLocked" runat="server" Text="Ấn phẩm chưa mở khóa"></asp:Label>
            <asp:Label ID="LabelCopyNumberNotIncurlation" runat="server" Text="Ấn phẩm chưa kiểm nhận"></asp:Label>
            <asp:Label ID="LabelCopyNumberInUsed" runat="server" Text="Ấn phẩm đang cho mượn"></asp:Label>
            <asp:Label ID="LabelCopyNumberAtLocal" runat="server" Text="ĐKCB đăng ký mượn tại chổ không được phép mượn về nhà"></asp:Label>
        </div>
    </form>
</body>
</html>
