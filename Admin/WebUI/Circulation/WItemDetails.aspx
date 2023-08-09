<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WItemDetails" CodeFile="WItemDetails.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 TRansitional//EN">
<html>
<head>
    <title>WItemDetails</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">

    <%--  <style>
        .lbGridHeader {
            background: #cccccc none repeat scroll 0 0;
            color: #2061a3;
            text-align: center;
        }

        .lbButton {
            background: #aacfea none repeat scroll 0 0;
            border: 1px solid #aacfea;
            border-radius: 5px;
            color: #2061a3;
            cursor: pointer;
            display: inline-block;
            min-width: 45px;
            padding: 5px 6px;
            vertical-align: top;
        }
    </style>--%>
    <link href="../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="rdoDefault();"
    oncontextmenu="return true;">
    <form id="Form1" method="post" runat="server">
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

        <table id="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <td>
                    <table id="Table1" cellspacing="0" cellpadding="2" width="100%" border="0">
                        <tr class="lbPageTitle">
                            <td colspan="3">
                                <asp:Label ID="lblMainTitle" runat="server" CssClass="main-group-form">Thông tin thư mục và xếp giá của ấn phẩm</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Table ID="tblMainInfor" runat="server"></asp:Table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <hr width="100%">
                            </td>
                        </tr>
                        <tr class="lbSubformTitle">
                            <td colspan="3">
                                <asp:Label ID="lblSubTitle" runat="server" CssClass="lbSubformTitle">Xếp giá</asp:Label></td>
                        </tr>
                        <tr class="lbAmount">
                            <td width="30%">
                                <asp:Label ID="lblWaitting" runat="server">Đang chờ nhập kho <img src="../images/process.gif"></asp:Label></td>
                            <td width="25%">
                                <asp:Label ID="lblLoanning" runat="server">Đang cho mượn <img src="../images/loan.gif"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblLocking" runat="server">Đang khoá <img src="../images/lock.gif"></asp:Label></td>
                        </tr>
                    </table>
                    <td></td>
                <tr>
                    <td>
                        <table id="GridTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td align="center" colspan="3">

                                    <telerik:RadGrid ID="dtgResult" runat="server" AllowPaging="True"
                                        CellSpacing="0"
                                        AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgResult_NeedDataSource">
                                        <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                            <PagerStyle AlwaysVisible="True" />
                                            <FooterStyle BackColor="White"></FooterStyle>
                                            <Columns>
                                                <telerik:GridTemplateColumn Visible="False">
                                                    <itemtemplate>
                                                    <asp:Label ID="lblRadio" runat="server">
														<%# DataBinder.Eval(Container.dataItem,"rdoChoice")%>
                                                    </asp:Label>
                                                </itemtemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Kho" Visible="False">
                                                    <headerstyle width="15%"></headerstyle>
                                                    <ItemTemplate>
                                                        <a href='<%# "#" & DataBinder.Eval(Container.DataItem, "ID")%>'>
                                                            <asp:Label ID="lblLocation" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LocName")%>'></asp:Label>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="LocName" HeaderText="Kho">
                                                    <headerstyle width="15%"></headerstyle>
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridTemplateColumn HeaderText="Giá sách" Visible="false">
                                                    <headerstyle width="5%"></headerstyle>
                                                    <ItemTemplate>
                                                        <a href='<%# "#" & DataBinder.Eval(Container.DataItem, "ID")%>'>
                                                            <asp:Label ID="lblShelf" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Shelf")%>'></asp:Label>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="Shelf" HeaderText="Giá sách">
                                                    <headerstyle width="5%"></headerstyle>
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridTemplateColumn HeaderText="Số định danh" Visible="false">
                                                    <headerstyle width="15%"></headerstyle>
                                                    <ItemTemplate>
                                                        <a href='<%# "#" & DataBinder.Eval(Container.DataItem, "ID")%>'>
                                                            <asp:Label ID="lblCallNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CallNumber")%>'></asp:Label>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="CallNumber" HeaderText="Số định danh">
                                                    <headerstyle width="15%"></headerstyle>
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridTemplateColumn HeaderText="Mã xếp giá">
                                                    <headerstyle width="15%"></headerstyle>
                                                    <ItemTemplate>
                                                        <%#If(DataBinder.Eval(Container.DataItem, "InUsed").ToString() = "False" And DataBinder.Eval(Container.DataItem, "Acquired").ToString() = "True" And DataBinder.Eval(Container.DataItem, "InCirculation").ToString() = "True",
                                                            "<a href='#" & DataBinder.Eval(Container.DataItem, "CopyNumber") & "' onclick=""return onclickCopyNumber('" & DataBinder.Eval(Container.DataItem, "CopyNumber") & "')"">" & DataBinder.Eval(Container.DataItem, "CopyNumber") & "</a>",
                                                            DataBinder.Eval(Container.DataItem, "CopyNumber"))
                                                        %>
                                                        
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="CopyNumber" HeaderText="Mã xếp giá" Visible="false">
                                                    <headerstyle width="15%"></headerstyle>
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridTemplateColumn HeaderText="Tập" Visible="false">
                                                    <headerstyle width="5%"></headerstyle>
                                                    <ItemTemplate>
                                                        <a href='<%# "#" & DataBinder.Eval(Container.DataItem, "ID")%>'>
                                                            <asp:Label ID="lblVolume" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Volume")%>'></asp:Label>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="Volume" HeaderText="Tập">
                                                    <headerstyle width="5%"></headerstyle>
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridTemplateColumn HeaderText="Giá tiền" Visible="false">
                                                    <headerstyle width="15%"></headerstyle>
                                                    <ItemTemplate>
                                                        <a href='<%# "#" & DataBinder.Eval(Container.DataItem, "ID")%>'>
                                                            <asp:Label ID="lblPrice" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price")%>'></asp:Label>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="Price" HeaderText="Giá tiền">
                                                    <headerstyle width="15%"></headerstyle>
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridTemplateColumn HeaderText="Ghi chú" Visible="false">
                                                    <headerstyle width="15%"></headerstyle>
                                                    <ItemTemplate>
                                                        <a href='<%# "#" & DataBinder.Eval(Container.DataItem, "ID")%>'>
                                                            <asp:Label ID="lblNote" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Note")%>'></asp:Label>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="Note" HeaderText="Ghi chú">
                                                    <headerstyle width="15%"></headerstyle>
                                                </telerik:GridBoundColumn>
                                                
                                                <telerik:GridTemplateColumn HeaderText="Dạng tài liệu lưu thông" Visible="false">
                                                    <headerstyle width="10%"></headerstyle>
                                                    <ItemTemplate>
                                                        <a href='<%# "#" & DataBinder.Eval(Container.DataItem, "ID")%>'>
                                                            <asp:Label ID="lblLoanType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LoanType")%>'></asp:Label>
                                                        </a>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridBoundColumn DataField="LoanType" HeaderText="Dạng tài liệu lưu thông">
                                                    <headerstyle width="10%"></headerstyle>
                                                </telerik:GridBoundColumn>

                                                <telerik:GridTemplateColumn HeaderText="Trạng thái">
                                                    <headerstyle width="10%"></headerstyle>
                                                    <itemtemplate>
                                                    <%--<asp:Label ID="lblStatus" runat="server"></asp:Label>--%>
                                                        
                                                    <asp:Label ID="lblStatus" text='<%# If(DataBinder.Eval(Container.DataItem, "InUsed").ToString() = "False", "", DataBinder.Eval(Container.DataItem, "InUsed").ToString())%>' Runat="server"></asp:Label>
                                                    <asp:Label ID="lblAcquired1" text='<%# If(DataBinder.Eval(Container.DataItem, "Acquired").ToString() = "True", "", DataBinder.Eval(Container.DataItem, "Acquired").ToString())%>' Runat="server"></asp:Label>
                                                    <asp:Label ID="lblInCirculation1" text='<%# If(DataBinder.Eval(Container.DataItem, "InCirculation").ToString() = "True", "", DataBinder.Eval(Container.DataItem, "InCirculation").ToString())%>' Runat="server"></asp:Label>
                                                </itemtemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Trạng thái 1" Visible="False">
                                                    <itemtemplate>
                                                    <asp:Label ID="lblInUsed" Text='<%# DataBinder.Eval(Container.dataItem,"InUsed")%>' runat="server">
                                                    </asp:Label>
                                                </itemtemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Trạng thái 2" Visible="False">
                                                    <itemtemplate>
                                                    <asp:Label ID="lblAcquired" Text='<%# DataBinder.Eval(Container.dataItem,"Acquired")%>' runat="server">
                                                    </asp:Label>
                                                </itemtemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Trạng thái 3" Visible="False">
                                                    <itemtemplate>
                                                    <asp:Label ID="lblInCirculation" Text='<%# DataBinder.Eval(Container.dataItem,"InCirculation")%>' runat="server">
                                                    </asp:Label>
                                                </itemtemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Copy Number" Visible="False">
                                                    <itemtemplate>
                                                    <asp:Label ID="lblCopyNumber" Text='<%# DataBinder.Eval(Container.dataItem,"CopyNumber")%>' runat="server">
                                                    </asp:Label>
                                                </itemtemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <PagerTemplate>
                                                <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                            </PagerTemplate>
                                        </MasterTableView>

                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                                    </telerik:RadGrid>

                                 <%--   <asp:DataGrid ID="DgrResult" runat="server" Width="100%" AutoGenerateColumns="False" PageSize="15"
                                        AllowPaging="TRue">
                                        <Columns>
                                            <asp:TemplateColumn>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRadio" runat="server">
														<%# DataBinder.Eval(Container.dataItem,"rdoChoice")%>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn DataField="LocName" HeaderText="Kho">
                                                <HeaderStyle Width="15%"></HeaderStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Shelf" HeaderText="Giá sách">
                                                <HeaderStyle Width="5%"></HeaderStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="CallNumber" HeaderText="Số định danh">
                                                <HeaderStyle Width="15%"></HeaderStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="CopyNumber" HeaderText="Mã xếp giá">
                                                <HeaderStyle Width="15%"></HeaderStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Volume" HeaderText="Tập">
                                                <HeaderStyle Width="5%"></HeaderStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Price" HeaderText="Giá tiền">
                                                <HeaderStyle Width="15%"></HeaderStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="Note" HeaderText="Ghi chú">
                                                <HeaderStyle Width="15%"></HeaderStyle>
                                            </asp:BoundColumn>
                                            <asp:BoundColumn DataField="LoanType" HeaderText="Dạng tài liệu lưu thông">
                                                <HeaderStyle Width="10%"></HeaderStyle>
                                            </asp:BoundColumn>
                                            <asp:TemplateColumn HeaderText="Trạng thái">
                                                <HeaderStyle Width="10%"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Trạng thái 1" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInUsed" Text='<%# DataBinder.Eval(Container.dataItem,"InUsed")%>' runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Trạng thái 2" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAcquired" Text='<%# DataBinder.Eval(Container.dataItem,"Acquired")%>' runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Trạng thái 3" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblInCirculation" Text='<%# DataBinder.Eval(Container.dataItem,"InCirculation")%>' runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Copy Number" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCopyNumber" Text='<%# DataBinder.Eval(Container.dataItem,"CopyNumber")%>' runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
                                    </asp:DataGrid>--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            <tr>
                <td>
                    <table id="Table2" cellspacing="0" cellpadding="2" width="100%" border="0">
                        <tr class="lbConTRolBar">
                            <td align="right" width="10%">
                                <asp:Button ID="btnStatus" runat="server" CssClass="lbButton"></asp:Button></td>
                            <td></td>
                        </tr>
                        <tr runat="server">
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td colspan="2"></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Label ID="lblNumOfFree" runat="server" CssClass="lbLabel">* Số bản rỗi: </asp:Label><asp:Label ID="lblFreeCount" runat="server" CssClass="lbAmount"></asp:Label></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Label ID="lblPatronHistory" runat="server" CssClass="lbLabel" Visible="False">* Những người đang mượn:</asp:Label></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Table ID="tblOnLoanInfor" runat="server"></asp:Table>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFieldLabel1" runat="server" CssClass="lbLabel" Visible="False">ISBN:</asp:Label><asp:Label ID="lblFieldLabel2" runat="server" CssClass="lbLabel" Visible="False">ISSN:</asp:Label><asp:Label ID="lblFieldLabel3" runat="server" CssClass="lbLabel" Visible="False">Tác giả:</asp:Label><asp:Label ID="lblFieldLabel4" runat="server" CssClass="lbLabel" Visible="False">Tác giả tập thể:</asp:Label><asp:Label ID="lblFieldLabel5" runat="server" CssClass="lbLabel" Visible="False">Tên hội nghị:</asp:Label><asp:Label ID="lblFieldLabel6" runat="server" CssClass="lbLabel" Visible="False">Nhan đề:</asp:Label><asp:Label ID="lblFieldLabel7" runat="server" CssClass="lbLabel" Visible="False">Xuất bản:</asp:Label>
                                <asp:Label ID="lblFieldLabel8" runat="server" CssClass="lbLabel" Visible="False">Đặc điểm vật lý:</asp:Label><asp:Label ID="lblPatronCode" runat="server" CssClass="lbLabel" Visible="False">Số thẻ:</asp:Label><asp:Label ID="lblCopyNum" runat="server" CssClass="lbLabel" Visible="False">ĐCCB:</asp:Label><asp:Label ID="lblCod" runat="server" CssClass="lbLabel" Visible="False">Ngày mượn:</asp:Label><asp:Label ID="lblCid" runat="server" CssClass="lbLabel" Visible="False">Hạn trả:</asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Label ID="lblMsg" runat="server" Visible="False" CssClass="lbLabel">Không tìm thấy biểu ghi thư mục có mã tài liệu: </asp:Label>
        <asp:Label ID="lblCheckOut" runat="server" Visible="False" CssClass="lbLabel">Ghi mượn</asp:Label>
        <asp:Label ID="lblCheckIn" runat="server" Visible="False" CssClass="lbLabel">Ghi trả</asp:Label>
    <input id="hidCopyNum" type="hidden" name="hidCopyNum" runat="server"/>
    <input id="hidControl" type="hidden" name="hidControl" runat="server" value="0"/>
        <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Hiện tại không có đăng kí cá biệt nào rỗi!</asp:ListItem>
            <asp:ListItem Value="3">Hiện tại không có đăng kí cá biệt nào đang được mượn!</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script type="text/javascript">
        function onclickCopyNumber(copynumber)
        {
            if (parent.CheckOut != null)
            {
                parent.CheckOut.document.forms[0].txtCopyNumber.value = copynumber;
            }
            if (parent.CheckIn != null) {
                parent.CheckIn.document.forms[0].txtCopyNumber.value = copynumber;
            }
        }
    </script>
</body>
</html>
