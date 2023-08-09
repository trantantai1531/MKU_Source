<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WItemDissertationDetail.aspx.vb" Inherits="eMicLibAdmin.Serial.Acquisition.WItemDissertationDetail" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>WItemDissertationDetail</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .table-form table td .three-column .three-column-form
        {
            width: 32.5%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="divBody">
            <h1 class="main-head-form">Chi tiết</h1>
            <div class="main-form">
                <div class="two-column">
                    <div class="two-column-form">
                        <div class="two-column">
                            <div class="two-column-form">
                                <div class="row-detail">
                                    <p>Số :</p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:TextBox CssClass="text-input" ID="txtNumber" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="two-column-form">
                                <div class="row-detail">
                                    <p>Năm :</p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <asp:TextBox CssClass="text-input" ID="txtYear" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>&nbsp</p>
                            <div class="button-control">
                                <div class="button-form">
                                    <input type="button" ID="btnAdd" Class="lbButton" runat="server" value="Thêm mới"/>
                                </div>
                                <div class="button-form">
                                    <asp:Button ID="btnSearch" CssClass="lbButton" runat="server" Text="Tìm kiếm"></asp:Button>
                                </div>
                                <div class="button-form">
                                    <input type="reset" value="Làm lại" class="lbButton" />
                                </div>
                                <div class="button-form">
                                    <asp:Button ID="btnBack" CssClass="lbButton" runat="server" Text="Trở về danh sách"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ClearFix"></div>
                <div class="table-form">
                    <asp:GridView ID="dtgPolicy" runat="server" DataKeyNames="ID" AllowPaging="True" Width="100%" AutoGenerateColumns="False" PageSize="20">
                        <HeaderStyle CssClass="lbGridHeader" Height="30" />
                        <Columns>
                            <asp:BoundField DataField="STT" HeaderText="STT" ReadOnly="true" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="50"/>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Số" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lbNumber" runat="server" Text='<%# String.Format("{0}", DataBinder.Eval(Container.DataItem, "Number"))%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNumber" runat="server" Height="25"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Năm" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lbYear" runat="server" Text='<%# String.Format("{0}", DataBinder.Eval(Container.DataItem, "Year"))%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtYear" runat="server" Height="25"></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ảnh bìa" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:HyperLink ID="linkImage" NavigateUrl='<%# String.Format("WViewImage.aspx?strPath={0}", DataBinder.Eval(Container.DataItem, "PathImage"))%>' Target="_blank" runat="server">Xem ảnh</asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <input id="txtPathImage" type="file"  Class="text-input" name="txtPathImage" runat="server"/>
                                    <br />
                                    <asp:HyperLink ID="linkImage" NavigateUrl='<%# String.Format("WViewImage.aspx?strPath={0}", DataBinder.Eval(Container.DataItem, "PathImage"))%>' Target="_blank" runat="server">Xem ảnh</asp:HyperLink>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="File" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:HyperLink ID="linkFile" NavigateUrl='<%# String.Format("WViewFile.aspx?strPath={0}", DataBinder.Eval(Container.DataItem, "PathFile"))%>' Target="_blank" runat="server">Xem File</asp:HyperLink>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <input id="txtPathFile" type="file" Class="text-input" name="txtPathFile" runat="server"/>
                                    <br />
                                    <asp:HyperLink ID="linkFile" NavigateUrl='<%# String.Format("WViewFile.aspx?strPath={0}", DataBinder.Eval(Container.DataItem, "PathFile"))%>' Target="_blank" runat="server">Xem File</asp:HyperLink>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="Sửa" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%"
                                    UpdateText="&lt;img src=&quot;../../Images/update.gif&quot; border=&quot;0&quot;&gt;" CancelText="&lt;img src=&quot;../../Images/cancel.gif&quot; border=&quot;0&quot;&gt;"
                                    EditText="&lt;img src=&quot;../../Images/Edit2.gif&quot; border=&quot;0&quot;&gt;" ButtonType="Link" ShowEditButton="True">
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="" HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:HyperLink CssClass="link-btn" ID="linkDelete" runat="server">
                                        <img src="../../Images/Delete.gif" alt="" />
                                    </asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Position="TopAndBottom" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hidItemId" runat="server" Value="0" />
        <asp:Label ID="lbNumberRequired" runat="server" Text="Số không để trống" Visible="false"></asp:Label>
        <asp:Label ID="lbYearRequired" runat="server" Text="Năm không để trống" Visible="false"></asp:Label>
        <asp:Label ID="lbPathImageRequired" runat="server" Text="Ảnh mục lục chưa chọn" Visible="false"></asp:Label>
        <asp:Label ID="lbPathFileRequired" runat="server" Text="File tài liệu chưa chọn" Visible="false"></asp:Label>
        <asp:Label ID="lbValidExist" runat="server" Text="Số và năm đã tồn tại" Visible="false"></asp:Label>
        <asp:Label ID="lbInputValid" runat="server" Text="Nội dung nhập tìm kiếm không hợp lệ" Visible="false"></asp:Label>
        <asp:Label ID="lbDeleteError" runat="server" Text="Xóa thất bại" Visible="false"></asp:Label>
        <asp:Label ID="lbDeleteSuccess" runat="server" Text="Xóa thành công" Visible="false"></asp:Label>
        <asp:Label ID="lbUpdateError" runat="server" Text="Cập nhật thất bại" Visible="false"></asp:Label>
        <asp:Label ID="lbUpdateSuccess" runat="server" Text="Cập nhật thành công" Visible="false"></asp:Label>
        <asp:Label ID="lbPathSave" runat="server" Text="D:\eMicLib" Visible="false"></asp:Label>
        <asp:Label ID="lbFolderImages" runat="server" Text="ImagesTT" Visible="false"></asp:Label>
        <asp:Label ID="lbFolderFiles" runat="server" Text="FilesTT" Visible="false"></asp:Label>
        <asp:Label ID="lbFileNotValid" runat="server" Text="File tài liệu chỉ được dùng file pdf" Visible="false"></asp:Label>
        <asp:Label ID="lbImageNotValid" runat="server" Text="File ảnh không đúng định dạng cho phép" Visible="false"></asp:Label>
        <script type="text/javascript">
            function OpenWindow(intItemId) {
                popUp = window.open("WItemDissertationAdd.aspx?ItemID=" + intItemId, "WItemDissertationAdd", "width=800,height=600,left=200,top=100,menubar=no,resizable=no,scrollbars=yes");
                popUp.focus()
            }
            function DeleteItem(strItemID, strID) {
                if (confirm("Bạn chắc chắn muốn xóa ?") == true) {
                    var linkRedirect = "WItemDissertationDetail.aspx?ItemID=" + strItemID + "&DeleteId=" + strID;
                    window.location.href = linkRedirect;
                }
            }
        </script>
    </form>
</body>
</html>
