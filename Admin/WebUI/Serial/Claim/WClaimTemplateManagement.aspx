<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Serial.WClaimTemplateManagement" CodeFile="WClaimTemplateManagement.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WClaimTemplateManagement</title>
    <script language="JavaScript" src="../Js/Claim/picker.js"></script>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
      <link runat="server" href="../../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../../js/SpryTabbedPanels.js"></script>
    <style>
        #divBody {
          
            padding-left: 20px
        }

            #divBody .tab {
                display: inline;
                text-align: right;
            }

                #divBody .tab ul {
                    padding-top: 5px;
                    padding-right: 30px;
                }

                    #divBody .tab ul li {
                        background: #f0a30a none repeat scroll 0 0;
                        color: #fff;
                        display: inline-block;
                        padding: 5px 10px;
                    }

        li {
            list-style: outside none none;
        }

        #divBody .tab ul li a {
            color: #fff;
        }

        #divBody .tab ul li.active {
            background-color: #000;
            color: #fff;
            display: inline-block;
            padding: 5px 10px;
        }
    </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
          
            <div class="tab">
                <ul>
                    <li class="active">
                        <asp:Label ID="lblCreateClaimCycle" CssClass="lbGroupTitle" runat="server">Tạo mẫu đơn khiếu nại</asp:Label>

                    </li>
                    <li >

                        <asp:HyperLink ID="lblSetClaimCycle" NavigateUrl="WSetClaimCycle.aspx"  CssClass="lbLinkFunction" runat="server">Chu trình khiếu nại</asp:HyperLink>
                    </li>
                    <li>
                          <asp:HyperLink ID="hrfClaim" NavigateUrl="WClaim.aspx" CssClass="lbLinkFunction" runat="server">Khiếu nại</asp:HyperLink>

                    </li>
                    <li>
                         <asp:HyperLink ID="hrfShowClaimList" NavigateUrl="WShowClaimList.aspx" CssClass="lbLinkFunction"
                        runat="server">Xem lại</asp:HyperLink>

                    </li>

                </ul>
            </div>
        
            <div class="main-form">
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <asp:Label ID="lblCaption" runat="server">Tê<u>n</u> mẫu:</asp:Label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCaption" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <asp:Label ID="lblPageHeader" runat="server"><U>Đ</U>ầu trang:</asp:Label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtPageHeader" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <asp:Label ID="lblHeader" runat="server" CssClass="lbSubFormTitle">T<u>i</u>êu đề</asp:Label>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="area-input" ID="txtHeader" TabIndex="3" runat="server" Width="" Wrap="true" TextMode="MultiLine" Height="60px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="two-column-form">
                        <div class="row-detail">
                            <asp:Label ID="lblPickForm" runat="server"><u>C</u>họn mẫu: </asp:Label>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlTemplate" Style="z-index: 2" TabIndex="1" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <asp:Label ID="lblHeaderAddInformation" runat="server">Thông tin bổ sun<u>g</u>:</asp:Label>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlHeaderAddInformation" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <h2 class="main-head-form">Mẫu báo cáo gồm các cột</h2>
            <div class="main-form">
                <div class="two-column ClearFix">


                    <div class="two-column-form ClearFix">
                        <div class="span45">
                            <div class="row-detail">
                                <p>Không hiển thị :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:ListBox CssClass="area-input" ID="lsbAllCollums" runat="server" Width="" SelectionMode="Multiple" Rows="6"
                                            Style="z-index: 2"></asp:ListBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="span1">
                            <div class="input-control button-list">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button CssClass="btn-icon btn-next" ID="btnAdd" runat="server" Text=">>"></asp:Button>
                                        <div class="icon-btn"><span class="icon-arrow-right"></span></div>
                                    </div>
                                </div>
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button CssClass="btn-icon btn-prev" ID="btnRemove" runat="server" Text="<<"></asp:Button>
                                        <div class="icon-btn"><span class="icon-arrow-left"></span></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="span45">
                            <div class="row-detail">
                                <p>Cột hiển thị :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:ListBox CssClass="area-input" ID="lsbCollum" runat="server" Width="" SelectionMode="Multiple" Rows="6" Style="z-index: 4"></asp:ListBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form ClearFix">
                        <div class="unit-4">
                            <div class="row-detail">
                                <p>Tên hiển thị :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="area-input" ID="txtCollumCaption" TabIndex="8" runat="server" Width="" Columns="20" Wrap="False"
                                            TextMode="MultiLine" Rows="5" Style="z-index: 6"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="unit-4">
                            <div class="row-detail">
                                <p>Độ rộng :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="area-input" ID="txtCollumWidth" runat="server" Width="" Columns="10" Wrap="False" TextMode="MultiLine"
                                            Rows="5" Style="z-index: 8"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="unit-4">
                            <div class="row-detail">
                                <p>Căn lề :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="area-input" ID="txtAlign" runat="server" Width="100px" Columns="10" Wrap="False" TextMode="MultiLine"
                                            Rows="5" Style="z-index: 10"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="unit-4">
                            <div class="row-detail">
                                <p>Định dạng :</p>
                                <div class="input-control">
                                    <div class="input-form ">
                                        <asp:TextBox CssClass="area-input" ID="txtFormat" runat="server" Width="" Columns="10" Wrap="False" TextMode="MultiLine"
                                            Rows="5" Style="z-index: 12"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>
                                Màu bảng :
                            <asp:HyperLink ID="lnkTableColor" runat="server" NavigateUrl="javascript:TCP.popup(document.forms[0].elements['txtTableColor'], 1)">Chọn</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtTableColor" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>
                                Màu hàng lẻ :
                            <asp:HyperLink ID="lnkOddColor" runat="server" NavigateUrl="javascript:TCP.popup(document.forms[0].elements['txtOddColor'], 1)">Chọn</asp:HyperLink>
                            </p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtOddColor" Width="" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Màu hàng chẳn :<asp:HyperLink ID="lnkEventColor" runat="server" NavigateUrl="javascript:TCP.popup(document.forms[0].elements['txtEventColor'], 1)">Chọn</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtEventColor" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Thông tin bổ sung :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlFooterAddInformation" Style="z-index: 21" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Cuối trang :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtPageFooter" Width="" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Cuối đơn :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtFooter" TabIndex="10" runat="server" Width="" Wrap="true" TextMode="MultiLine"
                                        Height="60px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="button-control" style="text-align: center;">
                        <div class="button-form">
                            <asp:Button ID="btnUpdate" TabIndex="11" runat="server" Text="Cập nhật(c)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnPreview" TabIndex="12" runat="server" Text="Xem trước(e)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnDelete" TabIndex="13" runat="server" Text="Xoá(x)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này.</asp:ListItem>
            <asp:ListItem Value="<$NUMBER$>,<$TOTALNUMBER$>,<$ISSUEDATE$>,<$LESSAMOUNT$>,<$PRICE$>,<$SPECIALTITLE$>,<$SPECIALISSUE$>">Số,Số toàn cục,Ngày phát hành,Số lượng thiếu,Đơn giá,Tên số đặc biệt,Kiểu số</asp:ListItem>
            <asp:ListItem Value=",<$PUBLISHER$>,<$ADDRESS$>,<$TELEPHONE$>,<$FAX$>,<$EMAIL$>,<$CONTACTPERSON$>,<$PROVINCE$>,<$POCODE$>,<$PONAME$>,<$VALIDDATE$>,<$EXPIREDDATE$>,<$MONEYTOTAL$>,<$CURRENCY$>,<$ITEMNAME$>">Chọn thông tin, Tên nhà phát hành,Địa chỉ, Điện thoại,Fax,Email,Người liên hệ,Tỉnh quốc gia,Mã số hợp đồng, Tên hợp đồng,Ngày bắt đầu,Ngày kết thúc,Tổng tiền,Đơn vị tiền tệ, Tên ấn phẩm</asp:ListItem>
            <asp:ListItem Value="5">--------- Tạo mới ---------</asp:ListItem>
            <asp:ListItem Value="6">Tên mẫu là bắt buộc</asp:ListItem>
            <asp:ListItem Value="7">Thêm mới thành công</asp:ListItem>
            <asp:ListItem Value="8">Cập nhật thành công</asp:ListItem>
            <asp:ListItem Value="9">Nhấn OK để khẳng định việc xoá mẫu này!!!</asp:ListItem>
            <asp:ListItem Value="10">Tạo mới mẫu đơn khiếu nại</asp:ListItem>
            <asp:ListItem Value="11">Cập nhật mẫu đơn khiếu nại</asp:ListItem>
            <asp:ListItem Value="12">Xoá mẫu đơn khiếu nại</asp:ListItem>
            <asp:ListItem Value="13">Cập nhật không thành công (Dữ liệu nhập vào không phù hợp).</asp:ListItem>
        </asp:DropDownList>
        <asp:ListBox ID="lsbTemp" runat="server" Width="0px" Height="0px" Enabled="False"></asp:ListBox><input id="txtTemplate" type="hidden" value="0" name="txtTemplate" runat="server">
        <input id="hidCollum" type="hidden" name="hidCollum" runat="server">
    </form>
    <script language="javascript">
        document.forms[0].txtCaption.focus();
    </script>
</body>
</html>
