<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqUploadFilesValue.aspx.vb" Inherits="eMicLibAdmin.WebUI.Edeliv.Pages_AcqUploadFilesValue" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">        
    <script language="JavaScript" type="text/javascript" src="../../js/upload.js"></script>
    <link href="../../Images/ComponentArt/Upload/style.css" type="text/css" rel="StyleSheet"/>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
  <script language="JavaScript">
  <!--
      function toggle_confirm_upload(obj, modal, icon, dialogtitle, dialogvalue) {
          if (Dialog_confirm_upload.get_isShowing()) {
              Dialog_confirm_upload.Close();
          }
          else {
              Dialog_confirm_upload.beginUpdate();
              Dialog_confirm_upload.set_value(dialogvalue);
              Dialog_confirm_upload.set_title(dialogtitle);

              Dialog_confirm_upload.set_showTransition(0);
              Dialog_confirm_upload.set_closeTransition(0);
              Dialog_confirm_upload.set_animationType('None');
              Dialog_confirm_upload.set_animationPath('Direct');

              Dialog_confirm_upload.set_modal(modal);

              arricon = new Array(9);
              arricon[0] = "pencil.png";
              arricon[1] = "arrow.gif";
              arricon[2] = "search.gif";
              arricon[3] = "x.png";
              arricon[4] = "Input.gif";
              arricon[5] = "Cancel.gif";
              arricon[6] = "Updated.png";
              arricon[7] = "Refresh.png";
              arricon[8] = "select_text.png";
              Dialog_confirm_upload.set_icon(arricon[icon]);
              Dialog_confirm_upload.set_x(null);
              Dialog_confirm_upload.set_y(null);
              Dialog_confirm_upload.endUpdate();

              Dialog_confirm_upload.contentUrl = obj;

              Dialog_confirm_upload.Show();
          }
      }

      function CheckSubmit(key) {
          switch (key) {
              case 'close':
                  top.closeDialog('Dialog_content');
                  var val = '<%=Replace(Request("uploadPath"),"\","\\")%>';
                  top.main.Workform.maincontent.TreeViewFolder_refresh(val);
                  break;
          }
      }
      function dialogconfirmclose(dialog) {
          if (dialog.get_result() == 'OK click') {
              var raiseRemoveFile = document.getElementById('raiseRemoveFile');
              raiseRemoveFile.click();
          }
          else {
              var hidRemovefileID = document.getElementById('hidRemovefileID');
              hidRemovefileID.value = -1;
          }
      }

      function dialogconfirmshow(dialog) {
          var infoTitle = document.getElementById("infoTitle");
          if (infoTitle != null) {
              infoTitle.innerHTML = GetValue(dialog.Title, 0);
          }
          var objyes = document.getElementById("buttonyes");
          if (objyes != null) {
              objyes.value = GetValue(dialog.Title, 1);
          }
          var objno = document.getElementById("buttonno");
          if (objno != null) {
              objno.value = GetValue(dialog.Title, 2);
              objno.focus();
          }
      }
      function GetValue(val, id) {
          var text;
          text = val.split(';');
          if (text[id] == undefined)
              return "???";
          else
              return text[id];
      }
      
      function dialogclose(dialog) {
          var raiseDisplayUpload = document.getElementById('raiseDisplayUpload');
          raiseDisplayUpload.click();
      }
      function removeFileUpload(id) {
          var span_cancel_para1;
          span_cancel_para1 = document.getElementById('span_cancel_para1');
          var span_Info_upload_removefiles;
          span_Info_upload_removefiles = document.getElementById('span_Info_upload_removefiles');
          var hidRemovefileID = document.getElementById('hidRemovefileID');
          hidRemovefileID.value = id;
          toggle_confirm_upload('', false, 3, span_cancel_para1.innerHTML, span_Info_upload_removefiles.innerHTML);
      }
  //-->
  </script>
