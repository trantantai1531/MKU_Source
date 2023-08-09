<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIndexDictionary" CodeFile="WIndexDictionary.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIndexDictionary</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link runat="server" href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link runat="server" href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link runat="server" href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
        <link runat="server" href="../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../js/SpryTabbedPanels.js"></script>

	</HEAD>
	<body class="backgroundbody" style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px;">
		<form id="Form1" method="post" runat="server">
		  <div id="divBody">
        	
            <div id="TabbedPanels1" class="TabbedPanels">
            <ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab TabbedPanelsTabSelected" tabindex="0">Từ điển</li>
                </ul>
				<div class="TabbedPanelsContentGroup  tab-head-content">
                	
                    <div class="TabbedPanelsContent">
                    	<ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                            	<a href="Dictionaries/WDicAuthority.aspx">
                                	<span class="icon-history"></span>
                                    <p>Quản lý chỉ mục dựng sẵn</p>
                                    <p class="desc-button">Quản lý các chỉ mục dựng sẵn.</p>
                                </a>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <a href="Dictionaries/WManualDic.aspx">
                            
                                	<span class="icon-history"></span>
                                    <p>Quản lý từ điển tự tạo</p>
                                    <p class="desc-button">Cho phép quản lý các chỉ mục tự tạo.</p>
                               </a>
                            </li>
                            
                             <li class="TabbedPanelsTab" tabindex="0">
                                <a href="Dictionaries/WEngVnDic.aspx">
                            
                                	<span class="icon-history"></span>
                                    <p>Quản lý từ điển Anh-Việt</p>
                                    <p class="desc-button">Cho phép quản lý từ điển Anh-Việt.</p>
                               </a>
                            </li>
                        </ul>
                    </div>
                    
                </div>
            </div>
        </div>
		</form>
	</body>
</HTML>
