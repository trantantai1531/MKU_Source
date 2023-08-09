<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WStatCreatedExpired" CodeFile="WStatCreatedExpired.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WStatCreated_Expired</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        #btnStatistic{
            margin-left:20px;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Thông kê theo thời gian cấp thẻ</h1>
            <table cellSpacing="0" cellPadding="0" width="100%">
                 <tr>
                    <td width="25%" align="right">
                        <asp:Label ID="lblFromDate" runat="server"><U>B</U>ắt đầu từ ngày: </asp:Label>&nbsp;
                        <asp:TextBox ID="txtFromDate" runat="server" Width="90px"></asp:TextBox>&nbsp;<asp:HyperLink ID="lnkFromDate" runat="server" NavigateUrl="#">Lịch</asp:HyperLink>
                    </td>
                    <td width="25%" align="right">                        
                        <asp:Label ID="lblToDate" runat="server">đến <u>n</u>gày: </asp:Label>&nbsp;
                        <asp:TextBox ID="txtToDate" runat="server" Width="90px"></asp:TextBox>&nbsp;<asp:HyperLink ID="lnkToDate" runat="server" NavigateUrl="#">Lịch</asp:HyperLink>
                    </td>
                     <td  width="30%" align="center">
                         <label>Đơn vị:</label>
                         <asp:DropDownList runat="server" ID="ddlFaculty" ></asp:DropDownList>
                     </td>
                     <td  width="20%" align="center">                         
                         <asp:Button ID="btnStatistic" runat="server" Text="Thống kê(s)" Width="" ></asp:Button>
                     </td>
            </table>
            <%--<div class="TabbedPanelsContent">
                <div id="TabbedPanels3" class="TabbedPanels">
                    <div class="TabbedPanelsContentGroup">
                        <div class="TabbedPanelsContent">
                            <h1 class="main-head-form">Thông kê theo thời gian cấp thẻ</h1>
                            <div class="three-column ClearFix">
                                <div class="three-column-form" style="width:30%">
                                    <div class="row-detail">
                                        <div class="radio-control">
                                            <asp:RadioButton ID="optAllYearsExpried" runat="server" Text="Tấ<u>t</u> cả các năm" GroupName="ExpiredDate" Checked="true"></asp:RadioButton>
                                            <asp:RadioButton ID="optEachYearExpired" runat="server" Text="Từn<u>g</u> năm:" GroupName="ExpiredDate"></asp:RadioButton>
                                        </div>
                                    </div>


                                </div>
                                <div class="three-column-form" style="width:30%">
                                   <div class="row-detail">
                                        <p>Năm hoạt động:</p>
                                        <div class="input-control" style="display:inline-block; max-width:120px;">
                                            <div class="input-form ">
                                                <asp:TextBox CssClass="text-input" ID="txtYear" runat="server" Width=""></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="three-column-form" style="width:39%">
                                     <div class="row-detail">
                                        <label>Đơn vị:</label>
                                        <asp:DropDownList runat="server" ID="ddlFaculty"></asp:DropDownList>
                                        <asp:Button ID="btnStatistic" runat="server" Text="Thống kê(s)" Width="" ></asp:Button>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Mã lổi: </asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
            <asp:ListItem Value="3">Năm cấp thẻ không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="4">Tất cả</asp:ListItem>
            <asp:ListItem Value="5">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="6">Bạn chưa chọn thời gian!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
