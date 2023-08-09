<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCirculationTemplate" CodeFile="WCirculationTemplate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCirculationTemplate</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
 
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />


</head>
<body onload="document.forms[0].txtTitle.focus();">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
                <asp:Label ID="lblTitleTem" runat="server" CssClass="main-head-form" Width="100%"></asp:Label>
            <div class="main-form">
                <div class="row-detail">
                    <p>Tên mẫu:
                        <asp:Label ID="lblMan" runat="server" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc phải nhập dữ liệu">(*)</asp:Label></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server" Width="200px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Nội dung :</p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox CssClass="area-input" ID="txtContent" runat="server" Width="" Rows="10" TextMode="MultiLine" Wrap="False"
                                Height="269px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Chọn thông tin :</p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlInf" runat="server">
                                <asp:ListItem Value="--------------">---------- Chọn -----------</asp:ListItem>
                                <asp:ListItem Value="<$CODE$>">Số thẻ</asp:ListItem>
                                <asp:ListItem Value="<$NAME$>">Họ tên</asp:ListItem>
                                <asp:ListItem Value="<$DOB$>">Ngày sinh</asp:ListItem>
                                <asp:ListItem Value="<$CLASS$>">Lớp</asp:ListItem>
                                <asp:ListItem Value="<$FACULTY$>">Khoa</asp:ListItem>
                                <asp:ListItem Value="<$GRADE$>">Khoá</asp:ListItem>
                                <asp:ListItem Value="<$TITLE$>">Nhan đề</asp:ListItem>
                                <asp:ListItem Value="<$COPYNUMBER$>">ÐKCB</asp:ListItem>
                                <asp:ListItem Value="<$CHECKOUTDATE$>">Ngày mượn</asp:ListItem>
                                <asp:ListItem Value="<$DUEDATE$>">Ngày trả</asp:ListItem>
                                <asp:ListItem Value="<$OVERDUEDAY$>">Số ngày quá hạn</asp:ListItem>
                                <asp:ListItem Value="<$FEES$>">Phí mượn</asp:ListItem>
                                <asp:ListItem Value="<$FINES$>">Phí phạt</asp:ListItem>
                                <asp:ListItem Value="<$MONEY$>">Tổng tiền</asp:ListItem>
                                <asp:ListItem Value="<$DD$>">Ngày</asp:ListItem>
                                <asp:ListItem Value="<$MM$>">Tháng</asp:ListItem>
                                <asp:ListItem Value="<$YYYY$>">Năm</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật(u)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnView" runat="server" Text="Xem trước(v)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" runat="server" Text="Ðặt lại(r)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <input id="hdType" runat="server" type="hidden">
        <input id="hdTemplateID" runat="server" type="hidden">
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem Value="5">Cập nhật khuôn dạng phiếu </asp:ListItem>
            <asp:ListItem Value="6">Xoá khuôn dạng phiếu</asp:ListItem>
            <asp:ListItem Value="7">thành công!</asp:ListItem>
            <asp:ListItem Value="8"></asp:ListItem>
            <asp:ListItem Value="9">Bạn chưa nhập tên khuôn dạng!</asp:ListItem>
            <asp:ListItem Value="10">Mẫu phiếu mượn sách</asp:ListItem>
            <asp:ListItem Value="11">Mẫu phiếu trả sách</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
