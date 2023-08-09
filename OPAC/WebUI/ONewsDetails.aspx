<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ONewsDetails.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.ONewsDetails" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
</head>
<body style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px">
<asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
<form id="form1" runat="server">
    <%--<header data-load="OTop.aspx"></header>
    <div class="" style="margin-top:-20px;">
        <div class="container">
            <div class="grid fluid">
                <div class="row"> &nbsp;</div>
                <div class="row">
                    <div class="tile-group no-margin no-padding clearfix" style="width: 100%">
                            <div class="tile double quadro-vertical bg-gray ol-transparent" style="float: right;display:none;">
                                <div class="tile-content">
                                    <div class="tile double quadro-vertical live" data-role="live-tile" data-effect="slideUp" data-easing="easeInCirc">
	                                    <div class="tile-content image">
		                                    <img src="images/Library/Advertising1.jpg">
                                            <div class="tile-status bg-dark opacity">
		                                        <span class="label">Quảng cáo 1</span>
	                                        </div>
	                                    </div>
	                                    <div class="tile-content image">
		                                    <img src="images/Library/Advertising5.jpg">
                                            <div class="tile-status bg-dark opacity">
		                                        <span class="label">Quảng cáo 2</span>
	                                        </div>
	                                    </div>
                                        <div class="tile-content image">
		                                    <img src="images/Library/Advertising6.jpg">
                                            <div class="tile-status bg-dark opacity">
		                                        <span class="label">Quảng cáo 3</span>
	                                        </div>
	                                    </div>
                                        <div class="tile-content image">
		                                    <img src="images/Library/Advertising7.jpg">
                                            <div class="tile-status bg-dark opacity">
		                                        <span class="label">Quảng cáo 4</span>
	                                        </div>
	                                    </div>
                                        <div class="tile-content image">
		                                    <img src="images/Library/Advertising8.jpg">
                                            <div class="tile-status bg-dark opacity">
		                                        <span class="label">Quảng cáo 5</span>
	                                        </div>
	                                    </div>
	                                    <div class="tile-content image">
		                                    <img src="images/Library/Advertising9.jpg">
                                            <div class="tile-status bg-dark opacity">
		                                        <span class="label">Quảng cáo 6</span>
	                                        </div>
	                                    </div>
                                    </div>
                                </div>
                            </div>


                            <div>
                                <asp:DataList ID="DataList1" runat="server" >
                                        <ItemTemplate>
                                        <div style="padding-bottom:10px" >                    
                                        <div class="panel-content fg-dark nlp nrp" style="margin-top: 10px;margin-bottom: 10px;font-size: 20px;font-weight: bold;"> <%# Eval("Tieu_de")%></div>
                                        </div>
                                        <span class="NoiDung">
                                       <div class="panel-content fg-dark nlp nrp" style="margin-top: 10px;margin-bottom: 10px;font-size: 15px;"><%# Eval("Tom_tat")%></div><br />
                                        <%# Eval("Noi_dung") %></span>
                                        </ItemTemplate>
                                    </asp:DataList>


                                <span style="text-decoration: underline; font-weight:bold; font-size:16px;color:Black;">Các tin khác</span>
                                <div style="padding-bottom:10px"></div>
                                    <asp:DataList ID="DataList2" runat="server" >
                                        <ItemTemplate>
                                        <div style="height:25px; padding-left:35px">
                                        <img src="images/arrows.gif" />
                                        <a href="ONewsDetails.aspx?cat=<%# GetFilename(Eval("Tieu_de").ToString()) %>&id=<%# Eval("id") %>" ><%# Eval("Tieu_de") %></a>
                                        </div>                                                    
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                    </div> <!-- End first group -->
                </div>
        <p id="back-top" data-hint="Trở về đầu trang" data-hint-position="left">
            <a href="#top"><span></span></a>
        </p>  
        </div>            
        </div>
    </div>
    <div class="page-footer">
        <div class="page-footer-content">
            <uc1:UFooter ID="UFooter1" runat="server" />
        </div>
    </div>  --%> 
    <uc2:UHeader ID="UHeader1" runat="server" />
    <div id="divMain">
        <div class="web-size news-page ClearFix">
            <h1  runat="server" id="h1News"><span class="mif-command"></span>Tin tức</h1>
            <div class="col-left-7 news-detail">
                <asp:Literal runat="server" ID="ltrNewsInfo"></asp:Literal>
            </div>
            <div class="col-right-3 news-other">
                <asp:Literal runat="server" ID="ltrNewsOther"></asp:Literal>
            </div>
        </div>
    </div>
    <uc1:UFooter ID="UFooter1" runat="server" />
    <a href="#" id="toTop" class="scrollup">Scroll</a>
</form>
</body>
</html>
