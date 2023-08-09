<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WSearchPrintInventory" CodeFile="WSearchPrintInventory.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 transitional//EN">
<html xmlns:o="urn:schemas-microsoft-com:office:office">
<head>
    <title>Ki?m kê</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script src="../../js/jquery.min.js" type="text/javascript"></script>
</head>
<body leftmargin="0" topmargin="4">
    <form id="frm" method="post" enctype="multipart/form-data" runat="server">
        <div id="divBody">
            <div class="main-body">
                <div class="two-column-form">
                    <h1 class="main-head-form">In kết quả kiểm kê</h1>
                    <div class="unit-3">
                        <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="optInventory" runat="server" Text="<U>K</U>ỳ kiểm kê" GroupName="optRangePrint"></asp:RadioButton>
                            </div>
                        </div>
                        <div class="row-detail" id="divInventory">
                            <p>Chọn kỳ:</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlInventory" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="unit-2">
                        <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="optValidDate" runat="server" Text="<U>N</U>gày kiểm kê" GroupName="optRangePrint" Checked="true"></asp:RadioButton>
                            </div>
                        </div>
                        <div class="row-detail" id="divVaiddate">
                            <div class="two-column">
                                <div class="two-column-form">
                                    <p>Từ ngày :
                                    <asp:HyperLink ID="lnkFromDate" runat="server">Lịch</asp:HyperLink></p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:textbox CssClass="text-input"  ID="txtFromOpenDate" runat="server" Width=""></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="two-column-form">
                                <p>Đến ngày :
                                <asp:HyperLink ID="lnkToDate" runat="server">Lịch</asp:HyperLink></p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:textbox CssClass="text-input"  ID="txtToOpenDate" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            </div>
       
                        </div>
                    </div>
                    
                    <h1 class="main-group-form">Phạm vi in</h1>
                    <div class="two-column">
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Tên thư viện :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlLibrary" runat="server" AutoPostBack="True"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Tên kho :</p>
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                    <div class="input-control">
                                        <div class="dropdown-form">
                                            <asp:DropDownList ID="ddlLocation" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                
                            </div>
                            <div class="row-detail">
                                <p>Tên giá sách :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input"  ID="txtShelf" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail">
                                <p>Số hàng trên một trang :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="text-input"  ID="txtNumrow" runat="server" Width=""></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Sắp xếp theo :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlOrderField" runat="server">
                                            <asp:ListItem Value="Title">Nhan đề</asp:ListItem>
                                            <asp:ListItem Value="CopyNumber" Selected="True">ÐKCB</asp:ListItem>
                                            <asp:ListItem Value="CallNumber">Số định danh</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <p>Tăng :</p>
                                <div class="input-control">
                                    <div class="dropdown-form">
                                        <asp:DropDownList ID="ddlDirection" runat="server">
                                            <asp:ListItem Value="ASC" Selected="True">Tăng</asp:ListItem>
                                            <asp:ListItem Value="DESC">Giảm</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    

                    <h1 class="main-group-form">Hình thức in</h1>
                    <asp:RadioButtonList ID="optPurpose" runat="server" CssClass="lbRadio">
                        <asp:ListItem Value="0" Selected="True">Kết q<u>u</u>ả đăng ký cá biệt thiếu</asp:ListItem>
                        <asp:ListItem Value="1">Kết quả đăng ký <u>c</u>á biệt nhầm chỗ</asp:ListItem>
                    </asp:RadioButtonList>

                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button CssClass="form-btn" ID="btnInventory" runat="server" Width="110px" Text="In kết quả(p)"></asp:Button>

                            </div>
                        </div>
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button ID="btnClose" runat="server" Width="" Text="Ðóng(c)" Visible="False"></asp:Button>

                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:DataGrid ID="dgrLostResult" Width="100%" runat="server" Visible="False" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn DataField="IDRESERVE" HeaderText="STT"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Title" HeaderText="Nhan đề"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CopyNumber" HeaderText="Mã xếp giá"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CallNumber" HeaderText="Số định danh"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Reason" HeaderText="Lý do khoá"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>
                    <div>
                        <asp:DataGrid ID="dgrFalsePath" Width="100%" runat="server" Visible="False" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundColumn DataField="IDRESERVE" HeaderText="STT"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Title" HeaderText="Nhan đề"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CopyNumber" HeaderText="Mã xếp giá"></asp:BoundColumn>
                                <asp:BoundColumn DataField="CallNumber" HeaderText="Số định danh"></asp:BoundColumn>
                                <asp:BoundColumn DataField="InPaths" HeaderText="Vị trí kiểm kê"></asp:BoundColumn>
                                <asp:BoundColumn DataField="TruePaths" HeaderText="Vị trí đúng"></asp:BoundColumn>
                            </Columns>
                        </asp:DataGrid>
                    </div>

                </div>

            </div>
        </div>
        <input type="hidden" id="hiddenIspostback" runat="server" name="" value="0"/>
        <input type="hidden" id="hiddenOptInventory" name="" runat="server" value="0"/>
        <asp:DropDownList ID="ddlLabel" Width="0" runat="server" Visible="False">
            <asp:ListItem Value="0">Mã lỗi </asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính nang này</asp:ListItem>
            <asp:ListItem Value="3">In kết quả kiểm kê</asp:ListItem>
            <asp:ListItem Value="4"> Dữ liệu phải là kiểu số</asp:ListItem>
            <asp:ListItem Value="5"> Bạn chua chọn dữ liệu để in</asp:ListItem>
            <asp:ListItem Value="6">---Chọn kho---</asp:ListItem>
            <asp:ListItem Value="7">---Chọn kỳ kỳ kiểm kê---</asp:ListItem>
            <asp:ListItem Value="8">Bạn chưa chọn kỳ kiểm kê.</asp:ListItem>
            <asp:ListItem Value="9">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtShelf.focus();
        $(document).ready(function () {
            changeOpt();
            //var isPostBackVal = $('#hiddenIspostback').val();
            // attr change
            $('input[type=radio][name=optRangePrint]').change(changeOpt);
            // set defallt pageload
            //if (isPostBackVal === '0') {
            //    $('#optValidDate').prop('checked', true);
            //    changeOpt();
            //}
            
            function changeOpt() {
                if ($('#optInventory').is(':checked')) {
                    $('#divVaiddate :input').attr('disabled', true);
                    $("#lnkFromDate").text('');
                    $("#lnkToDate").text('');
                    $('#divInventory :input').removeAttr('disabled');
                    $('#hiddenOptInventory').val(0); // selected is "Kỳ Kiểm Kê"
                } else {
                    $('#divInventory :input').attr('disabled', true);
                    $("#lnkFromDate").text('Lịch');
                    $("#lnkToDate").text('Lịch');
                    $('#divVaiddate :input').removeAttr('disabled');
                    $('#hiddenOptInventory').val(1); // selected is "Ngày kiểm kê"
                }
                
            };
            
        });
    </script>
</body>
</html>
