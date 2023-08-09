<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Dialog_alert.ascx.vb" Inherits="Controls_Common_Dialog_alert" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<script type="text/javascript">
     function dialogshow(dialog) {
         var DialogTitle;
         DialogTitle = document.getElementById("DialogTitle");
         if (DialogTitle != null) {
             DialogTitle.innerHTML = GetValue(dialog.Title, 0);
         }
        var obj ;
        obj = document.getElementById("buttonclose");
        if (obj != null)
        {
            obj.focus();
            obj.value = GetValue(dialog.Title,1);
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
        //alert(top.frames.length);
//        if (Dialog.contentUrl != '')
//            top.MLContent.main.maincontent.document.getElementById(Dialog.contentUrl).focus();
//        
//        Dialog.contentUrl = "";
    }
  </script> 
<ComponentArt:Dialog
	  ID="Dialog"
	  RunAt="server"
	  AllowDrag="true"
	  AllowResize="false"
	  Modal="false"
	  Alignment="MiddleCentre"
	  Width="450"
	  Height="200"
	  ContentCssClass="dlg"	  
	  contentUrl=""
	  ContentClientTemplateId="content" FooterClientTemplateId="footer"
	  HeaderClientTemplateId="header"
	>
	 <ClientEvents>
            <OnShow EventHandler="dialogshow" />
            <OnClose EventHandler="dialogclose" />                
     </ClientEvents>
     <ClientTemplates>
		<ComponentArt:ClientTemplate id="header">
			<table style="filter:alpha(opacity=60);" cellpadding="0" cellspacing="0" border="0" width="458" height="35" onmousedown="Dialog.StartDrag(event);">
				<tr>
					<td width="9" height="35" style="background-image:url(Images/ComponentArt/Dialog/images/top-left.png);"></td>
					<td height="35" style="background-image:url(Images/ComponentArt/Dialog/images/top-mid.png);height:35px !important;" valign="middle" width="409">
						<span id="DialogTitle" style="color:White;font-size:15px;font-family:Arial;font-weight:bold;"></span>
					</td>
					<td width="40" height="35" valign="top" style="background-image:url(Images/ComponentArt/Dialog/images/top-right.png);">
						<img src="Images/ComponentArt/Dialog/images/close.png" style="cursor:default;padding-top:4px;" width="32" height="25" style="margin-top:4px;" onmousedown="this.src='Images/ComponentArt/Dialog/images/close-down.png';" onmouseup="this.src='Images/ComponentArt/Dialog/images/close-hover.png';" onclick="Dialog.Close('Close click');" onmouseover="this.src='Images/ComponentArt/Dialog/images/close-hover.png';" onmouseout="this.src='Images/ComponentArt/Dialog/images/close.png';"/>
					</td>
				</tr>
			</table>
		</ComponentArt:ClientTemplate>

		<ComponentArt:ClientTemplate id="content">
			<table cellpadding="0" cellspacing="0" width="458">
				<tr>
					<td style="background-image:url(Images/ComponentArt/Dialog/images/left.png);filter:alpha(opacity=60);" width="7"></td>
					<td style="background-color:white;font-size:12px;font-family:Arial;"><table width="100%" cellpadding="0" cellspacing="0"><tr><td valign="middle" style="padding:10px;width:30px;">
													<img src="Images/ComponentArt/Dialog/icons/## Parent.Icon ##" style="padding:5px;"  id="imgIcon" /></td><td style="padding:5px;" align="left" valign="middle"> ## Parent.Value ##
													</td></tr><tr><td colspan="2" style="background-image:url(Images/ComponentArt/Dialog/images/bottom_content.gif);height:41px;padding-right:10px;" align="right"><input type='button' onclick='## Parent.Id ##.Close("Close click");' value='  close  ' class="btn" id="buttonclose" style="height:23px"/></td>
													</tr></table></td>
					<td style="background-image:url(Images/ComponentArt/Dialog/images/right.png);filter:alpha(opacity=60);" width="7"></td>
				</tr>
			</table>
			</ComponentArt:ClientTemplate>
		<ComponentArt:ClientTemplate id="footer">
			<table cellpadding="0" cellspacing="0" width="458" height="7" style="filter:alpha(opacity=60);">
				<tr>
					<td width="9" height="7"><img style="display:block;" src="Images/ComponentArt/Dialog/images/bottom-left.png"/></td>
					<td style="background-image:url(Images/ComponentArt/Dialog/images/bottom-mid.png);" width="440"></td>
					<td width="9" height="7"><img style="display:block;" src="Images/ComponentArt/Dialog/images/bottom-right.png"/></td>
				</tr>
			</table>
		</ComponentArt:ClientTemplate>
	</ClientTemplates>
	</ComponentArt:Dialog>