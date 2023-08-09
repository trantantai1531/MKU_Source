<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WBookLabelTemplateDisplay" CodeFile="WBookLabelTemplateDisplay.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WBookLabelTemplate</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">

        <div id="divBody">
            <div class="content-form">
                <h1 class="main-head-form">Khuôn dạng nhãn gáy / nhãn bìa</h1>
                <div class="main-form">
                    <div class="row-detail">
                        <p>Chọn mẫu :</p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:dropdownlist id="ddlTemplate" Runat="server"></asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Tên mẫu :</p>
                        <div class="input-control">
                            <div class="input-form ">
                                <asp:textbox CssClass="text-input" id="txtTitle" runat="server" Width=""></asp:textbox>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Nội dung :</p>
                        <div class="input-control">
                            <div class="input-form " style="border: none !important">
                            <asp:textbox CssClass="area-input display-none" id="txtContent" Runat="server" Columns="100" Rows="10" TextMode="MultiLine" Wrap="False"
							Width="" Height="00px" Visible="False"></asp:textbox>
                                 <FCKeditorV2:FCKeditor ID="fckContent" EnableXHTML="true" runat="server" BasePath="../../fckeditor/"
                            Height="335px" Width="100%" SkinPath="skins/silver/" StartupFocus="false"
                            ToolbarSet="Basic">
                        </FCKeditorV2:FCKeditor>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <p>Chọn thông tin :</p>
                        <div class="input-control">
                            <div class="dropdown-form">
                                <asp:dropdownlist id="ddlInf" Runat="server">
							        <asp:ListItem Value="--------------">---------- Chọn -----------</asp:ListItem>
							        <asp:ListItem Value="<$082$a$>">Phân loại</asp:ListItem>
                                    <asp:ListItem Value="<$040$c$>">Cơ quan sao chép</asp:ListItem>
							        <asp:ListItem Value="<$090$b$>">Cutter</asp:ListItem>
							        <asp:ListItem Value="<$260$c$>">Năm xuất bản</asp:ListItem>
							        <asp:ListItem Value="<$245$n$>">Thứ tự tập</asp:ListItem>
							        <asp:ListItem Value="<$245$p$>">Tên tập</asp:ListItem>
							        <asp:ListItem Value="<$holding:inventory$>">Kho</asp:ListItem>
							        <asp:ListItem Value="<$holding:number$>">Mã xếp giá</asp:ListItem>
                                    <asp:ListItem Value="<$topic$>">Chủ đề</asp:ListItem>
						        </asp:dropdownlist>
                            </div>
                        </div>
                    </div>
                    <div class="row-detail">
                        <div class="button-control">
                            <div class="button-form">
                                <asp:button id="btnUpdate" Runat="server" Text="Cập nhật(u)"></asp:button>
                            </div>
                            <div class="button-form">
                                <asp:button id="btnView" Runat="server" Text="Xem trước(v)"></asp:button>
                            </div>
                            <div class="button-form">
                                <asp:button id="btnReset" Runat="server" Text="Làm lại(r)"></asp:button>
                            </div>
                            <div class="button-form">
                                <asp:button id="btnDelete" Runat="server" Text="Xoá(d)"></asp:button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:DropDownList ID="ddlLog" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="0">Tạo mới mẫu nhãn gáy, nhãn bìa </asp:ListItem>
            <asp:ListItem Value="1">Cập nhật mẫu nhãn gáy, nhãn bìa</asp:ListItem>
            <asp:ListItem Value="2">Xoá mẫu nhãn gáy, nhãn bìa</asp:ListItem>
            <asp:ListItem Value="3">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="4">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="5">Bạn không được cấp quyền sử dụng tính năng này! </asp:ListItem>
            <asp:ListItem Value="6">---------- Tạo mới ----------</asp:ListItem>
            <asp:ListItem Value="7">Nhấn OK nếu thực sự muốn xoá mẫu này!</asp:ListItem>
            <asp:ListItem Value="8">Bạn chưa nhập tên mẫu!</asp:ListItem>
            <asp:ListItem Value="9">Cập nhật mẫu thành công!</asp:ListItem>
            <asp:ListItem Value="10">Tên mẫu đã tồn tại hoặc lỗi trong quá trình cập nhật!</asp:ListItem>
            <asp:ListItem Value="11">Bạn chưa chọn mẫu cần làm việc!</asp:ListItem>
        </asp:DropDownList>
    </form>

    <script language="javascript">
        document.forms[0].txtTitle.focus();
    </script>

</body>
</html>
