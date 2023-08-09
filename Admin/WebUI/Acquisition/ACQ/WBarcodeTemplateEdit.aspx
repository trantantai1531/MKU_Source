<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WBarcodeTemplateEdit" CodeFile="WBarcodeTemplateEdit.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WBarcodeTemplateEdit</title>
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
            <div class="content-form">
                <h1 class="main-head-form">Định dạng cho mã vạch</h1>
                <div class="main-form">
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
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server" Width=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Nội dung :</p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox CssClass="area-input" ID="txtContent" runat="server" Columns="100" Rows="10" TextMode="MultiLine" Wrap="False"
                                Width="" Height="90px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnUpdate" runat="server" Text="Cập nhật(u)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnView" runat="server" Text="Xem trước(v)"></asp:Button>

                        </div>
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnReset" runat="server" Text="Làm lại(r)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnDelete" runat="server" Text="Xoá(d)"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
                </div>
        </div>
        <asp:DropDownList ID="ddlLog" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Tạo mới mẫu nhãn gáy, nhãn bìa </asp:ListItem>
            <asp:ListItem Value="1">Cập nhật mẫu nhãn gáy, nhãn bìa</asp:ListItem>
            <asp:ListItem Value="2">Xoá mẫu nhãn gáy, nhãn bìa</asp:ListItem>
            <asp:ListItem Value="3">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="4">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="5">Bạn không được cấp quyền sử dụng tính năng này! </asp:ListItem>
            <asp:ListItem Value="6">---------- Tạo mới ----------</asp:ListItem>
            <asp:ListItem Value="7">Nhấn OK nếu thực sự muốn xoá mẫu này!</asp:ListItem>
            <asp:ListItem Value="8">Bạn chưa nhập tên mẫu!</asp:ListItem>
            <asp:ListItem Value="9">Cập nhật mẫu thành công!</asp:ListItem>
            <asp:ListItem Value="10">Tên mẫu đã tồn tại hoặc lỗi trong quá trình cập nhật!</asp:ListItem>
            <asp:ListItem Value="11">Bạn chưa chọn mẫu cần làm việc!</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtTitle.focus();
    </script>

</body>
</html>
