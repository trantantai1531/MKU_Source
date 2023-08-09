<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Patron.WImports" CodeFile="WImports.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Nhập dữ liệu</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body topmargin="0" leftmargin="0" rightmargin="0" onload="document.forms[0].ddlTemplate.focus()">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Nhập dữ liệu</h1>
            <asp:Label ID="lblViewLog" Runat="server" Width="100%" Visible="False"></asp:Label>
            <div class="main-form">
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Chọn mẫu :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:dropdownlist id="ddlTemplate" Runat="server"></asp:dropdownlist>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>File nguốn :</p>
                            <div class="input-control">
                                <div class="input-form fileAttach">
                                    <INPUT class="text-input" id="filImport" type="file" name="filImport" runat="server">
                                </div>
                            </div>
                            <div class="row-detail">
                                <div class="input-control">
                                    <p>Font chữ:</p>
                                    <div class="radio-control">
                                        <asp:radiobutton id="optTCVN" Runat="server" GroupName="Font" Text="T<u>C</u>VN"></asp:radiobutton>
                                        <asp:radiobutton id="optUnicode" Runat="server" GroupName="Font" Checked="True" Text="<u>U</u>nicode"></asp:radiobutton>
                                        <asp:radiobutton id="optVNI" Runat="server" GroupName="Font" Text="VN<u>I</u>"></asp:radiobutton>
                                    </div>
                                </div>
                            </div>
                            <div class="row-detail">
                                <div class="input-control">
                                    <p>Kiểu file:</p>
                                    <div class="radio-control">
                                        <asp:radiobutton id="optXML" Runat="server" GroupName="FileType" Text="<u>X</u>ML"></asp:radiobutton>
                                        <asp:radiobutton id="optText" Runat="server" GroupName="FileType" Checked="True" Text="Tex<u>t</u>"></asp:radiobutton>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Chỉ thị :</p>
                            <div class="row-detail">
                                <div class="checkbox-control">
                                    <asp:CheckBox ID="chkOverwrite" Runat="server" Checked="False" Text="Nhập <u>đ</u>è vào bản ghi cũ"></asp:CheckBox>
                                    <label for="chkOverwrite">Nhập đè vào bản ghi cũ</label>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Phân cách :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:textbox CssClass="text-input" id="txtSeperator" Runat="server" Width="">#</asp:textbox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="button-control inline-box">
                                <div class="button-form">
                                    <asp:Button ID="btnSetDefaultvalue" Runat="server" Text="Đặt giá trị mặc định(r)" Width=""></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-detail">
                    <div class="button-control inline-box">
                        <div class="button-form">
                            <asp:button id="btnImport" Runat="server" Text="Nhập(p)" Width=""></asp:button>
                        </div>
                        <div class="button-form">
                            <asp:button id="btnReset" Runat="server" Text="Làm lại(l)"></asp:button>
                        </div>
                    </div>
                </div>
                <div class="table-form">
                    <asp:DataGrid CssClass="table-control" ID="dgrResult" Runat="server" Width="100%" Visible="False" AutoGenerateColumns="False">
							<Columns>
								<asp:BoundColumn DataField="Code" HeaderText="Số thẻ">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FullName" HeaderText="Họ T&#234;n">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DOB" HeaderText="Ng&#224;y Sinh">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="IDCard" HeaderText="Số CMT nh&#226;n d&#226;n">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Nguy&#234;n nh&#226;n kh&#244;ng nhập bạn đọc v&#224;o database">
									<ItemTemplate>
										<asp:Label ID="lblMessage" Runat="server" Width="100%">Trùng số thẻ hoặc trùng ngày sinh và số CMT nhân dân.</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:DataGrid>
                </div>
            </div>
        </div>
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Chi tiết lỗi: </asp:ListItem>
            <asp:ListItem Value="1">Mã lỗi: </asp:ListItem>
            <asp:ListItem Value="2">Bạn không có quyền thực hiện chức năng này</asp:ListItem>
            <asp:ListItem Value="3">------Chọn mẫu nhập------</asp:ListItem>
            <asp:ListItem Value="4">Chưa chọn mẫu nhập!!!</asp:ListItem>
            <asp:ListItem Value="5">Giá trị dấu phân cách là bắt buộc</asp:ListItem>
            <asp:ListItem Value="6">Chưa chọn file nguồn</asp:ListItem>
            <asp:ListItem Value="7">Nhập được </asp:ListItem>
            <asp:ListItem Value="8">Có lỗi trong quá trình nhập dữ liệu!</asp:ListItem>
            <asp:ListItem Value="9">Nhập khẩu bản ghi</asp:ListItem>
            <asp:ListItem Value="10">File không tồn tại!</asp:ListItem>
            <asp:ListItem Value="11"> bạn đọc.Còn lại </asp:ListItem>
            <asp:ListItem Value="12"> bạn đọc. Xem dưới đây.</asp:ListItem>
            <asp:ListItem Value="13">Trùng số thẻ.</asp:ListItem>
            <asp:ListItem Value="14">Trùng ngày sinh và số chứng minh thư nhân dân.</asp:ListItem>
        </asp:DropDownList>
        <input type="hidden" id="hdValidDate" name="hdValidDate" runat="server">
        <input type="hidden" id="hdExpiredDate" name="hdExpiredDate" runat="server">
        <input type="hidden" id="hdPatronGroupID" runat="server" name="hdPatronGroupID" value="1">
        <input type="hidden" id="hdLastModifiedDate" runat="server" name="hdLastModifiedDate">
    </form>
</body>
</html>
