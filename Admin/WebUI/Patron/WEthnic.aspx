<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WEthnic" CodeFile="WEthnic.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="radgridpagerusc" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WEthnic</title>
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
        <div id="divBody">
            <div class="TabbedPanelsContent">
                <h1 class="main-head-form">Dân tộc</h1>
                <div class="main-form">
                <div class="row-detail">
                    <div class="input-control inline-box">
                        <p>Dân tộc :</p>
                        <div class="input-form">
                            <asp:textbox CssClass="text-input"  ID="txtEthnic" runat="server" MaxLength="30"></asp:TextBox>
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
                        
                           <telerik:RadGrid ID="dtgEthnic" runat="server" AllowPaging="True"
                        CellSpacing="0"
                        AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgEthnic_NeedDataSource">
<ExportSettings>
<Pdf>
<PageHeader>
<LeftCell Text=""></LeftCell>

<MiddleCell Text=""></MiddleCell>

<RightCell Text=""></RightCell>
</PageHeader>

<PageFooter>
<LeftCell Text=""></LeftCell>

<MiddleCell Text=""></MiddleCell>

<RightCell Text=""></RightCell>
</PageFooter>
</Pdf>
</ExportSettings>

                        <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<BatchEditingSettings EditType="Cell"></BatchEditingSettings>

                            <PagerStyle AlwaysVisible="True" />
                            <FooterStyle BackColor="White"></FooterStyle>

<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>

                            <Columns>

                                 <telerik:GridBoundColumn Display="False" DataField="ID" UniqueName="ID" ReadOnly="True" HeaderText="ID"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Postion" ReadOnly="True" HeaderText="STT">
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="T&#234;n d&#226;n tộc">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Ethnic") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:textbox CssClass="text-input"  ID="txtdtgEthnic"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Ethnic") %>' MaxLength="30">
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Sửa">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="<image src ='Images/Edit2.gif' border='0' title='Sửa'>" CommandName="Edit"
                                            CausesValidation="false"></asp:LinkButton>
                                        <asp:LinkButton runat="server" Text="<image src ='Images/Delete.gif' border='0' title='Xóa'>" CommandName="Delete"
                                            CausesValidation="false" OnClientClick="return confirm('Bạn có chắc muốn xóa ?');"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkbtnUpdate" runat="server" Text="<Image src ='Images/Update.gif' border='0' title='Cập nhật'>"
                                            CommandName="Update"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='Images/Cancel.gif' border='0' title='Thôi'>" CommandName="Cancel"
                                            CausesValidation="false"></asp:LinkButton>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Chọn">
                                    <ItemStyle  HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    <ItemTemplate>
                                   
                                         <input id="cbkOption" type="checkbox"  class="ckb-value" runat="server">
                                        <label for="cbkOption"></label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <PagerTemplate>
                                <gusc:radgridpagerusc runat="server" id="RadGridPagerUSC" clientidmode="Static" />
                            </PagerTemplate>
                        </MasterTableView>

                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


<FilterMenu EnableImageSprites="False"></FilterMenu>


                    </telerik:RadGrid>

                       <%-- <asp:DataGrid CssClass="table-control" ID="dtgEthnic" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
                            PageSize="8" CellPadding="3">
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Postion" ReadOnly="True" HeaderText="STT">
                                    <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="T&#234;n d&#226;n tộc">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Ethnic") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:textbox CssClass="text-input"  ID="txtdtgEthnic"  runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Ethnic") %>' MaxLength="30">
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Sửa">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="<image src ='Images/Edit2.gif' border='0' title='Sửa'>" CommandName="Edit"
                                            CausesValidation="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkbtnUpdate" runat="server" Text="<Image src ='Images/Update.gif' border='0' title='Cập nhật'>"
                                            CommandName="Update"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='Images/Cancel.gif' border='0' title='Thôi'>" CommandName="Cancel"
                                            CausesValidation="false"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Chọn">
                                    <ItemStyle  HorizontalAlign="Center" Width="5%"></ItemStyle>
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
                    <asp:Label ID="lblEthnicMerger" runat="server">Dân <u>t</u>ộc:</asp:Label>&nbsp;
						<asp:DropDownList ID="ddlEthnic" runat="server"></asp:DropDownList>&nbsp;
						<asp:Button ID="btnMerger" runat="server" Text="Gộp(g)" Width="70px"></asp:Button>
                </div>
                    </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabelNote" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Nhấn OK để khẳng định xoá tên dân tộc này</asp:ListItem>
            <asp:ListItem Value="1">Bạn chưa nhập tên dân tộc!</asp:ListItem>
            <asp:ListItem Value="2">Dân tộc</asp:ListItem>
            <asp:ListItem Value="3">đã tồn tại trong CSDL!</asp:ListItem>
            <asp:ListItem Value="4">Bạn có muốn gộp các dân tộc đã chọn không?</asp:ListItem>
            <asp:ListItem Value="5">Bạn phải chọn ít nhất một dân tộc trước khi gộp!</asp:ListItem>
            <asp:ListItem Value="6">thành công!</asp:ListItem>
            <asp:ListItem Value="7">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="8">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="9">Cập nhật tên dân tộc</asp:ListItem>
            <asp:ListItem Value="10">Gộp tên dân tộc</asp:ListItem>
            <asp:ListItem Value="11">Bạn phải nhập tên dân tộc !</asp:ListItem>
            <asp:ListItem Value="12">Dữ liệu nhập không chuẩn</asp:ListItem>
        </asp:DropDownList>
        <script language="javascript">
            document.forms[0].txtEthnic.focus();
        </script>
    </form>
</body>
</html>
