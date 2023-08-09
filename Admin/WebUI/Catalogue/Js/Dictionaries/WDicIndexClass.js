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

function CheckMerger(strNote,strErrorMerger,strConfirm) {	
	var inti;
	var arrLocIDs=document.forms[0].hidDicIDs.value.split(',');	
	var intCount = document.forms[0].getElementsByTagName("input").length - 5;
	//console.log(document.forms[0]);
	var currID = document.forms[0].ddlDic.options[document.forms[0].ddlDic.options.selectedIndex].value;
	
	var CheckMerger=0;
	var checkSelected=0;		
	for (inti = 3; inti < intCount; inti++) {
	    //dtgDicIndex__ctl17_ckbdtgMerger
		if (eval('document.forms[0].dtgDicIndex_ctl0'+inti+'_ckbdtgMerger')) {
			if (eval('document.forms[0].dtgDicIndex_ctl0'+inti+'_ckbdtgMerger').checked) {
				if (currID!=arrLocIDs[inti-3]) {
					CheckMerger=1;					
					break;
				}
				checkSelected=1;
			}
		}
	}
	// no selected for merger
	if ((inti==intCount)&&(checkSelected==0)) {
		alert(strNote);
		return false;
	}
	// selected one that the same id need merger
	if(CheckMerger==0) {
		alert(strErrorMerger);
		return false;
	}

	if (!confirm(strConfirm))
		return false;
	return true;

}

// Check for Addnew
function CheckAddNew(strNote){
	//return false;
	if(document.forms[0].txtCode.value==''){
		alert(strNote);
		document.forms[0].txtCode.focus();
		return(false);
	}
	return(true);
}
// Check for update
function CheckUpdate(txtField,strNote){
	//return false;
	if(eval(txtField).value==''){
		alert(strNote);
		eval(txtField).focus();
		return(false);
	}
	return true;
}

