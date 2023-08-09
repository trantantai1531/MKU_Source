function CheckFileExt() {
	var strFileExt;
	var intPos;
	var strAllowedFile = ';' + document.forms[0].hidAllowedFiles.value + ';';
	var strDenniedFile = ';' + document.forms[0].hidDenniedFiles.value + ';';
	strAllowedFile = strAllowedFile.replace(" ", "");
	strDenniedFile = strDenniedFile.replace(" ", "");
	strAllowedFile = strAllowedFile.toLowerCase();
	strDenniedFile = strDenniedFile.toLowerCase();
	strFileExt = document.forms[0].FileUpload.value;
	strFileExt = strFileExt.toLowerCase();	
	intPos = strFileExt.lastIndexOf(".");
	strFileExt = ';' + strFileExt.substring(intPos + 1, strFileExt.length) + ';';	
	if (strAllowedFile.indexOf(strFileExt) < 0) {
	return false;
	} else if (strDenniedFile.indexOf(strFileExt) >= 0) {		
	return false;
	}
	return true;
}