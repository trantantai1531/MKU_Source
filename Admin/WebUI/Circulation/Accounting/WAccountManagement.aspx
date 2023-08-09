<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WAccountManagement" CodeFile="WAccountManagement.aspx.vb" MaintainScrollPositionOnPostback="true" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="radgridpagerusc" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 TRansitional//EN">
<html>
<head>
    <title>WAccountManagement</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
    <link href="../../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="if (eval('document.forms[0].txtRate')) {ChangeRate('VND');}">
    <form id="Form2" method="post" runat="server">


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
            <div id="TabbedPanels1" class="TabbedPanels" style="display: none">
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink ID="lnkSettled" runat="server" Visible="False">
                                <span class="icon-history"></span>
                                <p>Khai báo khoản thu </p>
                                </asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink ID="lnkUnsettled" runat="server">
                                <span class="icon-history"></span>
                                <p>Khai báo khoản phải thu 
                                </p>
                                </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink ID="lnkReport" runat="server">
                                <span class="icon-history"></span>
                                <p>Báo cáo </p></asp:HyperLink></li>
                        </ul>
                    </div>
                </div>
            </div>
            <asp:Label ID="lblSettledTitle" CssClass="main-group-form" runat="server">Khai báo khoản thu</asp:Label>
            <asp:Label ID="lblUnSettledTitle" CssClass="main-group-form" runat="server" Visible="False">Khai báo khoản phải thu</asp:Label>
            <asp:Label ID="lblReportTitle" CssClass="main-group-form" runat="server" Visible="False">Báo cáo</asp:Label>

            <div class="two-column ClearFix" id="pnReport" runat="server">
                <div class="two-column-form">
                    <div id="TR1" runat="server">
                        <div class="row-detail">
                            <asp:Label ID="lblPatronCode" runat="server" CssClass="lbLabel">Số thẻ:</asp:Label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtPatronCode" runat="Server" AutoPostBack="True" Width="72px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <asp:Label ID="lblReason" runat="server" CssClass="lbLabel">Lí do:</asp:Label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtReason" runat="server" Width="100%" Rows="4" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="TR2" runat="server">
                        <div class="row-detail">
                            <asp:Label ID="lblAmount" runat="server" CssClass="lbLabel">Số tiền:</asp:Label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtAmount" runat="Server" Width="104px">0</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Đơn vị tính :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlCurrency" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="TR3" runat="server">
                        <div class="row-detail">
                            <asp:Label ID="lblRate" runat="server" CssClass="lbLabel">Tỉ giá (so với VND):</asp:Label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtRate" runat="Server" Width="56px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="TR4" class="two-column-form" runat="server">
                    <div class="row-detail">
                        <asp:Label ID="lblDate" runat="server" CssClass="lbLabel">Ngày thu:</asp:Label><asp:HyperLink ID="lnkDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtDate" runat="Server" Width="72px"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row-detail">
                        <div class="checkbox-control">
                            <asp:CheckBox ID="chkPatronDept" runat="server" Text="" Checked="True" CssClass="lbCheckbox"></asp:CheckBox>
                            <label for="chkPatronDept"></label>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnAction" runat="server" CssClass="lbButton" Text="Thực hiện"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnCancel" runat="server" CssClass="lbButton" Text="Huỷ bỏ"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <h1 class="main-group-form">Chi tiết</h1>
            <div class="row-detail">
                <p>
                    <b>Tổng phải thu:</b>
                    <asp:Label ID="lblUnSettledAmount" runat="server" CssClass="lbAmount"></asp:Label>
                    VND
                </p>
                <p>
                    <b>Tổng thu:</b>
                    <asp:Label ID="lblSettledAmount" runat="server" CssClass="lbAmount"></asp:Label>
                    VND
                </p>
                <p>
                    <b>Còn lại:</b>
                    <asp:Label ID="lblRemainAmount" runat="server" CssClass="lbAmount"></asp:Label>
                    VND
                </p>
            </div>

            <asp:Label ID="lblSettledDetails" runat="server" CssClass="main-group-form">Các khoản thu</asp:Label>
            <asp:Label ID="lblUnSettledDetails" runat="server" Visible="False" CssClass="main-group-form">Các khoản phải thu</asp:Label>
            <asp:Label ID="lblReportDetails" runat="server" Visible="False" CssClass="main-group-form">Báo cáo các khoản trong:</asp:Label>

            <div class="row-detail">
                <div class="input-control inline-box">
                    <p>Số thẻ :</p>
                    <div class="input-form ">
                        <asp:TextBox CssClass="text-input" ID="txtPaTronCodeToFil" runat="server" Width="72px"></asp:TextBox>
                    </div>
                    <p>Thời điểm :</p>
                    <div class="dropdown-form">
                        <asp:DropDownList ID="ddlMonth" runat="server">
                            <asp:ListItem Value="0" Selected="True">Trong tháng: </asp:ListItem>
                            <asp:ListItem Value="1">Tháng 1</asp:ListItem>
                            <asp:ListItem Value="2">Tháng 2</asp:ListItem>
                            <asp:ListItem Value="3">Tháng 3</asp:ListItem>
                            <asp:ListItem Value="4">Tháng 4</asp:ListItem>
                            <asp:ListItem Value="5">Tháng 5</asp:ListItem>
                            <asp:ListItem Value="6">Tháng 6</asp:ListItem>
                            <asp:ListItem Value="7">Tháng 7</asp:ListItem>
                            <asp:ListItem Value="8">Tháng 8</asp:ListItem>
                            <asp:ListItem Value="9">Tháng 9</asp:ListItem>
                            <asp:ListItem Value="10">Tháng 10</asp:ListItem>
                            <asp:ListItem Value="11">Tháng 11</asp:ListItem>
                            <asp:ListItem Value="12">Tháng 12</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <p>/</p>
                    <div class="input-form " style="width: 110px">
                        <asp:TextBox CssClass="text-input" ID="txtYear" runat="server" Width="50px"></asp:TextBox>
                    </div>
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnFilter" runat="server" CssClass="lbButton" Text="Lọc"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnPrint" runat="server" CssClass="lbButton" Text="In"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="input-control row-detail">
                <div class="table-form">


                    <telerik:RadGrid ID="dgtResult" runat="server" AllowPaging="True"
                        CellSpacing="0"
                        AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dgtResult_NeedDataSource">
                        <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                            <PagerStyle AlwaysVisible="True" />
                            <FooterStyle BackColor="White"></FooterStyle>

                            <Columns>

                                <telerik:GridTemplateColumn HeaderText="Ngày thu">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreatedDate" Text='<%# DataBinder.Eval(Container.DataItem, "FromDate")%>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="100%" runat="server" ID="txtCreatedDate" Text='<%# DataBinder.Eval(Container.DataItem, "FromDate") %>' />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Số thẻ">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblPatronCodeDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "PatronCode") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="100%" runat="server" ID="txtPatronCodeDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "PatronCode") %>' />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Lý do">
                                    <HeaderStyle Width="30%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblReasonDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Reason") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="100%" runat="server" ID="txtReasonDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Reason") %>' />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Số tiền">
                                    <HeaderStyle Width="13%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmountDisplay" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Amount") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="100%" runat="server" ID="txtAmountDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Amount") %>' />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Đơn vị TT">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCurrency" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"Currency")%>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Visible="False" runat="server" ID="txtCurrencyHid" Text='<%# DataBinder.Eval(Container.DataItem, "Currency") %>'>
                                        </asp:TextBox>
                                        <asp:DropDownList ID="ddlCurrencyDisplay" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Tỉ giá">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblRateDisplay" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"Rate")%>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="100%" runat="server" ID="txtRateDisplay" ReadOnly="True" Text='<%# DataBinder.Eval(Container.DataItem, "Rate") %>' />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Thành tiền">
                                    <HeaderStyle Width="13%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Total")%>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Sửa">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="<img src='../../images/edit2.gif' border='0'>" CommandName="Edit"
                                            CausesValidation="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkdtgUpdate" runat="server" Text="<img src='../../images/update.gif' border='0'>"
                                            CommandName="Update"></asp:LinkButton>&nbsp;
											<asp:LinkButton runat="server" Text="<img src='../../images/cancel.gif' border='0'>" CommandName="Cancel"
                                                CausesValidation="false"></asp:LinkButton>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Xoá">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="<img src='../../images/delete.gif' border='0'>" CommandName="Delete"
                                            CausesValidation="false" ID="lnkdtgDelete"></asp:LinkButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <PagerTemplate>
                                <gusc:radgridpagerusc runat="server" id="RadGridPagerUSC" clientidmode="Static" />
                            </PagerTemplate>
                        </MasterTableView>

                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                    </telerik:RadGrid>


                 <%--   <asp:DataGrid ID="dgtResult" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="10">
                        <EditItemStyle CssClass="lbGridEdit"></EditItemStyle>
                        <AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
                        <ItemStyle CssClass="lbGridCell"></ItemStyle>
                        <HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
                        <Columns>
                            <asp:TemplateColumn HeaderText="Ngày thu">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedDate" Text='<%# DataBinder.Eval(Container.DataItem, "FromDate")%>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" ID="txtCreatedDate" Text='<%# DataBinder.Eval(Container.DataItem, "FromDate") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Số thẻ">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblPatronCodeDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "PatronCode") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" ID="txtPatronCodeDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "PatronCode") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Lý do">
                                <HeaderStyle Width="30%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblReasonDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Reason") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" ID="txtReasonDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Reason") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Số tiền">
                                <HeaderStyle Width="13%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblAmountDisplay" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Amount") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" ID="txtAmountDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Amount") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Đơn vị TT">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblCurrency" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"Currency")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Visible="False" runat="server" ID="txtCurrencyHid" Text='<%# DataBinder.Eval(Container.DataItem, "Currency") %>'>
                                    </asp:TextBox>
                                    <asp:DropDownList ID="ddlCurrencyDisplay" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Tỉ giá">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblRateDisplay" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"Rate")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" ID="txtRateDisplay" ReadOnly="True" Text='<%# DataBinder.Eval(Container.DataItem, "Rate") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Thành tiền">
                                <HeaderStyle Width="13%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblTotal" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Total")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Sửa">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" Text="<img src='../../images/edit2.gif' border='0'>" CommandName="Edit"
                                        CausesValidation="false"></asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkdtgUpdate" runat="server" Text="<img src='../../images/update.gif' border='0'>"
                                        CommandName="Update"></asp:LinkButton>&nbsp;
											<asp:LinkButton runat="server" Text="<img src='../../images/cancel.gif' border='0'>" CommandName="Cancel"
                                                CausesValidation="false"></asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Xoá">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" Text="<img src='../../images/delete.gif' border='0'>" CommandName="Delete"
                                        CausesValidation="false" ID="lnkdtgDelete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Mode="NumericPages" />
                    </asp:DataGrid>--%>
                </div>
                <div id="TRSumary" runat="server">

                    <asp:Label ID="lblSumaryTemp" runat="server">Tổng: </asp:Label><asp:Label ID="lblSumary" runat="server" CssClass="lbAmount"></asp:Label>


                </div>
                <div class="table-form">
                    <asp:Table ID="tblReport" runat="server" CellPadding="2" CellSpacing="1"></asp:Table>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0" Height="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn phải nhập dữ liệu kiểu số!</asp:ListItem>
            <asp:ListItem Value="3">Bảng cân đối các khoản thu và phải thu</asp:ListItem>
            <asp:ListItem Value="4">Ngày</asp:ListItem>
            <asp:ListItem Value="5">Diễn giải</asp:ListItem>
            <asp:ListItem Value="6">Thu</asp:ListItem>
            <asp:ListItem Value="7">Phải thu</asp:ListItem>
            <asp:ListItem Value="8">Tỉ giá hạch toán</asp:ListItem>
            <asp:ListItem Value="9">Số tiền</asp:ListItem>
            <asp:ListItem Value="10">Đơn vị TT</asp:ListItem>
            <asp:ListItem Value="11">Tỉ giá thực tế</asp:ListItem>
            <asp:ListItem Value="12">Số tiền chênh lệch với tỉ giá (VND)</asp:ListItem>
            <asp:ListItem Value="13">Tổng</asp:ListItem>
            <asp:ListItem Value="14">Số dư</asp:ListItem>
            <asp:ListItem Value="15">Số tiền nhập vào phải lớn hơn 0!</asp:ListItem>
            <asp:ListItem Value="16">Tỉ giá phải lớn hơn 0!</asp:ListItem>
            <asp:ListItem Value="17">Số tiền nhập vào phải là kiểu số!</asp:ListItem>
            <asp:ListItem Value="18">Tỉ giá nhập vào phải là kiểu số!</asp:ListItem>
            <asp:ListItem Value="19">Khuôn dạng ngày tháng không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="20">Các trường không được bỏ trống!</asp:ListItem>
            <asp:ListItem Value="21">Số thẻ bạn đọc không tồn tại!</asp:ListItem>
            <asp:ListItem Value="22">Giao dịch đã được ghi nhận!</asp:ListItem>
            <asp:ListItem Value="23">Giao dịch thất bại!</asp:ListItem>
            <asp:ListItem Value="24">Cập nhật thành công!</asp:ListItem>
            <asp:ListItem Value="25">Cập nhật thất bại!</asp:ListItem>
            <asp:ListItem Value="26">Bạn có muốn xoá khoản thu không?</asp:ListItem>
            <asp:ListItem Value="27">Bạn có muốn xoá khoản phải thu không?</asp:ListItem>
            <asp:ListItem Value="28">Sửa khoản thu</asp:ListItem>
            <asp:ListItem Value="29">Sửa khoản phải thu</asp:ListItem>
            <asp:ListItem Value="30">Xoá khoản thu</asp:ListItem>
            <asp:ListItem Value="31">Xoá khoản phải thu</asp:ListItem>
            <asp:ListItem Value="32">Không có dữ liệu thoả mãn điều kiện!</asp:ListItem>
            <asp:ListItem Value="33">Thanh toán nợ bạn đọc</asp:ListItem>
            <asp:ListItem Value="34">Tính vào nợ bạn đọc</asp:ListItem>
        </asp:DropDownList>
        <input id="hidCurrency" type="hidden" name="hidCurrency" runat="server" />
        <input id="hidToday" type="hidden" name="hidToday" runat="server" />
    </form>
    <script language="javascript">
        document.forms[0].txtPaTronCodeToFil.focus();
    </script>
</body>
</html>
