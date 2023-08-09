<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WShowClaimList" CodeFile="WShowClaimList.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WShowClaimList</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
     <link runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
    <style>
        #divBody {
          
            padding-left: 20px
        }

            #divBody .tab {
                display: inline;
                text-align: right;
            }

                #divBody .tab ul {
                    padding-top: 5px;
                    padding-right: 30px;
                }

                    #divBody .tab ul li {
                        background: #f0a30a none repeat scroll 0 0;
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
            background-color: #000;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
        }
    </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
           <div class="tab">
                <ul>
                    <li>
                      <asp:HyperLink ID="hrfClaimTemplate" NavigateUrl="WClaimTemplateManagement.aspx" CssClass="lbLinkFunction"
                            runat="server">Tạo mẫu đơn khiếu nại</asp:HyperLink>


                    </li>
                    <li >

                        <asp:HyperLink ID="lblSetClaimCycle" NavigateUrl="WSetClaimCycle.aspx"  CssClass="lbLinkFunction" runat="server">Chu trình khiếu nại</asp:HyperLink>
                    </li>
                    <li>
                          <asp:HyperLink ID="hrfClaim" NavigateUrl="WClaim.aspx" CssClass="lbLinkFunction" runat="server">Khiếu nại</asp:HyperLink>

                    </li>
                    <li  class="active">
                          <asp:Label ID="lblShowClaimList" CssClass="lbGroupTitle" runat="server">Xem lại</asp:Label>

                    </li>

                </ul>
            </div>
            <div class="main-form">
                <div class="two-column ClearFix ">

                    <div class="two-column-form">
                        <div class="row-detail">
                            <asp:Label ID="lblVendor" runat="server">Nhà <u>p</u>hát hành: </asp:Label>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlVendor" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail ClearFix">
                    <div class="two-column">
                        <div class="two-column-form">
                            <div class="span4">
                                <div class="pad5">
                                    <p>
                                        Từ ngày
                                    <asp:HyperLink ID="hrfFromDate" runat="server" NavigateUrl="../../Common/WCalendar.aspx">Lịch</asp:HyperLink>
                                    </p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:TextBox CssClass="text-input" ID="txtFromDate" runat="server" Width=""></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="span4">

                                <div class="pad5">
                                    <p>
                                        Đến ngày
                                    <asp:HyperLink ID="hrfToDate" runat="server" NavigateUrl="../../Common/WCalendar.aspx">Lịch</asp:HyperLink>
                                    </p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:TextBox CssClass="text-input" ID="txtToDate" runat="server" Width=""></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnReview" runat="server" Text="Xem(v)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="table-form">
                        <asp:DataGrid ID="dgrClaimReview" CssClass="table-control" runat="server" AutoGenerateColumns="False" Width="100%" HeaderStyle-HorizontalAlign="Center">
                            <Columns>
                                <asp:BoundColumn DataField="STT" HeaderText="STT">
                                    <HeaderStyle Width="3%" HorizontalAlign="Center"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Content" HeaderText="Nhan đề"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Issue" HeaderText="Số">
                                    <HeaderStyle Width="12%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="IssuedDate" HeaderText="Ngày phát hành">
                                    <HeaderStyle Width="12%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="ClaimDate" HeaderText="Ngày khiếu nại">
                                    <HeaderStyle Width="12%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="SequenctClaimCycle" HeaderText="Lần khiếu nại">
                                    <HeaderStyle Width="8%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="center"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">---------- Chọn ----------</asp:ListItem>
            <asp:ListItem Value="3">Bạn chưa chọn nhà phát hành</asp:ListItem>
            <asp:ListItem Value="4">Sai khuôn dạng thời gian</asp:ListItem>
            <asp:ListItem Value="5">Không tìm thấy ấn phẩm nào thoả mãn điều kiện tìm kiếm!</asp:ListItem>
        </asp:DropDownList>

    </form>
</body>
</html>
