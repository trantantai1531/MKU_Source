<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WSearch"
    CodeFile="WSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSearch</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <style>
        .table-from .lbGrid .lbGridHeader {
            background-color: #CCCCCC;
            text-align: center;
            color: #3D61A7;
        }
    </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px;">
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
            <h1 class="main-head-form">TRA CỨU ẤN PHẨM ĐỊNH KỲ</h1>
            <div class="main-form">
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>
                                Chọn nhóm :
                            </p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                Tên nhóm :
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtGroupName" runat="server" Width="25%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                Nhan đề :
                            </p>
                            <p class="error-star">(*)</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                Nước xuất bản :
                            <asp:HyperLink ID="lnkCountry" runat="server">Từ điển</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCountry" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                Nhà xuất bản :
                            <asp:HyperLink ID="lnkPublisher" runat="server">Từ điển</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtPublisher" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                Ngôn ngữ :
                            <asp:HyperLink ID="lnkLanguage" runat="server">Từ điển</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtLanguage" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>
                                Định kỳ :
                            </p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlRegularity" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                ISSN :
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtISSN" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                Phân loại :
                            <asp:HyperLink ID="lnkClassify" runat="server">Từ điển</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtClassify" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                Tiêu đề đề mục :<asp:HyperLink ID="lnkSubject" runat="server">Từ điển</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtSubject" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                Từ khóa :
                            <asp:HyperLink ID="lnkKeyword" runat="server">Từ điển</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtKeyword" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control" style="text-align: center;">
                        <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" />
                        <div class="button-form">
                            <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật (u)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" runat="server" Text="Đặt lại (r)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnDelete" runat="server" Text="Xóa nhóm(x)"></asp:Button>
                        </div>
                    </div>
                </div>
                <div class="row-detail table-form">
                    <asp:Label ID="lblResult" runat="server" Visible="False">Không tìm thấy ấn phẩm nào thoả mãn điều kiện tìm kiếm</asp:Label>
                    <div class="table-from">


                        <telerik:RadGrid ID="dtgResult" runat="server" AllowPaging="True"
                            CellSpacing="0"
                            AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgResult_NeedDataSource">
                            <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                <PagerStyle AlwaysVisible="True" />
                                <FooterStyle BackColor="White"></FooterStyle>

                                <Columns>
                                     <telerik:GridTemplateColumn HeaderText="Mã tài liệu">
                                    <HeaderStyle Width="15%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="lnkItemDetails" CssClass="lbLinkFunction">
											<%# DataBinder.Eval(Container.dataItem,"Code")%>
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="Title" HeaderText="Nhan đề">
                                    <HeaderStyle Width="70%"></HeaderStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ISSN" HeaderText="ISSN">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Chọn">
                                    <HeaderStyle Width="5%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="lnkSelect">
											<img src="../Images/select.jpg" border="0"></asp:HyperLink>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                </Columns>
                                <PagerTemplate>
                                    <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                </PagerTemplate>
                            </MasterTableView>

                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                        </telerik:RadGrid>



<%--                        <asp:DataGrid ID="dtgResult" CssClass="table-control" runat="server" Width="100%"
                            AllowPaging="True" PageSize="15" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateColumn HeaderText="Mã tài liệu">
                                    <HeaderStyle Width="15%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="lnkItemDetails" CssClass="lbLinkFunction">
											<%# DataBinder.Eval(Container.dataItem,"Code")%>
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="Title" HeaderText="Nhan đề">
                                    <HeaderStyle Width="70%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ISSN" HeaderText="ISSN">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Chọn">
                                    <HeaderStyle Width="5%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="lnkSelect">
											<img src="../Images/select.jpg" border="0"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>--%>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">-------- Chọn mức định kỳ --------</asp:ListItem>
            <asp:ListItem Value="3">Bạn phải nhập vào tên nhóm trước khi cập nhật!</asp:ListItem>
            <asp:ListItem Value="4">----- Tạo nhóm mới -----</asp:ListItem>
            <asp:ListItem Value="5">Bạn phải nhập vào ít nhất một điều kiện tìm kiếm!</asp:ListItem>
            <asp:ListItem Value="6">Bạn có chắc chắn muốn xoá nhóm không?</asp:ListItem>
            <asp:ListItem Value="7">Bạn chưa chọn nhóm cần xoá!</asp:ListItem>
            <asp:ListItem Value="8">Ấn phẩm được chọn làm ấn phẩm hiện thời!</asp:ListItem>
            <asp:ListItem Value="9">Tên nhóm đã tồn tại.</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtTitle.focus();
    </script>
</body>
</html>
