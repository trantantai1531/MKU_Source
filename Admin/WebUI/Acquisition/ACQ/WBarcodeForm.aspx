<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WBarcodeForm" CodeFile="WBarcodeForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html>
<head runat="server">
    <title>In mã vạch</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
        function colorChanged(sender) {
            sender.get_element().style.backcolor = "#" + sender.get_selectedColor();
            var txtForeColor = document.getElementById("txtForeColor");
            if (txtForeColor) {
                txtForeColor.style.backgroundColor = "#" + sender.get_selectedColor();
                txtForeColor.style.color = "#" + sender.get_selectedColor();
            }
        }
    </script>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="AcqBarCode" class="content-form">
                <h1 class="main-group-form">In mã vạch cho các tư liệu trong cơ sở dữ liệu.</h1>
                <div class="main-form">
                <div class="ClearFix" style="display: none">
                    <div class="col-left-6" style="display: none;">
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblLibrary" runat="server">Chọn thư <u>v</u>iện: </asp:Label>
                            </p>
                            <div class="input-control">
                                <div class="dropdown-form ">
                                    <asp:DropDownList ID="ddlLibrary" runat="server" Height=""></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblStore" runat="server">Kh<u>o</u>:</asp:Label>
                            </p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlStore" runat="server"></asp:DropDownList><input id="hdStore" type="hidden" value="0" name="hdStore" runat="server"/>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblFromDate" runat="server">T<u>h</u>ời gian từ: </asp:Label>&nbsp;<asp:HyperLink ID="lnkCalFrom" runat="server">Lịch</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtFromDate" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblToDate" runat="server">Tớ<u>i</u>: </asp:Label>&nbsp;<asp:HyperLink ID="lnkCalTo" runat="server">Lịch</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtToDate" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-left-6">
                        <table id="ContentPrint" width="100%" style="display: none;">
                            <tr valign="top">
                                <td width="100%">
                                    <asp:CheckBox ID="ckbShelf" runat="server" Text="Gi<u>á</u>"></asp:CheckBox></td>
                            </tr>
                            <tr valign="top">
                                <td width="100%">
                                    <asp:CheckBox ID="ckbItemCode" runat="server" Text="Mã tài <u>l</u>iệu"></asp:CheckBox></td>
                            </tr>
                            <tr valign="top">
                                <td width="100%">
                                    <asp:CheckBox ID="ckbCopyNumber" runat="server" Text="<u>Đ</u>ăng ký cá biệt" Checked="True"></asp:CheckBox></td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="ClearFix">
                    <div class="col-left-6">

                        <div class="radio-control">
                            <asp:RadioButton ID="optCodeItem" TabIndex="3" runat="server" Text="<u>M</u>ã tài  liệu" GroupName="FilterChoice"
                                Checked="True"></asp:RadioButton>
                            <label for="optCodeItem"></label>
                        </div>
                        <div class="row-detail">
                            <p>
                                Từ mã tài liệu :
                                <asp:HyperLink ID="hrfFromCodeItem" runat="server" NavigateUrl="abc.aspx">Tìm</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtFromCodeItem" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                Tới mã tài liệu:
                                <asp:HyperLink ID="hrfToCodeItem" runat="server" NavigateUrl="abc.aspx">Tìm</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtToCodeItem" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="radio-control">
                            <asp:RadioButton ID="optCopyNumber" runat="server" Text="Mã <u>x</u>ếp giá" GroupName="FilterChoice"></asp:RadioButton>
                            <label for="optCopyNumber"></label>
                        </div>
                        <div class="row-detail">
                            <p>Từ ĐKCB :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtFromCopyNumber" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tới ĐKCB :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtToCopyNumber" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="radio-control">
                            <asp:RadioButton ID="optElse" runat="server" Text="In th<u>e</u>o các đăng ký cá biệt nhập dưới đây"
                                GroupName="FilterChoice"></asp:RadioButton>
                            <label for="optElse"></label>
                        </div>
                        <div class="row-detail">
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtElse" CssClass="area-input" runat="server" Height="80px" Wrap="False" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row-detail">
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button CssClass="form-btn" ID="btnBarCode" runat="server" Text="In ra máy in lazer(z)" Width=""></asp:Button>
                                </div>
                                <div class="button-form">
                                    <asp:Button CssClass="form-btn" ID="btnReset" runat="server" Text="Đặt lại(r)" Width=""></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-right-4">
                        <div class="input-control" style="  height: 31px;">
                            <asp:CheckBox ID="chkGenerateLabel" runat="server" Text="Tạo nhãn" Checked="True"></asp:CheckBox>
                            <label for="chkGenerateLabel"></label>
                        </div>
                        <div class="row-detail">
                            <p>Kiểu Barcode :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlType" runat="server">
                                        <asp:ListItem Value="1">UPC-A</asp:ListItem>
                                        <asp:ListItem Value="2">UPC-E</asp:ListItem>
                                        <asp:ListItem Value="3">UPC 2 Digit Ext</asp:ListItem>
                                        <asp:ListItem Value="4">UPC 5 Digit Ext</asp:ListItem>
                                        <asp:ListItem Value="5">EAN-13</asp:ListItem>
                                        <asp:ListItem Value="6">JAN-13</asp:ListItem>
                                        <asp:ListItem Value="7">EAN-8</asp:ListItem>
                                        <asp:ListItem Value="8">ITF-14</asp:ListItem>
                                        <asp:ListItem Value="9">Interleaved 2 of 5</asp:ListItem>
                                        <asp:ListItem Value="10">Standard 2 of 5</asp:ListItem>
                                        <asp:ListItem Value="11">Codabar</asp:ListItem>
                                        <asp:ListItem Value="12">Postnet</asp:ListItem>
                                        <asp:ListItem Value="13">Bookland-ISBN</asp:ListItem>
                                        <asp:ListItem Value="14">Code 11</asp:ListItem>
                                        <asp:ListItem Value="15" Selected="True">Code 39</asp:ListItem>
                                        <asp:ListItem Value="16">Code 39 Extended</asp:ListItem>
                                        <asp:ListItem Value="17">Code 93</asp:ListItem>
                                        <asp:ListItem Value="18">Code 128</asp:ListItem>
                                        <asp:ListItem Value="19">Code 128-A</asp:ListItem>
                                        <asp:ListItem Value="20">Code 128-B</asp:ListItem>
                                        <asp:ListItem Value="21">Code 128-C</asp:ListItem>
                                        <asp:ListItem Value="22">LOGMARS</asp:ListItem>
                                        <asp:ListItem Value="23">MSI</asp:ListItem>
                                        <asp:ListItem Value="24">Telepen</asp:ListItem>
                                        <asp:ListItem Value="25">FIM (Facing Identification Mark)</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Chiều cao :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtHeight" runat="server" Width="">60</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Chiều rộng :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtWidth" runat="server" Width="">250</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Kiểu ảnh :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlImageType" runat="server">
                                        <asp:ListItem Value="1">GIF</asp:ListItem>
                                        <asp:ListItem Value="2">JPEG</asp:ListItem>
                                        <asp:ListItem Value="3" Selected="true">PNG</asp:ListItem>
                                        <asp:ListItem Value="4">TIFF</asp:ListItem>
                                        <asp:ListItem Value="5">BMP</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <asp:Label ID="lblRotation" runat="server">Hướng <u>q</u>uay: </asp:Label>
                            <div class="input-control">
                                <div class="dropdown-form ">
                                    <asp:DropDownList ID="ddlRotation" runat="server">
                                        <asp:ListItem Value="0" Selected="True">Không quay</asp:ListItem>
                                        <asp:ListItem Value="1">90 độ</asp:ListItem>
                                        <asp:ListItem Value="2">180 độ</asp:ListItem>
                                        <asp:ListItem Value="3">270 độ</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                         <div class="row-detail">
                            <p>K/c bên trên :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtMarginTop" runat="server" Width="">5</asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row-detail">
                            <p>K/c bên trái:</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtMarginLeft" runat="server" Width="">5</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>K/c giữa các hàng :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtRowSpace" runat="server" Width="">5</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>K/c giữa các cột :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtColSpace" runat="server" Width="">5</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                           <asp:CheckBox ID="cbBorder" runat="server" Text="Viền" Checked="True"></asp:CheckBox>
                            <label for="cbBorder"></label>
                           
                        </div>
                        <div class="row-detail">
                            <p>Số ảnh/dòng :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtColNumber" runat="server" Width="">4</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Số ảnh/trang:</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtPage" runat="server" Width="60px">60</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                        </div>
                                                <div class="row-detail">
                            <div class="two-column ClearFix">
                                <div class="two-column-form">
                                    <p>
                                        <asp:Label ID="lblBarCodeType" runat="server">M<u>ẫ</u>u : </asp:Label></p>
                                    <div class="input-control">
                                        <div class="dropdown-form">
                                            <asp:DropDownList ID="ddlBarCodeType" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="two-column-form" style="padding-left: 10px; width: 40%;">
                                    <p>Màu :</p>
                                    <div class="input-control">
                                        <div class="input-form " style="padding: 0px;">
                                            <asp:TextBox ID="txtForeColor" CssClass="text-input" runat="server"
                                                ReadOnly="false" Width="" BackColor="Black" Height="27"></asp:TextBox>
                                        </div>
                                        <%--<cc1:ColorPickerExtender ID="ColorPickerExtender1" runat="server"
                                            TargetControlID="txtForeColor" OnClientColorSelectionChanged="colorChanged" />--%>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-detail">
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button CssClass="form-btn" ID="btnBarCodePrint" runat="server" Text="In ra máy in BarCode(b)" Width=""></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLog" runat="server" Height="0" Width="0" Visible="False">
            <asp:ListItem Value="PrintBarCode">In mã vạch cho tài liệu</asp:ListItem>
            <asp:ListItem Value="ErrorMsg">Chi tiết lỗi </asp:ListItem>
            <asp:ListItem Value="ErrorCode">Mã lỗi </asp:ListItem>
            <asp:ListItem Value="3">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
            <asp:ListItem Value="4">Không tìm thấy dữ liệu!</asp:ListItem>
            <asp:ListItem Value="5">------ Chọn ------</asp:ListItem>
            <asp:ListItem Value="6">Chưa chọn mẫu mã vạch</asp:ListItem>
            <asp:ListItem Value="7">Ngày tháng không hợp lệ !</asp:ListItem>
            <asp:ListItem Value="8">Dữ liệu phải là kiểu số.</asp:ListItem>
        </asp:DropDownList><input id="hdChoice" type="hidden" value="1" name="hdChoice" runat="server">
    </form>
    <script language="javascript">
        document.forms[0].txtFromCodeItem.focus();
    </script>
</body>
</html>
