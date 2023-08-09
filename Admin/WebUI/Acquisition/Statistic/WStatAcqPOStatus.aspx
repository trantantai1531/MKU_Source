<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatAcqPOStatus.aspx.vb" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatAcqPOStatus" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 transitional//EN">
<HTML>
	<HEAD>
		<title>WStatCopyNumberAcquiredSource</title>
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
	<body leftMargin="0" topMargin="0" onload="GenURLImg1(9)" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			 <div id="divBody">
        	<h1 class="main-head-form">Thống kê trạng thái đơn đặt</h1>
            <div class="main-form ClearFix">
                <div class="row-detail">
                    <table width="100%" border="0">
				        <tr>
                            <td>
                                <p>Từ ngày :<asp:hyperlink id="lnkDateSetFrom" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                 <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input"  id="txtDateSetFrom" Width="" Runat="server"></asp:textbox>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <p>Tới ngày : <asp:hyperlink id="lnkDateSetTo" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                 <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input"  id="txtDateSetTo" Width="100px" Runat="server"></asp:textbox>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <p>Nguồn bổ sung</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:dropdownlist id="ddlAcqSource" runat="server"></asp:dropdownlist>
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
                    <div class="two-column">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>&nbsp;</p>
                                <img id="image1" src="." alt="" border="0" name="Image1" runat="server"/>
                                <asp:Label ID="lblNostatic" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                            <div class="row-detail">
                                <p>&nbsp;</p>
                                <img id="image2" src="." alt="" border="0" name="Image2" runat="server"/>
                                <asp:Label ID="lblNostatic1" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail">
                                <asp:GridView ID="dtgResult" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                    <Columns>
                                        <asp:BoundField HeaderText="STT" ItemStyle-HorizontalAlign="Center" DataField="STT" HeaderStyle-Width="5%"/>
                                        <asp:BoundField HeaderText="Đơn đặt" ItemStyle-HorizontalAlign="Center" DataField="POName"/>
                                        <asp:BoundField HeaderText="Trạng thái" ItemStyle-HorizontalAlign="Center" DataField="Status"/>
                                        <asp:BoundField HeaderText="Nguồn bổ sung" ItemStyle-HorizontalAlign="Center" DataField="Source"/>
                                        <asp:BoundField HeaderText="Ngày cập nhật" ItemStyle-HorizontalAlign="Center" DataField="SetDate" DataFormatString="{0:dd/MM/yyyy}"/>
                                        <asp:BoundField HeaderText="Ghi chú" ItemStyle-HorizontalAlign="Center" DataField="Note"/>
                                        <asp:BoundField HeaderText="Ngày kết thúc" ItemStyle-HorizontalAlign="Center" DataField="FilledDate" DataFormatString="{0:dd/MM/yyyy}"/>
                                    </Columns>
                                </asp:GridView>
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
				<asp:ListItem Value="4">Mã biểu ghi</asp:ListItem>
				<asp:ListItem Value="5">Số lượt mượn</asp:ListItem>
				<asp:ListItem Value="6">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
			</asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">Đơn đặt</asp:ListItem>
                <asp:ListItem Value="2">Trạng thái</asp:ListItem>
                <asp:ListItem Value="3">Ngày cập nhật</asp:ListItem>
                <asp:ListItem Value="4">Ghi chú</asp:ListItem>
                <asp:ListItem Value="5">Ngày kết thúc</asp:ListItem>
            </asp:DropDownList>
        	<asp:Label runat="server" Visible="false" ID="lblTitle">Thống kê trạng thái đơn đặt</asp:Label>
		    <input id="hidHave" runat="server" type="hidden" value="0" NAME="hidHave"/>
		</form>
		<script language="javascript" type="text/javascript">
		    document.forms[0].txtDateSetFrom.focus();
		</script>
	</body>
</HTML>