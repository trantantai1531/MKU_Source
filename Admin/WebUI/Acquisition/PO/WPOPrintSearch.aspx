<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WPOPrintSearch" CodeFile="WPOPrintSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WPOPrintSearch</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Báo cáo duyệt mua</h1>
                <div class="three-column ClearFix">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Tiêu đề đơn yêu cầu :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtCaption" CssClass="text-input" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Đơn vị tiền tệ để tính tổng :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlSumCurrency" runat="server"></asp:DropDownList>
                                    <input type="hidden" id="txtSumCurrency" runat="server" name="txtSumCurrency">
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="radio-control">
                                <p>
                                    <asp:RadioButton CssClass="lbRadio " ID="optAll" runat="server" Text="Xét <u>t</u>oàn bộ yêu cầu"
                                        Checked="True" GroupName="Accepted"></asp:RadioButton><input type="hidden" id="hdAccepted" runat="server" name="hdAccepted" value="2">
                                    <label for="r1"></label>
                                </p>
                                <p>
                                    <asp:RadioButton CssClass="lbRadio" ID="optNotAccepted" runat="server" Text="Chỉ xét các yêu cầu <u>c</u>hưa duyệt"
                                        GroupName="Accepted"></asp:RadioButton>
                                    <label for="r2"></label>
                                </p>
                                <p>
                                    <asp:RadioButton CssClass="lbRadio " ID="optAccepted" runat="server" Text="Chỉ xét các yêu cầu đã du<u>y</u>ệt"
                                        GroupName="Accepted"></asp:RadioButton>
                                    <label for="r3"></label>
                                </p>
                            </div>
                        </div>
                    </div>

                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Nhà xuất bản:</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlPublisher" runat="server"></asp:DropDownList><input type="hidden" id="hdPublisher" name="hdPublisher" runat="server">
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Dạng tài liệu: :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlMedium" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Vật mang tin :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlMedia" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Mức độ quan trọng :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlUrgency" runat="server">
                                        <asp:ListItem Value="0">-----Chọn------</asp:ListItem>
                                        <asp:ListItem Value="1">Bình thường</asp:ListItem>
                                        <asp:ListItem Value="2">Cao</asp:ListItem>
                                        <asp:ListItem Value="3">Rất cao</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Lập từ ngày :<asp:HyperLink ID="hrfFromDate" runat="server">Lịch</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtFromDate" CssClass="text-input" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                Đến ngày :<a href="#">(*)
                            <asp:HyperLink ID="hrfToDate" runat="server">Lịch</asp:HyperLink></a>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtToDate" CssClass="text-input"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Đơn vị tiền tệ :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlCurrency" runat="server"></asp:DropDownList>
                                    <input type="hidden" id="txtCurrency" runat="server" name="txtCurrency"/>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Chọn mẫu :<p class="error-star">(*)</p></p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlForm" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control" style="text-align: center">
                        <div class="button-form">
                            <asp:Button ID="btnPrint" runat="server" Text="In(p)" Width="50px"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnEmail" runat="server" Text="Gửi thư(g)" Width="80px"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnPreview" runat="server" Text="Xem trước(v)" Width="98px"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnSaveToFile" runat="server" Text="Lưu vào file(s)" Width="127px"></asp:Button>
                            <input type="hidden" id="txtSignFlage" runat="server" name="txtSingFlage"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
            <asp:ListItem Value="3">-------- Chọn --------</asp:ListItem>
            <asp:ListItem Value="4">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="5">Bạn chưa chọn mẫu đơn!</asp:ListItem>
            <asp:ListItem Value="6">Bạn hãy đánh địa chỉ email cần gửi tới:</asp:ListItem>
            <asp:ListItem Value="7">Địa chỉ email không đúng định dạng!</asp:ListItem>
            <asp:ListItem Value="8">Không có dữ liệu nào thoả mãn điều kiện đưa vào!</asp:ListItem>
        </asp:DropDownList>
        <input id="hidToEmail" runat="server" type="hidden">
    </form>
    <script language="javascript">
        document.forms[0].txtCaption.focus();
    </script>
</body>
</html>
