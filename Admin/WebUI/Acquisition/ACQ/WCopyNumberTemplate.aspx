<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WCopyNumberTemplate" CodeFile="WCopyNumberTemplate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WACQTemplate</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Khuôn dạng ĐKCB</h1>
                <div class="row-detail">
                    <p>Ấn phẩm theo đơn đặt :</p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlElement" Runat="server">
							<asp:ListItem Value="" Selected="True">---------- Chọn ----------</asp:ListItem>
							<asp:ListItem Value="<$INV$>">Tên kho</asp:ListItem>
							<asp:ListItem Value="<$SHELF$>">Tên giá</asp:ListItem>
							<asp:ListItem Value="<$YR$>">Năm bổ sung</asp:ListItem>
							<asp:ListItem Value="<$SERINUM$>">Số sêri(liên tiếp)</asp:ListItem>
						</asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Định dạng cho ĐKCB [020$a] :</p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtFormat" CssClass="text-input" Runat="server" Width=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Cho phép sinh liên tục khi nhập bằng tay :</p> <asp:CheckBox CssClass="lbCheckbox" ID="ckbEnable" Text=" "  Runat="server" Width=""></asp:CheckBox>
                  
                 <%--   <div class="input-control">
                        <div class="input-form ">
                             <label for="ckbEnable"></label>
                            <asp:CheckBox ID="ckbEnable"  Runat="server" Width=""></asp:CheckBox>
                        </div>
                    </div>--%>
                </div>
                 <div class="row-detail" >
                    <p>Vị trí bắt đầu :</p>
                    <div class="input-control">
                        <div class="input-form ">
                           
                            <asp:TextBox ID="txtStartPosition" Text="0" CssClass="text-input" Runat="server" Width=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                 <div class="row-detail" >
                    <p>Vị trí kết thúc :</p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtEndPosition" Text="0" CssClass="text-input" Runat="server" Width=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Chiều dài chuỗi :</p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtLenght" CssClass="text-input" Runat="server" Width=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnUpdate" CssClass="form-btn" Runat="server" Text="Cập nhật(u)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" CssClass="form-btn" Runat="server" Text="Đặt lại(r)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0" Height="0">
            <asp:ListItem Value="0">Tạo mẫu đăng ký cá biệt </asp:ListItem>
            <asp:ListItem Value="1">Cập nhật mẫu đăng ký cá biệt </asp:ListItem>
            <asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="3">Mã lỗi </asp:ListItem>
            <asp:ListItem Value="4"> thành công</asp:ListItem>
            <asp:ListItem Value="5">Bạn chưa nhập nội dung khuôn dạng đăng ký cá biệt!</asp:ListItem>
        </asp:DropDownList>
        <input type="hidden" id="hidTemplateID" value="0" runat="server">
    </form>
</body>
</html>
