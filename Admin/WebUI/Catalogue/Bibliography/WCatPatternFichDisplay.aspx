<%@ Page Language="vb" AutoEventWireup="false" validateRequest="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCatPatternFichDisplay" CodeFile="WCatPatternFichDisplay.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCatPatternFichDisplay</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" rightmargin="0" topmargin="0" bottommargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Mẫu phích</h1>
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Loại khuôn dạng :</p><p class="error-star">(*)</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlTemplate" runat="server"></asp:DropDownList>
                                    <input type="hidden" runat="server" name="txtTemplate" id="txtTemplate" value="0"/>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tên khuôn dạng :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Phần đầu :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="area-input" ID="txtHeader" Width="" runat="server" Columns="10" Rows="10" TextMode="MultiLine"
                                        Wrap="False" Height="54px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Nội dung :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="area-input" ID="txtContent" Width="" runat="server" Columns="100" Rows="10" TextMode="MultiLine"
                                        Wrap="False" Height="103px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Phần cuối:</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="area-input" ID="txtFooter" Width="" runat="server" Columns="10" Rows="10" TextMode="MultiLine"
                                        Wrap="False" Height="54px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnUpdate" runat="server" Text="Cập nhật(u)" Width=""></asp:Button>

                        </div>
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnAddField" runat="server" Text="Thêm trường(a)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnView" runat="server" Text="Xem trước(v)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnReset" runat="server" Text="Đặt lại(r)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnDelete" runat="server" Text="Xoá mẫu(d)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input id="hidAddRight" type="hidden" runat="server" value="0" name="hidAddRight">
        <input id="hidUpdateRight" type="hidden" runat="server" value="0" name="hidUpdateRight">
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0px" Visible="False">
            <asp:ListItem Value="0">Chọn OK nến bạn thực sự muốn xoá mẫu này?</asp:ListItem>
            <asp:ListItem Value="1">Mẫu phích mới chưa được ghi nhận</asp:ListItem>
            <asp:ListItem Value="2">Cập nhật mẫu phích thành công!</asp:ListItem>
            <asp:ListItem Value="3">Đã ghi nhận mẫu phích mới</asp:ListItem>
            <asp:ListItem Value="4">Bạn chưa nhập tên phích!</asp:ListItem>
            <asp:ListItem Value="5">Mẫu phích mới đã được ghi nhận</asp:ListItem>
            <asp:ListItem Value="6">Tạo mới mẫu phích: </asp:ListItem>
            <asp:ListItem Value="7">Cập nhật mẫu phích: </asp:ListItem>
            <asp:ListItem Value="8">Xoá mẫu phích: </asp:ListItem>
            <asp:ListItem Value="9">Tên phích đã tồn tại trong CSDL!</asp:ListItem>
            <asp:ListItem Value="10">Tạo mới</asp:ListItem>
            <asp:ListItem Value="11">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="12">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="13">Mẫu phích:</asp:ListItem>
            <asp:ListItem Value="14">--------------- Nhập mới ---------------</asp:ListItem>
            <asp:ListItem Value="15">Bạn chưa chọn phích cần xoá!</asp:ListItem>
            <asp:ListItem Value="16">Xoá mẫu phích thành công!</asp:ListItem>
        </asp:DropDownList>
        </TD></TR></TBODY></TABLE>
    </form>
    <script language="javascript">
        document.forms[0].txtTitle.focus();
    </script>
</body>
</html>
