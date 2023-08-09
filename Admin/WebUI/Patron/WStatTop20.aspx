<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatTop20" CodeFile="WStatTop20.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatTop20</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			    <div id="divBody">
         
                            <h1 class="main-head-form">Thống kê theo TOP 20</h1>
                            <div class="main-form ClearFix">
                               

                                    <div class="row-detail">
                                        <p>Chọn tiêu chí thống kê:</p>
                                        <div class="input-control" style="display:inline-block;width:200px;">
                                            <div class="dropdown-form">
                                                <asp:dropdownlist id="ddlTop20" Runat="server">
							                        <asp:ListItem Value="1" Selected="True">Nhóm bạn đọc</asp:ListItem>
						                        	<asp:ListItem Value="2">Trường</asp:ListItem>
							                        <asp:ListItem Value="3">Khoa</asp:ListItem>
							                        <asp:ListItem Value="4">Khoá</asp:ListItem>
							                        <asp:ListItem Value="5">Lớp</asp:ListItem>
							                        <asp:ListItem Value="6">Dân tộc</asp:ListItem>
							                        <asp:ListItem Value="7">Trình độ</asp:ListItem>
							                        <asp:ListItem Value="8">Ngành nghề</asp:ListItem>
						                        </asp:dropdownlist>
                                            </div>

                                        </div>
                                         <asp:Button ID="btnStatistic" Runat="server" Text="Thống kê(s)" Width=""></asp:Button>
                                         <asp:Button ID="btnBack" Runat="server" Text="Quay lại(b)" Width=""></asp:Button>
                                    </div>
                                </div>
         
                        </div>

			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="1">Mã lổi: </asp:ListItem>
				<asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
