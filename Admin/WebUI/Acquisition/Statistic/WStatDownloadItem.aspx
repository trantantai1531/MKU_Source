<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatDownloadItem.aspx.vb" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatDownloadItem" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WStatDownLoadItem</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
        <script type="text/javascript" language="javascript">
            window.addEventListener("load", function () {
                GenURLImg(9);
            }, false);

        </script>
    </head>
    <body leftmargin="0" topmargin="0" onload="GenURLImg(9)" rightmargin="0">
        <form id="Form1" method="post" runat="server">
            <div id="divBody">
                <asp:Label ID="lblTitle" CssClass="main-head-form" Width="100%" runat="server">Thống kê lượt tải tài liệu điện tử</asp:Label>
                <div class="main-form ClearFix">
                    <div class="row-detail">
                        <table width="100%" border="0">
                            <tr>
                                <td>
                                    <table width="100%" border="0">
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rdNgay" GroupName="TypeSearch" runat="server" Text="Theo ngày" />
                                                <asp:RadioButton ID="rdTuan" GroupName="TypeSearch" runat="server" Text="Theo tuần" />
                                                <asp:RadioButton ID="rdThang" GroupName="TypeSearch" runat="server" Text="Theo tháng" />
                                                <asp:RadioButton ID="rdNam" GroupName="TypeSearch" runat="server" Text="Theo năm" />
                                                <asp:RadioButton ID="rdOther" GroupName="TypeSearch" runat="server" Text="Tùy chọn" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <asp:RadioButton ID="rdStaticItemFile" GroupName="TypeStatic" Checked="true" runat="server" Text="Theo tài liệu" />
                                    <asp:RadioButton ID="rdStaticPatron" GroupName="TypeStatic" runat="server" Text="Theo bạn đọc" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="PanelNgay" runat="server">
                                        <table width="100%" border="0">
                                            <tr>
                                                <td style="width:120px">
                                                    <p>Tháng</p>
                                                    <div class="input-control">
                                                        <div class="dropdown-form">
                                                            <asp:DropDownList ID="ddlMonth" runat="server">
                                                                <asp:ListItem Value="1">1</asp:ListItem>
                                                                <asp:ListItem Value="2">2</asp:ListItem>
                                                                <asp:ListItem Value="3">3</asp:ListItem>
                                                                <asp:ListItem Value="4">4</asp:ListItem>
                                                                <asp:ListItem Value="5">5</asp:ListItem>
                                                                <asp:ListItem Value="6">6</asp:ListItem>
                                                                <asp:ListItem Value="7">7</asp:ListItem>
                                                                <asp:ListItem Value="8">8</asp:ListItem>
                                                                <asp:ListItem Value="9">9</asp:ListItem>
                                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                                <asp:ListItem Value="11">11</asp:ListItem>
                                                                <asp:ListItem Value="12">12</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td style="width:120px">
                                                    <p>Năm</p>
                                                    <div class="input-control">
                                                        <div class="input-form ">
                                                            <asp:textbox CssClass="text-input"  id="txtDayYear" Width="" Runat="server"></asp:textbox>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="PanelTuan" runat="server">
                                        <table width="100%" border="0">
                                            <tr>
                                                <td style="width:120px">
                                                    <p>Tuần Từ</p>
                                                    <div class="input-control">
                                                        <div class="input-form ">
                                                            <asp:textbox CssClass="text-input"  id="txtWeekFrom" Width="" Runat="server"></asp:textbox>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td style="width:120px">
                                                    <p>Đến</p>
                                                    <div class="input-control">
                                                        <div class="input-form ">
                                                            <asp:textbox CssClass="text-input"  id="txtWeekTo" Width="" Runat="server"></asp:textbox>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td style="width:120px">
                                                    <p>Năm</p>
                                                    <div class="input-control">
                                                        <div class="input-form ">
                                                            <asp:textbox CssClass="text-input"  id="txtWeekYear" Width="" Runat="server"></asp:textbox>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="PanelThang" runat="server">
                                        <table width="100%" border="0">
                                            <tr>
                                                <td style="width:120px">
                                                    <p>Năm</p>
                                                    <div class="input-control">
                                                        <div class="input-form ">
                                                            <asp:textbox CssClass="text-input"  id="txtMonthYear" Width="" Runat="server"></asp:textbox>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="PanelNam" runat="server">
                                        <table width="100%" border="0">
                                            <tr>
                                                <td style="width:120px">
                                                    <p>Năm Từ</p>
                                                    <div class="input-control">
                                                        <div class="input-form ">
                                                            <asp:textbox CssClass="text-input"  id="txtYearFrom" Width="" Runat="server"></asp:textbox>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td style="width:120px">
                                                    <p>Đến</p>
                                                    <div class="input-control">
                                                        <div class="input-form ">
                                                            <asp:textbox CssClass="text-input"  id="txtYearTo" Width="" Runat="server"></asp:textbox>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel ID="PanelOther" runat="server">
                                        <table width="100%" border="0">
                                            <tr>
                                                <td style="width:120px">
                                                    <p>Từ ngày :<asp:hyperlink id="lnkDateFrom" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                                    <div class="input-control">
                                                        <div class="input-form ">
                                                            <asp:textbox CssClass="text-input"  id="txtDateFrom" Width="" Runat="server"></asp:textbox>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td style="width:120px">
                                                    <p>Đến ngày :<asp:hyperlink id="lnkDateTo" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                                    <div class="input-control">
                                                        <div class="input-form ">
                                                            <asp:textbox CssClass="text-input"  id="txtDateTo" Width="" Runat="server"></asp:textbox>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td align="right">
                                    <p>&nbsp</p>
                                    <div class="button-control">
                                        <div class="button-form">
                                            <asp:Button ID="btnStatic" runat="server" Text="Thống kê(t)"></asp:Button>
                                        </div>
                                        <div class="button-form">
                                            <asp:Button ID="btnCancel" runat="server" Text="Đặt lại(r)"></asp:Button>
                                        </div>
                                        <div class="button-form">
                                            <asp:Button ID="btnExport" runat="server" Text="Xuất file(t)"></asp:Button>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            
                        </table>
                    </div>

                    <div class="ClearFix">
                        <asp:Panel ID="PanelStatistic" runat="server" Width="100%">
                            <div class="row-detail" style="text-align: center">
                                <asp:Label ID="lblSubTitle" Width="100%" runat="server" CssClass="lbGroupTitle"></asp:Label>
                            </div>
                            <div class="row-detail" style="text-align: center">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình cột</p>
                                <img id="image1" src="" border="0" name="Image1" runat="server">
                                <asp:Label ID="lblNostatic" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                            <div class="row-detail" style="text-align: center">
                                <p style="text-transform: uppercase; color: #CCA809;">Biểu đồ hình tròn</p>
                                <img id="image2" src="" border="0" name="Image2" runat="server">
                                <asp:Label ID="lblNostatic1" runat="server">Không có thông tin thống kê !</asp:Label>
                            </div>
                        </asp:Panel>
                        
                    </div>
                </div>
            </div>
            <asp:DropDownList ID="ddlLabelValue" runat="server" Visible="False" Height="0" Width="0">
                <asp:ListItem Value="0">Chi tiết lỗi</asp:ListItem>
                <asp:ListItem Value="1">Mã lỗi</asp:ListItem>
                <asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
                <asp:ListItem Value="3">Giá trị trường còn rỗng !</asp:ListItem>
				<asp:ListItem Value="4">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
				<asp:ListItem Value="5">Số lượng TLĐT tải</asp:ListItem>
				<asp:ListItem Value="6">Mã bạn đọc</asp:ListItem>
            </asp:DropDownList>
            <input id="hidHave" runat="server" type="hidden" value="1" name="hidHave">
            <asp:HiddenField ID="hidTitleChart" runat="server" Value="Biểu đồ thống kê lượt tải tài liệu điện tử" />
            <asp:DropDownList ID="ddlLog" Runat="server" Visible="False">
				<asp:ListItem Value="MainLog">Thống kê lượt tải tài liệu điện tử</asp:ListItem>
				<asp:ListItem Value="ErrorMsg">Chi tiết lỗi </asp:ListItem>
				<asp:ListItem Value="ErrorCode">Mã lỗi </asp:ListItem>
			</asp:DropDownList>
        </form>

        <script type="text/javascript">
            function Choise(value) {
                if (value == 1) {
                    //var addAttr = document.createAttribute("disabled");
                    //addAttr.value = "disabled";

                    //document.getElementById("ddlKeyword").setAttributeNode(addAttr);
                    //document.getElementById("ddlKeyword").setAttribute("class", "disable-block");

                    //document.getElementById("txtKeyword").removeAttribute("disabled");
                    //document.getElementById("txtKeyword").setAttribute("class", "lbTextBox enable-block");

                    document.getElementById("PanelTuan").setAttribute("style", "display:none;");
                    document.getElementById("PanelThang").setAttribute("style", "display:none;");
                    document.getElementById("PanelNam").setAttribute("style", "display:none;");
                    document.getElementById("PanelOther").setAttribute("style", "display:none;");

                    document.getElementById("PanelNgay").removeAttribute("style");
                }
                if (value == 2) {
                    //var addAttr = document.createAttribute("disabled");
                    //addAttr.value = "disabled";

                    //document.getElementById("txtKeyword").setAttributeNode(addAttr);
                    //document.getElementById("txtKeyword").setAttribute("class", "lbTextBox disable-block");

                    //document.getElementById("ddlKeyword").removeAttribute("disabled");
                    //document.getElementById("ddlKeyword").setAttribute("class", "enable-block");

                    document.getElementById("PanelNgay").setAttribute("style", "display:none;");
                    document.getElementById("PanelThang").setAttribute("style", "display:none;");
                    document.getElementById("PanelNam").setAttribute("style", "display:none;");
                    document.getElementById("PanelOther").setAttribute("style", "display:none;");

                    document.getElementById("PanelTuan").removeAttribute("style");
                }

                if (value == 3) {
                    //var addAttr = document.createAttribute("disabled");
                    //addAttr.value = "disabled";

                    //document.getElementById("txtKeyword").setAttributeNode(addAttr);
                    //document.getElementById("txtKeyword").setAttribute("class", "lbTextBox disable-block");

                    //document.getElementById("ddlKeyword").removeAttribute("disabled");
                    //document.getElementById("ddlKeyword").setAttribute("class", "enable-block");

                    document.getElementById("PanelNgay").setAttribute("style", "display:none;");
                    document.getElementById("PanelTuan").setAttribute("style", "display:none;");
                    document.getElementById("PanelNam").setAttribute("style", "display:none;");
                    document.getElementById("PanelOther").setAttribute("style", "display:none;");

                    document.getElementById("PanelThang").removeAttribute("style");
                }

                if (value == 4) {
                    //var addAttr = document.createAttribute("disabled");
                    //addAttr.value = "disabled";

                    //document.getElementById("txtKeyword").setAttributeNode(addAttr);
                    //document.getElementById("txtKeyword").setAttribute("class", "lbTextBox disable-block");

                    //document.getElementById("ddlKeyword").removeAttribute("disabled");
                    //document.getElementById("ddlKeyword").setAttribute("class", "enable-block");

                    document.getElementById("PanelNgay").setAttribute("style", "display:none;");
                    document.getElementById("PanelTuan").setAttribute("style", "display:none;");
                    document.getElementById("PanelThang").setAttribute("style", "display:none;");
                    document.getElementById("PanelOther").setAttribute("style", "display:none;");

                    document.getElementById("PanelNam").removeAttribute("style");
                }


                if (value == 5) {
                    //var addAttr = document.createAttribute("disabled");
                    //addAttr.value = "disabled";

                    //document.getElementById("txtKeyword").setAttributeNode(addAttr);
                    //document.getElementById("txtKeyword").setAttribute("class", "lbTextBox disable-block");

                    //document.getElementById("ddlKeyword").removeAttribute("disabled");
                    //document.getElementById("ddlKeyword").setAttribute("class", "enable-block");

                    document.getElementById("PanelNgay").setAttribute("style", "display:none;");
                    document.getElementById("PanelTuan").setAttribute("style", "display:none;");
                    document.getElementById("PanelThang").setAttribute("style", "display:none;");
                    document.getElementById("PanelNam").setAttribute("style", "display:none;");

                    document.getElementById("PanelOther").removeAttribute("style");
                }
            }
        </script>
    </body>
</html>
