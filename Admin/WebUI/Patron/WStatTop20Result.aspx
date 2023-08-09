<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatTop20Result" CodeFile="WStatTop20Result.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStatTop20Result</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <style type="text/css">
        div.btn-report-prev {
            background-color: #aacfea;
            border: 1px solid #aacfea;
            border-radius: 5px;
            color: white;
            float: right;
            height: 20px;
            margin-right: 50px;
            padding: 5px 6px;
            width: 63px;
        }
    </style>
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body onload="GenImageURL(7)" topmargin="0" leftmargin="0" bgcolor="#ffffff">
    <form id="Form1" method="post" runat="server">
        <table cellpadding="1" width="100%" align="center" border="0" id="Table1" cellspacing="1" bgcolor="#ffffff">
            <tr>
                <td width="100%" align="center">
                    <asp:Label ID="lblNotFound" runat="server" Width="100%" CssClass="lbPageTitle" Visible="false">Không tìm thấy dữ liệu</asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
				    <asp:Button CssClass="lbButton" ID="btnClose" Runat="server" Text="Chọn lại(g)"></asp:Button>
                    <asp:Button CssClass="lbButton" ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
                </td>
            </tr>
            <tr>
                <td align="center" width="100%">
                    <div class="row-detail">
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
                                <asp:BoundField HeaderText="Khoa" ItemStyle-HorizontalAlign="Center" DataField="Faculty"/>
                                <asp:BoundField HeaderText="Nhóm bạn đọc" ItemStyle-HorizontalAlign="Center" DataField="GroupName"/>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <img alt="" src="/" name="chart1" border="0" id="chart1" runat="server">
                    <img alt="" src="/" name="chart2" border="0" id="chart2" runat="server">
                </td>
            </tr>
        </table>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này.</asp:ListItem>
            <asp:ListItem Value="3">Không rõ</asp:ListItem>
            <asp:ListItem Value="4">Thống kê Top 20 nhóm bạn đọc</asp:ListItem>
            <asp:ListItem Value="5">Thống kê Top 20 trường</asp:ListItem>
            <asp:ListItem Value="6">Thống kê Top 20 khoa</asp:ListItem>
            <asp:ListItem Value="7">Thống kê Top 20 khoá học</asp:ListItem>
            <asp:ListItem Value="8">Thống kê Top 20 lớp</asp:ListItem>
            <asp:ListItem Value="9">Thống kê Top 20 dân tộc</asp:ListItem>
            <asp:ListItem Value="10">Thống kê Top 20 trình độ</asp:ListItem>
            <asp:ListItem Value="11">Thống kê Top 20 nhóm ngành nghề</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlLabelTop20" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Thống kê Top 20 nhóm bạn đọc</asp:ListItem>
            <asp:ListItem Value="1">Thống kê Top 20 trường</asp:ListItem>
            <asp:ListItem Value="2">Thống kê Top 20 khoa</asp:ListItem>
            <asp:ListItem Value="3">Thống kê Top 20 khoá học</asp:ListItem>
            <asp:ListItem Value="4">Thống kê Top 20 lớp</asp:ListItem>
            <asp:ListItem Value="5">Thống kê Top 20 dân tộc</asp:ListItem>
            <asp:ListItem Value="6">Thống kê Top 20 trình độ</asp:ListItem>
            <asp:ListItem Value="7">Thống kê Top 20 nhóm ngành nghề</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">STT</asp:ListItem>
            <asp:ListItem Value="1">Họ tên</asp:ListItem>
            <asp:ListItem Value="2">Số thẻ</asp:ListItem>
            <asp:ListItem Value="3">Ngày sinh</asp:ListItem>
            <asp:ListItem Value="4">Tuổi</asp:ListItem>
            <asp:ListItem Value="5">Email</asp:ListItem>
            <asp:ListItem Value="6">Số điện thoại</asp:ListItem>
            <asp:ListItem Value="7">Lớp</asp:ListItem>
            <asp:ListItem Value="8">Khóa</asp:ListItem>
            <asp:ListItem Value="9">Khoa</asp:ListItem>
            <asp:ListItem Value="10">Nhóm bạn đọc</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="lblNoname" runat="server" Visible="False">Không rõ</asp:Label>
        <!-- Patron Group Stat _-->
        <asp:Label ID="lblPGVTitle" runat="server" Visible="false">Số lượng sinh viên</asp:Label>
        <asp:Label ID="lblPGHTitle" runat="server" Visible="false">Tên nhóm bạn đọc</asp:Label>
        <asp:Label ID="lblPGTitle" runat="server" Visible="false">Tỉ lệ % theo nhóm bạn đọc</asp:Label>
        <!-- School Stat _-->
        <asp:Label ID="lblSVTitle" runat="server" Visible="false">Số lượng sinh viên</asp:Label>
        <asp:Label ID="lblSHTitle" runat="server" Visible="false">Tên trường</asp:Label>
        <asp:Label ID="lblSTitle" runat="server" Visible="false">Tỉ lệ % theo trường</asp:Label>
        <!-- Faculty Stat _-->
        <asp:Label ID="lblFVTitle" runat="server" Visible="false">Số lượng sinh viên</asp:Label>
        <asp:Label ID="lblFHTitle" runat="server" Visible="false">Tên khoa</asp:Label>
        <asp:Label ID="lblFTitle" runat="server" Visible="false">Tỉ lệ % theo khoa</asp:Label>
        <!-- Grade Stat _-->
        <asp:Label ID="lblGVTitle" runat="server" Visible="false">Số lượng sinh viên</asp:Label>
        <asp:Label ID="lblGHTitle" runat="server" Visible="false">Tên khoá học</asp:Label>
        <asp:Label ID="lblGTitle" runat="server" Visible="false">Tỉ lệ % theo khoá học</asp:Label>
        <!-- Class Stat _-->
        <asp:Label ID="lblCVTitle" runat="server" Visible="false">Số lượng sinh viên</asp:Label>
        <asp:Label ID="lblCHTitle" runat="server" Visible="false">Tên lớp</asp:Label>
        <asp:Label ID="lblCTitle" runat="server" Visible="false">Tỉ lệ % theo lớp</asp:Label>
        <!-- Ethnic Stat _-->
        <asp:Label ID="lblEVTitle" runat="server" Visible="false">Số lượng sinh viên</asp:Label>
        <asp:Label ID="lblEHTitle" runat="server" Visible="false">Tên dân tộc</asp:Label>
        <asp:Label ID="lblETitle" runat="server" Visible="false">Tỉ lệ % theo dân tộc</asp:Label>
        <!-- EducationLevel Stat _-->
        <asp:Label ID="lblELVTitle" runat="server" Visible="false">Số lượng sinh viên</asp:Label>
        <asp:Label ID="lblELHTitle" runat="server" Visible="false">Trịnh độ</asp:Label>
        <asp:Label ID="lblELTitle" runat="server" Visible="false">Tỉ lệ % theo trình độ</asp:Label>
        <!-- Occupation Stat _-->
        <asp:Label ID="lblOVTitle" runat="server" Visible="false">Số lượng sinh viên</asp:Label>
        <asp:Label ID="lblOHTitle" runat="server" Visible="false">Tên nhóm ngành nghề</asp:Label>
        <asp:Label ID="lblOTitle" runat="server" Visible="false">Tỉ lệ % theo nhóm ngành nghề</asp:Label>
    </form>
</body>
</html>
