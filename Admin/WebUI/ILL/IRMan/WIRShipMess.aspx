<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.ILL.WIRShipMess" CodeFile="WIRShipMess.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Thông điệp giao hàng</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tblEnableView" cellSpacing="3" cellPadding="2" width="100%">
				<tr class="lbPageTitle">
					<td colSpan="2"><asp:label id="lblHeader" Runat="server" cssClass="lbPageTitle" Width="100%">Thông điệp giao hàng</asp:label></td>
				</tr>
				<tr>
					<td width="50%">
						<asp:label id="lblTypeService" Runat="server">Kiểu <u>d</u>ịch vụ:</asp:label>&nbsp;
						<asp:dropdownlist id="ddlServiceType" runat="server"></asp:dropdownlist>
					</td>
					<td>
						<asp:label id="lblSendDay" Runat="server"><u>N</u>gày gửi:</asp:label>&nbsp;
						<asp:textbox id="txtProvidedDate" Runat="server"></asp:textbox>&nbsp;
						<asp:HyperLink ID="lnkProvidedDate" Runat="server">Lịch</asp:HyperLink>
					</td>
				</tr>
				<tr class="lbSubFormTitle">
					<td colSpan="2">
						<asp:label id="lblBorrow" Runat="server" Cssclass="lbSubFormTitle" Width="100%">Điều kiện cho mượn</asp:label>
					</td>
				</tr>
				<tr>
					<td>
						<asp:label id="lblLimBorrow" Runat="server"><u>H</u>ạn mượn:</asp:label>&nbsp;
						<asp:textbox id="txtDueDate" Runat="server"></asp:textbox>&nbsp;
						<asp:HyperLink ID="lnkDueDate" Runat="server">Lịch</asp:HyperLink>
					</td>
					<td>
						<asp:checkbox id="cbkRenewable" Runat="server" Checked="True" Text="Được gi<u>a</u> hạn"></asp:checkbox>
					</td>
				</tr>
				<tr>
					<td colSpan="2" class="lbSubFormTitle">
						<asp:label id="lblConditionShip" Runat="server" cssclass="lbSubFormTitle">Điều kiện gia<u>o</u> hàng:</asp:label>
					</td>
				</tr>
				<tr>
					<td colspan="2"><asp:dropdownlist id="ddlCondition" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="lbSubFormTitle"></td>
					<td class="lbSubFormTitle"><asp:label id="lblPayMoney" Runat="server" Cssclass="lbSubFormTitle">Tiền phải trả</asp:label></td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td><asp:label id="lblPayType" Runat="server">Kiểu thanh <u>t</u>oán:</asp:label></td>
							</tr>
							<tr>
								<td style="HEIGHT: 19px"><asp:dropdownlist id="ddlPaymentType" runat="server"></asp:dropdownlist></td>
							</tr>
							<tr>
								<td><asp:label id="lblRefLocal" Runat="server">Số tham chiếu nội <u>b</u>ộ:</asp:label></td>
							</tr>
							<tr>
								<td><asp:textbox id="txtInternalRefNumber" Runat="server"></asp:textbox></td>
							</tr>
						</table>
					</td>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td colSpan="2"><asp:label id="lblUnitSpend" Runat="server">Số đơn vị chịu <u>p</u>hí</asp:label></td>
							</tr>
							<tr>
								<td colSpan="2"><asp:textbox id="txtChargeableUnit" Runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td width="50%"><asp:label id="lblPostage" Runat="server"><u>C</u>ước phí:</asp:label></td>
								<td><asp:label id="lblUnitMoney" Runat="server">Đơn <u>v</u>ị tiền tệ:</asp:label></td>
							</tr>
							<tr>
								<td><asp:textbox id="txtCost" Runat="server"></asp:textbox></td>
								<td><asp:dropdownlist id="ddlCurrencyCode1" runat="server"></asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td class="lbSubFormTitle"><asp:label id="lblInsure" Runat="server" Cssclass="lbSubFormTitle">Được bảo hiểm bằng</asp:label></td>
					<td class="lbSubFormTitle"><asp:label id="lblInsureRePay" Runat="server" Cssclass="lbSubFormTitle">Đòi hỏi phí bảo hiểm khi trả lại</asp:label></td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td width="50%"><asp:label id="lblPostageInsure" Runat="server"><u>C</u>ước phí:</asp:label></td>
								<td><asp:label id="lblUnitMoneyInsure" Runat="server">Đơn <u>v</u>ị tiền tệ:</asp:label></td>
							</tr>
							<tr>
								<td><asp:textbox id="txtInsuredForCost" Runat="server"></asp:textbox></td>
								<td><asp:dropdownlist id="ddlCurrencyCode2" runat="server"></asp:dropdownlist></td>
							</tr>
						</table>
					</td>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td width="50%"><asp:label id="lblPostageInsurePay" Runat="server"><u>C</u>ước phí:</asp:label></td>
								<td><asp:label id="lblUnitMoneyInsurePay" Runat="server">Đơn <u>v</u>ị tiền tệ:</asp:label></td>
							</tr>
							<tr>
								<td><asp:textbox id="txtReturnInsuranceCost" Runat="server"></asp:textbox></td>
								<td><asp:dropdownlist id="ddlCurrencyCode3" runat="server"></asp:dropdownlist></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<asp:label id="lblAddressRepay" Runat="server">Địa c<u>h</u>ỉ phát hoàn:</asp:label>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<asp:dropdownlist id="ddlReturnPhysicalAddress" runat="server"></asp:dropdownlist>&nbsp;
					</td>
				</tr>
				<tr>
					<td class="lbSubFormTitle">
						<asp:label id="lblSendMethod" Runat="server" cssclass="lbSubFormTitle">P<u>h</u>ương thức gửi hàng (vật lý):</asp:label></td>
					<td class="lbSubFormTitle"><asp:label id="lblRegLocal" Runat="server" cssclass="lbSubFormTitle">Đ<u>K</u>CB cục bộ:</asp:label></td>
				</tr>
				<tr>
					<td><asp:dropdownlist id="ddlTransportationModeID" runat="server"></asp:dropdownlist></td>
					<td>
						<asp:textbox id="txtBarcode" Runat="server"></asp:textbox>
					</td>
				</tr>
				<tr class="lbSubFormTitle">
					<td colspan="2"><asp:label id="lblNote" Runat="server" cssclass="lbSubFormTitle" Width="100%">Ghi <u>c</u>hú:</asp:label></td>
				<tr>
					<td colspan="2">
						<asp:textbox id="txtNote" Runat="server" Rows="7" TextMode="MultiLine" Width="100%"></asp:textbox></td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><asp:button id="btnSend" Runat="server" Text="Gửi (g)" Width="70px"></asp:button>
						&nbsp;
						<asp:button id="btnNoSend" Runat="server" Text="Đóng(d)" Width="70px"></asp:button>
					</td>
				</tr>
			</table>
			<input id="hidILLID" type="hidden" runat="server" NAME="hidILLID"> <input id="RequesterID" type="hidden" name="RequesterID" runat="server">
			<input id="RespondDate" type="hidden" name="RespondDate" runat="server">
			<asp:DropDownList Runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
				<asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="1">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="2">Bạn không được quyền truy cập vào chức năng này!</asp:ListItem>
				<asp:ListItem Value="3">Yêu cầu không tồn tại hoặc chưa lựa chọn yêu cầu.</asp:ListItem>
				<asp:ListItem Value="4">Thông điệp được gửi thành công</asp:ListItem>
				<asp:ListItem Value="5">Thông điệp chưa được gửi đi!</asp:ListItem>
				<asp:ListItem Value="6">Lỗi trong quá trình xử lý dữ liệu.</asp:ListItem>
				<asp:ListItem Value="7">Ở trạng thái hiện thời của yêu cầu, không thể thực hiện thao tác này.</asp:ListItem>
				<asp:ListItem Value="8">Ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="9">Giá trị không hợp lệ !</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
