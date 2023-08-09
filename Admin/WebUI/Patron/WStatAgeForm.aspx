<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatAgeForm" CodeFile="WStatAgeForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatAgeForm</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server">
			      <div id="divBody">
            <div class="TabbedPanelsContent">
                <div id="TabbedPanels3" class="TabbedPanels">

                    <div class="TabbedPanelsContentGroup">
                        <div class="TabbedPanelsContent">
                            <h1 class="main-head-form">Thông kê theo độ tuổi</h1>
                            <div class="three-column ClearFix">
                                <div class="three-column-form">
                                    <p>&nbsp;</p>
                                    <div class="row-detail">
                                        <div class="radio-control">
                                            <asp:radiobutton id="optAllAge" runat="server" Checked="True" GroupName="AgeStat" Text="T<u>o</u>àn bộ"></asp:radiobutton>
                                            <asp:radiobutton id="optEachAge" runat="server" GroupName="AgeStat" Text="Độ t<u>u</u>ổi: "></asp:radiobutton>
                                        </div>
                                    </div>


                                </div>
                                <div class="three-column-form">
                                    <div class="row-detail">
                                        <p>Từ: </p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:textbox CssClass="text-input" id="txtFromAge" runat="server"  MaxLength="3"></asp:textbox>
                                            </div>
                                        </div>
                                    </div>


                                </div>
                                <div class="three-column-form">
                                    <div class="row-detail">
                                        <p> Đến: </p>
                                        <div class="input-control">
                                            <div class="input-form ">
                                                <asp:textbox CssClass="text-input" id="txtToAge" runat="server"  MaxLength="3"></asp:textbox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row-detail">
                                        <div class="button-control" style="text-align:right">
                                            <div class="button-form">
                                                <asp:button id="btnStatistic" runat="server" Text="Thống kê(s)" CausesValidation="False" Width=""></asp:button>
                                            </div>
                                            <div class="button-form">
                                                <asp:button id="btnBack" runat="server" Text="Trở lại(b)" CausesValidation="False" Width=""></asp:button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>


                    </div>
                </div>
            </div>
        </div>
		    <input type="hidden" id="hidAllAge" runat="server" value="0" NAME="hidAllAge"/>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="1">Mã lổi: </asp:ListItem>
				<asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
				<asp:ListItem Value="3">Tuổi phải là số nguyên dương lớn hơn 7 và nhỏ hơn 200.</asp:ListItem>
				<asp:ListItem Value="4">Từ tuổi phải nhỏ hơn đến tuổi.</asp:ListItem>
				<asp:ListItem Value="5">Sai khuôn dạng dữ liệu!</asp:ListItem>
			</asp:DropDownList>
		</form>
	</body>
</HTML>
