<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WRegisterIssues" CodeFile="WRegisterIssues.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WRegisterIssues</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
          <style>
     #divBody .tab
        {
            display: inline;
            text-align: right;
        }
        #divBody .tab ul
        {
            padding-top: 5px;
        }
           #divBody .tab ul li
        {
            background: #4182C4 none repeat scroll 0 0;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
        }
        li
        {
            list-style: outside none none;
        }
        
        #divBody .tab ul li a
        {
            color: #fff;
        }
          #divBody .tab ul li.active
        {
            background-color: #024385;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
        }
  
    </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
		    
                <div id="divBody">
            
             <div class="tab">
            <ul>
                <li>
                    <asp:HyperLink ID="lnkHdAcquire" runat="server" CssClass="lbLinkFunction" NavigateUrl="WAcquire.aspx">Bổ sung</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdSetRegularity" runat="server" CssClass="lbLinkFunction">Định kỳ</asp:HyperLink></li>
                <li class="active">
                    <asp:Label ID="lblHdRegister" runat="server" CssClass="lbGroupTitle">Đăng ký</asp:Label></li>
                <li>
                    <asp:HyperLink ID="lnkHdReceive" runat="server" CssClass="lbLinkFunction" NavigateUrl="WReceive.aspx">Ghi nhận</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdView" runat="server" CssClass="lbLinkFunction" NavigateUrl="WViewInCalendarMode.aspx">Kiểm tra</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdBinding" runat="server" CssClass="lbLinkFunction" NavigateUrl="WBinding.aspx">Đóng tập</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdSummary" runat="server" CssClass="lbLinkFunction" NavigateUrl="WSummaryHoldingManagement.aspx">Tổng hợp</asp:HyperLink></li>
            </ul>
        </div>

			<TABLE id="tblHeader" cellSpacing="0" cellPadding="4" width="100%" border="0" runat="server">
				
			</TABLE>
			<TABLE id="Table1" cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TR>
					<TD align="center" colSpan="2">
						<asp:label id="lblTitle" CssClass="main-head-form" runat="server"></asp:label></TD>
				</TR>
				<TR class="lbSubFormTitle">
					<TD align="center" colSpan="2">
						<asp:hyperlink id="lnkCreateIssue" runat="server" CssClass="lbLinkFunction">Đăng ký trực tiếp</asp:hyperlink>&nbsp;|&nbsp;
						<asp:label id="lblRegister" runat="server" CssClass="lbSubFormTitle">Đăng ký tự động</asp:label></TD>
				</TR>
				<TR>
					<TD align="right" width=40%>
						<asp:label id="lblLastIssuelb" runat="server">Số cuối:</asp:label></TD>
					<TD>
						<asp:label id="lblLastIssue" runat="server"></asp:label>
						<asp:hyperlink id="lnkNextIssue" runat="server" CssClass="lbLinkFunction">Số tiếp</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblStartDate" runat="server"><U>T</U>ừ ngày:</asp:label></TD>
					<TD>
						<asp:textbox id="txtStartDate" runat="server" Width="200px"></asp:textbox>&nbsp;<asp:hyperlink id="lnkStartDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblEndDate" runat="server"><U>Đ</U>ến ngày:</asp:label></TD>
					<TD>
						<asp:textbox id="txtEndDate" runat="server" Width="200px"></asp:textbox>&nbsp;<asp:hyperlink id="lnkEndDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:hyperlink></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblVolumeByPublisher" runat="server"><U>T</U>ập:</asp:label></TD>
					<TD>
						<asp:textbox id="txtVolumeByPublisher" runat="server" Width="200px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblCopies" runat="server">Số <U>l</U>ượng đặt:</asp:label></TD>
					<TD>
						<asp:textbox id="txtCopies" runat="server" Width="200px">0</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblPrice" runat="server">Đơn <U>g</U>iá:</asp:label></TD>
					<TD>
						<asp:textbox id="txtPrice" runat="server" Width="199px">0</asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:label id="lblStartIssueNo" runat="server"><U>S</U>ố bắt đầu:</asp:label></TD>
					<TD>
						<asp:textbox id="txtStartIssueNo" Width="200px" runat="server"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">
						<asp:Label id="lblStartOvIssueNo" runat="server"><U>S</U>ố bắt đầu (toàn cục):</asp:Label></TD>
					<TD>
						<asp:TextBox id="txtStartOvIssueNo" Width="200px" runat="server"></asp:TextBox>
						<asp:Label id="lblNoteOverIssue" runat="server">(Rỗng hoặc bằng 0: không có số toàn cục)</asp:Label></TD>
				</TR>
				<TR class="lbControlbar">
					<TD></TD>
					<TD>
						<asp:Button id="btnRegister" runat="server" Width="90px" Text="Đăng ký(g)"></asp:Button>
						<asp:Button id="btnReset" runat="server" Width="88px" Text="Đặt lại(r)"></asp:Button></TD>
				</TR>
				<TR>
					<TD align="center" colspan="2">
						<asp:Label id="lblResult" runat="server" Font-Bold="True" Visible="False" ForeColor="#990033">Số kỳ xuất bản đã được sinh:</asp:Label>&nbsp;
						<asp:Label id="lblCount" runat="server" Font-Bold="True" Visible="False" ForeColor="#990033">0</asp:Label>
					</TD>
				</TR>
			</TABLE>
            
            
            </div>
		    <input id="hidLastIssueNo" type="hidden" runat="server" value="0" NAME="hidLastIssueNo"/>
		    <input id="hidLastOvIssueNo" type="hidden" runat="server" value="0" NAME="hidLastOvIssueNo"/>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Đăng ký số tự động</asp:ListItem>
				<asp:ListItem Value="3">Đăng ký thành công</asp:ListItem>
				<asp:ListItem Value="4">Lỗi trong quá trình xử lý</asp:ListItem>
				<asp:ListItem Value="5">Ngày phát hành đã tồn tại</asp:ListItem>
				<asp:ListItem Value="6">Số toàn cục này đã tồn tại</asp:ListItem>
				<asp:ListItem Value="7">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="8">Dữ liệu không hợp lệ!</asp:ListItem>
				<asp:ListItem Value="9">Bản ghi không được cập nhật nếu giá trị trường này trống</asp:ListItem>
				<asp:ListItem Value="10">Số toàn cục phải lớn hơn số cục bộ</asp:ListItem>
				<asp:ListItem Value="11">Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu</asp:ListItem>
			</asp:DropDownList>
		</form>
		<script language="javascript">
			document.forms[0].txtStartDate.focus();
		</script>
	</body>
</HTML>
