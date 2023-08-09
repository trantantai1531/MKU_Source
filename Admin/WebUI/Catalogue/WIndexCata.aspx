<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WIndexCata" CodeFile="WIndexCata.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WIndexBibliography</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="../js/SpryTabbedPanels.js"></script>
</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px;" onload="parent.document.getElementById('frmMain').setAttribute('rows','*,0');">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab" tabindex="0">Biên mục</li>
                    <li class="TabbedPanelsTab" tabindex="0">Trao đổi dữ liệu</li>
                    <li class="TabbedPanelsTab" tabindex="0">Khung biên mục</li>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="javascript:parent.Sentform.location.href='Catalogue/WCataDetailTaskbar.aspx';parent.Workform.location.href = 'WNothing.htm';">
                                    <span class="icon-history"></span>
                                    <p>Hàng đợi chờ biên mục chi tiết</p>
                                    <p class="desc-button">Tiếp tục biên mục chi tiết cho các tài liệu ấn phẩm mà bản ghi của chúng đã được bộ phận bổ sung cập nhật sơ lược vào cơ sở dữ liệu.</p>
                               </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="Catalogue/WMarcFormSelect.aspx">
                                    <span class="icon-history"></span>
                                    <p>Tạo mới</p>
                                    <p class="desc-button">Biên mục từ đầu một tài liệu ấn phẩm.</p>
                               </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="Catalogue/WSearchItemCode.aspx"> <!-- old: WItemModify.aspx -->
                                    <span class="icon-history"></span>
                                    <p>Sửa bản ghi biên mục</p>
                                    <p class="desc-button">Sửa chữa thuộc tính của các tài liệu ấn phẩm đã được biên mục trong cơ sở dữ liệu.</p>
                               </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="javascript:location.href='WNothing.htm'; parent.Sentform.location.href='Catalogue/WControlBarItemList.aspx?intTopNum=10'">
                                    <span class="icon-history"></span>
                                    <p>Xem dạng danh sách</p>
                                    <p class="desc-button">Liệt kê danh sách bản ghi theo thứ tự nhập vào cơ sở dữ liệu.</p>
                               </asp:HyperLink>

                                <asp:HyperLink runat="server" NavigateUrl="javascript:location.href='WNothing.htm'; parent.Sentform.location.replace('Catalogue/WControlBar.aspx');">
                                    <span class="icon-history"></span>
                                    <p>Xem dạng lần lượt</p>
                                    <p class="desc-button">Liệt kê lần lượt các bản ghi theo thứ tự nhập vào cơ sở dữ liệu.</p>
                               </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="Catalogue/WDeleteItem.aspx">
                                    <span class="icon-history"></span>
                                    <p>Xoá</p>
                                    <p class="desc-button">Xóa bản ghi của một tài liệu ấn phẩm đã được biên mục ra khỏi cơ sở dữ liệu.</p>
                               </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="javascript:parent.Sentform.location.href='Catalogue/WCataDetailRenewTaskbar.aspx';parent.Workform.location.href = 'WNothing.htm';">
                                    <span class="icon-history"></span>
                                    <p>Hàng đợi chờ duyệt</p>
                                    <p class="desc-button">Danh sách hàng đợi đã qua biên mục chi tiết chờ duyệt.</p>
                               </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="Catalogue/WImportDataExcel.aspx">
                                    <span class="icon-history"></span>
                                    <p>Import dữ liệu</p>
                                    <p class="desc-button">Import dữ liệu biên mục từ file excel</p>
                               </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="Catalogue/WMarcFieldsDefault.aspx">
                                    <span class="icon-history"></span>
                                    <p>Đặt giá trị ngầm định</p>
                                    <p class="desc-button">Thiết đặt giá trị ngầm định cho các trường thuộc tính của tài liệu ấn phẩm cần biên mục trong phiên làm việc.</p>
                               </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="javascript:location.href='WNothing.htm'; parent.Sentform.location.href='Catalogue/WCopyNumbersInfoBar.aspx'">
                                    <span class="icon-history"></span>
                                    <p>Tìm kiếm ĐKCB</p>
                                    <p class="desc-button">Tìm kiếm để xem được tình trạng cho mỗi số ĐKCB.</p>
                               </asp:HyperLink>
                            </li>
                        </ul>
                    </div>

                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="Catalogue/WExportRecordToFile.aspx">
                                    <span class="icon-history"></span>
                                    <p>Xuất khẩu bản ghi</p>
                                    <p class="desc-button">Xuất khẩu bản ghi ra file.</p>
                               </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="Catalogue/WZForm.aspx">
                                    <span class="icon-history"></span>
                                    <p>Nhập khẩu bản ghi qua Z39.50</p>
                                    <p class="desc-button">Nhập khẩu bản ghi biên mục từ nguồn bên ngoài (qua kết nối Z39.50).</p>
                               </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="Catalogue/WImportFromFile.aspx">
                                    <span class="icon-history"></span>
                                    <p>Nhập khẩu bản ghi từ tệp</p>
                                    <p class="desc-button">Nhập khẩu bản ghi biên mục từ nguồn bên ngoài (qua tệp ISO 2709).</p>
                               </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="Catalogue/UpdateDataBase.aspx">
                                    <span class="icon-history"></span>
                                    <p>Truy vấn dữ liệu</p>
                                    <p class="desc-button">Truy vấn dữ liệu (chức năng của nhà cung cấp)</p>
                               </asp:HyperLink>
                            </li>
                        </ul>
                    </div>

                    <div class="TabbedPanelsContent">
                        <ul class="TabbedPanelsTabGroup">
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="BibliographyTemplate/WIndexTemplate.aspx">
                                    <span class="icon-history"></span>
                                    <p>Mẫu biên mục/Trường biên mục</p>
                                    <p class="desc-button">Tạo mới, sửa, gộp các mẫu biên mục và trường biên mục.</p>
                               </asp:HyperLink>
                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="../../Acquisition/ACQ/WBarcodeForm.aspx">
                                    <span class="icon-history"></span>
                                    <p>In mã vạch </p>
                                    <p class="desc-button">In mã vạch cho các tư liệu trong cơ sở dữ liệu. </p>    
                                </asp:HyperLink>

                            </li>
                            <li class="TabbedPanelsTab" tabindex="0">
                                <asp:HyperLink runat="server" NavigateUrl="../../Acquisition/ACQ/WLabelPrintSearch.aspx">
                                    <span class="icon-history"></span> 
                                    <p>In nhãn </p>
                                    <p class="desc-button">In nhãn gáy ấn phẩm. </p>    
                                </asp:HyperLink>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" Visible="False" Width="0px" runat="server">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
        </asp:DropDownList>
         <script type="text/javascript">
			var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
    	</script>
    </form>
</body>
</html>
