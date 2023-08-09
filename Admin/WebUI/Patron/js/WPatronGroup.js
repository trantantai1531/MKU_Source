function CheckAddNew(strNote,strNotNumber){	
	var i;
	var strStoreIDs;
	if(document.forms[0].txtNameGroup.value==''){
		alert(strNote);
		document.forms[0].txtNameGroup.focus();
		return(false);
	}
	if(document.forms[0].txtLoanQuota.value==''){		
		alert(strNote);
		document.forms[0].txtLoanQuota.focus();
		return(false);		
	}
	else {
		if (isNaN(document.forms[0].txtLoanQuota.value)) {
			alert(strNotNumber);
			document.forms[0].txtLoanQuota.focus();
			return(false);			
		}
	}
	if(document.forms[0].txtInlibraryQuota.value==''){
		alert(strNote);
		document.forms[0].txtInlibraryQuota.focus();
		return(false);
	}
	else {
		if (isNaN(document.forms[0].txtInlibraryQuota.value)) {
			alert(strNotNumber);
			document.forms[0].txtInlibraryQuota.focus();
			return(false);			
		}
	}
	if(document.forms[0].txtHoldQuota.value==''){
		alert(strNote);
		document.forms[0].txtHoldQuota.focus();
		return(false);
	}
	else {
		if (isNaN(document.forms[0].txtHoldQuota.value)) {
			alert(strNotNumber);
			document.forms[0].txtHoldQuota.focus();
			return(false);			
		}
	}
	if(document.forms[0].txtIllQuota.value==''){
		alert(strNote);
		document.forms[0].txtIllQuota.focus();
		return(false);
	}
	else {
		if (isNaN(document.forms[0].txtIllQuota.value)) {
			alert(strNotNumber);
			document.forms[0].txtIllQuota.focus();
			return(false);			
		}
	}
	if(document.forms[0].txtPriority.value==''){
		alert(strNote);
		document.forms[0].txtPriority.focus();
		return(false);
	}
	else {
		if (isNaN(document.forms[0].txtPriority.value)) {
			alert(strNotNumber);
			document.forms[0].txtPriority.focus();
			return(false);			
		}
	}
	if(document.forms[0].txtHoldTurnTimeOut.value==''){
		alert(strNote);
		document.forms[0].txtHoldTurnTimeOut.focus();
		return(false);
	}
	else {
		if (isNaN(document.forms[0].txtHoldTurnTimeOut.value)) {
			alert(strNotNumber);
			document.forms[0].txtHoldTurnTimeOut.focus();
			return(false);			
		}
	}
	strStoreIDs="";	
	for (i = 0; i < document.forms[0].lstStoreUsed.length; i++) {			
		strStoreIDs=strStoreIDs+document.forms[0].lstStoreUsed.options[i].value+",";		
	}
	strStoreIDs=strStoreIDs.substr(0,strStoreIDs.length-1);
	document.forms[0].hidStoreIDs.value=strStoreIDs;
	//alert(document.forms[0].hidStoreIDs.value);
	return (true)
}
function AskDeletePatron(strNoteMsg) {
	if(document.forms[0].ddlPatronGroup.options[0].selected)
		return (false);
	if(confirm(strNoteMsg)) 
		return true;
	else return false;
}
function ResetForm() {
	document.forms[0].txtNameGroup.value='';
	document.forms[0].txtLoanQuota.value=0;
	document.forms[0].txtInlibraryQuota.value=0;
	document.forms[0].txtHoldQuota.value=0;
	document.forms[0].txtIllQuota.value=0;
	document.forms[0].txtPriority.value=0;
	document.forms[0].txtHoldTurnTimeOut.value = 0;
	
	document.forms[0].ddlAccessLevel.options[0].selected=true;
	var i=0;
	for (i = 0; i < document.forms[0].lstStoreUsed.length; i++) {	
		var tmp=document.forms[0].lstStoreUsed.options[i].value;			
		if(tmp.charAt(0)!='$') {
			document.forms[0].lstStore.length++;
			document.forms[0].lstStore.options[(document.forms[0].lstStore.length)- 1].value = document.forms[0].lstStoreUsed.options[i].value;
			document.forms[0].lstStore.options[(document.forms[0].lstStore.length)- 1].text = document.forms[0].lstStoreUsed.options[i].text;	
		}
	}
	document.forms[0].lstStoreUsed.length=0;			
	return false;
}

function AddItem(){
	var k = 0;
	var i=0;
	for (i = 0; i < document.forms[0].lstStore.length; i++) {
		if(document.forms[0].lstStore.options[i].selected) {
			document.forms[0].lstStoreUsed.length++;
			document.forms[0].lstStoreUsed.options[(document.forms[0].lstStoreUsed.length)- 1].value = document.forms[0].lstStore.options[i].value;
			document.forms[0].lstStoreUsed.options[(document.forms[0].lstStoreUsed.length)- 1].text = document.forms[0].lstStore.options[i].text;		
		}
		else {document.forms[0].lstStore.options[k].value =document.forms[0].lstStore.options[i].value;
			document.forms[0].lstStore.options[k].text =document.forms[0].lstStore.options[i].text;
			document.forms[0].lstStore.options[k].selected = false;
            k = k + 1;
		}		
	}
	document.forms[0].lstStore.length = k;
}

function RemoveItem(){
	var k=0;              
	var i=0;
	for (i = 0; i < document.forms[0].lstStoreUsed.length; i++) {	
		if(document.forms[0].lstStoreUsed.options[i].selected) {
			var tmp=document.forms[0].lstStoreUsed.options[i].value;			
			if(tmp.charAt(0)!='$') {
				document.forms[0].lstStore.length++;
				document.forms[0].lstStore.options[(document.forms[0].lstStore.length)- 1].value = document.forms[0].lstStoreUsed.options[i].value;
				document.forms[0].lstStore.options[(document.forms[0].lstStore.length)- 1].text = document.forms[0].lstStoreUsed.options[i].text;	
			}
		}
		else {document.forms[0].lstStoreUsed.options[k].value =document.forms[0].lstStoreUsed.options[i].value;
		document.forms[0].lstStoreUsed.options[k].text =document.forms[0].lstStoreUsed.options[i].text;
		document.forms[0].lstStoreUsed.options[k].selected = false;		
		k=k+1;
		}
	}			
	document.forms[0].lstStoreUsed.length = k;
}
