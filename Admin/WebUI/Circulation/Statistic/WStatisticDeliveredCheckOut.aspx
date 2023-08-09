<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatisticDeliveredCheckOut.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WStatisticDeliveredCheckOut" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStatisticDeliveredCheckOut</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" oncontextmenu="return true;">
    <form id="form1" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Thống kê giao nhận tài liệu</h1>
            <div class="main-form">
                <div class="three-column ClearFix">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Từ ngày :<asp:HyperLink ID="lnkDateFrom" runat="server">&nbsp;Lịch</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtDateFrom" Width="" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Đến ngày :<asp:HyperLink ID="lnkDateTo" runat="server">&nbsp;Lịch</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtDateTo" Width="" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>&nbsp;</p>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnSearch" runat="server" Text="Tìm(f)" Width=""></asp:Button>
                                    <asp:Button ID="btnExport" runat="server" Text="Xuất file" Width=""></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="table-form">
                        <asp:DataGrid ID="dtgDelivered" runat="server" Width="100%" AutoGenerateColumns="False">
                            <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                            <Columns>
                                <asp:BoundColumn DataField="STT" HeaderText="STT" ReadOnly="true">
                                    <HeaderStyle Width="5%"/>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Title" HeaderText="Nhan đề" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CopyNumber" HeaderText="Số ĐKCB" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Classification" HeaderText="Số phân loại" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SenderDelivered" HeaderText="Nhân viên giao" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ReceiverDelivered" HeaderText="Nhân viên nhận" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DateDelivered" HeaderText="Ngày nhận" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="AcqSource" HeaderText="Nguồn bổ sung" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="StatusNote" HeaderText="Tình trạng ấn phẩm" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="LocationName" HeaderText="Kho" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="AttachDocument" HeaderText="Tài liệu kèm theo" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Note" HeaderText="Ghi chú" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </div>
            </div>
        </div>
        
        <div style="display:none;">
            
            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">Nhan đề</asp:ListItem>
                <asp:ListItem Value="2">Số ĐKCB</asp:ListItem>
                <asp:ListItem Value="3">Số phân loại</asp:ListItem>
                <asp:ListItem Value="4">Nhân viên giao</asp:ListItem>
                <asp:ListItem Value="5">Nhân viên nhận</asp:ListItem>
                <asp:ListItem Value="6">Ngày nhận</asp:ListItem>
                <asp:ListItem Value="7">Nguồn bổ sung</asp:ListItem>
                <asp:ListItem Value="8">Tình trạng ấn phẩm</asp:ListItem>
                <asp:ListItem Value="9">Kho</asp:ListItem>
                <asp:ListItem Value="10">Tài liệu kèm theo</asp:ListItem>
                <asp:ListItem Value="11">Ghi chú</asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
                <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
                <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
                <asp:ListItem Value="3">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
                <asp:ListItem Value="4">Dạng tài liệu lưu thông</asp:ListItem>
                <asp:ListItem Value="5">Số lượt mượn</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
