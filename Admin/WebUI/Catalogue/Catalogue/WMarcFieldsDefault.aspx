<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WMarcFieldsDefault" CodeFile="WMarcFieldsDefault.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Đặt giá trị ngầm định</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="2" topmargin="0">
    <form id="frm" method="post" runat="server">
        <div id="divBody">
            <div class="row-detail">
                <h1 class="main-head-form">Đặt giá trị ngầm định</h1>
                <h1 class="main-group-form">Nhập nhãn trường và giá trị tương ứng cho nhãn trường đó.</h1>
                <div class="two-column">
                    <div class="two-column-form">
                        <div class="ClearFix"></div>
                        <div class="span8">
                            <p>Tên trường:</p>
                            <div class="pad5">
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtFieldName" runat="server" Width="304px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="ClearFix"></div>
                        <p style="display:block;">
                        <asp:HyperLink ID="lnkLabel" runat="server" >Nhãn</asp:HyperLink>
                            </p>
                        <div class="span1">
                            <div class="pad5">
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtFieldCode" runat="server" Width="47px" MaxLength="3"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="span3">
                            <div class="pad5">
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtIndicator" runat="server" Width="76px" MaxLength="2"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="span4">
                            <div class="pad5">
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input" ID="txtFieldValue" runat="server" Width="171px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="ClearFix"></div>
                        <div class="row-detail">
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button CssClass="form-btn" ID="btnUpdate" runat="server" Text="Nhập(u)"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="two-column-form">
                    <asp:Label ID="lblTitle5" runat="server" CssClass="lbGroupTitle" Visible="False">Danh sách giá trị ngầm định đã lập</asp:Label>
                    <div class="table-form">
                        <asp:DataGrid ID="grdDefault" CssClass="table-control" runat="server" Width="47%" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn Visible="False" DataField="ID" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="Indicator" ReadOnly="True" HeaderText="Indicator"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="FieldValue" ReadOnly="True" HeaderText="FieldValue"></asp:BoundColumn>
                                <asp:BoundColumn DataField="FieldCode" ReadOnly="True" HeaderText="Nhãn trường" HeaderStyle-HorizontalAlign="Center"
                                    ItemStyle-HorizontalAlign="Center" ItemStyle-Width="13%"></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Chỉ thị">
                                    <HeaderStyle Width="10%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Indicator") %>' ID="lblIndicator">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="text-input" ID="txtdtgIndicator" runat="server" Width="100px" Text='<%# DataBinder.Eval(Container, "DataItem.Indicator") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Giá trị">
                                    <HeaderStyle Width="50%"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FieldValue") %>' ID="Label4">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox CssClass="text-input" ID="txtdtgFieldValue" runat="server" TextMode="MultiLine" Width="400px" Text='<%# DataBinder.Eval(Container, "DataItem.FieldValue") %>'>
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="<IMG SRC='../images/Update.gif' title='Sửa' border='0'>"
                                    CancelText="<IMG SRC='../images/Cancel.gif' title='Thôi' border='0'>" EditText="<IMG SRC='../images/Edit.gif' title='Soạn thảo' border='0'>"
                                    HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%"></asp:EditCommandColumn>
                                <asp:ButtonColumn Text="<IMG SRC='../images/Delete.gif' title='Xoá' border='0'>" CommandName="Delete"
                                    HeaderText="Xoá" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%"></asp:ButtonColumn>
                            </Columns>
                            <PagerStyle CssClass="lbGridPager"></PagerStyle>
                        </asp:DataGrid>
                    </div>

                </div>
            </div>


        </div>
        <input id="hidID" type="hidden" runat="server">
        <input id="hidError" type="hidden" runat="server" name="hidError" value="0">
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="1">Chỉ thị dữ liệu thứ nhất không hợp lệ</asp:ListItem>
            <asp:ListItem Value="2">Chỉ thị dữ liệu thứ hai không hợp lệ</asp:ListItem>
            <asp:ListItem Value="3">Cả hai chỉ thị dữ liệu không hợp lệ</asp:ListItem>
            <asp:ListItem Value="4">Bạn chưa nhập đủ thông tin</asp:ListItem>
            <asp:ListItem Value="5">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="6">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="7">Không tồn tại</asp:ListItem>
            <asp:ListItem Value="8">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
            <asp:ListItem Value="9">Cập nhật dữ liệu thành công!</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtFieldCode.focus();
    </script>
</body>
</html>
