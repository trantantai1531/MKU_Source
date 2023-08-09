<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCatPatternDisplay" EnableViewState="False" CodeFile="WCatPatternDisplay.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCatPatternCatalogueDisplay</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0">
    <!-- EnableViewStateMAC="False"-->
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Mẫu danh mục</h1>
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Loại khuôn dạng :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlTemplate" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tên khuôn dạng :<p class="error-star">(*)</p></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="text-input" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tiêu đề :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtHeader" CssClass="area-input" Width="" runat="server" Columns="10" Rows="10"
                                        TextMode="MultiLine" Wrap="False" Height="44px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Nội dung :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtContent" CssClass="area-input" Width="" runat="server" Columns="100"
                                        Rows="10" TextMode="MultiLine" Wrap="False" Height="102px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Phần cuối:</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtFooter" CssClass="area-input " Width="" runat="server" Columns="10" Rows="10"
                                        TextMode="MultiLine" Wrap="False" Height="46px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnAddField" CssClass="form-btn" runat="server" Text="Cập nhật(c)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnView" CssClass="form-btn" runat="server" Text="Xem trước(x)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" CssClass="form-btn" runat="server" Text="Đặt lại(l)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnDelete" CssClass="form-btn" runat="server" Text="Xoá mẫu(o)"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" Width="0px" runat="server" Visible="False">
            <asp:ListItem Value="0">Bạn thực sự muốn xoá mẫu này?</asp:ListItem>
            <asp:ListItem Value="1">Mẫu danh mục mới chưa được ghi nhận</asp:ListItem>
            <asp:ListItem Value="2">Cập nhật mẫu danh mục thành công!</asp:ListItem>
            <asp:ListItem Value="3">Đã ghi nhận mẫu mẫu danh mục mới</asp:ListItem>
            <asp:ListItem Value="4">Bạn chưa nhập tên mẫu danh mục</asp:ListItem>
            <asp:ListItem Value="5">Mẫu danh mục mới đã được ghi nhận</asp:ListItem>
            <asp:ListItem Value="6">Tạo mới mẫu danh mục: </asp:ListItem>
            <asp:ListItem Value="7">Cập nhật mẫu danh mục: </asp:ListItem>
            <asp:ListItem Value="8">Xoá mẫu danh mục: </asp:ListItem>
            <asp:ListItem Value="9">Bạn không được cấp quyền sử dụng chức năng này</asp:ListItem>
            <asp:ListItem Value="10">Tạo mới</asp:ListItem>
            <asp:ListItem Value="11">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="12">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="13">Mẫu danh mục : </asp:ListItem>
            <asp:ListItem Value="14">-------- Mẫu mới --------</asp:ListItem>
            <asp:ListItem Value="15">Xoá mẫu danh mục thành công!</asp:ListItem>
        </asp:DropDownList></TD></TR></TBODY></TABLE>
        <input id="hidTemplate" type="hidden" value="0" runat="server" name="hidTemplate">
        <input id="hidTemplateName" type="hidden" runat="server" name="hidTemplateName">
        <input id="hidAddRight" type="hidden" runat="server" value="0" name="hidAddRight">
        <input id="hidUpdateRight" type="hidden" runat="server" value="0" name="hidUpdateRight">
    </form>
    <script language="javascript">
        document.forms[0].txtTitle.focus();
    </script>
</body>
</html>
