<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqDisplayControl.aspx.vb"
    Inherits="eMicLibAdmin.WebUI.Edeliv.Pages_AcqDisplayControl" %>

<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../Images/ComponentArt/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/Menu/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/MenuButton/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/Toolbar/style.css" type="text/css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />

    <style>
       
        #form1 > div {
            background-color: #fdfdc9;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
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

    function RedirectUrl(val) {
        switch (val) {
            case '0':
                visibleToolbar('', true);
                top.main.Workform.maincontent.location = "AcqDisplayFolder.aspx";
                break;
            case '2':
                visibleToolbar('acquisition', true);
                top.main.Workform.maincontent.location = "AcqDisplayStatus.aspx";
                break;
            case '1':
                visibleToolbar('acquisition', true);
                top.main.Workform.maincontent.location = "AcqDisplayFormat.aspx";
                break;
            case '3':
                visibleToolbar('acquisition', true);
                top.main.Workform.maincontent.location = "AcqDisplayCollection.aspx";
                break;
        }
        var cboType;
        cboType = document.getElementById('cboType');
        cboType.selectedIndex = val;
    }
    //-->
    </script>
</head>
<%
    Dim intType As Integer = 0
    If Not Session("displayType") Is Nothing Then
        intType = Session("displayType")
    End If
%>
<body class="bgbody" style="margin-top: 0; margin-left: 0; margin-right: 0; margin-bottom: 0"
    onload="RedirectUrl('<%=intType%>');">
    <form id="form1" runat="server">
        <asp:UpdatePanel ID="upnInput" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <table id="table1" style="width: 90%;" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="left" style="width: 20%">
                            <select id="cboType" onchange="RedirectUrl(this.value)" style="min-width: 150px;">
                                <option value="0"><span id="span_display_1" runat="server">Theo thư mục</span></option>
                                <option value="1"><span id="span_display_4" runat="server">Theo định dạng</span></option>
                                <%--<option value="2"><span  id="span_display_2" runat="server">Theo trạng thái</span></option>--%>
                                <%--<option value="3"><span  id="span_display_3" runat="server">Theo bộ sưu tập</span></option>--%>
                            </select>
                        </td>
                        <td valign="top" style="width: 80%;" align="center">
                            <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="false" runat="server" />
                            <ComponentArt:ToolBar ID="ToolBar" ImagesBaseUrl="../../Images/ComponentArt/Toolbar/images/FooterControls/"
                                DefaultItemCssClass="item" DefaultItemHoverCssClass="itemHover" DefaultItemActiveCssClass="itemActive"
                                DefaultItemTextImageSpacing="2" DefaultItemTextImageRelation="ImageBeforeText"
                                DefaultItemImageHeight="20" DefaultItemImageWidth="20" Orientation="Horizontal"
                                UseFadeEffect="false" runat="server">
                                <ClientEvents>
                                    <ItemSelect EventHandler="ToolBar_ItemCommand" />
                                </ClientEvents>
                                <Items>
                                    <ComponentArt:ToolBarItem ID="ToolBarItem1" runat="server" Text="Biên mục" Value="acquisition"
                                        ImageUrl="Acquisition.png" />
                                    <ComponentArt:ToolBarItem ItemType="Separator" Width="1" />
                                    <ComponentArt:ToolBarItem ID="ToolBarItem5" runat="server" Text="Đóng" Value="close"
                                        ImageUrl="Close.png" />
                                </Items>
                            </ComponentArt:ToolBar>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="display: none">
            <asp:HiddenField ID="folderPath" runat="server" Value="" />
            <span id="span_acquisition" runat="server">Biên mục</span> <span id="span_close"
                runat="server">Đóng</span>
        </div>
    </form>
</body>
</html>
