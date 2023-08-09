<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WContractDetail" CodeFile="WContractDetail.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Chi tiết hợp đồng</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/jquery-1.7.2.min.js"></script>

</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="divBody">
            <div class="main-page ClearFix">
            <asp:Label ID="lblMainTitle" runat="server" CssClass="lbPageTitle main-head-form" Width="100%"></asp:Label>
            <div class="row-group ClearFix">
                <div class="col-left-7">
                    <div class="row-detail">
                        <asp:Label ID="lblReceiptNo" runat="server"><U>M</U>ã số:</asp:Label>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txbReceiptNo" CssClass="text-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblPOName" runat="server"><U>T</U>ên đơn đặt:</asp:Label>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txbPOName" CssClass="text-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblVendor" runat="server">Nhà <U>c</U>ung cấp:</asp:Label>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:DropDownList ID="ddlVendor" runat="server" Width="201px"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnAddVendor" CssClass="form-btn" runat="server" Text="Thêm vào"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnVendorDetail" CssClass="form-btn" runat="server" Text="Tham khảo"></asp:Button><input id="txbVendorID" runat="server" type="hidden" size="7" name="txbVendorID">
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblValidDate" runat="server">Ngà<U>y</U> bắt đầu:</asp:Label>
                        &nbsp;<asp:HyperLink ID="lnkValidDate"  runat="server">(*) Lịch</asp:HyperLink>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txbValidDate" CssClass="text-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="Label2" runat="server">Ngày <U>k</U>ết thúc:</asp:Label>
                        &nbsp;<asp:HyperLink ID="lnkFilledDate" runat="server">(*) Lịch</asp:HyperLink>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txbFilledDate" CssClass="text-input" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                        <ContentTemplate>
                            <div class="row-detail">
                                <asp:Label ID="lblStatus" runat="server"><U>T</U>rạng thái</asp:Label>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlStatus" CssClass="text-input" runat="server" AutoPostBack="true"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <asp:Label ID="lblNote" runat="server">Ghi chú trạ<U>n</U>g thái:</asp:Label>
                                <div class="input-control">
                                    <div class="input-form ">
                             
                                        <asp:TextBox ID="txbNote" CssClass="text-input" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>  
                    
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnUpdate" CssClass="form-btn" runat="server" Text="Cập nhật"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnPrint" CssClass="form-btn" runat="server" Text="In, gửi"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnInventory" CssClass="form-btn" runat="server" Text="Kiểm nhận"></asp:Button>
                            </div>
                            <div class="button-form" style="display:none;">
                                <asp:Button ID="btnClaim" CssClass="form-btn" runat="server" Text="Khiếu nại"></asp:Button>
                            </div>
                            <div class="button-form" style="display:none;">
                                <asp:Button ID="btnStored" CssClass="form-btn" runat="server" Text="Phân kho"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnDelete" CssClass="form-btn" runat="server" Text="Xoá"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-right-3">
                    <div class="row-detail">
                        <asp:Label ID="lblTotalAmount" runat="server"><U>G</U>iá trị đơn đặt:</asp:Label>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txbTotalAmount" CssClass="text-input" runat="server">0</asp:TextBox>

                            </div>
                        </div>
                    </div>
                    
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                        <ContentTemplate>
                            <div class="row-detail">
                                <p>Đơn vị :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlCurrency" runat="server" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <asp:Label ID="lblFixedRate" runat="server">T<U>ỷ</U> giá:</asp:Label>
                                <div class="input-control">
                                    <div class="input-form control-disabled">
                                        <asp:TextBox ID="txbFixedRate" CssClass="text-input" runat="server" ReadOnly="true">1</asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>  
                    
                    <div class="row-detail">
                        <asp:Label ID="lblPrepaidAmount" runat="server">Thanh toán <U>b</U>an đầu:</asp:Label>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txbPrepaidAmount" CssClass="text-input" runat="server">0</asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblDiscount" runat="server">Giả<U>m</U> giá:</asp:Label>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:TextBox ID="txbDiscount" CssClass="text-input" runat="server">0</asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblPlanAmount" runat="server">Tổng dự ch<U>i</U>:</asp:Label>
                        <div class="input-control">
                            <div class="input-form control-disabled">
                                <asp:TextBox ID="txbPlanAmount" CssClass="text-input" ReadOnly="true" runat="server">0</asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <asp:Label ID="lblRealAmount" runat="server">Tổng thực ch<U>i</U>:</asp:Label>
                        <div class="input-control">
                            <div class="input-form control-disabled">
                                <asp:TextBox ID="txbRealAmount" CssClass="text-input" ReadOnly="true" runat="server">0</asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="input-control">
                <div class="table-form">
                    <%--<asp:Label ID="lblItemInfor" runat="server" CssClass="lbGroupTitle" Width="100%">Thông tin ấn phẩm</asp:Label>--%>
                    <asp:Table runat="server" CssClass="table-control" ID="tblItemInfor" Width="100%" CellPadding="3" CellSpacing="1"></asp:Table>
                </div>
            </div>
            <div class="row-detail" align="center">
                <div class="button-control">
                    <div class="button-form">
                        <input id="btnCheckAll" Visible="False" runat="server" class="lbButton" type="button" value="Chọn tất cả" onclick="CheckAllGrid()" />
                    </div>
                    <div class="button-form">
                        <input id="btnUnCheckAll" Visible="False" runat="server" class="lbButton" type="button" value="Bỏ chọn tất cả" onclick="UnCheckAllGrid()" />
                    </div>
                </div>
            </div>
            <div class="row-detail">
                <div class="button-control">
                    <div class="button-form">
                        <asp:Button ID="btnRemoveItems" runat="server" Text="Xoá" ></asp:Button>
                    </div>
                    <div class="button-form">
                        <asp:Button ID="btnPickItems" runat="server" Text="Chọn ấn phẩm"></asp:Button>
                    </div>
                </div>
            </div>
            <div class="row-group ClearFix" style="display:none;">
                <div class="col-left-4">
                    <%--<asp:Label ID="lblPoStatus" runat="server" CssClass="lbGroupTitle" Width="100%">Nhật ký trạng thái</asp:Label>--%>
                    <div class="table-form">
                        <asp:DataGrid ID="dtgStatus" runat="server" Width="100%" Height="22px" AutoGenerateColumns="False"
                            HeaderStyle-HorizontalAlign="Center" Visible="false">
                            <Columns>
                                <asp:BoundColumn DataField="SetDate" HeaderText="Thời gian" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="20%" ></asp:BoundColumn>
                                <asp:BoundColumn DataField="Status" HeaderText="Trạng thái" ItemStyle-Width="30%"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Note" HeaderText="Ghi chú trạng thái"  ItemStyle-Width="50%"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </div>
                <div class="col-right-6">
                    <%--<asp:Label ID="Label1" runat="server" CssClass="lbGroupTitle" Width="100%">Thông tin kế toán</asp:Label>--%>
                    <div class="table-form">
                        <asp:DataGrid ID="dtgAccount" runat="server" Width="100%" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center" Visible="false">
                            <Columns>
                                <asp:BoundColumn DataField="Amount" HeaderText="Số tiền" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="8%"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ExchangeRate" HeaderText="Tỷ giá" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="6%"></asp:BoundColumn>
                                <asp:BoundColumn DataField="BudgetName" HeaderText="Quỹ"></asp:BoundColumn>
                                <asp:BoundColumn DataField="TransactionDate" HeaderText="Ngày giao dịch" ItemStyle-HorizontalAlign="Center"
                                    ItemStyle-Width="9%"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Inputer" HeaderText="Người nhập" ItemStyle-Width="13%"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Commited" HeaderText="Trạng thái" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Reason" HeaderText="Ghi chú" ItemStyle-Width="16%" ItemStyle-HorizontalAlign="Center"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                </div>
            </div>
            <div class="row-detail" style="text-align: center; display:none;">
                <div class="button-control">
                    <div class="button-form">
                        <asp:Button ID="btnLiquidateInform" CssClass="form-btn" runat="server" Text="Khai báo chi"></asp:Button>
                    </div>
                    <div class="button-form">
                        <asp:Button ID="btnLiquidate" CssClass="form-btn" runat="server" Text="Khẳng định chi"></asp:Button>
                    </div>
                    <div class="button-form">
                        <asp:Button ID="btnToBudget" CssClass="form-btn" runat="server" Text="Hoàn quỹ"></asp:Button>
                    </div>
                </div>
            </div>
        </div>

        <input id="txbPOS" type="hidden" size="0" runat="server" value="0">
        <input id="txbPoType" type="hidden" size="0" runat="server" value="0">
        <input id="txbContractID" type="hidden" size="0" runat="server" value="0">
        <input id="txbItemIDs" type="hidden" size="0" runat="server" value=",">
        <input id="txbFunc" type="hidden" size="0" runat="server">
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Đơn đặt mua ấn phẩm đơn bản</asp:ListItem>
            <asp:ListItem Value="3">Đơn đặt mua ấn phẩm nhiều kỳ</asp:ListItem>
            <asp:ListItem Value="4">Cập nhật thông tin đơn đặt</asp:ListItem>
            <asp:ListItem Value="5">Xoá thông tin đơn đặt</asp:ListItem>
            <asp:ListItem Value="6">Đã tồn tại đơn đặt khác với mã số này</asp:ListItem>
            <asp:ListItem Value="7">Nhan đề</asp:ListItem>
            <asp:ListItem Value="8">Dạng tài liệu</asp:ListItem>
            <asp:ListItem Value="9">Vật mang tin</asp:ListItem>
            <asp:ListItem Value="10">Đơn giá (VND)</asp:ListItem>
            <asp:ListItem Value="11">Số lượng đặt</asp:ListItem>
            <asp:ListItem Value="12">Thành tiền (VND)</asp:ListItem>
            <asp:ListItem Value="13">Số lượng nhận</asp:ListItem>
            <asp:ListItem Value="14">Thành tiền (VND)</asp:ListItem>
            <asp:ListItem Value="15">Tổng:</asp:ListItem>
            <asp:ListItem Value="16">Giảm giá:</asp:ListItem>
            <asp:ListItem Value="17">Tổng:</asp:ListItem>
            <asp:ListItem Value="18">Loại ấn phẩm khỏi đơn đặt có mã số:</asp:ListItem>
            <asp:ListItem Value="19">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
            <asp:ListItem Value="20">Sai kiểu dữ liệu (số)</asp:ListItem>
            <asp:ListItem Value="21">Sai kiểu dữ liệu ngày tháng</asp:ListItem>
            <asp:ListItem Value="22">Bạn đang chuẩn bị xoá một đơn đặt ra khỏi CSDL, bạn có chắc chắn không ?</asp:ListItem>
            <asp:ListItem Value="23">Thực chi</asp:ListItem>
            <asp:ListItem Value="24">Dự chi</asp:ListItem>
            <asp:ListItem Value="25">Hoàn quỹ</asp:ListItem>
            <asp:ListItem Value="26">Ngày lập đơn chưa có</asp:ListItem>
            <asp:ListItem Value="27">STT</asp:ListItem>
        </asp:DropDownList>
        </div>
        
    </form>
    
    <script type="text/javascript">
        document.forms[0].txbReceiptNo.focus();

        function CheckAllGrid() {
            var ItemIds = ",";
            $("#<% =tblItemInfor.ClientID %> input[type='checkbox']").each(function () {
                $(this).prop('checked', true);
                var chkId = $(this).attr('id');
                ItemIds += chkId.replace("ck", "") + ",";
            });
            $("#txbItemIDs").val(ItemIds);
        }

        function UnCheckAllGrid() {
            $("#<% =tblItemInfor.ClientID %> input[type='checkbox']").each(function () {
                $(this).prop('checked', false);
            });
            $("#txbItemIDs").val(',');
        }


    </script>
</body>

</html>
