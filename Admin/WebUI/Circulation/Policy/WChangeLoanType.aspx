<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Circulation.WChangeLoanType" CodeFile="WChangeLoanType.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WChangeLoanType</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body topmargin="0" leftmargin="0" oncontextmenu="return true;">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Xem và thay đổi dạng tài liệu lưu thông</h1>
            <div class="main-form">
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Nhan đề :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtTitle" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Nhà xuất bản :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtPublisher" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>ISBN :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtISBN" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Dạng tài liệu (lưu thông) :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlLoanType" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Tác giả :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtAuthor" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Năm xuất bản :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtPublishYear" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>ĐKCB :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtCopyNumber" runat="server" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnSearch" runat="server" Text="Tìm(f)" Width=""></asp:Button>
                                </div>
                                <div class="button-form">
                                    <asp:Button ID="btnReset" runat="server" Text="Làm lại(r)" Width=""></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:label id="lblListCopyNumber" runat="server" CssClass="lbSubFormTitle"> Danh sách ĐKCB</asp:label>
                <div class="table-form">
                    <asp:datagrid CssClass="table-control" id="dtgHolding" runat="server" Width="100%" PageSize="10" AllowPaging="True" AutoGenerateColumns="False">
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="CopyNumber" HeaderText="ĐKCB" ItemStyle-Width="10%"></asp:BoundColumn>
								<asp:BoundColumn DataField="LoanType" HeaderText="Dạng tài liệu (lưu thông)" ItemStyle-Width="10%"></asp:BoundColumn>
								<asp:BoundColumn DataField="Content" HeaderText="Nhan đề"></asp:BoundColumn>
								<asp:BoundColumn DataField="strHolding" HeaderText="Thư viện/Kho/Giá">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="strInUsed" HeaderText="Đang mượn" ItemStyle-HorizontalAlign="Center">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="UseCount" HeaderText="Số lượt mượn" ItemStyle-HorizontalAlign="Center">
									<HeaderStyle Width="6%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="strLastUsed" HeaderText="Ngày mượn cuối">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn ItemStyle-HorizontalAlign="Center" ItemStyle-Width="3%" HeaderText="Chọn">
									<HeaderTemplate>
										<input class="lbCheckBox" type="checkbox" id="CheckAll" onclick="javascript: CheckAllOptionsVisible_1('dtgHolding', 'chkHoldingID', 3, 10);">
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox Runat="server" ID="chkHoldingID"></asp:CheckBox>
                                        <label for="chkHoldingID"></label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Position="Top" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
                </div>
                <div class="row-detail">
                    <asp:label id="lblMerge" runat="server"><U>C</U>huyển thành dạng tài liệu (lưu thông):</asp:label>&nbsp;
                    <div class="input-control"  style="width:20%; display:inline-block;">
                    <div class="dropdown-form">
						<asp:dropdownlist id="ddlNewLoanType" runat="server"></asp:dropdownlist>

                    </div></div>
						<asp:button id="btnMerge" runat="server" Text="Chuyển(c)" Width=""></asp:button>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Thay đổi dạng tài liệu lưu thông</asp:ListItem>
            <asp:ListItem Value="3">---------- Chọn ----------</asp:ListItem>
            <asp:ListItem Value="4">Không có dữ liệu thoả mãn điều kiện tìm kiếm!</asp:ListItem>
            <asp:ListItem Value="5">Bạn chưa chọn dạng tư liệu đích!</asp:ListItem>
            <asp:ListItem Value="6">Bạn chưa chọn đăng kí cá biệt!</asp:ListItem>
            <asp:ListItem Value="7">Bạn phải nhập ít nhất một điều kiện tìm kiếm!</asp:ListItem>
            <asp:ListItem Value="8">thành công!</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script language="javascript">
        document.forms[0].txtTitle.focus();
    </script>
</body>
</html>
