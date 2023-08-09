<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ODetail.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.ODetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>    
    <link href="Resources/StyleSheet/ssc/SpryAssets/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />
    <script src="Resources/StyleSheet/ssc/SpryAssets/SpryTabbedPanels.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="Resources/StyleSheet/ssc/styles/media.css" />
    <script type="text/javascript">
  <!--
        function onReservation(strReservation) {
            var hidCopynumber = document.getElementById('hidCopynumber');
            if (hidCopynumber) {
                hidCopynumber.value = strReservation;
            }
            var raiseReservation = document.getElementById('raiseReservation');
            if (raiseReservation) {
                raiseReservation.click();
            }
        }

        function onHolding(strHolding) {
            var hidCopynumber = document.getElementById('hidCopynumber');
            //var hidItemID = document.getElementById('hidItemID');
            if (hidCopynumber) {
                hidCopynumber.value = strHolding;
            }
            //if (hidItemID)
            //{
            //    hidItemID.value = strHolding
            //}
            var raiseHolding = document.getElementById('raiseHolding');
            if (raiseHolding) {
                raiseHolding.click();
            }
        }


    //-->
  </script>
    <style type="text/css">
        html, body {
            height: 100%;
        }
        ul li label, ul li a
        {
            color:#096;
            font-weight:bold;
            cursor:pointer;
        }
        .dissertation-close
        {
            display:none; 
            margin: 0px 15px 0px 15px;
            background: #fff;
            border: 1px solid #000;
            padding: 0px 15px;
        }
        .dissertation-open
        {
            display: inline;
            position: absolute;
            margin: 0px 15px 0px 15px;
            background: #fff;
            border: 1px solid #000;
            padding: 0px 15px;
        }
        iframe {
            min-height: 600px;
            width: 100%;
        }
        [class*="icon-"]
        {
            margin-right:5px;
        }
        @media screen and (max-width: 770px) 
        {
            [class*="col-left-"], [class*="col-right-"]
            {
                width:100%;
            }
        }
    </style>
