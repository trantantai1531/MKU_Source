<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WBatchPatronUpdate" MaintainScrollPositionOnPostback="true"
    CodeFile="WBatchPatronUpdate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Sửa thông tin bạn đọc theo lô</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('a[href^="#"]').click(function (e) {
                e.preventDefault();
            });
            setTimeout(function () { $(".spnlbProcessing").hide(); }, 300);
            $("span#spnlbProcessing").hide();

            if ($('#ddlFieldOpeFrom1').val() == 1) {
                $('#ope11').hide();
                $('#ope12').hide();
                $('#ope13').hide();
                $('#ope14').hide();
            }
            else {
                $('#ope11').show();
                $('#ope12').show();
                $('#ope13').show();
                $('#ope14').show();
            }
            if ($('#ddlFieldOpeFrom2').val() == 1) {
                $('#ope21').hide();
                $('#ope22').hide();
                $('#ope23').hide();
                $('#ope24').hide();
            }
            else {
                $('#ope21').show();
                $('#ope22').show();
                $('#ope23').show();
                $('#ope24').show();
            }

            $(function () {
                $('#ddlFieldOpeFrom1').on('change', function () {
                    if ($(this).val() == 1) {
                        $('#ope11').hide();
                        $('#ope12').hide();
                        $('#ope13').hide();
                        $('#ope14').hide();
                    } else {
                        $('#ope11').show();
                        $('#ope12').show();
                        $('#ope13').show();
                        $('#ope14').show();
                    }
                });
                $('#ddlFieldOpeFrom2').on('change', function () {
                    if ($(this).val() == 1) {
                        $('#ope21').hide();
                        $('#ope22').hide();
                        $('#ope23').hide();
                        $('#ope24').hide();
                    } else {
                        $('#ope21').show();
                        $('#ope22').show();
                        $('#ope23').show();
                        $('#ope24').show();
                    }
                });
            });
        });
    </script>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body leftmargin="0" topmargin="0" onload="document.forms[0].txtFieldValue1.focus()">
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
                <h1 class="main-head-form">Cập nhật thông tin bạn đọc theo lô</h1>
                <div class="main-form">
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail ClearFix" style="display: none">
                                <div class="span3">
                                    <div class="pad5" style="display: inline-block; height: 30px;">
                                    </div>
                                </div>
                                <div class="span7">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlFieldName1" runat="server" Width="100%">
                                                    <asp:ListItem Value="1">Số thẻ</asp:ListItem>
                                                    <asp:ListItem Value="2" Selected="True">Họ tên</asp:ListItem>
                                                    <asp:ListItem Value="3">Nơi công tác</asp:ListItem>
                                                    <asp:ListItem Value="4">Di động</asp:ListItem>
                                                    <asp:ListItem Value="5">Email</asp:ListItem>
                                                    <asp:ListItem Value="6">Lớp</asp:ListItem>
                                                    <asp:ListItem Value="7">Khoá</asp:ListItem>
                                                    <asp:ListItem Value="8">Địa chỉ</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail ClearFix" style="display: none">
                                <div class="span3">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlOperator1" runat="server" Width="">
                                                    <asp:ListItem Value="AND" Selected="True">Và</asp:ListItem>
                                                    <asp:ListItem Value="OR">Hoặc</asp:ListItem>
                                                    <asp:ListItem Value="AND NOT">Không</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span7">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlFieldName2" runat="server" Width="100%">
                                                    <asp:ListItem Value="1">Số thẻ</asp:ListItem>
                                                    <asp:ListItem Value="2" Selected="True">Họ tên</asp:ListItem>
                                                    <asp:ListItem Value="3">Nơi công tác</asp:ListItem>
                                                    <asp:ListItem Value="4">Di động</asp:ListItem>
                                                    <asp:ListItem Value="5">Email</asp:ListItem>
                                                    <asp:ListItem Value="6">Lớp</asp:ListItem>
                                                    <asp:ListItem Value="7">Khoá</asp:ListItem>
                                                    <asp:ListItem Value="8">Địa chỉ</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail ClearFix">
                                <div class="span3">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlOperator2" runat="server" Width="">
                                                    <asp:ListItem Value="AND" Selected="True">Và</asp:ListItem>
                                                    <asp:ListItem Value="OR">Hoặc</asp:ListItem>
                                                    <asp:ListItem Value="AND NOT">Không</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span7">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlFieldName3" runat="server" Width="100%">

                                                    <asp:ListItem Value="2" Selected="True">Ngày hiệu lực</asp:ListItem>
                                                    <asp:ListItem Value="3">Ngày hết hạn thẻ</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail ClearFix">
                                <div class="span3">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlOperator3" runat="server" Width="">
                                                    <asp:ListItem Value="AND" Selected="True">Và</asp:ListItem>
                                                    <asp:ListItem Value="OR">Hoặc</asp:ListItem>
                                                    <asp:ListItem Value="AND NOT">Không</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span7">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlFieldName4" runat="server" Width="100%">

                                                    <asp:ListItem Value="2" Selected="True">Ngày hiệu lực</asp:ListItem>
                                                    <asp:ListItem Value="3">Ngày hết hạn thẻ</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail ClearFix">
                                <div class="span3">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlOperator4" runat="server" Width="">
                                                    <asp:ListItem Value="AND" Selected="True">Và</asp:ListItem>
                                                    <asp:ListItem Value="OR">Hoặc</asp:ListItem>
                                                    <asp:ListItem Value="AND NOT">Không</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span7">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlFieldName5" runat="server" Width="100%" AutoPostBack="False">
                                                    <%--  <asp:ListItem Value="1" Selected="True">Khoa</asp:ListItem>--%>
                                                    <asp:ListItem Value="2">Trường</asp:ListItem>
                                                    <%-- <asp:ListItem Value="3">Trình độ</asp:ListItem>
                                                <asp:ListItem Value="4">Dân tộc</asp:ListItem>
                                                <asp:ListItem Value="5">Nhóm ngành nghề</asp:ListItem>
                                                <asp:ListItem Value="6">Tỉnh</asp:ListItem>--%>
                                                    <asp:ListItem Value="7">Nhóm bạn đọc</asp:ListItem>
                                                    <%--  <asp:ListItem Value="8">Giới tính</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail ClearFix">
                                <div class="span3">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlOperator5" runat="server" Width="">
                                                    <asp:ListItem Value="AND" Selected="True">Và</asp:ListItem>
                                                    <asp:ListItem Value="OR">Hoặc</asp:ListItem>
                                                    <asp:ListItem Value="AND NOT">Không</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span7">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlFieldName6" runat="server" Width="100%" AutoPostBack="False">
                                                    <%--  <asp:ListItem Value="1" Selected="True">Khoa</asp:ListItem>--%>
                                                    <asp:ListItem Value="2">Trường</asp:ListItem>
                                                    <%--  <asp:ListItem Value="3">Trình độ</asp:ListItem>
                                                <asp:ListItem Value="4">Dân tộc</asp:ListItem>
                                                <asp:ListItem Value="5">Nhóm ngành nghề</asp:ListItem>
                                                <asp:ListItem Value="6">Tỉnh</asp:ListItem>--%>
                                                    <asp:ListItem Value="7">Nhóm bạn đọc</asp:ListItem>
                                                    <%--   <asp:ListItem Value="8">Giới tính</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail ClearFix">
                                <div class="span3">
                                    <div class="pad5">
                                        Sắp xếp theo:
                                    </div>
                                </div>
                                <div class="span7">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlOrderBy" runat="server" Width="100%">
                                                    <asp:ListItem Value="1" Selected="True">Ngày cấp</asp:ListItem>
                                                    <asp:ListItem Value="2">Ngày hết hạn</asp:ListItem>
                                                    <asp:ListItem Value="3">Ngày sinh</asp:ListItem>
                                                    <asp:ListItem Value="4">Số thẻ</asp:ListItem>
                                                    <asp:ListItem Value="5">Họ</asp:ListItem>
                                                    <asp:ListItem Value="6">Tên</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail" style="display: none">
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtFieldValue1" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail" style="display: none">
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtFieldValue2" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail ClearFix">
                                <div class="span2">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlFieldOpeFrom1" runat="server" Width="">
                                                    <asp:ListItem Value="1" Selected="True">=</asp:ListItem>
                                                    <asp:ListItem Value="2">trong khoảng</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span1">
                                    <div class="pad5" id="ope11">
                                        <p>
                                            Từ: 
                                        </p>
                                    </div>
                                </div>
                                <div class="span2">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox CssClass="text-input" ID="txtFieldValueFrom1" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span1">
                                    <div class="span5">
                                        <asp:HyperLink ID="lnkFromDate1" runat="server">Lịch</asp:HyperLink>
                                    </div>
                                </div>
                                <div class="span1">
                                    <div class="pad5" id="ope12">
                                        <p>
                                            Đến
                                        </p>

                                    </div>
                                </div>

                                <div class="span2">
                                    <div class="pad5" id="ope13">
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox CssClass="text-input" ID="txtFieldValueTo1" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span1" id="ope14">
                                    <asp:HyperLink ID="lnkToDate1" runat="server">Lịch</asp:HyperLink>
                                </div>
                            </div>
                            <div class="row-detail ClearFix">
                                <div class="span2">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlFieldOpeFrom2" runat="server" Width="">
                                                    <asp:ListItem Value="1">=</asp:ListItem>
                                                    <asp:ListItem Value="2">>=</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span1">
                                    <div class="pad5" id="ope21">
                                        <p>Từ:</p>
                                    </div>
                                </div>
                                <div class="span2">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox CssClass="text-input" ID="txtFieldValueFrom2" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span1">
                                    <div class="span5">
                                        <asp:HyperLink ID="lnkFromDate2" runat="server">Lịch</asp:HyperLink>
                                    </div>
                                </div>
                                <div class="span1">
                                    <div class="pad5" id="ope22">
                                        <p>
                                            Đến
                                        </p>

                                    </div>
                                </div>
                                <div class="span2">
                                    <div class="pad5" id="ope23">
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:TextBox CssClass="text-input" ID="txtFieldValueTo2" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span1" id="ope24">
                                    <div class="span5">
                                        <asp:HyperLink ID="lnkToDate2" runat="server">Lịch</asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <div class="span10">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlOptionFieldValue1" runat="server" Width=""></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row-detail">
                                <div class="span10">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlOptionFieldValue2" runat="server" Width=""></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <div class="span3">
                                    <div class="pad5">
                                        <p>Giới hạn :</p>
                                    </div>
                                </div>
                                <div class="span7">
                                    <div class="pad5">
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlMaxRecord" runat="server" Width="">
                                                    <asp:ListItem Value="2000" Selected="True">Toàn bộ</asp:ListItem>
                                                    <asp:ListItem Value="50">50</asp:ListItem>
                                                    <asp:ListItem Value="100">100</asp:ListItem>
                                                    <asp:ListItem Value="200">200</asp:ListItem>
                                                    <asp:ListItem Value="300">300</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>

                    <div class="row-detail">
                        <div class="button-control inline-box">
                            <div class="button-form">
                                <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm(k)"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnReset" runat="server" Text="Làm lại(l)"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>

                <h1 class="main-group-form">Danh Sách bạn Đọc</h1>

                <div class="main-form">
                    <div style="width: 100%">
                        <asp:Label ID="lblNoData" runat="server" Visible="False" Font-Bold="True" ForeColor="#cc3333"
                            CssClass="lbLabel">Không tìm thấy dữ liệu</asp:Label>
                    </div>
                    <div class="table-form">
                        <telerik:RadGrid ID="dtgResult" runat="server" AllowPaging="True"
                            CellSpacing="0"
                            AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgResult_NeedDataSource">
                            <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                <PagerStyle AlwaysVisible="True" />
                                <FooterStyle BackColor="White"></FooterStyle>

                                <Columns>

                                    <telerik:GridBoundColumn DataField="ROWNUMBER" HeaderText="STT">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="FullName" HeaderText="Họ t&#234;n">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Code" HeaderText="Số thẻ">
                                        <ItemStyle Width="12%"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="DOB" HeaderText="Ng&#224;y sinh">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Ngày cấp">
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LastIssuedDate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblLastIssuedDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LastIssuedDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Ngày hiệu lực">
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ValidDate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblValidDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ValidDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Ngày hết hạn">
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ExpiredDate") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblExpiredDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ExpiredDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="Name" HeaderText="Nh&#243;m bạn đọc">
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle Width="15%"></ItemStyle>
                                    </telerik:GridBoundColumn>

                                    <telerik:GridTemplateColumn Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                                        <HeaderTemplate>
                                            <%-- <input class="lbCheckBox" type="checkbox" id="CheckAll" onclick="javascript: CheckAllOptionsVisible_1('dtgResult', 'chkSelectedID', 3, 10);">
                                      <label for="CheckAll">
                                    </label>--%>
                                            <label>Chọn</label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <input id="chkSelectedID" type="checkbox" class="ckb-value" runat="server">
                                            <label for="chkSelectedID"></label>
                                            <%-- <asp:CheckBox ID="chkSelectedID" runat="server"></asp:CheckBox>
                                            <label for="chkSelectedID">
                                            </label>--%>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                                <PagerTemplate>
                                    <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                </PagerTemplate>
                            </MasterTableView>

                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                        </telerik:RadGrid>



                        <%--                        <asp:DataGrid CssClass="table-control" ID="dtgResult" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False" OnPageIndexChanged="dtgResult_PageIndexChanged">
                            <Columns>
                                <asp:BoundColumn DataField="ROWNUMBER" HeaderText="STT">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Right" Width="3%"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="FullName" HeaderText="Họ t&#234;n">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Code" HeaderText="Số thẻ">
                                    <ItemStyle Width="12%"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DOB" HeaderText="Ng&#224;y sinh">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Ngày cấp">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LastIssuedDate") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastIssuedDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LastIssuedDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Ngày hiệu lực">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ValidDate") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblValidDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ValidDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Ngày hết hạn">
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ExpiredDate") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblExpiredDate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ExpiredDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="Name" HeaderText="Nh&#243;m bạn đọc">
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle Width="15%"></ItemStyle>
                                </asp:BoundColumn>

                                <asp:TemplateColumn Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn>
                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                                    <HeaderTemplate>
                                      
                                        <label>Chọn</label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelectedID" runat="server"></asp:CheckBox>
                                        <label for="chkSelectedID">
                                        </label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle NextPageText="&amp;gt;Next" PrevPageText="&amp;lt;Prev" HorizontalAlign="Right"
                                Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>--%>
                    </div>



                </div>


                <h1 class="main-group-form">Nội dung cập nhật</h1>
                <div class="main-form">
                    <div class="col-left-4">
                        <div class="row-detail ClearFix">
                            <div class="span4">
                                <div class="pad5">
                                    <div class="input-control">
                                        <div class="dropdown-form">
                                            <asp:DropDownList ID="ddlFieldName7" runat="server" Width="">

                                                <asp:ListItem Value="2" Selected="True">Ngày hiệu lực</asp:ListItem>
                                                <asp:ListItem Value="3">Ngày hết hạn thẻ</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="span4">
                                <div class="pad5">
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:TextBox CssClass="text-input" ID="txtNewDateValue" runat="server" Width=""></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="span2">
                                <div class="pad5">
                                    <asp:HyperLink ID="lnkNewDate" runat="server">Lịch</asp:HyperLink>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail ClearFix" style="display: none">
                            <div class="span4">
                                <div class="pad5">
                                    <div class="input-control">
                                        <div class="dropdown-form">
                                            <asp:DropDownList ID="ddlFieldName8" runat="server" Width="">
                                                <asp:ListItem Value="1">Số thẻ</asp:ListItem>
                                                <asp:ListItem Value="2" Selected="True">Họ tên</asp:ListItem>
                                                <asp:ListItem Value="4">Di động</asp:ListItem>
                                                <asp:ListItem Value="5">Email</asp:ListItem>
                                                <asp:ListItem Value="6">Lớp</asp:ListItem>
                                                <asp:ListItem Value="8">Địa chỉ</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="pad5">
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:TextBox CssClass="text-input" ID="txtNewTextValue" runat="server" Width=""></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="span2">
                                <div class="pad5">
                                </div>
                            </div>
                        </div>
                        <div class="row-detail ClearFix">
                            <div class="span4">
                                <div class="pad5">
                                    <div class="input-control">
                                        <div class="dropdown-form">
                                            <asp:DropDownList ID="ddlFieldName9" runat="server" Width="" AutoPostBack="False">
                                                <asp:ListItem Value="7">Nhóm bạn đọc</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="span4">
                                <div class="pad5">
                                    <div class="input-control">
                                        <div class="dropdown-form">
                                            <asp:DropDownList ID="ddlOptionFieldValue3" runat="server" Width="">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--  <div class="span2">
                            <div class="pad5">
                                <a href="#">Lịch</a>
                            </div>
                        </div>--%>
                        </div>
                    </div>

                </div>

            </div>
            <div class="row-detail" style="clear: both; text-align: center;">
                <div class="button-control inline-box">
                    <div class="button-form">

                        <asp:Button ID="btnUpdate" CssClass="lbButton" runat="server" Text="Cập nhật(p)"></asp:Button>
                    </div>

                </div>
            </div>
        </div>
        <input id="txtHidden1" type="hidden" name="txtHidden1" runat="server" />
        <input id="txtHidden2" type="hidden" name="txtHidden2" runat="server" />
        <input id="txtHidden3" type="hidden" name="txtHidden3" runat="server" />
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn chưa được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="3">Cập nhật dữ liệu theo lô</asp:ListItem>
            <asp:ListItem Value="4">------- Chọn -------</asp:ListItem>
            <asp:ListItem Value="5">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="6">Bạn chưa chọn bạn đọc cần cập nhật thông tin!</asp:ListItem>
            <asp:ListItem Value="7">Cập nhật không thành công!</asp:ListItem>
            <asp:ListItem Value="8">Cập nhật thành công!</asp:ListItem>
            <asp:ListItem Value="9">Bạn chưa nhập thông tin cập nhật!</asp:ListItem>
            <asp:ListItem Value="10">Không tìm thấy dữ liệu</asp:ListItem>
            <asp:ListItem Value="11">Nữ</asp:ListItem>
            <asp:ListItem Value="12">Nam</asp:ListItem>
            <asp:ListItem Value="13">Tất cả</asp:ListItem>
            <asp:ListItem Value="14">Tìm thấy</asp:ListItem>
            <asp:ListItem Value="15">kết quả ! Đang lấy dữ liệu, xin vui lòng chờ trong chốc lát ...</asp:ListItem>
            <asp:ListItem Value="16">Số thẻ đã tồn tại!</asp:ListItem>
            <asp:ListItem Value="17">Không thể cập nhật cùng 1 số thẻ cho hơn 2 bạn đọc!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
