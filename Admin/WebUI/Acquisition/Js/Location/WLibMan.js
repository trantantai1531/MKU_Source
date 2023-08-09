// Check for Addnew
function CheckAddNew(strNote,strTitle,strConfirm){
	//return false;
	if(trim(document.forms[0].txtCodeLib.value)==''){
		alert(strNote);
		document.forms[0].txtCodeLib.focus();
		return(false);
	}
	else {
		var Index=document.forms[0].ddlMergerLib.options.length;;
		var strtemp;
		var strCodeLib;
		for(i=0;i<Index;i++) {				
			strtemp=document.forms[0].ddlMergerLib.options[i].text;
			strCodeLib=strtemp.substring(strtemp.indexOf('(')+1,strtemp.indexOf(')'));
			if(trim(document.forms[0].txtCodeLib.value).toUpperCase()==trim(strCodeLib).toUpperCase()){
				alert(strTitle+" '"+trim(document.forms[0].txtCodeLib.value)+"' "+strConfirm);
				return false;					
				}				
			}	
		}	
	return(true);
}
// Check for update
function CheckUpdate(intIDcur,txtField,ddlField,strNote,strTitle,strConfirm){
	//return false;
	if(trim(eval(txtField).value)==''){
		alert(strNote);
		eval(txtField).focus();
		return(false);
	}
	else {
		var Index=eval(ddlField).options.length;;
		var strtemp;
		var strCodeLib;
		var i;		
			
		for(i=0;i<Index;i++) {				
			if(intIDcur!=eval(ddlField).options[i].value) {
				strtemp=eval(ddlField).options[i].text;			
				strCodeLib=strtemp.substring(strtemp.indexOf('(')+1,strtemp.indexOf(')'));
				if(trim(eval(txtField).value).toUpperCase()==trim(strCodeLib).toUpperCase()){
					alert(strTitle+" '"+trim(eval(txtField).value)+"' "+strConfirm);
					return false;									
					}							
				}
			}	
		}	
	return(true);
}

function CheckMerger(strErr,strNote,strErrorMerger,strConfirm) {	
	if (document.forms[0].hidLibIDs.value=="") {
		alert(strErr);
		return false;
	}		
	var inti;
	var arrLibIDs=document.forms[0].hidLibIDs.value.split(',');
	var intCount=arrLibIDs.length+3;
	var currID=document.forms[0].ddlMergerLib.options[document.forms[0].ddlMergerLib.options.selectedIndex].value;
	var CheckMerger=0;
	var checkSelected=0;		
	var intCurrIndex=parseInt(document.forms[0].hidPageIndex.value);	
	for (inti=3;inti<intCount;inti++) {		
	    if (eval('document.forms[0].dtgInfoLib_ctl0' + inti + '_ckbdtgMerger')) {
	        if (eval('document.forms[0].dtgInfoLib_ctl0' + inti + '_ckbdtgMerger').checked) {
				if (currID!=arrLibIDs[inti+intCurrIndex-3]) {
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
	// selected one that the same libid need merger
	if(CheckMerger==0) {
		alert(strErrorMerger);
		return false;
	}

	if (!confirm(strConfirm))
		return false;
	return true;

}

function ResetForm() {
	document.forms[0].txtCodeLib.value="";
	document.forms[0].txtNameLib.value="";
	document.forms[0].txtAddressLib.value="";	
}

