<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ODefault.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.ODefault" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <script src="js/ui/jquery.js"></script>
    <script src="js/ui/core.js"></script>
	<script src="js/ui/widget.js"></script>
	<script src="js/ui/mouse.js"></script>
    <script src="js/metro.min.js"></script>
    <script src="js/ODefault.js"></script>    
</head>
<body class="metro"  id="top"  style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px;">
    <form id="form1" runat="server">
     <div class="navigation-bar" id="navHeader" runat="server">
        <div class="navigation-bar-content container"  style="height:55px;">
            <div class="grid fluid">                
                <div class="row">
                     <div  class="element place-right" >
                        <span id="spLanguage" runat="server">Ngôn ngữ:</span>
                        <a class="dropdown-toggle" href="#" title="Thay đổi ngôn ngữ" runat="server" id="lnkChangLanguage">
					        <img src="images/Language/vie.png" style="height:22px;width:22px;text-align:center;vertical-align:text-top;margin-top:-3px;" id="imgFlag" runat="server"/>
				        </a>
				        <ul class="dropdown-menu place-right" data-role="dropdown">
                            <asp:Literal runat="server" ID="ltrLanguage"></asp:Literal>   
				        </ul>
                    </div>  
                    <div  class='span10'>
                        <div id="divWelcome" runat="server"><h3  class="fg-white"><img src="images/Imgviet/WhiteLogo.png" border="0" />&nbsp;Chào mừng đến với thư viện điện tử - thư viện số eMicLib</h3></div>
                    </div>
                </div>
            </div>
        </div>
     </div>
    <div class="container">
        <div class="grid fluid">
            <div class="row">
                <asp:Literal runat="server" ID="lrtLibrary"></asp:Literal>
            </div>
        </div>
    </div>
     <div class="page-footer">
        <div class="page-footer-content">
            <uc1:UFooter ID="UFooter1" runat="server" />
        </div>
    </div> 
    <div style="display:none">
        <span id="spLanguageVietNamese" runat="server">Tiếng Việt</span>
        <span id="spLanguageEnglish" runat="server">Tiếng Anh</span>
    </div>
    </form>
</body>
</html>
