<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WACQsRequest" CodeFile="WACQsRequest.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Lập yêu cầu bổ sung ấn phẩm định kỳ</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <div class="TabbedPanelsContent">
            <h1 class="main-head-form">Lập yêu cầu bổ sung ấn phẩm định kỳ</h1>
            <div class="three-column ClearFix">
                <div class="three-column-form">
                    <div class="row-detail">
                        <p> Nhan đề : <asp:Label ID="lblNote1" runat="server" ForeColor="red" style="display: none"  ToolTip="Trường bắt buộc">(*)</asp:Label><p class="error-star">(*)</p>&nbsp;<asp:HyperLink ID="lnkCheckExists" runat="server" Width="64px">Kiểm tra</asp:HyperLink>            </p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txtTitle" CssClass="text-input" runat="server" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Nhà xuất bản :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txtPublisher" CssClass="text-input" runat="server" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Ngôn ngữ :</p>
                                <div class="input-control control-disabled">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlLanguage" runat="server" ></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Nước xuất bản :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlCountry" runat="server" ></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Đơn giá :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txtUnitPrice" CssClass="text-input" runat="server"  MaxLength="10"></asp:TextBox>
                                        
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Người lập yêu cầu :</p>
                        <div class="input-control control-disabled">
                            <div class="input-form ">
                                <%--<input type="text" class="text-input" value="Administrator" disabled="disabled">--%>
                                <asp:TextBox ID="txtRequester" CssClass="text-input" runat="server" Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    
                </div>

                <div class="three-column-form">
                    <div class="row-detail">
                        <p>Tác giả :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txtAuthor" CssClass="text-input" runat="server" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Năm xuất bản :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txtPubYear" CssClass="text-input" runat="server" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>
                                    Ngày bắt đầu đặt :<p class="error-star">(*)</p>
                                    <asp:HyperLink ID="lnkValidSubscribedDate" runat="server" >Lịch</asp:HyperLink>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtValidSubscribedDate" CssClass="text-input" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>
                                    Ngày kết thúc đặt :<p class="error-star">(*)</p>
                                    <asp:HyperLink ID="lnkExpiredSubscribedDate" runat="server" >Lịch</asp:HyperLink>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtExpiredSubscribedDate" CssClass="text-input" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Số lượng :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txtRequestedCopies" CssClass="text-input" runat="server"  MaxLength="4">1</asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Ghi chú :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txtNote" CssClass="text-input" runat="server" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    
                </div>
                <div class="three-column-form">
                    <div class="row-detail" style="display: none">
                        <p>Lần xuất bản :</p>
                        <div class="input-control">
                            <div class="input-form ">
                              <%--  <input type="text" class="text-input">--%>
                                <asp:TextBox ID="Textbox1" CssClass="text-input" runat="server" MaxLength="4">1</asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Loại mã :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtISSN" CssClass="text-input" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Mã số :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtSerialCode" CssClass="text-input" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Cấp định kỳ :</p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlRegularityCode" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Mức độ quan trọng :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlUrgency" runat="server" >
                                            <asp:ListItem Value="1">Bình thường</asp:ListItem>
                                            <asp:ListItem Value="2">Cao</asp:ListItem>
                                            <asp:ListItem Value="3">Rất cao</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Vật mang tin :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlMedium" runat="server" ></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Đơn vị tính :</p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlCurrency" runat="server" ></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Số kỳ :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtIssues" CssClass="text-input" runat="server" MaxLength="4">1</asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Giá lẻ:</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtIssuePrice" CssClass="text-input" runat="server"  MaxLength="10">0</asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row-detail">
                <div class="button-control" style="text-align: center">
                    <div class="button-form">
                        <asp:Button ID="btnInsert" runat="server"  Text="Lập yêu cầu(u)"></asp:Button>
                    </div>
                    <div class="button-form">
                        <asp:Button ID="btnReset" runat="server" Text="Đặt lại(r)"></asp:Button>
                    </div>
                    <div class="button-form">
                        <asp:Button ID="btnZ3950" runat="server"  Text="Tải về qua Z3950(z)"></asp:Button>&nbsp;
                    </div>
                </div>
            </div>
        </div>


        <input id="txtRequestID" type="hidden" name="txtRequestID" runat="server">
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Lỗi trong quá trình xử lý</asp:ListItem>
            <asp:ListItem Value="3">Cập nhật dữ liệu thành công</asp:ListItem>
            <asp:ListItem Value="4">Bản ghi không được cập nhật nếu giá trị trường này trống</asp:ListItem>
            <asp:ListItem Value="5">Sai kiểu dữ liệu (số)</asp:ListItem>
            <asp:ListItem Value="6">Cập nhật bản ghi có nhan đề: </asp:ListItem>
            <asp:ListItem Value="7">Sai kiểu dữ liệu ngày tháng</asp:ListItem>
            <asp:ListItem Value="8">Ngày bắt đầu đặt phải bé hơn ngày kết thúc đặt !</asp:ListItem>
            <asp:ListItem Value="9">Bạn không được cấp quyền sử dụng tính năng này.</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtTitle.focus();
    </script>
</body>
</html>
