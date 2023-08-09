function CreateIDs(){
	var strIDs;
	strIDs='';
	document.forms[0].txtIDs.value='';
	//alert(document.forms[0].chkIDs.length);
	if ( ! document.forms[0].chkIDs.length){
		if (document.forms[0].chkIDs.value){
			if (document.forms[0].chkIDs.checked){
				strIDs=document.forms[0].chkIDs.value;
			}
		}
	}else{
		for (i=0;i<document.forms[0].chkIDs.length;i++){
			if (document.forms[0].chkIDs[i].checked){
				strIDs = strIDs + document.forms[0].chkIDs[i].value + ',';
			}
		}	
	}
	if (strIDs.substring(strIDs.length-1,strIDs.length)== ','){
		document.forms[0].txtIDs.value=strIDs.substring(0,strIDs.length-1);
	}else{
		document.forms[0].txtIDs.value=strIDs;
	}
}