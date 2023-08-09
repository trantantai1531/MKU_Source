<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WCardTemplate" CodeFile="WCardTemplate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCardTemplate</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body topmargin="0" leftmargin="0" rightmargin="0" onload="document.forms[0].ddlTemplate.focus()">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Mẫu thẻ</h1>
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
                            <p>Tên mẫu :</p>
                            <asp:Label ID="lblMan" runat="server" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc phải nhập dữ liệu">(*)</asp:Label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server" Width="200px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Thông tin :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlInf" runat="server">
                                        <asp:ListItem Value="--------------">---------- Chọn -----------</asp:ListItem>
                                        <asp:ListItem Value="<$CODE$>">Số thẻ</asp:ListItem>
                                        <asp:ListItem Value="<$NAME$>">Họ tên</asp:ListItem>
                                        <asp:ListItem Value="<$DOB$>">Ngày sinh</asp:ListItem>
                                        <asp:ListItem Value="<$OCCUPATION$>">Nghề nghiệp</asp:ListItem>
                                        <asp:ListItem Value="<$WORKPLACE$>">Cơ quan</asp:ListItem>
                                        <asp:ListItem Value="<$ADDRESS$>">Địa chỉ thường trú</asp:ListItem>
                                        <asp:ListItem Value="<$TELEPHONE$>">Số điện thoại</asp:ListItem>
                                        <asp:ListItem Value="<$CLASS$>">Lớp</asp:ListItem>
                                        <asp:ListItem Value="<$GRADE$>">Khoá</asp:ListItem>
                                        <asp:ListItem Value="<$FACULTY$>">Khoa</asp:ListItem>
                                        <asp:ListItem Value="<$CARDVALIDDATE$>">Ngày cấp thẻ</asp:ListItem>
                                        <asp:ListItem Value="<$CARDEXPIREDDATE$>">Ngày hết hạn thẻ</asp:ListItem>
                                        <asp:ListItem Value="<$EMAIL$>">Email</asp:ListItem>
                                        <asp:ListItem Value="<$ETHNIC$>">Dân tộc</asp:ListItem>
                                        <asp:ListItem Value="<$BARCODE$>">Mã vạch</asp:ListItem>
                                        <asp:ListItem Value="<$PICTURE$>">Ảnh</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Nội dung :</p>

                            <div class="input-control">
                                    <FCKeditorV2:FCKeditor ID="fckContent" EnableXHTML="true" runat="server" BasePath="../fckeditor/"
                                        Height="335px" Width="620px" SkinPath="skins/silver/" StartupFocus="false"
                                        ToolbarSet="Advance">
                                    </FCKeditorV2:FCKeditor>

                                    <asp:TextBox CssClass="text-input" style="display: none" ID="txtContent" runat="server" Width="560px" Columns="100" Rows="10" TextMode="MultiLine"
                                        Height="235px" Wrap="False"></asp:TextBox>
                                </div>
                
                        </div>
                    </div>
                </div>

                <div class="row-detail">
                    <div class="button-control inline-box">
                        <div class="button-form">
                            <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật(u)" Width="88px"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnView" runat="server" Text="Xem trước(v)" Width="98px"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" runat="server" Text="Đặt lại(r)" Width="83px"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnDelete" runat="server" Text="Xoá(d)" Width="63px"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
            <asp:ListItem Value="3">---------- Tạo mới ----------</asp:ListItem>
            <asp:ListItem Value="4">Chọn OK nếu bạn thực sự muốn xoá mẫu thẻ bạn đọc!</asp:ListItem>
            <asp:ListItem Value="5">Cập nhật khuôn dạng thẻ đọc</asp:ListItem>
            <asp:ListItem Value="6">Xoá khuôn dạng thẻ đọc</asp:ListItem>
            <asp:ListItem Value="7">thành công!</asp:ListItem>
            <asp:ListItem Value="8">Bạn chưa chọn khuôn dạng thẻ cần xoá!</asp:ListItem>
            <asp:ListItem Value="9">Bạn chưa nhập tên khuôn dạng!</asp:ListItem>
            <asp:ListItem Value="10">Khuôn dạng thẻ đã tồn tại!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
