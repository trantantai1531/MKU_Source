<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatItemTotal.aspx.vb" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatItemTotal" %>

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
                <h1 class="main-head-form">Báo cáo tổng hợp tài liệu số</h1>
                <div class="row-detail">
                    <div class="two-column">
                        <div class="two-column-form" style="text-align:right; padding-top: 3px;">
                            <div class="row-detail">
                                <p>Chọn thời gian</p>
                                <div class="dropdown-form">
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
                <asp:Panel ID="PanelTotal" runat="server">
                    <div style="padding-bottom:15px;">
                        <table cellspacing="0" rules="all" border="1" style="width:100%;border-collapse:collapse;">
                            <tbody>
                                <tr class="lbGridHeader" style="height:30px;">
			                        <th align="left" scope="col" style="width:8%;">Thời gian</th>
                                    <th align="center" scope="col" style="width:8%;">Lượt truy cập OPAC</th>
                                    <th align="center" scope="col" style="width:8.5%;">Lượt bạn đọc đăng  nhập</th>
                                    <th align="center" scope="col" style="width:8.5%;">Lượt xem biểu ghi</th>

                                    <th align="center" scope="col" style="width:8.5%;">Số biểu ghi</th>
                                    <th align="center" scope="col" style="width:8.5%;">Số ebook upload</th>
                                    <th align="center" scope="col" style="width:8.5%;">Số trang Ebook Upload</th>
                                    <th align="center" scope="col" style="width:8.5%;">Số lượt xem Ebook</th>

                                    <th align="center" scope="col" style="width:8.5%;">Lượt bạn đọc download</th>
                                    <th align="center" scope="col" style="width:8.5%;">Lượt tài liệu download</th>
                                    <th align="center" scope="col" style="width:8%;">Số file tạp chí</th>
                                    <th align="center" scope="col" style="width:8%;">Số trang tạp chí</th>
		                        </tr>
                                <tr>
                                    <td><asp:Label ID="LabelTime" runat="server" Text=""></asp:Label></td>
                                    <td align="center"><asp:Label ID="LabelCountValid" runat="server" Text=""></asp:Label></td>
                                    <td align="center"><asp:Label ID="LabelCountLogin" runat="server" Text=""></asp:Label></td>
                                    <td align="center"><asp:Label ID="LabelCountViews" runat="server" Text=""></asp:Label></td>
                                    
                                    <td align="center"><asp:Label ID="LabelCountItem" runat="server" Text=""></asp:Label></td>
                                    <td align="center"><asp:Label ID="LabelCountFileUpload" runat="server" Text=""></asp:Label></td>
                                    <td align="center"><asp:Label ID="LabelCountPageEbooks" runat="server" Text=""></asp:Label></td>
                                    <td align="center"><asp:Label ID="LabelCountViewEbooks" runat="server" Text=""></asp:Label></td>
                                    
                                    <td align="center"><asp:Label ID="LabelCountPatronDownloads" runat="server" Text=""></asp:Label></td>
                                    <td align="center"><asp:Label ID="LabelCountDownloads" runat="server" Text=""></asp:Label></td>
                                    <td align="center"><asp:Label ID="LabelCountDissertation" runat="server" Text=""></asp:Label></td>
                                    <td align="center"><asp:Label ID="LabelCountMagazinePage" runat="server" Text=""></asp:Label></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <hr />
                </asp:Panel>
                
                <asp:GridView ID="dtgPolicy" runat="server" AllowPaging="True" Width="100%" AutoGenerateColumns="False" PageSize="50">
                    <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                    <Columns>
                        <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true">
                            <HeaderStyle Width="4%"/>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SetDate" HeaderText="Ngày" ReadOnly="true">
                            <HeaderStyle Width="8%" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CountValid" HeaderText="Lượt truy cập OPAC" ReadOnly="true">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>                       
                        <asp:BoundField DataField="CountLogins" HeaderText="Lượt bạn đọc đăng nhập" ReadOnly="true">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CountViews" HeaderText="Lượt xem biểu ghi" ReadOnly="true">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CountItems" HeaderText="Số biểu ghi" ReadOnly="true">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CountFileUpload" HeaderText="Số ebook upload" ReadOnly="true">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CountPage" HeaderText="Số trang Ebook Upload" ReadOnly="true">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CountEbookView" HeaderText="Số lượt xem Ebook" ReadOnly="true">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CountPatronDownloads" HeaderText="Lượt bạn đọc download" ReadOnly="true">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CountDownloads" HeaderText="Lượt tài liệu download" ReadOnly="true">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CountDissertation" HeaderText="Số file tạp chí" ReadOnly="true">
                            <HeaderStyle Width="8%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CountMagazinePages" HeaderText="Số trang tạp chí" ReadOnly="true">
                            <HeaderStyle Width="8%" />
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
