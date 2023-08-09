<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WContractTaskbar" CodeFile="WContractTaskbar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WContractTaskbar</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0" onkeypress="if (event.keycode==13){ return false;}">
    <form id="Form1" method="post" runat="server">
        <div class="row-detail ClearFix"style="-moz-box-shadow: 0 0 5px #888;  -webkit-box-shadow: 0 0 5px#888;  background-color: #FDFDC9;">
            <div class="col-left">
                <div class="input-control inline-box">
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnMoveFirst" CssClass="form-btn" runat="server" Text="<<"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnMovePrev" CssClass="form-btn" runat="server" Text="<"></asp:Button>
                        </div>
                    </div>
                    <div class="input-form ">
                        <asp:TextBox ID="txtCurrentID" CssClass="text-input" runat="server" Width="54">0</asp:TextBox>
                    </div>
                    <div class="input-form control-disabled">
                        <asp:TextBox ID="txtMaxID" CssClass="text-input" runat="server" Enabled="False" Width="54">0</asp:TextBox>
                    </div>
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnMoveNext" CssClass="form-btn" runat="server" Text=">"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnMoveLast" CssClass="form-btn" runat="server" Text=">>"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnNew" CssClass="form-btn" runat="server" Text=">*"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-right">
                <div class="input-control inline-box">
                    <p>Kiểu:</p><%--<asp:Label ID="lblBrowseType" runat="server" Width="71px"><U>K</U>iểu:</asp:Label>--%>
                    <div class="dropdown-form">
                         <asp:DropDownList ID="ddlBrowseType" runat="server" >
                        <asp:ListItem Value="1">Theo ngày lập đơn</asp:ListItem>
                        <asp:ListItem Value="2">Theo nhà cung cấp</asp:ListItem>
                        <asp:ListItem Value="3">Theo quỹ</asp:ListItem>
                        <asp:ListItem Value="4">Theo trạng thái</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                    <div class="button-control">
                        <div class="button-form">
                            <asp:Button ID="btnBrowse" CssClass="form-btn" runat="server" Text="Duyệt xem"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnFilter"  CssClass="form-btn" runat="server" Text="Lọc"></asp:Button>
                        </div>
                        <div class="button-form">
                            <asp:Button ID="btnUnFilter"  CssClass="form-btn" runat="server" Text="Bỏ lọc"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="2">Bạn đang ở bản ghi đầu tiên</asp:ListItem>
            <asp:ListItem Value="3">Bạn đang ở bản ghi cuối cùng</asp:ListItem>
            <asp:ListItem Value="4">Ngoài phạm vi kiểm tra</asp:ListItem>
            <asp:ListItem Value="5">Sai kiểu dữ liệu (số)</asp:ListItem>
            <asp:ListItem Value="6">Bạn không được cấp quyền sử dung tính năng này</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
