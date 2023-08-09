function CheckUserName(msg){
	var chk;
	chk = CheckNull(document.forms[0].txtUserName)
	if (chk)
	{
		alert(msg);
		document.forms[0].txtUserName.focus();
		return false;	
	}
		return true;
}