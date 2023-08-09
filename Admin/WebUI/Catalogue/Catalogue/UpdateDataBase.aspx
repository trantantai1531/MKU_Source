<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.UpdateDataBse" CodeFile="UpdateDataBase.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCopyNumber</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" />

</head>
<body leftmargin="2" topmargin="2">
    <form id="Form1" method="post" runat="server">
        <div id="divBody" style="overflow: scroll">

            <h1 class="main-head-form">

                <span style="width: 100%;" class="lbLabel" id="Span1">Cập nhật dữ liệu</span>
            </h1>

            <div class="row ClearFix" style="text-align: center">

                <textarea id="txtQuery" style="width: 98%; height: 100px;" runat="server">
                            
                        </textarea>

            </div>
            <div class="row-detail">
                <div class="button-control" style="text-align: center;">
                    <div class="button-form">
                        <asp:Button ID="btnUpdate" runat="server" Text="Xử lý" />
                        <div>
                        </div>
                    </div>
                </div>

            </div>
             <div class="row-detail">
                 <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                 </div>

            <div class="row-detail">
                <div class="table-form">
                    <asp:DataGrid ID="dtgResult" runat="server" Width="100%" AllowPaging="True"
                        AutoGenerateColumns="True">
                        <PagerStyle Position="TopAndBottom" Mode="NumericPages" Width="100%"></PagerStyle>
                    </asp:DataGrid>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
