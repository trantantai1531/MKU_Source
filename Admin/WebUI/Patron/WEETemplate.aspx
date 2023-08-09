<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WEETemplate" CodeFile="WEETemplate.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WEETemplate</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body topmargin="0" leftmargin="0" rightmargin="0" onload="document.forms[0].txtTitle.focus()">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">

            <h1 class="main-head-form">Khuôn dạng xuất</h1>
            <div class="main-form">
            <div class="two-column ClearFix">
                <div class="two-column-form">
                    <div class="row-detail">
                        <p>Chọn mẫu :</p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:dropdownlist id="ddlTemplate" Runat="server"></asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Tên mẫu : <asp:label id="lblMan" Runat="server" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc">(*)</asp:label></p>
                        <div class="input-control">
                            <div class="input-form ">
                               <asp:textbox CssClass="text-input"  id="txtTitle" runat="server" Width=""></asp:textbox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Thông tin :</p>
                        <div class="input-control">
                            <div class="dropdown-form">
                            <asp:dropdownlist id="ddlInf" Runat="server">
							<asp:ListItem Value="">-------chọn thông tin------</asp:ListItem>
							<asp:ListItem Value="<$CODE$>">Số thẻ</asp:ListItem>
							<asp:ListItem Value="<$LASTISSUEDDATE$>">Ngày cấp thẻ</asp:ListItem>
							<asp:ListItem Value="<$EXPIREDDATE$>">Ngày hết hạn thẻ</asp:ListItem>
							<asp:ListItem Value="<$VALIDDATE$>">Ngày có hiệu lực</asp:ListItem>
							<asp:ListItem Value="<$FULLNAME$>">Họ và tên</asp:ListItem>
							<asp:ListItem Value="<$SEX$>">Giới tính</asp:ListItem>
							<asp:ListItem Value="<$DOB$>">Ngày sinh</asp:ListItem>
							<asp:ListItem Value="<$ETHNIC$>">Dân tộc</asp:ListItem>
							<asp:ListItem Value="<$TELEPHONE$>">Số điện thoại</asp:ListItem>
							<asp:ListItem Value="<$MOBILE$>">Số di động</asp:ListItem>
							<asp:ListItem Value="<$EMAIL$>">Email</asp:ListItem>
							<asp:ListItem Value="<$PORTRAIT$>">Ảnh</asp:ListItem>
							<asp:ListItem Value="<$GRADE$>">Khoá</asp:ListItem>
							<asp:ListItem Value="<$COLLEGE$>">Trường</asp:ListItem>
							<asp:ListItem Value="<$OCCUPATION$>">Nghề nghiệp</asp:ListItem>
							<asp:ListItem Value="<$FACULTY$>">Khoa</asp:ListItem>
							<asp:ListItem Value="<$CLASS$>">Lớp</asp:ListItem>
							<asp:ListItem Value="<$PROVINCE$>">Vùng</asp:ListItem>
							<asp:ListItem Value="<$ADDRESS$>">Địa chỉ</asp:ListItem>
							<asp:ListItem Value="<$CITY$>">Tỉnh- thành phố</asp:ListItem>
							<asp:ListItem Value="<$ZIP$>">Mã tỉnh- thành phố</asp:ListItem>
							<asp:ListItem Value="<$ACTIVE$>">Active</asp:ListItem>
							<asp:ListItem Value="<$LASTMODIFIEDDATE$>">Ngày truy cập cuối</asp:ListItem>
							<asp:ListItem Value="<$EDUCATIONLEVEL$>">Trình độ</asp:ListItem>
							<asp:ListItem Value="<$PATRONGROUPNAME$>">Tên nhóm bạn đọc</asp:ListItem>
							<asp:ListItem Value="<$NOTE$>">Ghi chú</asp:ListItem>
							<asp:ListItem Value="<$FIRSTNAME$>">Họ</asp:ListItem>
							<asp:ListItem Value="<$LASTNAME$>">Tên</asp:ListItem>
							<asp:ListItem Value="<$IDCARD$>">Số CMT nhân dân</asp:ListItem>
						</asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="two-column-form">
                    <div class="row-detail">
                        <p>Nội dung :</p>
                        <div class="input-control">
                            <div class="input-form ">
                               <asp:textbox CssClass="text-input"  id="txtContent" Runat="server" Width="" Columns="100" Rows="10" TextMode="MultiLine"
							Height="182px" Wrap="False"></asp:textbox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row-detail">
                <div class="button-control inline-box">
                    <div class="button-form">
                        <asp:button id="btnUpdate" Runat="server" Text="Cập nhật(u)" Width=""></asp:button>
                    </div>
                    <div class="button-form">
                        <asp:button id="btnView" Runat="server" Text="Xem trước(v)" Width=""></asp:button>
                    </div>
                    <div class="button-form">
                        <asp:button id="btnReset" Runat="server" Text="Đặt lại(r)" Width=""></asp:button>
                    </div>
                    <div class="button-form">
                        <asp:button id="btnDelete" Runat="server" Text="Xoá(d)" Width=""></asp:button>
                    </div>
                </div>
            </div>
                </div>
        </div>

        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
            <asp:ListItem Value="3">-------Thêm mới-------</asp:ListItem>
            <asp:ListItem Value="4">Nhấn OK nếu thực sự muốn xoá mẫu này!</asp:ListItem>
            <asp:ListItem Value="5">Tên mẫu là bắt buộc</asp:ListItem>
            <asp:ListItem Value="6">Đã tạo xong mẫu mới</asp:ListItem>
            <asp:ListItem Value="7">Quá trình tạo mẫu mới có lỗi</asp:ListItem>
            <asp:ListItem Value="8">Quá trình thực hiện thao tác này phát sinh lỗi</asp:ListItem>
            <asp:ListItem Value="9">Tạo mới khuôn dạng xuất</asp:ListItem>
            <asp:ListItem Value="10">Cập nhật khuôn dạng xuất</asp:ListItem>
            <asp:ListItem Value="11">Xoá khuôn dạng xuất</asp:ListItem>
            <asp:ListItem Value="12">thành công!</asp:ListItem>
            <asp:ListItem Value="13">Bạn chưa chọn khuôn dạng cần xoá!</asp:ListItem>
            <asp:ListItem Value="14">Khuông dạng xuất đã tồn tại!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
