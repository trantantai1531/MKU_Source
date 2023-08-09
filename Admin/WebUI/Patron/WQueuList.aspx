<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WQueuList" CodeFile="WQueuList.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Quản lý hàng đợi</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server" oncontextmenu="return false">
        <div id="divBody">
            <h1 class="main-head-form">Quản lý hàng đợi</h1>
            <div class="main-form">
                <asp:Label ID="lblTitle" runat="server" Width="100%" CssClass="lbPageTitle">Danh sách bản ghi nhập sơ lược</asp:Label>
                <asp:Label ID="lblNotFound" runat="server" Visible="False">Hiện tại không có bạn đọc nào trong hàng đợi!</asp:Label>
                <div class="table-form">
                    <asp:DataGrid CssClass="table-control" ID="dtgCirPatronQueue" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        Height="40px" Width="100%">
                        <Columns>
                            <asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Postion" HeaderText="STT">
                                <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:HyperLinkColumn DataTextField="Name" HeaderText="Họ v&#224; t&#234;n"></asp:HyperLinkColumn>
                            <asp:BoundColumn DataField="Code" HeaderText="Số thẻ">
                                <HeaderStyle Width="10%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="GroupName" HeaderText="Nh&#243;m bạn đọc">
                                <HeaderStyle Width="20%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="WorkPlace" HeaderText="Cơ quan">
                                <HeaderStyle Width="25%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Chọn">
                                <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <HeaderTemplate>
                                    <input class="lbCheckBox" type="checkbox" id="CheckAll" onclick="javascript: CheckAllOptionsVisible('dtgCirPatronQueue', 'cbkOption', 3, 10);">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbkOption" runat="server"></asp:CheckBox>
                                    <label for="cbkOption"></label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                </div>
                <asp:Button ID="btnDelete" runat="server" Text="Xoá bỏ(x)"></asp:Button>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabelNote" runat="server" Visible="False" Width="0px">
            <asp:ListItem Value="0">Bạn chưa chọn độc giả muốn xoá bỏ!</asp:ListItem>
            <asp:ListItem Value="1">Bạn có chắc chắn xoá bỏ bạn đọc ra khỏi hàng đợi không?</asp:ListItem>
            <asp:ListItem Value="2">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="3">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="4">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
