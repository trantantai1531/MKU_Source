<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WStatTop20" CodeFile="WStatTop20.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatTop20</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0" onload="if (eval(document.images['Image1']) &amp;&amp; eval(document.images['Image2'])) {GenURLImg1(9);}">
		<form id="Form1" method="post" runat="server">
		    <div id="divBody">
        	<h1 class="main-head-form"><asp:label id="lblHeader" Runat="server" CssClass="lbPageTitle"> Thống kê top 20 tài liệu điện tử được yêu cầu mua nhiều nhất </asp:label></h1>
            <div class="two-column ClearFix">
                <div class="two-column-form">
                	<div class="row-detail">
                    <p><asp:label id="lblPropertier" Runat="server" CssClass=""> Thống kê theo thuộc tính:</asp:label></p>
                        <div class="input-control">
                      		<div class="dropdown-form">
                        			<asp:dropdownlist id="ddlPropertyType" runat="server"></asp:dropdownlist>
                      		</div>
                    	</div>                                          
                   	</div>
                    <div class="row-detail"></div>
                </div> 
            </div>
            <div class="row-detail">
                <div class="button-control inline-box">
                    <div class="button-form">
                       <asp:button id="btnStatistic" Runat="server" CssClass="lbButton" Width="94px" Text="Thống kê (t)"></asp:button>
                    </div>
                </div>
            </div>
        </div>
            
            
            
            

			<TABLE id="Table2" cellSpacing="1" cellPadding="2" width="100%" border="0" runat="server">
				<TR Class="lbSubformTitle">
					<TD>
						<asp:label id="lblTitleChartBarItem2" Runat="server" CssClass="lbSubformTitle" Width="100%">Biểu đồ hình cột</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><IMG src="" useMap="#map1" border="0" name="Image1"></TD>
				</TR>
				<tr Class="lbSubformTitle">
					<TD><asp:label id="lblTitleChartBarCopynumber2" Runat="server" CssClass="lbSubformTitle" Width="100%">Biểu đồ hình tròn</asp:label></TD>
				</tr>
				<TR>
					<TD align="center"><IMG src="" border="0" name="Image2"></TD>
				</TR>
			</TABLE>
			<TABLE id="Table3" cellSpacing="1" cellPadding="2" width="100%" border="0" runat="server">
				<TR>
					<TD align="center"><asp:label id="lblNoStatic" Runat="server" CssClass="lbLabel">Không có thông tin thống kê </asp:label></TD>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Tỷ lệ các lượt đặt mua theo thuộc tính</asp:ListItem>
				<asp:ListItem Value="1">--- Chọn thuộc tính ---</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="3">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="4">Chi tiết lỗi</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
