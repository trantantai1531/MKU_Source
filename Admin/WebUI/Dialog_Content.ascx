<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Dialog_Content.ascx.vb" Inherits="UI_Control_Sys_Common_Dialog_Content_Preview" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<style>
.headerCss
{
	cursor:pointer;
	cursor:move;
}
.contentCss
{
  
  background-image:url(Images/ComponentArt/Dialog/images/s_L_main2.png); 
  text-align:center;
}
.iFrameCss
{
	overflow:auto;
	padding:0px;
}
</style>
  <script type="text/javascript">    
    function dialogshow(dialog) {
        document.getElementById('dialogtitle').innerHTML = Dialog_content.get_title();				
    }    
        
  function dialogclose(dialog)
    {          
        //dialog.set_value(null);   
        //dialog.close();                  
    }

  </script>
 
<ComponentArt:Dialog IFrameCssClass="iFrameCss"  ContentUrl="## Parent.ContentUrl ##"  ContentCssClass="contentCss" FooterCssClass="footerCss" HeaderCssClass="headerCss" CssClass="contentCss" Value="" Alignment="TopLeft"  ID="Dialog_content" IFrameScrolling="yes" runat="server" Height="0" Width="0" Offsetx="0" PreloadContentUrl="false" AllowDrag="false" >
  <ClientEvents>
    <OnShow EventHandler="dialogshow" />    
    <OnClose EventHandler="dialogclose" />                    
  </ClientEvents>
    <Header>
        <table cellpadding="0" cellspacing="0" id="tableheader" width="100%"  onmousedown="Dialog_content.StartDrag(event);">
            <tr>
                <td width="7"><img style="display:block;" src="Images/ComponentArt/Dialog/images/s_TL_main2.png"/></td>
                <td style="background-image:url(Images/ComponentArt/Dialog/images/s_T_main2.png);padding:3px;">
                    <table width="100%" height="100%" cellpadding="0" cellspacing="0">
                    <tr>    
                        <td valign="bottom" style="color:White;font-size:13px;font-family:Arial;font-weight:bold;">
                            <span style="color:#000000;font-size:15px;font-family:Arial;font-weight:bold;" id ="dialogtitle"></span>
                        </td>
                        <td align="right" valign="middle"></td>
                     </tr>
                     </table>
                 </td>
                <td style="cursor:default;background-color:#d5d5d5;" width="7">
                    <img style="display:block;cursor:pointer;" src="Images/ComponentArt/Dialog/images/btn_close2.gif" onclick="Dialog_content.Close('Close click');"/>
                </td>
            </tr>
        </table>
    </Header>
    <Footer>
        <table cellpadding="0" cellspacing="0" id="tablefooter" width="100%">
        <tr>
        <td width="7"><img style="display:block;" src="Images/ComponentArt/Dialog/images/s_BL_main2.png"/></td>
        <td style="background-image:url(Images/ComponentArt/Dialog/images/s_B_main2.png);background-color:#d5d5d5;" height="5" width="100%">
        </td>
        <td ><img style="display:block;" src="Images/ComponentArt/Dialog/images/s_BR_main2.png"/></td>
        </tr>
    </table>
    </Footer>	
</ComponentArt:Dialog>         