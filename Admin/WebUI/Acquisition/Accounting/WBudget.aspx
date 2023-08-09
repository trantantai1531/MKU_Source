<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WBudget" CodeFile="WBudget.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WBudget</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="ClearContent();">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Thay đổi trạng thái quỹ</h1>
                <div class="content-form">
                <div class="main-form">
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Danh sách quỹ :</p>
                                <div class="input-control">
                                    <div class="dropdown-form" style="height: auto">
                                        <asp:ListBox ID="lstBudget" runat="server" Rows="13"></asp:ListBox>
                                    </div>
                                </div>
                                <br />
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnDelete" CssClass="form-btn" runat="server" Text="Xoá(d)" Width=""></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="two-column-form">
                          
                            <div class="row-detail">
                                <p>Mã quỹ :</p>
                                <div class="input-control">
                                    <div class="input-form " style="  max-width: 136px; float: left;  margin-right: 10px;">
                                        <asp:TextBox CssClass="text-input" ID="txtBudgetCode" runat="server" Width="136px" MaxLength="4"></asp:TextBox>
                                    </div>
                                </div>
                                <em>(Độ dài tối đa là 4 kí tự)</em>
                            </div>
                              <div class="row-detail">
                                <p>Tên quỹ :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtBudgetName" runat="server" Width="" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Mục đích :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtPurpose" CssClass="area-input" runat="server" Rows="5" Width="" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Số tiền thực tế :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtAmount" runat="server" Width="" MaxLength="12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Đơn vị tiền tệ :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlCurrency" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <asp:Label ID="lblStatus" runat="server">Tr<u>ạ</u>ng thái:</asp:Label>
                                <div class="checkbox-control">
                                    <asp:RadioButton ID="rdoOpenStat" runat="server" Text="<u>M</u>ở " GroupName="rdoStatus"></asp:RadioButton>
                                    <%--label for="rdoOpenStat"></label><span>Mở</span>--%>
                                    <asp:RadioButton ID="rdoCloseStat" runat="server" Text="<u>Đ</u>óng" GroupName="rdoStatus"></asp:RadioButton>
                                    <%--<label for="rdoCloseStat"></label><span>Đóng</span>--%>
                                    <asp:RadioButton ID="rdoEnding" runat="server" Text="<u>P</u>hong toả" GroupName="rdoStatus"></asp:RadioButton>
                                    <%--<label for="rdoEnding"></label><span>Phong tỏa</span>--%>
                                </div>
                            </div>
                            <div class="row-detail">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnUpdate" CssClass="form-btn" runat="server" Width="" Text="Cập nhật(u)"></asp:Button>
                                    </div>
                                    <div class="button-form">
                                        <asp:Button ID="btnReset" CssClass="form-btn" runat="server" Width="" Text="Đặt lại(r)"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                     </div>
            </div>
        </div>
        <input id="hidBudgetId" type="hidden" value="0" runat="server">
        <asp:DropDownList ID="ddlLabel" Width="0px" runat="server" Visible="false" Height="0">
            <asp:ListItem Value="0">-------- Nhập mới --------</asp:ListItem>
            <asp:ListItem Value="1">Gi&#225; trị của trường</asp:ListItem>
            <asp:ListItem Value="2">T&#234;n quỹ</asp:ListItem>
            <asp:ListItem Value="3">M&#227; quỹ</asp:ListItem>
            <asp:ListItem Value="4">Số tiền thực tế</asp:ListItem>
            <asp:ListItem Value="5">l&#224; bắt buộc</asp:ListItem>
            <asp:ListItem Value="6">Số tiền thực tế nhập v&#224;o phải l&#224; kiểu số</asp:ListItem>
            <asp:ListItem Value="7">M&#227; lỗi</asp:ListItem>
            <asp:ListItem Value="8">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="9">Bạn phải chọn t&#234;n quỹ trước khi xo&#225;</asp:ListItem>
            <asp:ListItem Value="10">Dữ liệu nhập th&#224;nh c&#244;ng!</asp:ListItem>
            <asp:ListItem Value="11">Dữ liệu nhập kh&#244;ng th&#224;nh c&#244;ng (Sai kiểu dữ liệu hoặc tr&#249;ng m&#227; quỹ)!</asp:ListItem>
            <asp:ListItem Value="12">Bạn kh&#244;ng được cấp quyền khai th&#225;c t&#237;nh năng n&#224;y!</asp:ListItem>
            <asp:ListItem Value="13">Th&#234;m mới quỹ</asp:ListItem>
            <asp:ListItem Value="14">Cập nhật quỹ</asp:ListItem>
            <asp:ListItem Value="15">Xo&#225; quỹ</asp:ListItem>
            <asp:ListItem Value="16">Bạn chưa chọn quỹ cần l&#224;m việc!</asp:ListItem>
            <asp:ListItem Value="17">Số tiền qu&#225; lớn,tối đa l&#224; 1,000,000,000.</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
