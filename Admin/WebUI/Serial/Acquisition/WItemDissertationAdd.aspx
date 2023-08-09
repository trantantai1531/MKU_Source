<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WItemDissertationAdd.aspx.vb" Inherits="eMicLibAdmin.Serial.Acquisition.WItemDissertationAdd" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>WItemDissertationAdd</title>
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
            <h1 class="main-head-form">Thêm mới</h1>
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
                        <div class="two-column">
                            <div class="two-column-form">
                                <div class="row-detail">
                                    <p>Ảnh bìa :</p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <input id="txtPathImage" type="file" Class="text-input" name="txtPathImage" runat="server"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="two-column-form">
                                <div class="row-detail">
                                    <p>File tài liệu :</p>
                                    <div class="input-control">
                                        <div class="input-form ">
                                            <input id="txtPathFile" type="file" Class="text-input" name="txtPathFile" runat="server"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="ClearFix"></div>
                <div class="three-column">
                    <div class="three-column-form"></div>
                    <div class="three-column-form">
                        <div class="row-detail" style="text-align:center">
                            <p>&nbsp</p>
                            <div class="button-control">
                                <div class="button-form">
                                    <asp:Button ID="btnUpdate" CssClass="lbButton" runat="server" Text="Cập nhật"></asp:Button>
                                </div>
                                <div class="button-form">
                                    <asp:Button id="btnClose" CssClass="lbButton" runat="server" Text="Đóng"></asp:Button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="three-column-form"></div>
                </div>
            </div>
        </div>
        <asp:Label ID="lbNumberRequired" runat="server" Text="Số không để trống" Visible="false"></asp:Label>
        <asp:Label ID="lbYearRequired" runat="server" Text="Năm không để trống" Visible="false"></asp:Label>
        <asp:Label ID="lbPathImageRequired" runat="server" Text="Ảnh mục lục chưa chọn" Visible="false"></asp:Label>
        <asp:Label ID="lbPathFileRequired" runat="server" Text="File tài liệu chưa chọn" Visible="false"></asp:Label>
        <asp:Label ID="lbValidExist" runat="server" Text="Số và năm đã tồn tại" Visible="false"></asp:Label>
        <asp:Label ID="lbCreateError" runat="server" Text="Thêm mới thất bại" Visible="false"></asp:Label>
        <asp:Label ID="lbCreateSusscess" runat="server" Text="Thêm mới thành công" Visible="false"></asp:Label>
        <asp:Label ID="lbFileNotValid" runat="server" Text="File tài liệu chỉ được dùng file pdf" Visible="false"></asp:Label>
        <asp:Label ID="lbImageNotValid" runat="server" Text="File ảnh không đúng định dạng cho phép" Visible="false"></asp:Label>
        <asp:Label ID="lbPathSave" runat="server" Text="D:\eMicLib" Visible="false"></asp:Label>
        <asp:Label ID="lbFolderImages" runat="server" Text="ImagesTT" Visible="false"></asp:Label>
        <asp:Label ID="lbFolderFiles" runat="server" Text="FilesTT" Visible="false"></asp:Label>
        <asp:HiddenField ID="hidItemId" runat="server"/>
    </form>
</body>
</html>
