<%@ Reference Page="~/Acquisition/ACQ/WBarcodeForm.aspx" %>

<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WBarcodeForm" CodeFile="WBarcodeForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>In mã vạch</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <style>
        #txtElse {
            border: 1px solid #a2a2a2;
            height: 80px;
            width: 100%;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <table id="AcqBarCode" width="100%" cellpadding="2" cellspacing="1">
            <tr class="lbPageTitle">
                <td colspan="3" width="100%" align="center">
                    <asp:Label CssClass="main-group-form" ID="lblTitle" runat="server"> In mã vạch cho tài liệu</asp:Label></td>
            </tr>
            <tr class="lbGroupTitle">
                <td width="40%">
                    <asp:Label ID="lblFilter" runat="server" CssClass="lbGroupTitle">Điều kiện lọc</asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblContentPrint" runat="server" CssClass="lbGroupTitle">Chọn nội dung in</asp:Label>
                </td>
                <td width="35%">
                    <asp:Label ID="lblBarCodeFormal" runat="server" CssClass="lbGroupTitle">Chọn kiểu hiển thị cho ảnh</asp:Label>
                </td>
            </tr>
            <tr valign="top">
                <td width="40%">
                    <table id="FilterTable" cellspacing="2" cellpadding="1" width="100%">
                        <tr style="display: none">
                            <td align="right" width="28%">
                                <asp:Label ID="lblLibrary" runat="server">Chọn thư <u>v</u>iện: </asp:Label></td>
                            <td width="72%">
                                <asp:DropDownList ID="ddlLibrary" runat="server" Height="32px"></asp:DropDownList></td>
                        </tr>
                        <tr style="display: none;">
                            <td align="right" width="28%">
                                <asp:Label ID="lblStore" runat="server">Kh<u>o</u>:</asp:Label></td>
                            <td width="72%">
                                <asp:DropDownList ID="ddlStore" runat="server" Style="display: none;"></asp:DropDownList>
                                <input type="hidden" id="hdStore" runat="server" name="hdStore" value="0" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RadioButton ID="optCodeItem" runat="server" Checked="True" GroupName="FilterChoice" TabIndex="3"
                                    Text="<u>M</u>ã tài  liệu"></asp:RadioButton></td>
                        </tr>
                        <tr>
                            <td align="right" width="28%">
                                <asp:Label ID="lblFromCodeItem" runat="server"><u>T</u>ừ mã tài liệu: </asp:Label>
                            </td>
                            <td width="72%">
                                <asp:TextBox ID="txtFromCodeItem" runat="server"></asp:TextBox>&nbsp;<asp:HyperLink ID="hrfFromCodeItem" runat="server" NavigateUrl="abc.aspx">Tìm</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td align="right" width="28%">
                                <asp:Label ID="lblToCodeItem" runat="server">Tớ<u>i</u> mã tài liệu: </asp:Label></td>
                            <td width="72%">
                                <asp:TextBox ID="txtToCodeItem" runat="server"></asp:TextBox>&nbsp;<asp:HyperLink ID="hrfToCodeItem" runat="server" NavigateUrl="abc.aspx">Tìm</asp:HyperLink></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RadioButton ID="optCopyNumber" runat="server" GroupName="FilterChoice" Text="Mã <u>x</u>ếp giá"></asp:RadioButton></td>
                        </tr>
                        <tr>
                            <td align="right" width="28%">
                                <asp:Label ID="lblFromCopyNumber" runat="server">Từ ĐK<U>C</U>B: </asp:Label></td>
                            <td width="72%">
                                <asp:TextBox ID="txtFromCopyNumber" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" width="28%">
                                <asp:Label ID="lblToCopyNumber" runat="server">Tới Đ<u>K</u>CB: </asp:Label></td>
                            <td width="72%">
                                <asp:TextBox ID="txtToCopyNumber" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RadioButton ID="optElse" runat="server" GroupName="FilterChoice" Text="In th<u>e</u>o các đăng ký cá biệt nhập dưới đây"></asp:RadioButton></td>
                        </tr>
                        <tr valign="top">
                            <td width="72%"></td>
                            <td width="72%">
                                <asp:TextBox ID="txtElse" runat="server" Width="100%" TextMode="MultiLine" Wrap="False" Height="80px"></asp:TextBox></td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <table id="ContentPrint" width="100%">
                        <tr valign="top">
                            <td width="100%">
                                <asp:CheckBox ID="ckbShelf" runat="server" Text="Gi<u>á</u>"></asp:CheckBox>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td width="100%">
                                <asp:CheckBox ID="ckbItemCode" runat="server" Text="Mã tài <u>l</u>iệu"></asp:CheckBox>
                            </td>
                        </tr>
                        <tr valign="top">
                            <td width="100%">
                                <asp:CheckBox ID="ckbCopyNumber" runat="server" Checked="True" Text="<u>Đ</u>ăng ký cá biệt"></asp:CheckBox></td>
                        </tr>
                    </table>
                </td>
                <td width="35%">
                    <table id="BarCodeFormal" width="100%">
                        <tr>
                            <td align="right" width="75%">
                                <asp:Label ID="lblType" runat="server">Kiểu <u>B</u>arcode: </asp:Label></td>
                            <td width="72%">
                                <asp:DropDownList ID="ddlType" runat="server">
                                    <asp:ListItem Value="1">EAN-13</asp:ListItem>
                                    <asp:ListItem Value="2">EAN-8</asp:ListItem>
                                    <asp:ListItem Value="3">UPC-A</asp:ListItem>
                                    <asp:ListItem Value="4">Code 39 Check</asp:ListItem>
                                    <asp:ListItem Value="5">Codabar</asp:ListItem>
                                    <asp:ListItem Value="6">Code 39</asp:ListItem>
                                    <asp:ListItem Value="7">2 of 5</asp:ListItem>
                                    <asp:ListItem Value="8">Interleaved 2 of 5 (ITF)</asp:ListItem>
                                    <asp:ListItem Value="9">UPC-E</asp:ListItem>
                                    <asp:ListItem Value="10">EAN-13 + 2</asp:ListItem>
                                    <asp:ListItem Value="11">EAN-13 + 5</asp:ListItem>
                                    <asp:ListItem Value="12">EAN-8 + 2</asp:ListItem>
                                    <asp:ListItem Value="13">EAN-8 + 5</asp:ListItem>
                                    <asp:ListItem Value="14">UPC-A + 2</asp:ListItem>
                                    <asp:ListItem Value="15">UPC-A + 5</asp:ListItem>
                                    <asp:ListItem Value="16">UPC-E + 2</asp:ListItem>
                                    <asp:ListItem Value="17">UPC-E + 5</asp:ListItem>
                                    <asp:ListItem Value="18">EAN-128 A</asp:ListItem>
                                    <asp:ListItem Value="19">EAN-128 B</asp:ListItem>
                                    <asp:ListItem Value="20">EAN-128 C</asp:ListItem>
                                    <asp:ListItem Value="21">Code 93</asp:ListItem>
                                    <asp:ListItem Value="22">POSTNET</asp:ListItem>
                                    <asp:ListItem Value="23" Selected="True">Code-128 A</asp:ListItem>
                                    <asp:ListItem Value="24">Code-128 B</asp:ListItem>
                                    <asp:ListItem Value="25">Code-128 C</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" width="75%">
                                <asp:Label ID="lblHeight" runat="server">Chiều c<u>a</u>o: </asp:Label></td>
                            <td width="72%">
                                <asp:TextBox ID="txtHeight" runat="server" Width="60px">70</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" width="75%">
                                <asp:Label ID="lblWidth" runat="server">Chiều rộn<u>g</u>: </asp:Label></td>
                            <td width="72%">
                                <asp:TextBox ID="txtWidth" runat="server" Width="60px">1</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" width="75%">
                                <asp:Label ID="lblImageType" runat="server">Kiểu ản<u>h</u>: </asp:Label></td>
                            <td width="72%">
                                <asp:DropDownList ID="ddlImageType" runat="server">
                                    <asp:ListItem Value="3" Selected="true">JPG</asp:ListItem>
                                    <asp:ListItem Value="5">PNG</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" width="75%">
                                <asp:Label ID="lblRotation" runat="server">Hướng <u>q</u>uay: </asp:Label></td>
                            <td width="72%">
                                <asp:DropDownList ID="ddlRotation" runat="server">
                                    <asp:ListItem Value="0" Selected="True">Không quay</asp:ListItem>
                                    <asp:ListItem Value="1">90 độ</asp:ListItem>
                                    <asp:ListItem Value="2">180 độ</asp:ListItem>
                                    <asp:ListItem Value="3">270 độ</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" width="75%">
                                <asp:Label ID="lblRowSpace" runat="server"><u>K</u>/c giữa các hàng: </asp:Label></td>
                            <td width="72%">
                                <asp:TextBox ID="txtRowSpace" runat="server" Width="60px">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" width="75%">
                                <asp:Label ID="lblColSpace" runat="server">K/c giữa các cộ<u>t</u>: </asp:Label></td>
                            <td width="72%">
                                <asp:TextBox ID="txtColSpace" runat="server" Width="60px">0</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" width="75%">
                                <asp:Label ID="lblColNumber" runat="server">Số ảnh/<u>d</u>òng: </asp:Label></td>
                            <td width="72%">
                                <asp:TextBox ID="txtColNumber" runat="server" Width="60px">4</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="right" width="75%">
                                <asp:Label ID="lblPage" runat="server">Số ảnh/trang: </asp:Label></td>
                            <td width="72%">
                                <asp:TextBox ID="txtPage" runat="server" Width="60px">52</asp:TextBox></td>
                        </tr>
                        <tr>
                            <td width="75%" align="right">
                                <asp:Label ID="lblBarCodeType" runat="server">M<u>ẫ</u>u : </asp:Label></td>
                            <td width="72%">
                                <asp:DropDownList ID="ddlBarCodeType" runat="server"></asp:DropDownList></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="lbControlBar">
                <td>
                    <asp:Button ID="btnBarCode" runat="server" Text="In ra máy in lazer(z)" Width="160px"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Button ID="btnReset" runat="server" Text="Đặt lại(r)" Width="80px"></asp:Button></td>
                <td></td>
                <td align="right">
                    <asp:Button ID="btnBarCodePrint" runat="server" Text="In ra máy in BarCode(b)" Width="180px"></asp:Button></td>
            </tr>
        </table>
        </TR></TABLE></TR></TABLE>
			<asp:DropDownList ID="ddlLog" runat="server" Visible="False" Width="0" Height="0">
                <asp:ListItem Value="PrintBarCode">In mã vạch cho tài liệu</asp:ListItem>
                <asp:ListItem Value="ErrorMsg">Chi tiết lỗi </asp:ListItem>
                <asp:ListItem Value="ErrorCode">Mã lỗi </asp:ListItem>
                <asp:ListItem Value="Permission">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
                <asp:ListItem Value="4">Không tìm thấy dữ liệu!</asp:ListItem>
                <asp:ListItem Value="5">------ Chọn ------</asp:ListItem>
                <asp:ListItem Value="6">Chưa chọn mẫu mã vạch</asp:ListItem>
            </asp:DropDownList>
        <input type="hidden" id="hdChoice" runat="server" name="hdChoice" value="1">
    </form>
</body>
</html>
