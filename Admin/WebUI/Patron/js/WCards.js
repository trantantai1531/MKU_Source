/**************************************************************************
************************ Patron Card Js file *****************************
**************************************************************************/
// kiem tra du lieu hop le cua form PrintCard
function CheckAll(strMsg){
	// check ID
	if (document.forms[0].optRangePrint[0].checked){
		//if (isNaN(document.forms[0].txtFromID.value)){
		//	alert(strMsg);
		//	document.forms[0].txtFromID.value ='';
		//	document.forms[0].txtFromID.focus();
		//	return false;
		//}else{
		//	if (isNaN(document.forms[0].txtToID.value)){
		//		alert(strMsg);
		//		document.forms[0].txtToID.value ='';
		//		document.forms[0].txtToID.focus();			
		//		return false;
		//	}else{
		//		return true;
		//	}
		//}
	}
	// check Date
	if (document.forms[0].optRangePrint[1].checked){
		if (!CheckDate(document.forms[0].txtFromValidDate,'dd/mm/yyyy',strMsg)){
			return false;		
		}else{
			if (!CheckDate(document.forms[0].txtToValidDate,'dd/mm/yyyy',strMsg)){
				return false;
			}else{
				return true;
			}
		}
	}	
	// check txtPageSize
	if (isNaN(document.forms[0].txtPageSize.value)){
		alert(strMsg);
		document.forms[0].txtPageSize.value ='';
		document.forms[0].txtPageSize.focus();
		return false;
	}
	// txtCollum
	if (isNaN(document.forms[0].txtCollum.value)){
		alert(strMsg);
		document.forms[0].txtCollum.value ='';
		document.forms[0].txtCollum.focus();
		return false;
	}	
	return true;
}

function OpenDetailClass(){
	ClassWin = window.open('WClassDetail.aspx?cls=' + document.forms[0].txtClass.value ,'DetailClass', 'height=240,width=600,resizable,scrollbars=yes,screenX=50,screenY=40,top=40,left=50');
}
function NextAction(num){
	if (!isNaN(num)){
		if (parseFloat(document.forms[0].txtcurrec.value) < num){
			document.forms[0].txtcurrec.value =parseFloat(document.forms[0].txtcurrec.value)+1;
		}else{
			document.forms[0].txtcurrec.value =num;
		}
		document.forms[0].txtRec.value =document.forms[0].txtcurrec.value;
		parent.result.location.href='WCardDisplay.aspx?PgCur=' + document.forms[0].txtcurrec.value;
	}
}

function BackAction(num){
	if(!isNaN(num)){
		if (parseFloat(document.forms[0].txtcurrec.value) > 1){
			document.forms[0].txtcurrec.value =parseFloat(document.forms[0].txtcurrec.value)-1;
		}else{
			document.forms[0].txtcurrec.value =1;
		}
		document.forms[0].txtRec.value =parseFloat(document.forms[0].txtcurrec.value);
		parent.result.location.href='WCardDisplay.aspx?PgCur=' + document.forms[0].txtcurrec.value;	
	}
}

function FirstAction(num){
	if (parseFloat(document.forms[0].txtcurrec.value)!=1){
		document.forms[0].txtcurrec.value =1;
		document.forms[0].txtRec.value =document.forms[0].txtcurrec.value;
		if (!isNaN(num)){
			parent.result.location.href='WCardDisplay.aspx?PgCur=' + document.forms[0].txtcurrec.value;	
		}		
	}
}

function EndAction(num){
	if (!isNaN(num)){
		if (parseFloat(document.forms[0].txtcurrec.value)!=num){
			document.forms[0].txtcurrec.value =num;
			parent.result.location.href='WCardDisplay.aspx?PgCur=' + document.forms[0].txtcurrec.value;		
		}
	}else{
		document.forms[0].txtcurrec.value =1;
	}
	document.forms[0].txtRec.value =document.forms[0].txtcurrec.value;
}

function Action(num){
	if (!isNaN(document.forms[0].txtRec.value)){
		if(!isNaN(num)){
			if (parseFloat(document.forms[0].txtRec.value)>=1 && parseFloat(document.forms[0].txtRec.value)<= num){
				document.forms[0].txtcurrec.value =document.forms[0].txtRec.value;
				document.forms[0].txtRec.value =document.forms[0].txtcurrec.value;
				parent.result.location.href='WCardDisplay.aspx?PgCur=' + document.forms[0].txtcurrec.value;				
			}else{
				document.forms[0].txtRec.value =document.forms[0].txtcurrec.value;
			}			
		}else{
			document.forms[0].txtRec.value =document.forms[0].txtcurrec.value;
		}
	}else{
		document.forms[0].txtRec.value =document.forms[0].txtcurrec.value ;
	}
}

function Rechoose(){
	parent.parent.Workform.location.href='WCards.aspx';
}

function ConfirmPrint(){
	ConfirmWin = window.open('WCardPrintSuccessful.aspx','ConfirmPrint', 'height=240,width=600,resizable,scrollbars=yes,screenX=50,screenY=40,top=40,left=50');
}

function ClearAll() {
	document.forms[0].optID.checked = true;
	document.forms[0].txtFromID.value = '';
	document.forms[0].txtToID.value = '';
	document.forms[0].txtFromValidDate.value = '';
	document.forms[0].txtToValidDate.value = '';
	document.forms[0].txtCode.value = '';
	document.forms[0].txtFaculty.value = '';
	document.forms[0].txtPageSize.value = '';
	document.forms[0].txtCollum.value = '';
	document.forms[0].ddlPatronGroup.options.selectedIndex = 0;
	document.forms[0].ddlFormat.options.selectedIndex = 0;
	document.forms[0].ddlFormatBarcode.options.selectedIndex = 0;
	document.forms[0].ddlRotate.options.selectedIndex = 0;
	document.forms[0].ddlPicType.options.selectedIndex = 0;
	document.forms[0].ddlMaxRec.options.selectedIndex = 0;
}
function printDocument() {
  
    setTimeout('parent.result.print()', 1);
}