<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WOverCatalogue" CodeFile="WOverViewCatalogue.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WOverCatalogue</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/style.css" type="text/css" rel="StyleSheet">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script language="javascript">
        function GenRanNum(strIdlength) {
            var str;
            str = '';
            for (i = 1; i <= strIdlength; i++) {
                str = str + (String)(parseInt(9 * Math.random() + 48));
            }
            return (str);
        }
        function GenURLImg2(intNumber) {
            if (document.forms[0].hidControl.value > 0) {
                document.images["anh1"].src = '../Common/WChartDir.aspx?i=1&x=' + GenRanNum(intNumber);
            }
        }
    </script>
</head>
<body class="backgroundbody" style="margin-top: 0; margin-left: 0; margin-right: 0; margin-bottom: 0" onload="GenURLImg2(7);parent.document.getElementById('frmMain').setAttribute('rows','*,0');">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-page ClearFix">
                <div class="col-left-4">
                    <div class="chart-form">
                        <asp:Label ID="lblRectStat" runat="server" CssClass="lbRectStatistic main-head-form">Thống kê</asp:Label>
                        <p>Thống kê bản ấn phẩm theo dạng tài liệu</p>
                        <img id="anh1" src="" runat="server">
                        <ul>
                            <li style="display:none;">
                                <asp:Label ID="lblTotalRecords_Soluoc" runat="server" CssClass="lbFunctionDetail">Số lượng bản ghi biên mục sơ lược: </asp:Label></li>
                            <li style="display:none;">
                                <asp:Label ID="lblTotalRecords_Review" runat="server" CssClass="lbFunctionDetail">Số lượng bản ghi biên mục chờ duyệt: </asp:Label></li>
                            <li style="display:none;">
                                <asp:Label ID="lblTotalRecords_Bib" runat="server" CssClass="lbFunctionDetail">Số lượng bản biên mục: </asp:Label></li>
                            <li style="display:none;">
                                <asp:Label ID="lblTotalRecords_Aut" runat="server" CssClass="lbFunctionDetail">Số lượng bản biên mục căn cứ: </asp:Label></li>
                            <li>
                                <asp:Label ID="lblTotalItems" runat="server" CssClass="lbFunctionDetail">Tổng số biểu ghi biên mục: </asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="lblTotalItemsQueue" runat="server" CssClass="lbFunctionDetail">Tổng số ấn phẩm chờ biên mục: </asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="lblTotalItemsSendLocation" runat="server" CssClass="lbFunctionDetail">Tổng số bản ấn phẩm biên mục đã chuyển ra kho: </asp:Label>
                            </li>
                            <li>
                                <asp:Label ID="lblTotalItemsWaitSendLocation" runat="server" CssClass="lbFunctionDetail">Tổng số bản ấn phẩm biên mục chưa chuyển ra kho: </asp:Label>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-right-6">
                    <div class="text-column-2 ClearFix group-left">
                       
                        <div class="column-item">
                            <div class="group-menu">
                                <asp:HyperLink ID="lnkBibliographic" runat="server" NavigateUrl="#">Dữ liệu thư mục</asp:HyperLink>
                                <p>Các chức năng liên quan đến các bản ghi biên mục của dữ liệu thư mục.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="lnkIndex" runat="server" NavigateUrl="#">Từ điển, chỉ mục</asp:HyperLink>
                                <p>Quản lý các chỉ mục dựng sẵn và từ điển từ tạo.</p>
                            </div>
                            <div class="group-menu">
                                <asp:HyperLink ID="lnkBibliographies" runat="server" NavigateUrl="#">Danh mục</asp:HyperLink>
                                <p>Tạo sản phẩm đầu ra cho dữ liệu biên mục.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <input id="hidControl" type="hidden" value="0" name="hidControl" runat="server">
    </form>
</body>
</html>
