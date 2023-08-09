<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqCreateCollection.aspx.vb"
    Inherits="eMicLibAdmin.WebUI.Edeliv.Pages_AcqCreateCollection" %>

<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head1" runat="server">
    <script language="JavaScript" type="text/javascript" src="../../js/Public.js"></script>
    <link href="../../Images/ComponentArt/Menu/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/Treeview/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/MenuButton/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/Splitter/Style.css" rel="stylesheet" type="text/css" />
    <link href="../../Images/ComponentArt/Grid/style.css" type="text/css" rel="stylesheet" />
    <link href="../../Images/ComponentArt/Toolbar/style.css" type="text/css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .scroll-pane
        {
            overflow-y: scroll;
            padding-top: 3px;
            padding-right: 3px;
            padding-left: 3px;
            position: relative;
        }
        .TreeView
        {
            border: 5px outset #f0a30a;
        }
        
        .TreeNode
        {
            font-family: tahoma;
            font-size: 15px;
            margin-bottom: 4px;
        }
        .SelectedTreeNode
        {
            color: white;
            cursor: default;
            font-family: tahoma;
            font-size: 15px;
            background-color: #024385;
            background-image: none;
            border: none;
            margin-bottom: 4px;
        }
        .HoverTreeNode
        {
            color: #024385;
            cursor: default;
            font-family: tahoma;
            font-size: 15px;
            background-color: #CCCCCC;
            background-image: none;
            border: none;
            margin-bottom: 4px;
        }
        #SplitterCollection_pane_0 > div
        {
            margin-right: 27px;
        }
        #Gridformat_dom > table
        {
            border-collapse: collapse;
        }
        
        .row-hd
        {
            background-color: #024385;
        }
        .cell.MultiFont > div
        {
            width: auto !important;
            text-align: center !important;
        }
        #AsyncFileUpload1 :hover {
            border:none !important;
        }
        #AsyncFileUpload1__ctl1:hover {
            border:none !important;
        }
         #AsyncFileUpload1__ctl0 :hover {
            border:none !important;
        }
      .button-form {
          border:none !important;
          box-shadow:none !important;
      }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">

        var viewerHeight = getHeight();
        var viewerWidth = (getWidth() * 80 / 100);
        var intAddNew = 0;

        function AjaxCallBack_onLoad(sender, e) {
        }

        function getWidth() {
            var screenWidth = 0;
            var divWidth = 0;
            var divWidthTxt = "0";
            var myMainWidth = 1000;
            if (window.innerWidth) {
                screenWidth = window.innerWidth;
            }
            else if (document.documentElement && document.documentElement.clientWidth) {
                screenWidth = document.documentElement.clientWidth;
            }
            else if (document.body) {
                screenWidth = document.body.clientWidth;
            }
            return screenWidth;

        } // end getWidth

        function getHeight() {
            var screenHeight = 0;
            if (window.innerHeight) {
                screenHeight = window.innerHeight;
            }
            else if (document.documentElement && document.documentElement.clientHeight) {
                screenHeight = document.documentElement.clientHeight;
            }
            else if (document.body) {
                screenHeight = document.body.clientHeight;
            }
            return screenHeight;

        } // end getHeight

        // Forces the treeview to adjust to the new size of its container          
        function resizeTree(sender, eventArgs) {
            var iUnit;
            iUnit = 8;
            var pane = eventArgs.get_pane();
            var newPaneWidth = pane.get_width();
            var newPaneHeight = pane.get_height();

            if (window.TreeViewCollection && window.CallbackTreeview && newPaneWidth && newPaneWidth > 2 && newPaneHeight && newPaneHeight > 2) {
                CallbackTreeview.element.style.width = (newPaneWidth - 2) + 'px';
                //CallbackTreeview.element.style.height = (newPaneHeight - iUnit) + 'px';
                CallbackTreeview.element.style.height = viewerHeight - 40 + 'px';
                TreeViewCollection.render();
            }
        }

        // Handles the TreeView node select event 
        function TreeViewCollection_onNodeSelect(sender, eventArgs) {
            var node = eventArgs.get_node();
            var txtTenbosuutap = document.getElementById('txtTenbosuutap');
            if (txtTenbosuutap) {
                txtTenbosuutap.value = node.get_text();
            }
            var txtMotabosuutap = document.getElementById('txtMotabosuutap');
            if (txtMotabosuutap) {
                var attributes = node.getProperty("description");
                if (attributes) {
                    txtMotabosuutap.value = attributes;
                }
                else {
                    txtMotabosuutap.value = "";
                }
            }
            var chkShowOpac = document.getElementById('chkShowOpac');
            if (chkShowOpac) {
                var attributes1 = node.getProperty("isShow");
                if (attributes1 == true) {
                    chkShowOpac.checked = true;
                }
                else {
                    chkShowOpac.checked = false;
                }
            }

            var MyImageCover = document.getElementById('MyImageCover');
            if (MyImageCover) {
                var attributes2 = node.getProperty("cover");
                if (attributes2) {
                    var strImageCover = '';
                    var intImageCover = attributes2.toString().indexOf("\\ImageCover\\");
                    if (intImageCover > 0) {
                        strImageCover = attributes2.toString().substring(intImageCover + 11);
                        strImageCover = replaceAll(strImageCover, "\\", "/");
                        MyImageCover.src = "../../Upload/ImageCover" + strImageCover;
                    }
                }
                else {
                    MyImageCover.src = "../../Upload/ImageCover/collectionCover.jpg";
                }
            }


            var id = node.get_id();
            var imgCover = MyImageCover.src;
            var intCount = callbackGetDocIds(id, imgCover);
            if (intCount > 0) {
                indNum.set_minValue(1);
                indNum.set_maxValue(intCount);
                indNum.set_value(1);
                MaxNum.set_value(intCount);
                GridCallBack.callback(1);
            }
            else {
                indNum.set_minValue(0);
                indNum.set_maxValue(0);
                indNum.set_value(0);
                MaxNum.set_value(0);
                GridCallBack.callback(0);
            }
        }

        function replaceAll(strText, strTarget, strSubString) {
            var strText = strText;
            var intIndexOfMatch = strText.indexOf(strTarget);

            // Keep looping while an instance of the target string
            // still exists in the string.
            while (intIndexOfMatch != -1) {
                // Relace out the current instance.
                strText = strText.replace(strTarget, strSubString);

                // Get the index of any next matching substring.
                intIndexOfMatch = strText.indexOf(strTarget);
            }

            // Return the updated string with ALL the target strings
            // replaced out with the new substring.
            return strText;
        }


        // Forces the grid to adjust to the new size of its container          
        function resizeGrid(sender, eventArgs) {
            var iUnit;
            iUnit = 60;
            var iUnitHeight = 125 + 68;
            var pane = eventArgs.get_pane();
            var newPaneWidth = pane.get_width();
            var newPaneHeight = pane.get_height();
            if (window.Gridformat && window.GridCallBack && newPaneWidth && newPaneWidth > 2 && newPaneHeight && newPaneHeight > 2) {
                GridCallBack.element.style.width = (newPaneWidth - 2 - iUnit) + 'px';
                //GridCallBack.element.style.height = (newPaneHeight - 4 - iUnitHeight) + 'px';
                GridCallBack.element.style.height = '300px'; //viewerHeight - 250 + 'px';
                Gridformat.render();
            }
        }


        function raiseSubmit(key, val, updateFlag) {
            intAddNew = updateFlag;
            CheckSubmit(key, val);
        }

        function addNodeCollection(node, nid, name, description, isShow, cover) {
            TreeViewCollection.beginUpdate();
            var newNode = new ComponentArt.Web.UI.TreeViewNode();
            newNode.set_text(name);
            newNode.set_id(nid);
            newNode.setProperty("description", description);
            newNode.setProperty("cover", cover);
            newNode.setProperty("isShow", isShow);
            if (isShow == 1) {
                newNode.set_imageUrl("checkbox_yes.png");
            }
            else {
                newNode.set_imageUrl("checkbox_no.png");
            }
            TreeViewCollection.findNodeById(node.get_id()).get_nodes().add(newNode);
            TreeViewCollection.endUpdate();
            TreeViewCollection.selectNodeById(nid);
        }

        function updateNodeCollection(node, nid, name, description, isShow, cover) {
            TreeViewCollection.beginUpdate();
            node.set_text(name);
            node.set_id(nid);
            node.setProperty("description", description);
            node.setProperty("cover", cover);
            node.setProperty("isShow", isShow);
            if (isShow == 1) {
                node.set_imageUrl("checkbox_yes.png");
            }
            else {
                node.set_imageUrl("checkbox_no.png");
            }
            TreeViewCollection.endUpdate();
            TreeViewCollection.selectNodeById(nid);
        }

        function removeNodeCollection() {
            var node = TreeViewCollection.get_selectedNode();
            if (node) {
                node.remove();
                var idParentnode = node.get_parentNode().get_id();
                if (idParentnode) {
                    TreeViewCollection.selectNodeById(idParentnode);
                }
            }
        }

        function deleteCollection(id) {
            var intResult = callbackDeleteCollection(id);
            var span_info;
            span_info = document.getElementById('span_info');
            if (intResult == 1) {
                removeNodeCollection();
                var span_delete_success;
                span_delete_success = document.getElementById('span_delete_success');
                top.showDialogInfo('', true, 6, span_info.innerHTML, span_delete_success.innerHTML);
            }
            else {
                var span_delete_fail;
                span_delete_fail = document.getElementById('span_delete_fail');
                top.showDialogInfo('', true, 5, span_info.innerHTML, span_delete_fail.innerHTML);
            }
        }

        function CheckSubmit(key, val) {
            if (key) {
                switch (key) {
                    case 'New':
                        var curNode = TreeViewCollection.get_selectedNode();
                        var span_info;
                        span_info = document.getElementById('span_info');
                        var span_toolbar_add_alert = document.getElementById('span_toolbar_add_alert');
                        if (curNode != null) {
                            top.main.Workform.footercontent.setEnableButtonItem(key);
                            var idNode = curNode.get_id();
                            //top.main.Workform.maincontent.location = "AcqViewRecordFilter.aspx?addCollection=1&collection=" + idNode.toString();
                            top.main.Workform.maincontent.location = "AcqUniFilter.aspx?addCollection=1&collection=" + idNode.toString();
                        }
                        else {
                            top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_add_alert.innerHTML);
                        }
                        break;
                    case 'Edit':
                        var curNode = TreeViewCollection.get_selectedNode();
                        var span_info;
                        span_info = document.getElementById('span_info');
                        var span_toolbar_add_alert = document.getElementById('span_toolbar_add_alert');
                        if (curNode != null) {
                            var idNode = curNode.get_id();
                            if (idNode > 0) {
                                top.main.Workform.footercontent.setEnableButtonItem(key);
                                top.main.Workform.maincontent.location = "AcqUniFilter.aspx?addCollection=0&collection=" + idNode.toString();
                            }
                            else {
                                top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_add_alert.innerHTML);
                            }
                        }
                        else {
                            top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_add_alert.innerHTML);
                        }
                        break;
                    case 'Delete':
                        var id = 0;
                        var curNode = TreeViewCollection.get_selectedNode();
                        if (curNode) {
                            var id = curNode.get_id();
                        }
                        if (id > 0) {
                            var span_cancel_para;
                            span_cancel_para = document.getElementById('span_cancel_para');
                            var span_delete_info;
                            span_delete_info = document.getElementById('span_delete_info');
                            top.showDialogConfirmInfo('deleteCollection(' + String(id) + ')' + 'callback', true, 3, span_cancel_para.innerHTML, span_delete_info.innerHTML, true);
                        }
                        else {
                            var span_info;
                            span_info = document.getElementById('span_info');
                            var span_toolbar_add_alert = document.getElementById('span_toolbar_add_alert');
                            top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_add_alert.innerHTML);
                        }
                        break;
                    case 'Cancel':
                        top.main.Workform.footercontent.setEnableButtonItem(key);
                        top.main.Workform.maincontent.location = "AcqCreateCollection.aspx";
                        break;
                    case 'Save':
                        var intResults = -1;
                        var curNode = TreeViewCollection.get_selectedNode();
                        var txtTenbosuutap = document.getElementById('txtTenbosuutap');
                        var txtMotabosuutap = document.getElementById('txtMotabosuutap');
                        var chkShowOpac = document.getElementById('chkShowOpac');
                        var hidFilterCollectionId = document.getElementById('hidFilterCollectionId');
                        var strImageCover = '';
                        var intCheck = 0;
                        var idNode = 0;
                        if (curNode != null) {
                            idNode = curNode.get_id();
                            if (idNode >= 0) {
                                //updateCollection
                                var idNodeParent = 0;
                                if (intAddNew == 1) {
                                    idNodeParent = idNode;
                                }
                                else {
                                    if (idNode != 0) {
                                        var curNodeParent = curNode.get_parentNode();
                                        if (curNodeParent) {
                                            idNodeParent = curNodeParent.get_id();
                                        }
                                    }
                                }

                                if (chkShowOpac.checked) {
                                    intCheck = 1;
                                }

                                if (txtTenbosuutap.value == '') {
                                    intResults = -10;
                                }
                                else {
                                    intResults = callbackUpdateCollection(intAddNew, idNode, txtTenbosuutap.value, txtMotabosuutap.value, intCheck, idNodeParent, hidFilterCollectionId.value);
                                }
                            }
                        }
                        var span_info;
                        span_info = document.getElementById('span_info');
                        if (intResults == -10) {
                            var span_require;
                            span_require = document.getElementById('span_require');
                            top.showDialogInfo('', true, 5, span_info.innerHTML, span_require.innerHTML);
                        }
                        else {
                            if (intResults > 0) {
                                var span_update_success;
                                span_update_success = document.getElementById('span_update_success');
                                top.showDialogInfo('', true, 6, span_info.innerHTML, span_update_success.innerHTML);
                                top.main.Workform.footercontent.setEnableButtonItem(key);
                                strImageCover = callbackGetImageCover();
                                if (intAddNew == 1) {
                                    addNodeCollection(curNode, intResults, txtTenbosuutap.value, txtMotabosuutap.value, intCheck, strImageCover);
                                }
                                else {
                                    updateNodeCollection(curNode, intResults, txtTenbosuutap.value, txtMotabosuutap.value, intCheck, strImageCover);
                                }
                                txtTenbosuutap.disabled = 'disabled';
                                txtMotabosuutap.disabled = 'disabled';
                              
                                document.getElementById('AsyncFileUpload1__ctl2').disabled = 'disabled';
                                document.getElementById('lnkDelete').style.display = 'none';
                            }
                            else if (intResults == 0) {
                                var span_no_record;
                                span_no_record = document.getElementById('span_no_record');
                                top.showDialogInfo('', true, 5, span_info.innerHTML, span_no_record.innerHTML);
                                top.main.Workform.footercontent.setEnableButtonItem(key);
                            }
                            else {
                                var span_update_fail;
                                span_update_fail = document.getElementById('span_update_fail');
                                top.showDialogInfo('', true, 5, span_info.innerHTML, span_update_fail.innerHTML);
                                top.main.Workform.footercontent.setEnableButtonItem(key);
                            }
                        }
                        break;
                    case 'Close':
                        top.main.Workform.document.location.href = "WEdataMain.aspx";
                        break;
                    case 'first':
                        GridCallBack.callback(val);
                        break;
                    case 'previous':
                        GridCallBack.callback(val);
                        break;
                    case 'next':
                        GridCallBack.callback(val);
                        break;
                    case 'last':
                        GridCallBack.callback(val);
                        break;
                }
            }
        }

        function GridCallBack_onBeforeCallback(sender, e) {
            try {
                Gridformat.dispose();
            }
            catch (err) {
                //alert('GridCallBack_onBeforeCallback' + err.message);
            }
        }

        function ToolBarControl1_ItemCommand(sender, e) {
            var NumRec = document.getElementById('NumRec');
            switch (e.get_item().get_value()) {
                case 'first':
                    indNum.set_value(1);
                    NumRec.value = indNum.get_value();
                    break;
                case 'previous':
                    indNum.decreaseValue();
                    if (indNum.get_value() < 1) {
                        indNum.set_value(1);
                    }
                    NumRec.value = indNum.get_value();
                    break;
            }
            CheckSubmit(e.get_item().get_value(), NumRec.value);
        }

        function ToolBarControl2_ItemCommand(sender, e) {
            var NumRec = document.getElementById('NumRec');
            switch (e.get_item().get_value()) {
                case 'next':
                    indNum.increaseValue();
                    if (parseInt(indNum.get_value()) > parseInt(MaxNum.get_value())) {
                        indNum.set_value(MaxNum.get_value());
                    }
                    NumRec.value = indNum.get_value();
                    break;
                case 'last':
                    indNum.set_value(MaxNum.get_value());
                    NumRec.value = indNum.get_value();
                    break;
            }
            CheckSubmit(e.get_item().get_value(), NumRec.value);
        }

        function indNum_KeyPress(sender, eventArgs) {
            var evt = window.event;
            if (evt.keyCode == 13) {
                var NumRec = document.getElementById('NumRec');
                NumRec.value = indNum.get_value();
                CheckSubmit('next', NumRec.value);
            }
        }



        function uploadError(sender, args) {
            document.getElementById('lblstatusUploadCover').innerText = args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>";
        }

        function StartUpload(sender, args) {
            var span_start_upload;
            span_start_upload = document.getElementById('span_start_upload');
            document.getElementById('lblstatusUploadCover').innerText = span_start_upload.innerHTML;
        }

        function UploadComplete(sender, args) {
            var filename = args.get_fileName();
            var contentType = args.get_contentType();
            if (contentType.indexOf('image') >= 0) {
                /*var text = "Size of " + filename + " is " + args.get_length() + " bytes";
                if (contentType.length > 0) {
                text += " and content type is '" + contentType + "'.";
                }
                document.getElementById('lblstatusUploadCover').innerText = text;*/

                var span_finish_upload;
                span_finish_upload = document.getElementById('span_finish_upload');
                document.getElementById('lblstatusUploadCover').innerText = span_finish_upload.innerHTML;

                var curdate = new Date();
                var d = curdate.getDate().toString();
                if (d.toString().length < 2) {
                    d = '0' + d;
                }
                var m = (curdate.getMonth() + 1).toString();
                if (m.toString().length < 2) {
                    m = '0' + m;
                }
                var y = curdate.getFullYear();
                var folder;
                folder = y.toString() + m.toString() + d.toString();

                filename = callbackChangeFileName(filename);

                var MyImageCover = document.getElementById('MyImageCover');
                MyImageCover.src = "../../Upload/ImageCover/" + folder + "/" + filename;
            }
            else {
                var span_info;
                span_info = document.getElementById('span_info');
                var span_file_error;
                span_file_error = document.getElementById('span_file_error');
                top.showDialogInfo('', true, 5, span_info.innerHTML, span_file_error.innerHTML);
            }
        }

        function remove_image() {
            DeleteImageCover();
        }

        function DeleteImageCover() {
            var valReturn;
            valReturn = Delete_Image_Cover();
            if (valReturn) {
                var MyImageCover = document.getElementById('MyImageCover');
                MyImageCover.src = "../../Upload/ImageCover/collectionCover.jpg";
            }
        }

        function TreeViewCollection_onNodeBeforeMove(sender, eventArgs) {
            var movingNode = eventArgs.get_node();
            var sourceTreeView = eventArgs.get_node().get_parentTreeView();
            var targetNode = eventArgs.get_newParentNode();
            var targetTreeView = eventArgs.get_newParentTreeView();

            var span_treeview_move1, span_treeview_move2;
            span_treeview_move1 = document.getElementById('span_treeview_move1');
            span_treeview_move2 = document.getElementById('span_treeview_move2');
            var doMove = false;
            doMove = confirm(span_treeview_move1.innerHTML + " '" + movingNode.get_text() + "' " + span_treeview_move2.innerHTML + " '" + targetNode.get_text() + "'?");
            if (doMove) {
                var valReturn;
                valReturn = MoveCollection(movingNode.get_id(), targetNode.get_id());
                if (!valReturn) {
                    var span_treeivew_update_Tableofcontent;
                    span_treeivew_update_Tableofcontent = document.getElementById('span_treeivew_update_Tableofcontent');
                    alert(span_treeivew_update_Tableofcontent.innerHTML);
                }
            }
            else
                eventArgs.set_cancel(true);
        }
                     
    </script>
