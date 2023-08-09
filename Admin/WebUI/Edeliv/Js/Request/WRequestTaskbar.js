function FilterData()
{
	parent.Workform.location.href = 'WRequestFilter.aspx';
	document.forms[0].btnFilter.disabled=true;
	document.forms[0].ddlAction.disabled=true;
	document.forms[0].btnAction.disabled=true;
	document.forms[0].btnFilter.disabled=true;
	document.forms[0].btnCancelFilter.disabled=true;
}	


function Act()
{
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 1)
	{
			OpenWindow('WRequestRemove.aspx?RequestID=' + document.forms[0].hidRequestID.value,'WRequestRemove',450,200,100,50);
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 2)
	{
			OpenWindow('WRequestSendMsg.aspx?RequestID=' + document.forms[0].hidRequestID.value,'WRequestSendMsg',520,310,100,50);
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 3)
	{
			OpenWindow('WRequestSendFile.aspx?RequestID=' + document.forms[0].hidRequestID.value,'WRequestSendFile',420,210,100,50);
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 4)
	{
			OpenWindow('WRequestSendRefuse.aspx?TemplateType=1&RequestID=' + document.forms[0].hidRequestID.value,'WRequestSendRefuse',530,300,50,50);
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 5)
	{
			OpenWindow('WRequestSendBill.aspx?TemplateType=2&RequestID=' + document.forms[0].hidRequestID.value,'WRequestSendBill',530,300,50,50);
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 6)
	{
			OpenWindow('WRequestChangeStat.aspx?RequestID=' + document.forms[0].hidRequestID.value,'WRequestChangeStat',420,210,100,50);
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 7)
	{
			OpenWindow('WRequestPrintPack.aspx?RequestID=' + document.forms[0].hidRequestID.value,'WRequestSendFile',510,280,100,50);
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 8)
	{
			OpenWindow('WRequestSendNotice.aspx?TemplateType=0&RequestID=' + document.forms[0].hidRequestID.value,'WRequestSendNotice',530,300,50,50);
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 9)
	{
			parent.Hiddenbase.location.href='WRequestMoveFolder.aspx?RequestID=' + document.forms[0].hidRequestID.value;
	}
	if (document.forms[0].ddlAction.options[document.forms[0].ddlAction.options.selectedIndex].value == 10)
	{
			OpenWindow('WRequestCancel.aspx?RequestID=' + document.forms[0].hidRequestID.value,'WRequestCancel',530,300,50,50);
	}
}