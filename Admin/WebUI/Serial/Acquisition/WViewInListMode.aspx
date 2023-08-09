<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WViewInListMode"
    CodeFile="WViewInListMode.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WViewInListMode</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <style>
        #divBody .tab
        {
            display: inline;
            text-align: right;
        }
        #divBody .tab ul
        {
            padding-top: 5px;
        }
        #divBody .tab ul li
        {
            background: #4182C4 none repeat scroll 0 0;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
        }
        li
        {
            list-style: outside none none;
        }
        
        #divBody .tab ul li a
        {
            color: #fff;
        }
        
        
        .main-head-form
        {
            color: #4182C4;
            font-family: headfont;
            font-size: 250% !important;
            font-weight: normal !important;
        }
        
        .lbButton
        {
            background: #4182C4 none repeat scroll 0 0;
            border: medium none;
            color: white;
            cursor: pointer;
            padding: 8px;
        }
        #divBody .tab ul li.active
        {
            background-color: #1F61A3;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
        }
        .lbGridHeader {
    background: #CCCCCC none repeat scroll 0 0;
    text-align: center;
            color: #2061AB;
}
    </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div class="tab">
            <ul>
                <li>
                    <asp:HyperLink ID="lnkHdAcquire" runat="server" NavigateUrl="WAcquire.aspx">Bổ sung</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdSetRegularity" runat="server" NavigateUrl="WSetRegularity.aspx">Định kỳ</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdRegister" runat="server" NavigateUrl="WCreateIssue.aspx">Đăng ký</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdReceive" runat="server" NavigateUrl="WReceive.aspx">Ghi nhận</asp:HyperLink></li>
                <li class="active">
                    <asp:Label ID="lblHdView" runat="server" CssClass="lbGroupTitle">Kiểm tra</asp:Label></li>
                <li>
                    <asp:HyperLink ID="lnkHdBinding" runat="server" NavigateUrl="WBinding.aspx">Đóng tập</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdSummary" runat="server" NavigateUrl="WSummaryHoldingManagement.aspx">Tổng hợp</asp:HyperLink></li>
            </ul>
        </div>
        <table id="Table2" cellspacing="0" cellpadding="2" width="100%" border="0">
        </table>
        <table cellspacing="0" cellpadding="2" width="100%">
            <tr>
                <td align="left" colspan="2">
                    <asp:Label ID="lblTitle" runat="server" CssClass="main-head-form"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td class="lbControlBar" align="center" colspan="2">
                    <asp:LinkButton ID="lnkPrevious" runat="server"><<</asp:LinkButton>&nbsp;
                    <asp:Label ID="lblYear" runat="server" Font-Size="16" Font-Bold="True"></asp:Label>&nbsp;
                    <asp:LinkButton ID="lnkNext" runat="server">>></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="right" width="20%">
                    <asp:Label ID="lblHaving" runat="server">Các số có:</asp:Label>
                </td>
                <td width="80%">
                    <asp:Label ID="lblHavingIssue" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblNotHaving" runat="server">Các số thiếu:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLostIssue" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="lbControlBar" align="center" colspan="2">
                    <asp:Button ID="btnUpdateAcq" runat="server" Text="Cập nhật số liệu bổ sung tổng hợp (s)">
                    </asp:Button>
                </td>
            </tr>
        </table>
        <table cellspacing="1" cellpadding="1" width="100%">
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr class="lbSubFormTitle">
                <td width="30%">
                    &nbsp;&nbsp;
                    <asp:HyperLink ID="lnkCalendaView" runat="server">Hiển thị kiểu lịch</asp:HyperLink>
                </td>
                <td width="30%">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblListView" runat="server" CssClass="lbSubFormTitle">Hiển thị kiểu danh sách</asp:Label>
                </td>
                <td align="right" width="50%">
                    <asp:Label ID="lblHoldAddress" runat="server" CssClass="lbSubFormTitle">Địa chỉ lưu trữ:</asp:Label>&nbsp;
                    <asp:DropDownList ID="ddlHoldAddress" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td>
                    <div class="table-form">
                        <asp:DataGrid ID="dtgResult" runat="server" Width="100%" PageSize="15" AllowPaging="True"
                            AutoGenerateColumns="False">
                            <AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
                            <ItemStyle CssClass="lbGridCell"></ItemStyle>
                            <HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
                            <EditItemStyle CssClass="lbGridEdit"></EditItemStyle>
                            <PagerStyle CssClass="lbGridPager"></PagerStyle>
                            <Columns>
                                <asp:TemplateColumn HeaderText="Số">
                                    <HeaderStyle Width="9%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="lnkIssueNum" CssClass="lbLinkFunction">
											<%#DataBinder.Eval(Container.dataItem,"IssueNo")%>
											<%#" (" & DataBinder.Eval(Container.dataItem,"OvIssueNo") & ")"%>
                                        </asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="VolumeByPublisher" HeaderText="Tập (NXB)">
                                    <HeaderStyle Width="7%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="VolumeByLibrary" HeaderText="Tập (TV)">
                                    <HeaderStyle Width="7%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Series" HeaderText="Series">
                                    <HeaderStyle Width="7%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SpecialTitle" HeaderText="Tên số ĐB">
                                    <HeaderStyle Width="15%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="PhysDetail" HeaderText="Đặc trưng số lượng">
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Số bản">
                                    <HeaderStyle Width="4%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="right"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="lnkCopyNum" Visible="False">
											<%#DataBinder.Eval(Container.dataItem,"ReceivedCopies")%>
                                        </asp:HyperLink>
                                        <asp:Label runat="server" ID="lblCopyNum" Visible="False">
											<%#DataBinder.Eval(Container.dataItem,"ReceivedCopies")%>
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="Price" HeaderText="Đơn giá">
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="right"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IssuedDate" HeaderText="Ngày phát hành">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Note" HeaderText="Ghi chú">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>
                    </div>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td width="40%">
                            </td>
                            <td align="right">
                                &nbsp;&nbsp;
                                <asp:HyperLink ID="lnkShowMoney" runat="server" NavigateUrl="#">Thông tin chi phí</asp:HyperLink>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTime" runat="server">Hôm nay là:</asp:Label>&nbsp;
                    <asp:Label ID="lblCurrentDate" runat="server"></asp:Label>
                </td>
            </tr>
            <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False" Height="0">
                <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
                <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
                <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
                <asp:ListItem Value="3">----- Chọn kho: -----</asp:ListItem>
                <asp:ListItem Value="4">T</asp:ListItem>
                <asp:ListItem Value="5">Đang lấy dữ liệu, xin vui lòng chờ trong giây lát !</asp:ListItem>
                <asp:ListItem Value="6">Không tập</asp:ListItem>
                <asp:ListItem Value="7">Tất cả các số</asp:ListItem>
            </asp:DropDownList>
        </table>
    </div>
    <input type="hidden" id="hidNext" value="0" name="hidNext" runat="server" />
    <input type="hidden" id="hidPrevious" value="0" name="hidPrevious" runat="server" />
    </form>
</body>
</html>
