/*
	OpenRegForm function
	Purpose: open register form
*/
function OpenRegForm(strURL) {
	parent.Receive.location.href="WReceive.aspx?" + strURL;
}
function CheckSearch(strMsg) {
	if ((trim(document.forms[0].txtReceivedDate.value)=="")&&(trim(document.forms[0].txtIssuedDate.value)=="")) {
		alert(strMsg);
		document.forms[0].txtIssuedDate.focus();
		return false;
	}
	return true;	
}