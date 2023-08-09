<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WCheckOutResult" EnableViewStateMac="False" CodeFile="WCheckOutResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCheckOutResult</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <style type="text/css">
        .main-form:last-child {
            font-size: 15px;
            margin-bottom: 0;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .main-group-form
        {
            margin:0; padding:3px 0px 3px 5px; margin-bottom:5px;
        }
        .row-detail
        {
            font-size:14px;
            padding:5px 0px 10px 0px;
            margin:0px;
        }
        .table-form
        {
            margin:0px;
        }
        .rgEditRow input[type=text], .lbGridEdit input[type=text]
        {
            width:100%;
        }
    </style>
</head>
<body leftmargin="0" topmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">

            <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
            </telerik:RadStyleSheetManager>
            <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            </telerik:RadAjaxManager>
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                    <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
                </Scripts>
            </telerik:RadScriptManager>
            <h2 class="main-head-form">Ghi mượn ấn phẩm</h2>
            <div class="main-form">
                <asp:Label ID="lblPatronInfor" runat="server" Width="100%" CssClass="lbSubformTitle">Thông tin bạn đọc</asp:Label>
                <div class="ClearFix">
                    <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr valign="top">
                            <td width="160" align="center">
                                <img alt="" style="width:4cm;" id="imgPatronImage" runat="server" src="../../Images/Card/Empty.gif" border="0" />
                            </td>
                            <td align="left">
                                <ul>
                                    <li>
                                        <asp:Label ID="lblFullNamelb" runat="server" CssClass="lbLabel">Tên (Số thẻ):&nbsp;</asp:Label>
                                        <b>
                                            <asp:Label ID="lblFullName" runat="server" CssClass="lbLabel"></asp:Label></b>
                                    </li>
                                    <li>
                                        <asp:Label ID="lblDOBlb" runat="server" CssClass="lbLabel"> Ngày sinh:&nbsp; </asp:Label>
                                        <b>
                                            <asp:Label ID="lblDOB" runat="server" CssClass="lbLabel"></asp:Label></b>
                                    </li>
                                    <li>
                                        <asp:Label ID="lblRangelb" runat="server" CssClass="lbLabel">Giá trị thẻ:&nbsp;</asp:Label>
                                        <b>
                                            <asp:Label ID="lblRange" runat="server" CssClass="lbLabel"></asp:Label></b>
                                    </li>
                                    <li>
                                        <asp:Label ID="lblPatronGrouplb" runat="server" CssClass="lbLabel">Nhóm bạn đọc:&nbsp;</asp:Label>
                                        <b>
                                            <asp:Label ID="lblPatronGroup" runat="server" CssClass="lbLabel"></asp:Label></b>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="lnkRenew" runat="server">&nbsp;Gia hạn thẻ</asp:HyperLink>
                                    </li>
                                </ul>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="button-control">
                    <asp:Label Visible="False" ID="lblClick" runat="server">Bấm:&nbsp;</asp:Label>
                    <asp:Button Visible="False" ID="btnCheckOut" runat="server" Text="Ghi mượn" Width="80px"></asp:Button>&nbsp;
					<asp:Label Visible="False" ID="lblComment" runat="server">nếu bạn muốn bỏ qua thông tin đặt chỗ.</asp:Label>
                </div>
                <asp:Label ID="LabelMessage" runat="server" Font-Bold="true" ForeColor="Red" Text=""></asp:Label>
                <asp:Label ID="lblCopyInfor" runat="server" Width="100%" CssClass="main-group-form" BackColor="Silver">Danh sách ấn phẩm vừa ghi mượn</asp:Label>
                <div class="row-detail">
                    <div class="table-form">

                        <telerik:RadGrid ID="dtgResult" runat="server"
                            CellSpacing="0"
                            AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgResult_NeedDataSource">
                            <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                <PagerStyle AlwaysVisible="True" />
                                <FooterStyle BackColor="White"></FooterStyle>

                                <Columns>
                                    <telerik:GridTemplateColumn Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="STT" ReadOnly="True" HeaderText="STT" ItemStyle-Wrap="false">
                                        <HeaderStyle  HorizontalAlign="Center" Width="5%" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridButtonColumn Text="Thu hồi" HeaderText="Thu hồi" CommandName="Delete" ItemStyle-Wrap="false">
                                        <HeaderStyle  HorizontalAlign="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="lbLinkFunction"></ItemStyle>
                                    </telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn DataField="CopyNumber" ReadOnly="True" HeaderText="ĐKCB" ItemStyle-Wrap="false">
                                        <HeaderStyle  HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="TITLE" ReadOnly="True" ItemStyle-Wrap="true" HeaderText="Nhan đề">
                                        <HeaderStyle  HorizontalAlign="Center" Width="25%" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="Ngày mượn">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:Label ID="lblCheckOutDate" Text='<%# DataBinder.Eval(Container.dataItem,"CHECKOUTDATE") %>' runat="server">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="DUEDATE" UniqueName="DUEDATE" HeaderText="Ngày trả">
                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    </telerik:GridBoundColumn>
                                   <%-- <telerik:GridBoundColumn DataField="CHECKOUTDATE" UniqueName="CHECKOUTDATE" HeaderText="Ngày mượn" DataFormatString="{0:dd/MM/yyyy HH:mm }" ItemStyle-Wrap="false">
                                        <HeaderStyle  HorizontalAlign="Center" Width="15%" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>--%>
                                    <%--<telerik:GridBoundColumn DataField="DUEDATE" UniqueName="DUEDATE" HeaderText="Ngày trả" DataFormatString="{0:dd/MM/yyyy HH:mm }" ItemStyle-Wrap="false">
                                        <HeaderStyle  HorizontalAlign="Center" Width="15%" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </telerik:GridBoundColumn>--%>
                                    <telerik:GridBoundColumn DataField="LoanDepositFee" HeaderText="Tiền cọc" UniqueName="LoanDepositFee" DataFormatString="{0:###,###}">
                                        <HeaderStyle  HorizontalAlign="Center" Width="10%" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Note" HeaderText="Ghi chú" UniqueName="Note" ItemStyle-Wrap="false">
                                        <HeaderStyle  HorizontalAlign="Center" Width="15%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridEditCommandColumn ItemStyle-Wrap="false" ItemStyle-Width="5%" ButtonType="LinkButton" HeaderText="Sửa" UpdateText="&lt;img src=&quot;../../images/update.gif&quot; border=&quot;0&quot;&gt;"
                                        CancelText="&lt;img src=&quot;../../images/cancel.gif&quot; border=&quot;0&quot;&gt;" EditText="&lt;img src=&quot;../../images/Edit2.gif&quot; border=&quot;0&quot;&gt;">
                                        <HeaderStyle  HorizontalAlign="Center" Width="10%" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="lbLinkFunction"></ItemStyle>
                                    </telerik:GridEditCommandColumn>
                                </Columns>
                                <PagerTemplate>
                                    <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                </PagerTemplate>
                            </MasterTableView>

                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                        </telerik:RadGrid>



                        <%--  <asp:DataGrid ID="dtgResult" CssClass="table-control" runat="server" Width="100%" OnDeleteCommand="dtgResult_DeleteCommand"
                            OnEditCommand="dtgResult_EditCommand" OnCancelCommand="dtgResult_CancelCommand" OnUpdateCommand="dtgResult_UpdateCommand"
                            HeaderStyle-CssClass="lbGridHeader" ItemStyle-CssClass="lbGridItem" AlternatingItemStyle-CssClass="lbGridAlterCell"
                            AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center">
                            <AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
                            <ItemStyle CssClass="lbGridItem"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="lbGridHeader"></HeaderStyle>
                            <Columns>
                                <asp:TemplateColumn Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:ButtonColumn Text="Thu hồi" HeaderText="Thu hồi" CommandName="Delete">
                                    <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="lbLinkFunction"></ItemStyle>
                                </asp:ButtonColumn>
                                <asp:BoundColumn DataField="CopyNumber" ReadOnly="True" HeaderText="ĐKCB">
                                    <ItemStyle Width="11%"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TITLE" ReadOnly="True" HeaderText="Nhan đề"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Ngày mượn">
                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblCheckOutDate" Text='<%# DataBinder.Eval(Container.dataItem,"CHECKOUTDATE") %>' runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn DataField="DUEDATE" HeaderText="Ngày trả">
                                    <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Note" HeaderText="Ghi chú"></asp:BoundColumn>
                                <asp:EditCommandColumn ItemStyle-Width="5%" ButtonType="LinkButton" HeaderText="Sửa" UpdateText="&lt;img src=&quot;../../images/update.gif&quot; border=&quot;0&quot;&gt;"
                                    CancelText="&lt;img src=&quot;../../images/cancel.gif&quot; border=&quot;0&quot;&gt;" EditText="&lt;img src=&quot;../../images/Edit2.gif&quot; border=&quot;0&quot;&gt;">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="lbLinkFunction"></ItemStyle>
                                </asp:EditCommandColumn>
                            </Columns>
                        </asp:DataGrid>--%>
                    </div>
                    <div class="button-control" style="text-align:right; display:none;">
                        <asp:Button ID="btPrintCheckOut" Visible="false" runat="server" Text="In phiếu ghi mượn"></asp:Button>
                    </div>
                </div>
                <div style="display:none">
                    <asp:Label ID="lblTotallb" runat="server" Visible="False">Tổng số ấn phẩm:</asp:Label><asp:Label ID="lblTotal" runat="server" Visible="False"></asp:Label>
                </div>
                <div style="display:none">
                    <asp:Label ID="lblReason" runat="server">Đang kiểm tra tình trạng ấn phẩm...&nbsp;</asp:Label>
                </div>
                <div style="display:none">
                    <asp:Label ID="lblReasonInfor" runat="server"></asp:Label>
                </div>

                <TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
			        <TR>
				        <TD>
					        <asp:label runat="server" CssClass="main-group-form" BackColor="Silver" width="100%">Ấn phẩm đang mượn</asp:label></TD>
			        </TR>
			        <TR>
				        <TD>
					        <asp:datagrid id="dtgResultDetail" runat="server" Width="100%" AllowCustomPaging="False" HeaderStyle-HorizontalAlign="Center"
						        AutoGenerateColumns="False" ItemStyle-VerticalAlign="Top">
						        <AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
						        <Columns>
							        <asp:BoundColumn DataField="STT" HeaderText="STT" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
							        <asp:BoundColumn DataField="CopyNumber" HeaderText="ĐKCB" ItemStyle-Width="12%"></asp:BoundColumn>
							        <asp:BoundColumn DataField="Title" HeaderText="Nhan đề"></asp:BoundColumn>
							        <asp:BoundColumn DataField="CHECKOUTDATE" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="14%" HeaderText="Ngày mượn"></asp:BoundColumn>
							        <asp:BoundColumn DataField="DUEDATE" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" HeaderText="Ngày trả"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="LoanDepositFee" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" HeaderText="Tiền cọc" DataFormatString="{0:###,###}"></asp:BoundColumn>
							        <asp:BoundColumn DataField="Note" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="12%" HeaderText="Ghi chú"></asp:BoundColumn>
						        </Columns>
					        </asp:datagrid></TD>
			        </TR>
		        </TABLE>
		        <asp:DropDownList ID="ddlLabelLoanDetail" Runat="server" Visible="False" Width="0">
			        <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
			        <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			        <asp:ListItem Value="2">về nhà</asp:ListItem>
			        <asp:ListItem Value="3">tại chỗ</asp:ListItem>
			        <asp:ListItem Value="4">ngoài hạn ngạch</asp:ListItem>
		        </asp:DropDownList>
            </div>
        </div>
        <asp:Label ID="lblMsg1" runat="server" Visible="False">Không tồn tại ĐKCB:&nbsp;</asp:Label>
        <asp:Label ID="lblMsg2" runat="server" Visible="False">Ấn phẩm chưa sẵn sàng phục vụ (bị khoá hoặc chưa đưa ra lưu thông)</asp:Label>
        <asp:Label ID="lblMsg3" runat="server" Visible="False">Ấn phẩm đang được cho mượn</asp:Label>
        <asp:Label ID="lblMsg4" runat="server" Visible="False">Ấn phẩm đang được bạn đọc khác đặt chỗ</asp:Label>
        <asp:Label ID="lblMsg5" runat="server" Visible="False">Ấn phẩm này thuộc kho mà cán bộ thư viện không có quyền quản lý</asp:Label>
        <asp:Label ID="lblMsg6" runat="server" Visible="False">Bạn đọc không được mượn ấn phẩm tại những kho mà nhóm mình không được mượn.</asp:Label>
        <asp:Label ID="lblMsg7" runat="server" Visible="False">Thẻ bạn đọc đã hết hạn.</asp:Label>
        <asp:Label ID="lblMsg8" runat="server" Visible="False">Bạn đọc có ấn phẩm mượn quá hạn. Không được phép ghi mượn.</asp:Label>
        <asp:Label ID="lblMsg9" runat="server" Visible="False">Thẻ bạn đọc không tồn tại.</asp:Label>
        <asp:Label ID="lblMsg10" runat="server" Visible="False">Hạn ngạch cho phép ghi mượn đã đủ, không được phép ghi mượn thêm.</asp:Label>
        <input id="hidPatronCode" type="hidden" runat="server">
        <input id="hidHoldIgnored" type="hidden" value="0" name="hidHoldIgnored" runat="server">
        <input type="hidden" id="hidCont" runat="server" value="0" name="hidCont">
        <input id="hidLoanMode" type="hidden" runat="server" value="0">
        <input id="hidDueDate" type="hidden" runat="server" name="hidDueDate">
        <input id="hidCheckOutDate" type="hidden" runat="server" name="hidCheckOutDate">
        <input id="hidCopyNumber" type="hidden" runat="server">
        <input id="hidAmountDeposit" type="hidden" runat="server" name="hidAmountDeposit" value="0">
        <asp:DropDownList ID="ddlLabel" Width="0" Visible="False" runat="server">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Ghi mượn ấn phẩm</asp:ListItem>
            <asp:ListItem Value="3">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="4">Thu hồi ấn phẩm vừa ghi mượn</asp:ListItem>
            <asp:ListItem Value="5">Bạn không được phép mượn tài liệu tại kho chứa tài liệu này!</asp:ListItem>
            <asp:ListItem Value="6">Bạn đọc đã quá hạn ngạch. Bấm OK để đồng ý cho mượn. Bấm Cancel để từ chối.</asp:ListItem>
            <asp:ListItem Value="7">Ngày mượn phải nhỏ hơn ngày trả.</asp:ListItem>
            <asp:ListItem Value="8">Quá hạn: </asp:ListItem>
            <asp:ListItem Value="9">(d)</asp:ListItem>
            <asp:ListItem Value="10">Hạn trả mở</asp:ListItem>
            <asp:ListItem Value="11">(h)</asp:ListItem>
            <asp:ListItem Value="12">Bạn đọc không được phép mượn dạng tài liệu này!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
