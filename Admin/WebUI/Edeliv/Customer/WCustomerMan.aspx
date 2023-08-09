<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Edeliv.WCustomerMan"
    CodeFile="WCustomerMan.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCustomerMan</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="ClearContent(); OnLoad();">
    <form id="Form1" method="post" runat="server">
    <div id="divBody">
        <div class="center-form">
            <div class="main-body ClearFix">
                <div class="content-form">
                    <div class="main-form">
                        <div class="ClearFix main-page">
                            <div class="chart-form">
                                <asp:Label ID="lblMainTitle" runat="server" CssClass="main-head-form lbGroupTitle">Tài khoản</asp:Label>
                            </div>
                            <div class="col-left-2">
                                <div class=" row-detail">
                                    <div class="dropdown-form">
                                        <div class="input-control">
                                            <select id="lstCustomerName" style="width: 100%; height: auto"  size="18" name="lstCustomerName"
                                                onchange="if (this.options[this.options.selectedIndex].value != 0) {parent.Sentform.location.href='WCustomerLoadInfor.aspx?CustomerID=' + this.options[this.options.selectedIndex].value;document.forms[0].hidCustomerID.value=this.options[this.options.selectedIndex].value;return false;}else{ClearContent();return false;}"
                                                runat="server">
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-right-8">
                                <div class="text-column-2 row-detail ">
                                    <div class="two-column-form ">
                                        <asp:Label ID="lblAcountInformation" CssClass="lbSubFormTitle main-group-form" runat="server">Thông tin tài khoản:</asp:Label>
                                        <div class="row-detail">
                                            <asp:Label ID="lblFullName" runat="server">*Tên <u>c</u>hủ tài khoản:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblContactName" runat="server">*Tên <u>n</u>gười liên hệ:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblEmailAddress" runat="server">*Địa chỉ <u>e</u>mail:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtEmailAddress" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblPhone" runat="server">*<u>Đ</u>iện thoại:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblFax" runat="server"><u>F</u>ax:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtFaxNumber" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblNote" runat="server"><u>G</u>hi chú:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtNote" runat="server" Width="168px" TextMode="MultiLine" Height="48px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblEdelivUserName" runat="server">*Tên đăn<u>g</u> nhập:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtEdelivUserName" runat="server" Width="168px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblEdelivPassword" runat="server">*<u>M</u>ật khẩu:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtEdelivPassword" runat="server" Width="168px" TextMode="Password"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblRetypePassword" runat="server"><u>G</u>õ lại mật khẩu:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtRetypePassword" runat="server" Width="168px" TextMode="Password"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblSecretLevel" runat="server">Mức độ mật:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtSecretLevel" runat="server" Width="30px">0</asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Label ID="lblShippingInformation" CssClass="lbSubFormTitle main-group-form" runat="server">Địa chỉ giao nhận</asp:Label>
                                        <div class="row-detail">
                                            <asp:Label ID="lblWorkPlace" runat="server">*T<u>ê</u>n đơn vị:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtWorkPlace" runat="server" Width="168px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblDepartment" runat="server"><u>P</u>hòng ban:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtDepartment" runat="server" Width="168px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblAddress" runat="server">*Đ<u>ư</u>ờng phố:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtAddress" runat="server" Width="168px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblBox" runat="server"><u>H</u>ộp thư:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtBox" runat="server" Width="168px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblCity" runat="server">*Thành ph<u>ố</u>:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtCity" runat="server" Width="168px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblArea" runat="server"><u>K</u>hu vực:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:TextBox ID="txtArea" runat="server" Width="168px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                            <asp:Label ID="lblCountry" runat="server">*<u>Q</u>uốc gia:</asp:Label>
                                            <div class="input-control">
                                                <div class="dropdown-form">
                                                    <asp:DropDownList ID="ddlCountry" runat="server" Width="168px">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                             <asp:Label ID="lblPostalCode" runat="server">Mã bưu điện (Z<u>I</u>P):</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                  <asp:TextBox ID="txtPostalCode" runat="server" Width="168px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-detail">
                                           <asp:Label ID="lblDebt" runat="server"><u>T</u>iền dư:</asp:Label>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                     <asp:TextBox ID="txtDebt" runat="server" Width="168px" Enabled="False"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="checkbox-control">
                                            <input id="chkStatus" type="checkbox" name="chkStatus" runat="server" accesskey="a"/>
                                          <asp:Label ID="lblStatus" runat="server"> Kích ho<u>ạ</u>t:</asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-right-8">
                                        <div class="row-detail">
                                            <div class="button-control inline-box">
                                                <div class="button-form">
                                                    <asp:Button ID="btnUpdate" runat="server" CssClass="form-btn" Text="Cập nhật(u)"
                                                        Width="98px"></asp:Button>
                                                </div>
                                                <div class="button-form">
                                                    <asp:Button ID="btnDelete" runat="server" CssClass="form-btn" Text="Xoá(d)" Width="68px">
                                                    </asp:Button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <table id="Table1" cellspacing="0" cellpadding="2" width="100%" border="0">
        
        <tr>
            <td colspan="5">
                <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
                    <asp:ListItem Value="0">----Thêm mới----</asp:ListItem>
                    <asp:ListItem Value="1">Tên chủ tài khoản</asp:ListItem>
                    <asp:ListItem Value="2">Tên người liên hệ</asp:ListItem>
                    <asp:ListItem Value="3">Điện thoại</asp:ListItem>
                    <asp:ListItem Value="4">Địa chỉ email</asp:ListItem>
                    <asp:ListItem Value="5">Mã tài khoản</asp:ListItem>
                    <asp:ListItem Value="6">Mật khẩu</asp:ListItem>
                    <asp:ListItem Value="7">Tên đơn vị</asp:ListItem>
                    <asp:ListItem Value="8">Đường phố</asp:ListItem>
                    <asp:ListItem Value="9">Thành phố</asp:ListItem>
                    <asp:ListItem Value="10">Giá trị mật khẩu không khớp</asp:ListItem>
                    <asp:ListItem Value="11">Giá trị của trường</asp:ListItem>
                    <asp:ListItem Value="12">là bắt buộc</asp:ListItem>
                    <asp:ListItem Value="13">Địa chỉ email không hợp lệ</asp:ListItem>
                    <asp:ListItem Value="14">Bạn phải nhập vào số thẻ</asp:ListItem>
                    <asp:ListItem Value="15">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
                    <asp:ListItem Value="16">Mã lỗi</asp:ListItem>
                    <asp:ListItem Value="17">Chi tiết lỗi</asp:ListItem>
                    <asp:ListItem Value="18">Tạo tài khoản mới</asp:ListItem>
                    <asp:ListItem Value="19">Sửa thông tin tài khoản</asp:ListItem>
                    <asp:ListItem Value="20">Xoá tài khoản</asp:ListItem>
                    <asp:ListItem Value="21">Tạo mới tài khoản không thành công. Mã tài khoản đã tồn tại!</asp:ListItem>
                    <asp:ListItem Value="22">Cập nhật tài khoản không thành công! Mã tài khoản bị trùng với một tài khoản sẵn có!</asp:ListItem>
                    <asp:ListItem Value="23">Bạn có muốn xoá tài khoản không? Ấn OK để khẳng định, CANCEL để huỷ thao tác</asp:ListItem>
                    <asp:ListItem Value="24">Cập nhật tài khoản thành công!</asp:ListItem>
                    <asp:ListItem Value="25">Xoá tài khoản thành công!</asp:ListItem>
                    <asp:ListItem Value="26">Bạn chưa chọn tài khoản cần làm việc!</asp:ListItem>
                    <asp:ListItem Value="27">Mức độ mật phải nguyên dương và nhỏ hơn 10!</asp:ListItem>
                    <asp:ListItem Value="28">Tài khoản đã được kích hoạt.</asp:ListItem>
                    <asp:ListItem Value="29">Tài khoản đã bị khóa.</asp:ListItem>
                    <asp:ListItem Value="30">Thông tin về tài khoản đăng ký mua tài liệu điện tử của bạn.</asp:ListItem>
                    <asp:ListItem Value="31">Lỗi trong quá trình gửi Mail thông tin về tài khoản cho chủ tài khoản (Email không tồn tại).</asp:ListItem>
                </asp:DropDownList>
                <input id="hidCustomerID" type="hidden" value="0" runat="server" />
            </td>
        </tr>
    </table>
    </form>
    <script language="javascript">
        document.forms[0].txtFullName.focus();
    </script>
</body>
</html>
