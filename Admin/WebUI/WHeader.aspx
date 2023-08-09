<%@ Page Language="VB" AutoEventWireup="false" CodeFile="WHeader.aspx.vb" Inherits="eMicLibAdmin.WebUI.WHeader" %>
<%@ Register src="~/Controls/UHeader.ascx" TagName="Header" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Resources/StyleSheet/style.css" type="text/css" rel="stylesheet" />
    <link href="Resources/StyleSheet/iconFont.css" rel="stylesheet" type="text/css" />
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
</head>
<body style="margin-top:0px;margin-left:0px;margin-right:0px;margin-bottom:0px;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="false" runat="server" />
        <uc1:Header ID="Header1" runat="server" />  
    </form>
</body>
</html>
