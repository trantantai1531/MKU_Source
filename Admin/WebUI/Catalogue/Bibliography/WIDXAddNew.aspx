<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIDXAddNew"
    CodeFile="WIDXAddNew.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WIDXAddNew</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <style>
        .excheckbox > input
        {
            opacity: 1;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div class="main-body">
            <h1 class="main-head-form">
                In danh mục</h1>
            <div class="two-column ClearFix">
                <div class="two-column-form">
                    <div class="row-detail">
                        <p>
                            Tên danh mục :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server" Width=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="two-column-form">
                    <div class="row-detail">
                        <p>
                            Nhóm theo :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtGroupBy" runat="server" MaxLength="30" Width=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row-detail">
                <div class="button-control" style="text-align: right;">
                    <div class="button-form">
                        <asp:Button CssClass="form-btn" ID="btnAddNew" runat="server" Text="Tạo mới(a)" Width="">
                        </asp:Button>
                    </div>
                </div>
            </div>
            <div class="input-control row-detail">
                <div class="table-form">
                    <asp:DataGrid ID="dtgIDX" runat="server" Width="100%" AutoGenerateColumns="False"
                        AllowPaging="True">
                        <Columns>
                            <asp:TemplateColumn Visible="False">
                                <HeaderStyle Width="1px"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="optCheck" ReadOnly="True" HeaderText="Chọn" ItemStyle-Width="4%"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemStyle CssClass="excheckbox" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Danh mục">
                                <HeaderStyle Width="43%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="LblCapTitle" Text='<%# DataBinder.Eval(Container.DataItem, "lnkTitle") %>'
                                        runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" CssClass="lbTextBox" ID="txtTitleG" Text='<%# DataBinder.Eval(Container.DataItem, "Title") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Nhóm theo">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblCapGroupBy" Text='<%# DataBinder.Eval(Container.DataItem, "GroupedBy") %>'
                                        runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" runat="server" ID="txtGroupByG" CssClass="lbTextBox" Text='<%# DataBinder.Eval(Container.DataItem, "GroupedBy") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="TORs" ReadOnly="True" HeaderText="Tổng số tài liệu" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Width="6%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="LastModifiedDate" ReadOnly="True" HeaderText="Ngày cập nhật cuối"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="8%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CreatedDate" ReadOnly="True" HeaderText="Ngày tạo" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="8%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:EditCommandColumn HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ButtonType="LinkButton"
                                UpdateText="<img src='../images/update.gif' border='0'>" CancelText="<img src='../images/cancel.gif' border='0'>"
                                EditText="<img src='../images/edit2.gif' border='0'>" ItemStyle-Width="5%"></asp:EditCommandColumn>
                        </Columns>
                        <PagerStyle Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                </div>
            </div>
            <div class="row-detail">
                <div class="button-control">
                    <div class="button-form">
                        <asp:Button CssClass="form-btn" ID="btnView" runat="server" Text="Hiển thị(v)" Width="">
                        </asp:Button>
                    </div>
                    <div class="button-form">
                        <asp:Button CssClass="form-btn" ID="btnUpdate" runat="server" Text="Cập nhật(u)"
                            Width=""></asp:Button>
                    </div>
                    <div class="button-form">
                        <asp:Button CssClass="form-btn" ID="btnSaveToFile" runat="server" Text="Ghi ra file(f)"
                            Width=""></asp:Button>
                    </div>
                    <div class="button-form">
                        <asp:Button CssClass="form-btn" ID="btnDelete" runat="server" Text="Xoá danh mục(d)"
                            Width=""></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <input id="txtHidIDs" type="hidden" name="txtHidIDs" runat="server">
    <asp:DropDownList ID="ddlLabel" runat="server" Width="0px" Visible="False">
        <asp:ListItem Value="0">Bạn chưa nhập đủ thông tin cần thiết để tạo danh mục!</asp:ListItem>
        <asp:ListItem Value="1">Bạn có chắc chắn muốn xoá các danh mục đã chọn không?</asp:ListItem>
        <asp:ListItem Value="2">Bạn chưa chọn danh mục!</asp:ListItem>
        <asp:ListItem Value="3">Bạn không được cấp quyền sử dụng chức năng này</asp:ListItem>
        <asp:ListItem Value="4">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="5">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="6">Tạo mới danh mục: </asp:ListItem>
        <asp:ListItem Value="7">Cập nhật danh mục: </asp:ListItem>
        <asp:ListItem Value="8">Xoá danh mục: </asp:ListItem>
    </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtTitle.focus();
    </script>
</body>
</html>
