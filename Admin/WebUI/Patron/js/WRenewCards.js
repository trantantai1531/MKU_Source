/**************************************************************************
************************ Renew Card Js file ***********************
**************************************************************************/
// This function used to loaddata into child dropdownlist when index of parent dropdownlist changed 
// Created by Oanhtn
// Created Date: 15/10/2003
// Last Modified Date: 16/10/2003
// Input: 
//		- intParentSelectedValue: Selected value of Parent dropdownlist
//		- intParentIndex: Index of Parent dropdownlist
//		- strAdd: Add string at top of child dropdownlist

function LoadBack(intParentSelectedValue, intParentIndex, strAdd) {
	var j;
	eval('document.forms[0].ddlOptionFieldValue' + intParentIndex + '.options').length = 1;
	eval('document.forms[0].ddlOptionFieldValue' + intParentIndex + '.options[0]').value = 0;
	eval('document.forms[0].ddlOptionFieldValue' + intParentIndex + '.options[0]').text = strAdd;
	for (j = 0; j < ArrOptionIndex.length; j++) {		
		if (ArrOptionIndex[j] == intParentSelectedValue) {
			eval('document.forms[0].ddlOptionFieldValue' + intParentIndex + '.options').length = eval('document.forms[0].ddlOptionFieldValue' + intParentIndex + '.options').length + 1;
			eval('document.forms[0].ddlOptionFieldValue' + intParentIndex + '.options[document.forms[0].ddlOptionFieldValue' + intParentIndex + '.options.length - 1]').value = ArrValue[j];
			eval('document.forms[0].ddlOptionFieldValue' + intParentIndex + '.options[document.forms[0].ddlOptionFieldValue' + intParentIndex + '.options.length - 1]').text = ArrText[j];
		}
	}
}

// This function used to 
//	- Check null value of new text value, new date value, new option value
//  - Check selected patron
// Created by Oanhtn
// Created Date: 13/10/2003
// Last Modified Date: 13/10/2003
// Input: 
//		- DataGrid Infor: strDtgName, strOptionName, intMax
//		- 2 string value: strMess1, strMess2
// Ouput:
//		- Boolean value
// For Extend form
function CheckAllExtend(strDtgName, strOptionName, intMax, strMess1, strMess2) {
	if (document.forms[0].ddlExtendedMonth.selectedIndex==0 && document.forms[0].ddlExtendedYear.selectedIndex==0 && document.forms[0].txtExtendedDate.value=='') {
			alert(strMess1);
			return false;		
	}	
	
	if (!CheckOptionsNullByCssClass('ckb-value', 'cbkOption', 2, 50, strMess2)) {
	     return false;
	}
	   
	return true;
}

function ClearAll() {
	document.forms[0].txtFieldValue1.focus();
	document.forms[0].ddlFieldName1.options.selectedIndex = 0;
	document.forms[0].txtFieldValue1.value = '';
	document.forms[0].ddlFieldName2.options.selectedIndex = 0;
	document.forms[0].txtFieldValue2.value = '';
	document.forms[0].ddlFieldName3.options.selectedIndex = 0;
	document.forms[0].ddlFieldOpeFrom1.options.selectedIndex = 0;
	document.forms[0].txtFieldValueFrom1.value = '';
	document.forms[0].txtFieldValueTo1.value = '';
	document.forms[0].ddlFieldName4.options.selectedIndex = 0;
	document.forms[0].ddlFieldOpeFrom2.options.selectedIndex = 0;
	document.forms[0].txtFieldValueFrom2.value = '';
	document.forms[0].txtFieldValueTo2.value = '';	
	document.forms[0].ddlFieldName5.options.selectedIndex = 0;
	document.forms[0].ddlFieldName6.options.selectedIndex = 0;
	document.forms[0].ddlOrderBy.options.selectedIndex = 0;
	document.forms[0].ddlMaxRecord.options.selectedIndex = 0;
	document.forms[0].ddlOperator1.options.selectedIndex = 0;
	document.forms[0].ddlOperator2.options.selectedIndex = 0;
	document.forms[0].ddlOperator3.options.selectedIndex = 0;
	document.forms[0].ddlOperator4.options.selectedIndex = 0;
	document.forms[0].ddlOperator5.options.selectedIndex = 0;
	document.forms[0].ddlExtendedMonth.options.selectedIndex = 0;
	document.forms[0].ddlExtendedYear.options.selectedIndex = 0;
	document.forms[0].txtExtendedDate.value = '';
}
// If find an check object, check, if not, through away

function CheckAllOptionsVisible_1(strDtgName, strOptionName, intStart, intMax){	
	var intCounter;	
	var blnStatus;	
						
	if (eval('document.forms[0].CheckAll').checked) 
		blnStatus = true;
	else
		blnStatus = false;			
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName)){			
			eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked = blnStatus;			
		}			
	}
}