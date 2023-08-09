<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WPrintCheckInResult.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WPrintCheckInResult" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title></title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE"/>
    <meta content="JavaScript" name="vs_defaultClientScript"/>
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/magnific/magnific-popup.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/magnific/jquery.magnific-popup.min.js"></script>
    <style type="text/css">
        div.table
        {
            width:100%;
            text-align:center;
        }
        div.table table
        {
            margin:0 auto;
        }
        .text-color
        {
            /*text-align:center;*/
            color: rgb(31, 97, 163) !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-body">
            <div class="group-row">
                <div class="table">
                    <table border="0" style="width:100%;">
                        <tr>
                            <td><h1 class="main-head-form text-color">Phiếu ghi trả bạn đọc</h1></td>
                            <td style="text-align:right;"><input id="btnPrintCheckInLibrary" type="button" value="In phiếu" class="form-btn" onclick="HiddenButtonPrintMagnific(); parent.PrintMagnific();" /></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="group-row">
                <div class="table">
                    <table border="0" cellspacing="0" cellpadding="5">
                        <tr>
                            <td style="text-align:right">
                                <p><asp:Label ID="lbPatronInfolb" runat="server" Text="Tên (số thẻ): "></asp:Label></p>
                            </td>
                            <td style="text-align:left">
                                <p><asp:Label ID="lbPatronInfo" runat="server" Text=""></asp:Label></p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:center">
                                <asp:DataGrid ID="dtgResultCurrentCheckIn" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell"
                                    AutoGenerateColumns="False" Height="137px">
                                    <Columns>
                                        <asp:BoundColumn HeaderText="STT" DataField="STT" HeaderStyle-Width="4%"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Nhan đề" DataField="TITLE"></asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="ÐKCB" DataField="CopyNumber" HeaderStyle-Width="12%"></asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Ngày mượn" DataField="CheckOutDate" HeaderStyle-Width="10%"></asp:BoundColumn>
                                        <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Ngày trả" DataField="CheckInDate" HeaderStyle-Width="10%"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Phí mượn" DataField="Fees" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="100px" DataFormatString="{0:###,###}"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Phí phạt quá hạn" DataField="OverdueFine" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="100px" DataFormatString="{0:###,###}"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Tiền cọc" DataField="LoanDepositFee" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="100px"  DataFormatString="{0:###,###}"></asp:BoundColumn>
                                    </Columns>
                                </asp:DataGrid>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <table id="tblFeeInfo" runat="server" class="lbGrid" cellspacing="0" rules="all" border="1" style="width:100%;border-collapse:collapse;">
	                                <tbody >
                                        <tr class="lbGridHeader">
                                            <td>&nbsp;</td>
                                            <td align="center" style="width:100px;">Phí mượn</td>
                                            <td align="center" style="width:100px;">Phí phạt quá hạn</td>
                                            <td align="center" style="width:100px;">Tiền cọc</td>
                                
                                        </tr>
		                                <tr class="lbGridCell">
			                                <td style="font-weight:bold">Tổng cộng</td>
                                            <td align="right"><% =strTotalFees %></td>
                                            <td align="right"><% =strTotalOverdueFine %></td>
                                            <td align="right"><% =strTotalLoanDepositFee %></td>
                                  
	                                    </tr>
                                        <tr class="lbGridCell">
                                            <td class="auto-style2" style="font-weight:bold">Còn lại</td>
                                            <td colspan="3" align="right" class="auto-style2"><% =strTotal %></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function HiddenButtonPrintMagnific()
            {
                document.getElementById("btnPrintCheckInLibrary").style = "display:none;";
                window.print();
            }
        </script>
    </form>
</body>
</html>
