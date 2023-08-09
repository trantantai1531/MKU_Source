<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqTableOfContentsAddControl.aspx.vb" Inherits="eMicLibAdmin.WebUI.Edeliv.Pages_AcqTableOfContentsAddControl" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">        
    <link href="../../Images/ComponentArt/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/Menu/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/MenuButton/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/Toolbar/style.css" type="text/css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
      <script type="text/javascript">
        <!--
          function ToolBar_ItemCommand(sender, e) {
              OnSubmit(e.get_item().get_value());
          }
          function OnSubmit(key) {
              parent.mainTableofcontent.CheckSubmit(key);
              return;
        }
       //-->
     </script>      
</head>
<body  class="bgbody" style="margin-top:0;margin-left:0;margin-right:0;margin-bottom:0">
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
                      <ComponentArt:ToolBarItem runat="server" Text="Cập nhật"  Value="settableofcontent"    ImageUrl="addfieldUpdate.png" />
                      <ComponentArt:ToolBarItem ItemType="Separator" Width="1"/>
                      <ComponentArt:ToolBarItem ID="ToolBarItem1" runat="server" Text="Đóng"  Value="close"  ImageUrl="dialog-close.png" />
                    </Items>
                    </ComponentArt:ToolBar>
                </td>
            </tr>
         </table>
      </ContentTemplate>
    </asp:UpdatePanel>    
    <div style="display:none">
        <span  id="span_Toolbar_item0" runat="server">Cập nhật</span>
        <span  id="span_Toolbar_item2" runat="server">Đóng</span>
    </div>        
    </form>
</body>
</html>
