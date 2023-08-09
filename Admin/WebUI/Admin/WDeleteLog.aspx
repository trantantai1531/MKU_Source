<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WDeleteLog" CodeFile="WDeleteLog.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WDeleteLog</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="document.forms[0].txtFromDate.focus();">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <div class="content-form">
                    <h1 class="main-head-form">Xoá Log</h1>
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Ngày từ:</p><asp:HyperLink ID="lnkFromDate" runat="server">Lịch</asp:HyperLink>
                                <%--<asp:Label ID="lblFromDate"  runat="server">Ngày <U>t</U>ừ:</asp:Label>--%>
                                <div class="input-control">
                                    <div class="input-form">
                                        <asp:TextBox ID="txtFromDate" CssClass="text-input" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Thời gian từ:</p>
                                <div class="input-control">
                                    <div class="input-form">
                                        <asp:TextBox ID="txtFromTime" CssClass="text-input" runat="server"></asp:TextBox>
                                        <%----%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Ngày đến:</p><asp:HyperLink ID="lnkToDate" runat="server">Lịch</asp:HyperLink>
                                <%--<asp:Label ID="lblToDate" runat="server">Ngày đế<U>n</U>: </asp:Label>--%>
                                <div class="input-control">
                                    <div class="input-form">
                                        <asp:TextBox ID="txtToDate" CssClass="text-input" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Thời gian đến:</p>
                                <%--<asp:Label ID="lblToTime" runat="server">Thời gian đến: </asp:Label>--%>
                                <div class="input-control">
                                    <div class="input-form">
						                <asp:TextBox ID="txtToTime" CssClass="text-input" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnDelete" CssClass="form-btn" runat="server" Text="Xoá(d)"></asp:Button>
                                    </div>
                                    <div class="button-form">
                                        <asp:Button ID="btnReset" CssClass="form-btn" runat="server" Width="92px" Text="Đặt lại(r)"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="3">Bạn chưa chọn khoảng thời gian để xoá log</asp:ListItem>
            <asp:ListItem Value="4">Bạn có muốn xoá log không?</asp:ListItem>
            <asp:ListItem Value="5">Xoá log thành công!</asp:ListItem>
            <asp:ListItem Value="6">Thời gian không chính xác! (Thời gian phải nằm trong khoảng 00:00:00 - 23:59:99)</asp:ListItem>
            <asp:ListItem Value="7">Thời gian sau phải lớn hơn thời gian trước!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
