<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCheckInResult" EnableViewStateMac="False" CodeFile="WCheckInResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCheckInResult</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/magnific/magnific-popup.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery.min.js"></script>
    <script type="text/javascript" src="../../js/magnific/jquery.magnific-popup.min.js"></script>
    <style>
        .lbGridHeader {
            background: #cccccc none repeat scroll 0 0;
            color: #2061a3;
            text-align: center;
        }

        .row-detail p, .lbLabel {
            display: inline-block;
            height: auto;
            margin-bottom: 5px;
            padding-left: 10px;
        }
        .auto-style1 {
            width: 18%;
        }
        .auto-style2 {
            height: 21px;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblPatronInfor" runat="server" Width="100%" CssClass="lbGroupTitle">Thông tin bạn đọc</asp:Label></td>
            </tr>
            <tr valign="top">
                <td align="center" class="auto-style1">
                    <img id="imgPatronImage" src="../../Images/Card/Empty.gif" border="0" runat="server" />
                </td>
                <td align="left">
                    <br>
                    <asp:Label ID="lblFullNamelb" runat="server" CssClass="lbLabel">Tên (Số thẻ): &nbsp;</asp:Label><b><asp:Label ID="lblFullName" runat="server" CssClass="lbLabel"></asp:Label></b>
                    <br>
                    <asp:Label ID="lblDOBlb" CssClass="lbLabel" runat="server"> Ngày sinh: &nbsp; </asp:Label><b><asp:Label ID="lblDOB" runat="server" CssClass="lbLabel"></asp:Label></b>
                    <br>
                    <asp:Label ID="lblRangelb" runat="server" CssClass="lbLabel">Giá trị thẻ: &nbsp;</asp:Label><b><asp:Label ID="lblRange" runat="server" CssClass="lbLabel"></asp:Label></b>
                    <br>
                    <asp:Label ID="lblPatronGrouplb" runat="server" CssClass="lbLabel">Nhóm bạn đọc: &nbsp;</asp:Label><b><asp:Label ID="lblPatronGroup" runat="server" CssClass="lbLabel"></asp:Label></b>
                    <br>
                    <asp:Label ID="lblNoteb" runat="server" CssClass="lbLabel">Ghi chú: &nbsp;</asp:Label><i><asp:Label ID="lblNote" runat="server" CssClass="lbLabel"></asp:Label></i></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblCopyInfor" runat="server" Width="100%" CssClass="lbGroupTitle">Thông tin ấn phẩm</asp:Label></td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">
                    <asp:Label ID="lblTitlelb" runat="server">Nhan đề:</asp:Label></td>
                <td><b>
                    <asp:Label ID="lblTitle" runat="server"></asp:Label></b></td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">
                    <asp:Label ID="lblCopyNumberlb" runat="server">ÐKCB:</asp:Label></td>
                <td><b>
                    <asp:Label ID="lblCopyNumber" runat="server"></asp:Label></b></td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">
                    <asp:Label ID="lblCheckOutDatelb" runat="server">Ngày mượn:</asp:Label></td>
                <td><b>
                    <asp:Label ID="lblCheckOutDate" runat="server"></asp:Label></b></td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">
                    <asp:Label ID="lblCheckInDatelb" runat="server">Ngày trả:</asp:Label></td>
                <td><b>
                    <asp:Label ID="lblCheckInDate" runat="server"></asp:Label></b></td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">
                    <asp:Label ID="lblFeeslb" runat="server">Phí mượn, phạt:</asp:Label></td>
                <td><b>
                    <asp:Label ID="lblFees" runat="server"></asp:Label></b></td>
            </tr>
            <tr>
                <td class="lbPageTitle" style="HEIGHT: 19px; color: red" colspan="2">
                    <asp:Label ID="lblPageTitle" runat="server" Width="100%" CssClass="lbPageTitle">Trả ấn phẩm</asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblReasonInfor" runat="server" CssClass="lbLabel"></asp:Label></B></td>
            </tr>
            <tr>
                <td colspan="2"><asp:Label ID="lblLoanCurrentCheckIn" runat="server" Width="100%" CssClass="lbGroupTitle">Danh sách ấn phẩm vừa ghi trả:</asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DataGrid ID="dtgResultCurrentCheckIn" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell"
                        AutoGenerateColumns="False" DataKeyField="ID">
                        <Columns>
                            <asp:BoundColumn HeaderText="STT" DataField="STT" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center" ReadOnly="true"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Nhan đề" DataField="TITLE" ReadOnly="true"></asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="ÐKCB" DataField="CopyNumber" HeaderStyle-Width="125px" ReadOnly="true"></asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Ngày mượn" DataField="CheckOutDate" HeaderStyle-Width="130px" ReadOnly="true"></asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Ngày trả" DataField="CheckInDate" HeaderStyle-Width="130px" ReadOnly="true"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Phí mượn" ItemStyle-HorizontalAlign="Right" DataField="FeesTmp" HeaderStyle-Width="100px" ReadOnly="true"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Phí phạt quá hạn" ItemStyle-HorizontalAlign="Right" DataField="OverdueFineTmp" HeaderStyle-Width="100px"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Tiền cọc" ItemStyle-HorizontalAlign="Right" DataField="LoanDepositFeeTmp" HeaderStyle-Width="100px" ReadOnly="true"></asp:BoundColumn>
                            <asp:EditCommandColumn HeaderStyle-Width="50px" ButtonType="LinkButton" UpdateText="&lt;img src=&quot;../../images/Update.gif&quot; border=&quot;0&quot;&gt;"
                                CancelText="&lt;img src=&quot;../../images/Cancel.gif&quot; border=&quot;0&quot;&gt;"
                                EditText="&lt;img src=&quot;../../images/Edit.gif&quot; border=&quot;0&quot;&gt;"></asp:EditCommandColumn>
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>
            
            <tr>
                <td><p>&nbsp;</p></td>
            </tr>
            <tr>
                <td colspan="2">
                    <table id="tblFeeInfo" runat="server" class="lbGrid" cellspacing="0" rules="all" border="1" style="width:100%;border-collapse:collapse;">
	                    <tbody>
                            <tr class="lbGridHeader">
                                <td>&nbsp;</td>
                                <td style="width:100px;">Phí mượn</td>
                                <td style="width:100px;">Phí phạt quá hạn</td>
                                <td style="width:100px;">Tiền cọc</td>
                                <td style="width:50px;">&nbsp;</td>
                            </tr>
		                    <tr class="lbGridCell">
			                    <td>Tổng cộng</td>
                                <td align="right"><% =strTotalFees %></td>
                                <td align="right"><% =strTotalOverdueFine %></td>
                                <td align="right"><% =strTotalLoanDepositFee %></td>
                                <td>&nbsp;</td>
	                        </tr>
                            <tr class="lbGridCell">
                                <td class="auto-style2">Còn lại</td>
                                <td colspan="3" align="right" class="auto-style2"><% =strTotal %></td>
                                <td class="auto-style2"></td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="right" >
                    <div class="button-form" style="display:none;">
                        <button type="button" runat="server" id="btnPrintCheckIn" class="lbButton">In Phiếu</button>
                    </div>
                </td>
            </tr>
            <%--adfasdfsadf--%>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblLoanAlso" runat="server" Width="100%" CssClass="lbGroupTitle">Bạn đọc này cũng đang mượn các ấn phẩm</asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DataGrid ID="dtgResult" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-CssClass="lbGridItem" HeaderStyle-CssClass="lbGridHeader" AlternatingItemStyle-CssClass="lbGridAlterCell"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateColumn Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblSelectCopyNumber" Text='<%# DataBinder.Eval(Container.dataItem,"CopyNumber") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center" HeaderText="Chọn">
                                <ItemTemplate>
                                    <input type="checkbox" id="chkCopyNumber" runat="server" cssclass="lbCheckBox" />
                                    <label for="chkCopyNumber" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="STT" ItemStyle-HorizontalAlign="Center" DataField="STT"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Nhan đề" DataField="TITLE"></asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="ÐKCB" DataField="CopyNumber" ItemStyle-Width="12%"></asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Ngày mượn" DataField="CheckOutDate" ItemStyle-Width="8%" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="Center" HeaderText="Hạn trả" DataField="DueDate" ItemStyle-Width="10%" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundColumn>
                            <asp:TemplateColumn ItemStyle-Width="10%">
                                <ItemTemplate><asp:Label ID="LabelLoanMode" runat="server" Text='<%#If(DataBinder.Eval(Container.DataItem, "LoanMode") = "2", "Mượn tại chổ", "Mượn về nhà") %>'></asp:Label></ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="Tiền cọc" DataField="LoanDepositFee" ItemStyle-Width="15%" DataFormatString="{0:###,###}"></asp:BoundColumn>
                            <asp:BoundColumn DataField="RenewCount" HeaderText="Gia hạn" ReadOnly="true" ItemStyle-Wrap="true" ItemStyle-Width="12%" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Ghi chú" DataField="Note" ItemStyle-Width="18%"></asp:BoundColumn>
                        </Columns>
                    </asp:DataGrid></td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="padding-top: 10px">
                    <asp:Button ID="btnCheckIn" runat="server" Width="86px" Text="Ghi trả(c)"></asp:Button></td>
            </tr>
        </table>
        <asp:Label ID="lblJavascript" runat="server" Visible="True"></asp:Label>
        <input id="hidPatronCode" type="hidden" runat="server">
        <input id="hidCheckInDate" type="hidden" runat="server">
        <input id="hidAutoPaidFees" type="hidden" runat="server" value="1">
        <input id="hidPatronID" type="hidden" runat="server">
        <input id="hidCopyNumber" type="hidden" runat="server" value="">
        <input id="hidTransactionIDs" type="hidden" runat="server" value="">
        <asp:Label ID="lblMsg1" runat="server" Visible="False">Trả ấn phẩm thành công</asp:Label>
        <asp:Label ID="lblMsg2" runat="server" Visible="False">Lỗi trong quá trình trả ấn phẩm</asp:Label>
        <asp:Label ID="lblMsg3" runat="server" Visible="False">Tài liệu: {0} có bạn đọc {1} đặt mượn.</asp:Label>
        <asp:Label ID="lblMsg4" runat="server" Visible="False">Tài liệu: {0} có bạn đọc {1} đặt chổ.</asp:Label>
        <asp:Label ID="lblMsg5" runat="server" Visible="False">Cập nhật phí phạt thất bại</asp:Label>
        <asp:DropDownList ID="ddlLabel" Width="0" Visible="False" runat="server">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Trả ấn phẩm thành công</asp:ListItem>
            <asp:ListItem Value="3">Lỗi trong quá trình trả ấn phẩm</asp:ListItem>
            <asp:ListItem Value="4">Không tồn tại ÐKCB trong danh sách ấn phẩm cho mượn:&nbsp;</asp:ListItem>
            <asp:ListItem Value="5">Ấn phẩm chưa sẵn sàng phục vụ ( bị khóa hoặc chưa đưa ra lưu thông)</asp:ListItem>
            <asp:ListItem Value="6">Ấn phẩm đang được bạn đọc khác đặt chỗ</asp:ListItem>
            <asp:ListItem Value="7">Ấn phẩm này thuộc kho mà cán bộ thư viện không có quyền quản lý</asp:ListItem>
            <asp:ListItem Value="8">Bạn đọc không được mượn trả ấn phẩm thuộc những kho mà cán bộ thư viện quản lý</asp:ListItem>
            <asp:ListItem Value="9">Ấn phẩm này chưa được mượn.</asp:ListItem>
            <asp:ListItem Value="10">Quá hạn: </asp:ListItem>
            <asp:ListItem Value="11">(d)</asp:ListItem>
            <asp:ListItem Value="12">Hạn trả mở</asp:ListItem>
            <asp:ListItem Value="13">(h)</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script type="text/javascript">
        function showPopupDetail(strQueryString) {
            $.magnificPopup.open({
                items: {
                    src: 'WPrintCheckInResult.aspx' + strQueryString
                },
                tLoading: 'Loading...',
                type: 'iframe',
                closeBtnInside: true
            });
        }

        function showPopupReceipt(strQueryString) {
            $.magnificPopup.open({
                items: {
                    src: 'WPrintReceiptCheckInResult.aspx' + strQueryString
                },
                tLoading: 'Loading...',
                type: 'iframe',
                closeBtnInside: true
            });
        }

        function PrintMagnific() {
            $.magnificPopup.close();
        }
    </script>
</body>
</html>
