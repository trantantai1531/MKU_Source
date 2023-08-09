<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WAccountDetail" CodeFile="WAccountDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WAccountDetail</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <%--<link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />--%>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .row-detail > p
        {
            width: 100%;
        }
        .lblinkReport
        {
            font-size: 26px;
            height: 30px;
            margin-right: 10px;
            margin-left: 10px;
            text-transform: lowercase !important;
            width: auto;
            text-decoration: none;
        }
        .lblinkReport:hover
        {
            font-size: 26px;
            height: 30px;
            margin-right: 10px;
            margin-left: 10px;
            text-transform: lowercase !important;
            width: auto;
            text-decoration: none;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div style="display: block;" class="TabbedPanelsContent TabbedPanelsContentVisible">
            <h1 class="main-head-form">
                <asp:Label ID="lblHeader" CssClass="lbPageTitle" runat="server"> Quản lý tài chính</asp:Label>
                <div class="col-right-4">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:HyperLink ID="lnkAddAccount" runat="server" CssClass="lblinkReport"></asp:HyperLink>
                        </div>
                        <span class="lbLabel" id="lblTemp1">|</span>
                        <div class="button-form">
                            <asp:HyperLink ID="lnkReport" runat="server" CssClass="lblinkReport">Báo cáo quỹ</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </h1>
            <h1 class="main-group-form">
                <asp:Label ID="lblSettledTitle" runat="server" Visible="False"> Khai báo thu</asp:Label>
                <asp:Label ID="lblSpendTitle" runat="server" CssClass="lbGroupTitle" Visible="False">Khai báo chi</asp:Label><asp:Label
                    ID="lblReportTitle" runat="server" CssClass="lbGroupTitle" Visible="False">Báo cáo</asp:Label>
            </h1>
            <div class="two-column ClearFix">
                    <div class="row-detail">
                        <asp:RadioButton ID="rdoReal" runat="server" CssClass="lbRadio" Text="Dự chi" GroupName="rdoSpendMode"
                            Checked="True"></asp:RadioButton>&nbsp;
                        <asp:RadioButton ID="rdoUnReal" runat="server" CssClass="lbRadio" Text="Thực chi"
                            GroupName="rdoSpendMode"></asp:RadioButton>
                    </div>  
                <div class="two-column-form">
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblBudget" runat="server" CssClass="lbLabel">Quỹ:</asp:Label></p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlBudget" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="Label1" runat="server" CssClass="lbLabel">Tình trạng hợp đồng:</asp:Label></p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblReceiveFor" runat="server" Visible="False" CssClass="lbLabel">Thu từ hợp đồng:</asp:Label><asp:Label
                                ID="lblSpendFor" runat="server" Visible="False" CssClass="lbLabel">Chi cho hợp đồng:</asp:Label>
                            <asp:HyperLink ID="lnkPODetails" runat="server" CssClass="lbLinkFunction">Chi tiết</asp:HyperLink></p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlPO" AutoPostBack="true" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p><asp:Label ID="lblAmount" runat="server" CssClass="lbLabel">Khoản tiền:</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form">
                                <asp:TextBox ID="txtAmount" runat="Server" CssClass="text-input" Width="104px" MaxLength="10">0</asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p><asp:Label ID="lblRate" runat="server" CssClass="lbLabel">Tỉ giá (so với VND):</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form">
                                <asp:TextBox ID="txtRate" runat="Server" CssClass="text-input" Width="56px" MaxLength="10">1</asp:TextBox>
                            </div>
                        </div>
                    </div> 
                    
                   
                    <div class="button-control " style="margin-bottom: 20px; margin-top: 20px;">
                        <div class="button-form">
                            <asp:Button ID="btnAction" runat="server" Text="Thực hiện" CssClass="form-btn" Width="88px">
                            </asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnCancel" runat="server" CssClass="form-btn" Text="Huỷ bỏ" Width="70px">
                            </asp:Button>
                        </div>
                    </div>
                </div>
                <div class="two-column-form">
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblDate" runat="server" CssClass="lbLabel"></asp:Label>
                            <asp:HyperLink ID="lnkDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink></p>
                        <div class="input-control" id="divDate" runat="server">
                            <div class="input-form ">
                                <asp:TextBox ID="txtDate" runat="Server" CssClass="lbTextBox" Width="120px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblUser" runat="server" CssClass="lbLabel">Người khai báo:</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txtReporter" runat="server" Enabled="False" CssClass="lbTextBox"
                                    Width="168px" MaxLength="50"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblReason" runat="server" CssClass="lbLabel">Lí do:</asp:Label></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txtReason" runat="server" CssClass="area-input" Width="100%" Rows="4"
                                    TextMode="MultiLine" MaxLength="150"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear: both; width: 100%;">
                </div>
                <h1 class="main-group-form">
                    Chi tiết thống kê</h1>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblDetails" runat="server" CssClass="lbSubformTitle"></asp:Label></p>
                    <p>
                        <asp:Label ID="lblBalance" runat="server" CssClass="lbSubformTitle">Số tiền tồn (Có trừ dự chi): </asp:Label>&nbsp;<asp:Label
                            ID="lblBalanceAmount" runat="server" CssClass="lbAmount"></asp:Label>&nbsp;<asp:Label ID="lblSetCur1"
                                runat="server" CssClass="lbSubformTitle"></asp:Label></p>
                    <p>
                        <asp:Label ID="lblRealBalance" runat="server" CssClass="lbSubformTitle">Số tiền tồn : </asp:Label>&nbsp;<asp:Label
                            ID="lblRealBalanceAmount" runat="server" CssClass="lbAmount"></asp:Label>&nbsp;
                        <asp:Label ID="lblSetCur2" runat="server" CssClass="lbSubformTitle"></asp:Label></p>
                </div>
                <h1 class="main-group-form">
                    Báo cáo các khoảng trong</h1>
                <div class="row-detail">
                    <div class="input-control inline-box">
                        <p>
                            <asp:Label ID="lblSpendDetails" runat="server" Visible="False" Font-Size="13">Các khoản chi ghi nhận trong:</asp:Label><asp:Label
                                ID="lblSeetledDetails" runat="server" Visible="False" Font-Size="13">Các khoản thu ghi nhận trong:</asp:Label><asp:Label
                                    ID="lblReportDetails" runat="server" Visible="False" Font-Size="13">Báo cáo các khoản trong:</asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="lblPO1" runat="server">Đơn đặt: </asp:Label></p>
                        <div class="dropdown-form ">
                            <asp:DropDownList ID="ddlPO1" runat="server">
                            </asp:DropDownList>
                        </div>
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
                        <p>
                            /</p>
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlYear" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnFilter" runat="server" CssClass="form-btn" Text="Lọc"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnPrint" runat="server" CssClass="form-btn" Text="In"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <h1 class="main-group-form" id="TRHeader" runat="server">
                <asp:Label ID="lblReportHeader" runat="server" CssClass="lbSubTitle">Bảng cân đối các khoản thu và chi</asp:Label>
            </h1>
            <div class="input-control row-detail">
                <div class="table-form">
                    <asp:DataGrid ID="dgtResult" runat="server" Width="100%" AutoGenerateColumns="False">
                        <EditItemStyle CssClass="lbGridEdit"></EditItemStyle>
                        <AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
                        <ItemStyle CssClass="lbGridCell"></ItemStyle>
                        <HeaderStyle HorizontalAlign="Center" CssClass="lbGridHeader" VerticalAlign="Middle">
                        </HeaderStyle>
                        <Columns>
                            <asp:TemplateColumn HeaderText="Ng&#224;y nhập">
                                <HeaderStyle Width="15%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedDate" Text='<%# DataBinder.Eval(Container.DataItem, "TRANSACTIONDATE")%>'
                                        runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="70%" runat="server" CssClass="lbTextBox" ID="txtCreatedDate"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "TRANSACTIONDATE") %>' />
                                    <asp:HyperLink runat="server" CssClass="lbLinkFunction" ID="lnkCalendarDisplay">Lịch</asp:HyperLink>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Thông tin">
                                <HeaderStyle Width="20%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblAmountDisplay" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "InfoAmount") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" MaxLength="10" CssClass="lbTextBox" ID="txtAmountDisplay"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "AmountDisplay") %>' />
                                    <asp:Label ID="lblSpendForDisplay" runat="server" Visible="False" Text="Chi cho hợp đồng:"></asp:Label>
                                    <asp:Label ID="lblReceiveForDisplay" runat="server" Visible="False" Text="Thu từ hợp đồng:"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlPODisplay">
                                    </asp:DropDownList>
                                    <asp:DropDownList runat="server" ID="ddlComited" Visible="False">
                                        <asp:ListItem Value="0">Dự chi</asp:ListItem>
                                        <asp:ListItem Value="1">Thực chi</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox Visible="False" runat="server" ID="txtPOHid" Text='<%# DataBinder.Eval(Container.DataItem, "POID") %>'>
                                    </asp:TextBox>
                                    <asp:TextBox Visible="False" runat="server" ID="txtCommitedHid" Text='<%# DataBinder.Eval(Container.DataItem, "Commited") %>'>
                                    </asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Tỉ gi&#225;">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblRateDisplay" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"ExchangeRate")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" MaxLength="10" ID="txtRateDisplay" CssClass="lbTextBox"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "ExchangeRate") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="L&#253; do">
                                <HeaderStyle Width="35%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblReasonDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Reason") %>'
                                        runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" MaxLength="150" CssClass="lbTextBox" ID="txtReasonDisplay"
                                        Rows="4" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "Reason") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Người nhập">
                                <HeaderStyle Width="15%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblReporter" Text='<%# DataBinder.Eval(Container.DataItem, "Inputer") %>'
                                        runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" MaxLength="50" CssClass="lbTextBox" ID="txtReporterDisplay"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "Inputer") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src='../../images/update.gif' border='0'&gt;"
                                HeaderText="Sửa" CancelText="&lt;img src='../../images/cancel.gif' border='0'&gt;"
                                EditText="&lt;img src='../../images/edit2.gif' border='0'&gt;">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:EditCommandColumn>
                            <asp:ButtonColumn Text="&lt;img src='../../images/delete.gif' border='0'&gt;" HeaderText="Xo&#225;"
                                CommandName="Delete">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:ButtonColumn>
                        </Columns>
                    </asp:DataGrid>
                    <asp:Table ID="tblReport" runat="server" CssClass="lbGrid" CellSpacing="1" CellPadding="2">
                    </asp:Table>
                </div>
            </div>
        </div>
    </div>
    <table id="Table1" cellspacing="0" cellpadding="2" width="100%" border="0">
        <tr class="lbPageTitle">
            <td align="left" colspan="4">
                <%--  <asp:Label ID="lblHeader" CssClass="lbPageTitle" runat="server"> Quản lý tài chính</asp:Label>--%>
            </td>
        </tr>
        <tr class="lbGroupTitle">
            <td colspan="4">
                <table id="table3" cellspacing="2" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td align="left" width="40%">
                            <%-- <asp:Label ID="lblSettledTitle" runat="server" CssClass="lbGroupTitle" Visible="False"> Khai báo thu</asp:Label>--%><%--<asp:Label
                                ID="lblSpendTitle" runat="server" CssClass="lbGroupTitle" Visible="False">Khai báo chi</asp:Label><asp:Label
                                    ID="lblReportTitle" runat="server" CssClass="lbGroupTitle" Visible="False">Báo cáo</asp:Label>--%>
                        </td>
                        <td align="right" colspan="2">
                            <%-- <asp:HyperLink ID="lnkAddAccount" runat="server" CssClass="lbLinkFunction"></asp:HyperLink>--%>&nbsp;<%--<asp:HyperLink ID="lnkReport" runat="server"
                                    CssClass="lbLinkFunction">Báo cáo quỹ</asp:HyperLink>--%>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr id="TR1" runat="server">
            <td align="right" width="15%">
                <%-- <asp:Label ID="lblBudget" runat="server" CssClass="lbLabel">Quỹ:</asp:Label>--%>
            </td>
            <td width="25%">
                <%-- <asp:DropDownList ID="ddlBudget" runat="server" AutoPostBack="True">
                </asp:DropDownList>--%>
            </td>
            <td class="lbLabel" id="Td1" align="right" width="10%" runat="server">
                <%-- <asp:Label ID="lblDate" runat="server" CssClass="lbLabel"></asp:Label>--%>
            </td>
            <td width="30%">
                <%-- <asp:TextBox ID="txtDate" runat="Server" CssClass="lbTextBox" Width="72px"></asp:TextBox>--%>&nbsp;<%--<asp:HyperLink
                    ID="lnkDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink>--%>
            </td>
        </tr>
        <tr id="TR2" runat="server">
            <td align="right">
                <%--<asp:Label ID="lblReceiveFor" runat="server" Visible="False" CssClass="lbLabel">Thu từ hợp đồng:</asp:Label>--%><%--<asp:Label
                    ID="lblSpendFor" runat="server" Visible="False" CssClass="lbLabel">Chi cho hợp đồng:</asp:Label>
                --%>
            </td>
            <td>
                <%--  <asp:DropDownList ID="ddlPO" runat="server">
                </asp:DropDownList>--%>
                <%--<asp:HyperLink ID="lnkPODetails" runat="server" CssClass="lbLinkFunction">Chi tiết</asp:HyperLink>--%>
            </td>
            <td class="lbLabel" align="right" width="10%">
                <%--  <asp:Label ID="lblUser" runat="server" CssClass="lbLabel">Ngưòi khai báo:</asp:Label>--%>
            </td>
            <td>
                <%-- <asp:TextBox ID="txtReporter" runat="server" Enabled="False" CssClass="lbTextBox"
                    Width="168px" MaxLength="50"></asp:TextBox>--%>
            </td>
        </tr>
        <tr id="TR3" runat="server">
            <td align="right">
                <%-- <asp:Label ID="lblAmount" runat="server" CssClass="lbLabel">Khoản tiền:</asp:Label>--%>
            </td>
            <td>
                <%-- <asp:TextBox ID="txtAmount" runat="Server" CssClass="lbTextBox" Width="104px" MaxLength="10">0</asp:TextBox>--%>
            </td>
            <td align="right">
                <%--<asp:Label ID="lblReason" runat="server" CssClass="lbLabel">Lí do:</asp:Label>--%>
            </td>
            <td rowspan="3">
                <%--  <asp:TextBox ID="txtReason" runat="server" CssClass="lbTextBox" Width="100%" Rows="4"
                    TextMode="MultiLine" MaxLength="150"></asp:TextBox>--%>
            </td>
        </tr>
        <tr id="TR4" runat="server">
            <td align="right">
                <%--  <asp:Label ID="lblRate" runat="server" CssClass="lbLabel">Tỉ giá (so với VND):</asp:Label>--%>
            </td>
            <td>
                <%--<asp:TextBox ID="txtRate" runat="Server" CssClass="lbTextBox" Width="56px" MaxLength="10">1</asp:TextBox>--%>
            </td>
        </tr>
        <tr id="TR5" runat="server">
            <td align="right">
            </td>
            <td>
                <%--  <asp:RadioButton ID="rdoReal" runat="server" CssClass="lbRadio" Text="Dự chi" GroupName="rdoSpendMode"
                    Checked="True"></asp:RadioButton>&nbsp;
                <asp:RadioButton ID="rdoUnReal" runat="server" CssClass="lbRadio" Text="Thực chi"
                    GroupName="rdoSpendMode"></asp:RadioButton>--%>
            </td>
        </tr>
        <tr id="TR6" runat="server">
            <td align="right">
            </td>
            <td>
                <%-- <asp:Button ID="btnAction" runat="server" Text="Thực hiện" CssClass="lbButton" Width="88px">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" CssClass="lbButton" Text="Huỷ bỏ" Width="70px">
                </asp:Button>--%>
            </td>
        </tr>
        <tr class="lbSubformTitle">
            <td align="left" colspan="4">
                <table id="table2" cellspacing="2" cellpadding="0" width="100%" border="0">
                    <tr class="lbSubformTitle">
                        <td class="lbSubTitle" width="30%">
                            <%--   <asp:Label ID="lblDetails" runat="server" CssClass="lbSubformTitle"></asp:Label>--%>
                        </td>
                        <td width="30%">
                            <%-- <asp:Label ID="lblBalance" runat="server" CssClass="lbSubformTitle">Số tiền tồn (Có trừ dự chi): </asp:Label>&nbsp;<asp:Label
                                ID="lblBalanceAmount" runat="server" CssClass="lbAmount"></asp:Label>--%><%--<asp:Label
                                    ID="lblSetCur1" runat="server" CssClass="lbSubformTitle"></asp:Label>--%>
                        </td>
                        <td width="40%">
                            <%-- <asp:Label ID="lblRealBalance" runat="server" CssClass="lbSubformTitle">Số tiền tồn : </asp:Label>&nbsp;<asp:Label
                                ID="lblRealBalanceAmount" runat="server" CssClass="lbAmount"></asp:Label>
                            <asp:Label ID="lblSetCur2" runat="server" CssClass="lbSubformTitle"></asp:Label>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="lbSubTitle" style="width: 355px" colspan="2">
                <%-- <asp:Label ID="lblSpendDetails" runat="server" Visible="False" Font-Size="13">Các khoản chi ghi nhận trong:</asp:Label><asp:Label
                    ID="lblSeetledDetails" runat="server" Visible="False" Font-Size="13">Các khoản thu ghi nhận trong:</asp:Label><asp:Label
                        ID="lblReportDetails" runat="server" Visible="False" Font-Size="13">Báo cáo các khoản trong:</asp:Label>--%>&nbsp;
            </td>
            <td align="right" colspan="2">
                &nbsp;&nbsp;
                <%--  <asp:Label ID="lblPO1" runat="server">Đơn đặt: </asp:Label>--%>&nbsp;
                <%-- <asp:DropDownList ID="ddlPO1" runat="server">
                </asp:DropDownList>--%>
                &nbsp;&nbsp;
                <%--<asp:DropDownList ID="ddlMonth" runat="server">
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
                </asp:DropDownList>--%>
                &nbsp;
                <%-- <asp:Label ID="lblTemp" runat="server">/</asp:Label>--%>&nbsp;&nbsp;
                <%-- <asp:DropDownList ID="ddlYear" runat="server">
                </asp:DropDownList>--%>
                &nbsp;<%--<asp:Button ID="btnFilter" runat="server" CssClass="lbButton" Text="Lọc"></asp:Button>--%>&nbsp;<%--<asp:Button
                    ID="btnPrint" runat="server" CssClass="lbButton" Text="In"></asp:Button>--%>
            </td>
        </tr>
        <%--  <tr id="TRHeader" runat="server">
            <td class="lbGridPager" align="center" colspan="4" rowspan="1">
               <asp:Label ID="lblReportHeader" runat="server" CssClass="lbSubTitle">Bảng cân đối các khoản thu và chi</asp:Label>
            </td>
        </tr>--%>
        <tr class="lbControlBar" id="TRFirstRemain" runat="server">
            <td colspan="4">
                <asp:Label ID="lblFirstRemain" runat="server" CssClass="lbLabel">Số dư đầu kỳ: </asp:Label><asp:Label
                    ID="lblFirstRemainAmount" runat="server" CssClass="lbAmount"></asp:Label>&nbsp;
                <asp:Label ID="lblSetCurRemain1" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <%--   <tr>
            <td colspan="4">
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Table ID="tblReport" runat="server" CssClass="lbGrid" CellSpacing="1" CellPadding="2">
                </asp:Table>
            </td>
        </tr>--%>
        <tr class="lbControlBar" id="TRLastRemain" runat="server">
            <td align="right" colspan="4">
                <asp:Button ID="btnUpdateRemain" runat="server" CssClass="lbButton" Text="Cập nhật số dư cuối kỳ">
                </asp:Button>&nbsp;
                <asp:Label ID="lblLastRemain" runat="server" CssClass="lbLabel">Số dư cuối kỳ: </asp:Label><asp:Label
                    ID="lblLastRemainAmount" runat="server" CssClass="lbAmount"></asp:Label>&nbsp;
                <asp:Label ID="lblSetCurRemain2" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <input id="hidCurrency" type="hidden" name="hidCurrency" runat="server">
                <input id="hidToday" type="hidden" name="hidToday" runat="server">
                <input id="hidIDs" type="hidden" name="hidIDs" runat="server">
                <input id="hidRemain" type="hidden" name="hidCurrency" runat="server">
            </td>
        </tr>
    </table>
    <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0" Height="0">
        <asp:ListItem Value="0">----- Chọn đơn đặt -----</asp:ListItem>
        <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="3">Ngày</asp:ListItem>
        <asp:ListItem Value="4">Diễn giải</asp:ListItem>
        <asp:ListItem Value="5">Thu</asp:ListItem>
        <asp:ListItem Value="6">Chi</asp:ListItem>
        <asp:ListItem Value="7">Tỉ giá hạch toán</asp:ListItem>
        <asp:ListItem Value="8">Số tiền</asp:ListItem>
        <asp:ListItem Value="9">Đơn vị TT</asp:ListItem>
        <asp:ListItem Value="10">Tỉ giá thực tế</asp:ListItem>
        <asp:ListItem Value="11">Số tiền chênh lệch với tỉ giá (VND)</asp:ListItem>
        <asp:ListItem Value="12">Tổng</asp:ListItem>
        <asp:ListItem Value="13">Số tiền nhập vào phải lớn hơn 0!</asp:ListItem>
        <asp:ListItem Value="14">Tỉ giá phải lớn hơn 0!</asp:ListItem>
        <asp:ListItem Value="15">Số tiền nhập vào phải là kiểu số!</asp:ListItem>
        <asp:ListItem Value="16">Tỉ giá nhập vào phải là kiểu số!</asp:ListItem>
        <asp:ListItem Value="17">Khuôn dạng ngày tháng không hợp lệ!</asp:ListItem>
        <asp:ListItem Value="18">Các trường không được bỏ trống!</asp:ListItem>
        <asp:ListItem Value="19">Cập nhật thành công!</asp:ListItem>
        <asp:ListItem Value="20">Khai báo khoản thu</asp:ListItem>
        <asp:ListItem Value="21">Khai báo khoản chi</asp:ListItem>
        <asp:ListItem Value="22">Cập nhật khoản thu</asp:ListItem>
        <asp:ListItem Value="23">Cập nhật khoản chi</asp:ListItem>
        <asp:ListItem Value="24">Xoá khoản thu</asp:ListItem>
        <asp:ListItem Value="25">Xoá khoản chi</asp:ListItem>
        <asp:ListItem Value="26">Bạn có muốn xoá khoản thu không?</asp:ListItem>
        <asp:ListItem Value="27">Bạn có muốn xoá khoản chi không?</asp:ListItem>
        <asp:ListItem Value="28">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
        <asp:ListItem Value="29">Dự chi</asp:ListItem>
        <asp:ListItem Value="30">Thực chi</asp:ListItem>
        <asp:ListItem Value="31">Cho hợp đồng :</asp:ListItem>
        <asp:ListItem Value="32">Khoản thu</asp:ListItem>
        <asp:ListItem Value="33">Từ mã hợp đồng :</asp:ListItem>
        <asp:ListItem Value="34">Trạng thái</asp:ListItem>
        <asp:ListItem Value="35">Ngày chi:</asp:ListItem>
        <asp:ListItem Value="36">Ngày thu:</asp:ListItem>
        <asp:ListItem Value="37">Kiểu ngày không hợp lệ !</asp:ListItem>
    </asp:DropDownList>
    <script language="javascript">
        if (eval('document.forms[0].txtAmount')) {
            document.forms[0].txtAmount.focus();
        }
    </script>
    </form>
</body>
</html>
