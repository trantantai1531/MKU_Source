<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OSearchContent.aspx.vb" Inherits="eMicLibOPAC.WebUI.OSearchContent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <script type="text/javascript">
        $(window).ready(function () {
            $('#btSearchContent').click(function (event) {
                event.preventDefault(); 
            });
        });

        var bolSubmit = false;

        function keySearchContent(e) {
            var key = e.keyCode || e.which;
            if (key == 13) {
                checkValid();
            }
        }

        function clickSearchContent(e) {
            checkValid();
            if (bolSubmit) {
                var btSubmitContent = document.getElementById("btSubmitContent");
                if (btSubmitContent) {
                    btSubmitContent.click();
                }
            }
        }

        function checkValid() {
            var txtSearchContent = document.getElementById("txtSearchContent");
            if (txtSearchContent.value.trim() != '') {
                bolSubmit = true;
            }
            else {
                var spWarning = document.getElementById("spWarning");
                if (spWarning) {
                    parent.showNotify('warning', parent.strWarningBegin + spWarning.innerHTML + parent.strWarningEnd);
                }
            }
        }

        function gotoPage(pageno, searchContent) {
            parent.searchGotoPages(pageno, searchContent);
        }

        function showRecord(pg,searchContent) {
            var hidSearchContent = document.getElementById('hidSearchContent');
            hidSearchContent.value = searchContent;
            var hidCurrentPage = document.getElementById('hidCurrentPage');
            hidCurrentPage.value = pg;
            var raiseShowRecord = document.getElementById('raiseShowRecord');
            raiseShowRecord.click();
        }
    </script>
</head>
<body  style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px;background:white;">
    <form  method="post" action="OSearchContent.aspx?ItemID=<%=Request("ItemID")%>">
    <div id="divMain">
        <div class="web-size ClearFix book-detail">
            <div class="search-detail">
                <div class="search-tool">
                    <input type="text" class="tb-search" placeholder="Tìm kiếm nội dung tài liệu này" id="txtSearchContent" name="txtSearchContent" onkeypress="keySearchContent(event);"/>
                    <span class="icon-search"></span>
                    <input type="button" class="search-btn" id="btSearchContent" onclick="clickSearchContent()" />
		        </div>
                <div  id="panelBook" runat="server" visible="false">                    
                    <div class="divPage">
                        <ul class="ClearFix">
                            <asp:Literal runat="server" ID="lrtPagination1"></asp:Literal>
                        </ul>
                    </div>
                    <div class="search-item"  style="text-align:justify">
                        <asp:Literal runat="server" ID="ltrBookList"></asp:Literal>
                    </div>
                    <div class="divPage">
                        <ul class="ClearFix">
                            <asp:Literal runat="server" ID="lrtPagination2"></asp:Literal>
                        </ul>
                    </div>
                </div>
                
                <div id="panelNotFound" runat="server" visible="false">
                     <div class="panel-header">
                        <div style='vertical-align:middle;'>
                            <span class='tertiary-text-secondary'>
                                <asp:Literal runat="server" ID="ltrNotFound"></asp:Literal>
                            </span>                
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="display:none">
        <button class="btn-search" id="btSubmitContent"></button>
    </div>
    </form>
     <form id="form1" runat="server">
        <div style="display:none">
            <input id="hidSearchContent" type="hidden" value="" runat="server" />
            <span id="spNotFound" runat="server">Không tìm thấy: </span>
            <span id="spRecordItem" runat="server">Mục</span>
            <span id="spRecordTo" runat="server">đến</span>
            <span id="spRecordOf" runat="server">của</span>
            <span id="spPreviousPage" runat="server">Trang trước</span>
            <span id="spNextPage" runat="server">Trang tiếp</span>
            <span id="spPage" runat="server">Trang</span>
            <input id="hidCurrentPage" type="hidden" value="1" runat="server" />
            <span id="spWarning" runat="server">Bạn chưa nhập vào điêu kiện tìm kiếm nội dung...</span>
            <asp:Button runat="server" ID="raiseShowRecord"  Text="raiseShowRecord" CausesValidation="false"/>
        </div>
     </form>
</body>
</html>
