<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WPolicyManagerSemester.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WPolicyManagerSemester" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>WPolicyManagementSemester</title>
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
            <h1 class="main-head-form">Chính sách lưu thông</h1>
            <div class="main-form">
                <div class="three-column">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Từ ngày :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtDayFrom" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Từ tháng :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtMonthFrom" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Năm :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:DropDownList ID="ddlYearFrom" runat="server">
                                        <asp:ListItem Value="0">Năm nay</asp:ListItem>
                                        <asp:ListItem Value="1">Năm sau</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ClearFix"></div>
                <div class="three-column">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Đến ngày :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtDayTo" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Đến tháng :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtMonthTo" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Năm :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:DropDownList ID="ddlYearTo" runat="server">
                                        <asp:ListItem Value="0">Năm nay</asp:ListItem>
                                        <asp:ListItem Value="1">Năm sau</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ClearFix"></div>
                <div class="three-column">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Học kì :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:DropDownList ID="ddlSemester" runat="server">
                                        <asp:ListItem Value="1">Học kỳ I</asp:ListItem>
                                        <asp:ListItem Value="2">Học kỳ II</asp:ListItem>
                                        <asp:ListItem Value="3">Học kỳ hè</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>&nbsp</p>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnUpdate" CssClass="lbButton" runat="server" Text="Thêm(f)" Width=""></asp:Button>
                                </div>
                                <div class="button-form">
                                    <input type="reset" value="Làm lại(r)" class="lbButton" />
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
                                <HeaderStyle Width="2%"/>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Tiêu đề" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lbTitle" runat="server" Text='<%# String.Format("{0}", DataBinder.Eval(Container.DataItem, "Title"))%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlSemester" runat="server">
                                        <asp:ListItem Value="1">Học kỳ I</asp:ListItem>
                                        <asp:ListItem Value="2">Học kỳ II</asp:ListItem>
                                        <asp:ListItem Value="3">Học kỳ hè</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Thời gian bắt đầu" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lbDateFrom" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}", DataBinder.Eval(Container.DataItem, "DateFrom"))%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div class="three-column">
                                        <div class="three-column-form">
                                            <p>Ngày</p>
                                            <asp:TextBox ID="txtDayFrom" runat="server" Height="25"></asp:TextBox>
                                        </div>
                                        <div class="three-column-form">
                                            <p>Tháng</p>
                                            <asp:TextBox ID="txtMonthFrom" runat="server" Height="25"></asp:TextBox>
                                        </div>
                                        <div class="three-column-form">
                                            <p>Năm</p>
                                            <asp:DropDownList ID="ddlYearFrom" runat="server">
                                                <asp:ListItem Value="0">Năm nay</asp:ListItem>
                                                <asp:ListItem Value="1">Năm sau</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Thời gian kết thúc" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lbDateTo" runat="server" Text='<%# String.Format("{0:dd/MM/yyyy}", DataBinder.Eval(Container.DataItem, "DateTo"))%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div class="three-column">
                                        <div class="three-column-form">
                                            <p>Ngày</p>
                                            <asp:TextBox ID="txtDayTo" runat="server" Height="25"></asp:TextBox>
                                        </div>
                                        <div class="three-column-form">
                                            <p>Tháng</p>
                                            <asp:TextBox ID="txtMonthTo" runat="server" Height="25"></asp:TextBox>
                                        </div>
                                        <div class="three-column-form">
                                            <p>Năm</p>
                                            <asp:DropDownList ID="ddlYearTo" runat="server">
                                                <asp:ListItem Value="0">Năm nay</asp:ListItem>
                                                <asp:ListItem Value="1">Năm sau</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%"
                                    UpdateText="&lt;img src=&quot;../../Images/update.gif&quot; border=&quot;0&quot;&gt;" CancelText="&lt;img src=&quot;../../Images/cancel.gif&quot; border=&quot;0&quot;&gt;"
                                    EditText="&lt;img src=&quot;../../Images/Edit2.gif&quot; border=&quot;0&quot;&gt;" ButtonType="Link" ShowEditButton="True">
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="" HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink CssClass="link-btn" ID="linkDelete" runat="server">
                                        <img src="../../Images/Delete.gif" alt="" />
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Position="TopAndBottom" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <asp:Label ID="lbSemesterValid" runat="server" Text="Học kỳ đã tồn tại" Visible="false"></asp:Label>
        <asp:Label ID="lbDayRequired" runat="server" Text="Ngày không để trống" Visible="false"></asp:Label>
        <asp:Label ID="lbMonthRequired" runat="server" Text="Tháng không để trống" Visible="false"></asp:Label>
        <asp:Label ID="lbCreateError" runat="server" Text="Tạo mới thất bại" Visible="false"></asp:Label>
        <asp:Label ID="lbCreateSuccess" runat="server" Text="Tạo mới thành công" Visible="false"></asp:Label>
        <asp:Label ID="lbUpdateError" runat="server" Text="Cập nhật thất bại" Visible="false"></asp:Label>
        <asp:Label ID="lbUpdateSuccess" runat="server" Text="Cập nhật thành công" Visible="false"></asp:Label>
        <asp:Label ID="lbDeleteError" runat="server" Text="Xóa thất bại" Visible="false"></asp:Label>
        <asp:Label ID="lbDeleteSuccess" runat="server" Text="Xóa thành công" Visible="false"></asp:Label>
        <script type="text/javascript">
            function DeleteItem(strID) {
                if (confirm("Bạn chắc chắn muốn xóa ?") == true)
                {
                    var linkRedirect = "WPolicyManagerSemester.aspx?DeleteId=" + strID;
                    window.location.href = linkRedirect;
                }
            }
        </script>
    </form>
</body>
</html>
