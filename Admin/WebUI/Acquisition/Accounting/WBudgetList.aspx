<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WBudgetList" CodeFile="WBudgetList.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WBudgetList</title>
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
                <asp:Label runat="server" ID="lblReportTitle" CssClass="main-head-form">Báo cáo quỹ</asp:Label>
                <asp:Label runat="server" ID="lblSpendTitle" CssClass="main-head-form">Khai báo chi</asp:Label>
                <asp:Label runat="server" ID="lblReceiveTitle" CssClass="main-head-form">Khai báo thu</asp:Label>
                <div class="input-control row-detail">
                    <div class="table-form">
                        
                               <telerik:RadGrid ID="dgtBudget" runat="server" AllowPaging="True"
                                CellSpacing="0"
                                AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dgtBudget_NeedDataSource">
                                <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                    <PagerStyle AlwaysVisible="True" />
                                    <FooterStyle BackColor="White"></FooterStyle>

                                    <Columns>
                                     
                                         <telerik:GridTemplateColumn HeaderText="T&#234;n quỹ">
                                    <ItemStyle HorizontalAlign="Center" Width="25%"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="lnkBudgetName" >
											<%# DataBinder.Eval(Container, "DataItem.BudgetName") %>
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Purpose" HeaderText="Mục đ&#237;ch">
                                    <ItemStyle Width="25%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Balance" HeaderText="Số tiền sau khi đ&#227; trừ đi c&#225;c khoản dự chi" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RealBalance" HeaderText="Số tiền tồn" DataFormatString="{0:N0}">
                                    <ItemStyle HorizontalAlign="Right" Width="20%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Currency" HeaderText="Đơn vị tiền tệ">
                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                </telerik:GridBoundColumn>

                                    </Columns>
                                    <PagerTemplate>
                                        <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                    </PagerTemplate>
                                </MasterTableView>

                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                            </telerik:RadGrid>
                        
                        

                      
                    </div>
                </div>
            </div>
            <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
                <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
                <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