</head>
<body  class="backgroundbodywhite" style="margin-top:0;margin-left:0;margin-right:0;margin-bottom:0">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" />
        <asp:UpdatePanel id="upnInput" runat="server" UpdateMode="Conditional">
            <ContentTemplate>        
                <table id="table2" width="100%" border="0" cellspacing="1" cellpadding="1" bgcolor="white"  align="center">
                <tr>
                    <td width="32px" align="right"><img src="../../Images/ComponentArt/Toolbar/images/FooterControls/upload128.png"  style="border:none;display:block;vertical-align:top;" width="32px" height="32px"/>
                    </td>
                    <td align="left"><asp:label id="lblRowTitle" CssClass="titlerowtextread" Runat="server">Tải tệp lên...</asp:label>
                    </td>
                </tr>
                </table>
                </table>
                <table id="table6" width="100%" border="0" cellspacing="3" cellpadding="3" bgcolor="white" align="center">
                      <tr>
                        <td style="width:100%" valign="top" align="center">
                            <div class="sel">
		                        <ComponentArt:Upload
			                        ID="UploadFiles"
			                        RunAt="server"
			                        MaximumFileCount="100"
			                        AutoPostBack="false"
			                        FileInputClientTemplateId="FileInputTemplate"
			                        UploadCompleteClientTemplateId="CompletedTemplate"
			                        FileInputImageUrl="../../Images/ComponentArt/upload/images/_browse.png"
			                        FileInputHoverImageUrl="../../Images/ComponentArt/upload/images/_browse-h.png"
			                        ProgressClientTemplateId="ProgressTemplate" 
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
		                        <a href="javascript:void(0);" onclick="init_upload_Edata(UploadFiles);this.blur();return false;" class="upload-d" id="btn-upload"></a>
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
                        </td>
                   </tr>
                   <tr>
                      <td style="width:100%">
                        <asp:Literal ID="litinfoUpload" runat="server" Text=""></asp:Literal>
                      </td>
                  </tr>
                  <tr>
                    <td>
                      <ComponentArt:Dialog  ModalMaskImage="../../Images/ComponentArt/Dialog/images/alpha.png" AnimationDuration="600" HeaderCssClass="headerCss" Icon="pencil.gif"  Value="Dialog Content" HeaderClientTemplateId="header" Title="ComponentArt Dialog" ContentClientTemplateId="content" FooterClientTemplateId="footer" AllowDrag="true" Alignment="MiddleCentre"  ID="Dialog_confirm_upload" runat="server" Height="151" Width="458" contentUrl="">
                      <ClientEvents>
                        <OnShow EventHandler="dialogconfirmshow" />
                        <OnClose EventHandler="dialogconfirmclose" />                                                
                      </ClientEvents>
                        <ClientTemplates>
	                        <ComponentArt:ClientTemplate id="header">
		                        <table style="filter:alpha(opacity=60);" cellpadding="0" cellspacing="0" border="0" width="458" height="35" onmousedown="Dialog_confirm_upload.StartDrag(event);">
			                        <tr>
				                        <td width="9" height="35" style="background-image:url(../../Images/ComponentArt/Dialog/images/top-left.png);"></td>
				                        <td height="35" style="background-image:url(../../Images/ComponentArt/Dialog/images/top-mid.png);height:35px !important;" valign="middle" width="409">
					                        <span style="color:White;font-size:15px;font-family:Arial;font-weight:bold;" id ="infoTitle">## Parent.Title ##</span>
				                        </td>
				                        <td width="40" height="35" valign="top" style="background-image:url(../../Images/ComponentArt/Dialog/images/top-right.png);">
					                        <img src="../../Images/ComponentArt/Dialog/images/close.png" style="cursor:default;padding-top:4px;" width="32" height="25"  onmousedown="this.src='../../Images/ComponentArt/Dialog/images/close-down.png';" onmouseup="this.src='../../Images/ComponentArt/Dialog/images/close-hover.png';" onclick="Dialog_confirm_upload.Close('Close click');" onmouseover="this.src='../../Images/ComponentArt/Dialog/images/close-hover.png';" onmouseout="this.src='../../Images/ComponentArt/Dialog/images/close.png';"/>
				                        </td>
			                        </tr>
		                        </table>
	                        </ComponentArt:ClientTemplate>

	                        <ComponentArt:ClientTemplate id="content">
	                            <table cellpadding="0" cellspacing="0" width="458">
			                        <tr>
				                        <td style="background-image:url(../../Images/ComponentArt/Dialog/images/left.png);filter:alpha(opacity=60);" width="7"></td>
				                        <td style="background-color:white;font-size:12px;font-family:Arial;">
				                            <table width="100%" cellpadding="0" cellspacing="0">
				                                <tr>
				                                    <td valign="middle" style="padding:10px;width:30px;"><img src="../../Images/ComponentArt/Dialog/icons/## Parent.Icon ##" style="padding:5px;"/></td>
				                                    <td style="padding:5px;" align="left" valign="middle">## Parent.Value ##</td>
				                                </tr>
		                                        <tr>
		                                            <td colspan="2" style="background-image:url(../../Images/ComponentArt/Dialog/images/bottom_content.gif);height:41px;padding-right:10px;" align="right">
		                                            <input type="button"  id="buttonyes" onclick='Dialog_confirm_upload.Close("OK click");' class="btn" value="&nbsp;Yes&nbsp;" />&nbsp;&nbsp;<input class="btn" type='button' onclick='Dialog_confirm_upload.Close("Cancel click");' value='&nbsp;No&nbsp;' id="buttonno" />
		                                           </td>
						                        </tr>
					                        </table>
				                        </td>
				                        <td style="background-image:url(../../Images/ComponentArt/Dialog/images/right.png);filter:alpha(opacity=60);" width="7"></td>
			                        </tr>				
		                        </table>
									                        </ComponentArt:ClientTemplate>
                    													
	                        <ComponentArt:ClientTemplate id="footer">
		                        <table cellpadding="0" cellspacing="0" width="458" height="7" style="filter:alpha(opacity=60);">
			                        <tr>
				                        <td width="9" height="7"><img style="display:block;" src="../../Images/ComponentArt/Dialog/images/bottom-left.png"/></td>
				                        <td style="background-image:url(../../Images/ComponentArt/Dialog/images/bottom-mid.png);" width="440"></td>
				                        <td width="9" height="7"><img style="display:block;" src="../../Images/ComponentArt/Dialog/images/bottom-right.png"/></td>
			                        </tr>
		                        </table>
	                        </ComponentArt:ClientTemplate>
                        </ClientTemplates>
                       </ComponentArt:Dialog>
                    </td>
                  </tr>
              </table>   
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="display:none">   
            <input id="hidRemovefileID" type="hidden" value="-1" runat="server" />
            <span  id="span_input" runat="server">Nhập bộ sưu tập</span>
            <span  id="span_info" runat="server">Thông báo; Đóng</span>
            <span  id="span_addnew_invalid2" runat="server">Đường dẫn thư mục lưu file không hợp lệ.</span>
            <span  id="span_addnew_invalid3" runat="server">xin vui lòng chọn tệp và tải lên.</span>
            <span  id="span_info_uploadfiles" runat="server">Các tệp đã được tải lên</span>
            <span  id="span_upload_removefiles" runat="server">Hủy</span>
            <span  id="span_cancel_para1" runat="server">Cảnh báo!; Chấp nhận ; Không chấp nhận</span>
            <span  id="span_Info_upload_removefiles" runat="server">Bạn có chắc chắn muốn hủy tệp này không?</span>
            <asp:Button runat="server" ID="raiseDisplayUpload"  Text="raiseDisplayUpload" CausesValidation="false"/>     
            <asp:Button runat="server" ID="raiseRemoveFile"  Text="raiseRemoveFile" CausesValidation="false"/>     
        </div>                  
    </form>
</body>
</html>
