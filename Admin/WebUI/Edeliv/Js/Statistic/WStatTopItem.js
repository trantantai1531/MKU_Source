
function cmpeDate(strDateFormat, strMsg){
	if(CompareDate(document.forms[0].txtTimeFrom,document.forms[0].txtTimeTo,strDateFormat)==0){
		alert(strMsg);
		document.forms[0].txtTimeFrom.focus();
		return false;
	}
	return true;
}