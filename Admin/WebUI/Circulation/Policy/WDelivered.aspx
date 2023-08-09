<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WDelivered.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WDelivered" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WDelivered</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        input[type="checkbox"] {
            display:block; 
            -webkit-appearance: checkbox !important;
            width: 39px;
            height: 20px;
            position: relative;
            opacity: 1;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0" oncontextmenu="return true;">
    <form id="form1" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Giao nhận tài liệu</h1>
            <div class="main-form">
                <div class="three-column ClearFix">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Số ĐKCB :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCopyNumber" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Nhan đề :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Tác giả :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtAuthor" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="three-column ClearFix">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Số phân loại :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtClassification" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Nguồn bổ sung :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlAcquireSource" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Lý do :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtAdditionalBy" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="three-column ClearFix">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Từ ngày :<asp:HyperLink ID="lnkDateFrom" runat="server">&nbsp;Lịch</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtDateFrom" Width="" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Đến ngày :<asp:HyperLink ID="lnkDateTo" runat="server">&nbsp;Lịch</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtDateTo" Width="" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>&nbsp;</p>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnSearch" runat="server" Text="Tìm(f)" Width=""></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="table-form">
                        <asp:DataGrid ID="dtgDelivered" runat="server" Width="100%" AutoGenerateColumns="False">
                            <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                            <Columns>
                                <asp:TemplateColumn HeaderStyle-Width="45px" ItemStyle-Width="45px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkID"  runat="server" />
                                        <asp:HiddenField ID="hidID" Value='<%# DataBinder.Eval(Container.DataItem, "ID") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="STT" HeaderText="STT" ReadOnly="true">
                                    <HeaderStyle Width="5%"/>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="CopyNumber" HeaderText="Số ĐKCB" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Title" HeaderText="Nhan đề" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Author" HeaderText="Tác giả" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Classification" HeaderText="Số phân loại" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="AcquireSource" HeaderText="Nguồn bổ sung" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="AdditionalBy" HeaderText="Lý do" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </div>
                 
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnDelivered" runat="server" Text="Ghi nhận" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="display:none;">
            <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
                <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
                <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
                <asp:ListItem Value="3">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
                <asp:ListItem Value="4">Dạng tài liệu lưu thông</asp:ListItem>
                <asp:ListItem Value="5">Số lượt mượn</asp:ListItem>
            </asp:DropDownList>
        </div>
    </form>
</body>
</html>
