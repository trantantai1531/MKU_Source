<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.WSearchCopyNumber" CodeFile="WSearchCopyNumber.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSearchCopyNumber</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
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
        <div id="divBody" style="margin-left: 20px">
            <h2 class="main-head-form">Tìm kiếm đăng ký cá biệt</h2>
            <div class="main-form">
                <div class="row-detail">
                    <asp:Label ID="lblTitle" runat="server"><u>N</u>han đề chính:</asp:Label><p class="error-star">(*)</p>
                    <div class="input-control">
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:Label ID="lblISBN" runat="server"><u>I</u>SBN:</asp:Label>
                    <div class="input-control">
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtISBN" runat="server" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:Label ID="lblCopyNumber" Style="z-index: 103" runat="server"><u>M</u>ã xếp giá:</asp:Label>
                    <div class="input-control">
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtCopyNumber" Style="z-index: 104" runat="server" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:Label ID="lblLocation" runat="server"><u>K</u>ho:</asp:Label>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlLocation" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:Label ID="lblCallNumber" Style="z-index: 115" runat="server">Số định danh:</asp:Label>
                    <div class="input-control">
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtCallNumber" Style="z-index: 116" runat="server" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:Label ID="lblAuthor" Style="z-index: 105" runat="server"><u>T</u>ác giả:</asp:Label>
                    <div class="input-control">
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtAuthor" Style="z-index: 106" runat="server" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:Label ID="lblPublisher" Style="z-index: 107" runat="server">Nhà xuất <u>b</u>ản:</asp:Label>
                    <div class="input-control">
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtPublisher" Style="z-index: 108" runat="server" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:Label ID="lblYear" Style="z-index: 109" runat="server">Năm <u>x</u>uất bản:</asp:Label>
                    <div class="input-control">
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtYear" Style="z-index: 110" runat="server" Width=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnSearch" runat="server" CssClass="lbButton" Text="Tìm (f)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" runat="server" CssClass="lbButton" Text="Đặt lại(r)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
                <div>
                    <asp:Label ID="lblCapResult" runat="server" Visible="False">Tìm thấy:</asp:Label>&nbsp;
						<asp:Label ID="lblResult" runat="server" Visible="False" Font-Bold="True" ForeColor="Maroon"></asp:Label>&nbsp;
						<asp:Label ID="lblCap" runat="server" Visible="False">bản ghi biên mục</asp:Label>
                    <asp:Label ID="lblNotFound" runat="server" Visible="False">Không tìm thấy bản ghi nào thỏa mãn các điều kiện đặt ra </asp:Label>
                </div>
                <div class="row-detail table-form">


                    <telerik:RadGrid ID="dtgResult" runat="server" AllowPaging="True"
                        CellSpacing="0"
                        AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgResult_NeedDataSource">
                        <MasterTableView TableLayout="Auto" DataKeyNames="ItemID" EditMode="InPlace">
                            <PagerStyle AlwaysVisible="True" />
                            <FooterStyle BackColor="White"></FooterStyle>

                            <Columns>
                                <telerik:GridTemplateColumn SortExpression="Title" HeaderText="Nhan đề">
                                    <HeaderStyle Width="100%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkTitle" runat="server">
											<%# DataBinder.Eval(Container.dataItem,"Title")%>
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <PagerTemplate>
                                <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                            </PagerTemplate>
                        </MasterTableView>

                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                    </telerik:RadGrid>

                    <%--                    <asp:DataGrid ID="dtgResult" CssClass="table-control" runat="server" Width="100%" PageSize="15" AutoGenerateColumns="False"
                        AllowPaging="True">
                        <Columns>
                            <asp:TemplateColumn SortExpression="Title" HeaderText="Nhan đề">
                                <HeaderStyle Width="100%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkTitle" runat="server">
											<%# DataBinder.Eval(Container.dataItem,"Title")%>
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>--%>
                </div>
            </div>
        </div>
        <input id="hidIDs" type="hidden" name="hidIDs" runat="server"/>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn chưa nhập điều kiện tìm kiếm</asp:ListItem>
            <asp:ListItem Value="3">---------- Chọn ----------</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtTitle.focus();
    </script>
</body>
</html>
