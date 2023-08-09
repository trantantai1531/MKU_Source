<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCataDetailRenew" CodeFile="WCataDetailRenew.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCataDetail</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link runat="server" href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <style>
        input[type="radio"] {
            display: list-item;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="parent.document.getElementById('frmMain').setAttribute('rows','*,39');">
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
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr class="lbPageTitle">
                <td align="left">
                    <asp:Label ID="lblTitle" runat="server" CssClass="main-head-form">
							Biên mục chi tiết cho tài liệu ấn phẩm đã được biên mục chi tiết chờ duyệt
                    </asp:Label></td>
            </tr>
            <tr height="10">
                <td style="HEIGHT: 19px"></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblMainTitle" runat="server"><U>T</U>hời gian nhập:</asp:Label>&nbsp;<asp:DropDownList ID="ddlInputTime" runat="server" Width="344px" AutoPostBack="True"></asp:DropDownList></td>
            </tr>
            <tr height="5">
                <td></td>
            </tr>
            <tr>
                <td>
                    <div class="table-form">



                        <telerik:RadGrid ID="grdFItem" runat="server" AllowPaging="True"
                            CellSpacing="0"
                            AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="grdFItem_NeedDataSource">
                            <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                <PagerStyle AlwaysVisible="True" />
                                <FooterStyle BackColor="White"></FooterStyle>

                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Bi&#234;n mục">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblRadio" runat="server">
											<%# DataBinder.Eval(Container.dataItem,"rdoChoice") %>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn HeaderText="&lt;A class='lbLinkGrid' HREF='WCataDetailRenew.aspx?SortMode=0'&gt;Nhan đề&lt;/A&gt;">
                                        <headerstyle forecolor="#FFFFE1"></headerstyle>
                                        <itemtemplate>
                                        <asp:HyperLink ID="lnkContent" runat="server">
											<%# DataBinder.Eval(Container.dataItem,"Content")%>
                                        </asp:HyperLink>
                                    </itemtemplate>
                                    </telerik:GridTemplateColumn>
                                    
                                       <telerik:GridBoundColumn DataField="Code" HeaderText="&lt;A class='lbLinkGrid' HREF='WCataDetailRenew.aspx?SortMode=1'&gt;M&#227; t&#224;i liệu&lt;/A&gt;">
                                    <HeaderStyle ForeColor="#FFFFE1"></HeaderStyle>
                                </telerik:GridBoundColumn>
                                    
                                    
                                      <telerik:GridBoundColumn Visible="False" DataField="Reviewer" HeaderText="Người bi&#234;n mục">
                                    <HeaderStyle ForeColor="#FFFFE1"></HeaderStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CREATEDDATE" HeaderText="&lt;A class='lbLinkGrid' HREF='WCataDetailRenew.aspx?SortMode=2'&gt;Ng&#224;y nhập&lt;/A&gt;">
                                    <HeaderStyle ForeColor="#FFFFE1"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="9%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn Visible="False" DataField="Reviewed" HeaderText="Reviewed"></telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Chọn">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    <ItemTemplate>
                                        <%--	<asp:Label ID="lblCheckBox" Runat="server">
											<%# DataBinder.Eval(Container.dataItem,"chkChoice") %>
										</asp:Label>--%>
                                        <input type="checkbox" id="lblCheckBox" runat="server">
                                            <%# DataBinder.Eval(Container.dataItem,"chkChoice") %> </input>
                                        <label for="lblCheckBox"></label>

                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn Visible="False" DataField="ID" HeaderText="ID"></telerik:GridBoundColumn>
                                    

                                </Columns>
                                <PagerTemplate>
                                    <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                </PagerTemplate>
                            </MasterTableView>

                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                        </telerik:RadGrid>










                   <%--     <asp:DataGrid ID="grdFItem" CssClass="table-control" runat="server" Width="100%" PageSize="15" AutoGenerateColumns="False"
                            AllowSorting="True" AllowPaging="True">
                            <Columns>
                                <asp:TemplateColumn HeaderText="Bi&#234;n mục">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRadio" runat="server">
											<%# DataBinder.Eval(Container.dataItem,"rdoChoice") %>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="&lt;A class='lbLinkGrid' HREF='WCataDetailRenew.aspx?SortMode=0'&gt;Nhan đề&lt;/A&gt;">
                                    <HeaderStyle ForeColor="#FFFFE1"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkContent" runat="server">
											<%# DataBinder.Eval(Container.dataItem,"Content")%>
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="Code" HeaderText="&lt;A class='lbLinkGrid' HREF='WCataDetailRenew.aspx?SortMode=1'&gt;M&#227; t&#224;i liệu&lt;/A&gt;">
                                    <HeaderStyle ForeColor="#FFFFE1"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="Reviewer" HeaderText="Người bi&#234;n mục">
                                    <HeaderStyle ForeColor="#FFFFE1"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CREATEDDATE" HeaderText="&lt;A class='lbLinkGrid' HREF='WCataDetailRenew.aspx?SortMode=2'&gt;Ng&#224;y nhập&lt;/A&gt;">
                                    <HeaderStyle ForeColor="#FFFFE1"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="9%"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="Reviewed" HeaderText="Reviewed"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Chọn">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    <ItemTemplate>
                                        <%--	<asp:Label ID="lblCheckBox" Runat="server">
											<%# DataBinder.Eval(Container.dataItem,"chkChoice") %>
										</asp:Label>--%>
                                       <%-- <input type="checkbox" id="lblCheckBox" runat="server">
                                            <%# DataBinder.Eval(Container.dataItem,"chkChoice") %> </input>
                                        <label for="lblCheckBox"></label>

                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
                            </Columns>
                            <PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>--%>
                    </div>
                </td>
            </tr>
        </table>
        <input id="hidColSort" type="hidden" name="hidColSort" runat="server" />&nbsp;
        <input id="hidIDs" type="hidden" name="hidIDs" runat="server" />
        <input id="hidID" type="hidden" name="hidID" runat="server">
        <input type="hidden" id="hidIntime" value="0" runat="server" name="hidIntime" />
        <asp:DropDownList ID="ddlLabel" Width="0" Height="0" runat="server" Visible="False">
            <asp:ListItem Value="0">Tất cả: </asp:ListItem>
            <asp:ListItem Value="1">Tháng: </asp:ListItem>
            <asp:ListItem Value="2">-----</asp:ListItem>
            <asp:ListItem Value="3">Chưa biên mục chi tiết: </asp:ListItem>
            <asp:ListItem Value="4">Đã biên mục chi tiết: </asp:ListItem>
            <asp:ListItem Value="5">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="6">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="7">Đang tải dữ liệu. Xin vui lòng chờ trong chốc lát...</asp:ListItem>
        </asp:DropDownList>
        <script language="javascript">
            ReCheckbox();
        </script>
    </form>
</body>
</html>
