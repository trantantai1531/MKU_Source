<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqTableOfContentsAddValue.aspx.vb" Inherits="eMicLibAdmin.WebUI.Edeliv.Pages_AcqTableOfContentsAddValue" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">        
    <link href="../../Images/ComponentArt/Input/style.css" type="text/css" rel="StyleSheet"/>
  <script language="JavaScript">
  <!--
      function CheckSubmit(key) {
          switch (key) {
              case 'close':
                  top.closeDialog('Dialog_content');
                  break;
              case 'addTableofcontent':
                  var txtTableofcontents;
                  txtTableofcontents = document.getElementById('txtTableofcontents');
                  if (txtTableofcontents.value == '') {
                      var span_addTableofcontent = document.getElementById('span_addTableofcontent');
                      var span_info = document.getElementById('span_info');
                      top.showDialogInfo('', true, 0, span_info.innerHTML, span_addTableofcontent.innerHTML);
                      break;
                  }
                  if (txtNum.get_value() <= 0) {
                      var span_Numofcontent = document.getElementById('span_Numofcontent');
                      var span_info = document.getElementById('span_info');
                      top.showDialogInfo('', true, 0, span_info.innerHTML, span_Numofcontent.innerHTML);
                      break;
                  }
                  top.main.Workform.maincontent.create_Tableofcontent(txtTableofcontents.value, txtNum.get_value());
                  break;
              case 'renameTableofcontent':
                  var txtTableofcontents;
                  txtTableofcontents = document.getElementById('txtTableofcontents');
                  if (txtTableofcontents.value == '') {
                      var span_addTableofcontent = document.getElementById('span_addTableofcontent');
                      var span_info = document.getElementById('span_info');
                      top.showDialogInfo('', true, 0, span_info.innerHTML, span_addTableofcontent.innerHTML);
                      break;
                  }
                  if (txtNum.get_value() <= 0) {
                      var span_Numofcontent = document.getElementById('span_Numofcontent');
                      var span_info = document.getElementById('span_info');
                      top.showDialogInfo('', true, 0, span_info.innerHTML, span_Numofcontent.innerHTML);
                      break;
                  }
                  top.main.Workform.maincontent.rename_Tableofcontent(txtTableofcontents.value, txtNum.get_value());
                  break;
          } 
    }
  //-->
  </script>
    <style type="text/css">
        .style1
        {
            width: 211px;
        }
        .style2
        {
            width: 5%;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body  class="backgroundbodywhite" style="margin-top:0;margin-left:0;margin-right:0;margin-bottom:0">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" />
        <asp:UpdatePanel id="upnInput" runat="server" UpdateMode="Conditional">
            <ContentTemplate>        
                <table id="table2" width="100%" border="0" cellspacing="1" cellpadding="1" bgcolor="white" style="display:none;">
                <tr>
                    <td width="32px" align="right"><img src="../../Images/ComponentArt/Toolbar/images/FooterControls/Bookmark.png"  style="border:none;display:block;vertical-align:top;" width="32px" height="32px"/>
                    </td>
                    <td align="left"><asp:label id="lblRowTitle" CssClass="titlerowtextread" Runat="server">Nhập/sửa mục lục</asp:label>
                    </td>
                </tr>
                </table>
                <table id="tblParent" cellpadding="1" cellspacing="1" width="100%" border="0" align="center">
                    <tr>
                    <td style="width:5%"></td>
                    <td style="width:55%"><asp:label id="lblNewtableofcontent" Runat="server">Tên mục lục</asp:label></td>
                    <td style="width:40%">
                         <div class="autofield"> 
                        <ComponentArt:MaskedInput runat="server"
                            ID="txtTableofcontents"
                            Text=""
                            MaxLength="30"       
                            EmptyText="Nhập mục lục..."
                            CssClass="valid"
                            EmptyCssClass="required"
                            FocusedValidCssClass="focused-valid"
                            FocusedCssClass="focused"
                            InvalidCssClass="invalid"
                            DisabledCssClass="disabled"        
                          />
                        </div>
                    </td> 
                    <td style="width:5%"></td>                   
                    </tr>
                    <tr>
                    <td style="width:5%"></td>
                    <td style="width:15%"><asp:label id="lblNumofpage" Runat="server">Trang</asp:label></td>
                    <td style="width:75%">
                        <div class="fieldlogin">
                         <ComponentArt:NumberInput runat="server"
                            ID="txtNum"
                            MaxLength="5" 
                            EmptyText="Nhập trang..."
                            CssClass="valid"
                            EmptyCssClass="empty"
                            FocusedValidCssClass="focused-valid"
                            FocusedCssClass="focused"
                            InvalidCssClass="invalid"
                            DisabledCssClass="disabled"
                            NumberType="Number"
                            MinValue="0"
                            DecimalDigits="0"
                            >
                          </ComponentArt:NumberInput>
                          </div>
                    </td>        
                    <td style="width:5%"></td>            
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:UpdateProgress ID="ctrlUpdateProgress" runat="server" AssociatedUpdatePanelID="upnInput">
                              <ProgressTemplate>
                                  <table>
                                      <tr>
                                          <td>
                                              <img alt="" height="16" src="../../images/spinner.gif" width="16" runat="server" id="imgProgress"/></td>
                                          <td style="font-family:Verdana;font-size:11px;font-weight:bold;color:red;">
                                              <span ID="span_progress" runat="server" >Đang cập nhật. Xin vui lòng chờ đợi...</span></td>
                                      </tr>
                                  </table>
                              </ProgressTemplate>
                          </asp:UpdateProgress>
                        </td>
                    </tr>
                </table>
                <div style="display:none">
                    <asp:Button runat="server" ID="raiseUpdate"  Text="raiseUpdate" CausesValidation="false"/>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="display:none">   
            <ComponentArt:MaskedInput runat="server" ID="Temp"/>     
            <span  id="span_addTableofcontent" runat="server">Xin vui lòng nhập tên mục lục.</span>       
            <span  id="span_Numofcontent" runat="server">Xin vui lòng nhập số trang mục lục.</span>
            <span  id="span_info" runat="server">Thông báo; Đóng</span>
        </div>                  
    </form>
</body>
</html>
