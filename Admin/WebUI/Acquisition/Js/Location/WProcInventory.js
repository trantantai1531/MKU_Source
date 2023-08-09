function CheckedAllOpt(strDtgName, strOptionName, intMax,val){
	var intCounter;
	for (intCounter = 2; intCounter < intMax  ; intCounter++)
	{
	    if (intCounter < 10)
	    {
	        if (eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName)) {
	            eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName).checked = val;
	        }
	    }
	    else
	    {
	        if (eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName)) {
	            eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName).checked = val;
	        }
	    }
    }
}
function FilterLocation(f) {
	var libraryid;
	libraryid=document.forms[0].ddlLibrary.options[document.forms[0].ddlLibrary.options.selectedIndex].value;
	eval ("document.forms[0]." + f + ".options.length = 0;");
	for (j = 0; j < LibID.length; j++) {
		if (LibID[j] == libraryid) {
			eval("document.forms[0]." + f + ".options.length = document.forms[0]." + f + ".options.length + 1;");
			eval("document.forms[0]." + f + ".options[document.forms[0]." + f + ".options.length - 1].value = LocID[j];");
			eval("document.forms[0]." + f + ".options[document.forms[0]." + f + ".options.length - 1].text = Location[j];");
		}
	}
}