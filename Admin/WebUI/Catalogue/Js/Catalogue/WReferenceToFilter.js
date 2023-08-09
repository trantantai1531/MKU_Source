function LoadBackData() {
	var strValue;
	console.log(document.forms[0]);
	console.log(window.opener);
	if (document.forms[0].lstEntries.options.selectedIndex>=0)
	{
		strValue = document.forms[0].lstEntries.options[document.forms[0].lstEntries.options.selectedIndex].text;
		eval("window.opener.document.Form1." + strDestField + ".value = '" + strValue + "'");
		eval("window.opener.document.Form1." + strDestField + ".focus()");
		self.close();
		return true;
	}
	
	if (document.forms[0].lstEntries.options.selectedIndex<=0)
	{
	return false;
	}
	
	return true;
	
}

function LoadBackValue() {
	var strValue;
	console.log(document.forms[0]);
	console.log(window.opener);
	if (document.forms[0].lstEntries.options.selectedIndex>=0)
	{
		strValue = document.forms[0].lstEntries.options[document.forms[0].lstEntries.options.selectedIndex].value;
		eval("window.opener.document.Form1." + strDestField + ".value = '" + strValue + "';")
		eval("window.opener.document.Form1." + strDestField + ".focus();")
		self.close();
		return true;
	}
	
	if (document.forms[0].lstEntries.options.selectedIndex<=0)
	{
	return false;
	}
	
	return true;
	
}

function Close() {
    eval("opener.document.Form1." + strDestField + ".focus()");
	self.close();
	return true;
}
