<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WStatIndex"
    CodeFile="WStatIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStatIndex</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link id="Link1" runat="server" href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link id="Link2" runat="server" href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link id="Link3" runat="server" href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link id="Link4" runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" onload="parent.document.getElementById('frmMain').setAttribute('rows',rows='*,0');">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div id="TabbedPanels1" class="TabbedPanels">
            <ul class="TabbedPanelsTabGroup tab-head">
                <li class="TabbedPanelsTab" tabindex="0">
                    <asp:Label ID="lblSubTitle1" runat="server" CssClass="lbGroupTitle"> Thời gian</asp:Label></li>
                <li class="TabbedPanelsTab" tabindex="0">
                    <asp:Label CssClass="lbGroupTitle" ID="lblSubTitle2" runat="server"> Thuộc tính</asp:Label></li>
                <li class="TabbedPanelsTab" tabindex="0">
                    <asp:Label CssClass="lbGroupTitle" ID="lblSubTitle3" runat="server"> Danh sách upload file</asp:Label></li>
            </ul>
            <div class="TabbedPanelsContentGroup  tab-head-content">
                <div class="TabbedPanelsContent">
                    <div id="TabbedPanels2" class="TabbedPanels">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <a CssClass="lbLinkFunction" ID="lnkStatYear" runat="server" href="WStatYear.aspx"> 
                                        <span class="icon-history"></span>
                                         <span class="txtbox">Hàng năm </span>
                                        <span class="desc-button">Thống kê số lượt yêu cầu theo năm. </span>    
                                </a>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <a CssClass="lbLinkFunction" ID="lnkStatMonth" runat="server" href="WStatMonth.aspx"> 
                                        <span class="icon-history"></span> <span class="txtbox">Hằng tháng </span>
                                        <span class="desc-button">Thống kê số lượt yêu cầu theo tháng. </span>    
                                </a>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <a ID="lnkStatDay" runat="server" CssClass="lbLinkFunction" href="WStatDay.aspx">
                                        <span class="icon-history"></span> <span class="txtbox">Hằng ngày </span>
                                        <span class="desc-button">Thống kê số lượt yêu cầu theo ngày. </span>    
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="TabbedPanelsContent tab-head-content">
                    <ul class="TabbedPanelsTabGroup">
                        <li class="TabbedPanelsTab" tabindex="0">
                            <a CssClass="lbLinkFunction" ID="lnkStatTopItem" runat="server" href="WStatTopItem.aspx">
                                    <span class="icon-history"></span>
                                     <span class="txtbox">Tài liệu điện tử được yêu cầu mượn nhiều nhất </span>
                                    <span class="desc-button">Thống kê những tài liệu điện tử được yêu cầu mượn nhiều nhất theo khoảng thời gian. </span>    
                            </a>
                        </li>
                        <li class="TabbedPanelsTab" tabindex="0">
                            <a CssClass="lbLinkFunction" ID="lnkStatTopCustomer" runat="server" href="WStatTopCustomer.aspx">
                                    <span class="icon-history"></span> <span class="txtbox">Những đối tượng yêu cầu tài liệu điện tử</span>
                                    <span class="desc-button">Thống kê những đối tượng yêu cầu mượn tài liệu điện tử trong một khoảng thời gian.</span>    
                            </a>
                        </li>
                        <li class="TabbedPanelsTab" tabindex="0">
                            <a CssClass="lbLinkFunction" ID="lnkStatTop20" runat="server" href="WStatTop20.aspx">
                                    <span class="icon-history"></span> <span class="txtbox">Top 20 </span>
                                    <span class="desc-button">Thống kê 20 yêu cầu nhiều nhất theo các thuộc tính của tài liệu. </span>    
                            </a>
                        </li>
                    </ul>
                </div>

                
                <div class="TabbedPanelsContent">
                    <div id="TabbedPanels3" class="TabbedPanels">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <a CssClass="lbLinkFunction" ID="A1" runat="server" href="WStatFileUpload.aspx"> 
                                        <span class="icon-history"></span>
                                         <span class="txtbox">Danh sách upload file </span>
                                        <span class="desc-button">Thống kê danh sách upload file sách điện tử theo thời gian. </span>    
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
            var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels2");
            var TabbedPanels3 = new Spry.Widget.TabbedPanels("TabbedPanels3");
        </script>
    </div>
    <table style="display:none;" id="Table1" cellspacing="1" cellpadding="4" width="100%" border="0" bgcolor="#f3f3f3">
        <tr class="lbPageTitle">
            <td width="50%" class="lbGroupTitle" colspan="2">
                <%--<asp:Label id="lblSubTitle1" runat="server" CssClass="lbGroupTitle"> Thời gian</asp:Label>--%>
            </td>
            <td width="50%" class="lbGroupTitle" colspan="2">
                <%--<asp:Label CssClass="lbGroupTitle" id="lblSubTitle2" runat="server"> Thuộc tính</asp:Label>--%>
            </td>
        </tr>
        <tr class="lbFunctionTR">
            <td align="center" height="65" width="4%">
                <asp:ImageButton ID="imgStatYear" runat="server" ImageUrl="../Images/hang_nam.gif">
                </asp:ImageButton>
            </td>
            <td>
               <%-- <asp:HyperLink CssClass="lbLinkFunction" id="lnkStatYear11" runat="server" NavigateUrl="WStatYear.aspx"> Hàng năm</asp:HyperLink><br>--%>
                <asp:Label ID="lblStatYear" runat="server" CssClass="lbFunctionDetail"> Thống kê số lượt yêu cầu theo năm.</asp:Label>
            </td>
            <td align="center" height="65">
                <asp:ImageButton ID="imgStatTopItem" runat="server" ImageUrl="../Images/tai_lieu_dien_tu_muon_nhieu.gif">
                </asp:ImageButton>
            </td>
            <td>
                <%--	<asp:HyperLink CssClass="lbLinkFunction" id="lnkStatTopItem" runat="server" NavigateUrl="WStatTopItem.aspx">Tài liệu điện tử được yêu cầu mượn nhiều nhất</asp:HyperLink><br>--%>
                <asp:Label ID="lblStatTopItem" runat="server" CssClass="lbFunctionDetail">Thống kê những tài liệu điện tử được yêu cầu mượn nhiều nhất theo khoảng thời gian.</asp:Label>
            </td>
        </tr>
        <tr class="lbFunctionTR">
            <td align="center" height="65">
                <asp:ImageButton ID="imgStatMonth" runat="server" ImageUrl="../Images/hang_thang.gif">
                </asp:ImageButton>
            </td>
            <td>
                <%--<asp:HyperLink CssClass="lbLinkFunction" id="lnkStatMonth" runat="server" NavigateUrl="WStatMonth.aspx"> Hàng tháng</asp:HyperLink><br>--%>
                <asp:Label ID="lblStatMonth" runat="server" CssClass="lbFunctionDetail"> Thống kê số lượt yêu cầu theo tháng.</asp:Label>
            </td>
            <td align="center" height="65">
                <asp:ImageButton ID="imgStatTopCustomer" runat="server" ImageUrl="../Images/doi_tuong_yeu_cau_tai_lieu_.gif">
                </asp:ImageButton>
            </td>
            <td>
                <%--<asp:HyperLink CssClass="lbLinkFunction" id="lnkStatTopCustomer" runat="server" NavigateUrl="WStatTopCustomer.aspx">Những đối tượng yêu cầu tài liệu điện tử</asp:HyperLink><br>--%>
                <asp:Label ID="lblStatTopCustomer" runat="server" CssClass="lbFunctionDetail">Thống kê những đối tượng yêu cầu mượn tài liệu điện tử trong một khoảng thời gian.</asp:Label>
            </td>
        </tr>
        <tr class="lbFunctionTR">
            <td align="center" height="65">
                <asp:ImageButton ID="imgStatDay" runat="server" ImageUrl="../Images/hang_ngay.gif">
                </asp:ImageButton>
            </td>
            <td>
                <%--	<asp:HyperLink id="lnkStatDay" runat="server" CssClass="lbLinkFunction" NavigateUrl="WStatDay.aspx">Hàng ngày</asp:HyperLink><br>--%>
                <asp:Label ID="lblStatDay" runat="server" CssClass="lbFunctionDetail">Thống kê số lượt yêu cầu theo ngày. </asp:Label>
            </td>
            <td align="center" height="65">
                <asp:ImageButton ID="imgStatTop20" runat="server" ImageUrl="../Images/top_20.gif">
                </asp:ImageButton>
            </td>
            <td>
                <%--<asp:HyperLink CssClass="lbLinkFunction" id="lnkStatTop20" runat="server" NavigateUrl="WStatTop20.aspx">Top 20</asp:HyperLink><br>--%>
                <asp:Label ID="lblStatTop20" runat="server" CssClass="lbFunctionDetail">Thống kê 20 yêu cầu nhiều nhất theo các thuộc tính của tài liệu.</asp:Label>
            </td>
        </tr>
    </table>
    <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
        <asp:ListItem Value="0">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
    </asp:DropDownList>
    </form>
</body>
</html>
