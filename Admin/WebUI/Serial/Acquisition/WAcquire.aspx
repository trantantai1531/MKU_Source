<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WAcquire"
    CodeFile="WAcquire.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WAcquire</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
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
    <div id="divBody">
        <div class="tab">
            <ul>
                <li class="active">
                    <asp:Label ID="lblAcquire" runat="server" CssClass="lbGroupTitle">Bổ sung</asp:Label></li>
                <li>
                    <asp:HyperLink ID="lnkHdSetRegularity" runat="server" CssClass="lbLinkFunction">Định kỳ</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdRegister" runat="server" CssClass="lbLinkFunction">Đăng ký</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdReceive" runat="server" CssClass="lbLinkFunction">Ghi nhận</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdView" runat="server" CssClass="lbLinkFunction">Kiểm tra</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdBinding" runat="server" CssClass="lbLinkFunction">Đóng tập</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdSummary" runat="server" CssClass="lbLinkFunction">Tổng hợp</asp:HyperLink></li>
            </ul>
        </div>
        <asp:Label ID="lblTitle" runat="server" CssClass="main-head-form" Width="100%"></asp:Label>
        <div class="main-form">
            <div class="two-column ClearFix">
                <div class="two-column-form">
                    <div class="row-detail">
                        <asp:Label ID="lblSerCategory" runat="server"><U>K</U>iểu ấn phẩm:</asp:Label>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlSerCategory" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblAcqSource" runat="server"><U>H</U>ình thức bổ sung:</asp:Label>
                        <div class="input-control">
                            <div class="dropdown-form ">
                                <asp:DropDownList ID="ddlAcqSource" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                      <div class="row-detail">
                        <asp:Label ID="lblPO" runat="server">Đơn Đặt</asp:Label>
                        <div class="input-control">
                            <div class="dropdown-form ">
                                <asp:DropDownList ID="ddlAQCPO" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail" style="display: none">
                        <asp:Label ID="lblContractCode" runat="server">Hợ<U>p</U> đồng:</asp:Label>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtContractCode" runat="server" ReadOnly="True"></asp:TextBox>

                            </div>
                        </div>
                    </div>
                    <div class="row-detail" style="display:none">
                        <div class="button-control">
                            <div class="button-form ">
                                <asp:Button ID="btnViewContract" runat="server" Text="Xem(w)" Width=""></asp:Button>
                            </div>
                            <div class="button-form ">
                                <asp:Button ID="btnSearch" runat="server" Text="Chọn(i)" Width=""></asp:Button>
                            </div>
                            <div class="button-form ">
                                <asp:Button ID="btnRemove" runat="server" Text="Xoá(e)" Width=""></asp:Button>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblStatus" runat="server">Trạng thái đặt mua:</asp:Label>
                        <div class="radio-control ">
                            <asp:RadioButtonList ID="rdoStatus" runat="server" RepeatDirection="Horizontal" CssClass="lbRadio">
                                <asp:ListItem Value="1" Selected="True"><U>Đ</U>ang đặt</asp:ListItem>
                                <asp:ListItem Value="2">Ngừng/<U>C</U>hưa đặt</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblBasedDate" runat="server"><U>N</U>gày nhập số đầu tiên:</asp:Label><asp:HyperLink
                            ID="lnkBasedDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtBasedDate" runat="server" Width="90px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="two-column-form">
                    <div class="row-detail" style="width: 20%; display: inline-block;">
                        <asp:Label ID="lblCeased" runat="server">Đã đình <U>b</U>ản:</asp:Label>
                        <br />
                        <div class="checkbox-control">
                            <asp:CheckBox ID="chkCeased" runat="server" CssClass="excheckbox"></asp:CheckBox>
                            <label for="chkCeased">
                            </label>
                        </div>
                    </div>
                    <div class="row-detail" style="width: 49.5%; display: inline-block;">
                        <asp:Label ID="lblCeasedDate" runat="server">Ngà<u>y</u> đình bản:</asp:Label><asp:HyperLink
                            ID="lnkCeasedDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink>
                        <div class="input-control">
                            <div class="input-form " style="display: inline-block; width: 120px;">
                                <asp:TextBox CssClass="text-input" ID="txtCeasedDate" runat="server" Width=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblChangeNote" runat="server">Các <u>t</u>hay đổi khác:</asp:Label>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtChangeNote" runat="server" Width="450"
                                    TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblNote" runat="server"><U>G</U>hi chú:</asp:Label>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtNote" runat="server" Width="450" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="three-column ClearFix">
                            <div class="three-column-form">
                                <asp:Label ID="lblLibrary" runat="server">Thư <U>v</U>iện:</asp:Label>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlLibrary" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="three-column-form">
                                <asp:Label ID="lblLocation" runat="server">Kh<U>o</U>:</asp:Label>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlLocation" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="three-column-form">
                                <asp:Label ID="lblCopies" runat="server">Số <U>l</U>ượng:</asp:Label>
                                <div class="input-control">
                                    <div class="input-form">
                                        <asp:TextBox CssClass="text-input" ID="txtCopies" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblRemainCopies" runat="server" Visible="False">Số <U>b</U>ản chưa phân kho: </asp:Label>
                        <div class="input-control">
                            <asp:TextBox CssClass="text-input" ID="txtRemainCopies" runat="server" Width="" Style='border-right: medium none;
                                border-top: medium none; font-size: 12px; border-left: medium none; border-bottom: medium none;
                                background-color: #f0f3f4' Visible="False" ReadOnly="True">0</asp:TextBox>
                            <asp:Button ID="btnRoute" runat="server" Text="Nhập(a)" Width=""></asp:Button>
                            <asp:Button ID="btnView" runat="server" Text="Xem(v)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row-detail">
                <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật(u)" Width="" CssClass="form-btn">
                </asp:Button>
                <asp:Button ID="btnReset" runat="server" Text="Làm lại(r)" Width="" CssClass="form-btn">
                </asp:Button>
            </div>
        </div>
    </div>
    <input id="hidContractID" type="hidden" runat="server" value="0">
    <input id="hidLocationID" type="hidden" runat="server" value="0">
    <input id="hidCurrentDate" type="hidden" runat="server" name="hidCurrentDate">
    <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
        <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="2">----- Chọn -----</asp:ListItem>
        <asp:ListItem Value="3">Cập nhật thông tin thành công</asp:ListItem>
        <asp:ListItem Value="4">Lỗi trong quá trình cập nhật</asp:ListItem>
        <asp:ListItem Value="5">Bạn có thực sự muốn bỏ đơn đặt gắn với tài liệu này không?</asp:ListItem>
        <asp:ListItem Value="6">Số lượng phân kho vượt quá số lượng đặt mua</asp:ListItem>
        <asp:ListItem Value="7">Cập nhật thông tin bổ sung của ấn phẩm có nhan đề: </asp:ListItem>
        <asp:ListItem Value="8">Bạn chưa nhập ngày đình bản !</asp:ListItem>
        <asp:ListItem Value="9">Dữ liệu không phải dạng số</asp:ListItem>
        <asp:ListItem Value="10">Sai định dạng ngày tháng</asp:ListItem>
        <asp:ListItem Value="11">Ngày đình bản phải sau ngày nhập số đầu tiên!</asp:ListItem>
        <asp:ListItem Value="12">Ngày đình bản phải trước ngày hiện tại!</asp:ListItem>
        <asp:ListItem Value="13">Số lượng phân kho phải là số lớn hơn 0!</asp:ListItem>
        <asp:ListItem Value="14">Bạn chưa chọn kho!</asp:ListItem>
        <asp:ListItem Value="15">Bạn không được cấp quyền sử dụng chức năng này.</asp:ListItem>
    </asp:DropDownList>
    </form>
</body>
</html>
