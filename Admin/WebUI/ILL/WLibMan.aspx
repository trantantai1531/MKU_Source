<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WLibMan" CodeFile="WLibMan.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WLibMan</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
  
</head>
<body leftmargin="0" topmargin="0" onload="OnLoad();parent.document.getElementById('frmSubMain').setAttribute('rows',rows='*,0');">
    <form id="Form1" method="post" runat="server">
        <table id="Table1" cellspacing="0" cellpadding="2" width="100%" border="0">
            <tr class="lbPageTitle">
                <td colspan="5">
                    <asp:Label ID="lblMainTitle" runat="server" CssClass="lbGroupTitle">Danh sách thư viện</asp:Label></td>
            </tr>
            <tr>
                <td valign="top" width="15%" rowspan="2">
                    <asp:ListBox ID="lstLibrary" runat="server" Height="280px" Width="100%"></asp:ListBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <table id="Table2" cellspacing="0" cellpadding="2" width="100%" border="0">
                        <tr>
                            <td align="right" width="35%">
                                <asp:Label ID="lblFullName" runat="server"><u>K</u>ý hiệu :</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtSymbol" Width="168px" runat="server" MaxLength="50"></asp:TextBox>
                                <asp:Label ID="lblMan1" runat="server" ToolTip="Trường bắt buộc" Font-Bold="True" ForeColor="Red">(*)</asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblContactName" runat="server"><u>T</u>ên:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtName" Width="168px" runat="server" MaxLength="100"></asp:TextBox>
                                <asp:Label ID="lblMan2" runat="server" ToolTip="Trường bắt buộc" Font-Bold="True" ForeColor="Red">(*)</asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEmailAddress" runat="server">Địa chỉ <u>e</u>mail:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtEmailAddress" Width="168px" runat="server"></asp:TextBox>
                                <asp:Label ID="lblMan3" runat="server" ToolTip="Trường bắt buộc" Font-Bold="True" ForeColor="Red">(*)</asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPhone" runat="server">Đ<u>i</u>ện thoại:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtPhone" Width="168px" runat="server" MaxLength="14"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblFax" runat="server"><u>M</u>ã số cục bộ:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtCode" Width="168px" runat="server"></asp:TextBox>
                                <asp:Label ID="lblMan4" runat="server" ToolTip="Trường bắt buộc" Font-Bold="True" ForeColor="Red">(*)</asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" valign="top">
                                <asp:Label ID="lblNote" runat="server"><u>G</u>hi chú:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtNote" Height="48px" Width="208px" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                <asp:Label ID="lblDinamicAddress" runat="server" Font-Size="13pt" >Địa chỉ giao nhận điện tử:</asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEdelivPassword" runat="server">Tên <u>d</u>ịch vụ:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtEDelivMode" Width="168px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblRetypePassword" runat="server">Đị<u>a</u> chỉ:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtEDelivTSAdd" Width="168px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblEncodingSchema" runat="server">Chế độ mã hoá thư:</asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlEncodingSchema" runat="server">
                                    <asp:ListItem Value="0">XML</asp:ListItem>
                                    <asp:ListItem Value="1">BASE 64</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </td>
                <td colspan="2">
                    <table id="Table3" cellspacing="0" cellpadding="2" width="100%" border="0">
                        <tr>
                            <td align="right" width="42%"></td>
                            <td>
                                <asp:RadioButton ID="rdoPosAddress" runat="server" Checked="True" Text="Địa chỉ <u>n</u>hận"></asp:RadioButton></td>
                        </tr>
                        <tr>
                            <td align="right"></td>
                            <td>
                                <asp:RadioButton ID="rdoBillAddress" runat="server" Text="Địa chỉ thanh t<u>o</u>án "></asp:RadioButton></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblAddress" runat="server">Tên đơn <u>v</u>ị (dòng 1):</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDelivName" Width="168px" runat="server" MaxLength="100"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblBox" runat="server">Địa chỉ đơn <u>v</u>ị (dòng 2):</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDelivXAddr" Width="168px" runat="server" MaxLength="200"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCity" runat="server">Đường <u>p</u>hố:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDelivStreet" Width="168px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblArea" runat="server"><u>H</u>ộp thư:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDelivBox" Width="168px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblCountry" runat="server">Thành ph<u>ố</u>:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDelivCity" Width="168px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPostalCode" runat="server">Khu vự<u>c</u>:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDelivRegion" Width="168px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDebt" runat="server"><u>Q</u>uốc gia:</asp:Label></td>
                            <td>
                                <asp:DropDownList ID="ddlCountry" runat="server" style="width: 168px;"></asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblStatus" runat="server"> Mã <u>b</u>ưu điện:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="txtDelivCode" Width="168px" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right"></td>
                            <td></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="lbControlBar">
                <td></td>
                <td align="right" colspan="2">
                    <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật(u)" Width="98px"></asp:Button>
                    <asp:Button ID="btnReset" runat="server" Text="Đặt lại(r)" Width="92px"></asp:Button>
                    <asp:Button ID="btnDelete" runat="server" Text="Xoá(d)" Width="64px"></asp:Button></td>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td colspan="5">
                    <p>
                        <input id="hidLibID" type="hidden" value="0" runat="server">
                        <input id="hidBillDelivName" type="hidden" runat="server">
                        <input id="hidBillDelivXAddr" type="hidden" runat="server">
                    </p>
                    <p>
                        <input id="hidBillDelivStreet" type="hidden" runat="server">
                        <input id="hidBillDelivBox" type="hidden" runat="server">
                        <input id="hidBillDelivCity" type="hidden" runat="server">
                        <input id="hidBillDelivRegion" type="hidden" runat="server">
                    </p>
                    <p>
                        <input id="hidBillDelivCountry" type="hidden" runat="server" value="0">
                        <input id="hidBillDelivCode" type="hidden" runat="server">
                        <input id="hidPostDelivName" type="hidden" runat="server">
                        <input id="hidPostDelivXAddr" type="hidden" runat="server">
                    </p>
                    <p>
                        <input id="hidPostDelivStreet" type="hidden" runat="server">
                        <input id="hidPostDelivBox" type="hidden" runat="server">
                        <input id="hidPostDelivCity" type="hidden" runat="server">
                        <input id="hidPostDelivRegion" type="hidden" runat="server">
                    </p>
                    <p>
                        <input id="hidPostDelivCountry" type="hidden" runat="server" value="0">
                        <input id="hidPostDelivCode" type="hidden" runat="server">
                    </p>
                </td>
            </tr>
        </table>
        <input id="hidNoDel" runat="server" type="hidden" value="0">
        <asp:DropDownList ID="ddlLabel" Visible="False" runat="server" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Nhập thông tin thư viện mới</asp:ListItem>
            <asp:ListItem Value="3">Cập nhật thông tin thư viện</asp:ListItem>
            <asp:ListItem Value="4">Xoá thư viện</asp:ListItem>
            <asp:ListItem Value="5">Ký hiệu</asp:ListItem>
            <asp:ListItem Value="6">Tên</asp:ListItem>
            <asp:ListItem Value="7">Địa chỉ email</asp:ListItem>
            <asp:ListItem Value="8">Địa chỉ email không hợp lệ</asp:ListItem>
            <asp:ListItem Value="9">Giá trị của trường</asp:ListItem>
            <asp:ListItem Value="10">là bắt buộc</asp:ListItem>
            <asp:ListItem Value="11">Cập nhật dữ liệu thành công</asp:ListItem>
            <asp:ListItem Value="12">Việc xóa thư viện sẽ xóa tất cả các yêu cầu liên quan tới thư viện, bạn thực sự muốn xoá thư viện này? </asp:ListItem>
            <asp:ListItem Value="13">Xoá thư viện thành công</asp:ListItem>
            <asp:ListItem Value="14">------ Thêm mới ------</asp:ListItem>
            <asp:ListItem Value="15">Ký hiệu và địa chỉ E-mail thư viện đã tồn tại trong CSDL!</asp:ListItem>
            <asp:ListItem Value="16">Bạn chưa chọn thư viện cần xoá!</asp:ListItem>
            <asp:ListItem Value="17">Mã số cục bộ</asp:ListItem>
            <asp:ListItem Value="18">Mã số cục bộ đã tồn tại trong CSDL !</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtSymbol.focus();
    </script>
</body>
</html>
