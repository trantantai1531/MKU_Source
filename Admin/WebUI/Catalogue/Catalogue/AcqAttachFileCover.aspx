<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcqAttachFileCover.aspx.vb" Inherits="eMicLibAdmin.WebUI.Catalogue.Catalogue_Catalogue_AcqAttachFileCover" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body style="margin-top:0;margin-left:0;margin-right:0;margin-bottom:0;background-color:White;">
    <form id="form1" runat="server">
    <table id="table8" width="100%" height="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="white" style="vertical-align:top;" >
         <tr>
            <td style="width:100%;vertical-align:top;height:300px;">
                <iframe id="uploadFrame" frameborder="0" height="300" width="550" scrolling="no" src="AcqUploadToolkit.aspx?sfile=<%=Request("sfile")%>">
                </iframe>
            </td>
         </tr>
         <tr class="lbControlBar">
			<td colspan="2" style="width:100%;vertical-align:top;">
				<asp:button id="btnUpload" runat="server" Text="Gắn kèm(a)" Width="88px" CssClass="lbButton"/>
				<input type="button" id="btnClose" name="btnClose" value="Đóng(o)" class="lbButton" onclick="javascript:top.closeDialog('Dialog_content');" />
				<asp:Button runat="server" id="btnDownload"  CssClass="lbButton" Text="Tải ảnh" />
			</td>
		 </tr>
    </table>
    <div style="display:none">
        <input id="hidAllowedFiles" type="hidden" runat="server"/> <input id="hidDenniedFiles" type="hidden" runat="server"/>
	    <input id="hidFileSize" type="hidden" runat="server"/> <input id="hidDataTypeID" type="hidden" runat="server"/>
	    <input id="hidFieldCode" type="hidden" runat="server"/> <input id="hidWField" type="hidden" runat="server"/>
	    <input id="hidSField" type="hidden" runat="server"/> <input id="hidRepeatable" type="hidden" runat="server"/>
	    <input id="hidPath" type="hidden" runat="server"/> <input id="hidURL" type="hidden" runat="server"/>
	    <input id="hidPrefix" type="hidden" runat="server"/> <input id="hidSFile" type="hidden" runat="server"/>
    </div>
    </form>
</body>
</html>
