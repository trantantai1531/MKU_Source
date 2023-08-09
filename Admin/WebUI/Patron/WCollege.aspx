<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WCollege" CodeFile="WCollege.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCollege</title>
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
<body topmargin="0" leftmargin="0" onload="document.forms[0].txtCollege.focus()">
    <form id="Form1" method="post" runat="server">
     
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager2" runat="server">
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
            <h1 class="main-head-form">Trường</h1>
            <div class="main-form">
                <div class="row-detail">
                    <div class="input-control inline-box">
                        <p>Tên trường :</p>
                        <div class="input-form">
                            <asp:TextBox ID="txtCollege" runat="server"></asp:TextBox>
                        </div>
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnAdd" runat="server" Text="Thêm(a)" Width="70px"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="input-control row-detail">
                    <div class="table-form">

                        <telerik:RadGrid ID="dtgCollege" runat="server" AllowPaging="True"
                            CellSpacing="0"
                            AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgCollege_NeedDataSource">
                            <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                <PagerStyle AlwaysVisible="True" />
                                <FooterStyle BackColor="White"></FooterStyle>

                                <Columns>
                                    <telerik:GridBoundColumn Display="False" DataField="ID" ReadOnly="True" HeaderText="ID"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Postion" ReadOnly="True" HeaderText="STT" ItemStyle-HorizontalAlign="Right"
                                        ItemStyle-Width="5%">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Tên trường">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.College") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtdtgCollege" Width="250px" CssClass="lbTextBox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.College") %>'>
                                            </asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" Text="<image src ='Images/Edit2.gif' border='0' title='Sửa'>" CommandName="Edit"
                                                CausesValidation="false" ID="Linkbutton1"></asp:LinkButton>
                                        <asp:LinkButton runat="server" Text="<image src ='Images/Delete.gif' border='0' title='Xóa'>" CommandName="Delete"
                                            CausesValidation="false" OnClientClick="return confirm('Bạn có chắc muốn xóa ?');"></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkbtnUpdate" runat="server" Text="<Image src ='Images/update.gif' border='0' title='Cập nhật'>"
                                                CommandName="Update"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='Images/Cancel.gif' border='0' title='Thôi'>" CommandName="Cancel"
                                            CausesValidation="false" ID="Linkbutton2"></asp:LinkButton>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridButtonColumn Visible="False" Text="<IMAGE SRC='Images/Delete.gif' border='0' title='Xoá'>" HeaderText="Xoá"
                                        CommandName="Delete" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                    </telerik:GridButtonColumn>
                                    <telerik:GridTemplateColumn ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" HeaderText="Chọn">
                                        <ItemTemplate>
                                            <input id="cbkOption" type="checkbox" class="ckb-value" runat="server">
                                            <label for="cbkOption"></label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <PagerTemplate>
                                    <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                </PagerTemplate>
                            </MasterTableView>

                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </telerik:RadGrid>


                        <%--  <asp:DataGrid CssClass="table-control" ID="dtgCollege" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="10"
                            AllowPaging="True" CellPadding="3">
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Postion" ReadOnly="True" HeaderText="STT" ItemStyle-HorizontalAlign="Right"
                                    ItemStyle-Width="5%"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Tên trường">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.College") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtdtgCollege" Width="250px" CssClass="lbTextBox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.College") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="<image src ='Images/Edit2.gif' border='0' title='Sửa'>" CommandName="Edit"
                                            CausesValidation="false" ID="Linkbutton1"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkbtnUpdate" runat="server" Text="<Image src ='Images/update.gif' border='0' title='Cập nhật'>"
                                            CommandName="Update"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='Images/Cancel.gif' border='0' title='Thôi'>" CommandName="Cancel"
                                            CausesValidation="false" ID="Linkbutton2"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:ButtonColumn Visible="False" Text="<IMAGE SRC='Images/Delete.gif' border='0' title='Xoá'>" HeaderText="Xoá"
                                    CommandName="Delete" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center"></asp:ButtonColumn>
                                <asp:TemplateColumn ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" HeaderText="Chọn">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbkOption" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>--%>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:Label ID="lblCollegeMerger" runat="server"><U>T</U>ên trường:</asp:Label>&nbsp;
						<asp:DropDownList ID="ddlCollege" runat="server"></asp:DropDownList>&nbsp;
						<asp:Button ID="btnMerger" runat="server" Text="Gộp(m)" Width="70px"></asp:Button>
                </div>
            </div>
        </div>

        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Nhấn OK để khẳng định xoá tên trường này</asp:ListItem>
            <asp:ListItem Value="1">Bạn chưa nhập tên trường!</asp:ListItem>
            <asp:ListItem Value="2">Trường</asp:ListItem>
            <asp:ListItem Value="3">đã tồn tại trong CSDL!</asp:ListItem>
            <asp:ListItem Value="4">Bạn phải chọn ít nhất một tên trường để gộp!</asp:ListItem>
            <asp:ListItem Value="5">Bạn có muốn gộp các trường đã chọn không?</asp:ListItem>
            <asp:ListItem Value="6">Gộp tên trường</asp:ListItem>
            <asp:ListItem Value="7">Cập nhật tên trường</asp:ListItem>
            <asp:ListItem Value="8">Xoá tên trường</asp:ListItem>
            <asp:ListItem Value="9">thành công!</asp:ListItem>
            <asp:ListItem Value="10">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="11">Chi tiết lỗi</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
