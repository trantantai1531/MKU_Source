<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WPatronReport" CodeFile="WPatronReport.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WPatronReport</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link type="text/javascript" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="GenURLImg(9);">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr class="lbPageTitle">
					<td align="center" class="lbPageTitle"><asp:label id="lblTitle" Runat="server" CssClass="main-head-form">Thống kê số lượng bạn đọc vào phòng đọc theo các ngày trong tháng</asp:label></td>
				</tr>
			</table>
			<p></p>
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td align="right" width="40%"><asp:label id="lblCreatedDate" runat="server"><U>P</U>hòng mượn: </asp:label>&nbsp;</td>
					<td align="left"><asp:dropdownlist id="ddlLocation" Runat="server" Width="200px"></asp:dropdownlist></td>
				</tr>
                <tr>
                    <td width="40%" align="right">
                        <asp:Label ID="lblFromDate" runat="server"><U>B</U>ắt đầu từ ngày: </asp:Label>&nbsp;</td>
                    <td align="left">
                        <asp:TextBox ID="txtFromDate" runat="server" Width="90px"></asp:TextBox>&nbsp;<asp:HyperLink ID="lnkFromDate" runat="server" NavigateUrl="#">Lịch</asp:HyperLink>
                        &nbsp;<asp:Label ID="lblToDate" runat="server">đến <u>n</u>gày: </asp:Label>&nbsp;<asp:TextBox ID="txtToDate" runat="server" Width="90px"></asp:TextBox>&nbsp;<asp:HyperLink ID="lnkToDate" runat="server" NavigateUrl="#">Lịch</asp:HyperLink>
                    </td>
                </tr>
	<%--			<tr>
					<td align="right" width="40%"><asp:label id="lblMonth" Runat="server"><U>T</U>háng: </asp:label>&nbsp;</td>
					<td align="left">
                        <asp:textbox id="txtMonth" Runat="server" Width="50px"></asp:textbox>&nbsp;
                        <asp:label id="lblYear" Runat="server"><U>N</U>ăm: </asp:label>&nbsp;
                        <asp:textbox id="txtYear" Runat="server" Width="50px"></asp:textbox>&nbsp;&nbsp;&nbsp;
                        <asp:button id="btnReport" Runat="server" Text="Thống kê (t)"></asp:button>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
					</td>
				</tr>--%>
                <tr>
                    <td width="40%" align="right" ></td>                 
                    <td align="left" style="HEIGHT: 18px">
                        <asp:button id="btnReport" Runat="server" Text="Thống kê (t)"></asp:button>&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
                    </td>
                </tr>
				<tr>
					<td colspan="2"></td>
				</tr>
            
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="dtgResult" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                            <Columns>
                                <asp:BoundField HeaderText="STT" ItemStyle-HorizontalAlign="Center" DataField="STT" HeaderStyle-Width="5%"/>
                                    <asp:BoundField HeaderText="Số thẻ" ItemStyle-HorizontalAlign="Center" DataField="PatronCode"/>
                                    <asp:BoundField HeaderText="Họ tên" ItemStyle-HorizontalAlign="Center" DataField="FullName"/>                            
                                    <asp:BoundField HeaderText="Ngày sinh" ItemStyle-HorizontalAlign="Center" DataField="Birthday" DataFormatString="{0:dd/MM/yyyy}"/>
                                    <asp:BoundField HeaderText="Tuổi" ItemStyle-HorizontalAlign="Center" DataField="YEARS" Visible="false" />
                                    <asp:BoundField HeaderText="Số điện thoại" ItemStyle-HorizontalAlign="Center" DataField="Mobile" Visible="false" />
                                    <asp:BoundField HeaderText="Email" ItemStyle-HorizontalAlign="Center" DataField="Email" Visible="false"/>
                                    <asp:BoundField HeaderText="Facebook" ItemStyle-HorizontalAlign="Center" DataField="Facebook" Visible="false"/>
                                    <asp:BoundField HeaderText="Nhóm bạn đọc" ItemStyle-HorizontalAlign="Center" DataField="GroupName" Visible="false"/>   
                                    <asp:BoundField HeaderText="Khóa" ItemStyle-HorizontalAlign="Center" DataField="Grade" Visible="false" />
                                    <asp:BoundField HeaderText="Lớp" ItemStyle-HorizontalAlign="Center" DataField="Class"/>
                                    <asp:BoundField HeaderText="Đơn vị" ItemStyle-HorizontalAlign="Center" DataField="Faculty" />
                                    <asp:BoundField HeaderText="Kho" ItemStyle-HorizontalAlign="Center" DataField="CodeLoc"/>
                                    <%--<asp:BoundField HeaderText="Số lần" ItemStyle-HorizontalAlign="Center" DataField="CountCheckIn"/>--%>
                                    <asp:BoundField HeaderText="Thời gian quét" ItemStyle-HorizontalAlign="Center" DataField="CREATEDATE" DataFormatString="{0:hh:mm:tt dd/MM/yyyy}"/>
                                    <asp:BoundField HeaderText="Nhân viên quét" ItemStyle-HorizontalAlign="Center" DataField="Name"/>
                                    <asp:BoundField HeaderText="Ghi chú" ItemStyle-HorizontalAlign="Center" DataField="" Visible="false"/>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
				<tr align="center">
					<td colspan="2"><IMG alt="" src="/" border="0" name="anh1" runat="server" id="anh1"></td>
				</tr>
				<tr align="center">
					<td colspan="2"><IMG alt="" src="/" border="0" name="anh2" runat="server" id="anh2"></td>
				</tr>
				<tr>
					<td colSpan="2">
						<asp:Label ID="lblPatronTotal" Runat="server" Visible="False">Số lượng vào phòng đọc</asp:Label>
						<asp:Label ID="lblLocation1" Runat="server" Visible="False">Phòng (</asp:Label>
						<asp:Label ID="lbldayofmonth" Runat="server" Visible="False">Các ngày trong tháng </asp:Label>
						<asp:Label ID="LblPercent" Runat="server" Visible="False">Tỉ lệ % giữa các ngày trong </asp:Label>
						<input id="hidHave" runat="server" type="hidden" value="0" NAME="hidHave">
						<asp:Label ID="lblLocation" Runat="server" Visible="False">------Chọn phòng-----</asp:Label>
						<asp:dropdownlist id="ddlLabel" Runat="server" Width="0" Visible="False">
							<asp:ListItem Value="0">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
							<asp:ListItem Value="1">Giờ không hợp lệ!</asp:ListItem>
							<asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
							<asp:ListItem Value="3">Số thẻ không hợp lệ!</asp:ListItem>
							<asp:ListItem Value="4">Số không hợp lệ!</asp:ListItem>
							<asp:ListItem Value="5">Bạn đọc đã mượn quá hạn ngạch</asp:ListItem>
							<asp:ListItem Value="6">Ngày mượn phải nhỏ hơn ngày trả!</asp:ListItem>
							<asp:ListItem Value="7">Thẻ bạn đọc đã hết hạn!</asp:ListItem>
						</asp:dropdownlist>
            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">STT</asp:ListItem>
                        <asp:ListItem Value="1">Số thẻ</asp:ListItem>
                        <asp:ListItem Value="2">Họ tên</asp:ListItem>                
                        <asp:ListItem Value="3">Ngày sinh</asp:ListItem>
                        <asp:ListItem Value="4">Tuổi</asp:ListItem>
                        <asp:ListItem Value="5">Số điện thoại</asp:ListItem>
                        <asp:ListItem Value="6">Email</asp:ListItem>
                        <asp:ListItem Value="7">Facebook</asp:ListItem>
                        <asp:ListItem Value="8">Nhóm bạn đọc</asp:ListItem>
                        <asp:ListItem Value="9">Khóa</asp:ListItem>
                        <asp:ListItem Value="10">Lớp</asp:ListItem>
                        <asp:ListItem Value="11">Đơn vị</asp:ListItem>
                        <asp:ListItem Value="12">Kho</asp:ListItem>
                        <asp:ListItem Value="13">Thời gian quét</asp:ListItem>
                        <asp:ListItem Value="14">Nhân viên quét</asp:ListItem>
                        <asp:ListItem Value="15">Số lần</asp:ListItem>
                        <asp:ListItem Value="16">Ghi chú</asp:ListItem>
            </asp:DropDownList>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
