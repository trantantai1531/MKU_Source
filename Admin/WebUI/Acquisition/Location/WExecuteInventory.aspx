<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WExecuteInventory" CodeFile="WExecuteInventory.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 transitional//EN">
<html xmlns:o="urn:schemas-microsoft-com:office:office">
<head>
    <title>Kiểm kê</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script language="javascript">
        function ShowHideTable(val) {
            if (val == 0) {
                tblFormInventory.style.display = "";
                tblResultInventory.style.display = "none";
            }
            else {
                tblResultInventory.style.display = "";
                tblFormInventory.style.display = "none";
            }
        }
    </script>
</head>
<body leftmargin="5" topmargin="5">
    <form name="frm" method="post" action="WExecuteInventory.aspx" id="frm" enctype="multipart/form-data"
        runat="server">
        <div id="divBody">
            <div id="tblFormInventory" class="main-body">
                <h1 class="main-head-form">Kỳ kiểm kê</h1>
                <div class="row-detail">
                    <p>Kỳ kiểm kê :</p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlInventory" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <h1 class="main-group-form">Phạm vi kiểm kê</h1>
                <div class="row-detail">
                    <p>Tên thư viện :</p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlLibrary" runat="server" AutoPostBack="True"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Tên kho :</p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlLocation" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Tên giá sách :</p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox CssClass="text-input" ID="txtShelf" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <h1 class="main-group-form">Hình thức kiểm kê</h1>
                <asp:RadioButtonList ID="optPurpose" runat="server" CssClass="lbRadio">
                    <asp:ListItem Value="0" Selected="True">Khởi tạo <u>l</u>ại kết quả kiểm kê</asp:ListItem>
                    <asp:ListItem Value="1"><u>B</u>ổ sung tiếp vào kết quả kiểm kê hiện thời</asp:ListItem>
                </asp:RadioButtonList>
                <%--<div class="radio-control">

                        <input id="r01" type="radio" name="rr0" value="Radio 1" checked="checked">
                        <label for="r01">Khởi tạo lại kết quả kiểm kê</label>
                    </div>
                    <div class="radio-control">
                        <input id="r02" type="radio" name="rr0" value="Radio 1">
                        <label for="r02">Bổ sung tiếp vào kết quả kiểm kê hiện thời</label>
                    </div>--%>



                <h1 class="main-group-form">Nguồn đưa vào kiểm kê</h1>
                <div class="row-detail">
                    <div class="radio-control">
                        <asp:RadioButton ID="optFile" runat="server" CssClass="lbRadio" GroupName="OptionGroup" Text="Tệ<U>p</U> chứa danh sách ĐKCB"
                            Checked="true"></asp:RadioButton>
                        <label for="optFile"></label>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="input-control">
                        <div class="input-form fileAttach ">
                            <input id="filAttachment" class="text-input" type="file" size="25" name="filAttachment3" runat="server"/>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="radio-control">
                        <asp:RadioButton ID="optList" runat="server" CssClass="lbRadio" GroupName="OptionGroup" Text="Danh <U>s</U>ách ĐKCB nhập bên dưới(cách nhau bởi đấu , hoặc ;)"></asp:RadioButton>
                        <label for="optList"></label>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtCopyNumbers" runat="server" Width="" Height="85px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnInventory" runat="server" Text="Kiểm kê(k)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnViewResult" runat="server" Text="Xem kết quả(x)" Width=""></asp:Button>
                        </div>
                    </div>
                    <!--</div>
                </div>-->
                </div>
            </div>
            <div id="tblResultInventory" class="main-body">
                <asp:Label ID="lblResult" runat="server" Width="100%" CssClass="main-group-form">Kết quả kiểm kê 
                    </asp:Label><asp:HyperLink ID="lnkOtherRemove" NavigateUrl="WExecuteInventory.aspx" runat="server">Thực hiện kiểm kê khác</asp:HyperLink>
                <div>
                    <asp:Label ID="lblLibName" runat="server" Visible="False"><b>Thư viện:</b></asp:Label><br />
                    <asp:Label ID="lblLocName" runat="server" Visible="False"><b>Kho:</b></asp:Label><br />
                    <asp:Label ID="lblShelfInv" runat="server" Visible="False"><b>Giá:</b></asp:Label>

                </div>
                <asp:Label ID="lblDetailResult" runat="server" CssClass="main-group-form">Chi tiết kết quả (Thời gian thực hiện:</asp:Label>
                <div>
                    <asp:Label ID="lblTotalInventory" runat="server">Tổng số bản ghi kiểm kê: </asp:Label><br />
                    <asp:Label ID="lblTotalNoLoop" runat="server">Tổng số bản ghi thực kiểm kê(lọc bỏ các đăng ký cá biệt trùng): </asp:Label><br />
                    <asp:Label ID="lblTotalLost" runat="server">Tổng số ĐKCB bị thiếu:</asp:Label><br />
                    <asp:Label ID="lblTotalWrong" runat="server">Tổng số bản ghi đặt nhầm chỗ: </asp:Label>
                    <asp:Label ID="lblWrongDetail" runat="server">Các đăng ký cá biệt đặt nhầm chỗ là: </asp:Label>
                    <asp:Label ID="lblLnkWrongDetail1" runat="server" Visible="False">&nbsp;Nhấn</asp:Label>&nbsp;<asp:HyperLink ID="lnkFileStoreCN" runat="server" Visible="False">vào đây</asp:HyperLink>&nbsp;<asp:Label ID="lblLnkWrongDetail2" runat="server" Visible="False">để lấy file</asp:Label><br />
                    <asp:Label ID="lblTotalNo" runat="server">Tổng số bản ghi không có trong dữ liệu là: </asp:Label><br />
                    <asp:Label ID="lblNoDetail" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;Các đăng ký cá biệt không có trong dữ liệu là: </asp:Label>
                </div>
            </div>
        </div>
            <input id="hidFormAction" type="hidden" name="hidFormAction" runat="server">
        <input id="txtHiddenPathFile" type="hidden" name="txtHiddenPathFile" runat="server">
        <input id="txtLibraryID" type="hidden" name="txtLibraryID" runat="server">
        <input id="txtLocationID" type="hidden" name="txtLocationID" runat="server">
        <input id="txtInventoryID" type="hidden" name="txtInventoryID" runat="server">
        <script language="javascript">
            if (document.forms[0].hidFormAction.value == 0)
                ShowHideTable(0);
            else
                ShowHideTable(1);
        </script>
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi </asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="3">Kiểm kê</asp:ListItem>
            <asp:ListItem Value="4">Lỗi trong quá trình xử lý</asp:ListItem>
            <asp:ListItem Value="5">Tổng số bản ghi thực kiểm kê(lọc bỏ các đăng ký cá biệt trùng):</asp:ListItem>
            <asp:ListItem Value="6">Tổng số bản ghi đặt nhầm chỗ:</asp:ListItem>
            <asp:ListItem Value="7">&nbsp;&nbsp;&nbsp;&nbsp;Các đăng ký cá biệt đặt nhầm chỗ là:</asp:ListItem>
            <asp:ListItem Value="8">Tổng số bản ghi không có trong dữ liệu là:</asp:ListItem>
            <asp:ListItem Value="9">&nbsp;&nbsp;&nbsp;&nbsp;Các đăng ký cá biệt không có trong dữ liệu là:</asp:ListItem>
            <asp:ListItem Value="10">Không tồn tại file này.</asp:ListItem>
            <asp:ListItem Value="11">Không có đăng ký cá biệt nào được chọn.</asp:ListItem>
            <asp:ListItem Value="12">Không có.</asp:ListItem>
            <asp:ListItem Value="13">Đang kiểm kê ...</asp:ListItem>
            <asp:ListItem Value="14">Đã thực hiện xong!</asp:ListItem>
            <asp:ListItem Value="15">giờ</asp:ListItem>
            <asp:ListItem Value="16">phút</asp:ListItem>
            <asp:ListItem Value="17">giây</asp:ListItem>
            <asp:ListItem Value="18">Tổng số bản ghi kiểm kê:</asp:ListItem>
            <asp:ListItem Value="19">Không có kho nào được đóng.</asp:ListItem>
            <asp:ListItem Value="20">Tổng số ĐKCB bị thiếu: </asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
