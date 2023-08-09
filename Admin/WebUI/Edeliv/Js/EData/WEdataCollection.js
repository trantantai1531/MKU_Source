
// Check for Addnew
function CheckAddNew(txtField,ddlField,strNote,strTitle,strConfirm){			
	var strtemp=trim(eval(txtField).value);
	if(strtemp==""){
		alert(strNote);
		eval(txtField).focus();
		return(false);
	}
	else {
		var Index=eval(ddlField).options.length;		
		for(i=0;i<Index;i++) {				
			strtemp=eval(ddlField).options[i].text;
			if(trim(eval(txtField).value).toUpperCase()==strtemp.toUpperCase()){
				alert(strTitle+" '"+trim(eval(txtField).value)+"' "+strConfirm)
				return false;					
				}				
			}	
		}	
	return(true);
}
// Check for update
function CheckUpdate(intIDcur,txtField,ddlField,strNote,strTitle,strConfirm){
	//return false;
	if(eval(txtField).value==''){
		alert(strNote);
		eval(txtField).focus();
		return(false);
	}
	else {
		var Index=eval(ddlField).options.length;
		var i;		
		var strtemp;	
		for(i=0;i<Index;i++) {				
			if(intIDcur!=eval(ddlField).options[i].value) {
				strtemp=trim(eval(ddlField).options[i].text);			
				if(trim(eval(txtField).value.toUpperCase())==strtemp.toUpperCase()){
					alert(strTitle+" '"+eval(txtField).value+"' "+strConfirm)
					return false;					
					}							
				}
			}	
		}	
	return(true);
}

// CheckOptionsNull function - Alert when no option is checked
function CheckOptionsNull(strDtgName, strOptionName, intStart, intMax, strMsg){	
	var intCounter;	          			
	var intCount;          
	
	intCount = 0;			
	
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked)
		{
			intCount = intCount + 1;	
		}			
	}
	if (intCount != 0) {
		return true;
	}
	else
	{
		alert(strMsg);
		return false;
	}
}

// Confirm the merge (YES = Do action, NO = Cancel)
function ConfirmMerger(msg) {
var truthBeTold = window.confirm(msg);
if (truthBeTold) 
	return true;	
else  
	return false;
}


// Check for Addnew of Faculty
function CheckAddNewFaculty(strNote,strTitle,strConfirm){
	//return false;
	if(document.forms[0].txtFaculty.value==''){
		alert(strNote);
		document.forms[0].txtFaculty.focus();
		return(false);
	}
	else {		
		var ArrNameFac=document.forms[0].hidNameFacultys.value.split(",");
		var Index=ArrNameFac.length;
		var i;				
		for(i=0;i<Index;i++) {				
			if(document.forms[0].txtFaculty.value.toUpperCase()==ArrNameFac[i].toUpperCase()){
				if(confirm(strTitle+" '"+document.forms[0].txtFaculty.value+"' "+strConfirm)==false) {
					return false;					
					}
				break;
				}				
			}	
		}	
	return(true);
}
// Check for Update of Faculty
function CheckUpdateFaculty(intIDcur,txtField,strNote,strTitle,strConfirm){
	//return false;
	if(eval(txtField).value==''){
		alert(strNote);
		eval(txtField).focus();
		return(false);
	}
	else {		
		var ArrNameFac=document.forms[0].hidNameFacultys.value.split(",");
		var ArrIDFac=document.forms[0].hidIDFacultys.value.split(",");
		var Index=ArrNameFac.length;
		var i;				
		for(i=0;i<Index;i++) {				
			if(intIDcur!=ArrIDFac[i]) {
				if(eval(txtField).value.toUpperCase()==ArrNameFac[i].toUpperCase()){
					if(confirm(strTitle+" '"+eval(txtField).value+"' "+strConfirm)==false) {
						return false;					
						}
					break;
					}
				}				
			}	
		}	
	return(true);
}