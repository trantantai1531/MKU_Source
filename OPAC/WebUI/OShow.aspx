<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OShow.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OShow" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <script type="text/javascript" src="js/OShow.js"></script>    
    <% 
        Response.Write("<style type='text/css'>.item-box:hover h2, .item-box:hover h2 a { background: #096 none repeat scroll 0 0 !important; } .clr-cyan { background: #096; }</style>")
        Response.Write("<style type='text/css'>.item-box h3{ color:#1ba1e2; border-top:none; } .item-box h3 a{ color:#1ba1e2; } .item-box:hover h2, .item-box:hover h2 a { background: #1ba1e2 none repeat scroll 0 0 !important; } .clr-cyan { background: #1ba1e2; }</style>")

        Response.Write("<style type='text/css'>.item-box h3.clr-cyan-2{ color:#1ba1e2; background:none; text-align:right; margin-right: 10px;} .item-box h3.clr-cyan-2 a{ color:#1ba1e2; border-bottom: 1px solid #999; padding-bottom: 10px;}</style>")
        Response.Write("<style type='text/css'>.item-box h3.clr-cyan-3{ color:#096; border-top:none; } .item-box h3.clr-cyan-3 a{ color:#096; }</style>")
        Response.Write("<style type='text/css'>.item-box:hover h2.clr-cyan-2, .item-box:hover h2.clr-cyan-2 a { background: #096 none repeat scroll 0 0 !important; } .clr-cyan-2 { background: #096; }</style>")
    %>
    <style type="text/css">
        .item-info .item-intro {
            height: 215px;
            overflow: hidden;
            line-height:20px;
        }
        .item-intro p span
        {
            margin-right:0px;
        }
        .item-info .item-img
        {
            height:auto;
        }
        .item-info .item-img img
        {
            width:80%;
            max-width: none;
            min-height: initial;
            padding-top:10px;
            padding-bottom:10px;
        }
        .item-box h2
        {
            text-align:left;
        }
        .item-box h2 a
        {
            /*transition:none;*/
        }
        .item-box:hover h2 a
        {
            text-align:left;
            padding: 0px 0;
            /*transition:none;*/
            position:relative;
            top:-10px;
        }
        .item-box h3
        {
            padding: 11px 0px;
        }
        .item-box h3 span
        {
            margin-right: 0;
            margin-left: 10px;
        }
        .col-left-6
        {
            width:60%;
        }
        .more-detail
        {
            margin: 0px 10px;
            position:relative;
            border:none;
        }
        .class
        {
            position:absolute;
            left:0;
            top:5px;
        }
        .view
        {
            position:absolute;
            right:0;
            top:5px;
        }
        .divPage ul li a:hover, .divPage .PageSeleted
        {
            background:#013366 !important;
        }
        .clr-cyan
        {
            background:#013366 !important;
        }
        .item-box h3.clr-cyan-2 a
        {
            color:#013366 !important;
        }
        .item-box:hover h2, .item-box:hover h2 a
        {
            background:#013366 !important;
        }
    </style>
