function CheckSelected() {	
	var inti;
	var intCheckSelected=0;		
	//var intMax=parseInt(parent.display.document.forms[0].hidCountID.value)+1;			
	var intMax=parseInt(parent.display.document.forms[0].hidCountID.value);				
	for(inti=2;inti<intMax;inti++) {	
		if(inti<10)	
		{
			if (eval('parent.display.document.forms[0].dtgResult_ctl0' + inti + '_chkCopyID')) {
				if (eval('parent.display.document.forms[0].dtgResult_ctl0' + inti + '_chkCopyID').checked) {
					intCheckSelected=1;										
					if (eval('parent.display.document.forms[0].dtgResult_ctl0' + inti + '_txtdtgCopynumber')) {
						if (trim(eval('parent.display.document.forms[0].dtgResult_ctl0' + inti + '_txtdtgCopynumber').value) == '') {
							alert(strNote1);						
							eval('parent.display.document.forms[0].dtgResult_ctl0' + inti + '_txtdtgCopynumber').focus();
							return false;
						}				
					}
				}			
			}
		}
		else{
			if (eval('parent.display.document.forms[0].dtgResult_ctl' + inti + '_chkCopyID')) {
				if (eval('parent.display.document.forms[0].dtgResult_ctl' + inti + '_chkCopyID').checked) {
					intCheckSelected=1;										
					if (eval('parent.display.document.forms[0].dtgResult_ctl' + inti + '_txtdtgCopynumber')) {
						if (trim(eval('parent.display.document.forms[0].dtgResult_ctl' + inti + '_txtdtgCopynumber').value) == '') {
							alert(strNote1);						
							eval('parent.display.document.forms[0].dtgResult_ctl' + inti + '_txtdtgCopynumber').focus();
							return false;
						}				
					}
				}			
			}
		}
	}
	
	if (intCheckSelected==1) return true;
	alert(strNote);	
	return false;
	
}
function Lock(){
	
	if (CheckSelected()) {		
		var curURL;
		curURL=parent.display.location.href;
		if (curURL.indexOf("WNothing.aspx")>=0){
			return false;
		}				
		parent.display.document.forms[0].txtAction.value='Lock';
		parent.display.document.forms[0].hidTotalCopyIDs.value=GetIDs('dtgResult','chkCopyID',parent.display.document.forms[0].hidCountID.value);			
		parent.display.document.forms[0].action='WProcInventoryDisplay.aspx?Action=Lock&CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value;
		parent.display.document.forms[0].submit();
		return(false);
	}
	return false;
}

function UnLock(){
	if (CheckSelected()) {
		var curURL;
		curURL=parent.display.location.href;
		if (curURL.indexOf("WNothing.aspx")>=0){
			return false;
		}	
		parent.display.document.forms[0].txtAction.value='Unlock';
		parent.display.document.forms[0].hidTotalCopyIDs.value=GetIDs('dtgResult','chkCopyID',parent.display.document.forms[0].hidCountID.value);			
		parent.display.document.forms[0].action='WProcInventoryDisplay.aspx?Action=Unlock&CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value;
		parent.display.document.forms[0].submit();
		return(false);
	}
	return false;
}

function Delete(){
	if (CheckSelected()) {
		var curURL;
		curURL=parent.display.location.href;
		if (curURL.indexOf("WNothing.aspx")>=0){
			return false;
		}	
		parent.display.document.forms[0].txtAction.value='Delete';
		parent.display.document.forms[0].hidTotalCopyIDs.value=GetIDs('dtgResult','chkCopyID',parent.display.document.forms[0].hidCountID.value);			
		parent.display.document.forms[0].action='WProcLostDisplay.aspx?Action=Delete&CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value;
		parent.display.document.forms[0].submit();
		return(false);
	}
	return false;
}

