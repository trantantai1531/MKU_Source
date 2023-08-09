<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WOverdueTemplateWindow" CodeFile="WOverdueTemplate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WOverdueTemplateWindow</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
    <script type="text/javascript" src="../../js/jquery-1.10.2.js"></script>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head" id="tabMuonVe">
                    <li class="TabbedPanelsTab activetab" tabindex="0">
                        <asp:Label ID="lblOverdueTemplate" runat="server" CssClass="lbGroupTitleSmall">Mẫu quá hạn</asp:Label></li>
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkOverdueList" runat="server" NavigateUrl="WOverduelist.aspx">Quá hạn</asp:HyperLink></li>
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkOverduePrintLetter" runat="server" NavigateUrl="WOverduePrintLetter.aspx">In quá hạn</asp:HyperLink></li>
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkOverdueSendEmail" runat="server" NavigateUrl="WOrverdueSendMail.aspx">Gửi Email</asp:HyperLink>
                    </li>
                </ul>
            </div>
            <div class="main-form" style="margin: 0px;">
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <asp:label CssClass="lbLabel"  id="lblPickForm" Runat="server" >Chọn mẫu thư quá hạn: </asp:label>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:dropdownlist id="ddlTemplate" tabIndex="1" Runat="server"></asp:dropdownlist><input id="txtTemplate" type="hidden" value="0" name="txtTemplate" runat="server">
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                           <asp:label CssClass="lbLabel"  id="Label1" Runat="server" >Tiêu đề</asp:label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="area-input" id="txtHeader" Rows="3" Runat="server" Width="100%" TextMode="MultiLine" Wrap="true"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="two-column-form">
                        <div class="row-detail">
                            <asp:label CssClass="lbLabel"  id="lblCaption" Runat="server" >Tên mẫu:</asp:label>&nbsp;<asp:label CssClass="lbLabel"  id="lblMan" Runat="server" ToolTip="Trường bắt buộc phải nhập dữ liệu" Font-Bold="True"
							ForeColor="RED">(*)</asp:label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input" id="txtCaption" onchange="CheckExitName(this.value)" Runat="server" Width=""></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <asp:label CssClass="lbLabel"  id="lblHeaderPickInformation" Runat="server" >Thông tin bạn đọc:</asp:label>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:dropdownlist id="ddlHeaderPickInformation" Runat="server"></asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <h2 class="main-head-form">Những thông tin có trong đơn và định dạng của đơn</h2>
            <div class="main-form">
                <div class="two-column ClearFix">


                    <div class="two-column-form ClearFix">
                        <asp:listbox id="lsbTemp" Runat="server" Width="0" Height="0"></asp:listbox>
                        <div class="span45">
                            <div class="row-detail">
                                <asp:label CssClass="lbLabel"  id="lblAllCollums" Runat="server" Width="100%">Các cột không hiển thị</asp:label>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:listbox id="lsbAllCollums" CssClass="area-input" tabIndex="4" Runat="server" Width="100%" Height="" SelectionMode="Multiple"></asp:listbox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="span1">
                            <div class="input-control button-list">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:button id="btnAdd" CssClass="btn-icon btn-next"  tabIndex="5" Runat="server" Width="97%" Text=">>"></asp:button>
                                        <div class="icon-btn"><span class="icon-arrow-right"></span></div>
                                    </div>
                                </div>
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:button id="btnRemove" CssClass="btn-icon btn-prev"  tabIndex="7" Runat="server" Width="97%" Text="<<"></asp:button>
                                        <div class="icon-btn"><span class="icon-arrow-left"></span></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="span45">
                            <div class="row-detail">
                                <asp:label CssClass="lbLabel"  id="lblCollum" Runat="server" Width="100%">Các cột hiển thị</asp:label>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:listbox id="lsbCollum" CssClass="area-input" tabIndex="6" Runat="server" Width="100%" Height="" SelectionMode="Multiple"></asp:listbox>
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
                                        <asp:textbox CssClass="area-input" id="txtCollumCaption" tabIndex="8" Runat="server" Width="100%" TextMode="MultiLine"
										Wrap="False" Columns="12" Rows="7"></asp:textbox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="unit-4">
                            <div class="row-detail">
                                <p>Độ rộng :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="area-input" id="txtCollumWidth" tabIndex="9" Runat="server" Width="100%" TextMode="MultiLine"
										Wrap="False" Columns="12" Rows="7"></asp:textbox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="unit-4">
                            <div class="row-detail">
                                <p>Căn lề :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="area-input" id="txtAlign" tabIndex="10" Runat="server" Width="100%" TextMode="MultiLine" Wrap="False"
										Columns="12" Rows="7"></asp:textbox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="unit-4">
                            <div class="row-detail">
                                <p>Định dạng :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="area-input" id="txtWord" Runat="server" Width="100%" TextMode="MultiLine" Wrap="False" Columns="12"
										Rows="7"></asp:textbox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                           <asp:label CssClass="lbLabel"  id="lblFooter" Runat="server" Width="100%" >Cuối đơn</asp:label>
                            <div class="input-control">
                                <div class="input-form ">
                                   <asp:textbox id="txtFooter" CssClass="area-input" Rows="3" Runat="server" Width="100%" TextMode="MultiLine" Wrap="true"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">
                        <div class="row-detail">
                            <asp:label CssClass="lbLabel"  id="lblFooterInformation" Runat="server" >Thông tin bạn đọc:</asp:label>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:dropdownlist id="ddlFooterInformation" Runat="server"></asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control" style="text-align: center;">
                        <div class="button-form">
                            <asp:button id="btnUpdate" tabIndex="11" Runat="server" Text="Cập nhật(c)" Width=""></asp:button>
                        </div>
                        <div class="button-form">
                            <asp:button id="btnPreview" tabIndex="12" Runat="server" Text="Xem trước(e)" Width=""></asp:button>
                        </div>
                        <div class="button-form">
                            <asp:button id="btnDelete" tabIndex="13" Runat="server" Text="Xoá(x)" Width=""></asp:button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <br>
        <input id="txtCollum" type="hidden" name="txtCollum" runat="server">
        <input id="lblSequency" type="hidden" value="Số thứ tự" runat="server">
        <input id="lblItemCode" type="hidden" value="Mã tài liệu" runat="server">
        <input id="lblCopyNumber" type="hidden" value="Mã xếp giá" runat="server">
        <input id="lblItemTitle" type="hidden" value="Nhan đề" runat="server">
        <input id="lblCheckOutDate" type="hidden" value="Ngày mượn" runat="server">
        <input id="lblCheckInDate" type="hidden" value="Ngày trả" runat="server">
        <input id="lblOverdueDate" type="hidden" value="Số ngày quá hạn" runat="server">
        <input id="lblPenati" type="hidden" value="Tiền phạt" runat="server">
        <input id="lblLibrary" type="hidden" value="Thư viện" runat="server" name="lblLibrary">
        <input id="lblStore" type="hidden" value="Kho" runat="server" name="lblStore">
        <input id="lblNote" type="hidden" value="Ghi chú" runat="server" name="lblNote">
        <asp:HiddenField runat="server" ID="lblLoanCount" Value="Số lượng" />
    
        <asp:Label ID="lblPatronInformationValue" runat="server" Visible="False">---Chọn thông tin---,<$CARDNUMBER$>,<$NAME$>,<$DOB$>,<$OCUPATION$>,<$WORKPLACE$>,<$WORKADDRESS$>,<$HOMEADDRESS$>,<$PHONE$>,<$GRADE$>,<$FACULITY$>,<$CARDVALIDDATE$>,<$CARDEXPRIEDDATE$>,<$EMAIL$>,<$LOANCOUNT$></asp:Label>
        <asp:Label ID="lblPatronInformationText" runat="server" Visible="False">---Chọn thông tin---,Số thẻ, Họ Tên,Ngày sinh,Nghề nghiệp,Nơi làm việc,Địa chỉ làm việc,Địa chỉ nơi ở,Số điện thoại,Bậc học,Khoa,Ngày cấp thẻ,Ngày hết hạn thẻ,Địa chỉ Email,Số lượng</asp:Label>
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Tạo mẫu đơn quá hạn</asp:ListItem>
            <asp:ListItem Value="3">Sửa mẫu đơn quá hạn</asp:ListItem>
            <asp:ListItem Value="4">Xoá mẫu đơn quá hạn</asp:ListItem>
            <asp:ListItem Value="5">---------- Thêm mới ----------</asp:ListItem>
            <asp:ListItem Value="6">Cập nhật mẫu đơn thành công</asp:ListItem>
            <asp:ListItem Value="7">Bạn chắc chắn muốn xoá mẫu này?</asp:ListItem>
            <asp:ListItem Value="8">Bạn chưa nhập tên mẫu!</asp:ListItem>
            <asp:ListItem Value="9">Bạn chưa chọn mẫu cần làm việc!</asp:ListItem>
            <asp:ListItem Value="10">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtCaption.focus();
        // ham set text chung
        function setValueText(idSelect, idTextArea) {
            idSelect.on('change', function () {
                var cursorPos = idTextArea.prop('selectionStart');
                var v = idTextArea.val();
                var textBefore = v.substring(0, cursorPos);
                var textAfter = v.substring(cursorPos, v.length);
                idTextArea.val(textBefore + $(this).val() + textAfter);
            });
        }

        setValueText($('#ddlHeaderPickInformation'), $('#txtHeader')); // cho o tren
        setValueText($('#ddlFooterInformation'), $('#txtFooter')); // cho o duoi

        //$('#ddlHeaderPickInformation').on('change', function () {
        //    var cursorPos = $('#txtHeader').prop('selectionStart');
        //    var v = $('#txtHeader').val();
        //    var textBefore = v.substring(0, cursorPos);
        //    var textAfter = v.substring(cursorPos, v.length);
        //    $('#txtHeader').val(textBefore + $(this).val() + textAfter);
        //});
    </script>
</body>
</html>
