<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqMagazineTableOfContents.aspx.vb" Inherits="eMicLibAdmin.WebUI.Serial.eMagazine_AcqTableOfContents" %>
<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
 <head>
  <meta charset="utf-8" />
  <meta name="DC.creator" content="Ruven Pillay &lt;ruven@users.sourceforge.netm&gt;"/>
  <meta name="DC.title" content="eMagazine 1.0"/>
  <meta name="DC.subject" content="IIPMooViewer; IIPImage; Visualization; HTML5; Ajax; High Resolution; Internet Imaging Protocol; IIP"/>
  <meta name="DC.description" content="IIPMooViewer is an advanced javascript HTML5 image viewer for streaming high resolution scientific images"/>
  <meta name="DC.rights" content="Copyright &copy; 2003-2012 Ruven Pillay"/>
  <meta name="DC.source" content="http://iipimage.sourceforge.net"/>
  <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
  <meta name="apple-mobile-web-app-capable" content="yes" />
  <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent" />
  <meta http-equiv="X-UA-Compatible" content="IE=9" />

  <link rel="stylesheet" type="text/css" media="all" href="css/iip.min.css" />
  <link rel="stylesheet" type="text/css" href="css/magazine.css" media="all" />

  <script language="JavaScript" type="text/javascript" src="../../../js/Public.js"></script>
  <link href="../../../Images/ComponentArt/Menu/style.css" type="text/css" rel="StyleSheet"/>
  <link href="../../../Images/ComponentArt/Treeview/style.css" type="text/css" rel="StyleSheet"/> 
  <link href="../../../Images/ComponentArt/Toolbar/Style.css" rel="stylesheet" type="text/css" />   


<!--[if lt IE 10]>
  <link rel="stylesheet" type="text/css" media="all" href="css/ie.min.css" />
