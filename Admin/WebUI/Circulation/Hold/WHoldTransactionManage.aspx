<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WHoldTransactionManage" CodeFile="WHoldTransactionManage.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WHoldTransactionManage</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Đặt chỗ</h1>
            <div class="main-form">
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail" style="display:block">
                            <div class="radio-control">
                                <asp:RadioButton ID="rdoResrv" Text="Đặt <u>c</u>hỗ" runat="server" Checked="True"></asp:RadioButton>
                                <label for="rdoResrv"></label>
                                <asp:RadioButton ID="rdoOutTurn" Text="<u>H</u>ết lượt" runat="server"></asp:RadioButton>
                                <label for="rdoOutTurn"></label>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Từ : <asp:HyperLink ID="lnkDateFrom" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input"  ID="txtFrom" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tới : <asp:HyperLink ID="lnkDateTo" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input"  ID="txtTo" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">
                        <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="rdoTitle" Text="<u>N</u>han đề" runat="server" Checked="True"></asp:RadioButton>
                                <label for="rdoTitle"></label>
                                <asp:RadioButton ID="rdoPatron" Text="<u>B</u>ạn đọc" runat="server"></asp:RadioButton>
                                <label for="rdoPatron"></label>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Nội dung : </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input"  ID="txtTitlePatron" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-detail">
                    <div class="button-control" style="text-align: center;">
                        <div class="button-form">
                            <asp:Button ID="btnFilter" Text="Lọc (l)" runat="server"></asp:Button>
                        </div>
                    </div>
                </div>

                <div class="input-control row-detail">
                    <div class="table-form">
                       <asp:DataGrid CssClass="table-control" ID="dtgResult" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateColumn HeaderText="STT">
                                <HeaderStyle Width="3%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblID" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"ID")%>'>
                                    </asp:Label>
                                    <asp:Label ID="lblSTT" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "STT")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Bạn đọc">
                                <HeaderStyle  Width="16%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblPatronName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FullName")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Số thẻ">
                                <HeaderStyle  Width="7%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnkPatronCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PatronCode")%>'>
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Nhan đề">
                                <HeaderStyle  Width="20%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lnkTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Content")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ĐKCB" Visible="false">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <%--<asp:Label ID="lblCopyNumber" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"CopyNumber")%>'>
                                    </asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Thời điểm đặt chỗ">
                                <HeaderStyle  Width="12%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateCreate")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="false" SortExpression="TIMEOUTDATE" HeaderText="Thời điểm hết lượt">
                                <HeaderStyle  Width="12%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblTimeOutDate" runat="server" Text='<%--<%# DataBinder.Eval(Container.dataItem,"TimeOutDate")%>--%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Hiệu lực tới ngày">
                                <HeaderStyle  Width="12%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblExpiredDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "DateExpire")%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="false" HeaderText="Trạng th&#225;i">
                                <HeaderStyle Width="12%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblStatusDisplay" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="False" HeaderText="Trạng th&#225;i">
                                <HeaderStyle Width="5%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Visible="False" Text='<%--<%# DataBinder.Eval(Container.dataItem,"InTurn")%>--%>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="R&#250;t lượt" Visible="false">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" CommandName="btnOutTurn" ID="btnOutTurn" ImageUrl="../../Images/button.gif"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Chuyển lượt" Visible="false">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:ImageButton runat="server" CommandName="btnChangeTurn" ImageUrl="../../images/gia.gif" ID="btnChangeTurn"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Xo&#225;" HeaderStyle-Width="5%">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" Text="<img src='../../images/delete.gif' border='0'>" CommandName="Delete"
                                        CausesValidation="false" ID="lnkdtgDelete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Position="TopAndBottom" CssClass="lbGridPager" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                    </div>
                </div>
            </div>
        </div>

        <input id="hidReserv" type="hidden" value="0" runat="server">
        <input id="hidTitlePatron" type="hidden" value="0" runat="server">
        <input id="hidOutTurn" type="hidden" value="0" runat="server">
        <input id="hidChangeTurn" type="hidden" value="0" runat="server">
        <input id="hidColSort" type="hidden" runat="server">
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
            <asp:ListItem Value="3">tới lượt</asp:ListItem>
            <asp:ListItem Value="4">đợi</asp:ListItem>
            <asp:ListItem Value="5">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="6">Bạn có muốn xoá yêu cầu đặt chỗ này không?</asp:ListItem>
            <asp:ListItem Value="7">Chuyển lượt đặt chỗ</asp:ListItem>
            <asp:ListItem Value="8">Rút lựơt đặt chỗ</asp:ListItem>
            <asp:ListItem Value="9">Xoá lượt đặt chỗ</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtFrom.focus();
    </script>
</body>
</html>
