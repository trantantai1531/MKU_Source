<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Index" CodeFile="Index.aspx.vb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>
			   HỆ THỐNG QUẢN LÝ THƯ VIỆN ĐIỆN TỬ 
		</title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="Resources/StyleSheet/style.css" type="text/css" rel="StyleSheet">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bgColor="#ebebeb" leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<div align="center">
			    <div style="height:30%;">&nbsp;</div>
				<table width="306px" height="230px" border="0" align="center" cellpadding="0px" cellspacing="0px">
					<tr>
						<td align="center" valign="middle" class="logon">
							<table border="0"  cellspacing="0" cellpadding="0" >
								<tr>
									<td >
										<table border="0" width="100%" cellspacing="0" cellpadding="0">
										
											<tr>
											    <td valign="top">
													</td>
												<td  valign="top" height=25>
													<asp:dropdownlist id="ddlDataBase" Runat="server" Width="210px" Visible="false"></asp:dropdownlist></td>
											</tr>
											<tr>
											    <td valign="top"><asp:Label ID="lblLanguage" runat="server"></asp:Label>
													</td>
												<td valign="top" height=25>
													<asp:dropdownlist id="ddlLanguage" Runat="server" AutoPostBack="True"></asp:dropdownlist></td>
											</tr>
											<tr>
											       <td valign="top"><asp:Label ID="lblUserName" runat="server"></asp:Label>
													</td>
												<td valign="top" height=23>
													<asp:textbox id="txtUserName" accessKey="T" runat="server" Width="120px" CssClass="lbTextbox"></asp:textbox></td>
											</tr>
											<tr>    
											     <td valign="top"><asp:Label ID="lblPassword" runat="server"></asp:Label>
													</td>
												<td valign="top" height=23>
													<asp:textbox id="txtPassword" accessKey="M" Width="120px" CssClass="lbTextBox" Runat="server" TextMode="Password"></asp:textbox></td>
											</tr>
											<tr>
												<td valign="top"></td>
												<td><asp:ImageButton id="btnLogin" runat="server" ImageUrl="Images/10_search.jpg"></asp:ImageButton></td>
											</tr>
											
										</table>
									</td>
									<td valign="top"></td>  
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</div>
			<asp:dropdownlist id="ddlLabel" Width="0" Runat="server" Visible="False" Height="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Cặp tên và mật khẩu không hợp lệ!</asp:ListItem>
				<asp:ListItem Value="3">Bạn chưa nhập tên đăng nhập!</asp:ListItem>
				<asp:ListItem Value="4">Tiếng Việt</asp:ListItem>
				<asp:ListItem Value="5">Tiếng Việt - TCVN</asp:ListItem>
				<asp:ListItem Value="6">Tiếng Việt - VNI</asp:ListItem>
				<asp:ListItem Value="7">Tiếng Anh</asp:ListItem>
				<asp:ListItem Value="8">Tiếng Pháp</asp:ListItem>
				<asp:ListItem Value="9">Tiếng Trung</asp:ListItem>
				<asp:ListItem Value="10">Tiếng Ý</asp:ListItem>
				<asp:ListItem Value="11">Thư viện điện tử eMicLib</asp:ListItem>
				<asp:ListItem Value="12">Không kết nối được với cơ sở dữ liệu đã chọn !</asp:ListItem>
				<asp:ListItem Value="13">Đăng nhập hệ thống</asp:ListItem>
			</asp:dropdownlist><input id="hidLanguage" type="hidden" runat="server">
			<script language="JavaScript">
				document.forms[0].txtUserName.focus();
			</script>
		</form>
	</body>
</HTML>
