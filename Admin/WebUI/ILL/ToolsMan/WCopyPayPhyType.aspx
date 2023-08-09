<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WCopyPayPhyType" CodeFile="WCopyPayPhyType.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Danh mục thông tin</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <style>
        input.lbTextBox {
            margin-bottom: 10px;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <table id="tblCopyPayPhyType" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td width="100%">
                    <asp:Label ID="lblMainTitle" Width="100%" runat="server" CssClass="main-head-form"></asp:Label></td>
            </tr>
            <tr>
                <td height="7"></td>
            </tr>
            <tr>
                <td width="100%">
                    <table id="tblSub" cellspacing="0" cellpadding="3" width="100%" border="0">
                        <tr>
                            <td align="right" width="30%">
                                <asp:Label ID="lblNewPayment" runat="server"><U>T</U>ên mới: </asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtNewPayment" Width="200px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" width="30%"></td>
                            <td width="80%">
                                <asp:Button ID="btnAddnew" Width="98px" runat="server" Text="Cập nhật(u)"></asp:Button>&nbsp;
									<asp:Button ID="btnClose" Width="70px" runat="server" Text="Đóng(o)"></asp:Button></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%">
                    <div class="table-form">
                        <asp:DataGrid ID="dgrCopyPayPhyType" Width="100%" runat="server" HeaderStyle-HorizontalAlign="Center"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True"></asp:BoundColumn>
                                <asp:BoundColumn DataField="TYPE" HeaderText="Phương thức">
                                    <HeaderStyle Width="80%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:EditCommandColumn HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ButtonType="LinkButton" UpdateText="<Image src='../Images/update.gif' border='0' title='Cập nhật'>"
                                    CancelText="<Image src='../Images/Cancel.gif' border='0' title='Huỷ'>" EditText="<image src = '../Images/Edit.gif' border='0' title='Sửa'>">
                                    <HeaderStyle Width="15%"></HeaderStyle>
                                </asp:EditCommandColumn>
                                <asp:ButtonColumn HeaderText="Xoá" ItemStyle-HorizontalAlign="Center" Text="<IMAGE SRC='../Images/Delete.gif'; border='0' title='Xoá'>"
                                    CommandName="Delete">
                                    <HeaderStyle Width="5%"></HeaderStyle>
                                </asp:ButtonColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </td>
            </tr>
        </table>
        <input id="hdMode" type="hidden" value="COPYRIGHT" name="hdMode" runat="server" />
        <asp:DropDownList ID="ddlLabel" Width="0" runat="server" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Phương thức thanh toán</asp:ListItem>
            <asp:ListItem Value="3">Phương thức giao nhận vật lý</asp:ListItem>
            <asp:ListItem Value="4">Chế định bảo vệ bản quyền</asp:ListItem>
            <asp:ListItem Value="5">Tên phương thức là bắt buộc</asp:ListItem>
            <asp:ListItem Value="6">Nhấn OK để khẳng định xoá phương thức này</asp:ListItem>
            <asp:ListItem Value="7">Cập nhật phương thức giao nhận vật lý</asp:ListItem>
            <asp:ListItem Value="8">Xoá phương thức giao nhận vật lý</asp:ListItem>
            <asp:ListItem Value="9">Cập nhật chế định bảo vệ bản quyền</asp:ListItem>
            <asp:ListItem Value="10">Xoá nhật chế định bảo vệ bản quyền</asp:ListItem>
            <asp:ListItem Value="11">Cập nhật phương thức thanh toán</asp:ListItem>
            <asp:ListItem Value="12">Xoá phương thức thanh toán</asp:ListItem>
            <asp:ListItem Value="13">Mục từ đã tồn tại trong CSDL</asp:ListItem>
            <asp:ListItem Value="14">Cập nhập thành công!</asp:ListItem>
            <asp:ListItem Value="15">Xoá danh mục thành công!</asp:ListItem>
            <asp:ListItem Value="16">Bạn không được cấp quyền sử dụng chức năng này.</asp:ListItem>
            <asp:ListItem Value="17">Tên quá dài (tối đa là 50 ký tự).</asp:ListItem>
            <asp:ListItem Value="18">Xóa danh mục không thành công (danh mục đang được sử dụng trong các yêu cầu).</asp:ListItem>
        </asp:DropDownList>
        <input id="hidEMode" type="hidden" runat="server" name="hidEMode" />
        <script language="javascript">
            document.forms[0].txtNewPayment.focus();
        </script>
    </form>
</body>
</html>
