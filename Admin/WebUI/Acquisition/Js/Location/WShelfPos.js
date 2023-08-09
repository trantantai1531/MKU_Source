function CheckValue(field,strNote) {
	if (isNaN(eval(field).value) || parseFloat(eval(field).value) < 0) { 
		alert(strNote);		
		eval(field).focus(); 
		return false;
		} 	 
	return true;	
}
function CheckAddNew(strNote,strNote1) {
	if (document.forms[0].txtShelf.value=="") {
		alert(strNote);
		document.forms[0].txtShelf.focus();
		return false;
	}
	if (document.forms[0].txtShelfWidth.value=="") {
		alert(strNote);
		document.forms[0].txtShelfWidth.focus();
		return false;
	}
	else {
		if(!CheckValue('document.forms[0].txtShelfWidth',strNote1)) 
			return false;			
	}
	if (document.forms[0].txtShelfDepth.value=="") {
		alert(strNote);
		document.forms[0].txtShelfDepth.focus();
		return false;
	}
	else {
		if(!CheckValue('document.forms[0].txtShelfDepth',strNote1)) 
			return false;			
	}
	if (document.forms[0].txtTopCoor.value=="") {
		alert(strNote);
		document.forms[0].txtTopCoor.focus();
		return false;
	}
	else {
		if(!CheckValue('document.forms[0].txtTopCoor',strNote1)) 
			return false;			
	}
	if (document.forms[0].txtLeftCoor.value=="") {
		alert(strNote);
		document.forms[0].txtLeftCoor.focus();
		return false;
	}
	else {
		if(!CheckValue('document.forms[0].txtLeftCoor',strNote1)) 
			return false;			
	}
	return true;
}

function ResetForm() {
	document.forms[0].txtShelf.value="";
	document.forms[0].txtShelfWidth.value="";
	document.forms[0].txtShelfDepth.value="";
	document.forms[0].txtTopCoor.value="";
	document.forms[0].txtLeftCoor.value="";
	document.forms[0].ddlDirection.options.selectedIndex=0;	
	return false;	
}
function CheckUpdate(field,strNote,strNote1) {
	if (eval(field+'txtdtgShelf').value=="") {
		alert(strNote);
		eval(field+'txtdtgShelf').focus();
		return false;
	}
	if (eval(field+'txtdtgWidth').value =="") {
		alert(strNote);
		eval(field+'txtdtgWidth').focus();
		return false;	
		}
	else {
		if(!CheckValue(field+'txtdtgWidth',strNote1)) 
			return false;				
	}
	if (eval(field+'txtdtgDepth').value =="") {
		alert(strNote);
		eval(field+'txtdtgDepth').focus();
		return false;	
		}
	else {
		if(!CheckValue(field+'txtdtgDepth',strNote1)) 
			return false;				
	}
	if (eval(field+'txtdtgTopCoor').value =="") {
		alert(strNote);
		eval(field+'txtdtgTopCoor').focus();
		return false;	
		}
	else {
		if(!CheckValue(field+'txtdtgTopCoor',strNote1)) 
			return false;				
	}
	if (eval(field+'txtdtgLeftCoor').value =="") {
		alert(strNote);
		eval(field+'txtdtgLeftCoor').focus();
		return false;	
		}
	else {
		if(!CheckValue(field+'txtdtgLeftCoor',strNote1)) 
			return false;				
	}	
	return true;	
}

function SetLeftTopCoor(top,left) {
	var index=parseInt(opener.document.forms[0].hidIndex.value);		
	if (index>=0) {	
		index=index+2;		
		if (eval('opener.document.forms[0].dtgContent__ctl'+index+'_txtdtgLeftCoor')) {
			eval('opener.document.forms[0].dtgContent__ctl'+index+'_txtdtgLeftCoor').value=left;
			eval('opener.document.forms[0].dtgContent__ctl'+index+'_txtdtgTopCoor').value=top;
		}
	}
	else {		
		opener.document.forms[0].txtLeftCoor.value=left;
		opener.document.forms[0].txtTopCoor.value=top;
	}
}

function ShowImg() {	
	var LocID=document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.selectedIndex].value;
	OpenWindow('WShowShelfSchema.aspx?LocID='+LocID,'ShowSchema',750,500,30,30);
	return false;
}
function CalLeftTop(strNote,strNote1) {

	// check valid field
	if (document.forms[0].txtTopCoor.value=="") {
		alert(strNote);
		document.forms[0].txtTopCoor.focus();
		return false;
	}
	else {
		if(!CheckValue('document.forms[0].txtTopCoor',strNote1)) 
			return false;			
	}
	if (document.forms[0].txtLeftCoor.value=="") {
		alert(strNote);
		document.forms[0].txtLeftCoor.focus();
		return false;
	}
	else {
		if(!CheckValue('document.forms[0].txtLeftCoor',strNote1)) 
			return false;			
	}
	
	var intShelfLeftCoor=0;
	var intShelfTopCoor=0;
	var intTopCoor=document.forms[0].txtTopCoor.value;
	var intLeftCoor=document.forms[0].txtLeftCoor.value;
	var intImgHeight =parseInt(document.forms[0].hidImgHeight.value);	
	var intImgWidth	=parseInt(document.forms[0].hidImgWidth.value);
	var dbImgHeightMetter=parseFloat(document.forms[0].hidImgHeightMetter.value);
	var dbImgWidthMetter=parseFloat(document.forms[0].hidImgWidthMetter.value);	
	
	intShelfTopCoor = parseInt(document.forms[0].hidTopCoor.value) + Math.round((intImgHeight/dbImgHeightMetter)*intTopCoor);
	intShelfLeftCoor = parseInt(document.forms[0].hidLeftCoor.value) + Math.round((intImgWidth/dbImgWidthMetter)*intLeftCoor);	
	
	SetLeftTopCoor(intShelfTopCoor,intShelfLeftCoor);
	return false;
}