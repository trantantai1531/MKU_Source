<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIDXForm" CodeFile="WIDXForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WIDXForm</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<tr class="lbPageTitle">
					<td align="left">
						<asp:label id="lblPageHeader" runat="server" CssClass="lbPageTitle  main-head-form"></asp:label>
					</td>
				</tr>
				<TR class="lbGroupTitle">
					<TD><asp:label id="lblHeadGroup" runat="server" CssClass="lbGroupTitle">Nhóm danh mục</asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblGroup" runat="server"><u>C</u>họn nhóm:</asp:label>&nbsp;
						<asp:dropdownlist id="ddlGroup" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
				</TR>
				<TR class="lbGroupTitle">
					<TD><asp:label id="lblRange" CssClass="lbGroupTitle" runat="server">Khoảng dữ liệu:</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<table width="100%" border="0">
							<tr>
								<td align="right" width="30%"><asp:label id="lblRecFrom" runat="server"><u>B</u>iểu ghi từ:</asp:label></td>
								<td><asp:textbox id="txtIDFrom" runat="server" Width="128px"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:label id="lblRecTo" runat="server">Tớ<u>i</u>:</asp:label>&nbsp;<asp:textbox id="txtIDTo" runat="server" Width="136px"></asp:textbox></td>
							</tr>
							<TR>
								<TD align="right" width="30%"><asp:label id="lblFromDate" runat="server">Thời <u>g</u>ian biên mục từ:</asp:label></TD>
								<TD><asp:textbox id="txtCataFrom" runat="server" Width="128px"></asp:textbox>&nbsp;<asp:hyperlink id="lnkFrom" runat="server" CssClass="lbLinkFunction">Lịch</asp:hyperlink>&nbsp;
									<asp:label id="lblCataTo" runat="server">Tớ<u>i</u>:</asp:label>
									<asp:textbox id="txtCataTo" runat="server" Width="136px"></asp:textbox>&nbsp;<asp:hyperlink id="lnkTo" runat="server" CssClass="lbLinkFunction">Lịch</asp:hyperlink></TD>
							</TR>
							<TR>
								<TD align="right" width="30%"><asp:label id="lblItemType" runat="server">Dạng tài liệu:</asp:label></TD>
								<TD><asp:listbox id="lstItemType" runat="server" Width="304px" SelectionMode="Multiple" Height="80px"></asp:listbox>&nbsp;</TD>
							</TR>
						</table>
					</TD>
				</TR>
				<TR class="lbGroupTitle">
					<TD><asp:label id="lblFilter" runat="server" CssClass="lbGroupTitle">Lọc dữ liệu</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<table width="100%" border="0">
							<tr>
								<td align="right" width="10%"><asp:dropdownlist id="ddlBool1" runat="server"></asp:dropdownlist></td>
								<td width="20%"><asp:dropdownlist id="ddlField1" runat="server"></asp:dropdownlist></td>
								<td><asp:textbox id="txtVal1" runat="server" Width="408px"></asp:textbox>&nbsp;
									<asp:hyperlink id="lnkDic1" runat="server" CssClass="lbLinkFunction">Từ điển</asp:hyperlink></td>
							</tr>
							<TR>
								<TD style="HEIGHT: 25px" align="right" width="10%"><asp:dropdownlist id="ddlBool2" runat="server"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 25px" width="20%"><asp:dropdownlist id="ddlField2" runat="server"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 25px"><asp:textbox id="txtVal2" runat="server" Width="408px"></asp:textbox>&nbsp;
									<asp:hyperlink id="lnkDic2" runat="server" CssClass="lbLinkFunction">Từ điển</asp:hyperlink></TD>
							</TR>
							<TR>
								<TD align="right" width="10%"><asp:dropdownlist id="ddlBool3" runat="server"></asp:dropdownlist></TD>
								<TD width="20%"><asp:dropdownlist id="ddlField3" runat="server"></asp:dropdownlist></TD>
								<TD><asp:textbox id="txtVal3" runat="server" Width="408px"></asp:textbox>&nbsp;
									<asp:hyperlink id="lnkDic3" runat="server" CssClass="lbLinkFunction">Từ điển</asp:hyperlink></TD>
							</TR>
							<TR>
								<TD align="right" width="10%"><asp:dropdownlist id="ddlBool4" runat="server"></asp:dropdownlist></TD>
								<TD width="20%"><asp:dropdownlist id="ddlField4" runat="server"></asp:dropdownlist></TD>
								<TD><asp:textbox id="txtVal4" runat="server" Width="408px"></asp:textbox>&nbsp;
									<asp:hyperlink id="lnkDic4" runat="server" CssClass="lbLinkFunction">Từ điển</asp:hyperlink></TD>
							</TR>
						</table>
					</TD>
				</TR>
				<TR class="lbGroupTitle">
					<TD><asp:label id="lblInforGroup" runat="server" CssClass="lbGroupTitle">Thông tin nhóm</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<table width="100%" border="0">
							<tr>
								<td align="right" width="30%"><asp:label id="lblInset" runat="server">Nhóm <u>m</u>ới được chèn</asp:label>&nbsp;
									<asp:dropdownlist id="ddlBe_Af" runat="server">
										<asp:ListItem Value="1">Trước</asp:ListItem>
										<asp:ListItem Value="2">Sau</asp:ListItem>
									</asp:dropdownlist>&nbsp;</td>
								<td><asp:dropdownlist id="ddlGroupHave" runat="server"></asp:dropdownlist></td>
							</tr>
							<TR>
								<TD align="right" width="30%"><asp:label id="lblGroupName" runat="server">Tên n<u>h</u>óm:</asp:label></TD>
								<TD><asp:textbox id="txtGroupName" runat="server" Width="416px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="right" width="30%"><asp:label id="lblOrderBy" runat="server"><u>S</u>ắp xếp theo:</asp:label></TD>
								<TD><asp:textbox id="txtOrderBy" runat="server" Width="416px" value="245$a"></asp:textbox></TD>
							</TR>
						</table>
					</TD>
				</TR>
				<TR>
					<TD align="right"><asp:button id="btnUpdateGroup" runat="server" Text="Cập nhật (n) "></asp:button>&nbsp;
						<asp:button id="btnViewGroup" runat="server" Text="Xem nhóm (x) "></asp:button>&nbsp;
						<asp:button id="btnDelGroup" runat="server" Text="Xoá nhóm (m) "></asp:button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
			</table>
			<INPUT id="txtHidTypeIDs" type="hidden" name="txtHidTypeIDs" runat="server"></form>
		<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0" Height="0">
			<asp:ListItem Value="0">Bạn chưa chọn tên nhóm!</asp:ListItem>
			<asp:ListItem Value="1">Chưa có điều kiện lọc dữ liệu!</asp:ListItem>
			<asp:ListItem Value="2">Bạn chưa nhập tên nhóm!</asp:ListItem>
			<asp:ListItem Value="3">----- Chọn nhóm -----</asp:ListItem>
			<asp:ListItem Value="4">Bạn có chắc chắn muốn xoá nhóm đã chọn không ?</asp:ListItem>
			<asp:ListItem Value="5">Bạn không được cấp quyền sử dụng chức năng này</asp:ListItem>
			<asp:ListItem Value="6">Tạo mới nhóm danh mục: </asp:ListItem>
			<asp:ListItem Value="7">Cập nhật nhóm danh mục: </asp:ListItem>
			<asp:ListItem Value="8">Xoá nhóm danh mục: </asp:ListItem>
			<asp:ListItem Value="9">Tên danh mục:</asp:ListItem>
			<asp:ListItem Value="10">Tên nhóm:</asp:ListItem>
			<asp:ListItem Value="11">Mã lỗi</asp:ListItem>
			<asp:ListItem Value="12">Cập nhật được </asp:ListItem>
			<asp:ListItem Value="13">biểu ghi</asp:ListItem>
			<asp:ListItem Value="14">Biểu ghi nhập vào phải lớn hơn 0!</asp:ListItem>
			<asp:ListItem Value="15">Biểu ghi nhập vào phải là dữ liệu kiểu số!</asp:ListItem>
			<asp:ListItem Value="16">Biểu ghi đầu phải nhỏ hơn hoặc bằng biểu ghi cuối!</asp:ListItem>
			<asp:ListItem Value="17">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
			<asp:ListItem Value="18">Vượt quá giới hạn bản ghi hiện có!</asp:ListItem>
			<asp:ListItem Value="19">Thời gian biên mục từ: phải nhỏ hơn hoặc bằng tới:</asp:ListItem>
			<asp:ListItem Value="20">Sai kiểu dữ liệu.</asp:ListItem>
		</asp:DropDownList>
	</body>
</HTML>