function Remove(){
	var curURL;
	var reasonID;	
	curURL=parent.display.location.href;
	if (CheckSelected()) {
		if (curURL.indexOf("WNothing.aspx")>=0){
			return false;
		}
		parent.display.document.forms[0].txtAction.value='Remove';
		reasonID=document.forms[0].ddlReasonID.options[document.forms[0].ddlReasonID.options.selectedIndex].value;
		if (reasonID){
			parent.display.document.forms[0].txtReasonID.value=reasonID;
		}
		parent.display.document.forms[0].hidTotalCopyIDs.value=GetIDs('dtgResult','chkCopyID',parent.display.document.forms[0].hidCountID.value);			
		parent.display.document.forms[0].action='WProcInventoryDisplay.aspx?Action=Remove&CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value + '&Reason=' + reasonID;
		parent.display.document.forms[0].submit();		
		return(false);
	}
	return false;
}

function Restore(){	
	if (CheckSelected()) {
		var curURL;
		curURL=parent.display.location.href;
		if (curURL.indexOf("WNothing.aspx")>=0){
			return false;
		}
		parent.display.document.forms[0].txtAction.value='Restore';
		parent.display.document.forms[0].hidTotalCopyIDs.value=GetIDs('dtgResult','chkCopyID',parent.display.document.forms[0].hidCountID.value);				
		parent.display.document.forms[0].hidTotalCopyNumber.value=GetCopyNumbers('dtgResult','chkCopyID',parent.display.document.forms[0].hidCountID.value);				
		parent.display.document.forms[0].action='WProcLostDisplay.aspx?Action=Restore&CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value;
		parent.display.document.forms[0].submit();
		return(false);		
	}
		return false;	
}

function RestoreUnlock(){	
	if (CheckSelected()) {
		var curURL;
		curURL=parent.display.location.href;
		if (curURL.indexOf("WNothing.aspx")>=0){
			return false;
		}
		parent.display.document.forms[0].txtAction.value='RestoreUnlock';
		parent.display.document.forms[0].hidTotalCopyIDs.value=GetIDs('dtgResult','chkCopyID',parent.display.document.forms[0].hidCountID.value);				
		parent.display.document.forms[0].hidTotalCopyNumber.value=GetCopyNumbers('dtgResult','chkCopyID',parent.display.document.forms[0].hidCountID.value);				
		parent.display.document.forms[0].action='WProcLostDisplay.aspx?Action=RestoreUnlock&CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value;
		parent.display.document.forms[0].submit();
		return(false);		
	}
	return false;
}

function Receive(){				
if (CheckSelected()) {		
	var curURL;
		curURL=parent.display.location.href;
		if (curURL.indexOf("WNothing.aspx")>=0){
			return false;
		}
		parent.display.document.forms[0].txtAction.value='Receive';
		parent.display.document.forms[0].hidTotalCopyIDs.value=GetIDs('dtgResult','chkCopyID',parent.display.document.forms[0].hidCountID.value);				
		//parent.display.document.forms[0].hidTotalCopyNumber.value=GetCopyNumbers('dtgResult','chkCopyID',parent.display.document.forms[0].hidCountID.value);				
		parent.display.document.forms[0].action='WProcReceiveDisplay.aspx?Action=Receive&CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value;
		parent.display.document.forms[0].submit();
		return(false);		
	}	
	return false;
}

function ReceiveUnlock(){	
	if (CheckSelected()) {
		var curURL;
		curURL=parent.display.location.href;
		if (curURL.indexOf("WNothing.aspx")>=0){
			return false;
		}		
		parent.display.document.forms[0].txtAction.value='ReceiveUnlock';
		parent.display.document.forms[0].hidTotalCopyIDs.value=GetIDs('dtgResult','chkCopyID',parent.display.document.forms[0].hidCountID.value);		
		//parent.display.document.forms[0].hidTotalCopyNumber.value=GetCopyNumbers('dtgResult','chkCopyID',parent.display.document.forms[0].hidCountID.value);				
		parent.display.document.forms[0].action='WProcReceiveDisplay.aspx?Action=ReceiveUnlock&CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value;
		parent.display.document.forms[0].submit();	
		return(false);
	}
	return false;
}

