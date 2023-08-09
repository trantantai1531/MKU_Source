<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WCataSH.aspx.vb" Inherits="eMicLibAdmin.WebUI.Cataloguer.WCataSH" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCataSH</title>
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
                <h1 class="main-head-form">DANH MỤC TÀI LIỆU THEO NGÀNH</h1>
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
                                <asp:RadioButton ID="rdTextSH" GroupName="Keyword" Text="Nhập từ khóa" runat="server" />
                                <asp:RadioButton ID="rdDDLSH" GroupName="Keyword" runat="server" Text="Chọn từ khóa" />
                            </div>
                            <asp:Panel ID="PanelTextSH" runat="server">
                                <div class="input-control">
                                    <asp:TextBox ID="txtSH" runat="server"></asp:TextBox>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="PanelDDLSH" runat="server">
                                <div class="input-control">
                                    <div class="dropdown-form" style="margin-right: 100px;">
                                        <asp:DropDownList ID="ddlSH" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="button-form" style="text-align:right; margin-top:-29px; margin-right:50px;">
                                        <button type="button" class="form-btn" ID="btnAddSH" runat="server">Thêm</button>
                                    </div>
                                    <div class="button-form" style="text-align:right; margin-top:-27px; margin-right:2px;">
                                        <asp:Button ID="btnDelSH" CssClass="form-btn" runat="server" Text="Xóa"></asp:Button>
                                    </div>
                                </div>
                            </asp:Panel>
                            
                        </div>
                        <div class="two-column ClearFix" style="display:none">
                            <div class="two-column-form">
                                <div class="two-column ClearFix">
                                    <div class="two-column-form">
                                        <div class="row-detail">
                                            <p>Nguồn bổ sung</p>
                                            <asp:DropDownList ID="ddlAcqSource" Width="100%" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="two-column-form">
                                        <div class="row-detail">
                                            <p>Lý do</p>
                                            <asp:TextBox ID="txtAdditionalBy" CssClass="" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="two-column-form">
                                <div class="two-column ClearFix">
                                    <div class="two-column-form">
                                        <div class="row-detail">
                                            <p>Từ năm (NXB)</p>
                                            <asp:TextBox ID="txtYearFrom" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="two-column-form">
                                        <div class="row-detail">
                                            <p>Đến năm (NXB)</p>
                                            <asp:TextBox ID="txtYearTo" CssClass="" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">
                        <div class="row-detail" style="display:none">
                            <p>Kiểu tư liệu :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLoanType" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail" style="margin-top:5px;" style="display:none">
                            <p>Kho</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLocation" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="three-column ClearFix">
                            <div class="three-column-form" style="display:none">
                                <div class="row-detail">
                                    <p>Từ ngày :<asp:hyperlink id="lnkDateFrom" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:textbox CssClass="text-input"  id="txtDateFrom" Width="" Runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="three-column-form" style="display:none">
                                <div class="row-detail">
                                    <p>Đến ngày :<asp:hyperlink id="lnkDateTo" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:textbox CssClass="text-input"  id="txtDateTo" Width="" Runat="server"></asp:textbox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="three-column-form" style="display:none">
                                <div class="row-detail">
                                    <p>Khoa</p>
                                    <div class="input-control">
                                        <div class="dropdown-form">
                                            <asp:DropDownList ID="ddlFaculty" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                </div>
                <div class="ClearFix">
                    <div class="row-detail" style="text-align:right">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:Button CssClass="form-btn" ID="btnExportData" runat="server" Text="Thống kê"></asp:Button>
                            </div>
                            <div class="button-form" style="display:none">
                                <asp:Button ID="btnExportWord" CssClass="form-btn" runat="server" Text="Xuất word"></asp:Button>
                            </div>
                            <div class="button-form">
                                <asp:Button ID="btnExportExcel" CssClass="form-btn" runat="server" Text="Xuất excel"></asp:Button>
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
                            <asp:BoundField DataField="CopyNumber" HeaderText="ĐKCB" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BarCode" HeaderText="Mã vạch" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Title" HeaderText="Nhan đề" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Author" HeaderText="Tác giả" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NXB" HeaderText="Nơi XB" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Left"/>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Publisher" HeaderText="Nhà XB" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Left"/>
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PublishYear" HeaderText="Năm XB" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Classification" HeaderText="Số phân loại" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Specialized" HeaderText="Ngành học" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ItemType" HeaderText="Dạng tài liệu" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AcqSource" HeaderText="Nguồn bổ sung" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AdditionalBy" HeaderText="Lý do bổ sung" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LoanType" HeaderText="Kiểu tư liệu" ReadOnly="true">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LocationName" HeaderText="Kho" ReadOnly="true">
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
            <asp:ListItem Value="10">Dạng tài liệu</asp:ListItem>
            <asp:ListItem Value="11">Nguồn bổ sung</asp:ListItem>
            <asp:ListItem Value="12">Lý do bổ sung</asp:ListItem>
            <asp:ListItem Value="13">Kiểu tư liệu</asp:ListItem>
            <asp:ListItem Value="14">Kho</asp:ListItem>
        </asp:DropDownList>
        <div style="display:none">
            <input name="hidMessageBook" runat="server" type="hidden" id="hidMessageBook" value="Tổng số đầu sách: " />
            <input name="hidLeftTable" runat="server" type="hidden" id="hidLeftTable" value="THƯ VIỆN<BR/> ĐẠI HỌC QUỐC TẾ MIỀN ĐÔNG" />
            <input name="hidRightTable" runat="server" type="hidden" id="hidRightTable" value="CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM<BR/>Độc lập - Tự do - Hạnh phúc" />
            <input name="hidTitleTable" runat="server" type="hidden" id="hidTitleTable" value="BÁO CÁO DỮ LIỆU TÌM KIẾM THEO " />
            <input name="hidMessageCopyNumber" runat="server" type="hidden" id="hidMessageCopyNumber" value="Tổng số bản sách: " />

			<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
				<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
				<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
				<asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
                <asp:ListItem Value="3">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
			</asp:DropDownList>
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

                document.getElementById("ddlSH").setAttributeNode(addAttr);
                document.getElementById("ddlSH").setAttribute("class", "disable-block");

                document.getElementById("txtSH").removeAttribute("disabled");
                document.getElementById("txtSH").setAttribute("class", "lbTextBox enable-block");

                var addAttrStyle = document.createAttribute("style");
                addAttrStyle.value = "display:none;";
                document.getElementById("PanelDDLSH").setAttributeNode(addAttrStyle);

                document.getElementById("PanelTextSH").removeAttribute("style");
            }
            if (value == 2)
            {
                var addAttr = document.createAttribute("disabled");
                addAttr.value = "disabled";

                document.getElementById("txtSH").setAttributeNode(addAttr);
                document.getElementById("txtSH").setAttribute("class", "lbTextBox disable-block");

                document.getElementById("ddlSH").removeAttribute("disabled");
                document.getElementById("ddlSH").setAttribute("class", "enable-block");

                var addAttrStyle = document.createAttribute("style");
                addAttrStyle.value = "display:none;";
                document.getElementById("PanelTextSH").setAttributeNode(addAttrStyle);

                document.getElementById("PanelDDLSH").removeAttribute("style");
            }
        }
    </script>
</body>
</html>