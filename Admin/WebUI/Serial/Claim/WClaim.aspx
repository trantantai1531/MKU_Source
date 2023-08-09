<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WClaim" CodeFile="WClaim.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WClaim</title>
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
    <form id="Form1" runat="server">
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
                    <li class="active">
                          <asp:Label ID="hrfClaim" CssClass="lbGroupTitle" runat="server">Khiếu nại</asp:Label>

                    </li>
                    <li>
                         <asp:HyperLink ID="hrfShowClaimList" NavigateUrl="WShowClaimList.aspx" CssClass="lbLinkFunction"
                        runat="server">Xem lại</asp:HyperLink>

                    </li>

                </ul>
            </div>
            <div class="main-form">
                <div class="row-detail">
                    <div class="col-left-2">
                        <div class="input-control">
                            <span><u>N</u>ăm bổ sung: &nbsp; </span>
                            <div class="input-form" style="width: 39%; display: inline-block;">
                                <asp:TextBox CssClass="text-input" ID="txtAcqYear" runat="server"></asp:TextBox>
                            </div>
                            <input id="hdClaimCycleMode" type="hidden" value="1" name="hdClaimCycleMode" runat="server">
                        </div>

                    </div>
                    <div class="col-left-4">
                        <p>Tên mẫu :</p>
                        <div class="checkbox-control">
                            <asp:RadioButton ID="rdClaimCycle1" runat="server" Text="Khiếu nại lần <u>1</u>" Checked="True" GroupName="ClaimCycle"></asp:RadioButton>
                            <label for="rdClaimCycle1"></label>
                            <asp:RadioButton ID="rdClaimCycle2" runat="server" Text="Khiếu nại lần <u>2</u>" GroupName="ClaimCycle"></asp:RadioButton>
                            <label for="rdClaimCycle2"></label>
                            <asp:RadioButton ID="rdClaimCycle3" runat="server" Text="Khiếu nại lần <u>3</u>" GroupName="ClaimCycle"></asp:RadioButton>
                            <label for="rdClaimCycle3"></label>
                        </div>
                        
                    </div>
                    <div class="col-left-2">
                        <asp:Button ID="btnCheck1" runat="server" Width="88px" Text="Kiểm tra(c)"></asp:Button>
                        </div>
                </div>
                <div style="width: 100px; clear: both; margin-left :10px">
                    <asp:Label ID="lblClaimTemplate" runat="server" class="" style="float: left; width: 202px; font-size: 15px;"><u>M</u>ẫu đơn thư khiếu nại: </asp:Label>&nbsp;<asp:DropDownList ID="ddlClaimTemplate" CssClass="lbDrowpdownlist" runat="server"></asp:DropDownList>
                </div>
                <div class="table-form">
                    <asp:DataGrid ID="dgrClaimItem" CssClass="table-control" runat="server" Width="100%" PagerStyle-Position="TopAndBottom"
                        PageSize="20" AllowPaging="True" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="5%"></HeaderStyle>
                                <ItemTemplate>
                                    <input  type="checkbox" ID="ckbIssueNo" runat="server"></input>
                                   <label for="CheckAllSelect"></label>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <input class="lbCheckBox" type="checkbox" id="CheckAll" onclick="javascript: CheckAllOptionsVisible('dgrClaimItem', 'ckbIssueNo', 3, 20);">
                                      <label for="CheckAll"></label>
                                </HeaderTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="False">
                                <HeaderStyle Width="5%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtID" runat="server" Text='<%# DataBinder.Eval(Container.dataItem,"ItemID") %>' ReadOnly="True" Visible="False">
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn DataField="Content" HeaderText="Nhan đề">
                                <HeaderStyle Width="50%"></HeaderStyle>
                            </asp:BoundColumn>
                            <asp:BoundColumn DataField="IssueNo" HeaderText="Các số cần khiếu nại">
                                <HeaderStyle Width="40%"></HeaderStyle>
                            </asp:BoundColumn>
                        </Columns>
                        <PagerStyle CssClass="lbGridPage" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>

                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnPrintLetter" runat="server" Width="" Text="In thư(p)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnSendEmail" runat="server" Width="" Text="Gửi thư(s)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnPreview" runat="server" Width="" Text="Xem thử(v)"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input id="hdIDs" type="hidden" name="hdIDs" runat="server">
        <input id="hidSendTo" type="hidden" name="hidSendTo" runat="server">
        <input id="hdMsg" type="hidden" runat="server">
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
            <asp:ListItem Value="3">---------- Chọn mẫu ----------</asp:ListItem>
            <asp:ListItem Value="4">Năm kiểm tra phải là số nguyên</asp:ListItem>
            <asp:ListItem Value="5">Chưa chọn mẫu đơn khiếu nại</asp:ListItem>
            <asp:ListItem Value="6">Xem đơn khiếu nại</asp:ListItem>
            <asp:ListItem Value="7">In đơn khiếu nại</asp:ListItem>
            <asp:ListItem Value="8">Gửi đơn khiếu nại đến nhà cung cấp</asp:ListItem>
            <asp:ListItem Value="9">Bạn chưa chọn năm bổ sung!</asp:ListItem>
            <asp:ListItem Value="10">Bạn phải chọn ít nhất một ấn phẩm cần khiếu nại!</asp:ListItem>
            <asp:ListItem Value="11">Không tìm thấy ấn phẩm nào cần khiếu nại!</asp:ListItem>
            <asp:ListItem Value="12">Nhà cung cấp ấn phẩm: </asp:ListItem>
            <asp:ListItem Value="13">không có địa chỉ Email khiếu nại nên không gửi được.</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtAcqYear.focus();
    </script>
</body>
</html>
