/**************************************************************************
************************ Barcode Search Js file ***************************
**************************************************************************/
function SetFocusIt(control){
	control.focus();
}

function GenRanNum(strIdlength)
{
var str;
str='';
for(i = 1;i<=strIdlength;i++){ 
	str=str + (String)(parseInt(9 * Math.random()+48));		
      } 
 return(str);
}

function ValidData(strMsg){
	
	if (document.forms[1].BarCode[0].checked){
		if (!CheckDate(document.forms[0].txtFromDate,'dd/mm/yyyy',strMsg)){
			return false;
		}
		if (!CheckDate(document.forms[0].txtToDate,'dd/mm/yyyy',strMsg)){
			return false;
		}		
	}
	return true;
}

function GoPreviousPage(){
	parent.parent.Workform.location.href='WBarcodeSearch.aspx';
}

function ClearAll() {
	document.forms[0].txtFromIDs.value = '';
	document.forms[0].txtToIDs.value = '';
	document.forms[0].txtFromDate.value = '';
	document.forms[0].txtToDate.value = '';
	document.forms[0].txtID.value = '';
	document.forms[0].ddlType.options.selectedIndex = 0;
	document.forms[0].ddlRotate.options.selectedIndex = 0;
	document.forms[0].ddlImgType.options.selectedIndex = 0;
	document.forms[0].ddlBoundResult.options.selectedIndex = 0;
	document.forms[0].ddlOrderBy.options.selectedIndex = 0;
	document.forms[0].txtHeight.value = 70;
	document.forms[0].txtWidth.value = 1;
	document.forms[0].txtCol.value = 5;
	document.forms[0].txtOnPage.value = 20;
}