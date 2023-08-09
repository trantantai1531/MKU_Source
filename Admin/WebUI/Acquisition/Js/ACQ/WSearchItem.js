function LoadBack(ControlName,Code){
	if(ControlName!=''){
		eval('opener.document.forms[0].'+ControlName).value=Code;
	}
	if(ControlName=='txtCode'){
		opener.location.href='WCopyNumber.aspx?Code='+Code;
	}
	self.close();
}

function CheckAll(msg){
	var chk;
	chk=CheckNull(document.forms[0].txtTitle) && CheckNull(document.forms[0].txtCopyNumber) && CheckNull(document.forms[0].txtAuthor) && CheckNull(document.forms[0].txtPublisher) && CheckNull(document.forms[0].txtYear) && CheckNull(document.forms[0].txtISBN)
	if (chk){
		alert(msg);
		return false;
	}else{
		return true;
	}
}