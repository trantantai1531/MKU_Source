function ConUpdate_cl(){
	self.location.href='WCopyNumber.aspx?Code=' + document.forms[0].txtCode.value+'&txtPOID='+document.forms[0].txtPOID.value; 
	//document.forms[0].action='WCopyNumber.aspx?Code=' + document.forms[0].txtCode.value; 
	//document.forms[0].submit();
	return false;
}

function Back_cl(){
	self.location.href='WCataForm.aspx';
	return false;	
}
