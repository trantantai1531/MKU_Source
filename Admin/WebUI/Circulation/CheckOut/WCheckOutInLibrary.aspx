<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCheckOutInLibrary" CodeFile="WCheckOutInLibrary.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCheckOutInLibrary</title>
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
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.js" type="text/javascript"></script>
    <style type="text/css">
       
        .tab-head .TabbedPanelsTab {
            padding: 8px 10px;
        }
    </style>
</head>
<body onkeypress="return microsoftKeyPress(event);" leftmargin="0" topmargin="0" onload="document.forms[0].txtPatronCode.focus();" >
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head" id="tabMuonVe">
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkCheckOut" runat="server" NavigateUrl="WCheckOut.aspx" ForeColor="#FFFFFF">Mượn về</asp:HyperLink></li>
                    <li class="TabbedPanelsTab activetab" tabindex="0">
                        <asp:Label ID="lblCheckOutInLibrary" runat="server" ForeColor="#FFFFFF">Mượn đọc tại chỗ</asp:Label></li>
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkMuonDK" runat="server" NavigateUrl="WCheckOutCopyNumber.aspx" ForeColor="#FFFFFF">Bạn đọc vào thư viện</asp:HyperLink></li>
                </ul>
            </div>
            <div class="main-form">
                <div class="row-detail">
                    <p>Ngày mượn :</p>
                    <div class="inline-box">
                        <div class="input-control" style="width:49%; display:inline-block">
                            <div class="input-form">
                                <asp:textbox CssClass="text-input"  id="txtCreatedDate" Runat="server" Width=""></asp:textbox>
                            </div>
                        </div>
                        <div class="input-control" style="width:49%; display:inline-block">
                            <div class="input-form">
                                <asp:textbox CssClass="text-input"  id="txtCreatedTime" Runat="server" Width=""></asp:textbox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Hạn trả :</p>
                    <div class="inline-box">
                        <div class="input-control" style="width:49%; display:inline-block">
                            <div class="input-form">
                                <asp:textbox CssClass="text-input"  id="txtDueDate" Runat="server" Width=""></asp:textbox>
                            </div>
                        </div>
                        <div class="input-control" style="width:49%; display:inline-block">
                            <div class="input-form">
                                <asp:textbox CssClass="text-input"  id="txtDueTime" Runat="server" Width=""></asp:textbox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail inline-box">
                    <p>Số thẻ : <asp:hyperlink id="lnkSearchPatron" Runat="server" cssClass="lbLinkFunctionSmall">Tìm </asp:hyperlink><span></span>
                     <asp:hyperlink id="lnkAddPatron" Runat="server" cssClass="lbLinkFunctionSmall">Thêm</asp:hyperlink> <span>
                     </span> <asp:hyperlink Visible="False" id="lnkCheckPatronCode" Runat="server" cssClass="lbLinkFunctionSmall">Kiểm tra</asp:hyperlink></p>
                    <div class="input-control" style="display:inline-block">
                        <div class="input-form ">
                            <asp:textbox CssClass="text-input"  id="txtPatronCode" Runat="server" Width=""></asp:textbox>
                        </div>
                    </div>
                </div>
                <div class="row-detail inline-box">
                    <p>ĐKCB : <asp:hyperlink id="lnkSearchCopyNumber" Runat="server" cssClass="lbLinkFunctionSmall">Tìm </asp:hyperlink><span> |</span><asp:hyperlink id="lnkAddCopyNumber" Runat="server" cssClass="lbLinkFunctionSmall">Thêm</asp:hyperlink></p>
                    <div class="input-control" style="display:inline-block">
                        <div class="input-form ">
                            <asp:textbox CssClass="text-input"  id="txtCopyNumber" Runat="server" Width="89px"></asp:textbox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control" style="text-align: center">
                        <div class="button-form">
                            <asp:button id="btnCheckOut" Runat="server" Width="" Text="Ghi mượn(c)"></asp:button>
                        </div>
                        <div class="button-form" style="display:none;">
                            <asp:button id="btnEnd" Runat="server" Width="" Text="Kết thúc(e)"></asp:button>
                        </div>
                        <div class="button-form" style="display:none;">
                            <asp:button id="btnPrint" Runat="server" Width="" Text="Phiếu(p)"></asp:button>
                        </div>
                      
                    </div>
                </div>
                <div>
                    <asp:hyperlink id="lnkReservation" Runat="server" CssClass="lbLinkFunctionSmall" > Yêu cầu</asp:hyperlink>
                    <asp:hyperlink id="lnkPatronInLib" Runat="server" CssClass="lbLinkFunctionSmall">&nbsp;&nbsp;Bạn đọc trong thư viện</asp:hyperlink>
                </div>
            </div>
        </div>
        <input id="hidLoanMode" type="hidden" value="2" runat="server"/>
        <input type="hidden" id="hidContinue" runat="server" value="1"/>
        <input type="hidden" id="hidError" runat="server" value="0"/>
        <input id="hidOpen" type="hidden" runat="server" value="0"/>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
            <asp:ListItem Value="1">Giờ không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="3">Số thẻ không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="4">ĐKCB không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="5">Bạn đọc đã hết hạn ngạch. Bấm OK để đồng ý cho mượn. Bấm Cancel để từ chối.</asp:ListItem>
            <asp:ListItem Value="6">Ngày mượn phải nhỏ hơn ngày trả!</asp:ListItem>
            <asp:ListItem Value="7">Thẻ bạn đọc đã hết hạn!</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script type="text/javascript">
        $("input[name='txtCopyNumber']").on("change keyup paste mouseup", function () {
            var lenInput = $("input[name='txtCopyNumber']").val().length;
            if ($("input[name='txtCopyNumber']").val() != null) {
                if (lenInput == 10) {
                    $("input[name='btnCheckOut']").click();
                }
            }
        });
    </script>
</body>
</html>
