<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WMonitorPrintCard" CodeFile="WMonitorPrintCard.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Quản lý in thẻ</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body topmargin="0" leftmargin="0" onload="document.forms[0].txtCode.focus()">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">

            <h1 class="main-head-form">In thẻ bạn đọc</h1>
            <div class="main-form">
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Số thẻ</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtCode" runat="server" Width=""></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Ngày cấp : <asp:hyperlink id="lnkValidDate" runat="server">Lịch</asp:hyperlink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtValidDate" runat="server" Width=""></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Khóa</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtGrade" runat="server" Width=""></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Giới hạn kết quả :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:dropdownlist id="ddlSelectTop" runat="server">
							<asp:ListItem Value="0">Toàn bộ</asp:ListItem>
							<asp:ListItem Value="50" Selected="True">50</asp:ListItem>
							<asp:ListItem Value="100">100</asp:ListItem>
							<asp:ListItem Value="200">200</asp:ListItem>
							<asp:ListItem Value="300">300</asp:ListItem>
						</asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Họ tên :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtFullName" runat="server" Width=""></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Ngày sinh : <asp:hyperlink id="lnkDOB" runat="server">Lịch</asp:hyperlink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtDOB" runat="server" Width=""></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Lớp</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtClass" runat="server" Width=""></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Giới tính:</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:dropdownlist id="ddlSex" runat="server">
							<asp:ListItem Value="2" Selected="True">--- Chọn ---</asp:ListItem>
							<asp:ListItem Value="0">Nữ</asp:ListItem>
							<asp:ListItem Value="1">Nam</asp:ListItem>
						</asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control" style="text-align: center;">
                        <div class="button-form">
                            <asp:button id="btnSearch" runat="server" Text="Tìm kiếm(s)" Width=""></asp:button>
                        </div>
                        <div class="button-form">
                            <asp:button id="btnReset" runat="server" Width="" Text="Làm lại(r)"></asp:button>
                        </div>
                        <div class="button-form">
                            <asp:button id="btnPrintCard" runat="server" Width="" Text="In thẻ(p)"></asp:button>
                        </div>
                    </div>
                </div>
               
                <div class="input-control row-detail">
                     <asp:label id="lblListNotPrint" Width="100%" Runat="server" CssClass="lbPageTitle">Danh sách bạn đọc đã in thẻ</asp:label>
                    <div class="table-form">
                        <asp:datagrid id="DgrResult" runat="server" Width="100%" CellPadding="2" BackColor="White" BorderWidth="1px"
							BorderStyle="None" BorderColor="#CCCCCC" AutoGenerateColumns="False">
							<Columns>
								<asp:BoundColumn DataField="Code" HeaderText="Số thẻ" ItemStyle-Width="10%"></asp:BoundColumn>
								<asp:BoundColumn DataField="FullName" HeaderText="Họ và tên"></asp:BoundColumn>
								<asp:BoundColumn DataField="DOB" HeaderText="Ngày sinh" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center"
									HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Left" ForeColor="#000066" BackColor="White" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
                    </div>
                </div>
            </div>
        </div>
			<asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
                <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
                <asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
                <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
                <asp:ListItem Value="3">Không thực hiện được việc tìm kiếm</asp:ListItem>
                <asp:ListItem Value="4">Ngày tháng nhập vào sai định dạng</asp:ListItem>
            </asp:DropDownList>
    </form>
</body>
</html>
