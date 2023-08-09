<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WACQIntroduction" CodeFile="WACQIntroduction.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WACQIntroduction</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:HyperLink id="HyperLink1" style="Z-INDEX: 100; LEFT: 40px; POSITION: absolute; TOP: 312px"
				runat="server" Width="136px" Height="24px" NavigateUrl="acq\WCataForm.aspx">Biem muc so luoc</asp:HyperLink>
			<asp:HyperLink id="HyperLink28" style="Z-INDEX: 113; LEFT: 360px; POSITION: absolute; TOP: 288px"
				runat="server" NavigateUrl="Accounting/WAccountingIndex.aspx" Height="32px" Width="104px">Tài chính</asp:HyperLink>
			<asp:HyperLink id="HyperLink25" style="Z-INDEX: 111; LEFT: 32px; POSITION: absolute; TOP: 264px"
				runat="server" NavigateUrl="Location/WLostFrame.aspx" Height="24px" Width="176px">Xep gia da thanh ly/mat</asp:HyperLink>
			<asp:HyperLink id="HyperLink24" style="Z-INDEX: 110; LEFT: 32px; POSITION: absolute; TOP: 216px"
				runat="server" NavigateUrl="Location/WReceiveFrame.aspx" Height="24px" Width="168px">Xep gia chua kiem nhan</asp:HyperLink>
			<asp:HyperLink id="HyperLink23" style="Z-INDEX: 109; LEFT: 32px; POSITION: absolute; TOP: 168px"
				runat="server" NavigateUrl="Location/WInvenFrame.aspx" Height="24px" Width="136px">Xep gia trong kho</asp:HyperLink>
			<asp:HyperLink id="HyperLink2" style="Z-INDEX: 101; LEFT: 536px; POSITION: absolute; TOP: 248px"
				runat="server" Width="136px" Height="24px" NavigateUrl="acq\WCopyNumber.aspx">Xep gia</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink3" runat="server" NavigateUrl="Acq/WCopyNumberTemplate.aspx">Tạo mẫu đăng ký cá biệt</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink4" runat="server" NavigateUrl="Acq/WBookLabelTemplateDisplay.aspx">Tạo mẫu in nhãn gáy nhãn bìa</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink5" runat="server" NavigateUrl="Acq/WAcqReportTemplateDisplay.aspx">Tạo mẫu in báo cáo bổ sung</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink7" runat="server" NavigateUrl="Acq/WLabelPrintSearch.aspx">In nhãn gáy nhãn bìa</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink8" runat="server" NavigateUrl="Acq/WBarcodeForm.aspx">In mã vạch</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink10" runat="server" NavigateUrl="Acq/WACQForm.aspx">In báo cáo bổ sung</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink11" runat="server" NavigateUrl="Acq/WCopyNumRemF.aspx">In báo cáo đăng ký cá biệt huỷ</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink16" runat="server" NavigateUrl="PO/WPOTemplate.aspx?TemplateType=9">Soạn thảo mẫu đơn yêu cầu ấn phẩm</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink17" runat="server" NavigateUrl="PO/WPOTemplate.aspx?TemplateType=7">Soạn thảo mẫu đơn đặt</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink18" runat="server" NavigateUrl="PO/WPOTemplate.aspx?TemplateType=8">Soạn thảo mẫu đơn khiếu nại</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink19" runat="server" NavigateUrl="PO/WPOTemplate.aspx?TemplateType=10">Soạn thảo mẫu đơn phân kho</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink20" runat="server" NavigateUrl="PO/WViewItemOrder.aspx">Duyệt yêu cầu đặt mua ấn phẩm</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink21" runat="server" NavigateUrl="PO/WPOPrintSearch.aspx">In danh sách các yêu cầu bổ sung</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink22" runat="server" NavigateUrl="PO/WSendPOSearch.aspx">Gửi đơn đặt</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink26" runat="server" NavigateUrl="PO/WSendPOSeperatedSearch.aspx">Báo cáo phân kho</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink29" runat="server" NavigateUrl="PO/WSendPOSeperatedSearch.aspx?POID=1">Báo cáo phân kho có POID</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink30" runat="server" NavigateUrl="PO/WViewDetailPObyVendor.aspx?VendorID=1">Xem chi tiết về đơn đặt khi đã biết nhà cung cấp</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink31" runat="server" NavigateUrl="PO/WContractPickItems.aspx?POID=1&amp;TypeID=1">Thêm ấn phẩm vào một đơn đặt</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink32" runat="server" NavigateUrl="PO/WPOChangeStatus.aspx?POID=1&amp;StatusID=1">Thay đổi trạng thái của đơn đặt</asp:HyperLink>&nbsp;
			<asp:HyperLink id="Hyperlink33" runat="server" NavigateUrl="PO/WCheckingReceived.aspx?POID=3">Kiểm nhận</asp:HyperLink>&nbsp;
			<asp:HyperLink id="HyperLink6" style="Z-INDEX: 102; LEFT: 416px; POSITION: absolute; TOP: 240px"
				runat="server" NavigateUrl="Location/WMoveLoc.aspx" Height="32px" Width="104px">Chuyen kho</asp:HyperLink>
			<asp:HyperLink id="HyperLink9" style="Z-INDEX: 104; LEFT: 416px; POSITION: absolute; TOP: 192px"
				runat="server" NavigateUrl="Location/WHoldingLocRemove.aspx" Height="24px" Width="96px">Thanh lý</asp:HyperLink>
			<asp:HyperLink id="HyperLink12" style="Z-INDEX: 105; LEFT: 248px; POSITION: absolute; TOP: 240px"
				runat="server" NavigateUrl="Location/WLocPos.aspx" Height="24px" Width="88px">So do kho</asp:HyperLink>
			<asp:HyperLink id="HyperLink13" style="Z-INDEX: 106; LEFT: 232px; POSITION: absolute; TOP: 192px"
				runat="server" NavigateUrl="Location/WShelfPos.aspx" Height="24px" Width="96px">So do gia sach</asp:HyperLink>
			<asp:HyperLink id="HyperLink14" style="Z-INDEX: 107; LEFT: 224px; POSITION: absolute; TOP: 296px"
				runat="server" NavigateUrl="Location/WLibMan.aspx" Height="32px" Width="96px">Thu vien</asp:HyperLink>
			<asp:HyperLink id="HyperLink15" style="Z-INDEX: 108; LEFT: 464px; POSITION: absolute; TOP: 336px"
				runat="server" NavigateUrl="Location/WLocMan.aspx" Height="24px" Width="120px">Kho</asp:HyperLink>
			<asp:HyperLink id="HyperLink27" style="Z-INDEX: 112; LEFT: 368px; POSITION: absolute; TOP: 144px"
				runat="server" NavigateUrl="Location/WGenCopyNumListF.aspx" Height="24px" Width="64px">danh sach dang ky ca biet</asp:HyperLink>
		</form>
	</body>
</HTML>
