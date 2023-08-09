<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WContractPickItems" CodeFile="WContractPickItems.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Chọn ấn phẩm cần đặt mua</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <script src="../Js/PO/wContractPickItem.js"></script>
    <link href="../../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
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
        <div class="lbPageTitle" style="font-size:14pt;">
            <asp:Label ID="lblMainTitle" runat="server" Width="100%" CssClass="main-group-form">Chọn ấn phẩm cho đơn đặt</asp:Label>
        </div>
        <div >
            <div class="button-control">
                <div class="button-form">
                    <input id="btnCheckAll" runat="server" Visible="False" class="lbButton" type="button" value="Chọn tất cả" onclick="CheckAllGrid()" />
                </div>
                <div class="button-form">
                    <input id="btnUnCheckAll" runat="server" Visible="False" class="lbButton" type="button" value="Bỏ chọn tất cả" onclick="UnCheckAllGrid()" />
                </div>
            </div>
        </div>
        <table id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
            

            <tr>
                <td>
                    <telerik:RadGrid ID="dtgItem" runat="server" AllowPaging="False"
                        CellSpacing="0"
                        AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgItem_NeedDataSource">
                        <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                            <PagerStyle AlwaysVisible="True" />
                            <FooterStyle BackColor="White"></FooterStyle>

                            <Columns>
                                <telerik:GridTemplateColumn Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn ItemStyle-CssClass="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="6%">
                                    <HeaderTemplate>
                                        <input type="checkbox" class="lbCheckBox" id="CheckAll" onclick="javascript: CheckAllOptionsVisible('dtgItem', 'chkSelectedID', 2, 500);">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" id="chkSelectedID" class="ckb-value" runat="server"></input>
                                        <label for="chkSelectedID"></label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="MainTitle" HeaderText="Nhan đề"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TypeCode" HeaderText="Dạng tài liệu" ItemStyle-Width="8%"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Code" HeaderText="Mức độ mật" ItemStyle-Width="7%"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RequestedCopies" HeaderText="Số bản đặt" ItemStyle-Width="7%"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="UnitPrice" HeaderText="Đơn giá" ItemStyle-CssClass="Right" ItemStyle-Width="8%"></telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Note" HeaderText="Ghi chú" ItemStyle-Width="20%"></telerik:GridBoundColumn>
                            </Columns>
                            <PagerTemplate>
                                <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                            </PagerTemplate>
                        </MasterTableView>

                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                    </telerik:RadGrid>



                    <%--        <asp:datagrid id="dtgItem" runat="server" Width="100%" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:Label id="lblID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server">
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-CssClass="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="6%">
									<HeaderTemplate>
										<input type="checkbox" class="lbCheckBox" id="CheckAll" onclick="javascript: CheckAllOptionsVisible('dtgItem', 'chkSelectedID', 2, 500);">
									</HeaderTemplate>
									<ItemTemplate>
										<input type="checkbox" id="chkSelectedID" Runat="server"></input>
                                        <label for="chkSelectedID"></label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="MainTitle" HeaderText="Nhan đề"></asp:BoundColumn>
								<asp:BoundColumn DataField="TypeCode" HeaderText="Dạng tài liệu" ItemStyle-Width="8%"></asp:BoundColumn>
								<asp:BoundColumn DataField="Code" HeaderText="Mức độ mật" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="RequestedCopies" HeaderText="Số bản đặt" ItemStyle-Width="7%"></asp:BoundColumn>
								<asp:BoundColumn DataField="UnitPrice" HeaderText="Đơn giá" ItemStyle-CssClass="Right" ItemStyle-Width="8%"></asp:BoundColumn>
								<asp:BoundColumn DataField="Note" HeaderText="Ghi chú" ItemStyle-Width="20%"></asp:BoundColumn>
							</Columns>
						</asp:datagrid>--%>

                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnSelect" OnClientClick="if(!CheckOptionsNullByCssClass('ckb-value', 'chkID', 2, 50, 'Bạn phải chọn ít nhất một ấn phẩm')) return false;" runat="server" Width="64px" Visible="False" Text="Chọn(c)"></asp:Button>&nbsp;<asp:Button ID="btnClose" runat="server" Width="64px" Text="Đóng(o)"></asp:Button></td>
            </tr>
        </table>
        <input id="txbContractID" type="hidden" value="0" runat="server" />
        <input id="txbTypeID" type="hidden" value="0" runat="server" />
        <asp:DropDownList ID="ddlLabel" Width="0" Visible="False" runat="server">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Gắn tài liệu vào hợp đồng</asp:ListItem>
        </asp:DropDownList>
    </form>
<script type="text/javascript">
 
    function CheckAllGrid() {       
        $("#<% =dtgItem.ClientID %> input[type='checkbox']").each(function () {
            $(this).prop('checked', true);
            var chkId = $(this).attr('id');
        });
    }

    function UnCheckAllGrid() {
        $("#<% =dtgItem.ClientID %> input[type='checkbox']").each(function () {
            $(this).prop('checked', false);
        });
    }


</script>
</body>
</html>
