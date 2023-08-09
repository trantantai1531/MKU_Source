<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WViewLiq" CodeFile="WViewLiq.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html >
<head>
    <title>Xem kết quả kiểm kê</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style>
        .lbButton {
            margin-left: 5px;
            margin-right: 5px;
   
        }
        #tblFormInventory div {
            margin-top: 10px;
        }
    </style>
    
    <script type="text/javascript">
       $(document).ready(function () {
            $('[id*=chkCheckAll]').click(function () {
                $("[id*='cbkOption']").attr('checked', this.checked);
            });
        });
    </script>
</head>
<body leftmargin="0" topmargin="0" >
    <form id="Form1" method="post" runat="server">
        <div id="divBody" >
            <div id="tblFormInventory" class="main-body">
                <asp:Label ID="lblTitleForm" Width="100%" CssClass="main-group-form" runat="server">Kết quả kiểm kê</asp:Label>
                <%--<input type="checkbox"  id="chk1" class="inline-box" value="abc"/>--%>
                <div>
                    <asp:Label ID="lblInventory" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblTypeInventory" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:DataGrid ID="dtgInventoryLost" runat="server" Width="100%" HeaderStyle-HorizontalAlign="Center"
                        AllowPaging="True" AutoGenerateColumns="False">
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <Columns>
                            <asp:BoundColumn DataField="IDRESERVE" ReadOnly="True" HeaderText="STT"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Nhan đề">
                                <HeaderStyle Width="55%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>' ID="lbldtgContent">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ĐKCB">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Copynumber") %>' ID="lbldtgCopynumber">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Số định danh">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CallNumber") %>' ID="Label1">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="L&#253; do">
                                <HeaderStyle Width="15%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Reason") %> ' ID="Label2">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Chọn" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                <HeaderTemplate >
                                    <asp:CheckBox runat="server" CssClass="lbCheckBox" ID="chkCheckAll" Text="&nbsp;"/>
                                  <%--<input class="lbCheckBox" type="checkbox" id="chkCheckAll" onclick="javascript: CheckAllOptionsVisible_1('dtgInventoryLost', 'cbkOption', 3, 10);">--%>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbkOption" runat="server" ></asp:CheckBox>
                                    <label for="cbkOption"></label>   
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" ForeColor="White" />

                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                    <div>
                         <asp:Label ID="lblNote" runat="server"><u>L</u>ý do thiếu: </asp:Label><asp:DropDownList ID="ddlNote" runat="server">
                        <asp:ListItem Value="0">Mất</asp:ListItem>
                        <asp:ListItem Value="1">Xếp nhầm chỗ</asp:ListItem>
                        <asp:ListItem Value="2">Xuất kho</asp:ListItem>
                        <asp:ListItem Value="3">Tạm xuất</asp:ListItem>
                        <asp:ListItem Value="4">Không rõ</asp:ListItem>
                    </asp:DropDownList><asp:Button ID="btnUpdateNote" Width="120px" runat="server" Text="Cập nhật lý do(c)"></asp:Button>
                        <asp:Button ID="btnDelete" Width="120px" runat="server" Text="Xoá khỏi kho(x)"></asp:Button><asp:Button ID="btnSucessInt" Width="120px" runat="server" Text="Đã kiểm kê đủ(k)"></asp:Button>
                    </div>
                    <div>
                           <asp:DataGrid ID="dtgInventoryFalsePath" runat="server" HeaderStyle-HorizontalAlign="Center" AllowPaging="True"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundColumn DataField="IDRESERVE" ReadOnly="True" HeaderText="STT" FooterStyle-Width="5%" FooterStyle-HorizontalAlign="Right"
                                HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Nhan đề">
                                <HeaderStyle HorizontalAlign="Left" Width="35%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>' ID="lblLabel3">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ĐKCB">
                                <HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Copynumber") %>' ID="lblLabel4">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Số định danh">
                                <HeaderStyle HorizontalAlign="Left" Width="12%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CallNumber") %>' ID="Label5">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Vị trí kiểm kê">
                                <HeaderStyle HorizontalAlign="Left" Width="17%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.INPATHS") %>' ID="Label6">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Vị trí đúng">
                                <HeaderStyle HorizontalAlign="Left" Width="17%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TRUEPATHS") %>' ID="Label7">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Chọn" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="5%"></HeaderStyle>
                                <HeaderTemplate>
                                    <input class="lbCheckBox" type="checkbox" id="CheckAll" onclick="javascript: CheckAllOptionsVisible('dtgInventoryFalsePath', 'cbkOption1', 3, 10);">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbkOption1" runat="server"></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                        <div>  <asp:Button ID="btnDelete1" Width="54px" runat="server" Text="Xoá(o)"></asp:Button></div>
                    </div>
                    <div> <asp:Button ID="btnResultLost" Width="170px" runat="server" Text="Đăng ký cá biệt thiếu(k)"></asp:Button><asp:Button ID="btnResultFalse" Width="178px" runat="server" Text="Đăng ký cá biệt sai chỗ(t)"></asp:Button></div>
                    <div class="lbLinkfunction">
                        <asp:LinkButton ID="lnkCopynumbers" runat="server"></asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <input id="hidLoc" type="hidden" name="hidLoc" runat="server">
        <input id="hidLib" type="hidden" name="hidLib" runat="server">
        <input id="hidInt" type="hidden" name="hidInt" runat="server">
        <input id="hidShelf" type="hidden" name="hidShelf" runat="server">
        <input id="hidType" type="hidden" name="hidType" runat="server">
        <asp:DropDownList ID="ddlLabel" Width="0px" runat="server" Visible="False">
            <asp:ListItem Value="0">STT</asp:ListItem>
            <asp:ListItem Value="1">Nhan đề</asp:ListItem>
            <asp:ListItem Value="2">ĐKCB</asp:ListItem>
            <asp:ListItem Value="3">Số định danh</asp:ListItem>
            <asp:ListItem Value="4">Lý do</asp:ListItem>
            <asp:ListItem Value="5">Số định danh</asp:ListItem>
            <asp:ListItem Value="6">Vị trí thống kê</asp:ListItem>
            <asp:ListItem Value="7">Vị trí thống kê</asp:ListItem>
            <asp:ListItem Value="8">Vị trí đúng</asp:ListItem>
            <asp:ListItem Value="9">Chọn toàn bộ</asp:ListItem>
            <asp:ListItem Value="10">Danh sách đăng ký cá biệt thiếu:</asp:ListItem>
            <asp:ListItem Value="11">Danh sách đăng ký cá biệt đặt nhầm chỗ:</asp:ListItem>
            <asp:ListItem Value="12">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="13">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="14">Thư viện:&nbsp;</asp:ListItem>
            <asp:ListItem Value="15">, kho:&nbsp;</asp:ListItem>
            <asp:ListItem Value="16">, giá sách:&nbsp;</asp:ListItem>
            <asp:ListItem Value="17">Bạn phải chọn ít nhất một đăng ký cá biệt!</asp:ListItem>
            <asp:ListItem Value="18">Thao tác đã thực hiện xong!</asp:ListItem>
            <asp:ListItem Value="19">Không có ĐKCB đặt nhầm chỗ.</asp:ListItem>
            <asp:ListItem Value="20">Không có ĐKCB bị thiếu.</asp:ListItem>
        </asp:DropDownList><asp:Label ID="lblErrorInfor" runat="server" Visible="False"></asp:Label><asp:Label ID="lblErrorCode" runat="server" Visible="False"></asp:Label><asp:Label ID="lblLibName" runat="server" Visible="False"></asp:Label><asp:Label ID="lblLoction" runat="server" Visible="False"></asp:Label><asp:Label ID="lblShelf" runat="server" Visible="False">Giá: </asp:Label>
    </form>
</body>
</html>
