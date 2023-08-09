<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WZ3950" CodeFile="WZ3950.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WZ3050</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <style>
        input.lbTextBox, select {
            margin-bottom: 10px;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%">
            <tr class="lbPageTitle">
                <td class="lbPageTitle" colspan="4">
                    <asp:Label ID="lblHeader" runat="server" CssClass="lbPageTitle" Width="100%">Địa chỉ máy chủ Z39.50</asp:Label></td>
            </tr>
            <tr>
                <td colspan="4" height="7"></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblHostName" runat="server">Tên <u>m</u>áy chủ:</asp:Label>&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtHostName" runat="server"></asp:TextBox><font color="#ff0066">(*)</font></td>
                <td align="right">
                    <asp:Label ID="lblAddress" runat="server">Địa <u>c</u>hỉ:</asp:Label>&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox><font color="#ff0066">(*)</font></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblPort" runat="server">Cổ<u>n</u>g:</asp:Label>&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtPort" runat="server"></asp:TextBox></td>
                <td align="right">
                    <asp:Label ID="lblAccount" runat="server">Tài <u>k</u>hoản:</asp:Label>&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblPassword" runat="server">Mật khẩ<u>u</u>:</asp:Label>&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                <td align="right"></td>
                <td>
                    <asp:CheckBox ID="cbkLibPrefer" AccessKey="g" runat="server" Text="&nbsp;Thư viên ưa chuộn<u>g</u>"></asp:CheckBox></td>
            </tr>
            <tr>
                <td valign="bottom" align="center" colspan="4" height="30">
                    <asp:Button ID="btnAddnew" runat="server" Text="Tạo mới(a)" Width="83"></asp:Button>&nbsp;
						<asp:Button ID="btnReset" runat="server" Text="Làm lại(r)" Width="83"></asp:Button>&nbsp;
						<asp:Button ID="btnClose" runat="server" Text="Đóng(c)" Width="73"></asp:Button></td>
            </tr>
            <tr>
                <td height="5"></td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td width="100%">
                    <div class="table-form">
                        <asp:DataGrid ID="dtgZServer" runat="server" AutoGenerateColumns="False" Width="100%">
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="idOrder" ReadOnly="True" HeaderText="STT">
                                    <HeaderStyle Width="3%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="T&#234;n m&#225;y chủ">
                                    <HeaderStyle Width="25%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>' ID="Label1">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtHostNamedtg" CssClass="lbTextBox" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.Name") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Địa chỉ">
                                    <HeaderStyle Width="20%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Host") %>' ID="Label2">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtAddressdtg" CssClass="lbTextBox" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.Host") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Cổng">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Port") %>' ID="Label3">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="dtxtPort" CssClass="lbTextBox" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.Port") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="T&#224;i khoản">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Account") %>' ID="Label4">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="dtxtAccount" CssClass="lbTextBox" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.Account") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Mật khẩu">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Password") %>' ID="Label5">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="dtxtPassword" CssClass="lbTextBox" runat="server" TextMode="Password" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.Password") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Thư viện ưa chuộng">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Prefer") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="dcbkLibPrefer" CssClass="lbCheckBox" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.PreferredLender") %>'></asp:CheckBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;Image src =&quot;../Images/update.gif&quot; border=0 title=&quot;Cập nhật&quot;&gt;&amp;nbsp;&amp;nbsp;&amp;nbsp;"
                                    HeaderText="Sửa" CancelText="&lt;Image src =&quot;../Images/Cancel.gif&quot; title=&quot;Th&#244;i&quot; border=&quot;0&quot;&gt;"
                                    EditText="&lt;image src =&quot;../Images/Edit.gif&quot; border=0 title=&quot;Sửa đổi&quot;&gt;">
                                    <HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:EditCommandColumn>
                                <asp:ButtonColumn Text="&lt;IMAGE SRC='../Images/Delete.gif' border=0 title=&quot;Xo&#225; bỏ&quot;&gt;"
                                    HeaderText="Xo&#225;" CommandName="Delete">
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                </asp:ButtonColumn>
                                <asp:BoundColumn DataField="Link" ReadOnly="True" HeaderText="&amp;nbsp;"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="PreferredLender" ReadOnly="True" HeaderText="Prefervalue"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>

                </td>
            </tr>
        </table>
        <input id="ipAlertEmpty" type="hidden" value="Tên máy chủ và địa chỉ máy chủ là bắt buộc !!!"
            name="ipAlertEmpty">
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi </asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="3">Nhấn OK nếu thực sự muốn xoá!!!</asp:ListItem>
            <asp:ListItem Value="4"> Tên máy chủ là bắt buộc!!!</asp:ListItem>
            <asp:ListItem Value="5"> Tên phương thức đã tồn tại!!!</asp:ListItem>
            <asp:ListItem Value="6"> Xoá danh mục máy chủ</asp:ListItem>
            <asp:ListItem Value="7"> Nhập mới danh mục máy chủ</asp:ListItem>
            <asp:ListItem Value="8"> Update danh mục máy chủ</asp:ListItem>
            <asp:ListItem Value="9"> Sửa đổi tên máy chủ</asp:ListItem>
            <asp:ListItem Value="10">Địa chỉ máy chủ là bắt buộc</asp:ListItem>
            <asp:ListItem Value="11">Cập nhật thành công</asp:ListItem>
            <asp:ListItem Value="12">Cập nhật không thành công (các máy chủ phải khác nhau về tên, địa chỉ, cổng).</asp:ListItem>
            <asp:ListItem Value="13">Tên máy chủ là bắt buộc</asp:ListItem>
            <asp:ListItem Value="14">Địa chỉ máy chủ là bắt buộc</asp:ListItem>
            <asp:ListItem Value="15">Cổng là kiểu số</asp:ListItem>
            <asp:ListItem Value="16">Xóa danh mục máy chủ không thành công (danh mục đang có CSDL).</asp:ListItem>
        </asp:DropDownList>
        <script language="javascript">
            document.forms[0].txtHostName.focus();
        </script>
    </form>
</body>
</html>
