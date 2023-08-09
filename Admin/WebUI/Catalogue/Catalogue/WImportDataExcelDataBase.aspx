<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WImportDataExcelDataBase.aspx.vb" Inherits="eMicLibAdmin.WebUI.Catalogue.WImportDataExcelDataBase" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Đặt giá trị ngầm định</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        #Background{
            position:fixed;
            top:0;
            left:0;
            bottom:0;
            right:0;
            overflow:hidden;
            padding:0;
            margin:0;
            background-color:#f0f0f0;
            filter:alpha(opacity=80);
            opacity:0.8;
            z-index:99999;
        }
        #Progress {
          position: fixed;
          top: 40%;
          left:40%;
          width: 20%;
          height: 20%;
          z-index:100000;
          background-color: #ddd;
          border:1px solid Gray;
          background-image:url('/images/loading.gif');
          background-repeat:no-repeat;
          background-position:center;
        }

        #myBar {
          position: absolute;
          width: 0%;
          height: 100%;
          background-color: #4CAF50;
        }

        #label {
          text-align: center;
          line-height: 30px;
          color: white;
        }
        .main-group-form {
            margin: 3px 0 6px;
            width: 100%;
            display: block;
            padding:5px 0 5px 10px;
        }
    </style>
</head>
<body leftmargin="2" topmargin="0">
    <form id="frm" method="post" runat="server">
        <div id="divBody">
            <div class="row-detail">
                <div class="group-row">
                    <h1 class="main-head-form">Import Dữ liệu từ file excel</h1>
                </div>
                <div class="group-row">
                    <h1 class="main-group-form">Nhập file excel cần import</h1>
                </div>
            </div>
            <div class="group-row">
                <div class="row-detail">
                    <p>Đường dẫn file:</p>
                    <div class="input-control">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <asp:Button ID="btnImportData" runat="server" CssClass="form-btn" OnClientClick="return myFunction()" Text="Import data" />
                        <asp:Button ID="btnUpdateLoanType" runat="server" CssClass="form-btn" OnClientClick="return myFunction()" Text="Update LoanType" />
                    </div>
                    <div class="input-control" id="message" style="display:none">
                        Đang xử lý vui lòng chờ
                        <p><asp:Label ID="LabelUpdateProgress" runat="server" Text=""></asp:Label></p>
                    </div>
                    <div class="input-control" id="Div1" runat="server">
                        <asp:Label ID="lbSuccess" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lbTotalInput" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblErrorDataCat" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblErrorItemHolding" runat="server" Text=""></asp:Label><br />
                    </div>
                </div>
            </div>
        </div>
        <input id="hidID" type="hidden" runat="server" />
        <input id="hidError" type="hidden" runat="server" name="hidError" value="0" />
        <asp:DropDownList ID="ddlLabel" runat="server" Visible="False" Width="0">
            <asp:ListItem Value="3">Cả hai chỉ thị dữ liệu không hợp lệ</asp:ListItem>
            <asp:ListItem Value="5">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="6">Chi tiết lỗi</asp:ListItem>
            <asp:ListItem Value="7">Không tồn tại</asp:ListItem>
            <asp:ListItem Value="8">Bạn không được cấp quyền sử dụng tính năng này!</asp:ListItem>
            <asp:ListItem Value="9">Cập nhật dữ liệu thành công!</asp:ListItem>
        </asp:DropDownList>
    </form>
    <script type="text/javascript">

        function myFunction()
        {
            if (document.getElementById("FileUpload1").value != "")
            {
                document.forms[0].submit();   
                return true;
            }
            else
            {
                alert("Vui lòng chọn file upload");
                return false;
            }
        }
        
    </script>
</body>
</html>
