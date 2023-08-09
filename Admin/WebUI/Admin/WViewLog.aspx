<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WViewLog" EnableViewStateMac="False" CodeFile="WViewLog.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>


<%@ Register Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" TagPrefix="gusc" TagName="RadGridPagerUSC" %>
<%@ Register Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" TagPrefix="gusca" TagName="RadGridPagerUSC1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WViewLog</title>
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
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="dtgEvents">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="dtgEvents" />
                    </UpdatedControls>
                </telerik:AjaxSetting>

            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
            
        </telerik:RadScriptBlock>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <div id="divBody">
            <div class="center-form indexlog">
                <div class="content-form">
                    <h1 class="main-head-form">Kết quả tra cứu log
                        <asp:HyperLink ID="lnkSearch" runat="server">Tìm mới</asp:HyperLink></h1>
                    <br />
                    <div class="input-control">
                        <div class="table-form">




<%--                            <telerik:RadGrid ID="dtgLog" AllowPaging="False" runat="server"
                                OnNeedDataSource="dtgLog_NeedDataSource">
                                <MasterTableView>
                                   
                                </MasterTableView>
                            </telerik:RadGrid>--%>




                            <%-- <telerik:RadGrid ID="dtgLog" runat="server" AllowPaging="True"
                                CellSpacing="0"
                                AutoGenerateColumns="False" Skin="Office2010Black"  GridLines="None">
                                <MasterTableView TableLayout="Auto" EditMode="InPlace">
                                    <PagerStyle AlwaysVisible="True" />
                                    <Columns>
                                       <telerik:GridBoundColumn DataField="Event" HeaderText="Sự kiện" UniqueName="Event">
                                           
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="User" HeaderText="Người dùng" UniqueName="User">
                                         
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Workstation" HeaderText="Máy trạm" UniqueName="Workstation">
                                        
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="LogTime" HeaderText="Thời điểm" UniqueName="LogTime">
                                         
                                        </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ID" HeaderText="Tên sự kiện" UniqueName="ID">
                                           
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <PagerTemplate>
                                        <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                    </PagerTemplate>
                                </MasterTableView>

                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                            </telerik:RadGrid>--%>

                         <%--    <asp:DataGrid ID="dtgLog1" runat="server" Width="100%" AutoGenerateColumns="False" AlternatingItemStyle-CssClass="lbGridAlterCell"
                                ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" HeaderStyle-HorizontalAlign="Center"
                                FooterStyle-CssClass="lbGridFooter" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-Position="TopAndBottom"
                                PageSize="50" >
                                <Columns>
                                    <asp:BoundColumn DataField="Event" HeaderText="Sự kiện"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="User" HeaderText="Người dùng" ItemStyle-Width="12%"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Workstation" HeaderText="Máy trạm" ItemStyle-Width="10%"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="LogTime" HeaderText="Thời điểm" ItemStyle-Width="12%"></asp:BoundColumn>
                                </Columns>
                            </asp:DataGrid>--%>
                            
                            
                            
                            
                            
                              <telerik:RadGrid ID="dtgLog" runat="server" AllowPaging="True"
                                CellSpacing="0"
                                AutoGenerateColumns="False" Skin="Office2010Black" AllowMultiRowSelection="True" GridLines="None">
                                
                                <MasterTableView TableLayout="Auto" DataKeyNames="Event"
                ClientDataKeyNames="Event" EditMode="InPlace">

                                    <PagerStyle AlwaysVisible="True" />
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="Event" HeaderText="Tên sự kiện" UniqueName="Event">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="User" HeaderText="Người dùng" UniqueName="User">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Workstation" HeaderText="Máy trạm" UniqueName="Workstation">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="LogTime" HeaderText="Thời điểm" UniqueName="LogTime">
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
            </div>
        </div>
        <input type="hidden" id="hidWord" runat="server" />
        <input type="hidden" id="hidGroup" runat="server" />
        <input type="hidden" id="hidUser" runat="server" />
        <input type="hidden" id="hidFromDate" runat="server" />
        <input type="hidden" id="hidToDate" runat="server" />
        <input type="hidden" id="hidFromTime" runat="server" />
        <input type="hidden" id="hidToTime" runat="server" />
        <asp:DropDownList runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Không có dữ liệu thoả mãn điều kiện tìm kiếm!</asp:ListItem>
            <asp:ListItem Value="3">Không có dữ liệu thoả mãn điều kiện tìm kiếm!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