</head>
<body  style="margin-top:15px;margin-left:15px;margin-right:15px;margin-bottom:15px;background:white;">
    <form id="form1" runat="server">
       <%-- <div id="divMain">  
            <div class="web-size ClearFix book-detail">
                 <div class="detail-info">
                    <div id="TabbedPanels1" class="TabbedPanels">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">Đầy đủ</li>
                            <li class="TabbedPanelsTab" tabindex="0">Đơn giản</li>
                            <li class="TabbedPanelsTab" tabindex="0">ISBD</li>
                            <li class="TabbedPanelsTab" tabindex="0">MARC</li>
                        </ul>
                    </div>
                    <div class="TabbedPanelsContentGroup">
                    </div>
                 </div>
            </div>
        </div>--%>
     <div id="divMain">
        <div class="web-size ClearFix book-detail">
            <div class="detail-info">
                <div id="TabbedPanels1" class="TabbedPanels">
                    <ul class="TabbedPanelsTabGroup">
                        <li class="TabbedPanelsTab" tabindex="0"><span id="spFullDisplay" runat="server">Đầy đủ</span></li>
                        <li class="TabbedPanelsTab" tabindex="0"><span id="spISBDDisplay" runat="server">ISBD</span></li>
                       <%-- <li class="TabbedPanelsTab" tabindex="0"><span id="spSimpleDisplay" runat="server">Đơn giản</span></li>--%>
                        <li class="TabbedPanelsTab" tabindex="0"><span id="spMARCDisplay" runat="server">MARC</span></li>
                        <li class="TabbedPanelsTab" tabindex="0"><span id="spCataloguerDisplay" runat="server">Mục lục</span></li>
                        <%--<li class="TabbedPanelsTab" tabindex="0" style="display:none;"><span id="spRelation" runat="server">Tài liệu liên quan</span></li>--%>
                     </ul>
                    <div class="TabbedPanelsContentGroup">
                        <div class="TabbedPanelsContent">
                            <div class="popup-modul">
                                <asp:Literal runat="server" ID="ltrViewFull"></asp:Literal>
                            </div>
                        </div>
                        <div class="TabbedPanelsContent">
                            <div class="popup-modul">
                                <asp:Literal runat="server" ID="ltrViewISBD"></asp:Literal>
                            </div>
                        </div>
                         <%--<div class="TabbedPanelsContent">
                            <div class="popup-modul">
                                <asp:Literal runat="server" ID="ltrViewSimple"></asp:Literal>
                            </div>
                        </div>--%>
                         <div class="TabbedPanelsContent">
                            <div class="popup-modul">
                                <asp:Literal runat="server" ID="ltrViewMARC"></asp:Literal>
                            </div>
                        </div>
                        <div class="TabbedPanelsContent">
                            <div class="popup-modul">
                                <asp:Literal runat="server" ID="ltrViewCataloger"></asp:Literal>
                            </div>
                        </div>
                         <%--<div class="TabbedPanelsContent" style="display:none;">
                            <div class="popup-modul">
                                <asp:Literal runat="server" ID="ltrRelation"></asp:Literal>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>  
      <%--  <div class="tab-control" data-role="tab-control">
            <ul class="tabs">
                <li id="liFULLRECORD"><a href="#FullDisplay" onclick="viewRecord('FULLRECORD');" id="lnkFULLRECORD"></a></li>
                <li id="liSimple"><a href="#SimpleDisplay" onclick="viewRecord('SIMPLE');" id="lnkSIMPLE"></a></li>
                <li id="liISBD"  class="active"><a href="#ISBDDisplay" onclick="viewRecord('ISBD');" id="lnkISBD"></a></li>
                <li id="liMARC"><a href="#MARCDisplay" onclick="viewRecord('MARC');" id="lnkMARC"></a></li>
                <li id="liRelation"><a href="#divRelation" onclick="viewRecord('RELATION');" id="lnkRelation"></a></li>
            </ul>
            <div class="frames">
                <div  class="frame" id="SimpleDisplay">
                    <div class="panel">
	                    
                    </div>  
                    <div class="panel">
	                    
                    </div>  
                    <div class="panel">
	                    
                    </div>  
                    <div class="panel">
	                    
                    </div>  
                </div>
                <div  class="frame" id="ISBDDisplay">
                    <div class="panel">
	                    <asp:Literal runat="server" ID="ltrISBD"></asp:Literal>
                    </div>  
                    <div class="panel">
	                    <asp:Literal runat="server" ID="ltrBarcodeISBD"></asp:Literal>
                    </div>  
                    <div class="panel">
	                    <asp:Literal runat="server" ID="ltrMagazineISBD"></asp:Literal>
                    </div>  
                    <div class="panel">
	                    <asp:Literal runat="server" ID="ltrRelationWordISBD"></asp:Literal>
                    </div> 
                </div>
                <div  class="frame" id="FullDisplay">
                    <div class="panel">
	                    <asp:Literal runat="server" ID="ltrFull"></asp:Literal>
                    </div> 
                    <div class="panel">
	                    <asp:Literal runat="server" ID="ltrBarcodeFull"></asp:Literal>
                    </div>
                    <div class="panel">
	                    <asp:Literal runat="server" ID="ltrMagazineFull"></asp:Literal>
                    </div>     
                     <div class="panel">
	                    <asp:Literal runat="server" ID="ltrRelationWordFull"></asp:Literal>
                    </div> 
                </div>
                <div  class="frame" id="MARCDisplay">
                    <div class="panel">
	                    <asp:Literal runat="server" ID="lrtMARC"></asp:Literal>
                    </div>  
                    <div class="panel">
	                    <asp:Literal runat="server" ID="ltrBarcodeMARC"></asp:Literal>
                    </div>  
                    <div class="panel">
	                    <asp:Literal runat="server" ID="ltrMagazineMARC"></asp:Literal>
                    </div>  
                     <div class="panel">
	                    <asp:Literal runat="server" ID="ltrRelationWordMARC"></asp:Literal>
                    </div> 
                </div>
                <div  class="frame" id="divRelation">
                    <div class="panel">
	                    <asp:Literal runat="server" ID="ltrRelation"></asp:Literal>
                    </div>  
                </div>
            </div>
        </div>  --%>
         
        <div style="display:none">
            <span id="spRelationNone" runat="server">Không có tài liệu liên quan</span>   
            <span id="spISSN" runat="server">ISSN</span>         
            <span id="spAuthor" runat="server">Tác giả</span>
            <span id="spPublisher" runat="server">Nhà xuất bản</span>
            <span id="spPhysicalInfo" runat="server">Mô tả vật lý</span>
            <span id="spPublisherInfo" runat="server">Thông tin xuất bản</span>
             <span id="spEDATAContent" runat="server">&nbsp;Đọc nội dung</span> 
            <span id="spEDATA" runat="server">Dữ liệu điện tử</span>
            <span id="spItemType" runat="server">Dạng tài liệu</span> 
            <span id="spFree" runat="server">Rỗi</span>
            <span id="spBusy" runat="server">Bận</span>
            <span id="spMap" runat="server">Sơ đồ</span>
            <span id="spBarcodeInfo" runat="server">Thông tin xếp giá</span>
            <span id="spMagazineInfo" runat="server">Thông tin số liệu tổng hợp</span>
            <span id="spAvailable" runat="server">Số bản tài liệu rỗi:</span>
            <span id="spAddToMyList" runat="server">Thêm vào danh sách của tôi</span>
            <span id="spInMyList" runat="server">Đã trong danh sách của tôi</span>
            <span id="spKeyword" runat="server">Từ khóa</span>
            <span id="spSubjectHeading" runat="server">Tiêu đề đề mục</span>
            <span id="spDDC" runat="server">DDC</span>
            <span id="spNLM" runat="server">NLM</span>
            <span id="spSeries" runat="server">Tuyển tập (Series)</span>    
            <span id="spRelatedWord" runat="server">Mục từ truy cập</span>
            <span id="spRegister" runat="server">Đăng ký mượn</span>
            <span id="spReservation" runat="server">Đăng ký đặt chỗ</span>
            <span id="spSumOnHold" runat="server">Số bản được giữ chỗ:</span>
            <asp:label id="lblMSG0" runat="server" Visible="False">Đăng ký thành công</asp:label>
            <asp:label id="lblMSG1" runat="server" Visible="False">Chưa đăng nhập</asp:label>
            <asp:label id="lblMSG2" runat="server" Visible="False">Số thẻ đã bị hết hạn</asp:label>
            <asp:label id="lblMSG3" runat="server" Visible="False">Yêu cầu này đã tồn tại</asp:label>
            <asp:label id="lblMSG4" runat="server" Visible="False">Yêu cầu vượt quá giới hạn được mượn</asp:label>
            <asp:label id="lblMSG5R" runat="server" Visible="False">Bạn đã hết lượt đăng ký đặt chỗ</asp:label>
            <asp:label id="lblMSG6H" runat="server" Visible="False">Đăng ký cá biệt không hợp lệ!</asp:label>
            <input id="hidItemID" type="hidden" name="hidItemID" runat="server" />
            <input id="hidCopynumber" type="hidden" name="hidCopynumber" runat="server" value="" />
            <asp:dropdownlist id="ddlLabel" Height="0" Runat="server" Width="0">
			    <asp:ListItem Value="0">LC Control Number:</asp:ListItem>
			    <asp:ListItem Value="1">Dạng tài liệu:</asp:ListItem>
			    <asp:ListItem Value="2">Thông tin mô tả:</asp:ListItem>
			    <asp:ListItem Value="3">Call Number:</asp:ListItem>
			    <asp:ListItem Value="4">Phụ chú:</asp:ListItem>
			    <asp:ListItem Value="5">Sách:</asp:ListItem>
			    <asp:ListItem Value="6">Xuất bản ấn phẩm nhiều kỳ:</asp:ListItem>
                <asp:ListItem Value="7">Thông tin biên mục:</asp:ListItem>
                <asp:ListItem Value="8">Địa chỉ truy cập:</asp:ListItem>
                <asp:ListItem Value="9">Dữ liệu điện tử:</asp:ListItem>
                <asp:ListItem Value="10">Đọc nội dung:</asp:ListItem>
                <asp:ListItem Value="11">Tư liệu đính kèm</asp:ListItem>
            </asp:dropdownlist>
            <asp:dropdownlist id="ddlLabel_FullRecord" Height="0" Runat="server" Width="0" Visible="False">
				<asp:ListItem Value="0">Loại tài liệu:</asp:ListItem>
				<asp:ListItem Value="1">Chỉ số ISBN:</asp:ListItem>
				<asp:ListItem Value="2">Chỉ số ISSN:</asp:ListItem>
				<asp:ListItem Value="3">Mã ngôn ngữ:</asp:ListItem>
				<asp:ListItem Value="4">Phân loại UDC:</asp:ListItem>
				<asp:ListItem Value="5">Thông tin xếp giá:</asp:ListItem>
				<asp:ListItem Value="6">Phân loại BBK:</asp:ListItem>
				<asp:ListItem Value="7">Tên tác giả:</asp:ListItem>
				<asp:ListItem Value="8">Tác giả tập thể:</asp:ListItem>
				<asp:ListItem Value="9">Tác giả liên quan:</asp:ListItem>
				<asp:ListItem Value="10">Thông tin nhan đề:</asp:ListItem>
				<asp:ListItem Value="11">Thông tin xuất bản:</asp:ListItem>
				<asp:ListItem Value="12">Mô tả vật lý:</asp:ListItem>
				<asp:ListItem Value="13">Thông tin tùng thư:</asp:ListItem>
				<asp:ListItem Value="14">Tóm tắt/chú giải:</asp:ListItem>
				<asp:ListItem Value="15">Ký hiệu kho:</asp:ListItem>
				<asp:ListItem Value="16">Địa chỉ điện tử và truy cập:</asp:ListItem>
				<asp:ListItem Value="17">Từ khóa:</asp:ListItem>
				<asp:ListItem Value="18">Sách:</asp:ListItem>
				<asp:ListItem Value="19">Xuất bản ấn phẩm nhiều kỳ:</asp:ListItem>
                <asp:ListItem Value="20">Tiêu đề đề mục:</asp:ListItem>
                <asp:ListItem Value="21">Phân loại NLM:</asp:ListItem>
                <asp:ListItem Value="22">Thông tin biên mục:</asp:ListItem>
                <asp:ListItem Value="23">Địa chỉ truy cập:</asp:ListItem>
                <asp:ListItem Value="24">Dữ liệu điện tử:</asp:ListItem>
                <asp:ListItem Value="25">Đọc nội dung:</asp:ListItem>
                <asp:ListItem Value="26">Dạng tài liệu:</asp:ListItem>
                <asp:ListItem Value="27">Phụ chú luận án:</asp:ListItem>
                <asp:ListItem Value="28">Giá tiền:</asp:ListItem>
			</asp:dropdownlist>
            <input id="hidView" type="hidden" value="" runat="server" />
            <input id="hidWord" type="hidden" value="" runat="server" />
            <asp:Button runat="server" ID="raiseView"  Text="raiseView" CausesValidation="false"/>
            <asp:Button runat="server" ID="raiseReservation"  Text="raiseReservation"/>
            <asp:Button runat="server" ID="raiseHolding"  Text="raiseHolding"/>
        </div>
    </form>
    <script type="text/javascript">
        var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
    </script>
    <script type="text/javascript">
        function OpenNumberByYear(strYear)
        {
            if ($("#year-" + strYear).hasClass('dissertation-close')) {
                $("li div[id^=year-]").attr('class', 'dissertation-close');
                $("#year-" + strYear).attr('class', 'dissertation-open');
                return;
            }

            if ($("#year-" + strYear).hasClass('dissertation-open')) {
                $("#year-" + strYear).attr('class', 'dissertation-close');
                return;
            }
        }
    </script>
</body>
</html>
