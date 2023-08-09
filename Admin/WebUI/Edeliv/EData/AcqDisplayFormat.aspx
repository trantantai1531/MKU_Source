<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqDisplayFormat.aspx.vb" Inherits="eMicLibAdmin.WebUI.Edeliv.Pages_AcqDisplayformat" %>
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

        function AjaxCallBack_onLoad(sender, e) 
        { 
        }   
        
        function viewRecord(id){
            var span_preview;
            span_preview = document.getElementById('span_preview');
            top.showDialogContent('Edeliv/EData/AcqPreviewFrame.aspx?id=' + String(id), true, span_preview.innerHTML, 120, 80);
        }

      // Handles the Grid double-click event 
      function Gridformat_onItemDoubleClick(sender, eventArgs)
      {
          var item = eventArgs.get_item();
          if (item != null) {
              if (item.Cells[13].get_value()==-1){
                    TreeViewformat.selectNodeById(item.Cells[6].get_value());
              }
              else
              {
                var fileName = item.Cells[9].get_value();
                SetFileNameSession(fileName);
                top.MLFooter.location.href='AcqSaveFile.aspx?bol=1&FileName=' + fileName;
              }
          }
      }

        
      // Handles the TreeView node select event 
      function TreeViewformat_onNodeSelect(sender, eventArgs)
      { 
        if (contextData_grid_load){
            GridCallBack.callback(eventArgs.get_node().get_id()); 
        }
      }

      // Handles the TreeView load event 
      function TreeViewformat_onLoad(sender, eventArgs)
      { 
        TreeViewformat.SelectNodeById('n1');
      }

      // Overrides the default Grid client-side sort mechanism, 
      // ensuring that formats are grouped together 
      function Gridformat_onSortChange(sender, eventArgs)
      {
        var grid = sender;
        var isDesc = eventArgs.get_descending();
        var column = eventArgs.get_column();

        // multiple sort, giving the top priority to IsFolder
        grid.sortMulti([5,!isDesc,column.ColumnNumber,isDesc]);

        // cancel default sort
        eventArgs.set_cancel(true);
      }

      
      // Context menu global variables for grid    
      var contextData_grid_load = true; 

      // Forces the treeview to adjust to the new size of its container          
      function resizeTree(sender, eventArgs) {
              var iUnit;
              iUnit = 8;
            var pane = eventArgs.get_pane();
            var newPaneWidth = pane.get_width();
            var newPaneHeight = pane.get_height();
            if (window.TreeViewformat && newPaneWidth && newPaneWidth > 2 && newPaneHeight && newPaneHeight > 11)
            {
              document.getElementById("TreeContainer").style.width = (newPaneWidth - 2) + 'px';
              //document.getElementById("TreeContainer").style.height = (newPaneHeight - iUnit) + 'px';
              document.getElementById("TreeContainer").style.height = viewerHeight + 'px';
              TreeViewformat.render();
            }
        }    
      
      function GridCallBack_onBeforeCallback(sender, e){
          try {
            Gridformat.dispose();
        }
        catch (err) {
            //alert('GridCallBack_onBeforeCallback' + err.message);
        }  
      }

      // Forces the grid to adjust to the new size of its container          
      function resizeGrid(sender, eventArgs) {
          var iUnit;
          iUnit = 2;
        var pane = eventArgs.get_pane();
        var newPaneWidth = pane.get_width();
        var newPaneHeight = pane.get_height();
        if(window.Gridformat && window.GridCallBack && newPaneWidth && newPaneWidth > 2 && newPaneHeight && newPaneHeight > 2)
        {
            GridCallBack.element.style.width = (newPaneWidth - 2) + 'px';
            //GridCallBack.element.style.height = (newPaneHeight - iUnit) + 'px';
            GridCallBack.element.style.height = viewerHeight + 'px';
            Gridformat.render();
        }
      }  
      
      function CheckSubmit(key) {
          switch (key) {
              case 'close':
                  top.MLContent.main.document.location.href = "AcqAcquisition.aspx";
                  break;
          }
      }
          
       function Expandformat() {
          var obj;
          obj = '<%=Session("formatId")%>';
          if (obj != '') {
              contextData_grid_load =false;
              TreeViewformat.selectNodeById(obj);
              contextData_grid_load = true;
          }
      }
      
    </script>
