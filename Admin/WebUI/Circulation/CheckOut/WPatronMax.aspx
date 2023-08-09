<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WPatronMax" CodeFile="WPatronMax.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>

<head>
    <title></title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
        window.addEventListener("load", function () {
            GenURLImg(9);
        }, false);
      
    </script>
</head>
<body leftMargin="0" topMargin="0"  onload="GenURLImg(9);">
    <form id="Form1" method="post" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr class="lbPageTitle">
            <td align="center">
                <asp:Label ID="lblTitle" runat="server" CssClass="main-head-form">Thống kê số lượng bạn đọc vào phòng đọc nhiều nhất theo thời gian</asp:Label></td>
        </tr>
    </table>
    <p></p>
        <div style="overflow-x:auto">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tbody>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="lblCreatedDate" runat="server"><U>P</U>hòng mượn: </asp:Label>&nbsp;</td>

                        <td align="left">
                            <asp:DropDownList ID="ddlLocation" runat="server" Width="200px"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td width="40%" align="right">
                            <asp:Label ID="lblFromDate" runat="server"><U>B</U>ắt đầu từ ngày: </asp:Label>&nbsp;</td>
                        <td align="left">
                            <asp:TextBox ID="txtFromDate" runat="server" Width="90px"></asp:TextBox>&nbsp;<asp:HyperLink ID="lnkFromDate" runat="server" NavigateUrl="#">Lịch</asp:HyperLink>
                            &nbsp;<asp:Label ID="lblToDate" runat="server">đến <u>n</u>gày: </asp:Label>&nbsp;<asp:TextBox ID="txtToDate" runat="server" Width="90px"></asp:TextBox>&nbsp;<asp:HyperLink ID="lnkToDate" runat="server" NavigateUrl="#">Lịch</asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%" align="right" style="HEIGHT: 18px">
                            <asp:Label ID="lblTotal" runat="server">Số lượng bạn đọc cần thống kê: </asp:Label>&nbsp;</td>
                        <td align="left" style="HEIGHT: 18px">
                            <asp:DropDownList ID="ddlTotal" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnReport" runat="server" Text="Thống kê(t)"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
            
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="dtgResult" Width="100%" runat="server" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell" AutoGenerateColumns="False" AllowPaging="True" PageSize="20">
                                <Columns>
                                    <asp:BoundField HeaderText="STT" ItemStyle-HorizontalAlign="Center" DataField="STT" HeaderStyle-Width="5%"/>
                                    <asp:BoundField HeaderText="Số thẻ" ItemStyle-HorizontalAlign="Center" DataField="PatronCode"/>
                                    <asp:BoundField HeaderText="Họ tên" ItemStyle-HorizontalAlign="Center" DataField="FullName"/>                            
                                    <asp:BoundField HeaderText="Ngày sinh" ItemStyle-HorizontalAlign="Center" DataField="Birthday" DataFormatString="{0:dd/MM/yyyy}"/>
                                    <asp:BoundField HeaderText="Tuổi" ItemStyle-HorizontalAlign="Center" DataField="YEARS" Visible="false" />
                                    <asp:BoundField HeaderText="Số điện thoại" ItemStyle-HorizontalAlign="Center" DataField="Mobile" Visible="false" />
                                    <asp:BoundField HeaderText="Email" ItemStyle-HorizontalAlign="Center" DataField="Email" Visible="false"/>
                                    <asp:BoundField HeaderText="Facebook" ItemStyle-HorizontalAlign="Center" DataField="Facebook" Visible="false"/>
                                    <asp:BoundField HeaderText="Nhóm bạn đọc" ItemStyle-HorizontalAlign="Center" DataField="GroupName" Visible="false"/>   
                                    <asp:BoundField HeaderText="Khóa" ItemStyle-HorizontalAlign="Center" DataField="Grade" Visible="false" />
                                    <asp:BoundField HeaderText="Lớp" ItemStyle-HorizontalAlign="Center" DataField="Class"/>
                                    <asp:BoundField HeaderText="Đơn vị" ItemStyle-HorizontalAlign="Center" DataField="Faculty" Visible="false"/>
                                    <asp:BoundField HeaderText="Kho" ItemStyle-HorizontalAlign="Center" DataField="CodeLoc"/>       
                                    <asp:BoundField HeaderText="Số lần" ItemStyle-HorizontalAlign="Center" DataField="CountCheckIn"/>
                                    <asp:BoundField HeaderText="Ghi chú" ItemStyle-HorizontalAlign="Center" DataField="" Visible="false"/>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr align="left" >
                        <td colspan="2">
                            <img alt=""  src="/" border="0" name="anh1" usemap="#map1" runat="server" id="anh1" /></td>
                    </tr>
                    <tr align="left">
                        <td colspan="2">
                            <img alt="" src="/" border="0" name="anh2" runat="server" id="anh2" /></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <input id="hidHave" runat="server" type="hidden" value="0" name="hidHave" />
                            <asp:Label ID="lblPatronMax" runat="server" Visible="False">Số lượt vào phòng đọc</asp:Label>
                            <asp:Label ID="lblLocation1" runat="server" Visible="False">Phòng (</asp:Label>
                            <asp:Label ID="lblFrom" runat="server" Visible="False">Thời gian từ:</asp:Label>
                            <asp:Label ID="lblTo" runat="server" Visible="False">đến:</asp:Label>
                            <asp:Label ID="lblLocation" runat="server" Visible="False">------Chọn tên phòng-----</asp:Label>
                            <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
                                <asp:ListItem Value="0">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
                                <asp:ListItem Value="1">Giờ không hợp lệ!</asp:ListItem>
                                <asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
                                <asp:ListItem Value="3">Số thẻ không hợp lệ!</asp:ListItem>
                                <asp:ListItem Value="4">ĐKCB không hợp lệ!</asp:ListItem>
                                <asp:ListItem Value="5">Bạn đọc đã mượn quá hạn ngạch</asp:ListItem>
                                <asp:ListItem Value="6">Ngày mượn phải nhỏ hơn ngày trả!</asp:ListItem>
                                <asp:ListItem Value="7">Thẻ bạn đọc đã hết hạn!</asp:ListItem>
                                <asp:ListItem Value="8">Ngày tháng không hợp lệ!</asp:ListItem>
                                <asp:ListItem Value="9">Bắt đầu từ ngày: phải nhỏ hơn đến ngày:</asp:ListItem>
                            </asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
                        <asp:ListItem Value="0">STT</asp:ListItem>
                        <asp:ListItem Value="1">Số thẻ</asp:ListItem>
                        <asp:ListItem Value="2">Họ tên</asp:ListItem>                
                        <asp:ListItem Value="3">Ngày sinh</asp:ListItem>
                        <asp:ListItem Value="4">Tuổi</asp:ListItem>
                        <asp:ListItem Value="5">Số điện thoại</asp:ListItem>
                        <asp:ListItem Value="6">Email</asp:ListItem>
                        <asp:ListItem Value="7">Facebook</asp:ListItem>
                        <asp:ListItem Value="8">Nhóm bạn đọc</asp:ListItem>
                        <asp:ListItem Value="9">Khóa</asp:ListItem>
                        <asp:ListItem Value="10">Lớp</asp:ListItem>
                        <asp:ListItem Value="11">Đơn vị</asp:ListItem>
                        <asp:ListItem Value="12">Kho</asp:ListItem>
                        <asp:ListItem Value="13">Số lần</asp:ListItem>
                        <asp:ListItem Value="14">Ghi chú</asp:ListItem>
                
                    </asp:DropDownList>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
