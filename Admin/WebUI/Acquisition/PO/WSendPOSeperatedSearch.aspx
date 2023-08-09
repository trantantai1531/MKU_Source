<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WSendPOSeperatedSearch" CodeFile="WSendPOSeperatedSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSendPOSeperatedSearch</title>
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
            <div class="main-page ClearFix">
                <h1 class="main-head-form">Báo cáo phân kho</h1>
                <div class="three-column ClearFix">
                    <div class="three-column-form">
                        <div class="row-detail" id="boxPOCode" runat="server">
                            <p ID="lblPOCode" runat="server">Mã số đơn đặt :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlPOCode" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Mẫu in :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlTemplate" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Giới hạn :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlUbound" runat="server">
                                        <asp:ListItem Value="1" Selected="True">1</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="100">100</asp:ListItem>
                                        <asp:ListItem Value="1000">1000</asp:ListItem>
                                        <asp:ListItem Value="0">tất cả</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">                    
                            <div class="button-form">
                                <asp:Button ID="btnPrint" CssClass="form-btn" runat="server" Text="In(p)" ></asp:Button>
                            </div>
                            <div class="button-form">
                                 <asp:Button ID="btnEmail" CssClass="form-btn" runat="server" Text="Email(e)"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnPreview" CssClass="form-btn" runat="server" Text="Xem thử(m)"></asp:Button>
                            </div>
                            <div class="button-form">
                            
                                <asp:Button ID="btnFile" CssClass="form-btn" runat="server" Text="Ghi ra file(f)"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input type="hidden" id="hdPOID" runat="server" name="hdPOID" value="0">
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Bạn chưa chọn mẫu đơn phân kho</asp:ListItem>
            <asp:ListItem Value="1">---------- Chọn ---------</asp:ListItem>
            <asp:ListItem Value="2">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="3">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="4">Bạn không được cấp quyền khai thác tính năng này.</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
