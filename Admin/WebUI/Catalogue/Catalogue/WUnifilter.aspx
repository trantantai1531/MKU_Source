<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WUnifilter" CodeFile="WUnifilter.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />

	    <style type="text/css">
            .auto-style1 {
                width: 7%;
            }
        </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" width="100%" border="0">
				<TR class="lbPageTitle">
					<td colSpan="3"><asp:label id="lblTitle" runat="server" cssclass="main-head-form" Height="8px">Lọc bản ghi</asp:label></td>
				</TR>
				<TR>
					<TD align="right"><asp:dropdownlist id="ddlField1" runat="server" Width="176px" Height="32px"></asp:dropdownlist></TD>
					<TD colSpan="2"><asp:textbox id="txtField1" runat="server" Width="264px" CssClass="lbTextBox"></asp:textbox>&nbsp;<asp:hyperlink id="lnkDic1" runat="server" Height="16px" CssClass="lblinkFunction">Từ điển</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 4px" align="right"><asp:dropdownlist id="ddlBool1" runat="server" Width="70px" >
							<asp:ListItem Value="AND" Selected="True">Và</asp:ListItem>
							<asp:ListItem Value="OR">Hoặc</asp:ListItem>
							<asp:ListItem Value="NOT">Không</asp:ListItem>
						</asp:dropdownlist>&nbsp;<asp:dropdownlist id="ddlField2" runat="server" Width="176px" Height="32px"></asp:dropdownlist></TD>
					<TD style="HEIGHT: 4px" colSpan="2"><asp:textbox id="txtfield2" runat="server" Width="264px" CssClass="lbTextBox"></asp:textbox>&nbsp;<asp:hyperlink id="lnkDic2" runat="server" Height="16px" CssClass="lblinkFunction">Từ điển</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right"><asp:dropdownlist id="ddlBool2" runat="server" Width="70px">
							<asp:ListItem Value="AND" Selected="True">Và</asp:ListItem>
							<asp:ListItem Value="OR">Hoặc</asp:ListItem>
							<asp:ListItem Value="NOT">Không</asp:ListItem>
						</asp:dropdownlist>&nbsp;<asp:dropdownlist id="ddlField3" runat="server" Width="176px" Height="32px"></asp:dropdownlist></TD>
					<TD colSpan="2"><asp:textbox id="txtField3" runat="server" Width="264px" CssClass="lbTextBox"></asp:textbox>&nbsp;<asp:hyperlink id="lnkDic3" runat="server" Height="12px" CssClass="lblinkFunction">Từ điển</asp:hyperlink></TD>
				</TR>
				<TR>
					<td align="right"><asp:dropdownlist id="ddlBool3" runat="server" Width="70px" >
							<asp:ListItem Value="AND" Selected="True">Và</asp:ListItem>
							<asp:ListItem Value="OR">Hoặc</asp:ListItem>
							<asp:ListItem Value="NOT">Không</asp:ListItem>
						</asp:dropdownlist>&nbsp;<asp:dropdownlist id="ddlField4" runat="server" Width="176px" Height="32px"></asp:dropdownlist></td>
					<td colSpan="2"><asp:textbox id="txtField4" runat="server" Width="264px" CssClass="lbTextBox"></asp:textbox>&nbsp;<asp:hyperlink id="lnkDic4" runat="server" Height="16px" CssClass="lblinkFunction">Từ điển</asp:hyperlink></td>
				</TR>
				<TR>
					<td align="right"  style="padding-right: 82px;"><asp:label id="lblFrom" style="Z-INDEX: 101" runat="server" Height="16px" CssClass="lbLabel">Từ:</asp:label></td>
					<td class="auto-style1">&nbsp;</td>
					<td><asp:label id="lblTo" style="Z-INDEX: 105" runat="server" Height="8px" CssClass="lbLabel">Tới:</asp:label></td>
				</TR>
				<TR>
					<td align="right"><asp:label id="lblRecordID" runat="server" Height="16px" CssClass="lbLabel"><u>Mã số biểu ghi:</u></asp:label><asp:textbox id="txtRecordIDFrom" style="Z-INDEX: 102" runat="server" Width="104px" CssClass="lbTextBox"></asp:textbox></td>
					<td class="auto-style1">&nbsp;</td>
					<td><asp:textbox id="txtRecordIDto" style="Z-INDEX: 106; margin-left: 0px;" runat="server" Width="104px" CssClass="lbTextBox"></asp:textbox></td>
				</TR>
				<TR>
					<td align="right"  style="padding-right: 82px;"><asp:label id="lblFromTime" style="Z-INDEX: 103" runat="server" Width="48px" Height="16px"
							CssClass="lbLabel">Từ:</asp:label></td>
					<td class="auto-style1">&nbsp;</td>
					<td><asp:label id="lblToTime" style="Z-INDEX: 107" runat="server" Height="16px" CssClass="lbLabel">Tới:</asp:label></td>
				</TR>
				<TR>
					<td align="right"><asp:label id="lblUpdateTime" runat="server" Height="19px" CssClass="lbLabel">Thời gian biên mục:</asp:label><asp:textbox id="txtTimeFrom" style="Z-INDEX: 104" runat="server" Width="104px" CssClass="lbTextBox"></asp:textbox></td>
					<td class="auto-style1">&nbsp;<asp:hyperlink id="lnkFrom" runat="server" Height="16px" CssClass="lblinkFunction">Lịch</asp:hyperlink></td>
					<td><asp:textbox id="txtTimeTo" style="Z-INDEX: 108" runat="server" Width="104px" CssClass="lbTextBox"></asp:textbox>&nbsp;<asp:hyperlink id="lnkTo" runat="server" Height="16px" CssClass="lblinkFunction">Lịch</asp:hyperlink></td>
				</TR>
				<TR>
					<td></td>
					<td colSpan="2"><asp:checkbox id="chkMerge" style="Z-INDEX: 109" runat="server" Height="16px" CssClass="lbLabel"
							Text="Gộp kết quả với tập kết quả hiện thời"></asp:checkbox></td>
				</TR>
				<TR>
					<td align="center" colSpan="3"><asp:button id="btnFilter" runat="server" Width="64px" CssClass="lbButton" Text="Lọc (f)"></asp:button>
						<asp:button id="btnReset" runat="server" Width="72px" CssClass="lbButton" Text="Đặt lại (r)"></asp:button></td>
				</TR>
			</TABLE>
			<asp:DropDownList Runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
				<asp:ListItem Value="0">Không có giá trị nào thoả mãn điều kiện lọc</asp:ListItem>
				<asp:ListItem Value="1">Bạn phải nhập vào ít nhất một điều kiện lọc</asp:ListItem>
				<asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="3">Bạn phải nhập dữ liệu kiểu số cho Record ID</asp:ListItem>
				<asp:ListItem Value="4">Không có giá trị nào mới tìm thấy khi gộp kết quả với tập kết quả hiện thời!</asp:ListItem>
				<asp:ListItem Value="5">Mọi trường</asp:ListItem>
				<asp:ListItem Value="6">Nhan đề</asp:ListItem>
				<asp:ListItem Value="7">Năm xuất bản</asp:ListItem>
				<asp:ListItem Value="8">Đăng kí cá biệt</asp:ListItem>
				<asp:ListItem Value="9">ISBN</asp:ListItem>
				<asp:ListItem Value="10">ISSN</asp:ListItem>
				<asp:ListItem Value="11">Dạng tài liệu</asp:ListItem>
				<asp:ListItem Value="12">Người biên mục</asp:ListItem>
				<asp:ListItem Value="13">Số định danh</asp:ListItem>
				<asp:ListItem Value="14">Lọc bản ghi biên mục. Kết quả: </asp:ListItem>
				<asp:ListItem Value="15">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="16">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="17">bản ghi</asp:ListItem>
				<asp:ListItem Value="18">Thời gian biên mục từ: phải nhỏ hơn tới:</asp:ListItem>
			</asp:DropDownList>
		</form>
		<script language = javascript>
			document.forms[0].txtField1.focus();
		</script>
		
	</body>
</HTML>
