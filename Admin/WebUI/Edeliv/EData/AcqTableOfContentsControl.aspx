<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqTableOfContentsControl.aspx.vb"
    Inherits="eMicLibAdmin.WebUI.Edeliv.Pages_AcqTableOfContentsControl" %>

<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../Images/ComponentArt/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/Menu/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/MenuButton/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/Toolbar/style.css" type="text/css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <style>
       
         select#cboType
         {
             width: 174px;
         }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        <!--
        function ToolBar_ItemCommand(sender, e) {
            OnSubmit(e.get_item().get_value());
        }
        function OnSubmit(key) {
            switch (key) {
                case 'close':
                    top.main.Workform.document.location.href = "WEdataMain.aspx";
                    break;
                case 'acquisition':
                    top.main.Workform.maincontent.loadList();
                    break;
            }
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

        function linkParent(obj) {
            top.main.Workform.maincontent.gridCallback(obj.value);
        }

       //-->
    </script>
</head>
<body class="bgbody" style="margin-top: 0; margin-left: 0; margin-right: 0; margin-bottom: 0">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="false" runat="server" />
    <asp:UpdatePanel ID="upnInput" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table id="table1" style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td valign="top" style="width: 100%;" align="center">
                        <table id="table2" style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td align="right" style="background-color: #fdfdc9; width: 53%" >
                                    <asp:Label ID="lbldisplay" runat="server">Trạng thái tách tệp&nbsp;:&nbsp;</asp:Label>
                                    <select id="cboType" onchange="linkParent(this)">
                                        <option value="0"><span id="span_display_0" runat="server">Tất cả</span></option>
                                        <option value="1"><span id="span_display_2" runat="server">Đã biên mục mục lục</span></option>
                                        <option value="2" selected><span id="span_display_1" runat="server">Chưa biên mục mục
                                            lục</span></option>
                                    </select>
                                </td>
                                <td width="20px" style="background-color: #fdfdc9">
                                </td>
                                <td align="left">
                                    <ComponentArt:ToolBar ID="ToolBar" ImagesBaseUrl="../../Images/ComponentArt/Toolbar/images/FooterControls/"
                                        DefaultItemCssClass="item" DefaultItemHoverCssClass="itemHover" DefaultItemActiveCssClass="itemActive"
                                        DefaultItemTextImageSpacing="2" DefaultItemTextImageRelation="ImageBeforeText"
                                        DefaultItemImageHeight="20" DefaultItemImageWidth="20" Orientation="Horizontal"
                                        UseFadeEffect="false" runat="server">
                                        <ClientEvents>
                                            <ItemSelect EventHandler="ToolBar_ItemCommand" />
                                        </ClientEvents>
                                        <Items>
                                            <ComponentArt:ToolBarItem ID="ToolBarItem1" runat="server" Text="Danh mục" Value="acquisition"
                                                ImageUrl="view_text.png" />
                                            <ComponentArt:ToolBarItem ItemType="Separator" Width="1" />
                                            <ComponentArt:ToolBarItem ID="ToolBarItem5" runat="server" Text="Đóng" Value="close"
                                                ImageUrl="Close.png" />
                                        </Items>
                                    </ComponentArt:ToolBar>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="display: none">
        <asp:HiddenField ID="folderPath" runat="server" Value="" />
        <span id="span_acquisition" runat="server">Danh mục</span> <span id="span_close"
            runat="server">Đóng</span>
    </div>
    </form>
</body>
</html>
