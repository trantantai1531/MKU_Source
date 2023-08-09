function OnCheckParent(val,check) {
	var intTotalRec;	
	var intCounter;
	var strParentPFC=val;
	var strPFC;
	intTotalRec = document.forms[0].chkPickedFieldCode.length;
	if (intTotalRec > 0) {
		for (intCounter = 0; intCounter < intTotalRec; intCounter++) {
			strPFC=document.forms[0].chkPickedFieldCode[intCounter].value;
			if ((strPFC.length>3) && (strPFC.substring(0,3)==strParentPFC)) {
				document.forms[0].chkPickedFieldCode[intCounter].checked=check;
				document.forms[0].chkPickedFieldCode[intCounter].disabled=check;
			}
		}
	}
}
/*
	UpdateForm funtion
	Purpose: Update senform
*/
function UpdateForm() {
	// Declare variables
	var intTotalRec;
	var intCounter;
	var strFieldDefaultValues="";
	var strFieldIndicatorValues="";
	var strPickedFieldCodes="";
	var strMandatoryFieldCodes="";
	var strTextBoxFields="";
	var strExcludeFields="";
	var strPFC;
	var strParentPFC;
	var pos;
	var pos1;
	
	// Process
	//get fieldcode will include and exclude
	intTotalRec = document.forms[0].chkPickedFieldCode.length;
	strExcludeFields = "";
	strPickedFieldCodes = "";
	if (intTotalRec > 0) {
		for (intCounter = 0; intCounter < intTotalRec; intCounter++) {
			if (!document.forms[0].chkPickedFieldCode[intCounter].checked) {				
				strPFC=document.forms[0].chkPickedFieldCode[intCounter].value;
				pos=strPickedFieldCodes.indexOf(strParentPFC + ",");
				if (pos<0)
					strPickedFieldCodes = strPickedFieldCodes + strPFC + ",";
				
			}
		}
		for (intCounter = 0; intCounter < intTotalRec; intCounter++) {
			if (document.forms[0].chkPickedFieldCode[intCounter].checked) {
				strPFC=document.forms[0].chkPickedFieldCode[intCounter].value;
				strExcludeFields = strExcludeFields + strPFC + ",";			
				// kiem tra xem cac truong con bi xoa ma truong cha khong bi xoa thi xoa truong cha di
				//trong truong hop con mot truong con khong bi xoa thi khong duoc xoa truong cha
				if (strPFC.length>3) {
					strParentPFC=strPFC.substring(0,3);					
					pos=strPickedFieldCodes.indexOf(strParentPFC + ",");
					//kiem tra ton tai truong cha trong day khong
					if (pos>=0) {
						//neu ton tai kiem tra xem co truong con trong do khong
						pos=strPickedFieldCodes.indexOf(strParentPFC,pos+1);
						if (pos==-1) {
							//neu khong ton tai thi xoa truong cha di
							strPickedFieldCodes=strPickedFieldCodes.replace(strParentPFC + ",","");
						}
					}		
				}				
			}
		}		
	}		
	// Default value
	strFieldDefaultValues = "";
	strFieldIndicatorValues = "";
	strMandatoryFieldCodes = "";
	strTextBoxFields = "";	
	intTotalRec = document.forms[0].txtFieldDefault.length;
	if (intTotalRec > 0) {
		for (intCounter = 0; intCounter < intTotalRec; intCounter++) {
			// strPickedFieldCodes
			strPFC=document.forms[0].chkMandatoryFieldCode[intCounter].value;									
			// kiem tra xem no co bi xoa hay khong
			pos=strPickedFieldCodes.indexOf(strPFC + ",");
			if (pos>=0) {
				// Default and indicator value
				if (trim(document.forms[0].txtFieldDefault[intCounter].value)!="") {
					strFieldDefaultValues = strFieldDefaultValues + strPFC + "::" + document.forms[0].txtFieldDefault[intCounter].value + ":::";
					if (trim(document.forms[0].txtFieldIndicators[intCounter].value)=="") 
						strFieldIndicatorValues = strFieldIndicatorValues + strPFC + "::  :::";					
					else
						strFieldIndicatorValues = strFieldIndicatorValues + strPFC + "::" + document.forms[0].txtFieldIndicators[intCounter].value + ":::";					
				}
				// chkMandatoryFieldCode					
				if (document.forms[0].chkMandatoryFieldCode[intCounter].checked) {
					strMandatoryFieldCodes = strMandatoryFieldCodes + strPFC+ ",";
				}
				// chkTextBoxFields
				if (document.forms[0].chkIsTextBox[intCounter].checked) {
					strTextBoxFields = strTextBoxFields + strPFC + ",";
				}									
			}
		}
	}		
	// Load hidden fields
	document.forms[0].txtPickedFields.value = strPickedFieldCodes;
	document.forms[0].txtMandatoryFields.value = strMandatoryFieldCodes;
	document.forms[0].txtFieldDefaultValues.value = strFieldDefaultValues;
	document.forms[0].txtFieldIndicatorValues.value = strFieldIndicatorValues;
	document.forms[0].txtTextBoxFields.value = strTextBoxFields;		

	// Loadback sentform
	opener.document.forms[0].txtExcludeFields.value = strExcludeFields;		
	opener.document.forms[0].txtPickedFields.value = strPickedFieldCodes;
	opener.document.forms[0].txtMandatoryFields.value = strMandatoryFieldCodes;
	opener.document.forms[0].txtFieldDefaultValues.value = strFieldDefaultValues;
	opener.document.forms[0].txtFieldIndicatorValues.value = strFieldIndicatorValues;
	opener.document.forms[0].txtTextBoxFields.value = strTextBoxFields;
	return false;
}

