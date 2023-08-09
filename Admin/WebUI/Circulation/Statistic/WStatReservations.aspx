<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatReservations.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WStatReservations" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
    <title>Báo cáo tổng hợp</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        select
        {
            height:29px;
        }
        hr
        {
            margin:10px 5% 25px 5%;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
         <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Báo cáo lượt đăng ký mượn</h1>
                <div class="row-detail">
                    <div class="two-column">
                        <div class="two-column-form" style="text-align:right; padding-top: 3px;">
                                    <table width="100%" border="0">
                                        <tr style="text-align:right">
                                            <td style="width:70%">
                                                <div class=" row-detail" >
                                                    <p>Thống kê theo</p>
                                                     <div class="dropdown-form">
                                                     <asp:DropDownList ID="ddlType" runat="server" Width="100px">
                                                        <asp:ListItem Value="0">Tên tài liệu</asp:ListItem>
                                                        <asp:ListItem Value="1">Bạn đọc</asp:ListItem>
                                                     </asp:DropDownList>
                                                     </div>
                                                </div>
                                            </td>
                                            <td style="width:auto">
                                                <div class="row-detail">
                                                <p>Chọn thời gian</p>
                                                <div class="dropdown-form" >
                                                    <asp:DropDownList ID="ddlTimes" runat="server">
                                                        <asp:ListItem Value="0">Tất cả</asp:ListItem>
                                                        <asp:ListItem Value="7">7 ngày trước</asp:ListItem>
                                                        <asp:ListItem Value="14">14 ngày trước</asp:ListItem>
                                                        <asp:ListItem Value="30">30 ngày trước</asp:ListItem>
                                                        <asp:ListItem Value="60">60 ngày trước</asp:ListItem>
                                                        <asp:ListItem Value="90">90 ngày trước</asp:ListItem>
                                                        <asp:ListItem Value="-1">Tùy chọn</asp:ListItem>
                                                    </asp:DropDownList>
                                                 </div>
                                                 </div>
                                            </td>
                                        </tr>
                                    </table>
                        </div>
                        <div class="two-column-form" style="text-align:left">
                            <div class="two-column">
                                <asp:Panel ID="PanelOther" runat="server">
                                    <div class="two-column-form">
                                        <table width="100%" border="0">
                                            <tr>
                                                <td style="width:120px">
                                                    <div class="row-detail">
                                                        <p>Từ ngày :<asp:hyperlink id="lnkDateFrom" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                                        <div class="input-control">
                                                            <div class="input-form ">
                                                                <asp:textbox CssClass="text-input"  id="txtDateFrom" Width="" Runat="server"></asp:textbox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td style="width:120px">
                                                    <div class="row-detail">
                                                        <p>Đến ngày :<asp:hyperlink id="lnkDateTo" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                                        <div class="input-control">
                                                            <div class="input-form ">
                                                                <asp:textbox CssClass="text-input"  id="txtDateTo" Width="" Runat="server"></asp:textbox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                                <div class="two-column-form">
                                    <div class="row-detail" style="margin-top:1px;">
                                        <p>&nbsp</p>
                                        <div class="button-control">
                                            <div class="button-form">
                                                <asp:Button CssClass="form-btn" ID="btnBindData" runat="server" Text="Thống kê"></asp:Button>
                                            </div>
                                            <div class="button-form">
                                                <asp:Button CssClass="form-btn" ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
             
                
            <div class="ClearFix"></div>
            <div class="table-form"> 
                <asp:GridView ID="dtgResultByFileName" runat="server" AllowPaging="True" Width="100%" AutoGenerateColumns="False" PageSize="50">
                    <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                    <Columns>
                        <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true">
                            <HeaderStyle Width="4%"/>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CREATEDDATE" HeaderText="Ngày đăng ký mượn" ReadOnly="true" htmlencode="false" >
                            <HeaderStyle Width="12%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="MAINITEM" HeaderText="Tên tài liệu" ReadOnly="true">
                            <HeaderStyle Width="40%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>                       
                        <asp:BoundField DataField="COPYNUMBER" HeaderText="Số ĐKCB" ReadOnly="true">
                            <HeaderStyle Width="12%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CODE" HeaderText="Mã số thẻ" ReadOnly="true">
                            <HeaderStyle Width="12%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FULLNAME" HeaderText="Họ và tên" ReadOnly="true">
                            <HeaderStyle Width="20%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Position="Bottom" />
                </asp:GridView>

                <asp:GridView ID="dtgResultByPatronName" runat="server" AllowPaging="True" Width="100%" AutoGenerateColumns="False" PageSize="50">
                    <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                    <Columns>
                        <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true">
                            <HeaderStyle Width="4%"/>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CREATEDDATE" HeaderText="Ngày đăng ký mượn" ReadOnly="true" htmlencode="false">
                            <HeaderStyle Width="12%" HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CODE" HeaderText="Mã số thẻ" ReadOnly="true">
                            <HeaderStyle Width="12%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>                       
                        <asp:BoundField DataField="FULLNAME" HeaderText="Họ và Tên" ReadOnly="true">
                            <HeaderStyle Width="20%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MAINITEM" HeaderText="Tên tài liệu" ReadOnly="true">
                            <HeaderStyle Width="40%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="COPYNUMBER" HeaderText="Số ĐKCB" ReadOnly="true">
                            <HeaderStyle Width="12%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Position="Bottom" />
                </asp:GridView>
            </div> 
        </div>
        <asp:DropDownList ID="ddlLabelValue" runat="server" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="3">Giá trị trường còn rỗng !</asp:ListItem>
			<asp:ListItem Value="4">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
			<asp:ListItem Value="5">Số lượng TLĐT tải</asp:ListItem>
			<asp:ListItem Value="6">Mã bạn đọc</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">STT</asp:ListItem>
            <asp:ListItem Value="1">Ngày đăng ký mượn</asp:ListItem>
            <asp:ListItem Value="2">Tên tài liệu</asp:ListItem>
            <asp:ListItem Value="3">Số ĐKCB</asp:ListItem>
            <asp:ListItem Value="4">Mã số thẻ</asp:ListItem>
            <asp:ListItem Value="5">Họ và tên</asp:ListItem>
        </asp:DropDownList>
        <div style="display:none">
            <input name="hidMessageBook" runat="server" type="hidden" id="hidMessageBook" value="Tổng số: " />
            <input name="hidLeftTable" runat="server" type="hidden" id="hidLeftTable" value="THƯ VIỆN<BR/> ĐẠI HỌC QUỐC TẾ MIỀN ĐÔNG" />
            <input name="hidRightTable" runat="server" type="hidden" id="hidRightTable" value="CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM<BR/>Độc lập - Tự do - Hạnh phúc" />
            <input name="hidTitleTable" runat="server" type="hidden" id="hidTitleTable" value="BÁO CÁO LƯỢT ĐĂNG KÝ MƯỢN " />
            <input name="hidMessageCopyNumber" runat="server" type="hidden" id="hidMessageCopyNumber" value="" />
        </div>
        <script type="text/javascript">
            document.getElementById("PanelOther").setAttribute("style", "display:none;");
            function change(e)
            {
                if(e.value == "-1")
                {
                    document.getElementById("PanelOther").removeAttribute("style");
                }
                else
                {
                    document.getElementById("PanelOther").setAttribute("style", "display:none;");
                }
            }
        </script>
    </form>
</body>
</html>
