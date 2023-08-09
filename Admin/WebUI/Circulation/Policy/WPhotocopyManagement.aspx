<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WPhotocopyManagement" CodeFile="WPhotocopyManagement.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WPhotocopyManagement</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Quản lý Photocopy</h1>
            <div class="main-form">
                <div class="two-column">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Số thẻ:</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCardNo" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <asp:Label ID="lblCopyNumber" runat="server"><U>Đ</U>KCB:</asp:Label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCopyNumber" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <asp:Label ID="lblCreatedDate" runat="server">Thời <U>g</U>ian yêu cầu:</asp:Label><asp:HyperLink ID="lnkCreatedDate" runat="server">Lịch</asp:HyperLink>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtCreatedDate" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <asp:Label ID="lblTypeID" runat="server"><U>K</U>iểu photo:</asp:Label><asp:HyperLink ID="lnkNewPaperType" runat="server" CssClass="lbLinkfunction" NavigateUrl="javascript:NewPhotoType();">Kiểu mới</asp:HyperLink>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlTypeID" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=" two-column-form">
                        <div class="two-column row-detail ClearFix">
                            <div class="two-column-form">
                                <asp:Label ID="lblPageCount" runat="server">Số <U>t</U>rang:</asp:Label>
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtPageCount" runat="server" Width="">0</asp:TextBox>
                                </div>

                            </div>
                            <div class="two-column-form">
                                <asp:Label ID="lblPageDetail" runat="server"><U>C</U>hi tiết:</asp:Label>
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtPageDetail" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="two-column row-detail ClearFix">
                            <div class="two-column-form">
                                <asp:Label ID="lblAmount" runat="server"><U>P</U>hí phải trả:</asp:Label>
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtAmount" runat="server" ReadOnly="True" Width=""></asp:TextBox>
                                </div>
                            </div>
                            <div class="two-column-form">
                                <asp:Label ID="lblPaidAmount" runat="server">đã <U>t</U>rả:</asp:Label>
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtPaidAmount" runat="server" Width="">0</asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="row-detail">
                            <div class="two-column ClearFix">
                                <div class="two-column-form">
                                    <asp:Label ID="lblInputer" runat="server"><U>N</U>gười photo:</asp:Label>
                                    <div class="input-control">
                                        <div class="input-form">
                                            <asp:TextBox CssClass="text-input" ID="txtInputer" runat="server" Width=""></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="two-column-form" style="padding-top: 26px;">
                                    <asp:CheckBox ID="chkDone" runat="server" CssClass="excheckbox" Checked="True"></asp:CheckBox>
                                    <label for="chkDone"></label>
                                    <asp:Label ID="lblDone" runat="server">Đã photo</asp:Label>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
                <br />
                <div class="row-detail ClearFix">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnNew" runat="server" Width="" Text="Nhập mới(u)"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnReset" runat="server" Width="" Text="Làm lại(r)"></asp:Button>
                        </div>
                    </div>
                </div>


                <div class="row-detail ClearFix">
                    <asp:Label ID="lblListPhoto" runat="server" CssClass="lbSubFormTitle">Danh sách yêu cầu photocopy</asp:Label>
                </div>
                <div class="row-detail">
                    <div class="input-control inline-box">
                        <asp:Label ID="lblCardNoSearch" runat="server"><U>S</U>ố thẻ:</asp:Label>
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtCardNoSearch" runat="server" Width="164px"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblCopyNumSearch" runat="server"><U>Đ</U>KCB:</asp:Label>
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtCopyNumSearch" runat="server" Width="150px"></asp:TextBox>
                        </div>
                        <asp:Label ID="lblDoneSearch" runat="server">Trạng thá<U>i</U>:</asp:Label>
                        <div class="input-control" style="width: 132px;">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlDone" runat="server">
                                    <asp:ListItem Value="2">&nbsp;</asp:ListItem>
                                    <asp:ListItem Value="1">Đã photo</asp:ListItem>
                                    <asp:ListItem Value="0">Chưa photo</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <asp:Label ID="lblFromPhoto" runat="server">Từ ngà<U>y</U>:</asp:Label>
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtFromPhoto" runat="server" Width=""></asp:TextBox>
                        </div>
                        <asp:HyperLink ID="lnkFromPhoto" runat="server">Lịch</asp:HyperLink>&nbsp;&nbsp;
						<asp:Label ID="lblToPhoto" runat="server">đế<U>n</U>:</asp:Label>
                        <div class="input-form">
                            <asp:TextBox CssClass="text-input" ID="txtToPhoto" runat="server" Width=""></asp:TextBox>
                        </div>
                        <asp:HyperLink ID="lnkToPhoto" runat="server">Lịch</asp:HyperLink>&nbsp;
                        <asp:Button ID="btnFind" runat="server" Text="Tìm(s)" Width=""></asp:Button>
                    </div>
                </div>

                <p>
                    <asp:Label ID="lblNothing" runat="server" Visible="False">Không tồn tại dữ liệu thoả mãn điều kiện tìm kiếm</asp:Label>
                </p>
                <div class="table-form">
                    <asp:DataGrid ID="dtgListPhoto" CssClass="table-control" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True">
                        <Columns>
                            <asp:TemplateColumn Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                    </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Số thẻ">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblPatronCodeGrid" Text='<%# DataBinder.Eval(Container.DataItem, "PatronCode") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" Width="50px" MaxLength="100" runat="server" ID="txtPatronCodeGrid" Text='<%# DataBinder.Eval(Container.DataItem, "PatronCode") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ĐKCB">
                                <HeaderStyle Width="10%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblCopyNumberGrid" Text='<%# DataBinder.Eval(Container.DataItem, "CopyNumber") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" Width="90px" MaxLength="100" runat="server" ID="txtCopyNumberGrid" Text='<%# DataBinder.Eval(Container.DataItem, "CopyNumber") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Số trang" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Width="9%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblPageCountGrid" Text='<%# DataBinder.Eval(Container.DataItem, "PageCount") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" Width="50px" AutoPostBack="True" OnTextChanged="PopulateTypeID" MaxLength="100" runat="server" ID="txtPageCountGrid" Text='<%# DataBinder.Eval(Container.DataItem, "PageCount") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Ngày yêu cầu" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="11%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedDateGrid" Text='<%# DataBinder.Eval(Container.DataItem, "CREATEDDATE") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Số tiền (VNĐ)" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Width="12%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblAmountGrid" Text='<%# DataBinder.Eval(Container.DataItem, "Amount") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" Width="80px" MaxLength="100" runat="server" ID="txtAmountGrid" ReadOnly="True" Text='<%# DataBinder.Eval(Container.DataItem, "Amount") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Đã trả (VNĐ)" ItemStyle-HorizontalAlign="Right">
                                <HeaderStyle Width="12%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblPaidAmountGrid" Text='<%# DataBinder.Eval(Container.DataItem, "PaidAmount") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" Width="80px" MaxLength="100" runat="server" ID="txtPaidAmountGrid" Text='<%# DataBinder.Eval(Container.DataItem, "PaidAmount") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Đã photo" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="7%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblDoneGrid" Text='<%# DataBinder.Eval(Container.DataItem, "strDone") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkDoneGrid" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "Done") %>'></asp:CheckBox>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Ghi chú">
                                <ItemTemplate>
                                    <asp:Label ID="lblPageDetailGrid" Text='<%# DataBinder.Eval(Container.DataItem, "PageDetail") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" Width="130px" MaxLength="100" runat="server" ID="txtPageDetailGrid" Text='<%# DataBinder.Eval(Container.DataItem, "PageDetail") %>' />
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Kiểu" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="7%"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:Label ID="lblPaperTypeGrid" Text='<%# DataBinder.Eval(Container.DataItem, "TypeName") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox CssClass="text-input" Visible="False" runat="server" ID="txtTypeIDHid" Text='<%# DataBinder.Eval(Container.DataItem, "TypeID") %>' />
                                    <asp:DropDownList ID="ddlTypeIDGrid" runat="server" OnSelectedIndexChanged="PopulateTypeID" AutoPostBack="True"></asp:DropDownList>
                                </EditItemTemplate>
                            </asp:TemplateColumn>
                            <asp:EditCommandColumn HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" ButtonType="LinkButton"
                                UpdateText="&lt;img src=&quot;../../images/update.gif&quot; border=&quot;0&quot;&gt;" CancelText="&lt;img src=&quot;../../images/cancel.gif&quot; border=&quot;0&quot;&gt;"
                                EditText="&lt;img src=&quot;../../images/Edit2.gif&quot; border=&quot;0&quot;&gt;"></asp:EditCommandColumn>
                        </Columns>
                        <PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
                    </asp:DataGrid>
                </div>
            </div>
            
        </div>
        <asp:Label ID="lblAlert" runat="server" Visible="False">Dữ liệu không hợp lệ! |Số thẻ hoặc ĐKCB không tồn tại</asp:Label>
        <input id="txtHidDataPrice" type="hidden" size="5" name="txtHidDataPrice" runat="server">
        <input id="txtHidDataTypeID" type="hidden" size="7" name="txtHidDataTypeID" runat="server">
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">---------- Chọn ----------</asp:ListItem>
            <asp:ListItem Value="3">Tạo mới khoản thu tiền photocopy</asp:ListItem>
            <asp:ListItem Value="4">Cập nhật khoản thu tiền photocopy</asp:ListItem>
            <asp:ListItem Value="5">Xoá khoản thu tiền photocopy</asp:ListItem>
            <asp:ListItem Value="6">Dữ liệu đuợc cập nhật thành công</asp:ListItem>
            <asp:ListItem Value="7">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="8">Số không hợp lệ!</asp:ListItem>
            <asp:ListItem Value="9">Thẻ đã hết hạn sử dụng!</asp:ListItem>
            <asp:ListItem Value="10">Vượt quá hạn ngạch!</asp:ListItem>
            <asp:ListItem Value="11">Thẻ đang bị khoá!</asp:ListItem>
            <asp:ListItem Value="12">Đăng ký cá biệt không tồn tại!</asp:ListItem>
            <asp:ListItem Value="13">Thẻ không tồn tại!</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtCardNo.focus();
    </script>
</body>
</html>
