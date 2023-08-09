<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WCardIndex" CodeFile="WCardIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCardIndex</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link runat="server" href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link runat="server" href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link runat="server" href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
        <link runat="server" href="../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
        <script type="text/javascript" src="../js/SpryTabbedPanels.js"></script>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body class="backgroundbody" style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px;">
		<form id="Form1" method="post" runat="server">
			<div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab TabbedPanelsTabSelected" tabindex="0">Thẻ bạn đọc</li>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <div id="TabbedPanels2" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server"  href="WCardTemplate.aspx">
                                        <span class="icon-history"></span>
                                        <p>Mẫu thẻ</p>
                                        <p class="desc-button">Tạo mới, sữa, xoá mẫu thẻ bạn đọc.</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server"  href="WCards.aspx">
                                        <span class="icon-history"></span>
                                        <p>In thẻ</p>
                                        <p class="desc-button">In thẻ bạn đọc theo mẫu.</p>    
                                    </asp:HyperLink>
                                    
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server"  href="WBarcodeSearch.aspx">
                                        <span class="icon-history"></span>
                                        <p>In mã vạch</p>
                                        <p class="desc-button">In mã vạch theo lô, từng số thẻ.</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server"  href="WMonitorPrintCard.aspx">
                                        <span class="icon-history"></span>
                                        <p>Theo dõi in thẻ</p>
                                        <p class="desc-button">Theo dõi quá trình in thẻ bạn đọc.</p>    
                                    </asp:HyperLink>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
		</form>
	</body>
</HTML>
