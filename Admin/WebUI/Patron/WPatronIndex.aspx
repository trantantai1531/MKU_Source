<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WPatronIndex" CodeFile="WPatronIndex.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WPatronIndex</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />

    <script language="javascript">
        function GenRanNum(intNumber) {
            var str = '';
            var intCount;
            for (intCount = 1; intCount <= intNumber; intCount++) {
                str = str + (String)(parseInt(9 * Math.random() + 48));
            }
            return (str);
        }
        // Gen Image url function
        function GenURL1(strIdlength) {
            if (document.forms[0].hidControl.value > 0) {
                document.images["anh1"].src = '../Common/WChartDir.aspx?i=1&x=' + GenRanNum(strIdlength);
            }
        }
    </script>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body class="backgroundbody" style="margin-top: 0; margin-left: 0; margin-right: 0; margin-bottom: 0" onload="GenURL1(7)"
    rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">

            <div class="ClearFix main-page">
                <div class="col-left-4">
                    <div class="chart-form">
                        <h1 class="main-head-form">Thống kê</h1>
                        <asp:label id="lblStatCat" CssClass="lbFunctionDetail" Runat="server">Thống kê bạn đọc theo nhóm bạn đọc</asp:label>
                        <img id="anh1" src="" runat="server">
                        <p>

                            <script type="text/javascript">
                                //load the Google Visualization API and the chart
                                google.load('visualization', '1', { 'packages': ['columnchart', 'piechart'] });
                                //set callback
                                google.setOnLoadCallback(createChart);
                                //callback function
                                function createChart() {
                                    //create data table object
                                    var dataTable = new google.visualization.DataTable();
                                    //define columns
                                    dataTable.addColumn('string', 'Quarters');
                                    dataTable.addColumn('number', 'Visits');
                                    dataTable.addColumn('number', 'Pageviews');
                                    dataTable.addColumn('number', 'Visitors');
                                    //define rows of data
                                    dataTable.addRows([
                                                        ['1', 1037, 4152, 780],
                                                        ['2', 1116, 5951, 857],
                                                        ['3', 2439, 5183, 1924],
                                                        ['4', 3868, 7641, 3095]
                                    ]);
                                    //instantiate our chart objects
                                    var chart = new google.visualization.ColumnChart(document.getElementById('chart'));
                                    //define options for visualization
                                    var options = { width: 800, height: 400, is3D: true, title: 'VietCoding Stats' };
                                    //draw our chart
                                    chart.draw(dataTable, options);
                                }
                            </script>




                        </p>
                        <ul>
                            <li><asp:label id="lblTotalOfPatrons" CssClass="lbFunctionDetail" Runat="server">
										Tổng số bạn đọc:
									</asp:label></li>
                        </ul>
                    </div>
                </div>
                <div class="col-right-6">
                    <div class="text-column-2 ClearFix group-left">
                      
                        <div class="column-item">
                            <div class="group-menu">
                                <asp:hyperlink id="hrfPatronProfile" Runat="server" NavigateUrl="#">Hồ sơ bạn đọc</asp:hyperlink>
                                <p>Quản lý hồ sơ bạn đọc</p>
                            </div>
                            <div class="group-menu">
                                <asp:hyperlink id="hrfPatronCard" Runat="server" NavigateUrl="#">In thẻ bạn đọc</asp:hyperlink>
                                <p>Tạo mẫu thể, in thẻ, theo dõi quá trình in thẻ bạn đọc.</p>
                            </div>
                            <div class="group-menu">
                                <asp:hyperlink id="hrfBatchProcess" Runat="server" NavigateUrl="#">Xử lý theo lô</asp:hyperlink>
                                <p>Cập nhật, gia hạn, xoá thẻ bạn đọc theo lô.</p>
                            </div>
                            <div class="group-menu">
                                <asp:hyperlink id="hrfStatistic" Runat="server" NavigateUrl="#">Thông kê báo cáo</asp:hyperlink>
                                <p>Thông kê báo cáo bạn đọc.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <input type="hidden" id="hidControl" runat="server" name="hidControl" value="0">
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
            <asp:ListItem Value="3">Nhóm bạn đọc</asp:ListItem>
            <asp:ListItem Value="4">Số lượng bạn đọc</asp:ListItem>
            <asp:ListItem Value="5">Tỉ lệ % theo nhóm bạn đọc</asp:ListItem>
            <asp:ListItem Value="6">Không rõ</asp:ListItem>
            <asp:ListItem Value="7">Thống kê nhóm bạn đọc</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