<![endif]-->

  <!-- Basic example style for a 100% view -->
  <style type="text/css">
    body{
      height: 100%;
      padding: 0;
      margin: 0;
    }
    div#viewer{
      height: 93%;
      min-height: 93%;
      width: 80%;
      position: absolute;
      top: 0;
      left: 20%;
      margin: 0;
      padding: 0;
    }	
	div#vList{
	  height: 5%;
	  min-height: 5%;
      width: 100%;
      position: absolute;
      top: 95%;      
      margin: 0;
      padding: 0;
	}
	div#divTableOfContent
	{
	  height: 100%;
      min-height: 100%;
      width: 20%;
      position: absolute;
      top: 0;
      left: 0;
      margin: 0;
      padding: 0;
      color:#333; 
      background:#eee;
	}
	div#TreeContainer	
	{	  
      top: 32px;     
      height: 95%;
      min-height: 95%;
	}				
	div#divPage
	{		
	  position: absolute;	
      top: 8px;      
      margin: 0;
      padding: 0;
      color:#333;       
	}
	.img{
        text-align:left;
        vertical-align: middle;
    }
    div#divAnnotation
	{		
	  position: absolute;	
      bottom: 8px;      
      margin: 0;
      padding: 0;
      left: 50%;      
	}
	div#divShowhideW
	{		
	  position: absolute;	
      bottom: 5px;    
      margin: 0;
      padding: 0;
      left:40%;      
	}
  </style>

  <link rel="shortcut icon" href="images/iip-favicon.png" />
  <link rel="apple-touch-icon" href="images/iip.png" />

  <title>eMagazine 1.0</title>

 <!--  <script src="//ajax.googleapis.com/ajax/libs/mootools/1.4.5/mootools-yui-compressed.js"></script> -->
  <script type="text/javascript" src="js/mootools-yui-compressed.js"></script>
  <script type="text/javascript" src="js/iipmooviewer-2.0-min.js"></script>
  <script type="text/javascript" src="src/lang/help.vi.js"></script>

  <script type="text/javascript" src="src/annotations-edit.js"></script>

    <link rel="stylesheet"  href="css/jMobile/jquery.mobile-1.3.2.min.css" />

	<link rel="stylesheet"  href="css/jMobile/popup.css" />
	
	<link href="css/jquery.mCustomScrollbar.css" rel="stylesheet" />
	<script src="js/jquery.mCustomScrollbar.concat.min.js"></script>
        
    <script type="text/javascript" src="js/jMobile/jquery-1.9.1.min.js"></script>
	<script type="text/javascript" src="js/jMobile/jquery.mobile-1.3.2.min.js"></script>    
    <script type="text/javascript" src="js/jMobile/popup.js"></script>
    

  <script type="text/javascript">

      $.noConflict();  

      var magId = 0;
      var magDetailId = 0;
      var magPage = 1;
      var magPageCounts = 1;
      var magServer = ''; // '/IIPServerTVKHTH/iipsrv.fcgi';
      var magFile = '';
      //magFile = 'D:/Emiclib/Project-2013/SVN/DEVELOPMENT/SourceCode/ResourceMagazine/Images/DONG NAI_Page_1.tif';
      var magTitle = '';
      var iipmooviewer;

      function getXY() {
          var result = new Object;
          var offSetTop = 0.009, offSetLeft = 0.005;
          //var result = [];//0:left, 1:top
          result.left = (iipmooviewer.wid < iipmooviewer.view.w) ? 0.25 : (iipmooviewer.view.x + iipmooviewer.view.w / (7 * 2)) / iipmooviewer.wid - offSetLeft,
			result.top = (iipmooviewer.hei < iipmooviewer.view.h) ? 0.25 : ((iipmooviewer.view.y + iipmooviewer.view.h / (7 * 2)) / iipmooviewer.hei) - offSetTop,
            result.docId = 0,
            result.fileId = 0;
          return result;
      }

      function toggleFullScreen() {
          iipmooviewer.toggleFullScreen();
      }
      function moveXY(xk, yk) {
          var offset = 10;
          var x, y;
          xk = xk.replace(',', '.');
          yk = yk.replace(',', '.');
          x = Math.round(xk * iipmooviewer.wid) - (iipmooviewer.view.res * offset);
          y = Math.round(yk * iipmooviewer.hei) - offset;
          moveTo(x, y);
          //closePanel();
      }
      function moveTo(x, y) {
          iipmooviewer.moveTo(x, y);
      }
      
      (function ($) {
          jQuery(window).load(function () {
              jQuery("#TreeContainer").mCustomScrollbar({
                  scrollButtons: {
                      enable: true
                  },
                  theme: "dark"
              });
//              $(".TreeContainer.inner").mCustomScrollbar({
//                  horizontalScroll: true
//              });
          });
      })(jQuery);


      function gotoPrevious() {
          var hidMagId = document.getElementById('hidMagId');
          magId = hidMagId.value;            
          var num = parseInt(magPage);
          if (num > 1) {
              num = num - 1;
              location.href = "AcqMagazineTableOfContents.aspx?MagId=" + magId + "&page=" + num;
          }
          else {
              var span_info = document.getElementById('span_info');
              var span_warning_previous_page = document.getElementById('span_warning_previous_page');
              top.showDialogInfo('', true, 5, span_info.innerHTML, span_warning_previous_page.innerHTML);
          }
      }

      function gotoNext() {
          var hidMagId = document.getElementById('hidMagId');
          magId = hidMagId.value;
          var num = parseInt(magPage);
          if (num < parseInt(magPageCounts)) {
              num = num + 1;
              location.href = "AcqMagazineTableOfContents.aspx?MagId=" + magId + "&page=" + num;
          }
          else {
              var span_info = document.getElementById('span_info');
              var span_warning_next_page = document.getElementById('span_warning_next_page');
              top.showDialogInfo('', true, 5, span_info.innerHTML, span_warning_next_page.innerHTML);
          }
      }

      function ToolBar_ItemCommand(sender, e) {
          var hidMagDetailId = document.getElementById('hidMagDetailId');
          magDetailId = hidMagDetailId.value;
          if (magDetailId > 0) {
              var node = TreeViewCollection_Table_Of_Contents.get_selectedNode();
              switch (e.get_item().get_value()) {
                  case 'addbookmark':
                      if (node) {
                          var span_addCollection_info;
                          span_addCollection_info = document.getElementById('span_addCollection_info');
                          top.OpenWindowTableOfContentsEditor(1, magDetailId);
                      }
                      else {
                          var span_info;
                          span_info = document.getElementById('span_info');
                          var span_toolbar_add_alert = document.getElementById('span_toolbar_add_alert');
                          top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_add_alert.innerHTML);
                      }
                      break;
                  case 'editbookmark':
                      if (node) {
                          if (node) {
                              nodeId = node.get_id();
                          }
                          if (nodeId > 0) {
                              var span_editCollection_info;
                              span_editCollection_info = document.getElementById('span_editCollection_info');
                              top.OpenWindowTableOfContentsEditor(0, nodeId);
                          }
                          else {
                              var span_info;
                              span_info = document.getElementById('span_info');
                              var span_toolbar_edit_alert = document.getElementById('span_toolbar_edit_alert');
                              top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_edit_alert.innerHTML);
                          }
                      }
                      else {
                          var span_info;
                          span_info = document.getElementById('span_info');
                          var span_toolbar_add_alert = document.getElementById('span_toolbar_add_alert');
                          top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_add_alert.innerHTML);
                      }
                      break;
                  case 'deletebookmark':
                      if (node) {
                          nodeId = node.get_id();
                          if (nodeId > 0) {
                              remove_Tableofcontent();
                          }
                          else {
                              var span_info;
                              span_info = document.getElementById('span_info');
                              var span_toolbar_edit_alert = document.getElementById('span_toolbar_edit_alert');
                              top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_edit_alert.innerHTML);
                          }
                      }
                      else {
                          var span_info;
                          span_info = document.getElementById('span_info');
                          var span_toolbar_add_alert = document.getElementById('span_toolbar_add_alert');
                          top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_add_alert.innerHTML);
                      }
                      break;
              }
          }
          else {
              var span_info;
              span_info = document.getElementById('span_info');
              var span_choose_doc = document.getElementById('span_choose_doc');
              top.showDialogInfo('', true, 5, span_info.innerHTML, span_choose_doc.innerHTML);
          }
      }

      function remove_Tableofcontent() {
          var node = TreeViewCollection_Table_Of_Contents.get_selectedNode();
          if (node) {
              var span_cancel_para1;
              span_cancel_para1 = document.getElementById('span_cancel_para1');
              var span_treeivew_delete_Tableofcontent;
              span_treeivew_delete_Tableofcontent = document.getElementById('span_treeivew_delete_Tableofcontent');
              //top.showDialogConfirmInfo('delete_Tableofcontent()' + 'callbackMagazineDetail', true, 3, span_cancel_para1.innerHTML, span_treeivew_delete_Tableofcontent.innerHTML, true);
              if (confirm(span_treeivew_delete_Tableofcontent.innerHTML)) {
                  delete_Tableofcontent(); 
              }
          }
      }

      function delete_Tableofcontent() {
          var node = TreeViewCollection_Table_Of_Contents.get_selectedNode();
          var valReturn;
          valReturn = DeleteTableofcontent(node.get_id());
          if (valReturn == 1) {
              if (node) {
                  node.remove();
                  TreeViewCollection_Table_Of_Contents.SelectNodeById('0');
              }
          }
          else {
              var span_info;
              span_info = document.getElementById('span_info');
              var span_treeivew_delete_Tableofcontent_fail1 = document.getElementById('span_treeivew_delete_Tableofcontent_fail1');
              top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_delete_Tableofcontent_fail1.innerHTML);
          }
      }

      function CheckSubmit(key) {
          switch (key) {
              case 'close':
                  top.onClientCloseRWTableOfContents();
                  break;
          }
      }

      function create_Tableofcontent(subjectName, authorName, overview, pageNum) {
          var hidMagDetailId = document.getElementById('hidMagDetailId');
          magDetailId = hidMagDetailId.value;
          if (magDetailId > 0) {
              var coordinatesX = getXY().left, coordinatesY = getXY().top;
              var id = CreateTableofcontent(subjectName, authorName, overview, magDetailId, pageNum, coordinatesX, coordinatesY);
              if (id > 0) {
                  createNodeTableofcontent(id, overview, coordinatesX, coordinatesY);
              }
              else if (id == 0) {
                  var span_info;
                  span_info = document.getElementById('span_info');
                  var span_treeivew_Tableofcontent_duplicate;
                  span_treeivew_Tableofcontent_duplicate = document.getElementById('span_treeivew_Tableofcontent_duplicate');
                  top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_Tableofcontent_duplicate.innerHTML);
              }
          }
      }

      function createNodeTableofcontent(nid, overview, coordinatesX, coordinatesY) {
          TreeViewCollection_Table_Of_Contents.SelectNodeById('0');
          var node = TreeViewCollection_Table_Of_Contents.get_selectedNode();

          TreeViewCollection_Table_Of_Contents.beginUpdate();
          var newNode = new ComponentArt.Web.UI.TreeViewNode();
          newNode.set_text(overview);
          newNode.set_value(coordinatesX + '-' + coordinatesY);
          newNode.set_id(nid);
          TreeViewCollection_Table_Of_Contents.findNodeById(node.get_id()).get_nodes().add(newNode);
          TreeViewCollection_Table_Of_Contents.endUpdate();
          node.expand(true);
      }

      function rename_Tableofcontent(subjectName, authorName, overview, pageNum) {
          var coordinatesX = getXY().left, coordinatesY = getXY().top;
          var node = TreeViewCollection_Table_Of_Contents.get_selectedNode();
          if (node.get_id() > 0) {
              var valReturn;
              valReturn = UpdateTableofcontent(node.get_id(), subjectName, authorName, overview, pageNum, coordinatesX, coordinatesY);
              if (valReturn == 1) {
                  TreeViewCollection_Table_Of_Contents.beginUpdate();
                  node.set_text(overview);
                  node.set_value(coordinatesX + '-' + coordinatesY);
                  TreeViewCollection_Table_Of_Contents.endUpdate();
              }
              else if (valReturn == 0) {
                  var span_info;
                  span_info = document.getElementById('span_info');
                  var span_treeivew_rename;
                  span_treeivew_rename = document.getElementById('span_treeivew_rename');
                  top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_rename.innerHTML);
              }
          }
          else {
              var span_info;
              span_info = document.getElementById('span_info');
              var span_treeivew_rename;
              span_treeivew_rename = document.getElementById('span_treeivew_rename');
              top.showDialogInfo('', true, 5, span_info.innerHTML, span_treeivew_rename.innerHTML);
          }
      }

      function AjaxCallBack_onLoad(sender, e) {
          var iUnit;
          iUnit = 8;
          var iHeight = getHeightByBrowse();
          if (window.TreeViewCollection_Table_Of_Contents && window.CallbackTreeview && iHeight && iHeight > 2) {
              TreeContainer.style.height = (iHeight - iUnit) + 'px';
              CallbackTreeview.element.style.height = (iHeight - iUnit) + 'px';
              TreeViewCollection_Table_Of_Contents.render();
          }
      }
      // Handles the TreeView load event 
      function TreeViewCollection_onLoad(sender, eventArgs) {
          TreeViewCollection_Table_Of_Contents.SelectNodeById('0');
      }
      // Handles the TreeView node select event 
      function TreeViewCollection_onNodeSelect(sender, eventArgs) {
          var val = eventArgs.get_node().get_value();
          if (val != '0-0') {
              var coordinates = val.split("-");
              if (coordinates) {
                  moveXY(coordinates[0], coordinates[1]);
              }
          }
      }
      // Loads the TreeView context menu through an AJAX-style callback 
      function TreeViewCollection_onContextMenu(sender, eventArgs) {
          
          SetupContextMenuCallbackContainer(eventArgs.get_event());

          // Set the global contextItem variable
          //contextItem = eventArgs.get_node().get_text();
          contextItem = eventArgs.get_node().get_id();

          // Load the menu from the server, given the directory 
          // (empty string) extension
          MenuCallBack.callback('');

      }

      function SetupContextMenuCallbackContainer(evt) {
          evt = (evt == null) ? window.event : evt;

          var scrollLeft = document.documentElement && document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft;
          var scrollTop = document.documentElement && document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop;

          contextMenuX = evt.x ? evt.clientX : evt.clientX + scrollLeft;
          contextMenuY = evt.y ? evt.clientY : evt.clientY + scrollTop;

          var callbackX = evt.x ? contextMenuX + scrollLeft : contextMenuX;
          var callbackY = evt.y ? contextMenuY + scrollTop : contextMenuY;

          var menuCallBackDomElement = MenuCallBack.element;
          menuCallBackDomElement.style.position = 'absolute';
          menuCallBackDomElement.style.left = callbackX + 'px';
          menuCallBackDomElement.style.top = callbackY + 'px';
      }

      // Handles the CallBack callback complete event 
      function MenuCallBack_onCallbackComplete() {
          MenuCollection.showContextMenu(contextMenuX, contextMenuY);
      }

      // Handles the Menu item select event 
      function MenuCollection_onItemSelect(sender, eventArgs) {
          var hidMagDetailId = document.getElementById('hidMagDetailId');
          magDetailId = hidMagDetailId.value;
          if (magDetailId > 0) {
              var node = TreeViewCollection_Table_Of_Contents.get_selectedNode();  
              var menuItem = eventArgs.get_item();
              var contextDataNode = menuItem.get_parentMenu().get_contextData();
              switch (menuItem.get_value()) {
                  case 'add':
                      if (node) {
                          var span_addCollection_info;
                          span_addCollection_info = document.getElementById('span_addCollection_info');
                          top.OpenWindowTableOfContentsEditor(1, magDetailId);
                      }
                      else {
                          var span_info;
                          span_info = document.getElementById('span_info');
                          var span_toolbar_add_alert = document.getElementById('span_toolbar_add_alert');
                          top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_add_alert.innerHTML);
                      }
                      break;

                  case 'edit':
                      if (node) {
                          if (node) {
                              nodeId = node.get_id();
                          }
                          if (nodeId > 0) {
                              var span_editCollection_info;
                              span_editCollection_info = document.getElementById('span_editCollection_info');
                              top.OpenWindowTableOfContentsEditor(0, nodeId);
                          }
                          else {
                              var span_info;
                              span_info = document.getElementById('span_info');
                              var span_toolbar_edit_alert = document.getElementById('span_toolbar_edit_alert');
                              top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_edit_alert.innerHTML);
                          }
                      }
                      else {
                          var span_info;
                          span_info = document.getElementById('span_info');
                          var span_toolbar_add_alert = document.getElementById('span_toolbar_add_alert');
                          top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_add_alert.innerHTML);
                      }
                      break;
                  case 'delete':
                      if (node) {
                          nodeId = node.get_id();
                          if (nodeId > 0) {
                              remove_Tableofcontent();
                          }
                          else {
                              var span_info;
                              span_info = document.getElementById('span_info');
                              var span_toolbar_edit_alert = document.getElementById('span_toolbar_edit_alert');
                              top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_edit_alert.innerHTML);
                          }
                      }
                      else {
                          var span_info;
                          span_info = document.getElementById('span_info');
                          var span_toolbar_add_alert = document.getElementById('span_toolbar_add_alert');
                          top.showDialogInfo('', true, 5, span_info.innerHTML, span_toolbar_add_alert.innerHTML);
                      }
                      break;
              }
          }
          else {
              var span_info;
              span_info = document.getElementById('span_info');
              var span_choose_doc = document.getElementById('span_choose_doc');
              top.showDialogInfo('', true, 5, span_info.innerHTML, span_choose_doc.innerHTML);
          }
          return true;
      }
      //var sports = ["a": { x: 0, y: 0, w: 0.05, h: 0.05, text: "a" }];
      
      /*var annotations = {
          "a": { x: 0, y: 0, w: 0.05, h: 0.05, text: "a" },
          "b": { x: 0.03, y: 0.1, w: 0.05, h: 0.05, text: "b" }
      };*/

      var annotations = {};
      //var annotations = {};
      //annotations.push(sports);

      function showData() {
          var hidMagFilePath = document.getElementById('hidMagFilePath');
          magFile = hidMagFilePath.value;
          var hidMagPage = document.getElementById('hidMagPage');
          magPage = hidMagPage.value;
          var hidMagPageCount = document.getElementById('hidMagPageCount');
          magPageCounts = hidMagPageCount.value;
          var hidIIPServer = document.getElementById('hidIIPServer');
          magServer = hidIIPServer.value;

          iipmooviewer = new IIPMooViewer("viewer", {
              server: magServer,
              image: magFile,
              credit: magTitle,
              navigation: {
                  draggable: true,
                  buttons: ['zoomIn', 'zoomOut', 'reset', 'rotateLeft', 'rotateRight']
              },
              showCoords: true
	            , viewport: { resolution: 5, x: 0.5, y: 0.5, rotation: 0 }
              //,scale: 18.0
              , annotations: annotations
          });

          iipmooviewer.addEvent('annotationChange', function (action, annotation_id) {
              var data = { id: annotation_id, action: action };
              // `action` is either `updated` or `deleted`
              var hidMagDetailId = document.getElementById('hidMagDetailId');
              magDetailId = hidMagDetailId.value;
              if (action == 'updated') {
                  // If the annotation has been updated, send the updated data.
                  data.annotation = JSON.encode(this.annotations[annotation_id]);
                  var jsonData = data.annotation;
                  var jData = JSON.parse(jsonData);
                  var valReturn = 0;
                  valReturn = UpdateAnnotation(magDetailId, annotation_id, jData.x, jData.y, jData.w, jData.h, jData.title, jData.text);
                  
                  /*
                  if (valReturn == 1) {
                  alert("okay");
                  }
                  else {
                  alert("fails");
                  }
                  */
              }
              else {
                  var valReturn = 0;
                  valReturn = DeleteAnnotation(magDetailId, annotation_id);
                  //alert(valReturn);

                  /*if (valReturn == 1) {
                  alert(magDetailId + '  ' + annotation_id);
                  }
                  else {
                  alert("fails");
                  }*/
              }
          });
      }

      function viewData() {
          var hidMagDetailId = document.getElementById('hidMagDetailId');
          magDetailId = hidMagDetailId.value;
          getAnnotations(magDetailId);          
          
      }

      function newAnnotation() {
          iipmooviewer.newAnnotation();
      }

      function getAnnotations(magId) {
          var serviceURL = "eService.asmx/getAnnotation";
          var str = '';
          var jAnnotations = {};
          var element = Object();
          var jqxhrAnnotation = jQuery.ajax({ url: serviceURL,
              type: "GET",
              contentType: "application/json; charset=utf-8",
              data: { magId: magId
              },
              dataType: "json",
              success: function (json) {
                  if (json.length > 0) {
                      for (i = 0; i < json.length; i++) {
                          element = new Object();
                          element.x = json[i].coordinatesX;
                          element.y = json[i].coordinatesY;
                          element.w = json[i].aWidth;
                          element.h = json[i].aHeight;
                          element.text = json[i].lnk;
                          element.title = json[i].title;
                          jAnnotations[json[i].aId] = element;
                      }
                  }
                  else {
                  }
              },
              error: function () {
              }
          });

          jqxhrAnnotation.complete(function () {
              annotations = jAnnotations;
              showData();
          });
      }

      function ShowhideWindows() {
          iipmooviewer.toggleNavigationWindow(); 
       }

  </script>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
 </head>
 <body  oncontextmenu="CancelContextMenu(event);" onload="viewData()">		
 <form id="form1" runat="server">
    <div id="divTableOfContent">
        <div class="bgbody">
            <ComponentArt:ToolBar ID="ToolBarTableOfContents"
            ImagesBaseUrl="~/Resources/Skin/arcticwhite/Toolbar/images/FooterControls/"
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
                <ComponentArt:ToolBarItem ID="ToolBarItem1" runat="server" Text=""    Value="addbookmark"    ImageUrl="bookma-new.png" />
                    <ComponentArt:ToolBarItem ItemType="Separator" Width="1"/>
                    <ComponentArt:ToolBarItem ID="ToolBarItem2" runat="server"  Text=""  Value="editbookmark"  ImageUrl="bookmark-edit.png" />
                    <ComponentArt:ToolBarItem ItemType="Separator" Width="1"/>
                    <ComponentArt:ToolBarItem ID="ToolBarItem3" runat="server"  Text=""  Value="deletebookmark"  ImageUrl="bookmark-delete.png" />
             </Items>
            </ComponentArt:ToolBar>
         </div>  
         <div id="TreeContainer" class="TreeContainer">
            <ComponentArt:CallBack ID="CallbackTreeview" runat="server">
            <clientevents>
	            <load eventhandler="AjaxCallBack_onLoad" />
            </clientevents>
            <Content>
                <ComponentArt:TreeView id="TreeViewCollection_Table_Of_Contents" Width="100%"
                    AutoScroll="true"
                    FillContainer="true"
                    HoverPopupEnabled="true"
                    HoverPopupNodeCssClass="HoverPopup"
                    DragAndDropEnabled="true" 
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
                    ImagesBaseUrl="~/Resources/Skin/arcticwhite/Treeview/images/"
                    NodeLabelPadding="3"
                    ShowLines="true" 
                    LineImagesFolderUrl="~/Resources/Skin/arcticwhite/Treeview/images/lines/"
                    CollapseNodeOnSelect="false"
                    EnableViewState="false"
                    runat="server" >
                    <ClientEvents>
                        <Load EventHandler="TreeViewCollection_onLoad" />
                        <NodeSelect EventHandler="TreeViewCollection_onNodeSelect" />
                        <ContextMenu EventHandler="TreeViewCollection_onContextMenu" />
                    </ClientEvents>
                    </ComponentArt:TreeView> 
            </Content>
            </ComponentArt:CallBack>

            <ComponentArt:CallBack id="MenuCallBack" runat="server" >
                <ClientEvents>
                <CallbackComplete EventHandler="MenuCallBack_onCallbackComplete" />                            
                <load eventhandler="AjaxCallBack_onLoad" />
                </ClientEvents>
                <Content>
                <ComponentArt:Menu id="MenuCollection" 
                    Orientation="Vertical"
                    DefaultGroupCssClass="TopMenu_Group"
                    DefaultItemLookID="DefaultItemLook"
                    DefaultGroupItemSpacing="0"
                    DefaultItemHeight="22"
                    TopGroupExpandDirection="BelowLeft"
                    ImagesBaseUrl="../../../Resources/Skin/arcticwhite/Menu/images/"
                    EnableViewState="false"
                    ExpandDelay="100"
                    ExpandDuration="0"
                    ExpandSlideType="None"
                    ContextMenu="Custom"
                    runat="server">
                    <ClientEvents>
                    <ItemSelect EventHandler="MenuCollection_onItemSelect" />
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
                                    <td><img alt="" src="../../../images/spinner.gif" width="16" height="16" border="0"/></td>
                                    </tr>
                                </table>      
                            </td>
                    </tr>
                </table>
                </LoadingPanelClientTemplate>
            </ComponentArt:CallBack>  
        </div>
    </div>

	<div id="viewer">				
	</div>
	<div class="footer">
        <div class="footer-wrap">
		  <!-- <div class="ie-logo"></div> -->	
          <div id="divPage"><a href="javascript:gotoPrevious()"><img src="../../../Resources/Skin/arcticwhite/Arrows/Arrow-Left.png" class="img" /></a>&nbsp;<span id="pageInfo" runat="server"></span>&nbsp;<a href="javascript:gotoNext()"><img src="../../../Resources/Skin/arcticwhite/Arrows/Arrow-Right.png"  class="img"/></a></div>
          <div id="divAnnotation"><a href="javascript:newAnnotation()"><img src="images/magazine/hotspot.png" class="img" alt="Thêm liên kết trang" title="Thêm liên kết trang" /></a></div>
          <div id="divShowhideW"><a href="javascript:ShowhideWindows()"><img src="images/magazine/ShowhideW.png" class="img" alt="Ẩn/hiện cửa sổ chuyển hướng" title="Ẩn/hiện cửa sổ chuyển hướng" /></a></div>
          <div class="view-control-tabs">			
			<a id="lnkAllPages" href="#popupAllpages" data-rel="popup" data-position-to="window" data-wrapperels="span"  aria-haspopup="true" aria-owns="popupAllpages" aria-expanded="false">
	            <div class="grid"></div>			
			</a>
          </div>
        </div>
      </div>

    <div data-role="popup" id="popupAllpages" data-overlay-theme="a" data-theme="d" data-tolerance="15,15" class="ui-content">
	    <a href="#" data-rel="back" data-role="button" data-theme="a" data-icon="delete" data-iconpos="notext" class="ui-btn-right">Close</a>
	    <iframe src="AcqMagazineShowAllPages.aspx?MagId=<%=Request("MagId")%>" width="400" height="200" seamless></iframe>		 
    </div> 

     <div style="position:absolute;top:0px;left:0px;visibility:hidden;">
        <span  id="span_treeview_new_Tableofcontent" runat="server">Thêm mới Mục lục</span>
        <span  id="span_treeview_edit_Tableofcontent" runat="server">Sửa Mục lục</span>
        <span  id="span_treeview_delete_Tableofcontent" runat="server">Xóa Mục lục</span>
        <span  id="span_treeview_root_Tableofcontent" runat="server">Mục lục</span>
        <input id="hidIIPServer" type="hidden" value="" runat="server" /> 
        <input id="hidMagId" type="hidden" value="0" runat="server" />       
        <input id="hidMagDetailId" type="hidden" value="0" runat="server" />       
        <input id="hidMagFilePath" type="hidden" value="" runat="server" /> 
        <input id="hidMagPage" type="hidden" value="1" runat="server" /> 
        <input id="hidMagPageCount" type="hidden" value="1" runat="server" /> 
        <span id="span_addCollection_info" runat="server">Thêm mục lục</span>
        <span id="span_editCollection_info" runat="server">Sửa mục lục</span>
        <span  id="span_info" runat="server">Thông báo!; Đóng</span>
        <span  id="span_toolbar_add_alert" runat="server">Xin vui lòng chọn mục trong cây Mục lục...</span>
        <span  id="span_toolbar_edit_alert" runat="server">Không thể xóa/sửa Mục lục này...</span>
        <span  id="span_choose_doc" runat="server">Xin vui lòng chọn dữ liệu điện tử để tạo mục lục...</span>
        <span  id="span_cancel_para1" runat="server">Cảnh báo!; Chấp nhận ; Không chấp nhận</span>
        <span  id="span_treeivew_Tableofcontent_duplicate_rename" runat="server">Mục lục này đã tồn tại. Sửa Mục lục không thành công.</span>
        <span  id="span_treeivew_delete_Tableofcontent" runat="server">Bạn có chắc chắn muốn xóa Mục lục này không?</span>
        <span  id="span_treeivew_delete_Tableofcontent_fail1" runat="server">Lỗi xóa Mục lục. Xóa Mục lục không thành công.</span>
        <span  id="span_treeivew_delete_Tableofcontent_fail2" runat="server">Xin vui lòng xóa Mục lục con trước khi xóa Mục lục này .Xóa Mục lục không thành công.</span>
        <span  id="span_treeivew_delete_Tableofcontent_fail3" runat="server">Mục lục đang gắn với biểu ghi biên mục .Xóa Mục lục không thành công.</span>
        <span  id="span_treeivew_update_Tableofcontent" runat="server">Lỗi chuyển mục lục. Chuyển mục lục không thành công.</span>
        <span  id="span_warning_next_page" runat="server">Bạn đang ở trang cuối.</span>
        <span  id="span_warning_previous_page" runat="server">Bạn đang ở trang đầu.</span>
        <span  id="span_page" runat="server">Trang</span>
     </div>
 </body>
</form>
</html>
