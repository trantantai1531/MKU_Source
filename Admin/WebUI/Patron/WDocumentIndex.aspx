<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WDocumentIndex" CodeFile="WDocumentIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WDocumentIndex</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">

    <link runat="server" href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link runat="server" href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link runat="server" href="../Resources/StyleSheet/iconFont.css" rel="stylesheet" />
    <link runat="server" href="../Resources/StyleSheet/SpryTabbedPanels.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/SpryTabbedPanels.js"></script>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body class="backgroundbody" style="margin-top: 0px; margin-left: 0px; margin-right: 0px; margin-bottom: 0px;">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div id="TabbedPanels1" class="TabbedPanels">
                <ul class="TabbedPanelsTabGroup tab-head">
                    <li class="TabbedPanelsTab" tabindex="0">Thông tin hồ sơ</li>
                    <li class="TabbedPanelsTab" tabindex="0">Danh mục</li>
                    <li class="TabbedPanelsTab" tabindex="0" style="display:none;">Xuất nhập dữ liệu</li>
                </ul>
                <div class="TabbedPanelsContentGroup  tab-head-content">
                    <div class="TabbedPanelsContent">
                        <div id="TabbedPanels3" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink runat="server" href="WPatron.aspx">
                                        <span class="icon-history"></span><p>Quản lý hồ sơ</p><p class="desc-button">Cập nhật sửa chữa hồ sơ.</p>    
                                    </asp:HyperLink>
                                </li>
                                   <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink  runat="server" href="WImportPatronExcel.aspx">
                                        <span class="icon-history"></span><p>Import Excell</p><p class="desc-button">Import Excel</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink runat="server" href="WSimpleSearch.aspx">
                                        <span class="icon-history"></span><p>Tra cứu</p><p class="desc-button">Tìm kiếm thông tin hồ sơ bạn đọc.</p>    
                                    </asp:HyperLink>

                                </li>
                                <li class="TabbedPanelsTab" tabindex="0" style="display:none" >
                                    <asp:HyperLink runat="server" href="WQueuList.aspx">
                                        <span class="icon-history"></span><p>Hàng đợi</p><p class="desc-button">Sửa chữa hồ sơ trong hàng đợi.</p>    
                                    </asp:HyperLink>
                                </li>
                            </ul>
                        </div>
                    </div>

                    <div class="TabbedPanelsContent">
                        <div id="TabbedPanels2" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink runat="server" href="WPatronGroup.aspx">
                                        <span class="icon-history"></span><p>Nhóm bạn đọc</p><p class="desc-button">Dạnh mục các nhóm bạn đọc.</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0" >
                                    <asp:HyperLink runat="server" href="WFaculty.aspx">
                                        <span class="icon-history"></span><p>Khoa</p><p class="desc-button">Danh mục các khoa.</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0" >
                                    <asp:HyperLink runat="server" href="WProvince.aspx">
                                        <span class="icon-history"></span><p>Tỉnh</p><p class="desc-button">Danh mục các tỉnh.</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0" >
                                    <asp:HyperLink runat="server" href="WEthnic.aspx">
                                        <span class="icon-history"></span><p>Dân tộc</p><p class="desc-button">Danh mục các dân tộc.</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0" >
                                    <asp:HyperLink runat="server" href="WEducation.aspx">
                                        <span class="icon-history"></span><p>Trình độ văn hóa</p><p class="desc-button">Danh mục trình độ.</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0" style="display:none;">
                                    <asp:HyperLink runat="server" href="WOccupation.aspx">
                                        <span class="icon-history"></span><p>Nhóm ngành nghề</p><p class="desc-button">Danh mục các nhóm ngành nghề.</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0" style="display:none;">
                                    <asp:HyperLink runat="server" href="WCollege.aspx">
                                        <span class="icon-history"></span><p>Trường</p><p class="desc-button">Danh mục các trường.</p>    
                                    </asp:HyperLink>
                                </li>
                            </ul>
                        </div>
                    </div>

                    <div class="TabbedPanelsContent" style="display:none;">
                        <div id="TabbedPanels4" class="TabbedPanels">
                            <ul class="TabbedPanelsTabGroup">
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink runat="server" href="WEETemplate.aspx">
                                        <span class="icon-history"></span><p>Khuôn dạng xuất</p><p class="desc-button">Tạo ra các khuôn dạng xuất dữ liệu.</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink runat="server" href="WExport.aspx">
                                        <span class="icon-history"></span><p>Xuất dữ liệu</p><p class="desc-button">Xuất dữ liệu theo khuôn dạng.</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink runat="server" href="WIETemplate.aspx">
                                        <span class="icon-history"></span><p>Khuôn dạng nhập</p><p class="desc-button">Tạo các khuôn dạng nhập dữ liệu.</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0">
                                    <asp:HyperLink runat="server" href="WImports.aspx">
                                        <span class="icon-history"></span><p>Nhập dữ liệu</p><p class="desc-button">Nhập dữ liệu theo khuôn dạng.</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" style="display:none" tabindex="0">
                                    <asp:HyperLink runat="server" href="WGetUsers.aspx">
                                        <span class="icon-history"></span><p>Đồng bộ tài khoản</p><p class="desc-button">Đồng bộ danh sách bạn đọc từ SSC</p>    
                                    </asp:HyperLink>
                                </li>
                                <li class="TabbedPanelsTab" tabindex="0" style="display:none;">
                                    <asp:HyperLink runat="server" href="WRequestCataloguer.aspx">
                                        <span class="icon-history"></span><p>Yêu cầu bổ sung tài liệu</p><p class="desc-button">Danh sách yêu cầu bổ sung tài liệu</p>    
                                    </asp:HyperLink>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
            var TabbedPanels2 = new Spry.Widget.TabbedPanels("TabbedPanels2");
            var TabbedPanels3 = new Spry.Widget.TabbedPanels("TabbedPanels3");
            var TabbedPanels4 = new Spry.Widget.TabbedPanels("TabbedPanels4");
        </script>
    </form>
</body>
</html>
