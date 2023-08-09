/*
	LoadBack function
	Purpose: loadback display view
*/
function LoadBack(strMess) {
	alert(strMess);
	parent.Sentform.location.href = "WMarcSend.aspx";
	self.location.href = "WMarcFrame.aspx";
}