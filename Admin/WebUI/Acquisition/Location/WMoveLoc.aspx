<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WMoveLoc" CodeFile="WMoveLoc.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WMoveLoc</title>
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
                <h1 class="main-head-form">Chuyển kho</h1>
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Thư viện :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLibSource" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row-detail">
                            <p>Kho :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLocSource" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row-detail">
                            <p>Giá :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input"  ID="txtShelfSource" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Thư viện :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLibDestination" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row-detail">
                            <p>Kho :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLocDestination" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row-detail">
                            <p>Giá :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input"  ID="txtShelfDestination" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="radio-control">
                        <asp:RadioButton ID="rdbCodeDoc" CssClass="lbSubTitle" runat="server" Text="Chuyển theo <u>đ</u>ầu ấn phẩm"
                            Checked="True" GroupName="rdbGroupName"></asp:RadioButton>
                        <label for="rdbCodeDoc"></label>
                        <asp:RadioButton ID="rdbCopyNum" CssClass="lbSubTitle" runat="server" Text="Chuyển theo ĐK<u>C</u>B"
                            GroupName="rdbGroupName"></asp:RadioButton>
                        <label for="rdbCopyNum"></label>
                    </div>
                </div>
                <div id="tblCodeDoc" class="row-detail">
                    <asp:Label ID="lblCodeDoc" runat="server"><u>M</u>ã tài liệu:</asp:Label>
                    <div class="input-control" style="width: 25%;display: inline-block;">
                        <div class="input-form ">
                            <asp:TextBox CssClass="text-input"  ID="txtCodeDoc" runat="server"></asp:TextBox>
                        </div>
                    </div>
                            <asp:Button ID="btnCodeDoc" runat="server" Text="Tìm(s)" Width=""></asp:Button>
                </div>

                <div id="tblCopyNumber" class="row-detail two-column ClearFix">
                    <div class="two-column-form ">
                        <div class="radio-control">
                            <asp:RadioButton ID="rdbCopyNumFile" runat="server" Text="D<u>a</u>nh sách ĐKCB lấy từ file" Checked="True"
                                GroupName="rdbGroupNameCN"></asp:RadioButton>
                            <label for="rdbCopyNumFile"></label>
                        </div>
                        <div class="input-control">
                            <div class="input-form fileAttach">
                                <input id="FileCopyNum" class="text-input" type="file" name="FileCopyNum" runat="server">
                            </div>
                        </div>
                    </div>
                    <div class="two-column-form ">
                        <div class="radio-control">
                            <p>
                                <asp:RadioButton ID="rdbCopyNumManual" runat="server" Text="<u>D</u>anh sách ĐKCB nhập bên dưới"
                                    GroupName="rdbGroupNameCN"></asp:RadioButton>
                                <label for="rdbCopyNumManual"></label>
                                <asp:HyperLink ID="lnkShowCopyNum" runat="server">Thêm ĐKCB</asp:HyperLink>
                            </p>
                        </div>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox  ID="txtCopyNumManual" CssClass="area-input" runat="server" Width="" Rows="5" TextMode="MultiLine"
                                    Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail ClearFix">
                    <div class="button-control" style="text-align: center">
                        <div class="button-form">
                            <asp:Button ID="btnMoveLocation" runat="server" Text="Chuyển kho(m)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
                 <asp:Label Height="500px" Width="100%" ID="lblErrorReports" runat="server" Font-Bold="True"></asp:Label>
            </div>

        </div>

        <asp:DropDownList ID="ddlLabelNote" runat="server" Visible="False" Width="0" Height="0">
            <asp:ListItem Value="0">Bạn chưa nhập đủ thông tin cần thiết</asp:ListItem>
            <asp:ListItem Value="1">Không có ấn phẩm nào được chuyển kho!</asp:ListItem>
            <asp:ListItem Value="2">Chuyển kho thành công!</asp:ListItem>
            <asp:ListItem Value="3">---------Chọn thư viện---------</asp:ListItem>
            <asp:ListItem Value="4">Bạn chưa chọn thư viện thư viện nguồn!</asp:ListItem>
            <asp:ListItem Value="5">Chuyển kho</asp:ListItem>
            <asp:ListItem Value="6">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="7">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="8">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="9">Bạn phải chọn kho nguồn khác với kho đích!</asp:ListItem>
            <asp:ListItem Value="10">Danh sách các đăng ký cá biệt được chuyển kho: </asp:ListItem>
        </asp:DropDownList>
        <input id="hidLocSourceID" runat="server" name="hidLocSourceID" type="hidden" value="0"/>
        <input id="hidLocDesID" runat="server" name="hidLocDesID" type="hidden" value="0"/>
        <script language="javascript">
            if (document.forms[0].rdbCodeDoc.checked)
                ShowHideTable(0);
            else {
                ShowHideTable(1);
                if (document.forms[0].rdbCopyNumFile.checked)
                    SwitchEnable(0);
                else
                    SwitchEnable(1);
            }
        </script>
    </form>
</body>
</html>
