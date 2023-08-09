<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WSendPOSearch" CodeFile="WSendPOSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSendPOSearch</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <style>
        #lblMessages {
            font-size: 15px;
            margin-left: 16px;
            margin-top: 20px;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-page ClearFix">
                <asp:Label ID="lblMainTitle" CssClass="lbPageTitle main-head-form" runat="server" Width="100%">Liệt kê các đơn đặt đang chờ và gửi đi.</asp:Label>
                <div class="three-column ClearFix" id="dataResult" runat="server">
                    <div class="">
                        <div class="row-detail">
                            <div class="input-control">
                                <asp:CheckBox ID="optSelectAll" runat="server" Text="Chọn <U>t</U>oàn bộ"></asp:CheckBox>
                               
                            </div>
                        </div>
                        <div class="table-form">
                            <asp:DataGrid ID="dgrPOList" runat="server" Width="100%" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                                    <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <input type="checkbox" id="optChoice" runat="server"></input>
                                            <label for="optChoice"></label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIDs" runat="server">
											<%# DataBinder.Eval(Container.dataItem,"ID")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="URL" HeaderText="Đơn đặt"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="ValidDate" HeaderText="Ngày bắt đầu" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle Width="14%"></HeaderStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="FilledDate" HeaderText="Ngày kết thúc" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle Width="14%"></HeaderStyle>
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Đơn bản" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle Width="8%"></HeaderStyle>
                                        <ItemTemplate>
                                            <input type="checkbox" id="chkType" runat="server" checked='<%# DataBinder.Eval(Container.dataItem,"Type")%>' enabled="False"> </input>
                                            <label for="chkType"></label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                        </div>
                        <div class="row-detail">
                            <asp:Label ID="lblTemplate" runat="server">Chọ<u>n</u> mẫu hiển thị:</asp:Label>
                            <div class="input-control" style="width: 300px">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlTemplate" Width="200px" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="input-control">
                                <asp:CheckBox ID="ckbPOStatus" runat="server" Text="<u>C</u>huyển trạng thái đơn đặt thành đã gửi"></asp:CheckBox>
                              
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnPrint" CssClass="form-btn" runat="server" Text="In(p)" Width="50px"></asp:Button>
                            </div>
                            <div class="button-form">

                                <asp:Button ID="btnEmail" CssClass="form-btn" runat="server" Text="Gửi thư(s)" Width="78px"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnPreview" CssClass="form-btn" runat="server" Text="Xem trước(v)" Width="98px"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnFile" CssClass="form-btn" runat="server" Text="Ghi ra file(f)" Width="100px"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <asp:Label ID="lblMessages" ForeColor="red" runat="server" Text="Label"></asp:Label>

            </div>
        </div>
        <table cellspacing="0" cellpadding="4" width="100%" border="0">
            <tr>
                <td colspan="2"></td>
            </tr>
        </table>
        <input type="hidden" id="hdIDs" runat="server" />
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Enabled="False">
            <asp:ListItem Value="0">---------- Chọn mẫu ----------</asp:ListItem>
            <asp:ListItem Value="1">Bạn chưa chọn mẫu đơn hiển thị</asp:ListItem>
            <asp:ListItem Value="2">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="3">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="4">Phải chọn ít nhất 1 đơn đặt</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblJS" runat="server"></asp:Label>
    </form>
</body>
</html>
