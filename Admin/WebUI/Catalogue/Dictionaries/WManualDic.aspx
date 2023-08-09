<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WManualDic" CodeFile="WManualDic.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WManualDic</title>
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
                <h1 class="main-head-form">Quản lý từ điển tự tạo</h1>
                <div class="input-control row-detail">
                    <div class="table-form">

                        <telerik:RadGrid ID="dtgDicSelfMade" runat="server" AllowPaging="True"
                            CellSpacing="0"
                            AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgDicSelfMade_NeedDataSource">
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
                                <telerik:GridTemplateColumn HeaderText="T&#234;n từ điển tự tạo">
                                    <HeaderStyle Width="60%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink CssClass="lbLinkfunction" ID="lnkName" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "ShowSelfMade") %>' runat="server">
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="150" runat="server" CssClass="lbTextbox" ID="txtName" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="C&#225;n bộ">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <input type="checkbox" id="chkForStaffV" runat="server" checked='<%# DataBinder.Eval(Container.DataItem, "ForStaff") %>' disabled="disabled"></input>
                                        <label id="Label3" runat="server" for="c3"></label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkForStaffE" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ForStaff") %>'></asp:CheckBox>
                                        <label id="Label2" runat="server" for="c3"></label>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Bạn đọc">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <input type="checkbox" id="chkForPatronV" runat="server" checked='<%# DataBinder.Eval(Container.DataItem, "ForPatron") %>' disabled="disabled"></input>
                                        <label id="Label1" runat="server" for="c3"></label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkForPatronE" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ForPatron") %>'></asp:CheckBox>
                                        <label id="Label6" runat="server" for="c3"></label>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="K&#237;ch thước">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFieldSize" Text='<%# DataBinder.Eval(Container.DataItem, "FieldSize") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="40" runat="server" CssClass="lbTextbox" ID="txtFieldSize" Text='<%# DataBinder.Eval(Container.DataItem, "FieldSize") %>' />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridEditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src='../images/update.gif' border='0'&gt;"
                                    HeaderText="Sửa" CancelText="&lt;img src='../images/cancel.gif' border='0'&gt;" EditText="&lt;img src='../images/edit2.gif' border='0'&gt;">
                                    <HeaderStyle Width="5%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridEditCommandColumn>
                                <telerik:GridButtonColumn Text="&lt;img src='../images/delete.gif' border='0'&gt;" HeaderText="Xo&#225;" CommandName="Delete">
                                    <HeaderStyle Width="5%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridButtonColumn>
                                </Columns>
                                <PagerTemplate>
                                    <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                </PagerTemplate>
                            </MasterTableView>

                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                        </telerik:RadGrid>

<%--                        <asp:DataGrid ID="dtgDicSelfMade" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            Width="100%" PageSize="15">
                            <Columns>
                                <asp:TemplateColumn Visible="False">
                                    <HeaderStyle Width="1px"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="T&#234;n từ điển tự tạo">
                                    <HeaderStyle Width="60%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink CssClass="lbLinkfunction" ID="lnkName" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "ShowSelfMade") %>' runat="server">
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="150" runat="server" CssClass="lbTextbox" ID="txtName" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="C&#225;n bộ">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <input type="checkbox" id="chkForStaffV" runat="server" checked='<%# DataBinder.Eval(Container.DataItem, "ForStaff") %>' disabled="disabled"></input>
                                        <label id="Label3" runat="server" for="c3"></label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkForStaffE" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ForStaff") %>'></asp:CheckBox>
                                        <label id="Label2" runat="server" for="c3"></label>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Bạn đọc">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <input type="checkbox" id="chkForPatronV" runat="server" checked='<%# DataBinder.Eval(Container.DataItem, "ForPatron") %>' disabled="disabled"></input>
                                        <label id="Label1" runat="server" for="c3"></label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkForPatronE" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "ForPatron") %>'></asp:CheckBox>
                                        <label runat="server" for="c3"></label>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="K&#237;ch thước">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFieldSize" Text='<%# DataBinder.Eval(Container.DataItem, "FieldSize") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="40" runat="server" CssClass="lbTextbox" ID="txtFieldSize" Text='<%# DataBinder.Eval(Container.DataItem, "FieldSize") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src='../images/update.gif' border='0'&gt;"
                                    HeaderText="Sửa" CancelText="&lt;img src='../images/cancel.gif' border='0'&gt;" EditText="&lt;img src='../images/edit2.gif' border='0'&gt;">
                                    <HeaderStyle Width="5%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:EditCommandColumn>
                                <asp:ButtonColumn Text="&lt;img src='../images/delete.gif' border='0'&gt;" HeaderText="Xo&#225;" CommandName="Delete">
                                    <HeaderStyle Width="5%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonColumn>
                            </Columns>
                            <PagerStyle Position="Bottom" Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>--%>
                        <table border="0" width="100%" cellpadding="2" cellspacing="1">
                            <tr>
                                <td width="60%">
                                    <asp:TextBox ID="txtNameDic" runat="server"></asp:TextBox></td>
                                <td width="10%" align="center">
                                    <input type="checkbox" id="chkStaff" runat="server" checked="True"></input>
                                    <label id="Label5" runat="server" for="c3"></label>
                                </td>
                                <td width="10%" align="center">
                                    <input type="checkbox" id="chkPatron" runat="server" checked="True"></input>
                                    <label id="Label4" runat="server" for="c3"></label>
                                </td>

                                <td width="10%" align="center">
                                    <asp:TextBox ID="txtFieldSizeDic" runat="server" Width="90%">0</asp:TextBox></td>
                                <td width="10%" colspan="2" align="center">
                                    <asp:Button ID="btnNewDic" runat="server" Text="Thêm(n)" CssClass="lbButton" Width=""></asp:Button></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>

    </form>
    <script language="javascript">
        document.forms[0].txtNameDic.focus();
    </script>
    <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
        <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="2">Tên từ điển đã tồn tại trong CSDL!</asp:ListItem>
        <asp:ListItem Value="3">Cập nhật thành công!</asp:ListItem>
        <asp:ListItem Value="4">Chọn OK nếu bạn thực sự muốn xoá từ điển này!</asp:ListItem>
        <asp:ListItem Value="5">Bạn chưa nhập tên từ điển!#Kích thước phải là số và lớn hơn 0 và bé hơn 4000!</asp:ListItem>
        <asp:ListItem Value="6">Sai định dạng dữ liệu!</asp:ListItem>
        <asp:ListItem Value="7">Kích thước từ điển mới không được nhỏ hơn kích thước ban đầu! Kích thước ban đầu là :</asp:ListItem>
        <asp:ListItem Value="8">Kích thước phải là số bé hơn 4000 </asp:ListItem>
        <asp:ListItem Value="9">Bạn không được cấp quyền sử dụng chức năng này.</asp:ListItem>
    </asp:DropDownList>
</body>
</html>
