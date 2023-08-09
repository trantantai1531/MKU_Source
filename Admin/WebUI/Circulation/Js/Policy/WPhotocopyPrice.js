function ValidNew(strMsg){
	if (CheckNull(document.forms[0].txtTypeName)){
		alert(strMsg);
		document.forms[0].txtTypeName.focus();
		return false;
	}else{
		if (!CheckNum(document.forms[0].txtPricePerPage)){
			document.forms[0].txtPricePerPage.focus();
			alert(strMsg);
			return false;
		}else{
			return true;
		}
	}
}