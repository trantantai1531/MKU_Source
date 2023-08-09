<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WFaculty" CodeFile="WFaculty.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WFaculty</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" onload="document.forms[0].ddlCollege.focus()">
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
                <h1 class="main-head-form">Khoa</h1>
                <div class="main-form">
                    <div class="row-detail">
                        <div class="input-control inline-box">
                            <p>Trường :</p>
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlCollege" runat="server" AutoPostBack="True"></asp:DropDownList>
                            </div>
                            <p>Khoa :</p>
                            <div class="input-form">
                                <asp:TextBox CssClass="text-input" ID="txtFaculty" runat="server"></asp:TextBox>
                            </div>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnAdd" runat="server" Text="Thêm(a)" Width=""></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="input-control row-detail">
                        <div class="table-form">
                            
                             <telerik:RadGrid ID="dtgFaculty" runat="server" AllowPaging="True"
                                CellSpacing="0"
                                AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgFaculty_NeedDataSource">
                                <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                    <PagerStyle AlwaysVisible="True" />
                                    <FooterStyle BackColor="White"></FooterStyle>

                                    <Columns>
                                       <telerik:GridBoundColumn Display="False" DataField="ID" ReadOnly="True" HeaderText="ID"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Postion" ReadOnly="True" HeaderText="STT" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Tên khoa">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Faculty") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtdtgFaculty" CssClass="lbTextBox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Faculty") %>'>
                                            </asp:TextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" Text="<image src ='Images/Edit2.gif' border=0 title='Sửa'>" CommandName="Edit"
                                                CausesValidation="false"></asp:LinkButton>
                                        <asp:LinkButton runat="server" Text="<image src ='Images/Delete.gif' border='0' title='Xóa'>" CommandName="Delete"
                                            CausesValidation="false" OnClientClick="return confirm('Bạn có chắc muốn xóa ?');"></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkbtnUpdate" runat="server" Text="<Image src ='Images/Update.gif' border=0 title='Cập nhật'>"
                                                CommandName="Update"></asp:LinkButton>&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='Images/Cancel.gif' border=0 title='Thôi'>" CommandName="Cancel"
                                            CausesValidation="false"></asp:LinkButton>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridButtonColumn Visible="False" Text="<IMAGE SRC='Images/Delete.gif' border=0 title='Xoá'>" HeaderText="Xoá"
                                        CommandName="Delete" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center"></telerik:GridButtonColumn>
                                    <telerik:GridTemplateColumn ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" HeaderText="Chọn">
                                        <ItemTemplate>
                                           <input id="cbkOption" type="checkbox"  class="ckb-value" runat="server">
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
                            

                          <%--  <asp:DataGrid CssClass="table-control" ID="dtgFaculty" runat="server" CellPadding="3" PageSize="10" AllowPaging="True"
                                AutoGenerateColumns="False" Width="100%">
                                <Columns>
                                    <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Postion" ReadOnly="True" HeaderText="STT" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Tên khoa">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Faculty") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtdtgFaculty" CssClass="lbTextBox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Faculty") %>'>
                                            </asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" Text="<image src ='Images/Edit2.gif' border=0 title='Sửa'>" CommandName="Edit"
                                                CausesValidation="false"></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lnkbtnUpdate" runat="server" Text="<Image src ='Images/Update.gif' border=0 title='Cập nhật'>"
                                                CommandName="Update"></asp:LinkButton>&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='Images/Cancel.gif' border=0 title='Thôi'>" CommandName="Cancel"
                                            CausesValidation="false"></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:ButtonColumn Visible="False" Text="<IMAGE SRC='Images/Delete.gif' border=0 title='Xoá'>" HeaderText="Xoá"
                                        CommandName="Delete" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center"></asp:ButtonColumn>
                                    <asp:TemplateColumn ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" HeaderText="Chọn">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbkOption" runat="server"></asp:CheckBox>
                                            <label for="cbkOption"></label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>--%>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblFacultyMerger" runat="server">Kh<u>o</u>a:</asp:Label>
                        <div class="input-control" style="width: 420px; display: inline-block;">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlFaculty" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <asp:Button ID="btnMerger" runat="server" Text="Gộp(m)" Width="70px"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
        <input id="hidNameFacultys" type="hidden" name="hidNameFacultys" runat="server">
        <input id="hidIDFacultys" type="hidden" name="hidIDFacultys" runat="server">
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Nhấn OK để khẳng định xoá tên khoa này</asp:ListItem>
            <asp:ListItem Value="1">Bạn chưa nhập tên khoa!</asp:ListItem>
            <asp:ListItem Value="2">Khoa</asp:ListItem>
            <asp:ListItem Value="3">đã tồn tại trong CSDL!</asp:ListItem>
            <asp:ListItem Value="4">Bạn phải chọn ít nhất một khoa cần gộp!</asp:ListItem>
            <asp:ListItem Value="5">Bạn có muốn gộp các khoa đã chọn không?</asp:ListItem>
            <asp:ListItem Value="6">Gộp tên khoa</asp:ListItem>
            <asp:ListItem Value="7">Cập nhật tên khoa</asp:ListItem>
            <asp:ListItem Value="8">Xoá tên khoa</asp:ListItem>
            <asp:ListItem Value="9">thành công!</asp:ListItem>
            <asp:ListItem Value="10">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="11">Chi tiết lỗi</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
