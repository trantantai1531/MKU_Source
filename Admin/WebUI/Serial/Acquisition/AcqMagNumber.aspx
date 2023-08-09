<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqMagNumber.aspx.vb" Inherits="eMicLibAdmin.WebUI.Serial.Page_AcqMagNumber" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="head1" runat="server">    
    <script language="JavaScript" type="text/javascript" src="../../js/Public.js"></script>
    <link href="../../Images/ComponentArt/Menu/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/Treeview/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/Splitter/Style.css" rel="stylesheet" type="text/css" />   
    <link href="../../Images/ComponentArt/Grid/style.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript">
        var intMagId = 0;
        var intDocId = 0;
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

        function tableOfContents(id) {
            intMagId = id;
            if (intDocId == 0) {
                var span_info;
                span_info = document.getElementById('span_info');
                var span_document_choose;
                span_document_choose = document.getElementById('span_document_choose');
                top.showDialogInfo('', true, 5, span_info.innerHTML, span_document_choose.innerHTML);                
            }
            else {
                OpenWindowTableOfContents(intMagId);
            }
        }
        function modifyRecord(id) {
            intMagId = id;
            if (intDocId == 0) {
                var span_info;
                span_info = document.getElementById('span_info');
                var span_document_choose;
                span_document_choose = document.getElementById('span_document_choose');
                top.showDialogInfo('', true, 5, span_info.innerHTML, span_document_choose.innerHTML);
                top.closeDialog('Dialog_content');
            }
            else {
                OpenWindowRegisterNum(0, intDocId, intMagId);
            }
        }
        function deleteRecord(id) {
            intMagId = id;
            var span_cancel_para1;
            span_cancel_para1 = document.getElementById('span_cancel_para1');
            var span_delete_magazine_number;
            span_delete_magazine_number = document.getElementById('span_delete_magazine_number');
            top.showDialogConfirmInfo('delete_magazine_number(' + intMagId + ')' + 'callback', true, 3, span_cancel_para1.innerHTML, span_delete_magazine_number.innerHTML, true);            
        }
        function delete_magazine_number(id) {
            var bolDetele = callback_delete_magazine_number(id);
            if (bolDetele==1) {
                var span_info;
                span_info = document.getElementById('span_info');
                var span_delete_sucess;
                span_delete_sucess = document.getElementById('span_delete_sucess');
                top.showDialogInfo('', true, 6, span_info.innerHTML, span_delete_sucess.innerHTML);
                GridCallBack.callback(intDocId);
            }
            else {
                var span_info;
                span_info = document.getElementById('span_info');
                var span_delete_fail;
                span_delete_fail = document.getElementById('span_delete_fail');
                top.showDialogInfo('', true, 5, span_info.innerHTML, span_delete_fail.innerHTML);
            }            
        }
           

      // Handles the Grid double-click event 
      function GridFolder_onItemDoubleClick(sender, eventArgs)
      {
          
      }

        // Handles the TreeView node select event 
      function RegisterMagazine_refresh(val)
      { 
        GridCallBack.callback(val); 
      }
        
      // Handles the TreeView node select event 
      function TreeViewFolder_onNodeSelect(sender, eventArgs)
      { 
            intDocId = eventArgs.get_node().get_value();                        
            GridCallBack.callback(intDocId);                         
      }

      // Handles the TreeView load event 
      function TreeViewFolder_onLoad(sender, eventArgs)
      { 
        TreeViewFolder.SelectNodeById('0');
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
      var contextItem_grid_toc = 0; 

      // Loads the Grid context menu through an AJAX-style callback 
      function GridFolder_onContextMenu(sender, eventArgs) 
      {
        
        var item = eventArgs.get_item();
        GridFolder.select(item);
        
        contextData_DocID = item.getMember('MagId').get_value(); 
        
        SetupContextMenuCallbackContainerForMenuGrid(eventArgs.get_event());
        MenuGrid.set_contextData(eventArgs.get_item());
        contextData_grid = MenuGrid.get_contextData();


        // Set the global contextItem variable
        //contextItem = item.Cells[1].get_value(); 
        contextItem_grid = item.Cells[0].get_value();
        contextItem_grid_toc = item.Cells[1].get_value();

        // Load the menu from the server, given the file extension 
        MenuCallBackGrid.callback(item.Cells[0].get_value()); 
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
                  top.showDialogContent('Serial/Acquisition/AcqUploadFilesFrame.aspx?uploadPath=' + contextItem, true, span_addfolder_info.innerHTML, parseInt(window.screen.availWidth / 5), parseInt(window.screen.availHeight / 5));
                  break;
              case 'add':
                  var span_addfolder_info;
                  span_addfolder_info = document.getElementById('span_addfolder_info');
                  top.showDialogContent('Serial/Acquisition/AcqAddFolderFrame.aspx?addnew=1', true, span_addfolder_info.innerHTML, parseInt(window.screen.availWidth / 3), parseInt(window.screen.availHeight / 3));
                  break;
              case 'edit':
                  var span_addfolder_info;
                  span_addfolder_info = document.getElementById('span_addfolder_info');
                  top.showDialogContent('Serial/Acquisition/AcqAddFolderFrame.aspx', true, "", parseInt(window.screen.availWidth / 3), parseInt(window.screen.availHeight / 3));
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
              case 'add':                  
                  if (intDocId == 0) {
                      var span_info;
                      span_info = document.getElementById('span_info');
                      var span_document_choose;
                      span_document_choose = document.getElementById('span_document_choose');
                      top.showDialogInfo('', true, 5, span_info.innerHTML, span_document_choose.innerHTML);                      
                  }
                  else {
                      OpenWindowRegisterNum(1, intDocId, intMagId);
                  }
                  break;
              case 'edit':
                  intMagId = contextItem_grid;
                  if (intDocId == 0) {
                      var span_info;
                      span_info = document.getElementById('span_info');
                      var span_document_choose;
                      span_document_choose = document.getElementById('span_document_choose');
                      top.showDialogInfo('', true, 5, span_info.innerHTML, span_document_choose.innerHTML);                      
                  }
                  else {
                      OpenWindowRegisterNum(0, intDocId, intMagId);
                  }
                  break;
              case 'delete':
                  intMagId = contextItem_grid;
                  var span_cancel_para1;
                  span_cancel_para1 = document.getElementById('span_cancel_para1');
                  var span_delete_magazine_number;
                  span_delete_magazine_number = document.getElementById('span_delete_magazine_number');
                  top.showDialogConfirmInfo('delete_magazine_number(' + intMagId + ')' + 'callback', true, 3, span_cancel_para1.innerHTML, span_delete_magazine_number.innerHTML, true);
                  break;
              case 'tableOfContents':
                  intMagId = contextItem_grid;
                  if (intDocId == 0) {
                      var span_info;
                      span_info = document.getElementById('span_info');
                      var span_document_choose;
                      span_document_choose = document.getElementById('span_document_choose');
                      top.showDialogInfo('', true, 5, span_info.innerHTML, span_document_choose.innerHTML);
                  }
                  else {
                      if (contextItem_grid_toc == 0) {
                          var span_info;
                          span_info = document.getElementById('span_info');
                          var span_document_choose;
                          span_warning_toc = document.getElementById('span_warning_toc');
                          top.showDialogInfo('', true, 5, span_info.innerHTML, span_warning_toc.innerHTML);
                      }
                      else {
                          OpenWindowTableOfContents(intMagId);
                      }                      
                  }
                  break;            
          }

          return true;
      }
      
         
            
      function GridCallBack_onBeforeCallback(sender, e){              
      }

      // Forces the treeview to adjust to the new size of its container          
      function resizeTree(sender, eventArgs) {
          var iUnit;
          iUnit = -15;
        var pane = eventArgs.get_pane();
        var newPaneWidth = pane.get_width();
        var newPaneHeight = pane.get_height();
        if (window.TreeViewFolder && newPaneWidth && newPaneWidth > 2 && newPaneHeight && newPaneHeight > 11) {
            TreeContainer.style.width = (newPaneWidth - 2) + 'px';
            //TreeContainer.style.height = (newPaneHeight - iUnit - 200) + 'px';
            //document.getElementById("TreeContainer").style.width = (newPaneWidth - 2) + 'px';
            //document.getElementById("TreeContainer").style.height = (newPaneHeight - iUnit) + 'px';
            TreeContainer.style.height = viewerHeight + 'px';
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
        if(window.GridFolder && window.GridCallBack && newPaneWidth && newPaneWidth > 2 && newPaneHeight && newPaneHeight > 2)
        {
            GridCallBack.element.style.width = (newPaneWidth - 2) + 'px';
            //GridCallBack.element.style.height = (newPaneHeight - iUnit - 200) + 'px';
            GridCallBack.element.style.height = viewerHeight + 'px';
            GridFolder.render();
        }
      }

      function CheckSubmit(key) {
          switch (key) {
              case 'close':
                  top.main.Workform.document.location.href = "../WSerialQuickView.aspx";
                  break;
              case 'add':
                  if (intDocId==0){
                      var span_info;
                      span_info = document.getElementById('span_info');
                      var span_document_choose;
                      span_document_choose = document.getElementById('span_document_choose');
                      top.showDialogInfo('', true, 5, span_info.innerHTML, span_document_choose.innerHTML);
                      //top.closeDialog('Dialog_content');
                  }
                  else {
                      top.OpenWindowRegisterNum(1, intDocId, intMagId);
                  } 
                  break;          
                             
          }
      }

      function OpenWindowRegisterNum(add,DocId,MagId) {
          top.OpenWindowRegisterNum(add, DocId, MagId);
      }
      function OpenWindowTableOfContents(MagId) {
          top.OpenWindowTableOfContents(MagId);
      }
                         
    </script>    
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body oncontextmenu="CancelContextMenu(event);">
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
                                <div id="TreeContainer" class="TreeContainer">
                                  <div class="HeadingCell" style="font-family: verdana; font-size: 10px; font-weight:bold;padding-top:3px;padding-bottom:5px; height: 16px;cursor:default;"><span id="span_folder" runat="server">Danh mục tài liệu</span> </div>
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
                                    AutoAdjustPageSize="true"
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
                                    Sort="Name DESC, eYear DESC, eMonth DESC, eDay DESC,eNum DESC" 
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
                                        DataKeyField="MagId"
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
                                          <ComponentArt:GridColumn DataField="MagId" Visible="false" />
                                          <ComponentArt:GridColumn DataField="TocMagId" Visible="false" />
                                          <ComponentArt:GridColumn DataField="DocID" Visible="false" />
                                          <ComponentArt:GridColumn DataField="Name" DataCellClientTemplateId="TitleTemplate" HeadingText="&nbsp;&nbsp;Nhan đề" SortImageJustify="false" DefaultSortDirection="Descending" />
                                          <ComponentArt:GridColumn DataField="eYear" DataCellClientTemplateId="eYearTemplate" Align="Right" SortImageJustify="true" HeadingText="Năm&nbsp;&nbsp;" DefaultSortDirection="Descending"/>
                                          <ComponentArt:GridColumn DataField="eMonth" DataCellClientTemplateId="eMonthTemplate" Align="Right" SortImageJustify="true" HeadingText="Tháng&nbsp;&nbsp;" DefaultSortDirection="Descending"/>
                                          <ComponentArt:GridColumn DataField="eDay" DataCellClientTemplateId="eDayTemplate" Align="Right" SortImageJustify="true" HeadingText="Ngày&nbsp;&nbsp;" DefaultSortDirection="Descending"/>
                                          <ComponentArt:GridColumn DataField="eNum" DataCellClientTemplateId="eNumTemplate" Align="Right" SortImageJustify="true" HeadingText="Số&nbsp;&nbsp;" DefaultSortDirection="Descending"/>                                                                                   
                                          <ComponentArt:GridColumn DataField="MagId" HeadingText="&nbsp;&nbsp;Sửa số" DataCellClientTemplateId="ModifyColumnTemplate" Width="50" DefaultSortDirection="Descending"/>                                                                                    
                                          <ComponentArt:GridColumn DataField="MagId" HeadingText="&nbsp;&nbsp;Xóa số" DataCellClientTemplateId="DeleteColumnTemplate" Width="50" DefaultSortDirection="Descending"/>                                                                                    
                                          <ComponentArt:GridColumn DataField="TocMagId" HeadingText="&nbsp;&nbsp;Mục lục" DataCellClientTemplateId="TableOfContentTemplate" Width="50" DefaultSortDirection="Descending"/>
                                         </Columns>
                                      </ComponentArt:GridLevel>
                                    </Levels>
                                    <ClientTemplates>                                       
                                      <ComponentArt:ClientTemplate Id="TitleTemplate">
                                          <table cellspacing="1" cellpadding="1" border="0">
                                              <tr>                                                
                                                <td style="padding-left:2px;"><div style="font-size:10px;font-family: MS Sans Serif;text-overflow:ellipsis;overflow:hidden;"><nobr>## DataItem.GetMember("Name").Value ##</nobr></div></td>
                                              </tr>
                                          </table>
                                      </ComponentArt:ClientTemplate>
                                      <ComponentArt:ClientTemplate Id="eYearTemplate">
                                            ## DataItem.GetMember("eYear").Value ##
                                      </ComponentArt:ClientTemplate>
                                      <ComponentArt:ClientTemplate Id="eMonthTemplate">
                                            ## DataItem.GetMember("eMonth").Value ##
                                      </ComponentArt:ClientTemplate>
                                      <ComponentArt:ClientTemplate Id="eDayTemplate">
                                            ## DataItem.GetMember("eDay").Value ##
                                      </ComponentArt:ClientTemplate>
                                      <ComponentArt:ClientTemplate Id="eNumTemplate">
                                            ## DataItem.GetMember("eNum").Value ##
                                      </ComponentArt:ClientTemplate>
                                      <ComponentArt:ClientTemplate Id="ModifyColumnTemplate">              
                                              ## DataItem.GetMember('MagId').Value==-1 ? '' : '<img src="../../Images/ComponentArt/Toolbar/images/FooterControls/Modify.png" onclick="modifyRecord(' + DataItem.GetMember('MagId').Value + ');" height="20" width="20" style="cursor:pointer;" alt="Sửa số tài liệu điện tử" title="Sửa số tài liệu điện tử" />' ##
                                          </ComponentArt:ClientTemplate>
                                    <ComponentArt:ClientTemplate Id="DeleteColumnTemplate">              
                                              ## DataItem.GetMember('MagId').Value==-1 ? '' : '<img src="../../Images/ComponentArt/Toolbar/images/FooterControls/Delete.png" onclick="deleteRecord(' + DataItem.GetMember('MagId').Value + ');" height="20" width="20" style="cursor:pointer;" alt="Xóa số tài liệu điện tử" title="Xóa số tài liệu điện tử" />' ##
                                          </ComponentArt:ClientTemplate>
                                    <ComponentArt:ClientTemplate Id="TableOfContentTemplate">              
                                              ## DataItem.GetMember('TocMagId').Value==0 ? '' : '<img src="../../Images/ComponentArt/Toolbar/images/FooterControls/bookma-new.png" onclick="tableOfContents(' + DataItem.GetMember('TocMagId').Value + ');" height="20" width="20" style="cursor:pointer;" alt="Biên mục mục lục" title="Biên mục mục lục" />' ##
                                          </ComponentArt:ClientTemplate>
                                      <ComponentArt:ClientTemplate Id="ScrollPopupTemplate">
                                          <table cellspacing="0" cellpadding="2" border="0" class="ScrollPopup">
                                              <tr>                                                
                                                <td style="width:130px;"><div style="font-size:10px;font-family: MS Sans Serif;text-overflow:ellipsis;overflow:hidden;width:130px;"><nobr>## DataItem.GetMember("Name").Value ##</nobr></div></td>                                                
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
                              ImagesBaseUrl="../../Images/ComponentArt/Toolbar/images/FooterControls/"
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
            <ComponentArt:Menu id="MenuTemp" runat="server"></ComponentArt:Menu>
            <ComponentArt:Grid ID="gridTemp" runat="server"></ComponentArt:Grid>
            <ComponentArt:TreeView id="TreeviewTemp" Width="100%" runat="server" Visible="false"></ComponentArt:TreeView>
            <span  id="span_preview" runat="server"></span>
            <span id="span_addfolder_info" runat="server"></span>
            <span  id="span_treeview_new_folder" runat="server">Thêm mới thư mục</span>
            <span  id="span_treeview_edit_folder" runat="server">Đổi tên thư mục</span>
            <span  id="span_treeview_delete_folder" runat="server">Xóa thư mục</span>
            <span  id="span_treeview_upload" runat="server">Tải tệp lên</span>
            <span  id="span_grid_open" runat="server">Mở</span>
            <span id="span_grid_item" runat="server">mục</span> 
            <span id="span_grid_nodata" runat="server">Không có dữ liệu</span> 
            <span id="span_grid_page" runat="server">Trang</span>
            <span id="Span_grid_of" runat="server">của</span>
            <span  id="span_info" runat="server">Thông báo!; Đóng</span>
            <span  id="span_grid_check" runat="server">Xin vui lòng đánh dấu để chọn tệp biên mục...</span>
            <span  id="span_grid_check_delete" runat="server">Xin vui lòng đánh dấu để chọn tệp xóa...</span>
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
            <span  id="span_grid_delete_file" runat="server">Bạn có chắc chắn muốn xóa tệp này không?</span>
            <span  id="span_grid_delete_file_error1" runat="server">Đường dẫn tệp không tồn tại. Xóa tệp không thành công...</span>
            <span  id="span_grid_delete_file_error2" runat="server">Lỗi xóa tệp..... Xóa tệp không thành công...</span>
            <span  id="span_grid_delete_file_error3" runat="server">Tệp có gắn với biểu ghi biên mục. Xóa tệp không thành công.</span>
            
            <span  id="span_document_list" runat="server">Tài liệu</span>
            <span  id="span_document_choose" runat="server">Vui lòng chọn tài liệu từ danh mục tài liệu</span>
            <span  id="span_grid_add" runat="server">Thêm số</span>
            <span  id="span_grid_edit" runat="server">Sửa số</span>
            <span  id="span_grid_delete" runat="server">Xóa số</span>            
            <span  id="span_grid_tableOfContents" runat="server">Biên mục mục lục</span>
            <span  id="span_delete_magazine_number" runat="server">Bạn có chắc chắn muốn xóa số này không?</span>
            <span  id="span_delete_sucess" runat="server">Xóa số thành công</span>
            <span  id="span_delete_fail" runat="server">Lỗi xóa số</span>
            <span  id="span_warning_toc" runat="server">Số này chưa thể biên mục mục lục...</span>
        </div>      
   </form>
</body>
</html>