</head>
<body style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px" >
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
    <form id="form1" runat="server">
          <uc2:UHeader ID="UHeader1" runat="server" />
           <div id="divMain" style="min-height: 400px;">
    	    <div class="web-size ClearFix">                
        	    <div class="col-right-7 item-list">
                    <div>
                        <h3>
                            <asp:Literal runat="server" ID="ltrBreadcrumbsInResult"></asp:Literal>
                            <asp:Literal runat="server" ID="ltrBreadcrumbsFilter"></asp:Literal>
                        </h3>
                    </div>
            	    <div class="search-tool"  id="divSearchInResult" runat="server">
                	    <input type="text" class="tb-search" placeholder="<%=strTextHolder %>" id="txtSearchInResult" name="txtSearchInResult" onkeypress="keySearchInResult(event);"/>
                        <span class="icon-search"></span>
                        <input type="button" class="search-btn" id="btSearchInResult" onclick="searchInResult()"/>
                    </div>
                
                    <div class="divPage">
                	    <ul class="ClearFix">
                            <asp:Literal runat="server" ID="lrtPagination1"></asp:Literal>
                        </ul>
                        <div class="inline-block  place-right" runat="server" id="divOrderBy">
                            <div class="input-control">
                                <div class="input-dropdownlist">
                                    <asp:Literal runat="server" ID="ltrOrderBy"></asp:Literal> 
                                </div>
                            </div>
                        </div>     
                    </div>
                    
            	    <ul class="ClearFix">
                        <asp:Literal runat="server" ID="ltrBookList"></asp:Literal>
                    </ul>
                
                    <div class="divPage">
                	    <ul class="ClearFix">
                             <asp:Literal runat="server" ID="lrtPagination2"></asp:Literal>
                        </ul>
                    </div>
                </div>
        	    <div class="col-left-3 page-list">
                    <asp:Literal runat="server" ID="ltrDDC"></asp:Literal>
                    <asp:Literal runat="server" ID="ltrList"></asp:Literal>
                </div>
            </div> 
        </div>

          <uc1:UFooter ID="UFooter1" runat="server" />
          <a href="#" id="toTop" class="scrollup">Scroll</a>
          <div style="display:none">                    
                <span id="spSaveList" runat="server">Lưu danh sách</span>
                <span id="spCancelList" runat="server">Hủy danh sách</span>
                <span id="spOrderBy" runat="server">--Sắp xếp bởi--</span>
                <span id="spPageLink" runat="server">Trang</span>  
                <span id="spMXG" runat="server">Ký hiệu</span>  
                <span id="spCatalogy" runat="server">Danh mục</span>   
                <span id="spEDATAContent" runat="server">&nbsp;Đọc nội dung</span> 
                <span id="spEDATA" runat="server">Dữ liệu điện tử</span> 
                <span id="spURL" runat="server">Địa chỉ truy cập</span> 
                <span id="spMsgNotFound" runat="server">Không tìm thấy biểu ghi nào.</span>   
                <span id="spItemType" runat="server">Dạng tài liệu</span> 
                <span id="spISSN" runat="server">ISSN</span>         
                <span id="spAuthor" runat="server">Tác giả</span>
                <span id="spPublisher" runat="server">Nhà xuất bản</span>
                <span id="spKeyWord" runat="server">Từ khóa</span>
                <span id="spSeries" runat="server">Series</span>
                <span id="spSubjectheading" runat="server">Tiêu đề đề mục</span>
                <span id="spLanguage" runat="server">Ngôn ngữ</span>
                <span id="spNLM" runat="server">Phân loại NLM</span>
                <span id="spDDC" runat="server">Phân loại DDC</span>
                <span id="spElectronicData" runat="server">Tài liệu số (Toàn văn)</span>
                <span id="spPublisherYear" runat="server">Năm xuất bản</span>
                <span id="spViewMore" runat="server">Xem nhiều hơn</span>
                <span id="spViewLess" runat="server">Xem rút gọn</span>
                <span id="spFilter" runat="server">Lọc&nbsp;-&nbsp;</span>
                <span id="spRemoveFilter" runat="server">Bỏ điều kiện lọc này</span>
                <span id="spTitleInfo" runat="server">Nhan đề</span>
                <span id="spDKCBInfo" runat="server">Chỉ số Phân loại thập phân Dewey</span>
                <span id="spSoDinhDanhInfo" runat="server">Số định danh</span>
                <span id="spPublisherInfo" runat="server">Thông tin xuất bản</span>
                <span id="spRecordItem" runat="server">Mục</span>
                <span id="spRecordTo" runat="server">đến</span>
                <span id="spRecordOf" runat="server">của</span>
                <span id="spPreviousPage" runat="server">Trang trước</span>
                <span id="spNextPage" runat="server">Trang tiếp</span>
                <span id="spFirstPage" runat="server">Trang đầu</span>
                <span id="spLastPage" runat="server">Trang cuối</span>
                <span id="spMyListTitle" runat="server">Tiêu đề</span>
                <span id="spAddToMyList" runat="server">Thêm vào danh sách của tôi</span>
                <span id="spInMyList" runat="server">Đã trong danh sách của tôi</span>
                <span id="spInfoSearchInResult" runat="server">Bạn vui lòng nhập thông tin tìm kiếm trong tập kết quả.</span>
                <span id="spInfoNotFound" runat="server">Không tìm thấy kết quả tìm kiếm của bạn. Bạn vui lòng thử lại.</span>
                <span id="spFilterFor" runat="server">Kết quả tìm kiếm cho:&nbsp;</span>
                <%--<input id="hidMyListIds" type="hidden" value="" runat="server" />--%>
                <input id="hidTxtSearch" type="hidden" value="" runat="server" />
                <input id="hidSearch" type="hidden" value="" runat="server" />
                <input id="hidSearchEbooks" type="hidden" value="" runat="server" />
                <input id="hidBrowseId" type="hidden" value="" runat="server" />
                <input id="hidDicId" type="hidden" value="" runat="server" />
                <input id="hidDicName" type="hidden" value="" runat="server" />
                <input id="hidFilterStatus" type="hidden" value="" runat="server" />
                <input id="hidCurrentPage" type="hidden" value="1" runat="server" />
                <input id="hidOrderBy" type="hidden" value="" runat="server" />
                <input id="hidSearchInResult" type="hidden" value="" runat="server" />
                <input id="hidMutiLibrary" type="hidden" value="0" runat="server" />
                <input id="hidSearchType" type="hidden" value="0" runat="server" />
                <asp:Button runat="server" ID="raiseFilterInResult"  Text="raiseFilterInResult" CausesValidation="false"/>
                <asp:Button runat="server" ID="raiseFilter"  Text="raiseFilter" CausesValidation="false"/>
                <asp:Button runat="server" ID="raiseShowRecord"  Text="raiseShowRecord" CausesValidation="false"/>
                <asp:Button runat="server" ID="raiseOrderBy"  Text="raiseOrderBy" CausesValidation="false"/>
                <asp:Button runat="server" ID="raiseDeleteFilterInResult"  Text="raiseDeleteFilterInResult" CausesValidation="false" />
          </div>
    </form>
</body>
</html>
