<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WIndexLog"
    CodeFile="WIndexLog.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WIndexLog</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/SpryTabbedPanels.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script>
        $(document).ready(function () {
            $("p").click(function () {
                $(this).hide();
            });
        });
    </script>
</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px;
    margin-bottom: 0px;">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div class="TabbedPanels" id="Div1">
            <ul class="TabbedPanelsTabGroup tab-head">
                <li tabindex="0" class="TabbedPanelsTab TabbedPanelsTabSelected"> Thống kê các hoạt động sử dụng hệ thống </li>
              
            </ul>
        </div>
      
        <div class="main-body ClearFix">
            <div class="content-form">
                <div id="TabbedPanels1" class="TabbedPanels">
                    <ul class="TabbedPanelsTabGroup demo-3">
                        <li class="TabbedPanelsTab tab-item" tabindex="0">
                            <asp:HyperLink runat="server" NavigateUrl="WSetLogMode.aspx">
                                        <span class="icon-history"></span> 
                                        <label class="txtbox"> Đặt chế độ ghi Log</label> </asp:HyperLink>
                        </li>
                        <li class="TabbedPanelsTab tab-item" tabindex="1">
                            <asp:HyperLink runat="server" NavigateUrl="WSearchForm.aspx">
                                      <span class="icon-history"></span><label class="txtbox">Tra cứu Log</label>
                            </asp:HyperLink>
                        </li>
                        <li class="TabbedPanelsTab tab-item" tabindex="2"><a href="~/Admin/WDeleteLog.aspx"
                            id="lnkDeleteLog" runat="server"><span class="icon-history"></span><span class="txtbox">
                                Xóa Log</span> </a></li>
                        <li class="TabbedPanelsTab tab-item" tabindex="3"><a href="~/Admin/WStatWeek.aspx"
                            id="A1" runat="server"><span class="icon-history"></span><span class="txtbox">Thống kê Log
                                theo tuần</span> </a></li>
                        <li class="TabbedPanelsTab tab-item" tabindex="4">
                            <asp:HyperLink runat="server" NavigateUrl="WStatMonth.aspx">
                                       <span class="icon-history"></span>
                                        <label class="txtbox">Thống kê Log theo tháng</label>
                            </asp:HyperLink>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div style="display: none;">
        <asp:ImageButton ID="imgSetLogMode" runat="server" ImageUrl="Images/dat_che_do_ghi_log.gif">
        </asp:ImageButton>
        <asp:ImageButton ID="imgDeleteLog" runat="server" ImageUrl="Images/xoa_log.gif">
        </asp:ImageButton>
        <asp:ImageButton ID="imgWeekStat" runat="server" ImageUrl="Images/thong_ke_log_theo_tuan.gif">
        </asp:ImageButton>
        <asp:ImageButton ID="imgMonthStat" runat="server" ImageUrl="Images/thong_ke_log_theo_thang.gif">
        </asp:ImageButton>
        <asp:ImageButton ID="imgSearchLog" runat="server" ImageUrl="Images/thong_ke_log_theo_thang.gif">
        </asp:ImageButton>
    </div>
    <asp:DropDownList runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
        <asp:ListItem Value="0">Bạn không được quyền truy cập vào chức năng này!</asp:ListItem>
    </asp:DropDownList>
    </form>
</body>
</html>
