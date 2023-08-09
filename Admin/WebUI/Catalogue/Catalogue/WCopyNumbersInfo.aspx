<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WCopyNumbersInfo.aspx.vb" Inherits="eMicLibAdmin.WebUI.Catalogue.WCopyNumbersInfo" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCatalogueProperty</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />   
</head>
<body leftmargin="0" topmargin="0">
    <form id="frm" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <div class="content-form">
                    <asp:Label ID="lblMainTitle1" runat="server" CssClass="main-head-form"></asp:Label>
                    <div class="input-control row-detail">
                        <div class="table-form">
                            <table cellspacing="0" cellpadding="2" width="100%" border="0">
                                <tr style="background: white none repeat scroll 0% 0%;">
                                    <td>
                                        <asp:Image ID="imgLoan" runat="server" Style="margin-right: 10px;" ImageUrl="../../Images/loan.gif"></asp:Image><asp:Label ID="lblLoan" runat="server">Đang cho mượn</asp:Label>
                                        <asp:Image ID="imgLock" runat="server" Style="margin-right: 10px;" ImageUrl="../../Images/lock.gif"></asp:Image><asp:Label ID="lblLock" runat="server">Đang khóa </asp:Label>
                                        <asp:Image ID="imgProcess" runat="server" Style="margin-right: 10px;" ImageUrl="../../Images/process.gif"></asp:Image><asp:Label ID="lblProcess" runat="server">Chưa kiểm nhận tại kho </asp:Label></td>
                                    </tr>
                                        <tr style="background: white none repeat scroll 0% 0%;">
                                            <td align="center">
                                                <asp:DataGrid ID="dtgHoldingInfo" runat="server" 
                                                    Width="100%" AllowPaging="True" 
                                                    AutoGenerateColumns="False">
                                                    <Columns>
                                                        <asp:TemplateColumn HeaderText="Thư viện">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSelectLibrary" Text='<%# DataBinder.Eval(Container.DataItem, "Code") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Kho">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSelectLocation" Text='<%# DataBinder.Eval(Container.DataItem, "Symbol") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Giá sách">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblShelfDa" Text='<%# DataBinder.Eval(Container.DataItem, "Shelf") %>' runat="server">
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Tập" Visible="False">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVolume" Text='<%# DataBinder.Eval(Container.DataItem, "Volume") %>' runat="server">
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Số phân loại">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCallNumber" Text='<%# DataBinder.Eval(Container.DataItem, "CallNumber") %>'  runat="server">
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="ĐKCB">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCopyNumber" Text='<%# DataBinder.Eval(Container.DataItem, "CopyNumber") %>' runat="server">
                                                                </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Giá tiền" ItemStyle-HorizontalAlign="Right">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPriceDa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price") %>'  />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Ngày bổ sung" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAcquiredDate" Text='<%# DataBinder.Eval(Container.DataItem, "AcquiredDate") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Nguồn bổ sung" ItemStyle-HorizontalAlign="Center">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "Source") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Ghi chú">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNote" Text='<%# DataBinder.Eval(Container.DataItem, "Note") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Mã Vạch">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBarCode" Text='<%# DataBinder.Eval(Container.DataItem, "BarCode") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Số bản">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNumberCopies" Text='<%# DataBinder.Eval(Container.DataItem, "NumberCopies") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Trạng thái">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus" Text='<%# DataBinder.Eval(Container.DataItem, "Imgs") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Tình trạng">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatusNode" Text='<%# DataBinder.Eval(Container.DataItem, "StatusNode") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:TemplateColumn HeaderText="Lý do">
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAdditionalBy" Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalBy") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                    </Columns>
                                                    <PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
                                                </asp:DataGrid>
                                            </td>
                                        </tr>
                                    </table>
                            </div>
                    </div>
                </div>
                <div id="tblTaggedContent" class="content-form" runat="server">
                    <asp:Label ID="lblMainTitle" runat="server" CssClass="main-head-form"></asp:Label>
                    <div class="input-control row-detail">
                        <div class="table-form">
                            <asp:DataGrid ID="grdProperty" CssClass="table-control" runat="server" AutoGenerateColumns="False" Width="100%">
                                <AlternatingItemStyle CssClass="lbGridAlterCell"></AlternatingItemStyle>
                                <ItemStyle CssClass="lbGridCell"></ItemStyle>
                                <HeaderStyle CssClass="lbGridHeader"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="Nh&#227;n">
                                        <HeaderStyle Width="5%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnkFieldCode" runat="server" CssClass="lbLinkFunction">
											        <%#DataBinder.Eval(Container.dataItem,"FieldCode")%>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn DataField="Ind" HeaderText="Chỉ thị">
                                        <HeaderStyle Width="15%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundColumn>
                                    <asp:BoundColumn DataField="Content" HeaderText="Nội dung trường">
                                        <HeaderStyle HorizontalAlign="Center" Width="90%"></HeaderStyle>
                                    </asp:BoundColumn>
                                </Columns>
                            </asp:DataGrid>
                        </div>
                    </div>
                </div>
            </div>
        </div>
  
        <asp:DropDownList ID="ddlLabel" Width="0px" Visible="False" runat="server">
            <asp:ListItem Value="0">Xoá bản ghi biên mục</asp:ListItem>
            <asp:ListItem Value="1">Xoá bản ghi dữ liệu căn cứ</asp:ListItem>
            <asp:ListItem Value="2">Hiển thị bản ghi</asp:ListItem>
            <asp:ListItem Value="3">Xem bản ghi dữ liệu biên mục</asp:ListItem>
            <asp:ListItem Value="4">Xem bản ghi dữ liệu xếp giá</asp:ListItem>
            <asp:ListItem Value="5">Không thể xoá bản ghi dữ liệu biên mục vì vẫn tồn tại mã xếp giá</asp:ListItem>
            <asp:ListItem Value="6">Đóng</asp:ListItem>
            <asp:ListItem Value="7">Xoá</asp:ListItem>
            <asp:ListItem Value="8">Sửa</asp:ListItem>
            <asp:ListItem Value="9">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="10">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="11">Xoá bản ghi dữ liệu biên mục (1 bản ghi)</asp:ListItem>
            <asp:ListItem Value="12">Xoá bản ghi dữ liệu căn cứ (1 bản ghi)</asp:ListItem>
            <asp:ListItem Value="13">Xoá bản ghi thành công!</asp:ListItem>
            <asp:ListItem Value="14">Bạn có muốn xóa bản ghi biên mục này không?</asp:ListItem>
            <asp:ListItem Value="15">Hủy</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
