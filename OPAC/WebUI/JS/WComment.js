
//Check null value
function CheckNullNew(obj,strError){
	alert('true');
	strValue = eval(obj).value;
	strValue = trim(strValue);
	if (strValue == "") {
		eval(obj).value = '';
		eval(obj).focus();
		alert(strError);
		return true;
	}
	return false;
}

function ReturnIt(intItemID){
	self.location.href='WShowDetail.aspx?intItemID=' + intItemID
	return false;
}

function ResetIt(){
	document.forms[0].txtSubject.value='';
	document.forms[0].txtContent.value='';
	return false;
}

function CheckAll(strMsg1,strMsg2){
	if(document.forms[0].txtCode==''){
		alert(strMsg1);
		document.forms[0].txtCode.focus();
		return false;
	}
	if(document.forms[0].txtPassWord==''){
		alert(strMsg2);
		document.forms[0].txtPassWord.focus();
		return false;
	}
	return true;
}