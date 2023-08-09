<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatPatronGrp" CodeFile="WStatPatronGrp.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatPatronGrp</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="GenURL(7)" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0" bgcolor="#ffffff">
				<tr>
					<td width="100%"><asp:Label ID="lblNotFound" Runat="server" Width="100%" CssClass="lbPageTitle" Visible="False">Không tìm thấy dữ liệu.</asp:Label></td>
				</tr>
				<tr class="lbPageTitle">
					<td><asp:label id="lblGroup" Runat="server" Width="100%" CssClass="main-head-form">Thống kê theo nhóm bạn đọc</asp:label></td>
				</tr>
                <tr>
                    <%--<td align="right" >
                        <asp:Label ID="lblPatronGroup" runat="server">Chọn nhóm bạn đọc: </asp:Label>
                    </td>
                    <td align="right">
                        <asp:DropDownList name="ddlPatronGroup" ID="ddlPatronGroup" Width="150px" runat="server"></asp:DropDownList>
                    </td>--%>
                    <td align="right">
                        <label>Nhóm bạn đọc:</label>
                        <asp:DropDownList runat="server" ID="ddlPatronGroup" ></asp:DropDownList>
                        <asp:button CssClass="lbButton" id="btnStatic" Runat="server" Width="88px" Text="Thống kê(b)"></asp:button>
                        <asp:Button CssClass="lbButton" ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td style="width:40%;display:none">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <TR align="center" valign="top">
				                            <TD align="center"><img alt="" src="." border="0" name="anh1" id="anh1" runat="server"/></TD>
				                        </TR>
				                        <TR align="center" valign="top">
					                        <TD align="center"><img alt="" src="." border="0" name="anh2" id="anh2" runat="server"></TD>
				                        </TR>
                                    </table>
                                </td>
                                <td style="width:60%;">
                                    <div>
                                        <p><b>Tổng số: </b><asp:Label runat="server" ID="lblTotal"></asp:Label></p>
                                    </div>
                                    <div class="row-detail">
                                        <asp:GridView ID="dtgResult" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                            <Columns>
                                                <asp:BoundField HeaderText="STT" ItemStyle-HorizontalAlign="Center" DataField="STT" HeaderStyle-Width="5%"/>
                                                <asp:BoundField HeaderText="Họ và tên lót" ItemStyle-HorizontalAlign="Center" DataField="FirstName"/>
                                                <asp:BoundField HeaderText="Tên" ItemStyle-HorizontalAlign="Center" DataField="LastName"/>
                                                <asp:BoundField HeaderText="Mã số thẻ" ItemStyle-HorizontalAlign="Center" DataField="PatronCode"/>
                                                <asp:BoundField HeaderText="Ngày cấp thẻ" ItemStyle-HorizontalAlign="Center" DataField="LastIssuedDate" DataFormatString="{0:dd/MM/yyyy}" Visible="false"/>
                                                <asp:BoundField HeaderText="Ngày hết hạn" ItemStyle-HorizontalAlign="Center" DataField="ExpiredDate" DataFormatString="{0:dd/MM/yyyy}"/>
                                                <asp:BoundField HeaderText="Lớp" ItemStyle-HorizontalAlign="Center" DataField="Class" Visible="false"/>
                                                <asp:BoundField HeaderText="Khóa" ItemStyle-HorizontalAlign="Center" DataField="Grade" Visible="false"/>
                                                <asp:BoundField HeaderText="Đơn vị" ItemStyle-HorizontalAlign="Center" DataField="Faculty"/>
                                                <asp:BoundField HeaderText="Trường" ItemStyle-HorizontalAlign="Center" DataField="College"/>
                                                <asp:BoundField HeaderText="Nhóm bạn đọc" ItemStyle-HorizontalAlign="Center" DataField="GroupName"/>
                                                <asp:BoundField HeaderText="Số điện thoại" ItemStyle-HorizontalAlign="Center" DataField="Mobile"/>
                                                <asp:BoundField HeaderText="Email" ItemStyle-HorizontalAlign="Center" DataField="Email" />
                                                <asp:BoundField HeaderText="Địa chỉ" ItemStyle-HorizontalAlign="Center" DataField="Address" Visible="false"/>
                                                <asp:BoundField HeaderText="Tỉnh/Thành phố" ItemStyle-HorizontalAlign="Center" DataField="City" Visible="false"/>
                                                <asp:BoundField HeaderText="Ghi chú" ItemStyle-HorizontalAlign="Center" DataField="Note"/>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>				
			</TABLE>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
				<asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
				<asp:ListItem Value="3">Nhóm bạn đọc</asp:ListItem>
				<asp:ListItem Value="4">Số lượng bạn đọc</asp:ListItem>
				<asp:ListItem Value="5">Tỉ lệ % theo nhóm bạn đọc</asp:ListItem>
				<asp:ListItem Value="6">Không rõ</asp:ListItem>
				<asp:ListItem Value="7">Thống kê nhóm bạn đọc</asp:ListItem>
			    <asp:ListItem Value="8">Tất cả</asp:ListItem>
			</asp:DropDownList>
            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">Họ và tên lót</asp:ListItem>
                <asp:ListItem Value="2">Tên</asp:ListItem>
                <asp:ListItem Value="3">Mã số thẻ</asp:ListItem>
                <asp:ListItem Value="4">Ngày cấp thẻ</asp:ListItem>
                <asp:ListItem Value="5">Ngày hết hạn</asp:ListItem>
                <asp:ListItem Value="6">Lớp</asp:ListItem>
                <asp:ListItem Value="7">Khóa</asp:ListItem>
                <asp:ListItem Value="8">Đơn vị</asp:ListItem>
                <asp:ListItem Value="9">Trường</asp:ListItem>
                <asp:ListItem Value="10">Nhóm bạn đọc</asp:ListItem>
                <asp:ListItem Value="11">Số điện thoại</asp:ListItem>
                <asp:ListItem Value="12">Email</asp:ListItem>
                <asp:ListItem Value="13">Địa chỉ</asp:ListItem>
                <asp:ListItem Value="14">Tỉnh/Thành phố</asp:ListItem>
                <asp:ListItem Value="15">Ghi chú</asp:ListItem>
            </asp:DropDownList>
		    <div style="display:none">
		        <input name="hidMessageBook" runat="server" type="hidden" id="hidMessageBook" value="Tổng số: " />
		        <input name="hidLeftTable" runat="server" type="hidden" id="hidLeftTable" value="ĐẠI HỌC GIAO THÔNG - VẬN TẢI<BR/>TP.HỒ CHÍ MINH" />
		        <input name="hidRightTable" runat="server" type="hidden" id="hidRightTable" value="CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM<BR/>Độc lập - Tự do - Hạnh phúc" />
		        <input name="hidTitleTable" runat="server" type="hidden" id="hidTitleTable" value="THỐNG KÊ THEO NHÓM BẠN ĐỌC" />
		        <input name="hidMessageCopyNumber" runat="server" type="hidden" id="hidMessageCopyNumber" value="" />
		    </div>
		</form>
	</body>
</HTML>
