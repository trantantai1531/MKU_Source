<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WHoldingLocRemove" CodeFile="WHoldingLocRemove.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WHoldingLocRemove</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Thanh lý</h1>
                <div id="tblFormLiquidate" class="two-column ClearFix">
                    <div class="col-left-6">
                        <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="rdbCodeDoc" runat="server" Text="Thanh lý theo đầu ấn <u>p</u>hẩm" Checked="True"
                                    GroupName="rdbGroupName"></asp:RadioButton>
                                <label for="rdbCodeDoc"></label>
                            </div>
                            <div class="input-control">
                                <p>Mã tài liệu :</p>
                                <div class="input-form " style="display: inline-block; width: 35%">
                                    <asp:TextBox CssClass="text-input" ID="txtCodeDoc" runat="server"></asp:TextBox>
                                </div>
                                <asp:Button ID="btnFindCode" Width="" runat="server" Text="Tìm(m)"></asp:Button>
                            </div>
                        </div>
                        <hr />
                                                <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="rdbCopyNum" runat="server" Text="Thanh lý theo ĐKC<u>B</u>" GroupName="rdbGroupName"></asp:RadioButton>
                                <label for="r022"></label>
                            </div>
                            <div class="input-control">
                                <p>Thư viện :</p>
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLibSource" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="input-control">
                                <p>Kho :</p>
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLocSource" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="input-control">
                                <p>Giá :</p>
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtShelfSource" Width="" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="rdbCopyNumFile" CssClass="radio" runat="server" Text="Danh sách ĐKCB lấy từ <u>f</u>ile" Checked="True"
                                    GroupName="rdbGroupNameCN"></asp:RadioButton>
                            </div>
                            <div class="input-control">
                                <div class="input-form  fileAttach">
                                    <input id="FileCopyNum" class="text-input" type="file" name="FileCopyNum" runat="server"/>
                                </div>
                            </div>
                        </div>

                        <div class="row-detail">
                            <div class="radio-control">

                                    <asp:RadioButton ID="rdbCopyNumManual" runat="server" Text="Danh <u>s</u>ách ĐKCB nhập bên dưới"
                                        GroupName="rdbGroupNameCN"></asp:RadioButton>&nbsp;<asp:HyperLink ID="lnkShowCopyNum" runat="server" NavigateUrl="#">Thêm ĐKCB</asp:HyperLink>
 
                            </div>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="area-input" Height="100px" ID="txtCopyNumManual" Width="" runat="server" Rows="5" TextMode="MultiLine"
                                        Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-left-4">
                        <div class="row-detail">
                            <p>Mã thanh lý :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCodeRemove" Width="" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Ngày thanh lý :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtDateRemove" Width="" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Lý do :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlReason" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="button-control" style="text-align: right">
                                <div class="button-form">
                                    <asp:Button ID="btnLocRemove" Width="" runat="server" Text="Thanh lý(t)"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tblResultLiqudate" class="ClearFix">
                    <asp:Label ID="lblResult" runat="server" Width="100%" CssClass="main-group-form">Kết quả ghi nhận thanh lý</asp:Label>
                    <asp:HyperLink ID="lnkOtherRemove" runat="server" NavigateUrl="WHoldingLocRemove.aspx">Giao dịch thanh lý khác</asp:HyperLink>
                    <div>
                        <asp:Label ID="lblLibName" runat="server" Visible="False"><b>Thư viện:</b></asp:Label><asp:Label ID="lblLocName" runat="server" Visible="False"><b>Kho:</b></asp:Label><asp:Label ID="lblReasonR" runat="server" Visible="False"><b>Lý 
											do:</b></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="lblDetailResult" runat="server" CssClass="lbPageTitle">Chi tiết kết quả</asp:Label><br />
                        <asp:Label ID="lblTotalRemove" runat="server">Số đăng ký cá biệt đưa vào thanh lý:</asp:Label><br />
                        <asp:Label ID="lblNumRemove" runat="server">Số đăng ký cá biệt được ghi nhận thanh lý:</asp:Label><br />
                        <asp:Label ID="lblNumNoRemove" runat="server">Số đăng ký cá biệt không được ghi nhận thanh lý:</asp:Label><br />
                        <ul>
                            <li>
                                <asp:Label ID="lblNumNoRemove1" runat="server">Vì đang ghi mượn:</asp:Label>
                            <li>
                                <asp:Label ID="lblNumNoRemove2" runat="server">Vì lý do khác:</asp:Label>
                            </li>
                        </ul>
                    </div>

                </div>
            </div>
        </div>

        <input id="hidLocSourceName" type="hidden" name="hidLocSourceName" runat="server"/>
        <input id="hidFormAction" type="hidden" name="hidFormAction" runat="server"/>
        <script language="javascript">
            if (document.forms[0].rdbCodeDoc.checked)
                SwitchEnable(0);
            else {
                SwitchEnable(1);
                if (document.forms[0].rdbCopyNumFile.checked)
                    SwitchCopyNum(0);
                else
                    SwitchCopyNum(1);
            }
            if (document.forms[0].hidFormAction.value == 0)
                ShowHideTable(0);
            else
                ShowHideTable(1);
        </script>
        <asp:DropDownList ID="ddlLabelNote" runat="server" Visible="False">
            <asp:ListItem Value="0">Phương thức chưa có giá trị!</asp:ListItem>
            <asp:ListItem Value="1">Đã thực hiện xong!</asp:ListItem>
            <asp:ListItem Value="2">Ngày tháng không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="3">Bạn chưa chọn thư viện thư viện!</asp:ListItem>
            <asp:ListItem Value="4">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="5">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="6">Thanh lý</asp:ListItem>
            <asp:ListItem Value="7">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="8">Đã thanh lý được:</asp:ListItem>
            <asp:ListItem Value="9">Đang thanh lý ...</asp:ListItem>
            <asp:ListItem Value="10">----- Chọn -----</asp:ListItem>
            <asp:ListItem Value="11">Thanh lý theo mã tài liệu:</asp:ListItem>
            <asp:ListItem Value="12">Số đăng ký cá biệt thực sự có trong kho:</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
