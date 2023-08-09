<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WScheduleView" CodeFile="WScheduleView.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WScheduleView</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
    
    <style>
        tr.lbCalendarDay .lbLabel {
                background: none;
                font-weight: bold;
                text-transform: uppercase;
            }
            .inline-box .input-control {
                display: inline-block !important;
                vertical-align: bottom;
            }
            html, body, p, h1, h2, h3, h4, h5, h6, ul, ol, header, footer {
                line-height: inherit !important;
                margin: 0;
                padding: 0;
            }

            body {
                font-family: WebFont;
  
                overflow-x: hidden;
                position: relative;
                background-color: white;
            }
            .row-detail .inline-box > div {
                display: inline-block;
                vertical-align: middle;
            }
            .input-control .dropdown-form {
                background: white none repeat scroll 0 0;
                border: 1px solid #999;
                height: 25px;
                padding: 2px 5px;
            }

            .input-control .dropdown-form > select {
                background: rgba(0, 0, 0, 0) none repeat scroll 0 0;
                border: medium none;
                cursor: pointer;
                font-size: 100%;
                height: 25px;
                width: 100% !important;
            }

            .row-detail.inline-box {
                margin-bottom: 17px;
                margin-top: 15px;
            }

            .form-btn, .lbButton {
                color: #fff;
                display: inline-block;
                margin-right: 2px;
                position: relative;
                vertical-align: top;
            }
            .button-form a.lbLinkFunction {
                color: #aacfea;
                text-decoration: none
            }
            .button-form a.lbLinkFunction:hover {
                color: #1D24FB;
                 text-decoration: none
            }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="1">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head" id="tabMuonVe">
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="Hyperlink1" runat="server" NavigateUrl="WWorkingUpdate.aspx">Thời gian làm việc</asp:HyperLink></li>
                    <li class="TabbedPanelsTab " tabindex="0">
                       <a href="WScheduleUpdate.aspx" class="lbLinkFunction" id="lnkWorkingSchedue">Lập lịch làm việc</a>
                       </li>
                    <li class="TabbedPanelsTab activetab" tabindex="0">
                        Xem lịch làm việc
                    </li>
                </ul>
            </div>

            <div class="main-form">
                <div class="row-detail inline-box">
                    <span>Năm :</span>
                    <div class="input-control button-control" style="width: auto;">
                        <div class="button-form">
                            <asp:LinkButton ID="lnkPrevious" runat="server" CssClass="form-btn btn-previous"> <<   </asp:LinkButton>
                        </div>
                    </div>
                    <div class="input-control inline-box" style="width: auto;">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="input-control button-control" style="width: auto;">
                        <div class="button-form">
                            <asp:LinkButton ID="lnkNext" runat="server" CssClass="form-btn btn-next"> >> </asp:LinkButton>
                        </div>
                    </div>
                    &nbsp;&nbsp;
                    <span>Kho :</span>
                    <div class="input-control" style="width: 200px;">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <table id="tblCalendar" cellspacing="0" cellpadding="0" width="100%" border="1">
                    <tr>
                        <td colspan="3"></td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tblMon1" class="lbCalendar" cellspacing="1" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td colspan="7" align="center" class="lbCalendarMon">
                                        <asp:Label ID="lblJan" runat="server">January</asp:Label>
                                    </td>
                                </tr>
                                <tr class="lbCalendarDay">
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJanSu" runat="server" ForeColor="red">Su</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJanMo" runat="server">Mo</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJanTu" runat="server">Tu</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJanWe" runat="server">We</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJanTh" runat="server">Th</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJanFr" runat="server">Fr</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJanSt" runat="server" ForeColor="Blue">St</asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label1" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label2" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label3" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label4" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label5" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label6" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label7" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label8" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label9" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label10" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label11" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label12" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label13" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label14" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label15" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label16" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label17" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label18" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label19" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label20" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label21" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label22" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label23" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label24" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label25" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label26" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label27" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label28" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label29" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label30" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label31" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label32" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label33" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label34" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label35" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label36" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label37" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label38" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label39" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label40" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label41" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label42" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table id="tblMon2" class="lbCalendar" cellspacing="1" cellpadding="0" width="100%" height="100%"
                                border="0">
                                <tr>
                                    <td colspan="7" align="center" class="lbCalendarMon">
                                        <asp:Label ID="lblFeb" runat="server">February</asp:Label></td>
                                </tr>
                                <tr class="lbCalendarDay">
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblFebSu" runat="server" ForeColor="red">Su</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblFebMo" runat="server">Mo</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblFebTu" runat="server">Tu</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblFebWe" runat="server">We</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblFebTh" runat="server">Th</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblFebFr" runat="server">Fr</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblFebSt" runat="server" ForeColor="Blue">St</asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label43" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label44" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label45" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label46" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label47" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label48" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label49" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label50" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label51" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label52" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label53" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label54" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label55" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label56" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label57" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label58" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label59" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label60" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label61" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label62" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label63" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label64" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label65" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label66" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label67" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label68" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label69" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label70" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label71" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label72" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label73" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label74" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label75" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label76" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label77" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label78" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label79" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label80" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label81" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label82" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label83" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label84" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table id="tblMon3" class="lbCalendar" cellspacing="1" cellpadding="0" width="100%" height="100%"
                                border="0">
                                <tr>
                                    <td colspan="7" align="center" class="lbCalendarMon">
                                        <asp:Label ID="lblMar" runat="server">March</asp:Label></td>
                                </tr>
                                <tr class="lbCalendarDay">
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMarSu" runat="server" ForeColor="red">Su</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMarMo" runat="server">Mo</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMarTu" runat="server">Tu</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMarWe" runat="server">We</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMarTh" runat="server">Th</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMarFr" runat="server">Fr</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMarSt" runat="server" ForeColor="Blue">St</asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label85" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label86" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label87" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label88" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label89" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label90" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label91" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label92" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label93" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label94" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label95" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label96" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label97" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label98" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label99" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label100" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label101" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label102" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label103" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label104" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label105" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label106" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label107" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label108" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label109" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label110" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label111" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label112" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label113" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label114" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label115" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label116" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label117" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label118" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label119" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label120" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label121" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label122" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label123" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label124" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label125" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label126" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tblMon4" class="lbCalendar" cellspacing="1" cellpadding="0" width="100%" height="100%"
                                border="0">
                                <tr>
                                    <td colspan="7" align="center" class="lbCalendarMon">
                                        <asp:Label ID="lblApr" runat="server">April</asp:Label></td>
                                </tr>
                                <tr class="lbCalendarDay">
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAprSu" runat="server" ForeColor="red">Su</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAprMo" runat="server">Mo</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAprTu" runat="server">Tu</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAprWe" runat="server">We</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAprTh" runat="server">Th</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAprFr" runat="server">Fr</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAprSt" runat="server" ForeColor="Blue">St</asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label127" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label128" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label129" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label130" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label131" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label132" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label133" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label134" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label135" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label136" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label137" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label138" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label139" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label140" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label141" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label142" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label143" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label144" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label145" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label146" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label147" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label148" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label149" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label150" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label151" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label152" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label153" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label154" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label155" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label156" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label157" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label158" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label159" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label160" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label161" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label162" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label163" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label164" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label165" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label166" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label167" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label168" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table id="tblMon5" class="lbCalendar" cellspacing="1" cellpadding="0" width="100%" height="100%"
                                border="0">
                                <tr>
                                    <td colspan="7" align="center" class="lbCalendarMon">
                                        <asp:Label ID="lblMay" runat="server">May</asp:Label></td>
                                </tr>
                                <tr class="lbCalendarDay">
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMaySu" runat="server" ForeColor="red">Su</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMayMo" runat="server">Mo</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMayTu" runat="server">Tu</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMayWe" runat="server">We</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMayTh" runat="server">Th</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMayFr" runat="server">Fr</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblMaySt" runat="server" ForeColor="Blue">St</asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label169" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label170" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label171" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label172" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label173" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label174" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label175" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label176" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label177" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label178" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label179" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label180" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label181" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label182" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label183" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label184" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label185" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label186" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label187" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label188" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label189" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label190" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label191" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label192" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label193" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label194" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label195" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label196" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label197" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label198" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label199" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label200" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label201" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label202" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label203" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label204" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label205" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label206" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label207" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label208" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label209" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label210" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table id="tblMon6" class="lbCalendar" cellspacing="1" cellpadding="0" width="100%" height="100%"
                                border="0">
                                <tr>
                                    <td colspan="7" align="center" class="lbCalendarMon">
                                        <asp:Label ID="lblJun" runat="server">June</asp:Label></td>
                                </tr>
                                <tr class="lbCalendarDay">
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJunSu" runat="server" ForeColor="red">Su</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJunMo" runat="server">Mo</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJunTu" runat="server">Tu</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJunWe" runat="server">We</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJunTh" runat="server">Th</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJunFr" runat="server">Fr</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJunSt" runat="server" ForeColor="Blue">St</asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label211" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label212" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label213" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label214" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label215" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label216" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label217" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label218" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label219" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label220" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label221" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label222" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label223" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label224" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label225" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label226" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label227" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label228" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label229" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label230" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label231" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label232" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label233" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label234" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label235" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label236" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label237" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label238" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label239" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label240" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label241" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label242" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label243" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label244" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label245" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label246" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label247" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label248" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label249" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label250" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label251" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label252" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tblMon7" class="lbCalendar" cellspacing="1" cellpadding="0" width="100%" height="100%"
                                border="0">
                                <tr>
                                    <td colspan="7" align="center" class="lbCalendarMon">
                                        <asp:Label ID="lblJul" runat="server">July</asp:Label></td>
                                </tr>
                                <tr class="lbCalendarDay">
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJulSu" runat="server" ForeColor="red">Su</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJulMo" runat="server">Mo</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJulTu" runat="server">Tu</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJulWe" runat="server">We</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJulTh" runat="server">Th</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJulFr" runat="server">Fr</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblJulSt" runat="server" ForeColor="Blue">St</asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label253" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label254" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label255" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label256" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label257" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label258" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label259" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label260" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label261" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label262" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label263" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label264" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label265" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label266" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label267" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label268" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label269" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label270" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label271" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label272" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label273" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label274" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label275" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label276" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label277" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label278" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label279" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label280" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label281" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label282" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label283" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label284" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label285" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label286" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label287" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label288" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label289" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label290" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label291" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label292" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label293" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label294" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table id="tblMon8" class="lbCalendar" cellspacing="1" cellpadding="0" width="100%" height="100%"
                                border="0">
                                <tr>
                                    <td colspan="7" align="center" class="lbCalendarMon">
                                        <asp:Label ID="lblAug" runat="server">August</asp:Label></td>
                                </tr>
                                <tr class="lbCalendarDay">
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAugSu" runat="server" ForeColor="red">Su</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAugMo" runat="server">Mo</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAugTu" runat="server">Tu</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAugWe" runat="server">We</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAugTh" runat="server">Th</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAugFr" runat="server">Fr</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblAugSt" runat="server" ForeColor="Blue">St</asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label295" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label296" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label297" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label298" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label299" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label300" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label301" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label302" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label303" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label304" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label305" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label306" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label307" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label308" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label309" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label310" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label311" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label312" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label313" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label314" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label315" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label316" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label317" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label318" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label319" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label320" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label321" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label322" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label323" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label324" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label325" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label326" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label327" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label328" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label329" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label330" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label331" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label332" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label333" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label334" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label335" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label336" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table id="tblMon9" class="lbCalendar" cellspacing="1" cellpadding="0" width="100%" height="100%"
                                border="0">
                                <tr>
                                    <td colspan="7" align="center" class="lbCalendarMon">
                                        <asp:Label ID="lblSep" runat="server">September</asp:Label></td>
                                </tr>
                                <tr class="lbCalendarDay">
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblSepSu" runat="server" ForeColor="red">Su</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblSepMo" runat="server">Mo</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblSepTu" runat="server">Tu</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblSepWe" runat="server">We</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblSepTh" runat="server">Th</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblSepFr" runat="server">Fr</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblSepSt" runat="server" ForeColor="Blue">St</asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label337" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label338" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label339" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label340" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label341" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label342" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label343" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label344" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label345" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label346" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label347" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label348" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label349" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label350" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label351" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label352" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label353" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label354" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label355" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label356" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label357" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label358" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label359" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label360" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label361" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label362" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label363" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label364" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label365" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label366" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label367" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label368" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label369" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label370" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label371" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label372" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label373" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label374" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label375" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label376" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label377" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label378" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tblMon10" class="lbCalendar" cellspacing="1" cellpadding="0" width="100%" height="100%"
                                border="0">
                                <tr>
                                    <td colspan="7" align="center" class="lbCalendarMon">
                                        <asp:Label ID="lblOct" runat="server">October</asp:Label></td>
                                </tr>
                                <tr class="lbCalendarDay">
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblOctSu" runat="server" ForeColor="red">Su</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblOctMo" runat="server">Mo</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblOctTu" runat="server">Tu</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblOctWe" runat="server">We</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblOctTh" runat="server">Th</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblOctFr" runat="server">Fr</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblOctSt" runat="server" ForeColor="Blue">St</asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label379" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label380" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label381" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label382" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label383" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label384" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label385" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label386" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label387" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label388" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label389" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label390" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label391" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label392" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label393" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label394" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label395" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label396" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label397" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label398" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label399" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label400" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label401" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label402" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label403" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label404" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label405" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label406" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label407" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label408" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label409" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label410" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label411" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label412" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label413" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label414" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label415" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label416" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label417" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label418" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label419" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label420" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table id="tblMon11" class="lbCalendar" cellspacing="1" cellpadding="0" width="100%" height="100%"
                                border="0">
                                <tr>
                                    <td colspan="7" align="center" class="lbCalendarMon">
                                        <asp:Label ID="lblNov" runat="server">November</asp:Label></td>
                                </tr>
                                <tr class="lbCalendarDay">
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblNovSu" runat="server" ForeColor="red">Su</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblNovMo" runat="server">Mo</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblNovTu" runat="server">Tu</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblNovWe" runat="server">We</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblNovTh" runat="server">Th</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblNovFr" runat="server">Fr</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblNovSt" runat="server" ForeColor="Blue">St</asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label421" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label422" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label423" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label424" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label425" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label426" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label427" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label428" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label429" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label430" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label431" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label432" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label433" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label434" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label435" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label436" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label437" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label438" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label439" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label440" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label441" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label442" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label443" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label444" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label445" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label446" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label447" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label448" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label449" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label450" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label451" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label452" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label453" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label454" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label455" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label456" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label457" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label458" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label459" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label460" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label461" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label462" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table id="tblMon12" class="lbCalendar" cellspacing="1" cellpadding="0" width="100%" height="100%"
                                border="0">
                                <tr>
                                    <td colspan="7" align="center" class="lbCalendarMon">
                                        <asp:Label ID="lblDec" runat="server">December</asp:Label></td>
                                </tr>
                                <tr class="lbCalendarDay">
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblDecSu" runat="server" ForeColor="red">Su</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblDecMo" runat="server">Mo</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblDecTu" runat="server">Tu</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblDecWe" runat="server">We</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblDecTh" runat="server">Th</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblDecFr" runat="server">Fr</asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label CssClass="lbLabel" ID="lblDecSt" runat="server" ForeColor="Blue">St</asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label463" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label464" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label465" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label466" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label467" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label468" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label469" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label470" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label471" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label472" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label473" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label474" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label475" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label476" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label477" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label478" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label479" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label480" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label481" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label482" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label483" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label484" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label485" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label486" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label487" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label488" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label489" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label490" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label491" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label492" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label493" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label494" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label495" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label496" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label497" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label498" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label499" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label500" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label501" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label502" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label503" runat="server"></asp:Label></td>
                                    <td width="20" align="center" class="excheckbox">
                                        <asp:Label Visible="false" CssClass="lbLabel" ID="Label504" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            </div>
            <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
                <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
                <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
                <asp:ListItem Value="2">---------- Chọn kho ----------</asp:ListItem>
            </asp:DropDownList>
    </form>
</body>
</html>
