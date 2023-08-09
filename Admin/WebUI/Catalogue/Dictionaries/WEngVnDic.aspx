<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WEngVnDic" CodeFile="WEngVnDic.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

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
                <h1 class="main-head-form">Quản lý từ điển Anh Việt</h1>
                <div class="form-group">
                    <label >Import từ điển:</label>
                    <asp:FileUpload ID="fupload" runat="server" />
                   
                    <asp:Button ID="btnImport" class="btn btn-default" runat="server" Text="Import" />
                </div>
                  <div class="form-group" runat="server" id="dvError">
                         <label ></label>
                      <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </div>
                 
                <div class="input-control row-detail">
                    <div class="table-form">

                        <telerik:RadGrid ID="dtgDicData" runat="server" AllowPaging="True"
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

                                    <telerik:GridTemplateColumn HeaderText="Từ vựng" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="LblCode" Text='<%# DataBinder.Eval(Container.DataItem, "EnglishVocabulary")%>' runat="server">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox Width="300" CssClass="lbTextBox" runat="server" ID="txtEnglishVocabulary" Text='<%# DataBinder.Eval(Container.DataItem, "EnglishVocabulary")%>' />
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>


                                    <telerik:GridTemplateColumn HeaderText="Nghĩa từ vựng" ItemStyle-Width="8%">
                                        <ItemTemplate>
                                            <asp:Label ID="LblMean" Text='<%# DataBinder.Eval(Container.DataItem, "Mean")%>' runat="server">
                                            </asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox Width="300" CssClass="lbTextBox" runat="server" ID="txtMean" Text='<%# DataBinder.Eval(Container.DataItem, "Mean")%>' />
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>


                                    <telerik:GridEditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src='../images/update.gif' border='0'&gt;"
                                        HeaderText="Sửa" CancelText="&lt;img src='../images/cancel.gif' border='0'&gt;" EditText="&lt;img src='../images/edit2.gif' border='0'&gt;">
                                        <HeaderStyle Width="5%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridEditCommandColumn>
                                    <telerik:GridButtonColumn ConfirmText="Chọn OK nếu bạn thực sự muốn xoá từ điển này!" ConfirmDialogType="RadWindow"  Text="&lt;img src='../images/delete.gif' border='0'&gt;" HeaderText="Xo&#225;" CommandName="Delete">
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


                        <table border="0" width="100%" cellpadding="2" cellspacing="1">
                            <tr>
                                <td width="40%">
                                    <asp:TextBox ID="txtEnglishVocabuary" runat="server"></asp:TextBox></td>
                                <td width="50%" align="center">
                                    <asp:TextBox ID="txtMean" runat="server"></asp:TextBox>
                                </td>

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
        <asp:ListItem Value="5">Bạn chưa nhập từ vựng</asp:ListItem>
        <asp:ListItem Value="6">Bạn chưa nhập nghĩa từ vựng</asp:ListItem>
        <asp:ListItem Value="7">Kích thước từ điển mới không được nhỏ hơn kích thước ban đầu! Kích thước ban đầu là :</asp:ListItem>
        <asp:ListItem Value="8">Kích thước phải là số bé hơn 4000 </asp:ListItem>
        <asp:ListItem Value="9">Bạn không được cấp quyền sử dụng chức năng này.</asp:ListItem>
    </asp:DropDownList>
</body>
</html>
