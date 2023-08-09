<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WBarcodeSearch" CodeFile="WBarcodeSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WAdvanceSearch</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body leftmargin="0" topmargin="0" rightmargin="0" onload="document.forms[0].txtFromIDs.focus()">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">

            <h1 class="main-head-form">In mã vạch</h1>
            <div class="main-form">
                <asp:HyperLink ID="hrfCardPrint" runat="server">
							Nhấn vào đây để in thẻ</asp:HyperLink>
                <div class="three-column ClearFix">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="optIDs" Checked="True" Text="<u>T</u>ừ số thẻ:" GroupName="BarCode" runat="server"></asp:RadioButton>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Từ số thẻ:</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtFromIDs" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Đến số thẻ:</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtToIDs" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="three-column-form">
                        <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="optDate" Text="<U>T</U>ừ ngày: " GroupName="BarCode" runat="server"></asp:RadioButton>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Từ ngày :
                                <asp:HyperLink ID="hrfFromDate" runat="server">Lịch</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtFromDate" runat="server" Width="120px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Đến ngày :
                                <asp:HyperLink ID="hrfToDate" runat="server">Lịch</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtToDate" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="three-column-form">
                        <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="optID" Text="<u>S</u>ố thẻ: " GroupName="BarCode" runat="server"></asp:RadioButton>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Mã số</p>
                            <asp:Label ID="lblComment" runat="server">(Ngăn cách bởi dấu ;)</asp:Label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtID" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <div class="three-column ClearFix">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Kiểu :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlType" runat="server" Width="">
                                        <asp:ListItem Value="1">UPC-A</asp:ListItem>
                                        <asp:ListItem Value="2">UPC-E</asp:ListItem>
                                        <asp:ListItem Value="3">UPC 2 Digit Ext</asp:ListItem>
                                        <asp:ListItem Value="4">UPC 5 Digit Ext</asp:ListItem>
                                        <asp:ListItem Value="5">EAN-13</asp:ListItem>
                                        <asp:ListItem Value="6">JAN-13</asp:ListItem>
                                        <asp:ListItem Value="7">EAN-8</asp:ListItem>
                                        <asp:ListItem Value="8">ITF-14</asp:ListItem>
                                        <asp:ListItem Value="9">Interleaved 2 of 5</asp:ListItem>
                                        <asp:ListItem Value="10">Standard 2 of 5</asp:ListItem>
                                        <asp:ListItem Value="11">Codabar</asp:ListItem>
                                        <asp:ListItem Value="12">Postnet</asp:ListItem>
                                        <asp:ListItem Value="13">Bookland-ISBN</asp:ListItem>
                                        <asp:ListItem Value="14">Code 11</asp:ListItem>
                                        <asp:ListItem Value="15" Selected="True">Code 39</asp:ListItem>
                                        <asp:ListItem Value="16">Code 39 Extended</asp:ListItem>
                                        <asp:ListItem Value="17">Code 93</asp:ListItem>
                                        <asp:ListItem Value="18">Code 128</asp:ListItem>
                                        <asp:ListItem Value="19">Code 128-A</asp:ListItem>
                                        <asp:ListItem Value="20">Code 128-B</asp:ListItem>
                                        <asp:ListItem Value="21">Code 128-C</asp:ListItem>
                                        <asp:ListItem Value="22">LOGMARS</asp:ListItem>
                                        <asp:ListItem Value="23">MSI</asp:ListItem>
                                        <asp:ListItem Value="24">Telepen</asp:ListItem>
                                        <asp:ListItem Value="25">FIM (Facing Identification Mark)</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Hướng quay:</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlRotate" runat="server">
                                        <asp:ListItem Value="0" Selected="True">Không quay</asp:ListItem>
                                        <asp:ListItem Value="1">90 độ</asp:ListItem>
                                        <asp:ListItem Value="2">180 độ</asp:ListItem>
                                        <asp:ListItem Value="3">270 độ</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>File dạng ảnh :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlImgType" runat="server">
                                        <asp:ListItem Value="1">GIF</asp:ListItem>
                                        <asp:ListItem Value="2">JPEG</asp:ListItem>
                                        <asp:ListItem Value="3" Selected="true">PNG</asp:ListItem>
                                        <asp:ListItem Value="4">TIFF</asp:ListItem>
                                        <asp:ListItem Value="5">BMP</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Số ảnh/trang :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtOnPage" runat="server" Width="">20</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Số cột :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCol" runat="server" Width="">5</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Chiều rộng :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtWidth" runat="server" Width="">1</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Chiều Cao :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtHeight" runat="server" Width="">70</asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Giới hạn :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlBoundResult" runat="server" Width="">
                                        <asp:ListItem Value="50">50</asp:ListItem>
                                        <asp:ListItem Value="100">100</asp:ListItem>
                                        <asp:ListItem Value="300" Selected="True">300</asp:ListItem>
                                        <asp:ListItem Value="4000">Tất cả</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Sắp xếp theo :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlOrderBy" runat="server">
                                        <asp:ListItem Value="0" Selected="True">Không sắp xếp</asp:ListItem>
                                        <asp:ListItem Value="1">Ngày cấp thẻ</asp:ListItem>
                                        <asp:ListItem Value="2">Ngày hết hạn thẻ</asp:ListItem>
                                        <asp:ListItem Value="3">Ngày sinh</asp:ListItem>
                                        <asp:ListItem Value="4">Số thẻ</asp:ListItem>
                                        <asp:ListItem Value="5">Họ</asp:ListItem>
                                        <asp:ListItem Value="6">Tên</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>

                <div class="row-detail">
                    <div class="button-control" style="text-align: center;">
                        <div class="button-form">
                            <asp:Button ID="btnBarCode" runat="server" Text="In(p)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" runat="server" Text="Đặt lại(r)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi:</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi:</asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này!</asp:ListItem>
            <asp:ListItem Value="3">Sai khuôn dạng ngày tháng</asp:ListItem>
            <asp:ListItem Value="4">Dữ liệu đầu vào không đúng!</asp:ListItem>
            <asp:ListItem Value="5">Trường này chỉ nhận giá trị nguyên dương!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
