<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WProcReceive" CodeFile="WProcReceive.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WProcReceive</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
		<script language="javascript">
		function Previous(Direction,LibID,LocID,Shelf){			
			parent.process.document.forms(0).action='WProcReceive.aspx?Direction='+Direction+'&LibID='+LibID+'&LocID='+LocID+'&Shelf='+Shelf;
			parent.process.document.forms[0].submit()
			return(false);
		}
		function Next(Direction,LibID,LocID,Shelf){		
			parent.process.document.forms(0).action='WProcReceive.aspx?Direction='+Direction+'&LibID='+LibID+'&LocID='+LocID+'&Shelf='+Shelf;
			parent.process.document.forms[0].submit()
			
			return(false);
		}
		function Received(){
			alert('Received');
			return(false);
		}
		function ReceivedAndUnlock(){
			alert('ReceivedAndUnlock');
			return(false);
		}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="2" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0">
				<TR>
					<TD><asp:label id="lblHeader" runat="server" CssClass="lbPageTitle" Width="100%">Số liệu xếp giá chưa kiểm nhận nhập kho </asp:label></TD>
				</TR>
				<TR>
					<TD><asp:label id="lblCapLib" runat="server" Font-Bold="True">Thư viện:</asp:label>&nbsp;<asp:label id="lblLib" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id="lblCapLoc" runat="server" Font-Bold="True">Kho:</asp:label>&nbsp;<asp:label id="lblLoc" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label>&nbsp;&nbsp;&nbsp;
						<asp:label id="lblCapShelf" runat="server" Font-Bold="True">Giá sách:</asp:label>&nbsp;<asp:label id="lblShelf" runat="server" Font-Bold="True" ForeColor="Maroon"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<table width="100%" border="0">
							<TR>
								<TD><asp:label id="lblDes" runat="server">Đánh dấu những tư liệu muốn kiểm nhận và bấm nút "Kiểm nhận" hoặc "Kiểm nhận/Mở 
khóa". Bạn có thể quy định lại vị trí xếp giá của các ấn phẩm được kiểm nhận cho 
phù hợp với thực tế trong kho</asp:label>&nbsp;</TD>
							</TR>
							<TR>
								<TD>
									<P><asp:radiobutton id="optOld" runat="server" Text="Xếp vào vị trí chỉ ra hiện thờ<u>i</u>" Checked="True"
											GroupName="optShelf"></asp:radiobutton></P>
								</TD>
							</TR>
							<TR>
								<TD><asp:radiobutton id="optNew" runat="server" Text="Xếp vào vị trí sa<u>u</u>:" GroupName="optShelf"></asp:radiobutton></TD>
							</TR>
							<TR>
								<TD><asp:label id="lblLibInput" runat="server"><u>T</u>hư viện:</asp:label><asp:dropdownlist id="ddlLib" runat="server" AutoPostBack="True"></asp:dropdownlist>&nbsp;<asp:label id="lblLocation" runat="server"><u>K</u>ho:</asp:label><asp:dropdownlist id="ddlLocation" runat="server"></asp:dropdownlist>&nbsp;<asp:label id="lblShelfInput" runat="server"><u>G</u>iá sách:</asp:label><asp:textbox id="txtShelf" runat="server" Width="96px"></asp:textbox></TD>
							</TR>
						</table>
						<asp:hyperlink id="lnkCheckAll" runat="server" CssClass="lbLinkFunction">Chọn tất </asp:hyperlink>&nbsp;
						<asp:hyperlink id="lnkUnCheckAll" runat="server" CssClass="lbLinkFunction">Bỏ tất </asp:hyperlink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
				</TR>
				<tr>
					<td><asp:datagrid id="dtgResult" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							PageSize="20">
							<Columns>
								<asp:TemplateColumn HeaderText="Trạng th&#225;i">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox id="chkCopyID" runat="server" Visible='<%#Not DataBinder.Eval(Container.dataItem,"InUsed") %>'>
										</asp:CheckBox>
										<asp:label id="lblCopyID" text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' Runat="server" Visible="False">
										</asp:label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="CopyNumber" HeaderText="ĐKCB"></asp:BoundColumn>
								<asp:BoundColumn DataField="CallNumber" HeaderText="Số định danh"></asp:BoundColumn>
								<asp:BoundColumn DataField="Volume" HeaderText="Tập"></asp:BoundColumn>
								<asp:BoundColumn DataField="CONTENT" HeaderText="Th&#244;ng tin chi tiết"></asp:BoundColumn>
								<asp:BoundColumn DataField="ACQUIREDDATE" HeaderText="Ng&#224;y bổ sung">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Price" HeaderText="Gi&#225; tiền">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Note" HeaderText="Ghi ch&#250;"></asp:BoundColumn>
							</Columns>
							<PagerStyle PageButtonCount="20" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<tr>
					<td>
					</td>
				</tr>
			</table>
			<asp:dropdownlist id="ddlLabel" Width="0" Runat="server" Visible="False">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Kiểm nhận thành công!</asp:ListItem>
				<asp:ListItem Value="3">Kiểm nhận và mở khoá thành công!</asp:ListItem>
				<asp:ListItem Value="4">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
				<asp:ListItem Value="5">Kiểm nhận đăng ký cá biệt</asp:ListItem>
				<asp:ListItem Value="6">Kiểm nhận đăng ký cá biệt và mở khoá</asp:ListItem>
				<asp:ListItem Value="7">Không tìm thấy dữ liệu</asp:ListItem>
			</asp:dropdownlist><input id="txtAction" type="hidden" name="txtAction" runat="server">&nbsp;
			<input id="hidCountID" type="hidden" value="0" name="hidCountID" runat="server">
			<input id="hidNextID" type="hidden" value="0" runat="server"> <input id="hidPreviousID" type="hidden" value="0" runat="server">
			<input type="hidden" id="hidIndexChanged" runat="server" value="0">
		</form>
	</body>
</HTML>
