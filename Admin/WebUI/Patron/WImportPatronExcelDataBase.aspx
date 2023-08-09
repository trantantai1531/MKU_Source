<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WImportPatronExcelDataBase.aspx.vb" Inherits="eMicLibAdmin.WebUI.Patron.WImportPatronExcelDataBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Đặt giá trị ngầm định</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="2" topmargin="0">
    <form id="frm" method="post" runat="server">
        <div id="divBody">
            <div class="row-detail">
                <h1 class="main-head-form">Import Dữ liệu từ file excel</h1>
                <h1 class="main-group-form">Nhập file excel cần import</h1>
                <div class="group-row">
                    <p>Đường dẫn file:</p>
                    <div class="row-detail">
                        <div class="input-control">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Button ID="btnImportData" runat="server"  CssClass="form-btn" Text="Import data" OnClientClick="myFunction()" />
                        </div>
                        <div class="input-control" id="message" style="display: none;">
                            Đang xử lý vui lòng chờ
                        </div>
                    </div>
                    <div class="input-control" id="Div1" runat="server">
                        <asp:Label ID="lbSuccess" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lbTotalInput" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblErrorDataCat" runat="server" Text=""></asp:Label><br />
                    </div>
                </div>
            </div>
        </div>
        <input id="hidID" type="hidden" runat="server" />
        <input id="hidError" type="hidden" runat="server" name="hidError" value="0" />
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="3">Cả hai chỉ thị dữ liệu không hợp lệ</asp:ListItem>
            <asp:ListItem Value="5">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="6">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="7">Không tồn tại</asp:ListItem>
            <asp:ListItem Value="8">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
            <asp:ListItem Value="9">Cập nhật dữ liệu thành công!</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script type="text/javascript" language="javascript">
        function myFunction()
        {
            if (document.getElementById("FileUpload1").value != "")
            {
                var message = document.getElementById("message");
                console.log(document.getElementById("FileUpload1").value);
                message.style.display = null;
                return true;
            }
            else
            {
                alert("Vui lòng chọn file upload");
                return false;
            }
        }
    </script>
</body>
</html>