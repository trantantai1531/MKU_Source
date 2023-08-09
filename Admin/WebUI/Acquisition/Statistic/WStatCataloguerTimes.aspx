<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WStatCataloguerTimes.aspx.vb" Inherits="eMicLibAdmin.WebUI.Acquisition.WStatCataloguerTimes" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">

<html>
<head>
    <title>WStatCataloguerTimes</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Thống kê biên mục theo thời gian</h1>
                <div class="row-detail">
                    <div class="two-column">
                        <div class="two-column-form">
                            <table width="100%" border="0">
                                <tr>
                                    <td style="width:120px">
                                        <div class="row-detail">
                                            <p>Từ ngày :<asp:hyperlink id="lnkDateFrom" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:textbox CssClass="text-input"  id="txtDateFrom" Width="" Runat="server"></asp:textbox>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                    <td style="width:120px">
                                        <div class="row-detail">
                                            <p>Đến ngày :<asp:hyperlink id="lnkDateTo" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                                            <div class="input-control">
                                                <div class="input-form ">
                                                    <asp:textbox CssClass="text-input"  id="txtDateTo" Width="" Runat="server"></asp:textbox>
                                                </div>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="two-column-form">
                            <div class="row-detail" style="margin-top:1px;">
                                <p>&nbsp</p>
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button CssClass="form-btn" ID="btnStatic" runat="server" Text="Thống kê"></asp:Button>
                                    </div>
                                    <div class="button-form">
                                        <asp:Button CssClass="form-btn" ID="btnExport" runat="server" Text="Xuất file"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
             
            <div class="ClearFix"></div>
            <div class="table-form">
                <asp:GridView ID="dtgResult" runat="server" AllowPaging="True" Width="100%" AutoGenerateColumns="False" PageSize="50">
                    <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                    <Columns>
                        <asp:BoundField HeaderText="STT" ItemStyle-HorizontalAlign="Center" DataField="STT" HeaderStyle-Width="5%"/>
                        <asp:BoundField HeaderText="Ngày biên mục" ItemStyle-HorizontalAlign="Center" DataField="DateCreate"/>
                        <asp:BoundField HeaderText="Nhân viên biên mục" ItemStyle-HorizontalAlign="Center" DataField="NameCreate"/>
                        <asp:BoundField HeaderText="Loại sách" ItemStyle-HorizontalAlign="Center" DataField="LoanType"/>
                        <asp:BoundField HeaderText="ĐKCB" ItemStyle-HorizontalAlign="Center" DataField="CopyNumber"/>
                        <asp:BoundField HeaderText="Mã vạch" ItemStyle-HorizontalAlign="Center" DataField="Barcode"/>
                        <asp:BoundField HeaderText="Nhan đề" ItemStyle-HorizontalAlign="Center" DataField="Content"/>
                        <asp:BoundField HeaderText="Tác giả" ItemStyle-HorizontalAlign="Center" DataField="Author"/>
                        <asp:BoundField HeaderText="Nơi XB" ItemStyle-HorizontalAlign="Center" DataField="PublishPlace"/>
                        <asp:BoundField HeaderText="Nhà XB" ItemStyle-HorizontalAlign="Center" DataField="Publisher"/>
                        <asp:BoundField HeaderText="Năm XB" ItemStyle-HorizontalAlign="Center" DataField="PublishYear"/>
                        <asp:BoundField HeaderText="Số phân loại" ItemStyle-HorizontalAlign="Center" DataField="ClassifyIndex"/>
                        <asp:BoundField HeaderText="Ngành học" ItemStyle-HorizontalAlign="Center" DataField="Majors"/>
                    </Columns>
                    <PagerSettings Position="Bottom" />
                </asp:GridView>
            </div> 
        </div>
		<asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
			<asp:ListItem Value="0">Mã lỗi: </asp:ListItem>
			<asp:ListItem Value="1">Chi tiết lỗi: </asp:ListItem>
			<asp:ListItem Value="2">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
			<asp:ListItem Value="3">Dữ liệu phải là kiểu số nguyên</asp:ListItem>
			<asp:ListItem Value="4">Mã biểu ghi</asp:ListItem>
			<asp:ListItem Value="5">Số lượt mượn</asp:ListItem>
			<asp:ListItem Value="6">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
		</asp:DropDownList>
            
            
        <asp:DropDownList runat="server" ID="ddlLabelHeaderTable" Visible="False" Height="0" Width="0">
            <asp:ListItem Value="0">STT</asp:ListItem>
            <asp:ListItem Value="1">Ngày biên mục</asp:ListItem>
            <asp:ListItem Value="2">Nhân viên biên mục</asp:ListItem>
            <asp:ListItem Value="3">Loại sách</asp:ListItem>
            <asp:ListItem Value="4">ĐKCB</asp:ListItem>
            <asp:ListItem Value="5">Mã vạch</asp:ListItem>
            <asp:ListItem Value="6">Nhan đề</asp:ListItem>
            <asp:ListItem Value="7">Tác giả</asp:ListItem>
            <asp:ListItem Value="8">Nơi XB</asp:ListItem>
            <asp:ListItem Value="9">Nhà XB</asp:ListItem>
            <asp:ListItem Value="10">Năm XB</asp:ListItem>
            <asp:ListItem Value="11">Số phân loại</asp:ListItem>
            <asp:ListItem Value="12">Ngành học</asp:ListItem>
        </asp:DropDownList>
        <script language="javascript" type="text/javascript">
            document.forms[0].txtDateFrom.focus();
		</script>
    </form>
</body>
</html>
