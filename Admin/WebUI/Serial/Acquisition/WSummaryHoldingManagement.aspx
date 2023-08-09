<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WSummaryHoldingManagement" CodeFile="WSummaryHoldingManagement.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSummaryHoldingManagement</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
       <style>
        #divBody .tab
        {
            display: inline;
            text-align: right;
        }
        #divBody .tab ul
        {
            padding-top: 5px;
        }
               #divBody .tab ul li
        {
            background: #f0a30a none repeat scroll 0 0;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
        }
        li
        {
            list-style: outside none none;
        }
        
        #divBody .tab ul li a
        {
            color: #fff;
        }
          #divBody .tab ul li.active
        {
            background-color: #000;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
        }
    </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">

        <div id="divBody">
           <%-- <div id="TabbedPanels1" class="TabbedPanels">
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab " tabindex="0">
                                <asp:HyperLink ID="lnkHdAcquire" runat="server"  CssClassNavigateUrl="WAcquire.aspx">Bổ sung</asp:HyperLink></li>
                            <li class="TabbedPanelsTab " tabindex="0">
                                <asp:HyperLink ID="lnkHdSetRegularity" runat="server" NavigateUrl="WSetRegularity.aspx">Định kỳ</asp:HyperLink></li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink ID="lnkHdRegister" runat="server" NavigateUrl="WCreateIssue.aspx">Đăng ký</asp:HyperLink></li>
                            <li class="TabbedPanelsTab " tabindex="0">
                                <asp:HyperLink ID="lnkHdReceive" runat="server" NavigateUrl="WReceive.aspx">Ghi nhận</asp:HyperLink></li>
                            <li class="TabbedPanelsTab " tabindex="0">
                                <asp:HyperLink ID="lnkHdView" runat="server" NavigateUrl="WViewInCalendarMode.aspx">Kiểm tra</asp:HyperLink></li>
                            <li class="TabbedPanelsTab " tabindex="0">
                                <asp:HyperLink ID="lnkHdBinding" runat="server" NavigateUrl="WBinding.aspx">Đóng tập</asp:HyperLink></li>
                           
                        </ul>
                    </div>
                </div>
            </div>--%>
            <div class="tab">
            <ul>
                <li>
                    <asp:HyperLink ID="lnkHdAcquire" runat="server" CssClass="lbLinkFunction" NavigateUrl="WAcquire.aspx">Bổ sung</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdSetRegularity" runat="server" CssClass="lbLinkFunction">Định kỳ</asp:HyperLink></li>
                <li >
                   <asp:HyperLink ID="lnkHdRegister" runat="server" NavigateUrl="WCreateIssue.aspx">Đăng ký</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdReceive" runat="server" CssClass="lbLinkFunction" NavigateUrl="WReceive.aspx">Ghi nhận</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdView" runat="server" CssClass="lbLinkFunction" NavigateUrl="WViewInCalendarMode.aspx">Kiểm tra</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdBinding" runat="server" CssClass="lbLinkFunction" NavigateUrl="WBinding.aspx">Đóng tập</asp:HyperLink></li>
                <li class="active">
                    <span>
                        Tổng hợp
                    </span>
                   
                </li>
            </ul>
        </div>
            <div class="main-form">
            <div class="main-head-form">
                 <asp:Label runat="server" ID="lblTitle" ></asp:Label>
            </div>
               
                <div class="row-detail">
                    <div class="input-control">
                        <asp:Label runat="server" Text="Tổng hợp:"></asp:Label>
                        <div class="input-form">
                            <asp:TextBox Width="100%" CssClass="area-input" TextMode="MultiLine" Rows="10" ID="txtAcqData" runat="server" Height="120px"></asp:TextBox>
                        </div>
                        <asp:Label runat="server" Text="Ghi chú:"></asp:Label>
                        <div class="input-form">
                            <asp:TextBox Width="100%" CssClass="area-input" TextMode="MultiLine" Rows="10" ID="txtNote" runat="server" Height="120px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <asp:Button CssClass="lbButton" runat="server" ID="btnUpdate" Text="Cập nhật (u)"></asp:Button>
            </div>
            <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Height="0" Visible="False">
                <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
                <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
                <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
                <asp:ListItem Value="3">Cập nhật số liệu bổ sung tổng hợp</asp:ListItem>
                <asp:ListItem Value="4">Nhan đề</asp:ListItem>
                <asp:ListItem Value="5">T</asp:ListItem>
                <asp:ListItem Value="6">Cập nhật thành công!</asp:ListItem>
                <asp:ListItem Value="7">Không tập</asp:ListItem>
            </asp:DropDownList>
            </div>
      
    </form>
    <script language="javascript">
        document.forms[0].txtAcqData.focus();
    </script>
</body>
</html>
