function CheckForm(strNote) {
	if ((document.forms[0].txtTitle.value!="")||(document.forms[0].txtCopyNumber.value!="")||(document.forms[0].txtAuthor.value!="")||(document.forms[0].txtPublishing.value!="")||(document.forms[0].txtPublicYear.value!="")||(document.forms[0].txtISBN.value!=""))
		return true;
	alert(strNote);
	return false;
}
function ResetForm() {
	document.forms[0].txtTitle.value="";
	document.forms[0].txtCopyNumber.value="";
	document.forms[0].txtAuthor.value="";
	document.forms[0].txtPublishing.value="";
	document.forms[0].txtPublicYear.value="";
	document.forms[0].txtISBN.value="";
	return false;
}
function LoadBack(val) {			
	opener.document.forms[0].txtCodeDoc.value=val;
	self.close();
}