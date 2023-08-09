<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WImportFromFile" CodeFile="WImportFromFile.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 TRansitional//EN">
<html>
<head>
    <title>WImport</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" onload="document.forms[0].filAttach.focus()">
    <form id="Form1" method="post" runat="server">
        <div id="divBody">
            <div class="main-body">
                <h1 class="main-head-form">Nhập khẩu bản ghi từ tệp</h1>
                  <asp:label id="lblTitle" runat="server" cssclass="lbPageTitle">Nhập bản ghi dữ liệu biên mục từ tệp (ISO 2709)</asp:label>
                    <asp:label id="lblAutitle" runat="server" cssclass="lbPageTitle">Nhập bản ghi dữ liệu căn cứ từ tệp (ISO 2709)</asp:label>
                <div class="two-column ClearFix">
                  
                    <div class="two-column-form">
                        <div class="row-detail">
                            <p>Từ biểu ghi :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input"  ID="txtLRange" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tới biểu ghi :</p>
                            <div class="input-control">
                                <div class="input-form ">
                                    <asp:TextBox CssClass="text-input"  ID="txtRRange" runat="server" Width=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Gắn với mẫu biên mục :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlForm" runat="server" Width=""></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Bảng mã chữ Việt của tệp nguồn :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlEncode" runat="server" Width="">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem Value="TCVN">TCVN</asp:ListItem>
                                        <asp:ListItem Value="VNI">VNI</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Khuôn dạng :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlPattern" runat="server" Width="">
                                        <asp:ListItem Value="TCVN">MARC 21 (tagged)</asp:ListItem>
                                        <asp:ListItem Value="VNI">MARC 21 (raw)</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Chế độ nhập khẩu :</p>
                            <div class="input-control">
                                <div class="dropdown-form">
                                    <asp:DropDownList ID="ddlImportMode" runat="server">
                                        <asp:ListItem Value="0">Tạo mới mã tài liệu theo thư viện</asp:ListItem>
                                        <asp:ListItem Value="1">Giữ nguyên mã tài liệu, tạo mới nếu trùng</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="two-column-form">

                        <div class="row-detail">
                            <p>Tên tệp :</p>
                            <div class="input-control">
                                <div class="input-form fileAttach ">
                                    <INPUT id="filAttach" runat="server" type="file" size="23"	name="filAttach" class="text-input" />
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tên tệp :</p>
                            <div class="input-control">
                                <div class="input-form fileAttach ">
                                    <INPUT id="filAttach2" runat="server" style="" type="file" size="23" name="filAttach2" class="text-input" />
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tên tệp :</p>
                            <div class="input-control">
                                <div class="input-form fileAttach ">
                                     <INPUT id="filAttach3" runat="server" type="file" size="23"	name="filAttach3" class="text-input" />
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tên tệp :</p>
                            <div class="input-control">
                                <div class="input-form fileAttach ">
                                     <INPUT id="filAttach4" runat="server" type="file" size="23"	name="filAttach4" class="text-input" />
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <p>Tên tệp :</p>
                            <div class="input-control">
                                <div class="input-form fileAttach ">
                                     <INPUT id="filAttach5" runat="server" type="file" size="23"	name="filAttach5" class="text-input" />
                                </div>
                            </div>
                        </div>
                        <div class="row-detail">
                            <div class="button-control" style="  float: right;margin-top: 26px;">
                                <div class="button-form">
                                    <asp:button id="btnImport" runat="server" Width="" CssClass="form-btn" Text="Nhập(n)" ></asp:button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            <div>
                <asp:label id="lblSuccess" runat="server" Visible="False">Nhập khẩu thành công!</asp:label>
						<asp:label id="lblFail" runat="server" Visible="False">Nhập khẩu thất bại!</asp:label>
						<asp:label id="lblTotal" runat="server" Visible="False"> Tổng số bản ghi đã nhập khẩu:</asp:label>
						<asp:label id="lblCount" runat="server" cssClass="lbAmount" Visible="False"></asp:label><br />
                        <asp:label id="lblTotalDuplicate" runat="server" Visible="False"> Tổng số bản ghi trùng lặp:</asp:label>
						<asp:label id="lblCountDuplicate" runat="server" cssClass="lbAmount" Visible="False"></asp:label>
            </div>
            </div>
        </div>
        <asp:DropDownList runat="server" Width="0" Height="0" Visible="False" ID="ddlLabel">
            <asp:ListItem Value="0">Biểu ghi nhập vào phải là dữ liệu kiểu số! </asp:ListItem>
            <asp:ListItem Value="1">Sai khuôn dạng dữ liệu (số)!</asp:ListItem>
            <asp:ListItem Value="2">Biểu ghi đầu phải nhỏ hơn hoặc bằng biểu ghi cuối!</asp:ListItem>
            <asp:ListItem Value="3">Biểu ghi nhập vào nằm ngoài khoảng giới hạn số biểu ghi trong tệp nhập khẩu!</asp:ListItem>
            <asp:ListItem Value="4">Bạn phải nhập vào đường dẫn của tệp trước khi nhập khẩu!</asp:ListItem>
            <asp:ListItem Value="5">Nội dung tệp rỗng hoặc sai cấu trúc!</asp:ListItem>
            <asp:ListItem Value="6">Nhập khẩu dữ liệu: </asp:ListItem>
            <asp:ListItem Value="7">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="8">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="9">Nhập bản ghi dữ liệu biên mục từ tệp (ISO 2709).</asp:ListItem>
            <asp:ListItem Value="10">Nhập bản ghi dữ liệu căn cứ từ tệp (ISO 2709).</asp:ListItem>
            <asp:ListItem Value="11">Bạn không được cấp quyền khai thác tính năng này</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
