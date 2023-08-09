<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WOverdueList" CodeFile="WOverdueList.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WOverdueList</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
    <link href="../../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .RadGrid_Office2010Black .rgRow td, .RadGrid_Office2010Black .rgAltRow td
        {
            line-height:25px;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
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
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head" id="tabMuonVe">
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkOverdueTemplate" runat="server" NavigateUrl="WOverdueTemplate.aspx">Mẫu quá hạn</asp:HyperLink></li>
                    <li class="TabbedPanelsTab activetab" tabindex="0">
                        <asp:Label ID="lblOverduelist" runat="server" CssClass="lbGroupTitleSmall">Quá hạn</asp:Label></li>
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkOverduePrintLetter" runat="server" NavigateUrl="WOverduePrintLetter.aspx">In quá hạn</asp:HyperLink></li>
                    <li class="TabbedPanelsTab " tabindex="0">
                        <asp:HyperLink ID="lnkOverdueSendEmail" runat="server" NavigateUrl="WOrverdueSendMail.aspx">Gửi Email</asp:HyperLink>
                    </li>
                </ul>
            </div>
            <div class="main-form">
                <div class="row-detail">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="lblNoListOverdue" runat="server" Visible="False">Hiện tại không có bạn đọc nào quá hạn mượn.</asp:Label>
                            </td>
                            <td style="width:200px;">
                                <div class="row-detail">
                                    <p>Nhóm bạn đọc</p>
                                    <div class="input-control">
                                        <div class="dropdown-form">
                                            <asp:DropDownList ID="ddlPatronGroup" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </td>
                            <td style="width:200px;">
                                <div class="row-detail">
                                    <p>Đơn vị</p>
                                    <div class="input-control">
                                        <div class="dropdown-form">
                                            <asp:DropDownList ID="ddlFaculty" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                
                            </td>
                            <td align="right" style="width:200px;">
                                <p>&nbsp;</p>
                                <div class="row-detail">
                                    <div class="button-control">
                                        <div class="button-form">
                                            <asp:Button CssClass="lbButton" ID="btnStatis" runat="server" Text="Danh sách"></asp:Button>
                                            <asp:Button CssClass="lbButton" ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="table-form">
                    <telerik:RadGrid ID="dgrOverdue" runat="server" AllowPaging="True" CellSpacing="0" AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dgrOverdue_NeedDataSource" AllowSorting="True">
                        <MasterTableView TableLayout="Auto" DataKeyNames="LOANID" EditMode="InPlace">
                            <PagerStyle AlwaysVisible="True" />
                            <FooterStyle BackColor="White"></FooterStyle>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Index" ReadOnly="True" HeaderText="STT" AllowSorting="false">
                                    <ItemStyle HorizontalAlign="Center" Width="2.5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Name" AllowSorting="false" SortExpression="Name" ReadOnly="True" HeaderText="Bạn đọc">
                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PatronCode" AllowSorting="false" ReadOnly="True" HeaderText="Số thẻ">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="MainTitle" AllowSorting="false" SortExpression="MainTitle" ReadOnly="True" HeaderText="Nhan đề">
                                    <ItemStyle HorizontalAlign="Center" Width="30%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CopyNumber" AllowSorting="false" SortExpression="CopyNumber" ReadOnly="True" HeaderText="ĐKCB">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CheckOutDate" AllowSorting="false" SortExpression="CheckOutDate" ReadOnly="True" HeaderText="Ngày mượn">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </telerik:GridBoundColumn>                               
                                <telerik:GridBoundColumn DataField="CheckInDate" AllowSorting="false" SortExpression="CheckInDate" ReadOnly="True" HeaderText="Hạn trả">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OverdueDate" AllowSorting="false" SortExpression="OverdueDate" ReadOnly="True" HeaderText="Quá hạn (ngày)">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn DataField="Email" AllowSorting="false" SortExpression="Email" ReadOnly="True" HeaderText="Email">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Note" AllowSorting="false" SortExpression="Note" ReadOnly="True" HeaderText="Ghi chú">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CataloguerName" AllowSorting="false" SortExpression="CataloguerName" ReadOnly="True" HeaderText="Người cho mượn">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                            </Columns>
                            <PagerTemplate>
                                <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                            </PagerTemplate>
                        </MasterTableView>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    </telerik:RadGrid>

                    <%--<telerik:RadGrid ID="dgrOverdue" runat="server" AllowPaging="True" CellSpacing="0" AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dgrOverdue_NeedDataSource" AllowSorting="True">
                        <MasterTableView TableLayout="Auto" DataKeyNames="LOANID" EditMode="InPlace">
                            <PagerStyle AlwaysVisible="True" />
                            <FooterStyle BackColor="White"></FooterStyle>
                            <Columns>
                                <telerik:GridBoundColumn DataField="Index" ReadOnly="True" HeaderText="STT" AllowSorting="false">
                                    <ItemStyle HorizontalAlign="Center" Width="2.5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Name" AllowSorting="false" SortExpression="Name" ReadOnly="True" HeaderText="Bạn đọc">
                                    <ItemStyle HorizontalAlign="Center" Width="12.5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PatronCode" AllowSorting="false" ReadOnly="True" HeaderText="Số thẻ">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="MainTitle" AllowSorting="false" SortExpression="MainTitle" ReadOnly="True" HeaderText="Nhan đề">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CopyNumber" AllowSorting="false" SortExpression="CopyNumber" ReadOnly="True" HeaderText="ĐKCB">
                                    <ItemStyle HorizontalAlign="Center" Width="7.5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CheckOutDate" AllowSorting="false" SortExpression="CheckOutDate" ReadOnly="True" HeaderText="Ngày mượn">
                                    <ItemStyle HorizontalAlign="Center" Width="7.5%"></ItemStyle>
                                </telerik:GridBoundColumn>                               
                                <telerik:GridBoundColumn DataField="CheckInDate" AllowSorting="false" SortExpression="CheckInDate" ReadOnly="True" HeaderText="Hạn trả">
                                    <ItemStyle HorizontalAlign="Center" Width="7.5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="OverdueDate" AllowSorting="false" SortExpression="OverdueDate" ReadOnly="True" HeaderText="Quá hạn (ngày)">
                                    <ItemStyle HorizontalAlign="Center" Width="7.5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Mobile" AllowSorting="false" SortExpression="Mobile" ReadOnly="True" HeaderText="Số điện thoại">
                                    <ItemStyle HorizontalAlign="Center" Width="7.5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Email" AllowSorting="false" SortExpression="Email" ReadOnly="True" HeaderText="Email">
                                    <ItemStyle HorizontalAlign="Center" Width="12.5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Class" AllowSorting="false" SortExpression="Class" ReadOnly="True" HeaderText="Lớp">
                                    <ItemStyle HorizontalAlign="Center" Width="7.5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Facebook" AllowSorting="false" SortExpression="Facebook" ReadOnly="True" HeaderText="Facebook">
                                    <ItemStyle HorizontalAlign="Center" Width="7.5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="GroupName" AllowSorting="false" SortExpression="GroupName" ReadOnly="True" HeaderText="Nhóm bạn đọc">
                                    <ItemStyle HorizontalAlign="Center" Width="7.5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Note" AllowSorting="false" SortExpression="Note" ReadOnly="True" HeaderText="Ghi chú">
                                    <ItemStyle HorizontalAlign="Center" Width="7.5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CataloguerName" AllowSorting="false" SortExpression="CataloguerName" ReadOnly="True" HeaderText="Người cho mượn">
                                    <ItemStyle HorizontalAlign="Center" Width="7.5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                            </Columns>
                            <PagerTemplate>
                                <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                            </PagerTemplate>
                        </MasterTableView>
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                    </telerik:RadGrid>--%>


                    <%--<asp:DataGrid ID="dgrOverdue" CssClass="table-control" runat="server" AutoGenerateColumns="False" PageSize="20" AllowPaging="True"
                        AllowSorting="True" Width="98%" CellSpacing="0" CellPadding="2" HorizontalAlign="Center"
                        BorderWidth="1" HeaderStyle-CssClass="lbGridHeader" ItemStyle-CssClass="lbGridCell">
                        <Columns>
                            <asp:BoundColumn DataField="Index" ReadOnly="True" HeaderText="STT">
                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="PatronCode" ReadOnly="True" HeaderText="Số thẻ">
                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Name" ReadOnly="True" HeaderText="Bạn đọc">
                                <ItemStyle HorizontalAlign="Center" Width="17%"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="MainTitle" ReadOnly="True" HeaderText="Nhan đề">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Email" ReadOnly="True" HeaderText="Email">
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Mobile" ReadOnly="True" HeaderText="Số điện thoại">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="Faculty" ReadOnly="True" HeaderText="Khoa">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="GroupName" ReadOnly="True" HeaderText="Nhóm bạn đọc">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CheckOutDate" ReadOnly="True" HeaderText="Ngày mượn">
                                <ItemStyle HorizontalAlign="Center" Width="11%"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CheckInDate" ReadOnly="True" HeaderText="Ngày trả">
                                <ItemStyle HorizontalAlign="Center" Width="9%"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CopyNumber" ReadOnly="True" HeaderText="ĐKCB">
                                <ItemStyle HorizontalAlign="Center" Width="9%"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="OverdueDate" ReadOnly="True" HeaderText="Quá hạn (ngày)">
                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle CssClass="lbGridPager" Position="Bottom" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>--%>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			    <asp:ListItem Value="2">Tất cả</asp:ListItem>
        </asp:DropDownList>
        
            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">Họ tên</asp:ListItem>
                <asp:ListItem Value="2">Số thẻ</asp:ListItem>
                <asp:ListItem Value="3">Nhan đề</asp:ListItem>
                <asp:ListItem Value="4">ĐKCB</asp:ListItem>
                <asp:ListItem Value="5">Ngày mượn</asp:ListItem>
                <asp:ListItem Value="6">Nhân viên quét</asp:ListItem>
                <asp:ListItem Value="7">Hạn trả</asp:ListItem>
                <asp:ListItem Value="8">Quá hạn</asp:ListItem>
                <asp:ListItem Value="9">Số điện thoại</asp:ListItem>
                <asp:ListItem Value="10">Email</asp:ListItem>
                <asp:ListItem Value="11">Lớp</asp:ListItem>
                <asp:ListItem Value="12">Facebook</asp:ListItem>
                <asp:ListItem Value="13">Nhóm bạn đọc</asp:ListItem>
                <asp:ListItem Value="14">Ghi chú</asp:ListItem>
            </asp:DropDownList>
    </form>
</body>
</html>
