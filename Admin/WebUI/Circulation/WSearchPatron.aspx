<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WSearchPatron" CodeFile="WSearchPatron.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSearchPatron</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

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
        <div id="divBody" style="margin-left: 20px">
            <h2 class="main-head-form">Tìm số thẻ bạn đọc</h2>
            <div class="main-form">
                <div class="three-column">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <asp:Label ID="lblFullName" runat="server"><U>H</U>ọ và tên: </asp:Label>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtFullName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <asp:Label ID="lblPatronCode" runat="server">Số thẻ: </asp:Label>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtPatronCode" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <asp:Label ID="Label1" runat="server">Nhóm: </asp:Label>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlPatronGroup" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="three-column">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <asp:Label ID="Label2" runat="server">Email: </asp:Label>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtEmail" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <asp:Label ID="Label3" runat="server">Số điện thoại: </asp:Label>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtTelephone" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <span>&nbsp;</span>
                            <div class="button-control" style="text-align:right">
                                <asp:Button ID="btnSearch" Text="Tìm(s)" Width="" runat="server"></asp:Button>
                            </div>
                            
                        </div>
                    </div>
                </div>
                
                <div class="table-form">


                    <telerik:RadGrid ID="DgdGetPatronInfor" runat="server" AllowPaging="True"
                        CellSpacing="0"
                        AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="DgdGetPatronInfor_NeedDataSource">
                        <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                            <PagerStyle AlwaysVisible="True" />
                            <FooterStyle BackColor="White"></FooterStyle>

                            <Columns>
                                <telerik:GridBoundColumn DataField="FullName" HeaderText="Họ tên đầy đủ"></telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Số thẻ" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <a style="text-decoration:underline" href='#<%# DataBinder.Eval(Container.DataItem, "Code") %>' onclick='onclickPatronCode("<%# DataBinder.Eval(Container.DataItem, "Code") %>")'><%# DataBinder.Eval(Container.DataItem, "Code") %></a>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn DataField="DOB" HeaderText="Ngày sinh" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ValidDate" HeaderText="Ngày cấp" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="13%">
                                    <ItemStyle HorizontalAlign="Center" Width="13%"></ItemStyle>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ExpiredDate" HeaderText="Ngày hết hạn" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center"
                                    ItemStyle-Width="17%">
                                    <ItemStyle HorizontalAlign="Center" Width="17%"></ItemStyle>
                                </telerik:GridBoundColumn>
                            </Columns>
                            <PagerTemplate>
                                <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                            </PagerTemplate>
                        </MasterTableView>

                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                    </telerik:RadGrid>

                   <%-- <asp:DataGrid ID="DgdGetPatronInfor" CssClass="table-control" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
                        <Columns>
                            <asp:BoundColumn DataField="FullName" HeaderText="Họ tên đầy đủ"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Code" HeaderText="Số thẻ" ItemStyle-Width="10%">
                                <ItemStyle Width="10%"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="DOB" HeaderText="Ngày sinh" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%">
                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ValidDate" HeaderText="Ngày cấp" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="13%">
                                <ItemStyle HorizontalAlign="Center" Width="13%"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="ExpiredDate" HeaderText="Ngày hết hạn" ItemStyle-HorizontalAlign="Center"
                                ItemStyle-Width="17%">
                                <ItemStyle HorizontalAlign="Center" Width="17%"></ItemStyle>
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle Mode="NumericPages" />
                    </asp:DataGrid>--%>
                </div>
                <div>
                    <asp:Label ID="lblNotFound" runat="server" Visible="FALSE">Không có bạn đọc nào thỏa mãn điều kiện tìm kiếm!</asp:Label>
                </div>
                <div style="display: none">
                    <asp:HyperLink ID="lnkAddPatron" runat="server" Visible="FALSE" CssClass="lbLinkFunction">Nhập hồ sơ bạn đọc</asp:HyperLink>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Không tồn tại hồ sơ bạn đọc thoả mãn điều kiện tìm kiếm!</asp:ListItem>
            <asp:ListItem Value="3">Bạn chưa nhập tên bạn đọc !</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="LabelSelect" runat="server" Text="------ Chọn ------" Visible="false"></asp:Label>
    </form>
    <script type="text/javascript">
        document.forms[0].txtFullName.focus();

        function onclickPatronCode(patroncode)
        {
            if (parent.CheckOut != null)
            {
                parent.CheckOut.document.forms[0].txtPatronCode.value = patroncode;
            }
            if (parent.CheckIn != null) {
                parent.CheckIn.document.forms[0].txtPatronCode.value = patroncode;
            }
        }
    </script>
</body>
</html>