function Search(){
	var curURL;	
	curURL=self.location.href;	
	if (curURL.indexOf("Mode=0")>=0){
		parent.display.location.href='WCNSearch.aspx?Mode=0';
	}
	if (curURL.indexOf("Mode=1")>=0){
		parent.display.location.href='WCNSearch.aspx?Mode=1';
	}
	if (curURL.indexOf("Mode=2")>=0){
		parent.display.location.href='WCNSearch.aspx?Mode=2';
	}
	return false;
}

// This function used to check any checkbox on this form have been selected
// Created by: Sondp
// Created date: 24/11/2005
// Input: 
//		- strDtgName: name of datagrid 
//		- strOptionName: name of checkbox
//		- intMax: number of checkboxs on this form
// Output: Boolean value
//		- true if atlease one checkbox selected
function GetIDs(strDtgName, strOptionName, intMax){ 
 var intCounter; 
 blnStatus = false;
 strIDs='';  
 strCopynumbers='';
 for(intCounter = 2; intCounter < intMax; intCounter++) { 
  if(intCounter<10){  
   if (eval('parent.display.document.forms[0].dtgResult_ctl0' + intCounter + '_chkCopyID')) {
    if (eval('parent.display.document.forms[0].dtgResult_ctl0' + intCounter + '_chkCopyID').checked) {
     strIDs = strIDs + eval('parent.display.document.forms[0].dtgResult_ctl0' + intCounter + '_hidCopyID').value + ',';
     //strCopynumbers = strCopynumbers + eval('parent.display.document.forms[0].dtgResult__ctl' + intCounter + '_hidCopyNumber').value + ',';
    }
   }
  }
  else{
   if (eval('parent.display.document.forms[0].dtgResult_ctl' + intCounter + '_chkCopyID')) {
    if (eval('parent.display.document.forms[0].dtgResult_ctl' + intCounter + '_chkCopyID').checked) {
     strIDs = strIDs + eval('parent.display.document.forms[0].dtgResult_ctl' + intCounter + '_hidCopyID').value + ',';
     //strCopynumbers = strCopynumbers + eval('parent.display.document.forms[0].dtgResult__ctl' + intCounter + '_hidCopyNumber').value + ',';
    }
   }
  }
    }                 
    return strIDs;
}

// This function used to check any checkbox on this form have been selected
// Created by: Sondp
// Created date: 24/11/2005
// Input: 
//		- strDtgName: name of datagrid 
//		- strOptionName: name of checkbox
//		- intMax: number of checkboxs on this form
// Output: Boolean value
//		- true if atlease one checkbox selected
function GetCopyNumbers(strDtgName, strOptionName, intMax){	
	var intCounter;	
	blnStatus = false;
	strCopyNumbers='';		
	for(intCounter = 2; intCounter < intMax; intCounter++) {			
		if (eval('parent.display.document.forms[0].dtgResult__ctl' + intCounter + '_chkCopyID')){
			if (eval('parent.display.document.forms[0].dtgResult__ctl' + intCounter + '_chkCopyID').checked) {		
				strCopyNumbers = strCopyNumbers + eval('parent.display.document.forms[0].dtgResult__ctl' + intCounter + '_txtdtgCopynumber').value + ',';			
			}
		}
    }    
    return strCopyNumbers;
}

