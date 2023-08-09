<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OPatronUpdate.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OPatronUpdate" %>

<%@ Register src="UFooter.ascx" tagname="UFooter" tagprefix="uc1" %>
<%@ Register src="UHeader.ascx" tagname="UHeader" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
</head>
<body  class="metro"  style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px">
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
                                        <asp:label id="lblMainTitle" CssClass="lbPageTitle" Runat="server">Cập nhật thông tin bạn đọc</asp:label>
                                    </h3>
						        </td>
					        </tr>
					        <tr>
						        <td align="right" width="15%"></td>
						        <td colspan="3" align="left"><asp:label id="lblCardNo" Runat="server">Số thẻ: </asp:label><asp:label id="lblCardNoValue" Runat="server"></asp:label>&nbsp;&nbsp;&nbsp;<asp:label id="lblPatronName" Runat="server">Họ và tên: </asp:label>&nbsp;<asp:label id="lblPatronNameValue" Runat="server"></asp:label></td>
					        </tr>
					        <tr>
						        <td align="right" width="15%"><asp:label id="lblEducation" Runat="server">Trình độ: </asp:label></td>
						        <td width="40%"><asp:dropdownlist id="ddlEducation" Runat="server"></asp:dropdownlist></td>
						        <td align="right" width="15%"><asp:label id="lblTel" Runat="server">Số điện th<u>o</u>ại: </asp:label></td>
						        <td><asp:textbox id="txtTel" Runat="server" Width="120px" MaxLength="50"></asp:textbox></td>
					        </tr>
					        <tr>
						        <td align="right" width="15%"><asp:label id="lblOccupation" Runat="server">Nhóm nghành: </asp:label></td>
						        <td width="40%"><asp:dropdownlist id="ddlOccupation" Runat="server"></asp:dropdownlist></td>
						        <td align="right" width="15%"><asp:label id="lblMobile" Runat="server">Mo<u>b</u>ile: </asp:label></td>
						        <td><asp:textbox id="txtMobile" Runat="server" Width="120px" MaxLength="12"></asp:textbox></td>
					        </tr>
					        <tr>
						        <td align="right" width="15%"><asp:label id="lblWorkPlace" Runat="server">Đị<u>a</u> chỉ c/q: </asp:label></td>
						        <td width="40%"><asp:textbox id="txtWorkPlace" Runat="server" Width="250px" MaxLength="150"></asp:textbox></td>
						        <td align="right" width="15%"><asp:label id="lblPassword" Runat="server">Mật khẩ<u>u</u>: </asp:label></td>
						        <td><asp:textbox id="txtPassword" Runat="server" Width="120px" TextMode="Password" MaxLength="16"></asp:textbox></td>
					        </tr>
					        <tr>
						        <td align="right" width="15%"><asp:label id="lblEmail" Runat="server">Email:</asp:label></td>
						        <td width="40%"><asp:textbox id="txtEmail" Runat="server" Width="250px" MaxLength="50"></asp:textbox></td>
						        <td align="right" width="15%"><asp:label id="lblConfirmPassword" Runat="server">&nbsp;<u>X</u>ác nhận m/k: </asp:label></td>
						        <td><asp:textbox id="txtConfirmPassword" Runat="server" Width="120px" TextMode="Password" MaxLength="16"></asp:textbox></td>
					        </tr>
					        <tr>
						        <td align="right"><asp:label id="lblAddress" Runat="server">Đ/c thường trú: </asp:label></td>
						        <td colspan="3"><asp:textbox id="txtAddress" Runat="server" Width="480px" MaxLength="200"></asp:textbox></td>
					        </tr>
					        <tr>
						        <td align="right"></td>
						        <td colspan="3">
                                    <asp:button id="btnUpdate" Runat="server" Text="Cập nhật(c)"></asp:button>&nbsp;<input id="btnReset" type="reset" value="Làm lại(i)" name="btnReset" runat="server"/></td>
						        </td>
					        </tr>
				        </tbody>
			        </table>
                    <div style="display:none">
                        <asp:TextBox ID="txtOccupation" Runat="server" Visible="False" Width="0">0</asp:TextBox>
			            <asp:TextBox ID="txtEducation" Runat="server" Visible="False" Width="0">0</asp:TextBox>
			            <input type="hidden" id="hidPassword" runat="server" value=""/>
                        <input type="hidden" id="hidOccupation" runat="server" value="0"/>
			            <input type="hidden" id="hidEducation" runat="server" value="0"/>
			            <asp:label id="lblUpdateSuccessful" Runat="server" Visible="False">Cập nhật thành công</asp:label>
                        <asp:label id="lblEmtyPassword" Runat="server" Visible="False">Mật khẩu không hợp lệ, mật khẩu phải lớn hơn 4 ký tự !</asp:label>
                        <asp:Label ID="lblComparePassword" Runat="server" Visible="False">mật khẩu phải trùng nhau!!!</asp:Label>
                        <asp:Label id="lblNotValidEmail" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 248px" Runat="server" Visible="False">Email không hợp lệ</asp:Label>
                    </div>
			        <script language="javascript" type="text/javascript">
			            document.forms[0].txtPassword.value = document.forms[0].hidPassword.value;
			            document.forms[0].txtConfirmPassword.value = document.forms[0].hidPassword.value;
			            document.forms[0].hidPassword.value = "";
			        </script>
                </div>
            </div>
        </div>
        
        <uc1:UFooter ID="UFooter1" runat="server" />
        <a href="#" id="toTop" class="scrollup">Scroll</a>
    </form>
</body>
</html>
