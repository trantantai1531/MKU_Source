<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OMyList.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OMyList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Trường Đại Học Cửu Long</title>
    <link href="Resources/StyleSheet/ssc/styles/FullFooter.css" type="text/css" rel="StyleSheet"></link></head>
<body  style="margin-top:15px;margin-left:15px;margin-right:15px;margin-bottom:15px;background:white;">
    <form id="form1" runat="server">
        <div id="divMain">
            <div class="web-size ClearFix book-detail">
                <div class="divPage">
                    <ul class="ClearFix">
                        <asp:Literal runat="server" ID="lrtPagination"></asp:Literal>
                    </ul>
                </div>
                <div class="detail-head ClearFix">
                    <div class="detail-intro">
                        <asp:Literal runat="server" ID="ltrBookList"></asp:Literal>
                    </div>
                </div>
                <footer class="site-footer editor-footer">
                    <div class="footer-left">
                        &nbsp;<a onclick="parent.export2File()" class="button mini-button embed-builder-button" style="cursor:pointer;">
                            <span id="spExport2File" runat="server"  class="icon-file">&nbsp;Xuất ra file</span>
                        </a>&nbsp;
                        <a onclick="parent.send2Email()" class="button mini-button embed-builder-button" style="cursor:pointer;">
                            <span id="spSend2Email" runat="server" class="icon-mail-2">&nbsp;Gửi email</span>
                        </a>
                    </div>
                    <div class="footer-right">
                        <a onclick="parent.printOptions()" class="button mini-button embed-builder-button" style="cursor:pointer;">
                            <span id="spPrint2List" runat="server" class="icon-printer">&nbsp;In danh sách</span>
                        </a>&nbsp;
                        <a onclick="parent.removeALlMyList()" class="button mini-button embed-builder-button" style="cursor:pointer;">
                            <span id="spDelete2List" runat="server" class="icon-remove">&nbsp;Xóa danh sách</span>
                        </a>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                </footer>
            </div>
        </div>

        <div style="display:none">
             <span id="spDetail" runat="server">Xem chi tiết</span> 
            <span id="spItemType" runat="server">Dạng tài liệu</span> 
            <span id="spEDATAContent" runat="server">&nbsp;Đọc nội dung</span> 
            <span id="spEDATA" runat="server">Dữ liệu điện tử</span> 
            <span id="spURL" runat="server">Địa chỉ truy cập</span> 
            <span id="spISSN" runat="server">ISSN</span>         
            <span id="spAuthor" runat="server">Tác giả</span>
            <span id="spPhysicalInfo" runat="server">Mô tả vật lý</span>
            <span id="spPublisherInfo" runat="server">Thông tin xuất bản</span>
            <span id="spRecordItem" runat="server">Mục</span>
            <span id="spRecordTo" runat="server">đến</span>
            <span id="spRecordOf" runat="server">của</span>
            <span id="spPreviousPage" runat="server">Trang trước</span>
            <span id="spNextPage" runat="server">Trang tiếp</span>
            <span id="spNotFoundItem" runat="server">Không có tài liệu nào được chọn</span>
            <span id="spRemoveMyList" runat="server">Xóa mục này khỏi danh sách</span>
            <input id="hidCurrentPage" type="hidden" value="1" runat="server" />
            <input id="hidItem" type="hidden" value="0" runat="server" />
            <asp:Button runat="server" ID="raiseShowRecord"  Text="raiseShowRecord" CausesValidation="false"/>
            <asp:Button runat="server" ID="raiseRemoveItem"  Text="raiseRemoveItem" CausesValidation="false"/>
        </div>
    </form>
</body>
</html>
