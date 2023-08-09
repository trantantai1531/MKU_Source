<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WReservationsRun" CodeFile="WReservationsRun.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Yêu cầu đặt chỗ</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0" >
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<tr>
					<td colSpan="3" align="left">
                        <marquee id="marMsg">
							<asp:Label ID="lblReserve" Runat="server" CssClass="lbLabel" ForeColor="#FF3300" Font-Size="17px"></asp:Label>
							<asp:Label ID="lblReserveRequest" Runat="server" CssClass="lbLabel" ForeColor="#333300" Font-Size="17px"></asp:Label>
						</marquee>
					</td>
				</tr>
				<asp:label Visible="False" Runat="server" ID="lblLabel1">ĐKCB rỗi:&nbsp;</asp:label>
				<asp:label Visible="False" Runat="server" ID="lblLabel2">Tất cả các ĐKCB đều bận</asp:label>
				<asp:label Visible="False" Runat="server" ID="lblMsg1">Bạn phải nhập dữ liệu kiểu số!</asp:label>
				<asp:label Visible="False" Runat="server" ID="lblMsg2">Bạn chưa nhập số giây!</asp:label>
				<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
					<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
					<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
					<asp:ListItem Value="2">ĐKCB rỗi:&nbsp;</asp:ListItem>
					<asp:ListItem Value="3">Tất cả các ĐKCB đều bận</asp:ListItem>
					<asp:ListItem Value="4">Sai kiểu dữ liệu (số)</asp:ListItem>
					<asp:ListItem Value="5">Bạn chưa nhập thời gian chờ (giây)</asp:ListItem>
					<asp:ListItem Value="6">Tài liệu:</asp:ListItem>
					<asp:ListItem Value="7">đang được</asp:ListItem>
					<asp:ListItem Value="8">đặt mượn vào thời điểm </asp:ListItem>
					<asp:ListItem Value="9">Hiện tại không có yêu cầu đặt mượn nào.</asp:ListItem>
				</asp:DropDownList>
				<asp:label Visible="False" Runat="server" ID="lblReserveCreate">đặt chỗ vào thời điểm </asp:label>
				<asp:label Visible="False" Runat="server" ID="lblReserveNull">Hiện tại không có yêu cầu đặt chỗ nào.</asp:label>
				<asp:label Visible="False" Runat="server" ID="lblReservation">Yêu cầu đặt mượn: </asp:label>
				<asp:label Visible="False" Runat="server" ID="lblReservationHolding">Yêu cầu đặt chổ: </asp:label>
			</TABLE>
		</form>
	</body>
</HTML>
