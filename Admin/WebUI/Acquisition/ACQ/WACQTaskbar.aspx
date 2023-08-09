<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Acquisition.WACQTaskbar" CodeFile="WACQTaskbar.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WACQTaskbar</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
        <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" />
        <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
        <style>
            .btn-button {
                background: #aacfea none repeat scroll 0 0;
                min-height: 31px;
                border: medium none;
                color: #2061a3;
                cursor: pointer;
                display: inline-block;
                padding: 5px 6px;
                vertical-align: top;
            }
            .bol{
                font-weight:bold;
            }
        </style>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
	</HEAD>
	<body topmargin="0" leftmargin="0" rightmargin="0" >
		<form id="Form1" method="post" runat="server">
			<table id="AcqResult" border="0" cellpadding="0" cellspacing="1" style="width:100%">
				<tr>
					<td style="text-align:right;width:10%"><asp:button cssclass="lbButton" id="btnPrevious" Text="Trang trước(c)" Runat="server" Width="100px"></asp:button></td>
					<td align="center" style="width:30%">
                        <asp:label id="lblPages" Runat="server">Tran<u>g</u>: </asp:label>&nbsp;<asp:textbox CssClass="lbTextbox" id="txtCurrentPage" Runat="server" Width="40">0</asp:textbox>&nbsp;<asp:label id="lblInPages" Runat="server"> trong</asp:label>&nbsp;<asp:label id="lblMaxPage" Runat="server"> 0</asp:label>&nbsp;<asp:label id="lblPage" Runat="server"> trang</asp:label>&nbsp;<asp:HyperLink ID="hrfReChoice" Runat="server"><b>Yêu 
								cầu khác</b></asp:HyperLink>
					</td>     
					<td align="left" style="width:10%"><asp:button cssclass="lbButton" id="btnNext" Text="Trang sau(s)" Runat="server" Width="100px"></asp:button></td>
                    <td><span>Tổng số nhan đề:&nbsp;</span><asp:Label runat="server" CssClass="bol" ID="lblItemCount" Text="10"></asp:Label></td>
                    <td><span>Tổng số bản sách:&nbsp;</span><asp:Label runat="server" CssClass="bol" ID="lblCopyNumberCount" Text="20"></asp:Label></td>
                    <td align="left" style="width:10%">
                        <asp:button cssclass="lbButton" id="btnExportExcell" Text="Xuất Excell" Runat="server" ></asp:button>
                    </td>
                    <td align="left" style="width:10%">
                        <asp:button cssclass="lbButton" id="btnPrint" Text="Xuất Word" Runat="server" ></asp:button>
                    </td>
				</tr>
                <tr>
                    
                </tr>
			</table>
            <asp:DropDownList ID="ddlLabel" Width="0" Height="0" runat="server" Visible="False">
                 <asp:ListItem Value="0">Đang tải dữ liệu. Xin vui lòng chờ trong chốc lát...</asp:ListItem>
            </asp:DropDownList>
            <div style="display:none">
            <input name="hidMessageBook" runat="server" type="hidden" id="hidMessageBook" value="Tổng số: " />
            <input name="hidLeftTable" runat="server" type="hidden" id="hidLeftTable" value="THƯ VIỆN<BR/> ĐẠI HỌC QUỐC TẾ MIỀN ĐÔNG" />
            <input name="hidRightTable" runat="server" type="hidden" id="hidRightTable" value="CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM<BR/>Độc lập - Tự do - Hạnh phúc" />
            <input name="hidTitleTable" runat="server" type="hidden" id="hidTitleTable" value="BÁO CÁO BỔ SUNG SÁCH" />
            <input name="hidMessageCopyNumber" runat="server" type="hidden" id="hidMessageCopyNumber" value="" />
        </div>
		</form>
	</body>
</HTML>
