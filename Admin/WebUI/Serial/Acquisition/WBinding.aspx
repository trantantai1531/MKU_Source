<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WBinding"
    CodeFile="WBinding.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WBinding</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <style>
        #divBody .tab {
            display: inline;
            text-align: right;
        }

            #divBody .tab ul {
                padding-top: 5px;
            }

                #divBody .tab ul li {
                    background: #4182C4 none repeat scroll 0 0;
                    color: #fff;
                    display: inline-block;
                    padding: 5px 10px;
                }

        li {
            list-style: outside none none;
        }

        #divBody .tab ul li a {
            color: #fff;
        }

        #divBody .tab ul li.active {
            background-color: #024385;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
        }

        select {
            min-width: 240px;
            width: auto;
        }
    </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="tab">
                <ul>
                    <li>
                        <asp:HyperLink ID="lnkHdAcquire" runat="server" CssClass="lbLinkFunction">Bổ sung</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="lnkHdSetRegularity" runat="server" CssClass="lbLinkFunction">Định kỳ</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="lnkHdRegister" runat="server" CssClass="lbLinkFunction">Đăng ký</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="lnkHdReceive" runat="server" CssClass="lbLinkFunction">Ghi nhận</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="lnkHdView" runat="server" CssClass="lbLinkFunction">Kiểm tra</asp:HyperLink></li>
                    <li class="active">
                        <asp:Label ID="lblBinding" runat="server" CssClass="lbGroupTitle">Đóng tập</asp:Label></li>
                    <li>
                        <asp:HyperLink ID="lnkHdSummary" runat="server" CssClass="lbLinkFunction">Tổng hợp</asp:HyperLink></li>
                </ul>
            </div>
            <div class="row-detail">
                <h1 class="main-head-form">
                    <asp:Label ID="lblTitle" runat="server" Width="100%"></asp:Label>
                </h1>
                <p>
                    <asp:Label ID="lblBindingRule" runat="server" CssClass="lbSubFormTitle">Đóng tập theo kho</asp:Label>
                    |
                <asp:HyperLink ID="lnkBinding" runat="server" CssClass="lbLinkFunction">Quy tắc đóng tập</asp:HyperLink>
                </p>
            </div>
            <div class="two-column ClearFix">
                <div class="two-column-form">
                    <div class="row-detail ClearFix">
                        <p>
                            <asp:Label ID="lblNotBindIssue" runat="server" CssClass="lbSubFormTitle"><U>C</U>ác số chưa đóng tập trong năm:</asp:Label>
                        </p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblLocation" runat="server" CssClass="lbSubFormTitle"><U>K</U>ho:</asp:Label></p>
                    <div class="input-control">
                        <div class="dropdown-form">
                            <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    </div>
                    <div class="row-detail">
                        <p>
                            <asp:Label ID="lblBindIssue" runat="server" CssClass="lbSubFormTitle">Các số đã đóng tập</asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="lblVolumeDetail" runat="server"></asp:Label><br>
                        </p>
                    </div>
                </div>
            </div>
            <div class="table-form">
                <asp:DataGrid ID="dtgCopiesToBind" runat="server" Width="100%" AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderText="Chọn">
                            <ItemTemplate>

                                <input id="chkID" type="checkbox" runat="server">
                                <label for="chkID"></label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="IssueNo" HeaderText="Số" ItemStyle-Width="23%"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IssuedMonth" HeaderText="Tháng" ItemStyle-HorizontalAlign="Center"
                            ItemStyle-Width="11%"></asp:BoundColumn>
                        <asp:BoundColumn DataField="IssuedDate" HeaderText="Ngày phát hành" ItemStyle-HorizontalAlign="Center"
                            ItemStyle-Width="23%"></asp:BoundColumn>
                        <asp:BoundColumn DataField="ReceivedDate" HeaderText="Ngày nhận" ItemStyle-HorizontalAlign="Center"
                            ItemStyle-Width="17%"></asp:BoundColumn>
                        <asp:BoundColumn DataField="VolumeByPublisher" HeaderText="Tập (NXB)"></asp:BoundColumn>
                    </Columns>
                </asp:DataGrid>
            </div>
            <table id="Table2" cellspacing="0" cellpadding="4" width="100%" border="0">
            </table>
            <table id="Table1" cellspacing="0" cellpadding="3" width="100%" border="0">
                <tr>
                    <td valign="top"></td>
                    <td valign="top" colspan="1" rowspan="2"></td>
                </tr>
            </table>
            <div style="text-align: center">
                <asp:Label ID="lblBindingInfor" runat="server" CssClass="main-group-form" Width="100%">Thông tin đóng tập</asp:Label>
            </div>
            <table id="Table3" cellspacing="0" cellpadding="2" width="100%" border="0">
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td align="right" width="48%">
                        <asp:Label ID="lblLoanType" runat="server"><U>D</U>ạng tư liệu lưu thông:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLoanType" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblAcqSource" runat="server"><U>N</U>guồn bổ sung:</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAcqSource" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblPrice" runat="server"><U>G</U>iá tiền:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrice" runat="server" Width="240px">0</asp:TextBox>&nbsp;
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc">(*)</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblVolume" runat="server"><U>T</U>ên tập:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtVolume" runat="server" Width="240px"></asp:TextBox>&nbsp;
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc">(*)</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblShelf" runat="server"><U>T</U>ên giá:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtShelf" runat="server" Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblCopyNumber" runat="server"><U>Đ</U>KCB:</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCopyNumber" runat="server" Width="240px"></asp:TextBox>&nbsp;
                    <asp:Label ID="lblLabel3" runat="server" Font-Bold="True" ForeColor="Red" ToolTip="Trường bắt buộc">(*)</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2"></td>
                </tr>
            </table>
            <div class="row-detail">
                <div class="button-control" style="text-align: center;">
                    <div class="button-form">
                        <asp:Button ID="btnGenCopyNum" runat="server" Width="105px" Text="Sinh giá trị(g)"></asp:Button>
                    </div>
                    <div class="button-form">
                        <asp:Button ID="btnUpdate" runat="server" Width="88px" Text="Cập nhật(c)"></asp:Button>
                    </div>
                </div>
            </div>
            <input id="hidCopyNumberID" type="hidden" value="0" runat="server" />
            <input id="hidPrice" type="hidden" value="0" runat="server" />
            <input id="hidCopyNumber" type="hidden" runat="server" />
        </div>
        <asp:DropDownList ID="ddlLabel" Width="0" Visible="False" runat="server">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Đóng tập ấn phẩm định kỳ với tên: </asp:ListItem>
            <asp:ListItem Value="3">Gỡ tập ấn phẩm định kỳ</asp:ListItem>
            <asp:ListItem Value="4">Đã đến kỳ đóng tập cho ấn phẩm hiện hành</asp:ListItem>
            <asp:ListItem Value="5">Sai kiểu dữ liệu</asp:ListItem>
            <asp:ListItem Value="6">Bạn chưa nhập đủ thông tin</asp:ListItem>
            <asp:ListItem Value="7">Đóng tập thành công</asp:ListItem>
            <asp:ListItem Value="8">Bạn chưa chọn bản tạp chí cần đóng tập</asp:ListItem>
            <asp:ListItem Value="9">Bạn có muốn gỡ tập không?</asp:ListItem>
            <asp:ListItem Value="10">Gỡ tập thành công!</asp:ListItem>
            <asp:ListItem Value="11">Đóng tập không thành công (Dự liệu nhập vào có chứa các ký tự đặc biệt).</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
