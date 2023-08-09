<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WBatchProcess" CodeFile="WBatchProcess.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WBatchProcess</title>
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
                    <li class="TabbedPanelsTab TabbedPanelsTabSelected" tabindex="0">Xử lý lô</li>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <div id="TabbedPanels2" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server"  href="WBatchPatronUpdate.aspx">
                                        <span class="icon-history"></span>
                                        <p>Sửa</p>
                                        <p class="desc-button">Sửa thẻ bạn đọc theo lô.</p>    
                                    </asp:HyperLink>
                                    
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server"  href="WBatchPatronDelete.aspx">
                                        <span class="icon-history"></span>
                                        <p>Xoá</p>
                                        <p class="desc-button">Xoá thẻ bạn đọc theo lô.</p>    
                                    </asp:HyperLink>
                                    
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server"  href="WRenewCards.aspx">
                                        <span class="icon-history"></span>
                                        <p>Gia hạn</p>
                                        <p class="desc-button">Gia hạn thẻ bạn đọc theo lô.</p>    
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