/*
	LoadForm function
	Purpose: load default value for all form's controls (textbox, checkbox)
*/

function LoadForm() {
	// Declare variables
	var strPickedFieldCodes;
	var strMandatoryFieldCodes;
	var strFieldDefaultValues;
	var strFieldIndicatorValues;
	var strTextBoxFields;	
	var strFieldCode;
	var intTotal;
	var intCounter;
	var intIndex1;
	var intIndex2;
	var strTempo;

	// Assign variables's value from hidden fields
	strPickedFieldCodes = document.forms[0].txtPickedFields.value;
	strMandatoryFieldCodes = document.forms[0].txtMandatoryFields.value;
	strFieldDefaultValues = document.forms[0].txtFieldDefaultValues.value;
	strFieldIndicatorValues = document.forms[0].txtFieldIndicatorValues.value;
	strTextBoxFields = document.forms[0].txtTextBoxFields.value;	
	if (strFieldDefaultValues.length > 2) {
		intTotalRec = document.forms[0].txtFieldDefault.length;
		// Load field default value
		//001::a:::100$a::$lenta:::100$b::$lenta:::
		for (intCounter = 0; intCounter < intTotalRec; intCounter++) {
			strFieldCode = document.forms[0].chkMandatoryFieldCode[intCounter].value;
			intIndex1 = strFieldDefaultValues.indexOf(strFieldCode + "::");
			
			// Default field value
			if (intIndex1 >= 0) {
				strTempo = strFieldDefaultValues.substring(intIndex1 + 5, strFieldDefaultValues.length);
				intIndex2 = strTempo.indexOf(":::");
				if (intIndex2 > 0) {
					strTempo = strTempo.substring(0, intIndex2);
					document.forms[0].txtFieldDefault[intCounter].value = strTempo;
				}
				strTempo = "";
			}

			// Default indicator value
			intIndex1 = strFieldIndicatorValues.indexOf(strFieldCode + "::");
			if (intIndex1 >= 0) {
				strTempo = strFieldIndicatorValues.substring(intIndex1 + strFieldCode.length + 2, strFieldIndicatorValues.length);
				intIndex2 = strTempo.indexOf(":::");
				if (intIndex2 > 0) {
					strTempo = strTempo.substring(0, intIndex2);
					document.forms[0].txtFieldIndicators[intCounter].value = strTempo;
				}
				strTempo = "";
			}
		}
	}	
}