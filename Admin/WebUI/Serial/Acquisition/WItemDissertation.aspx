<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WItemDissertation.aspx.vb" Inherits="eMicLibAdmin.Serial.Acquisition.WItemDissertation" %>


<!DOCTYPE html>

<html>
<head runat="server">
    <title>WItemDissertation</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .table-form table td .three-column .three-column-form
        {
            width: 32.5%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Danh sách ắn phẩm</h1>
            <div class="main-form">
                <div class="two-column">
                    <div class="two-column-form">
                        <div class="two-column">
                            <div class="two-column-form">
                                <div class="row-detail">
                                    <p>Nhan đề :</p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="two-column-form">
                                <div class="row-detail">
                                    <p>Số :</p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:TextBox CssClass="text-input" ID="txtNumber" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="two-column-form">
                        <div class="two-column">
                            <div class="two-column-form">
                                <div class="row-detail">
                                    <p>Năm :</p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:TextBox CssClass="text-input" ID="txtYear" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="two-column-form">
                                <div class="row-detail">
                                    <p>&nbsp</p>
                                    <div class="button-control">
                                        <div class="button-form">
                                            <asp:Button ID="btnSearch" CssClass="lbButton" runat="server" Text="Tìm(f)" Width=""></asp:Button>
                                        </div>
                                        <div class="button-form">
                                            <input type="reset" value="Làm lại(r)" class="lbButton" />
                                        </div>
                                        <div class="button-form">
                                            <asp:Button ID="btnUpdateCountPage" CssClass="lbButton" runat="server" Text="Cập nhật số trang(All)" Width=""></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ClearFix"></div>
                <div class="table-form">
                    <asp:GridView ID="dtgPolicy" runat="server" DataKeyNames="ID" AllowPaging="True" Width="100%" AutoGenerateColumns="False" PageSize="20">
                        <HeaderStyle CssClass="lbGridHeader" Height="30" />
                        <Columns>
                            <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="50"/>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Tiêu đề" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:HyperLink ID="linkDetail" NavigateUrl='<%# String.Format("WItemDissertationDetail.aspx?ItemID={0}", DataBinder.Eval(Container.DataItem, "ID"))%>' runat="server">
                                        <%# String.Format("{0}", DataBinder.Eval(Container.DataItem, "Content"))%>
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Position="TopAndBottom" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <asp:Label ID="lbInputValid" runat="server" Text="Nội dung nhập tìm kiếm không hợp lệ" Visible="false"></asp:Label>
        <asp:Label ID="lbUpdateSusscess" runat="server" Text="Cập nhật số trang thành công!" Visible="false"></asp:Label>
    </form>
</body>
</html>
