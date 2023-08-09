<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WShowShelfSchema" CodeFile="WShowShelfSchema.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sơ đồ vị trí giá sách trong thư viện</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="1" cellPadding="1" width="100%">
				<tr class="lbPageTitle">
					<td align="center"><asp:label id="lblTitle" runat="server" CssClass="lbPageTitle">Sơ đồ giá sách</asp:label></td>
				</tr>
				<tr>
					<td><asp:label id="lblHelp" Runat="server">Bạn có thể xác định tung độ và hoành độ bằng 1 trong 2 cách sau</asp:label></td>
				</tr>
				<tr>
					<td class="lbSubFormTitle">
						<asp:label id="lblMethod1" Runat="server" CssClass="lbSubFormTitle">Cách 1: Nhập khoảng cách tính đỉnh giá sách (góc trên bên trái) tới góc trên bên trái của kho.</asp:label></td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="1" cellPadding="1" width="100%">
							<tr>
								<td align="right"><asp:label id="lblTopCoor" Runat="server"><u>T</u>ung độ:</asp:label></td>
								<td><asp:textbox id="txtTopCoor" Runat="server" Width="80px">0</asp:textbox>&nbsp;<asp:label id="lblUnitPixel1" Runat="server">(m)</asp:label></td>
								<td align="right"><asp:label id="lblLeftCoor" Runat="server"><u>H</u>oành độ:</asp:label></td>
								<td><asp:textbox id="txtLeftCoor" Runat="server" Width="80px">0</asp:textbox>&nbsp;<asp:label id="lblUnitPixel2" Runat="server">(m)</asp:label></td>
							</tr>
							<tr>
								<td align="center" colSpan="4">
									<asp:button id="btnAccept" Runat="server" Text="Chấp nhận(a)" Width="100px"></asp:button>&nbsp;
									<asp:button id="btnClose" Runat="server" Text="Đóng(o)" Width="70px"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td class="lbSubFormTitle">
						<asp:label id="lblMethod2" Runat="server" CssClass="lbSubFormTitle">Cách 2: Bấm chuột thẳng vị trí toạ độ đỉnh trên sơ đồ kho.</asp:label></td>
				</tr>
				<tr>
					<td align="center">
						<input id="imgShelfSchema" type="image" name="imgShelfSchema" runat="server">
						<asp:Label ID="lblNoSchema" Runat=server Visible=False>Chưa có sơ đồ kho!</asp:Label>
					</td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlLabelNote" runat="server" Visible="False">
				<asp:ListItem Value="0">Trường giá trị còn rỗng!</asp:ListItem>
				<asp:ListItem Value="1">Giá trị không hợp lệ!</asp:ListItem>
				<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="3">Mã lỗi</asp:ListItem>
			</asp:dropdownlist>
			<input id="hidImgWidth" runat="server" type="hidden" name="hidImgWidth"> <input id="hidImgHeight" runat="server" type="hidden" name="hidImgHeight">
			<input id="hidTopCoor" runat="server" type="hidden" name="hidTopCoor"> <input id="hidLeftCoor" runat="server" type="hidden" name="hidLeftCoor">
			<input id="hidImgHeightMetter" runat="server" type="hidden" name="hidImgHeightMetter">
			<input id="hidImgWidthMetter" runat="server" type="hidden" name="hidImgWidthMetter">&nbsp;
		</form>
	</body>
</HTML>
