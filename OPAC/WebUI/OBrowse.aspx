<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OBrowse.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OBrowse" %>

<%@ Register Src="UFooter.ascx" TagName="UFooter" TagPrefix="uc1" %>
<%@ Register Src="UHeader.ascx" TagName="UHeader" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <script src="js/OBrowse.js" type="text/javascript"></script>
    <script language="JavaScript" type="text/javascript" src="Resources/StyleSheet/ssc/java/metro.js"></script>
    <style type="text/css">
        .treeview .leaf .icon {
            display: none;
        }
        .sort-page h1
        {
            padding:20px 0px 5px 0px;
        }
        h1 ul.sort-text li, h1 ul.sort-text li a
        {
            font-size: 100%;
        }
        .title-browse, .dictionary-browse
        {
            float:left;
        }
        .dictionary-browse
        {
            padding:22px 0px 0px 20px;
        }
        .row
        {
            clear:left;
        }
        .sort-result {
            margin: 0px 0px 20px 0px;
        }
        .search-tool {
            margin-bottom: 5px;
        }
    </style>
</head>
<body class="metro" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px" id="top">
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
    <form id="form1" runat="server">
        <uc2:UHeader ID="UHeader1" runat="server" />
        <div id="divMain">
            <div class="web-size sort-page ClearFix">
                <%--<h1><span class="mif-brightness-auto"></span>DUYỆT ĐỀ MỤC</h1>--%>
                <div class="row">
                    <%
                        If Not (IsNothing(Request("DicID"))) AndAlso Not (Request("DicID") = "11" Or Request("DicID") = "10") Then
                    %>
                        <div class="title-browse"><h1><% Response.Write(strTitle)%> </h1></div>
                        <div class="dictionary-browse">
                            <asp:Literal runat="server" ID="lrtDictionary"></asp:Literal>
                        </div>
                    <%
                    Else
                    %>
                        <div class="title-browse"><h1><% Response.Write(strTitle)%></h1></div>
                    <%
                    End If
                    %>
                    <h2 style="display:none;">Bạn có thể lựa chọn duyệt xem theo một trong số các đề mục sau :</h2>
                    <div class="sort-list ClearFix" style="display:none;">
                        <div class="sort-item"><a href="javascript:OpenOBrowse(14);"><span class="mif-cabinet"></span>Bộ sưu tập</a></div>
                        <div class="sort-item"><a href="javascript:OpenOBrowse(12);"><span class="mif-list"></span>Danh mục</a></div>
                        <div class="sort-item"><a href="javascript:OpenOBrowse(13);"><span class="mif-spell-check"></span>Nhan đề</a></div>
                        <div class="sort-item"><a href="javascript:OpenOBrowse(1);"><span class="mif-users"></span>Tác giả</a></div>
                        <div class="sort-item"><a href="javascript:OpenOBrowse(9);"><span class="mif-calendar"></span>Năm xuất bản</a></div>
                        <div class="sort-item"><a href="javascript:OpenOBrowse(2);"><span class="mif-bookmark"></span>Nhà xuất bản</a></div>
                        <%--<div class="sort-item"><a href="javascript:OpenOBrowse(5);"><span class="mif-tag"></span>Tiêu đề đề mục</a></div>--%>
                        <div class="sort-item"><a href="javascript:OpenOBrowse(3);"><span class="mif-target"></span>Từ khóa</a></div>
                        <div class="sort-item"><a href="javascript:OpenOBrowse(10);"><span class="mif-shareable"></span>Dạng tài liệu</a></div>
                        <%--<div class="sort-item"><a href="javascript:OpenOBrowse(11);"><span class="mif-cogs"></span>Tài liệu số (Toàn văn)</a></div>--%>
                    </div>
                </div>
                <div class="row">
                    <%
                        If Not (IsNothing(Request("DicID"))) AndAlso Not (Request("DicID") = "11" Or Request("DicID") = "10") Then
                        %>
                            <div class="search-tool" id="divSearchBrowse" runat="server">
                                <input type="text" class="tb-search" placeholder="<%=strTextHolder %>" id="txtSearchBrowse" name="txtSearchBrowse" value="" onkeypress="keySearchBrowse(event);"/>
                                <span class="icon-search"></span>
                                <input type="button" class="search-btn" id="btSearchBrowse" onclick="searchBrowse()"/>
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
                        <%
                        End If
                    %>
                </div>
                
                <div class="sort-result">
                    <asp:Literal runat="server" ID="ltrList"></asp:Literal>
                </div>
                <div class="divPage">
                    <ul class="ClearFix">
                        <asp:Literal runat="server" ID="lrtPagination2"></asp:Literal>
                    </ul>
                </div>
            </div>
        </div>
        <uc1:UFooter ID="UFooter1" runat="server" />
        <a href="#" id="toTop" class="scrollup">Scroll</a>
        <div style="display: none">
            <span id="spOrderBy" runat="server">--Sắp xếp bởi--</span>
            <span id="spCollection" runat="server">Bộ sưu tập</span>
            <span id="spCatalogy" runat="server">Danh mục</span>
            <span id="spMsgNotFound" runat="server">Không tìm thấy thông tin.</span>
            <span id="spTitle" runat="server">Nhan đề</span>
            <span id="spAuthor" runat="server">Tác giả</span>
            <span id="spPublisher" runat="server">Nhà xuất bản</span>
            <span id="spKeyWord" runat="server">Từ khóa</span>
            <span id="spSeries" runat="server">Series</span>
            <span id="spSubjectheading" runat="server">Tiêu đề đề mục</span>
            <span id="spPublisherYear" runat="server">Năm xuất bản</span>
            <span id="spDocType" runat="server">Dạng tài liệu</span>
            <span id="spElectronicData" runat="server">Tài liệu số (Toàn văn)</span>
            <span id="spRecordItem" runat="server">Mục</span>
            <span id="spRecordTo" runat="server">đến</span>
            <span id="spRecordOf" runat="server">của</span>
            <span id="spPreviousPage" runat="server">Trang trước</span>
            <span id="spNextPage" runat="server">Trang tiếp</span>
             <span id="spFirstPage" runat="server">Trang đầu</span>
            <span id="spLastPage" runat="server">Trang cuối</span>
            <span id="spInputEmptyBrowse" runat="server">Bạn vui lòng nhập thông tin duyệt đề mục.</span>
            <span id="spOrderAZ" runat="server">A-Z (Tăng dần)</span>
            <span id="spOrderZA" runat="server">Z-A (Giảm dần)</span>
            <span id="spOrderAZRQ" runat="server">Số lượng tham chiếu (Tăng dần)</span>
            <span id="spOrderZARQ" runat="server">Số lượng tham chiếu (Giảm dần)</span>
            <input id="hidSearchBrowse" type="hidden" value="" runat="server" />
            <input id="hidOrderBy" type="hidden" value="" runat="server" />
            <input id="hidCurrentPage" type="hidden" value="1" runat="server" />
            <span id="spDKCBInfo" runat="server">Chỉ số Phân loại thập phân Dewey</span>
            <span id="spSoDinhDanhInfo" runat="server">Số định danh</span>
            <span id="spPublisherInfo" runat="server">Thông tin xuất bản</span>
            <span id="spMXG" runat="server">Ký hiệu</span>  
            <span id="spItemType" runat="server">Dạng tài liệu</span> 
            <span id="spEDATA" runat="server">Dữ liệu điện tử</span> 
            <span id="spEDATAContent" runat="server">&nbsp;Đọc nội dung</span> 
            <span id="spPageLink" runat="server">Trang</span>  
            <span id="spSaveList" runat="server">Lưu danh sách</span>
            <span id="spCancelList" runat="server">Hủy danh sách</span>
            <input id="hidTypeSearch" type="hidden" value="1" runat="server" />
            <asp:Button runat="server" ID="btSubmitBrowse" Text="raiseSubmitBrowse" CausesValidation="false" />
            <asp:Button runat="server" ID="raiseShowRecord" Text="raiseShowRecord" CausesValidation="false" />
            <asp:Button runat="server" ID="raiseOrderBy" Text="raiseOrderBy" CausesValidation="false" />
        </div>
    </form>
</body>
</html>
