<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WSearchForm"
    CodeFile="WSearchForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSearchForm</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" onload="document.forms[0].txtFromDate.focus()">
    <form id="Form1" method="post" runat="server">
    <div class="main-body">
        <div class="content-form">
            <h1 class="main-head-form">
                Tra cứu Log</h1>
            <div class="ClearFix main-page">
                <div class="col-left-4">
                    <div class="row-detail inline-box">
                       <label> Từ:</label>&nbsp;<asp:HyperLink
                            ID="lnkFromDate" runat="server">Lịch</asp:HyperLink>
                        <div class="input-control">
                            <div class="input-form">
                                <asp:TextBox ID="txtFromDate" CssClass="text-input" runat="server" PlaceHolder="dd/mm/yyyy"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblfromtime" runat="server">Thời gian từ giờ: </asp:Label>
                        <div class="input-control">
                            <div class="input-form">
                                <asp:TextBox ID="txtFromTime" CssClass="text-input" runat="server" PlaceHolder="hh:mi"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblToDate" runat="server"> Ngày đến: </asp:Label>&nbsp;<asp:HyperLink
                            ID="lnkToDate" runat="server">Lịch</asp:HyperLink>
                        <div class="input-control">
                            <div class="input-form">
                                <asp:TextBox ID="txtToDate" CssClass="text-input" runat="server"  PlaceHolder="dd/mm/yyyy"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lbltotime" runat="server"> Thời gian đến: </asp:Label>
                        <div class="input-control">
                            <div class="input-form">
                                <asp:TextBox ID="txtToTime" CssClass="text-input" runat="server" PlaceHolder="hh:mi"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblWord" runat="server">Thông điệp chứa <U>c</U>ụm từ:</asp:Label>
                        <div class="input-control">
                            <div class="input-form">
                                <asp:TextBox ID="txtWord" CssClass="text-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-right-6">
                    <div class="text-column-2 ClearFix">
                        <div class="column-item">
                            <div class="group-menu">
                                <div class="row-detail">
                                    <asp:Label ID="lblGroup" runat="server">Nhóm <U>s</U>ự kiện:</asp:Label>
                                    <div class="input-control">
                                        <div class="listbox-form">
                                            <select id="lsbGroup" size="10" name="lsbGroup" runat="server" multiple="true">
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="group-menu">
                                <div class="row-detail">
                                     <asp:Label ID="lblUser" runat="server">Người <U>d</U>ùng:</asp:Label>
                                    <div class="input-control">
                                        <div class="listbox-form">
                                            <asp:ListBox ID="lsbUser" runat="server" Rows="5" SelectionMode="Multiple"></asp:ListBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                               <asp:Button ID="btnSearch" CssClass="form-btn" runat="server" Width="65px" Text="Tìm(s)">
                            </asp:Button>
                            </div>
                            <div class="button-form">
                                 <asp:Button ID="btnReset" CssClass="form-btn" runat="server" Width="92px" Text="Đặt lại(r)">
                            </asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
        <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
        <asp:ListItem Value="3">Khuôn dạng giờ không hợp lệ (hh:mi)</asp:ListItem>
    </asp:DropDownList>
    </form>
</body>
</html>
