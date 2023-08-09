<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WEducation" CodeFile="WEducation.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Duyệt xem từ điển trình độ văn hoá</title>
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
<body leftmargin="0" topmargin="0" onload="document.forms[0].txtEducation.focus()">
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
            <h1 class="main-head-form">Trình độ văn hóa</h1>
            <div class="main-form">
                <div class="row-detail">
                    <div class="input-control inline-box">
                        <p>Trình độ :</p>
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtEducation" runat="server" MaxLength="30"></asp:TextBox>
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
                        <telerik:RadGrid ID="dtgEducation" runat="server" AllowPaging="False"
                            CellSpacing="0"
                            AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgEducation_NeedDataSource">
                            <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                <PagerStyle AlwaysVisible="True" />
                                <FooterStyle BackColor="White"></FooterStyle>

                                <Columns>
                                    <telerik:GridBoundColumn Display="False" DataField="ID" ReadOnly="True" HeaderText="ID"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Postion" ReadOnly="True" HeaderText="STT">
                                        <ItemStyle HorizontalAlign="Right" Width="5%"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Tr&#236;nh độ văn ho&#225;">
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EducationLevel") %>'>
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox CssClass="text-input" ID="txtdtgEducation" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.EducationLevel") %>' MaxLength="30">
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
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
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
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-form">
                        <asp:Label ID="lblMerger" runat="server"><U>T</U>rình độ:</asp:Label>
                        <div class="input-control" style="max-width: 120px; display: inline-block;">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlEducation" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <asp:Button ID="btnMerger" runat="server" Text="Gộp(g)" Width="73px"></asp:Button>
                    </div>
                </div>
            </div>

        </div>
        <asp:DropDownList ID="ddlLabelNote" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Nhấn OK để khẳng định xoá trình độ văn hoá này</asp:ListItem>
            <asp:ListItem Value="1">Bạn chưa nhập tên trình độ văn hoá!</asp:ListItem>
            <asp:ListItem Value="2">Trình độ văn hoá</asp:ListItem>
            <asp:ListItem Value="3">đã tồn tại trong cơ sở dữ liệu</asp:ListItem>
            <asp:ListItem Value="4">Bạn phải chọn ít nhất một trình độ văn hoá cần gộp!</asp:ListItem>
            <asp:ListItem Value="5">Bạn có muốn gộp các trình độ đã chọn không?</asp:ListItem>
            <asp:ListItem Value="6">Bạn phải chọn ít nhất một trình độ trước khi gộp!</asp:ListItem>
            <asp:ListItem Value="7">Gộp thành công!</asp:ListItem>
            <asp:ListItem Value="8">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="9">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="10">Bạn phải nhập tên trình độ văn hoá</asp:ListItem>
            <asp:ListItem Value="11">Cập nhật tên trình độ văn hoá </asp:ListItem>
            <asp:ListItem Value="12">Xoá tên trình độ văn hoá</asp:ListItem>
            <asp:ListItem Value="13">Gộp tên trình độ văn hoá</asp:ListItem>
            <asp:ListItem Value="14">thành công</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
