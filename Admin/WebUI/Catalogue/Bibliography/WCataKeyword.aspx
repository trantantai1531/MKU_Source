<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WCataKeyword.aspx.vb" Inherits="eMicLibAdmin.WebUI.Cataloguer.WCataKeyword" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCataKeyword</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .disable-block
        {
            background: #cfcfcf !important;
            cursor: not-allowed !important;
        }
        .enable-block
        {
            background:none !important;
            cursor:pointer !important;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Danh mục tài liệu theo từ khóa</h1>
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Dạng tài liệu</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlItemType" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="radio-control">
                                <asp:RadioButton ID="rdTextKeyword" GroupName="Keyword" Text="Nhập từ khóa" runat="server" />
                                <asp:RadioButton ID="rdDDLKeyword" GroupName="Keyword" runat="server" Text="Chọn từ khóa" />
                            </div>
                            <asp:Panel ID="PanelTextKeyword" runat="server">
                                <div class="input-control">
                                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="PanelDDLKeyword" runat="server">
                                <div class="input-control">
                                    <div class="dropdown-form" style="margin-right: 100px;">
                                        <asp:DropDownList ID="ddlKeyword" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="button-form" style="text-align:right; margin-top:-29px; margin-right:50px;">
                                        <button type="button" class="form-btn" ID="btnAddKeyword" runat="server">Thêm</button>
                                    </div>
                                    <div class="button-form" style="text-align:right; margin-top:-27px; margin-right:2px;">
                                        <asp:Button ID="btnDelKeyword" CssClass="form-btn" runat="server" Text="Xóa"></asp:Button>
                                    </div>
                                </div>
                            </asp:Panel>
                            
                        </div>
                        <div class="row-detail">
                            <div class="span4">
                                <div class="row-detail">
                                    <p>
                                        Lý do
                                    </p>
                                    <asp:TextBox ID="txtAdditionalBy" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="span4">
                                <div class="row-detail">
                                    <p>Nguồn bổ sung</p>
                                    <asp:DropDownList ID="ddlAcqSource" Width="100%" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Kiểu tư liệu :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLoanType" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail" style="margin-top:5px;">
                            <p>Kho</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLocation" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail" style="margin-top:5px; text-align:right">
                            <div class="span3">
                                <div class="row-detail">
                                    <p>Từ năm (NXB)</p>
                                    <asp:TextBox ID="txtYearFrom" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="span3">
                                <div class="row-detail">
                                    <p>Đến năm (NXB)</p>
                                    <asp:TextBox ID="txtYearTo" CssClass="" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <p>&nbsp</p>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button CssClass="form-btn" ID="btnExportData" runat="server" Text="Thống kê"></asp:Button>
                                </div>
                                <div class="button-form">
                                    <asp:Button ID="btnExportWord" CssClass="form-btn" runat="server" Text="Xuất word"></asp:Button>
                                </div>
                                <div class="button-form">
                                    <asp:Button ID="btnExportExcel" CssClass="form-btn" runat="server" Text="Xuất excel"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear:left;"></div>
            <div class="input-control">
                <div class="row-detail">
                    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                    <%--<asp:Label ID="lblCountBook" runat="server" Text=""></asp:Label><asp:Label ID="lblCountCopyNumber" runat="server" Text=""></asp:Label>--%>
                </div>
                <div class="table-form">
                    <asp:GridView ID="dtgPolicy" runat="server" AllowPaging="True" Width="100%" AutoGenerateColumns="False" PageSize="100">
                        <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                        <Columns>
                            <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true">
                                <HeaderStyle Width="5%"/>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BarCode" HeaderText="Mã vạch" ReadOnly="true">
                                <HeaderStyle Width="7.5%" HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CopyNumber" HeaderText="ĐKCB" ReadOnly="true">
                                <HeaderStyle Width="7.5%" HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Title" HeaderText="Nhan đề" ReadOnly="true">
                                <HeaderStyle Width="20%" HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Author" HeaderText="Tác giả" ReadOnly="true">
                                <HeaderStyle Width="20%" HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NXB" HeaderText="Nơi XB" ReadOnly="true">
                                <HeaderStyle Width="7.5%"  HorizontalAlign="Left"/>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Publisher" HeaderText="Nhà XB" ReadOnly="true">
                                <HeaderStyle Width="7.5%"  HorizontalAlign="Left"/>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PublishYear" HeaderText="Năm XB" ReadOnly="true">
                                <HeaderStyle Width="7.5%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ItemType" HeaderText="Số phân loại" ReadOnly="true">
                                <HeaderStyle Width="10%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Specialized" HeaderText="Ngành học" ReadOnly="true">
                                <HeaderStyle Width="7.5%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings Position="TopAndBottom" />
                    </asp:GridView>
                </div> 
                
            </div>
        </div>
        <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">STT</asp:ListItem>
            <asp:ListItem Value="1">ĐKCB</asp:ListItem>
            <asp:ListItem Value="2">Mã vạch</asp:ListItem>
            <asp:ListItem Value="3">Nhan đề</asp:ListItem>
            <asp:ListItem Value="4">Tác giả</asp:ListItem>
            <asp:ListItem Value="5">Nơi xuất bản</asp:ListItem>
            <asp:ListItem Value="6">Nhà xuất bản</asp:ListItem>
            <asp:ListItem Value="7">Năm xuất bản</asp:ListItem>
            <asp:ListItem Value="8">Số phân loại</asp:ListItem>
            <asp:ListItem Value="9">Ngành học</asp:ListItem>
        </asp:DropDownList>
        <div style="display:none">
            <input name="hidMessageBook" runat="server" type="hidden" id="hidMessageBook" value="Tổng số đầu sách: " />
            <input name="hidLeftTable" runat="server" type="hidden" id="hidLeftTable" value="THƯ VIỆN<BR/> ĐẠI HỌC QUỐC TẾ MIỀN ĐÔNG" />
            <input name="hidRightTable" runat="server" type="hidden" id="hidRightTable" value="CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM<BR/>Độc lập - Tự do - Hạnh phúc" />
            <input name="hidTitleTable" runat="server" type="hidden" id="hidTitleTable" value="BÁO CÁO DỮ LIỆU TÌM KIẾM THEO " />
            <input name="hidMessageCopyNumber" runat="server" type="hidden" id="hidMessageCopyNumber" value="Tổng số bản sách: " />
        </div>
    </form>
    <script type="text/javascript">
        function OpenWindow(strUrl, strWinname, intWidth, intHeight, intLeft, intTop) {
            popUp = window.open(strUrl, strWinname, "width=" + intWidth + ",height=" + intHeight + ",left=" + intLeft + ",top=" + intTop + ",menubar=no,resizable=no,scrollbars=yes");
            popUp.focus()
        }

        function Choise(value)
        {
            if (value == 1)
            {
                var addAttr = document.createAttribute("disabled");
                addAttr.value = "disabled";

                document.getElementById("ddlKeyword").setAttributeNode(addAttr);
                document.getElementById("ddlKeyword").setAttribute("class", "disable-block");

                document.getElementById("txtKeyword").removeAttribute("disabled");
                document.getElementById("txtKeyword").setAttribute("class", "lbTextBox enable-block");

                var addAttrStyle = document.createAttribute("style");
                addAttrStyle.value = "display:none;";
                document.getElementById("PanelDDLKeyword").setAttributeNode(addAttrStyle);

                document.getElementById("PanelTextKeyword").removeAttribute("style");
            }
            if (value == 2)
            {
                var addAttr = document.createAttribute("disabled");
                addAttr.value = "disabled";

                document.getElementById("txtKeyword").setAttributeNode(addAttr);
                document.getElementById("txtKeyword").setAttribute("class", "lbTextBox disable-block");

                document.getElementById("ddlKeyword").removeAttribute("disabled");
                document.getElementById("ddlKeyword").setAttribute("class", "enable-block");

                var addAttrStyle = document.createAttribute("style");
                addAttrStyle.value = "display:none;";
                document.getElementById("PanelTextKeyword").setAttributeNode(addAttrStyle);

                document.getElementById("PanelDDLKeyword").removeAttribute("style");
            }
        }
    </script>
</body>
</html>