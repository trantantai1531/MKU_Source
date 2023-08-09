<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WExport" CodeFile="WExport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WExport</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body leftmargin="0" topmargin="0" onload="document.forms[0].txtFromID.focus();" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">

            <h1 class="main-head-form">Xuất dữ liệu</h1>
            <div class="main-form">
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Chọn mẫu :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlTemplate" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Từ ID :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtFromID" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Đến ID :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtToID" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">
                        <div class="row-detail">
                                                            <p>Phông chữ:</p>
                            <div class="input-control">


                                <div class="radio-control">
                                    <asp:RadioButton ID="optUnicode" runat="server" Text="<u>U</u>nicode" Checked="True" GroupName="Font"></asp:RadioButton>
                                    <asp:RadioButton ID="optTCVN" runat="server" Text="TC<u>V</u>N" GroupName="Font"></asp:RadioButton>
                                    <asp:RadioButton ID="optVNI" runat="server" Text="VN<u>I</u>" GroupName="Font"></asp:RadioButton>
                                </div>

                            </div>
                        </div>
                        <div class="row-detail">
                                           <p>Phông chữ:</p>
                            <div class="input-control">
                 
                                <div class="radio-control">
                                    <asp:RadioButton ID="optXML" runat="server" Text="<u>X</u>ML" GroupName="FileType"></asp:RadioButton>
                                    <asp:RadioButton ID="optText" runat="server" Text="T<u>e</u>xt" Checked="True" GroupName="FileType"></asp:RadioButton>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Phân cách :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtSeperator" runat="server" Width="">#</asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-detail">
                    <div class="button-control inline-box">
                        <div class="button-form">
                            <asp:Button ID="btnExport" runat="server" Width="" Text="Xuất(e)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" runat="server" Width="" Text="Làm lại(r)"></asp:Button>
                        </div>
                    </div>
                </div>
                <asp:HyperLink ID="lnkPhysicalPath" runat="server" Visible="False">Tải dữ liệu về máy trạm</asp:HyperLink>
            </div>
        </div>

        <asp:DropDownList ID="ddlLabel" Visible="False" runat="server" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Xuất dữ liệu</asp:ListItem>
            <asp:ListItem Value="3">------Chọn mẫu xuất------</asp:ListItem>
            <asp:ListItem Value="4">Bạn chưa chọn mẫu xuất!</asp:ListItem>
            <asp:ListItem Value="5">Giá trị dấu phân cách là bắt buộc!</asp:ListItem>
            <asp:ListItem Value="6">Xuất khẩu dữ liệu</asp:ListItem>
            <asp:ListItem Value="7">Dữ liệu phải là số nguyên dương!</asp:ListItem>
            <asp:ListItem Value="8">Không có dữ liệu thoả mãn điều kiện tìm kiếm!</asp:ListItem>
            <asp:ListItem Value="9">Bạn không được cấp quyền sử dụng chức năng này.</asp:ListItem>
        </asp:DropDownList>
        <input id="hidFileName" runat="server" type="hidden">
    </form>
</body>
</html>
