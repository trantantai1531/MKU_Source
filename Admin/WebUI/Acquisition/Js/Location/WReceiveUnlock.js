function CheckMoveLocation(Msg)
{
	var blnOK;
	//var Msg=document.forms[0].txtMsg.value;
	blnOK=CheckNull(document.forms[0].txtCopyNumberFrom);
	blnOK=blnOK && CheckNull(document.forms[0].txtCopyNumberTo);	
	if (blnOK){
		alert(Msg);
		return false;	
	}else{
		return true;		
	}
	
}