/**********************************************************************************/
/***********************		WCopyNumRem Js file		***************************/
/**********************************************************************************/
// Load Holding Location 
function BindStoreData(LibraryID){
	if(LibraryID==0){// Delete store here
		document.forms[0].ddlStore.options.length=0;
		document.forms[0].txtStore.value=0;
	}
	else{// Load store dependon 3 arrays ID,Symbol,LibID
		document.forms[0].ddlStore.options.length=0;
		for(i=0;i<ID.length;i++){
			if(LibraryID==LibID[i]){
				document.forms[0].ddlStore.options.length++;
				document.forms[0].ddlStore.options[document.forms[0].ddlStore.options.length-1].value=ID[i];
				document.forms[0].ddlStore.options[document.forms[0].ddlStore.options.length-1].text=Symbol[i];
			}
		}
		if(document.forms[0].ddlStore.options.length>0){
			document.forms[0].txtStore.value=document.forms[0].ddlStore.options[0].value;
		}
		else{
			document.forms[0].txtStore.value=0;
		}
	}
	return false;
}