<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WItemQueue" CodeFile="WItemQueue.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Danh sách ấn phẩm đã biên mục sơ lược</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('[id*=chkCheckAll]').click(function () {
                $("[id*='cbkOption']").attr('checked', this.checked);
            });
        });
    </script>
</head>
<body topmargin="2" leftmargin="2">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h2 class="main-group-form">Danh sách ấn phẩm đã biên mục sơ lược</h2>
            <div class="main-form">
                  <asp:Label ID="lblInputTime" runat="server"><u>T</u>hời gian nhập:</asp:Label>
                    <asp:DropDownList ID="ddlInputTime" runat="server" AutoPostBack="True"></asp:DropDownList>
                <div class="table-form">
                      <asp:DataGrid ID="dtgItemContent" CssClass="table-control" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
                        PageSize="15" AllowSorting="True">
                        <Columns>
                            <asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
                            <asp:HyperLinkColumn DataTextField="Content" SortExpression="0" HeaderText="Nhan đề">
                                <HeaderStyle HorizontalAlign="Center" ForeColor="White"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                            </asp:HyperLinkColumn>
                            <asp:BoundColumn DataField="Code" SortExpression="1" HeaderText="Mã số biểu ghi">
                                <HeaderStyle HorizontalAlign="Center" Width="15%" ForeColor="White"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="CREATEDDATE" SortExpression="2" HeaderText="Ngày nhập">
                                <HeaderStyle HorizontalAlign="Center" Width="15%" ForeColor="White"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Chọn" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate >
                                    <asp:CheckBox runat="server" CssClass="lbCheckBox" ID="chkCheckAll" Text="&nbsp;"/>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbkOption" runat="server" ></asp:CheckBox>
                                    <label for="cbkOption"></label>   
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" ForeColor="White" />
                                <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Position="Top" PageButtonCount="100" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                </div>
                <div>
                    <asp:Button runat="server" ID="btnClose" Width="78px" Text="Đóng(o)"></asp:Button>
                </div>
            </div>
        </div>
       
        <input id="ipSortType" runat="server" name="ipSortType" type="hidden" value="0">
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Hiện tại chưa có ấn phẩm nào được biên mục sơ lược</asp:ListItem>
            <asp:ListItem Value="3">Toàn bộ:</asp:ListItem>
            <asp:ListItem Value="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tháng:</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
