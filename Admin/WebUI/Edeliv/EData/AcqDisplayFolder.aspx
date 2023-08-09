<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqDisplayFolder.aspx.vb" Inherits="eMicLibAdmin.WebUI.Edeliv.Page_AcqDisplayFolder" %>
<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">
    <script language="JavaScript" type="text/javascript" src="../../js/Public.js"></script>
    <link href="../../Images/ComponentArt/Menu/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/Treeview/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/MenuButton/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/Splitter/Style.css" rel="stylesheet" type="text/css" />   
    <link href="../../Images/ComponentArt/Grid/style.css" type="text/css" rel="stylesheet" />
    <link href="../../Images/ComponentArt/Toolbar/style.css" type="text/css" rel="stylesheet" />
    <style>
        #SplitterFolder_pane_1 > div {
            width: 100% !important;
        }

        .HeadingCellText {
            text-align: left;
            white-space: normal !important;
            width: 100%;
        }
        #GridCallBack {
            width:100% !important;
            overflow: scroll;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        var viewerHeight = getHeight();
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

        function AjaxCallBack_onLoad(sender, e){ 
        }  
    
        function rename_folder(name) {
            var node = TreeViewFolder.get_selectedNode();
            var valReturn;
            valReturn = DeleteFolder(node.get_id(), name);
            if (valReturn == 0) {
                node.remove();
                var parentnode = node.get_parentNode();
                if (parentnode) {
                    var newNodeId = parentnode.get_id() + '\\' + name;
                    var newNode = CreateFolder(newNodeId, name);
                    if (newNode) {
                        createNode(parentnode, newNodeId, name);
                        //TreeViewFolder.selectNodeById(newNodeId);
                    }
                }
            }
            else if (valReturn == 1) {
                var span_info;
                span_info = document.getElementById('span_info');
                var span_treeivew_rename;
                span_treeivew_rename = document.getElementById('span_treeivew_rename');
                top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_rename.innerHTML);
                top.closeDialog('Dialog_content');
            }
            else if (valReturn == 2) {
                var span_info;
                span_info = document.getElementById('span_info');
                var span_treeivew_rename_duplicate;
                span_treeivew_rename_duplicate = document.getElementById('span_treeivew_rename_duplicate');
                top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_rename_duplicate.innerHTML);
                top.closeDialog('Dialog_content');
            }
        }
    
        function create_folder(name) {
            var node = TreeViewFolder.get_selectedNode();
            if (node) {
                var newNodeId = node.get_id() + '\\' + name;
                var newNode = CreateFolder(newNodeId, name);
                if (newNode) {
                    createNode(node, newNodeId, name);
                }
                else {
                    var span_info;
                    span_info = document.getElementById('span_info');
                    var span_treeivew_addnew_duplicate;
                    span_treeivew_addnew_duplicate = document.getElementById('span_treeivew_addnew_duplicate');
                    top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_addnew_duplicate.innerHTML);
                    top.closeDialog('Dialog_content');
                }
            }
        }
          
        function createNode(pid, nid, name) {
            TreeViewFolder.beginUpdate();
            var newNode = new ComponentArt.Web.UI.TreeViewNode();
            newNode.set_text(name);
            newNode.set_imageUrl('folder-open.png');
            newNode.set_id(nid);
            TreeViewFolder.findNodeById(pid.get_id()).get_nodes().add(newNode);
            TreeViewFolder.endUpdate();
            pid.expand(true);
            TreeViewFolder.selectNodeById(pid.get_id());
            top.closeDialog('Dialog_content');
        }
          
        function remove_folder() {
            var node = TreeViewFolder.get_selectedNode();
            if (node) {
                var span_cancel_para1;
                span_cancel_para1 = document.getElementById('span_cancel_para1');
                var span_treeivew_delete_info;
                span_treeivew_delete_info = document.getElementById('span_treeivew_delete_info');
                top.showDialogConfirmInfo('delete_folder()' + 'callback', true, 3, span_cancel_para1.innerHTML, span_treeivew_delete_info.innerHTML, true);
            }
        }
          
        function delete_folder() {
            var node = TreeViewFolder.get_selectedNode();
            var valReturn;
            valReturn = DeleteFolder(node.get_id(), '');
            if (valReturn == 1) {
                var span_info;
                span_info = document.getElementById('span_info');
                var span_treeivew_delete;
                span_treeivew_delete = document.getElementById('span_treeivew_delete');
                top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_delete.innerHTML);
            }
            else if (valReturn == 0) {
                if (node) {
                    node.remove();
                    if (node.get_parentNode().get_id()) {
                        TreeViewFolder.selectNodeById(node.get_parentNode().get_id());
                    }
                }
            }
        }
      
        function viewRecord(id){
            var span_preview;
            span_preview = document.getElementById('span_preview');
            top.showDialogContent('Edeliv/EData/AcqPreviewFrame.aspx?id='+String(id), true, span_preview.innerHTML, 120, 80);
        }
        function CheckAllElements(checkallbox) {
            var itemIndex = 0;
            var grid = <%= GridFolder.ClientObjectId %>; 
            if (checkallbox.checked == true){
                for(i = 0; i < grid.get_recordCount(); i++){
                    var chk = document.getElementById("chkAllC" + String(i));
                    if (chk!=null)
                        if (!grid.get_table().getRow(i).getMemberAt(5).get_value())
                            chk.checked = true;

                }
            }
            else{
                for(i = 0; i < grid.get_recordCount(); i++){
                    var chk = document.getElementById("chkAllC" + String(i));
                    if (chk!=null)
                        if (!grid.get_table().getRow(i).getMemberAt(5).get_value())
                            chk.checked = false;

                }
            }
        }
        
        function CheckAllElements1(checkallbox) 
        {
            var itemIndex = 0;
            var grid = <%= GridFolder.ClientObjectId %>; 
		    if (checkallbox.checked == true)
		    {
		        for(i = 0; i < document.forms[0].elements.length; i++)
		        { 
		            if ((document.forms[0].elements[i].type == 'checkbox') && (document.forms[0].elements[i].id == 'chkAllC'))
		            {
		                if (!grid.get_table().getRow(itemIndex).getMemberAt(5).get_value()){
		                    document.forms[0].elements[i].checked = true; 
		                }						
		                itemIndex++;
		            }
		        }
		    }
		    else
		    {
		        for(i = 0; i < document.forms[0].elements.length; i++)
		        { 
		            if ((document.forms[0].elements[i].type == 'checkbox') && (document.forms[0].elements[i].id == 'chkAllC'))
		            {
		                if (!grid.get_table().getRow(itemIndex).getMemberAt(5).get_value()){
		                    document.forms[0].elements[i].checked = false; 
		                }						
		                itemIndex++; 
		            }
		        }
		    }
        }

    
        function abcd() {
            var grid = <%= GridFolder.ClientObjectId %>; 
            for(i = 0; i < grid.get_recordCount(); i++){
                var chk = document.getElementById("chkAllC"+ String(i));
                if (chk!=null)
                    if (chk.checked)
                        alert(chk.value);
            }
        }
        

        // Handles the Grid double-click event 
        function GridFolder_onItemDoubleClick(sender, eventArgs)
        {
            var item = eventArgs.get_item();
            if (item != null) {
                if (item.Cells[5].get_value()){
                    TreeViewFolder.selectNodeById(item.Cells[6].get_value());
                }
                else
                {
                    var fileName = item.Cells[9].get_value();
                    SetFileNameSession(fileName);
                    top.main.Workform.hiddenSaveFile.location.href='AcqSaveFile.aspx?bol=1&FileName=' + fileName;
                }
            }
        }

        // Handles the TreeView node select event 
        function TreeViewFolder_refresh(val)
        { 
            GridCallBack.callback(val); 
        }
        
        // Handles the TreeView node select event 
        function TreeViewFolder_onNodeSelect(sender, eventArgs)
        { 
            if (contextData_grid_load){
                GridCallBack.callback(eventArgs.get_node().get_id()); 
            }
        }

        // Handles the TreeView load event 
        function TreeViewFolder_onLoad(sender, eventArgs)
        { 
            TreeViewFolder.SelectNodeById('n1');
        }

        // Overrides the default Grid client-side sort mechanism, 
        // ensuring that folders are grouped together 
        function GridFolder_onSortChange(sender, eventArgs)
        {
            var grid = sender;
            var isDesc = eventArgs.get_descending();
            var column = eventArgs.get_column();

            // multiple sort, giving the top priority to IsFolder
            grid.sortMulti([5,!isDesc,column.ColumnNumber,isDesc]);

            // cancel default sort
            eventArgs.set_cancel(true);
        }

        // Context menu global variables     
        var contextMenuX = 0; 
        var contextMenuY = 0; 
        var contextItem = ""; 
      
      
        // Context menu global variables for grid    
        var contextMenuX_grid = 0; 
        var contextMenuY_grid = 0; 
        var contextItem_grid = ""; 
        var contextData_grid = ""; 
        var contextData_DocID = -1; 
        var contextData_grid_load = true; 

        // Loads the Grid context menu through an AJAX-style callback 
        function GridFolder_onContextMenu(sender, eventArgs) 
        {
        
            var item = eventArgs.get_item();
            GridFolder.select(item);
        
            contextData_DocID = item.getMember('DocID').get_value(); 
        
            SetupContextMenuCallbackContainerForMenuGrid(eventArgs.get_event());
            MenuGrid.set_contextData(eventArgs.get_item());
            contextData_grid = MenuGrid.get_contextData();


            // Set the global contextItem variable
            //contextItem = item.Cells[1].get_value(); 
            contextItem_grid = item.Cells[9].get_value(); 

            // Load the menu from the server, given the file extension 
            MenuCallBackGrid.callback(item.Cells[7].get_value()); 
        }

        // Loads the TreeView context menu through an AJAX-style callback 
        function TreeViewFolder_onContextMenu(sender, eventArgs) 
        {
            SetupContextMenuCallbackContainer(eventArgs.get_event());

            // Set the global contextItem variable
            //contextItem = eventArgs.get_node().get_text();
            contextItem = eventArgs.get_node().get_id();

            // Load the menu from the server, given the directory 
            // (empty string) extension 
            MenuCallBack.callback('');
        }

        // Positions the context menu CallBack container
        function SetupContextMenuCallbackContainer(evt)
        {
            evt = (evt == null) ? window.event : evt;

            var scrollLeft = document.documentElement && document.documentElement.scrollLeft? document.documentElement.scrollLeft : document.body.scrollLeft;
            var scrollTop =  document.documentElement && document.documentElement.scrollTop ? document.documentElement.scrollTop  : document.body.scrollTop;

            contextMenuX = evt.x ? evt.clientX : evt.clientX + scrollLeft;
            contextMenuY = evt.y ? evt.clientY : evt.clientY + scrollTop;

            var callbackX = evt.x ? contextMenuX + scrollLeft : contextMenuX;
            var callbackY = evt.y ? contextMenuY + scrollTop  : contextMenuY;

            var menuCallBackDomElement = MenuCallBack.element;
            menuCallBackDomElement.style.position = 'absolute'; 
            menuCallBackDomElement.style.left = callbackX + 'px'; 
            menuCallBackDomElement.style.top = callbackY + 'px' ; 
        }

        // Positions the context menu CallBack container
        function SetupContextMenuCallbackContainerForMenuGrid(evt)
        {
            evt = (evt == null) ? window.event : evt;
        
            var scrollLeft = document.documentElement && document.documentElement.scrollLeft? document.documentElement.scrollLeft : document.body.scrollLeft;
            var scrollTop =  document.documentElement && document.documentElement.scrollTop ? document.documentElement.scrollTop  : document.body.scrollTop;

            contextMenuX_grid = evt.x ? evt.clientX : evt.clientX + scrollLeft;
            contextMenuY_grid = evt.y ? evt.clientY : evt.clientY + scrollTop;

            var callbackX = evt.x ? contextMenuX_grid + scrollLeft : contextMenuX_grid;
            var callbackY = evt.y ? contextMenuY_grid + scrollTop  : contextMenuY_grid;

            var menuCallBackDomElement = MenuGrid.element;
            menuCallBackDomElement.style.position = 'absolute'; 
            menuCallBackDomElement.style.left = callbackX + 'px'; 
            menuCallBackDomElement.style.top = callbackY + 'px' ;         
        }


     

        // Handles the Menu item select event 
        function MenuFolder_onItemSelect(sender, eventArgs)
        {
            var menuItem = eventArgs.get_item();
            var contextDataNode = menuItem.get_parentMenu().get_contextData();
            switch (menuItem.get_value()) {
                case 'upload' :
                    var span_addfolder_info;
                    span_addfolder_info = document.getElementById('span_addfolder_info');
                    top.showDialogContent('Edeliv/EData/AcqUploadFilesFrame.aspx?uploadPath='+contextItem, true, span_addfolder_info.innerHTML, parseInt(window.screen.availWidth / 5), parseInt(window.screen.availHeight / 5));
                    break;
                case 'add':
                    var span_addfolder_info;
                    span_addfolder_info = document.getElementById('span_addfolder_info');
                    top.showDialogContent('Edeliv/EData/AcqAddFolderFrame.aspx?Dialog_Content_Child=0&addnew=1', true, span_addfolder_info.innerHTML, parseInt(window.screen.availWidth / 3), parseInt(window.screen.availHeight / 3));
                    break;
                case 'edit':
                    var node = TreeViewFolder.get_selectedNode();
                    if(node)
                    {
                        nodeId = node.get_id();
                        nodeName = nodeId.substring(nodeId.lastIndexOf("\\")+1);
                        }
                    var span_addfolder_info;
                    span_addfolder_info = document.getElementById('span_addfolder_info');
                    top.showDialogContent('Edeliv/EData/AcqAddFolderFrame.aspx?Dialog_Content_Child=0&nodeName='+nodeName, true, "", parseInt(window.screen.availWidth / 3), parseInt(window.screen.availHeight / 3));
                    break;
                case 'delete':
                    remove_folder();
                    break;
            }

            return true;
        }

        // Handles the CallBack callback complete event 
        function MenuCallBack_onCallbackComplete()
        {
            MenuFolder.showContextMenu(contextMenuX, contextMenuY); 
        }    
      
        // Handles the CallBack callback complete event 
        function MenuCallBackGrid_onCallbackComplete()
        {
            MenuGrid.showContextMenu(contextMenuX_grid, contextMenuY_grid); 
        }   
      
        // Handles the Menu item select event 
        function MenuGrid_onItemSelect(sender, eventArgs)
        {
            var menuItem = eventArgs.get_item();
            var contextDataNode = menuItem.get_parentMenu().get_contextData();
            switch (menuItem.get_value()) {
                case 'open':
                    var isFolder = CheckIsFolderOrFile(contextItem_grid);
                    if (isFolder==1){
                        TreeViewFolder.selectNodeById(contextItem_grid);
                    }
                    else if (isFolder==2) {
                        var fileName = contextItem_grid;
                        SetFileNameSession(fileName);
                        top.main.Workform.hiddenSaveFile.location.href='AcqSaveFile.aspx?bol=1&FileName=' + fileName;
                    }
                    break;
                case 'edit':
                    var span_addfolder_info;
                    span_addfolder_info = document.getElementById('span_addfolder_info');
                    top.showDialogContent('Edeliv/EData/AcqAddFolderFrame.aspx?Dialog_Content_Child=0', true, "", parseInt(window.screen.availWidth / 3), parseInt(window.screen.availHeight / 3));
                    break;
                case 'delete':
                    if (parseInt(contextData_DocID)>0){
                        var span_info;
                        span_info = document.getElementById('span_info');
                        var span_grid_delete_file_error3;
                        span_grid_delete_file_error3 = document.getElementById('span_grid_delete_file_error3');
                        top.showDialogInfo('', true, 5, span_info.innerHTML, span_grid_delete_file_error3.innerHTML);
                    }
                    else {
                        remove_file();
                    }
                    break;
                case "checkall":
                    var grid = <%= GridFolder.ClientObjectId %>; 
                if (grid!=null){
                    for(i = 0; i < grid.get_recordCount(); i++){
                        var chk = document.getElementById("chkAllC" + String(i));
                        if (chk!=null)
                            if (!grid.get_table().getRow(i).getMemberAt(5).get_value())
                                chk.checked = true;

                    }
                }
                break;
            case "uncheckall":
                var grid = <%= GridFolder.ClientObjectId %>; 
                if (grid!=null){
                    for(i = 0; i < grid.get_recordCount(); i++){
                        var chk = document.getElementById("chkAllC" + String(i));
                        if (chk!=null)
                            if (!grid.get_table().getRow(i).getMemberAt(5).get_value())
                                chk.checked = false;

                    }
                }
                break;
        }

        return true;
    }
      
    function remove_file() {
        var span_cancel_para1;
        span_cancel_para1 = document.getElementById('span_cancel_para1');
        var span_grid_delete_file;
        span_grid_delete_file = document.getElementById('span_grid_delete_file');
        top.showDialogConfirmInfo('delete_file()' + 'callback', true, 3, span_cancel_para1.innerHTML, span_grid_delete_file.innerHTML, true);
    }
        
    function delete_file() {
        if (contextItem_grid!=''){
            var valReturn;
            valReturn = deletefile(contextItem_grid);
            if (valReturn == 1) {
                var span_info;
                span_info = document.getElementById('span_info');
                var span_grid_delete_file_error1;
                span_grid_delete_file_error1 = document.getElementById('span_grid_delete_file_error1');
                top.showDialogInfo('', true, 5, span_info.innerHTML, span_grid_delete_file_error1.innerHTML);
            }
            else if (valReturn == 0) {
                if (contextData_grid!=null)
                {
                    GridFolder.deleteItem(contextData_grid);
                }
            }
            else if (valReturn == 2) {
                var span_info;
                span_info = document.getElementById('span_info');
                var span_grid_delete_file_error2;
                span_grid_delete_file_error2 = document.getElementById('span_grid_delete_file_error2');
                top.showDialogInfo('', true, 5, span_info.innerHTML, span_grid_delete_file_error2.innerHTML);
            }
            else if (valReturn == 3) {
                var span_info;
                span_info = document.getElementById('span_info');
                var span_treeivew_delete;
                span_treeivew_delete = document.getElementById('span_treeivew_delete');
                top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_delete.innerHTML);
            }
            else if (valReturn == 4) {
                var span_info;
                span_info = document.getElementById('span_info');
                var span_not_rights_delete;
                span_not_rights_delete = document.getElementById('span_not_rights_delete');
                top.showDialogInfo('', true, 5, span_info.innerHTML, span_not_rights_delete.innerHTML);
            }
        }
    }
      
    function GridCallBack_onBeforeCallback(sender, e){
        var grid = <%= GridFolder.ClientObjectId %>; 
          if (grid != null)
          {
              grid.dispose();
          }
      }

      // Forces the treeview to adjust to the new size of its container          
      function resizeTree(sender, eventArgs) {
          var iUnit;
          iUnit = 8;
          var pane = eventArgs.get_pane();
          var newPaneWidth = pane.get_width();
          var newPaneHeight = pane.get_height();
          if (window.TreeViewFolder && newPaneWidth && newPaneWidth > 2 && newPaneHeight && newPaneHeight > 11)
          {
              document.getElementById("TreeContainer").style.width = (newPaneWidth - 2) + 'px';
              //document.getElementById("TreeContainer").style.height = (newPaneHeight - iUnit) + 'px';
              document.getElementById("TreeContainer").style.height = viewerHeight + 'px';
              document.getElementById("TreeContainer").style.height = viewerHeight + 'px';
              document.getElementById("TreeContainer").parentElement.style.width = (newPaneWidth - 20) + 'px';
              document.getElementById("TreeContainer").parentElement.parentElement.style.width = (newPaneWidth - 20) + 'px';
              //   console.log(document.getElementById("TreeContainer").parentElement);
              TreeViewFolder.render();
          }
      }    

      // Forces the grid to adjust to the new size of its container          
      function resizeGrid(sender, eventArgs) {
          var iUnit;
          iUnit = 2;
          var pane = eventArgs.get_pane();
          var newPaneWidth = pane.get_width();
          var newPaneHeight = pane.get_height();
          if(window.GridFolder && window.GridCallBack && newPaneWidth && newPaneWidth > 2 && newPaneHeight && newPaneHeight > 2) {
              GridCallBack.element.style.width = '80%' ;//(newPaneWidth - 2) + 'px';
              //GridCallBack.element.style.height = (newPaneHeight - iUnit) + 'px';
              GridCallBack.element.style.height = viewerHeight -20 +'px';
              GridFolder.render();
          }
      }  
      
      function CheckSubmit(key) {
          switch (key) {
              case 'close':
                  top.main.Workform.document.location.href = "WEdataMain.aspx";
                  break;
              case 'acquisition':
                  var grid = <%= GridFolder.ClientObjectId %>; 
                  var CheckId = '';
                  for(i = 0; i < grid.get_recordCount(); i++){
                      var chk = document.getElementById("chkAllC"+ String(i));
                      if (chk!=null)
                          if (chk.checked){
                              CheckId = CheckId + String(chk.value) + ',';
                          }
                  }
                  if (CheckId==''){
                      var span_info;
                      span_info = document.getElementById('span_info');
                      var span_grid_check;
                      span_grid_check = document.getElementById('span_grid_check');
                      top.showDialogInfo('', true, 4, span_info.innerHTML, span_grid_check.innerHTML);
                  }
                  else
                  {
                      var valReturn;
                      valReturn = saveFileIds(CheckId);
                      top.main.location.href = "../../Catalogue/WMainFrameLinkEdeliv.aspx?FileIds=" + valReturn;
                  }
                  break;
              case 'addfile':
                  var grid = <%= GridFolder.ClientObjectId %>; 
                 var CheckId = '';
                 for(i = 0; i < grid.get_recordCount(); i++){
                     var chk = document.getElementById("chkAllC"+ String(i));
                     if (chk!=null)
                         if (chk.checked){
                             CheckId = CheckId + String(chk.value) + ',';
                         }
                 }
                 if (CheckId==''){
                     var span_info;
                     span_info = document.getElementById('span_info');
                     var span_grid_check;
                     span_grid_check = document.getElementById('span_grid_check');
                     top.showDialogInfo('', true, 5, span_info.innerHTML, span_grid_check.innerHTML);
                 }
                 else
                 {
                     var hidFieldCodeValue = '';
                     var hidFieldCode = document.getElementById('hidFieldCode');
                     if (hidFieldCode){
                         hidFieldCodeValue = hidFieldCode.value;
                     }
                     var hidSFileValue = '';
                     var hidSFile = document.getElementById('hidSFile');
                     if (hidSFile){
                         hidSFileValue = hidSFile.value;
                     }
                     var valFiles;
                     valFiles = addSaveFileIds(CheckId,hidSFileValue,hidFieldCodeValue);
                     if (valFiles){
                         if (hidFieldCodeValue != '907') {
                             var span_info;
                             span_info = document.getElementById('span_info');
                             var span_grid_info;
                             span_grid_info = document.getElementById('span_grid_info');
                             top.showDialogInfo('', true, 4, span_info.innerHTML, span_grid_info.innerHTML);
                         }
                        

                         var hidWFieldValue = '';
                         var hidWField = document.getElementById('hidWField');
                         if (hidWField){
                             hidWFieldValue = hidWField.value;
                         }                        
                         top.main.Workform.chooseAddfiles(hidWFieldValue,hidFieldCodeValue,valFiles);
                     }
                     else {
                         var span_info;
                         span_info = document.getElementById('span_info');
                         var span_grid_err;
                         span_grid_info = document.getElementById('span_grid_err');
                         top.showDialogInfo('', true, 5, span_info.innerHTML, span_grid_info.innerHTML);
                     }
                 }
                 break;
             case 'closefile':          
                 //alert(top.main.Workform.location.href);        
                 top.closeDialog('Dialog_content');
                 break;
         }
     }

    
     function delete_multi_file() {
         var grid = <%= GridFolder.ClientObjectId %>; 
           var valReturn;
           for(i = 0; i < grid.get_recordCount(); i++){
               var chk = document.getElementById("chkAllC"+ String(i));
               if (chk!=null) {
                   if (chk.checked){
                       valReturn = deletefile(String(chk.value));
                       if (valReturn==0){
                           //GridFolder.deleteItem(String(chk.value));
                       }                        
                   }
               }
           }
       }
          

       function ExpandFolder() {
           var obj;
           obj = '<%=Replace(Session("folderPath"), "\", "\\")%>';
          if (obj != '') {
              contextItem_grid = obj;
              contextData_grid_load =false;
              TreeViewFolder.selectNodeById(obj);
              contextData_grid_load = true;
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
      //
    </script>
</head>
<body oncontextmenu="CancelContextMenu(event);" onload="ExpandFolder();" style="background-color:White;">
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"  /> 
       <table width="1000" border="0" cellpadding="0" cellspacing="0">
            <tr> 
              <td valign="top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="bgmain">
                  <tr> 
                     <td valign="top">
                           <ComponentArt:Splitter runat="server" id="SplitterFolder" Height="1600px" FillWidth="true" ImagesBaseUrl="../../Images/ComponentArt/Splitter/Images/">
                            <Layouts>
                              <ComponentArt:SplitterLayout>
                                <Panes Orientation="Horizontal" SplitterBarCollapseImageUrl="splitter_horCol.gif" SplitterBarCollapseHoverImageUrl="splitter_horColHover.gif" SplitterBarExpandImageUrl="splitter_horExp.gif" SplitterBarExpandHoverImageUrl="splitter_horExpHover.gif" SplitterBarCollapseImageWidth="5" SplitterBarCollapseImageHeight="116" SplitterBarCssClass="HorizontalSplitterBar" SplitterBarCollapsedCssClass="CollapsedHorizontalSplitterBar" SplitterBarActiveCssClass="ActiveSplitterBar" SplitterBarWidth="5">
                                  <ComponentArt:SplitterPane PaneContentId="TreeViewContent" Width="20%" MinWidth="50">
                                    <ClientEvents>
                                      <PaneResize EventHandler="resizeTree" />
                                    </ClientEvents>
                                  </ComponentArt:SplitterPane>
                                  <ComponentArt:SplitterPane PaneContentId="GridContent" Width="80%" MinWidth="100">
                                    <ClientEvents>
                                      <PaneResize EventHandler="resizeGrid" />
                                    </ClientEvents>
                                  </ComponentArt:SplitterPane>
                                </Panes>
                              </ComponentArt:SplitterLayout>
                            </Layouts>
                            <Content>
                              <ComponentArt:SplitterPaneContent id="TreeViewContent">
                                <div id="TreeContainer" class="TreeContainer" >
                                  <div class="HeadingCell" style="font-family: verdana; font-size: 10px; font-weight:bold;padding-top:3px;padding-bottom:5px; height: 16px;cursor:default;"><span id="span_folder" runat="server">Thư mục</span> </div>
                                  <ComponentArt:TreeView id="TreeViewFolder" Width="100%" 
                                    AutoScroll="true"
                                    FillContainer="true"
                                    HoverPopupEnabled="true"
                                    HoverPopupNodeCssClass="HoverPopup"
                                    DragAndDropEnabled="false" 
                                    NodeEditingEnabled="false"
                                    KeyboardEnabled="false"
                                    CssClass="TreeView" 
                                    NodeCssClass="TreeNode" 
                                    SelectedNodeCssClass="SelectedTreeNode" 
                                    HoverNodeCssClass="HoverTreeNode"
                                    LineImageWidth="19" 
                                    LineImageHeight="20"
                                    DefaultImageWidth="20" 
                                    DefaultImageHeight="20"
                                    ItemSpacing="0" 
                                    ImagesBaseUrl="../../Images/ComponentArt/Treeview/images/"
                                    NodeLabelPadding="3"
                                    ParentNodeImageUrl="folder.png" 
                                    LeafNodeImageUrl="folder-open.png" 
                                    ShowLines="true" 
                                    LineImagesFolderUrl="../../Images/ComponentArt/Treeview/images/lines/"
                                    CollapseNodeOnSelect="false"
                                    EnableViewState="false"
                                    runat="server" >
                                    <ClientEvents>
                                      <Load EventHandler="TreeViewFolder_onLoad" />
                                      <NodeSelect EventHandler="TreeViewFolder_onNodeSelect" />
                                      <ContextMenu EventHandler="TreeViewFolder_onContextMenu" />
                                    </ClientEvents>
                                  </ComponentArt:TreeView>  
                                </div>
                              </ComponentArt:SplitterPaneContent>

                              <ComponentArt:SplitterPaneContent id="GridContent"> 
                              <ComponentArt:CallBack id="GridCallBack" CssClass="GridContainer" runat="server" LoadingPanelFadeDuration="500" LoadingPanelFadeMaximumOpacity="60">
                                 <ClientEvents>
                                    <beforecallback eventhandler="GridCallBack_onBeforeCallback" />
                                    <load eventhandler="AjaxCallBack_onLoad" />
                                </ClientEvents>
                                <Content>
                                  <ComponentArt:Grid id="GridFolder"
                                    FillContainer="true"
                                    AutoAdjustPageSize="True"
                                    RunningMode="Client" 
                                    KeyboardEnabled="false"
                                    CssClass="GridTree"  
                                    FooterCssClass="GridFooternew"
                                    ImagesBaseUrl="../../Images/ComponentArt/Grid/images/"
                                    PagerImagesFolderUrl="../../Images/ComponentArt/Grid/images/pager/"
                                    EnableViewState="false"
                                    PagerStyle="Slider"
                                    PagerTextCssClass="GridFooterText"
                                    PagerButtonHoverEnabled="true"
                                    PagerButtonWidth="41"
                                    PagerButtonHeight="22"
                                    SliderHeight="20"
                                    SliderWidth="150"
                                    SliderGripWidth="9"
                                    SliderPopupOffsetX="20"
                                    Sort="IsFolder DESC, Type" 
                                    SliderPopupClientTemplateId="SliderTemplate"
                                    PagerInfoClientTemplateId="MyPager"
                                    GroupBySortAscendingImageUrl="group_asc.gif"
                                    GroupBySortDescendingImageUrl="group_desc.gif"
                                    GroupBySortImageWidth="10"
                                    GroupBySortImageHeight="10"
                                    IndentCellWidth="22"
                                    Width="100%" Height="100%" runat="server">
                                    <ClientEvents>
                                      <ItemDoubleClick EventHandler="GridFolder_onItemDoubleClick" />
                                      <SortChange EventHandler="GridFolder_onSortChange" />
                                      <ContextMenu EventHandler="GridFolder_onContextMenu" />
                                    </ClientEvents>
                                    <Levels>
                                      <ComponentArt:GridLevel
                                        DataKeyField="id"
                                        ShowTableHeading="false" 
                                        ShowSelectorCells="false" 
                                        HeadingCellCssClass="HeadingCell" 
                                        HeadingCellHoverCssClass="HeadingCellHover" 
                                        HeadingTextCssClass="HeadingCellText"
                                        DataCellCssClass="DataCell" 
                                        RowCssClass="Row" 
                                        SelectedRowCssClass="SelectedRow"
                                        SortedDataCellCssClass="SortedDataCell"
                                        SortedHeadingCellCssClass="SortedHeadingCell"
                                        ColumnReorderIndicatorImageUrl="reorder.gif"
                                        SortAscendingImageUrl="asc.gif" 
                                        SortDescendingImageUrl="desc.gif"                     
                                        SortImageWidth="10"
                                        SortImageHeight="19">
                                        <Columns>
                                          <ComponentArt:GridColumn DataField="Icon" AllowEditing="True" Visible="false" DataCellCssClass="table-column-grid"/>
                                          <ComponentArt:GridColumn DataField="DateModified" FormatString="dd/MM/yyyy hh:mm tt" SortImageJustify="false" HeadingText="&nbsp;&nbsp;Ngày nhập" DefaultSortDirection="Descending" DataCellCssClass="table-column-grid" Width="33"/>
                                          <ComponentArt:GridColumn DataField="Name" DataCellClientTemplateId="FirstColumnTemplate" HeadingText="&nbsp;&nbsp;Tên tập tin" SortImageJustify="false" DefaultSortDirection="Descending"  DataCellCssClass="table-column-grid" Width="40"/>
                                          <ComponentArt:GridColumn DataField="Size" DataCellClientTemplateId="SizeColumnTemplate" Align="Right" SortImageJustify="true" HeadingText="Kích thước&nbsp;&nbsp;" DefaultSortDirection="Descending" DataCellCssClass="table-column-grid"  Width="30"/>
                                          <ComponentArt:GridColumn DataField="Type" SortImageJustify="false"  HeadingText="&nbsp;&nbsp;Kiểu tập tin" DefaultSortDirection="Descending" DataCellCssClass="table-column-grid" Width="33"/>
                                          <ComponentArt:GridColumn DataField="IsFolder" Align="Center" HeadingText= "Chọn"  ColumnType="CheckBox"  DataCellClientTemplateId="chkTemplate"  DataType="System.Boolean" Width="20"  AllowReordering="False"  AllowGrouping="False" AllowSorting="False" DataCellCssClass="table-column-grid"  /> 
                                          <ComponentArt:GridColumn DataField="Value" Visible="false" DataCellCssClass="table-column-grid"  Width="20"/>
                                          <ComponentArt:GridColumn DataField="Extension" Visible="false" DataCellCssClass="table-column-grid" Width="20" />
                                          <ComponentArt:GridColumn DataField="SizeString" Visible="false"  DataCellCssClass="table-column-grid" />
                                          <ComponentArt:GridColumn DataField="FullPath" Visible="false" DataCellCssClass="table-column-grid" />
                                          <ComponentArt:GridColumn DataField="id" Visible="false"  DataCellCssClass="table-column-grid"/>
                                          <ComponentArt:GridColumn DataField="SercretLevel" Visible="False" HeadingText="&nbsp;&nbsp;Mức độ mật" DataCellClientTemplateId="SercretLevelColumnTemplate" Width="40" DefaultSortDirection="Descending" DataCellCssClass="table-column-grid"/>
                                          <ComponentArt:GridColumn DataField="DownloadTimes" Visible="False" HeadingText="&nbsp;&nbsp;Số lần tải về" DataCellClientTemplateId="DownloadTimesColumnTemplate" Width="40" DefaultSortDirection="Descending" DataCellCssClass="table-column-grid"/>
                                          <ComponentArt:GridColumn DataField="DocID" Visible="False" HeadingText="&nbsp;&nbsp;Thông tin biên mục" DataCellClientTemplateId="DocIDColumnTemplate" Width="40" DefaultSortDirection="Descending" DataCellCssClass="table-column-grid"/>
                                          <ComponentArt:GridColumn DataField="Charge" Visible="False" HeadingText="&nbsp;&nbsp;Truy cập" DataCellClientTemplateId="ChargeColumnTemplate" Width="40" DefaultSortDirection="Descending" DataCellCssClass="table-column-grid"/>
                                          <ComponentArt:GridColumn DataField="statusid" Visible="false" />
                                          <ComponentArt:GridColumn DataField="status"  HeadingText="&nbsp;&nbsp;Trạng thái" DataCellClientTemplateId="statusColumnTemplate" Width="0" DefaultSortDirection="Descending" Visible="false" DataCellCssClass="table-column-grid"/>
                                             <ComponentArt:GridColumn DataField="IsExit800" Visible="false" />
                                         </Columns>
                                      </ComponentArt:GridLevel>
                                    </Levels>
                                    <ClientTemplates>
                                          <ComponentArt:ClientTemplate Id="statusColumnTemplate">              
                                              ## DataItem.GetMember('IsFolder').Value ? '' : DataItem.GetMember('DocID').Value==-1 ? '' : DataItem.GetMember('statusid').Value==1 ? '<img src="../../Images/ComponentArt/grid/images/Be_exploited.png" height="20" width="20" alt="'+ DataItem.GetMember('status').Value + '" title="' + DataItem.GetMember('status').Value + '" />' : DataItem.GetMember('statusid').Value==2 ? '<img src="../../Images/ComponentArt/grid/images/Be_processing.png" height="20" width="20" alt="'+ DataItem.GetMember('status').Value + '" title="' + DataItem.GetMember('status').Value + '" />' : DataItem.GetMember('statusid').Value==3 ? '<img src="../../Images/ComponentArt/grid/images/Reviewing_wait.png" height="20" width="20" alt="'+ DataItem.GetMember('status').Value + '" title="' + DataItem.GetMember('status').Value + '" />' : DataItem.GetMember('statusid').Value==4 ? '<img src="../../Images/ComponentArt/grid/images/Stop_exploitation.png" height="20" width="20" alt="'+ DataItem.GetMember('status').Value + '" title="' + DataItem.GetMember('status').Value + '" />' : '<img src="../../Images/ComponentArt/grid/images/Other.jpg" height="20" width="20" alt="'+ DataItem.GetMember('status').Value + '" title="' + DataItem.GetMember('status').Value + '" />' ##
                                          </ComponentArt:ClientTemplate>
                                           <ComponentArt:ClientTemplate Id="SercretLevelColumnTemplate">              
                                              ## DataItem.GetMember('DocID').Value==-1 ? '' : DataItem.GetMember('SercretLevel').Value ##
                                          </ComponentArt:ClientTemplate>
                                          <ComponentArt:ClientTemplate Id="ChargeColumnTemplate">              
                                              ## DataItem.GetMember('IsFolder').Value ? '' : DataItem.GetMember('DocID').Value==-1 ? '' : DataItem.GetMember('Charge').Value ? '<img src="../../Images/ComponentArt/grid/images/money_charge.png" height="20" width="20" alt="Ấn phẩm điện tử thu phí" title="Ấn phẩm điện tử thu phí" />' : '<img src="../../Images/ComponentArt/grid/images/money_free.png" height="20" width="20" alt="Ấn phẩm điện tử tự do" title="Ấn phẩm điện tử tự do" />' ##
                                          </ComponentArt:ClientTemplate>
                                          <ComponentArt:ClientTemplate Id="DocIDColumnTemplate">              
                                              ## DataItem.GetMember('DocID').Value==-1 ? '' : '<img src="../../Images/ComponentArt/grid/images/Information.png" onclick="viewRecord(' + DataItem.GetMember('DocID').Value + ');" height="20" width="20" style="cursor:pointer;" alt="Xem chi tiết biểu ghi biên mục" title="Xem chi tiết biểu ghi biên mục" />' ##
                                          </ComponentArt:ClientTemplate>
                                          <ComponentArt:ClientTemplate Id="DownloadTimesColumnTemplate">              
                                              ## DataItem.GetMember('DocID').Value==-1 ? '' : DataItem.GetMember('DownloadTimes').Value ##
                                          </ComponentArt:ClientTemplate>
                                          <ComponentArt:ClientTemplate Id="chkTemplate">              
                                               <input type="checkbox" id="chkAllC##DataItem.GetMember('id').Value##" ## DataItem.GetMember('IsFolder').Value ? '' : '' ## ## (DataItem.GetMember('IsFolder').Value) || (DataItem.GetMember('DocID').Value > 0) ? 'disabled' : '' ## ## (DataItem.GetMember('IsFolder').Value) || (DataItem.GetMember('IsExit800').Value > 0) ? 'disabled' : '' ## value='##DataItem.GetMember('FullPath').Value##' />
                                          </ComponentArt:ClientTemplate>
                                      <ComponentArt:ClientTemplate Id="FirstColumnTemplate">
                                          <table cellspacing="1" cellpadding="1" border="0">
                                              <tr>
                                                <td><img src="../../Images/ComponentArt/grid/images/## DataItem.GetMember('Icon').Value ##" width="16" height="16" border="0" /></td>
                                                <td style="padding-left:2px;"><div style="font-size:10px;font-family: MS Sans Serif;text-overflow:ellipsis;overflow:hidden;"><nobr>## DataItem.GetMember("Name").Value ##</nobr></div></td>
                                              </tr>
                                          </table>
                                      </ComponentArt:ClientTemplate>
                                      <ComponentArt:ClientTemplate Id="SizeColumnTemplate">
                                            ## DataItem.GetMember("SizeString").Value ##
                                      </ComponentArt:ClientTemplate>
                                      <ComponentArt:ClientTemplate Id="ScrollPopupTemplate">
                                          <table cellspacing="0" cellpadding="2" border="0" class="ScrollPopup">
                                              <tr>
                                                <td style="width:20px;"><img src="../../Images/ComponentArt/grid/images/## DataItem.GetMember('Icon').Value ##" width="16" height="16" border="0" /></td>
                                                <td style="width:130px;"><div style="font-size:10px;font-family: MS Sans Serif;text-overflow:ellipsis;overflow:hidden;width:130px;"><nobr>## DataItem.GetMember("Name").Value ##</nobr></div></td>
                                                <td style="width:50px;"><div style="font-size:10px;font-family: MS Sans Serif;text-overflow:ellipsis;overflow:hidden;width:50px;"><nobr>## DataItem.GetMember("SizeString").Value ##</nobr></div></td>
                                                <td  style="width:120px;" align="right"><div style="font-size:10px;font-family: MS Sans Serif;text-overflow:ellipsis;overflow:hidden;width:120px;"><nobr>## DataItem.GetMember("DateModified").Text ##</nobr></div></td>
                                              </tr>
                                          </table>
                                      </ComponentArt:ClientTemplate>
                                      
                                      <ComponentArt:ClientTemplate Id="SliderTemplate">
			                            <table class="SliderPopup" width="200" style="background-color:#ffffff" cellspacing="0" cellpadding="0" border="0">
			                            <tr>
			                              <td style="padding:10px;" valign="center" align="center">
			                            Trang <b>## DataItem.PageIndex + 1 ##</b> của <b>## GridFolder.PageCount ##</b>
			                              </td>
			                            </tr>
			                            </table>
		                            </ComponentArt:ClientTemplate>
		                            <ComponentArt:ClientTemplate Id="MyPager">
                                        ##
                                        var Page = document.getElementById('span_grid_page').innerHTML;
                                        var of = document.getElementById('Span_grid_of').innerHTML;
                                        var items = document.getElementById('span_grid_item').innerHTML;
                                        var Norecordsfound = document.getElementById('span_grid_nodata').innerHTML;
                                                
                                        var currentPageIndex = (GridFolder == null) ? 0 : GridFolder.get_currentPageIndex();
                                        var pageCount = (GridFolder == null) ? 0 : GridFolder.get_pageCount();
                                        var recordCount = (GridFolder == null) ? 0 : GridFolder.get_recordCount();

                                        if (recordCount < 1)
                                        {
                                           Norecordsfound;
                                        }
                                        else
                                        {
                                           Page + " <b>" + (currentPageIndex + 1) + "</b> " + of + " <b>" + (pageCount) + "</b> (" + recordCount + " " + items + ")";
                                        }
                                        ##
                                        </ComponentArt:ClientTemplate>
                                      
                                    </ClientTemplates>
                                  </ComponentArt:Grid>
                                </Content>
                                
                                <LoadingPanelClientTemplate>
                                      <table width="100%" height="100%" cellspacing="0" cellpadding="0" border="0" bgcolor="#e0e0e0">
                                          <tr>
                                                <td align="center">
                                                    <table cellspacing="0" cellpadding="0" border="0">
                                                        <tr>
                                                          <td style="font-size:10px;">Đang nạp dữ liệu...&nbsp;</td>
                                                          <td><img src="../../images/spinner.gif" width="16" height="16" border="0"/></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                          </tr>
                                      </table>
                                </LoadingPanelClientTemplate>
                              </ComponentArt:CallBack> 
                              </ComponentArt:SplitterPaneContent>
                            </Content>          
                          </ComponentArt:Splitter>
                          
                          <ComponentArt:CallBack id="MenuCallBack" runat="server" >
                          <ClientEvents>
                            <CallbackComplete EventHandler="MenuCallBack_onCallbackComplete" />                            
                            <load eventhandler="AjaxCallBack_onLoad" />
                          </ClientEvents>
                          <Content>
                            <ComponentArt:Menu id="MenuFolder" 
                              Orientation="Vertical"
                              DefaultGroupCssClass="TopMenu_Group"
                              DefaultItemLookID="DefaultItemLook"
                              DefaultGroupItemSpacing="0"
                              DefaultItemHeight="22"
                              TopGroupExpandDirection="BelowLeft"
                              ImagesBaseUrl="../../Images/ComponentArt/Menu/images/"
                              EnableViewState="false"
                              ExpandDelay="100"
                              ExpandDuration="0"
                              ExpandSlideType="None"
                              ContextMenu="Custom"
                              runat="server">
                              <ClientEvents>
                                <ItemSelect EventHandler="MenuFolder_onItemSelect" />
                              </ClientEvents>
                              <ItemLooks>
                                    <ComponentArt:ItemLook LookID="DefaultItemLook" CssClass="MenuItemInputAcquisition" HoverCssClass="MenuItemHoverInputAcquisition" ExpandedCssClass="MenuItemHoverInputAcquisition" LeftIconWidth="20" LeftIconHeight="18" LabelPaddingLeft="10" LabelPaddingRight="10" LabelPaddingTop="3" LabelPaddingBottom="4" />
                                    <ComponentArt:ItemLook LookID="BreakItem" CssClass="MenuBreakInputAcquisition" />
                              </ItemLooks>
                            </ComponentArt:Menu>
                          </Content>
                          <LoadingPanelClientTemplate>
                            <table cellspacing="0" cellpadding="0" border="0" class="MenuCallBack">
                                <tr>
                                      <td align="center">
                                          <table cellspacing="0" cellpadding="0" border="0">
                                              <tr>
                                                <td style="font-size:10px;" align="center">Đang nạp dữ liệu...&nbsp;</td>
                                                <td><img alt="" src="../../images/spinner.gif" width="16" height="16" border="0"/></td>
                                              </tr>
                                          </table>      
                                      </td>
                                </tr>
                            </table>
                          </LoadingPanelClientTemplate>
                        </ComponentArt:CallBack>     
                        
                        
                        <ComponentArt:CallBack id="MenuCallBackGrid" runat="server" >
                          <ClientEvents>
                            <CallbackComplete EventHandler="MenuCallBackGrid_onCallbackComplete" />                            
                            <load eventhandler="AjaxCallBack_onLoad" />
                          </ClientEvents>
                          <Content>
                            <ComponentArt:Menu id="MenuGrid" 
                              Orientation="Vertical"
                              DefaultGroupCssClass="TopMenu_Group"
                              DefaultItemLookID="DefaultItemLook"
                              DefaultGroupItemSpacing="0"
                              DefaultItemHeight="22"
                              TopGroupExpandDirection="BelowLeft"
                              ImagesBaseUrl="../../Images/ComponentArt/Menu/images/"
                              EnableViewState="false"
                              ExpandDelay="100"
                              ExpandDuration="0"
                              ExpandSlideType="None"
                              ContextMenu="Custom"
                              runat="server">
                              <ClientEvents>
                                <ItemSelect EventHandler="MenuGrid_onItemSelect" />
                              </ClientEvents>
                              <ItemLooks>
                                    <ComponentArt:ItemLook LookID="DefaultItemLook" CssClass="MenuItemInputAcquisition" HoverCssClass="MenuItemHoverInputAcquisition" ExpandedCssClass="MenuItemHoverInputAcquisition" LeftIconWidth="20" LeftIconHeight="18" LabelPaddingLeft="10" LabelPaddingRight="10" LabelPaddingTop="3" LabelPaddingBottom="4" />
                                    <ComponentArt:ItemLook LookID="BreakItem" CssClass="MenuBreakInputAcquisition" />
                              </ItemLooks>
                            </ComponentArt:Menu>
                          </Content>
                          <LoadingPanelClientTemplate>
                            <table cellspacing="0" cellpadding="0" border="0" class="MenuCallBack">
                                <tr>
                                      <td align="center">
                                          <table cellspacing="0" cellpadding="0" border="0">
                                              <tr>
                                                <td style="font-size:10px;" align="center">Đang nạp dữ liệu...&nbsp;</td>
                                                <td><img alt="" src="../../images/spinner.gif" width="16" height="16" border="0"/></td>
                                              </tr>
                                          </table>      
                                      </td>
                                </tr>
                            </table>
                          </LoadingPanelClientTemplate>
                        </ComponentArt:CallBack>      	
                    </td>
                   </tr>
                </table></td>
            </tr>           
          </table>
       <div style="position:absolute;top:0px;left:0px;visibility:hidden;">   
            <input type="button" value="testCheckbox" onclick="abcd()" />
            <ComponentArt:Menu id="MenuTemp" runat="server"></ComponentArt:Menu>
            <ComponentArt:Grid ID="gridTemp" runat="server"></ComponentArt:Grid>
            <ComponentArt:TreeView id="TreeviewTemp" Width="100%" runat="server" Visible="false"></ComponentArt:TreeView>
            <span  id="span_preview" runat="server"></span>
            <span id="span_addfolder_info" runat="server"></span>
            <span  id="span_treeview_new_folder" runat="server">Thêm mới thư mục</span>
            <span  id="span_treeview_edit_folder" runat="server">Đổi tên thư mục</span>
            <span  id="span_treeview_delete_folder" runat="server">Xóa thư mục</span>
            <span  id="span_treeview_upload" runat="server">Tải tập tin lên</span>
            <span  id="span_grid_open" runat="server">Mở</span>
            <span id="span_grid_item" runat="server">mục</span> 
            <span id="span_grid_nodata" runat="server">Không có dữ liệu</span> 
            <span id="span_grid_page" runat="server">Trang</span>
            <span id="Span_grid_of" runat="server">của</span>
            <span  id="span_info" runat="server">Thông báo!; Đóng</span>
            <span  id="span_grid_check" runat="server">Xin vui lòng đánh dấu để chọn tập tin biên mục...</span>
            <span  id="span_grid_check_delete" runat="server">Xin vui lòng đánh dấu để chọn tập tin xóa...</span>
            <span  id="span_treeivew_addnew_duplicate" runat="server">Thư mục này đã tồn tại. Thêm mới thư mục không thành công.</span>
            <span  id="span_cancel_para1" runat="server">Cảnh báo!; Chấp nhận ; Không chấp nhận</span>
            <span  id="span_treeivew_delete_info" runat="server">Bạn có chắc chắn muốn xóa thư mục này không?</span>
            <span  id="span_treeivew_delete" runat="server">Thư mục là không rỗng. Xóa thư mục không thành công.</span>
            <span  id="span_treeivew_rename" runat="server">Thư mục này là không rỗng. Đổi tên thư mục này không thành công.</span>
            <span  id="span_treeivew_rename_duplicate" runat="server">Thư mục này đã tồn tại. Đổi tên thư mục này không thành công.</span>
            <span  id="span_not_rights_delete" runat="server">Bạn không có quyền xóa tập tin này.</span>
            <span  id="span_grid_delete_file_info" runat="server">Xóa</span>
            <span  id="span_grid_checkall" runat="server">Chọn toàn bộ</span>
            <span  id="span_grid_uncheckall" runat="server">Bỏ chọn toàn bộ</span>
            <span  id="span_grid_info" runat="server">Đã thêm tập tin</span>
            <span  id="span_grid_err" runat="server">Không thêm được tập tin</span>
            <span  id="span_grid_delete_file" runat="server">Bạn có chắc chắn muốn xóa tập tin này không?</span>
            <span  id="span_grid_delete_file_error1" runat="server">Đường dẫn tập tin không tồn tại. Xóa tập tin không thành công...</span>
            <span  id="span_grid_delete_file_error2" runat="server">Lỗi xóa tập tin..... Xóa tập tin không thành công...</span>
            <span  id="span_grid_delete_file_error3" runat="server">tập tin có gắn với biểu ghi biên mục. Xóa tập tin không thành công.</span>
            <input id="hidFieldCode" type="hidden" value="" runat="server"/> <input id="hidWField" type="hidden" value="" runat="server"/>
		    <input id="hidSField" type="hidden" value="" runat="server"/> <input id="hidRepeatable" type="hidden" value="0" runat="server"/>
             <input id="hidSFile" type="hidden" value="" runat="server"/>
        </div>      
   </form>
</body>
</html>
