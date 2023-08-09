/**********************************************************************************/
/*******************		WLabelPrintSearch Js file		***********************/
/**********************************************************************************/
// Purpose: kiem tra va gan cac gia tri cho phan in nhan
// Creator: sondp
// CreatedDate: 23/02/2005
// Goto previous page
function PreviousClick(MaxPage,CurrentPage){
var CPage;
CPage=parseInt(CurrentPage);
	if(isNaN(CPage)){
		if(MaxPage>1){
			CPage=1;
		}
		else{
			CPage=0;
		}
	}
	else{
		if(CPage>parseInt(MaxPage)){
		CPage=parseInt(MaxPage);
		}
		else{
			if(CPage<=1 && MaxPage>=1){
				CPage=1;
			}
			else{
				if(MaxPage<1){
					CPage=0;
				}
				else{
					CPage=CPage-1;
				}
			}
		}
	}
	document.forms[0].txtCurrentPage.value=CPage;
	parent.Display.location.href='WLabelPrintDisplay.aspx?CurrentPage=' + document.forms[0].txtCurrentPage.value;
	return false;
}
// Goto next page
function NextClick(MaxPage,CurrentPage){
var CPage;
CPage=parseInt(CurrentPage);
	if(isNaN(CPage)){
		if(MaxPage>=1){
			CPage=1;
		}
		else{
			CPage=0;
		}
	}
	else{
		if (CPage>=MaxPage) {
		CPage=parseInt(MaxPage);
		}
		else{
			if(CPage<1){
				if(MaxPage<1){
					CPage=0;
				}
				else{
					CPage=1;
				}
			}
			else CPage=CPage+1;
		}
	}
	
	document.forms[0].txtCurrentPage.value=CPage;
	parent.Display.location.href='WLabelPrintDisplay.aspx?CurrentPage=' + document.forms[0].txtCurrentPage.value;
	return false;
}
// Goto page
function CurrentPageChange(MaxPage,CurrentPage){
var CPage;
CPage=parseInt(CurrentPage);
	if(isNaN(CPage)){	
		if(MaxPage<1){
			CPage=0;
		}
		else{
			CPage=1;
		}		
	}
	else{
		if(CPage>parseInt(MaxPage)){
		CPage=parseInt(MaxPage);
		}
		else{
			if(CPage<1 && MaxPage>0){
				CPage=1;
			}		
			else{
				aler('abc');
				CPage=0;
			}
		}	
	}	
	document.forms[0].txtCurrentPage.value=CPage;
	parent.Display.location.href='WLabelPrintDisplay.aspx?CurrentPage=' + document.forms[0].txtCurrentPage.value;
}
// BindStoreData method
function BindStoreData(LibraryID){
	document.forms[0].txtStore.value=0;
	if(LibraryID==0){//se xoa kho o day
		return(false);
	}	
	else{//load kho len drowdownlist thong qua 3 mang ID,Symbol,LibID
		document.forms[0].ddlStore.options.length=1;
		document.forms[0].ddlStore.options[0].text='             ';
		document.forms[0].ddlStore.options[0].value=0;
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
		return true;		
	}
}
// Check for print label function
function PrintLabel(){
//default: optCodeItem.checked=true->0, optCopyNumber.checked==true->1, optElse.checked==true->2
	var Mode;
	if (document.forms[0].optCodeItem.checked==true){
		Mode=0;//optCodeItem.checked==true
	}
	if(document.forms[0].optCopyNumber.checked==true){
		Mode=1;//optCopyNumber.checked==true
	}
	if(document.forms[0].optElse.checked==true){
		Mode=2;//optElse.checked==true
	}
	return true;
}
function Resetform() {
		document.forms[0].txtFromCodeItem.value="";
		document.forms[0].txtToCodeItem.value="";
		document.forms[0].txtFromCopyNumber.value="";
		document.forms[0].txtToCopyNumber.value="";
		document.forms[0].txtElse.value="";
		document.forms[0].ddlItemType.selectedIndex=0;
		document.forms[0].ddlFormal.selectedIndex=0;
		document.forms[0].reset();
}

function printDocument() {
    setTimeout('parent.Display.print()', 1);
}