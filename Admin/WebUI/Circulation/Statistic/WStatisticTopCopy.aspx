<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WStatisticTopCopy" CodeFile="WStatisticTopCopy.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 transitional//EN">
<HTML>
	<HEAD>
		<title>WStatisticTopCopy</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
        <script src="../Js/Statistic/WStatistic.js"></script>
        <script type="text/javascript">
            function myFunction() {
                setTimeout(
                    function () {
                        GenURLImg1(9);
                    }, 1000);
            }
            window.onload = myFunction();
        </script>
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="GenURLImg1(9)"
		rightMargin="0">
		<form id="Form1" method="post" runat="server">
			 <div id="divBody">
        	<h1 class="main-head-form">Thống kê ấn phẩm có tần suất mượn cao nhất</h1>
            <div class="main-form ClearFix">
                <div class="span8">
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
                            <td>
                                <p>Lọc ra :</p>
                                 <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input"  id="txtTopNum" Width="" Runat="server">20</asp:textbox>
                                    </div>
                                </div>
                            </td>
                            <td style="width:320px">
                                <p>Ấn phẩm dẫn đầu với tối thiểu (lượt mượn):</p>
                                 <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input"  id="txtMin" Width="" Runat="server">1</asp:textbox>
                                    </div>
                                </div>
                            </td>
					        <td align="left" style="width:320px">
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
                 <div class="span8">
                    <div class="two-column">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Biểu đồ hình cột</p>
                              <img id="image1" src="" border="0" name="Image1" runat="server"/>
                                <asp:Label ID="lblNostatic" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                            <div class="row-detail">
                                <p>Biểu đồ hình tròn</p>
                               <img id="image2" src="" border="0" name="Image2" runat="server"/>
                                <asp:Label ID="lblNostatic1" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                        </div>
                      
                    </div>
                </div>
            </div>
        </div>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi: </asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
				<asp:ListItem Value="3">Dữ liệu phải là kiểu số nguyên</asp:ListItem>
				<asp:ListItem Value="4">Số ĐKCB</asp:ListItem>
				<asp:ListItem Value="5">Số lượt mượn</asp:ListItem>
				<asp:ListItem Value="6">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
			</asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
		        <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">Số ĐKCB</asp:ListItem>
                <asp:ListItem Value="2">Số môn loại</asp:ListItem>
                <asp:ListItem Value="3">Nhan đề</asp:ListItem>
                <asp:ListItem Value="4">Tác giả</asp:ListItem>
                <asp:ListItem Value="5">Nhà xuất bản</asp:ListItem>
                <asp:ListItem Value="6">Năm xuất bản</asp:ListItem>
                <asp:ListItem Value="7">Số lượt</asp:ListItem>
                <asp:ListItem Value="8">Kho</asp:ListItem>
                <asp:ListItem Value="9">Ghi chú</asp:ListItem>
		    </asp:DropDownList>
        	<asp:Label runat="server" Visible="false" ID="lblTitle">Thống kê ấn phẩm có tần suất mượn cao nhất</asp:Label>
		    <input id="hidHave" runat="server" type="hidden" value="0" NAME="hidHave"/>
		</form>
		<script language = javascript>
			document.forms[0].txtCheckOutDateFrom.focus();
		</script>
	</body>
</HTML>
