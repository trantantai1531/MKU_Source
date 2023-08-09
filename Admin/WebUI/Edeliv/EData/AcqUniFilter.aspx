<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqUniFilter.aspx.vb" Inherits="eMicLibAdmin.WebUI.Edeliv.Edeliv_EData_AcqUniFilter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="Table2" width="100%" border="0">
				<tr class="lbPageTitle">
					<td colspan="4"><asp:label id="lblTitle" runat="server" cssclass="main-head-form" Height="8px">Lọc bản ghi</asp:label></td>
				</tr>
				<tr>
					<td align="right" width="10%"></td>
					<td align="right"><asp:dropdownlist id="ddlField1" runat="server" Width="176px" Height="32px"></asp:dropdownlist></td>
					<td colspan="2"><asp:textbox id="txtField1" runat="server" Width="264px" CssClass="lbTextBox"></asp:textbox>&nbsp;<asp:hyperlink id="lnkDic1" runat="server" Height="16px" CssClass="lblinkFunction">Từ điển</asp:hyperlink></td>
				</tr>
				<tr>
					<td style="HEIGHT: 4px" align="right"></td>
					<td style="HEIGHT: 4px" align="right"><asp:dropdownlist id="ddlBool1" runat="server" Width="80px" Height="31px">
							<asp:ListItem Value="AND" Selected="True">Và</asp:ListItem>
							<asp:ListItem Value="OR">Hoặc</asp:ListItem>
							<asp:ListItem Value="NOT">Không</asp:ListItem>
						</asp:dropdownlist>&nbsp;<asp:dropdownlist id="ddlField2" runat="server" Width="176px" Height="32px"></asp:dropdownlist></td>
					<td style="HEIGHT: 4px" colspan="2"><asp:textbox id="txtfield2" runat="server" Width="264px" CssClass="lbTextBox"></asp:textbox>&nbsp;<asp:hyperlink id="lnkDic2" runat="server" Height="16px" CssClass="lblinkFunction">Từ điển</asp:hyperlink></td>
				</tr>
				<tr>
					<td align="right"></td>
					<td align="right"><asp:dropdownlist id="ddlBool2" runat="server" Width="80px">
							<asp:ListItem Value="AND" Selected="True">Và</asp:ListItem>
							<asp:ListItem Value="OR">Hoặc</asp:ListItem>
							<asp:ListItem Value="NOT">Không</asp:ListItem>
						</asp:dropdownlist>&nbsp;<asp:dropdownlist id="ddlField3" runat="server" Width="176px" Height="32px"></asp:dropdownlist></td>
					<td colspan="2"><asp:textbox id="txtField3" runat="server" Width="264px" CssClass="lbTextBox"></asp:textbox>&nbsp;<asp:hyperlink id="lnkDic3" runat="server" Height="12px" CssClass="lblinkFunction">Từ điển</asp:hyperlink></td>
				</tr>
				<tr>
					<td align="right"></td>
					<td align="right"><asp:dropdownlist id="ddlBool3" runat="server" Width="80px" Height="31px">
							<asp:ListItem Value="AND" Selected="True">Và</asp:ListItem>
							<asp:ListItem Value="OR">Hoặc</asp:ListItem>
							<asp:ListItem Value="NOT">Không</asp:ListItem>
						</asp:dropdownlist>&nbsp;<asp:dropdownlist id="ddlField4" runat="server" Width="176px" Height="31px"></asp:dropdownlist></td>
					<td colspan="2"><asp:textbox id="txtField4" runat="server" Width="264px" CssClass="lbTextBox"></asp:textbox>&nbsp;<asp:hyperlink id="lnkDic4" runat="server" Height="16px" CssClass="lblinkFunction">Từ điển</asp:hyperlink></td>
				</tr>
                <tr>
					<td align="right"></td>
					<td align="right"><asp:label id="lblType" style="Z-INDEX: 101" runat="server" Height="31px" CssClass="lbLabel">Loại tài liệu</asp:label></td>
					<td colspan="2">
                        <asp:dropdownlist id="ddlType" runat="server" Width="264px" Height="32px">
                            <asp:ListItem Value="0" Selected="True">Tất cả</asp:ListItem>
							<asp:ListItem Value="1">Tài liệu biên mục</asp:ListItem>
							<asp:ListItem Value="2">Tài liệu điện tử</asp:ListItem>
                        </asp:dropdownlist>
                    </td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td width="25%"><asp:label id="lblFrom" style="Z-INDEX: 101" runat="server" Height="16px" CssClass="lbLabel">Từ:</asp:label></td>
					<td><asp:label id="lblTo" style="Z-INDEX: 105" runat="server" Height="8px" CssClass="lbLabel">Tới:</asp:label></td>
				</tr>
				<tr>
					<td></td>
					<td align="right"><asp:label id="lblRecordID" runat="server" Height="8px" CssClass="lbLabel">Mã biểu ghi</asp:label></td>
					<td><asp:textbox id="txtRecordIDFrom" style="Z-INDEX: 102" runat="server" Width="104px" CssClass="lbTextBox"></asp:textbox></td>
					<td><asp:textbox id="txtRecordIDto" style="Z-INDEX: 106" runat="server" Width="104px" CssClass="lbTextBox"></asp:textbox></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td><asp:label id="lblFromTime" style="Z-INDEX: 103" runat="server" Width="48px" Height="16px"
							CssClass="lbLabel">Từ:</asp:label></td>
					<td><asp:label id="lblToTime" style="Z-INDEX: 107" runat="server" Height="16px" CssClass="lbLabel">Tới:</asp:label></td>
				</tr>
				<tr>
					<td></td>
					<td align="right"><asp:label id="lblUpdateTime" runat="server" Height="19px" CssClass="lbLabel">Thời gian biên mục:</asp:label></td>
					<td><asp:textbox id="txtTimeFrom" style="Z-INDEX: 104" runat="server" Width="104px" CssClass="lbTextBox"></asp:textbox>&nbsp;<asp:hyperlink id="lnkFrom" runat="server" Height="16px" CssClass="lblinkFunction">Lịch</asp:hyperlink></td>
					<td><asp:textbox id="txtTimeTo" style="Z-INDEX: 108" runat="server" Width="104px" CssClass="lbTextBox"></asp:textbox>&nbsp;<asp:hyperlink id="lnkTo" runat="server" Height="16px" CssClass="lblinkFunction">Lịch</asp:hyperlink></td>
				</tr>
				<tr>
					<td></td>
					<td></td>
					<td colspan="2"><asp:checkbox id="chkMerge" style="Z-INDEX: 109" runat="server" Height="16px" CssClass="lbLabel"
							Text="Gộp kết quả với tập kết quả hiện thời"></asp:checkbox></td>
				</tr>
				<tr>
					<td align="center" colspan="4"><asp:button id="btnFilter" runat="server" Width="64px" CssClass="lbButton" Text="Lọc (f)"></asp:button>
						<asp:button id="btnReset" runat="server" Width="72px" CssClass="lbButton" Text="Đặt lại (r)"></asp:button></td>
				</tr>
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
            <div style="display:none">
                <asp:HiddenField ID="hidFilterCollectionId" runat="server" Value="0" />
            </div>
		</form>
		<script language = javascript>
		    document.forms[0].txtField1.focus();
		</script>		
	</body>
</html>
