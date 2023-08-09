<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WDeleteItem" CodeFile="WDeleteItem.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WDeleteItem</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .table-form .divTD {
            padding: 8px 20px;
            font-weight: bold;
        }
    </style>
</head>
<body leftmargin="0" rightmargin="0" topmargin="0" bottommargin="0"
    onload="document.forms[0].txtFromCode.focus()">
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
                <div class="two-column-form">
                    <h1 class="main-head-form">Xóa bản ghi của một tài liệu ấn phẩm</h1>
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Mã tài liệu:</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtItemCode" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Nhan đề chính :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>ISBN :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtISBN" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Năm xuất bản :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtYear" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>ĐKCB :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtCopyNumber" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Tác giả :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtAuthor" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Nhà xuất bản :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtPublisher" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>&nbsp;</p>
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button CssClass="form-btn" ID="btnSearch" runat="server" Text="Tìm (f)"></asp:Button>
                                    </div>
                                    <div class="button-form">
                                        <asp:Button CssClass="form-btn" ID="btnReset" runat="server" Text="Đặt lại(r)"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    
                    <div class="row-detail">
                        <asp:Label ID="lblNotFound" runat="server" Visible="False">Không tìm thấy bản ghi biên mục nào thoả mãn điều kiện tìm kiếm</asp:Label><asp:Label ID="lblCapResult" runat="server" Visible="False">Tìm thấy:</asp:Label>&nbsp;
						<asp:Label ID="lblResult" runat="server" Visible="False" CssClass="lbAmount"></asp:Label>&nbsp;
						<asp:Label ID="lblCap" runat="server" Visible="False">bản ghi biên mục</asp:Label>
                    </div>
                    <div class="input-control">
                        <div class="table-form">
                            <asp:DataGrid ID="DgrResult" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                                PageSize="15">
                                <Columns>
                                    <asp:BoundColumn DataField="Code" HeaderText="Mã tài liệu">
                                        <HeaderStyle Width="20%"></HeaderStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="TITLE" HeaderText="Nhan đề">
                                        <HeaderStyle Width="80%"></HeaderStyle>
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn Visible="False">
                                        <HeaderStyle Width="300px"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="LblID" Text='<%# DataBinder.Eval(Container.dataItem, "ItemID") %>' runat="server">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle Width="12%"></HeaderStyle>
                                        <HeaderTemplate>
                                            <input class="lbCheckBox" type="checkbox" id="CheckAll" onclick="javascript: CheckAllOptionsVisibleByCssClass('ckb-value', 'ckbdtgCopyNumber', 2, 50);">
                                             <label for="chkCheckAll"></label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="divTD">
                                                <input type="checkbox" ID="CheckItemID" runat="server"/>
                                                <label for="CheckItemID"></label>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnDelete" runat="server" CssClass="form-btn" Width="" Text="Xoá(d)" Visible="False"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input id="hidIDs" runat="server" type="hidden"/>
        <asp:DropDownList runat="server" ID="ddlLabel" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">Bạn phải nhập ít nhất một điều kiện tìm kiếm!</asp:ListItem>
            <asp:ListItem Value="1">Bạn có muốn xoá biểu ghi biên mục đã chọn không?</asp:ListItem>
            <asp:ListItem Value="2">Xoá bản ghi thành công!</asp:ListItem>
            <asp:ListItem Value="3">Bạn phải chọn ít nhất một bản ghi trước khi xoá!</asp:ListItem>
            <asp:ListItem Value="4">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="5">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="6">Xoá bản ghi dữ liệu biên mục</asp:ListItem>
            <asp:ListItem Value="7">bản ghi</asp:ListItem>
            <asp:ListItem Value="8">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
