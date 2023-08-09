<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqMagRegisterNumber.aspx.vb" Inherits="eMicLibAdmin.WebUI.Serial.Pages_AcqMagRegisterNumber" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">        
    <telerik:RadCodeBlock ID="RadCodeBlock2" runat="server">
    <script language="JavaScript" type="text/javascript" src="../../js/upload.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../js/Public.js"></script>
    <link href="../../Images/ComponentArt/Menu/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/Treeview/style.css" type="text/css" rel="StyleSheet"/>
    <link href="../../Images/ComponentArt/Splitter/Style.css" rel="stylesheet" type="text/css" />   
    <link href="../../Images/ComponentArt/Grid/style.css" type="text/css" rel="stylesheet" />
    <link href="../../Images/ComponentArt/Tabstrip/style.css" type="text/css" rel="stylesheet" />
     <link href="../../Images/ComponentArt/Upload/style.css" type="text/css" rel="stylesheet" />
  <script language="JavaScript">
  <!--
    var addfiles = 0;
  
    function formatYear() {
        var currentYear = document.getElementById('indYear_masked').value;
        document.getElementById('indYear_masked').value = currentYear.replace(",", "");
        console.log(document.getElementById('indYear_masked'));
        document.getElementById("indYear_masked").addEventListener("change", changeYear);
        document.getElementById("indYear_masked").addEventListener("keydown", changeYear);
        document.getElementById("indYear_masked").addEventListener("keyup", changeYear);
        document.getElementById("indYear_masked").addEventListener("keypress", changeYear);
        document.getElementById("indYear_masked").addEventListener("click", changeYear);
        document.getElementById("indYear_masked").addEventListener("blur", changeYear); 
        document.getElementById("indYear_masked").addEventListener("focus", changeYear);
    }

    setTimeout(formatYear, 200);
 


    function changeYear() {
        console.log("sss");
        setTimeout(function() {
            var x = document.getElementById("indYear_masked");
            x.value = x.value.replace(",", "");;
        }, 100);
      
    }
    function rename_folder(name) {
        var node = TreeViewInputAcquisition.get_selectedNode();
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
                    var txtfilePath;
                    txtfilePath = document.getElementById('txtfilePath');
                    txtfilePath.value = newNodeId;
                    UploadFiles.set_callbackParameter(txtfilePath.value);
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
        var node = TreeViewInputAcquisition.get_selectedNode();
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
        TreeViewInputAcquisition.beginUpdate();
        var newNode = new ComponentArt.Web.UI.TreeViewNode();
        newNode.set_text(name);
        newNode.set_imageUrl('folder-open.png');
        newNode.set_id(nid);
        TreeViewInputAcquisition.findNodeById(pid.get_id()).get_nodes().add(newNode);
        TreeViewInputAcquisition.endUpdate();
        pid.expand(true);
        top.closeDialog('Dialog_content');
    }

    function remove_folder() {
        console.log(1);
        var node = TreeViewInputAcquisition.get_selectedNode();
        if (node) {
            var span_cancel_para1;
            span_cancel_para1 = document.getElementById('span_cancel_para1');
            var span_treeivew_delete_info;
            span_treeivew_delete_info = document.getElementById('span_treeivew_delete_info');
            var r = confirm("Bạn có chắc chắn muốn xóa thư mục này không?");
            if (r == true) {
                delete_folder();
            } 
        }
    }


    function delete_folder() {
        var node = TreeViewInputAcquisition.get_selectedNode();
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
                    var txtfilePath;
                    txtfilePath = document.getElementById('txtfilePath');
                    txtfilePath.value = node.get_parentNode().get_id();
                    UploadFiles.set_callbackParameter(txtfilePath.value);
                }
            }
        }
    }


    function TreeViewInputAcquisition_onContextMenu(sender, eventArgs) {
        MenuInputAcquisition.showContextMenuAtEvent(eventArgs.get_event(), eventArgs.get_node());
    }


    function MenuInputAcquisition_onItemSelect(sender, eventArgs) {
        var menuItem = eventArgs.get_item();
        var contextDataNode = menuItem.get_parentMenu().get_contextData();
        switch (menuItem.get_value()) {
            case 'add':
                var span_addfolder_info;
                span_addfolder_info = document.getElementById('span_addfolder_info');
                top.showDialogContent('Serial/Acquisition/AcqMagazineAddFolderFrame.aspx?addnew=1', true, span_addfolder_info.innerHTML, parseInt(window.screen.availWidth / 3), parseInt(window.screen.availHeight / 3));
                break;
            case 'edit':
                var span_addfolder_info;
                span_addfolder_info = document.getElementById('span_addfolder_info');
                top.showDialogContent('Serial/Acquisition/AcqMagazineAddFolderFrame.aspx', true, span_addfolder_info.innerHTML, parseInt(window.screen.availWidth / 3), parseInt(window.screen.availHeight / 3));
                break;
            case 'delete':
                remove_folder();
                break;
        }

        return true;
    }

    // Handles the TreeView node select event
    function TreeViewInputAcquisition_onNodeSelect(sender, eventArgs) {
        var txtfilePath;
        txtfilePath = document.getElementById('txtfilePath');
        txtfilePath.value = eventArgs.get_node().get_id();
        UploadFiles.set_callbackParameter(txtfilePath.value);
    }


    // Handles the TreeView load event 
    function TreeViewInputAcquisition_onLoad(sender, eventArgs) {
        //TreeViewInputAcquisition.SelectNodeById('n1');
    }


    function CheckSubmit(key) {
        switch (key) {
            case 'close':
                //top.main.document.location.href = "AcqAcquisition.aspx";
                top.onClientCloseRadWindows();
                break;
            case 'update':
                var raiseAddRecord;
                raiseAddRecord = document.getElementById('raiseAddRecord');
                raiseAddRecord.click();
                break;
        }
    }

    function callbackParent(val, title, info, icon) {
        top.showDialogInfo('', true, icon, title, info);
        top.onClientCloseRadWindows();
        top.main.Workform.maincontent.RegisterMagazine_refresh(val);
    }


    function removeUpload(id) {
        var hidRemovefileID = document.getElementById('hidRemovefileID');
        hidRemovefileID.value = id;
        //if is firefox alert(id);
        var raiseRemoveFile = document.getElementById('raiseRemoveFile');
        raiseRemoveFile.click();
    }
    function removeFileUpload(id) {
        var span_cancel_para1;
        span_cancel_para1 = document.getElementById('span_cancel_para1');
        var span_Info_upload_removefiles;
        span_Info_upload_removefiles = document.getElementById('span_Info_upload_removefiles');
        var raiseFunc = 'removeUpload(' + String(id) + ') ;' + 'callbackMagazine';
        removeUpload(id);
        //top.showDialogConfirmInfo(raiseFunc, true, 3, span_cancel_para1.innerHTML, span_Info_upload_removefiles.innerHTML, true);
    }
    function dialogclose(dialog) {
        var raiseDisplayUpload = document.getElementById('raiseDisplayUpload');
        raiseDisplayUpload.click();
    }

    function chooseEbookDictionany() {
        addfiles = 0;
        var iHeight = getHeightByBrowse();
        var iWidth = getWidthByBrowse();
        var WindowEbooksDirectory = $find("<%= WindowEbooksDirectory.ClientID %>");
          WindowEbooksDirectory.set_navigateUrl('<%=Page.ResolveUrl("~/Serial/Acquisition/AcqDisplayChooseFilesFrame.aspx") %>');
          WindowEbooksDirectory.setSize(iWidth, iHeight);
          WindowEbooksDirectory.show();
      }

      function chooseAddfiles(val) {
          addfiles = val;
      }

      function onClientClose(oWnd, args) {
          if (addfiles) {
              var raiseDisplayUpload = document.getElementById('raiseDisplayUpload');
              raiseDisplayUpload.click();
          }
      }

      function onClientCloseRadWindows() {
          var WindowEbooksDirectory = $find("<%= WindowEbooksDirectory.ClientID %>");
            WindowEbooksDirectory.close(null);
        }

        //-->
  </script>
  </telerik:RadCodeBlock>
        <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body  class="backgroundbodywhite" style="margin-top:0;margin-left:0;margin-right:0;margin-bottom:0" oncontextmenu="CancelContextMenu(event);">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" />
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server"></telerik:RadStyleSheetManager>
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"></telerik:RadAjaxManager>
        <asp:UpdatePanel id="upnInput" runat="server" UpdateMode="Conditional">
            <ContentTemplate>        
                <table id="table2" width="100%" border="0" cellspacing="1" cellpadding="1" bgcolor="white">
                <tr>
                    <td width="32px" align="right"><img src="../../Resources/Skin/arcticwhite/Icon/Acquisition/Add.png"  style="border:none;display:block;vertical-align:top;" width="32px" height="32px"/>
                    </td>
                    <td align="left"><asp:label id="lblRowTitle" CssClass="titlerowtextread" Runat="server">Đăng ký số dữ liệu điện tử</asp:label>
                    </td>
                </tr>
                </table>
                <table id="tblParent" cellpadding="0" cellspacing="0" width="80%" border="0" align="center">
                <tr>
                    <td style="width:100%;">
                        <ComponentArt:TabStrip id="TabStripInputAcquisition"
                          CssClass="TopGroupWithIcon"
                          SiteMapXmlFile="../../Resources/Skin/arcticwhite/Tabstrip/AcqMagRegisterNumber_vie.xml"
                          DefaultItemLookId="DefaultTabLook"
                          DefaultSelectedItemLookId="SelectedTabLook"
                          DefaultGroupTabSpacing="1"
                          ImagesBaseUrl="../../Resources/Skin/arcticwhite/Tabstrip/images/InputAcquisition/"
                          MultiPageId="MultiPageInputAcquisition"
                          Width="100%"
                          runat="server">
                        <ItemLooks>
                          <ComponentArt:ItemLook LookId="DefaultTabLook" CssClass="DefaultTabWithIcon" HoverCssClass="DefaultTabHoverWithIcon" LabelPaddingLeft="1" LabelPaddingRight="15" LabelPaddingTop="5" LabelPaddingBottom="4" LeftIconWidth="25" LeftIconHeight="25" />
                          <ComponentArt:ItemLook LookId="SelectedTabLook" CssClass="SelectedTabWithIcon" LabelPaddingLeft="1" LabelPaddingRight="15" LabelPaddingTop="5" LabelPaddingBottom="4" LeftIconWidth="25" LeftIconHeight="25" />
                        </ItemLooks>
                        </ComponentArt:TabStrip>

                        <ComponentArt:MultiPage id="MultiPageInputAcquisition" CssClass="MultiPageWithIcon" runat="server">                           
                          <ComponentArt:PageView ID="PageView12" CssClass="PageContentWithIcon" runat="server">
                             <table id="table3" width="100%" border="0" cellspacing="3" cellpadding="3" bgcolor="white">
                                <tr>
                                    <td align="left" style="width:7%">
                                        <asp:label id="Label2" CssClass="lbllabel" Runat="server">Năm</asp:label>
                                    </td>
                                    <td  align="left"  style="width:93%">
                                        <ComponentArt:NumberInput runat="server"
                                            ID="indYear"
                                            CssClass="valid"
                                            EmptyCssClass="empty"
                                            FocusedValidCssClass="focused-valid"
                                            FocusedCssClass="focused"
                                            InvalidCssClass="invalid"
                                            DisabledCssClass="disabled"
                                            Width="70px"
                                            NumberType="Number"
                                            Value="0"
                                            DecimalDigits="0" 
                                            MinValue="1900" 
                                            MaxLength="4" 
                                            MaxValue="3000"  
                                            ClientScriptLocation="formatYear"
                                            Increment="1">                                       
                                         </ComponentArt:NumberInput>
                                    </td>
                                </tr>             
                                 <tr>
                                    <td align="left" style="width:7%">
                                        <asp:label id="lbldocType" CssClass="lbllabel" Runat="server">Tháng</asp:label>
                                    </td>
                                    <td  align="left"  style="width:93%">
                                        <ComponentArt:NumberInput runat="server"
                                            ID="indMonth"
                                            CssClass="valid"
                                            EmptyCssClass="empty"
                                            FocusedValidCssClass="focused-valid"
                                            FocusedCssClass="focused"
                                            InvalidCssClass="invalid"
                                            DisabledCssClass="disabled"
                                            Width="70px"
                                            NumberType="Number"
                                            Value="0"
                                            DecimalDigits="0"
                                            Increment="1"
                                            MaxLength="2">                                         
                                         </ComponentArt:NumberInput>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width:7%">
                                        <asp:label id="lblstatus" CssClass="lbllabel" Runat="server">Ngày</asp:label>
                                    </td>
                                    <td  align="left"  style="width:93%">
                                        <ComponentArt:NumberInput runat="server"
                                            ID="indDay"
                                            CssClass="valid"
                                            EmptyCssClass="empty"
                                            FocusedValidCssClass="focused-valid"
                                            FocusedCssClass="focused"
                                            InvalidCssClass="invalid"
                                            DisabledCssClass="disabled"
                                            Width="70px"
                                            NumberType="Number"
                                            Value="0"
                                            DecimalDigits="0"
                                            Increment="1"
                                            MaxLength="2">                                           
                                         </ComponentArt:NumberInput>
                                    </td>
                                </tr>                                    
                                <tr>
                                    <td align="left" style="width:7%">
                                        <asp:label id="Label1" CssClass="lbllabel" Runat="server">Số</asp:label>
                                    </td>
                                    <td  align="left"  style="width:93%">
                                        <div class="fieldlogin"> 
                                        <ComponentArt:MaskedInput runat="server"
                                            ID="txtNumber"
                                            Text=""        
                                            EmptyText=""        
                                            CssClass="valid"
                                            EmptyCssClass="required"
                                            FocusedValidCssClass="focused-valid"
                                            FocusedCssClass="focused"
                                            InvalidCssClass="invalid"
                                            DisabledCssClass="disabled"        
                                            />
                                        </div>
                                    </td>
                                </tr>             
                                <tr>
                                    <td align="left" style="width:7%">
                                        <asp:label id="Label3" CssClass="lbllabel" Runat="server">Mô tả</asp:label>
                                    </td>
                                    <td  align="left"  style="width:93%">
                                        <asp:TextBox id="txtDecription" runat="server" Width="400px"></asp:TextBox>
                                    </td>
                                </tr>    
                             </table>
                          </ComponentArt:PageView>
                          <ComponentArt:PageView ID="PageView3" CssClass="PageContentWithIcon" runat="server">
                          <table id="table6" width="100%" border="0" cellspacing="3" cellpadding="3" bgcolor="white">
                          <tr>
                            <td style="width:30%" valign="top">
                                <table id="table7" width="100%" border="0" cellspacing="1" cellpadding="1" bgcolor="white">                                   
                                    <tr>
                                        <td colspan="2">
                                            <div class="sel">
		                                            <ComponentArt:Upload
			                                            ID="UploadFiles"
			                                            RunAt="server"
			                                            MaximumFileCount="100"
			                                            AutoPostBack="false"
			                                            FileInputClientTemplateId="FileInputTemplate"
			                                            UploadCompleteClientTemplateId="CompletedTemplate"
			                                            FileInputImageUrl="../../Resources/Skin/arcticwhite/upload/images/_browse.png"
			                                            FileInputHoverImageUrl="../../Resources/Skin/arcticwhite/upload/images/_browse-h.png"
			                                            ProgressClientTemplateId="ProgressTemplate"
			                                            TempFileFolder = "../../Upload"
			                                            ProgressDomElementId="upload-progress">
			                                            <ClientEvents>
				                                            <FileChange EventHandler="file_change" />
				                                            <UploadBegin EventHandler="upload_begin" />
				                                            <UploadEnd EventHandler="upload_end" />
			                                            </ClientEvents>

			                                            <ClientTemplates>
				                                            <ComponentArt:ClientTemplate ID="FileInputTemplate">
					                                            <div class="file">
						                                            <div class="## DataItem.FileName ? "filename" : "filename empty"; ##"><input value="## DataItem.FileName ? DataItem.FileName : "Vui lòng chọn tệp để tải lên"; ##" onfocus="this.blur();" /></div>
						                                            <a href="javascript:void(0);" onclick="this.blur();return false;" class="browse" title="Chọn tệp">#$FileInputImage</a>
						                                            <a href="javascript:void(0);" onclick="remove_file(## Parent.Id ##,## DataItem.FileIndex ##);return false;" class="remove" title="Hủy tệp"></a>
					                                            </div>
				                                            </ComponentArt:ClientTemplate>

				                                            <ComponentArt:ClientTemplate ID="ProgressTemplate">
					                                            <!-- Dialogue contents -->
					                                            <div class="con">
						                                            <div class="stat">
							                                            <h3 rel="total"><span id="span_upload_total_process">Tổng tiến trình thực hiện:</span></h3>
							                                            <div class="prog">
								                                            <div class="con">
									                                            <div class="bar" style="width:## get_percentage(DataItem.Progress) ##%;"></div>
								                                            </div>
							                                            </div>
							                                            <div class="lbl" style="text-align:right;"><strong>## format_file_size(DataItem.ReceivedBytes) ##</strong> <span id="span_upload_uploading_of1">của</span> <strong>## format_file_size(DataItem.TotalBytes) ##</strong> (## get_percentage(DataItem.Progress) ##%) <span id="span_upload_uploaded">Đã tải lên</span></div>
						                                            </div>

						                                            <div class="list">
							                                            <h3><span id="span_upload_uploading">Đang tải tệp lên</span><span style="font-size:11px;">(<strong>## get_file_position(Parent,DataItem.CurrentFile) ##</strong> <span id="span_upload_uploading_of2">của</span> <strong>## Parent.GetFiles().length ##</strong>):</span></h3>
							                                            <div class="files">## generate_file_list(Parent,DataItem.CurrentFile); ##</div>
						                                            </div>
					                                            </div>
					                                            <!-- /Dialogue contents -->

					                                            <!-- Dialogue footer -->
					                                            <div class="ftr">
						                                            <div class="ftr-l"></div>
						                                            <div class="ftr-m">
							                                            <div class="info">
								                                            <span id="span_upload_elapsed">T/gian trôi qua: <strong>## format_time(DataItem.ElapsedTime); ##</strong></span>
								                                            <span style="padding-left:8px;" id="span_upload_estimated">T/gian ước lượng: <strong>## format_time(DataItem.ElapsedTime + DataItem.RemainingTime); ##</strong></span>
								                                            <span style="padding-left:8px;" id="span_upload_speed">Tốc độ: <strong>## DataItem.Speed.toFixed(2) ## KB/S</strong></span>
							                                            </div>
							                                            <div class="btns">
								                                            <a onclick="Parent.abort();return false;" href="javascript:void(0);" rel="cancel">
									                                            <span class="l"></span>
									                                            <span class="m" id="btn1" id="span_upload_cancel">Hủy tải lên</span>
									                                            <span class="r"></span>
								                                            </a>
							                                            </div>
						                                            </div>
						                                            <div class="ftr-r"></div>
					                                            </div>
					                                            <!-- /Dialogue footer -->
				                                            </ComponentArt:ClientTemplate>

				                                            <ComponentArt:ClientTemplate ID="CompletedTemplate">
					                                            <!-- Dialogue contents -->
					                                            <div class="con">
						                                            <div class="stat">
							                                            <h3 style="text-align:center;" class="red">&mdash; <span id="span_upload_complete">Tải tệp lên hoàn thành</span> &mdash;</h3>
							                                            <div class="prog">
								                                            <div class="con">
									                                            <div class="bar" style="width:## get_percentage(DataItem.Progress) ##%;"></div>
								                                            </div>
							                                            </div>
							                                            <div class="lbl" style="text-align:right;"><strong>## format_file_size(DataItem.ReceivedBytes) ##</strong> of <strong>## format_file_size(DataItem.TotalBytes) ##</strong> (## get_percentage(DataItem.Progress) ##%) <span id="span_upload_percent">Đã tải lên</span></div>
						                                            </div>

						                                            <div class="list">
							                                            <h3><strong>## Parent.GetFiles().length ##</strong> ## (Parent.GetFiles().length > 1) ? "tệp" : "tệp" ## <span id="span_upload_uploded3">tải lên trong</span> <strong>## format_time(DataItem.ElapsedTime,true); ##</strong>:</h3>
							                                            <div class="files">## generate_file_list(Parent,DataItem.CurrentFile); ##</div>
						                                            </div>
					                                            </div>
					                                            <!-- /Dialogue contents -->

					                                            <!-- Dialogue footer -->
					                                            <div class="ftr">
						                                            <div class="ftr-l"></div>
						                                            <div class="ftr-m">
							                                            <div class="btns">
								                                            <a onclick="UploadDialog.close();return false;" href="javascript:void(0);" rel="cancel">
									                                            <span class="l"></span>
									                                            <span class="m" style="padding-left:6px;padding-right:6px;"  id="span_upload_close">Đóng</span>
									                                            <span class="r"></span>
								                                            </a>
							                                            </div>
						                                            </div>
						                                            <div class="ftr-r"></div>
					                                            </div>
					                                            <!-- /Dialogue footer -->
				                                            </ComponentArt:ClientTemplate>
			                                            </ClientTemplates>
		                                            </ComponentArt:Upload>
	                                            </div>
	                                            <div class="actions" rel="UploadFiles">
		                                            <a href="javascript:void(0);" onclick="add_file(UploadFiles,this);this.blur();return false;" class="add" id="btn-add"></a>
		                                            <a href="javascript:void(0);" onclick="init_upload(UploadFiles);this.blur();return false;" class="upload-d" id="btn-upload"></a>
	                                            </div>
                                        				
                                                <ComponentArt:Dialog
                                                    ID="UploadDialog"
                                                    RunAt="server"
                                                    AllowDrag="true"
                                                    AllowResize="false"
                                                    Modal="false"
                                                    Alignment="MiddleCentre"
                                                    Width="458"
                                                    Height="247"
                                                    ContentCssClass="dlg-up"
                                                    ContentClientTemplateId="UploadContent">
                                                     <ClientEvents>
                                                        <OnClose EventHandler="dialogclose" />                    
                                                      </ClientEvents>
                                                    <ClientTemplates>
	                                                    <ComponentArt:ClientTemplate id="UploadContent">
		                                                    <div class="ttl" onmousedown="UploadDialog.StartDrag(event);">
			                                                    <div class="ttlt">
				                                                    <div class="ttlt-l"></div>
				                                                    <div class="ttlt-m">
					                                                    <a class="close" href="javascript:void(0);" onclick="UploadDialog.close();return false;"></a>
					                                                    <span id="span_upload">Tải lên</span>
				                                                    </div>
				                                                    <div class="ttlt-r"></div>
			                                                    </div>

			                                                    <div class="ttlb">
				                                                    <div class="ttlb-l"></div>
				                                                    <div class="ttlb-m"></div>
				                                                    <div class="ttlb-r"></div>
			                                                    </div>
		                                                    </div>

		                                                    <!-- for contents & footer, see upload progress client template -->
		                                                    <div id="upload-progress"></div>
	                                                    </ComponentArt:ClientTemplate>
                                                    </ClientTemplates>
                                                </ComponentArt:Dialog>
                                              </div>  
                                        </td>
                                    </tr>
                                </table>                              
                                
                            </td>
                            <td  style="width:70%" valign="top">
                                <table id="table1" width="100%" border="0" cellspacing="3" cellpadding="3" bgcolor="white">                                
                                <tr>
                                    <td align="left" style="width:20%">
                                        <asp:label id="lblSavefile" CssClass="lbllabel" Runat="server">Thư mục lưu file</asp:label>
                                    </td>
                                    <td  align="left"  style="width:80%">
                                        <asp:TextBox ID="txtfilePath" runat="server" Text="" Width="99%" onfocus="this.blur();return false;" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2"   style="width:100%">
                                         <ComponentArt:TreeView id="TreeViewInputAcquisition" Width="99%" 
                                            AutoScroll="true"
                                            FillContainer="false"
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
                                            ImagesBaseUrl="../../Resources/Skin/arcticwhite/Treeview/images/"
                                            NodeLabelPadding="3"
                                            ParentNodeImageUrl="folder.png" 
                                            LeafNodeImageUrl="folder-open.png" 
                                            ShowLines="true" 
                                            LineImagesFolderUrl="../../Resources/Skin/arcticwhite/Treeview/images/lines/"
                                            CollapseNodeOnSelect="false"
                                            EnableViewState="false"
                                            runat="server">
                                            <ClientEvents>
                                              <Load EventHandler="TreeViewInputAcquisition_onLoad" />
                                              <NodeSelect EventHandler="TreeViewInputAcquisition_onNodeSelect" />
                                              <ContextMenu EventHandler="TreeViewInputAcquisition_onContextMenu" />
                                            </ClientEvents>
                                          </ComponentArt:TreeView>                                
                                                               
                                        <ComponentArt:Menu id="MenuInputAcquisition"
                                          Orientation="Vertical"
                                          DefaultGroupCssClass="MenuGroupInputAcquisition"                                  
                                          DefaultItemLookID="ItemLookInputAcquisition"
                                          DefaultGroupItemSpacing="1"
                                          ImagesBaseUrl="../../Resources/Skin/arcticwhite/Menu/images/"
                                          EnableViewState="false"
                                          ContextMenu="Custom"
                                          ShadowEnabled="true"
                                          runat="server">
                                        <ClientEvents>
                                          <ItemSelect EventHandler="MenuInputAcquisition_onItemSelect" />
                                        </ClientEvents>
                                        <ItemLooks>
                                           <ComponentArt:ItemLook LookID="ItemLookInputAcquisition" CssClass="MenuItemInputAcquisition" HoverCssClass="MenuItemHoverInputAcquisition" ExpandedCssClass="MenuItemHoverInputAcquisition" LeftIconWidth="20" LeftIconHeight="18" LabelPaddingLeft="10" LabelPaddingRight="10" LabelPaddingTop="3" LabelPaddingBottom="4" />
                                            <ComponentArt:ItemLook LookID="BreakItem" CssClass="MenuBreakInputAcquisition" />
                                        </ItemLooks>
                                        <Items>
                                            <ComponentArt:MenuItem ID="MenuItem1" runat="server" Text="New folder" Value="add" Look-LeftIconUrl ="folder_add.png" Look-HoverLeftIconUrl="folder_add.png"></ComponentArt:MenuItem>
                                            <ComponentArt:MenuItem ID="MenuItem2" runat="server" Text="Edit folder" Value="edit" Look-LeftIconUrl ="folder-remote.png" Look-HoverLeftIconUrl=""></ComponentArt:MenuItem>
                                            <ComponentArt:MenuItem ID="MenuItem3" runat="server" Text="Delete folder" Value="delete" Look-LeftIconUrl ="folder_remove.png" Look-HoverLeftIconUrl=""></ComponentArt:MenuItem>
                                        </Items>
                                        </ComponentArt:Menu>
                                    </td>
                                </tr>
                                </table>   
                            </td>
                          </tr>
                          <tr>
                              <td style="width:100%" colspan="2">
                                <asp:Literal ID="litinfoUpload" runat="server" Text=""></asp:Literal>
                              </td>
                          </tr>
                         <%-- <tr>
                            <td style="width:100%" colspan="2">
                                <input type="button" id="btchooseEbookDictionary" value="Bổ sung thêm tài liệu" onclick="chooseEbookDictionany();" />
                            </td>
                          </tr>--%>
                          </table>                                
                          </ComponentArt:PageView>                          
                        </ComponentArt:MultiPage>
                    </td>
                </tr>
                </table>                 
            </ContentTemplate>
        </asp:UpdatePanel>        
        <div style="display:none">
            <input id="hidRemovefileID" type="hidden" value="-1" runat="server" />
            <span  id="span_info" runat="server">Thông báo!; Đóng</span>
            <span  id="span_cancel_para1" runat="server">Cảnh báo!; Chấp nhận ; Không chấp nhận</span>
            <span  id="span_cancel_para2" runat="server">Bạn có chắc chắn muốn hủy thông tin không?</span>
            <span  id="span_addfolder_info" runat="server"></span>
            <span  id="span_menu_loading" runat="server">Đang nạp dữ liệu...</span>
            <span  id="span_save_file" runat="server">Đường dẫn</span>
            <span  id="span_Menu_item1" runat="server">Tạo mới thư mục</span>
            <span  id="span_Menu_item2" runat="server">Đổi tên thư mục</span>
            <span  id="span_Menu_item3" runat="server">Xóa thư mục</span>
            <span  id="span_treeview_root" runat="server">Quản lý tư liệu điện tử</span>
            <span  id="span_treeivew_delete_info" runat="server">Bạn có chắc chắn muốn xóa thư mục này không?</span>
            <span  id="span_treeivew_rename" runat="server">Thư mục này là không rỗng. Đổi tên thư mục này không thành công.</span>
            <span  id="span_treeivew_rename_duplicate" runat="server">Thư mục này đã tồn tại. Đổi tên thư mục này không thành công.</span>
            <span  id="span_treeivew_addnew_duplicate" runat="server">Thư mục này đã tồn tại. Thêm mới thư mục không thành công.</span>
            <span  id="span_treeivew_delete" runat="server">Thư mục là không rỗng. Xóa thư mục không thành công.</span>
            <span  id="span_info_uploadfiles" runat="server">Các tệp đã được tải lên</span>
            <span  id="span_upload_removefiles" runat="server">Hủy</span>
            <span  id="span_Info_upload_removefiles" runat="server">Bạn có chắc chắn muốn hủy tệp này không?</span>
            <span  id="span_addnew_invalid1" runat="server">Xin vui lòng nhập giá trị vào trường số.</span>
            <span  id="span_addnew_invalid2" runat="server">Đường dẫn thư mục lưu file không hợp lệ.</span>
            <span  id="span_addnew_invalid3" runat="server">xin vui lòng chọn tệp và tải lên.</span>
            <span  id="span_addnew_invalid4" runat="server">Đăng ký số trùng lặp.</span>
            <span  id="span_addnew" runat="server">Cập nhật biểu ghi dữ liệu điện tử thành công.</span>
            <asp:Button runat="server" ID="raiseAddRecord"  Text="raiseAddRecord" CausesValidation="false"/>
            <asp:Button runat="server" ID="raiseDisplayUpload"  Text="raiseDisplayUpload" CausesValidation="false"/>
            <asp:Button runat="server" ID="raiseRemoveFile"  Text="raiseRemoveFile" CausesValidation="false"/>      
            <telerik:RadWindow runat="server" Width="800px" Height="500px" VisibleStatusbar="False"
                ID="WindowEbooksDirectory" Modal="True" Behavior="Close, Move" InitialBehavior="None" IconUrl="/Skin/arcticwhite/Toolbar/images/FooterControls/folderDisplay.png" Title="Chọn dữ liệu điện tử" ReloadOnShow="false" Animation="Resize" OnClientClose="onClientClose" >
            </telerik:RadWindow>
            <span  id="span_txtNumber_info" runat="server">Số là rỗng...</span>    
            <input id="hidAddNew" type="hidden" value="0" runat="server" />        
            <input id="hidOldNum" type="hidden" value="" runat="server" /> 
            <input id="hidDocId" type="hidden" value="0" runat="server" />        
            <input id="hidMagId" type="hidden" value="0" runat="server" />       
            <span  id="span_error" runat="server">Lỗi hệ thống.Cập nhật biểu ghi dữ liệu điện tử không thành công.</span> 
        </div>                  
    </form>
</body>
</html>