/**************************************************************************
************************ SetFieldShow Js file *****************************
**************************************************************************/
function SetValueFieldShow(st){
	var val;
	if (isNaN(document.forms[0].txtPageSize.value)){
		alert(st);
		document.forms[0].txtPageSize.value='';
		document.forms[0].txtPageSize.focus();
		return;
	}else{
		opener.document.forms[0].txtPageSize.value='';
		opener.document.forms[0].txtPageSize.value=document.forms[0].txtPageSize.value;
		val='';
		for (i = 0; i < document.forms[0].lstFieldShow.options.length; i++) {
			if (document.forms[0].lstFieldShow.options[i].selected) {
				val = val + document.forms[0].lstFieldShow.options[i].value +",";
			}
		}	
		if (val.length > 0){
			opener.document.forms[0].txtFieldShow.value='';
			opener.document.forms[0].txtFieldShow.value=val.substring(0,val.length-1);
		}
		self.close();
	}
}