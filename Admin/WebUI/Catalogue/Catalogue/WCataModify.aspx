<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCataModify" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WCataModify.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WCataModify</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body leftMargin="0" topMargin="0"
		rightmargin="0" bottommargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0" >
				<tr>
					<td>
						<asp:button id="btnUpdate" runat="server" Text="Cập nhật" Width="65px"></asp:button>
						<asp:button id="btnPreview" runat="server" Text="Xem" Width="45px"></asp:button>
						<asp:button id="btnOverlay" runat="server" Text="Nhập đè" Width="65px"></asp:button>
						<asp:button id="btnValidate" runat="server" Text="Hợp lệ" Width="55px"></asp:button>
						<asp:button id="btnAddFields" runat="server" Text="Thêm trường" Width="85px"></asp:button>
						<asp:button id="btnSpellCheck" runat="server" Text="Chính tả" Width="65px" style="display:none"></asp:button>
						<asp:button id="btnHolding" runat="server" Text="Xếp giá" Width="65px" Visible="False"></asp:button>
						<asp:button id="btnCatalogue" runat="server" Text="Biên mục" Width="65px"></asp:button>
					</td>
					<td align="right">
						<asp:button id="btnMoveFirst" runat="server" Text="|<"></asp:button>
						<asp:button id="btnMovePrev" runat="server" Text="<"></asp:button>
						<asp:textbox id="txtCurrentRec" runat="server" CssClass="lbTextbox" Width="50px"></asp:textbox>
						<asp:textbox id="txtTotalRec" runat="server" CssClass="lbTextbox" Enabled="False" Width="50px"></asp:textbox>
						<asp:button id="btnMoveNext" runat="server" Text=">"></asp:button>
						<asp:button id="btnMoveLast" runat="server" Text=">|"></asp:button>
						<asp:button id="btnNew" runat="server" Text=">*"></asp:button>
						<asp:button id="btnFilter" runat="server" Text="..."></asp:button>
					</td>
				</tr>
			</table>
			<input id="txtFunc" type="hidden" name="txtFunc" runat="server">
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0px">
				<asp:ListItem Value="0"></asp:ListItem>
				<asp:ListItem Value="1">Emiclib -- Xem trước dữ liệu bản ghi</asp:ListItem>
				<asp:ListItem Value="2">Xem trước dữ liệu bản ghi</asp:ListItem>
				<asp:ListItem Value="3">Đóng</asp:ListItem>
				<asp:ListItem Value="4">Bạn không có quyền sửa bản ghi do người khác nhập.</asp:ListItem>
				<asp:ListItem Value="5">Bạn đang biên mục dở dang. Chuyển chức năng làm việc có thể làm mất những dữ liệu đã sửa đổi cho bản ghi này. Bấm Cancel để tiếp tục sửa chữa biểu ghi hoặc bấm OK để khẳng định quyết định của mình</asp:ListItem>
				<asp:ListItem Value="6">Bạn đang ở bản ghi đầu tiên</asp:ListItem>
				<asp:ListItem Value="7">Bạn đang ở bản ghi cuối cùng</asp:ListItem>
				<asp:ListItem Value="8">Dữ liệu nhập vào không thuộc phạm vi kiểm tra</asp:ListItem>
				<asp:ListItem Value="9">Bạn hãy kiểm tra giá trị của trường</asp:ListItem>
				<asp:ListItem Value="10">Bản ghi này không được cập nhật nếu trường này trống hoặc không hợp lệ</asp:ListItem>
				<asp:ListItem Value="11">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="12">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="12"></asp:ListItem>
			</asp:DropDownList>
			<input id="txtChangeForm" type="hidden" value="0" name="txtChangeForm" runat="server">
			<input id="txtHolding" type="hidden" value="0" name="txtHolding" runat="server">
			<input id="txtUpdateNow" type="hidden" value="0" name="txtUpdateNow" runat="server">
			<input id="txtItemID" type="hidden" name="txtItemID" runat="server" value="0"> <input id="txtCurFilteredID" type="hidden" name="txtCurFilteredID" runat="server">
			<input id="txtFormID" type="hidden" name="txtFormID" runat="server" value="0"> <input id="txtClone" type="hidden" name="txtClone" runat="server">
			<input id="txtCataDetail" type="hidden" name="txtCataDetail" runat="server"> <input id="txtModule" type="hidden" name="txtModule" runat="server">
			<input id="txtFieldCodes" type="hidden" name="txtFieldCodes" runat="server"> <input id="txtAddedFieldCodes" type="hidden" name="txtAddedFieldCodes" runat="server">
			<asp:Label id="lblHiddenField" runat="server"></asp:Label>
			<input id="txtModifiedFieldCodes" type="hidden" name="txtModifiedFieldCodes" runat="server">
			<input id="txtUsedFieldCodes" type="hidden" name="txtUsedFieldCodes" runat="server">
			<input id="txtLeader" type="hidden" name="txtLeader" runat="server">
			<asp:label id="lblMyJS" runat="server" Width="0px"></asp:label>
			<script language=javascript>
				if (document.forms[0].txtHolding.value==1) {
					parent.document.getElementById('frmMain').setAttribute('rows','*,28');
					parent.Workform.focus();
					self.focus();
					parent.Workform.location.href = 'WCopyNumber.aspx?FormID='+ document.forms[0].txtFormID.value +'&Module='+document.forms[0].txtModule.value+'&AddedFieldCodes='+document.forms[0].txtAddedFieldCodes.value;
				}
				else {
					OnLoad()
				}
			</script>
		</form>
	</body>
</HTML>
