<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WDicAuthority" CodeFile="WDicAuthority.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WDicAuthority</title>
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
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <h1 class="main-head-form">Quản lý chỉ mục dựng sẵn</h1>
                        <div class="input-control row-detail">
                            <div class="table-form">

                                <telerik:RadGrid ID="DtgDictionary" runat="server" AllowPaging="True"
                                    CellSpacing="0"
                                    AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="DtgDictionary_NeedDataSource">
                                    <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                        <PagerStyle AlwaysVisible="True" />
                                        <FooterStyle BackColor="White"></FooterStyle>

                                        <Columns>
                                            <telerik:GridBoundColumn DataField="Name" HeaderText="T&#234;n chỉ mục"></telerik:GridBoundColumn>
                                            <telerik:GridHyperLinkColumn Text="&lt;img src='../images/update.gif' border='0'&gt;" DataNavigateUrlFields="ShowAuthor"
                                                HeaderText="Duyệt">
                                                <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                            </telerik:GridHyperLinkColumn>
                                            <telerik:GridHyperLinkColumn DataNavigateUrlFields="ShowClass" DataTextField="ShowClassText" HeaderText="Cập nhật">
                                                <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                            </telerik:GridHyperLinkColumn>
                                        </Columns>
                                        <PagerTemplate>
                                            <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                        </PagerTemplate>
                                    </MasterTableView>

                                    <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                                </telerik:RadGrid>





                                <%--                            <asp:DataGrid ID="DtgDictionary" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                Width="100%" PageSize="20">
                                <Columns>
                                    <asp:BoundColumn DataField="Name" HeaderText="T&#234;n chỉ mục"></asp:BoundColumn>
                                    <asp:HyperLinkColumn Text="&lt;img src='../images/update.gif' border='0'&gt;" DataNavigateUrlField="ShowAuthor"
                                        HeaderText="Duyệt">
                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                    </asp:HyperLinkColumn>
                                    <asp:HyperLinkColumn DataNavigateUrlField="ShowClass" DataTextField="ShowClassText" HeaderText="Cập nhật">
                                        <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                    </asp:HyperLinkColumn>
                                </Columns>
                                <PagerStyle Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <%--     <div class="two-column-form">
                    <h1 class="main-head-form">Quản lý từ điển tự tạo</h1>
                    <div class="input-control row-detail">
                        <div class="table-form">
                            <table class="table-control" cellpadding="0" cellspacing="0" width="100%" border="1">
                                <tr class="row-head">
                                    <td width="60%">Tên từ điển tự tạo</td>
                                    <td width="10%">Cán bộ</td>
                                    <td width="10%">Bạn đọc</td>
                                    <td width="10%">Kích thước</td>
                                    <td width="5%">Sửa</td>
                                    <td width="5%">Xoá</td>
                                </tr>
                                <tr>
                                    <td>Số Tổng Quát</td>
                                    <td align="center">
                                    	<div class="checkbox-control">
                                            <input id="c1" type="checkbox" name="check" value="check1" checked="checked">
                                            <label for="c1"></label>
                                        </div>
                                    </td>
                                    <td align="center">
                                    	<div class="checkbox-control">
                                            <input id="c2" type="checkbox" name="check" value="check1" checked="checked">
                                            <label for="c2"></label>
                                        </div>
                                    </td>
                                    <td align="center">4000</td>
                                    <td align="center"><a href="#" class="link-control"><span class="icon-checkmark"></span></a></td>
                                    <td align="center"><a href="#" class="link-control"><span class="icon-remove"></span></a></td>
                                </tr>
                                <tr class="row-second">
                                     <td>Từ Điển</td>
                                    <td align="center">
                                    	<div class="checkbox-control">
                                            <input id="c1" type="checkbox" name="check" value="check1" checked="checked">
                                            <label for="c1"></label>
                                        </div>
                                    </td>
                                    <td align="center">
                                    	<div class="checkbox-control">
                                            <input id="c2" type="checkbox" name="check" value="check1" checked="checked">
                                            <label for="c2"></label>
                                        </div>
                                    </td>
                                    <td align="center">4000</td>
                                    <td align="center"><a href="#" class="link-control"><span class="icon-checkmark"></span></a></td>
                                    <td align="center"><a href="#" class="link-control"><span class="icon-remove"></span></a></td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <input type="button" class="table-btn" value="1">
                                        <input type="button" class="table-btn" value="2">
                                        <input type="button" class="table-btn" value="3">
                                    </td>
                                </tr>
                                <tr class="row-total">
                                    <td>
                                    	<div class="input-form">
                                            <input type="text" class="text-input">
                                        </div>
                                    </td>
                                    <td align="center">
                                    	<div class="checkbox-control">
                                            <input id="c3" type="checkbox" name="check" value="check1" checked="checked">
                                            <label for="c3"></label>
                                        </div>
                                    </td>
                                    <td align="center">
                                    	<div class="checkbox-control">
                                            <input id="c4" type="checkbox" name="check" value="check1" checked="checked">
                                            <label for="c4"></label>
                                        </div>
                                    </td>
                                    <td align="center">
                                    	<div class="input-form">
                                            <input type="text" class="text-input">
                                        </div>
                                    </td>
                                    <td align="center" colspan="2"><input type="button" class="table-btn" value="Thêm"></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
