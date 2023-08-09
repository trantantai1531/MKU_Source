<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WFindField.aspx.vb" Inherits=".WFindField"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>WFindField</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </head>
  <body MS_POSITIONING="GridLayout">
    <form id="Form1" method="post" runat="server">
		<asp:Label Runat="server" ID="lblTemp1">Màn hình lựa chọn tiêu chí muốn tìm.</asp:Label>
		<P>
			<asp:Label Runat="server" ID="lblTemp2">Bạn đã lựa chọn tìm trên mọi tư liệu thư viện. Để lựa chọn dạng tư liệu hoặc 
dịch vụ khác bấm phím *.</asp:Label>
		</P>
		<P>
			<asp:Label Runat="server" ID="lblTemp3">Bạn có thể lựa chọn một trong các thông tin thư mục của ấn phẩm để tiến hành tìm 
kiếm.</asp:Label>
		</P>
		<P>
			<asp:Label Runat="server" ID="lblTemp4">Tìm theo mọi trường bấm phím 1.</asp:Label><br>
			<asp:Label Runat="server" ID="lblTemp5">Tìm theo nhan đề bấm phím 2.</asp:Label><br>
			<asp:Label Runat="server" ID="lblTemp6">Tìm theo tên tác giả bấm phím 3.</asp:Label><br>
			<asp:Label Runat="server" ID="lblTemp7">Tìm theo từ khóa bấm phím 4.</asp:Label><br>
			<asp:Label Runat="server" ID="lblTemp8">Tìm theo chủ đề bấm phím 5.</asp:Label>
		</P>
    </form>
  </body>
</html>
