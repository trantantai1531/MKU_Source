<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Dialog_Confirm.ascx.vb" Inherits="UI_Control_Sys_Common_Confirm" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
  <script type="text/javascript">    
    function dialogshow(dialog) {
        var infoTitle = document.getElementById("infoTitle");
        if (infoTitle != null) {
            infoTitle.innerHTML = GetValue(dialog.Title, 0);
        }
        var objyes = document.getElementById("buttonyes");
        if (objyes != null) {
            objyes.value = GetValue(dialog.Title,1);
        }
        var objno = document.getElementById("buttonno");
        if (objno != null) {
            objno.value = GetValue(dialog.Title, 2);
            objno.focus();            
        }
    }
    function GetValue(val,id) {
        var text;
        text = val.split(';');
        if (text[id] == undefined)
            return "???";
        else
            return text[id];
    }
    function dialogclose(dialog)
    {        
      if(dialog.get_result() == 'OK click')
        {        
            if (Dialog_confirm.contentUrl!='')                
            {                
                var url;
                url=Dialog_confirm.contentUrl;
                if (url.indexOf("?") > 0)
                    location.href = Dialog_confirm.contentUrl;
                else if (url.indexOf("callback") > 0) {
                    var Control, RaiseFunction;
                    Control = Dialog_confirm.contentUrl;
                    RaiseFunction = Control.replace("callback", "");
                    eval('top.main.Workform.maincontent.' + RaiseFunction);
                }
                else {
                    top.MLContent.main.maincontent.document.getElementById(Dialog_confirm.contentUrl).click();
                }
            }
            Dialog_confirm.contentUrl = "";
            dialog.set_value(null);              
        }              
    }
    
    function alignmentchange(sender, eventargs)
    {
        Dialog_confirm.set_x(null);
        Dialog_confirm.set_y(null);
        Dialog_confirm.set_alignment(sender.getSelectedItem().Value);
    }
    function update()
    {
			Dialog_confirm.beginUpdate();			
			Dialog_confirm.set_icon(ComboBox2.getSelectedItem().Value);
			Dialog_confirm.endUpdate();
    }

  </script>
 
            <ComponentArt:Dialog  ModalMaskImage="Images/ComponentArt/Dialog/images/alpha.png" AnimationDuration="600" HeaderCssClass="headerCss" Icon="pencil.gif"  Value="Dialog Content" HeaderClientTemplateId="header" Title="ComponentArt Dialog" ContentClientTemplateId="content" FooterClientTemplateId="footer" AllowDrag="true" Alignment="MiddleCentre"  ID="Dialog_confirm" runat="server" Height="151" Width="458" contentUrl="">
              <ClientEvents>
                <OnShow EventHandler="dialogshow" />
                <OnClose EventHandler="dialogclose" />                                                
              </ClientEvents>
	<ClientTemplates>
		<ComponentArt:ClientTemplate id="header">
			<table style="filter:alpha(opacity=60);" cellpadding="0" cellspacing="0" border="0" width="458" height="35" onmousedown="Dialog_confirm.StartDrag(event);">
				<tr>
					<td width="9" height="35" style="background-image:url(Images/ComponentArt/Dialog/images/top-left.png);"></td>
					<td height="35" style="background-image:url(Images/ComponentArt/Dialog/images/top-mid.png);height:35px !important;" valign="middle" width="409">
						<span style="color:White;font-size:15px;font-family:Arial;font-weight:bold;" id ="infoTitle">## Parent.Title ##</span>
					</td>
					<td width="40" height="35" valign="top" style="background-image:url(Images/ComponentArt/Dialog/images/top-right.png);">
						<img src="Images/ComponentArt/Dialog/images/close.png" style="cursor:default;padding-top:4px;" width="32" height="25"  onmousedown="this.src='Images/ComponentArt/Dialog/images/close-down.png';" onmouseup="this.src='Images/ComponentArt/Dialog/images/close-hover.png';" onclick="Dialog_confirm.Close('Close click');" onmouseover="this.src='Images/ComponentArt/Dialog/images/close-hover.png';" onmouseout="this.src='Images/ComponentArt/Dialog/images/close.png';"/>
					</td>
				</tr>
			</table>
		</ComponentArt:ClientTemplate>

		<ComponentArt:ClientTemplate id="content">
		    <table cellpadding="0" cellspacing="0" width="458">
				<tr>
					<td style="background-image:url(Images/ComponentArt/Dialog/images/left.png);filter:alpha(opacity=60);" width="7"></td>
					<td style="background-color:white;font-size:12px;font-family:Arial;">
					    <table width="100%" cellpadding="0" cellspacing="0">
					        <tr>
					            <td valign="middle" style="padding:10px;width:30px;"><img src="Images/ComponentArt/Dialog/icons/## Parent.Icon ##" style="padding:5px;"/></td>
					            <td style="padding:5px;" align="left" valign="middle">## Parent.Value ##</td>
					        </tr>
			                <tr>
			                    <td colspan="2" style="background-image:url(Images/ComponentArt/Dialog/images/bottom_content.gif);height:41px;padding-right:10px;" align="right">
			                    <input type="button"  id="buttonyes" onclick='Dialog_confirm.Close("OK click");' class="btn" value="&nbsp;Yes&nbsp;" />&nbsp;&nbsp;<input class="btn" type='button' onclick='Dialog_confirm.Close("Cancel click");' value='&nbsp;No&nbsp;' id="buttonno" />
			                   </td>
							</tr>
						</table>
					</td>
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