function SelectCode(){
	var code;
	var PO;
	PO=document.forms[0].ddlPO.options[document.forms[0].ddlPO.selectedIndex].value;
	code=document.forms[0].ddlCode.options[document.forms[0].ddlCode.selectedIndex].value;
	document.forms[0].txtPOID.value=PO;
	if (code){
		//opener.document.forms[0].txtCodePO.value=PO;
		//opener.document.forms[0].txtCode.value=code;
		opener.location.href='WCopyNumber.aspx?Code=' + code+'&txtPOID='+PO;
		//opener.document.forms[0].action='WCopyNumber.aspx?Code=' + code; 
		//opener.document.forms[0].submit();
	}
	self.close();
	return false;
}