</head>
<body oncontextmenu="CancelContextMenu(event);" onload="Expandformat();">
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server"  /> 
       <table width="1000" border="0" cellpadding="0" cellspacing="0">
            <tr> 
              <td valign="top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="bgmain">
                  <tr> 
                     <td valign="top">
                           <ComponentArt:Splitter runat="server" id="Splitterformat"  Height="1600px" FillWidth="true" ImagesBaseUrl="../../Images/ComponentArt/Splitter/Images/">
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
                                  <div class="HeadingCell" style="font-family: verdana; font-size: 10px; font-weight:bold;padding-top:3px;padding-bottom:5px; height: 16px;cursor:default;"><span id="span_format" runat="server">Định dạng</span> </div>
                                  <ComponentArt:TreeView id="TreeViewformat" Width="100%" 
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
                                    ParentNodeImageUrl="folder_blue_open.png" 
                                    LeafNodeImageUrl="folder_blue_open.png" 
                                    ShowLines="true" 
                                    LineImagesFolderUrl="../../Images/ComponentArt/Treeview/images/lines/"
                                    CollapseNodeOnSelect="false"
                                    EnableViewState="true"
                                    runat="server" >
                                    <ClientEvents>
                                      <Load EventHandler="TreeViewformat_onLoad" />
                                      <NodeSelect EventHandler="TreeViewformat_onNodeSelect" />
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
                                  <ComponentArt:Grid id="Gridformat"
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
                                    SliderPopupClientTemplateId="SliderTemplate"
                                    PagerInfoClientTemplateId="MyPager"
                                    GroupBySortAscendingImageUrl="group_asc.gif"
                                    GroupBySortDescendingImageUrl="group_desc.gif"
                                    GroupBySortImageWidth="10"
                                    GroupBySortImageHeight="10"
                                    IndentCellWidth="22"
                                    Width="100%" Height="100%" runat="server">
                                    <ClientEvents>
                                      <ItemDoubleClick EventHandler="Gridformat_onItemDoubleClick" />
                                      <SortChange EventHandler="Gridformat_onSortChange" />
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
                                          <ComponentArt:GridColumn DataField="Icon" AllowEditing="True" Visible="false"/>
                                          <ComponentArt:GridColumn DataField="Name" DataCellClientTemplateId="FirstColumnTemplate" HeadingText="&nbsp;&nbsp;Tên tệp" SortImageJustify="false" DefaultSortDirection="Descending" />
                                          <ComponentArt:GridColumn DataField="Size" DataCellClientTemplateId="SizeColumnTemplate" Align="Right" SortImageJustify="true" HeadingText="Kích thước&nbsp;&nbsp;" DefaultSortDirection="Descending"/>
                                          <ComponentArt:GridColumn DataField="Type" SortImageJustify="false"  HeadingText="&nbsp;&nbsp;Kiểu tệp" DefaultSortDirection="Descending"/>
                                          <ComponentArt:GridColumn DataField="DateModified" FormatString="dd/MM/yyyy hh:mm tt" SortImageJustify="false" HeadingText="&nbsp;&nbsp;Ngày nhập" DefaultSortDirection="Descending"/>
                                          <ComponentArt:GridColumn DataField="IsFolder" Align="Center" HeadingText= "&nbsp;"  ColumnType="CheckBox"  DataCellClientTemplateId="chkTemplate"  DataType="System.Boolean" Width="20"  AllowReordering="False"  AllowGrouping="False" AllowSorting="False"  Visible="false"/> 
                                          <ComponentArt:GridColumn DataField="Value" Visible="false" />
                                          <ComponentArt:GridColumn DataField="Extension" Visible="false" />
                                          <ComponentArt:GridColumn DataField="SizeString" Visible="false" />
                                          <ComponentArt:GridColumn DataField="FullPath" Visible="false" />
                                          <ComponentArt:GridColumn DataField="id" Visible="false" />
                                          <ComponentArt:GridColumn DataField="SercretLevel" HeadingText="&nbsp;&nbsp;Mức độ mật" DataCellClientTemplateId="SercretLevelColumnTemplate" Width="40" DefaultSortDirection="Descending"/>
                                          <ComponentArt:GridColumn DataField="DownloadTimes" HeadingText="&nbsp;&nbsp;Số lần tải về" DataCellClientTemplateId="DownloadTimesColumnTemplate" Width="40" DefaultSortDirection="Descending"/>
                                          <ComponentArt:GridColumn DataField="DocID" HeadingText="&nbsp;&nbsp;Thông tin biên mục" DataCellClientTemplateId="DocIDColumnTemplate" Width="40" DefaultSortDirection="Descending"/>
                                          <ComponentArt:GridColumn DataField="Charge" HeadingText="&nbsp;&nbsp;Truy cập" DataCellClientTemplateId="ChargeColumnTemplate" Width="40" DefaultSortDirection="Descending"/>
                                          <ComponentArt:GridColumn DataField="statusid" Visible="false" />
                                          <ComponentArt:GridColumn DataField="status" HeadingText="&nbsp;&nbsp;Định dạng" DataCellClientTemplateId="statusColumnTemplate" Width="0" DefaultSortDirection="Descending"  Visible="false"/>
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
                                               <input type="checkbox" id="chkAllC##DataItem.GetMember('id').Value##" ## DataItem.GetMember('IsFolder').Value ? '' : '' ## ## (DataItem.GetMember('IsFolder').Value) || (DataItem.GetMember('DocID').Value > 0) ? 'disabled' : '' ## value='##DataItem.GetMember('FullPath').Value##' />
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
			                            Trang <b>## DataItem.PageIndex + 1 ##</b> của <b>## Gridformat.PageCount ##</b>
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
                                                
                                        var currentPageIndex = (Gridformat == null) ? 0 : Gridformat.get_currentPageIndex();
                                        var pageCount = (Gridformat == null) ? 0 : Gridformat.get_pageCount();
                                        var recordCount = (Gridformat == null) ? 0 : Gridformat.get_recordCount();

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
            <span id="span_grid_item" runat="server">mục</span> 
            <span id="span_grid_nodata" runat="server">Không có dữ liệu</span> 
            <span id="span_grid_page" runat="server">Trang</span>
            <span id="Span_grid_of" runat="server">của</span>
            <span  id="span_info" runat="server">Thông báo!; Đóng</span>
            <span  id="span_treeview_root_format" runat="server">Định dạng</span>
        </div>      
   </form>
</body>
</html>
