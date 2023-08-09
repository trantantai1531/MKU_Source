<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WClassificationDetail" CodeFile="WClassificationDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WClassification</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
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
        <table width="100%" border="0">
            <tr class="lbPageTitle">
                <td colspan="4" align="center">
                    <h1 class="main-group-form">
                        <asp:Label ID="lblHeader" runat="server" CssClass="lbPageTitle">Chỉ Số Phân Loại</asp:Label>
                    </h1>

                </td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <asp:Label ID="lblDisplayEntryL" runat="server"><u>T</u>ên chỉ số:</asp:Label></td>
                <td width="35%">
                    <asp:TextBox ID="txtDisplayEntryT" runat="server" Width="222px"></asp:TextBox>
                    <asp:Label ID="lblComment" runat="server" Font-Bold="True" ForeColor="Red">(*)</asp:Label>
                </td>
                <td align="right">
                    <asp:Label ID="lblVersionL" runat="server"><u>P</u>hiên bản:</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtVersionT" runat="server" Width="104px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblVietCaptionL" runat="server">Tiê<u>u</u> đề (Việt):</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtVietCaptionT" runat="server" Width="222px"></asp:TextBox></td>
                <td align="right">
                    <asp:Label ID="lblDescriptionL" runat="server"><u>G</u>iải thích:</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtDescriptionT" BorderStyle="Solid" BorderWidth="1px" BorderColor="#999999" runat="server" Width="222px" TextMode="MultiLine" Rows="1"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lvlCaptionL" runat="server">Tiêu <u>đ</u>ề (Anh):</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtCaptionT" runat="server" Width="222px"></asp:TextBox></td>
                <td></td>
                <td>
                    <asp:Button ID="btnNew" runat="server" Text="Nhập(n)" Width="65px"></asp:Button></td>
            </tr>
            <tr class="lbGroupTitle">
                <td align="center" colspan="4">
                    <h1 class="main-group-form">
                        <asp:Label ID="lblList" runat="server" CssClass="lbGroupTitle">Danh sách phân loại</asp:Label></h1>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <telerik:RadGrid ID="dtgDicClassi" runat="server" AllowPaging="False"
                        CellSpacing="0"
                        AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgDicClassi_NeedDataSource">
                        <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                            <PagerStyle AlwaysVisible="True" />
                            <FooterStyle BackColor="White"></FooterStyle>

                            <Columns>
                                 <telerik:GridTemplateColumn Visible="False">
                                <HeaderStyle Width="1px"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="ItemLeader" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemLeader" Text='<%# DataBinder.Eval(Container.DataItem, "ItemLeader") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" ID="txtItemLeader" Text='<%# DataBinder.Eval(Container.DataItem, "ItemLeader") %>' />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="ItemCode" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemCode" Text='<%# DataBinder.Eval(Container.DataItem, "ItemCode") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Width="100%" ID="txtItemCode" Text='<%# DataBinder.Eval(Container.DataItem, "ItemCode") %>' />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Chỉ số" ItemStyle-Width="8%">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayEntry" Text='<%# DataBinder.Eval(Container.DataItem, "DisplayEntry") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="lbTextBox" Width="100%" runat="server" ID="txtDisplayEntry" Text='<%# DataBinder.Eval(Container.DataItem, "DisplayEntry") %>' />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Tiêu đề">
                                <ItemTemplate>
                                    <asp:Label ID="lblCaption" Text='<%# DataBinder.Eval(Container.DataItem, "Caption") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="lbTextBox" Width="100%" runat="server" ID="txtCaption" Text='<%# DataBinder.Eval(Container.DataItem, "Caption") %>' />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Tiêu đề (Việt)">
                                <ItemTemplate>
                                    <asp:Label ID="lblVietCaption" Text='<%# DataBinder.Eval(Container.DataItem, "VietCaption") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="lbTextBox" Width="100%" runat="server" ID="txtVietCaption" Text='<%# DataBinder.Eval(Container.DataItem, "VietCaption") %>' />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Giải thích">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="lbTextBox" Width="100%" runat="server" ID="txtDescription" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>' />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Phiên bản" ItemStyle-Width="8%">
                                <ItemTemplate>
                                    <asp:Label ID="lblVersion" Text='<%# DataBinder.Eval(Container.DataItem, "Version") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="lbTextBox" Width="100%" runat="server" ID="txtVersion" Text='<%# DataBinder.Eval(Container.DataItem, "Version") %>' />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridEditCommandColumn ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" HeaderText="Sửa" ButtonType="LinkButton"
                                UpdateText="&lt;img src=&quot;../images/update.gif&quot; border=&quot;0&quot;&gt;" CancelText="&lt;img src=&quot;../images/cancel.gif&quot; border=&quot;0&quot;&gt;"
                                EditText="&lt;img src=&quot;../images/edit2.gif&quot; border=&quot;0&quot;&gt;"></telerik:GridEditCommandColumn>
                            <telerik:GridButtonColumn  ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" HeaderText="Xoá" Text="&lt;img src=&quot;../images/delete.gif&quot; border=&quot;0&quot;&gt;"
                                CommandName="Delete"></telerik:GridButtonColumn>
                            </Columns>
                            <PagerTemplate>
                                <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                            </PagerTemplate>
                        </MasterTableView>

                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                    </telerik:RadGrid>





                    <%--<asp:DataGrid ID="dtgDicClassi" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                        PageSize="20">
                        <Columns>
                            <asp:TemplateColumn Visible="False">
                                <HeaderStyle Width="1px"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ItemLeader" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemLeader" Text='<%# DataBinder.Eval(Container.DataItem, "ItemLeader") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" ID="txtItemLeader" Text='<%# DataBinder.Eval(Container.DataItem, "ItemLeader") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ItemCode" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblItemCode" Text='<%# DataBinder.Eval(Container.DataItem, "ItemCode") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox runat="server" Width="100%" ID="txtItemCode" Text='<%# DataBinder.Eval(Container.DataItem, "ItemCode") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Chỉ số" ItemStyle-Width="8%">
                                <ItemTemplate>
                                    <asp:Label ID="lblDisplayEntry" Text='<%# DataBinder.Eval(Container.DataItem, "DisplayEntry") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="lbTextBox" Width="100%" runat="server" ID="txtDisplayEntry" Text='<%# DataBinder.Eval(Container.DataItem, "DisplayEntry") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Tiêu đề">
                                <ItemTemplate>
                                    <asp:Label ID="lblCaption" Text='<%# DataBinder.Eval(Container.DataItem, "Caption") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="lbTextBox" Width="100%" runat="server" ID="txtCaption" Text='<%# DataBinder.Eval(Container.DataItem, "Caption") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Tiêu đề (Việt)">
                                <ItemTemplate>
                                    <asp:Label ID="lblVietCaption" Text='<%# DataBinder.Eval(Container.DataItem, "VietCaption") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="lbTextBox" Width="100%" runat="server" ID="txtVietCaption" Text='<%# DataBinder.Eval(Container.DataItem, "VietCaption") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Giải thích">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="lbTextBox" Width="100%" runat="server" ID="txtDescription" Text='<%# DataBinder.Eval(Container.DataItem, "Description") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Phiên bản" ItemStyle-Width="8%">
                                <ItemTemplate>
                                    <asp:Label ID="lblVersion" Text='<%# DataBinder.Eval(Container.DataItem, "Version") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="lbTextBox" Width="100%" runat="server" ID="txtVersion" Text='<%# DataBinder.Eval(Container.DataItem, "Version") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:EditCommandColumn ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" HeaderText="Sửa" ButtonType="LinkButton"
                                UpdateText="&lt;img src=&quot;../images/update.gif&quot; border=&quot;0&quot;&gt;" CancelText="&lt;img src=&quot;../images/cancel.gif&quot; border=&quot;0&quot;&gt;"
                                EditText="&lt;img src=&quot;../images/edit2.gif&quot; border=&quot;0&quot;&gt;"></asp:EditCommandColumn>
                            <asp:ButtonColumn ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" HeaderText="Xoá" Text="&lt;img src=&quot;../images/delete.gif&quot; border=&quot;0&quot;&gt;"
                                CommandName="Delete"></asp:ButtonColumn>
                        </Columns>
                        <PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>--%>
                </td>
            </tr>
        </table>
        <asp:DropDownList ID="ddlAboutAction" runat="server" Width="0px" Visible="False">
            <asp:ListItem Value="0">Bạn thực sự muốn xoá mẫu này?</asp:ListItem>
            <asp:ListItem Value="1">Mẫu danh mục mới chưa được ghi nhận</asp:ListItem>
            <asp:ListItem Value="2">Cập nhật mẫu danh mục thành công</asp:ListItem>
            <asp:ListItem Value="3">Đã ghi nhận mẫu mẫu danh mục mới</asp:ListItem>
            <asp:ListItem Value="4">Bạn chưa nhập tên mẫu danh mục</asp:ListItem>
            <asp:ListItem Value="5">Mẫu danh mục mới đã được ghi nhận</asp:ListItem>
            <asp:ListItem Value="6">"Insert: "</asp:ListItem>
            <asp:ListItem Value="7">"Update: "</asp:ListItem>
            <asp:ListItem Value="8">"Delete: "</asp:ListItem>
            <asp:ListItem Value="9">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="10">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="11">Bạn chưa nhập tên chỉ số</asp:ListItem>
            <asp:ListItem Value="12">Tên chỉ số đã tồn tại trong cơ sở dữ liệu.</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
