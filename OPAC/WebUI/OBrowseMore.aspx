<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OBrowseMore.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OBrowseMore" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <script src="js/OBrowseMore.js"></script>  
     <script type="text/javascript" >
         $(document).ready(function () {
             $(".menu-icon").click(function () {
                 var X = $(this).attr('id');

                 if (X == 1) {
                     $(".submenu").hide();
                     $(this).attr('id', '0');
                 }
                 else {

                     $(".submenu").show();
                     $(this).attr('id', '1');
                 }

             });

             //Mouseup textarea false
             $(".submenu").mouseup(function () {
                 return false
             });
             $(".menu-icon").mouseup(function () {
                 return false
             });

             //Textarea without editing.
             $(document).mouseup(function () {
                 $(".submenu").hide();
                 $(".menu-icon").attr('id', '');
             });

         });
</script>
<script type="text/javascript" >
    $(document).ready(function () {
        $(".user-icon").click(function () {
            var X = $(this).attr('id');

            if (X == 1) {
                $(".user-menu").hide();
                $(this).attr('id', '0');
            }
            else {

                $(".user-menu").show();
                $(this).attr('id', '1');
            }

        });

        //Mouseup textarea false
        $(".user-menu").mouseup(function () {
            return false
        });
        $(".user-icon").mouseup(function () {
            return false
        });

        //Textarea without editing.
        $(document).mouseup(function () {
            $(".user-menu").hide();
            $(".user-icon").attr('id', '');
        });

    });
</script>
<script type="text/javascript" >
    $(document).ready(function () {
        $(".head-menu-icon").click(function () {
            var X = $(this).attr('id');

            if (X == 1) {
                $(".head-submenu").hide();
                $(this).attr('id', '0');
            }
            else {

                $(".head-submenu").show();
                $(this).attr('id', '1');
            }

        });

        //Mouseup textarea false
        $(".head-submenu").mouseup(function () {
            return false
        });
        $(".head-menu-icon").mouseup(function () {
            return false
        });

        //Textarea without editing.
        $(document).mouseup(function () {
            $(".head-submenu").hide();
            $(".head-menu-icon").attr('id', '');
        });

    });
</script>
<script type="text/javascript" >
    $(document).ready(function () {
        $(".config-menu-icon").click(function () {
            var X = $(this).attr('id');

            if (X == 1) {
                $(".config-submenu").hide();
                $(this).attr('id', '0');
            }
            else {

                $(".config-submenu").show();
                $(this).attr('id', '1');
            }

        });

        //Mouseup textarea false
        $(".config-submenu").mouseup(function () {
            return false
        });
        $(".config-menu-icon").mouseup(function () {
            return false
        });

        //Textarea without editing.
        $(document).mouseup(function () {
            $(".config-submenu").hide();
            $(".config-menu-icon").attr('id', '');
        });

    });
</script>

<script type="text/javascript">
    $(document).ready(function () {

        $(window).scroll(function () {
            if ($(this).scrollTop() > 100) {
                $('.scrollup').fadeIn();
            } else {
                $('.scrollup').fadeOut();
            }
        });

        $('.scrollup').click(function () {
            $("html, body").animate({ scrollTop: 0 }, 600);
            return false;
        });
    });
 </script>
