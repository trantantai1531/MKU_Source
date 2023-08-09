<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCopyNumber" CodeFile="WCopyNumber.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCopyNumber</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
</head>
<body leftmargin="2" topmargin="2">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="two-column ClearFix">
                <div class="two-column-form">
                    <h1 class="main-head-form"><asp:Label ID="lblHeader" runat="server" CssClass="">Dữ liệu xếp giá</asp:Label></h1>
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>
                                    <asp:Label ID="lblCode" runat="server"><U>M</U>ã tài liệu:</asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtCode" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail" style="display:none">
                                <p>
                                    <asp:Label ID="lblAcqCode" runat="server">Mã đơn đặt:</asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtAcqCode" runat="server" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h1 class="main-head-form"><asp:Label ID="lblPosHolding" runat="server" CssClass="" Width="100%">Thông tin vị trí xếp giá</asp:Label></h1>
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>
                                    <asp:Label ID="lblLibrary" runat="server"><u>T</u>hư viện</asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlLibrary" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>
                                    <asp:Label ID="lblLocation" runat="server">Kh<U>o</U></asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlLocation" runat="server"></asp:DropDownList>
                                        <input id="txtLocID" type="hidden" size="1" name="txtLocID" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>
                                    <asp:Label ID="lblShelf" runat="server">G<U>i</U>á sách</asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtShelf" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail" style="display:none;">
                                <p>
                                    <asp:Label ID="lblNumberCopiesStart" runat="server">Số bản bắt đầu</asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtNumberCopiesStart" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>
                                    <asp:Label ID="lblHolding" runat="server">Đăng ký <U>c</U>á biệt</asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtHolding" runat="server"></asp:TextBox>
                                    </div>
                                    <div>
                                        <asp:CheckBox ID="cbFreeText" Text="Cho phép nhập DKCB tự do" runat="server" Checked="true" Visible="false"></asp:CheckBox>
                                    </div>
                                    
                                </div>
                                <div style="text-align: right;" class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnGenHolding" runat="server" Text="Sinh giá trị(g)"></asp:Button>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>
                                    <asp:Label ID="lblQuantity" runat="server">Số <U>l</U>ượng</asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>

                                    </div>

                                </div>
                                <div style="text-align: right;" class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnUpdate" runat="server" Text="Bổ sung(a)"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="two-column-form">
                    <h1 class="main-head-form">
                        <asp:Label ID="lblInforHold" runat="server" CssClass="" Width="100%">Thông tin xếp giá bổ sung</asp:Label>

                    </h1>
                    <div class="two-column ClearFix">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>
                                    <asp:Label ID="lblACQSource" runat="server">Nguồn bổ s<U>u</U>ng:</asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlACQSource" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail" style="display:none">
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
                                    <asp:Label ID="lblACQDate" runat="server"><U>N</U>gày bổ sung:</asp:Label>
                                    <asp:HyperLink ID="lnkCalendar" runat="server" NavigateUrl="javascript:ViewCanlendar();">Lịch</asp:HyperLink>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtDateChng" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>
                                    <asp:Label ID="lblLoanType" runat="server"><u>K</u>iểu tư liệu (lưu thông):</asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlLoanType" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>
                                    <asp:Label ID="lblPrice" runat="server">Đơn <u>g</u>iá (đ/bản):</asp:Label>
                                </p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox ID="txtPrice" runat="server">0</asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail" style="display:none">
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
                    </div>

                    <h1 class="main-head-form">
                        <asp:Label ID="lblCurrentInforHolding" runat="server" CssClass="" Width="100%">Thông tin xếp giá hiện thời</asp:Label></h1>
                    <div class="two-column ClearFix">
                           <div class="row-detail">
                            
                                <div class="input-control">
                                    <div class="">
                                        <asp:Label ID="txtDeptTitle" runat="server" ForeColor="Maroon" Font-Bold="True"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        <div class="row-detail">
                            <p>
                                <asp:Label ID="lblSumCopyNum" runat="server" Visible="False"> Tổng số ĐKCB: </asp:Label>
                                <a>
                                    <asp:Label ID="lblSumCopyNumVal" runat="server" Visible="False"></asp:Label></a>
                            </p>
                            <br />
                            <p style="display:flex;">
                                <asp:Label ID="lblCopyData" runat="server" Visible="False">Dữ liệu ĐKCB tổng hợp: </asp:Label>
                                <a><asp:Label ID="lblCopyDataVal" runat="server" Visible="False"></asp:Label></a>
                            </p>
                            <br />
                            <p>
                                <asp:Label ID="lblFreeCopy" runat="server" Visible="False"> Tổng số bản rỗi: </asp:Label><a><asp:Label ID="lblSumFreeCopy" runat="server" Visible="False"></asp:Label></a>
                            </p>
                        </div>

                    </div>



                </div>
            </div>
            <div class="row-detail">
            </div>

            <div class="row-detail" style="display:none">
                <div style="text-align: center;" class="button-control">
                    <div class="button-form">
                        <asp:Button ID="btnBarCode" runat="server" Width="110px" Text="In mã vạch(v)"></asp:Button>
                    </div>
                    <div class="button-form">
                        <asp:Button ID="btnLabel" runat="server" Width="110px" Text="In nhãn gáy(g)"></asp:Button>
                    </div>
                </div>
            </div>
            <div class="two-column ClearFix">

                <%-- <div class="row-detail">
                    <p><a href="">Chọn tất</a>-<a href="">Bỏ tất</a></p>
                </div>
                <div class="row-detail">
                    <div style="text-align: center;" class="button-control">
                        <div class="button-form">
                            <input type="button" class="form-btn" value="Đang cho mượn">
                        </div>
                        <div class="button-form">
                            <input type="button" class="form-btn" value="Đang khóa">
                        </div>
                        <div class="button-form">
                            <input type="button" class="form-btn" value="Chưa kiểm nhận tại kho">
                        </div>
                    </div>
                </div>--%>
                <div class="input-control row-detail">
                    <div class="table-form">
                        <table cellspacing="0" cellpadding="2" width="100%" border="0">
                            <tr style="background: white none repeat scroll 0% 0%;">
                                <td>
                                    <asp:HyperLink ID="lnkCheckAll" runat="server" Style="margin-right: 10px;">Chọn tất </asp:HyperLink>
                                    <asp:HyperLink ID="lnkUnCheckAll" runat="server" Style="margin-right: 10px;">Bỏ tất </asp:HyperLink>
                                    <asp:Image ID="imgLoan" runat="server" Style="margin-right: 10px;" ImageUrl="../../Images/loan.gif"></asp:Image><asp:Label ID="lblLoan" runat="server">Đang cho mượn</asp:Label>
                                    <asp:Image ID="imgLock" runat="server" Style="margin-right: 10px;" ImageUrl="../../Images/lock.gif"></asp:Image><asp:Label ID="lblLock" runat="server">Đang khóa </asp:Label>
                                    <asp:Image ID="imgProcess" runat="server" Style="margin-right: 10px;" ImageUrl="../../Images/process.gif"></asp:Image><asp:Label ID="lblProcess" runat="server">Chưa kiểm nhận tại kho </asp:Label></td>
                            </tr>
                            <tr style="background: white none repeat scroll 0% 0%;">
                                <td align="center">
                                    <asp:DataGrid ID="dtgHoldingInfo" runat="server" Width="100%" AllowPaging="True" OnItemDataBound="dtgHoldingInfo_ItemDataBound"
                                        OnEditCommand="dtgHoldingInfo_EditCommand" OnUpdateCommand="dtgHoldingInfo_UpdateCommand" OnCancelCommand="dtgHoldingInfo_CancelCommand"
                                        AutoGenerateColumns="False">
                                        <EditItemStyle CssClass="lbGridEdit"></EditItemStyle>
                                        <Columns>
                                            <asp:TemplateColumn Visible="False">
                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMark" Text='<%# DataBinder.Eval(Container.dataItem,"Mark") %>' runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src=&quot;../../images/Update.gif&quot; border=&quot;0&quot;&gt;"
                                                CancelText="&lt;img src=&quot;../../images/Cancel.gif&quot; border=&quot;0&quot;&gt;" EditText="&lt;img src=&quot;../../images/Edit.gif&quot; border=&quot;0&quot;&gt;">
												<HeaderStyle Width="4%"></HeaderStyle>
											</asp:EditCommandColumn>
                                            <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                                            <asp:TemplateColumn Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCopyID" Text='<%# DataBinder.Eval(Container.dataItem,"ID") %>' runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Chọn">
								<ItemStyle Wrap="True" HorizontalAlign="Center" Width="3%"></ItemStyle>
                                                <ItemTemplate>
                                                    <input type="checkbox" id="chkCopyID" runat="server" visible='<%# DataBinder.Eval(Container.DataItem, "Checked") %>'></input>
                                                    <label for="chkCopyID"></label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Thư viện">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSelectLibrary" Text='<%# DataBinder.Eval(Container.DataItem, "Code") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtSelectLibID" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "LibID") %>' />
                                                    <asp:DropDownList ID="ddlSelectLibrary" OnSelectedIndexChanged="PopulateLocationDropDownList" AutoPostBack="True" runat="server" Enabled='<%# Session("HoldingsInCatalogNew") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Kho">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="3%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSelectLocation" Text='<%# DataBinder.Eval(Container.DataItem, "Symbol") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtSelectLocID" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "LocationID") %>' />
                                                    <asp:DropDownList ID="ddlSelectLocation" DataTextField="Symbol" DataValueField="ID" runat="server" Enabled='<%# Session("HoldingsInCatalogNew") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Giá sách">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblShelfDa" Text='<%# DataBinder.Eval(Container.DataItem, "Shelf") %>' runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="70" runat="server" ID="txtShelfDa" Text='<%# DataBinder.Eval(Container.DataItem, "Shelf") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Tập" Visible="False">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVolume" Text='<%# DataBinder.Eval(Container.DataItem, "Volume") %>' runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="30" runat="server" ID="txtVolume" Enabled='<%# Session("HoldingsInCatalogNew") %>' Text='<%# DataBinder.Eval(Container.DataItem, "Volume") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Số phân loại">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label Width="60" ID="lblCallNumber" Text='<%# DataBinder.Eval(Container.DataItem, "CallNumber") %>'  runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox runat="server" Width="40" ID="txtCallNumber" Text='<%# DataBinder.Eval(Container.DataItem, "CallNumber")%>' Enabled="False" />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="ĐKCB">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCopyNumber" Text='<%# DataBinder.Eval(Container.DataItem, "CopyNumber") %>' runat="server">
                                                    </asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox runat="server" Width="60" ID="txtCopyNumber" Enabled='<%# Session("ALLOW_MODIFY_HOLDINGS") %>' Text='<%# DataBinder.Eval(Container.DataItem, "CopyNumber") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Giá tiền" ItemStyle-HorizontalAlign="Right">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPriceDa" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Price") %>'  />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="70" runat="server" ID="txtPriceDa"  Text='<%# DataBinder.Eval(Container.DataItem, "Price") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Ngày bổ sung" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAcquiredDate" Text='<%# DataBinder.Eval(Container.DataItem, "AcquiredDate") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="70" runat="server" ID="txtAcquiredDate"  Text='<%# DataBinder.Eval(Container.DataItem, "AcquiredDate") %>' />
                                                    <asp:HyperLink ID="lnkCal" runat="server">Lich</asp:HyperLink>
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Nguồn bổ sung" ItemStyle-HorizontalAlign="Center">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="Label1" Text='<%# DataBinder.Eval(Container.DataItem, "Source") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox runat="server" ID="txtAcqSourceID" Visible="False" Text='<%# DataBinder.Eval(Container.DataItem, "AcquiredSourceID") %>' />
                                                    <asp:DropDownList ID="ddlAcqSourceID" DataTextField="Source"  DataValueField="ID" runat="server" />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Mã Vạch" Visible="False">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBarCode" Text='<%# DataBinder.Eval(Container.DataItem, "BarCode") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="100" runat="server" ID="txtBarCode" Text='<%# DataBinder.Eval(Container.DataItem, "BarCode") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Số bản" Visible="False">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNumberCopies" Text='<%# DataBinder.Eval(Container.DataItem, "NumberCopies") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="100" runat="server" ID="txtNumberCopies" Text='<%# DataBinder.Eval(Container.DataItem, "NumberCopies") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Trạng thái">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="5%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" Text='<%# DataBinder.Eval(Container.DataItem, "Imgs") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblStatusEdit" Text='' runat="server" />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Tình trạng" Visible="False">
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
                                            <asp:TemplateColumn HeaderText="Lý do" Visible="False">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAdditionalBy" Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalBy") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="100" runat="server" ID="txtAdditionalBy" Text='<%# DataBinder.Eval(Container.DataItem, "AdditionalBy") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Kiểu tư liệu">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLoanTypeCurrent" Text='<%# DataBinder.Eval(Container.DataItem, "LoanType") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlLoanTypeCurrent" Width="100" AppendDataBoundItems="True" runat="server" >
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="HiddenFieldLoanTypeID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "LoanTypeID") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="Ghi chú">
                                                <ItemStyle Wrap="True" HorizontalAlign="Center"></ItemStyle>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNote" Text='<%# DataBinder.Eval(Container.DataItem, "Note") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox Width="250" runat="server" ID="txtNote" Text='<%# DataBinder.Eval(Container.DataItem, "Note") %>' />
                                                </EditItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src=&quot;../../images/Update.gif&quot; border=&quot;0&quot;&gt;"
                                                CancelText="&lt;img src=&quot;../../images/Cancel.gif&quot; border=&quot;0&quot;&gt;" EditText="&lt;img src=&quot;../../images/Edit.gif&quot; border=&quot;0&quot;&gt;">
												<HeaderStyle Width="4%"></HeaderStyle>
											</asp:EditCommandColumn>
                                        </Columns>
                                        <PagerStyle Position="TopAndBottom" Mode="NumericPages"></PagerStyle>
                                    </asp:DataGrid>
                                </td>
                            </tr>
                            <tr style="background: white none repeat scroll 0% 0%;">
                                <td>
                                    <asp:CheckBox ID="chkAllinLoc" runat="server" Text="Thay đổi số định danh cho cả kho" Checked="False"></asp:CheckBox>
                                </td>
                            </tr>
                            <tr style="background: white none repeat scroll 0% 0%;">
                                <td class="lbGroupTitle">
                                    <asp:Label ID="lblReasonDel" runat="server" CssClass="lbSubTitleSmall" Visible="True">Lý do loại <u>b</u>ỏ:</asp:Label>&nbsp;
						            <asp:DropDownList ID="ddlReasonDel" AccessKey="b" runat="server" Width="120px" Visible="False">
						            </asp:DropDownList>&nbsp;
                                    <asp:Button ID="btnDeletePrevious" runat="server" Text="Xóa(x)" OnClientClick="if(!confirm('Xác nhận xóa ĐKCB'))return false;"></asp:Button>
						            <asp:Button ID="btnDelHoding" runat="server" Width="92px" Text="Loại bỏ(r)" Visible="False">
						            </asp:Button>&nbsp; 
                                    <asp:Button ID="btnReceiveUnlock" runat="server" Text="Kiểm nhân/mở khóa(d)" Width="160px" Visible="False"></asp:Button>&nbsp; 
                                    <asp:Button ID="btnReceiveDelivered" runat="server" Text="Ghi nhận chờ chuyển ra kho" Width="200px" Visible="False"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>


        <input id="hidSDD" type="hidden" value="0" name="txtSDD" runat="server" />
        <input id="txtLibID" type="hidden" name="txtLibID" runat="server" />
        &nbsp;<input id="txtLocIDdgr" type="hidden" name="txtLocIDdgr" runat="server" />&nbsp;
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
                <asp:ListItem Value="9">Kiểm nhận và mở khóa thành công !</asp:ListItem>
                <asp:ListItem Value="10">Chưa chọn ĐKCB nào!</asp:ListItem>
                <asp:ListItem Value="11">Số bản bắt đầu không hợp lệ</asp:ListItem>
                <asp:ListItem Value="12">Cập nhật trạng thái thành công</asp:ListItem>
                <asp:ListItem Value="13">Ghi nhận chuyển ra kho thành công</asp:ListItem>
                <asp:ListItem Value="14">Ghi nhận chuyển ra kho không thành công</asp:ListItem>
            </asp:DropDownList>
    </form>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtQuantity").val(1);
            var dd = document.getElementById('ddlLibrary');
            for (var i = 0; i < dd.options.length; i++) {
                if (dd.options[i].text === "EIU") {
                    dd.selectedIndex = i;
                    break;
                }
            }
            FilterLocation('ddlLocation');
        });
    </script>
</body>
</html>
