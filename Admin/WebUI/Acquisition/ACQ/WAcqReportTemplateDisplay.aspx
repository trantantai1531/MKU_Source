<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WAcqReportTemplateDisplay" CodeFile="WAcqReportTemplateDisplay.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WAcqReportTemlateDisplay</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
		<script language="JavaScript" src="../Js/ACQ/picker.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="Request" width="100%" border="0">
				<TBODY>
					<tr>
						<td colSpan="7"><asp:label id="lblMainTitle" Width="100%" Runat="server" cssclass="main-head-form">Soạn thảo mẫu in báo cáo bổ sung</asp:label></td>
					</tr>
					<tr>
                    <td align="right"><asp:label id="lblPickForm" Runat="server">Chọn <u>m</u>ẫu: </asp:label></td>
						<td width="65%" align="left" colSpan="5"><asp:dropdownlist id="ddlID" Runat="server"></asp:dropdownlist></td>
						<td width="5%"></td>
					</tr>
					<tr>
						<td width="8%" align="right"><asp:label id="lblCaption" Runat="server">Tê<u>n</u> mẫu: </asp:label></td>
						<td colSpan="4"><asp:textbox id="txtCaption" Width="95%" Runat="server"></asp:textbox>&nbsp;<asp:label id="lblMan" Runat="server" Font-Bold="True" ForeColor="Red" Tooltip="Trường bắt buộc phải nhập dữ liệu">(*)</asp:label></td>
						<td colSpan="2" rowSpan="1"><INPUT id="txtCollum" type="hidden" name="txtCollum" runat="server"></td>
					</tr>
					<tr class="lbGroupTitle">
						<td colSpan="7" class="lbGroupTitle"><asp:label id="lblHeader" Width="100%" Runat="server" CssClass="lbSubTitle">Phần đầu của báo cáo</asp:label></td>
					</tr>
					<tr>
						<td colSpan="1"></td>
						<td width="85%" colSpan="5"><asp:textbox id="txtHeader" Width="100%" style="border: 1px solid #999999;" Runat="server" Wrap="true" TextMode="MultiLine" Height="60px"></asp:textbox></td>
						<td width="5%" colSpan="1"></td>
					</tr>
					<tr>
						<td align="right" colSpan="1"><asp:label id="lblPageHeader" Runat="server">Đầ<u>u</u> trang:</asp:label></td>
						<td colSpan="5"><asp:textbox id="txtPageHeader" Width="100%" Runat="server"></asp:textbox></td>
						<td colSpan="1"></td>
					</tr>
					<tr>
						<td class="lbGroupTitle" colSpan="7"><asp:label id="lblList" Width="100%" Runat="server" CssClass="lbSubTitle">Phần thân của báo cáo</asp:label></td>
					</tr>
					<TR>
						<td colSpan="1"><asp:listbox id="lsbTemp" Width="0" Runat="server" Height="0" style="display: none">
								<asp:ListItem Value="<$SEQUENCY$>">Số thứ tự</asp:ListItem>
								<asp:ListItem Value="<$DKCB$>">Đăng ký cá biệt</asp:ListItem>
								<asp:ListItem Value="<$TITLE$>">Nhan đề</asp:ListItem>
								<asp:ListItem Value="<$PLACE$>">Địa điểm xuất bản</asp:ListItem>
								<asp:ListItem Value="<$YEAR$>">Năm xuất bản</asp:ListItem>
								<asp:ListItem Value="<$ISSUEPRICE$>">Đơn giá</asp:ListItem>
								<asp:ListItem Value="<$ACQUISITIONDATE$>">Ngày bổ sung</asp:ListItem>
								<asp:ListItem Value="<$NOTE$>">Ghi chú</asp:ListItem>
                                <asp:ListItem Value="<$ISBN$>">ISBN</asp:ListItem>
                                <asp:ListItem Value="<$SOHD$>">Số HĐ</asp:ListItem>
                                <asp:ListItem Value="<$AUTHOR$>">Tác giả</asp:ListItem>
                                <asp:ListItem Value="<$DDC$>">Mã phân loại DDC</asp:ListItem>
							</asp:listbox></td>
						<TD colSpan="5">
							<table cellSpacing="0" width="100%">
								<tr>
									<td align="center"><asp:label id="lblAllCollums" Width="100%" Runat="server">Cột <u>k</u>hông hiển thị</asp:label></td>
									<td width="7%"></td>
									<td align="center" width="20%"><asp:label id="lblCollum" Width="100%" Runat="server">Cột <u>h</u>iển thị</asp:label></td>
									<td align="center" width="12%"><asp:label id="lblCollumCaption" Width="100%" Runat="server">Tên hiển <u>t</u>hị</asp:label></td>
									<td align="center" width="10%"><asp:label id="lblCollumWidth" Width="100%" Runat="server">Độ <u>r</u>ộng</asp:label>
									<td align="center" width="10%"><asp:label id="lblAlign" Runat="server">Căn <u>l</u>ề</asp:label></td>
									<td align="center"><asp:label id="lblFormat" Runat="server">Đinh dạn<u>g</u></asp:label></td>
								</tr>
								<tr>
									<td align="right" width="20%"><asp:listbox id="lsbAllCollums" Width="100%" Runat="server" Height="140px" SelectionMode="Multiple"
											Rows="5">
											<asp:ListItem Value="&lt;$SEQUENCY$&gt;">Số thứ tự</asp:ListItem>
											<asp:ListItem Value="&lt;$DKCB$&gt;">Đăng ký cá biệt</asp:ListItem>
											<asp:ListItem Value="&lt;$TITLE$&gt;">Nhan đề</asp:ListItem>
											<asp:ListItem Value="&lt;$PLACE$&gt;">Địa điểm xuất bản</asp:ListItem>
											<asp:ListItem Value="&lt;$YEAR$&gt;">Năm xuất bản</asp:ListItem>
											<asp:ListItem Value="&lt;$ISSUEPRICE$&gt;">Đơn giá</asp:ListItem>
											<asp:ListItem Value="&lt;$ACQUISITIONDATE$&gt;">Ngày bổ sung</asp:ListItem>
											<asp:ListItem Value="&lt;$NOTE$&gt;">Ghi chú</asp:ListItem>
                                            <asp:ListItem Value="&lt;$ISBN$&gt;">ISBN</asp:ListItem>
                                            <asp:ListItem Value="&lt;$SOHD$&gt;">Số HĐ</asp:ListItem>
                                            <asp:ListItem Value="&lt;$AUTHOR$&gt;">Tác giả</asp:ListItem>
                                            <asp:ListItem Value="&lt;$DDC$&gt;">Mã phân loại DDC</asp:ListItem>
										</asp:listbox></td>
									<td width="7%">
										<table cellSpacing="0" cellPadding="0" width="100%">
											<tr>
												<td><asp:button id="btnAdd" Width="100%" style="margin-bottom: 5px;" Runat="server" Text=">>"></asp:button></td>
											</tr>
											<tr>
												<td><asp:button id="btnRemove" Width="100%" Runat="server" Text="<<"></asp:button></td>
											</tr>
										</table>
									</td>
									<td width="20%"><asp:listbox id="lsbCollum" Width="100%" Runat="server" Height="140px" SelectionMode="Multiple"
											Rows="5"></asp:listbox></td>
									<td width="20%" vAlign="top"><asp:textbox id="txtCollumCaption" Width="100%" Runat="server" cssclass="lbtextarea" Wrap="False"
											TextMode="MultiLine" Height="140px" Rows="6" Columns="6"></asp:textbox></td>
									<td width="9%" vAlign="top" colSpan="1" rowSpan="1"><asp:textbox id="txtCollumWidth" Width="100%" Runat="server" cssclass="lbtextarea" Wrap="false"
											TextMode="MultiLine" Height="140px" Rows="6" Columns="6"></asp:textbox></td>
									<td width="10%" vAlign="top" colSpan="1" rowSpan="1"><asp:textbox id="txtAlign" Width="100%" Runat="server" cssclass="lbtextarea" Wrap="False" TextMode="MultiLine"
											Height="140px"></asp:textbox></td>
									<td width="25%" vAlign="top"><asp:textbox id="txtFormat" Width="100%" Runat="server" cssclass="lbtextarea" Wrap="False" TextMode="MultiLine"
											Height="140px" Rows="6" Columns="6"></asp:textbox></td>
								</tr>
							</table>
						</TD>
					</TR>
				</TBODY>
				<tr>
					<td colSpan="1"></td>
					<td colSpan="5" align="center"><asp:label id="lblTableColor" Runat="server">Màu b<u>ả</u>ng: </asp:label><asp:textbox id="txtTableColor" Width="60" Runat="server" MaxLength="7">12</asp:textbox>
                        <asp:hyperlink id="lnkTableColor" runat="server" NavigateUrl="javascript:TCP.popup(document.forms[0].elements['txtTableColor'], 1)"> Chọn</asp:hyperlink>&nbsp;&nbsp;&nbsp;
                        <asp:label id="lblOddColor" Runat="server">Màu hàng l<u>ẻ</u>: </asp:label>
                        <asp:textbox id="txtOddColor" Width="60" Runat="server" MaxLength="7">

                        </asp:textbox><asp:hyperlink id="lnkColorChan" runat="server" NavigateUrl="javascript:TCP.popup(document.forms[0].elements['txtOddColor'], 1)"> Chọn</asp:hyperlink>
                        &nbsp;&nbsp;&nbsp;
						<asp:label id="lblEventColor" Runat="server">Màu hàng ch<u>ẵ</u>n: </asp:label>
                        <asp:textbox id="txtEventColor" Width="60" Runat="server" MaxLength="7"></asp:textbox>
                        <asp:hyperlink id="lnkColorLe" runat="server" NavigateUrl="javascript:TCP.popup(document.forms[0].elements['txtEventColor'], 1)"> Chọn</asp:hyperlink>

					</td>
					<td colSpan="1"></td>
				</tr>
				<tr>
					<td align="right" colSpan="1"><asp:label id="lblPageFooter" Runat="server">Cuối tra<u>n</u>g: </asp:label></td>
					<td colSpan="5"><asp:textbox id="txtPageFooter" Width="100%" Runat="server"></asp:textbox></td>
					<td colSpan="1"></td>
				</tr>
				<tr>
					<td class="lbGroupTitle" colSpan="7"><asp:label id="lblFoter" Width="100%" Runat="server" CssClass="lbSubTitle">Cuối đơn</asp:label></td>
				</tr>
				<tr>
					<td colSpan="1"></td>
					<td width="80%" colSpan="5"><asp:textbox id="txtFooter"  style="border: 1px solid #999999;" Width="100%" Runat="server" Wrap="true" TextMode="MultiLine" Height="60px"></asp:textbox></td>
					<td rowSpan="1"></td>
				</tr>
				<tr>
					<td class="lbControlBar" align="center" colSpan="7"><asp:button id="btnUpdate" Runat="server" Text="Cập nhật(c)"></asp:button>&nbsp;<asp:button id="btnPreview" Runat="server" Text="Xem trước(t)"></asp:button>&nbsp;<asp:button id="btnDelete" Runat="server" Text="Xoá (x)"></asp:button></td>
				</tr>
			</table>
			<input id="hdMax" type="hidden" name="hdMax" runat="server"> <input id="hdCollumCaptionText" type="hidden" name="hdCollumCaptionText" runat="server">
			<asp:dropdownlist id="ddlLabel" Width="0" Runat="server" Height="0" Visible="False">
				<asp:ListItem Value="0">Tạo mới mẫu báo cáo bổ sung</asp:ListItem>
				<asp:ListItem Value="1">Cập nhật mẫu báo cáo bổ sung</asp:ListItem>
				<asp:ListItem Value="2">Xoá mẫu báo cáo bổ sung</asp:ListItem>
				<asp:ListItem Value="3">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="4">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="5">------Tạo mới------</asp:ListItem>
				<asp:ListItem Value="6">Nhấn OK nếu thực sự muốn xoá mẫu này!</asp:ListItem>
				<asp:ListItem Value="7">Tên mẫu là bắt buộc!</asp:ListItem>
				<asp:ListItem Value="8">Cập nhật thành công!</asp:ListItem>
				<asp:ListItem Value="9">Cập nhật không thành công!</asp:ListItem>
				<asp:ListItem Value="10">Bạn chưa nhập đủ thông tin cần thiết!</asp:ListItem>
				<asp:ListItem Value="11">Bạn chưa chọn khuôn dạng báo cáo!</asp:ListItem>
				<asp:ListItem Value="12">Xoá thành công !</asp:ListItem>
			</asp:dropdownlist></form>
			<script language = javascript>
				document.forms[0].txtCaption.focus();
			</script>
	</body>
</HTML>
