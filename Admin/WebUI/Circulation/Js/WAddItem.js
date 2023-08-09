function Update(msg){
	if (CheckNull(document.forms[0].txt245_a)){
		alert(msg);
		document.forms[0].txt245_a.focus();
		return false;
	}else{
		document.forms[0].action='WAddCopyNumber.aspx?Update=1'; 
		document.forms[0].submit();
		return true;
	}
}


