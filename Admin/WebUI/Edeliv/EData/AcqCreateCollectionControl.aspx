<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqCreateCollectionControl.aspx.vb" Inherits="eMicLibAdmin.WebUI.Edeliv.Pages_AcqCreateCollectionControl" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">        
    <link href="../../Images/ComponentArt/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/Menu/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/MenuButton/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/Toolbar/style.css" type="text/css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript">
        <!--
        function ToolBar_ItemCommand(sender, e) {
            OnSubmit(e.get_item().get_value(), 0);
        }

        function OnSubmit(key, val) {
            var intUpdate = getValueUpdate();
            //parent.maincontent.CheckSubmit(key, val);
            top.main.Workform.maincontent.raiseSubmit(key, val, intUpdate);            
            return;
        }

        function setValueUpdate(val) {
            var hdSave = document.getElementById('hdSave');
            if (hdSave) {
                hdSave.value = val;
            }
        }

        function getValueUpdate() {
            var val = 0;
            var hdSave = document.getElementById('hdSave');
            if (hdSave) {
                val = hdSave.value;
            }
            return val;
        }        

        function setEnableButtonItem(val) {
            switch (val) {
                case "New":
                    setValueUpdate(1);
                    ToolBar.beginUpdate();
                    var itemArray = ToolBar.get_items().get_itemArray();
                    for (var i = 0; i < itemArray.length; i++) {
                        var item = itemArray[i];
                        switch (item.get_value()) {
                            case "New":
                                item.set_enabled(false);
                                item.set_imageUrl("addField_disabled.png");
                                break;
                            case "Edit":
                                item.set_enabled(false);
                                item.set_imageUrl("Modify_disabled.png");
                                break;
                            case "Delete":
                                item.set_enabled(false);
                                item.set_imageUrl("Delete_disabled.png");
                                break;
                            case "Save":
                                item.set_enabled(true);
                                item.set_imageUrl("Update.png");
                                break;
                            case "Cancel":
                                item.set_enabled(true);
                                item.set_imageUrl("Reset.png");
                                break;
                        }
                    }
                    ToolBar.endUpdate();
                    break;
                case "Edit":
                    setValueUpdate(0);
                    ToolBar.beginUpdate();
                    var itemArray = ToolBar.get_items().get_itemArray();
                    for (var i = 0; i < itemArray.length; i++) {
                        var item = itemArray[i];
                        switch (item.get_value()) {
                            case "New":
                                item.set_enabled(false);
                                item.set_imageUrl("addField_disabled.png");
                                break;
                            case "Edit":
                                item.set_enabled(false);
                                item.set_imageUrl("Modify_disabled.png");
                                break;
                            case "Delete":
                                item.set_enabled(false);
                                item.set_imageUrl("Delete_disabled.png");
                                break;
                            case "Save":
                                item.set_enabled(true);
                                item.set_imageUrl("Update.png");
                                break;
                            case "Cancel":
                                item.set_enabled(true);
                                item.set_imageUrl("Reset.png");
                                break;
                        }
                    }
                    ToolBar.endUpdate();
                    break;
                case "Delete":
                    setValueUpdate(0);
                    break;
                case "Save":
                    setValueUpdate(0);
                    ToolBar.beginUpdate();
                    var itemArray = ToolBar.get_items().get_itemArray();
                    for (var i = 0; i < itemArray.length; i++) {
                        var item = itemArray[i];
                        switch (item.get_value()) {
                            case "New":
                                item.set_enabled(true);
                                item.set_imageUrl("addField.png");
                                break;
                            case "Edit":
                                item.set_enabled(true);
                                item.set_imageUrl("Modify.png");
                                break;
                            case "Delete":
                                item.set_enabled(true);
                                item.set_imageUrl("Delete.png");
                                break;
                            case "Save":
                                item.set_enabled(false);
                                item.set_imageUrl("Update_disabled.png");
                                break;
                            case "Cancel":
                                item.set_enabled(false);
                                item.set_imageUrl("Reset_disabled.png");
                                break;
                        }
                    }
                    ToolBar.endUpdate();
                    break;
                case "Cancel":
                    setValueUpdate(0);
                    ToolBar.beginUpdate();
                    var itemArray = ToolBar.get_items().get_itemArray();
                    for (var i = 0; i < itemArray.length; i++) {
                        var item = itemArray[i];
                        switch (item.get_value()) {
                            case "New":
                                item.set_enabled(true);
                                item.set_imageUrl("addField.png");
                                break;
                            case "Edit":
                                item.set_enabled(true);
                                item.set_imageUrl("Modify.png");
                                break;
                            case "Delete":
                                item.set_enabled(true);
                                item.set_imageUrl("Delete.png");
                                break;
                            case "Save":
                                item.set_enabled(false);
                                item.set_imageUrl("Update_disabled.png");
                                break;
                            case "Cancel":
                                item.set_enabled(false);
                                item.set_imageUrl("Reset_disabled.png");
                                break;
                        }
                    }
                    ToolBar.endUpdate();
                    break;
            }
        }

       //-->
     </script>   
    
</head>
<body  class="bgbody" style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="false" runat="server" />
    <table id="table1" style="width:100%;" cellpadding="0px" cellspacing="0px" border="0px">
        <tr>
            <td valign="top" style="width:100%;" align="center" >   
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
                    <ComponentArt:ToolBarItem ID="ToolBarItem5" runat="server" Text="Thêm mới"    Value="New"    ImageUrl="Acquisition.png" />
                    <ComponentArt:ToolBarItem ItemType="Separator" runat="server" ID ="Separator5" Width="1"/>
                    <ComponentArt:ToolBarItem ID="ToolBarItem3" runat="server" Text="Sửa"    Value="Edit"    ImageUrl="Modify.png" />
                    <ComponentArt:ToolBarItem ItemType="Separator" runat="server" ID ="Separator3" Width="1"/>
                    <ComponentArt:ToolBarItem ID="ToolBarItem4" runat="server" Text="Xóa"    Value="Delete"    ImageUrl="RecycleBin.png" />
                    <ComponentArt:ToolBarItem ItemType="Separator" runat="server" ID ="Separator4" Width="1"/>
                    <ComponentArt:ToolBarItem ID="ToolBarItem7" runat="server" Text="Hủy" Value="Cancel" ImageUrl="Reset.png" />
                    <ComponentArt:ToolBarItem ItemType="Separator" Width="1"/>
                    <ComponentArt:ToolBarItem ID="ToolBarItem8" runat="server" Text="Lưu"  Value="Save"    ImageUrl="Update.png" />
                    <ComponentArt:ToolBarItem ItemType="Separator" Width="1"/>
                    <ComponentArt:ToolBarItem ID="ToolBarItem6" runat="server"  Text="Đóng"  Value="Close"  ImageUrl="Close.png" />
                    <ComponentArt:ToolBarItem ItemType="Separator" runat="server" ID ="Separator6" Width="1"/>
                </Items>
                </ComponentArt:ToolBar>
            </td>
        </tr>
        </table>
    <div style="display:none">
        <asp:HiddenField ID="hdSave" runat="server" Value="0" />
        <span  id="span_addnew" runat="server">Thêm mới</span>
        <span  id="span_modify" runat="server">Sửa</span>
        <span  id="span_delete" runat="server">Xóa</span>
        <span  id="span_cancel" runat="server">Hủy</span>
        <span  id="span_save" runat="server">Hủy</span>
        <span  id="span_close" runat="server">Đóng</span>
    </div>          
    </form>
</body>
</html>
