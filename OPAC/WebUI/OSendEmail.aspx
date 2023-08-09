<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OSendEmail.aspx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.OSendEmail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        </table>
       <div style="display:none">
            <span id="spEmailSuccess" runat="server"><B>Đã gửi mail thành công. Vui lòng kiểm tra lại hộp mail của bạn</B>.</span>
            <span id="spEmailFail" runat="server"><B>Lỗi gửi mail...</B></span>
            <span id="spEmailBodyHeader" runat="server"><B>Danh sách ấn phẩm</B></span>
            <span id="spEmailSubject" runat="server">Hệ thống quản lý thư viện điện tử</span>
        </div>
    </form>
</body>
</html>
