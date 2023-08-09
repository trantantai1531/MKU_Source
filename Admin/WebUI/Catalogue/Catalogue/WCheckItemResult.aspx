<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WCheckItemResult" CodeFile="WCheckItemResult.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>WCheckItemResult</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <style>
        .lbButton:hover {
            background: #1D24FB none repeat scroll 0 0 !important;
            color: white !important;
            border-radius: 5px;
            border: 1px solid #024385;
        }


        .main-group-form {
            background: #aacfea none repeat scroll 0 0;
            color: #000;
            font-family: HeadFont;
            font-size: 150%;
            font-weight: normal;
            margin-bottom: 10px;
        }

        .form-btn, .lbButton {
            background: #aacfea none repeat scroll 0 0;
            border: 1px solid #aacfea;
            border-radius: 5px;
            color: #2061a3;
            cursor: pointer;
            display: inline-block;
            padding: 5px 6px;
            vertical-align: top;
            margin-right: 18px;
        }

        #tblResult {
            border-collapse: collapse;
            border-style: solid;
            border-width: 2px;
            width: 100%;
        }


            #tblResult td {
                border: 1px solid #000;
                border-collapse: collapse;
                height: 34px;
            }

        .lbGridHeader {
            background: #cccccc none repeat scroll 0 0;
            color: #2061a3;
            text-align: center;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body topmargin="0" leftmargin="0">
    <form id="Form1" method="post" runat="server">
        <asp:Table ID="tblResult" runat="server" Width="100%" BorderWidth="2px"></asp:Table>
        <asp:Label ID="lblLabel1" runat="server" Visible="False">Hiển thị các bản ghi</asp:Label>
        <asp:Label ID="lblLabel2" runat="server" Visible="False">Sao chép biểu ghi</asp:Label>
        <asp:Label ID="lblLabel3" runat="server" Visible="False">Mở biểu ghi</asp:Label>
        <asp:Label ID="lblLabel4" runat="server" Visible="False">Mã lỗi</asp:Label>
        <asp:Label ID="lblLabel5" runat="server" Visible="False">Chi tiết lỗi</asp:Label>
    </form>
</body>
</html>
