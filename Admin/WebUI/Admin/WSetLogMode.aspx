<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WSetLogMode" CodeFile="WSetLogMode.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" TagPrefix="gusc" TagName="RadGridPagerUSC" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSetLogMode</title>

    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
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
            <div class="main-body set-log-mod">
                <div class="content-form">
                    <h1 class="main-head-form">Thiết lập chế độ ghi nhật ký</h1>
                    <div class="row-detail inline-box">
                        <asp:Label ID="lblGroup" runat="server"><U>N</U>hóm sự kiện:</asp:Label>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="input-control">
                        <div class="table-form">
                            <telerik:RadGrid ID="dtgEvents" runat="server" AllowPaging="False"
                                CellSpacing="0"
                                AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgEvents_NeedDataSource">
                                <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                    <PagerStyle AlwaysVisible="True" />
                                    <FooterStyle BackColor="White"></FooterStyle>

                                    <Columns>
                                        <telerik:GridTemplateColumn Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                        <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="Template Column" Visible="True">
                                            <HeaderStyle Width="5%" />
                                            <HeaderTemplate>
                                                <input class="lbCheckBox" type="checkbox" id="chkCheckAll" onclick="javascript: CheckAllOptionsVisibleByCssClass('ckb-value', 'chkID', 2, 50);">
                                                <label for="c1"></label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <input id="chkID" type="checkbox" checked='<%# DataBinder.Eval(Container.dataItem,"LogMode") %>' class="ckb-value" runat="server">

                                                <label for="c2"></label>
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        </telerik:GridTemplateColumn>


                                        <telerik:GridBoundColumn DataField="VietName" HeaderText="Tên sự kiện" UniqueName="VietName">
                                            <HeaderStyle Width="90%"></HeaderStyle>
                                        </telerik:GridBoundColumn>
                                        <%--  <telerik:GridBoundColumn DataField="LogMode"  HeaderText="Tên sự kiện" UniqueName="LogMode"><HeaderStyle Width="5%"></HeaderStyle>
                                           
                                        </telerik:GridBoundColumn>--%>
                                    </Columns>
                                    <PagerTemplate>
                                        <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                    </PagerTemplate>
                                </MasterTableView>

                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                            </telerik:RadGrid>

                            <br />
                            <br />

                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnUpdate" runat="server" Width="90px" Text="Cập nhật(u)"></asp:Button>

                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>

        <asp:DropDownList runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn phải chọn ít nhất một sự kiện trước khi cập nhật!</asp:ListItem>
            <asp:ListItem Value="3">Cập nhật thành công!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
