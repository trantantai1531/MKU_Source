<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Admin.WIndexUser" CodeFile="WIndexUser.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" TagPrefix="gusc" TagName="RadGridPagerUSC" %>
<%@ Register Src="~/Telerik/RadGrid/RadGridPagerUSC.ascx" TagPrefix="gusca" TagName="RadGridPagerUSC1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WIndexUser</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../Resources/Controls/GridView.css" rel="stylesheet" />
    <link href="../Telerik/RadGrid/RadGrid.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" onload="document.forms[0].txtFullName.focus();">
    <form id="Form1" method="post" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="dtgEvents">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="dtgEvents" />
                    </UpdatedControls>
                </telerik:AjaxSetting>

            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        </telerik:RadScriptBlock>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            <Scripts>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
            </Scripts>
        </telerik:RadScriptManager>
        <div id="divBody">
            <div class="main-body">
                <div class="content-form">
                    <div class="main-form">

                        <div class="col-left-3">
                            <h1 class="main-group-form">NGƯỜI DÙNG HIỆN THỜI</h1>
                            <p style="display: none" id="lblNote2" runat="server">Bấm vào đường link để đặt lại quyền cho người dùng tương ứng </p>
                            <asp:HyperLink ID="lnkPersonal" Style="display: none" runat="server" CssClass="lbLinkFunction">Thay đổi thông tin cá nhân</asp:HyperLink>
                            <div class="input-control">
                                <div class="table-form">
                                    <%--   <asp:hyperlink id="Hyperlink1" runat="server" CssClass="lbLinkFunction">Thay đổi thông tin cá nhân</asp:hyperlink><br>--%>
                                    <%-- <asp:DataGrid ID="dgtUser" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True"
                                        PageSize="15">
                                        <Columns>
                                            <asp:TemplateColumn>
                                                <HeaderStyle Width="5%"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                <HeaderTemplate>
                                                    <input class="lbCheckBox" type="checkbox" id="CheckAll" onclick="javascript: CheckAllOptionsVisible('dgtUser', 'chkID', 3, 15);">
                                                </HeaderTemplate>
                                                <ItemTemplate>

                                                    <asp:CheckBox ID="chkID" runat="server"></asp:CheckBox>
                                                    <label for="chkID">
                                                    </label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Tài khoản người dùng">
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" ID="lnkUser" CssClass="lbLinkFunction">
															<%#DataBinder.Eval(Container.DataItem, "UserName")%>
                                                    </asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn Visible="False">
                                                <HeaderStyle Width="300px"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
                                    </asp:DataGrid>--%>



                                    <%--                                    <telerik:RadGrid ID="dgtUser" runat="server" AllowPaging="false"
                                        CellSpacing="0"
                                        AutoGenerateColumns="False" Skin="Office2010Black" AllowMultiRowSelection="True" GridLines="None">

                                        <MasterTableView TableLayout="Auto" DataKeyNames="Event"
                                            ClientDataKeyNames="Event" EditMode="InPlace">

                                            <PagerStyle AlwaysVisible="True" />
                                            <Columns>
                                                <telerik:GridTemplateColumn UniqueName="checkAll" HeaderText="Template Column" Visible="True">
                                                    <HeaderStyle Width="5%" />
                                                    <HeaderTemplate>
                                                        <input class="lbCheckBox" type="checkbox" id="chkCheckAll" onclick="javascript: CheckAllOptionsVisibleByCssClass('ckb-value', 'chkID', 2, 50);">
                                                        <label for="c1"></label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <input id="chkID" type="checkbox" class="ckb-value" runat="server">
                                                        <label for="c2"></label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Tài khoản người dùng">
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" ID="lnkUser" CssClass="lbLinkFunction">
															<%#DataBinder.Eval(Container.DataItem, "UserName")%>
                                                        </asp:HyperLink>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn Visible="False">
                                                    <HeaderStyle Width="300px"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                            </Columns>
                                          
                                        </MasterTableView>

                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                                    </telerik:RadGrid>--%>



                                    <telerik:RadGrid ID="dgtUser" runat="server" AllowPaging="False"
                                        CellSpacing="0"
                                        AutoGenerateColumns="False" Skin="Office2010Black" GridLines="None">
                                        <MasterTableView TableLayout="Auto" DataKeyNames="ID" EditMode="InPlace">
                                            <PagerStyle AlwaysVisible="True" />
                                            <FooterStyle BackColor="White"></FooterStyle>

                                            <Columns>
                                                <telerik:GridTemplateColumn UniqueName="cbCheckAll" HeaderText="Template Column" Visible="True">
                                                    <HeaderStyle Width="5%" />
                                                    <HeaderTemplate>
                                                        <input class="lbCheckBox" type="checkbox" id="chkCheckAll" onclick="javascript: CheckAllOptionsVisibleByCssClass('ckb-value', 'chkID', 2, 50);">
                                                        <label for="c1"></label>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <input id="chkID" type="checkbox" class="ckb-value" runat="server">
                                                        <label for="c2"></label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="Tài khoản người dùng">
                                                    <ItemTemplate>
                                                        <asp:HyperLink runat="server" ID="lnkUser" CssClass="lbLinkFunction">
															<%#DataBinder.Eval(Container.DataItem, "UserName")%>
                                                        </asp:HyperLink>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn Visible="False">
                                                    <HeaderStyle Width="300px"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                                        </asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <PagerTemplate>
                                                <gusc:RadGridPagerUSC runat="server" ID="RadGridPagerUSC" ClientIDMode="Static" />
                                            </PagerTemplate>
                                        </MasterTableView>

                                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>


                                    </telerik:RadGrid>




                                </div>
                            </div>
                            <div class="row-detail">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnDelete" CssClass="form-btn" runat="server" Text="Xoá(d)"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-right-7 userinfo">
                            <h1 class="main-group-form">THÔNG TIN CHI TIẾT</h1>
                            <asp:Label Style="display: none" ID="lblNote" runat="server">* Khi cập nhật tài khoản, chỉ nhập mật khẩu khi muốn thay đổi mật khẩu cũ</asp:Label>
                            <div class="two-column ClearFix">
                                <div class="two-column-form">
                                    <div id="TRLDAP" runat="server">
                                        <asp:HyperLink ID="lnkLoadLDAP" runat="server" CssClass="lbLinkFunction">Nạp từ LDAP</asp:HyperLink>
                                    </div>
                                    <div class="row-detail">
                                        <asp:Label ID="lblUserName" runat="server"><u>T</u>ên đăng nhập:</asp:Label><span class="error-star">(*)</span>
                                        <div class="input-control ">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txtUserName" CssClass="text-input" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <asp:Label ID="lblFullName" runat="server"><u>H</u>ọ tên:</asp:Label><span class="error-star">(*)</span>
                                        <div class="input-control ">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txtFullName" CssClass="text-input" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row-detail">
                                        <asp:Label ID="lblPassword" runat="server"><u>M</u>ật khẩu:</asp:Label><span class="error-star">(*)</span>
                                        <div class="input-control ">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txtPassword" CssClass="text-input" runat="server" TextMode="Password">*****</asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <asp:Label ID="lblReTypePass" runat="server"><u>G</u>õ lại mật khẩu:</asp:Label><span class="error-star">(*)</span>
                                        <div class="input-control ">
                                            <div class="input-form ">
                                                <asp:TextBox ID="txtRetypePass" runat="server" TextMode="Password">*****</asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div class="two-column-form">
                                    <div class="row-detail">
                                        <asp:Label ID="lblCatalogue" runat="server"><u>B</u>iên mục:</asp:Label><asp:HyperLink ID="lnkCatalogue" runat="server" CssClass="lbLinkFunction">(Các quyền)</asp:HyperLink>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlCatalogue" runat="server">
                                                    <asp:ListItem Value="0">0 - Không phân quyền</asp:ListItem>
                                                    <asp:ListItem Value="1">1 - Phân quyền</asp:ListItem>
                                                    <asp:ListItem Value="2">2 - Toàn quyền dữ liệu</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <asp:Label ID="lblPatron" runat="server">Bạn <u>đ</u>ọc:</asp:Label><asp:HyperLink ID="lnkPatron" runat="server" CssClass="lbLinkFunction">(Các quyền)</asp:HyperLink>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlPatron" runat="server">
                                                    <asp:ListItem Value="0">0 - Không phân quyền</asp:ListItem>
                                                    <asp:ListItem Value="1">1 - Phân quyền</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <asp:Label ID="lblCirculation" runat="server">Mượ<u>n</u> Trả:</asp:Label><asp:HyperLink ID="lnkCirculation" runat="server" CssClass="lbLinkFunction">(Các quyền)</asp:HyperLink>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlCirculation" runat="server">
                                                    <asp:ListItem Value="0">0 - Không phân quyền</asp:ListItem>
                                                    <asp:ListItem Value="1">1 - Phân quyền</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <asp:Label ID="lblAcq" runat="server">Bổ <u>s</u>ung:</asp:Label><asp:HyperLink ID="lnkAcq" runat="server" CssClass="lbLinkFunction">(Các quyền)</asp:HyperLink>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlAcq" runat="server">
                                                    <asp:ListItem Value="0">0 - Không phân quyền</asp:ListItem>
                                                    <asp:ListItem Value="1">1 - Phân quyền</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <asp:Label ID="lblSerial" runat="server">Ấn phẩm định <u>k</u>ỳ:</asp:Label><asp:HyperLink ID="lnkSerial" runat="server" CssClass="lbLinkFunction">(Các quyền)</asp:HyperLink>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlSerial" runat="server">
                                                    <asp:ListItem Value="0">0 - Không phân quyền</asp:ListItem>
                                                    <asp:ListItem Value="1">1 - Phân quyền</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail" style="display: none">
                                        <asp:Label ID="lblILL" runat="server"><u>I</u>LL:</asp:Label><asp:HyperLink ID="lnkILL" runat="server" CssClass="lbLinkFunction">(Các quyền)</asp:HyperLink>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlILL" runat="server">
                                                    <asp:ListItem Value="0">0 - Không phân quyền</asp:ListItem>
                                                    <asp:ListItem Value="1">1 - Phân quyền</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <asp:Label ID="lblEdeliv" runat="server"><u>T</u>ư liệu số :</asp:Label>
                                        <asp:HyperLink ID="lnkEdeliv" runat="server" Style="display: none" CssClass="lbLinkFunction">(Các quyền) </asp:HyperLink>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlEdeliv" runat="server">
                                                    <asp:ListItem Value="0">0 - Không phân quyền</asp:ListItem>
                                                    <asp:ListItem Value="1">1 - Phân quyền</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail" id="TRAdmin" runat="server">
                                        <asp:Label ID="lblAdmin" runat="server">Qu<u>ả</u>n trị</asp:Label><asp:HyperLink ID="lnkAdmin" runat="server" CssClass="lbLinkFunction">(Các quyền)</asp:HyperLink>
                                        <div class="input-control">
                                            <div class="dropdown-form">
                                                <asp:DropDownList ID="ddlAdmin" runat="server">
                                                    <asp:ListItem Value="0">0 - Không phân quyền</asp:ListItem>
                                                    <asp:ListItem Value="1">1 - Phân quyền</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-detail">
                                        <div class="button-control">
                                            <div class="button-form">

                                                <asp:Button ID="btnAdd" CssClass="form-btn" runat="server" Text="Lưu(s)"></asp:Button>
                                            </div>
                                            <div class="button-form">
                                                <asp:Button ID="btnReset" CssClass="form-btn" runat="server" Text="Tạo mới(c)"></asp:Button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <input id="hidUpdate" type="hidden" value="0" runat="server" size="1" name="hidUpdate" />
        <input id="hidUserID" type="hidden" value="0" runat="server" size="1" name="hidUserID" />
        <input id="hidParentID" type="hidden" value="1" runat="server" size="1" name="hidParentID" />
        <input id="hidParentIDTemp" type="hidden" value="1" runat="server" size="1" name="hidParentIDTemp" />
        <input id="hidRights" type="hidden" size="1" runat="server" name="hidRights" />
        <input id="hidCirRights" type="hidden" runat="server" size="1" name="hidCirRights" />
        <input id="hidAcqRights" type="hidden" runat="server" size="1" name="hidAcqRights" />
        <input id="hidSerRights" type="hidden" runat="server" size="1" name="hidSerRights" />
        <input id="hidAdmRights" type="hidden" runat="server" size="1" name="hidAdmRights" />
        <input id="hidLDAPAdsPath" type="hidden" runat="server" size="1" name="hidLDAPAdsPath" />
        <asp:DropDownList runat="server" ID="ddlLabel" Width="0" Height="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="2">Các trường không được bỏ trống</asp:ListItem>
            <asp:ListItem Value="3">Họ tên và tên đăng nhập không được bỏ trống</asp:ListItem>
            <asp:ListItem Value="4">Giá trị mật khẩu không khớp</asp:ListItem>
            <asp:ListItem Value="5">Tên đăng nhập đã tồn tại!</asp:ListItem>
            <asp:ListItem Value="6">Bạn có muốn xoá người dùng đã chọn không?</asp:ListItem>
            <asp:ListItem Value="7">Xoá bản ghi thành công!</asp:ListItem>
            <asp:ListItem Value="8">Bạn phải chọn ít nhất một bản ghi trước khi xoá!</asp:ListItem>
            <asp:ListItem Value="9">Tạo mới tài khoản người dùng</asp:ListItem>
            <asp:ListItem Value="10">Cập nhật tài khoản người dùng</asp:ListItem>
            <asp:ListItem Value="11">Bạn có muốn cập nhật tài khoản (Cắt quyền quản trị của Admin cấp 2 đang quản lý tài khoản này) không? Bấm OK để thực hiện!</asp:ListItem>
            <asp:ListItem Value="12">Xoá tài khoản người dùng</asp:ListItem>
            <asp:ListItem Value="13">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
            <asp:ListItem Value="14">Cập nhật thành công!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
