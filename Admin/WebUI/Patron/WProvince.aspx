<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WProvince" CodeFile="WProvince.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WProvince</title>
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
<body topmargin="0" leftmargin="0" onload="document.forms[0].txtProvince.focus()">
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

            <h1 class="main-head-form">Tỉnh</h1>
            <div class="main-form">
                <div class="row-detail">
                    <div class="input-control inline-box">
                        <p>Tỉnh :</p>
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtProvince" runat="server"></asp:TextBox>
                        </div>
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnAdd" runat="server" Text="Thêm(a)" Width=""></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnFilter" runat="server" Text="Lọc(l)" Width=""></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="input-control row-detail">
                    <div class="table-form">
                        
                         <telerik:RadGrid ID="dtgProvince" runat="server" AllowPaging="True"
                                CellSpacing="0"
                                AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgProvince_NeedDataSource">
                                <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                    <PagerStyle AlwaysVisible="True" />
                                    <FooterStyle BackColor="White"></FooterStyle>

                                    <Columns>
                                       
                                         <telerik:GridBoundColumn Display="False" DataField="ID" ReadOnly="True" HeaderText="ID"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Postion" ReadOnly="True" HeaderText="STT" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Tên tỉnh (thành phố)">
                                    <ItemTemplate>
                                        <asp:Label runat="server" CssClass="lbLabel" Text='<%# DataBinder.Eval(Container, "DataItem.Province") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtdtgProvince" CssClass="lbTextBox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Province") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Sửa" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="<image src ='Images/Edit2.gif' border='0' title='Sửa'>" CommandName="Edit"
                                            CausesValidation="false"></asp:LinkButton>
                                        <asp:LinkButton runat="server" Text="<image src ='Images/Delete.gif' border='0' title='Xóa'>" CommandName="Delete"
                                            CausesValidation="false" OnClientClick="return confirm('Bạn có chắc muốn xóa ?');"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkbtnUpdate" runat="server" Text="<Image src ='Images/Update.gif' border='0' title='Cập nhật'>"
                                            CommandName="Update"></asp:LinkButton>&nbsp;&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='Images/Cancel.gif' border='0' title='Thôi'>" CommandName="Cancel"
                                            CausesValidation="false"></asp:LinkButton>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridButtonColumn ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" Text="<IMAGE SRC='Images/Delete.gif' border='0' title='Xoá'>"
                                    HeaderText="Xoá" CommandName="Delete" Visible="False">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridButtonColumn>
                                <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderText="Chọn">
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
                        

                    <%--    <asp:DataGrid CssClass="table-control" ID="dtgProvince" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="10"
                            AllowPaging="True" CellPadding="3">
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Postion" ReadOnly="True" HeaderText="STT" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Tên tỉnh (thành phố)">
                                    <ItemTemplate>
                                        <asp:Label runat="server" CssClass="lbLabel" Text='<%# DataBinder.Eval(Container, "DataItem.Province") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtdtgProvince" CssClass="lbTextBox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Province") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Sửa" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="<image src ='Images/Edit2.gif' border='0' title='Sửa'>" CommandName="Edit"
                                            CausesValidation="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkbtnUpdate" runat="server" Text="<Image src ='Images/Update.gif' border='0' title='Cập nhật'>"
                                            CommandName="Update"></asp:LinkButton>&nbsp;&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='Images/Cancel.gif' border='0' title='Thôi'>" CommandName="Cancel"
                                            CausesValidation="false"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:ButtonColumn ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" Text="<IMAGE SRC='Images/Delete.gif' border='0' title='Xoá'>"
                                    HeaderText="Xoá" CommandName="Delete" Visible="False">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderText="Chọn">
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
                    <asp:Label ID="lblProvinceMerger" runat="server"><U>T</U>ỉnh: </asp:Label>
                    <div class="input-control" style="width: 120px; display: inline-block;">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlProvince" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <asp:Button ID="btnMerger" runat="server" Text="Gộp(g)" Width=""></asp:Button>
                </div>
            </div>
        </div>

        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Nhấn OK để khẳng định xoá tên tỉnh (thành phố) này</asp:ListItem>
            <asp:ListItem Value="1">Bạn chưa nhập tên tỉnh (thành phố)</asp:ListItem>
            <asp:ListItem Value="2">Tỉnh (thành phố)</asp:ListItem>
            <asp:ListItem Value="3">đã tồn tại trong CSDL</asp:ListItem>
            <asp:ListItem Value="4">Bạn phải chọn ít nhất một tên tỉnh (thành phố) cần gộp!</asp:ListItem>
            <asp:ListItem Value="5">Bạn có muốn gộp các tỉnh (thành phố) đã chọn không?</asp:ListItem>
            <asp:ListItem Value="6">Bạn phải chọn ít nhất một tỉnh trước khi gộp!</asp:ListItem>
            <asp:ListItem Value="7">Cập nhật tên tỉnh (thành phố)</asp:ListItem>
            <asp:ListItem Value="8">Xoá tên tỉnh (thành phố)</asp:ListItem>
            <asp:ListItem Value="9">thành công</asp:ListItem>
            <asp:ListItem Value="10">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="11">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="12">Gộp các tỉnh (thành phố)</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
