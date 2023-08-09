<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WZFind" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WZFind.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Kết quả tìm kiếm qua Z3950</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="5" topMargin="2">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<TR>
					<TD class="lbPageTitle" colSpan="2">
						<asp:label id="lblHeader" runat="server" CssClass="lbPageTitle">Emiclib - Z39.50 Gateway</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="2">
						<P><asp:label id="lblFound" runat="server">Tìm thấy:</asp:label>&nbsp;
							<asp:label id="lblSumrec" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:label>&nbsp;
							<asp:label id="lblRec" runat="server">biểu ghi</asp:label></P>
						<P><asp:label id="lblStatus" runat="server"></asp:label></P>
					</TD>
				</TR>
				<TR valign="top">
					<TD width="50%" style="HEIGHT: 26px">
						<asp:label id="lblNext" runat="server"><U>X</U>em 10 kết quả tiếp kể từ biểu ghi số:</asp:label>
						<asp:textbox id="txtStart" runat="server" Width="56px">11</asp:textbox>&nbsp;
						<asp:button id="btnView" runat="server" Width="57" Text="Xem(v)"></asp:button>&nbsp;
						<asp:Button ID="btnBack" Runat="server" Width="70" Text="Quay lại(b)"></asp:Button>
					</TD>
					<TD align="right" style="HEIGHT: 26px"><asp:label id="lblDisplay" runat="server" Visible="False">Hiển thị:</asp:label><asp:dropdownlist id="ddlDisplay" runat="server" Visible="False" AutoPostBack="True">
							<asp:ListItem Value="0">ISBD</asp:ListItem>
							<asp:ListItem Value="1">MARC</asp:ListItem>
							<asp:ListItem Value="2">Đơn giản</asp:ListItem>
						</asp:dropdownlist>&nbsp;
						</TD>
				</TR>
				<tr>
					<td></td>
					<td align="right" >
					<asp:label id="lblForm" Runat="server"><U>S</U>ử dụng mẫu: </asp:label>&nbsp;
						<asp:dropdownlist id="ddlForm" runat="server"></asp:dropdownlist>&nbsp;
						<asp:button id="btnImport" runat="server" Width="95" Text="Nhập khẩu(i)"></asp:button></td>
				</tr>
				<tr class="lbGridHeader">
					<td align="center" colSpan="2"><asp:label id="NotFound" Runat="server" Visible="False" ForeColor="White">Không tìm thấy bản ghi nào thoả mãn điều kiện</asp:label></td>
				</tr>
				<TR>
					<TD colSpan="2">
						<asp:Table id="tblResult" runat="server" Width="100%"></asp:Table>
					</TD>
				</TR>
			</table>
			<INPUT id="ddlFieldName1" type="hidden" runat="server"> <INPUT id="txtFieldValue1" type="hidden" runat="server">
			<INPUT id="ddlFieldName2" type="hidden" runat="server"> <INPUT id="txtFieldValue2" type="hidden" runat="server">
			<INPUT id="ddlFieldName3" type="hidden" runat="server"> <INPUT id="txtFieldValue3" type="hidden" runat="server">
			<INPUT id="ddlOperator2" type="hidden" runat="server"> <INPUT id="ddlOperator3" type="hidden" runat="server">
			<INPUT id="txtImportedID" type="hidden" runat="server"> <INPUT id="hidCountRec" type="hidden" runat="server" NAME="hidCountRec">
			<INPUT id="hidAction" type="hidden" value="2" runat="server" NAME="hidAction"><INPUT id="hidPosRec" type="hidden" value="1" runat="server" NAME="hidPosRec">
			<asp:DropDownList ID="ddlLabel" Runat="server" Width="0px" Visible="False">
				<asp:ListItem Value="0">Lỗi trong quá trình xử lý</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="3">Tác giả</asp:ListItem>
				<asp:ListItem Value="4">Nhan đề</asp:ListItem>
				<asp:ListItem Value="5">Nhà xuất bản</asp:ListItem>
				<asp:ListItem Value="6">Mô tả vật lý</asp:ListItem>
				<asp:ListItem Value="7">Chọn</asp:ListItem>
				<asp:ListItem Value="8">Danh sách biểu ghi tìm được</asp:ListItem>
				<asp:ListItem Value="9">Dữ liệu không hợp lệ!</asp:ListItem>
				<asp:ListItem Value="10">Xin vui lòng chờ đợi trong chốc lát!</asp:ListItem>
				<asp:ListItem Value="11">STT</asp:ListItem>
			</asp:DropDownList>
		</form>
		<script language='javascript'>
		<!--
			// Uncheck all checkboxs
			for (intIndex = 0; intIndex < 10; intIndex++) {
				if(eval('document.forms[0].chk' + intIndex)){
					eval('document.forms[0].chk' + intIndex + '.checked=false;')
				}
			}
		//-->
		</script>
	</body>
</HTML>
