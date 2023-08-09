<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WViewItemOrder" CodeFile="WViewItemOrder.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Danh sách ấn phẩm duyệt mua</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <script language="javascript" src="../Js/WACQCheckAll.js"></script>
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
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
                <h1 class="main-head-form">Duyệt yêu cầu đặt mua ấn phẩm</h1>
                <div class="input-control">
                    <div class="table-form">
                        
                        
                         <telerik:RadGrid ID="dtgBOAccepted" runat="server" AllowPaging="False"
                                CellSpacing="0"
                                AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgBOAccepted_NeedDataSource">
                                <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                    <PagerStyle AlwaysVisible="True" />
                                    <FooterStyle BackColor="White"></FooterStyle>

                                    <Columns>
                                           <telerik:GridTemplateColumn  HeaderText="Chọn" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="optChoice" runat="server" Checked="False"></asp:CheckBox>
                                         <label for="optChoice"></label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                      
                                           <telerik:GridHyperLinkColumn Target="_blank" DataNavigateUrlFields="URL" DataNavigateUrlFormatString="{0}" DataTextField="MainTitle"
                                    ItemStyle-CssClass="lbLinkFunction" HeaderText="Nhan đề"></telerik:GridHyperLinkColumn>
                                        
                                           <telerik:GridTemplateColumn  HeaderText="Duyệt" ItemStyle-Height="5%">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAccepted" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"Accepted") %>' Width="20">
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Yêu cầu" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelType" Font-Bold="true" ForeColor="#000000" runat="server" Text='<%# If(DataBinder.Eval(Container.DataItem, "TypeID") = 0, "Ấn phẩm nhiều kỳ", "Ấn phẩm đơn bản") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        
                                        <telerik:GridBoundColumn DataField="TypeCode" HeaderText="Dạng tài liệu">
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Code" HeaderText="Vật mang tin">
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RequestedCopies" HeaderText="Số bản yêu cầu">
                                    <HeaderStyle Width="7%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="MoneyPrice" HeaderText="Ðơn giá">
                                    <HeaderStyle Width="9%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Amount" HeaderText="Tổng tiền">
                                    <HeaderStyle Width="12%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Requester" HeaderText="Người yêu cầu">
                                    <HeaderStyle Width="9%"></HeaderStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Note" HeaderText="Ghi chú">
                                    <HeaderStyle Width="13%"></HeaderStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn Display="False" DataField="ID"></telerik:GridBoundColumn>
                                    </Columns>
                                    <PagerTemplate>
                                        <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                    </PagerTemplate>
                                </MasterTableView>

                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                            </telerik:RadGrid>


                        <%--<asp:DataGrid ID="dtgBOAccepted" runat="server" Width="100%" PageSize="3" AutoGenerateColumns="False"
                            HeaderStyle-CssClass="lbGridHeader" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="lbGridItem"
                            AlternatingItemStyle-CssClass="lbGridAlterCell">
                            <AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
                            <ItemStyle CssClass="lbGridItem"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="lbGridHeader"></HeaderStyle>
                            <Columns>
                                <asp:TemplateColumn HeaderText="Chọn" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="optChoice" runat="server" Checked="False"></asp:CheckBox>
                                         <label for="optChoice"></label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:HyperLinkColumn Target="_blank" DataNavigateUrlField="URL" DataNavigateUrlFormatString="{0}" DataTextField="MainTitle"
                                    ItemStyle-CssClass="lbLinkFunction" HeaderText="Nhan đề"></asp:HyperLinkColumn>
                                <asp:TemplateColumn HeaderText="Duyệt" ItemStyle-Height="5%">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAccepted" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"Accepted") %>' Width="20">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="TypeCode" HeaderText="Dạng tài liệu">
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Code" HeaderText="Vật mang tin">
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="RequestedCopies" HeaderText="Số bản yêu cầu">
                                    <HeaderStyle Width="7%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="MoneyPrice" HeaderText="Ðơn giá">
                                    <HeaderStyle Width="9%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Amount" HeaderText="Tổng tiền">
                                    <HeaderStyle Width="12%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Requester" HeaderText="Người yêu cầu">
                                    <HeaderStyle Width="9%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Note" HeaderText="Ghi chú">
                                    <HeaderStyle Width="13%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                            </Columns>
                            <PagerStyle VerticalAlign="Bottom" NextPageText="Trang tiếp" Font-Bold="True" PrevPageText="Trang trước"
                                HorizontalAlign="Right" Position="TopAndBottom"></PagerStyle>
                        </asp:DataGrid>--%>
                    </div>
                    <div class="row-detail">
                        <div class="button-control" style="text-align: center">
                            <div class="button-form">
                                <input id="btnCheckAllGrid" class="lbButton" type="button" value="Chọn tất cả" onclick="CheckAllGrid()" />
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnAccepted" runat="server" Text="Duyệt(t)" Width="66px"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnStop" runat="server" Text="Thôi duyệt(i)" Width="95px"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnDelete" runat="server" Text="Xoá(x)" Width="60px"></asp:Button>
                            </div>
                            <div class="button-form" style="display:none;">
                                <input id="btnReset" type="reset" value="Làm lại(l)" runat="server" width="63px" class="lbButton"/>
                            </div>
                        </div>
                    </div>

                    <div class="table-form">
                        
                        
                         <telerik:RadGrid ID="dtgBOAccepted2" runat="server" AllowPaging="False"
                                CellSpacing="0"
                                AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgBOAccepted2_NeedDataSource">
                                <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                    <PagerStyle AlwaysVisible="True" />
                                    <FooterStyle BackColor="White"></FooterStyle>

                                    <Columns>
                                           <telerik:GridTemplateColumn  HeaderText="Chọn" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="optChoice" runat="server" Checked="False"></asp:CheckBox>
                                         <label for="optChoice"></label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                      
                                           <telerik:GridHyperLinkColumn Target="_blank" DataNavigateUrlFields="URL" DataNavigateUrlFormatString="{0}" DataTextField="MainTitle"
                                    ItemStyle-CssClass="lbLinkFunction" HeaderText="Nhan đề"></telerik:GridHyperLinkColumn>
                                        
                                           <telerik:GridTemplateColumn  HeaderText="Duyệt" ItemStyle-Height="5%">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAccepted" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"Accepted") %>' Width="20">
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Yêu cầu" ItemStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="LabelType" Font-Bold="true" ForeColor="#000000" runat="server" Text='<%# If(DataBinder.Eval(Container.DataItem, "TypeID") = 0, "Ấn phẩm nhiều kỳ", "Ấn phẩm đơn bản") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        
                                        <telerik:GridBoundColumn DataField="TypeCode" HeaderText="Dạng tài liệu">
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Code" HeaderText="Vật mang tin">
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="RequestedCopies" HeaderText="Số bản yêu cầu">
                                    <HeaderStyle Width="7%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="MoneyPrice" HeaderText="Ðơn giá">
                                    <HeaderStyle Width="9%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Amount" HeaderText="Tổng tiền">
                                    <HeaderStyle Width="12%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Requester" HeaderText="Người yêu cầu">
                                    <HeaderStyle Width="9%"></HeaderStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Note" HeaderText="Ghi chú">
                                    <HeaderStyle Width="13%"></HeaderStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn Display="False" DataField="ID"></telerik:GridBoundColumn>
                                    </Columns>
                                    <PagerTemplate>
                                        <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                    </PagerTemplate>
                                </MasterTableView>

                                <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                            </telerik:RadGrid>
                    </div>
                        <div class="row-detail">
                        <div class="button-control" style="text-align: center">
                            <div class="button-form">
                                <input id="btnCheckAllGrid2" class="lbButton" type="button" value="Chọn tất cả" onclick="CheckAllGrid2()" />
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnAccepted2" runat="server" Text="Duyệt(t)" Width="66px"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnStop2" runat="server" Text="Thôi duyệt(i)" Width="95px"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnDelete2" runat="server" Text="Xoá(x)" Width="60px"></asp:Button>
                            </div>
                            <div class="button-form" style="display:none;">
                                <input id="btnReset2" type="reset" value="Làm lại(l)" runat="server" width="63px" class="lbButton"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Xoá yêu cầu đặt mua</asp:ListItem>
            <asp:ListItem Value="3">Duyệt yêu cầu đặt mua</asp:ListItem>
            <asp:ListItem Value="4">Thôi duyệt yêu cầu đặt mua</asp:ListItem>
            <asp:ListItem Value="5">Duyệt yêu cầu thành công.</asp:ListItem>
            <asp:ListItem Value="6">Không có yêu cầu nào được chọn.</asp:ListItem>
            <asp:ListItem Value="7">Thôi duyệt yêu cầu thành công.</asp:ListItem>
            <asp:ListItem Value="8">Xóa yêu cầu thành công.</asp:ListItem>
            <asp:ListItem Value="9">Bạn không được cấp quyền sử dụng tính năng này.</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script type="text/javascript">
        function CheckAllGrid()
        {
            $("#<% =dtgBOAccepted.ClientID %> input[type='checkbox']").each(function () {
                $(this).prop('checked', true);
            });
        }
        
        function CheckAllGrid2()
        {
            $("#<% =dtgBOAccepted2.ClientID %> input[type='checkbox']").each(function () {
                $(this).prop('checked', true);
            });
        }
    </script>
</body>
</html>
