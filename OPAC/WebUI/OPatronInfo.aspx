<%@ Page Language="vb"  AutoEventWireup="false" CodeBehind="OPatronInfo.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OPatronInfo" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <link href="Resources/StyleSheet/ssc/SpryAssets/SpryCollapsiblePanel.css" rel="stylesheet" type="text/css" />
    <script src="Resources/StyleSheet/ssc/SpryAssets/SpryTabbedPanels.js" type="text/javascript"></script>
    <script src="Resources/StyleSheet/ssc/SpryAssets/SpryCollapsiblePanel.js" type="text/javascript"></script>
    <script src="JS/OPatronInfo.js" type="text/javascript"></script>
</head>
<body class="metro"  id="top"  style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px">
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
    <form id="form1" runat="server">
        <uc2:UHeader ID="UHeader1" runat="server" />
        <div id="divMain">
            <div class="web-size news-page ClearFix">
                <div class="container">
                    <table id="tblPatron" width="100%" border="0">
				        <tr>
					        <td valign="top" align="center" width="25%" style="padding-top:10px;">
						        <img src="/" alt="" id="imgPatron" border="0" runat="server" style="width:90px;height:120px;"/>
					        </td>
					        <td align="center" width="75%">
						        <table id="tblPatronInfor" width="100%" border="0">
							        <tr>
								        <td width="100%"><b><asp:label id="lblPatronName" Runat="server"></asp:label></b></td>
							        </tr>
							        <tr>
								        <td>
									        <asp:label id="lblCardNoText" Runat="server">Số thẻ: </asp:label><asp:label id="lblCardNoValue" Runat="server"></asp:label>
								        </td>
							        </tr>
							        <tr>
								        <td>
									        <asp:label id="lblValidDateText" Runat="server">Cấp ngày: </asp:label><asp:label id="lblValidDateValue" Runat="server"></asp:label>
								        </td>
							        </tr>
							        <tr>
								        <td>
									        <asp:label id="lblExpriedDateText" Runat="server">Hết hạn ngày: </asp:label><asp:label id="lblExpriedDateValue" Runat="server"></asp:label>    
                                        </td>
							        </tr>
							        <tr>
								        <td>
									        <asp:label id="lblPatronGroupText" Runat="server">Nhóm bạn đọc: </asp:label><asp:label id="lblPatronGroupValue" Runat="server"></asp:label>
								        </td>
							        </tr>
							        <tr>
								        <td valign="bottom">
                                            <div class="button-control">
                                                <div class="button-form">
                                                    <asp:button id="btnUpdateInfor" Runat="server" class="btn-icon" Text=""></asp:button><div class="btn-value"><span class="mif-user"></span>Thay đổi thông tin</div>
                                                </div>
                                            </div>
								        </td>
							        </tr>
						        </table>
					        </td>
				        </tr>
				        <tr>
					        <td valign="top" width="100%" colspan="4">
                                <h3 class="head-title"><asp:label id="lblReservation" Runat="server" Width="100%" >Ấn phẩm đặt chỗ</asp:label></h3>
					        </td>
				        </tr>
				        <tr>
					        <td valign="top" width="100%" colspan="4">
						        <asp:datagrid id="dgrReservation" Runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
							        <Columns>
								        <asp:TemplateColumn>
									        <HeaderStyle Width="5%"></HeaderStyle>
									        <ItemTemplate>
                                                <div class="checkbox-control">
                                                    <asp:CheckBox ID="ckbItemID" Runat="server" Text=" "></asp:CheckBox>
                                                    <asp:HiddenField ID="txtItemID" Runat ="server" Value='<%# Eval("ID") %>' />
                                                </div>										    
									        </ItemTemplate>
								        </asp:TemplateColumn>
								        <asp:BoundColumn DataField="STT" HeaderText="STT">
									        <HeaderStyle Width="5%"></HeaderStyle>
								        </asp:BoundColumn>
								        <asp:BoundColumn DataField="Title" HeaderText="Nhan đề">
									        <HeaderStyle Width="25%"></HeaderStyle>
								        </asp:BoundColumn>
								        <asp:BoundColumn DataField="CopyNumber" HeaderText="Số ĐKCB">
									        <HeaderStyle Width="10%"></HeaderStyle>
								        </asp:BoundColumn>
								        <asp:BoundColumn DataField="DateCirculation" HeaderText="Ngày đặt chổ">
									        <HeaderStyle Width="15%"></HeaderStyle>
								        </asp:BoundColumn>
								        <asp:BoundColumn DataField="DateExpired" HeaderText="Hết hiệu lực">
									        <HeaderStyle Width="15%"></HeaderStyle>
								        </asp:BoundColumn>
								        <asp:BoundColumn DataField="NOR" HeaderText="Vị trí">
									        <HeaderStyle Width="5%"></HeaderStyle>
								        </asp:BoundColumn>
								        <asp:BoundColumn DataField="Note" HeaderText="Ghi chú">
									        <HeaderStyle Width="20%"></HeaderStyle>
								        </asp:BoundColumn>
							        </Columns>
						            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <ItemStyle BackColor="White" ForeColor="#330099" />
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
						        </asp:datagrid>                           
					        </td>
				        </tr>
                        <tr>
                            <td colspan="4">
                                 <div class="checkbox-control">
                                    <asp:CheckBox ID="ckbCheckAll" Runat="server" Text="Chọn tất"></asp:CheckBox>
                                </div>
                            </td>
                        </tr>
				        <tr>
					        <td width="100%" colspan="4">
                                <div class="button-control" runat="server" id="divReservationDelete">
                                    <div class="button-form">
                                        <asp:button id="btnReservationDelete" Runat="server" class="btn-icon"></asp:button><div class="btn-value"><span class="mif-bin"></span>Xoá</div>
                                    </div>
                                </div>
					        </td>
				        </tr>
				        <tr>
					        <td width="100%" colspan="4">
                                <h3 class="head-title">
                                    <asp:label id="lblOnHolding" Runat="server" Width="100%" >Ấn phẩm đang mượn</asp:label>
                                </h3>
                            </td>
				        </tr>
				        <tr>
					        <td width="100%" colspan="4">
                                <asp:datagrid id="dgrOnHolding" Runat="server" Width="100%" AutoGenerateColumns="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
							        <Columns>
								        <asp:BoundColumn DataField="STT" HeaderText="STT">
									        <HeaderStyle Width="2.5%"></HeaderStyle>
								        </asp:BoundColumn>
								        <asp:BoundColumn DataField="Content" HeaderText="Nhan đề">
									        <HeaderStyle Width="22.5%"></HeaderStyle>
								        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CopyNumber" HeaderText="Số ĐKCB">
									        <HeaderStyle Width="10%"></HeaderStyle>
								        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CODate" HeaderText="Ngày mượn">
									        <HeaderStyle Width="15%"></HeaderStyle>
								        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CIDate" HeaderText="Hạn trả">
									        <HeaderStyle Width="15%"></HeaderStyle>
								        </asp:BoundColumn>
                                        <%--<asp:BoundColumn DataField="Renew" HeaderText="Gia hạn" Visible="false">
									        <HeaderStyle Width="10%"></HeaderStyle>
								        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Reserver" Visible="false" HeaderText="Đặt chổ">
									        <HeaderStyle Width="10%"></HeaderStyle>
								        </asp:BoundColumn>--%>
                                        <asp:BoundColumn DataField="Note" HeaderText="Ghi chú">
									        <HeaderStyle Width="15%"></HeaderStyle>
								        </asp:BoundColumn>
							        </Columns>
						            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                                    <ItemStyle BackColor="White" ForeColor="#330099" />
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
						        </asp:datagrid>
					        </td>
				        </tr>
				        <tr class="lbGroupTitle" style="display:none">
					        <td width="100%" colspan="2">
                                <asp:label id="lblILLRequest" Runat="server" Width="100%" CssClass="lbGroupTitle">Ấn phẩm mưọn liên thư viện</asp:label>
					        </td>
				        </tr>
				        <tr style="display:none">
					        <td width="100%" colspan="2">
                                <asp:datagrid id="dgrILLRequest" Runat="server" Width="100%" AutoGenerateColumns="False" ShowHeader="False">
							        <Columns>
								        <asp:BoundColumn DataField="CheckBox">
									        <HeaderStyle Width="5%"></HeaderStyle>
								        </asp:BoundColumn>
								        <asp:BoundColumn DataField="Title">
									        <HeaderStyle Width="95%"></HeaderStyle>
								        </asp:BoundColumn>
							        </Columns>
						        </asp:datagrid>
					        </td>
				        </tr>
				        <tr class="lbGroupTitle" style="display:none;">
					        <td colspan="2" width="100%">
                                <asp:Label ID="lblInterestItem" Runat="server" Width="100%" CssClass="lbGroupTitle">Ấn phẩm mới</asp:Label>
					        </td>
				        </tr>
				        <tr style="display:none">
					        <td colspan="2" width="100%">
						        <asp:HyperLink CssClass="lbLinkFunction" ID="hrfInterstItem" Runat="server" Width="100%" NavigateUrl="javascript:SubmitForm();">Chọn lĩnh vực quan tâm</asp:HyperLink>
					        </td>
				        </tr>
				        <tr style="display:none">
					        <td colspan="2" width="100%">
                                <asp:DataGrid ID="dgrInterestItem" Runat="server" Width="100%" AutoGenerateColumns="False">
							        <Columns>
								        <asp:BoundColumn DataField="Content">
									        <HeaderStyle Width="100%"></HeaderStyle>
								        </asp:BoundColumn>
							        </Columns>
						        </asp:DataGrid>
					        </td>
				        </tr>
			        </table>
			        <div style="display:none">
                        <asp:Label ID="lblCheckOutDate" Runat="server" Visible="False">Ngày mượn: </asp:Label>
			            <asp:Label ID="lblCheckInDate" Runat="server" Visible="False">Ngày trả: </asp:Label>
			            <asp:Label ID="lblOverDueDate" Runat="server" Visible="False">Quá hạn: </asp:Label>
			            <asp:Label ID="lblDate" Runat="server" Visible="False"> ngày</asp:Label>
			            <asp:Label ID="lblCreatedDate" Runat="server" Visible="False">Ngày tạo y/c: </asp:Label>
			            <asp:Label ID="lbldelILL" Runat="server" Visible="False">huỷ yêu cầu</asp:Label>
			            <asp:Label ID="lblStatus" Runat="server" Visible="False"> Trạng thái: </asp:Label>
			            <asp:Label ID="lblRenew" Runat="server" Visible="False">gia hạn </asp:Label>
			            <asp:Label ID="lblOnHoldingB" Runat="server" Visible="False">sách đã được đặt chỗ </asp:Label>
			            <asp:Label ID="lblNotRenew" Runat="server" Visible="False"> không có quyền gia hạn</asp:Label>
			            <asp:Label ID="lblHour" Runat="server" Visible="False">giá</asp:Label>
			            <asp:Label ID="lblGetBefore" Runat="server" Visible="False">Lấy truớc: </asp:Label>
			            <asp:Label ID="lblLibaryName" Runat="server" Visible="False">Thư viện: </asp:Label>
			            <asp:Label ID="lblPosition" Runat="server" Visible="False">Bạn đứng thứ</asp:Label>
			            <input type="hidden" runat="server" id="hdInterestObject" name="hdInterestObject"/>
			            <input type="hidden" runat="server" id="hdInheritanceMap" name="hdInheritanceMap" value="||"/>
			            <input type="hidden" id="hdOpenedParentIDs" runat="server" name="hdOpenedParentIDs"/>
			            <input type="hidden" id="hdAllwaysChecking" name="hdAllwaysChecking" runat="server" value="false"/>
			            <input type="hidden" name="hdScrollTop" id="hdScrollTop" runat="server" value=""/> 
                        <input type="hidden" name="hdUpdateFlag" id="hdUpdateFlag" runat="server" value="false"/>
                        <asp:Label ID="lblHeaderReservation" Runat="server" Visible="False">Ấn phẩm đặt chỗ</asp:Label>
                        <asp:Label ID="lblHeaderOnHolding" Runat="server" Visible="False">Ấn phẩm đang mượn</asp:Label>
                    </div>
                 </div>
            </div>
        </div>
        
        <uc1:UFooter ID="UFooter1" runat="server" />
        <a href="#" id="toTop" class="scrollup">Scroll</a>
    </form>
</body>
</html>
