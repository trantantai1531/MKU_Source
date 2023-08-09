<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatisticLoanHistoryCopyNumber.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WStatisticLoanHistoryCopyNumber" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 transitional//EN">
<HTML>
	<HEAD>
		<title>WStatisticLoanHistoryCopyNumber</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" src="../Js/Statistic/WStatistic.js"></script>
        <script type="text/javascript">
            function myFunction() {
                setTimeout(
                    function () {
                        GenURLImg1(9);
                    }, 100);
            }
            window.onload = myFunction();
        </script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			 <div id="divBody">
        	<h1 class="main-head-form">Thống kê số lần mượn bản ấn phẩm</h1>
            <div class="main-form ClearFix">
                <div class="row-detail">
                    <table width="100%" border="0">
				        <tr>
                            <td>
                                <p>Từ ngày :<asp:hyperlink id="lnkCheckOutDateFrom" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                 <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input"  id="txtCheckOutDateFrom" Width="" Runat="server"></asp:textbox>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <p>Tới ngày : <asp:hyperlink id="lnkCheckOutDateTo" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                 <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input"  id="txtCheckOutDateTo" Width="100px" Runat="server"></asp:textbox>
                                    </div>
                                </div>
                            </td>
					        <td align="left">
                                <p>&nbsp</p>
                                <div class="button-control" style="text-align:right">
                                    <div class="button-form">
                                        <asp:button id="btnStatic" Width="" Runat="server" Text="Thống kê(t)"></asp:button>
                                    </div>
                                    <div class="button-form">
                                        <asp:button id="btnCancel" Width="" Runat="server" Text="Đặt lại(l)"></asp:button>
                                    </div>
                                    <div class="button-form">
                                        <asp:Button ID="btnExport" runat="server" Text="Xuất file(t)" Width="" CssClass=""></asp:Button>
                                    </div>
                                </div>
					        </td>
				        </tr>
			        </table>
                </div>
                <div class="ClearFix"></div>
                <div class="row-detail">
                    <asp:GridView ID="dtgResult" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                        <Columns>
                            <asp:BoundField HeaderText="STT" ItemStyle-HorizontalAlign="Center" DataField="STT" HeaderStyle-Width="5%"/>
                            <asp:BoundField HeaderText="ĐKCB" ItemStyle-HorizontalAlign="Center" DataField="CopyNumber"/>
                            <asp:BoundField HeaderText="Số thẻ" ItemStyle-HorizontalAlign="Center" DataField="PatronCode"/>
                            <asp:BoundField HeaderText="Ngày mượn" ItemStyle-HorizontalAlign="Center" DataField="CheckOutDate" DataFormatString="{0:dd/MM/yyyy}"/>
                            <asp:BoundField HeaderText="Ngày trả" ItemStyle-HorizontalAlign="Center" DataField="CheckInDate" DataFormatString="{0:dd/MM/yyyy}"/>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="row-detail">
                    <p>&nbsp;</p>
                    <img alt="" id="Image1" src="." border="0" name="Image1" runat="server"/>
                    <asp:Label ID="lblNostatic" runat="server">Không có thông tin thống kê !</asp:Label>
                </div>
                <div class="row-detail">
                    <p>&nbsp;</p>
                    <img alt="" id="Image2" src="." border="0" name="Image2" runat="server"/>
                    <asp:Label ID="lblNostatic1" runat="server">Không có thông tin thống kê !</asp:Label>
                </div>
            </div>
        </div>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi: </asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
				<asp:ListItem Value="3">Dữ liệu phải là kiểu số nguyên</asp:ListItem>
				<asp:ListItem Value="4">Top 20 mã biểu ghi có số lượt mượn cao nhất theo số lượng</asp:ListItem>
				<asp:ListItem Value="5">Top 20 mã biểu ghi có số lượt mượn cao nhất theo tỉ lệ</asp:ListItem>
				<asp:ListItem Value="6">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
			</asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">ĐKCB</asp:ListItem>
                <asp:ListItem Value="2">Số thẻ</asp:ListItem>
                <asp:ListItem Value="3">Ngày mượn</asp:ListItem>
                <asp:ListItem Value="4">Ngày trả</asp:ListItem>
            </asp:DropDownList>
        	<asp:Label runat="server" Visible="false" ID="lblTitle">Thống kê số lần mượn bản ấn phẩm</asp:Label>
		    <input id="hidHave" runat="server" type="hidden" value="1" NAME="hidHave"/>
		</form>
		<script language = javascript>
		    document.forms[0].txtCheckOutDateFrom.focus();
		</script>
	</body>
</HTML>
