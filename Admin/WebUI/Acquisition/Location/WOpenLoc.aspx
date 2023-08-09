<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WOpenLoc" CodeFile="WOpenLoc.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WOpenLoc</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
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
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Mở kho</h1>
                <div class="row-detail">
                    <p>Thư viện :</p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlLibrary" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="input-control row-detail">
                    <div class="table-form">
                       <%-- <asp:DataGrid ID="dtgLocation" CssClass="table-control" runat="server" CellPadding="3" PageSize="8" AllowPaging="True" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Symbol" HeaderText="Kho"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Chọn">
                                    <HeaderStyle Width="5%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <input type="checkbox" ID="cbkdtgLocation" runat="server"></input>
                                        <label for="cbkdtgLocation"></label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>--%>
                        
                        
                                 <telerik:RadGrid ID="dtgLocation" runat="server" AllowPaging="False"
                                CellSpacing="0"
                                AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgLocation_NeedDataSource">
                                <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                    <PagerStyle AlwaysVisible="True" />
                                    <FooterStyle BackColor="White"></FooterStyle>

                                    <Columns>
                                        
                                        
                                        <telerik:GridBoundColumn Display="False" DataField="ID" ReadOnly="True" HeaderText="ID"></telerik:GridBoundColumn>
								<telerik:GridBoundColumn DataField="Symbol" HeaderText="Kho"></telerik:GridBoundColumn>
								<telerik:GridTemplateColumn HeaderText="Chọn" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="6%">
									<ItemTemplate>
										<input  type="checkbox" id="cbkdtgLocation" class="ckb-value" Runat="server"></input>
                                        <label for="cbkdtgLocation"></label>
									</ItemTemplate>
								</telerik:GridTemplateColumn>

                                    </Columns>
                                    <PagerTemplate>
                                        <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                    </PagerTemplate>
                                </MasterTableView>

                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                            </telerik:RadGrid>
                        

                    </div>

                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                             <asp:Button CssClass="text-input form-btn" ID="btnOpenLoc" runat="server" Text="Mở kho(u)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>


               <%-- <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <input type="button" value="Cập nhật" class="form-btn" />
                        </div>
                        <div class="button-form">
                            <input type="button" value="Đặt lại" class="form-btn" />
                        </div>
                    </div>
                </div>--%>
            </div>
        <asp:DropDownList ID="ddlLabelNote" runat="server" Visible="False" Width="0" Height="0">
            <asp:ListItem Value="0">--------Hiện tất cả--------</asp:ListItem>
            <asp:ListItem Value="1">Bạn phải chọn ít nhất một kho!</asp:ListItem>
            <asp:ListItem Value="2">Bạn có muốn mở (các) kho đã chọn không?</asp:ListItem>
            <asp:ListItem Value="3">Mở kho thành công!</asp:ListItem>
            <asp:ListItem Value="4">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="5">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="6">Mở (các) kho tại</asp:ListItem>
            <asp:ListItem Value="7">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="8">Tất cả các kho đang được mở!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
