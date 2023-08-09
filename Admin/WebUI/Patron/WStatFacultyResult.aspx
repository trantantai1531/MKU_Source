<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatFacultyResult" CodeFile="WStatFacultyResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatFacultyResult</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
        <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
	    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body bgColor="#ffffff" onload="GenURL(7)" topmargin="0" leftmargin="0" rightmargin="0">
		<form id="Form1" method="post" runat="server" style="margin:0;">
            <h1 class="main-head-form">Thống kê theo đơn vị</h1>
            <table width="100%" border="0">
				<tr>
					<td align="left">
                        <asp:label id="lblFaculty" Runat="server"><u>C</u>họn đơn vị:</asp:label>&nbsp;
                        <asp:dropdownlist id="ddlFaculty" Runat="server"></asp:dropdownlist>&nbsp;
                        <asp:label id="lbGroupPatron" Runat="server"><u>C</u>họn nhóm bạn đọc:</asp:label>&nbsp;
                        <asp:dropdownlist id="ddlGroupPatron" Runat="server"></asp:dropdownlist>&nbsp;
                        <asp:label id="lblYearFrom" Runat="server" Visible="false"><u>T</u>ừ khóa:</asp:label>&nbsp;
                        <asp:TextBox ID="txtYearFrom" runat="server" Width="100px" Visible="false"></asp:TextBox>
                        <asp:label id="lblYearTo" Runat="server" Visible="false"><u>Đ</u>ến khóa:</asp:label>&nbsp;
                        <asp:TextBox ID="txtYearTo" runat="server" Width="100px" Visible="false" Height="21px"></asp:TextBox>
                        <asp:button id="btnStatic" Runat="server" Width="88px" Text="Thống kê(b)"></asp:button>
                        <asp:Button CssClass="lbButton" ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
                        <asp:button id="btnBack" Runat="server" Width="88px" Text="Quay lại(b)"></asp:button>
					</td>
				</tr>
			</table>
			<table cellSpacing="1" cellPadding="1" width="100%" align="center" border="0" bgcolor="#ffffff">
				<tr>
					<td width="100%">
                        <asp:Label ID="lblNotFound" Runat="server" Width="100%" CssClass="lbPageTitle" Visible="False">Không tìm thấy dữ liệu</asp:Label>
					</td>
				</tr>
                <tr>
                    <td >
                        <p style="margin-left:10px"><b>Tổng số: </b><asp:Label runat="server" ID="lblTotal"></asp:Label></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="row-detail">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td>
                                        <asp:GridView ID="dtgResult" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                            <Columns>
                                                <asp:BoundField HeaderText="STT" ItemStyle-HorizontalAlign="Center" DataField="STT" HeaderStyle-Width="5%"/>
                                                <asp:BoundField HeaderText="Họ và tên lót" ItemStyle-HorizontalAlign="Center" DataField="FirstName"/>
                                                <asp:BoundField HeaderText="Tên" ItemStyle-HorizontalAlign="Center" DataField="LastName"/>
                                                <asp:BoundField HeaderText="Mã số thẻ" ItemStyle-HorizontalAlign="Center" DataField="PatronCode"/>
                                                <asp:BoundField HeaderText="Ngày cấp thẻ" ItemStyle-HorizontalAlign="Center" DataField="LastIssuedDate" DataFormatString="{0:dd/MM/yyyy}" Visible="false"/>
                                                <asp:BoundField HeaderText="Ngày hết hạn" ItemStyle-HorizontalAlign="Center" DataField="ExpiredDate" DataFormatString="{0:dd/MM/yyyy}" Visible="false"/>
                                                <asp:BoundField HeaderText="Lớp" ItemStyle-HorizontalAlign="Center" DataField="Class" />
                                                <asp:BoundField HeaderText="Khóa" ItemStyle-HorizontalAlign="Center" DataField="Grade" />
                                                <asp:BoundField HeaderText="Đơn vị" ItemStyle-HorizontalAlign="Center" DataField="Faculty"/>
                                                <asp:BoundField HeaderText="Trường" ItemStyle-HorizontalAlign="Center" DataField="College"/>
                                                <asp:BoundField HeaderText="Nhóm bạn đọc" ItemStyle-HorizontalAlign="Center" DataField="GroupName"/>
                                                <asp:BoundField HeaderText="Số điện thoại" ItemStyle-HorizontalAlign="Center" DataField="Mobile" Visible="false"/>
                                                <asp:BoundField HeaderText="Email" ItemStyle-HorizontalAlign="Center" DataField="Email" />
                                                <asp:BoundField HeaderText="Địa chỉ" ItemStyle-HorizontalAlign="Center" DataField="Address" Visible="false"/>
                                                <asp:BoundField HeaderText="Tỉnh/Thành phố" ItemStyle-HorizontalAlign="Center" DataField="City" Visible="false"/>
                                                <asp:BoundField HeaderText="Ghi chú" ItemStyle-HorizontalAlign="Center" DataField="Note"/>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                         </div>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        <div class="two-column">
                            <div class="two-column-form">
                                <div class="row-detail">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
					                        <td align="center">
                                                <img alt="" src="/" border="0" name="anh1" id="anh1" runat="server"/><br /><br/>
                                                <img alt="" src="/" border="0" name="anh2" id="anh2" runat="server"/>
					                        </td>
				                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="two-column-form">
                                <div class="row-detail">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="dtgResult" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="STT" ItemStyle-HorizontalAlign="Center" DataField="STT" HeaderStyle-Width="5%"/>
                                                        <asp:BoundField HeaderText="Họ tên" ItemStyle-HorizontalAlign="Center" DataField="FullName"/>
                                                        <asp:BoundField HeaderText="Số thẻ" ItemStyle-HorizontalAlign="Center" DataField="PatronCode"/>
                                                        <asp:BoundField HeaderText="Ngày sinh" ItemStyle-HorizontalAlign="Center" DataField="Birthday" DataFormatString="{0:dd/MM/yyyy}"/>
                                                        <asp:BoundField HeaderText="Tuổi" ItemStyle-HorizontalAlign="Center" DataField="YEARS"/>
                                                        <asp:BoundField HeaderText="Email" ItemStyle-HorizontalAlign="Center" DataField="Email"/>
                                                        <asp:BoundField HeaderText="Số điện thoại" ItemStyle-HorizontalAlign="Center" DataField="Mobile"/>
                                                        <asp:BoundField HeaderText="Lớp" ItemStyle-HorizontalAlign="Center" DataField="Class"/>
                                                        <asp:BoundField HeaderText="Khóa" ItemStyle-HorizontalAlign="Center" DataField="Grade"/>
                                                        <asp:BoundField HeaderText="Đơn vị" ItemStyle-HorizontalAlign="Center" DataField="Faculty"/>
                                                        <asp:BoundField HeaderText="Nhóm bạn đọc" ItemStyle-HorizontalAlign="Center" DataField="GroupName"/>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                        
                    </td>
                </tr>	--%>			
			</table>
			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
				<asp:ListItem Value="1">Mã lổi: </asp:ListItem>
				<asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
				<asp:ListItem Value="3">Tên khoa</asp:ListItem>
				<asp:ListItem Value="4">Số lượng sinh viên</asp:ListItem>
				<asp:ListItem Value="5">Tỉ lệ % sinh viên theo khoa</asp:ListItem>
				<asp:ListItem Value="6">Không rõ</asp:ListItem>
				<asp:ListItem Value="7">Thống kê theo khoa</asp:ListItem>
				<asp:ListItem Value="8">Chọn nhóm bạn đọc</asp:ListItem>
			    <asp:ListItem Value="9">Tất cả</asp:ListItem>
			</asp:DropDownList>
		    <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
		        <asp:ListItem Value="0">STT</asp:ListItem>
                <asp:ListItem Value="1">Họ và tên lót</asp:ListItem>
                <asp:ListItem Value="2">Tên</asp:ListItem>
                <asp:ListItem Value="3">Mã số thẻ</asp:ListItem>
                <asp:ListItem Value="4">Ngày cấp thẻ</asp:ListItem>
                <asp:ListItem Value="5">Ngày hết hạn</asp:ListItem>
                <asp:ListItem Value="6">Lớp</asp:ListItem>
                <asp:ListItem Value="7">Khóa</asp:ListItem>
                <asp:ListItem Value="8">Đơn vị</asp:ListItem>
                <asp:ListItem Value="9">Trường</asp:ListItem>
                <asp:ListItem Value="10">Nhóm bạn đọc</asp:ListItem>
                <asp:ListItem Value="11">Số điện thoại</asp:ListItem>
                <asp:ListItem Value="12">Email</asp:ListItem>
                <asp:ListItem Value="13">Địa chỉ</asp:ListItem>
                <asp:ListItem Value="14">Tỉnh/Thành phố</asp:ListItem>
                <asp:ListItem Value="15">Ghi chú</asp:ListItem>
		    </asp:DropDownList>
		    <div style="display:none">
		        <input name="hidMessageBook" runat="server" type="hidden" id="hidMessageBook" value="Tổng số: " />
		        <input name="hidLeftTable" runat="server" type="hidden" id="hidLeftTable" value="ĐẠI HỌC GIAO THÔNG - VẬN TẢI<BR/>TP.HỒ CHÍ MINH" />
		        <input name="hidRightTable" runat="server" type="hidden" id="hidRightTable" value="CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM<BR/>Độc lập - Tự do - Hạnh phúc" />
		        <input name="hidTitleTable" runat="server" type="hidden" id="hidTitleTable" value="THỐNG KÊ BẠN ĐỌC THEO KHOA" />
		        <input name="hidMessageCopyNumber" runat="server" type="hidden" id="hidMessageCopyNumber" value="" />
		    </div>
		</form>
	</body>
</HTML>
