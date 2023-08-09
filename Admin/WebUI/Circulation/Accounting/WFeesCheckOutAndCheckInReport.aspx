<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WFeesCheckOutAndCheckInReport" CodeFile="WFeesCheckOutAndCheckInReport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Báo cáo tổng hợp</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <style>
        .lbGridHeader {
            font-weight: bold;
            text-align: center;
        }
      
            @page 
            {
                size: auto;   /* auto is the initial value */
                margin: 7mm;  /* this affects the margin in the printer settings */
            }
            @media print {
                html, body {
                    height: 99%;    
                }
            }
        .colRight{
            padding-left:120px;
        }
        .textCenter {
            vertical-align:middle;          
        }
        .textRight{
            text-align:right;
            font-weight:bold;
        }
      
        .lbAmount {
            text-align:center;
            font-weight:bold;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr align="center" class="">
                <td align="center" class="">
                    <asp:Label runat="server" CssClass="main-group-form">BÁO CÁO CÁC KHOẢN THU CHI MƯỢN TRẢ SÁCH</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align:center">
                    <asp:Label runat="server"> Từ ngày: </asp:Label>
                    <asp:TextBox runat="server" ID="txtFromDate" CssClass="input-form"></asp:TextBox><asp:HyperLink ID="lnkFromDate" runat="server" NavigateUrl="#">Lịch</asp:HyperLink>
                    <asp:Label runat="server" CssClass="colRight"> Đến ngày:</asp:Label>
                    <asp:TextBox runat="server" ID="txtToDate" CssClass="input-form"></asp:TextBox><asp:HyperLink ID="lnkToDate" runat="server" NavigateUrl="#">Lịch</asp:HyperLink>
                </td>
                <td>
            </tr>            
            <tr >
                <td style="text-align:center;padding-bottom:20px" >
                    <asp:Button ID="btnStatistic" runat="server" CssClass="lbButton" Text="Thống kê(s)" Width="" ></asp:Button>
                </td>
            </tr>
            <tr runat="server" id="TRNothing" >
                <td style="color:red;font-size:medium;font-weight:bold;text-align:center"> Không có dữ liệu.</td>
            </tr>
            <tr runat="server" id="TRbtnExport">
                <td Class="textRight" style="padding-bottom:5px">
                    <asp:Button ID="btnExport" runat="server" CssClass="lbButton" Text="Xuất file" Width="" ></asp:Button>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DataGrid ID="dtgResultCurrentCheckIn" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell"
                        AutoGenerateColumns="False" PageSize="20" AllowPaging="true">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="STT" DataField="STT" HeaderStyle-Width="5%"></asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Số Thẻ" DataField="PatronCode" HeaderStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="ÐKCB" DataField="CopyNumber" HeaderStyle-Width="10%"></asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Ngày mượn" DataField="CheckOutDate" HeaderStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Ngày trả" DataField="CheckInDate" HeaderStyle-Width="15%"></asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Phí mượn" DataField="Fees" HeaderStyle-Width="15%" DataFormatString="{0:###,###}"></asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Phí phạt quá hạn" DataField="OverdueFine" HeaderStyle-Width="15%" DataFormatString="{0:###,###}"></asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Tiền cọc" DataField="LoanDepositFee" HeaderStyle-Width="15%" DataFormatString="{0:###,###}"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                </td>
            </tr>
            <tr runat="server" id="TRSumary" align="right" class="">
                <td  align="right" class="">
                    <asp:Label ID="lblSumaryTemp" runat="server" CssClass="textRight">Tổng:</asp:Label>
                    <asp:Label ID="lblSumaryFees" runat="server" CssClass="lbAmount" Width="15%"></asp:Label>     
                    <asp:Label ID="lblSumaryOverdueFine" runat="server" CssClass="lbAmount" Width="15%"></asp:Label> 
                    <asp:Label ID="lblSumaryLoanDepositFee" runat="server" CssClass="lbAmount" Width="15%" Height="19px"></asp:Label> 
                </td>
            </tr>
            <tr runat="server" id="TRRealCollection">
                <td align="right" style="padding-right: 7px" >
                    <asp:Label  runat="server" CssClass="textRight">Thực Thu:</asp:Label>
                    <asp:Label ID="lblRealCollection" runat="server" CssClass="lbAmount" Width="15%"></asp:Label> 
                    <asp:Label  runat="server" CssClass="lbAmount" Width="30%">&nbsp</asp:Label> 
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
                        <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
                        <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
                        <asp:ListItem Value="2">Số thẻ</asp:ListItem>
                        <asp:ListItem Value="3">Tháng</asp:ListItem>
                        <asp:ListItem Value="4">tháng</asp:ListItem>
                        <asp:ListItem Value="5">Năm</asp:ListItem>
                        <asp:ListItem Value="6">năm</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlHeaderLabel" runat="server" Visible="False" Height="0" Width="0">
                        <asp:ListItem Value="0">STT</asp:ListItem>
                        <asp:ListItem Value="1">Số Thẻ</asp:ListItem>
                        <asp:ListItem Value="2">ÐKCB</asp:ListItem>
                        <asp:ListItem Value="3">Ngày mượn</asp:ListItem>
                        <asp:ListItem Value="4">Ngày trả</asp:ListItem>
                        <asp:ListItem Value="5">Phí mượn</asp:ListItem>
                        <asp:ListItem Value="6">Phí phạt quá hạn</asp:ListItem>
                        <asp:ListItem Value="7">Tiền cọc</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </form>
   <%-- <script language="JavaScript">
		<!--
    self.focus();
    setTimeout('self.print()', 1);
    //-->
    </script>--%>
</body>
</html>
