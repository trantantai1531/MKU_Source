<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WLibMan" CodeFile="WLibMan.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WLibMan</title>
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
            <div class="main-body">
                <h1 class="main-head-form">Thư viện</h1>
                <div class="row-detail">
                    <asp:Label ID="lblCodeLib" runat="server"><u>T</u>ên thư viện (viết tắt): </asp:Label> &nbsp;<asp:Label ID="lblForce" runat="server" ToolTip="Trường bắt buộc phải nhập dữ liệu" Font-Bold="True"
                                    ForeColor="Red">(*)</asp:Label>
                    <div class="input-control">
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtCodeLib" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                   <asp:Label ID="lblNameLib" runat="server">Tên t<u>h</u>ư viện (đầy đủ):</asp:Label>
                    <div class="input-control">
                        <div class="input-form">
                            <asp:TextBox ID="txtNameLib" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                   <asp:Label ID="lblAddressLib" runat="server">Địa <u>c</u>hỉ:</asp:Label>
                    <div class="input-control">
                        <div class="input-form">
                            <asp:TextBox ID="txtAddressLib" CssClass="text-input" runat="server" Width=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnAddnewLib" runat="server" Width="98px" Text="Thêm mới(a)"></asp:Button>

                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" runat="server" Width="91px" Text="Làm lại(r)"></asp:Button>
                        </div>
                    </div>
                </div>
                <div class="input-control row-detail">
                    <div class="table-form">
                        <asp:DataGrid ID="dtgInfoLib" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                            Height="40px">
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Tên thư viện (viết tắt)">
                                    <HeaderStyle Width="20%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.code") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtdtgCodeLib" CssClass="lbTextBox" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.code") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Tên thư viện (đầy đủ)">
                                    <HeaderStyle Width="30%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtdtgNameLib" CssClass="lbTextBox" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Địa chỉ">
                                    <HeaderStyle Width="35%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Address") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtdtgAddressLib" CssClass="lbTextBox" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Address") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" Text="<image src ='../../Images/Edit2.gif' border=0 title='Sửa đổi'>"
                                            CommandName="Edit" CausesValidation="false"></asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="lnkdtgbtnUpdate" runat="server" Text="<Image src ='../../Images/update.gif' title='Cập nhật' border=0>"
                                            CommandName="Update"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
										<asp:LinkButton runat="server" Text="<Image src ='../../Images/Cancel.gif' title='Thôi' border=0>"
                                            CommandName="Cancel" CausesValidation="false"></asp:LinkButton>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderText="Chọn">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ckbdtgMerger" runat="server" Text=""></asp:CheckBox>
                                        <label for="ckbdtgMerger"></label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>
                    </div>
                    <div>
                    </div>
                </div>

                <div class="row-detail">
                    <div class="button-control inline-box">
                        <p>Gộp thư viện đã chọn vào thư viện :</p>
                        <div class="input-control" style="width: 26%;">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlMergerLib" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnMergerLib" runat="server" Width="64px" Text="Gộp(m)"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <input id="hidLibIDs" type="hidden" name="hidLibIDs" runat="server">
        <input id="hidPageIndex" type="hidden" name="hidPageIndex" runat="server">
        <asp:DropDownList ID="ddlLabelNote" runat="server" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="0">Nhấn OK để khẳng định xoá phương thức này</asp:ListItem>
            <asp:ListItem Value="1">Bạn chưa nhập tên thư viện!</asp:ListItem>
            <asp:ListItem Value="2">Thư viện</asp:ListItem>
            <asp:ListItem Value="3">đã có trong cơ sở dữ liệu ?</asp:ListItem>
            <asp:ListItem Value="4">Lỗi ! Bạn phải chọn một thư viện khác với thư viện cần gộp!</asp:ListItem>
            <asp:ListItem Value="5">Bạn có muốn gộp thư viện đã chọn không?</asp:ListItem>
            <asp:ListItem Value="6">Bạn phải chọn ít nhất một thư viện trước khi gộp!</asp:ListItem>
            <asp:ListItem Value="7">Gộp thành công!</asp:ListItem>
            <asp:ListItem Value="8">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="9">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="10">Tạo thư viện mới</asp:ListItem>
            <asp:ListItem Value="11">Gộp thư viện</asp:ListItem>
            <asp:ListItem Value="12">Cập nhật thư viện </asp:ListItem>
            <asp:ListItem Value="13">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="14">Lỗi trong quá trình tải dữ liệu.</asp:ListItem>
            <asp:ListItem Value="15">thành công</asp:ListItem>
            <asp:ListItem Value="16">Lỗi trong quá trình cập nhật hoặc tên thư viện đã tồn tại!</asp:ListItem>
            <asp:ListItem Value="17">Tạo mới thành công !</asp:ListItem>
        </asp:DropDownList>
    </form>

    <script language="javascript">
        document.forms[0].txtCodeLib.focus();
    </script>
</body>
</html>