</head>
<body  style="margin-top:15px;margin-left:15px;margin-right:15px;margin-bottom:15px;background:white;">
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
    <form id="form1" runat="server">
     <%--<div>
            <div class="grid fluid">
                <div class="row">
                    <div class="span12">
                        <button class="button primary image-left" onclick="returnShowRecord()" type="button"><i class="icon-undo"></i>&nbsp;<span runat="server" id="spReturnShow">Trở về trang kết quả tìm kiếm</span></button>
                    </div>
                </div>
                <div class="row">&nbsp;</div>
                <div class="row">
                    <div class="span12">
                        <asp:Literal runat="server" ID="lrtDictionary"></asp:Literal> 
                    </div>                    
                </div>       
                <div class="row">
                    <div class="span6">
                        <div class="element input-element"  id="divSearchBrowse" runat="server">
                            <div class="input-control text" data-role="input-control">
                                    <input type="text" placeholder="Nhập thông tin duyệt đề mục của bạn ở đây" id="txtSearchBrowse" name="txtSearchBrowse" value="" onkeypress="keySearchBrowse(event);"/>
                                    <button class="btn-search" id="btSearchBrowse" onclick="searchBrowse()" type="button"></button>
			                </div>
		                </div>
                    </div>
                </div>         
                <div class="row">
                    <div style="height:20px;"></div>
                </div> 
                <div class="row">
                    <div class="span10">
                        <div class="pagination">
                            <ul>
                                <asp:Literal runat="server" ID="lrtPagination1"></asp:Literal>
                            </ul>
                        </div>
                    </div>
                    <div class="span2" runat="server" id="divOrderBy">
                            <div class="button-dropdown place-right">
                            <button class="dropdown-toggle info"  type="button"><span runat="server" id="spBrowseMoreOrderBy">Sắp xếp</span></button>
                            <ul class="dropdown-menu place-right" data-role="dropdown" style="display: none;">
                                <asp:Literal runat="server" ID="ltrBrowseMoreOrderBy"></asp:Literal>                                                
                            </ul>
                        </div>
                    </div>    
                </div> 
                <div class="row">
                    <div class="span12">
                        <asp:Literal runat="server" ID="ltrBrowseMoreList"></asp:Literal> 
                    </div>                    
                </div>  
                <div class="row">
                    <div style="height:10px;"></div>
                </div>  
                 <div class="row">
                    <div class="span12">
                        <div class="pagination">
                            <ul>
                                <asp:Literal runat="server" ID="lrtPagination2"></asp:Literal>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
        <div id="divMain">
            <div class="web-size sort-page ClearFix">
                 <div class="span10 margin5">
                     <div class="button-control">
                        <div class="button-form">
                            <input type="button" class="btn-icon" onclick="returnShowRecord()" >
                            <div class="margin5"><span class="mif-undo"></span>&nbsp;<span runat="server" id="spReturnShow">Trở về trang kết quả tìm kiếm</span></div>
                        </div>
                     </div>
                </div>
                <div class="row">
                    <div class="span12">
                        <asp:Literal runat="server" ID="lrtDictionary"></asp:Literal> 
                    </div>                    
                </div> 
             </div>
             <asp:Literal runat="server" ID="Literal1"></asp:Literal> 
            <div class="search-tool"  id="divSearchBrowse"  runat="server">
                <input type="text" class="tb-search" placeholder="Nhập thông tin duyệt đề mục của bạn ở đây" id="txtSearchBrowse" name="txtSearchBrowse" value="" onkeypress="keySearchBrowse(event);">
                <span class="icon-search"></span>
                <input type="button" class="search-btn" id="btSearchBrowse" onclick="searchBrowse()">
            </div>
            
            <div class="divPage">
                <ul class="ClearFix">
                    <asp:Literal runat="server" ID="lrtPagination1"></asp:Literal>
                </ul>  
                <div class="inline-block  place-right" runat="server" id="divOrderBy">
                    <div class="input-control">
                        <div class="input-dropdownlist">
                            <asp:Literal runat="server" ID="ltrBrowseMoreOrderBy"></asp:Literal> 
                        </div>
                    </div>
                </div>   
            </div>
                                
            <div class="sort-result">
                <asp:Literal runat="server" ID="ltrBrowseMoreList"></asp:Literal> 
            </div>
            <div class="divPage">
                <ul class="ClearFix">
                    <asp:Literal runat="server" ID="lrtPagination2"></asp:Literal>
                </ul>
            </div>
        </div>
              
        <div style="display:none">
            <span id="spOrderBy" runat="server">--Sắp xếp bởi--</span>
            <span id="spCollection" runat="server">Bộ sưu tập</span>
            <span id="spCatalogy" runat="server">Danh mục</span>   
            <span id="spMsgNotFound" runat="server">Không tìm thấy thông tin.</span>   
            <span id="spTitle" runat="server">Nhan đề</span>
            <span id="spAuthor" runat="server">Tác giả</span>
            <span id="spPublisher" runat="server">Nhà xuất bản</span>
            <span id="spKeyWord" runat="server">Từ khóa</span>
            <span id="spSeries" runat="server">Series</span>
            <span id="spDDC" runat="server">DDC</span>
            <span id="spLanguage" runat="server">Ngôn ngữ</span>
            <span id="spNLM" runat="server">NLM</span>
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
            <asp:Button runat="server" ID="btSubmitBrowse"  Text="raiseSubmitBrowse" CausesValidation="false"/>
            <asp:Button runat="server" ID="raiseShowRecord"  Text="raiseShowRecord" CausesValidation="false"/>
            <asp:Button runat="server" ID="raiseOrderBy"  Text="raiseOrderBy" CausesValidation="false"/>             
        </div>
    </form>
</body>
</html>
