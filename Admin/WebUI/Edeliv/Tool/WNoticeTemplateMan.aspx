<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WNoticeTemplateMan"
    EnableViewState="False" EnableViewStateMac="False" CodeFile="WNoticeTemplateMan.aspx.vb"
    CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WNoticeTemplateMan</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <h1 class="main-head-form">
            <asp:Label ID="lblMainTitle" CssClass="lbPagetitle" runat="server" Width="100%">
							Soạn mẫu hoá đơn thanh toán
            </asp:Label></h1>
        <div class="two-column ClearFix">
            <div class="two-column-form">
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lbFormat" runat="server"><U>K</U>huôn dạng: </asp:Label></p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlFormatName" runat="server" Width="300px">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lbNFormat" runat="server"><U>T</U>ên khuôn dạng:</asp:Label>
                        <asp:Label ID="lblMan" runat="server" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc">(*)</asp:Label></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="text-input" Width="500"></asp:TextBox>&nbsp;
                        </div>
                    </div>
                </div>
            </div>
            <div class="two-column-form">
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblOption" runat="server">Chọn thông tin:</asp:Label></p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlHeadRequestInfo1" runat="server" Width="150px">
                                <asp:ListItem Value="" Selected="True">--- Chọn thông tin ---</asp:ListItem>
                                <asp:ListItem Value=" &lt;$NAME$&gt;">Người đặt</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVNAME$&gt;">Đơn vị</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVXADDR$&gt;">Địa chỉ (1)</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVSTREET$&gt;">Địa chỉ (2)</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVBOX$&gt;">Hộp thư</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVCITY$&gt;">Thành phố</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVREGION$&gt;">Khu vực</asp:ListItem>
                                <asp:ListItem Value="&lt;$DELIVCOUNTRY$&gt;">Quốc gia</asp:ListItem>
                                <asp:ListItem Value="&lt;$DEBT$&gt;">Số tiền còn nợ</asp:ListItem>
                                <asp:ListItem Value="&lt;$CREATEDDATE$&gt;">Ngày đặt mua</asp:ListItem>
                                <asp:ListItem Value="&lt;$EXPIREDDATE$&gt;">Ngày hết hạn đặt</asp:ListItem>
                                <asp:ListItem Value="&lt;$DD$&gt;">Ngày</asp:ListItem>
                                <asp:ListItem Value="&lt;$MM$&gt;">Tháng</asp:ListItem>
                                <asp:ListItem Value="&lt;$YYYY$&gt;">Năm</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        Nội dung :</p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtHeader" CssClass="text-input" TabIndex="3" runat="server" Width="100%" Wrap="true"
                                TextMode="MultiLine" Columns="100" Height="60px"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <h1 class="main-group-form">
            Những thông tin có khuôn và định dạng của khuôn</h1>
        <div class="two-column ClearFix">
            <div class="two-column-form ClearFix">
                <div class="span45">
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblAllCollums" runat="server">Cột <U> k</U>hông hiển thị</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:ListBox ID="lsbAllCollums" runat="server" CssClass="area-input" SelectionMode="Multiple"
                                    Rows="6"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="span1">
                    <div class="input-control button-list">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn-icon" Text=">>"></asp:Button>
                                <div class="icon-btn"><span class="icon-arrow-right"></span></div>
                            </div>
                        </div>
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnRemove" runat="server" CssClass="btn-icon" Text="<<"></asp:Button>
                                <div class="icon-btn"><span class="icon-arrow-left"></span></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="span45">
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblCollum" runat="server" Width="100%">Cột <u> h</u>iển thị</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:ListBox ID="lsbCollum" runat="server" CssClass="area-input" SelectionMode="Multiple"
                                    Rows="6"></asp:ListBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="two-column-form ClearFix">
                <div class="unit-4">
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblCollumCaption" runat="server"><u> T</u>iêu đề cột</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txtCollumCaption" TabIndex="8" runat="server" CssClass="area-input"
                                    Wrap="False" TextMode="MultiLine" Columns="20" Rows="5"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="unit-4">
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblCollumWidth" runat="server">Độ <u> r</u>ộng</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txtCollumWidth" runat="server" CssClass="area-input" Wrap="False"
                                    TextMode="MultiLine" Columns="10" Rows="5"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="unit-4">
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblAlign" runat="server">Căn <u>l</u>ề</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txtAlign" runat="server" CssClass="area-input" Wrap="False" TextMode="MultiLine"
                                    Columns="10" Rows="5"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="unit-4">
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblFormat" runat="server">Định dạng</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txtFormat" runat="server" CssClass="area-input" Wrap="False" TextMode="MultiLine"
                                    Columns="10" Rows="5"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row-detail">
            <p>
                <asp:Label ID="lblOption2" runat="server">Chọn thông tin:</asp:Label></p>
            <div class="input-control">
                <asp:DropDownList ID="ddlFootRequestInfo" runat="server">
                    <asp:ListItem Value="" Selected="True">--- Chọn thông tin ---</asp:ListItem>
                    <asp:ListItem Value=" &lt;$NAME$&gt;">Người đặt</asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVNAME$&gt;">Đơn vị</asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVXADDR$&gt;">Địa chỉ (1)</asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVSTREET$&gt;">Địa chỉ (2)</asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVBOX$&gt;">Hộp thư</asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVCITY$&gt;">Thành phố</asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVREGION$&gt;">Khu vực</asp:ListItem>
                    <asp:ListItem Value="&lt;$DELIVCOUNTRY$&gt;">Quốc gia</asp:ListItem>
                    <asp:ListItem Value="&lt;$DEBT$&gt;">Số tiền còn nợ</asp:ListItem>
                    <asp:ListItem Value="&lt;$CREATEDDATE$&gt;">Mô tả tài liệu đặt mua</asp:ListItem>
                    <asp:ListItem Value="&lt;$EXPIREDDATE$&gt;">Ngày đặt</asp:ListItem>
                    <asp:ListItem Value="&lt;$DD$&gt;">Ngày</asp:ListItem>
                    <asp:ListItem Value="&lt;$MM$&gt;">Tháng</asp:ListItem>
                    <asp:ListItem Value="&lt;$YYYY$&gt;">Năm</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row-detail">
            <p>
                Cuối đơn :</p>
            <div class="input-control">
                <div class="input-form ">
                    <asp:TextBox ID="txtFooter" TabIndex="10" CssClass="text-input" runat="server" Width="100%" Wrap="true"
                        TextMode="MultiLine" Columns="100" Height="60px"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row-detail">
            <div class="button-control" style="text-align: center;">
                <div class="button-form">
                    <asp:Button ID="btnUpdate" CssClass="form-btn" runat="server" Width="98px" Text="Cập nhật(u)"></asp:Button>
                </div>
                <div class="button-form">
                    <asp:Button ID="btnPreview" CssClass="form-btn" runat="server" Width="100px" Text="Xem trước(p)"></asp:Button>
                </div>
                <div class="button-form">
                    <asp:Button ID="btnDelete" CssClass="form-btn" runat="server" Width="68px" Text="Xóa(d)"></asp:Button>
                </div>
            </div>
        </div>
    </div>
    <table cellspacing="0" cellpadding="1" width="100%" border="0">
        <tr class="lbGroupTitle">
            <td valign="top" width="20%" colspan="2">
                <asp:Label ID="lblLabel1" runat="server" Width="100%" CssClass="lbGroupTitle">P<u>h</u>ần đầu thư:</asp:Label>
            </td>
        </tr>
        <tr class="lbGroupTitle">
            <td colspan="2">
                <asp:Label ID="lblIncudeCollums" runat="server" Width="100%" CssClass="lbGroupTitle">Phần giữa thư gồm các cột:</asp:Label>
            </td>
        </tr>
        <tr class="lbGroupTitle">
            <td colspan="2">
                <asp:Label ID="lblFooter" runat="server" Width="100%" CssClass="lbGroupTitle">Phần cuối thư:</asp:Label>
            </td>
        </tr>
    </table>
    <asp:Label ID="lblEmtyCaption" runat="server" Visible="False">Tên mẫu là bắt buộc</asp:Label><asp:Label
        ID="lblAddNewSuccessful" runat="server" Visible="False">Thêm mới thành công</asp:Label><asp:Label
            ID="lblUpdateSuccessful" runat="server" Visible="False">Cập nhật thành công</asp:Label><asp:Label
                ID="lblConfirmDelete" runat="server" Visible="False">Nhấn OK để khẳng định việc xoá mẫu này!!!</asp:Label><asp:ListBox
                    ID="lsbTemp" Width="0px" runat="server" Height="0px" Enabled="False">
    </asp:ListBox>
    <input id="txtTemplate" type="hidden" value="0" name="txtTemplate" runat="server">
    <input id="txtCollum" type="hidden" name="txtCollum" runat="server">
    <asp:Label ID="lblAddNewFormat" runat="server" Visible="False">---------- Khuôn dạng mới ---------- </asp:Label><asp:Label
        ID="lblInformationText" runat="server" Visible="False">Chọn thông tin,Người đặt, Đơn vị, Địa chỉ (1), Địa chỉ (2), Hộp thư, Thành phố, Khu vực, Quốc gia, Số tiền còn nợ, Mô tả tài liệu đặt mua, Ngày đặt, Ngày, Tháng, Năm</asp:Label><asp:Label
            ID="lblInformationValue" runat="server" Visible="False">, &lt;$NAME$&gt;,&nbsp; &lt;$DELIVNAME$&gt;, &lt;$DELIVXADDR$&gt;, &lt;$DELIVSTREET$&gt;, &lt;$DELIVBOX$&gt;, &lt;$DELIVCITY$&gt;, &lt;$DELIVREGION$&gt;, &lt;$DELIVCOUNTRY$&gt;, &lt;$DEBT$&gt;, &lt;$CREATEDDATE$&gt;,&lt;$EXPIREDDATE$&gt;, &lt;$DD$&gt;, &lt;$MM$&gt;,&lt;$YYYY$&gt;</asp:Label><asp:Label
                ID="lblCollumText" runat="server" Visible="False">STT, Mô tả tài liệu, Kích cỡ, Giá, Đơn vị tiền tệ</asp:Label><asp:Label
                    ID="lblCollumValue" runat="server" Visible="False">&lt;$NO$&gt;, &lt;$NOTE$&gt;,&lt;$FILESIZE$&gt;, &lt;$PRICE$&gt;, &lt;$CURRENCY$&gt;</asp:Label><input
                        id="Hidden1" type="hidden" value="0" name="txtTemplate" runat="server">
    <input id="Hidden2" type="hidden" name="txtCollum" runat="server">
    <input id="hdCollumCaptionText" type="hidden" name="hdCollumCaptionText" runat="server">
    <input id="hdMax" type="hidden" name="hdMax" runat="server">
    <asp:Label runat="server" ID="lblLabel4" Visible="False">Bạn không được cấp quyền khai thác tính năng này</asp:Label>
    <asp:Label runat="server" ID="lblLabel2" Visible="False">Mã lỗi</asp:Label>
    <asp:Label runat="server" ID="lblLabel3" Visible="False">Chi tiết lỗi</asp:Label>
    </form>
    <script language="javascript">
        document.forms[0].txtTitle.focus();
    </script>
</body>
</html>
