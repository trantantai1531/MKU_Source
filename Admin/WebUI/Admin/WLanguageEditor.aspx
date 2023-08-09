<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WLanguageEditor" CodeFile="WLanguageEditor.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WLanguageEditor</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body>
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="center-form">
                <div class="main-body">
                    <div class="content-form">
                        <div class="main-form">
                            <h1 class="main-head-form">Quản lý ngôn ngữ</h1>
                            <div class="ClearFix two-column language-manage">
                                <div class="two-column-form">
                                    <div class="row-detail inline-box">
                                        <asp:Label ID="lbLanguage" runat="server">Chọn Ngôn ngữ:</asp:Label>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlLanguage" runat="server">
                                                    <asp:ListItem Value="eng" Selected="True">Tiếng Anh</asp:ListItem>
                                                    <asp:ListItem Value="fre">Tiếng Ph&#225;p</asp:ListItem>
                                                    <asp:ListItem Value="chi">Tiếng Trung Quốc</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="two-column-form" style="text-align: right;">
                                    <div class="row-detail inline-box">
                                        <asp:Label ID="lblSort" runat="server">Sắp xếp:</asp:Label>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlSort" runat="server">
                                                    <asp:ListItem Value="0" Selected="True">Ngầm định</asp:ListItem>
                                                    <asp:ListItem Value="1">Nh&#227;n tiếng việt</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="ClearFix main-page">
                                <div class="input-control">
                                    <div class="table-form" style="  overflow: hidden;border-right: 1px solid #666;">
                                        <asp:DataGrid ID="dtgLabel" runat="server" AutoGenerateColumns="False" Width="100%">
                                            <Columns>
                                                <asp:BoundColumn DataField="namelabel" ReadOnly="True" HeaderText="T&#234;n nh&#227;n">
                                                    <HeaderStyle Width="10%"></HeaderStyle>
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="Tiếng Việt">
                                                    <HeaderStyle Width="35%"></HeaderStyle>
                                                    <ItemTemplate>
                                                        
                                                        <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.vietnamese") %>' ID="txtdtgVie" Width="350px" TextMode="MultiLine" CssClass="lbTextBox" ReadOnly="True">
                                                        </asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn>
                                                    <HeaderStyle Width="35%"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.langtran") %>' ID="txtdtgLangtran" Width="350px" TextMode="MultiLine" CssClass="lbTextBox" ReadOnly="True">
                                                        </asp:TextBox>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                    </EditItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="FilePath" ReadOnly="True">
                                                    <HeaderStyle Width="15%"></HeaderStyle>
                                                </asp:BoundColumn>
                                            </Columns>
                                        </asp:DataGrid>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
