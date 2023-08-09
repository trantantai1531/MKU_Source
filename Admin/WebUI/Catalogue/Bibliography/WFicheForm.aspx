<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WFicheForm" CodeFile="WFicheForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WFicheForm</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" onload="parent.document.getElementById('frmMain').setAttribute('rows','*,0');">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">In phích</h1>
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Từ mã tài liệu :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtItemIDFrom" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Đến mã tài liệu :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtItemIDTo" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Mã tài liệu :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtItemCode" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail" style="display:none">
                            <p>Đăng ký cá biệt Từ :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCopyNumberFrom" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail" style="display:none">
                            <p>Đăng ký cá biệt Tới :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCopyNumberTo" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Thư viện</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLib" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Kho</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLoc" runat="server"></asp:DropDownList><INPUT id="txtLocID" type="hidden" name="txtLocID" runat="server">
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Dạng tài liệu :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlItemType" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Số phích mỗi trang :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtFichePerPage" runat="server" Width="40px">4</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Mẫu phích</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlTempate" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Sắp xếp theo :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtSortBy" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="checkbox-control">
                                <asp:CheckBox ID="chkNewRec" runat="server" Text="Chỉ in các bản <U>g</U>hi mới" ></asp:CheckBox>
                                <%--<label for="chkNewRec"></label>--%>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="checkbox-control">
                                <asp:CheckBox ID="chkLoc" runat="server" Text="In phích cho từn<U>g</U> kho" ></asp:CheckBox>
                                <%--<label for="chkLoc"></label>--%>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="checkbox-control">
                                <asp:CheckBox ID="chkExportToMSWord" runat="server" Text="Xuất ra file <u>W</u>ord" ></asp:CheckBox>
                                <%--<label for="chkExportToMSWord"></label>--%>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnPrint" runat="server" Text="Tạo phích(p)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" CssClass="form-btn" runat="server" Text="Làm lại(r)" Width="80px"></asp:Button>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlAboutAction" runat="server" Width="0px" Visible="False">
            <asp:ListItem Value="0">In Phích</asp:ListItem>
            <asp:ListItem Value="1">Xuất phích ra file word</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="ddlLabel" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">Bạn không được cấp quyền sử dụng chức năng này</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="3">In phích: </asp:ListItem>
            <asp:ListItem Value="4">---- Chọn dạng tài liệu ----</asp:ListItem>
            <asp:ListItem Value="5">----- Chọn thư viện -----</asp:ListItem>
            <asp:ListItem Value="6">Sai kiểu dữ liệu!</asp:ListItem>
            <asp:ListItem Value="7">Không tìm thấy dữ liệu !</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtItemIDFrom.focus();
    </script>
</body>
</html>
