<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqDisplayControlChooseFiles.aspx.vb" Inherits="eMicLibAdmin.WebUI.Serial.Pages_AcqDisplayControlChooseFiles" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">        
    <%=Session("cssPage")%>  
    <script type="text/javascript">
        <!--
          function ToolBar_ItemCommand(sender, e) {
              OnSubmit(e.get_item().get_value());
          }
          function OnSubmit(key) {
              parent.maincontentchoosefile.CheckSubmit(key);              
              /*switch (key) {
                  case 'addfile':
                      var intSavefile;
                      intSavefile = saveFileIds();  
                      break;
                  case 'close':
                      break;
              }*/
          }

          function visibleToolbar(val,bol) {
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

          function RedirectUrl(val) {
            switch (val) {
                case '0':
                    visibleToolbar('',true);
                    parent.maincontentchoosefile.location = "../../Edeliv/EData/AcqDisplayFolder.aspx";
                    break;
                case '1':
                    visibleToolbar('acquisition', true);
                    parent.maincontentchoosefile.location = "AcqDisplayCollection.aspx";
                    break;
                case '2':
                    visibleToolbar('acquisition', true);
                    parent.maincontentchoosefile.location = "AcqDisplayStatus.aspx";
                    break;
                case '3':
                    visibleToolbar('acquisition', true);
                    parent.maincontentchoosefile.location = "AcqDisplayFormat.aspx";
                    break;
            }
         }
       //-->
     </script>   
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    
</head>
<%
    Dim intType As Integer = 0
    If Not Session("displayType") Is Nothing Then
          intType = Session("displayType")
    End If 
%>   
<body  class="bgbody" style="margin-top:0;margin-left:0;margin-right:0;margin-bottom:0" onload="RedirectUrl('<%=intType%>');">
    <form id="form1" runat="server">
    <asp:UpdatePanel id="upnInput" runat="server" UpdateMode="Always">
        <ContentTemplate>   
            <table id="table1" style="width:100%;" cellpadding="0" cellspacing="0" border="0">
            <tr>
             <td  align="left"  style="width:20%">
                 &nbsp;
            </td>
              <td valign="top" style="width:80%;" align="center">   
                    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="false" runat="server" />
                     <ComponentArt:ToolBar ID="ToolBar"
                        ImagesBaseUrl="../../Skin/arcticwhite/Toolbar/images/FooterControls/"
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
                    <ComponentArt:ToolBarItem ID="ToolBarItem1" runat="server" Text="Biên mục"    Value="addfile"    ImageUrl="Charge.png" />
                    <ComponentArt:ToolBarItem ItemType="Separator" Width="1"/>
                      <ComponentArt:ToolBarItem ID="ToolBarItem2" runat="server"  Text="Đóng"  Value="closefile"  ImageUrl="Close.png" />
                    </Items>
                    </ComponentArt:ToolBar>
                </td>
               
            </tr>
         </table>
      </ContentTemplate>
    </asp:UpdatePanel>  
    <div style="display:none">
        <asp:HiddenField ID="folderPath" runat="server" Value="" />
        <span  id="span_acquisition" runat="server">Thêm tập tin</span>
        <span  id="span_close" runat="server">Đóng</span>
    </div>          
    </form>
</body>
</html>
