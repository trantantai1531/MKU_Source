<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WRequestCataloguerDetail.aspx.vb" Inherits="eMicLibAdmin.WebUI.Patron.WRequestCataloguerDetail" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Yêu cầu bổ sung tài liệu</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Yêu cầu bổ sung tài liệu</h1>
            <div class="main-form">
                <table width="100%" border="0" cellpadding="5" cellspacing="5">
			        <tbody>
				        <tr>
                            <td><span class="lbLabel">&nbsp;</span></td>
					        <td align="left" colspan="3"><asp:label id="lblInfo" Runat="server" ForeColor="#1f61a3"><b>Thông tin người yêu cầu bổ sung: </b></asp:label></td>
				        </tr>
				        <tr>
					        <td align="right" width="15%"><asp:label id="lblFullName" Runat="server" Font-Bold="true">Họ tên: </asp:label></td>
					        <td width="40%">
                                <asp:label id="txtFullName" Runat="server"></asp:label>
					        </td>
					        <td align="right" width="15%"><asp:label id="lblPatronCode" Runat="server" Font-Bold="true">Số thẻ: </asp:label></td>
					        <td width="40%">
                                <asp:label id="txtPatronCode" Runat="server"></asp:label>
					        </td>
				        </tr>
				        <tr>
					        <td align="right" width="15%"><asp:label id="lblEmail" Runat="server" Font-Bold="true">Email: </asp:label></td>
					        <td width="40%">
                                <asp:label id="txtEmail" Runat="server"></asp:label>
					        </td>
					        <td align="right" width="15%"><asp:label id="lblPhone" Runat="server" Font-Bold="true">Số điện th<u>o</u>ại: </asp:label></td>
					        <td>
                                <asp:label id="txtPhone" Runat="server"></asp:label>
					        </td>
				        </tr>
				        <tr>
					        <td align="right" width="15%"><asp:label id="lblFacebook" Runat="server" Font-Bold="true">Facebook: </asp:label></td>
					        <td width="40%">
                                <asp:label id="txtFacebook" Runat="server"></asp:label>
					        </td>
					        <td align="right" width="15%"><asp:label id="lblSupplier" Runat="server" Font-Bold="true">Đơn vị: </asp:label></td>
					        <td>
                                <asp:label id="txtSupplier" Runat="server"></asp:label>
					        </td>
				        </tr>
				        <tr>
                            <td align="right"><asp:label id="lblGroupName" Runat="server" Font-Bold="true">Nghề nghiệp: </asp:label></td>
					        <td colspan="3">
                                <asp:label id="txtGroupName" Runat="server"></asp:label>
					        </td>
				        </tr>
				        <tr>
                            <td><span class="lbLabel">&nbsp;</span></td>
					        <td align="left" colspan="3"><asp:label id="lblAddress" Runat="server" ForeColor="#1f61a3"><b>Thông tin yêu cầu bổ sung tài liệu: </b></asp:label></td>
				        </tr>
				        <tr>
					        <td align="right"><asp:label id="lblTitle" Runat="server" Font-Bold="true">Nhan đề: </asp:label></td>
					        <td colspan="3">
                                <asp:label id="txtTitle" Runat="server"></asp:label>
					        </td>
				        </tr>
				        <tr>
					        <td align="right"><asp:label id="lblAuthor" Runat="server" Font-Bold="true">Tác giả: </asp:label></td>
					        <td colspan="3">
                                <asp:label id="txtAuthor" Runat="server"></asp:label>
					        </td>
				        </tr>
				        <tr>
					        <td align="right"><asp:label id="lblPublier" Runat="server" Font-Bold="true">Nhà xuất bản: </asp:label></td>
					        <td colspan="3">
                                <asp:label id="txtPublier" Runat="server"></asp:label>
					        </td>
				        </tr>
				        <tr>
					        <td align="right"><asp:label id="lblPublishYear" Runat="server" Font-Bold="true">Năm xuất bản: </asp:label></td>
					        <td colspan="3">
                                <asp:label id="txtPublishYear" Runat="server"></asp:label>
					        </td>
				        </tr>
				        <tr>
					        <td align="right" valign="top"><asp:label id="lblInformation" Runat="server" Font-Bold="true">Các thông tin khác: </asp:label></td>
					        <td colspan="3">
                                <asp:Literal id="txtInformation" Runat="server"></asp:Literal>
					        </td>
				        </tr>
				        <tr>
					        <td align="right"><asp:label id="lblDateInput" Runat="server" Font-Bold="true">Ngày yêu cầu: </asp:label></td>
					        <td colspan="3">
                                <asp:label id="txtDateInput" Runat="server"></asp:label>
					        </td>
				        </tr>
                        <%--<tr>
                            <td><span class="lbLabel">&nbsp;</span></td>
                            <td align="right" colspan="3">
                                <asp:Button ID="btnExport" runat="server" Text="Xuất file" />
                            </td>
                        </tr>--%>
			        </tbody>
		        </table>
            </div>
            
        </div>
    </form>
</body>
</html>
