<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WAddItem" CodeFile="WAddItem.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WAddItem</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="2" width="100%" border="0">
				<TR>
					<TD class="lbPageTitle" align="left" colSpan="2"><asp:label id="lblMainTitle" runat="server" CssClass="lbPageTitle">Nhập mới biểu ghi thư mục</asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%">
						<asp:label id="lblCataForm" Runat="server" cssClass="lbLabel">Chọn mẫu <u>b</u>iên mục:</asp:label></TD>
					<TD>
						<asp:dropdownlist id="ddlForm" Runat="server"></asp:dropdownlist>
						<asp:label id="Label3" CssClass="lbAmount" Runat="server">
							* 
						</asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width="20%"><asp:label id="lblField1" cssClass="lbLabel" Runat="server"><u>K</u>iểu bản ghi:</asp:label></TD>
					<TD><asp:dropdownlist id="ddlRecordType" Runat="server">
							<asp:ListItem Selected="True" Value="a">Tư liệu ngôn ngữ</asp:ListItem>
							<asp:ListItem Value="b">Điều khiển ngôn ngữ và các bản viết tay [BỎ]</asp:ListItem>
							<asp:ListItem Value="c">Bản nhạc in</asp:ListItem>
							<asp:ListItem Value="d">Bản nhạc viết tay</asp:ListItem>
							<asp:ListItem Value="e">Tư liệu bản đồ in</asp:ListItem>
							<asp:ListItem Value="f">Tư liệu bản đồ viết tay</asp:ListItem>
							<asp:ListItem Value="g">Phương tiện chiếu</asp:ListItem>
							<asp:ListItem Value="h">Các xuất bản phẩm vi mẫu [BỎ]</asp:ListItem>
							<asp:ListItem Value="i">Bản thu âm không phải âm nhạc</asp:ListItem>
							<asp:ListItem Value="j">Bản thu âm nhạc</asp:ListItem>
							<asp:ListItem Value="k">Đồ hoạ hai chiều không chiếu được</asp:ListItem>
							<asp:ListItem Value="m">Tệp máy tính</asp:ListItem>
							<asp:ListItem Value="n">Tư liệu hướng dẫn đặc biệt [BỎ]</asp:ListItem>
							<asp:ListItem Value="o">Bộ dụng cụ</asp:ListItem>
							<asp:ListItem Value="p">Vật liệu hỗn hợp</asp:ListItem>
							<asp:ListItem Value="r">Vật thể ba chiều tự nhiên hoặc nhân tạo</asp:ListItem>
							<asp:ListItem Value="t">Tư liệu ngôn ngữ viết tay</asp:ListItem>
						</asp:dropdownlist><asp:label id="lblNote1" CssClass="lbAmount" Runat="server">
							* 
						</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField2" cssClass="lbLabel" Runat="server"><u>C</u>ấp thư mục:</asp:label></TD>
					<TD><asp:dropdownlist id="ddlDicLevel" Runat="server">
							<asp:ListItem Selected="True" Value="a">Phần cấu thành của ấn phẩm đơn bản</asp:ListItem>
							<asp:ListItem Value="b">Phần cấu thánh của ấn phẩm định kỳ</asp:ListItem>
							<asp:ListItem Value="c">Bộ (Collection)</asp:ListItem>
							<asp:ListItem Value="d">Tiểu mục</asp:ListItem>
							<asp:ListItem Value="m">Tư liệu đơn bản (Monograph/item)</asp:ListItem>
							<asp:ListItem Value="s">Ấn phẩm định kỳ</asp:ListItem>
						</asp:dropdownlist>
						<asp:label id="lblNote2" CssClass="lbAmount" Runat="server">
							* 
						</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField3" cssClass="lbLabel" Runat="server">Dạng tài <u>l</u>iệu:</asp:label></TD>
					<TD><asp:dropdownlist id="ddlItemType" Runat="server"></asp:dropdownlist><asp:label id="lblNote3" CssClass="lbAmount" Runat="server">
							* 
						</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField4" cssClass="lbLabel" Runat="server"><u>V</u>ật mang tin:</asp:label></TD>
					<TD><asp:dropdownlist id="ddlMedium" Runat="server"></asp:dropdownlist><asp:label id="lblNote4" CssClass="lbAmount" Runat="server">
							* 
						</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField5" cssClass="lbLabel" Runat="server">Độ <u>m</u>ật:</asp:label></TD>
					<TD><asp:dropdownlist id="ddlSecLevel" Runat="server"></asp:dropdownlist><asp:label id="lblNote5" CssClass="lbAmount" Runat="server">
							* 
						</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField6" cssClass="lbLabel" Runat="server"><u>I</u>SBN:</asp:label></TD>
					<TD><asp:textbox id="txt020_a" CssClass="lbTextbox" Runat="server" Width="296px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField7" cssClass="lbLabel" Runat="server">I<u>S</u>SN:</asp:label></TD>
					<TD><asp:textbox id="txt022_a" CssClass="lbTextbox" Runat="server" Width="296px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right" style="HEIGHT: 31px"><asp:label id="lblField8" cssClass="lbLabel" Runat="server"><u>N</u>han đề chính:</asp:label></TD>
					<TD style="HEIGHT: 31px"><asp:textbox id="txt245_a" CssClass="lbTextbox" Runat="server" Width="296px"></asp:textbox><asp:label id="lblNote6" CssClass="lbAmount" Runat="server">
							* 
						</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField9" cssClass="lbLabel" Runat="server">Nơi <u>x</u>uất bản:</asp:label></TD>
					<TD><asp:textbox id="txt260_a" CssClass="lbTextbox" Runat="server" Width="296px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField10" cssClass="lbLabel" Runat="server">Nhà xuất <u>b</u>ản:</asp:label></TD>
					<TD><asp:textbox id="txt260_b" CssClass="lbTextbox" Runat="server" Width="296px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField11" cssClass="lbLabel" Runat="server">Năm x<u>u</u>ất bản:</asp:label></TD>
					<TD><asp:textbox id="txt260_c" CssClass="lbTextbox" Runat="server" Width="296px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right"><asp:label id="lblField12" cssClass="lbLabel" Runat="server">Số tr<u>a</u>ng:</asp:label></TD>
					<TD><asp:textbox id="txt300_a" CssClass="lbTextbox" Runat="server" Width="296px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:button id="btnAdd" cssClass="lbButton" Runat="server" Text="Nhập(n)"></asp:button>&nbsp;
						<asp:button id="btnDelete" cssClass="lbButton" Runat="server" text="Đặt lại(d)"></asp:button>&nbsp;
						<asp:Label id="Label2" CssClass="lbAmount" Runat="server">
							* 
						</asp:Label>&nbsp;
						<asp:Label id="Label1" CssClass="lbLabel" Runat="server">-- Thông tin bắt buộc</asp:Label></TD>
				</TR>
			</table>
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Height="0" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn hãy kiểm tra giá trị cuả trường nhan đề chính. Bản ghi không được cập nhật nếu trường này trống hoặc không hợp lệ</asp:ListItem>
				<asp:ListItem Value="3">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
			</asp:DropDownList><INPUT id="hidAddCopyNumber" type="hidden" size="1" value="1" runat="server">
		</form>
	</body>
</HTML>
