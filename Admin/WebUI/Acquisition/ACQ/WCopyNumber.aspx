<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WCopyNumber" CodeFile="WCopyNumber.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCopyNumber</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <style>
        .row-detail > p {
            width: 100%;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="2" topmargin="2">
    <form id="Form1" method="post" runat="server">
        <table cellspacing="0" cellpadding="2" width="100%" border="0">
            <div id="divBody">
                <h1 class="main-head-form">
                    <asp:Label ID="lblHeader" runat="server" CssClass="">Dữ liệu xếp giá</asp:Label></h1>
                <asp:HyperLink ID="lnkCata" runat="server" Visible="False" NavigateUrl="WCataForm.aspx">Biên mục sơ lược</asp:HyperLink>
                <div class="three-column ClearFix">
                    <div class="three-column-form">
                        <h1 class="main-group-form">
                            <asp:Label ID="lblInforHold" runat="server" CssClass="" Width="100%">Thông tin xếp giá bổ sung</asp:Label></h1>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblCode" runat="server">&lt;U&gt;M&lt;/U&gt;ã tài liệu:</asp:Label> <span class="error-star">(*)</span>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <p>
                            </p>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnCodeFind" runat="server" Width="60px" Text="Tìm(f)"></asp:Button>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblACQSource" runat="server">Nguồn bổ s&lt;U&gt;u&lt;/U&gt;ng:</asp:Label>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:DropDownList ID="ddlACQSource" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblAdditionalBy" runat="server">Lý do:</asp:Label>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtAdditionalBy" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblACQDate" runat="server">&lt;U&gt;N&lt;/U&gt;gày bổ sung:</asp:Label>
                                <asp:HyperLink ID="lnkCalendar" runat="server" NavigateUrl="javascript:ViewCanlendar();">Lịch</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtDateChng" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <h1 class="main-group-form">
                            <asp:Label ID="lblPosHolding" runat="server" CssClass="" Width="100%">Thông tin xếp giá bổ sung</asp:Label>
                        </h1>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblCodePO" runat="server">Mã &lt;U&gt;s&lt;/U&gt;ố đơn đặt:</asp:Label>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtCodePO" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <p>
                            </p>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnCodePOFind" runat="server" Width="60px" Text="Tìm(r)"></asp:Button>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblLoanType" runat="server">&lt;u&gt;K&lt;/u&gt;iểu tư liệu (lưu thông):</asp:Label><span class="error-star">(*)</span>
                            </p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLoanType" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblPrice" runat="server">Đơn &lt;u&gt;g&lt;/u&gt;iá (đ/bản):</asp:Label>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtPrice" runat="server">0</asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblStatus" runat="server">Tình trạng:</asp:Label>
                            </p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <h1 class="main-group-form">Thông tin xếp giá </h1>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblLibrary" runat="server"><u>&lt;u&gt;T&lt;/u&gt;hư viện</asp:Label><span class="error-star">(*)</span>
                            </p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLibrary" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblLocation" runat="server">Kh&lt;U&gt;o&lt;/U&gt;</asp:Label><span class="error-star">(*)</span>
                            </p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLocation" runat="server">
                                    </asp:DropDownList>
                                    <input id="txtLocID" type="hidden" size="1" name="txtLocID" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblShelf" runat="server">G&lt;U&gt;i&lt;/U&gt;á sách</asp:Label>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtShelf" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                            <div class="row-detail" style="display:none">
                                <p>
                                    <asp:Label ID="lblNumberCopiesStart" runat="server">Số bản bắt đầu</asp:Label><span class="error-star">(*)</span>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtNumberCopiesStart" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblHolding" runat="server">Đăng ký &lt;U&gt;c&lt;/U&gt;á biệt</asp:Label><span class="error-star">(*)</span>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtHolding" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <p>
                            </p>
                            <div>
                                <asp:CheckBox ID="cbFreeText" Text="Cho phép nhập DKCB tự do" runat="server" Checked="true" Visible="false"></asp:CheckBox>
                            </div>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnGenHolding" runat="server" Width="100px" Text="Sinh giá trị(g)"></asp:Button>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblQuantity" runat="server">Số &lt;U&gt;l&lt;/U&gt;ượng</asp:Label><span class="error-star">(*)</span>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <p>
                            </p>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnUpdate" runat="server" Width="82px" Text="Bổ sung(a)"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <h1 class="main-group-form">
                    <asp:Label ID="lblCurrentInforHolding" runat="server" Width="100%">Thông tin xếp giá hiện thời</asp:Label></h1>
                <div class="row-detail">
                    <p>
                        <asp:Label ID="txtDeptTitle" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="lblSumCopyNum" runat="server" Visible="False">Tổng số ĐKCB:</asp:Label>
                        <asp:Label ID="lblSumCopyNumVal" runat="server" ForeColor="Maroon" Font-Bold="True"
                            Visible="False"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="lblCopyData" runat="server" Visible="False">Dữ liệu ĐKCB tổng hợp: </asp:Label>
                        <asp:Label ID="lblCopyDataVal" runat="server" ForeColor="Maroon" Font-Bold="True"
                            Visible="False"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="lblFreeCopy" runat="server" Visible="False">Tổng số bản rỗi:</asp:Label>
                        <asp:Label ID="lblSumFreeCopy" runat="server" ForeColor="Maroon" Font-Bold="True"
                            Visible="False"></asp:Label>
                    </p>
                </div>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnBarCode" CssClass="" runat="server" Width="110px" Text="In mã vạch(v)"></asp:Button>&nbsp;
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnLabel" CssClass="form-btn" runat="server" Width="110px" Text="In nhãn gáy(g)"></asp:Button>
                        </div>
                    </div>
                </div>
                <h1 class="main-group-form">Thông tin bảng</h1>
                <div class="row-detail">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:HyperLink ID="lnkCheckAll" runat="server" Style="margin-right: 20px">Chọn tất</asp:HyperLink>
                        </div>
                        <div class="button-form">
                            <asp:HyperLink ID="lnkUnCheckAll" runat="server" Style="margin-right: 20px">Bỏ tất</asp:HyperLink>
                        </div>
                        <div class="button-form">
                            <asp:Image ID="imgLoan" runat="server" ImageUrl="../../Images/loan.gif" Style="margin-right: 10px"></asp:Image>
                            <asp:Label ID="lblLoan" runat="server" Style="margin-right: 20px">Đang cho mượn</asp:Label>
                        </div>
                        <div class="button-form">
                            <asp:Image ID="imgLock" runat="server" ImageUrl="../../Images/lock.gif" Style="margin-right: 10px"></asp:Image>
                            <asp:Label ID="lblLock" runat="server" Style="margin-right: 20px">Đang khóa</asp:Label>&nbsp;&nbsp;
                        </div>
                        <div class="button-form">
                            <asp:Image ID="imgProcess" runat="server" ImageUrl="../../Images/process.gif" Style="margin-right: 10px"></asp:Image><asp:Label
                                ID="lblProcess" runat="server">Chưa kiểm nhận tại kho</asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <tr>
                <td align="right"></td>
                <td colspan="3">
                    <asp:Label ID="lblPOHolding" runat="server" ForeColor="Maroon" Font-Bold="True" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        <table cellspacing="0" cellpadding="2" width="100%" border="0">
            <tr>
                <td align="center">
                    <div class="table-form">
                        <asp:DataGrid ID="dtgHoldingInfo" runat="server" Width="100%" AllowPaging="True"
                            OnItemDataBound="dtgHoldingInfo_ItemDataBound" OnEditCommand="dtgHoldingInfo_EditCommand"
                            OnUpdateCommand="dtgHoldingInfo_UpdateCommand" OnCancelCommand="dtgHoldingInfo_CancelCommand"
                            AutoGenerateColumns="False">
                            <EditItemStyle CssClass="lbGridEdit"></EditItemStyle>
                            <Columns>
                                <asp:TemplateColumn>
                                    <HeaderStyle Width="0px"></HeaderStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblMark" Text='<%# DataBinder.Eval(Container.dataItem,"Mark") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src=&quot;../../images/Update.gif&quot; border=&quot;0&quot;&gt;"
                                    CancelText="&lt;img src=&quot;../../images/Cancel.gif&quot; border=&quot;0&quot;&gt;"
                                    EditText="&lt;img src=&quot;../../images/Edit.gif&quot; border=&quot;0&quot;&gt;"></asp:EditCommandColumn>
                                <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                                <asp:TemplateColumn Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCopyID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn>
                                    <HeaderStyle Width="32" />
                                    <ItemTemplate>
                                        <input id="chkCopyID" type="checkbox" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "Checked") %>'>
                                        </input>
                                        <label for="chkCopyID"></label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Thư viện">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSelectLibrary" Text='<%# DataBinder.Eval(Container.DataItem, "Code") %>'
                                            runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtSelectLibID" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "LibID") %>' />
                                        <asp:DropDownList ID="ddlSelectLibrary" OnSelectedIndexChanged="PopulateLocationDropDownList"
                                            AutoPostBack="True" runat="server" Enabled='<%# DataBinder.Eval(Container.DataItem, "Checked") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Kho">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSelectLocation" Text='<%# DataBinder.Eval(Container.DataItem, "Symbol") %>'
                                            runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtSelectLocID" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "LocationID") %>' />
                                        <asp:DropDownList ID="ddlSelectLocation" DataTextField="Symbol" DataValueField="ID"
                                            runat="server" Enabled='<%# DataBinder.Eval(Container.DataItem, "Checked") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Giá sách">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShelfDa" Text='<%# DataBinder.Eval(Container.DataItem, "Shelf") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtShelfDa" Enabled='<%# DataBinder.Eval(Container.DataItem, "Checked") %>'
                                            Text='<%# DataBinder.Eval(Container.DataItem, "Shelf") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Tập" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVolume" Text='<%# DataBinder.Eval(Container.DataItem, "Volume") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="30" runat="server" ID="txtVolume" Enabled='<%# DataBinder.Eval(Container.DataItem, "Checked") %>'
                                            Text='<%# DataBinder.Eval(Container.DataItem, "Volume") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Số phân loại">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCallNumber" Text='<%# DataBinder.Eval(Container.DataItem, "CallNumber") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCallNumber" Enabled='<%# DataBinder.Eval(Container.DataItem, "Checked") %>'
                                            ReadOnly="True" Text='<%# DataBinder.Eval(Container.DataItem, "CallNumber") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="ÐKCB">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCopyNumber" Text='<%# DataBinder.Eval(Container.DataItem, "CopyNumber") %>'
                                            runat="server">
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtCopyNumber" Enabled='<%# DataBinder.Eval(Container.DataItem, "Checked") %>'
                                            Text='<%# DataBinder.Eval(Container.DataItem, "CopyNumber") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Giá tiền" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPriceDa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price") %>'/>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="70" runat="server" ID="txtPriceDa" Text='<%# DataBinder.Eval(Container.DataItem, "Price")%>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Ngày bổ sung" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle Wrap="False"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAcquiredDate" Text='<%# DataBinder.Eval(Container.DataItem, "AcquiredDate") %>'
                                            runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="70" runat="server" ID="txtAcquiredDate" Text='<%# DataBinder.Eval(Container.DataItem, "AcquiredDate") %>' />
                                        <asp:HyperLink ID="lnkCal" runat="server">Lich</asp:HyperLink>
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Nguồn bổ sung" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "Source") %>'
                                            runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtAcqSourceID" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "AcquiredSourceID") %>' />
                                        <asp:DropDownList ID="ddlAcqSourceID" DataTextField="Source" DataValueField="ID"
                                            runat="server" />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Ghi chú">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNote" Text='<%# DataBinder.Eval(Container.DataItem, "Note") %>'
                                            runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="100" runat="server" ID="txtNote" Text='<%# DataBinder.Eval(Container.DataItem, "Note") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Mã Vạch">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBarCode" Text='<%# DataBinder.Eval(Container.DataItem, "BarCode") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="100" runat="server" ID="txtBarCode" Text='<%# DataBinder.Eval(Container.DataItem, "BarCode") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Số bản" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNumberCopies" Text='<%# DataBinder.Eval(Container.DataItem, "NumberCopies") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="100" runat="server" ID="txtNumberCopies" Text='<%# DataBinder.Eval(Container.DataItem, "NumberCopies") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Trạng thái">
                                    <ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" Text='<%# DataBinder.Eval(Container.DataItem, "Imgs") %>'
                                            runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblStatusEdit" Text='' runat="server" />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Tình trạng">
                                    <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatusNode" Text='<%# DataBinder.Eval(Container.DataItem, "StatusNode") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlStatusNote"  AppendDataBoundItems="True" runat="server" >
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="HiddenFieldStatusCode" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "StatusCode") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Lý do">
                                    <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lblAdditionalBy" Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalBy") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox Width="100" runat="server" ID="txtAdditionalBy" Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalBy") %>' />
                                    </EditItemTemplate>
                                </asp:TemplateColumn>
                                <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src=&quot;../../images/Update.gif&quot; border=&quot;0&quot;&gt;"
                                    CancelText="&lt;img src=&quot;../../images/Cancel.gif&quot; border=&quot;0&quot;&gt;"
                                    EditText="&lt;img src=&quot;../../images/Edit.gif&quot; border=&quot;0&quot;&gt;"></asp:EditCommandColumn>
                            </Columns>
                            <PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="lbGroupTitleA">
                    <asp:Label ID="lblReasonDel" runat="server" CssClass="lbSubTitleSmall" Visible="False">Lý do loại &lt;u&gt;b&lt;/u&gt;ỏ:</asp:Label>&nbsp;
                    <asp:DropDownList ID="ddlReasonDel" AccessKey="b" runat="server" Width="120px" Visible="False">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="btnDelHoding" runat="server" Width="92px" Text="Loại bỏ(r)" Visible="False" Style="margin-right: 10px"></asp:Button>

                    <asp:Button ID="btnReceiveUnlock" runat="server" Text="Kiểm nhận/mở khóa(d)" Width="160px" Visible="False"></asp:Button> 
                    
                    <asp:Button ID="btnReceiveDelivered" runat="server" Text="Ghi nhận chờ chuyển ra kho" Width="200px" Visible="False"></asp:Button>
                </td>
            </tr>
        </table>
        <input id="txtLibID" type="hidden" name="txtLibID" runat="server">
        &nbsp;<input id="txtLocIDdgr" type="hidden" name="txtLocIDdgr" runat="server">&nbsp;
    <input id="hidUnHolding" type="hidden" runat="server">
        <input id="hidPOID" type="hidden" runat="server">
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Dữ liệu không phải là kiểu số</asp:ListItem>
            <asp:ListItem Value="3">Dữ liệu không phải kiểu ngày tháng</asp:ListItem>
            <asp:ListItem Value="4">Bạn chưa nhập đủ thông tin cần thiết cho việc bổ sung ĐKCB!</asp:ListItem>
            <asp:ListItem Value="5">Đăng ký cá biệt đang tồn tại !</asp:ListItem>
            <asp:ListItem Value="6">Cập nhật thông tin đăng ký cá biệt</asp:ListItem>
            <asp:ListItem Value="7">Xoá đăng ký cá biệt</asp:ListItem>
            <asp:ListItem Value="8">Bổ sung đăng ký cá biệt</asp:ListItem>
            <asp:ListItem Value="9">Số lượng nhận:</asp:ListItem>
            <asp:ListItem Value="10">Số lượng chưa phân kho:</asp:ListItem>
            <asp:ListItem Value="11">Số lượng phân kho vượt quá số lượng chưa phân kho! Số lượng chưa phân kho còn lại là :</asp:ListItem>
            <asp:ListItem Value="12">Số lượng phân kho phải lớn hơn 0!</asp:ListItem>
            <asp:ListItem Value="13">Kiểm nhận và mở khóa thành công!</asp:ListItem>
            <asp:ListItem Value="14">Bạn chưa chọn ĐKCB nào!</asp:ListItem>
            <asp:ListItem Value="15">Ghi nhận chuyển ra kho thành công</asp:ListItem>
            <asp:ListItem Value="16">Ghi nhận chuyển ra kho không thành công</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtCode.focus();
    </script>
</body>
</html>
