<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCatAuthority" CodeFile="WCatAuthority.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCatAuthority</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/assert/setlogmod.css" rel="stylesheet" />
        <link href="../../Resources/Controls/GridView.css" rel="stylesheet" />
        <link href="../../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
		    
               <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
			<table width="100%" border="0">
				<TR class="lbPageTitle">
					<TD width="100%">
						<asp:Label id="lblHeader" runat="server" CssClass="lbPageTile">Dữ liệu căn cứ</asp:Label></TD>
				</TR>
				<tr>
					<td width="100%">
					    
                        
                         <telerik:RadGrid ID="dtgCatAuthor" runat="server" AllowPaging="True"
                                CellSpacing="0"
                                AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgCatAuthor_NeedDataSource">
                                <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                    <PagerStyle AlwaysVisible="True" />
                                    <FooterStyle BackColor="White"></FooterStyle>

                                    <Columns>
                                       <telerik:GridBoundColumn DataField="DisplayEntry" HeaderText="Nội dung"></telerik:GridBoundColumn>
								<telerik:GridBoundColumn DataField="AccessEntry" HeaderText="Mục từ"></telerik:GridBoundColumn>


                                    </Columns>
                                    <PagerTemplate>
                                        <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                    </PagerTemplate>
                                </MasterTableView>

                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                            </telerik:RadGrid>
                        

						<%--<asp:DataGrid id="dtgCatAuthor" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True"
							PageSize="15">
							<Columns>
								<asp:BoundColumn DataField="DisplayEntry" HeaderText="Nội dung"></asp:BoundColumn>
								<asp:BoundColumn DataField="AccessEntry" HeaderText="Mục từ"></asp:BoundColumn>
							</Columns>
							<PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>--%>
					</td>
				</tr>
			</table>
			<asp:Label ID="lblLabel0" Runat="server" Visible="False">Bạn không được cấp quyền sử dụng chức năng này</asp:Label>
			<asp:Label ID="lblLabel1" Runat="server" Visible="False">Tạo mới</asp:Label>
			<asp:Label ID="lblLabel2" Runat="server" Visible="False">Mã lỗi</asp:Label>
			<asp:Label ID="lblLabel3" Runat="server" Visible="False">Chi tiết lỗi</asp:Label>
			<asp:Label ID="lblLabel4" Runat="server" Visible="False">Dữ liệu căn cứ : </asp:Label>
			<asp:DropDownList ID="ddlAboutAction" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Bạn thực sự muốn xoá mẫu Từ điển này?</asp:ListItem>
				<asp:ListItem Value="1">Mẫu danh mục mới chưa được ghi nhận</asp:ListItem>
				<asp:ListItem Value="2">Cập nhật mẫu danh mục thành công</asp:ListItem>
				<asp:ListItem Value="3">Đã ghi nhận mẫu mẫu danh mục mới</asp:ListItem>
				<asp:ListItem Value="4">Bạn chưa nhập tên mẫu danh mục</asp:ListItem>
				<asp:ListItem Value="5">Mẫu danh mục mới đã được ghi nhận</asp:ListItem>
				<asp:ListItem Value="6">"Insert: "</asp:ListItem>
				<asp:ListItem Value="7">"Update: "</asp:ListItem>
				<asp:ListItem Value="8">"Delete: "</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
