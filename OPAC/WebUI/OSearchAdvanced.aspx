<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OSearchAdvanced.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OSearchAdvanced" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <script src="js/OSearchAdvanced.js"></script>
    <%--<script src="js/ui/jquery.js"></script>
    <script src="js/ui/core.js"></script>
	<script src="js/ui/widget.js"></script>
	<script src="js/ui/mouse.js"></script>
	<script src="js/ui/draggable.js"></script>
	<script src="js/ui/droppable.js"></script>
    <script src="js/ui/jquery.bpopup.min.js"></script>
    <script src="js/metro.min.js"></script>
    <script src="js/docs.js"></script>
    
    <style type="text/css">
    .scroll_checkboxes
    {
        height: 120px;
        width: 350px;
        padding: 5px;
        overflow:auto;
        border: 1px solid #ccc;
    }    
</style>--%>
<script language="javascript">
    var boldivLimit = false;
    function showMe() {
        if (boldivLimit) {
            $("#divLimit").hide();
            boldivLimit = false;
            $("#lblLimit").text(document.getElementById("spAddLimit").innerHTML);
            $('#iconLimit').removeClass("icon-minus").addClass('icon-plus');
        }
        else {
            $("#divLimit").show();
            boldivLimit = true;
            $("#lblLimit").text(document.getElementById("spRemoveLimit").innerHTML);
            $('#iconLimit').removeClass("icon-plus").addClass('icon-minus');
        }
    }

    function TurnOnOffCheckboxAll(id, checkListId) {
        var frm = document.forms[0];
        for (i = 0; i < frm.elements.length; i++) {
            if (frm.elements[i].type == "checkbox" && frm.elements[i].id.indexOf(checkListId) >= 0) {
                frm.elements[i].checked = document.getElementById(id).checked;
                if (checkListId == 'chkLibrary') {
                    setIdFromCheckBoxForLibrary(frm.elements[i].id);
                }
                else if (checkListId == 'chkMaterialType') {
                    setIdFromCheckBoxForMaterialType(frm.elements[i].id); 
                }
            }
        }
    }
    function setIdFromCheckBoxForLibrary(id) {
        var hdLibraryIds = document.getElementById("hdLibraryIds");
        if (hdLibraryIds) {
            var chkId = document.getElementById(id).checked;
            var chkValue = document.getElementById(id).value;
            if (chkId) {
                if (hdLibraryIds.value.toString().indexOf(chkValue.toString() + ',') == -1) {
                    hdLibraryIds.value = hdLibraryIds.value + chkValue.toString() + ',';
                }
            }
            else {
                var strListIds = hdLibraryIds.value;
                var strListIdsNew = strListIds.replace(chkValue.toString() + ',', '');
                hdLibraryIds.value = strListIdsNew;
            }
        }
    }
    function setIdFromCheckBoxForMaterialType(id) {
        var hdMaterialType = document.getElementById("hdMaterialType");
        if (hdMaterialType) {
            var chkId = document.getElementById(id).checked;
            var chkValue = document.getElementById(id).value;
            if (chkId) {
                if (hdMaterialType.value.toString().indexOf(chkValue.toString() + ',') == -1) {
                    hdMaterialType.value = hdMaterialType.value + chkValue.toString() + ',';
                }
            }
            else {
                var strListIds = hdMaterialType.value;
                var strListIdsNew = strListIds.replace(chkValue.toString() + ',', '');
                hdMaterialType.value = strListIdsNew;
            }
        }
    }

    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode;
        if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        } else {
            // If the number field already has . then don't allow to enter . again.
            if (evt.target.value.search(/\./) > -1 && charCode == 46) {
                return false;
            }
            return true;
        }
    }

    var bolSubmit = false;
    function callSubmit() {
        if (ValidData()) {
            var btnSearch = document.getElementById("btnSearch");
            if (btnSearch) {
                btnSearch.click();
            }
        }
    }
    
