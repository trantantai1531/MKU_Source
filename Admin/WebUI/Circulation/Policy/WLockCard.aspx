<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WLockCard" CodeFile="WLockCard.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WLockCard</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />


</head>
<body leftmargin="5" topmargin="0" rightmargin="5" onload="document.forms[0].txtPatronCodeText.focus();">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Thông tin thẻ bạn đọc bị khoá</h1>
            <div class="main-form">
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                            <div class="row-detail" >
                                <p>Số thẻ</p>
                                <div class="input-control">
                                    <div class="input-form">
                                        <asp:TextBox CssClass="text-input" ID="txtPatronCodeText" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Ngày bắt đầu: &nbsp;<asp:HyperLink ID="lnkStartDate" runat="server">Lịch</asp:HyperLink></p>
                                <div class="input-control">
                                    <div class="input-form">
                                        <asp:TextBox CssClass="text-input" ID="txtStartedDateText" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Đến ngày: &nbsp;<asp:HyperLink ID="lnkEndDate" runat="server">Lịch</asp:HyperLink></p>
                                <div class="input-control">
                                    <div class="input-form">
                                        <asp:TextBox CssClass="text-input" ID="txtEndDateText" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                        <div class="row-detail" style="display:none;">
                            <p>Số ngày:</p>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtLockedDaysText" runat="server" Width="">1</asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Ghi chú:</p>
                            <asp:TextBox CssClass="area-input" ID="txtNoteText" runat="server" Width="100%" TextMode="MultiLine" Rows="5"></asp:TextBox>
                        </div>
                        <div class="row-detail">
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnLocks" runat="server" Text="Khoá(k)" Width=""></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <hr />
            <div id="trShowFillter" runat="server"  class="row-detail">
                <div class="input-control inline-box">
                    <p>Số thẻ :</p>
                    <div class="input-form ">
                        <asp:TextBox CssClass="text-input" ID="txtPatronCodeF" Width="" runat="server"></asp:TextBox>
                    </div>
                    <p>Ngày khóa từ : <asp:HyperLink ID="lnkStartDateFrom" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink></p>
                    <div class="input-form ">
                         <asp:TextBox CssClass="text-input" ID="txtStartDateFrom" Width="" runat="server"></asp:TextBox>
                    </div>
                    <p>Đến : <asp:HyperLink ID="lnkStartDateTo" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink></p>
                    <div class="input-form ">
                        <asp:TextBox CssClass="text-input" ID="txtStartDateTo" Width="" runat="server"></asp:TextBox>
                    </div>
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnFillter" Width="" runat="server" Text="Lọc(l)" CssClass="form-btn"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>

            <asp:Label ID="lblPatronLockCodes" runat="server" CssClass="lbSubFormTitle">Danh sách những thẻ đang bị khoá</asp:Label>
            <div class="table-form">
                <asp:DataGrid CssClass="table-control" ID="dgdPantronLocks" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                    PageSize="5">
                    <AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
                    <ItemStyle CssClass="lbGridCell"></ItemStyle>
                    <HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
                    <Columns>
                        <asp:TemplateColumn HeaderText="Họ t&#234;n bạn đọc">
                            <ItemStyle Width="20%"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblFullName" Text='<%# DataBinder.Eval(Container.dataItem,"FullName")%>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Số thẻ bạn đọc">
                            <ItemStyle Width="12%"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblPatronCode" Text='<%# DataBinder.Eval(Container.dataItem,"PatronCode")%>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Từ ng&#224;y">
                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblStartedDate" Text='<%# DataBinder.Eval(Container.dataItem,"STARTEDDATE")%>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Center"></FooterStyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Đến ng&#224;y">
                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblFinishDate" Text='<%# DataBinder.Eval(Container.dataItem,"FINISHDATE")%>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Center"></FooterStyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Số ng&#224;y">
                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                            <ItemTemplate>
                                <asp:Label ID="lblLockedDays" Text='<%# DataBinder.Eval(Container.dataItem,"LockedDays")%>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Center"></FooterStyle>
                            <EditItemTemplate>
                                <asp:TextBox CssClass="text-input" ID="txtLockday" Width="70px" Text='<%# DataBinder.Eval(Container.dataItem,"LockedDays")%>' runat="server">
                                </asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="L&#253; do">
                            <ItemTemplate>
                                <asp:Label ID="lblNote" Text='<%# DataBinder.Eval(Container.dataItem,"Note")%>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox CssClass="text-input" Width="200px" TextMode="MultiLine" runat="server" ID="txtNote" Text='<%# DataBinder.Eval(Container.DataItem, "Note") %>' />
                            </EditItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Chọn">
                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkCopyID" runat="server"></asp:CheckBox>
                                <label for="chkCopyID"></label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src=&quot;../../images/update.gif&quot; border=&quot;0&quot;&gt;"
                            HeaderText="Sửa" CancelText="&lt;img src=&quot;../../images/cancel.gif&quot; border=&quot;0&quot;&gt;"
                            EditText="&lt;img src=&quot;../../images/Edit2.gif&quot; border=&quot;0&quot;&gt;">
                            <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                        </asp:EditCommandColumn>
                    </Columns>
                    <PagerStyle Position="Top" CssClass="lbGridPager" Mode="NumericPages"></PagerStyle>
                </asp:DataGrid>
            </div>
                <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnDelete" runat="server" Text="Xoá(d)" Width=""></asp:Button>
                            </div>
                        </div>
                    </div>
            
        </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Khoá thẻ</asp:ListItem>
            <asp:ListItem Value="3">Mở khoá thẻ</asp:ListItem>
            <asp:ListItem Value="4">Ngày bắt đầu không hợp lệ</asp:ListItem>
            <asp:ListItem Value="5">Số ngày không hợp lệ</asp:ListItem>
            <asp:ListItem Value="6">Sai định dạng dữ liệu hoặc lỗi trong quá trình xử lý</asp:ListItem>
            <asp:ListItem Value="7">Bạn không thể cập nhật nếu nội dung trường này trống!</asp:ListItem>
            <asp:ListItem Value="8">thành công!</asp:ListItem>
            <asp:ListItem Value="9">Thẻ đang bị khoá!</asp:ListItem>
            <asp:ListItem Value="10">Khoá thẻ không thành công!</asp:ListItem>
            <asp:ListItem Value="11">Thẻ không tồn tại!</asp:ListItem>
            <asp:ListItem Value="12">Hiện tại thẻ này đang bị khoá!</asp:ListItem>
            <asp:ListItem Value="13">Ghi chú quá dài ( tối đa là 200 ký tự )</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblMsg1" runat="server" Visible="False">Các thẻ bạn đọc {0} còn đang nợ sách. Không cho phép mở khóa.</asp:Label>
        <asp:Label ID="lblMsg2" runat="server" Visible="False">Các thẻ bạn đọc {0} Không tồn tại trong hệ thống. Nhấn OK để tiếp tục xóa khóa thẻ với các thẻ này. Nhấn Cancel để giữ nguyên khóa thẻ các thẻ này.</asp:Label>
        <asp:Label ID="lblMsg3" runat="server" Visible="False">Các thẻ bạn đọc {0} mở khóa thành công.</asp:Label>
        <asp:Label ID="lblMsg4" runat="server" Visible="False">Cập nhật thành công</asp:Label>
        <asp:Label ID="lblMsg5" runat="server" Visible="False">Các thẻ bạn đọc {0} còn đang nợ sách. Không cho phép khóa thẻ.</asp:Label>
        <input id="hidPatronCodeCheck" type="hidden" runat="server" name="hidPatronCodeCheck"/>
        <asp:HiddenField ID="hidPatronCodeNotExist" Value="" runat="server" />
        <div style="display:none;">
            <asp:Button ID="btnAcceptUnLock" runat="server" Text="" Width=""></asp:Button>
        </div>
    </form>
</body>
</html>
