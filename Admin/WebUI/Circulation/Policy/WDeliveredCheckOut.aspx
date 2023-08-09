<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WDeliveredCheckOut.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WDeliveredCheckOut" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WDeleveredCheckOut</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        input[type="checkbox"] {
            display:block; 
            -webkit-appearance: checkbox !important;
            width: 39px;
            height: 20px;
            position: relative;
            opacity: 1;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0" oncontextmenu="return true;">
    <form id="form1" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Kiểm tra giao nhận tài liệu</h1>
            <div class="main-form">
                <div class="row-detail">
                    <div class="table-form">
                        <asp:DataGrid ID="dtgDelivered" runat="server" Width="100%" AutoGenerateColumns="False">
                            <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                            <Columns>
                                <asp:BoundColumn DataField="STT" HeaderText="STT" ReadOnly="true">
                                    <HeaderStyle Width="5%"/>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CopyNumber" HeaderText="Số ĐKCB" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Title" HeaderText="Nhan đề" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Author" HeaderText="Tác giả" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Classification" HeaderText="Số phân loại" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="AcquireSource" HeaderText="Nguồn bổ sung" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="AdditionalBy" HeaderText="Lý do" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </div>
                 
                <div class="three-column ClearFix">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Thời gian :<asp:HyperLink ID="lnkDate" runat="server">&nbsp;Lịch</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtDate" Width="" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Bên giao :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtSender" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Bên nhận :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtReceiver" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnPrint" runat="server" Text="In Phiếu" Width=""></asp:Button>
                            <asp:Button ID="btnDeliveredSend" runat="server" Text="Đồng ý chuyển" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="display:none;">
            <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
                <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
                <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
                <asp:ListItem Value="3">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
                <asp:ListItem Value="4">Xác nhận bàn giao tài liệu giấy nhập kho lưu hành thành công</asp:ListItem>
                <asp:ListItem Value="5">Xác nhận bàn giao tài liệu giấy nhập kho lưu hành không thành công</asp:ListItem>
            </asp:DropDownList>

            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">ĐKCB</asp:ListItem>
                <asp:ListItem Value="2">Nhan đề</asp:ListItem>
                <asp:ListItem Value="3">Tác giả</asp:ListItem>
                <asp:ListItem Value="4">Số phân loại</asp:ListItem>
                <asp:ListItem Value="5">Nguồn bổ sung</asp:ListItem>
                <asp:ListItem Value="6">Lý do</asp:ListItem>
            </asp:DropDownList>
        </div>
        
        
        <div style="display:none">
            <input name="hidLeftTable" runat="server" type="hidden" id="hidLeftTable" value="<B>ĐẠI HỌC QUỐC TẾ MIỀN ĐÔNG</B><BR/><U>&nbsp;&nbsp;&nbsp;THƯ VIỆN&nbsp;&nbsp;&nbsp;</U><BR/>Số 110/HKI/18-19-BGTLG-LH" />
            <input name="hidRightTable" runat="server" type="hidden" id="hidRightTable" value="<B>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</B><BR/><B><I><U>Độc lập - Tự do - Hạnh phúc</U></I></B>" />
            <input name="hidTitleTable" runat="server" type="hidden" id="hidTitleTable" value="<B>BIÊN BẢN BÀN GIAO TÀI LIỆU GIẤY NHẬP KHO LƯU HÀNH</B>" />
            
            <input name="hidTimes" runat="server" type="hidden" id="hidTimes" value="Thời gian: " />
            <input name="hidSender" runat="server" type="hidden" id="hidSender" value="Bên giao: " />
            <input name="hidReceiver" runat="server" type="hidden" id="hidReceiver" value="Bên nhận: " />
            <input name="hidDetailList" runat="server" type="hidden" id="hidDetailList" value="Chi tiết tài liệu bàn giao: " />
        </div>
    </form>
</body>
</html>

