<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ONews.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.ONews" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Trường Đại Học Cửu Long</title>
    <script src="js/ONews.js"></script> 
    <style type="text/css" >
        .columnLeft {
            float: left;
            width: 20%;                     
        }
        .columnRight {
            float: left;
            width: 80%;
        }
   
        .liMenu{
            padding:1px 0px 0px 1px;
        }
        .aMenu{
            font-size: 14px; 
            text-transform: capitalize; 
            color: rgb(255, 255, 255); 
            font-family: sans-serif;
            font-weight: 400;
            background-color: rgb(40, 96, 144); 
            line-height: 40px;

            display: inline-block;
            width: 100%;
            text-align: center;
            text-decoration: none;
            border-right: 1px solid #cfcfcf;
            box-sizing: border-box;
            padding-left: 5%;
            padding-right: 5%;
           
        }
        .aMenu:hover{
            color:white;
            background-color:#4da6ff;
        }
    </style>

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
                         <div class="tile double quadro-vertical bg-gray ol-transparent" style="float: right;display:none; ">
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
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                    <asp:Repeater ID="rptNews" runat="server">
                                        <ItemTemplate>
                                            <div style="margin-top:15px;width: 90%;">
                                                <a href='ONewsDetails.aspx?cat=<%# GetFilename(Eval("Tieu_de").ToString()) %>&id=<%# Eval("id") %>' title="<%# Eval("Tieu_de") %>" style="float:left;margin-top: 10px;margin-right: 20px;"> <img src="upload/TT/<%# Eval("Anh") %>" style="width:100px;height:100px;"></a>
                                                <div ><a title="<%# Eval("Tieu_de") %>" href="ONewsDetails.aspx?cat=<%# GetFilename(Eval("Tieu_de").ToString()) %>&id=<%# Eval("id") %>" class="titleNew" style="font-weight: bold;"><%# Eval("Tieu_de")%></a></div>
                                                <div class="panel-content fg-dark nlp nrp" style="margin-top: 10px;margin-bottom: 10px;"><%# Eval("Tom_tat")%></div>    
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div> <!-- End first group -->
                </div>
            <p id="back-top" data-hint="Trở về đầu trang" data-hint-position="left">
                <a href="#top"><span></span></a>
            </p>  
            </div>
                   
         </div>
    </div>--%>
    <uc2:UHeader ID="UHeader1" runat="server" />
       <div id="divMain" >
            <div class="web-size news-page ClearFix">                
                <div class="columnLeft">
                    <h1  runat="server" id="h1News"><span class="mif-command"><a href="ONews.aspx?">Tin Tức</a> </h1>                    
                        <ul>
                            <asp:Literal runat="server" ID="LiteralListSubject"></asp:Literal>                         
                        </ul>                      
                </div>

                <div class="columnRight"  >
                    <h1  runat="server" id="SubjectName" style=""><span class=""></span></h1>
                    <div class="list-news">
                            <div class="row-group">
                            <asp:Literal runat="server" ID="ltrNews"></asp:Literal>
                            </div>
                    </div>
                    <div class="divPage">
                        <ul class="ClearFix">
                            <asp:Literal runat="server" ID="lrtPagination"></asp:Literal>
                        </ul>
                    </div>
                </div>
           </div>
        </div>

    <uc1:UFooter ID="UFooter1" runat="server" />
    <a href="#" id="toTop" class="scrollup">Scroll</a>
    <div style="display:none">
        <input id="hidCurrentPage" type="hidden" value="1" runat="server" />
        <input id="hidIds" type="hidden" value="" runat="server" />
        <span id="spRecordItem" runat="server">Mục</span>
        <span id="spRecordTo" runat="server">đến</span>
        <span id="spRecordOf" runat="server">của</span>
        <span id="spPreviousPage" runat="server">Trang trước</span>
        <span id="spNextPage" runat="server">Trang tiếp</span>
        <asp:Button runat="server" ID="raiseShowRecord"  Text="raiseShowRecord" CausesValidation="false"/>
    </div>
</form>
</body>
</html>
