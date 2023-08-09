<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WReceive"
    CodeFile="WReceive.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WReceive</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <style>
        #divBody .tab
        {
            display: inline;
            text-align: right;
        }
        #divBody .tab ul
        {
            padding-top: 5px;
        }
          #divBody .tab ul li
        {
            background: #f0a30a none repeat scroll 0 0;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
        }
        li
        {
            list-style: outside none none;
        }
        
        #divBody .tab ul li a
        {
            color: #fff;
        }
          #divBody .tab ul li.active
        {
            background-color: #000;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
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
                    <asp:HyperLink ID="lnkHdRegister" runat="server" CssClass="lbLinkFunction">Ðăng ký</asp:HyperLink></li>
                <li class="active">
                    <asp:Label ID="lblHdRegister" runat="server" CssClass="lbGroupTitle">Ghi nhận</asp:Label></li>
                <li>
                    <asp:HyperLink ID="lnkHdView" runat="server" CssClass="lbLinkFunction">Kiểm tra</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdBinding" runat="server" CssClass="lbLinkFunction">Ðóng tập</asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="lnkHdSummary" runat="server" CssClass="lbLinkFunction">Tổng hợp</asp:HyperLink></li>
            </ul>
        </div>
        <div class="row-detail">
            <h1 class="main-head-form">
                <asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
        </div>
        <div class="two-column ClearFix">
            <div class="two-column-form">
                <div class="input-control">
                    <div class="row-detail ClearFix">
                        <div class="span3">
                            <div class="pad5">
                                <div class="input-control">
                                    <p>
                                        <asp:Label ID="lblLocation" runat="server"><U>K</U>ho:</asp:Label></p>
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlLocation" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="span3">
                            <div class="pad5">
                                <div class="input-control">
                                    <p>
                                        <asp:Label ID="lblYear" runat="server"><U>N</U>ăm:</asp:Label></p>
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="span3">
                            <div class="pad5">
                                <div class="input-control" id="ddlformboxMonth" runat="server">
                                    <p>
                                        <asp:Label ID="lblMonth" runat="server"><U>T</U>háng:</asp:Label></p>
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="1" Selected="True">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                            <asp:ListItem Value="7">7</asp:ListItem>
                                            <asp:ListItem Value="8">8</asp:ListItem>
                                            <asp:ListItem Value="9">9</asp:ListItem>
                                            <asp:ListItem Value="10">10</asp:ListItem>
                                            <asp:ListItem Value="11">11</asp:ListItem>
                                            <asp:ListItem Value="12">12</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail ClearFix">
                        <div class="span3">
                            <div class="pad5">
                                <div class="input-control">
                                    <p>
                                        <asp:Label ID="lblIssue" runat="server"><U>S</U>ố:</asp:Label></p>
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlIssue" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="span7">
                            <div class="pad5">
                                <div class="input-control">
                                    <p>
                                        <asp:Label ID="lblVolume" runat="server">Tậ<U>p</U> (NXB):</asp:Label></p>
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlVolume" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="two-column-form">
                <div class="row-detail ClearFix">
                    <div class="span3">
                        <div class="pad5">
                            <div class="input-control">
                                <p>
                                    <asp:Label ID="lblReceivedDate" runat="server">N<U>g</U>ày nhận:</asp:Label><asp:HyperLink
                                        ID="lnkReceivedDate" runat="server" CssClass="lbLinkFunction">Lịch</asp:HyperLink></p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtReceivedDate" runat="server" Width="120px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="span7">
                        <div class="pad5">
                            <div class="input-control">
                                <p>
                                    <asp:Label ID="lblReceivedCopies" runat="server"><U>S</U>ố lượng</asp:Label></p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtReceivedCopies" runat="server" Width="120px">0</asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="lblNote" runat="server">Ghi <U>c</U>hú:</asp:Label></p>
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtNote" runat="server" Rows="2" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row-detail">
            <div class="button-control" style="text-align: center;">
                <div class="button-form">
                    <asp:Button ID="btnReceive" runat="server" Text="Ghi nhận(e)"></asp:Button>&nbsp;
                </div>
                <div class="button-form">
                    <asp:Button ID="btnReset" runat="server" Text="Ðặt lại(r)"></asp:Button>
                </div>
            </div>
        </div>
        <div class="table-form">
            <asp:DataGrid ID="dtgResult" runat="server" Width="100%" OnEditCommand="dtgResult_EditCommand"
                OnCancelCommand="dtgResult_CancelCommand" OnUpdateCommand="dtgResult_UpdateCommand"
                AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateColumn>
                        <ItemStyle HorizontalAlign="Center" Width="4%"></ItemStyle>
                        <HeaderTemplate>
                            <input class="lbCheckBox" type="checkbox" id="chkCheckAll" onclick="javascript: CheckAllOptionsVisible('dtgResult', 'chkID', 2, 1000);">
                            <label for="chkCheckAll"></label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%--<asp:CheckBox ID="chkID" runat="server"></asp:CheckBox>
                                <label for="chkID"></label>--%>
                            <asp:Literal ID="LiteralCheckBox" runat="server"></asp:Literal>
                            <asp:HiddenField ID="hidID" Value='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:BoundColumn DataField="ReceivedDate" HeaderText="Ng&#224;y nhận">
                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Note" HeaderText="Ghi ch&#250;"></asp:BoundColumn>
                    <asp:BoundColumn DataField="VolumeByLibrary" ReadOnly="True" HeaderText="Tập (Thư viện qui ước)">
                        <ItemStyle Width="20%"></ItemStyle>
                    </asp:BoundColumn>
                    <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src=&quot;../../images/update.gif&quot; border=&quot;0&quot;&gt;"
                        HeaderText="Sửa" CancelText="&lt;img src=&quot;../../images/cancel.gif&quot; border=&quot;0&quot;&gt;"
                        EditText="&lt;img src=&quot;../../images/Edit2.gif&quot; border=&quot;0&quot;&gt;">
                        <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="lbLinkFunction"></ItemStyle>
                    </asp:EditCommandColumn>
                </Columns>
                <PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
            </asp:DataGrid>
        </div>
        <div class="row-detail">
            <div class="button-control" style="text-align: center;">
                <div class="button-form">
                    <asp:Button ID="btnUnReceive" runat="server" Text="Hủy ghi nhận(u)"></asp:Button>
                </div>
            </div>
        </div>
    </div>
    <table id="tblHeader" cellspacing="0" cellpadding="4" width="100%" border="0" runat="server">
    </table>
    <table id="Table1" cellspacing="0" cellpadding="3" width="100%" border="0">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblComment" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <input type="hidden" id="hidCeasedDate" name="hidCeasedDate" runat="server" />
    <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
        <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
        <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
        <asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
        <asp:ListItem Value="3">Dữ liệu không phải dạng số</asp:ListItem>
        <asp:ListItem Value="4">Bạn chưa nhập đủ thông tin về số cần ghi nhận</asp:ListItem>
        <asp:ListItem Value="5">---------- Chọn ----------</asp:ListItem>
        <asp:ListItem Value="6">Ghi nhận số cho ấn phẩm có nhan đề</asp:ListItem>
        <asp:ListItem Value="7">Hủy ghi nhận số cho ấn phẩm có nhan đề</asp:ListItem>
        <asp:ListItem Value="8">Bạn chưa chọn bản cần hủy!</asp:ListItem>
        <asp:ListItem Value="9">Bạn có muốn hủy ghi nhận không?</asp:ListItem>
        <asp:ListItem Value="10">Ngày ghi nhận lớn hơn ngày đình bản</asp:ListItem>
        <asp:ListItem Value="11">Không có số nào của ấn phẩm được phân vào kho hiện tại!</asp:ListItem>
        <asp:ListItem Value="12">Số lượng ghi nhận phải lớn hơn 0!</asp:ListItem>
        <asp:ListItem Value="13">Bạn không được cấp quyền sử dụng chức năng này.</asp:ListItem>
    </asp:DropDownList>
    </form>
</body>
</html>
