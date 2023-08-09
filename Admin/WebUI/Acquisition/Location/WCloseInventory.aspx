<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WCloseInventory" CodeFile="WCloseInventory.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCloseInventory</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="3" leftmargin="5">
		<form id="Form1" method="post" runat="server">
			<table id="tbl1" width="100%" cellpadding="4" cellspacing="0" border="0" style=" font-size: 15px;  border-bottom: 1px solid #FCC997;  padding: 5px;">
				<tr>
					<td>
						<asp:Label ID="lblInventoryName" Runat="server"><u>K</u>ỳ kiểm kê:</asp:Label>
						<asp:DropDownList ID="ddlInventory" Runat="server" AutoPostBack="True" Width="150px"></asp:DropDownList>&nbsp;&nbsp;&nbsp;
						<asp:Label ID="lblDateClose" Runat="server"><u>N</u>gày khoá sổ:</asp:Label>
						<asp:TextBox ID="txtDateClose" Runat="server" Width="70px" ReadOnly="True"></asp:TextBox>

                    <div class="button-control" style="display:inline-block">
                        <div class="button-form ">
                           <asp:Button ID="btnClose" CssClass="form-btn" Runat="server" Text="Khoá(k)" Width="64px"></asp:Button>
                        </div>
                    </div>

						
					</td>
				</tr>
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Kỳ kiểm kê đã được khoá</asp:ListItem>
				<asp:ListItem Value="3">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
