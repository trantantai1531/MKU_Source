<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatOccuForm" CodeFile="WStatOccuForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStatOccuForm</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <asp:Label ID="lblOccupation" runat="server" CssClass="main-head-form" Width="100%">Thống kê theo nhóm ngành nghề</asp:Label>
            <div class="main-form">
                <div class="two-column ClearFix">
                    <div class="two-column-form ClearFix">
                        <div class="span45">
                            <div class="row-detail">
                                <p>Hoạt động trước :</p>
                                <div class="input-control">

                                    <asp:ListBox CssClass="area-input" ID="lbSource" runat="server" SelectionMode="Multiple" Width="100%" Height="184px"
                                        Rows="6"></asp:ListBox>
                                </div>
                            </div>
                        </div>

                        <div class="span1">
                            <div class="input-control button-list">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnAdd" runat="server" Text=" >> " Width="" CssClass="btn-icon btn-next"></asp:Button>
                                        <div class="icon-btn"><span class="icon-arrow-right"></span></div>
                                    </div>
                                </div>
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnRemove" runat="server" Text=" << " CssClass="btn-icon btn-prev"></asp:Button>
                                        <div class="icon-btn"><span class="icon-arrow-left"></span></div>
                                    </div>
                                </div>
                             
                            </div>
                        </div>

                        <div class="span45">
                            <div class="row-detail">
                                <p>Cột hiển thị :</p>
                                <div class="input-control">

                                    <asp:ListBox ID="lbDest" CssClass="area-input" runat="server" SelectionMode="Multiple" Width="100%" Height="184px"
                                        Rows="6"></asp:ListBox>
                                </div>
                            </div>
                        </div>
                        <div class="ClearFix"></div>
                        <div >
                             <div class="button-control" style="text-align:right;">
                                    <div class="button-form">
                                        <asp:Button ID="btnStatistic" runat="server" Text="Thống kê" Width=""></asp:Button> &nbsp;
                                        <asp:Button ID="btnBack" runat="server" Text="Quay lại" Width=""></asp:Button>
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
  


            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
            <asp:ListItem Value="3">Bạn chưa chọn nhóm ngành nghề thống kê!</asp:ListItem>
            <asp:ListItem Value="4">Không rõ</asp:ListItem>
        </asp:DropDownList>
        <input type="hidden" id="txtID" name="txtID" runat="server">
    </form>
</body>
</html>
