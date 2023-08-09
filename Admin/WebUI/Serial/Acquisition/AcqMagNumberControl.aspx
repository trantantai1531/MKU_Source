<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqMagNumberControl.aspx.vb" Inherits="eMicLibAdmin.WebUI.Serial.Pages_AcqMagNumberControl" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">        
    <link href="../../Images/ComponentArt/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/Toolbar/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        <!--
          function ToolBar_ItemCommand(sender, e) {
              OnSubmit(e.get_item().get_value());
          }
          function OnSubmit(key) {
              parent.maincontent.CheckSubmit(key);
              return;
          }

          function visibleToolbar(val, bol) {              
              ToolBar.beginUpdate();
              var itemArray = ToolBar.get_items().get_itemArray();
              for (var i = 0; i < itemArray.length; i++) {
                  var item = itemArray[i];
                  if (val == '') {
                      item.set_visible(bol);
                  }
                  else {
                      if (item.get_value() == val) {
                          item.set_visible(!bol);
                      }
                  }
              }
              ToolBar.endUpdate();
          }      
       //-->
     </script>   
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    
</head> 
<body  class="bgbody" style="margin-top:0;margin-left:0;margin-right:0;margin-bottom:0" onload="parent.document.getElementById('frmMain').setAttribute('rows','*,38');">
    <form id="form1" runat="server">
    <asp:UpdatePanel id="upnInput" runat="server" UpdateMode="Always">
        <ContentTemplate>   
            <table id="table1" style="width:100%;" cellpadding="0" cellspacing="0" border="0">
            <tr>             
              <td valign="top" style="width:100%;" align="center">   
                    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="false" runat="server" />
                     <ComponentArt:ToolBar ID="ToolBar"
                        ImagesBaseUrl="../../Images/ComponentArt/Toolbar/images/FooterControls/"
                        DefaultItemCssClass="item"
                        DefaultItemHoverCssClass="itemHover"
                        DefaultItemActiveCssClass="itemActive"
                        DefaultItemTextImageSpacing="2"
                        DefaultItemTextImageRelation="ImageBeforeText"
                        DefaultItemImageHeight="20"
                        DefaultItemImageWidth="20"
                        Orientation="Horizontal"
                        UseFadeEffect="false"
                        runat="server">       
                        <ClientEvents>
                            <ItemSelect EventHandler="ToolBar_ItemCommand" />
                        </ClientEvents>       
                    <Items>
                      <ComponentArt:ToolBarItem ID="ToolBarItem1" runat="server" Text="Biên mục"    Value="add"    ImageUrl="Acquisition.png" />
                      <ComponentArt:ToolBarItem ItemType="Separator" Width="1"/>
                      <ComponentArt:ToolBarItem ID="ToolBarItem5" runat="server"  Text="Đóng"  Value="close"  ImageUrl="Close.png" />
                    </Items>
                    </ComponentArt:ToolBar>
                </td>
               
            </tr>
         </table>
      </ContentTemplate>
    </asp:UpdatePanel>  
    <div style="display:none">
        <span  id="span_add" runat="server">Thêm số mới</span>
        <span  id="span_close" runat="server">Đóng</span>
    </div>          
    </form>
</body>
</html>