// Next click
		
		function NextPage(intMaxPage,LibID,LocID,Shelf,strNotIsNumeric,strPageMax,bytMode){			
			if (isNaN(parent.mainfunc.document.forms[0].txtCurrentPage.value)) {				
				alert(strNotIsNumeric);
				parent.mainfunc.document.forms[0].txtCurrentPage.focus();				
				return false;
			}
			if (parseInt(parent.mainfunc.document.forms[0].txtCurrentPage.value) < intMaxPage) {
				parent.mainfunc.document.forms[0].txtCurrentPage.value = parseInt(parent.mainfunc.document.forms[0].txtCurrentPage.value) + 1; 
				switch(bytMode){
					case 0:
						parent.display.document.forms[0].action='WProcReceiveDisplay.aspx?CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value ;													
						parent.display.document.forms[0].submit();
						break;
					case 1:						
						parent.display.document.forms[0].action='WProcInventoryDisplay.aspx?CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value ;														
						parent.display.document.forms[0].submit();
						break;
					case 2:
						parent.display.location.href='WProcLostDisplay.aspx?CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value + '&LibID=' + LibID +'&LocID=' + LocID + '&Shelf=' + Shelf;			
						break;
					default:
						parent.display.location.href='../../WNothing.aspx';			
				}				
				//parent.display.document.forms[0].submit();
			} else {
				alert(strPageMax);
			}
				parent.mainfunc.document.forms[0].txtCurrentPage.focus();
			return false;			
		}
		// Previous click
		function PreviousPage(intMaxPage,LibID,LocID,Shelf,strNotIsNumeric,strPage0,bytMode){
			if (isNaN(parent.mainfunc.document.forms[0].txtCurrentPage.value)) {
			alert(strNotIsNumeric);
			parent.mainfunc.document.forms[0].txtCurrentPage.focus();
			return false;
			}
			if (parseInt(document.forms[0].txtCurrentPage.value) > 1) {
				parent.mainfunc.document.forms[0].txtCurrentPage.value = parseInt(parent.mainfunc.document.forms[0].txtCurrentPage.value) - 1; 
				switch(bytMode){
					case 0:
						parent.display.document.forms[0].action='WProcReceiveDisplay.aspx?CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value ;													
						parent.display.document.forms[0].submit();
						break;
					case 1:						
						parent.display.document.forms[0].action='WProcInventoryDisplay.aspx?CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value ;														
						parent.display.document.forms[0].submit();
						break;
					case 2:
						parent.display.location.href='WProcLostDisplay.aspx?CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value + '&LibID=' + LibID +'&LocID=' + LocID + '&Shelf=' + Shelf;			
						break;
					default:
						parent.display.location.href='../../WNothing.aspx';			
				}				
				//parent.display.document.forms[0].submit();	
			} else {
				alert(strPage0);
			}
			parent.mainfunc.document.forms[0].txtCurrentPage.focus();
			return false;					
		}
		// Text change
		function CurrentPageChange(intMaxPage,LibID,LocID,Shelf,strNotIsNumeric,strNote,bytMode) {							
			if (isNaN(parent.mainfunc.document.forms[0].txtCurrentPage.value)) {
				alert(strNotIsNumeric);
				parent.mainfunc.document.forms[0].txtCurrentPage.focus();
				return false;
				}
			if ((parseInt(parent.mainfunc.document.forms[0].txtCurrentPage.value) <= intMaxPage)&&(parseInt(parent.mainfunc.document.forms[0].txtCurrentPage.value) >=1)) {
			switch(bytMode){
					case 0:
						parent.display.document.forms[0].action='WProcReceiveDisplay.aspx?CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value ;													
						parent.display.document.forms[0].submit();
						break;
					case 1:						
						parent.display.document.forms[0].action='WProcInventoryDisplay.aspx?CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value ;														
						parent.display.document.forms[0].submit();
						break;
					case 2:
						parent.display.location.href='WProcLostDisplay.aspx?CurPage='+ parent.mainfunc.document.forms[0].txtCurrentPage.value + '&LibID=' + LibID +'&LocID=' + LocID + '&Shelf=' + Shelf;			
						break;
					default:
						parent.display.location.href='../../WNothing.aspx';			
				}				
				//parent.display.document.forms[0].submit();				
			} else {
				alert(strNote);
			}
			parent.mainfunc.document.forms[0].txtCurrentPage.focus();
			return false;
		}