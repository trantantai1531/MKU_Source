function LoadBackData() {
    var strValue;
   // console.log(strValue);
    if (document.forms[0].lstEntries.options.selectedIndex >= 0) {
        strValue = document.forms[0].lstEntries.options[document.forms[0].lstEntries.options.selectedIndex].text;
       // console.log(strValue);
        //window.opener.document.forms[0].txtPubCountry
        // console.log("window.opener.document.forms[0]." + strDestField);

        eval("window.opener.document.forms[0]." + strDestField + ".value = '" + strValue + "';");
        eval("window.opener.document.forms[0]." + strDestField + ".focus();");
        self.close();
        return true;
    }

    if (document.forms[0].lstEntries.options.selectedIndex <= 0) {
        return false;
    }

    return true;
	
}

function LoadBackValue() {
	var strValue;
	
	if (document.forms[0].lstEntries.options.selectedIndex>=0)
	{
	    strValue = document.forms[0].lstEntries.options[document.forms[0].lstEntries.options.selectedIndex].value;
	    //console.log(strValue);
	    //window.opener.document.forms[0].txtPubCountry
	   // console.log("window.opener.document.forms[0]." + strDestField);
	 
	    eval("window.opener.document.forms[0]." + strDestField + ".value = '" + strValue + "';");
	    eval("window.opener.document.forms[0]." + strDestField + ".focus();");
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
 //   eval("opener.document.forms(0)." + strDestField + ".focus();");
    console.log(self);
	self.close();
	return true;
}
