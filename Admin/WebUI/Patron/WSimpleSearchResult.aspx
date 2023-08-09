<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WSimpleSearchResult" CodeFile="WSimpleSearchResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WSimpleSearchResult</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
            <table width="100%" border="0" style="padding: 0 50px;">

					
				<asp:label id="lblContacInfor" runat="server" ForeColor="white" Width="100%" CssClass="lbPageTitle" Visible="false">Thông tin hồ sơ bạn đọc</asp:label>
				
				<tr>
					<td align="center" style="WIDTH: 30%">
                        <IMG alt="" id="imgPortrait" style="height:160pt;width:120pt;"  runat="server" src="../Images/Card/Empty.gif"></IMG>
					</td>
					<td style="WIDTH: 35%; padding: 15px 0;">
						<table width="100%" border="0">
							<tr>
								<td align="left" width="100%">
                                    <asp:label id="lblCapFullName" runat="server" Font-Bold="True">Họ tên : </asp:label>
                                    <asp:label id="lblFullName" runat="server" Font-Bold="True"></asp:label>
								</td>

							</tr>
							<tr>
								<td align="left" width="100%">
                                    <asp:label id="lblCapEthnic" runat="server" Font-Bold="True">Dân tộc : </asp:label>
                                    <asp:label id="lblEthnic" runat="server"></asp:label>
								</td>

							</tr>
							<tr>
								<td align="left" width="100%">
                                    <asp:label id="lblCapDOB" runat="server" Font-Bold="True">Ngày sinh : </asp:label>
                                    <asp:label id="lblDOB" runat="server"></asp:label>
								</td>
	
							</tr>
							<tr>
								<td align="left" width="100%">
                                    <asp:label id="lblCapSex" runat="server" Font-Bold="True">Giới tính : </asp:label>
                                    <asp:label id="lblSex" runat="server"></asp:label>
								</td>
								<%--<td width="70%"></td>--%>
							</tr>
							<tr id="rowEducation" runat="server">
								<td align="left" width="100%">
                                    <asp:label id="lblCapEducation" runat="server" Font-Bold="True">Trình độ : </asp:label>
                                    <asp:label id="lblEducation" runat="server"></asp:label>
								</td>
								<%--<td width="70%"></td>--%>
							</tr>
							<tr>
								<td align="left" width="100%">
                                    <asp:label id="lblCapCode" runat="server" Font-Bold="True">Số thẻ : </asp:label>
                                    <asp:label id="lblCode" runat="server" Font-Bold="True"></asp:label>
								</td>
								<%--<td width="70%"></td>--%>
							</tr>
							<tr>
								<td align="left" width="100%">
                                    <asp:label id="lblCapValidDate" runat="server" Font-Bold="True">Ngày cấp : </asp:label>
                                    <asp:label id="lblValidDate" runat="server"></asp:label>
								</td>
								<%--<td width="70%"></td>--%>
							</tr>
							<tr>
								<td align="left" width="100%">
                                    <asp:label id="lblCapExipredDate" runat="server" Font-Bold="True">Ngày hết hạn : </asp:label>
                                    <asp:label id="lblExipredDate" runat="server"></asp:label>
								</td>
								<%--<td width="70%"></td>--%>
							</tr>
							<tr>
								<td align="left" width="100%">
                                    <asp:label id="lblCapGroup" runat="server" Font-Bold="True">Nhóm : </asp:label>
                                    <asp:label id="lblGroup" runat="server"></asp:label>
								</td>
								<%--<td width="70%"></td>--%>
							</tr>
							<tr>
								<td align="left" width="100%">
                                    <asp:label id="lblCapNote" runat="server" Font-Bold="True">Ghi chú : </asp:label>
                                    <asp:label id="lblNote" runat="server"></asp:label>
								</td>
							</tr>
						</table>
					</td>
                    <td style="WIDTH: 35%; padding: 15px 0;">
                        <table width="100%" border="0">
				            <tr>
					            <td align="left" width="100%">
					                <asp:label id="lblCapCollege" runat="server" Font-Bold="True">Trường: </asp:label>
                                    <asp:label id="lblCollege" runat="server"></asp:label>
					            </td>
				            </tr>     
                            <tr>
                                <td align="left" width="100%">
                                    <asp:label id="lblCapFaculty" runat="server" Font-Bold="True">Đơn vị: </asp:label>
                                    <asp:label id="lblFaculty" runat="server"></asp:label>
                                </td>
                            </tr>  
                            <tr>
                                <td align="left" width="100%">
                                    <asp:label id="lblCapGrade" runat="server" Font-Bold="True">Khóa: </asp:label>
                                    <asp:label id="lblGrade" runat="server"></asp:label>
                                </td>
                            </tr>  
				            <tr runat="server" id="rowClass">
					            <td align="left" width="100%">
                                    <asp:label id="lblCapClass" runat="server" Font-Bold="True">Lớp: </asp:label>
                                    <asp:label id="lblClass" runat="server"></asp:label>
					            </td>
				            </tr>
				            <tr runat="server" id="rowOccupation">
					            <td align="left" width="100%">
                                    <asp:label id="lblCapOccupation" runat="server" Font-Bold="True">Ngành nghề: </asp:label>
                                    <asp:label id="lblOccupation" runat="server"></asp:label>
					            </td>
				            </tr>
                             <tr>
					            <td align="left" width="100%">
                                    <asp:label id="lblCapOtherAddress" runat="server" Font-Bold="True">Nơi thường trú: </asp:label>
                                    <asp:label id="lblOtherAddress" runat="server"></asp:label>
					            </td>
				            </tr>
				            <tr>
					            <td align="left" width="100%">
                                    <asp:label id="lblCapTel" runat="server" Font-Bold="True">Số điện thoại: </asp:label>
                                    <asp:label id="lblTel" runat="server"></asp:label>
					            </td>
					           <%-- <td></td>--%>
				            </tr>
                            <tr runat="server" id="Tr1">
                                <td align="left" width="100%">
                                    <asp:label id="lblCapEmail" runat="server" Font-Bold="True">Email: </asp:label>
                                    <asp:label id="lblEmail" runat="server"></asp:label>
                                </td>
                                <%-- <td></td>--%>
                            </tr>
                            <tr runat="server" id="Tr2">
                                <td align="left" width="100%">
                                    <asp:label id="lblCapFacebook" runat="server" Font-Bold="True">Facebook: </asp:label>
                                    <asp:label id="lblFacebook" runat="server"></asp:label>
                                </td>
                                <%-- <td></td>--%>
                            </tr>
				            <tr runat="server" id="rowIDCard">
					            <td align="left" width="100%">
                                    <asp:label id="lblCapIDCard" runat="server" Font-Bold="True">Số CMND: </asp:label>
                                    <asp:label id="lblIDCard" runat="server"></asp:label>
					            </td>
					           <%-- <td></td>--%>
				            </tr>
       
			            </table>
                  
                    </td>

				</tr>
			</table>

		<%--	<table width="100%" border="0">
				<tr  class="lbPageTitle">
					<td colSpan="2">
						<asp:label id="lblMainInfor" runat="server" ForeColor="White" Width="100%" CssClass="lbPageTitle">Thông tin hồ sơ bạn đọc</asp:label></td>
				</tr>
				<tr>
					<td align="center" width="268" style="WIDTH: 268px"><IMG alt="" id="imgPortrait" runat="server" src="../Images/Card/Empty.gif"></td>
					<td>
						<table width="100%" border="0">
							<tr>
								<td align="right"><asp:label id="lblCapFullName" runat="server" Font-Bold="True">Họ tên: </asp:label></td>
								<td width="70%"><asp:label id="lblFullName" runat="server" Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblCapEthnic" runat="server" Font-Bold="True">Dân tộc: </asp:label></td>
								<td width="70%"><asp:label id="lblEthnic" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblCapDOB" runat="server" Font-Bold="True">Ngày sinh: </asp:label></td>
								<td width="70%"><asp:label id="lblDOB" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblCapSex" runat="server" Font-Bold="True">Giới tính: </asp:label></td>
								<td width="70%"><asp:label id="lblSex" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblCapEducation" runat="server" Font-Bold="True">Trình độ: </asp:label></td>
								<td width="70%"><asp:label id="lblEducation" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblCapCode" runat="server" Font-Bold="True">Số thẻ: </asp:label></td>
								<td width="70%"><asp:label id="lblCode" runat="server" Font-Bold="True"></asp:label></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblCapValidDate" runat="server" Font-Bold="True">Ngày cấp: </asp:label></td>
								<td width="70%"><asp:label id="lblValidDate" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblCapExipredDate" runat="server" Font-Bold="True">Ngày hết hạn: </asp:label></td>
								<td width="70%"><asp:label id="lblExipredDate" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="right" width="255"><asp:label id="lblCapGroup" runat="server" Font-Bold="True">Nhóm: </asp:label></td>
								<td width="70%"><asp:label id="lblGroup" runat="server"></asp:label></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblCapNote" runat="server" Font-Bold="True">Ghi chú: </asp:label></td>
								<td width="70%"><asp:label id="lblNote" runat="server"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>--%>
		<%--	<table width="100%" border="0">
				<tr  class="lbPageTitle">
					<td colSpan="2"><asp:label id="lblOccupInfor" runat="server" ForeColor="White" Width="100%" CssClass="lbPageTitle">Nghề nghiệp: </asp:label></td>
				</tr>
				<tr>
					<td align="right" width="50%"><asp:label id="lblCapCollege" runat="server" Font-Bold="True">Trường: </asp:label></td>
					<td><asp:label id="lblCollege" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="right" width="50%"><asp:label id="lblCapFaculty" runat="server" Font-Bold="True">Đơn vị: </asp:label></td>
					<td><asp:label id="lblFaculty" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="right" width="50%"><asp:label id="lblCapGrade" runat="server" Font-Bold="True">Khoá: </asp:label></td>
					<td><asp:label id="lblGrade" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="right" width="50%"><asp:label id="lblCapClass" runat="server" Font-Bold="True">Lớp: </asp:label></td>
					<td><asp:label id="lblClass" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="right" width="50%"><asp:label id="lblCapOccupation" runat="server" Font-Bold="True">Ngành nghề: </asp:label></td>
					<td><asp:label id="lblOccupation" runat="server"></asp:label></td>
				</tr>
			</table>--%>
		<%--	<table width="100%" border="0">
				<tr  class="lbPageTitle">
					<td colSpan="2"><asp:label id="lblContacInfor" runat="server" ForeColor="White" Width="100%" cssclass="lbPageTitle">Thông tin liên lạc: </asp:label></td>
				</tr>
				<tr>
					<td align="right" width="50%"><asp:label id="lblCapOtherAddress" runat="server" Font-Bold="True">Nơi thường trú: </asp:label></td>
					<td><asp:label id="lblOtherAddress" runat="server"></asp:label></td>
				</tr>
				<tr>
					<td align="right" width="50%"><asp:label id="lblCapTel" runat="server" Font-Bold="True">Số điện thoại: </asp:label></td>
					<td><asp:label id="lblTel" runat="server"></asp:label></td>
				</tr>
				<tr style="display:none">
					<td align="right" width="50%"><asp:label id="lblCapMobile" runat="server" Font-Bold="True">Số Mobile: </asp:label></td>
					<td><asp:label id="lblMobile" runat="server"></asp:label></td>
				</tr>
                <tr>
                    <td align="right" width="50%"><asp:label id="lblCapEmail" runat="server" Font-Bold="True">Email: </asp:label></td>
					<td><asp:label id="lblEmail" runat="server"></asp:label></td>
                </tr>
                <tr>
                    <td align="right" width="50%"><asp:label id="lblCapFacebook" runat="server" Font-Bold="True">FaceBook: </asp:label></td>
					<td><asp:label id="lblFaceBook" runat="server"></asp:label></td>
                </tr>
				<tr>
					<td align="right" width="50%"><asp:label id="lblCapIDCard" runat="server" Font-Bold="True">Số chứng minh thư nhân dân: </asp:label></td>
					<td><asp:label id="lblIDCard" runat="server"></asp:label></td>
				</tr>
			</table>--%>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Nam</asp:ListItem>
				<asp:ListItem Value="3">Nữ</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
