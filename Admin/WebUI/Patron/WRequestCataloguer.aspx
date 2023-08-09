<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WRequestCataloguer.aspx.vb" Inherits="eMicLibAdmin.WebUI.Patron.WRequestCataloguer" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Yêu cầu bổ sung tài liệu</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Yêu cầu bổ sung tài liệu</h1>
            <div class="main-form">
                <div class="three-column">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Tên: </p>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtName" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Số thẻ: </p>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtPatronCode" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Nhan đề:</p>
                            <div class="input-control">
                                <div class="input-form">
                                    <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="three-column">
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Từ ngày :<asp:hyperlink id="lnkDateFrom" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtDateFrom" Width="" Runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>Đến ngày :<asp:hyperlink id="lnkDateTo" Runat="server">&nbsp;Lịch</asp:hyperlink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input"  id="txtDateTo" Width="" Runat="server"></asp:textbox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form">
                        <div class="row-detail">
                            <p>&nbsp;</p>
                            <div class="input-control">
                                <div class="button-control">
                                    <div class="button-form">
                                        <asp:Button ID="btnSearch" runat="server" Text="Tìm(a)" Width=""></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="table-form">
                        <asp:GridView ID="dtgResult" runat="server" Width="100%" PagerStyle-Mode="NumericPages" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="ID">
                            <HeaderStyle CssClass="lbGridHeader" Height="30px" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="linkDetail" runat="server">Xem chi tiết</asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="STT" HeaderText="STT" />
                                <asp:BoundField DataField="FullName" HeaderText="Họ tên" />
                                <asp:BoundField DataField="PatronCode" HeaderText="Số thẻ" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Literal ID="LiteralContent" runat="server" Text='<%#Eval("Content") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DateInput" HeaderText="Ngày yêu cầu" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="linkDelete" runat="server">Xóa</asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Position="TopAndBottom" Mode="Numeric" />
                        </asp:GridView>
                    </div>
                </div>
            </div>

        </div>
        <asp:DropDownList ID="ddlLabel" Runat="server" Visible="False" Width="0">
			<asp:ListItem Value="0">Mã lỗi</asp:ListItem>
			<asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
			<asp:ListItem Value="2">Khuôn dạng ngày tháng không hợp lệ</asp:ListItem>
            <asp:ListItem Value="3">Bạn không được cấp quyền sử dụng tính năng này</asp:ListItem>
            <asp:ListItem Value="4">Bạn có chắc chắn muốn xóa</asp:ListItem>
            <asp:ListItem Value="5">Xóa thành công</asp:ListItem>
            <asp:ListItem Value="6">Xóa thất bại</asp:ListItem>
            <asp:ListItem Value="7">Nhan đề: </asp:ListItem>
            <asp:ListItem Value="8">Tác giả: </asp:ListItem>
            <asp:ListItem Value="9">Nhà xuất bản: </asp:ListItem>
            <asp:ListItem Value="10">Năm xuất bản: </asp:ListItem>
            <asp:ListItem Value="11">Các thông tin khác: </asp:ListItem>
		</asp:DropDownList>
        <script type="text/javascript">
            function DeleteItem(strID) {
                if (confirm("Bạn chắc chắn muốn xóa ?") == true)
                {
                    var strDateFrom = document.getElementById("txtDateFrom").value;
                    var strDateTo = document.getElementById("txtDateTo").value;
                    var strFullName = document.getElementById("txtName").value;
                    var strPatronCode = document.getElementById("txtPatronCode").value;
                    var strTitle = document.getElementById("txtTitle").value;

                    var linkRedirect = "WRequestCataloguer.aspx?DeleteId=" + strID;
                    if (strDateFrom != "") {
                        linkRedirect = linkRedirect + "&strDateFrom=" + strDateFrom;
                    }
                    if (strDateTo != "") {
                        linkRedirect = linkRedirect + "&strDateTo=" + strDateTo;
                    }
                    if (strFullName != "") {
                        linkRedirect = linkRedirect + "&strFullName=" + strFullName;
                    }
                    if (strPatronCode != "") {
                        linkRedirect = linkRedirect + "&strPatronCode=" + strPatronCode;
                    }
                    if (strTitle != "") {
                        linkRedirect = linkRedirect + "&strTitle=" + strTitle;
                    }
                    window.location.href = linkRedirect;
                }
            }

            function OpenWindow(strUrl, strWinname, intWidth, intHeight, intLeft, intTop) {
                popUp = window.open(strUrl, strWinname, "width=" + intWidth + ",height=" + intHeight + ",left=" + intLeft + ",top=" + intTop + ",menubar=no,resizable=no,scrollbars=yes");
                popUp.focus()
            }
        </script>
    </form>
</body>
</html>
