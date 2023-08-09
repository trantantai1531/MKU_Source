<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WItemModify" CodeFile="WItemModify.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WItemModify</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftmargin="0" topmargin="0">
		<form id="Form1" method="post" runat="server">
	<div id="divBody">
        	<h1 class="main-head-form">Sửa bản ghi</h1>
            <div class="row-detail">
                <p>Nhập mã tài liệu của bản ghi biên mục cần sửa hoặc bấm "<asp:HyperLink ID="lnkSearchItem" ForeColor="Red"  Runat="server" NavigateUrl="WSearchItemCode.aspx">Tìm</asp:HyperLink>" để xác định giá trị này.</p>
                <div class="ClearFix"></div>
                <div class="input-form span3">
                    <asp:TextBox id="txtItemCode" CssClass="text-input" runat="server"></asp:TextBox>
                </div>
                
                <div class="button-control inline-box span2">
                    <div class="button-form">
                        <asp:Button id="btnModify" CssClass="form-btn" runat="server" Text="Sửa(s)"></asp:Button>
                    </div>
                </div>

            </div>
           
        </div>
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Height="0" Width="0">
				<asp:ListItem Value="0">Bạn chưa nhập mã tài liệu!</asp:ListItem>
				<asp:ListItem Value="1">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
				<asp:ListItem Value="2">Không tìm thấy mã tài liệu này !</asp:ListItem>
			</asp:DropDownList>
		</form>
		<script language = javascript>
			document.forms[0].txtItemCode.focus();
		</script>

	</body>
</HTML>
