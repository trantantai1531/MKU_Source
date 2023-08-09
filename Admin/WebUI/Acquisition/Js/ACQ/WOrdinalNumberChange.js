function CheckValue(field,strNote) {
	if (isNaN(eval(field).value) || parseInt(eval(field).value) < 0) { 
		alert(strNote);		
		eval(field).focus(); 
		return false;
		} 	 
	return true;	
}
function CheckUpdate(maxid,strNote,strNote1) {
	var i;
	var field;
	if (maxid<2) return false;
	for(i=2;i<maxid;i++) {
		field='document.forms[0].dtgContent__ctl'+i+'_txtdtgMaxNumber';
		if(eval(field)) {
			if (eval(field).value=='') {
				alert(strNote);
				eval(field).focus();
				return false;				
			}
			else {
				if(!CheckValue(field,strNote1)) 
					return false;
			}
		}
		else break;
	}
	return true;
}