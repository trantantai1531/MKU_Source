<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WShowResult.aspx.vb" Inherits="WShowResult"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WShowResult</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label Runat="server" ID="lblTemp1">Màn hình kết quả tìm kiếm</asp:Label><br>
			<asp:Label Runat="server" ID="lblTemp2">Tìm cụm từ</asp:Label>
			<asp:Label Runat="server" ID="lblSearchData"></asp:Label>&nbsp;
			<asp:Label Runat="server" ID="lblTemp3">trong</asp:Label>&nbsp;
			<asp:Label Runat="server" ID="lblSearchField"></asp:Label>&nbsp;
			<asp:Label Runat="server" ID="lblTemp4">của</asp:Label>&nbsp;
			<asp:Label Runat="server" ID="lblItemType"></asp:Label>.<br>
			<asp:Label Runat="server" ID="lblTemp5">Tìm thấy</asp:Label>&nbsp;
			<asp:Label Runat="server" ID="lblAmount"></asp:Label>&nbsp;
			<asp:Label Runat="server" ID="lblTemp6">ấn phẩm.</asp:Label><br>
			<asp:Label Runat="server" ID="lblTemp7">Hiện bạn đang mở bản ghi thứ</asp:Label>&nbsp;
			<asp:Label Runat="server" ID="lblCurPos"></asp:Label>&nbsp;
			<asp:Label Runat="server" ID="lblTemp8">trong số</asp:Label>&nbsp;
			<asp:Label Runat="server" ID="lblTotal"></asp:Label>&nbsp;
			<asp:Label Runat="server" ID="lblTemp9">bản ghi tìm được.</asp:Label><BR>
			<asp:Label Runat="server" ID="lblTemp10">Bạn có thể bấm các phím từ 1 đến 9 để chuyển thẳng tới một trong chín bản ghi đầu tiên</asp:Label>
			<P>
				<asp:Label Runat="server" ID="lblTemp11">Ấn phẩm thứ</asp:Label>&nbsp;
				<asp:Label Runat="server" ID="lblPosition"></asp:Label>&nbsp;
				<asp:Label Runat="server" ID="lblTemp12">có tác giả chính là</asp:Label>&nbsp;
				<asp:Label Runat="server" ID="lblAuthor"></asp:Label>
				<asp:Label Runat="server" ID="lblTemp13">Tác giả tập thể chính là</asp:Label>&nbsp;
				<asp:Label Runat="server" ID="lblGroupAuthor"></asp:Label>
				<asp:Label Runat="server" ID="lblTemp14">Nhan đề là</asp:Label>&nbsp;
				<asp:Label Runat="server" ID="lblTitle"></asp:Label>
				<asp:Label Runat="server" ID="lblTemp15">Lần xuất bản:</asp:Label>&nbsp;
				<asp:Label Runat="server" ID="lblEdition"></asp:Label>
				<asp:Label Runat="server" ID="lblTemp16">Xuất bản:</asp:Label>&nbsp;
				<asp:Label Runat="server" ID="lblPublisher"></asp:Label>
				<asp:Label Runat="server" ID="lblTemp17">Vật mang tin:</asp:Label>&nbsp;
				<asp:Label Runat="server" ID="lblMediumType"></asp:Label>
				<asp:Label Runat="server" ID="lblTemp18">Đăng ký cá biệt:</asp:Label>&nbsp;
				<asp:Label Runat="server" ID="lblCopyNumber"></asp:Label>		
			</P>
			<P>
				<asp:Label Runat="server" ID="lblTemp19">Mở bản ghi trước bấm phím p. Mở bản ghi tiếp bấm phím n. Để thực hiện yêu cầu 
tìm kiếm khác bấm phím *</asp:Label>
			</P>
		</form>
	</body>
</HTML>
