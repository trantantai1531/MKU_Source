<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WLabelPrintSearch" CodeFile="WLabelPrintSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>In nhãn gáy</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body bgcolor="white" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="content-form">
                <h1 class="main-group-form">In nhãn gáy ấn phẩm</h1>
                <div class="main-form">
                <div style="display:none;">
                    <asp:Label id="lblLibrary" Runat="server">Thư <u>v</u>iện: </asp:Label>
                    <asp:DropDownList ID="ddlLibrary" Runat="server"></asp:DropDownList>
                    <asp:Label ID="lblStore" Runat="server">Kh<u>o</u>: </asp:Label>
                    <asp:DropDownList ID="ddlStore" Runat="server"></asp:DropDownList>
						<input type="hidden" id="txtStore" runat="server" NAME="txtStore" value="0">
                </div>
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="radio-control">
                            <asp:RadioButton CssClass="lbSubTitle" ID="optCodeItem" runat="server" GroupName="PrintWhat" Text="In cho từng tên <u>s</u>ách"></asp:RadioButton>
                            <label for="optCodeItem"></label>
                        </div>
                        <div class="row-detail">
                            <p>Từ mã tài liệu :
                                <asp:HyperLink ID="hrfFromCodeItem" runat="server">Tìm</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtFromCodeItem" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tới mã tài liệu:
                                <asp:HyperLink ID="hrfToCodeItem" runat="server">Tìm</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtToCodeItem" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="radio-control">
                            <asp:RadioButton CssClass="lbSubTitle" ID="optCopyNumber" runat="server" GroupName="PrintWhat" Text="In cho từng đăng ký <u>c</u>á biệt"
                                Checked="True"></asp:RadioButton>
                            <label for="optCopyNumber"></label>
                        </div>
                        <div class="row-detail">
                            <p>Từ đăng ký cá biệt :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtFromCopyNumber" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tới đăng ký cá biệt :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtToCopyNumber" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                    </div>

                    <div class="two-column-form">
                        <div class="radio-control">
                            <asp:RadioButton CssClass="lbSubTitle" ID="optElse" runat="server" GroupName="PrintWhat" Text="Hoặc in các giá trị sau"></asp:RadioButton>
                            <label for="optElse"></label>
                        </div>
                        <div class="row-detail">
                            <p>Các giá trị cần in :</p>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox ID="txtElse" CssClass="area-input" runat="server" Width="100%" TextMode="MultiLine" Wrap="False" Height="90px"></asp:TextBox>
                                </div>
                                <asp:Button runat="server" CssClass="lbButton" ID="btnClearQueue" Text="Xóa hàng đợi" />
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Dạng tài liệu :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlItemType" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Mẫu nhãn :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlFormal" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Số cột/trang :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtColPage" runat="server" Width="">4</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Số hàng/trang :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtHagPage" runat="server" Width="">5</asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button CssClass="form-btn" ID="btnPrint" runat="server" Text="In nhãn(p)" Width=""></asp:Button>

                            </div>
                            <div class="button-form">
                                <asp:Button CssClass="form-btn" ID="btnReset" runat="server" Text="Đặt lại(r)" Width=""></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLog" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
            <asp:ListItem Value="3">Khuôn dạng dữ liệu không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="4">Không tìm thấy dữ liệu!</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtFromCodeItem.focus();
    </script>
</body>
</html>
