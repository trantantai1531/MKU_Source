<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="s3capcha.ascx.vb" Inherits="eMicLibOPAC.WebUI.OPAC.s3capcha_s3capcha" %>
<script language="javascript" type="text/javascript" src="<%=ResolveClientUrl("~/s3capcha/s3Capcha.js")%>"></script>
<script language="javascript" type="text/javascript">
    $(document).ready(function () { $('#capcha').s3Capcha(); });
</script>
<div id="capcha">
<asp:Literal ID="CapchaHTML" runat="server"></asp:Literal>
</div>