</script>
</head>
<body style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px">
    <form id="form1" runat="server">
    <uc2:UHeader ID="UHeader1" runat="server" />
        <div id="divMain" style="min-height:400px">
    	<div class="web-size sort-page ClearFix">
        	<h1><span class="mif-filter"></span>Tìm kiếm nâng cao</h1>
            
            <div class="seach-control">
           		<div class="search-row clearfix">
                	<div class="span1">&nbsp;</div>
                    <div class="span4">
                    	<div class="input-control">
                        	<div class="input-form">
                            	<input type="text" class="tb-text" runat="server" id="txtFieldValue1" />
                            </div>
                        </div>
                    </div>
                    <div class="span2">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                                <asp:dropdownlist id="ddlPrefix1" runat="server" Width="100%">
						            <asp:ListItem Value="0">Chứa</asp:ListItem>
						            <asp:ListItem Value="1">Chính xác</asp:ListItem>
						            <asp:ListItem Value="2">Bắt đầu bằng</asp:ListItem>
						            <asp:ListItem Value="3">Kết thúc bằng</asp:ListItem>
					            </asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                    <div class="span1"><p>Trong</p></div>
                    <div class="span2">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                                <asp:dropdownlist id="ddlFieldName1" runat="server" Width="100%"></asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="search-row clearfix">
                	<div class="span1">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                                <asp:dropdownlist id="ddlOperator2" runat="server">
						            <asp:ListItem Value="AND">AND</asp:ListItem>
						            <asp:ListItem Value="OR">OR</asp:ListItem>
						            <asp:ListItem Value="NOT">NOT</asp:ListItem>
					            </asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                    	<div class="input-control">
                        	<div class="input-form">
                            	<input type="text" class="tb-text" runat="server" id="txtFieldValue2"/>
                            </div>
                        </div>
                    </div>
                    <div class="span2">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                                <asp:dropdownlist id="ddlPrefix2" runat="server" Width="100%">
						            <asp:ListItem Value="0">Chứa</asp:ListItem>
						            <asp:ListItem Value="1">Chính xác</asp:ListItem>
						            <asp:ListItem Value="2">Bắt đầu bằng</asp:ListItem>
						            <asp:ListItem Value="3">Kết thúc bằng</asp:ListItem>
					            </asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                    <div class="span1"><p>Trong</p></div>
                    <div class="span2">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                                <asp:dropdownlist id="ddlFieldName2" runat="server" Width="100%"></asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="search-row clearfix">
                	<div class="span1">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                                <asp:dropdownlist id="ddlOperator3" runat="server">
						            <asp:ListItem Value="AND">AND</asp:ListItem>
						            <asp:ListItem Value="OR">OR</asp:ListItem>
						            <asp:ListItem Value="NOT">NOT</asp:ListItem>
					            </asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                    	<div class="input-control">
                        	<div class="input-form">
                            	<input type="text" class="tb-text" runat="server" id="txtFieldValue3"/>
                            </div>
                        </div>
                    </div>
                    <div class="span2">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                                <asp:dropdownlist id="ddlPrefix3" runat="server" Width="100%">
						            <asp:ListItem Value="0">Chứa</asp:ListItem>
						            <asp:ListItem Value="1">Chính xác</asp:ListItem>
						            <asp:ListItem Value="2">Bắt đầu bằng</asp:ListItem>
						            <asp:ListItem Value="3">Kết thúc bằng</asp:ListItem>
					            </asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                    <div class="span1"><p>Trong</p></div>
                    <div class="span2">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                                <asp:dropdownlist id="ddlFieldName3" runat="server" Width="100%"></asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                </div>
                
                <a class="list" onclick="showMe();"  style='cursor:pointer;'><h2><span runat="server" ID="lblLimit">Thêm giới hạn</span></h2></a>
                
                <div class="three-column ClearFix search-other" id="divLimit" style="display:none;">
                	<div class="three-column-form search-other-item">
                    	<div class="row-detail">
                            <div class="radio-control">
                                <input type="radio" id="chkPublisherYear1" runat="server" name="rr">
                                <label for="chkPublisherYear1">Năm</label>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="input-control">
                                <div class="input-dropdownlist">
                                     <asp:dropdownlist id="ddlPublisherYear" Runat="server">
						                <asp:ListItem Value="0" Selected="True">Tất cả các năm</asp:ListItem>
						                <asp:ListItem Value="1">Năm vừa rồi</asp:ListItem>
						                <asp:ListItem Value="5">5 năm vừa qua</asp:ListItem>
						                <asp:ListItem Value="10">10 năm vừa qua</asp:ListItem>
					                </asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="radio-control">
                                <input type="radio" id="chkPublisherYear2"  runat="server" name="rr">
                                <label for="chkPublisherYear2">Thời gian</label>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="input-control">
                                <p>Từ năm :</p>
                                <div class="input-form">
                                    <input type="text" class="tb-text" id="txtPublisherYearFrom" runat="server" onkeypress="return isNumberKey(event)" MaxLength="4">
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="input-control">
                                <p>Đến năm :</p>
                                <div class="input-form">
                                    <input type="text" class="tb-text" id="txtPublisherYearTo" runat="server" onkeypress="return isNumberKey(event)"  MaxLength="4">
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="input-control">
                            	<p>Sắp xếp theo :</p>
                                <div class="input-dropdownlist">
                                    <asp:dropdownlist id="ddlSort" Runat="server">
					                    <asp:ListItem Value="">---Chọn trường sắp xếp---</asp:ListItem>
					                    <asp:ListItem Value="TITLE">Nhan đề chính</asp:ListItem>
					                    <asp:ListItem Value="AUTHOR">Tác giả chính</asp:ListItem>
					                    <asp:ListItem Value="YEAR">Năm xuất bản</asp:ListItem>
					                    <asp:ListItem Value="PUBLISH">Nhà xuất bản</asp:ListItem>
				                    </asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    <div class="three-column-form search-other-item">
                    	<div class="pad5">
                            <div class="row-detail">
                                <div class="checkbox-control">
                                    <input id="c1" type="checkbox" onclick="TurnOnOffCheckboxAll(this.id,'chkLibrary')"  id="chkLiraryAll">
                                    <label for="c1">Thư viện</label>
                                </div>
                            </div>
                            <div class="checkbox-box">
                                <asp:Literal runat="server" ID="ltrLibrary"></asp:Literal>
                            </div>
                        </div>
                    </div>
                    
                    <div class="three-column-form search-other-item">
                    	<div class="pad5">
                            <div class="row-detail">
                                <div class="checkbox-control">
                                    <input id="c21" type="checkbox" onclick="TurnOnOffCheckboxAll(this.id,'chkMaterialType')"  id="chkSellectAllMaterialType">
                                    <label for="c21" id="spMaterialType">Loại tài liệu</label>
                                </div>
                            </div>
                            <div class="checkbox-box">
                                <asp:Literal runat="server" ID="ltrMaterialType"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="search-row clearfix">
                	<div class="button-control" style="text-align:center">
                        <div class="button-form">
                            <input type="button" class="btn-icon" id="btnSearch1" onclick="callSubmit();" >
                            <div class="btn-value"><span class="mif-search"></span>Tìm kiếm</div>
                        </div>
                        
                        <div class="button-form">
                            <input type="button" class="btn-icon" id="btnReset1" onclick="ResetAll();">
                            <div class="btn-value"><span class="mif-undo"></span>Làm lại</div>
                        </div>
                    </div>
                  </div>
            </div>
        </div> 
    </div>
    <uc1:UFooter ID="UFooter1" runat="server" />
    <a href="#" id="toTop" class="scrollup">Scroll</a>
    <div style="display:none">
        <span id="spAddLimit" runat="server">Thêm giới hạn</span>   
        <span id="spRemoveLimit" runat="server">Hủy bỏ giới hạn </span>   
        <asp:Label id="lblMXG" runat="server" Height="16px" Visible="False">Ký hiệu xếp giá</asp:Label>
        <asp:Label id="lblISBN" runat="server" Height="16px" Visible="False">ISBN</asp:Label>
        <asp:Label id="lblISSN" runat="server" Height="16px" Visible="False">ISSN</asp:Label>
		<asp:Label id="lblMSG" runat="server" Height="16px" Visible="False">Chưa nhập thông tin cần tìm !</asp:Label>
		<asp:Label id="lbAllField" runat="server" Height="16px" Visible="False">Mọi trường</asp:Label>
        <input id="ValDocType" type="hidden" size="2" value="0" name="ValDocType" runat="server" />
		<asp:Label id="lbTitleInDDL" runat="server" Height="16px" Visible="False">Nhan đề</asp:Label>
		<asp:Label id="lblItemType" Runat="server" Visible="False">Toàn bộ tài liệu</asp:Label>
        <asp:Label id="lblNamXuatBan" Runat="server" Visible="False">Năm xuất bản</asp:Label>
        <asp:Label id="lblDangTaiLieu" Runat="server" Visible="False">Dạng tài liệu</asp:Label>
        <input id="txtMsg" type="hidden" value="Bạn vui lòng nhập điều kiện tìm kiếm nâng cao." name="txtMsg" runat="server"/>
		<asp:Label ID="lblMsgNotFound" Runat="server" Visible="False">Không tìm thấy biểu ghi nào.</asp:Label>
        <input type="hidden" value="" runat="server" id="hdLibraryIds" />
        <input type="hidden" value="" runat="server" id="hdMaterialType" />
        <asp:button id="btnSearch" Runat="server" Text="Tìm kiếm (f)" />
	    <asp:button id="btnReset" Runat="server" Text="Làm lại (r)" />
    </div>
    </form>
</body>
</html>
