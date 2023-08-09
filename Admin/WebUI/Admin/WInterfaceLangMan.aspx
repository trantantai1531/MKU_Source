<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WInterfaceLangMan" CodeFile="WInterfaceLangMan.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WInterfaceLangMan</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="document.forms[0].txtLanguageName.focus()">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="center-form">
                <div class="content-form">
                    <h1 class="main-group-form">Soạn nội dung hiển thị theo ngôn ngữ</h1>
                    <div class="row-detail inline-box">
                        <div class="lbSubformTitle">
                            <asp:Label ID="lblLangNew" runat="server" CssClass="lbSubformTitle" Width="100%">Tạo mới ngôn ngữ</asp:Label></div>
                        <asp:HyperLink ID="lnkGoBack" runat="server">Trở lại trang Overview</asp:HyperLink>
                        <asp:Label ID="lblLanguageName" runat="server"><u>N</u>gôn ngữ:</asp:Label>&nbsp;<asp:TextBox ID="txtLanguageName" runat="server" Width="120px"></asp:TextBox><asp:Button ID="btnAddNew" runat="server" Width="93px" Text="Tạo mới(a)"></asp:Button>

                        <asp:Label ID="lblChange" runat="server" CssClass="lbSubformTitle" Width="100%">Thay đổi nội dung hiển thị</asp:Label>
                        <asp:Label ID="lblSource" runat="server"><u>N</u>gôn ngữ nguồn:</asp:Label>&nbsp;<asp:DropDownList ID="ddlSource" runat="server" Width="120px"></asp:DropDownList>
                        <asp:Label ID="lblDes" runat="server"><u>N</u>gôn ngữ đích:</asp:Label>&nbsp;<asp:DropDownList ID="ddlDes" runat="server" Width="120px"></asp:DropDownList><asp:Button ID="btnChange" runat="server" Width="93px" Text="Thay đổi(c)"></asp:Button>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlGroup" runat="server" AutoPostBack="True"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="input-control">
                        <div class="table-form">
                            <asp:DataGrid ID="dgrResult" runat="server" CellPadding="3" PageSize="10" Width="100%" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundColumn DataField="ControlName" ReadOnly="True" HeaderText="Tên điều khiển"></asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Ngôn ngữ nguồn">
                                        <HeaderStyle HorizontalAlign="Left" Width="40%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtdtgSource" CssClass="lbTextBox" runat="server" Width="90%" Text='<%# DataBinder.Eval(Container, "DataItem.TextField") %>'>
                                            </asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Ngôn ngữ đích">
                                        <HeaderStyle HorizontalAlign="Left" Width="40%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtdtgDes" CssClass="lbTextBox" runat="server" Width="90%" Text='<%# DataBinder.Eval(Container, "DataItem.ValueField") %>'>
                                            </asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
                            </asp:DataGrid>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnUpdate" runat="server" Width="98px" Text="Cập nhật(u)"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <input id="hidFilexml" type="hidden" name="hidFilexml" runat="server">
        <input type="hidden" id="hdMax" runat="server" value="0" name="hdMax">
        <input type="hidden" id="hidLanguages" runat="server" value="0" name="hidLanguages">
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Bạn phải nhập tên ngôn ngữ hoặc tên ngôn ngữ đã tồn tại!</asp:ListItem>
        </asp:DropDownList>

    </form>
</body>
</html>
