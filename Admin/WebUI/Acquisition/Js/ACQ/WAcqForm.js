/**********************************************************************************/
/***********************		WAcqForm Js file		***************************/
/**********************************************************************************/

//btnPrevious Click
function PreviousClick(MaxPage,CurrentPage){
var CPage;
CPage=parseInt(CurrentPage);
	if(isNaN(CPage)){
		document.forms[0].txtCurrentPage.value=1;
		CPage=1;
	}
	else{
		if(CPage>parseInt(MaxPage)){
		CPage=parseInt(MaxPage);
		}
		else{
			if(CPage<=1){
				CPage=1;
			}
			else{
				CPage=CPage-1;
			}
		}
	}
	
	document.forms[0].txtCurrentPage.value=CPage;
	parent.Display.location.href='WACQResult.aspx?CurrentPage=' + document.forms[0].txtCurrentPage.value;
	return false;
}
//btnNext Click
function NextClick(MaxPage,CurrentPage){
var CPage;
CPage=parseInt(CurrentPage);
	if(isNaN(CPage)){
		document.forms[0].txtCurrentPage.value=1;
		CPage=1;
	}
	else{
		if (CPage>=MaxPage) {
		CPage=parseInt(MaxPage);
		}
		else{
			if(CPage<1){CPage=1;
			}
			else CPage=CPage+1;
		}
	}
	
	document.forms[0].txtCurrentPage.value=CPage;
	parent.Display.location.href='WACQResult.aspx?CurrentPage=' + document.forms[0].txtCurrentPage.value;
	return false;
}
//txtCurrentPage Change
function CurrentPageChange(MaxPage,CurrentPage){
var CPage;
CPage=parseInt(CurrentPage);
	if(isNaN(CPage)){
		document.forms[0].txtCurrentPage.value=1;
		CPage=1;
	}
	else{
		if(CPage>parseInt(MaxPage)){
		CPage=parseInt(MaxPage);
		}
		else{
			if(CPage<1){
				CPage=1;
			}		
		}	
	}	
	document.forms[0].txtCurrentPage.value=CPage;
	parent.Display.location.href='WACQResult.aspx?CurrentPage=' + document.forms[0].txtCurrentPage.value;
	return false;
}
//clear data in form WDKCBAcquisitionReportedDisplay.aspx when btnReset clicked
function ClearData(){
	document.forms[0].optDKCB.checked=true;
	document.forms[0].optEachBook.checked=false;
	document.forms[0].txtFromDKCB.value='';
	document.forms[0].ddlLibrary.options[0].selected=true;
	document.forms[0].ddlStore.options.length=0;
	document.forms[0].txtToDKCB.value='';
	document.forms[0].txtFromAcquisitionTime.value='';
	document.forms[0].txtToAcquisitionTime.value='';
	document.forms[0].ddlFormal.options[0].selected=true;
	document.forms[0].ddlOrder.options[0].selected=true;
	document.forms[0].ddlBy.options[0].selected=true;
	document.forms[0].txtPage.value=20;
	return false;
}
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
// Check Valid Data function
function CheckValidData(strFromDate,strToDate,strPageSize){
	// Check from date
	if(!CheckDate(document.forms[0].txtFromAcquisitionTime,'dd/mm/yyyy',strFromDate)){
		document.forms[0].txtFromAcquisitionTime.focus();
		return(false);
	}
	// Check to date
	if(!CheckDate(document.forms[0].txtToAcquisitionTime,'dd/mm/yyyy',strToDate)){
		document.forms[0].txtToAcquisitionTime.focus();
		return(false);
	}
	if(isNaN(document.forms[0].txtPage.value) || parseInt(document.forms[0].txtPage.value)==0){
		alert(strPageSize);
		document.forms[0].txtPage.focus();
		return false;
	}
	return true;
}