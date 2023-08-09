<%@ Page Language="vb" AutoEventWireup="false" EnableViewStateMAC="False" EnableViewState="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCirculationTemplatePreview" CodeFile="WCirculationTemplatePreview.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCirculationTemplatePreview</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td align="center" style="display:none;"><asp:Label ID="lblMainTitle" Runat="server" Width="100%"></asp:Label></td>
				</tr>
				<tr>
					<td><asp:Label ID="lblPreview" Runat="server" Width="100%"></asp:Label></td>
				</tr>
				<tr>
					<td align="center" ><asp:Button ID="btnClose" Runat="server" Text="Đóng(o)" Width="73px"></asp:Button></td>
				</tr>
			</table>
			<asp:Label ID="lblContentData" Runat="server" Visible="False">053106504,Phạm Yên Hạ,01/04/1984,T5,CNTT,5,123 Đinh Tiên Hoàng - Phường 5 - Quận 1 - TPHCM,0909.123.321,yenpham1984@gmail.com,1,Giáo trình tin học căn bản,KC012345,Kho KC,50.000 VNĐ,14/02/2007,20/02/2007,2,10000,10000,10000,31,12,2007,Giáo trình tin học căn bản,Hoàng Đình Tín,NXB Đại học Quốc gia,2012,441,24</asp:Label>
			<asp:Label ID="lblContentDataValue" Runat="server" Visible="False">PATRONCODE,FULLNAME,DOB,CLASS,FACULTY,GRADE,ADDRESS,MOBILE,EMAIL,COUNTLOAN,TITLE,COPYNUMBER,LOCATIONNAME,PRICE,CHECKOUTDATE,DUEDATE,OVERDUEDAY,FEES,FINES,MONEY,DD,MM,YYYY,245a,245c,260b,260c,300a,300c</asp:Label>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Xem mẫu phiếu ghi mượn</asp:ListItem>
				<asp:ListItem Value="3">Xem mẫu phiếu ghi trả</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
