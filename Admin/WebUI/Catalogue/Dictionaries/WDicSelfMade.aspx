<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WDicSelfMade"
    CodeFile="WDicSelfMade.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WDicSelfMade</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div class="row-detail">
            <h1 class="main-group-form">
                <asp:Label ID="lblHeader" runat="server" CssClass="lbPageTitle">Từ điển</asp:Label></h1>
            <div class="TabbedPanelsContentGroup">
                <div style="display: block;" class="TabbedPanelsContent TabbedPanelsContentVisible">
                    <div class="input-control inline-box">
                        <p>
                            <asp:Label ID="lblLabelField" runat="server"><u>N</u>hãn trường:</asp:Label></p>
                        <div class="input-form ">
                            <asp:TextBox ID="txtFieldCode" runat="server"></asp:TextBox>
                        </div>
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnInsertFromSource" runat="server" Text="Nhập từ nguồn(i)"></asp:Button>
                            </div>
                        </div>
                        <p>
                            <asp:Label ID="lblFilterGrid" runat="server"><u>L</u>ọc:</asp:Label></p>
                        <div class="input-form ">
                            <asp:TextBox ID="txtFilter" runat="server" Width="96px"></asp:TextBox>
                        </div>
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnFilter" runat="server" Text="Lọc(c)" Width="54px"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="input-control">
                    <div class="table-form">
                        <asp:DataGrid ID="DtgDicSelfMade" runat="server" Width="100%" AllowPaging="True"
                            AutoGenerateColumns="False" PageSize="15">
                            <Columns>
                                <asp:TemplateColumn Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Chọn">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkID" runat="server" ></asp:CheckBox>
                                        <label for="c4"></label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Mục từ">
                                    <ItemTemplate>
                                        <asp:Label ID="LblDictionary" Text='<%# DataBinder.Eval(Container.DataItem, "Dictionary") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="300" runat="server" ID="txtDictionary" Text='<%# DataBinder.Eval(Container.DataItem, "Dictionary") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src='../images/update.gif' border='0'&gt;"
                                    HeaderText="Sửa" CancelText="&lt;img src='../images/cancel.gif' border='0'&gt;"
                                    EditText="&lt;img src='../images/edit2.gif' border='0'&gt;">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </asp:EditCommandColumn>
                            </Columns>
                            <PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>
                        <div class="row-detail" id="divDictionary" runat="server">
                            <div class="input-control inline-box">
                                <p>
                                    <asp:Label ID="lblEntry" runat="server"><U>M</U>ục từ:</asp:Label></p>
                                <div class="input-form ">
                                    <asp:TextBox ID="txtNewDictionary" CssClass="lbTextBox" runat="server" Width="50%"></asp:TextBox>
                                </div>
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnNewDictionary" runat="server" Text="Thêm mới(n)" CssClass="form-btn">
                                        </asp:Button>
                                    </div>
                                </div>
                                <p>
                                    <input id="txtIDs" type="hidden" name="txtIDs" runat="server" />
                                    <input id="txtReIndex" type="hidden" value="0" name="txtReIndex" runat="server" />
                                    <asp:Label ID="lblFilterDrop" runat="server"><u>G</u>ộp thành:</asp:Label></p>
                                <div class="input-form ">
                                    <asp:TextBox ID="txtGroup" CssClass="lbTextBox"  runat="server" AutoPostBack="True"></asp:TextBox>
                                </div>
                                <div class="dropdown-form input-form">
                                    <asp:DropDownList ID="ddlDic" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="button-control">
                                    <div class="button-form">
                                          <asp:Button ID="btnGroup" runat="server" Text="Gộp(m)" CssClass="form-btn"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            
            </div>
        </div>
    </div>
    <table id="tblDisplay" width="100%" border="0">
    </table>
    <asp:DropDownList ID="ddlAboutAction" Width="0px" runat="server" Visible="False">
        <asp:ListItem Value="0">Bạn thực sự muốn xoá mẫu này?</asp:ListItem>
        <asp:ListItem Value="1">Mẫu danh mục mới chưa được ghi nhận</asp:ListItem>
        <asp:ListItem Value="2">Cập nhật mẫu danh mục thành công</asp:ListItem>
        <asp:ListItem Value="3">Đã ghi nhận mẫu mẫu danh mục mới</asp:ListItem>
        <asp:ListItem Value="4">Bạn chưa nhập tên mẫu danh mục</asp:ListItem>
        <asp:ListItem Value="5">Mẫu danh mục mới đã được ghi nhận</asp:ListItem>
        <asp:ListItem Value="6">"Insert: "</asp:ListItem>
        <asp:ListItem Value="7">"Update: "</asp:ListItem>
        <asp:ListItem Value="8">"Delete: "</asp:ListItem>
        <asp:ListItem Value="9">Bạn chưa nhập mục từ</asp:ListItem>
        <asp:ListItem Value="10">Bạn không được cấp quyền sử dụng chức năng này</asp:ListItem>
        <asp:ListItem Value="11">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="12">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="13">Mục từ này đã tồn tại trong CSDL</asp:ListItem>
        <asp:ListItem Value="14">Nhãn trường không hợp lệ</asp:ListItem>
        <asp:ListItem Value="15">Nhãn trường đã có từ điển tham chiếu khác</asp:ListItem>
        <asp:ListItem Value="16">Nhãn trường không tồn tại</asp:ListItem>
        <asp:ListItem Value="17">Từ điển đang có dữ liệu. Bạn có muốn xoá hết dữ liệu cũ không ?</asp:ListItem>
        <asp:ListItem Value="18">Nhập khẩu mục từ</asp:ListItem>
        <asp:ListItem Value="19">Sửa mục từ</asp:ListItem>
        <asp:ListItem Value="20">Gộp các mục từ thành: </asp:ListItem>
        <asp:ListItem Value="21">Bạn chưa nhập đủ thông tin cần gộp</asp:ListItem>
        <asp:ListItem Value="22">Nhập mới mục từ: </asp:ListItem>
        <asp:ListItem Value="23">Đang nhập từ nguồn... </asp:ListItem>
    </asp:DropDownList>
    </form>
</body>
</html>
