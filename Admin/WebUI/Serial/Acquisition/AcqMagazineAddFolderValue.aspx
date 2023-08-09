<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqMagazineAddFolderValue.aspx.vb" Inherits="eMicLibAdmin.WebUI.Serial.Pages_AcqMagazineAddFolderValue" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">        
   <link href="../../Images/ComponentArt/style.css" type="text/css" rel="StyleSheet"/>
   <link href="../../Images/ComponentArt/Toolbar/style.css" type="text/css" rel="stylesheet" />
   <link href="../../Images/ComponentArt/Input/style.css" type="text/css" rel="stylesheet" />
  <script language="JavaScript">
  <!--
      function CheckSubmit(key) {
          switch (key) {
              case 'close':
                  top.closeDialog('Dialog_content');
                  break;
              case 'addfolder':
                  var txtNewFolder;
                  txtNewFolder = document.getElementById('txtNewFolder');
                  if (txtNewFolder.value == '') {
                      var span_addfolder = document.getElementById('span_addfolder');
                      var span_info = document.getElementById('span_info');
                      top.showDialogInfo('', true, 0, span_info.innerHTML, span_addfolder.innerHTML);
                  }
                  else {
                      top.WindowRegisterNum.maincontentMagazine.create_folder(txtNewFolder.value);
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
                      top.WindowRegisterNum.maincontentMagazine.rename_folder(txtNewFolder.value);
                  }
                  break;  
          } 
      }
  //-->
  </script>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body  class="backgroundbodywhite" style="margin-top:0;margin-left:0;margin-right:0;margin-bottom:0">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" />
        <asp:UpdatePanel id="upnInput" runat="server" UpdateMode="Conditional">
            <ContentTemplate>        
                <table id="table2" width="100%" border="0" cellspacing="1" cellpadding="1" bgcolor="white">
                <tr>
                    <td width="32px" align="right"><img src="../../Resources/Skin/arcticwhite/Toolbar/images/FooterControls/folder_add.png"  style="border:none;display:block;vertical-align:top;" width="32px" height="32px"/>
                    </td>
                    <td align="left"><asp:label id="lblRowTitle" CssClass="titlerowtextread" Runat="server">Thêm mới/đổi tên thư mục</asp:label>
                    </td>
                </tr>
                </table>
                <table id="tblParent" cellpadding="0" cellspacing="0" width="100%" border="0" align="center">
                    <tr>
                    <td style="width:10%"></td>
                    <td style="width:30%"><asp:label id="lblNewFolder" Runat="server">Tên thư mục</asp:label></td>
                    <td style="width:60%">
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
                            DisabledCssClass="disabled"        
                          />
                        </div>
                    </td>                    
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="display:none">   
            <ComponentArt:MaskedInput runat="server" ID="Temp"/>
            <span  id="span_input" runat="server">Nhập tên thu mục</span>
            <span  id="span_info" runat="server">Thông báo; Đóng</span>
            <span  id="span_addfolder" runat="server">Xin vui lòng nhập tên thư mục.</span>
        </div>                  
    </form>
</body>
</html>
