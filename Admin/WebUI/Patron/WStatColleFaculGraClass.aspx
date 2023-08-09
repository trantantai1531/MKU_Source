<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatColleFaculGraClass" CodeFile="WStatColleFaculGraClass.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatColleFaculGraClass</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
		
        <div id="divBody">
         
                            <h1 class="main-head-form">Thống kê trường khoa, khóa, lớp</h1>
                            <div class="main-form ClearFix">
                               

                                    <div class="row-detail">
                                        <p>Chọn tiêu chí thống kê:</p>
                                        <div class="input-control" style="display:inline-block;width:120px;">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlPickTypeStat" Runat="server">
							<asp:ListItem Value="0" Selected="True">Trường</asp:ListItem>
							<asp:ListItem Value="1">Khoa</asp:ListItem>
							<asp:ListItem Value="2">Khóa</asp:ListItem>
							<asp:ListItem Value="3">Lớp</asp:ListItem>
						</asp:DropDownList>
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
