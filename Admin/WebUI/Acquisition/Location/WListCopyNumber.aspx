<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WListCopyNumber" CodeFile="WListCopyNumber.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WListCopyNumber</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
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
        <table cellspacing="1" cellpadding="1" width="100%">
            <tr class="lbPageTitle">
                <td align="center" colspan="3">
                    <asp:Label CssClass="lbPageTitle" ID="lblTitle" runat="server">Danh sách đăng ký cá biệt</asp:Label></td>
            </tr>
            <tr>
                <td width="60%">
                    <asp:Label ID="lblLibrary" runat="server">Thư viện:</asp:Label>&nbsp;<asp:Label ID="lblLibName" runat="server" CssClass="lbAmount"></asp:Label></td>
                <td width="20%">
                    <asp:Label ID="lblLocation" runat="server">Kho:</asp:Label>&nbsp;<asp:Label ID="lblLocName" runat="server" CssClass="lbAmount"></asp:Label></td>
                <td>
                    <asp:Label ID="lblShelf" runat="server">Giá:</asp:Label>&nbsp;<asp:Label ID="lblShelfName" runat="server" CssClass="lbAmount"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="3">

                    <telerik:RadGrid ID="dtgCopyNumber" runat="server" AllowPaging="True"
                        CellSpacing="0"
                        AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgCopyNumber_NeedDataSource">
                        <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                            <PagerStyle AlwaysVisible="True" />
                            <FooterStyle BackColor="White"></FooterStyle>

                            <Columns>
                                <telerik:GridBoundColumn DataField="OrderNum" HeaderText="TT">
                                    <HeaderStyle ForeColor="White" Width="20px"></HeaderStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Content" SortExpression="0" HeaderText="Nhan đề">
                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White" Width="55%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Shelf" SortExpression="1" HeaderText="Giá">
                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White" Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CallNumber" SortExpression="2" HeaderText="Số định danh">
                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White" Width="15%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Copynumber" SortExpression="3" HeaderText="ĐKCB">
                                    <HeaderStyle HorizontalAlign="Center" ForeColor="White" Width="15%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn>
                                    <HeaderTemplate>
                                        <input class="lbCheckBox" type="checkbox" id="CheckAll" onclick="javascript: CheckAllOptionsVisibleByCssClass('ckb-value', 'ckbdtgCopyNumber', 2, 50);">
                                         <label for="c1"></label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input id="ckbdtgCopyNumber" type="checkbox" runat="server"  class="ckb-value"></input>
                                         <label for="c2"></label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <PagerTemplate>
                                <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                            </PagerTemplate>
                        </MasterTableView>

                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                    </telerik:RadGrid>



              <%--      <asp:DataGrid ID="dtgCopyNumber" runat="server" AllowPaging="True" PageSize="30" AutoGenerateColumns="False"
                        AllowSorting="True" Height="112px" Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="OrderNum" HeaderText="TT">
                                <HeaderStyle ForeColor="White" Width="20px"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Content" SortExpression="0" HeaderText="Nhan đề">
                                <HeaderStyle HorizontalAlign="Center" ForeColor="White" Width="55%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Shelf" SortExpression="1" HeaderText="Giá">
                                <HeaderStyle HorizontalAlign="Center" ForeColor="White" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CallNumber" SortExpression="2" HeaderText="Số định danh">
                                <HeaderStyle HorizontalAlign="Center" ForeColor="White" Width="15%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Copynumber" SortExpression="3" HeaderText="ĐKCB">
                                <HeaderStyle HorizontalAlign="Center" ForeColor="White" Width="15%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate>
                                    <input class="lbCheckBox" type="checkbox" id="CheckAll" onclick="javascript: CheckAllOptionsVisible('dtgCopyNumber', 'ckbdtgCopyNumber', 3, 30);">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckbdtgCopyNumber" runat="server" CssClass="lbCheckBox"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Position="Top" PageButtonCount="100" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>--%>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="3">
                    <asp:Button ID="btnCopyNumber" runat="server" Text="Chấp nhận(c)"></asp:Button>&nbsp;<asp:Button ID="btnClose" runat="server" Text="Đóng(d)"></asp:Button></td>
            </tr>
        </table>
        <input id="hidLibID" type="hidden" name="hidLibID" runat="server">
        <input id="hidLocID" type="hidden" name="hidLocID" runat="server">
        <input id="hidTypeSort" type="hidden" name="hidTypeSort" runat="server">
        <asp:DropDownList ID="ddlLabelNote" runat="server" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn phải chọn ít nhất một đăng ký cá biệt!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
