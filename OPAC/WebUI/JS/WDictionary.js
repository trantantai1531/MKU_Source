function LoadBackData(ControlName){
	if(document.forms[0].flage.value > 0){
		if(document.forms[0].lsbDictionary.options.selectedIndex >=0){
			eval('opener.document.forms[0].' + ControlName).value=document.forms[0].lsbDictionary.options[document.forms[0].lsbDictionary.options.selectedIndex].text;
			self.close();
			opener.focus();
			return(false);//close current form		
		}
		else{
			return(true);//allow submit current form
		}		
	}
	else{
		return(true);//allow submit current form
	}
}