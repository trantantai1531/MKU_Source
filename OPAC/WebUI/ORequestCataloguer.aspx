<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ORequestCataloguer.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.ORequestCataloguer" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
    <style type="text/css">
        input[type=radio] ~ label:before
        {
            top:4px;
        }

        input[readonly="readonly"], [disabled~="disabled"] label {
            cursor:not-allowed;
        }
    </style>
</head>
<body class="metro"  id="top" >
    <asp:ScriptManager ID="sm" runat="server" EnablePageMethods="true" />
    <form id="form1" runat="server">
        <uc2:UHeader ID="UHeader1" runat="server" />
        <div id="divMain">
            <div class="web-size news-page ClearFix">
                <div class="container">            
			        <table id="tblUpdatePersonalPageMain" width="100%" border="0">
				        <tbody>
					        <tr class="lbPageTitle">
						        <td width="100%" colspan="4">
                                    <h3 class="head-title">
                                        <asp:label id="lblMainTitle" CssClass="lbPageTitle" Runat="server">Yêu cầu bổ sung tài liệu</asp:label>
                                    </h3>
						        </td>
					        </tr>
					        <tr>
						        <td align="right" width="15%"><asp:label id="lblFullName" Runat="server">Họ tên: </asp:label><span style="color:red"> *</span></td>
						        <td width="40%">
                                    <div class="input-control">
                                        <div class="input-form">
                                            <asp:textbox id="txtFullName" Runat="server" CssClass="tb-text"></asp:textbox>
                                        </div>
                                    </div>
						        </td>
						        <td align="right" width="15%"><asp:label id="lblPatronCode" Runat="server">Số thẻ: </asp:label><span style="color:red"> *</span></td>
						        <td width="40%">
                                    <div class="input-control">
                                        <div class="input-form">
                                            <asp:textbox id="txtPatronCode" Runat="server" CssClass="tb-text"></asp:textbox>
                                        </div>
                                    </div>
						        </td>
					        </tr>
					        <tr>
						        <td align="right" width="15%"><asp:label id="lblEmail" Runat="server">Email:</asp:label><span style="color:red"> *</span></td>
						        <td width="40%">
                                    <div class="input-control">
                                        <div class="input-form">
                                            <asp:textbox id="txtEmail" Runat="server" CssClass="tb-text"></asp:textbox>
                                        </div>
                                    </div>
						        </td>
						        <td align="right" width="15%"><asp:label id="lblPhone" Runat="server">Số điện th<u>o</u>ại: </asp:label><span style="color:red"> *</span></td>
						        <td>
                                    <div class="input-control">
                                        <div class="input-form">
                                            <asp:textbox id="txtPhone" Runat="server" CssClass="tb-text"></asp:textbox>
                                        </div>
                                    </div>
						        </td>
					        </tr>
					        <tr>
						        <td align="right" width="15%"><asp:label id="lblFacebook" Runat="server">Facebook: </asp:label></td>
						        <td width="40%">
                                    <div class="input-control">
                                        <div class="input-form">
                                            <asp:textbox id="txtFacebook" Runat="server" CssClass="tb-text"></asp:textbox>
                                        </div>
                                    </div>
						        </td>
						        <td align="right" width="15%"><asp:label id="lblSupplier" Runat="server">Đơn vị: </asp:label></td>
						        <td>
                                    <div class="input-control">
                                        <div class="input-form">
                                            <asp:textbox id="txtSupplier" Runat="server" CssClass="tb-text"></asp:textbox>
                                        </div>
                                    </div>
						        </td>
					        </tr>
					        <tr>
                                <td>&nbsp;</td>
						        <td colspan="3">
                                    <div class="row-detail">
                                        <div class="radio-control">
                                            <asp:RadioButtonList ID="RadioButtonListGroupName" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Sinh Viên" Selected="True">Sinh viên</asp:ListItem>
                                                <asp:ListItem Value="Học viên cao học">Học viên cao học</asp:ListItem>
                                                <asp:ListItem Value="Cán bộ quản lý">Cán bộ quản lý</asp:ListItem>
                                                <asp:ListItem Value="Giảng viên">Giảng viên</asp:ListItem>
                                                <asp:ListItem Value="Nhân Viên">Nhân viên</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
						        </td>
					        </tr>
					        <tr>
                                <td>&nbsp;</td>
						        <td align="left" colspan="3"><asp:label id="lblAddress" Runat="server"><b>Thông tin yêu cầu cần bổ sung: </b></asp:label></td>
					        </tr>
					        <tr>
						        <td align="right">Nhan đề<span style="color:red"> *</span></td>
						        <td colspan="3">
                                    <div class="input-control">
                                        <div class="input-form">
                                            <asp:textbox id="txtTitle" Runat="server" Width="100%" CssClass="tb-text"></asp:textbox>
                                        </div>
                                    </div>
						        </td>
					        </tr>
					        <tr>
						        <td align="right">Tác giả</td>
						        <td colspan="3">
                                    <div class="input-control">
                                        <div class="input-form">
                                            <asp:textbox id="txtAuthor" Runat="server" Width="100%" CssClass="tb-text"></asp:textbox>
                                        </div>
                                    </div>
						        </td>
					        </tr>
					        <tr>
						        <td align="right">Nhà xuất bản</td>
						        <td colspan="3">
                                    <div class="input-control">
                                        <div class="input-form">
                                            <asp:textbox id="txtPublier" Runat="server" Width="100%" CssClass="tb-text"></asp:textbox>
                                        </div>
                                    </div>
						        </td>
					        </tr>
					        <tr>
						        <td align="right">Năm xuất bản</td>
						        <td colspan="3">
                                    <div class="input-control">
                                        <div class="input-form">
                                            <asp:textbox id="txtPublishYear" Runat="server" Width="100%" CssClass="tb-text"></asp:textbox>
                                        </div>
                                    </div>
						        </td>
					        </tr>
					        <tr>
						        <td align="right" valign="top">Các thông tin khác</td>
						        <td colspan="3">
                                    <div class="input-control">
                                        <div class="input-form">
                                            <asp:textbox id="txtInformation" Runat="server" Width="100%" TextMode="MultiLine" Rows="4" CssClass="tb-text"></asp:textbox>
                                        </div>
                                    </div>
						        </td>
					        </tr>
					        <tr>
						        <td align="right"></td>
						        <td colspan="3">
                                    <div class="button-control">
                                        <div class="button-form">
                                            <asp:Button ID="btnUpdate" runat="server" Text="" CssClass="btn-icon" />
                                            <div class="btn-value"><span class="mif-upload"></span>Gửi yêu cầu</div>
                                        </div>
                                        <div class="button-form">
                                            <asp:Button ID="btnReset" runat="server" Text="" CssClass="btn-icon" />
                                            <div class="btn-value"><span class="mif-undo"></span>Làm lại</div>
                                        </div>
                                    </div>
						        </td>
					        </tr>
				        </tbody>
			        </table>
                    <div style="display:none">
                        <asp:Label id="lblNotValidEmail" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 248px" Runat="server" Visible="False">Email không hợp lệ</asp:Label>
                        <asp:Label id="lblRequired" Runat="server" Visible="False">Thông tin bắt buộc không để trống</asp:Label>
                        <asp:Label id="lblSuccessRequest" Runat="server" Visible="False">Gửi yêu cầu thành công</asp:Label>
                        <asp:Label id="lblNoSuccessRequest" Runat="server" Visible="False">Gửi yêu cầu thất bại</asp:Label>
                    </div>
                </div>
            </div>
        </div>
        
        <uc1:UFooter ID="UFooter1" runat="server" />
        <a href="#" id="toTop" class="scrollup">Scroll</a>
    </form>
</body>
</html>