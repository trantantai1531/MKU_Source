 <%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WPolicyManagement" CodeFile="WPolicyManagement.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI, Version=2013.2.611.40, Culture=neutral, PublicKeyToken=121fae78165ba3d4" %>
<%@ Register TagPrefix="gusc" TagName="RadGridPagerUSC" Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WPolicyManagement</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/assert/setlogmod.css" rel="stylesheet" />
    <link href="../../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" href="../../Scripts/chosen/docsupport/style.css">
    <link rel="stylesheet" href="../../Scripts/chosen/docsupport/prism.css">
    <link rel="stylesheet" href="../../Scripts/chosen/chosen.css">
</head>
<body topmargin="0" leftmargin="0">
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
        <div id="divBody">
            <h1 class="main-head-form">Chính sách lưu thông</h1>
            <div class="main-form">
            <div class="three-column ClearFix">
                <div class="three-column-form">
                    <div class="row-detail">
                        <p>Dạng tài liệu :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtNewLoanType" runat="server"  MaxLength="100" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail" style="display:none">
                        <p>Thời gian mượn :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtNewLoanPeriod" runat="server"  MaxLength="3" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Thời gian gia hạn :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtNewRenewalPeriod" runat="server"  MaxLength="3" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                     <div class="row-detail">
                        <p>Mã :</p>
                        <div class="input-control">
                            <div class="input-form">
                                <asp:TextBox CssClass="text-input" ID="txtLoanTypeCode" runat="server"  MaxLength="10" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail" style="display:none">
                        <p>Đơn vị thời gian :</p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlNewTimeUnit" runat="server" Width="100%"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="three-column-form">
                    <div class="row-detail">
                        <p>Phí mượn :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtNewFee" runat="server"  MaxLength="10" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Số lượt gia hạn :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtNewRenewals" runat="server"  MaxLength="3" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%--<div class="row-detail">
                        <p>Thời gian gia hạn :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtNewRenewalPeriod" runat="server"  MaxLength="3" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>--%>
                    
                    <div class="row-detail" style="display:none">
                        <p>Nhóm bạn đọc:</p>
                        <div>
                            <select id="selectGroups" runat="server"   class="chosen-select" multiple="True" style="width: 100% !important" data-placeholder="Chọn một hoặc nhiều nhóm...">
                            </select>
                        </div>
                    </div>
                </div>

                <div class="three-column-form">
                    <div class="row-detail">
                        <p>Phí quá hạn đơn vị thời gian :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox CssClass="text-input" ID="txtNewOverdueFine" runat="server"  MaxLength="10" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Chọn :</p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlNewFixedFee" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                   <%-- <div class="row-detail">
                        <p>Mã :</p>
                        <div class="input-control">
                            <div class="input-form">
                                <asp:TextBox CssClass="text-input" ID="txtLoanTypeCode" runat="server"  MaxLength="10" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                    </div>--%>
                    <div class="row-detail" style="text-align:left;">
                        <div>&nbsp</div>
                        <div class="button-control">
                            <div class="button-form">                                 
                                <asp:Button ID="btnNew" runat="server" Text="Tạo mới" Width="100%"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="input-control row-detail">
                <div class="table-form">
                    
                        <telerik:RadGrid ID="dtgPolicy" runat="server" AllowPaging="True"
                                CellSpacing="0"
                                AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None" OnNeedDataSource="dtgPolicy_NeedDataSource">
                                <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                    <PagerStyle AlwaysVisible="True" />
                                    <FooterStyle BackColor="White"></FooterStyle>

                                    <Columns>
                                        <telerik:GridTemplateColumn Display="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMark" Text='<%# DataBinder.Eval(Container.dataItem, "Mark") %>' runat="server">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn Display="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem, "ID") %>' runat="server">
                                                </asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>                                        
                                        <telerik:GridTemplateColumn HeaderText="Dạng tài liệu">
                                            <HeaderStyle Width="20%"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblLoanType" Text='<%# DataBinder.Eval(Container.DataItem, "strLoanTypeView") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox CssClass="text-input" Width="100%" MaxLength="100"  runat="server" ID="txtLoanType" Text='<%# DataBinder.Eval(Container.DataItem, "LoanType") %>' />
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Mã">
                                            <HeaderStyle Width="7%"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblLoanTypeCode" Text='<%# DataBinder.Eval(Container.DataItem, "LoanTypeCode") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox CssClass="text-input" Width="130px" MaxLength="100"  runat="server" ID="txtLoanTypeCode" Text='<%# DataBinder.Eval(Container.DataItem, "LoanTypeCode") %>' />
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>                                     
                                        <telerik:GridTemplateColumn HeaderText="Thời gian mượn" ItemStyle-HorizontalAlign="Right" Visible="false">
                                            <HeaderStyle Width="7%"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblLoanPeriod" Text='<%# DataBinder.Eval(Container.DataItem, "LoanPeriod") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox CssClass="text-input" Width="50px" MaxLength="3"  runat="server" ID="txtLoanPeriod" Text='<%# DataBinder.Eval(Container.DataItem, "LoanPeriod") %>' />
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Đơn vị thời gian" Visible="false">
                                            <HeaderStyle Width="7%"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTimeUnit" Text='<%# DataBinder.Eval(Container.DataItem, "strTimeUnit") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox CssClass="text-input" runat="server" ID="txtSelectTimeUnit" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "TimeUnit") %>' />
                                                <asp:DropDownList ID="ddlSelectTimeUnit" runat="server" />
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Số lượt gia hạn" ItemStyle-HorizontalAlign="Right">
                                            <HeaderStyle Width="7%"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRenewals" Text='<%# DataBinder.Eval(Container.DataItem, "Renewals") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox CssClass="text-input" Width="50px" MaxLength="3"  runat="server" ID="txtRenewals" Text='<%# DataBinder.Eval(Container.DataItem, "Renewals") %>' />
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Thời gian gia hạn" ItemStyle-HorizontalAlign="Right">
                                            <HeaderStyle Width="8%"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblRenewalPeriod" Text='<%# DataBinder.Eval(Container.DataItem, "RenewalPeriod") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox CssClass="text-input" Width="50px" MaxLength="3"  runat="server" ID="txtRenewalPeriod" Text='<%# DataBinder.Eval(Container.DataItem, "RenewalPeriod") %>' />
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Phí quá hạn / đ.vị thời gian" ItemStyle-HorizontalAlign="Right">
                                            <HeaderStyle Width="10%"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblOverdueFine" Text='<%# DataBinder.Eval(Container.DataItem, "OverdueFine") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox CssClass="text-input" Width="100px" MaxLength="10"  runat="server" ID="txtOverdueFine" Text='<%# DataBinder.Eval(Container.DataItem, "OverdueFine") %>' />
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Phí mượn" ItemStyle-HorizontalAlign="Right">
                                            <HeaderStyle Width="8%"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblFee" Text='<%# DataBinder.Eval(Container.DataItem, "Fee") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox CssClass="text-input" Width="70px" MaxLength="10"  runat="server" ID="txtFee" Text='<%# DataBinder.Eval(Container.DataItem, "Fee") %>' />
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Cố định/ theo thời gian">
                                            <HeaderStyle Width="10%"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblFixFee" Text='<%# DataBinder.Eval(Container.DataItem, "strFixedFee") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox CssClass="text-input" runat="server" ID="txtSelectFixedFee" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "FixedFee") %>' />
                                                <asp:DropDownList ID="ddlFixedFee" runat="server" />
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="Nhóm bạn đọc">
                                            <HeaderStyle ></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblGroupsName" Text='<%# DataBinder.Eval(Container.DataItem, "GroupsName") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox  runat="server" ID="txtGroupsName" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "GroupIDs") %>' />
                                                <select id="ReSelectGroups" runat="server"   class="chosen-select" multiple="True" style="width: 100% !important" data-placeholder="Chọn một hoặc nhiều nhóm...">
                                                </select>
                                            </EditItemTemplate>
                                            
                                        </telerik:GridTemplateColumn>                                        
                                        <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="Chọn" ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkCopyID" runat="server"></asp:CheckBox>
                                                <label for="chkCopyID"></label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridEditCommandColumn HeaderText="Sửa" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ButtonType="LinkButton"
                                            UpdateText="&lt;img src=&quot;../../images/update.gif&quot; border=&quot;0&quot;&gt;" CancelText="&lt;img src=&quot;../../images/cancel.gif&quot; border=&quot;0&quot;&gt;"
                                            EditText="&lt;img src=&quot;../../images/Edit2.gif&quot; border=&quot;0&quot;&gt;"></telerik:GridEditCommandColumn>
                                    </Columns>
                                    <PagerTemplate>
                                        <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                    </PagerTemplate>
                                </MasterTableView>

                                <PagerStyle PageSizeControlType="RadComboBox" ></PagerStyle>


                            </telerik:RadGrid>

                  <%--  <asp:DataGrid CssClass="table-control" ID="dtgPolicy" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
                        <Columns>
                            <asp:TemplateColumn Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblMark" Text='<%# DataBinder.Eval(Container.dataItem,"Mark") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Dạng tài liệu">
                                <ItemTemplate>
                                    <asp:Label ID="lblLoanType" Text='<%# DataBinder.Eval(Container.DataItem, "strLoanTypeView") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" Width="130px" MaxLength="100"  runat="server" ID="txtLoanType" Text='<%# DataBinder.Eval(Container.DataItem, "LoanType") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Thời gian mượn" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Width="8%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblLoanPeriod" Text='<%# DataBinder.Eval(Container.DataItem, "LoanPeriod") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" Width="50px" MaxLength="3"  runat="server" ID="txtLoanPeriod" Text='<%# DataBinder.Eval(Container.DataItem, "LoanPeriod") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Đơn vị thời gian">
                                <HeaderStyle Width="8%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblTimeUnit" Text='<%# DataBinder.Eval(Container.DataItem, "strTimeUnit") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" runat="server" ID="txtSelectTimeUnit" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "TimeUnit") %>' />
                                    <asp:DropDownList ID="ddlSelectTimeUnit" runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Số lượt gia hạn" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Width="7%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblRenewals" Text='<%# DataBinder.Eval(Container.DataItem, "Renewals") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" Width="50px" MaxLength="3"  runat="server" ID="txtRenewals" Text='<%# DataBinder.Eval(Container.DataItem, "Renewals") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Thời gian gia hạn" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Width="9%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblRenewalPeriod" Text='<%# DataBinder.Eval(Container.DataItem, "RenewalPeriod") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" Width="50px" MaxLength="3"  runat="server" ID="txtRenewalPeriod" Text='<%# DataBinder.Eval(Container.DataItem, "RenewalPeriod") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Phí quá hạn / đ.vị thời gian" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblOverdueFine" Text='<%# DataBinder.Eval(Container.DataItem, "OverdueFine") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" Width="100px" MaxLength="10"  runat="server" ID="txtOverdueFine" Text='<%# DataBinder.Eval(Container.DataItem, "OverdueFine") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Phí mượn" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblFee" Text='<%# DataBinder.Eval(Container.DataItem, "Fee") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" Width="70px" MaxLength="10"  runat="server" ID="txtFee" Text='<%# DataBinder.Eval(Container.DataItem, "Fee") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Cố định/ theo thời gian">
                                <HeaderStyle Width="13%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblFixFee" Text='<%# DataBinder.Eval(Container.DataItem, "strFixedFee") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" runat="server" ID="txtSelectFixedFee" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "FixedFee") %>' />
                                    <asp:DropDownList ID="ddlFixedFee" runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderText="Chọn" ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkCopyID" runat="server"></asp:CheckBox>
                                    <label for="chkCopyID"></label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:EditCommandColumn HeaderText="Sửa" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ButtonType="LinkButton"
                                UpdateText="&lt;img src=&quot;../../images/update.gif&quot; border=&quot;0&quot;&gt;" CancelText="&lt;img src=&quot;../../images/cancel.gif&quot; border=&quot;0&quot;&gt;"
                                EditText="&lt;img src=&quot;../../images/Edit2.gif&quot; border=&quot;0&quot;&gt;"></asp:EditCommandColumn>
                        </Columns>
                        <PagerStyle Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>--%>
                </div>
            </div>

            <div class="row-detail">
                <div class="input-control inline-box">
                    <div class="dropdown-form">
                        <asp:dropdownlist id="ddlLoanTypeGroup" runat="server"></asp:dropdownlist>
                    </div>
                    <div class="button-control">
                        <div class="button-form">
                           <asp:button id="btnGroup" runat="server" Text="Gộp(m)" Width=""></asp:button>
                        </div>
                    </div>
                </div>
            </div>
                </div>
        </div>
        <asp:Label ID="lblLabel1" runat="server" Visible="False">Ngày|Giờ</asp:Label>
        <asp:Label ID="lblLabel2" runat="server" Visible="False">Cố định|Theo thời gian</asp:Label>
        <input type="hidden" id="HidenListGroups"  runat="server" />
        <input type="hidden" id="Hidden1"  runat="server" />
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
    <script src="../../Scripts/chosen/docsupport/jquery-3.2.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/chosen/chosen.jquery.js" type="text/javascript"></script>
    <script src="../../Scripts/chosen/docsupport/prism.js" type="text/javascript" charset="utf-8"></script>
    <script src="../../Scripts/chosen/docsupport/init.js" type="text/javascript" charset="utf-8"></script>
    </form>
    <script type="text/javascript"  language="javascript">
        $('#selectGroups').change(function () {
            var listGroups = "";
            $('#selectGroups :selected').each(function () {
                listGroups += "," + $(this).val();
            });           
            if (listGroups.length > 0) {
                listGroups = listGroups.substring(1,listGroups.length)
            }
            $("#HidenListGroups").val(listGroups);  
        });

      
        document.forms[0].txtNewLoanType.focus();
    </script>
</body>
</html>
