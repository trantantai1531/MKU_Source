<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WPatronGroup" CodeFile="WPatronGroup.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WPatronGroup</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="document.forms[0].txtNameGroup.focus()">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="TabbedPanelsContent">
                <h1 class="main-head-form">Nhóm bạn đọc</h1>
                <div class="row-detail">
                    <p>Nhóm bạn đọc :</p> <p class="error-star">(*)</p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:dropdownlist id="ddlPatronGroup" Runat="server" AutoPostBack="True"></asp:dropdownlist>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>Tên nhóm:<asp:label id="lblMan" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc" Runat="server"></asp:label></p> <p class="error-star">(*)</p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:textbox id="txtNameGroup" Runat="server" MaxLength="32"></asp:textbox>
                        </div>
                    </div>
                </div>


                <div class="ClearFix">
                    <div class="col-left-4">
                        <div class="row-detail">
                            <p>Số sách được mượn về :</p><p class="error-star"> (*)</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox id="txtLoanQuota" Runat="server" Width="" MaxLength="2"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Số sách được mượn tại chỗ :</p><p class="error-star"> (*)</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox id="txtInlibraryQuota" Runat="server" Width="" MaxLength="2"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Số sách được giữ chỗ :</p><p class="error-star"> (*)</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox id="txtHoldQuota" Runat="server" Width="" MaxLength="2"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail" style="display:none">
                            <p>Số sách được mượn qua ILL :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox id="txtIllQuota" Text="10" Runat="server" Width="" MaxLength="2"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Mức ưu tiên :</p><p class="error-star">(*)</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox id="txtPriority" Runat="server" Width="" MaxLength="2"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Thời gian bảo lưu lượt giữ chỗ đến lượt (ngày) :</p><p class="error-star">(*)</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox id="txtHoldTurnTimeOut" Runat="server" Width="" MaxLength="3"></asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Cấp độ mật tối đa được truy cập :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:dropdownlist id="ddlAccessLevel" Runat="server">
										<asp:ListItem Value="0" Selected="True">0</asp:ListItem>
										<asp:ListItem Value="1">1</asp:ListItem>
										<asp:ListItem Value="2">2</asp:ListItem>
										<asp:ListItem Value="3">3</asp:ListItem>
										<asp:ListItem Value="4">4</asp:ListItem>
										<asp:ListItem Value="5">5</asp:ListItem>
										<asp:ListItem Value="6">6</asp:ListItem>
										<asp:ListItem Value="7">7</asp:ListItem>
										<asp:ListItem Value="8">8</asp:ListItem>
										<asp:ListItem Value="9">9</asp:ListItem>
									</asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="input-control">
                                <input type="checkbox" ID="ckbDownLoad" class="checkbox-control" value="1" runat="server" />
                                <label for="ckbDownLoad">Được phép Download Tài liệu điện tử</label>
                            </div>
                        </div>
                    </div>

                    <div class="col-right-6">
                        <div class="span10">
                            <div class="row-detail">
                                <p>Thời gian mượn về :</p><p class="error-star"> (*)</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox id="txtLoanDayPeriod" Runat="server" Width=""></asp:textbox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="span45">
                            <div class="row-detail">
                                <p>Kho :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:listbox id="lstStore" Runat="server" Width="100%" SelectionMode="Multiple" Rows="11"></asp:listbox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="span1">
                            <div class="input-control button-list">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:button id="btnAdd" Runat="server" Text=" >> "></asp:button>
                                        <div class="icon-btn"><span class="icon-arrow-right"></span></div>
                                    </div>
                                </div>
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:button id="btnRemove" Runat="server" Text=" << "></asp:button>
                                        <div class="icon-btn"><span class="icon-arrow-left"></span></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="span45">
                            <div class="row-detail">
                                <p>Các kho được quyền mượn :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:listbox id="lstStoreUsed" Runat="server" Width="100%" SelectionMode="Multiple" Rows="11"></asp:listbox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-detail">
                    <div class="button-control" style="text-align: center">
                        <div class="button-form">
                            <asp:button id="btnUpdate" Runat="server" Width="" Text="Cập nhật(u)"></asp:button>
                        </div>
                        <div class="button-form">
                            <asp:button id="btnReset" Runat="server" Width="" Text="Làm lại(r)"></asp:button>
                        </div>
                        <div class="button-form">
                            <asp:button id="btnDelete" Runat="server" Width="" Text="Xoá(d)"></asp:button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input id="hidStoreIDs" type="hidden" name="hidStoreIDs" runat="server">
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="false">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">---------- Nhóm mới ----------</asp:ListItem>
            <asp:ListItem Value="3">Bạn có chắc chắn xoá nhóm bạn đọc này không?</asp:ListItem>
            <asp:ListItem Value="4">Bạn chưa nhập đủ thông tin cần thiết cho nhóm bạn đọc</asp:ListItem>
            <asp:ListItem Value="5">Sai định dạng dữ liệu</asp:ListItem>
            <asp:ListItem Value="6">Cập nhật nhóm bạn đọc</asp:ListItem>
            <asp:ListItem Value="7">Xoá nhóm bạn đọc</asp:ListItem>
            <asp:ListItem Value="8">thành công</asp:ListItem>
            <asp:ListItem Value="9">Tên nhóm bạn đọc đã tồn tại trong CSDL</asp:ListItem>
            <asp:ListItem Value="10">Bạn chưa nhập tên nhóm bạn đọc</asp:ListItem>
            <asp:ListItem Value="11">Tạo mới nhóm bạn đọc</asp:ListItem>
            <asp:ListItem Value="12">Bạn không có quyền thực hiện chức năng này.</asp:ListItem>
            <asp:ListItem Value="13">không</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
