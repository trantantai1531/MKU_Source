<%@ Reference Page="~/Edeliv/EData/WEDataManager.aspx" %>
<%@ Page Language="vb" AutoEventWireup="false" Inherits="eMicLibAdmin.WebUI.Catalogue.WEDataManager" CodeFile="WEDataManager.aspx.vb" CodeFileBaseClass="eMicLibAdmin.WebUI.clsWBase" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
  <head>
    <title>Chọn tệp cần đính kèm biểu ghi biên mục</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
    <meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
    <link href="/Resources/style.css" type="text/css" rel="stylesheet" />
  </head>
  <FRAMESET border="0" frameSpacing="0" cols="200,*,0" frameBorder="0">
		<FRAME name="foldertree" marginWidth="0" marginHeight="0" src="clsWTreeView.aspx?FieldCode=<%=Request.querystring("FieldCode")%>&Repeatable=<%=Request.querystring("Repeatable")%>&WField=<%=Request.querystring("WField")%>&SField=<%=Request.querystring("SField")%>" scrolling="yes">
		<FRAME name="foldercontents" marginWidth="0" marginHeight="0" src="WShowDetail.aspx?FieldCode=<%=Request.querystring("FieldCode")%>" scrolling="yes">
		<FRAME name="HiddenDownload" marginWidth="0" marginHeight="0" src="../../WNothing.htm" frameBorder="0"
					scrolling="no">
	</FRAMESET>
</HTML>
