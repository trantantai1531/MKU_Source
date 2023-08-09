<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WPolicyManagementOther.aspx.vb" Inherits="eMicLibAdmin.WebUI.Circulation.WPolicyManagementOther" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <title>WPolicyManagementOther</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
        <style type="text/css">
            html body .riSingle .riTextBox[type="text"] {
                padding-right: 5px;
                padding-left: 5px;
                margin: 0;
                height: 31px;
                width:250px;
            }
        </style>
        <div id="divBody">
                        <asp:UpdatePanel ID="updatepanel1" runat="server">
                            <ContentTemplate>
            <h1 class="main-head-form">Chính sách lưu thông</h1>
            <div class="main-form">
                <div class="span8">
                    <div class="row-detail">
                        <p>Dạng tài liệu :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:DropDownList ID="ddlLoanType" runat="server" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear:left"></div>
                <div class="span3">
                    <div class="row-detail">
                        <p>Từ ngày :</p>
                        <div class="input-control">
                            <telerik:RadDatePicker ID="RadDateTimePickerDateStart" DateInput-ReadOnly="true" runat="server" Culture="vi-VN" DateInput-MinDate="1980-01-01"></telerik:RadDatePicker>
                        </div>
                    </div>
                </div>
                <div class="span3">
                    <div class="row-detail">
                        <p>Đến :</p>
                        <div class="input-control">
                            <telerik:RadDatePicker ID="RadDateTimePickerDateEnd" DateInput-ReadOnly="true" runat="server" Culture="vi-VN" DateInput-MinDate="1980-01-01"></telerik:RadDatePicker>
                        </div>
                    </div>
                </div>
                <div class="span3">
                    <div class="row-detail">
                        <p>Ngày hết hạn :</p>
                        <div class="input-control">
                            <telerik:RadDatePicker ID="RadDateTimePickerDateExpired" DateInput-ReadOnly="true" runat="server" Culture="vi-VN" DateInput-MinDate="1980-01-01"></telerik:RadDatePicker>
                        </div>
                    </div>
                </div>
                <div style="clear:left"></div>
                <div class="span8">
                    <div class="row-detail">
                        <p>&nbsp</p>
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnNew" CssClass="lbButton" runat="server" Text="Cập nhật"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
                <div style="clear:left;"></div>
                <div class="input-control row-detail">
                    <div class="table-form">
                                <asp:GridView ID="dtgPolicy" runat="server" AllowPaging="True" Width="100%" AutoGenerateColumns="False" PageSize="20">
                            <HeaderStyle CssClass="lbGridHeader" />
                            <Columns>
                                <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true">
                                    <HeaderStyle Width="5%" Height="30px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Dạng tài liệu">
                                    <HeaderStyle Width="15%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hidID" Value='<%# Eval("ID")%>' runat="server" />
                                        <asp:Label ID="lblLoanType" Text='<%# Eval("Title")%>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:HiddenField ID="hidID" Value='<%# Eval("ID")%>' runat="server" />
                                        <asp:HiddenField ID="hidLoanTypeID" Value='<%# Eval("LoanTypeID")%>' runat="server" />
                                        <asp:DropDownList ID="ddlLoanTypeOther" runat="server"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Thời gian">
                                    <HeaderStyle Width="25%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateStart" Text='<%# Eval("DateStart")%>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadDatePicker ID="RadDateTimePickerDateStartEdit" Width="100px" DateInput-ReadOnly="true" runat="server" Culture="vi-VN" SelectedDate='<%# Eval("DateStart")%>' DateInput-MinDate="1980-01-01"></telerik:RadDatePicker>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Đến">
                                    <HeaderStyle Width="25%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateEnd" Text='<%# Eval("DateEnd")%>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadDatePicker ID="RadDateTimePickerDateEndEdit" Width="100px" DateInput-ReadOnly="true" runat="server" Culture="vi-VN" SelectedDate='<%# Eval("DateEnd")%>' DateInput-MinDate="1980-01-01"></telerik:RadDatePicker>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hết hạn">
                                    <HeaderStyle Width="25%"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblDateExpired" Text='<%# Eval("DateExpired")%>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <telerik:RadDatePicker ID="RadDateTimePickerDateExpiredEdit" Width="100px" DateInput-ReadOnly="true" runat="server" Culture="vi-VN" SelectedDate='<%# Eval("DateExpired")%>' DateInput-MinDate="1980-01-01"></telerik:RadDatePicker>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" ShowCancelButton="true"
                                    UpdateText="&lt;img src=&quot;../../images/update.gif&quot; border=&quot;0&quot;&gt;" CancelText="&lt;img src=&quot;../../images/cancel.gif&quot; border=&quot;0&quot;&gt;"
                                    EditText="&lt;img src=&quot;../../images/Edit2.gif&quot; border=&quot;0&quot;&gt;" DeleteText="&lt;img src=&quot;../../images/delete.gif&quot; border=&quot;0&quot;&gt;"></asp:CommandField>
                            </Columns>
                        </asp:GridView>
                        
                    </div>
                </div>
            </div>
        </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2"></asp:ListItem>
            <asp:ListItem Value="3"></asp:ListItem>
            <asp:ListItem Value="4">Sai khuôn dạng dữ liệu hoặc bạn chưa nhập đủ thông tin cần thiết</asp:ListItem>
            <asp:ListItem Value="5">Có chắc chắn gộp các dạng tài liệu lưu thông không?</asp:ListItem>
            <asp:ListItem Value="6">bản</asp:ListItem>
            <asp:ListItem Value="7">Xem</asp:ListItem>
            <asp:ListItem Value="8">Tạo mới chính sách lưu thông</asp:ListItem>
            <asp:ListItem Value="9">Cập nhật chính sách lưu thông</asp:ListItem>
            <asp:ListItem Value="10">Gộp các chính sách lưu thông</asp:ListItem>
            <asp:ListItem Value="11">Sai khuôn dạng dữ liệu</asp:ListItem>
            <asp:ListItem Value="12">Chính sách lưu thông đã tồn tại</asp:ListItem>
            <asp:ListItem Value="13">Số giờ tối đa là: 15h</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
