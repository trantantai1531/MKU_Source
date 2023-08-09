<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIDXViewForm"
    CodeFile="WIDXViewForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WIDXViewForm</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div class="main-form">
            <div class="ClearFix main-page">
                <h1 class="main-head-form">
                    <asp:Label ID="lbHeader" runat="server" >Hiển thị danh mục</asp:Label></h1>
                <p style="font-style: italic;">
                     <asp:Label ID="lblNameBib" runat="server"></asp:Label></p>
                <div class="col-left-8">
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>
                                    <asp:Label ID="lblTypeView" runat="server"><U>H</U>iển thị:</asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="pad5">
                                        <div class="dropdown-form">
                                            <asp:DropDownList ID="ddlTypeView" runat="server">
                                            </asp:DropDownList>
                                       
                                        </div>
                                    </div>
                                    <div class="pad5" style="display: none">
                                        <div class="input-control">
                                            <div class="input-form ">
                                                   <asp:TextBox ID="txtTypeViewID" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                 
                            <div class="row-detail">
                                <p>
                                    <asp:Label ID="lblTemplate" runat="server"><U>K</U>huôn dạng:</asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlTemplate" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>
                                    <asp:Label ID="lblPageSize" runat="server"><U>S</U>ố mục hiển thị mỗi trang:</asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtPageSize" runat="server" MaxLength="3">20</asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnView" CssClass="form-btn" runat="server" Text="Hiển thị(v)" Width="90px"></asp:Button>&nbsp;
                                        
                                      
                                    </div>
                                    <div class="button-form">
                                        <asp:Button ID="btnReset" CssClass="form-btn" runat="server" Text="Làm lại(r)" Width="80px"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:DropDownList runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
        <asp:ListItem Value="0">Toàn bộ danh mục</asp:ListItem>
        <asp:ListItem Value="1">Không có dữ liệu thoả mãn!</asp:ListItem>
        <asp:ListItem Value="2">Khuôn dạng dữ liệu không hợp lệ!</asp:ListItem>
        <asp:ListItem Value="3">Các mã nhóm</asp:ListItem>
        <asp:ListItem Value="4">Các tên nhóm</asp:ListItem>
        <asp:ListItem Value="5">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="6">Chi tiết lỗi</asp:ListItem>
    </asp:DropDownList>
    </form>
</body>
</html>
