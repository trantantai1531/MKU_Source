<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WAddCopyNumber" EnableViewStateMac="False" CodeFile="WAddCopyNumber.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 TRansitional//EN">
<html>
<head>
    <title>WAddCopyNumber</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <style>
        input.lbTextBox {
            font: 15px Arial;
            height: 30px;
            width: 67%;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body leftmargin="0" topmargin="0" onload="if(eval('document.forms[0].txtItemCode')) document.forms[0].txtItemCode.focus();">
    <form id="Form1" method="post" runat="server" style="margin-left: 20px">
        <table cellspacing="0" cellpadding="2" width="100%" border="0">
            <tr class="lbPageTitle">
                <td align="left" colspan="2">
                    <asp:Label CssClass="main-head-form" ID="lblMainTitle" runat="server">Thêm mới đăng kí cá biệt</asp:Label></td>
            </tr>
            <tr class="lbSubformTitle">
                <td></td>
                <td align="left">
                    <asp:Label ID="lbSubTitle1" runat="server" CssClass="lbSubformTitle">Biểu ghi thư mục của ấn phẩm</asp:Label></td>
            </tr>
            <tr class="lbControlBar">
                <td align="right" width="20%">
                    <asp:Label ID="lblField1" CssClass="lbLabel" runat="server"><u>M</u>ã số biểu ghi:
                    </asp:Label>
                <td>
                    <asp:TextBox ID="txtItemCode" runat="server" CssClass="lbTextbox"></asp:TextBox><asp:Label ID="lblNote3" CssClass="lbAmount" runat="server" ForeColor="Red">
							* 
                    </asp:Label>&nbsp;
						<asp:HyperLink ID="lnkSearch" runat="server" CssClass="lbLinkFunction">Tìm</asp:HyperLink>&nbsp;&nbsp;
						<asp:HyperLink ID="lnkView" runat="server" CssClass="lbLinkFunction">Xem</asp:HyperLink>&nbsp;
						<asp:HyperLink ID="lnkAdd" runat="server" CssClass="lbLinkFunction">Nhập mới</asp:HyperLink></td>
            </tr>
            <tr class="lbSubformTitle">
                <td></td>
                <td align="left">
                    <asp:Label ID="lblSubTitle2" runat="server" CssClass="lbSubformTitle">Thông tin xếp giá</asp:Label></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblField2" CssClass="lbLabel" runat="server">Thư <u>v</u>iện:</asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlLibrary" runat="server"></asp:DropDownList><asp:Label ID="lblNote4" CssClass="lbAmount" runat="server" ForeColor="Red">* </asp:Label></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblField3" CssClass="lbLabel" runat="server"><u>K</u>ho:</asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlLocation" runat="server"></asp:DropDownList><asp:Label ID="lblNote7" CssClass="lbAmount" runat="server" ForeColor="Red">* </asp:Label></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblField4" CssClass="lbLabel" runat="server"><u>G</u>iá sách:</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtShelf" runat="server" CssClass="lbTextbox"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblField5" CssClass="lbLabel" runat="server"><u>S</u>ố định danh:</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtCallNumber" runat="server" CssClass="lbTextbox"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblField6" CssClass="lbLabel" runat="server">Đăng kí <u>c</u>á biệt:</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtCopyNumber" runat="server" CssClass="lbTextbox" MaxLength="20"></asp:TextBox><asp:Label ID="lblNote5" CssClass="lbAmount" runat="server" ForeColor="Red">* </asp:Label></td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblField7" CssClass="lbLabel" runat="server">Giá tiề<u>n</u>:</asp:Label></td>
                <td>
                    <asp:TextBox ID="txtCost" runat="server" CssClass="lbTextbox">0</asp:TextBox>&nbsp;
						<asp:DropDownList ID="ddlCurrency" runat="server"></asp:DropDownList><asp:Label ID="Label1" CssClass="lbAmount" runat="server" ForeColor="Red" >* </asp:Label></td>
            </tr>
            <tr class="lbSubformTitle">
                <td style="HEIGHT: 25px"></td>
                <td align="left" style="HEIGHT: 25px">
                    <asp:Label ID="lblSubTitle3" runat="server" CssClass="lbSubformTitle">Chính sách lưu thông</asp:Label></td>
            </tr>
            </TR>
				<tr>
                    <td align="right" style="HEIGHT: 29px">
                        <asp:Label ID="lblField8" CssClass="lbLabel" runat="server"><u>D</u>ạng tài liệu:</asp:Label></td>
                    <td style="HEIGHT: 29px">
                        <asp:DropDownList ID="ddlLoanType" runat="server"></asp:DropDownList><asp:Label ID="lblNote6" CssClass="lbAmount" runat="server" ForeColor="Red">* </asp:Label></td>
                </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnAdd" CssClass="lbButton" runat="server" Text="Nhập(n)"></asp:Button>&nbsp;
						<asp:Button ID="btnReset" CssClass="lbButton" runat="server" Text="Đặt lại(r)"></asp:Button>&nbsp;
						<asp:Label ID="lblNote1" CssClass="lbAmount" runat="server" ForeColor="Red">* </asp:Label>&nbsp;
						<asp:Label ID="lblNote2" CssClass="lbLabel" runat="server">-- Thông tin bắt buộc</asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblSelectLib" runat="server" CssClass="lblabel" Visible="False">----- Chọn thư viện:</asp:Label><asp:Label ID="lblResult" runat="server" CssClass="lblabel" Visible="False">Cập nhật bản ghi thư mục thành công. Tiếp tục nhập đăng kí cá biệt!</asp:Label><asp:Label ID="lblFail" runat="server" CssClass="lblabel" Visible="False">Cập nhật bản ghi thư mục thất bại!</asp:Label><asp:Label ID="LblMsg1" runat="server" CssClass="lblabel" Visible="False">Thêm mới đăng kí cá biệt thất bại! Mã tài liệu bạn nhập vào không tồn tại!</asp:Label><asp:Label ID="LblMsg2" runat="server" CssClass="lblabel" Visible="False">Thêm mới đăng kí cá biệt thất bại! Đăng kí cá biệt của tài liệu nhập vào đã tồn tại!</asp:Label><asp:Label ID="LblMsg3" runat="server" CssClass="lblabel" Visible="False">Bạn phải chọn thư viện và kho trước khi nhập mới một đăng kí cá biệt!</asp:Label><asp:Label ID="LblMsg4" runat="server" CssClass="lblabel" Visible="False">Bạn phải nhập vào mã tài liệu!</asp:Label><asp:Label ID="LblMsg5" runat="server" CssClass="lblabel" Visible="False">Bạn phải nhập vào một đăng kí cá biệt!</asp:Label><asp:Label ID="LblMsg6" runat="server" CssClass="lblabel" Visible="False">Thêm mới đăng kí cá biệt thành công!</asp:Label><asp:Label ID="lblMsg7" runat="server" CssClass="lblabel" Visible="False">Trường giá tiền nhập vào không hợp lệ!</asp:Label></td>
            </tr>
        </table>
        <input id="txtLocID" type="hidden" size="1" name="txtLocID" runat="server">
        <input id="txtLibID" type="hidden" size="1" name="txtLibID" runat="server">
        <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Thêm mới tài liệu</asp:ListItem>
            <asp:ListItem Value="3">Thêm mới ĐKCB</asp:ListItem>
            <asp:ListItem Value="4">Mã tài liệu</asp:ListItem>
            <asp:ListItem Value="5">Đăng kí cá biệt</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
