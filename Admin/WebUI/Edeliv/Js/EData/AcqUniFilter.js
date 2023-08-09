function CheckAll(msg,msg1){
	var chk;
	
	chk =	CheckNull(document.forms[0].txtField1) && 	
			CheckNull(document.forms[0].txtfield2) && 	
			CheckNull(document.forms[0].txtField3) && 
			CheckNull(document.forms[0].txtField4) &&	
			CheckNull(document.forms[0].txtRecordIDFrom) &&	
			CheckNull(document.forms[0].txtRecordIDto) &&	
			CheckNull(document.forms[0].txtTimeFrom) &&	
			CheckNull(document.forms[0].txtTimeTo)
	if (chk)
	{
		alert(msg);
		return false;	
	}
	else {
		// Check CataFrom > CataTo
		if ((document.forms[0].txtTimeFrom.value !='') && (document.forms[0].txtTimeTo.value !='') && (CompareDate(document.forms[0].txtTimeFrom,document.forms[0].txtTimeTo,'dd/mm/yyyy')==0)) {
			alert(msg1);
			return false;
		}
	}

	return true;
	
}

function CheckValidNumber(obj,msg) {
	var tempNum;
	tempNum = eval(obj).value;
	if (isNaN(tempNum)) {
		alert(msg);
		eval(obj).value = "";							
		eval(obj).focus();							
		return false;
	} 
		return true;
		
}

function ResetForm(){
	document.forms[0].ddlBool1.options[0].selected=true;
	document.forms[0].ddlField2.options[0].selected=true;
	document.forms[0].ddlBool2.options[0].selected=true;
	document.forms[0].ddlField3.options[0].selected=true;
	document.forms[0].ddlBool3.options[0].selected=true;
	document.forms[0].ddlField4.options[0].selected=true;
	document.forms[0].txtField1.value='';
	document.forms[0].txtfield2.value='';
	document.forms[0].txtField3.value='';
	document.forms[0].txtField4.value='';
	document.forms[0].txtRecordIDFrom.value='';
	document.forms[0].txtRecordIDto.value='';
	document.forms[0].txtTimeFrom.value='';
	document.forms[0].txtTimeTo.value='';
}

function OnSubmit(min, max, collect, addCollect, intCollectionFilter) {
    top.main.Workform.maincontent.location = "AcqCreateCollection.aspx?NumRec=" + String(min) + "&collectionId=" + String(collect) + "&addCollection=" + String(addCollect) + "&FilterCollectionId=" + String(intCollectionFilter);
}
function raiseSubmit(key, val, updateFlag) {
    CheckSubmit(key, val);
}
function CheckSubmit(key, val) {
    switch (key) {
        case 'Cancel':
            top.main.Workform.footercontent.setEnableButtonItem(key);
            top.main.Workform.maincontent.location = "AcqCreateCollection.aspx";
            break;
    }
}