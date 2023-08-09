<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WRooms.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WRooms" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WRooms</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="5" topmargin="0" rightmargin="5">
    <form id="form1" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Phòng họp</h1>
            <div class="main-form">
                <div class="three-column">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Mã phòng :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtRoomCode" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Tên phòng :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtRoomName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Ghi chú :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtRoomNote" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="button-control" style="text-align: right">
                                <div class="button-form">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="lbButton" Text="Thêm"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ClearFix"></div>
                <div class="table-form">
                    <asp:GridView ID="GridViewRooms" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True" Width="100%" PageIndex="10">
                        <HeaderStyle CssClass="lbGridHeader" Height="30" />
                        <Columns>
                            <asp:BoundField DataField="STT" ReadOnly="true" HeaderText="STT" HeaderStyle-Width="4%" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField DataField="RoomCode" HeaderText="Mã phòng" />
                            <asp:BoundField DataField="RoomName" HeaderText="Tên phòng" />
                            <asp:BoundField DataField="RoomNote" HeaderText="Ghi chú" />
                            
                            <asp:CommandField HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="3%"
                                    UpdateText="&lt;img src=&quot;../../Images/update.gif&quot; border=&quot;0&quot;&gt;" CancelText="&lt;img src=&quot;../../Images/cancel.gif&quot; border=&quot;0&quot;&gt;"
                                    EditText="&lt;img src=&quot;../../Images/Edit2.gif&quot; border=&quot;0&quot;&gt;" ButtonType="Link" ShowEditButton="True">
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="" HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink CssClass="link-btn" ID="linkDelete" runat="server">
                                        <img src="../../Images/Delete.gif" alt="" />
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <asp:Label ID="lbCreateError" runat="server" Text="Tạo mới thất bại" Visible="false"></asp:Label>
        <asp:Label ID="lbCreateSuccess" runat="server" Text="Tạo mới thành công" Visible="false"></asp:Label>
        <asp:Label ID="lbUpdateError" runat="server" Text="Cập nhật thất bại" Visible="false"></asp:Label>
        <asp:Label ID="lbUpdateSuccess" runat="server" Text="Cập nhật thành công" Visible="false"></asp:Label>
        <asp:Label ID="lbDeleteError" runat="server" Text="Xóa thất bại" Visible="false"></asp:Label>
        <asp:Label ID="lbDeleteSuccess" runat="server" Text="Xóa thành công" Visible="false"></asp:Label>
        <script type="text/javascript">
            function DeleteRoom(intID) {
                if (confirm("Bạn chắc chắn muốn xóa ?") == true)
                {
                    var linkRedirect = "WRooms.aspx?DeleteId=" + intID;
                    window.location.href = linkRedirect;
                }
            }
        </script>
    </form>
</body>
</html>
