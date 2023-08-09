<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OZ3950.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OZ3950" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <script src="Common/eMicLibCommon.js"></script>
    <script src="js/Z3950/OZ3950.js"></script>
    <script language="javascript">
        function callSubmit() {
            if (CheckForSubmit('Trường tìm kiếm còn rỗng !', 'Cổng dịch vụ phải là số !')) {
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
         <div id="divMain">
    	<div class="web-size sort-page ClearFix">
        	<h1><span class="mif-rocket"></span>Z39.50</h1>
            
            <div class="seach-control">
            	<div class="search-z39 ClearFix">
                	<div class="span2">
                    	<p class="txt-right">Tên máy chủ Z39.50 :</p>
                    </div>
                    <div class="span3">
                    	<div class="input-control">
                        	<div class="input-form">
                            	<input type="text" class="tb-text"  id="txtzServer" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="span5">
                    	<p><asp:HyperLink id="lnkOServerList" runat="server">Danh sách máy chủ Z39.50</asp:HyperLink></p>
                    </div>
                </div>
                
                <div class="search-z39 ClearFix">
                	<div class="span2">
                    	<p class="txt-right">Cổng dịch vụ :</p>
                    </div>
                    <div class="span3">
                    	<div class="input-control">
                        	<div class="input-form">
                            	<input type="text" class="tb-text" id="txtZPort" runat="server"/>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="search-z39 ClearFix">
                	<div class="span2">
                    	<p class="txt-right">Tên cơ sở dữ liệu :</p>
                    </div>
                    <div class="span3">
                    	<div class="input-control">
                        	<div class="input-form">
                            	<input type="text" class="tb-text" id="txtZDatabase" runat="server"/>
                            </div>
                        </div>
                    </div>
                </div>
                
                <h2>Điều kiện tìm kiếm</h2>
                
                <div class="search-row ClearFix">
                	<div class="span2">&nbsp;</div>
                    <div class="span3">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                            	 <asp:DropDownList id="ddlFieldName1" runat="server">
							        <asp:ListItem Value="@attr 1=1016">Mọi trường</asp:ListItem>
							        <asp:ListItem Value="@attr 1=1">T&#225;c giả</asp:ListItem>
							        <asp:ListItem Value="@attr 1=2">T&#225;c giả tập thể</asp:ListItem>
							        <asp:ListItem Value="@attr 1=4" Selected="True">Nhan đề</asp:ListItem>
							        <asp:ListItem Value="@attr 1=5">Nhan đề t&#249;ng thư</asp:ListItem>
							        <asp:ListItem Value="@attr 1=7">ISBN</asp:ListItem>
							        <asp:ListItem Value="@attr 1=8">ISSN</asp:ListItem>
							        <asp:ListItem Value="@attr 1=13">Chỉ số DDC</asp:ListItem>
							        <asp:ListItem Value="@attr 1=14">Chỉ số UDC</asp:ListItem>
							        <asp:ListItem Value="@attr 1=16">Chỉ số LC</asp:ListItem>
							        <asp:ListItem Value="@attr 1=21">Chủ đề</asp:ListItem>
							        <asp:ListItem Value="@attr 1=29">Từ kho&#225;</asp:ListItem>
							        <asp:ListItem Value="@attr 1=31">Năm xuất bản</asp:ListItem>
							        <asp:ListItem Value="@attr 1=30">Nh&#224; xuất bản</asp:ListItem>
						        </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="span5">
                    	<div class="input-control">
                        	<div class="input-form">
                            	<input type="text" class="tb-text" id="txtFieldValue1" runat="server"/>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="search-row ClearFix">
                	<div class="span2">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                            	<asp:DropDownList id="ddlOperator2" runat="server">
							        <asp:ListItem Value="@and">AND</asp:ListItem>
							        <asp:ListItem Value="@or">OR</asp:ListItem>
							        <asp:ListItem Value="@not">NOT</asp:ListItem>
						        </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="span3">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                            	 <asp:DropDownList id="ddlFieldName2" runat="server">
							        <asp:ListItem Value="@attr 1=1016">Mọi trường</asp:ListItem>
							        <asp:ListItem Value="@attr 1=1">T&#225;c giả</asp:ListItem>
							        <asp:ListItem Value="@attr 1=2">T&#225;c giả tập thể</asp:ListItem>
							        <asp:ListItem Value="@attr 1=4">Nhan đề</asp:ListItem>
							        <asp:ListItem Value="@attr 1=5">Nhan đề t&#249;ng thư</asp:ListItem>
							        <asp:ListItem Value="@attr 1=7">ISBN</asp:ListItem>
							        <asp:ListItem Value="@attr 1=8">ISSN</asp:ListItem>
							        <asp:ListItem Value="@attr 1=13">Chỉ số DDC</asp:ListItem>
							        <asp:ListItem Value="@attr 1=14">Chỉ số UDC</asp:ListItem>
							        <asp:ListItem Value="@attr 1=16">Chỉ số LC</asp:ListItem>
							        <asp:ListItem Value="@attr 1=21">Chủ đề</asp:ListItem>
							        <asp:ListItem Value="@attr 1=29">Từ kho&#225;</asp:ListItem>
							        <asp:ListItem Value="@attr 1=31">Năm xuất bản</asp:ListItem>
							        <asp:ListItem Value="@attr 1=30">Nh&#224; xuất bản</asp:ListItem>
						        </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="span5">
                    	<div class="input-control">
                        	<div class="input-form">
                            	<input type="text" class="tb-text" id="txtFieldValue2" runat="server"/>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="search-row ClearFix">
                	<div class="span2">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                            	<asp:DropDownList id="ddlOperator3" runat="server">
							        <asp:ListItem Value="@and">AND</asp:ListItem>
							        <asp:ListItem Value="@or">OR</asp:ListItem>
							        <asp:ListItem Value="@not">NOT</asp:ListItem>
						        </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="span3">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                            	<asp:DropDownList id="ddlFieldName3" runat="server">
							        <asp:ListItem Value="@attr 1=1016">Mọi trường</asp:ListItem>
							        <asp:ListItem Value="@attr 1=1">T&#225;c giả</asp:ListItem>
							        <asp:ListItem Value="@attr 1=2">T&#225;c giả tập thể</asp:ListItem>
							        <asp:ListItem Value="@attr 1=4">Nhan đề</asp:ListItem>
							        <asp:ListItem Value="@attr 1=5">Nhan đề t&#249;ng thư</asp:ListItem>
							        <asp:ListItem Value="@attr 1=7">ISBN</asp:ListItem>
							        <asp:ListItem Value="@attr 1=8">ISSN</asp:ListItem>
							        <asp:ListItem Value="@attr 1=13">Chỉ số DDC</asp:ListItem>
							        <asp:ListItem Value="@attr 1=14">Chỉ số UDC</asp:ListItem>
							        <asp:ListItem Value="@attr 1=16">Chỉ số LC</asp:ListItem>
							        <asp:ListItem Value="@attr 1=21">Chủ đề</asp:ListItem>
							        <asp:ListItem Value="@attr 1=29">Từ kho&#225;</asp:ListItem>
							        <asp:ListItem Value="@attr 1=31">Năm xuất bản</asp:ListItem>
							        <asp:ListItem Value="@attr 1=30">Nh&#224; xuất bản</asp:ListItem>
						        </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="span5">
                    	<div class="input-control">
                        	<div class="input-form">
                                <input type="text" class="tb-text" id="txtFieldValue3" runat="server"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="display:none;">
                     <h2>Dạng hiển thị</h2>
                    <div class="search-row ClearFix">
                	    <div class="radio-control">
                    	    <input id="optMARC" runat="server" type="radio" name="rr" value="optmarc" checked>
                            <label for="optMARC">MARC</label>
                            <input id="optISBD" runat="server" type="radio" name="rr" value="optisbd">
                            <label for="optISBD">ISBD</label>
                            <input id="optSimple" runat="server" type="radio" name="rr" value="optsimple">
                            <label for="optSimple">Đơn giản</label>
                        </div>
                    </div>
                </div>
               
                
                <h2>Giới hạn kết quả tìm kiếm</h2>
                <div class="search-row ClearFix">
                	<div class="span2">
                    	<p class="txt-right">Giới hạn kết quả tối đa :</p>
                    </div>
                    <div class="span3">
                    	<div class="input-control">
                        	<div class="input-dropdownlist">
                            	<asp:DropDownList id="ddlLimit" runat="server">
							        <asp:ListItem Value="50">50</asp:ListItem>
							        <asp:ListItem Value="100">100</asp:ListItem>
							        <asp:ListItem Value="300">300</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
						        </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="search-row ClearFix">
                	<div class="span2">&nbsp;</div>
                    <div class="span3">
                    	<div class="button-control">
                            <div class="button-form">
                                <input type="button" class="btn-icon" onclick="callSubmit();">
                                <div class="btn-value"><span class="mif-search"></span>Tìm kiếm</div>
                            </div>
                            
                            <div class="button-form">
                                <input type="button" class="btn-icon" onclick="ResetAll();">
                                <div class="btn-value"><span class="mif-undo"></span>Làm lại</div>
                            </div>
                        </div>
                    </div>
                </div>               
               
            </div>
        </div> 
         </div>
        <uc1:UFooter ID="UFooter1" runat="server" />
        <a href="#" id="toTop" class="scrollup">Scroll</a>
        <div style="display:none;"> 
             <asp:Button id="btnSearch" runat="server" Text="Tìm kiếm (f)" accessKey="f" CssClass="lbButton"></asp:Button>
            <asp:Button id="btnReset" runat="server" Text="Làm lại (r)" accessKey="r" CssClass="lbButton"></asp:Button>
            <asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Trường tìm kiếm còn rỗng !</asp:ListItem>
				<asp:ListItem Value="1">Cổng dịch vụ phải là số !</asp:ListItem>
			</asp:DropDownList>
			<input type="hidden" id="search" value="1" runat="server" />            
        </div>
    </form>
</body>
</html>
