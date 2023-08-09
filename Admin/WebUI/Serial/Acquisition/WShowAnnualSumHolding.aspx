<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WShowAnnualSumHolding" CodeFile="WShowAnnualSumHolding.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WSearch</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link runat="server" href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link runat="server" href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Kiểm tra quá trình bổ sung từng năm.</h1>
            <div class="main-form">
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Năm:</p>
                            <div class="input-control">
                                <div class="dropdown-form ">
                                    <asp:DropDownList ID="ddlYears" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Nhan đề :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Nước xuất bản :
                                <asp:HyperLink ID="lnkCountry" runat="server" CssClass="lbLinkFunction">Từ điển</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCountry" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Nhà xuất bản :
                                <asp:HyperLink ID="lnkPublisher" runat="server" CssClass="lbLinkFunction">Từ điển</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtPublisher" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Ngôn ngữ :
                                <asp:HyperLink ID="lnkLanguage" runat="server" CssClass="lbLinkFunction">Từ điển</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtLanguage" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Định kỳ :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlRegularity" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>ISSN :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtISSN" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Phân loại :
                                <asp:HyperLink ID="lnkClassify" runat="server" CssClass="lbLinkFunction">Từ điển</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtClassify" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tiêu đề đề mục :
                                <asp:HyperLink ID="lnkSubject" runat="server" CssClass="lbLinkFunction">Từ điển</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtSubject" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Từ khóa :
                                <asp:HyperLink ID="lnkKeyword" runat="server" CssClass="lbLinkFunction">Từ điển</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtKeyword" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnSearch" runat="server" CssClass="lbButton" Text="Kiểm tra (t)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" runat="server" CssClass="lbButton" Text="Đặt lại (r)"></asp:Button>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <asp:Label ID="lblResult" runat="server" Visible="False" CssClass="lbLabel">Không tìm thấy ấn phẩm nào thoả mãn điều kiện tìm kiếm</asp:Label>
                    <div class="table-form">
                        <asp:DataGrid ID="DgrResult" CssClass="table-control" runat="server" Width="100%" PageSize="15" AutoGenerateColumns="False">
                            <EditItemStyle CssClass="lbGridEdit"></EditItemStyle>
                            <AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
                            <ItemStyle CssClass="lbGridCell"></ItemStyle>
                            <HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn DataField="Content" HeaderText="Nhan đề">
                                    <HeaderStyle Width="40%"></HeaderStyle>
                                    <ItemStyle VerticalAlign="Top"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ItemID" HeaderText="Số c&#243;, số thiếu">
                                    <HeaderStyle Width="40%"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="LastDateReceived" HeaderText="Ng&#224;y nhận cuối">
                                    <HeaderStyle HorizontalAlign="Center" Width="12%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn Visible="False" HeaderText="Số đầu"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" HeaderText="Kiểu định kỳ"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Chọn">
                                    <HeaderStyle Width="5%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:HyperLink runat="server" ID="lnkSelect" CssClass="lbLinkFunction">
											<img src="../../Images/select.jpg" border="0"></asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn Visible="False" DataField="ItemID"></asp:BoundColumn>
                            </Columns>
                            <PagerStyle Position="Top" CssClass="lbGridPager" Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>

                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="0">----- Chọn mức định kỳ: -----</asp:ListItem>
            <asp:ListItem Value="1">Bạn phải nhập điều kiện tìm kiếm</asp:ListItem>
            <asp:ListItem Value="2">Số có:</asp:ListItem>
            <asp:ListItem Value="3">Số thiếu:</asp:ListItem>
            <asp:ListItem Value="4">T</asp:ListItem>
            <asp:ListItem Value="5">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="6">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="7">Không tìm thấy dữ liệu thoả mãn điều kiện tìm kiêm!</asp:ListItem>
            <asp:ListItem Value="8">Ấn phẩm được chọn làm ấn phẩm hiện thời!</asp:ListItem>
            <asp:ListItem Value="9">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="10">Không tập</asp:ListItem>
            <asp:ListItem Value="11">Tất cả các số</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtTitle.focus();
    </script>
</body>
</html>
