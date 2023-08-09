<%@ Reference Page="~/Catalogue/Catalogue/WCalendar.aspx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Common.WCalendar" CodeFile="WCalendar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WCalendar</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../Styles.css" type="text/css" rel="stylesheet">
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
		<script language="javascript">
            function CloseWindow()
            {
                self.close();
            }
		</script>
	</HEAD>
	<body bgColor="#f0f3f4" leftMargin="5" topMargin="5">
		<form id="Calendar" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr bgcolor="#f3f3f3">
					<td colspan="2"><img src="images/spacer.gif" height="4" width="1"></td>
				</tr>
				<tr bgcolor="#f3f3f3">
					<td align="center" colSpan="2">
						<asp:dropdownlist id="ddlMonthSelect" runat="server" CssClass="standard-text" Height="22px" Width="90px"
							AutoPostBack="True" OnSelectedIndexChanged="MonthSelect_SelectedIndexChanged"></asp:dropdownlist>&nbsp;
						<asp:dropdownlist id="ddlYearSelect" runat="server" CssClass="standard-text" Height="22px" Width="60px"
							AutoPostBack="True" OnSelectedIndexChanged="YearSelect_SelectedIndexChanged"></asp:dropdownlist>
						<asp:calendar id="dgtCalendar" runat="server" BorderWidth="5px" ShowTitle="False" ShowNextPrevMonth="False"
							BorderStyle="Solid" Font-Size="XX-Small" Font-Names="Arial" BorderColor="White" DayNameFormat="Short"
							ForeColor="#C0C0FF" FirstDayOfWeek="Monday" CssClass="standard-text" OnSelectionChanged="Cal_SelectionChanged">
							<TodayDayStyle Font-Bold="True" ForeColor="White" BackColor="#990000"></TodayDayStyle>
							<DayStyle BorderWidth="2px" ForeColor="#666666" BorderStyle="Solid" BorderColor="White" BackColor="#EAEAEA"></DayStyle>
							<DayHeaderStyle ForeColor="#649CBA"></DayHeaderStyle>
							<SelectedDayStyle Font-Bold="True" ForeColor="#333333" BackColor="#FAAD50"></SelectedDayStyle>
							<WeekendDayStyle ForeColor="White" BackColor="#BBBBBB"></WeekendDayStyle>
							<OtherMonthDayStyle ForeColor="#666666" BackColor="White"></OtherMonthDayStyle>
						</asp:calendar>
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2">
						<asp:label id="lblSelectedDate" runat="server" CssClass="lbLabel">Ngày được chọn:</asp:label>
						<asp:label id="lblDate" runat="server" CssClass="lbLabel"></asp:label>
						<input id="txtdatechosen" type="hidden" name="datechosen" runat="server">
					</td>
				</tr>
				<tr>
					<td colspan="2"><img src="images/spacer.gif" height="4" width="1"></td>
				</tr>
				<tr>
					<td align="center">
						<asp:button CssClass="lbButton" id="btnOK" runat="server" Text="Chọn" Width="60px"></asp:button>
					</td>
					<td align="center">
						<a href="javascript:CloseWindow()">
							<asp:button CssClass="lbButton" id="btnCancel" runat="server" Text="Thoát" Width="60px"></asp:button>
						</a>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
