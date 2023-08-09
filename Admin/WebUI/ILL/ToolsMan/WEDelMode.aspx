<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WEDelMode" CodeFile="WEDelMode.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Quản lý danh mục các phương thức giao nhận điện tử</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>

<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">

        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        </telerik:RadAjaxManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>

        <table id="tblEdelMode" cellspacing="0" cellpadding="4" width="100%" border="0">
            <tr>
                <td width="100%">
                    <asp:Label ID="lblMainTitle" Width="100%" runat="server" CssClass="main-head-form">Phương thức giao nhận điện tử</asp:Label></td>
            </tr>
            <tr>
                <td height="7"></td>
            </tr>
            <tr>
                <td width="100%">
                    <table id="tblSub" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td align="right" width="35%" colspan="1">
                                <asp:Label ID="lblAddnew" runat="server"><U>T</U>ên phương thức: </asp:Label>&nbsp;</td>
                            <td width="80%" colspan="1">
                                <asp:TextBox ID="txtAddnew" Width="150px" runat="server"></asp:TextBox>&nbsp;<asp:Label ID="lblNote1" runat="server" ForeColor="red" ToolTip="Trường bắt buộc">(*)</asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" width="35%" colspan="1">
                                <asp:Label ID="lblAddr" runat="server">Đị<u>a</u> chỉ: </asp:Label>&nbsp;</td>
                            <td width="80%" colspan="1">
                                <asp:TextBox ID="txtAddr" Width="200px" runat="server"></asp:TextBox>&nbsp;<asp:Label ID="lblNote2" runat="server" ForeColor="red" ToolTip="Trường bắt buộc">(*)</asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" width="35%" colspan="1"></td>
                            <td width="80%" colspan="1">
                                <asp:Button ID="btnAddnew" Width="98px" runat="server" Text="Nhập mới(u)"></asp:Button>&nbsp;
									<asp:Button ID="btnClose" Width="73px" runat="server" Text="Đóng(o)"></asp:Button></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="100%">
                    <div class="table-form">
                        <asp:DataGrid ID="dgrEdelMode" Width="100%" runat="server" HeaderStyle-HorizontalAlign="Center"
                            AutoGenerateColumns="False">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True"></asp:BoundColumn>
                                <asp:BoundColumn DataField="EdelivMode" HeaderText="Phương thức">
                                    <HeaderStyle Width="20%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="EdelivTSAddr" HeaderText="Địa chỉ">
                                    <HeaderStyle Width="50%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:EditCommandColumn HeaderText="Sửa" ButtonType="LinkButton" UpdateText="<Image src ='../Images/update.gif' border='0' title='Cập nhật'>"
                                    CancelText="<Image src ='../Images/Cancel.gif' border='0' title='Huỷ'>" EditText="<image src ='../Images/Edit.gif' border='0' title='Sửa'>">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </asp:EditCommandColumn>
                                <asp:ButtonColumn Text="<IMAGE SRC='../Images/Delete.gif' border='0' title='Xoá'>" HeaderText="Xoá"
                                    CommandName="Delete">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </asp:ButtonColumn>
                            </Columns>
                        </asp:DataGrid>

                        <asp:GridView ID="gvEdelMode" Visible="False" runat="server" DataKeyNames="ID" AllowPaging="True" Width="100%" PageSize="2" AutoGenerateColumns="False">

                            <Columns>
                                <asp:BoundField Visible="False" DataField="ID" ReadOnly="True"></asp:BoundField>
                                <asp:BoundField DataField="EdelivMode" HeaderText="Phương thức">
                                    <HeaderStyle Width="20%"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="EdelivTSAddr" HeaderText="Địa chỉ">
                                    <HeaderStyle Width="50%"></HeaderStyle>
                                </asp:BoundField>
                                <asp:CommandField HeaderText="Sửa" ButtonType="Link" UpdateText="<Image src ='../Images/update.gif' border='0' title='Cập nhật'>"
                                    CancelText="<Image src ='../Images/Cancel.gif' border='0' title='Huỷ'>" EditText="<image src ='../Images/Edit.gif' border='0' title='Sửa'>" ShowEditButton="True">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </asp:CommandField>
                                <asp:ButtonField Text="<IMAGE SRC='../Images/Delete.gif' border='0' title='Xoá'>" HeaderText="Xoá"
                                    CommandName="Delete">
                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                </asp:ButtonField>

                            </Columns>
                            <HeaderStyle CssClass="lbGridHeader" />
                            <PagerStyle BorderStyle="None" />

                            <PagerStyle HorizontalAlign="Left" />

                            <PagerTemplate>
                                <table class="footer-pager">
                                    <tr class="lbGridPager">
                                        <td>
                                            <asp:PlaceHolder ID="phPageSize" runat="server"></asp:PlaceHolder>
                                        </td>
                                    </tr>
                                </table>
                            </PagerTemplate>

                        </asp:GridView>


                    </div>

                </td>
            </tr>
        </table>
        <asp:DropDownList ID="ddlLabel" Width="0" runat="server" Visible="False">
            <asp:ListItem Value="0">Mã lỗi </asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="3">Nhấn OK nếu thực sự muốn xoá!</asp:ListItem>
            <asp:ListItem Value="4">Đây là trường bắt buộc!</asp:ListItem>
            <asp:ListItem Value="5">Tên phương thức đã tồn tại!</asp:ListItem>
            <asp:ListItem Value="6">Xoá phương thức giao nhận thành công.</asp:ListItem>
            <asp:ListItem Value="7">Nhập mới danh mục các phuơng thức giao nhận </asp:ListItem>
            <asp:ListItem Value="8">Update danh mục các phuơng thức giao nhận </asp:ListItem>
            <asp:ListItem Value="9">Tên phương thức quá dài (tối đa là 20 ký tự).</asp:ListItem>
            <asp:ListItem Value="10">Địa chỉ quá dài (tối đa là 50 ký tự).</asp:ListItem>
            <asp:ListItem Value="11">Xóa phương thức không thành công (Phương thức này đang được sử dụng trong yêu cầu).</asp:ListItem>
        </asp:DropDownList>
        <input id="hidEMode" runat="server" type="hidden" />
        <input id="hidEArr" runat="server" type="hidden" />
        <script language="javascript">
            document.forms[0].txtAddnew.focus();
        </script>
    </form>
</body>
</html>
