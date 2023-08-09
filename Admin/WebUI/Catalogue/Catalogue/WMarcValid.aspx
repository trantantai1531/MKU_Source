<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcValid" EnableViewState="False" EnableViewStateMAC="False" CodeFile="WMarcValid.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>Emiclib - Kiểm tra hợp lệ MARC</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
		<asp:DropDownList ID="ddlLabel" Runat="server" Width="0" Visible="False">
			<asp:ListItem Value="0">Emiclib - Kiểm tra hợp lệ MARC</asp:ListItem>
			<asp:ListItem Value="1">Bản ghi hợp lệ</asp:ListItem>
			<asp:ListItem Value="2">Bản ghi không hợp lệ</asp:ListItem>
			<asp:ListItem Value="3">Bắt buộc</asp:ListItem>
			<asp:ListItem Value="4">Không phải trường lặp</asp:ListItem>
			<asp:ListItem Value="5">Trường con không tồn tại: </asp:ListItem>
			<asp:ListItem Value="6">Không tồn tại</asp:ListItem>
			<asp:ListItem Value="7">Vị trí chỉ định dữ liệu thứ nhất không hợp lệ.</asp:ListItem>
			<asp:ListItem Value="8">Vị trí chỉ định dữ liệu thứ hai không hợp lệ.</asp:ListItem>
			<asp:ListItem Value="9">Độ dài dữ liệu không đúng</asp:ListItem>
			<asp:ListItem Value="10">Dữ liệu vị trí thứ</asp:ListItem>
			<asp:ListItem Value="11">không hợp lệ</asp:ListItem>
			<asp:ListItem Value="12">Cả hai vị trí chỉ định dữ liệu không hợp lệ.</asp:ListItem>
			<asp:ListItem Value="13">Mã lỗi</asp:ListItem>
			<asp:ListItem Value="14">Chi tiết lỗi</asp:ListItem>
			<asp:ListItem Value="15">Lỗi trong quá trình xử lý</asp:ListItem>
			<asp:ListItem Value="16">Độ dài không đủ 16 ký tự</asp:ListItem>
			<asp:ListItem Value="17">Năm không hợp lệ</asp:ListItem>
			<asp:ListItem Value="18">Tháng không hợp lệ</asp:ListItem>
			<asp:ListItem Value="19">Ngày không hợp lệ</asp:ListItem>
			<asp:ListItem Value="20">Giờ không hợp lệ</asp:ListItem>
			<asp:ListItem Value="21">Phút không hợp lệ</asp:ListItem>
			<asp:ListItem Value="22">Giây không hợp lệ</asp:ListItem>
			<asp:ListItem Value="23">Phần trăm giây không hợp lệ</asp:ListItem>
			<asp:ListItem Value="24">Thế kỷ không hợp lệ</asp:ListItem>
		</asp:DropDownList>
    </form>
  </body>
</html>
