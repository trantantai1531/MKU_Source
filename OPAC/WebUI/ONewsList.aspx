<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ONewsList.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.ONewsList" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <script src="js/ui/jquery.js"></script>
    <script src="js/ui/core.js"></script>
	<script src="js/ui/widget.js"></script>
	<script src="js/ui/mouse.js"></script>
	<script src="js/ui/draggable.js"></script>
	<script src="js/ui/droppable.js"></script>
    <script src="js/ui/jquery.bpopup.min.js"></script>
    <script src="js/ui/jquery.easing.1.3.min.js"></script>
    <script src="js/metro.min.js"></script>
    <script src="js/docs.js"></script>
    <script src="js/OIndex.js"></script>
    <style>
	    #back-top {
	        position: fixed;
	        bottom: 70px;
	        right: 15px;
	        margin-left: -150px;
	        z-index:1000;
        }
        #back-top a {
	        width: 32px;
	        display: block;
	        text-align: center;
	        font: 11px/100% Arial, Helvetica, sans-serif;
	        text-transform: uppercase;
	        text-decoration: none;
	        color: #fff;
        }
        #back-top a:hover {
	        color: #fff;
        }
        #back-top span {
	        width: 48px;
	        height: 48px;
	        display: block;
	        margin-bottom: 1px;
	        background: #0EA6E2 url(Images/Icons/up-arrow2.png) no-repeat center center;
	        background-color: transparent;
        }
        #back-top a:hover span {
	        background-color: transparent;
        }      
    </style>
    <script type="text/javascript">
        $(function () {

            $("#back-top").hide();

            $(window).scroll(function () {
                if ($(this).scrollTop() > 100) {
                    $('#back-top').fadeIn();
                } else {
                    $('#back-top').fadeOut();
                }
            });

            // scroll body to 0px on click
            $('#back-top a').click(function () {
                $('body,html').animate({
                    scrollTop: 0
                }, 800);
                return false;
            });
        });
    </script>
</head>
<body class="metro"  id="top"  style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px">
<asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
<form id="form1" runat="server">
    <header data-load="OTop.aspx"></header>
    <div class="" style="margin-top:-20px;">
        <div class="container">
            <div class="grid fluid">
                 <div class="row"> &nbsp;</div>
                <div class="row">
                    <div class="tile-group no-margin no-padding clearfix" style="width: 100%">
                         <div class="tile double quadro-vertical bg-gray ol-transparent" style="float: right; ">
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
                            <asp:Repeater ID="rptType" runat="server">
                                    <ItemTemplate>
                                    <a href="ONewsList.aspx?cat=<%# GetFilename(Eval("Loai").ToString()) %>&id=<%# Eval("id") %>"><span class=" fg-orange" style="font-size: 20px;font-weight: bold;"><%# Eval("Loai")%> <span class="icon-arrow-right-5"></span></span></a>
                                    </ItemTemplate>
                                </asp:Repeater>
                                

                                <asp:Repeater ID="rptNews" runat="server">
                                    <ItemTemplate>
                                        <div style="margin-top:15px;width: 90%;">
                                            <a href='ONewsDetails.aspx?cat=<%# GetFilename(Eval("Tieu_de").ToString()) %>&id=<%# Eval("id") %>' title="<%# Eval("Tieu_de") %>" style="float:left;margin-top: 10px;margin-right: 20px;"> <img src="upload/TT/<%# Eval("Anh") %>" style="width:100px;height:100px;"></a>
                                            <div ><a title="<%# Eval("Tieu_de") %>" href="ONewsDetails.aspx?cat=<%# GetFilename(Eval("Tieu_de").ToString()) %>&id=<%# Eval("id") %>" class="titleNew" style="font-weight: bold;"><%# Eval("Tieu_de")%></a></div>
                                            <div class="panel-content fg-dark nlp nrp" style="margin-top: 10px;margin-bottom: 10px;"><%# Eval("Tom_tat")%></div>    
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                        </div>
                        <br />
                            <asp:Label ID="lblCurrpage" runat="server" Text=""></asp:Label>
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
    </div> 
</form>
</body>
</html>
