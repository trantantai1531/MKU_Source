<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WCards" CodeFile="WCards.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCards</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body leftmargin="0" topmargin="0" rightmargin="0" onload="document.forms[0].txtFromID.focus()">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="TabbedPanelsContent">
                <h1 class="main-head-form">In thẻ bạn đọc</h1>

                <div class="main-form ClearFix">
                    <p>
                        <asp:HyperLink ID="hrfBarCode" runat="server" NavigateUrl="javascript:parent.Workform.location.href='WBarcodeSearch.aspx';">
								<b>In mã vạch cho thẻ bạn đọc</b></asp:HyperLink>
                    </p>
                    <div class="unit-4">
                        <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="optID" runat="server" Text="Số thẻ" Checked="True" GroupName="optRangePrint"></asp:RadioButton>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Từ : <a href="#"></a></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  ID="txtFromID" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Đến  : <a href="#"></a></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  ID="txtToID" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="unit-4">
                        <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="optValidDate" runat="server" Text="<U>N</U>gày cấp" GroupName="optRangePrint"></asp:RadioButton>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Từ ngày :
                                <asp:HyperLink ID="lnkCalFrom" runat="server">Lịch</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  ID="txtFromValidDate" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Đến ngày :
                                <asp:HyperLink ID="lnkCalTo" runat="server">Lịch</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  ID="txtToValidDate" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="unit-4">
                        <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="optCode" runat="server" Text="<U>S</U>ố thẻ" GroupName="optRangePrint"></asp:RadioButton>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Mã số</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  ID="txtCode" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="unit-4">
                        <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="optClass" runat="server" Text="<U>K</U>hoa" GroupName="optRangePrint"></asp:RadioButton>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Chọn khoa :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlFaculty" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Lớp :
                                <asp:HyperLink ID="lnkDetailClass" runat="server">Chi tiết</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  ID="txtClass" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="three-column ClearFix">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Nhóm bạn đọc :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlPatronGroup" runat="server" Width=""></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Khuôn dạng :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlFormat" runat="server" Width=""></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Loại mã vạch :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlFormatBarcode" runat="server" Width="">
                                        <asp:ListItem Value="1">EAN-13</asp:ListItem>
                                        <asp:ListItem Value="2">EAN-8</asp:ListItem>
                                        <asp:ListItem Value="3">UPC-A</asp:ListItem>
                                        <asp:ListItem Value="4">Code 39 Check</asp:ListItem>
                                        <asp:ListItem Value="5">Codabar</asp:ListItem>
                                        <asp:ListItem Value="6" Selected="True">Code 39</asp:ListItem>
                                        <asp:ListItem Value="7">2 of 5</asp:ListItem>
                                        <asp:ListItem Value="8">Interleaved 2 of 5 (ITF)</asp:ListItem>
                                        <asp:ListItem Value="9">UPC-E</asp:ListItem>
                                        <asp:ListItem Value="10">EAN-13 + 2</asp:ListItem>
                                        <asp:ListItem Value="11">EAN-13 + 5</asp:ListItem>
                                        <asp:ListItem Value="12">EAN-8 + 2</asp:ListItem>
                                        <asp:ListItem Value="13">EAN-8 + 5</asp:ListItem>
                                        <asp:ListItem Value="14">UPC-A + 2</asp:ListItem>
                                        <asp:ListItem Value="15">UPC-A + 5</asp:ListItem>
                                        <asp:ListItem Value="16">UPC-E + 2</asp:ListItem>
                                        <asp:ListItem Value="17">UPC-E + 5</asp:ListItem>
                                        <asp:ListItem Value="18">EAN-128 A</asp:ListItem>
                                        <asp:ListItem Value="19">EAN-128 B</asp:ListItem>
                                        <asp:ListItem Value="20">EAN-128 C</asp:ListItem>
                                        <asp:ListItem Value="21">Code 93</asp:ListItem>
                                        <asp:ListItem Value="22">POSTNET</asp:ListItem>
                                        <asp:ListItem Value="23">Code-128 A</asp:ListItem>
                                        <asp:ListItem Value="24">Code-128 B</asp:ListItem>
                                        <asp:ListItem Value="25">Code-128 C</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Kiểu quay :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlRotate" runat="server" Width="">
                                        <asp:ListItem Value="0" Selected="True">Không quay</asp:ListItem>
                                        <asp:ListItem Value="1">90 độ</asp:ListItem>
                                        <asp:ListItem Value="2">180 độ</asp:ListItem>
                                        <asp:ListItem Value="3">270 độ</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Dạng file :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlPicType" runat="server" Width="">
                                        <asp:ListItem Value="3" Selected="True">JPG</asp:ListItem>
                                        <asp:ListItem Value="1">PNG</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Số thẻ/trang :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  ID="txtPageSize" runat="server" Width="">8</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Số cột :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  ID="txtCollum" runat="server" Width="">2</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Giới hạn :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:DropDownList ID="ddlMaxRec" runat="server" Width="">
                                        <asp:ListItem Value="0">Toàn bộ</asp:ListItem>
                                        <asp:ListItem Value="50">50</asp:ListItem>
                                        <asp:ListItem Value="100">100</asp:ListItem>
                                        <asp:ListItem Value="300" Selected="True">300</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-detail">
                    <div class="button-control" style="text-align: center;">
                        <div class="button-form">
                            <asp:Button ID="btnPrint" runat="server" Width="" Text="In thẻ(p)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" runat="server" Width="" Text="Làm lại(r)"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" Width="0" runat="server" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi:</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi:</asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
            <asp:ListItem Value="3">Dữ liệu đưa vào không hợp lệ, xin kiểm tra lại</asp:ListItem>
            <asp:ListItem Value="4">In thẻ bạn đọc</asp:ListItem>
            <asp:ListItem Value="5">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="6">Không tìm thấy dữ liệu thoả mãn điều kiện!</asp:ListItem>
            <asp:ListItem Value="7">----Chọn khoa-----</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
