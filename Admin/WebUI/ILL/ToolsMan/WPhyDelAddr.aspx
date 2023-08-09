<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WPhyDelAddr" CodeFile="WPhyDelAddr.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Danh mục địa chỉ giao nhận, thanh toán</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <style>
        input.lbTextBox,select {
            margin-bottom: 10px;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <table id="tblPhyDelAddr" width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="100%" colspan="2">
                    <asp:Label ID="lblMainTitle" runat="server" CssClass="main-head-form" Width="100%">Phương thức giao nhận, thanh toán</asp:Label></td>
            </tr>
            <tr class="lbSubFormTitle">
                <td width="25%">
                    <asp:Label ID="lblAddressIndex" runat="server" CssClass="lbSubFormTitle">D<U>a</U>nh mục địa chỉ</asp:Label></td>
                <td width="75%"></td>
            </tr>
            <tr>
                <td width="25%" align="center">
                    <asp:ListBox ID="lsbAddressIndex" runat="server" Width="90%" Height="200px"></asp:ListBox></td>
                <td width="75%">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="20%" align="right">
                                <asp:Label ID="lblAddress" runat="server">Địa chỉ dòng <u>1</u>: </asp:Label></td>
                            <td width="80%">
                                <asp:TextBox ID="txtAddress" runat="server" MaxLength="100"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="20%" align="right">
                                <asp:Label ID="lblXAddrerss" runat="server">Địa chỉ dòng <u>2</u>: </asp:Label></td>
                            <td width="80%">
                                <asp:TextBox ID="txtXAddress" runat="server" MaxLength="100"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="20%" align="right">
                                <asp:Label ID="lblStreet" runat="server">Địa <u>c</u>hỉ: </asp:Label></td>
                            <td width="80%">
                                <asp:TextBox ID="txtStreet" runat="server" MaxLength="64"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="20%" align="right">
                                <asp:Label ID="lblPOBox" runat="server">P<u>O</u> Box: </asp:Label></td>
                            <td width="80%">
                                <asp:TextBox ID="txtPOBox" runat="server" MaxLength="32"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="20%" align="right">
                                <asp:Label ID="lblCity" runat="server">Thành <u>p</u>hố/Tỉnh</asp:Label></td>
                            <td width="80%">
                                <asp:TextBox ID="txtCity" runat="server" MaxLength="40"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="20%" align="right">
                                <asp:Label ID="lblRegion" runat="server">Khu <u>v</u>ực: </asp:Label></td>
                            <td width="80%">
                                <asp:TextBox ID="txtRegion" runat="server" MaxLength="50"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="20%" align="right">
                                <asp:Label ID="lblCountry" runat="server">Quốc gi<u>a</u>: </asp:Label></td>
                            <td width="80%">
                                <asp:DropDownList ID="ddlCountry" runat="server"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td width="20%" align="right">
                                <asp:Label ID="lblPostCode" runat="server">Mã bư<u>u</u> điện: </asp:Label></td>
                            <td width="80%">
                                <asp:TextBox ID="txtPostCode" runat="server" MaxLength="10"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="25%"></td>
                <td width="75%"></td>
            </tr>
            <tr class="lbControlBar">
                <td colspan="2" width="100%" align="center">&nbsp;
						<asp:Button ID="btnUpdate" runat="server" Text="Cập nhật(u)" Width="95px"></asp:Button>&nbsp;
						<asp:Button ID="btnDelete" runat="server" Text="Xoá(d)" Width="65px"></asp:Button>&nbsp;&nbsp;
						<asp:Button ID="btnClose" runat="server" Text="Đóng(o)" Width="80px"></asp:Button>
                </td>
            </tr>
        </table>
        <input type="hidden" id="hdAddressIndex" runat="server" name="hdAddressIndex">
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">----------- Chọn ----------</asp:ListItem>
            <asp:ListItem Value="3">----------- Tạo mới ----------</asp:ListItem>
            <asp:ListItem Value="4">Bạn chưa nhập đủ thông tin bắt buộc</asp:ListItem>
            <asp:ListItem Value="5">Chọn OK nếu bạn thực sự muốn xoá mục từ</asp:ListItem>
            <asp:ListItem Value="6">Cập nhật mục từ</asp:ListItem>
            <asp:ListItem Value="7">Xoá mục từ</asp:ListItem>
            <asp:ListItem Value="8">thành công</asp:ListItem>
            <asp:ListItem Value="9">Mục từ đã tồn tại</asp:ListItem>
            <asp:ListItem Value="10">Bạn chưa chọn bản ghi cần làm việc</asp:ListItem>
            <asp:ListItem Value="11">Bạn không được cấp quyền sử dụng chức năng này.</asp:ListItem>
            <asp:ListItem Value="12">Xóa mục từ không thành công (mục từ đang được sử dụng trong các yêu cầu).</asp:ListItem>
            <asp:ListItem Value="13">Xóa mục từ thành công.</asp:ListItem>
        </asp:DropDownList>
        <script language="javascript">
            document.forms[0].txtAddress.focus();
        </script>
    </form>
</body>
</html>
