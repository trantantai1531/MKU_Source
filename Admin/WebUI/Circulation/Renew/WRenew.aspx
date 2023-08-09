<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WRenew" CodeFile="WRenew.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WRenew</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script src="../../js/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('a[href^="#"]').click(function (e) {
                e.preventDefault();
            });
        })
    </script>
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
            <h1 class="main-head-form">Gia hạn</h1>
            <div class="main-form">
                <div class="row-detail inline-box">
                    <p>Mã số :</p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtTypeVal" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="radio-control">
                        <asp:RadioButton ID="optHolding" runat="server" GroupName="optType" Text="<U>Đ</U>KCB"></asp:RadioButton>
                        <label for="optHolding"></label>
                        <asp:RadioButton ID="optCardNo" runat="server" GroupName="optType" Text="<U>S</U>ố thẻ " Checked="True"></asp:RadioButton>
                        <label for="optCardNo"></label>
                        <asp:RadioButton ID="optItemCode" runat="server" GroupName="optType" Text="Mã <U>t</U>ài liệu"></asp:RadioButton>
                        <label for="optItemCode"></label>
                    </div>
                </div>

                <div class="row-detail">
                    <div class="button-control">

                        <div class="button-form">
                            <asp:Button ID="btnFilter" runat="server" Width="" Text="Lọc(f)"></asp:Button>
                        </div>
                    </div>
                    <div class="button-control">
                    </div>
                </div>
                <div class="row-detail table-form">

                    <telerik:RadGrid ID="dtgReNewInfor" runat="server" AllowPaging="True"
                        CellSpacing="0"
                        AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgReNewInfor_NeedDataSource">
                        <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                            <PagerStyle AlwaysVisible="True" />
                            <FooterStyle BackColor="White"></FooterStyle>

                            <Columns>
                                <telerik:GridTemplateColumn Display="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn>
                                    <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                                    <ItemTemplate>
                                        <input type="checkbox" id="chkID" runat="server"></input>
                                        <label for="chkID" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPatronCode" Text='<%# DataBinder.Eval(Container.dataItem,"Code") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Content" HeaderText="Nhan đề">
                                    <headerstyle width="40%"></headerstyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TimeHold" HeaderText="Thời gian mượn">
                                    <itemstyle horizontalalign="Center" width="13%"></itemstyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="FullName" HeaderText="Bạn đọc">
                                    <headerstyle width="20%"></headerstyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Đ&#227; gia hạn">
                                    <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRenewCount" Text='<%# DataBinder.Eval(Container.dataItem,"RenewCount") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Số lượt gia hạn tối đa">
                                    <itemstyle horizontalalign="Center" width="8%"></itemstyle>
                                    <itemtemplate>
                                    <asp:Label ID="lblRenewals" Text='<%# DataBinder.Eval(Container.dataItem,"Renewals") %>' runat="server">
                                    </asp:Label>
                                </itemtemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="strNote" HeaderText="Ghi ch&#250;"></telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn Visible="False">
                                    <itemtemplate>
                                    <asp:Label ID="lblToday" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"Today") %>'>
                                    </asp:Label>
                                </itemtemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn Visible="False">
                                    <itemtemplate>
                                    <asp:Label ID="lblDueDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DueDate") %>'>
                                    </asp:Label>
                                </itemtemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="CheckReNew" Visible="False">
                                    <itemstyle horizontalalign="Center" width="8%"></itemstyle>
                                    <itemtemplate>
                                    <asp:Label ID="lblCheckReNew" Text='<%# DataBinder.Eval(Container.DataItem, "CheckReNew")%>' runat="server">
                                    </asp:Label>
                                </itemtemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <PagerTemplate>
                                <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                            </PagerTemplate>
                        </MasterTableView>

                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                    </telerik:RadGrid>



                 <%--   <asp:DataGrid ID="dtgReNewInfor" CssClass="table-control" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateColumn Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <ItemStyle HorizontalAlign="Center" Width="3%"></ItemStyle>
                                <ItemTemplate>
                                    <input type="checkbox" id="chkID" runat="server"></input>
                                    <label for="chkID" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblPatronCode" Text='<%# DataBinder.Eval(Container.dataItem,"Code") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Content" HeaderText="Nhan đề">
                                <HeaderStyle Width="40%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="TimeHold" HeaderText="Thời gian mượn">
                                <ItemStyle HorizontalAlign="Center" Width="13%"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="FullName" HeaderText="Bạn đọc">
                                <HeaderStyle Width="20%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Đ&#227; gia hạn">
                                <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblRenewCount" Text='<%# DataBinder.Eval(Container.dataItem,"RenewCount") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Số lượt gia hạn tối đa">
                                <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblRenewals" Text='<%# DataBinder.Eval(Container.dataItem,"Renewals") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="strNote" HeaderText="Ghi ch&#250;"></asp:BoundColumn>
                            <asp:TemplateColumn Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblToday" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"Today") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblDueDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DueDate") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="CheckReNew" Visible="False">
                                <ItemStyle HorizontalAlign="Center" Width="8%"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblCheckReNew" Text='<%# DataBinder.Eval(Container.DataItem, "CheckReNew")%>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>--%>
                </div>

                <div class="row-detail">

                 
                   <asp:HyperLink ID="lblFixDueDate" runat="server">Lịch</asp:HyperLink>    <%--    <asp:label id="lblFixDueDate" runat="server"><u>N</u>gày gia hạn cụ thể:</asp:label>&nbsp; <asp:HyperLink ID="lnkCal" runat="server" NavigateUrl="javascript:OpenWindow('../../Common/WCalendar.aspx?id=opener.document.forms[0].txtFixDueDate','Calendar',200,256,220,100)">Lịch</asp:HyperLink>--%>
                 <%--   <a href="#" onclick="popUpCalendar(this, document.forms[0].txtFixDueDate, 'dd/mm/yyyy',26)" class="lbLinkFunction" id="lnkStartDate">Lịch</a>--%>
                    <div class="input-control">
                        <div class="input-form">
                            <asp:TextBox ID="txtFixDueDate" CssClass="text-input" runat="server" Width=""></asp:TextBox>

                            <input id="Hidden1" type="hidden" name="txthidRenewalPeriod" runat="server" />

                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnRenew" runat="server" Width="" Text="Gia hạn(r)" Visible="False"></asp:Button>
                        </div>
                        <div class="button-form">
                            <%-- <asp:Button ID="btnFilter" runat="server" Width="" Text="Lọc(f)"></asp:Button>--%>
                        </div>
                    </div>
                    <div class="button-control">
                    </div>
                </div>
                <div>
                    <input id="txthidRenewalPeriod" type="hidden" name="txthidRenewalPeriod" runat="server" />
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" Width="0" Visible="False" runat="server">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Vượt quá số lượt được gia hạn|Chưa đến thời điểm được gia hạn|Có người đang đặt |Có người đang đặt chỗ|Đã quá hạn trả |Đã hết lượt được gia hạn</asp:ListItem>
            <asp:ListItem Value="3">Gia hạn mượn tài liệu</asp:ListItem>
            <asp:ListItem Value="4">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="5">Ngày gia hạn nằm ngoài khoảng thời gian hiệu lực. Gia hạn không thành công.</asp:ListItem>
            <asp:ListItem Value="6">Đã hết lượt được gia hạn</asp:ListItem>
            <asp:ListItem Value="7">Ngày gia hạn không phù hợp.</asp:ListItem>
            <asp:ListItem Value="8">Bạn không được cấp quyền sử dụng chức năng này.</asp:ListItem>
            <asp:ListItem Value="9">Gia hạn thành công.</asp:ListItem>
            <asp:ListItem Value="10">Đã quá hạn trả. Gia hạn không thành công.</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        //  document.forms[0].txtTypeVal.focus();
    </script>
</body>
</html>
