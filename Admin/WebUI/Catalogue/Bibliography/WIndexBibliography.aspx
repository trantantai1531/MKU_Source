<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIndexBibliography" CodeFile="WIndexBibliography.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIndexBibliography</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link runat="server" href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link runat="server" href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link runat="server" href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
        <link runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>

	</HEAD>
	<body class="backgroundbody" style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px;" onload="parent.document.getElementById('frmMain').setAttribute('rows','*,0');">
		<form id="Form1" method="post" runat="server">
		  <div id="divBody">
        	<div id="TabbedPanels1" class="TabbedPanels">
            	<ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab" tabindex="0">Danh mục</li>
                    <li class="TabbedPanelsTab" tabindex="0" style="display:none;">Phích</li>
                </ul>
				<div class="TabbedPanelsContentGroup  tab-head-content">
                	
                    <div class="TabbedPanelsContent">
                    	<ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" style = "display:none" tabindex="0">
                            	<a href="WCatPatternFrame.aspx">
                                	<span class="icon-history"></span>
                                    <p>Mẫu danh mục</p>
                                    <p class="desc-button">Định dạng các sản phẩm thư mục bằng các mẫu (template).</p>
                                </a>
                            </li>
                            <li class="TabbedPanelsTab" style = "display:none" tabindex="0">
                            	<a href="WIDXAddNew.aspx">
                                	<span class="icon-history"></span>
                                    <p>In danh mục</p>
                                    <p class="desc-button">In danh mục ấn phẩm theo template.</p>
                                </a>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                            	<a href="WCataSH.aspx">
                                	<span class="icon-history"></span>
                                    <p>Danh mục theo chuyên ngành</p>
                                    <p class="desc-button">Danh mục tài liệu theo chuyên ngành.</p>
                                </a>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                            	<a href="WCataSHCount.aspx">
                                	<span class="icon-history"></span>
                                    <p>Danh mục số lượng theo chuyên ngành</p>
                                    <p class="desc-button">Danh mục số lượng tài liệu theo chuyên ngành.</p>
                                </a>
                            </li>
                        </ul>
                    </div>
                    
                    <div class="TabbedPanelsContent">
                    	<ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                            	<a href="WCatPatternFichFrame.aspx">
                                	<span class="icon-history"></span>
                                    <p>Mẫu phích</p>
                                    <p class="desc-button">Định dạng các sản phẩm phích phiếu bằng các mẫu (template).</p>
                                </a>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                            	<a href="WFicheForm.aspx">
                                	<span class="icon-history"></span>
                                    <p>In phích</p>
                                    <p class="desc-button">In phích phiếu cho các bản ghi trong cơ sở dữ liệu theo template.</p>
                                </a>
                            </li>
                        </ul>
                    </div>
                    
                </div>
            </div>
               <script type="text/javascript">
			var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
    	</script>
        </div>
		</form>
	</body>
</HTML>
