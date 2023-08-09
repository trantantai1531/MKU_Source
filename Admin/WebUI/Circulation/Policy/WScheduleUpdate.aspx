<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WScheduleUpdate" CodeFile="WScheduleUpdate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WScheduleUpdate</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

    <link href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
    <link href="../../Resources/StyleSheet/Schedule.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
   
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head" id="tabMuonVe">
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkWorkingTime" runat="server" NavigateUrl="WWorkingUpdate.aspx">Thời gian làm việc</asp:HyperLink></li>
                    <li class="TabbedPanelsTab activetab" tabindex="0">

                        <asp:HyperLink ID="lnkWorkingSchedue" runat="server" CssClass="lbFunctionTitle">Lập lịch làm việc</asp:HyperLink>
                    </li>
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lblSchedueView" runat="server" NavigateUrl="WScheduleView.aspx">Xem lịch làm việc</asp:HyperLink>
                    </li>
                </ul>
            </div>
            <div class="main-form">
                <div class="row-detail inline-box">
                    <span>Năm :</span>
                    <div class="input-control button-control" style="width: 20px;">
                        <div class="button-form">
                            <asp:LinkButton ID="lnkPrevious" runat="server" CssClass=""> <<   </asp:LinkButton>
                        </div>
                    </div>
                    <div class="input-control inline-box" style="width: auto;">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="input-control button-control" style="width: 20px;">
                        <div class="button-form">
                            <asp:LinkButton ID="lnkNext" runat="server" CssClass=""> >> </asp:LinkButton>
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

                <div class="row-detail">
                    <table id="tblCalendar" cellspacing="0" cellpadding="0" width="100%" border="1">
                        <tr>
                            <td colspan="3"></td>
                        </tr>
                        <tr>
                            <td>
                                <table id="tblMon1" class="lbCalendar" cellspacing="1" cellpadding="0" width="100%" height="100%"
                                    border="0">
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
                                            <div>
                                                <asp:CheckBox Visible="false" ID="CheckBox1" runat="server" TextAlign="Left"
                                                    Width="20"></asp:CheckBox>
                                            </div>
                                        </td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox2" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox3" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox4" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox5" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox6" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox7" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox8" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox9" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox10" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox11" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox12" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox13" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox14" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox15" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox16" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox17" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox18" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox19" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox20" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox21" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox22" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox23" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox24" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox25" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox26" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox27" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox28" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox29" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox30" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox31" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox32" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox33" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox34" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="CheckBox35" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox36" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox37" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox38" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox39" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox40" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox41" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox42" runat="server" TextAlign="Left"></asp:CheckBox></td>
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
                                            <asp:CheckBox Visible="false" ID="Checkbox43" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox44" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox45" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox46" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox47" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox48" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox49" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox50" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox51" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox52" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox53" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox54" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox55" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox56" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox57" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox58" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox59" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox60" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox61" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox62" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox63" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox64" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox65" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox66" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox67" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox68" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox69" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox70" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox71" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox72" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox73" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox74" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox75" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox76" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox77" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox78" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox79" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox80" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox81" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox82" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox83" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox84" runat="server" TextAlign="Left"></asp:CheckBox></td>
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
                                            <asp:CheckBox Visible="false" ID="Checkbox85" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox86" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox87" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox88" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox89" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox90" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox91" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox92" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox93" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox94" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox95" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox96" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox97" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox98" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox99" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox100" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox101" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox102" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox103" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox104" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox105" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox106" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox107" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox108" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox109" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox110" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox111" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox112" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox113" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox114" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox115" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox116" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox117" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox118" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox119" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox120" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox121" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox122" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox123" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox124" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox125" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox126" runat="server" TextAlign="Left"></asp:CheckBox></td>
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
                                            <asp:CheckBox Visible="false" ID="Checkbox127" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox128" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox129" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox130" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox131" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox132" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox133" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox134" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox135" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox136" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox137" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox138" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox139" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox140" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox141" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox142" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox143" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox144" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox145" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox146" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox147" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox148" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox149" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox150" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox151" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox152" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox153" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox154" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox155" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox156" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox157" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox158" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox159" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox160" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox161" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox162" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox163" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox164" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox165" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox166" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox167" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox168" runat="server" TextAlign="Left"></asp:CheckBox></td>
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
                                            <asp:CheckBox Visible="false" ID="Checkbox169" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox170" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox171" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox172" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox173" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox174" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox175" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox176" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox177" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox178" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox179" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox180" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox181" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox182" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox183" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox184" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox185" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox186" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox187" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox188" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox189" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox190" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox191" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox192" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox193" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox194" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox195" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox196" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox197" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox198" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox199" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox200" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox201" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox202" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox203" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox204" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox205" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox206" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox207" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox208" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox209" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox210" runat="server" TextAlign="Left"></asp:CheckBox></td>
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
                                            <asp:CheckBox Visible="false" ID="Checkbox211" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox212" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox213" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox214" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox215" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox216" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox217" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox218" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox219" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox220" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox221" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox222" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox223" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox224" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox225" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox226" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox227" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox228" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox229" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox230" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox231" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox232" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox233" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox234" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox235" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox236" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox237" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox238" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox239" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox240" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox241" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox242" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox243" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox244" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox245" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox246" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox247" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox248" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox249" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox250" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox251" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox252" runat="server" TextAlign="Left"></asp:CheckBox></td>
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
                                            <asp:CheckBox Visible="false" ID="Checkbox253" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox254" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox255" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox256" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox257" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox258" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox259" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox260" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox261" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox262" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox263" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox264" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox265" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox266" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox267" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox268" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox269" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox270" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox271" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox272" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox273" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox274" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox275" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox276" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox277" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox278" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox279" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox280" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox281" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox282" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox283" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox284" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox285" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox286" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox287" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox288" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox289" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox290" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox291" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox292" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox293" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox294" runat="server" TextAlign="Left"></asp:CheckBox></td>
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
                                            <asp:CheckBox Visible="false" ID="Checkbox295" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox296" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox297" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox298" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox299" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox300" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox301" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox302" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox303" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox304" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox305" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox306" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox307" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox308" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox309" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox310" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox311" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox312" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox313" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox314" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox315" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox316" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox317" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox318" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox319" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox320" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox321" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox322" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox323" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox324" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox325" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox326" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox327" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox328" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox329" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox330" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox331" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox332" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox333" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox334" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox335" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox336" runat="server" TextAlign="Left"></asp:CheckBox></td>
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
                                            <asp:CheckBox Visible="false" ID="Checkbox337" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox338" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox339" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox340" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox341" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox342" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox343" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox344" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox345" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox346" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox347" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox348" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox349" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox350" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox351" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox352" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox353" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox354" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox355" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox356" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox357" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox358" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox359" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox360" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox361" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox362" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox363" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox364" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox365" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox366" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox367" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox368" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox369" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox370" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox371" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox372" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox373" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox374" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox375" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox376" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox377" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox378" runat="server" TextAlign="Left"></asp:CheckBox></td>
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
                                            <asp:CheckBox Visible="false" ID="Checkbox379" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox380" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox381" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox382" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox383" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox384" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox385" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox386" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox387" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox388" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox389" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox390" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox391" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox392" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox393" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox394" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox395" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox396" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox397" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox398" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox399" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox400" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox401" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox402" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox403" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox404" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox405" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox406" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox407" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox408" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox409" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox410" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox411" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox412" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox413" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox414" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox415" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox416" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox417" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox418" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox419" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox420" runat="server" TextAlign="Left"></asp:CheckBox></td>
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
                                            <asp:CheckBox Visible="false" ID="Checkbox421" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox422" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox423" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox424" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox425" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox426" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox427" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox428" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox429" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox430" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox431" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox432" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox433" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox434" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox435" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox436" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox437" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox438" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox439" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox440" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox441" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox442" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox443" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox444" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox445" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox446" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox447" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox448" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox449" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox450" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox451" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox452" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox453" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox454" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox455" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox456" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox457" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox458" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox459" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox460" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox461" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox462" runat="server" TextAlign="Left"></asp:CheckBox></td>
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
                                            <asp:CheckBox Visible="false" ID="Checkbox463" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox464" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox465" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox466" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox467" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox468" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox469" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox470" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox471" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox472" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox473" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox474" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox475" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox476" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox477" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox478" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox479" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox480" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox481" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox482" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox483" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox484" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox485" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox486" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox487" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox488" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox489" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox490" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox491" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox492" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox493" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox494" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox495" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox496" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox497" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                    <tr>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox498" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox499" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox500" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox501" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox502" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox503" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                        <td width="20" align="center" class="excheckbox">
                                            <asp:CheckBox Visible="false" ID="Checkbox504" runat="server" TextAlign="Left"></asp:CheckBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="row-detail">
                    <asp:Label CssClass="lbSubFormTitle" ID="lblAssignAlso" runat="server">Giờ làm việc này cũng được áp dụng cho các kho sau</asp:Label>
                    <div class="input-control">
                        <div class="input-form">
                            <asp:ListBox ID="lstLocation" CssClass="area-input" runat="server" SelectionMode="Multiple" Height="84px" Width="300px"></asp:ListBox>
                        </div>
                    </div>

                </div>

                <div class="row-detail">
                    <div class="button-control" style="text-align: center">
                        <div class="button-form">
                            <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật(u)" Width=""></asp:Button>

                            <asp:Button ID="btnReset" runat="server" Text="Nhập lại(r)" Width=""></asp:Button>
                        </div>
                        <%-- <div class="button-form">
                            <asp:Button ID="btnReset" runat="server" Text="Nhập lại(r)" Width=""></asp:Button>
                        </div>--%>
                    </div>
                </div>

            </div>
        </div>

        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">---------- Chọn kho ----------</asp:ListItem>
            <asp:ListItem Value="3">Bạn chưa chọn kho cần làm việc</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
