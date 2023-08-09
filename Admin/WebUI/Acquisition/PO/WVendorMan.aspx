<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WVendorMan" CodeFile="WVendorMan.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Cập nhật thông tin nhà cung cấp</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-form">
                <h1 class="main-head-form">Quản lý thông tin nhà cung cấp</h1>
                <div class="three-column ClearFix">
                    <div class="three-column-form">
                        <asp:Panel ID="PanelDDLVendorMan" runat="server">
                            <div class="row-detail">
                                <p>Danh sách các nhà cung cấp:</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlVendorLists" Runat="server" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                         
                        <div class="row-detail">
                            <p>Tên NCC :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtName" Runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                      
                        <div class="row-detail">
                            <p>Người liên hệ :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtContactPerson" runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Email :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtEmail" runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Mốc khiếu nại lần 1 :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtClaimCycle1" runat="server">30</asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Email khiếu nại :</p>
                            <div class="input-control">
                                <div class="input-form ">
<asp:textbox CssClass="text-input"  id="txtClaimEmail" runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Thời gian chuyển phát qua bưu điện :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtDeliveryTime" runat="server">1</asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Địa chỉ :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtAddress" Runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Nước :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
<asp:dropdownlist id="ddlCountry" runat="server"></asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                          <div class="row-detail">
                            <p>Tỉnh thành :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                   <asp:dropdownlist id="ddlProvince" Runat="server"></asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Số điện thoại :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtTelephone" runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>SAN :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtSAN" runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Mốc khiếu nại lần 2 :</p>
                            <div class="input-control">
                                <div class="input-form ">
<asp:textbox CssClass="text-input"  id="txtClaimCycle2" runat="server">60</asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>SAN của NCC :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtLibAC" runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                       
                        <div class="row-detail">
                            <p>Mã :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtZip" runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Fax :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtFax" runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>SAN của thư viện :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtLibSAN" runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Mốc khiếu nại lần 3 :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtClaimCycle3" runat="server">90</asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Số tài khoản NCC :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtBankingInfo" runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="input-control">
                                  <p>Hỗ trợ <U>X</U>12:&nbsp;&nbsp;  </p>
                                <input type="checkbox" id="cbxX12" runat="server" TextAlign="Left" Text="Hỗ trợ <U>X</U>12:"></input>
                                <label for="cbxX12"></label>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Hỗ trợ X12Email :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtX12Email" runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Ghi chú :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="area-input" id="txtNote" runat="server" Width="100%" TextMode="MultiLine" Rows="4"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-detail">
                    <div class="button-control" style="text-align: center">
                        <div class="button-form">
<asp:button id="btnUpdate" runat="server" Text="Cập nhật(u)" Width=""></asp:button>
                        </div>
                        <div class="button-form">
                            <asp:button  id="btnCancel" runat="server" Text="Đặt lại(r)" Width=""></asp:button>
                        </div>
                        <div class="button-form">
                            <asp:button  id="btnDelete" runat="server" Text="Xoá(d)" Width=""></asp:button>
                        </div>
                        <div class="button-form">
                            <asp:button  id="btnClose" runat="server" Text="Đóng(c)" Width=""></asp:button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Sai kiểu dữ liệu (số)!</asp:ListItem>
            <asp:ListItem Value="3">Địa chỉ email không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="4">Nhấn OK nếu bạn chắc chắn muốn xoá nhà cung cấp này!</asp:ListItem>
            <asp:ListItem Value="5">Cập nhật nhà cung cấp thành công</asp:ListItem>
            <asp:ListItem Value="6">Lỗi trong quá trình xử lý</asp:ListItem>
            <asp:ListItem Value="7">---------- Chọn ----------</asp:ListItem>
            <asp:ListItem Value="8">---------- Thêm mới ----------</asp:ListItem>
            <asp:ListItem Value="9">Thêm mới nhà cung cấp!</asp:ListItem>
            <asp:ListItem Value="10">Sửa thông tin nhà cung cấp!</asp:ListItem>
            <asp:ListItem Value="11">Xoá thông tin nhà cung cấp:</asp:ListItem>
            <asp:ListItem Value="12">Trường thông tin nhà cung cấp bắt buộc nhập!</asp:ListItem>
            <asp:ListItem Value="13">Bạn chưa chọn nhà cung cấp cần làm việc</asp:ListItem>
            <asp:ListItem Value="14">Tên nhà cung cấp đã tồn tại.</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtName.focus();
    </script>
</body>
</html>
