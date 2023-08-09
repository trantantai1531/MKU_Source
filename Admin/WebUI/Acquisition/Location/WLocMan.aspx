<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WLocMan" CodeFile="WLocMan.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WLocMan</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Hệ thống kho</h1>
                <div class="three-column">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Thư viện :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLibrary" runat="server" AutoPostBack="True"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Tên kho:</p><p class="error-star">(*)</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtLocation" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Mã kho :</p><p class="error-star">(*)</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCode" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row-detail" style="text-align:right;">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnAdd" runat="server" Text="Thêm(a)" Width=""></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="input-control row-detail" style="padding-top: 0px;padding-bottom: 0px;">
                    <div class="table-form">
                        <asp:DataGrid ID="dtgLocation" CssClass="table-form" runat="server" CellPadding="3" PageSize="15" AllowPaging="True"
                            AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Mã Kho">
                                    <HeaderStyle Width="30%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Symbol") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtdtgLocation" CssClass="lbTextBox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Symbol") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Tên kho">
                                    <HeaderStyle Width="50%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CodeLoc") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtdtgCode" CssClass="lbTextBox" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CodeLoc") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Sửa">
                                    <HeaderStyle Width="5%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="<image src ='../../Images/Edit2.gif' border=0 title='Sửa đổi'>"
                                            CommandName="Edit" CausesValidation="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkdtgUpdate" runat="server" Text="<Image src ='../../Images/update.gif' border=0 title='Cập nhật'>"
                                            CommandName="Update"></asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='../../Images/Cancel.gif' border=0 title='Thôi'>"
                                            CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Chọn">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckbdtgMerger" runat="server" Text=""></asp:CheckBox>
                                        <label for="ckbdtgMerger"></label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>
                    </div>
                </div>
                <div class="row-detail" style="background-color: #F2F2F2;padding: 5px 10px;border-top: 1px solid #DBDBD9;border-bottom: 1px solid #DBDBD9;">
                    <div class="button-control inline-box">
                        <asp:Label ID="lblLocationMerger" runat="server">Kh<u>o</u>:</asp:Label>
                        <div class="input-control" style="width: 26%;">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlLocation" runat="server" Width=""></asp:DropDownList>
                            </div>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnMerger" runat="server" Text="Gộp(m)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabelNote" runat="server" Visible="False" Width="0" Height="0">
            <asp:ListItem Value="0">Nhấn OK để khẳng định xoá phương thức này</asp:ListItem>
            <asp:ListItem Value="1">Bạn chưa nhập tên kho!</asp:ListItem>
            <asp:ListItem Value="2">Kho</asp:ListItem>
            <asp:ListItem Value="3">đã có trong thư viện hiện tại!</asp:ListItem>
            <asp:ListItem Value="4">Lỗi ! Bạn phải chọn một kho khác với kho cần gộp!</asp:ListItem>
            <asp:ListItem Value="5">Bạn có muốn gộp kho đã chọn không?</asp:ListItem>
            <asp:ListItem Value="6">Bạn phải chọn ít nhất một kho trước khi gộp!</asp:ListItem>
            <asp:ListItem Value="7">Gộp thành công!</asp:ListItem>
            <asp:ListItem Value="8">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="9">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="10">Tạo kho mới tại thư viện</asp:ListItem>
            <asp:ListItem Value="11">Gộp kho tại thư viện</asp:ListItem>
            <asp:ListItem Value="12">Cập nhật kho </asp:ListItem>
            <asp:ListItem Value="13">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="14">Không có kho trong thư viện.</asp:ListItem>
            <asp:ListItem Value="15">thành công !</asp:ListItem>
            <asp:ListItem Value="16">Lỗi trong quá trình cập nhật hoặc kho đã tồn tại!</asp:ListItem>
            <asp:ListItem Value="17">Tạo mới thành công !</asp:ListItem>
            <asp:ListItem Value="18">Mã kho</asp:ListItem>
            <asp:ListItem Value="19">Bạn chưa nhập mã kho!</asp:ListItem>
        </asp:DropDownList>
        <input id="hidLocIDs" name="hidLocIDs" type="hidden" runat="server">
        <input id="hidPageIndex" name="hidPageIndex" type="hidden" runat="server">
    </form>
    <script language="javascript">
        document.forms[0].txtCode.focus();
    </script>
</body>
</html>
