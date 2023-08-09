<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WDenyReason" CodeFile="WDenyReason.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Danh mục lý do từ chối yêu cầu</title>
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
        <table id="Table1" cellspacing="0" cellpadding="3" width="100%">
            <tr>
                <td colspan="2" class="lbPageTitle">
                    <asp:Label ID="lblHeader" CssClass="main-head-form" runat="server">Danh mục các lý do từ chối</asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" height="7"></td>
            </tr>
            <tr>
                <td align="right" width="35%">
                    <asp:Label ID="lblCode" runat="server"><U>M</U>ã:</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtCode" runat="server" Width="350px"></asp:TextBox>&nbsp;
						<asp:Label ID="lblMan1" runat="server" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc">(*)</asp:Label></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblEnglish" runat="server"><U>T</U>ên tiếng Anh :</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtNameEng" Width="350px" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblVietnam" runat="server">Tên tiếng <U>V</U>iệt :</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtNameViet" Width="350px" runat="server"></asp:TextBox></td>
            </tr>
            <tr class="lbControlBar">
                <td valign="bottom" align="center" colspan="2" height="30">
                    <asp:Button ID="btnAddnew" runat="server" Text="Tạo mới(n)" Width="88px"></asp:Button>&nbsp;
						<asp:Button ID="btnReset" runat="server" Text="Làm lại(e)" Width="82px"></asp:Button>&nbsp;
						<asp:Button ID="btnClose" runat="server" Text="Đóng(o)" Width="68px"></asp:Button></td>
            </tr>
        </table>
        <table id="table2" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <div class="table-form">


                        <asp:DataGrid ID="dtgDenyReason" runat="server" Width="100%" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="idOrder" ReadOnly="True" HeaderText="STT" ItemStyle-HorizontalAlign="right">
                                    <HeaderStyle Width="3%"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Mã" ItemStyle-Width="10%">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Code") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="dtxtCode" CssClass="lbTextBox" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Code") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>

<ItemStyle Width="10%"></ItemStyle>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Tên tiếng Anh">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Eng") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="dtxtNameEng" CssClass="lbTextBox" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Eng") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Tên tiếng Việt">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Viet") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="dtxtNameViet" CssClass="lbTextBox" Width="100%" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Viet") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:EditCommandColumn HeaderText="Sửa" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ButtonType="LinkButton"
                                    UpdateText="<Image src ='../Images/update.gif' border='0' title='Cập nhật'>" CancelText="<Image src ='../Images/Cancel.gif' border='0' title='Huỷ'>"
                                    EditText="<image border='0' src='../Images/Edit.gif' boder='0' title='Sửa đổi'" >
<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </asp:EditCommandColumn>
                                <asp:ButtonColumn HeaderText="Xo&#225;" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" Text="<IMAGE SRC='../Images/Delete.gif'; border='0' title='Xoá'>"
                                    CommandName="Delete" >
<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </asp:ButtonColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </td>
            </tr>
        </table>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Chọn OK nếu thực sự muốn xoá</asp:ListItem>
            <asp:ListItem Value="3">Bạn chưa nhập đủ thông tin cần thiết</asp:ListItem>
            <asp:ListItem Value="4">Cập nhật lý do từ chối</asp:ListItem>
            <asp:ListItem Value="5">Xoá lý do từ chối</asp:ListItem>
            <asp:ListItem Value="6">thành công</asp:ListItem>
            <asp:ListItem Value="7">Mã lý do từ chối đã tồn tại trong CSDL</asp:ListItem>
            <asp:ListItem Value="8">Bạn không được cấp quyền sử dụng chức năng này.</asp:ListItem>
            <asp:ListItem Value="9">Xóa danh mục không thành công (danh mục đang được sử dụng). </asp:ListItem>
        </asp:DropDownList>
        <script language="javascript">
            document.forms[0].txtCode.focus();
        </script>
    </form>
</body>
</html>
