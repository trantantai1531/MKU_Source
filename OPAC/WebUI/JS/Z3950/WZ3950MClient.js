function CheckForSubmit(strNote,strNoLib) {
	if((document.forms[0].txtFieldValue1.value!="")&&(document.forms[0].ListZ3950.length!=0)) {
		document.forms[0].action="WZ3950MultiShow.aspx";
		document.forms[0].submit();
		}
	else {
		if(document.forms[0].txtFieldValue1.value=="") {
			alert(strNote);
			document.forms[0].txtFieldValue1.focus();			
			}
		else {
			if(document.forms[0].ListZ3950.length==0) {
				alert(strNoLib);
			}
		}
	}
	return false;
}
