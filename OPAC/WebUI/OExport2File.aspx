<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OExport2File.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OExport2File" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trường Đại Học Cửu Long</title>
</head>
<body>
    <form id="form1" runat="server">
        <table id="Table1" cellpadding="3" cellspacing="3" width="98%" border="0" align="center" style="height:50px">
            <tr>
                <td style="height:90px">&nbsp;</td>
            </tr>
        </table>
        <table id="tblParent" cellpadding="3" cellspacing="3" width="98%" border="0" align="center">
            <tr>
                <td align="center" style="width:100%">
                    <asp:Label id="lblResult" runat="server" ></asp:Label>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center" style="width:100%">
                    <asp:Label id="lblClick" runat="server" >&nbsp;Click</asp:Label>&nbsp;
				    <asp:HyperLink id="lnkLink" runat="server">vào đây</asp:HyperLink>&nbsp;
				    <asp:Label id="lblLinkTail" runat="server" >để lấy tệp về</asp:Label>
                </td>
            </tr>
        </table>
        <div style="display:none">
            <span  id="span_pecent_process" runat="server">Đang xuất dữ liệu ra word...</span>
            <span  id="span_pecent_finish" runat="server">Đã thực hiện xong!</span>
            <span  id="span_result_choose" runat="server">Tổng số bản ghi :</span>
        </div>
    </form>
</body>
</html>
