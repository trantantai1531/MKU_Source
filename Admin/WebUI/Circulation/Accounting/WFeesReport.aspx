<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WFeesReport" CodeFile="WFeesReport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Báo cáo tổng hợp</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <style>
        .lbGridHeader {
            font-weight: bold;
            text-align: center;
        }
      
            @page 
            {
                size: auto;   /* auto is the initial value */
                margin: 7mm;  /* this affects the margin in the printer settings */
            }
            @media print {
                html, body {
                    height: 99%;    
                }
            }
        
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr align="center" class="">
                <td align="center" class="">
                    <asp:Label ID="lblSettledTitle" runat="server">BÁO CÁO KHOẢN THU</asp:Label>
                    <asp:Label ID="lblUnsettledTitle" runat="server">BÁO CÁO KHOẢN PHẢI THU</asp:Label>
                </td>
            </tr>
            <tr align="center" class="">
                <td align="center" class="">
                    <asp:Label ID="lblSubTitle" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="dgtResult" runat="server" Width="100%" AllowPaging="False" AutoGenerateColumns="False">
                        <AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
                        <ItemStyle CssClass="lbGridCell"></ItemStyle>
                        <HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
                        <EditItemStyle CssClass="lbGridEdit"></EditItemStyle>
                        <Columns>
                            <asp:TemplateColumn HeaderText="Ngày thu">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedDate" Text='<%# DataBinder.Eval(Container.DataItem, "FromDate") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" CssClass="lbTextBox" runat="server" ID="txtCreatedDate" Text='<%# DataBinder.Eval(Container.DataItem, "FromDate") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Số thẻ">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblPatronCodeDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "PatronCode") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" CssClass="lbTextBox" runat="server" ID="txtPatronCodeDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "PatronCode") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Lý do">
                                <HeaderStyle Width="30%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblReasonDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Reason") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" CssClass="lbTextBox" runat="server" ID="txtReasonDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Reason") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Số tiền" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Width="13%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblAmountDisplay" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Amount") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" CssClass="lbTextBox" runat="server" ID="txtAmountDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Amount") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Đơn vị TT">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblCurrency" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"Currency")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Visible="False" runat="server" ID="txtCurrencyHid" Text='<%# DataBinder.Eval(Container.DataItem, "Currency") %>'>
                                    </asp:TextBox>
                                    <asp:DropDownList ID="ddlCurrencyDisplay" runat="server"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Tỉ giá" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblRateDisplay" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"Rate")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox Width="100%" CssClass="lbTextBox" runat="server" ID="txtRateDisplay" Text='<%# DataBinder.Eval(Container.DataItem, "Rate") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Thành tiền" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Width="13%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblTotal" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"Total")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>
            <tr runat="server" id="TRSumary" align="right" class="">
                <td colspan="4" align="right" class="">
                    <asp:Label ID="lblSumaryTemp" runat="server">Tổng: </asp:Label>
                    <asp:Label ID="lblSumary" runat="server" CssClass="lbAmount"></asp:Label>
                    <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
                        <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
                        <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
                        <asp:ListItem Value="2">Số thẻ</asp:ListItem>
                        <asp:ListItem Value="3">Tháng</asp:ListItem>
                        <asp:ListItem Value="4">tháng</asp:ListItem>
                        <asp:ListItem Value="5">Năm</asp:ListItem>
                        <asp:ListItem Value="6">năm</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </form>
    <script language="JavaScript">
		<!--
    self.focus();
    setTimeout('self.print()', 1);
    //-->
    </script>
</body>
</html>
