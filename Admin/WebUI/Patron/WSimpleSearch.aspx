<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WSimpleSearch" CodeFile="WSimpleSearch.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSimpleSearch</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link id="Link1" runat="server" href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link id="Link2" runat="server" href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link id="Link3" runat="server" href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" rightmargin="0" onkeypress="microsoftKeyPress()"
    onload="document.forms[0].txtCode.focus()">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Quản lý hồ sơ</h1>
            <div class="main-form">
            <div class="two-column ClearFix">
                <div class="two-column-form">
                    <div class="row-detail">
                        <p>Số thẻ:</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:textbox CssClass="text-input"  ID="txtCode" runat="server" Width=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Giới tính:</p>
                        <div class="input-control">
                            <div class="dropdown-form ">
                                <asp:DropDownList ID="ddlSex" runat="server" Width="">
                                    <asp:ListItem Value="2">-------- Chọn --------</asp:ListItem>
                                    <asp:ListItem Value="1">Nam</asp:ListItem>
                                    <asp:ListItem Value="0">Nữ</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>
                            Ngày cấp thẻ:
                            <asp:HyperLink ID="lnkValidDate" runat="server">Lịch</asp:HyperLink>
                        </p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:textbox CssClass="text-input"  ID="txtValidDate" runat="server" Width=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Nhóm bạn đọc :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:ListBox CssClass="area-input" ID="lstGroupID" runat="server" SelectionMode="Multiple" Height="" Width=""></asp:ListBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail" style="display: none">
                        <p>Lớp :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:textbox CssClass="text-input"  ID="txtClass" runat="server" Width=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail" style="display: none">
                        <p>Khóa :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:textbox CssClass="text-input"  ID="txtGrade" runat="server" Width=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Giới hạn kết quả :</p>
                        <div class="input-control">
                            <div class="dropdown-form ">
                                <asp:DropDownList ID="ddlSelectTop" runat="server" Width="">
                                    <asp:ListItem Value="300">300</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="0">To&#224;n bộ</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Kiểu hiển thị :</p>
                        <div class="input-control" style="width:40%;display:inline-block;">
                            <div class="dropdown-form ">
                                <asp:DropDownList ID="ddlTypeShow" runat="server" Width="">
                                    <asp:ListItem Value="0">Hồ sơ</asp:ListItem>
                                    <asp:ListItem Value="1">Bảng</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                          <asp:button id="btnSetFieldShow" runat="server" text="Đặt tham số(s)" width="" TabIndex="4"></asp:button>
                    </div>
                  


                </div>

                <div class="two-column-form">
                    <div class="row-detail">
                        <p>Họ tên :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:textbox CssClass="text-input"  ID="txtFullName" runat="server" Width="120px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Ngày sinh:
                            <asp:HyperLink ID="lnkDOB" runat="server">Lịch</asp:HyperLink></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:textbox CssClass="text-input"  ID="txtDOB" runat="server" Width=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Ngày hết hạn :
                            <asp:HyperLink ID="lnkExpiredDate" runat="server">Lịch</asp:HyperLink></p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:textbox CssClass="text-input"  ID="txtExpiredDate" runat="server" Width=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail" style="display: none">
                        <p>Khoa : </p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlFaculty" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="row-detail" style="display: none">
                        <p>Nghề nghiệp :</p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlOccupation" runat="server" Width=""></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Sắp xếp: </p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlOrderBy" runat="server" Width="">
                                    <asp:ListItem Value="0">Không sắp xếp</asp:ListItem>
                                    <asp:ListItem Value="1">Ngày cấp thẻ</asp:ListItem>
                                    <asp:ListItem Value="2">Ngày hết hạn thẻ</asp:ListItem>
                                    <asp:ListItem Value="4">Số thẻ</asp:ListItem>
                                    <asp:ListItem Value="5">Họ</asp:ListItem>
                                    <asp:ListItem Value="6">Tên</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
 

            <div class="row-detail">
                <div class="button-control inline-box">
                    <div class="button-form">
                        <asp:button id="btnSearch" runat="server" text="Tìm kiếm(m)" Width="" TabIndex="0"></asp:button>
                    </div>
                    <div class="button-form">
                        <asp:button id="btnReset" runat="server" text="Làm lại(i)" Width="" TabIndex="1"></asp:button>
                    </div>
                    <div class="button-form">
                        <asp:button id="btnSearchAdv" runat="server" text="Tìm nâng cao(a)" Width="" TabIndex="2"></asp:button>
                    </div>
                  
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="false" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này.</asp:ListItem>
            <asp:ListItem Value="3">-------Chọn-------</asp:ListItem>
            <asp:ListItem Value="4">Tra cứu bạn đọc đơn giản</asp:ListItem>
            <asp:ListItem Value="5">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="6">Chỉ đặt tham số khi kết quả hiển thị là bảng!</asp:ListItem>
            <asp:ListItem Value="7">Không có hồ sơ bạn đọc thoả mãn điều kiện tìm kiếm!</asp:ListItem>
        </asp:DropDownList>
        <input type="hidden" runat="server" id="hidPatronGroupIDs">
        <input type="hidden" runat="server" id="txtFieldShow" value="0,1,2,17">
        <input type="hidden" runat="server" id="txtPageSize" value="20">
    </form>
</body>
</html>
