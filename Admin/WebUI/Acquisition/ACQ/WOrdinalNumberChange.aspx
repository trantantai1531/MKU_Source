<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WOrdinalNumberChange" CodeFile="WOrdinalNumberChange.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WOrdinalNumberChange</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="1" leftmargin="0">
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
                <asp:Label ID="lblMainTitle" runat="server" CssClass="main-head-form">" Width="100%">Thiết đặt số thứ tự</asp:Label>
                <p>Thiết đặt giá trị của số thứ tự xuất phát (theo từng kho) để làm căn cứ cho việc sinh tự động ĐKCB.</p>
                <div class="input-control">
                    <div class="table-form">
                        
                         <telerik:RadGrid ID="dtgContent" runat="server" AllowPaging="False"
                                CellSpacing="0"
                                AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgContent_NeedDataSource">
                                <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                    <PagerStyle AlwaysVisible="True" />
                                    <FooterStyle BackColor="White"></FooterStyle>
                                    <Columns>
                                        <telerik:GridBoundColumn Visible="False" DataField="ID"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Title" HeaderText="Thư viện">
                                            <HeaderStyle></HeaderStyle>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Symbol" HeaderText="Kho">
                                            <HeaderStyle Width="12%"></HeaderStyle>
                                        </telerik:GridBoundColumn>
                                        <telerik:GridTemplateColumn HeaderText="Số thứ tự hiện thời">
                                            <HeaderStyle Width="16%"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MaxNumber") %>' ID="txtdtgMaxNumber" CssClass="lbTextBox" Width="">
                                                </asp:TextBox>
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
                    <div class="button-control" style="text-align: right">
                        <div class="button-form">
                            <asp:Button ID="btnUpdateAll" CssClass="form-btn" runat="server" Text="Thiết đặt(s)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabelNote" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="3">Trường giá trị còn rỗng!</asp:ListItem>
            <asp:ListItem Value="4">Giá trị không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="5">Cập nhập thành công!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
