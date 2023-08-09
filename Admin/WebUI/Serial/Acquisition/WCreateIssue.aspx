<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WCreateIssue"
    CodeFile="WCreateIssue.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCreateIssue</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
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
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
    <table id="tblHeader" cellspacing="0" cellpadding="4" width="100%" border="0" runat="server">
    </table>
    <div id="divBody">
        <div class="tab">
            <ul>
                <li>
                    <asp:HyperLink ID="lnkHdAcquire" runat="server" CssClass="lbLinkFunction" NavigateUrl="WAcquire.aspx">Bổ sung</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdSetRegularity" runat="server" CssClass="lbLinkFunction">Định kỳ</asp:HyperLink></li>
                <li class="active">
                    <asp:Label ID="lblHdRegister" runat="server" CssClass="lbGroupTitle">Đăng ký</asp:Label></li>
                <li>
                    <asp:HyperLink ID="lnkHdReceive" runat="server" CssClass="lbLinkFunction" NavigateUrl="WReceive.aspx">Ghi nhận</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdView" runat="server" CssClass="lbLinkFunction" NavigateUrl="WViewInCalendarMode.aspx">Kiểm tra</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdBinding" runat="server" CssClass="lbLinkFunction" NavigateUrl="WBinding.aspx">Đóng tập</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdSummary" runat="server" CssClass="lbLinkFunction" NavigateUrl="WSummaryHoldingManagement.aspx">Tổng hợp</asp:HyperLink></li>
            </ul>
        </div>
        <div class="row-detail">
            <h1 class="main-head-form">
                <asp:Label ID="lblTitle" runat="server" Width="100%"></asp:Label></h1>
            <div class="button-control" style="text-align: center;">
                <div class="button-form">
                    <asp:Label ID="lblCreateIssue" runat="server" CssClass="lbSubFormTitle">Đăng ký trực tiếp</asp:Label>
                </div>
                <div class="button-form">
                    <asp:HyperLink ID="lnkRegister" NavigateUrl="~/Serial/Acquisition/WRegisterIssues.aspx" runat="server" CssClass="lbLinkFunction">Đăng ký tự động</asp:HyperLink>
                </div>
            </div>
            <p>
                <asp:Label ID="lblLastIssuelb" runat="server">Số cuối:</asp:Label>
                <asp:Label ID="lblLastIssue" runat="server"></asp:Label>
                <asp:HyperLink ID="lnkNextIssue" runat="server" CssClass="lbLinkFunction">Số tiếp</asp:HyperLink></p>
        </div>
        <div class="two-column ClearFix">
            <div class="two-column-form">
                <div class="row-detail ClearFix">
                    <div class="span1">
                        <div class="pad5">
                            <p>
                                <asp:Label ID="lblIssueNo" runat="server"><U>S</U>ố:</asp:Label></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtIssueNo" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="span6">
                        <div class="pad5">
                            <p>
                                <asp:Label ID="lblOvIssueNo" runat="server"><U>S</U>ố toàn cục:</asp:Label></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtOvIssueNo" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="checkbox-control">
                        <asp:CheckBox ID="chkFirstIssueInYear" runat="server" Text="<U>S</U>ố đầu của năm">
                        </asp:CheckBox>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblVolumeByPublisher" runat="server"><U>T</U>ập:</asp:Label></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtVolumeByPublisher" runat="server" Width="330"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblIssuedDate" runat="server"><U>N</U>gày phát hành:</asp:Label>
                        <asp:HyperLink ID="lnkIssuedDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtIssuedDate" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblPhysDetail" runat="server"><U>Đ</U>ặc điểm vật lý:</asp:Label></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtPhysDetail" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="two-column-form">
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblCopies" runat="server">Số <U>l</U>ượng đặt:</asp:Label></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtCopies" runat="server">0</asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblSpecialTitle" runat="server"><U>T</U>ên số đặc biệt:</asp:Label></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtSpecialTitle" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblPrice" runat="server">Đơn <U>g</U>iá:</asp:Label></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtPrice" runat="server">0</asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblNote" runat="server">Ghi <U>c</U>hú:</asp:Label></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtNote" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblSummary" runat="server"><U>T</U>óm tắt:</asp:Label></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtSummary" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="checkbox-control">
                        <asp:CheckBox ID="chkSpecialIssue" runat="server" Text="<U>P</U>hụ trương, phụ bản, tờ rơi, phần bổ sung">
                        </asp:CheckBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="row-detail">
            <div style="text-align: center;" class="button-control">
                <div class="button-form">
                    <asp:Button ID="btnUpdate" runat="server" Width="90px" Text="Cập nhật(u)"></asp:Button>
                </div>
                <div class="button-form">
                    <asp:Button ID="btnDelete" runat="server" Width="64px" Text="Xoá(d)" Visible="False">
                    </asp:Button>
                </div>
                <div class="button-form">
                    <asp:Button ID="btnReset" runat="server" Width="88px" Text="Đặt lại(r)"></asp:Button>
                </div>
            </div>
        </div>
    </div>
    <input id="hidLastIssueNo" type="hidden" runat="server" value="0" />
    <input id="hidLastOvIssueNo" type="hidden" runat="server" value="0" />
    <input id="hidIssueID" type="hidden" runat="server" />
    <input id="hidClaimCycle1" type="hidden" runat="server" value="0" />
    <input id="hidClaimCycle2" type="hidden" runat="server" value="0" />
    <input id="hidClaimCycle3" type="hidden" runat="server" value="0" />
    <input id="hidDeliveryTime" type="hidden" runat="server" />
    <input id="hidResetRegularity" type="hidden" runat="server" value="0" />
    <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
        <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="2">Đăng ký số mới cho ấn phẩm có nhan đề</asp:ListItem>
        <asp:ListItem Value="3">Xoá số của ấn phẩm có nhan đề</asp:ListItem>
        <asp:ListItem Value="4">Cập nhật thành công</asp:ListItem>
        <asp:ListItem Value="5">Tạo mới thành công</asp:ListItem>
        <asp:ListItem Value="6">Xoá thành công</asp:ListItem>
        <asp:ListItem Value="7">Lỗi trong quá trình xử lý</asp:ListItem>
        <asp:ListItem Value="8">Số này đã tồn tại</asp:ListItem>
        <asp:ListItem Value="9">Ngày phát hành đã tồn tại</asp:ListItem>
        <asp:ListItem Value="10">Số toàn cục này đã tồn tại</asp:ListItem>
        <asp:ListItem Value="11">Xoá số thành công</asp:ListItem>
        <asp:ListItem Value="12">Bạn phải huỷ ghi nhận các bản tạp chí của số trước khi xoá</asp:ListItem>
        <asp:ListItem Value="13">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
        <asp:ListItem Value="14">Dữ liệu không hợp lệ !</asp:ListItem>
        <asp:ListItem Value="15">Bản ghi không được cập nhật nếu giá trị trường này trống</asp:ListItem>
        <asp:ListItem Value="16">Số lượng đặt phải lớn hơn 0</asp:ListItem>
        <asp:ListItem Value="17">Số toàn cục phải lớn hơn số cục bộ!</asp:ListItem>
        <asp:ListItem Value="18">Bạn có muốn xoá số đã chọn không!</asp:ListItem>
    </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtIssueNo.focus();
    </script>
</body>
</html>
