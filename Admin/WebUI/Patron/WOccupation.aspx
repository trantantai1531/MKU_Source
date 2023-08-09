<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WOccupation" CodeFile="WOccupation.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Tên ngành nghề</title>
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
<body topmargin="0" leftmargin="0" onload="document.forms[0].txtOccupation.focus()">
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
            <div class="TabbedPanelsContent">
                <h1 class="main-head-form">Nhóm ngành nghề</h1>
                <div class="row-detail">
                    <div class="input-control inline-box">
                        <p>Nghề nghiệp :</p>
                        <div class="input-form">
                            <asp:TextBox ID="txtOccupation" runat="server"></asp:TextBox>
                        </div>
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnAdd" runat="server" Text="Thêm(e)" Width=""></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="input-control row-detail">
                    <div class="table-form">

                        <telerik:RadGrid ID="dtgOccupation" runat="server" AllowPaging="True"
                            CellSpacing="0"
                            AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgOccupation_NeedDataSource">
                            <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                <PagerStyle AlwaysVisible="True" />
                                <FooterStyle BackColor="White"></FooterStyle>

                                <Columns>
                                    <telerik:GridBoundColumn Display="False" DataField="ID" ReadOnly="True" HeaderText="ID"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Postion" ReadOnly="True" HeaderText="STT">
                                        <HeaderStyle HorizontalAlign="Left" Width="5%"></HeaderStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Nghề nghiệp">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Justify"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Occupation") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtdtgOccupation" CssClass="lbTextBox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Occupation") %>'>
                                            </asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Sửa">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" Text="<image src ='Images/Edit2.gif' border='0' title='Sửa'>" CommandName="Edit"
                                                CausesValidation="false" ID="Linkbutton1"></asp:LinkButton>
                                        <asp:LinkButton runat="server" Text="<image src ='Images/Delete.gif' border='0' title='Xóa'>" CommandName="Delete"
                                            CausesValidation="false" OnClientClick="return confirm('Bạn có chắc muốn xóa ?');"></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkbtnUpdate" runat="server" Text="<Image src ='Images/Update.gif' border='0' title='Cập nhật'>"
                                                CommandName="Update"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='Images/Cancel.gif' border='0' title='Thôi'>" CommandName="Cancel"
                                            CausesValidation="false" ID="Linkbutton2"></asp:LinkButton>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Chọn">
                                        <itemstyle width="5%"></itemstyle>
                                        <itemtemplate>
                                   
                                         <input id="cbkOption" type="checkbox"  class="ckb-value" runat="server">
                                        <label for="cbkOption"></label>
                                </itemtemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <PagerTemplate>
                                    <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                </PagerTemplate>
                            </MasterTableView>

                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                        </telerik:RadGrid>


                        <%--  <asp:DataGrid ID="dtgOccupation" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="8"
                        AllowPaging="True" CellPadding="3">
                        <Columns>
                            <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Postion" ReadOnly="True" HeaderText="STT">
                                <HeaderStyle HorizontalAlign="Left" Width="5%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Nghề nghiệp">
                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Justify"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Occupation") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtdtgOccupation" CssClass="lbTextBox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Occupation") %>'>
                                    </asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Sửa">
                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" Text="<image src ='Images/Edit2.gif' border='0' title='Sửa'>" CommandName="Edit"
                                        CausesValidation="false" ID="Linkbutton1"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkbtnUpdate" runat="server" Text="<Image src ='Images/Update.gif' border='0' title='Cập nhật'>"
                                        CommandName="Update"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='Images/Cancel.gif' border='0' title='Thôi'>" CommandName="Cancel"
                                            CausesValidation="false" ID="Linkbutton2"></asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Chọn">
                                <ItemStyle Width="5%"></ItemStyle>
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
                    <asp:Label ID="lblOccupationMerger" runat="server">Nghề ngh<u>i</u>ệp</asp:Label>
                    <asp:DropDownList ID="ddlOccupation" runat="server"></asp:DropDownList>
                    <asp:Button ID="btnMerger" runat="server" Text="Gộp(g)" Width=""></asp:Button>
                </div>
            </div>

        </div>

        <asp:DropDownList ID="ddlLabelNote" runat="server" Visible="False" Width="0px">
            <asp:ListItem Value="0">Nhấn OK để khẳng định xoá tên ngề này!!</asp:ListItem>
            <asp:ListItem Value="1">Bạn chưa nhập tên nghề nghiệp!</asp:ListItem>
            <asp:ListItem Value="2">Nghề nghiệp</asp:ListItem>
            <asp:ListItem Value="3">đã tồn tại trong CSDL!</asp:ListItem>
            <asp:ListItem Value="4">Bạn phải chọn ít nhất một nghề nghiệp</asp:ListItem>
            <asp:ListItem Value="5">Bạn có muốn gộp các nghề nghiệp đã chọn không?</asp:ListItem>
            <asp:ListItem Value="6">Bạn phải chọn ít nhất một nghề nghiệp khi gộp!</asp:ListItem>
            <asp:ListItem Value="7">Gộp thành công!</asp:ListItem>
            <asp:ListItem Value="8">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="9">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="10">Cập nhật tên nghề nghiệp</asp:ListItem>
            <asp:ListItem Value="11">Thay đổi tên nghề nghiệp</asp:ListItem>
            <asp:ListItem Value="12">Xoá tên nghề nghiệp</asp:ListItem>
            <asp:ListItem Value="13">Gộp tên nghề</asp:ListItem>
            <asp:ListItem Value="14">Nghề nghiệp đã tồn tại trong CSDL!</asp:ListItem>
            <asp:ListItem Value="15">thành công</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
