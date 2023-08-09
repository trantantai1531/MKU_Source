<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WRequestModeMan" CodeFile="WRequestModeMan.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WRequestModeMan</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
			    
                <div id="divBody">
        	<h1 class="main-head-form"><asp:Label Runat="server" id="lblMainTitle" CssClass="lbPageTitle">Danh mục các phương thức giao nhận</asp:Label>
					</h1>
            <div class="two-column ClearFix">
                <div class="col-left-4 row-detail">
                	<div class="dropdown-form">
                		<div class="input-control">
                 		<asp:ListBox id="lstRequestMode" runat="server" Height="120px"></asp:ListBox>
                		</div>
                	</div>
                </div>
            </div>
            <div class="row-detail col-left-4">
            	<p><asp:Label Runat="server" id="lblSubTitle2">Phương thức</asp:Label></p>
            	<div class="input-control">
                	<asp:TextBox Runat="server" ID="txtRequestMode" Width="120px"></asp:TextBox>&nbsp;
            	</div>                                          
            </div>
            <div class="ClearFix"></div>            
            <div class="row-detail ">
                <div class="button-control inline-box">
                    <div class="button-form">
                        
						<asp:Button Runat="server" ID="btnAddNew" CssClass="form-btn" Text="Nhập mới"></asp:Button>&nbsp;
						
                    </div>
                    <div class="button-form">
                      <asp:Button id="btnUpdate" Runat="server" CssClass="form-btn" Text="Cập nhật" Enabled="False"></asp:Button>&nbsp;
                    </div>
                    <div class="button-form">
                        <asp:Button id="btnDelete" Runat="server" CssClass="form-btn" Text="Xoá" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;
                    </div>
             	</div>
        	</div>
        </div>
                
                
                

				<TR class="lbPageTitle">
					<TD>
						<%--<asp:Label Runat="server" id="lblMainTitle" CssClass="lbPageTitle">Danh mục các phương thức giao nhận</asp:Label>
					--%></TD>
				</TR>
				<TR>
					<TD>
						<%--<asp:ListBox id="lstRequestMode" runat="server" Height="120px"></asp:ListBox>--%>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR>
					<TD>
						<%--<asp:Label Runat="server" id="lblSubTitle2">Phương thức</asp:Label>--%>
					</TD>
				</TR>
				<tr>
					<td class="lbGroupTitle">
						<%--<asp:TextBox Runat="server" ID="txtRequestMode" Width="120px"></asp:TextBox>&nbsp;
						<asp:Button Runat="server" ID="btnAddNew" Text="Nhập mới"></asp:Button>&nbsp;
						<asp:Button id="btnUpdate" Runat="server" Text="Cập nhật" Enabled="False"></asp:Button>&nbsp;
						<asp:Button id="btnDelete" Runat="server" Text="Xoá" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;--%>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="lblAddNew" Visible="False" Runat="server">-------NHẬP MỚI-------</asp:Label>
						<asp:Label id="lblError" Visible="False" Runat="server">Phương thức đã tồn tại, nhập tên khác</asp:Label>
						<asp:Label id="lblMsg" Runat="server" Visible="False">Bạn cần nhập tên phương thức</asp:Label>
						<asp:Label Runat="server" ID="lblLabel1" Visible="False">Bạn không được cấp quyền khai thác tính năng này</asp:Label>
						<asp:Label Runat="server" ID="lblLabel2" Visible="False">Mã lỗi</asp:Label>
						<asp:Label Runat="server" ID="lblLabel3" Visible="False">Chi tiết lỗi</asp:Label>
						<asp:Label id="lblConfirm" Runat="server" Visible="False">Bạn có chắc chắn muốn xoá phương thức giao nhận này không?</asp:Label>
						<asp:DropDownList Runat="server" ID="ddlLog" Width="0" Height="0" Visible="False" Enabled="False">
							<asp:ListItem Value="0">Nhập mới phương thức giao nhận</asp:ListItem>
							<asp:ListItem Value="1">Cập nhật phương thức giao nhận</asp:ListItem>
							<asp:ListItem Value="2">Xoá phương thức giao nhận</asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
			</TABLE>
		</form>
		<script language = javascript>
			document.forms[0].txtRequestMode.focus();
		</script>
	</body>
</HTML>
