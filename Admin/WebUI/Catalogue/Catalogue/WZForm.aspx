<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WZForm" EnableViewState="False" EnableViewStateMac="False" CodeFile="WZForm.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Tìm kiếm qua Z3950</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="1" onload="document.forms[0].txtFieldValue1.focus()">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Nhập khẩu bản ghi từ tệp</h1>
                <div class="two-column ClearFix">
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Tên máy chủ Z39.50 :
                                <asp:HyperLink ID="lnkZServerList" runat="server">Danh sách</asp:HyperLink></p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtzServer" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Cổng dịch vụ :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtZPort" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tên cơ sở dữ liệu :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtZDatabase" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tên :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtName" runat="server" Width=""></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Mật khẩu :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtPass" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="two-column-form">
                        <div class="row-detail">
                            <asp:Label ID="lblComment" runat="server">Cách xử lý những bản ghi trùng với bản ghi có sẵn trong cơ sở dữ liệu (dựa trên ISBN, ISSN):</asp:Label><br />
                            <div class="row-detail">
                                <div class="radio-control">
                                    <div class="row-detail">
                                        <asp:RadioButton ID="optNotImport" runat="server" Text="<U>K</U>hông nhập khẩu" GroupName="optChoice"
                                            Checked="True"></asp:RadioButton>
                                        <label for="optNotImport"></label>
                                    </div>
                                    <div class="row-detail">
                                        <asp:RadioButton ID="optOverlay" runat="server" Text=" Nhập đè lên bản ghi hiện <U>t</U>hời" GroupName="optChoice"></asp:RadioButton>
                                        <label for="optOverlay"></label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <asp:Label ID="lblSubTitle" runat="server" CssClass="lbSubformTitle">Điều kiện tìm kiếm</asp:Label>
                            <div class="row-detail">
                                <div class="checkbox-control">
                                    <asp:CheckBox ID="chkVietUSMARC" runat="server" Text="  Máy chủ <U>Z</U>39.50 sử dụng bảng mã tiếng Việt theo chuẩn USMARC"
                                        CssClass="lbCheckbox" Checked="True"></asp:CheckBox>
                                    <label for="chkVietUSMARC"></label>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Hiển thị:</p>
                            <div class="row-detail">
                                <div class="radio-control">
                                    <asp:RadioButton ID="optMARC" runat="server" Text="M<u>A</u>RC" GroupName="optDisplay"></asp:RadioButton>
                                    <label for="optMARC"></label>
                                    <asp:RadioButton ID="optISBN" runat="server" Text="IS<u>B</u>D" Checked="True" GroupName="optDisplay"></asp:RadioButton>
                                    <label for="optISBN"></label>
                                    <asp:RadioButton ID="optSimple" runat="server" Text="Đơn <u>g</u>iản" GroupName="optDisplay"></asp:RadioButton>
                                    <label for="optSimple"></label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-detail ClearFix">
                    <div class="span1">
                        <div class="pad5">&nbsp;</div>
                    </div>
                    <div class="span3">
                        <div class="pad5">
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlFieldName1" runat="server" Width="">
                                        <asp:ListItem Value="@attr 1=4">Nhan đề</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=5">Nhan đề tùng thư</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=1">Tác giả</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=2">Tác giả tập thể</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=7">ISBN</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=8">ISSN</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=13">Chỉ số DDC</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=14">Chỉ số UDC</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=16">Chỉ số LC</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=21">Chủ đề</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=29">Từ khoá</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=31">Năm xuất bản</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=30">Nhà xuất bản</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=1016">Mọi trường</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="span6">
                        <div class="pad5">
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtFieldValue1" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail ClearFix">
                    <div class="span1">
                        <div class="pad5">
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlOperatorI" runat="server">
                                        <asp:ListItem Value="@and" Selected="True">AND</asp:ListItem>
                                        <asp:ListItem Value="@or">OR</asp:ListItem>
                                        <asp:ListItem Value="@not">NOT</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="span3">
                        <div class="pad5">
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlFieldName2" runat="server" Width="">
                                        <asp:ListItem Value="@attr 1=4">Nhan đề</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=5">Nhan đề tùng thư</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=1">Tác giả</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=2">Tác giả tập thể</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=7">ISBN</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=8">ISSN</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=13">Chỉ số DDC</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=14">Chỉ số UDC</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=16">Chỉ số LC</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=21">Chủ đề</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=29">Từ khoá</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=31">Năm xuất bản</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=30">Nhà xuất bản</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=1016">Mọi trường</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="span6">
                        <div class="pad5">
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtFieldValue2" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail ClearFix">
                    <div class="span1">
                        <div class="pad5">
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlOperatorII" runat="server">
                                        <asp:ListItem Value="@and" Selected="True">AND</asp:ListItem>
                                        <asp:ListItem Value="@or">OR</asp:ListItem>
                                        <asp:ListItem Value="@not">NOT</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="span3">
                        <div class="pad5">
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlFieldName3" runat="server" Width="">
                                        <asp:ListItem Value="@attr 1=4">Nhan đề</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=5">Nhan đề tùng thư</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=7">ISBN</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=8">ISSN</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=1">Tác giả</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=2">Tác giả tập thể</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=13">Chỉ số DDC</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=14">Chỉ số UDC</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=16">Chỉ số LC</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=21">Chủ đề</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=29">Từ khoá</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=31">Năm xuất bản</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=30">Nhà xuất bản</asp:ListItem>
                                        <asp:ListItem Value="@attr 1=1016">Mọi trường</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="span6">
                        <div class="pad5">
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input" ID="txtFieldValue3" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div style="text-align: center" class="button-control">
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnSearch" runat="server" Text="Tìm kiếm(f)" Width=""></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button CssClass="form-btn" ID="btnReset" runat="server" Text="Làm lại(r)" Width=""></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Bạn chưa nhập đủ thông tin cần thiết!</asp:ListItem>
            <asp:ListItem Value="1">Bạn phải nhập tên máy chủ!</asp:ListItem>
            <asp:ListItem Value="2">Bạn phải nhập cổng dịch vụ!</asp:ListItem>
            <asp:ListItem Value="3">Bạn phải nhập tên cơ sở dữ liệu!</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
