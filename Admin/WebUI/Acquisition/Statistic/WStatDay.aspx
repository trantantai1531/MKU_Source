<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatDay" CodeFile="WStatDay.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatDay</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bgcolor="white" topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0" onload="GenURLImg(7)">
		<form id="Form1" method="post" runat="server">
            <div class="two-column">
                <div class="two-column-form">
                    <div class="row-detail">
                        <table id="StatDay" runat="server" border="0" align="center" width="100%" bgcolor="white">
				            <tr>
					            <td colspan="2"><asp:Label id="lblDAP" runat="server" Width="100%" CssClass="lbGroupTitle"></asp:Label></td>
				            </tr>
				            <tr>
					            <td><IMG alt="" src="/" border="0" name="anh1"></td>
					            <td><IMG alt="" src="/" border="0" name="anh2"></td>
				            </tr>
				            <tr>
					            <td colspan="2"><asp:Label id="lblBAP" runat="server" Width="100%" CssClass="lbGroupTitle"></asp:Label></td>
				            </tr>
				            <tr>
					            <td><IMG alt="" src="/" border="0" name="anh3"></td>
					            <td><IMG alt="" src="/" border="0" name="anh4"></td>
				            </tr>
				            <tr>
					            <td colspan="2"><asp:Label id="lblMoney" runat="server" Width="100%" CssClass="lbGroupTitle"></asp:Label></td>
				            </tr>
				            <tr>
					            <td><IMG alt="" src="/" border="0" name="anh5"></td>
					            <td><IMG alt="" src="/" border="0" name="anh6"></td>
				            </tr>
			            </table>
                    </div>
                </div>
                <div class="two-column-form">
                    <div class="row-detail">
                        <asp:GridView ID="dtgResult" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                            <Columns>
                                <asp:BoundField HeaderText="STT" ItemStyle-HorizontalAlign="Center" DataField="STT" HeaderStyle-Width="5%"/>
                                <asp:BoundField HeaderText="Nhan đề" ItemStyle-HorizontalAlign="Center" DataField="Content"/>
                                <asp:BoundField HeaderText="Tác giả" ItemStyle-HorizontalAlign="Center" DataField="Author"/>
                                <asp:BoundField HeaderText="Nhà XB" ItemStyle-HorizontalAlign="Center" DataField="Publisher"/>
                                <asp:BoundField HeaderText="Năm XB" ItemStyle-HorizontalAlign="Center" DataField="PublishYear"/>
                                <asp:BoundField HeaderText="Ngày" ItemStyle-HorizontalAlign="Center" DataField="Times"/>
                                <asp:BoundField HeaderText="Số lượng" ItemStyle-HorizontalAlign="Center" DataField="Count"/>
                                <asp:BoundField HeaderText="Tổng tiền" ItemStyle-HorizontalAlign="Center" DataField="Total"/>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
			
			<asp:label id="lblDAPTotal" Visible="False" Runat="server">Tổng số đầu ấn phẩm</asp:label><asp:label id="lblDAPHTitle" Visible="False" Runat="server">Các ngày</asp:label><asp:label id="lblDAPVTitle" Visible="False" Runat="server">Số đầu ấn phẩm</asp:label><asp:label id="lblDAPTitle" Visible="False" Runat="server">Tỉ lệ % đầu ấn phẩm theo các ngày</asp:label><asp:label id="lblBAPTotal" Visible="False" Runat="server">Tổng số bản ấn phẩm</asp:label><asp:label id="lblBAPHTitle" Visible="False" Runat="server">Các ngày</asp:label><asp:label id="lblBAPVTitle" Visible="False" Runat="server">Số bản ấn phẩm</asp:label><asp:label id="lblBAPTitle" Visible="False" Runat="server">Tỉ lệ % bản ấn phẩm theo các ngày</asp:label>
			<asp:Label ID="lblVMoney" Runat="server" Visible="False">Mức chi phí đ/v: 1000vnđ</asp:Label>
			<asp:Label ID="lblHMoney" Runat="server" Visible="False">Các ngày</asp:Label>
			<asp:Label ID="lblTMoney" Runat="server" Visible="False">Tỉ lệ % mức chi phí giữa các ngày </asp:Label>
			<asp:Label ID="lblInMonth" Runat="server" Visible="False"> trong tháng </asp:Label>
			<asp:Label ID="lblInYear" Runat="server" Visible="False"> trong năm </asp:Label>
			<asp:Label ID="lblInday" Runat="server" Visible="False">Ngày</asp:Label>
			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="MainLog">Thống kê theo các ngày bổ sung</asp:ListItem>
				<asp:ListItem Value="ErrorMsg">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="ErrorCode">Mã lỗi </asp:ListItem>
			</asp:DropDownList>
            
            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">Nhan đề</asp:ListItem>
                <asp:ListItem Value="2">Tác giả</asp:ListItem>
                <asp:ListItem Value="3">Nhà XB</asp:ListItem>
                <asp:ListItem Value="4">Năm XB</asp:ListItem>
                <asp:ListItem Value="5">Ngày</asp:ListItem>
                <asp:ListItem Value="6">Số lượng</asp:ListItem>
                <asp:ListItem Value="7">Tổng tiền</asp:ListItem>
            </asp:DropDownList>
		</form>
	</body>
</HTML>
