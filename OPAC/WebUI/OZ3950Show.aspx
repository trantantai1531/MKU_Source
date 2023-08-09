<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OZ3950Show.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OZ3950Show" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 transitional//EN" "http://www.w3.org/tr/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <%--<script src="js/ui/jquery.js"></script>
    <script src="js/ui/core.js"></script>
	<script src="js/ui/widget.js"></script>
	<script src="js/ui/mouse.js"></script>
	<script src="js/ui/draggable.js"></script>
	<script src="js/ui/droppable.js"></script>
    <script src="js/ui/jquery.bpopup.min.js"></script>
    <script src="js/ui/jquery.easing.1.3.min.js"></script>
    <script src="js/metro.min.js"></script>
    <script src="js/docs.js"></script>--%>
    <script src="js/Z3950/OZ3950Show.js"></script>
</head>
<body  style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px">
    <form id="form1" runat="server">
   <%-- <header data-load="OTop.aspx"></header>
    <div class="container">
        <div class="grid fluid">
            <div class="row">
                
            </div>
            <div class="row">
                <div class="span12">
                    <div class="pagination">
                        <ul>
                            <asp:Literal runat="server" ID="lrtPagination1"></asp:Literal>
                        </ul>
                    </div>
                </div>
            </div> 
            <div class="row">
                <div class="span12">
                    <asp:Literal runat="server" ID=""></asp:Literal> 
                </div> 
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
    </div>
    <div class="page-footer">
        <div class="page-footer-content">
            <uc1:UFooter ID="UFooter1" runat="server" />
        </div>
    </div> --%>
    <uc2:UHeader ID="UHeader1" runat="server" />
    <div id="divMain">
        <div class="web-size sort-page ClearFix">
            <h1><span class="mif-filter"></span>Kết quả tìm kiếm Z39.50</h1>
            <div>
            <table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td>
						<table width="100" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td width="13" rowspan="2"><img border="0" src="Images/ImgViet/title_01.gif" width="13" height="55"></td>
								<td height="15" colspan="2"><img border="0" src="Images/ImgViet/title_02.gif" width="85" height="15"></td>
							</tr>
							<tr>
								<td width="40"><h3><i class="icon-cloud-2  on-right on-left" style="background: red;color: white;padding: 7px;border-radius: 50%"></i></h3></td>
								<td background="Images/ImgViet/title_bg.gif" align="left"><asp:label id="lblTitleZ3950Result" CssClass="lbTitleHeader" Runat="server">Z3950</asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="2">&nbsp;<asp:label id="lbShowRemote" runat="server" Width="384px">Máy chủ/Cổng dịch vụ: </asp:label><br />
						&nbsp;<asp:label id="lbShowDatabase" runat="server" Width="136px">Cơ sở dữ liệu: </asp:label></td>
				</tr>
				<tr>
					<td colspan="2">
						<P>&nbsp;<asp:label id="lblFound" runat="server" Width="56px">Tìm thấy:</asp:label>&nbsp;
							<asp:label id="lblSumrec" runat="server" Font-Bold="true" ForeColor="Maroon"></asp:label>&nbsp;
							<asp:label id="lblRec" runat="server">biểu ghi</asp:label></P>
						<P><asp:label id="lblStatus" runat="server"></asp:label></P>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<table cellSpacing="0" cellPadding="2" width="100%">
							<tr>
								<td align="center">&nbsp;</td>
								<td align="right"><asp:label id="lblDisplay" runat="server" Visible="False">Hiển thị:</asp:label><asp:dropdownlist id="ddlDisplay" runat="server" Visible="False" AutoPostBack="true">
										<asp:ListItem Value="MARC">MARC</asp:ListItem>
										<asp:ListItem Value="ISBD">ISBD</asp:ListItem>
										<asp:ListItem Value="SIMPLE">Đơn giản</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center" colspan="2"><asp:label id="NotFound" Runat="server" ForeColor="black" Visible="False">Không tìm thấy bản ghi nào thoả mãn điều kiện</asp:label></td>
				</tr>
				<tr>
					<td align="center" colspan="2"></td>
				</tr>
			</table>
            </div>
             <div class="divPage">
                <ul class="ClearFix">
                    <asp:Literal runat="server" ID="lrtPagination1"></asp:Literal>
                </ul>
            </div>
             <ul class="ClearFix">
                <asp:Literal runat="server" ID="ltrContent"></asp:Literal>
            </ul>
                
            <div class="divPage">
                <ul class="ClearFix">
                        <asp:Literal runat="server" ID="lrtPagination2"></asp:Literal>
                </ul>
            </div>
        </div>
    </div>
    <uc1:UFooter ID="UFooter1" runat="server" />
    <a href="#" id="toTop" class="scrollup">Scroll</a>
    <div style="display:none;">
        <asp:dropdownlist id="ddlLabel" Runat="server" Visible="False" Width="0">
		    <asp:ListItem Value="0">tìm thấy </asp:ListItem>
		    <asp:ListItem Value="1"> biểu ghi</asp:ListItem>
		    <asp:ListItem Value="2">Tác giả</asp:ListItem>
		    <asp:ListItem Value="3">Nhan đề</asp:ListItem>
		    <asp:ListItem Value="4">Xuất bản</asp:ListItem>
		    <asp:ListItem Value="5">Thông tin khác</asp:ListItem>
		    <asp:ListItem Value="6">Xin vui lòng chờ đợi trong chốc lát !</asp:ListItem>
		    <asp:ListItem Value="7">trường xem tiếp phải có thông tin !</asp:ListItem>
		    <asp:ListItem Value="8">trường xem tiếp phải là số !</asp:ListItem>
		    <asp:ListItem Value="9">Vượt quá phạm vi cho phép !</asp:ListItem>
		    <asp:ListItem Value="10">Không kết nối được với máy chủ !</asp:ListItem>
	    </asp:dropdownlist>
        <input id="hidTag020" type="hidden" runat="server" /> <input id="hidTag022" type="hidden" runat="server" />
	    <input id="hidTag041" type="hidden" runat="server" /> <input id="hidTag044" type="hidden" runat="server" />
	    <input id="hidTag100" type="hidden" runat="server" /> <input id="hidTag245a" type="hidden" runat="server" />
	    <input id="hidTag245b" type="hidden" runat="server" /> <input id="hidTag245c" type="hidden" runat="server" />
	    <input id="hidTag245n" type="hidden" runat="server" /> <input id="hidTag245p" type="hidden" runat="server" />
	    <input id="hidTag250" type="hidden" runat="server" /> <input id="hidTag260a" type="hidden" runat="server" />
	    <input id="hidTag260b" type="hidden" runat="server" /> <input id="hidTag260c" type="hidden" runat="server" />
	    <input id="hidTag300a" type="hidden" runat="server" /> <input id="hidTag300b" type="hidden" runat="server" />
	    <input id="hidTag300c" type="hidden" runat="server" /> <input id="hidTag300e" type="hidden" runat="server" />
	    <input id="hidContent" type="hidden" runat="server" /> <input id="hidCountrec" type="hidden" runat="server" />
	    <input id="hidAction" type="hidden" value="2" runat="server" /> <input id="hidPosRec" type="hidden" value="1" runat="server" />
	    <asp:label id="lblJS" runat="server"></asp:label>
        <input id="hidCurrentPage" type="hidden" value="1" runat="server" />
        <span id="spRecordItem" runat="server">Mục</span>
        <span id="spRecordTo" runat="server">đến</span>
        <span id="spRecordOf" runat="server">của</span>
        <span id="spPreviousPage" runat="server">Trang trước</span>
        <span id="spNextPage" runat="server">Trang tiếp</span>
        <span id="spServer" runat="server">Máy chủ/Cổng dịch vụ: </span>
        <span id="spDatabase" runat="server">Cơ sở dữ liệu: </span>
        <asp:Button runat="server" ID="raiseShowRecord"  Text="raiseShowRecord" CausesValidation="false"/>
    </div>
   
			
    </form>
</body>
</html>
