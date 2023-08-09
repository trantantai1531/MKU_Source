<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WPOTemplate" CodeFile="WPOTemplate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WPOTemplate</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <script language="JavaScript" src="../Js/ACQ/picker.js"></script>
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/media.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-page ClearFix">
                <asp:Label ID="lblMainTitle" runat="server" CssClass="lbPageTitle main-head-form">Soạn thảo mẫu đơn đặt</asp:Label>
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Chọn mẫu :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlID" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tiêu đề trang :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtPageHeader"  Width="100%" runat="server" CssClass="text-input"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>
                                Tên đơn đặt :
                                <span id="lblMan" title="Trường bắt buộc phải nhập dữ liệu" class="lbLabel" style="color: Red; margin-bottom: 0; font-weight: bold;">(*)</span>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtCaption" Width="96%" runat="server" CssClass="text-input"></asp:TextBox>

                                    <input id="txtCollum" type="hidden" name="txtCollum" runat="server"/>
                                </div>
                            </div>
                        </div>

                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblHeaderVendor" runat="server" CssClass="lbSubTitleSmall" Visible="False">Thông t<u>i</u>n về NCC:</asp:Label></td>
                                <td>
                                    <asp:Label ID="lblHeaderInfPostForm" runat="server" CssClass="lbSubTitleSmall" Visible="False">Thôn<u>g</u> tin về đơn:</asp:Label></td>
                            </tr>
                            <tr>
                                <td class="input-control" style="width: 57%;">
                                    <div class="dropdown-form" style="border: none; padding: 0">
                                        <asp:DropDownList ID="ddlHeaderVendor" CssClass="ddlSelectChoice " runat="server" Visible="False"></asp:DropDownList>
                                    </div>
                                </td>
                                <td class="input-control" style="width: 43%;">
                                    <div class="dropdown-form" style="border: none; padding: 0">
                                        <asp:DropDownList ID="ddlHeaderInfPostForm" CssClass="ddlSelectChoice " runat="server" Visible="False"></asp:DropDownList>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <div style="padding: 0px 10px;">
                            <div class="input-control">
                                 <p>
                                   Đầu trang
                                </p>
                                <div class="input-form ">
                                    <asp:TextBox ID="txtHeader" Width="100%" runat="server" CssClass="lbtextarea area-input" Wrap="true" TextMode="MultiLine"
                                        Height="60px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="two-column ClearFix">
                    <div class="two-column-form ClearFix">
                        <div class="span44">
                            <div class="row-detail">
                                <p>Không hiển thị :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:ListBox ID="lsbTemp" Width="0" runat="server" Height="0" ></asp:ListBox>
                                        <asp:ListBox ID="lsbAllCollums" CssClass="area-input" Width="100%" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="span1">
                            <div class="input-control button-list">
                                <div class="button-control" style="position: relative;">
                                    <div class="button-form">
                                        <input id="btnAdd" runat="server" type="button" class="btn-icon"/>
                                        <div class="icon-btn"><span class="icon-arrow-right"></span></div>
                                    </div>
                                </div>
                                <div class="button-control" style="position: relative;">
                                    <div class="button-form">
                                        <input id="btnRemove" type="button" class="btn-icon" runat="server"/>
                                        <div class="icon-btn"><span class="icon-arrow-left"></span></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="span44">
                            <div class="row-detail">
                                <p>Cột hiển thị :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:ListBox ID="lsbCollum" CssClass="area-input" Width="100%" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form ClearFix">
                        <div class="unit-4">
                            <div class="row-detail">
                                <p>Tên hiển thị :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtCollumCaption" runat="server" CssClass="area-input" Wrap="False"
                                            TextMode="MultiLine" Height="140px" Rows="6" Columns="6"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="unit-4">
                            <div class="row-detail">
                                <p>Độ rộng :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtCollumWidth" runat="server" CssClass="area-input" Wrap="False"
                                            TextMode="MultiLine" Height="140px" Rows="6" Columns="6"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="unit-4">
                            <div class="row-detail">
                                <p>Căn lề :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtAlign" Width="100%" runat="server" CssClass="area-input" Wrap="False" TextMode="MultiLine"
                                            Height="140"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="unit-4">
                            <div class="row-detail">
                                <p>Định dạng :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtFormat" Width="100%" runat="server" CssClass="area-input" Wrap="False" TextMode="MultiLine"
                                            Height="140" Rows="6" Columns="6"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>
                                    Màu bảng :
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="javascript:TCP.popup(document.forms[0].elements['txtTableColor'], 1)">Chọn</asp:HyperLink>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtTableColor" Width="60" runat="server" CssClass="text-input" MaxLength="7"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>
                                    Màu hàng lẻ :
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="javascript:TCP.popup(document.forms[0].elements['txtOddColor'], 1)">Chọn</asp:HyperLink>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtOddColor" Width="60" runat="server" CssClass="text-input" MaxLength="7"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>
                                    Màu hàng chẳn :
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="javascript:TCP.popup(document.forms[0].elements['txtEventColor'], 1)">Chọn</asp:HyperLink>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtEventColor" Width="60" runat="server" CssClass="text-input" MaxLength="7"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Cuối trang :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtPageFooter" Width="100%" runat="server" CssClass="text-input"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFooterVendor" runat="server" CssClass="lbSubTitleSmall" Visible="False">Thông tin <u>v</u>ề NCC: </asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblFooterInfPostForm" runat="server" CssClass="lbSubTitleSmall" Visible="False">Thông tin về đơ<u>n</u> đặt: </asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="input-control" style="width: 57%;">
                                        <div class="dropdown-form" style="border: none; padding: 0">
                                            <asp:DropDownList ID="ddlFooterVendor" CssClass="ddlSelectChoice" runat="server" Visible="False"></asp:DropDownList>
                                        </div>
                                    </td>
                                    <td class="input-control" style="width: 43%;">
                                        <div class="dropdown-form" style="border: none; padding: 0">
                                            <asp:DropDownList ID="ddlFooterInfPostForm" CssClass="ddlSelectChoice" TabIndex="13" runat="server" Visible="False"></asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <div style="padding: 0px 10px;">
                                <div class="input-control">
                                     <p>
                                   Cuối trang
                                </p>
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtFooter" TabIndex="10" Width="100%" runat="server" CssClass="area-input" Wrap="true"
                                            TextMode="MultiLine" Height="60px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                                                    <div class="row-detail">
                            <div class="button-control" style="text-align: center">
                                <div class="button-form">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="form-btn" Text="Cập nhật"></asp:Button>
                                </div>
                                <div class="button-form">
                                    <asp:Button ID="btnPreview" runat="server" CssClass="form-btn" Text="Xem trước"></asp:Button>
                                </div>
                                <div class="button-form">
                                    <asp:Button ID="btnDelete" runat="server" CssClass="form-btn" Text="Xoá đơn"></asp:Button>
                                </div>
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <input id="hdTemplateType" type="hidden" value="9" name="hdTemplateType" runat="server">
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">Mã lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền truy cập vào chức năng này</asp:ListItem>
            <asp:ListItem Value="3">---- Thêm mới ----</asp:ListItem>
            <asp:ListItem Value="4">Soạn thảo mẫu đơn yêu cầu ấn phẩm</asp:ListItem>
            <asp:ListItem Value="5">Soạn thảo mẫu đơn đặt ấn phẩm</asp:ListItem>
            <asp:ListItem Value="6">Soạn thảo mẫu đơn khiếu nại cho ấn phẩm</asp:ListItem>
            <asp:ListItem Value="7">Soạn thảo mẫu đơn phân kho</asp:ListItem>
            <asp:ListItem Value="8"><$SEQUENCY$>,<$SERIACODE$>,<$TITLE$>,<$AUTHOR$>,<$EDITION$>,<$PUBLISHER$>,<$YEAR$>,<$ISBN$>,<$LANGUAGE$>,<$COUNTRY$>,<$DOCUMENTTYPE$>,<$MEDIUM$>,<$ISSN$>,<$VALDSUBSCRIBEDDATE$>,<$FREQCODE$>,<$EXPIRESUBSCRIBEDDATE$>,<$ISSUES$>,<$ISSUEPRICE$>,<$UNITPRICE$>,<$CURRENCY$>,<$REQUESTEDCOPIES$>,<$ACCEPTEDCOPIES$>,<$MONEY$>,<$NOTE$>,<$REQUESTER$>,<$URGENCY$></asp:ListItem>
            <asp:ListItem Value="9">Số thứ tự,Mã báo, Nhan đề, Tác giả, Lần xuất bản, Nhà xuất bản,Năm xuất bản, ISBN, Ngôn ngữ, Nước xuất bản, Dạng tài liệu, Vật mang tin, ISSN, Ngày bắt đầu đặt, Cấp định kỳ, Ngày kết thúc đặt, Số kỳ, Giá lẻ, Đơn giá, Đơn vị tiền tệ, Số lượng đề nghị, Số lượng được duyệt, Thành tiền, Ghi chú, Người yêu cầu, Mức độ quan trọng</asp:ListItem>
            <asp:ListItem Value="10"><$TITLE$>,<$SERIACODE$>,<$AUTHOR$>,<$EDITION$>,<$PUBLISHER$>,<$YEAR$>,<$ISBN$>,<$LANGUAGE$>,<$COUNTRY$>,<$ISSN$>,<$VALDSUBSCRIBEDDATE$>,<$FREQCODE$>,<$EXPIRESUBSCRIBEDDATE$>,<$ISSUES$>,<$REQUESTEDCOPIES$></asp:ListItem>
            <asp:ListItem Value="11">Nhan đề,Mã báo,Tác giả,Lần xuất bản,Nhà xuất bản,Năm xuất bản,ISBN,Ngôn ngữ,Nước xuất bản,ISSN,Ngày bắt đầu đặt,Cấp định kỳ,Ngày kết thúc đặt,Số kỳ,Số lượng đặt</asp:ListItem>
            <asp:ListItem Value="12"><$TITLE$>,<$AUTHOR$>,<$EDITION$>,<$PUBLISHER$>,<$YEAR$>,<$ISBN$>,<$ISSN$>,<$REQUESTEDCOPIES$>,<$RETRIEVEDCOPIES$>,<$ERRONEUOS$></asp:ListItem>
            <asp:ListItem Value="13">Nhan đề,Tác giả,Lần xuất bản,Nhà xuất bản,Năm xuất bản,ISBN,ISSN,Số lượng yêu cầu,Số lượng nhận được,Số lượng sai lệch</asp:ListItem>
            <asp:ListItem Value="14"><$SEQUENCY$>,<$SERIACODE$>,<$TITLE$>,<$AUTHOR$>,<$EDITION$>,<$PUBLISHER$>,<$YEAR$>,<$ISBN$>,<$UNITPRICE$>,<$LANGUAGE$>,<$COUNTRY$>,<$DOCUMENTTYPE$>,<$MEDIUM$>,<$ISSN$>,<$VALDSUBSCRIBEDDATE$>,<$FREQCODE$>,<$EXPIRESUBSCRIBEDDATE$>,<$ISSUES$>,<$CURRENCY$>,<$REQUESTER$>,<$REQUESTEDCOPIES$>,<$URGENCY$>,<$NOTE$></asp:ListItem>
            <asp:ListItem Value="15">Số thứ tự,Mã báo,Nhan đề,Tác giả,Lần xuất bản,Nhà xuất bản,Năm xuất bản,ISBN,Đơn giá,Ngôn ngữ,Nước xuất bản,Dạng tài liệu,Vật mang tin,ISSN,Ngày bắt đầu đặt,Cấp định kỳ,Ngày kết thúc đặt,Số kỳ,Đơn vị tiền tệ,Người đề nghị,Số lượng đề nghị,Mức độ quan trọng,Ghi chú</asp:ListItem>
            <asp:ListItem Value="16">,<$NAME$>,<$ADDRESS$>,<$TEL$>,<$FAX$>,<$EMAIL$>,<$CONTACTPERSON$>,<$PROVINCE$>,<$COUNTRY$>,<$LIBAC$>,<$BANKINGINFO$>,<$X12EMAIL$>,<$X12ENABLE$>,<$SAN$>,<$LIBSAN$>,<$NOTE$></asp:ListItem>
            <asp:ListItem Value="17">Chọn thông tin,Tên nhà cung cấp,Địa chỉ,Số điện thoại,Số Fax,Địa chỉ Email,Người liên hệ,Tỉnh- thành phố,Nước,Số tài khoản NCC cấp cho thư viện,Tài khoản NCC,Email cho X12,Email khiếu nại,SAN,SAN của thư viện do NCC cấp,Ghi chú</asp:ListItem>
            <asp:ListItem Value="18">,<$CONTRACTCODE$>,<$CONTRACTNAME$>,<$CONTRACTVALIDDATE$>,<$CONTRACTEXPIREDDATE$>,<$SUM$>,<$CURRENCY$>,<$USERFULLNAME$></asp:ListItem>
            <asp:ListItem Value="19">Chọn thông tin,Mã số đơn đặt,Tên đơn đặt,Ngày bắt đầu đặt,Ngày kết thúc đặt,Tổng giá trị đơn đặt,Đơn vị tiền tệ,Người lập yêu cầu</asp:ListItem>
            <asp:ListItem Value="20">Cập nhật mẫu thành công!</asp:ListItem>
            <asp:ListItem Value="21">Cập nhật không thành công!</asp:ListItem>
            <asp:ListItem Value="22">Bạn chưa nhập tên mẫu đơn!</asp:ListItem>
            <asp:ListItem Value="23">Chọn OK nếu bạn thực sự muốn xoá mẫu này không?</asp:ListItem>
            <asp:ListItem Value="24">Tạo mới mẫu đơn yêu cầu ấn phẩm</asp:ListItem>
            <asp:ListItem Value="25">Cập nhật mẫu đơn yêu cầu ấn phẩm</asp:ListItem>
            <asp:ListItem Value="26">Xoá mẫu đơn yêu cầu ấn phẩm</asp:ListItem>
            <asp:ListItem Value="27">Tạo mới mẫu đơn đặt</asp:ListItem>
            <asp:ListItem Value="28">Cập nhật mẫu đơn đặt</asp:ListItem>
            <asp:ListItem Value="29">Xoá mẫu đơn đặt</asp:ListItem>
            <asp:ListItem Value="30">Tạo mới mẫu đơn khiếu nại</asp:ListItem>
            <asp:ListItem Value="31">Cập nhật mẫu đơn khiếu nại</asp:ListItem>
            <asp:ListItem Value="32">Xoá mẫu đơn khiếu nại</asp:ListItem>
            <asp:ListItem Value="33">Tạo mới mẫu đơn phân kho</asp:ListItem>
            <asp:ListItem Value="34">Cập nhật mẫu đơn phân kho</asp:ListItem>
            <asp:ListItem Value="35">Xoá mẫu đơn phân kho</asp:ListItem>
            <asp:ListItem Value="36">Bạn chưa chọn mẫu đơn cần làm việc!</asp:ListItem>
            <asp:ListItem Value="37">Tạo mới mẫu thành công!</asp:ListItem>
            <asp:ListItem Value="38">Tạo mới không thành công!</asp:ListItem>
            <asp:ListItem Value="39">Xóamẫu thành công!</asp:ListItem>
            <asp:ListItem Value="40">Xóa không thành công!</asp:ListItem>
        </asp:DropDownList>
    </form>

    <script language="javascript">
        document.forms[0].txtCaption.focus();
    </script>

</body>
</html>