</head>
<body style="margin: 0px;  left: 3px;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" />
    <table width="1000" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:Label ID="lblRowTitlex" CssClass="titlerowtextread main-head-form" runat="server">Quản lý bộ sưu tập</asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <ComponentArt:Splitter runat="server" ID="SplitterCollection" Height="980px" FillWidth="true"
                    ImagesBaseUrl="../../Images/ComponentArt/Splitter/Images/">
                    <Layouts>
                        <ComponentArt:SplitterLayout>
                            <Panes Orientation="Horizontal" SplitterBarCollapseImageUrl="splitter_horCol.gif"
                                SplitterBarCollapseHoverImageUrl="splitter_horColHover.gif" SplitterBarExpandImageUrl="splitter_horExp.gif"
                                SplitterBarExpandHoverImageUrl="splitter_horExpHover.gif" SplitterBarCollapseImageWidth="1"
                                SplitterBarCollapseImageHeight="116" SplitterBarCssClass="HorizontalSplitterBar"
                                SplitterBarCollapsedCssClass="CollapsedHorizontalSplitterBar" SplitterBarActiveCssClass="ActiveSplitterBar"
                                SplitterBarWidth="1">
                                <ComponentArt:SplitterPane PaneContentId="TreeViewContent" Width="20%" MinWidth="50">
                                    <ClientEvents>
                                        <PaneResize EventHandler="resizeTree" />
                                    </ClientEvents>
                                </ComponentArt:SplitterPane>
                                <ComponentArt:SplitterPane PaneContentId="GridContent" Width="80%" MinWidth="100"
                                    Visible="true" AllowScrolling="True" Height="400px">
                                    <ClientEvents>
                                        <PaneResize EventHandler="resizeGrid" />
                                    </ClientEvents>
                                </ComponentArt:SplitterPane>
                            </Panes>
                        </ComponentArt:SplitterLayout>
                    </Layouts>
                    <Content>

                        <ComponentArt:SplitterPaneContent ID="TreeViewContent">
                            <div id="TreeContainer" class="TreeContainer">
                                <ComponentArt:CallBack ID="CallbackTreeview" runat="server">
                                    <ClientEvents>
                                        <Load EventHandler="AjaxCallBack_onLoad" />
                                    </ClientEvents>
                                    <Content>
                                        <ComponentArt:TreeView ID="TreeViewCollection" Width="100%" AutoScroll="true" FillContainer="true"
                                            HoverPopupEnabled="true" HoverPopupNodeCssClass="HoverPopup" DragAndDropEnabled="true"
                                            NodeEditingEnabled="false" KeyboardEnabled="false" CssClass="TreeView" NodeCssClass="TreeNode"
                                            SelectedNodeCssClass="SelectedTreeNode" HoverNodeCssClass="HoverTreeNode" LineImageWidth="19"
                                            LineImageHeight="20" DefaultImageWidth="16" DefaultImageHeight="16" ItemSpacing="0"
                                            ImagesBaseUrl="../../Images/ComponentArt/Treeview/images/" NodeLabelPadding="3"
                                            ShowLines="true" LineImagesFolderUrl="../../Images/ComponentArt/Treeview/images/lines/"
                                            CollapseNodeOnSelect="false" EnableViewState="true" runat="server">
                                            <ClientEvents>
                                                <NodeSelect EventHandler="TreeViewCollection_onNodeSelect" />
                                                <NodeBeforeMove EventHandler="TreeViewCollection_onNodeBeforeMove" />
                                            </ClientEvents>
                                        </ComponentArt:TreeView>
                                    </Content>
                                </ComponentArt:CallBack>
                            </div>
                        </ComponentArt:SplitterPaneContent>

                        <ComponentArt:SplitterPaneContent ID="GridContent">
                            <div style="width:100%;">                                
                                <table id="tbCollection" cellpadding="0px" cellspacing="0px" border="0px" style="width:97%;">
                                    <tr>
                                        <td colspan="5">
                                            <div class=" row-detail col-right-8 show-form-view" style="width: 99%">
                                                <h1 class="main-group-form">
                                                    Thông tin bộ sưu tập</h1>
                                                <div class="row-detail">
                                                    <p>
                                                        Tên bộ sưu tập :</p>
                                                    <div class="input-control">
                                                        <div class="input-form ">
                                                            <asp:TextBox ID="txtTenbosuutap" runat="server" Width="100%" MaxLength="100"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row-detail">
                                                    <p>
                                                        Mô tả :</p>
                                                    <div class="input-control">
                                                        <div class="input-form ">
                                                            <asp:TextBox ID="txtMotabosuutap" runat="server" TextMode="MultiLine" Rows="5" Width="100%"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row-detail">
                                                    <p>
                                                        Hiển thị OPAC :</p>
                                                  
                                                        <input type="checkbox" ID="chkShowOpac" runat="server"  />
                                                  <label for="chkShowOpac"></label>
                                                </div>
                                                <div class="row-detail">
                                                    <p>
                                                        Ảnh bìa :</p>
                                                    <div class="input-control">
                                                        <div class="input-form ">
                                                            <br />
                                                            <asp:Label ID="lblstatusUploadCover" runat="server" Style="font-family: Arial; font-size: small;"></asp:Label>
                                                            <img runat="server" id="MyImageCover" src="../../Upload/ImageCover/collectionCover.jpg"
                                                                style="width: 200px; height: 133px; border: 1px;" />
                                                            <div id="rLink" runat="server">
                                                                <a href="javascript:void(0);" onclick="remove_image();">
                                                                    <asp:Label runat="server" ID="lnkDelete" Text="Xóa" Visible="true" /></a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row-detail">
                                                        <div class="button-control">
                                                            <div class="button-form">
                                                                <cc1:AsyncFileUpload ID="AsyncFileUpload1" runat="server" OnClientUploadError="uploadError"
                                                                    OnClientUploadStarted="StartUpload" OnClientUploadComplete="UploadComplete" CompleteBackColor="#FDFDC9"
                                                                    UploaderStyle="Traditional"  ThrobberID="Throbber"
                                                                    OnUploadedComplete="AsyncFileUpload1_UploadedComplete" />
                                                                <asp:Label ID="Throbber" runat="server" Style="display: none"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <div class=" row-detail col-right-8 show-form-view" style="width:99%;height:32px;">
                                    <div class="main-group-form">
                                        Thông tin bản ghi
                                    </div>
                                </div>
                                <table style="width:95%;" cellspacing="0px" cellpadding="0px" border="0px">
                                    <tr style="width:95%;text-align:left;">                                         
                                        <td colspan="5">
                                            <div class="scroll-pane">
                                                <ComponentArt:CallBack ID="GridCallBack" CssClass="GridContainer" runat="server"
                                                    Height="210px" LoadingPanelFadeDuration="500" LoadingPanelFadeMaximumOpacity="60">
                                                    <ClientEvents>
                                                        <BeforeCallback EventHandler="GridCallBack_onBeforeCallback" />
                                                    </ClientEvents>
                                                    <Content>
                                                        <ComponentArt:Grid ID="Gridformat" FillContainer="true" RunningMode="Client" KeyboardEnabled="false"
                                                            CssClass="GridTree" ShowFooter="false" FooterCssClass="GridFooternew" ImagesBaseUrl="../../Images/ComponentArt/Grid/images/"
                                                            EnableViewState="false" GroupBySortAscendingImageUrl="group_asc.gif" GroupBySortDescendingImageUrl="group_desc.gif"
                                                            GroupBySortImageWidth="10" GroupBySortImageHeight="10" IndentCellWidth="22" AllowEditing="false"
                                                            AllowTextSelection="true" AllowMultipleSelect="false" PageSize="200" Width="100%"
                                                            Height="100%" runat="server">
                                                            <Levels>
                                                                <ComponentArt:GridLevel AllowGrouping="false" ShowTableHeading="false" ShowSelectorCells="false"
                                                                    HeadingCellCssClass="cell" HeadingCellHoverCssClass="cell" HeadingRowCssClass="row-hd"
                                                                    HeadingTextCssClass="txt" ShowHeadingCells="true" DataCellCssClass="DataCell"
                                                                    RowCssClass="Row" SortedDataCellCssClass="SortedDataCell" SortedHeadingCellCssClass="SortedHeadingCell"
                                                                    ColumnReorderIndicatorImageUrl="reorder.gif" SortAscendingImageUrl="asc.gif"
                                                                    SortDescendingImageUrl="desc.gif" SortImageWidth="10" SortImageHeight="19">
                                                                    <Columns>
                                                                        <ComponentArt:GridColumn DataField="FieldCode" DataCellClientTemplateId="ThreadTemplateFieldCode"
                                                                            HeadingText="&nbsp;&nbsp;Chỉ thị&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                                                                            HeadingCellCssClass="MultiFont" FixedWidth="false" SortImageJustify="false" AllowSorting="False" />
                                                                        <ComponentArt:GridColumn DataField="Ind" DataCellClientTemplateId="ThreadTemplateInd"
                                                                            HeadingText="&nbsp;&nbsp;Nhãn trường&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                                                                            HeadingCellCssClass="MultiFont" FixedWidth="true" SortImageJustify="false" AllowSorting="False" />
                                                                        <ComponentArt:GridColumn DataField="Content" DataCellClientTemplateId="ThreadTemplateContent"
                                                                            HeadingCellCssClass="MultiFont" HeadingText="&nbsp;&nbsp;Nội dung trường&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                                                                            AllowSorting="False" TextWrap="true" />
                                                                    </Columns>
                                                                </ComponentArt:GridLevel>
                                                            </Levels>
                                                            <ClientTemplates>
                                                                <ComponentArt:ClientTemplate ID="ThreadTemplateFieldCode">
                                                                    <table cellspacing="3px" cellpadding="3px" border="0px" style="width: 100%">
                                                                        <tr>
                                                                            <td style="width: 100%; padding: 3px;" valign="top" class="MultiFont">
                                                                                ## DataItem.GetMember("FieldCode").Value ##
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ComponentArt:ClientTemplate>
                                                                <ComponentArt:ClientTemplate ID="ThreadTemplateInd">
                                                                    <table cellspacing="3px" cellpadding="3px" border="0px" style="width: 100%">
                                                                        <tr>
                                                                            <td style="width: 100%; padding: 3px;" valign="top" class="MultiFont">
                                                                                ## DataItem.GetMember("Ind").Value ##
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ComponentArt:ClientTemplate>
                                                                <ComponentArt:ClientTemplate ID="ThreadTemplateContent">
                                                                    <table cellspacing="3px" cellpadding="3px" border="0px" style="width: 100%">
                                                                        <tr>
                                                                            <td style="width: 100%" valign="top" class="MultiFont">
                                                                                ## ReplaceAll(DataItem.GetMember("Content").Value,'&lt;br/&gt;','<br />
                                                                                ') ##
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ComponentArt:ClientTemplate>
                                                            </ClientTemplates>
                                                        </ComponentArt:Grid>
                                                    </Content>
                                                    <LoadingPanelClientTemplate>
                                                        <table style="width: 100%; height: 100%;" cellspacing="0px" cellpadding="0px" border="0px"
                                                            bgcolor="#e0e0e0">
                                                            <tr>
                                                                <td align="center">
                                                                    <table cellspacing="0px" cellpadding="0px" border="0px">
                                                                        <tr>
                                                                            <td style="font-size: 10px;">
                                                                                Đang nạp dữ liệu...&nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <img src="../../images/spinner.gif" width="16px" height="16px" border="0px" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </LoadingPanelClientTemplate>
                                                </ComponentArt:CallBack>
                                            </div>
                                        </td>
                                    </tr>                                   
                                </table>
                                <table style="width:95%;" cellspacing="0px" cellpadding="0px" border="0px">
                                     <tr style="background-color: #EEEEEE; height: 30px;width:95%;" >
                                        <td align="right" style="width:90%;">
                                            <div class=" row-detail col-right-8 show-form-view" style="width:96%;">&nbsp;</div>
                                        </td>
                                        <td align="left" style="width: 1%">
                                            <ComponentArt:ToolBar ID="ToolBarControl1" ImagesBaseUrl="../../Images/ComponentArt/Toolbar/images/pager/"
                                                DefaultItemCssClass="item" DefaultItemHoverCssClass="itemHover" DefaultItemActiveCssClass="itemActive"
                                                DefaultItemTextImageSpacing="2" DefaultItemTextImageRelation="ImageBeforeText"
                                                DefaultItemImageHeight="22" DefaultItemImageWidth="22" Orientation="Horizontal"
                                                UseFadeEffect="false" runat="server">
                                                <ClientEvents>
                                                    <ItemSelect EventHandler="ToolBarControl1_ItemCommand" />
                                                </ClientEvents>
                                                <Items>
                                                    <ComponentArt:ToolBarItem ID="ToolBarItem1" runat="server" Text="" Value="first"
                                                        ImageUrl="first.gif" />
                                                    <ComponentArt:ToolBarItem ItemType="Separator" Width="1" />
                                                    <ComponentArt:ToolBarItem ID="ToolBarItem2" runat="server" Text="" Value="previous"
                                                        ImageUrl="prev.gif" />
                                                </Items>
                                            </ComponentArt:ToolBar>
                                        </td>
                                        <td align="left" style="width: 1%" valign="middle">
                                            <ComponentArt:NumberInput runat="server" ID="indNum" CssClass="valid" EmptyCssClass="empty"
                                                FocusedValidCssClass="focused-valid" FocusedCssClass="focused" InvalidCssClass="invalid"
                                                DisabledCssClass="disabled" Width="70px" NumberType="Number" Value="0" DecimalDigits="0"
                                                Increment="1" MaxLength="15">
                                                <ClientEvents>
                                                    <KeyPress EventHandler="indNum_KeyPress" />
                                                </ClientEvents>
                                            </ComponentArt:NumberInput>
                                        </td>
                                        <td align="left" style="width: 1%" valign="middle">
                                            <ComponentArt:NumberInput runat="server" ID="MaxNum" CssClass="valid" EmptyCssClass="empty"
                                                FocusedValidCssClass="focused-valid" FocusedCssClass="focused" InvalidCssClass="invalid"
                                                DisabledCssClass="disabled" Width="70px" NumberType="Number" Value="0" DecimalDigits="0"
                                                Enabled="false" MaxLength="15">
                                            </ComponentArt:NumberInput>
                                        </td>
                                        <td align="left" style="width: 1%">
                                            <ComponentArt:ToolBar ID="ToolBarControl2" ImagesBaseUrl="../../Images/ComponentArt/Toolbar/images/pager/"
                                                DefaultItemCssClass="item" DefaultItemHoverCssClass="itemHover" DefaultItemActiveCssClass="itemActive"
                                                DefaultItemTextImageSpacing="2" DefaultItemTextImageRelation="ImageBeforeText"
                                                DefaultItemImageHeight="22" DefaultItemImageWidth="22" Orientation="Horizontal"
                                                UseFadeEffect="false" runat="server">
                                                <ClientEvents>
                                                    <ItemSelect EventHandler="ToolBarControl2_ItemCommand" />
                                                </ClientEvents>
                                                <Items>
                                                    <ComponentArt:ToolBarItem ID="ToolBarItem9" runat="server" Text="" Value="next" ImageUrl="next.gif" />
                                                    <ComponentArt:ToolBarItem ItemType="Separator" Width="1" />
                                                    <ComponentArt:ToolBarItem ID="ToolBarItem10" runat="server" Text="" Value="last"
                                                        ImageUrl="last.gif" />
                                                </Items>
                                            </ComponentArt:ToolBar>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ComponentArt:SplitterPaneContent>

                    </Content>
                </ComponentArt:Splitter>
            </td>
        </tr>
    </table>
    <div style="position: absolute; top: 0px; left: 0px; visibility: hidden;">
        <asp:HiddenField ID="NumRec" runat="server" Value="1" />
        <asp:HiddenField ID="hidFilterCollectionId" runat="server" Value="0" />
        <ComponentArt:ToolBar ID="ToolbarTemp" runat="server" Visible="false">
        </ComponentArt:ToolBar>
        <ComponentArt:Grid ID="gridTemp" runat="server" Visible="false">
        </ComponentArt:Grid>
        <ComponentArt:TreeView ID="TreeviewTemp" Width="100%" runat="server" Visible="false">
        </ComponentArt:TreeView>
        <span id="span_toolbar_add_alert" runat="server">Xin vui lòng click chọn bộ sưu tập.</span>
        <span id="span_toolbar_edit_alert" runat="server">Không thể xóa/sửa Bộ sưu tập này...</span>
        <span id="span_require" runat="server">Xin vui lòng nhập tên bộ sưu tập</span> <span
            id="span_treeview_new_Tableofcontent" runat="server">Thêm mới Bộ sưu tập</span>
        <span id="span_treeview_edit_Tableofcontent" runat="server">Sửa Bộ sưu tập</span>
        <span id="span_treeview_delete_Tableofcontent" runat="server">Xóa Bộ sưu tập</span>
        <span id="span_grid_nodata" runat="server">Không có dữ liệu</span> <span id="span_grid_page"
            runat="server">Trang</span> <span id="Span_grid_of" runat="server">của</span>
        <span id="span_info" runat="server">Thông báo!; Đóng</span> <span id="span_grid_check"
            runat="server">Xin vui lòng đánh dấu để chọn tệp biên mục...</span> <span id="span_grid_check_delete"
                runat="server">Xin vui lòng đánh dấu để chọn tệp xóa...</span> <span id="span_cancel_para"
                    runat="server">Cảnh báo!; Chấp nhận ; Không chấp nhận</span> <span id="span_delete_info"
                        runat="server">Bạn chắc chắn muốn xóa bộ sưu tập này không?</span>
        <span id="span_grid_delete_file_info" runat="server">Xóa</span> <span id="span_grid_delete_file"
            runat="server">Bạn có chắc chắn muốn xóa tệp này không?</span> <span id="span_treeview_root_collection"
                runat="server">Bộ sưu tập</span> <span id="span_update_success" runat="server">Cập nhật
                    bộ sưu tập thành công.</span> <span id="span_update_fail" runat="server">Lỗi cập nhật
                        bộ sưu tập.</span> <span id="span_no_record" runat="server">Không có dữ liệu bản ghi
                            tài liệu điện tử để tạo bộ sưu tập. Xin vui lòng chọn lại điều kiện lọc!</span>
        <span id="span_delete_success" runat="server">Xóa bộ sưu tập thành công.</span>
        <span id="span_delete_fail" runat="server">Lỗi xóa bộ sưu tập.</span> <span id="span_treeview_move1"
            runat="server">Bạn có chắc chắn muốn chuyển mục</span> <span id="span_treeview_move2"
                runat="server">đến mục</span> <span id="span_treeivew_update_Tableofcontent" runat="server">
                    Lỗi chuyển bộ sưu tập. Chuyển bộ sưu tập không thành công.</span> <span id="span_start_upload"
                        runat="server">Tải dữ liệu bắt đầu</span> <span id="span_finish_upload" runat="server">
                            Tải dữ liệu đã hoàn thành</span> <span id="span_file_error" runat="server">Xin vui lòng
                                chọn tệp hình ảnh...</span> <span id="span_image_delete_info" runat="server">Bạn có
                                    chắc chắn muốn xóa ảnh bìa này không?</span>
    </div>
    </form>
</body>
</html>
