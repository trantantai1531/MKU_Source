<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WExportRecordToFile" CodeFile="WExportRecordToFile.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WExportRecord</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="5" onload="if(document.forms[0].hidFormAction.value==0) {document.forms[0].txtTitle.focus();}">
    <form id="Form1" method="post" runat="server">
        <div id="tblMain">
        <div id="divBody">
            <div class="main-body">
                    <h1 class="main-head-form">Xuất khẩu bản ghi</h1>
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Nhan đề chính :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>
                                    Tác giả :
                                <asp:HyperLink ID="lnkAuthor" runat="server" CssClass="lbLinkFunction">Từ điển</asp:HyperLink>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtAuthor" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>
                                    Nhà xuất bản :
                                <asp:HyperLink ID="lnkPublisher" runat="server" CssClass="lbLinkFunction">Từ điển</asp:HyperLink>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtPublisher" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>
                                    Khung phân loại :
                                <asp:HyperLink ID="lnkFrameType" runat="server" CssClass="lbLinkFunction">Từ điển</asp:HyperLink>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtFrameType" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>
                                    Ngôn ngữ :
                                <asp:HyperLink ID="lnkLanguage" runat="server" CssClass="lbLinkFunction">Từ điển</asp:HyperLink>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtLanguage" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>
                                    Từ khóa :
                                <asp:HyperLink ID="lnkKeyWord" runat="server" CssClass="lbLinkFunction">Từ điển</asp:HyperLink>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtKeyWord" runat="server" Width=""></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Dạng tài liệu :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlItemType" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Người biên mục :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlEditPerson" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Record ID từ :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtFrom" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Record ID tới :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtTo" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Khuôn dạng :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlPattern" runat="server">
                                            <asp:ListItem Value="1" Selected="True">MARC 21 (tagged)</asp:ListItem>
                                            <asp:ListItem Value="2">MARC 21 (raw)</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="row-detail">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button CssClass="form-btn" ID="btnExport" runat="server" Text="Xuất khẩu(e)" Width=""></asp:Button>
                                    </div>
                                    <div class="button-form">
                                        <asp:Button CssClass="form-btn" ID="btnReset" runat="server" Text="Đặt lại(r)" Width=""></asp:Button>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="tblShowResult" style="margin-top:3%">
            <h1 class="main-group-form">Kết quả xuất khẩu bản ghi dữ liệu biên mục</h1><br />
            <div class="main-body">
            <asp:Label ID="lblResult" runat="server" Visible="False">&nbsp;Số bản ghi được xuất khẩu là:</asp:Label>&nbsp;
						<asp:Label ID="lblCount" runat="server" Visible="False" CssClass="lbAmount"></asp:Label><br />
            <asp:Label ID="lblClick" runat="server" Visible="False">&nbsp;Click</asp:Label>&nbsp;<asp:HyperLink ID="lnkLink" runat="server" Visible="False">vào đây</asp:HyperLink>&nbsp;<asp:Label ID="lblLinkTail" runat="server" Visible="False">để lấy file về</asp:Label>
                </div>
        </div>
        <input id="hidFormAction" type="hidden" name="hidFormAction" runat="server">
        <script language="javascript">
            if (document.forms[0].hidFormAction.value == 0)
                ShowHideTable(0);
            else
                ShowHideTable(1);
        </script>
        <asp:DropDownList runat="server" ID="ddlLabel" Visible="False" Width="0" Height="0">
            <asp:ListItem Value="0">Xuất khẩu được:</asp:ListItem>
            <asp:ListItem Value="1">Không có bản ghi nào thoả mãn điều kiện tìm kiếm!</asp:ListItem>
            <asp:ListItem Value="2">Không có bản ghi nào được xuất khẩu!</asp:ListItem>
            <asp:ListItem Value="3">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="4">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="5">-- Chọn người biên mục --</asp:ListItem>
            <asp:ListItem Value="6">-- Chọn dạng tài liệu --</asp:ListItem>
            <asp:ListItem Value="7">Record ID nhập vào phải là dữ liệu kiểu số! </asp:ListItem>
            <asp:ListItem Value="8">Record ID nhập vào phải lớn hơn 0!</asp:ListItem>
            <asp:ListItem Value="9">Record ID đầu phải nhỏ hơn hoặc bằng Record ID cuối!</asp:ListItem>
            <asp:ListItem Value="10">Bạn phải nhập ít nhất một điều kiện tìm kiếm!</asp:ListItem>
            <asp:ListItem Value="11">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
            <asp:ListItem Value="12">Đang xuất khẩu dữ liệu ra file...</asp:ListItem>
            <asp:ListItem Value="13">Đã thực hiện xong!</asp:ListItem>
            <asp:ListItem Value="14">Dữ liệu không phải dạng số!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
