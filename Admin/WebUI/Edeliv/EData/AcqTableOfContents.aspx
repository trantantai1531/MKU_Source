<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqTableOfContents.aspx.vb"
    Inherits="eMicLibAdmin.WebUI.Edeliv.Pages_AcqTableOfContents" %>

<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head1" runat="server">
    <script language="JavaScript" type="text/javascript" src="../../js/Public.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../js/swfobject.js"></script>
    <script type="text/javascript" src="viewer/js/jquery.min.js"></script>
    <link href="../../Images/ComponentArt/Menu/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/Treeview/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/MenuButton/style.css" type="text/css" rel="StyleSheet" />
    <link href="../../Images/ComponentArt/Splitter/Style.css" rel="stylesheet" type="text/css" />
    <link href="../../Images/ComponentArt/Grid/style.css" type="text/css" rel="stylesheet" />
    <link href="../../Images/ComponentArt/Toolbar/style.css" type="text/css" rel="stylesheet" />
    <link href="../../Resources/StyleSheet/default.css" rel="stylesheet" type="text/css" />
    <link href="../../Resources/StyleSheet/main.css" rel="stylesheet" type="text/css" />
    <style type="text/css">  
        iframe {
		    display: block;       /* iframes are inline by default */
		    border: none;         /* Reset default border */
		    height: 100vh;        /* Viewport-relative units */
		    width: 100vw;
	    }
    </style> 
    <style  type="text/css">
         .Row td.DataCell div {
            padding: 10px !important;
        }
         #divBody
         {
             min-height: auto !important;
         }
          #GridCallBack {
            width:100% !important;
            overflow-y: scroll;
        }
    </style>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        
        var FileId=0;
        var DocId=0;
        var XMLpath = '';
        var itemGrid;
        var viewerHeight = getHeight();
        var viewerWidth = (getWidth() * 80 / 100);
        
        function AjaxCallBack_onLoad(sender, e) 
        { 
        }   

         function resizeTreeRefresh(sender, e) 
            { 
               var spCollection = window.SplitterCollection;
                if (spCollection){
                var pane = spCollection.Panes[0];
                    pane.collapse();
                    pane.expand();
                }
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
        
        function gridCallback(val){
            loadList();
            GridCallBack.callback(val);
        }
        
        function loadList(){
                var divViewer = document.getElementById('divViewer');
                divViewer.style.display = "none";
                var divViewerPdf = document.getElementById('divViewerPdf');
                divViewerPdf.style.display = "none";
                var divGrid = document.getElementById('divGrid');
                divGrid.style.display = "inline";
        }
        
         function showViewerFromChildrent(pageno,pathxml){
            if (FileId>0){
                CallbackTreeview.callback(FileId); 
                onOffViewer(pageno,0,pathxml);
                top.closeDialog('Dialog_content');
                refreshGrid(1,pathxml);
            }
        }
        
        function replaceSwfWithEmptyDiv(targetID){   
            var el = document.getElementById(targetID);   
            if(el){   
                el.innerHTML='<div id="spViewerPdf"></div>';   
            }
        }
        
        function writeMLbookPdf(pathxml){
                var flashvars = {
			      doc_url: pathxml,
			      langcode : '<%=langcodePath%>'
			    };
			    var params = {
			      menu: "false",
			      bgcolor: '#efefef',
			      allowFullScreen: 'true',
			      wmode: 'transparent'
			    };
			    var attributes = {
				    id: 'ViewerPdf',
				    name : 'ViewerPdf'
			    };
			    replaceSwfWithEmptyDiv("divViewerPdf");
			    swfobject.embedSWF('swf/MLbook.swf', 'spViewerPdf', viewerWidth, viewerHeight, '9.0.45',
                    'swfobject/expressinstall.swf', flashvars, params, attributes);
        }
        
        function showViewerFromChildrentPdf(pathxml){
            if (FileId>0){
                CallbackTreeview.callback(FileId); 
                onOffViewer(0,1,pathxml);
                writeMLbookPdf(pathxml);                
                top.closeDialog('Dialog_content');
                refreshGrid(1,pathxml);
            }
        }
        
        function refreshGrid(valviewer,valXMLpath){
            if (itemGrid){
                var bol = false;
                var uViewer = itemGrid.getMember('viewer');
                if(uViewer.get_value() == false){
                    itemGrid.setValue(5,valviewer,true);
                    bol = true;
                }
                var uXMLpath = itemGrid.getMember('XMLpath');
                if(uXMLpath.get_value()!=''){
                    itemGrid.setValue(7,valXMLpath,true);
                    bol = true;
                }
                if (bol){
                    GridTableOfContent.Render();
                }
            }
        }
        
        function onOffViewer(pageno,pdf,pathxml){
            var divGrid = document.getElementById('divGrid');
            divGrid.style.display = "none";
            if (pdf==1){
                var divViewerPdf = document.getElementById('divViewerPdf');
                divViewerPdf.style.display = "inline";
                var divViewer = document.getElementById('divViewer');
                divViewer.style.display = "none";                
                writeMLbookPdf(pathxml);
            }
            else {
                var divViewerPdf = document.getElementById('divViewerPdf');
                divViewerPdf.style.display = "none";
                //var strViewer ;
                //strViewer  = GetFalshViewer(pageno,pathxml);
                var divViewer = document.getElementById('divViewer');
                divViewer.style.display = "inline";                
                //var spViewer = document.getElementById('spViewer');
                //spViewer.innerHTML=strViewer;

                var pathURL = 'AcqViewer.aspx?DocId=' + DocId + '&Page=' + pageno + '&fileId=' + FileId + '&XMLpath=' + XMLpath;
                document.getElementById("ifrm1").src = pathURL;
            }
        }
        
        function showViewer(pageno,pathxml){
            /*
            if (FileId>0){
                
                CallbackTreeview.callback(FileId); 
                var pdf = IsSwf(pathxml);
                onOffViewer(pageno,pdf,pathxml);
                
            }
            */
	    console.log(DocId + 'g');
            if (DocId>0){
                
                CallbackTreeview.callback(DocId); 
                var pdf = IsSwf(pathxml);
		//console.log(pdf  + 'g');
                onOffViewer(pageno,pdf,pathxml);
                
            }
        }
        
        function LoadViewer(pageno,pathxml){
           if (FileId>0){
                var divGrid = document.getElementById('divGrid');
                divGrid.style.display = "none";
                var pdf = IsSwf(pathxml);
                var flash = 1;
                if (pdf==1) {
                    //flash = getFlashMovieObject("ViewerPdf");
                    var divViewerPdf = document.getElementById('divViewerPdf');
                    divViewerPdf.style.display = "inline";
                    var divViewer = document.getElementById('divViewer');
                    divViewer.style.display = "none";
                }
                else {
                    //flash = getFlashMovieObject("idViewer");
                    var divViewerPdf = document.getElementById('divViewerPdf');
                    divViewerPdf.style.display = "none";
                    var divViewer = document.getElementById('divViewer');
                    divViewer.style.display = "inline";
                }
                if (flash){
                    //Call a function from flash and return IE
                    //flash.GotoPages(pageno);
                    searchGotoPages(pageno);
                }
            }
        }


        function searchGotoPages(pageno) {
            if (pageno > 0) {
                $("#ifrm1").prop("contentWindow").gotoPage(pageno - 1);
            }
        }
       
        function ToolBar_ItemCommand(sender, e) {
              if (FileId>0){
                  var node = TreeViewCollection_Table_Of_Contents.get_selectedNode();
                  switch (e.get_item().get_value()) {
                        case 'addbookmark':
                            if (node){
                                    var flash;
                                    var page = 0;
                                    flash = getFlashMovieObject("ViewerPdf");
                                    if (flash) {
                                        page = flash.GetPages();
                                    }  
                                  var span_title_form;
                                  span_title_form = document.getElementById('span_title_form');
                                  top.showDialogContentFix('Edeliv/Edata/AcqTableOfContentsAddFrame.aspx?addnew=1&page='+page, false, span_title_form.innerHTML,25,25 , 720 , 135);
                            }
                            else
                            {
                                  var span_info;
                                  span_info = document.getElementById('span_info');
                                  var span_toolbar_add_alert = document.getElementById('span_toolbar_add_alert');
                                  top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_add_alert.innerHTML);
                            }                        
                            break;
                        case 'editbookmark':
                            if (node){
                                  if (node) {
                                        nodeId = node.get_id();
                                  }
                                  if (nodeId>0){
                                        var span_title_form;
                                        span_title_form = document.getElementById('span_title_form');
                                        top.showDialogContentFix('Edeliv/Edata/AcqTableOfContentsAddFrame.aspx?nodeId='+ String(nodeId), false, span_title_form.innerHTML,25,25 , 720 , 135);
                                  }
                                  else{
                                        var span_info;
                                        span_info = document.getElementById('span_info');
                                        var span_toolbar_edit_alert = document.getElementById('span_toolbar_edit_alert');
                                        top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_edit_alert.innerHTML);
                                  }
                            }
                            else
                            {
                                  var span_info;
                                  span_info = document.getElementById('span_info');
                                  var span_toolbar_add_alert = document.getElementById('span_toolbar_add_alert');
                                  top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_add_alert.innerHTML);
                            }           
                            break;
                        case 'deletebookmark':
                            if (node){
                                  if (node) {
                                        nodeId = node.get_id();
                                  }
                                  if (nodeId>0){
                                       remove_Tableofcontent();
                                  }
                                  else{
                                        var span_info;
                                        span_info = document.getElementById('span_info');
                                        var span_toolbar_edit_alert = document.getElementById('span_toolbar_edit_alert');
                                        top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_edit_alert.innerHTML);
                                  }
                            }
                            else
                            {
                                  var span_info;
                                  span_info = document.getElementById('span_info');
                                  var span_toolbar_add_alert = document.getElementById('span_toolbar_add_alert');
                                  top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_add_alert.innerHTML);
                            }           
                            break;
                  }
              }
              else{
                  var span_info;
                  span_info = document.getElementById('span_info');
                  var span_choose_doc = document.getElementById('span_choose_doc');
                  top.showDialogInfo('', true, 5, span_info.innerHTML, span_choose_doc.innerHTML);
              }
              
          }
         
        function rename_Tableofcontent(name,pageNum) {
              var node = TreeViewCollection_Table_Of_Contents.get_selectedNode();
              if (node.get_id() > 0) {
                  var valReturn;
                  valReturn = UpdateTableofcontent( node.get_id(), name,pageNum);
                  if (valReturn == 1) {
                       TreeViewCollection_Table_Of_Contents.beginUpdate();
                       node.set_text(name);
                       node.set_value(pageNum);
                       TreeViewCollection_Table_Of_Contents.endUpdate();
                       //closeDialog('Dialog_Content_Table_Of_Contents');
                       top.closeDialog('Dialog_content');
                  }
                  else if (valReturn == 0) {
                      var span_info;
                      span_info = document.getElementById('span_info');
                      var span_treeivew_rename;
                      span_treeivew_rename = document.getElementById('span_treeivew_rename');
                      top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_rename.innerHTML);
                      //closeDialog('Dialog_Content_Table_Of_Contents');
                      top.closeDialog('Dialog_content');
                  }
              }
              else {
                  var span_info;
                  span_info = document.getElementById('span_info');
                  var span_treeivew_rename;
                  span_treeivew_rename = document.getElementById('span_treeivew_rename');
                  top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_rename.innerHTML);
                  //closeDialog('Dialog_Content_Table_Of_Contents');
                  top.closeDialog('Dialog_content');
              }
          }
    
        function create_Tableofcontent(name,pageNum) {
              var node = TreeViewCollection_Table_Of_Contents.get_selectedNode();
              if (node) {
                  var newNodeId = node.get_id();
                  var id = CreateTableofcontent(FileId,newNodeId, name, pageNum);
                  if (id>0) {
                      createNodeTableofcontent(node, id, name,pageNum);
                  }
                  else if(id==0) {
                      var span_info;
                      span_info = document.getElementById('span_info');
                      var span_treeivew_Tableofcontent_duplicate;
                      span_treeivew_Tableofcontent_duplicate = document.getElementById('span_treeivew_Tableofcontent_duplicate');
                      top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_Tableofcontent_duplicate.innerHTML);
                      //closeDialog('Dialog_Content_Table_Of_Contents');
                      top.closeDialog('Dialog_content');
                  }
                  else if(id==-1) {
                      var span_error_update;
                      span_error_update = document.getElementById('span_error_update');
                      top.showDialogInfo('', true, 5, span_info.innerHTML, span_error_update.innerHTML);
                      top.closeDialog('Dialog_content');
                  }
              }
          }
          
          function createNodeTableofcontent(pid, nid, name,pageNum) {
              TreeViewCollection_Table_Of_Contents.beginUpdate();
              var newNode = new ComponentArt.Web.UI.TreeViewNode();
              newNode.set_text(name);
              newNode.set_value(pageNum);
              newNode.set_id(nid);
			  newNode.setProperty('fileId',FileId);
              TreeViewCollection_Table_Of_Contents.findNodeById(pid.get_id()).get_nodes().add(newNode);
              TreeViewCollection_Table_Of_Contents.endUpdate();
              pid.expand(true);
              //closeDialog('Dialog_Content_Table_Of_Contents');
              top.closeDialog('Dialog_content');
          }
          
          function remove_Tableofcontent() {
              var node = TreeViewCollection_Table_Of_Contents.get_selectedNode();
              if (node) {
                  var span_cancel_para1;
                  span_cancel_para1 = document.getElementById('span_cancel_para1');
                  var span_treeivew_delete_Tableofcontent;
                  span_treeivew_delete_Tableofcontent = document.getElementById('span_treeivew_delete_Tableofcontent');
                  top.showDialogConfirmInfo('delete_Tableofcontent()' + 'callback', true, 3, span_cancel_para1.innerHTML, span_treeivew_delete_Tableofcontent.innerHTML, true);
              }
          }
          
          function delete_Tableofcontent() {
              var node = TreeViewCollection_Table_Of_Contents.get_selectedNode();
              var valReturn;
              valReturn = DeleteTableofcontent(node.get_id());
              if (valReturn==1) {
                  if (node) {
                      node.remove();
                      var idParentnode = node.get_parentNode().get_id();
                      if (idParentnode){
                            TreeViewCollection_Table_Of_Contents.selectNodeById(idParentnode);
                      }
                  }
              }
              else if (valReturn == 2) {
                  var span_info;
                  span_info = document.getElementById('span_info');
                  var span_treeivew_delete_Tableofcontent_fail2 = document.getElementById('span_treeivew_delete_Tableofcontent_fail2');
                  top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_delete_Tableofcontent_fail2.innerHTML);
              }
              else if (valReturn == 0) {
                  var span_info;
                  span_info = document.getElementById('span_info');
                  var span_treeivew_delete_Tableofcontent_fail1 = document.getElementById('span_treeivew_delete_Tableofcontent_fail1');
                  top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_delete_Tableofcontent_fail1.innerHTML);
              }
          }
      
        function viewRecord(id){
//            var span_preview;
//            span_preview = document.getElementById('span_preview');
//            var displayType;
//            displayType = top.footercontent.document.getElementById('cboType');
//            top.showDialogContent('AcqPreviewFrame.aspx?id='+String(id)+ '&displayType='+displayType.value, true, span_preview.innerHTML, 120, 80);
        }
    
      function GridTableOfContent_onItemClick(sender, eventArgs){
            var item = eventArgs.get_item();
            itemGrid = item;
	    //console.log(item.Cells[7].get_value() + ' 5 ' + item.Cells[5].get_value() + ' 8 ' + item.Cells[8].get_value());
            if (item != null){
                FileId = item.Cells[7].get_value();
                DocId = item.Cells[5].get_value();
                if(item.Cells[8].get_value()!=''){
                    XMLpath = item.Cells[8].get_value();
                }
            }            
      }    
    
      // Handles the Grid double-click event 
      function GridTableOfContent_onItemDoubleClick(sender, eventArgs)
      {
          var item = eventArgs.get_item();       
	  //console.log(item);   
          if (item != null) {
                //console.log(XMLpath + item.Cells[8].get_value() + 'g');
                if(item.Cells[8].get_value()){
                    if (XMLpath!=''){
                        showViewer(1,XMLpath);
                    }
                }
          }
      }
      
      // Handles the TreeView node select event 
      function TreeViewCollection_refresh(val)
      { 
        if (val) {
            TreeViewCollection_Table_Of_Contents.selectNodeById(val); 
        }
        else {
            var node = TreeViewCollection_Table_Of_Contents.get_selectedNode();
            if (node.get_id() > 0) {
                TreeViewCollection_Table_Of_Contents.selectNodeById(node.get_id()); 
            }
        }
      }
        
      // Handles the TreeView node select event 
      function TreeViewCollection_onNodeSelect(sender, eventArgs)
      { 
        if (XMLpath!='')
        {
            var node = eventArgs.get_node();
            var id = node.getProperty("fileId");
            if (FileId==id){
                if (node.get_value()>0){
                    /// LoadViewer(node.get_value(),XMLpath);
                    searchGotoPages(node.get_value());
                }
            }
        }
      }

      // Handles the TreeView load event 
      function TreeViewCollection_onLoad(sender, eventArgs)
      { 
        TreeViewCollection_Table_Of_Contents.SelectNodeById('0');
      }

      // Context menu global variables     
      var contextMenuX = 0; 
      var contextMenuY = 0; 
      var contextItem = ""; 
      
      
      // Context menu global variables for grid    
      var contextMenuX_grid = 0; 
      var contextMenuY_grid = 0; 

      // Loads the Grid context menu through an AJAX-style callback 
      function GridTableOfContent_onContextMenu(sender, eventArgs) 
      {
        
        var item = eventArgs.get_item();
        GridTableOfContent.select(item);
        
        SetupContextMenuCallbackContainerForMenuGrid(eventArgs.get_event());
        MenuGrid.set_contextData(eventArgs.get_item());

        // Load the menu from the server, given the file extension 
        MenuCallBackGrid.callback(item.Cells[5].get_value()); 
      }

      // Loads the TreeView context menu through an AJAX-style callback 
      function TreeViewCollection_onContextMenu(sender, eventArgs) 
      {
        SetupContextMenuCallbackContainer(eventArgs.get_event());

        // Set the global contextItem variable
        //contextItem = eventArgs.get_node().get_text();
        contextItem = eventArgs.get_node().get_id();

        // Load the menu from the server, given the directory 
        // (empty string) extension 
        MenuCallBack.callback(contextItem);
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
      function MenuCollection_onItemSelect(sender, eventArgs)
      {
          if (FileId>0){
              var menuItem = eventArgs.get_item();
              var contextDataNode = menuItem.get_parentMenu().get_contextData();
              switch (menuItem.get_value()) {
                  case 'add':
                        var flash;
                        var page = 0;
                        flash = getFlashMovieObject("ViewerPdf");
                        if (flash) {
                            page = flash.GetPages();
                        }

                      var intHeight;
                      intHeight = window.screen.availHeight;
                      if (intHeight-contextMenuY<305+100)
                      {
                        contextMenuY = contextMenuY - 205;
                      }
                      var span_title_form;
                      span_title_form = document.getElementById('span_title_form');
                      //top.showDialogContent('AcqTableOfContentsAddFrame.aspx?addnew=1&page='+page, false, span_title_form.innerHTML,contextMenuX , contextMenuY , 720 , 305);
                      top.showDialogContentFix('Edeliv/Edata/AcqTableOfContentsAddFrame.aspx?addnew=1&page='+page, false, span_title_form.innerHTML, 25,25 , 720 , 205);
                      break;
                      
                  case 'edit':
                      var nodeId = 0;
                      var node = TreeViewCollection_Table_Of_Contents.get_selectedNode();
                      if (node) {
                         nodeId = node.get_id();
                      }
                      var intHeight
                      intHeight = window.screen.availHeight;
                      if (intHeight-contextMenuY<305+100)
                      {
                        contextMenuY = contextMenuY - 205;
                      }
                      var span_title_form;
                      span_title_form = document.getElementById('span_title_form');
                      top.showDialogContentFix('Edeliv/Edata/AcqTableOfContentsAddFrame.aspx?nodeId='+ String(nodeId) , false, span_title_form.innerHTML,25,25 , 720 , 205);
                      break;
                  case 'delete':
                      remove_Tableofcontent();
                      break;
              }
          }
          else{
              var span_info;
              span_info = document.getElementById('span_info');
              var span_choose_doc = document.getElementById('span_choose_doc');
              top.showDialogInfo('', true, 5, span_info.innerHTML, span_choose_doc.innerHTML);
          }
          return true;

          
      }

      // Handles the CallBack callback complete event 
      function MenuCallBack_onCallbackComplete()
      {
        MenuCollection.showContextMenu(contextMenuX, contextMenuY); 
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
                  if (XMLpath)
                    showViewer(1,XMLpath);
                  break;
          }
          return true;
      }
      
      function GridCallBack_onBeforeCallback(sender, e){
          var tree = <%= TreeViewCollection_Table_Of_Contents.ClientObjectId %>; 
          if (tree != null)
		    {
			    tree.dispose();
		    }
      }

      // Forces the treeview to adjust to the new size of its container          
      function resizeTree(sender, eventArgs) {
          var iUnit;
          iUnit = 8;
        var pane = eventArgs.get_pane();
        var newPaneWidth = pane.get_width();
        var newPaneHeight = pane.get_height();
        
        if(window.TreeViewCollection_Table_Of_Contents && window.CallbackTreeview && newPaneWidth && newPaneWidth > 2 && newPaneHeight && newPaneHeight > 2)
        {
            CallbackTreeview.element.style.width = (newPaneWidth - 2) + 'px';
            //CallbackTreeview.element.style.height = (newPaneHeight - iUnit) + 'px';
            CallbackTreeview.element.style.height = (viewerHeight - 20) + 'px';
            TreeViewCollection_Table_Of_Contents.render();
            document.getElementById("ifrm1").style.height = (viewerHeight - 10) + "px";
            
        }
      }    

      // Forces the grid to adjust to the new size of its container          
      function resizeGrid(sender, eventArgs) {
          var iUnit;
          iUnit = 12;
        var pane = eventArgs.get_pane();
        var newPaneWidth = pane.get_width();
        var newPaneHeight = pane.get_height();
        if(window.GridTableOfContent && window.GridCallBack && newPaneWidth && newPaneWidth > 2 && newPaneHeight && newPaneHeight > 2) {
            //GridCallBack.element.style.width = '100%'; //(newPaneWidth - 2 - iUnit) + 'px';
            GridCallBack.element.style.width = (newPaneWidth - 10 - iUnit) + 'px';
            GridCallBack.element.style.height = (newPaneHeight - 10) + 'px';
            //GridCallBack.element.style.height = viewerHeight  +'px';
            GridTableOfContent.render();

            document.getElementById("ifrm1").style.width = (newPaneWidth - 4) + "px";
        }
      }  
      
      function closeDialog(key) {
            toggle_close('Dialog_Content_Table_Of_Contents');
      }

      function TreeViewCollection_onNodeBeforeMove(sender, eventArgs)
        {
          var movingNode = eventArgs.get_node();
          var sourceTreeView = eventArgs.get_node().get_parentTreeView();
          var targetNode = eventArgs.get_newParentNode();
          var targetTreeView = eventArgs.get_newParentTreeView();

          var span_treeview_move1,span_treeview_move2;
          span_treeview_move1 = document.getElementById('span_treeview_move1');
          span_treeview_move2 = document.getElementById('span_treeview_move2');
          var doMove = false;
          doMove = confirm(span_treeview_move1.innerHTML + " '" + movingNode.get_text() + "' " + span_treeview_move2.innerHTML + " '" + targetNode.get_text() + "'?");          
          if (doMove)
            {
                var valReturn;
                valReturn = MoveTableofcontent(movingNode.get_id(),  targetNode.get_id());
                if (!valReturn)
                {
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
<body oncontextmenu="CancelContextMenu(event);" style="margin-top: 0px; margin-left: 0px;
                                          margin-right: 0px; margin-bottom: 0px">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" />
   <%-- <div class="main-head-form">
        Biên mục mục lục
    </div>--%>
    <div id="divBody">
        <ComponentArt:Splitter runat="server" ID="SplitterCollection" Height="400px" FillWidth="true"
            ImagesBaseUrl="../../Images/ComponentArt/Splitter/Images/">
            <Layouts>
                <ComponentArt:SplitterLayout>
                    <Panes Orientation="Horizontal" SplitterBarCollapseImageUrl="splitter_horCol.gif"
                        SplitterBarCollapseHoverImageUrl="splitter_horColHover.gif" SplitterBarExpandImageUrl="splitter_horExp.gif"
                        SplitterBarExpandHoverImageUrl="splitter_horExpHover.gif" SplitterBarCollapseImageWidth="1"
                        SplitterBarCollapseImageHeight="116" SplitterBarCssClass="HorizontalSplitterBar"
                        SplitterBarCollapsedCssClass="CollapsedHorizontalSplitterBar" SplitterBarActiveCssClass="ActiveSplitterBar"
                        SplitterBarWidth="5">
                        <ComponentArt:SplitterPane PaneContentId="TreeViewContent" Width="20%" MinWidth="1">
                            <ClientEvents>
                                <PaneResize EventHandler="resizeTree" />
                            </ClientEvents>
                        </ComponentArt:SplitterPane>
                        <ComponentArt:SplitterPane PaneContentId="GridContent" Width="80%" MinWidth="100"
                            Visible="true">
                            <ClientEvents>
                                <PaneResize EventHandler="resizeGrid" />
                            </ClientEvents>
                        </ComponentArt:SplitterPane>
                    </Panes>
                </ComponentArt:SplitterLayout>
            </Layouts>
            <Content>
                <ComponentArt:SplitterPaneContent ID="TreeViewContent">
                    <div class="bgbody">
                        <ComponentArt:ToolBar ID="ToolBarTableOfContents" ImagesBaseUrl="../../Images/ComponentArt/Toolbar/images/FooterControls/"
                            DefaultItemCssClass="item" DefaultItemHoverCssClass="itemHover" DefaultItemActiveCssClass="itemActive"
                            DefaultItemTextImageSpacing="2" DefaultItemTextImageRelation="ImageBeforeText"
                            DefaultItemImageHeight="20" DefaultItemImageWidth="20" Orientation="Horizontal"
                            UseFadeEffect="false" runat="server">
                            <ClientEvents>
                                <ItemSelect EventHandler="ToolBar_ItemCommand" />
                            </ClientEvents>
                            <Items>
                                <ComponentArt:ToolBarItem ID="ToolBarItem1" runat="server" Text="" Value="addbookmark"
                                    ImageUrl="bookma-new.png" />
                                <ComponentArt:ToolBarItem ItemType="Separator" Width="1" />
                                <ComponentArt:ToolBarItem ID="ToolBarItem2" runat="server" Text="" Value="editbookmark"
                                    ImageUrl="bookmark-edit.png" />
                                <ComponentArt:ToolBarItem ItemType="Separator" Width="1" />
                                <ComponentArt:ToolBarItem ID="ToolBarItem3" runat="server" Text="" Value="deletebookmark"
                                    ImageUrl="bookmark-delete.png" />
                            </Items>
                        </ComponentArt:ToolBar>
                    </div>
                    <div id="TreeContainer" class="TreeContainer">
                        <ComponentArt:CallBack ID="CallbackTreeview" runat="server">
                            <ClientEvents>
                                <Load EventHandler="AjaxCallBack_onLoad" />
                                <CallbackComplete EventHandler="resizeTreeRefresh" />
                            </ClientEvents>
                            <Content>
                                <ComponentArt:TreeView ID="TreeViewCollection_Table_Of_Contents" Width="100%" AutoScroll="true"
                                    FillContainer="true" HoverPopupEnabled="true" HoverPopupNodeCssClass="HoverPopup"
                                    DragAndDropEnabled="true" NodeEditingEnabled="false" KeyboardEnabled="false"
                                    CssClass="TreeView" NodeCssClass="TreeNode" SelectedNodeCssClass="SelectedTreeNode"
                                    HoverNodeCssClass="HoverTreeNode" LineImageWidth="19" LineImageHeight="20" DefaultImageWidth="20"
                                    DefaultImageHeight="20" ItemSpacing="0" ImagesBaseUrl="../../Images/ComponentArt/Treeview/images/"
                                    NodeLabelPadding="3" ShowLines="true" LineImagesFolderUrl="../../Images/ComponentArt/Treeview/images/lines/"
                                    CollapseNodeOnSelect="false" EnableViewState="true" runat="server">
                                    <ClientEvents>
                                        <Load EventHandler="TreeViewCollection_onLoad" />
                                        <NodeSelect EventHandler="TreeViewCollection_onNodeSelect" />
                                        <ContextMenu EventHandler="TreeViewCollection_onContextMenu" />
                                        <NodeBeforeMove EventHandler="TreeViewCollection_onNodeBeforeMove" />
                                    </ClientEvents>
                                </ComponentArt:TreeView>
                            </Content>
                        </ComponentArt:CallBack>
                    </div>
                </ComponentArt:SplitterPaneContent>

                <ComponentArt:SplitterPaneContent ID="GridContent">
                    <div id="divViewerPdf">
                        <div id="spViewerPdf">
                        </div>
                    </div>
                    <div id="divViewer">
                        <span id="spViewer" runat="server">
                            
                        </span>
                        <iframe  allowtransparency="true" class="iframe" id="ifrm1" scrolling="no" src="" ></iframe>
                    </div>
                    <div id="divGrid">
                        <ComponentArt:CallBack ID="GridCallBack" CssClass="GridContainer" runat="server"
                            LoadingPanelFadeDuration="500" LoadingPanelFadeMaximumOpacity="60">
                            <ClientEvents>
                                <BeforeCallback EventHandler="GridCallBack_onBeforeCallback" />
                                <Load EventHandler="AjaxCallBack_onLoad" />
                            </ClientEvents>
                            <Content>
                                <ComponentArt:Grid ID="GridTableOfContent" FillContainer="true" AutoAdjustPageSize="true"
                                    RunningMode="Client" ShowHeader="true" ShowSearchBox="true" AutoFocusSearchBox="false"
                                    SearchText="Lọc" SearchBoxPosition="TopRight" SearchBoxCssClass="searchbox" GroupingNotificationText=""
                                    SearchOnKeyPress="false" HeaderCssClass="GridHeader" KeyboardEnabled="false"
                                    CssClass="GridTree" FooterCssClass="GridFooternew" ImagesBaseUrl="../../Images/ComponentArt/Grid/images/"
                                    PagerImagesFolderUrl="../../Images/ComponentArt/Grid/images/pager/" EnableViewState="false"
                                    PagerStyle="Slider" PagerTextCssClass="GridFooterText" PagerButtonHoverEnabled="true"
                                    PagerButtonWidth="41" PagerButtonHeight="22" SliderHeight="20" SliderWidth="150"
                                    SliderGripWidth="9" SliderPopupOffsetX="20" SliderPopupClientTemplateId="SliderTemplate"
                                    PagerInfoClientTemplateId="MyPager" GroupBySortAscendingImageUrl="group_asc.gif"
                                    GroupBySortDescendingImageUrl="group_desc.gif" GroupBySortImageWidth="10" GroupBySortImageHeight="10"
                                    IndentCellWidth="22" Width="300px" Height="70%" runat="server">
                                    <ClientEvents>
                                        <ItemClick EventHandler="GridTableOfContent_onItemClick" />
                                        <ItemDoubleClick EventHandler="GridTableOfContent_onItemDoubleClick" />
                                        <ContextMenu EventHandler="GridTableOfContent_onContextMenu" />
                                    </ClientEvents>
                                    <Levels>
                                        <ComponentArt:GridLevel ShowTableHeading="false" ShowSelectorCells="false" HeadingCellCssClass="HeadingCell"
                                            HeadingCellHoverCssClass="HeadingCellHover" HeadingTextCssClass="HeadingCellText"
                                            DataCellCssClass="DataCell" RowCssClass="Row" SelectedRowCssClass="SelectedRow"
                                            SortedDataCellCssClass="SortedDataCell" SortedHeadingCellCssClass="SortedHeadingCell"
                                            ColumnReorderIndicatorImageUrl="reorder.gif" SortAscendingImageUrl="asc.gif"
                                            SortDescendingImageUrl="desc.gif" SortImageWidth="10" SortImageHeight="19">
                                            <Columns>
                                                <ComponentArt:GridColumn DataField="Icon" AllowEditing="True" Visible="false" />
                                                <ComponentArt:GridColumn DataField="DateModified" FormatString="dd/MM/yyyy hh:mm tt" SortImageJustify="false" HeadingText="&nbsp;&nbsp;Ngày nhập" DefaultSortDirection="Descending" />
                                                <ComponentArt:GridColumn DataField="FielName" DataCellClientTemplateId="FirstColumnTemplate"
                                                    HeadingText="&nbsp;&nbsp;Tên tệp" SortImageJustify="false" DefaultSortDirection="Descending"
                                                    Align="left" />
                                                <ComponentArt:GridColumn DataField="Name" DataCellClientTemplateId="NameColumnTemplate"
                                                    Align="left" SortImageJustify="true" HeadingText="Nhan đề&nbsp;&nbsp;" DefaultSortDirection="Descending" />
                                                <ComponentArt:GridColumn DataField="Value" Visible="false" />
                                                <ComponentArt:GridColumn DataField="DocID" Visible="false" />
                                                <ComponentArt:GridColumn DataField="Creator" HeadingText="&nbsp;&nbsp;Người biên mục"
                                                    DataCellClientTemplateId="creatorColumnTemplate" DefaultSortDirection="Ascending"
                                                    Align="left" Width="100" />
                                                <ComponentArt:GridColumn DataField="id" Visible="false" />
                                                <ComponentArt:GridColumn DataField="XMLpath" Visible="false" />
                                                <ComponentArt:GridColumn DataField="viewContent" Visible="false" />
                                                <ComponentArt:GridColumn DataField="viewer" HeadingText="&nbsp;Trạng thái" DataCellClientTemplateId="statusColumnTemplate"
                                                    DefaultSortDirection="Descending" Align="left" Width="30" />
                                            </Columns>
                                        </ComponentArt:GridLevel>
                                    </Levels>
                                    <ClientTemplates>
                                        <ComponentArt:ClientTemplate ID="statusColumnTemplate">
                                            ## DataItem.GetMember('viewContent').Value ? '<img src="../../Images/ComponentArt/grid/images/viewered.png"
                                                height="20" width="20" alt="'+ document.getElementById('span_viewered').innerHTML + '"
                                                title="' + document.getElementById('span_viewered').innerHTML + '" />' : '<img src="../../Images/ComponentArt/grid/images/view-refresh.png"
                                                    height="20" width="20" alt="'+ document.getElementById('span_not_viewer').innerHTML + '"
                                                    title="' + document.getElementById('span_not_viewer').innerHTML + '" />'
                                            ##
                                        </ComponentArt:ClientTemplate>
                                        <ComponentArt:ClientTemplate ID="FirstColumnTemplate">
                                            <img src="../../Images/ComponentArt/grid/images/## DataItem.GetMember('Icon').Value ##"
                                                width="16" height="16" border="0" />
                                            ## DataItem.GetMember("FielName").Value ##
                                        </ComponentArt:ClientTemplate>
                                        <ComponentArt:ClientTemplate ID="NameColumnTemplate">
                                            ## DataItem.GetMember("Name").Value ##
                                        </ComponentArt:ClientTemplate>
                                        <ComponentArt:ClientTemplate ID="creatorColumnTemplate">
                                            ## DataItem.GetMember("Creator").Value ##
                                        </ComponentArt:ClientTemplate>
                                        <ComponentArt:ClientTemplate ID="SliderTemplate">
                                            <table class="SliderPopup" width="200" style="background-color: #ffffff" cellspacing="0"
                                                cellpadding="0" border="0">
                                                <tr>
                                                    <td style="padding: 10px;" valign="middle" align="center">
                                                        Trang <b>## DataItem.PageIndex + 1 ##</b> của <b>## GridTableOfContent.PageCount ##</b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ComponentArt:ClientTemplate>
                                        <ComponentArt:ClientTemplate ID="MyPager">
                                            ## var Page = document.getElementById('span_grid_page').innerHTML; var of = document.getElementById('Span_grid_of').innerHTML;
                                            var items = document.getElementById('span_grid_item').innerHTML; var Norecordsfound
                                            = document.getElementById('span_grid_nodata').innerHTML; var currentPageIndex =
                                            (GridTableOfContent == null) ? 0 : GridTableOfContent.get_currentPageIndex(); var
                                            pageCount = (GridTableOfContent == null) ? 0 : GridTableOfContent.get_pageCount();
                                            var recordCount = (GridTableOfContent == null) ? 0 : GridTableOfContent.get_recordCount();
                                            if (recordCount < 1) { Norecordsfound; } else { Page + " <b>" + (currentPageIndex +
                                                1) + "</b> " + of + " <b>" + (pageCount) + "</b> (" + recordCount + " " + items
                                            + ")"; } ##
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
                                                    <td style="font-size: 10px;">
                                                        Đang nạp dữ liệu...&nbsp;
                                                    </td>
                                                    <td>
                                                        <img src="../../images/spinner.gif" width="16" height="16" border="0" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </LoadingPanelClientTemplate>
                        </ComponentArt:CallBack>
                    </div>
                </ComponentArt:SplitterPaneContent>
            </Content>
        </ComponentArt:Splitter>

        <ComponentArt:CallBack ID="MenuCallBack" runat="server">
            <ClientEvents>
                <CallbackComplete EventHandler="MenuCallBack_onCallbackComplete" />
                <Load EventHandler="AjaxCallBack_onLoad" />
            </ClientEvents>
            <Content>
                <ComponentArt:Menu ID="MenuCollection" Orientation="Vertical" DefaultGroupCssClass="TopMenu_Group"
                    DefaultItemLookId="DefaultItemLook" DefaultGroupItemSpacing="0" DefaultItemHeight="22"
                    TopGroupExpandDirection="BelowLeft" ImagesBaseUrl="../../Images/ComponentArt/Menu/images/"
                    EnableViewState="false" ExpandDelay="100" ExpandDuration="0" ExpandSlideType="None"
                    ContextMenu="Custom" runat="server">
                    <ClientEvents>
                        <ItemSelect EventHandler="MenuCollection_onItemSelect" />
                    </ClientEvents>
                    <ItemLooks>
                        <ComponentArt:ItemLook LookId="DefaultItemLook" CssClass="MenuItemInputAcquisition"
                            HoverCssClass="MenuItemHoverInputAcquisition" ExpandedCssClass="MenuItemHoverInputAcquisition"
                            LeftIconWidth="20" LeftIconHeight="18" LabelPaddingLeft="10" LabelPaddingRight="10"
                            LabelPaddingTop="3" LabelPaddingBottom="4" />
                        <ComponentArt:ItemLook LookId="BreakItem" CssClass="MenuBreakInputAcquisition" />
                    </ItemLooks>
                </ComponentArt:Menu>
            </Content>
            <LoadingPanelClientTemplate>
                <table cellspacing="0" cellpadding="0" border="0" class="MenuCallBack">
                    <tr>
                        <td align="center">
                            <table cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td style="font-size: 10px;" align="center">
                                        Đang nạp dữ liệu...&nbsp;
                                    </td>
                                    <td>
                                        <img alt="" src="../../images/spinner.gif" width="16" height="16" border="0" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LoadingPanelClientTemplate>
        </ComponentArt:CallBack>

        <ComponentArt:CallBack ID="MenuCallBackGrid" runat="server" Width="500px">
            <ClientEvents>
                <CallbackComplete EventHandler="MenuCallBackGrid_onCallbackComplete" />
                <Load EventHandler="AjaxCallBack_onLoad" />
            </ClientEvents>
            <Content>
                <ComponentArt:Menu ID="MenuGrid" Orientation="Vertical" DefaultGroupCssClass="TopMenu_Group"
                    DefaultItemLookId="DefaultItemLook" DefaultGroupItemSpacing="0" DefaultItemHeight="22"
                    TopGroupExpandDirection="BelowLeft" ImagesBaseUrl="../../Images/ComponentArt/Menu/images/"
                    EnableViewState="false" ExpandDelay="100" ExpandDuration="0" ExpandSlideType="None"
                    Width="500px" ContextMenu="Custom" runat="server">
                    <ClientEvents>
                        <ItemSelect EventHandler="MenuGrid_onItemSelect" />
                    </ClientEvents>
                    <ItemLooks>
                        <ComponentArt:ItemLook LookId="DefaultItemLook" CssClass="MenuItemInputAcquisition"
                            HoverCssClass="MenuItemHoverInputAcquisition" ExpandedCssClass="MenuItemHoverInputAcquisition"
                            LeftIconWidth="20" LeftIconHeight="18" LabelPaddingLeft="10" LabelPaddingRight="10"
                            LabelPaddingTop="3" LabelPaddingBottom="4" />
                        <ComponentArt:ItemLook LookId="BreakItem" CssClass="MenuBreakInputAcquisition" />
                    </ItemLooks>
                </ComponentArt:Menu>
            </Content>
            <LoadingPanelClientTemplate>
                <table cellspacing="0" cellpadding="0" border="0" class="MenuCallBack">
                    <tr>
                        <td align="center">
                            <table cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td style="font-size: 10px;" align="center">
                                        Đang nạp dữ liệu...&nbsp;
                                    </td>
                                    <td>
                                        <img alt="" src="../../images/spinner.gif" width="16" height="16" border="0" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LoadingPanelClientTemplate>
        </ComponentArt:CallBack>
    </div>
    <div>
    </div>
    <div style="position: absolute; top: 0px; left: 0px; visibility: hidden;">
        <ComponentArt:ToolBar ID="ToolbarTemp" runat="server">
        </ComponentArt:ToolBar>
        <ComponentArt:Menu ID="MenuTemp" runat="server">
        </ComponentArt:Menu>
        <ComponentArt:Grid ID="gridTemp" runat="server">
        </ComponentArt:Grid>
        <ComponentArt:TreeView ID="TreeviewTemp" Width="100%" runat="server" Visible="false">
        </ComponentArt:TreeView>
        <span id="span_viewered" runat="server">Đã biên mục mục lục...</span> <span id="span_not_viewer"
            runat="server">Chưa biên mục mục lục...</span> <span id="span_toolbar_add_alert"
                runat="server">Xin vui lòng chọn mục trong cây Mục lục trước...</span> <span id="span_toolbar_edit_alert"
                    runat="server">Không thể xóa/sửa Mục lục này...</span> <span id="span_choose_doc"
                        runat="server">Xin vui lòng chọn dữ liệu điện tử để tạo mục lục...</span>
        <span id="span_preview" runat="server"></span><span id="span_addCollection_info"
            runat="server"></span><span id="span_addFile_info" runat="server"></span><span id="span_treeview_new_Tableofcontent"
                runat="server">Thêm mới Mục lục</span> <span id="span_treeview_edit_Tableofcontent"
                    runat="server">Sửa Mục lục</span> <span id="span_treeview_delete_Tableofcontent"
                        runat="server">Xóa Mục lục</span> <span id="span_treeview_charge" runat="server">Truy
                            cập</span> <span id="span_treeview_status" runat="server">Trạng thái</span>
        <span id="span_treeview_security" runat="server">Mức độ mật</span> <span id="span_grid_open"
            runat="server">Mở</span> <span id="span_grid_item" runat="server">mục</span>
        <span id="span_grid_nodata" runat="server">Không có dữ liệu</span> <span id="span_grid_page"
            runat="server">Trang</span> <span id="Span_grid_of" runat="server">của</span>
        <span id="span_info" runat="server">Thông báo!; Đóng</span> <span id="span_grid_check"
            runat="server">Xin vui lòng đánh dấu để chọn tệp biên mục...</span> <span id="span_grid_check_delete"
                runat="server">Xin vui lòng đánh dấu để chọn tệp xóa...</span> <span id="span_treeivew_Tableofcontent_duplicate"
                    runat="server">Mục lục này đã tồn tại. Thêm mới Mục lục không thành công.</span>
        <span id="span_treeivew_Tableofcontent_duplicate_rename" runat="server">Mục lục này
            đã tồn tại. Sửa Mục lục không thành công.</span> <span id="span_treeivew_delete_Tableofcontent"
                runat="server">Bạn có chắc chắn muốn xóa Mục lục này không?</span> <span id="span_treeivew_delete_Tableofcontent_fail1"
                    runat="server">Lỗi xóa Mục lục. Xóa Mục lục không thành công.</span>
        <span id="span_treeivew_delete_Tableofcontent_fail2" runat="server">Xin vui lòng xóa
            Mục lục con trước khi xóa Mục lục này .Xóa Mục lục không thành công.</span>
        <span id="span_treeivew_delete_Tableofcontent_fail3" runat="server">Mục lục đang gắn
            với biểu ghi biên mục .Xóa Mục lục không thành công.</span> <span id="span_treeivew_update_Tableofcontent"
                runat="server">Lỗi chuyển mục lục. Chuyển mục lục không thành công.</span>
        <span id="span_treeview_move1" runat="server">Bạn có chắc chắn muốn chuyển mục</span>
        <span id="span_treeview_move2" runat="server">đến mục</span> <span id="span_cancel_para1"
            runat="server">Cảnh báo!; Chấp nhận ; Không chấp nhận</span> <span id="span_treeivew_delete"
                runat="server">Mục lục này là mục lục gốc. Xóa Mục lục không thành công.</span>
        <span id="span_treeivew_rename" runat="server">Mục lục này là mục lục gốc. Sửa Mục lục
            này không thành công.</span> <span id="span_treeivew_rename_duplicate" runat="server">
                Mục lục này đã tồn tại. Sửa Mục lục này không thành công.</span> <span id="span_grid_delete_file_info"
                    runat="server">Xóa</span> <span id="span_grid_delete_file" runat="server">Bạn có chắc
                        chắn muốn xóa tệp này không?</span> <span id="span_grid_delete_file_error1" runat="server">
                            Đường dẫn tệp không tồn tại. Xóa tệp không thành công...</span>
        <span id="span_grid_delete_file_error2" runat="server">Lỗi xóa tệp..... Xóa tệp không
            thành công...</span> <span id="span_grid_delete_file_error3" runat="server">Tệp có gắn
                với biểu ghi biên mục. Xóa tệp không thành công.</span> <span id="span_treeview_root_Tableofcontent"
                    runat="server">Mục lục</span> <span id="span_title_form" runat="server">Nhập/sửa mục
                        lục</span> <span id="span_error_update" runat="server">Lỗi cập nhật dữ liệu. Cập nhật
                            dữ liệu không thành công.</span>
        <asp:DropDownList ID="ddlLabel" runat="server" Width="0" Visible="False">
            <asp:ListItem Value="0">Mã lỗi</asp:ListItem>
            <asp:ListItem Value="1">Chi tiết lỗi</asp:ListItem>
        </asp:DropDownList>
    </div>
    </form>
</body>
</html>
