<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatPublishYear.aspx.vb" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatPublishYear" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatYear</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bgColor="white" leftMargin="0" topMargin="0" onload="GenURLImg(7);" rightMargin="0">
		<form id="Form1" method="post" runat="server">
            <div class="row-detail">
                <div class="span1">
                    <div class="row-detail">
                        <p>Từ năm</p>
                        <asp:TextBox ID="txtYearStart" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="span1">
                    <div class="row-detail">
                        <p>Đến năm</p>
                        <asp:TextBox ID="txtYearEnd" CssClass="" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="span8">
                    <div class="row-detail">
                        <p>&nbsp</p>
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button CssClass="form-btn" ID="btnExportData" runat="server" Text="Thống kê"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button CssClass="form-btn" ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:button id="btnClose" runat="server" CssClass="lbButton" Text="Đóng(g)" Width="62px"></asp:button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="two-column">
                <div class="two-column-form">
                    <div class="row-detail">
                        <table id="StatisticItemType" height="100%" width="100%" align="center" border="0" bgcolor="white">
				            <tr>
					            <td colSpan="2"><asp:label id="lblDAP" runat="server" CssClass="lbPageTitle" Width="100%"></asp:label></td>
				            </tr>
				            <tr>
					            <td><IMG src="/" alt="" useMap="#map1" border="0" name="anh1"></td>
					            <td><IMG src="/" alt="" border="0" name="anh2"></td>
				            </tr>
				            <tr>
					            <td colSpan="2"><asp:label id="lblBAP" runat="server"  CssClass="lbGroupTitle" Width="100%"></asp:label></td>
				            </tr>
				            <tr>
					            <td><IMG alt="" src="/" useMap="#map2" border="0" name="anh3"></td>
					            <td><IMG alt="" src="/" border="0" name="anh4"></td>
				            </tr>
				            <tr>
					            <td colSpan="2"><asp:label id="lblMoney" runat="server"  CssClass="lbGroupTitle" Width="100%"></asp:label></td>
				            </tr>
				            <tr>
					            <td><IMG alt="" src="/" useMap="#map3" border="0" name="anh5"></td>
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
                                <asp:BoundField HeaderText="Năm" ItemStyle-HorizontalAlign="Center" DataField="Times"/>
                                <asp:BoundField HeaderText="Số lượng" ItemStyle-HorizontalAlign="Center" DataField="Count"/>
                                <asp:BoundField HeaderText="Tổng tiền" ItemStyle-HorizontalAlign="Center" DataField="Total"/>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
			
            <asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
                <asp:ListItem Value="0">Tổng số đầu ấn phẩm</asp:ListItem>
				<asp:ListItem Value="1">Năm xuất bản</asp:ListItem>
				<asp:ListItem Value="2">Số đầu ấn phẩm</asp:ListItem>
				<asp:ListItem Value="3">Tỉ lệ % năm xuất bản của ấn phẩm</asp:ListItem>
				<asp:ListItem Value="4">Tổng số bản ấn phẩm</asp:ListItem>
				<asp:ListItem Value="5">Năm xuất bản</asp:ListItem>
				<asp:ListItem Value="6">Số bản ấn phẩm</asp:ListItem>
				<asp:ListItem Value="7">Tỉ lệ % năm xuất bản của ấn phẩm</asp:ListItem>
				<asp:ListItem Value="8">Mức chi phí đ/v: 1000vnđ</asp:ListItem>
				<asp:ListItem Value="9">Năm</asp:ListItem>
				<asp:ListItem Value="10">Tỉ lệ % mức chi phí giữa các năm</asp:ListItem>
				<asp:ListItem Value="11">Năm</asp:ListItem>
				<asp:ListItem Value="12">Tổng chi phí bổ sung bản ấn phẩm</asp:ListItem>
            </asp:DropDownList>
			<asp:label id="lblDAPTotal" Visible="False" Runat="server">Tổng số đầu ấn phẩm</asp:label>
            <asp:label id="lblDAPHTitle" Visible="False" Runat="server">Năm xuất bản</asp:label>
            <asp:label id="lblDAPVTitle" Visible="False" Runat="server">Số đầu ấn phẩm</asp:label>
            <asp:label id="lblDAPTitle" Visible="False" Runat="server">Tỉ lệ % năm xuất bản của ấn phẩm</asp:label>
            <asp:label id="lblBAPTotal" Visible="False" Runat="server">Tổng số bản ấn phẩm</asp:label>
            <asp:label id="lblBAPHTitle" Visible="False" Runat="server">Năm xuất bản</asp:label>
            <asp:label id="lblBAPVTitle" Visible="False" Runat="server">Số bản ấn phẩm</asp:label>
            <asp:label id="lblBAPTitle" Visible="False" Runat="server">Tỉ lệ % năm xuất bản của ấn phẩm</asp:label>
            <asp:label id="lblCAPToal" Visible="False" Runat="server">Tổng chi phí bổ sung bản ấn phẩm</asp:label>
			<asp:Label ID="lblVMoney" Runat="server" Visible="False">Mức chi phí đ/v: 1000vnđ</asp:Label>
			<asp:Label ID="lblHMoney" Runat="server" Visible="False">Năm</asp:Label>
			<asp:Label ID="lblTMoney" Runat="server" Visible="False">Tỉ lệ % mức chi phí giữa các năm</asp:Label>
			<asp:Label ID="lblInYear" Runat="server" Visible="False">Năm</asp:Label>
			<asp:DropDownList ID="ddlLog" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Thống kê theo năm xuất bản</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="2">Mã lỗi </asp:ListItem>
			</asp:DropDownList>
            
            <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">Nhan đề</asp:ListItem>
                <asp:ListItem Value="2">Tác giả</asp:ListItem>
                <asp:ListItem Value="3">Nhà XB</asp:ListItem>
                <asp:ListItem Value="4">Năm XB</asp:ListItem>
                <asp:ListItem Value="5">Năm</asp:ListItem>
                <asp:ListItem Value="6">Số lượng</asp:ListItem>
                <asp:ListItem Value="7">Tổng tiền</asp:ListItem>
            </asp:DropDownList>
		</form>
	</body>
</HTML>