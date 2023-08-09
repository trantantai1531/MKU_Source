<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqUploadToolkit.aspx.vb" Inherits="eMicLibAdmin.WebUI.Catalogue.Pages_AcqUploadToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">   
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
<script language="JavaScript">
  <!-- 
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
          if (contentType.indexOf('image')>=0) {
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
                  //d = '0' + d;
              }
              var m = (curdate.getMonth() + 1).toString();
              if (m.toString().length < 2) {
                  //m = '0' + m;
              }
              var y = curdate.getFullYear();            
              var folder;
              folder = y.toString() + '/' + m.toString() + '/'+ d.toString();

              filename = callbackChangeFileName(filename);

              var MyImageCover = document.getElementById('MyImageCover');
              MyImageCover.src = "../../Upload/ImageCover/" + folder + "/" + filename;
          }
          else {
              var span_info;
              span_info = document.getElementById('span_info');
              var span_file_error;
              span_file_error = document.getElementById('span_file_error');
              //top.showDialogInfo('', true, 5, span_info.innerHTML, span_file_error.innerHTML);
              alert(span_file_error.innerHTML);              
          }
      }

      function remove_image() {
          DeleteImageCover();  
          /*var span_cancel_para;
          span_cancel_para = document.getElementById('span_cancel_para');
          var span_image_delete_info;
          span_image_delete_info = document.getElementById('span_image_delete_info');
          top.showDialogConfirmInfo('DeleteImageCover()' + 'callback', true, 3, span_cancel_para.innerHTML, span_image_delete_info.innerHTML, true);*/
      }

      function DeleteImageCover() {
          var valReturn;
          valReturn = Delete_Image_Cover();
          if (valReturn) {
              var MyImageCover = document.getElementById('MyImageCover');
              MyImageCover.src = "../../Upload/ImageCover/emiclibBlank.jpg";
          }
      }
      
       //-->
  </script>    
</head>
<body style="margin-top:0;margin-left:0;margin-right:0;margin-bottom:0;background-color:White;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server" />
        <table id="table8" width="100%" height="100%" border="0" cellspacing="3" cellpadding="3" bgcolor="white">                                
            <tr>
                <td align="left" style="width:15%">
                    <asp:label id="lbl" CssClass="lbllabel" Runat="server">Tải tệp tin</asp:label>
                </td>
                <td  align="left"  style="width:85%">
                    <cc1:AsyncFileUpload ID="AsyncFileUpload1" runat="server" 
                        OnClientUploadError="uploadError" 
                        OnClientUploadStarted="StartUpload"
                        OnClientUploadComplete="UploadComplete"
                        CompleteBackColor="Lime" UploaderStyle="Traditional"
                        ErrorBackColor="Red" 
                        Width="350px"
                        ThrobberID="Throbber" 
                        onuploadedcomplete="AsyncFileUpload1_UploadedComplete" 
                        UploadingBackColor="#66CCFF" /> <asp:Label ID="Throbber" runat="server" Style="display: none">
                            <img src="../../Images/spinner.gif" align="absmiddle" alt="loading" />
                        </asp:Label>
                        <br />
                        <asp:Label ID="lblstatusUploadCover" runat="server" Style="font-family: Arial; font-size: small;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <img runat="server" id="MyImageCover" src="../../Upload/ImageCover/emiclibBlank.jpg"  style ="width:160px;height:210px;" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <a href="javascript:void(0);" onclick="remove_image();"><asp:Label runat="server" id="lnkDelete" Text="Xóa" Visible="true" /></a>
                </td>
            </tr>            
          </table>
          <div style="display:none">
                <span  id="span_start_upload" runat="server">Tải dữ liệu bắt đầu</span>
                <span  id="span_finish_upload" runat="server">Tải dữ liệu đã hoàn thành</span>
                <span  id="span_info" runat="server">Thông báo!; Đóng</span>
                <span  id="span_file_error" runat="server">Xin vui lòng chọn tệp hình ảnh...</span>
                <span  id="span_cancel_para" runat="server">Cảnh báo!; Chấp nhận ; Không chấp nhận</span>
                <span  id="span_image_delete_info" runat="server">Bạn có chắc chắn muốn xóa ảnh bìa này không?</span>                
          </div>
    </form>
</body>
</html>
