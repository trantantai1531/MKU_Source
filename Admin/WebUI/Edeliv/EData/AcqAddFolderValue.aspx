<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqAddFolderValue.aspx.vb" Inherits="eMicLibAdmin.WebUI.Edeliv.Pages_AcqAddFolderValue" %>

<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../Images/ComponentArt/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/Input/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/Toolbar/style.css" type="text/css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script language="JavaScript">
  <!--
    var specialChars = "<>@!#$%^&*()_+[]{}?:;|'\"\\,./~`-=";
    var check = function(string){
        for(i = 0; i < specialChars.length;i++){
            if(string.indexOf(specialChars[i]) > -1) {
                return true;
            }
        }
        return false;
    }
    function CheckSubmit(key) {
        switch (key) {
            case 'close':
                var jDialog = '<%=Request.QueryString("Dialog_Content_Child")%>';
                if (jDialog) {
                    top.showDialogContentChild('', true, '', parseInt(window.screen.availWidth / 3), parseInt(window.screen.availHeight / 3));
                }
                else {
                    top.closeDialog('Dialog_content');
                }
                break;
            case 'addfolder':
                var txtNewFolder = document.getElementById('txtNewFolder');
                if (txtNewFolder.value == '') {
                    var span_addfolder = document.getElementById('span_addfolder');
                    var span_info = document.getElementById('span_info');
                    top.showDialogInfo('', true, 0, span_info.innerHTML, span_addfolder.innerHTML);
                }
                else {
                    if (check(txtNewFolder.value) == true) {
                        var span_info = document.getElementById('span_info');
                        top.showDialogInfo('', true, 0, span_info.innerHTML, "vui lòng không nhập các ký tự đặc biệt");
                    }
                    else {
                        if (txtNewFolder.value.length > 20) {
                            var span_info = document.getElementById('span_info');
                            top.showDialogInfo('', true, 0, span_info.innerHTML, "vui lòng không nhập quá 20 ký tự");
                        }
                        else {
                            top.main.Workform.maincontent.create_folder(txtNewFolder.value);
                        }
                    }
                }
                break;
            case 'rename':
                var txtNewFolder;
                txtNewFolder = document.getElementById('txtNewFolder');
                if (txtNewFolder.value == '') {
                    var span_addfolder = document.getElementById('span_addfolder');
                    var span_info = document.getElementById('span_info');
                    top.showDialogInfo('', true, 0, span_info.innerHTML, span_addfolder.innerHTML);
                }
                else {
                    if (check(txtNewFolder.value) == true) {
                        var span_info = document.getElementById('span_info');
                        top.showDialogInfo('', true, 0, span_info.innerHTML, "vui lòng không nhập các ký tự đặc biệt");
                    } else {
                        if (txtNewFolder.value.length > 20) {
                            var span_info = document.getElementById('span_info');
                            top.showDialogInfo('', true, 0, span_info.innerHTML, "vui lòng không nhập quá 20 ký tự");
                        }
                        else {
                            top.main.Workform.maincontent.rename_folder(txtNewFolder.value);
                        }
                    }
                }
                break;
        }
    }
    //-->
    </script>
</head>
<body class="backgroundbodywhite" style="margin-top: 0; margin-left: 0; margin-right: 0; margin-bottom: 0">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" />
        <asp:UpdatePanel ID="upnInput" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table id="table2" width="100%" border="0" cellspacing="1" cellpadding="1" bgcolor="white">
                    <tr>
                        <td width="32px" align="right">
                            <img src="../../Images/ComponentArt/Toolbar/images/FooterControls/folder_add.png" style="border: none; display: block; vertical-align: top;" width="32px" height="32px" />
                        </td>
                        <td align="left">
                            <asp:Label ID="lblRowTitle" CssClass="titlerowtextread" runat="server">Thêm mới/đổi tên thư mục</asp:Label>
                        </td>
                    </tr>
                </table>
                <table id="tblParent" cellpadding="0" cellspacing="0" width="100%" border="0" align="center">
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 30%">
                            <asp:Label ID="lblNewFolder" runat="server">Tên thư mục</asp:Label></td>
                        <td style="width: 60%">
                            <div class="fieldlogin">
                                <ComponentArt:MaskedInput runat="server"
                                    ID="txtNewFolder"
                                    Text=""
                                    EmptyText=""
                                    CssClass="valid"
                                    EmptyCssClass="required"
                                    FocusedValidCssClass="focused-valid"
                                    FocusedCssClass="focused"
                                    InvalidCssClass="invalid"
                                    DisabledCssClass="disabled" />
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="display: none">
            <ComponentArt:MaskedInput runat="server" ID="Temp" />
            <span id="span_input" runat="server">Nhập tên thu mục</span>
            <span id="span_info" runat="server">Thông báo; Đóng</span>
            <span id="span_addfolder" runat="server">Xin vui lòng nhập tên thư mục.</span>
        </div>
    </form>
</body>
</html>
