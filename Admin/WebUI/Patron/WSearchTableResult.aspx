<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WSearchTableResult"
    CodeFile="WSearchTableResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSearchTableResult</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0">
    <form id="Form1" method="post" runat="server">
        <div class="button-control">
            <asp:button id="btnExport" runat="server" Width="88px" Text="Xuất file"></asp:button>
        </div>
						
    <div class="table-form">
        <asp:DataGrid ID="DgrResult" runat="server" Width="100%" BorderColor="Black" BorderWidth="1px"
            CellPadding="0" AutoGenerateColumns="False" PageSize="30" AllowPaging="True">
            <Columns>
                <asp:BoundColumn DataField="Code" HeaderText="Số thẻ"></asp:BoundColumn>
                <asp:BoundColumn DataField="FullName" HeaderText="Họ T&#234;n"></asp:BoundColumn>
                <asp:BoundColumn DataField="DOB" HeaderText="Ng&#224;y sinh" ItemStyle-HorizontalAlign="Center">
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ValidDate" HeaderText="Ng&#224;y cấp thẻ" ItemStyle-HorizontalAlign="Center">
                </asp:BoundColumn>
                <asp:BoundColumn DataField="ExpiredDate" HeaderText="Ng&#224;y hết hạn" ItemStyle-HorizontalAlign="Center">
                </asp:BoundColumn>
                <asp:TemplateColumn HeaderText="Giới t&#237;nh">
                    <ItemTemplate>
                        <asp:Label ID="lblSex" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sex") %>'>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Sex") %>'>
                        </asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateColumn>
                <asp:BoundColumn DataField="Ethnic" HeaderText="D&#226;n tộc"></asp:BoundColumn>
                <asp:BoundColumn DataField="College" HeaderText="Trường"></asp:BoundColumn>
                <asp:BoundColumn DataField="Faculty" HeaderText="Khoa"></asp:BoundColumn>
                <asp:BoundColumn DataField="Grade" HeaderText="Kho&#225;"></asp:BoundColumn>
                <asp:BoundColumn DataField="Class" HeaderText="Lớp"></asp:BoundColumn>
                <asp:BoundColumn DataField="Address" HeaderText="Địa chỉ"></asp:BoundColumn>
                <asp:BoundColumn DataField="Telephone" HeaderText="Điện thoại"></asp:BoundColumn>
                <asp:BoundColumn DataField="Mobile" HeaderText="Di động"></asp:BoundColumn>
                <asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>
                <asp:BoundColumn DataField="Note" HeaderText="Ghi ch&#250;"></asp:BoundColumn>
                <asp:BoundColumn DataField="Occupation" HeaderText="Ng&#224;nh nghề"></asp:BoundColumn>
                <asp:BoundColumn DataField="Name" HeaderText="Nh&#243;m bạn đọc"></asp:BoundColumn>
            </Columns>
            <PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
        </asp:DataGrid>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
            <asp:ListItem Value="3">Nam</asp:ListItem>
            <asp:ListItem Value="4">Nữ</asp:ListItem>
            <asp:ListItem Value="5">Không xác định</asp:ListItem>
        </asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">Số thẻ</asp:ListItem>
                <asp:ListItem Value="2">Họ Tên</asp:ListItem>
                <asp:ListItem Value="3">Ngày sinh</asp:ListItem>
                <asp:ListItem Value="4">Ngày cấp thẻ</asp:ListItem>
                <asp:ListItem Value="5">Ngày hết hạn</asp:ListItem>
                <asp:ListItem Value="6">Giới tính</asp:ListItem>
                <asp:ListItem Value="7">Dân tộc</asp:ListItem>
                <asp:ListItem Value="8">Trường</asp:ListItem>
                <asp:ListItem Value="9">Khoa</asp:ListItem>
                <asp:ListItem Value="10">Khóa</asp:ListItem>
                <asp:ListItem Value="11">Lớp</asp:ListItem>
                <asp:ListItem Value="12">Địa chỉ</asp:ListItem>
                <asp:ListItem Value="13">Số điện thoại</asp:ListItem>
                <asp:ListItem Value="14">Di động</asp:ListItem>
                <asp:ListItem Value="15">Email</asp:ListItem>
                <asp:ListItem Value="16">Ghi chú</asp:ListItem>
                <asp:ListItem Value="17">Ngành nghề</asp:ListItem>
                <asp:ListItem Value="18">Nhóm bạn đọc</asp:ListItem>
            </asp:DropDownList>
    </div>
    </form>
</body>
</html>
