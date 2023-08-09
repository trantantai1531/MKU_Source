<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatCopyNumberAcquiredSource.aspx.vb" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatCopyNumberAcquiredSource" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 transitional//EN">
<HTML>
	<HEAD>
		<title>WStatCopyNumberAcquiredSource</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
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
	<body bgColor="white" leftMargin="0" topMargin="0" onload="GenURLImg(9);" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			 <div id="divBody">
        	<h1 class="main-head-form">Thống kê số bản ấn phẩm theo nguồn bổ sung</h1>
            <div class="main-form ClearFix">
                <div class="row-detail">
                    <table width="100%" border="0">
				        <tr>
                            <td>
                                <p>Từ ngày :<asp:hyperlink id="lnkAcquiredDateFrom" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                 <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input"  id="txtAcquiredDateFrom" Width="" Runat="server"></asp:textbox>
                                    </div>
                                </div>
                            </td>
                            <td>
                                <p>Tới ngày : <asp:hyperlink id="lnkAcquiredDateTo" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                 <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input"  id="txtAcquiredDateTo" Width="100px" Runat="server"></asp:textbox>
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
                                <IMG src="/" alt="" useMap="#map1" border="0" name="Image1">
                                <IMG src="/" alt="" border="0" name="Image2">

                            </div>
                            <div class="row-detail">
                                <p>&nbsp;</p>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail">
                                <asp:GridView ID="dtgResult" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                    <Columns>
                                        <asp:BoundField HeaderText="STT" ItemStyle-HorizontalAlign="Center" DataField="STT" HeaderStyle-Width="5%"/>
                                        <asp:BoundField HeaderText="Nguồn bổ sung" ItemStyle-HorizontalAlign="Center" DataField="Source"/>
                                        <asp:BoundField HeaderText="ĐKCB" ItemStyle-HorizontalAlign="Center" DataField="CopyNumber"/>
                                        <asp:BoundField HeaderText="Nhan đề" ItemStyle-HorizontalAlign="Center" DataField="Content"/>
                                        <asp:BoundField HeaderText="Tác giả" ItemStyle-HorizontalAlign="Center" DataField="Author"/>
                                        <asp:BoundField HeaderText="Nhà XB" ItemStyle-HorizontalAlign="Center" DataField="Publisher"/>
                                        <asp:BoundField HeaderText="Năm XB" ItemStyle-HorizontalAlign="Center" DataField="PublishYear"/>
                                        <asp:BoundField HeaderText="Ghi chú" ItemStyle-HorizontalAlign="Center" DataField="Note"/>
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
                <asp:ListItem Value="1">Nguồn bổ sung</asp:ListItem>
                <asp:ListItem Value="2">ĐKCB</asp:ListItem>
                <asp:ListItem Value="3">Nhan đề</asp:ListItem>
                <asp:ListItem Value="4">Tác giả</asp:ListItem>
                <asp:ListItem Value="5">Nhà XB</asp:ListItem>
                <asp:ListItem Value="6">Năm XB</asp:ListItem>
                <asp:ListItem Value="7">Ghi chú</asp:ListItem>
            </asp:DropDownList>
        	<asp:Label runat="server" Visible="false" ID="lblTitle">Thống kê số bản ấn phẩm theo nguồn bổ sung</asp:Label>
		    <input id="hidHave" runat="server" type="hidden" value="1" NAME="hidHave"/>
		</form>
		<script language="javascript" type="text/javascript">
		    document.forms[0].txtAcquiredDateFrom.focus();
		</script>
	</body>
</HTML>