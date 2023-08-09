<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WRoomsBooking.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WRoomsBooking" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WRoomsBooking</title>
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
            <h1 class="main-head-form">Danh sách đặt phòng</h1>
            <div class="main-form">
                <div class="three-column">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Mã bạn đọc :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtPatronCode" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Phòng :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:dropdownlist id="ddlRooms" Runat="server"></asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Ngày đặt : <asp:hyperlink id="lnkBookingDate" Runat="server" CssClass="lbLinkFunction">Lịch</asp:hyperlink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input"  id="txtBookingDate" Runat="server" Width="90"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ClearFix"></div>
                <div class="three-column">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Ngày tạo từ :<asp:hyperlink id="lnkDateFrom" Runat="server" CssClass="lbLinkFunction">Lịch</asp:hyperlink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input"  id="txtDateFrom" Runat="server" Width="90"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Tới : <asp:hyperlink id="lnkDateTo" Runat="server" CssClass="lbLinkFunction">Lịch</asp:hyperlink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input"  id="txtDateTo" Runat="server" Width="90"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>&nbsp;</p>
                            <div class="button-control" style="text-align: right">
                                <div class="button-form">
                                    <asp:button id="btnFind" Runat="server" CssClass="lbButton" Text="Tìm (t)"></asp:button>
                                </div>
                                <div class="button-form">
                                    <asp:button id="btnExport" Runat="server" CssClass="lbButton" Text="Xuất báo cáo"></asp:button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ClearFix"></div>
                <div class="table-form">
                    <asp:GridView ID="GridViewHistory" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True" Width="100%" PageIndex="10">
                        <HeaderStyle CssClass="lbGridHeader" Height="30" />
                        <Columns>
                            <asp:BoundField DataField="STT" ReadOnly="true" HeaderText="STT" />
                            <asp:BoundField DataField="Code" ReadOnly="true" HeaderText="Mã bạn đọc" />
                            <asp:BoundField DataField="FullName" ReadOnly="true" HeaderText="Họ tên" />
                            <asp:BoundField DataField="Email" ReadOnly="true" HeaderText="Email" />
                            <asp:BoundField DataField="Faculty" ReadOnly="true" HeaderText="Khoa/Phòng ban" />
                            <asp:BoundField DataField="TypeRoom" ReadOnly="true" HeaderText="Loại phòng" />
                            <asp:BoundField DataField="RoomName" ReadOnly="true" HeaderText="Phòng" />
                            <asp:BoundField DataField="Uses" ReadOnly="true" HeaderText="Mục đích sử dụng" />
                            <asp:BoundField DataField="RequestOther" ReadOnly="true" HeaderText="Yêu cầu khác" />
                            <asp:BoundField DataField="Count" ReadOnly="true" HeaderText="Số lượng" />
                            <asp:BoundField DataField="ListCode" ReadOnly="true" HeaderText="Chi tiết số lượng" />
                            <asp:BoundField DataField="BookingDate" HeaderText="Ngày đặt" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="TimeStart" HeaderText="Giờ đặt" />
                            <asp:BoundField DataField="TimeEnd" HeaderText="Giờ trả" />
                            <asp:BoundField DataField="Note" HeaderText="Ghi chú" />
                            
                            <asp:CommandField HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="3%"
                                    UpdateText="&lt;img src=&quot;../../Images/update.gif&quot; border=&quot;0&quot;&gt;" CancelText="&lt;img src=&quot;../../Images/cancel.gif&quot; border=&quot;0&quot;&gt;"
                                    EditText="&lt;img src=&quot;../../Images/Edit2.gif&quot; border=&quot;0&quot;&gt;" ButtonType="Link" ShowEditButton="True">
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="" HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hidStatus" runat="server" Value='<%#Eval("BookingStatus") %>' />
                                    <asp:HyperLink CssClass="link-btn" ID="linkActive" runat="server" ToolTip="Duyệt">
                                        <img src="../../Images/select.jpg" alt="" />
                                    </asp:HyperLink>
                                    <asp:HyperLink CssClass="link-btn" ID="linkCancel" runat="server" ToolTip="Từ chối">
                                        <img src="../../Images/lock.gif" alt="" />
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn phải nhập dữ liệu kiểu số!</asp:ListItem>
            <asp:ListItem Value="3">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="4">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="5">Tất cả các phòng</asp:ListItem>
         </asp:DropDownList>
        <asp:DropDownList ID="ddlTypeRoom" Visible="False" runat="server">
            <asp:ListItem Value="0">Phòng học nhóm</asp:ListItem>
            <asp:ListItem Value="1">Phòng họp</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">STT</asp:ListItem>
            <asp:ListItem Value="1">Mã bạn đọc</asp:ListItem>
            <asp:ListItem Value="2">Họ tên</asp:ListItem>
            <asp:ListItem Value="3">Email</asp:ListItem>
            <asp:ListItem Value="4">Khoa/Phòng ban</asp:ListItem>
            <asp:ListItem Value="5">Loại phòng</asp:ListItem>
            <asp:ListItem Value="6">Mục đích sử dụng</asp:ListItem>
            <asp:ListItem Value="7">Yêu cầu khác</asp:ListItem>
            <asp:ListItem Value="8">Số lượng</asp:ListItem>
            <asp:ListItem Value="9">Chi tiết số lượng</asp:ListItem>
            <asp:ListItem Value="10">Ngày đặt</asp:ListItem>
            <asp:ListItem Value="11">Giờ đặt</asp:ListItem>
            <asp:ListItem Value="12">Giờ trả</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lbHeaderLeft" runat="server" Text="TRƯỜNG ĐẠI HỌC QUỐC TẾ MIỀN ĐÔNG<BR/>THƯ VIỆN" Visible="false"></asp:Label>
        <asp:Label ID="lbHeaderRight" runat="server" Text="CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM<BR/>Độc lập - Tự do - Hạnh phúc" Visible="false"></asp:Label>
        <asp:Label ID="lbHeaderTitle" runat="server" Text="BÁO CÁO<BR/>DANH SÁCH ĐẶT PHÒNG TỔNG HỢP</BR>" Visible="false"></asp:Label>
        <asp:Label ID="lbHeaderFromTo" runat="server" Text="(Từ {0} đến {1})" Visible="false"></asp:Label>
        <asp:Label ID="lbFooterRight" runat="server" Text="Bình Dương, ngày {0:dd} tháng {0:MM} năm {0:yyyy}<BR/>Người lập bảng" Visible="false"></asp:Label>
        <asp:Label ID="lbMsgActive" runat="server" Visible="false" Text="Đã duyệt"></asp:Label>
        <asp:Label ID="lbMsgCancel" runat="server" Visible="false" Text="Từ chối"></asp:Label>
        <asp:Label ID="lbSubjectEmailActive" runat="server" Visible="false" Text="Đặt phòng họp - {0} - {1} - Đã được duyệt"></asp:Label>
        <asp:Label ID="lbSubjectEmailCancel" runat="server" Visible="false" Text="Đặt phòng họp - {0} - {1} - Đã bị từ chối"></asp:Label>
        <asp:Literal ID="LiteralContentMailActive" runat="server" Visible="false">
            <p><b>Thông tin yêu cầu đặt phòng họp đã được duyệt</b></p>
            <table border="0">
                <tr>
                    <td>Họ tên</td>
                    <td>: <$FullName$></td>
                </tr>
                <tr>
                    <td>Mã bạn đọc</td>
                    <td>: <$Code$></td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>: <$Email$></td>
                </tr>
                <tr>
                    <td>Ngày</td>
                    <td>: <$BookingDate$></td>
                </tr>
                <tr>
                    <td>Thời gian</td>
                    <td>: <$TimeRange$></td>
                </tr>
                <tr>
                    <td>Phòng</td>
                    <td>: <$RoomName$></td>
                </tr>
            </table>
        </asp:Literal>
        <asp:Literal ID="LiteralContentMailCancel" runat="server" Visible="false">
            <p><b>Thông tin yêu cầu đặt phòng họp đã bị từ chối</b></p>
            <table border="0">
                <tr>
                    <td>Họ tên</td>
                    <td>: <$FullName$></td>
                </tr>
                <tr>
                    <td>Mã bạn đọc</td>
                    <td>: <$Code$></td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>: <$Email$></td>
                </tr>
                <tr>
                    <td>Ngày</td>
                    <td>: <$BookingDate$></td>
                </tr>
                <tr>
                    <td>Thời gian</td>
                    <td>: <$TimeRange$></td>
                </tr>
                <tr>
                    <td>Phòng</td>
                    <td>: <$RoomName$></td>
                </tr>
            </table>
        </asp:Literal>
        <asp:Label ID="lbUpdateError" runat="server" Text="Cập nhật thất bại" Visible="false"></asp:Label>
        <asp:Label ID="lbUpdateSuccess" runat="server" Text="Cập nhật thành công" Visible="false"></asp:Label>
        <asp:Label ID="lbCancelError" runat="server" Text="Từ chối yêu cầu thất bại" Visible="false"></asp:Label>
        <asp:Label ID="lbCancelSuccess" runat="server" Text="Từ chối yêu cầu thành công" Visible="false"></asp:Label>
        <asp:Label ID="lbActiveError" runat="server" Text="Duyệt yêu cầu thất bại" Visible="false"></asp:Label>
        <asp:Label ID="lbActiveSuccess" runat="server" Text="Duyệt yêu cầu thành công" Visible="false"></asp:Label>
        <asp:Label ID="lbMsgValidBusyTime" runat="server" Visible="false" Text="Thời gian đăng ký phòng đã bận. Chọn thời gian khác."></asp:Label>
        <script type="text/javascript">
            function ActiveRoomsBooking(intID) {
                if (confirm("Bạn chắc chắn duyệt đặt phòng họp này ?") == true)
                {
                    var linkRedirect = "WRoomsBooking.aspx?ActiveId=" + intID;
                    window.location.href = linkRedirect;
                }
            }
            function CancelRoomsBooking(intID) {
                if (confirm("Bạn chắc chắn từ chối đặt phòng họp này ?") == true) {
                    var linkRedirect = "WRoomsBooking.aspx?CancelId=" + intID;
                    window.location.href = linkRedirect;
                }
            }
        </script>
    </form>
</body>
</html>
