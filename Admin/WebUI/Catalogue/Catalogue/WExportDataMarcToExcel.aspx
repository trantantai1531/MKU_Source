<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WExportDataMarcToExcel.aspx.vb" Inherits="Catalogue_Catalogue_WExportDataMarcToExcel" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Đặt giá trị ngầm định</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
</head>
<body>
    <form id="form1" runat="server">
        <div id="divBody">
            <div class="group-row">
                <div class="row-detail">
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:TextBox ID="txtIDFrom" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtIDTo" runat="server"></asp:TextBox>
                            <asp:Button ID="ExportExcel" runat="server" Text="Export Excel" />
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Button ID="ConvertFileExcel" runat="server" Text="Convert File Excel" />
                        </div>
                    </div>
                </div>
                <div class="row-detail">
                    <div class="input-control">
                        <div class="input-form ">
                            <asp:FileUpload ID="FileUpload2" runat="server" /><asp:Button ID="ViewGroupBy" runat="server" Text="View Group By" /><asp:Label ID="LabelList" runat="server" Text="Label"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
