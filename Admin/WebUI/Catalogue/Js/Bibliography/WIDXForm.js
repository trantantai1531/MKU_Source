function AddTypeID(){
	var i;
	var strTypeIDs;
	strTypeIDs='';
	for (i = 0; i < document.forms[0].lstItemType.length; i++){
		if (document.forms[0].lstItemType.options[i].selected){
			strTypeIDs=strTypeIDs + document.forms[0].lstItemType.options[i].value + ',' ;
		}
	}
	if (strTypeIDs!=''){
		strTypeIDs=strTypeIDs.substring(0,strTypeIDs.length-1);
	}
	return strTypeIDs;
}

function RestoreTypeID(val){
	var i;
	var j;
	var strTypeIDs;
	var arrID;
	//document.forms[0].txtHidTypeIDs.value
	strTypeIDs=',' + val + ',';
	if(strTypeIDs != ''){
		for (i = 0; i < document.forms[0].lstItemType.options.length; i++) {
			if (strTypeIDs.indexOf(',' + document.forms[0].lstItemType.options[i].value + ',') >= 0) {
				document.forms[0].lstItemType.options[i].selected = true;
			}
		}	
//		arrID=strTypeIDs.split(',')
//		for(i=0 ;i< arrID.length ; i++){
//			for (j = 0; j < document.forms[0].lstItemType.length; j++){
//				if (document.forms[0].lstItemType.options[j].value==arrID[i]){
//					document.forms[0].lstItemType.options[j].selected=true;
//				}
//			}			
//		}
	alert(strTypeIDs);
	}
	return;
}

function RestoreField(){
	
}

function ValidUpdate(strMsg1,strMsg2,strMsg3,strMsg4,strMsg5,strMsg6){
	var strTypeIDs;
	strTypeIDs=AddTypeID();
	document.forms[0].txtHidTypeIDs.value=strTypeIDs;
	if (CheckNull(document.forms[0].txtIDFrom) && CheckNull(document.forms[0].txtIDTo) && CheckNull(document.forms[0].txtCataFrom) && CheckNull(document.forms[0].txtIDTo) && CheckNull(document.forms[0].txtVal1) && CheckNull(document.forms[0].txtVal2) && CheckNull(document.forms[0].txtVal3) && CheckNull(document.forms[0].txtVal4) && CheckNull(document.forms[0].txtGroupName) && ( strTypeIDs=='')){
		alert(strMsg1);	
		return false;
	}else{
		// Check CataFrom > CataTo
		if ((document.forms[0].txtCataFrom.value !='') && (document.forms[0].txtCataTo.value !='') && (CompareDate(document.forms[0].txtCataFrom,document.forms[0].txtCataTo,'dd/mm/yyyy')==0)) {
			alert(strMsg6);
			return false;
		}
		if (CheckNull(document.forms[0].txtGroupName)){
			alert(strMsg2);	
			return false;
		}
		// Check the number is less than zero
		if (!CheckNumber('document.forms[0].txtIDFrom',strMsg3,'>0'))
		{
			eval(document.forms[0].txtIDFrom).focus();
			return false;
		}
		
		// Check the number is less than zero
		if (!CheckNumber('document.forms[0].txtIDTo',strMsg3,'>0'))
		{
			eval(document.forms[0].txtIDTo).focus();
			return false;
		}
		
	
		// Check the from record is less than to record
		if (isNumber('document.forms[0].txtIDFrom')&& isNumber('document.forms[0].txtIDTo')) {
			if (parseFloat(document.forms[0].txtIDFrom.value) > parseFloat(document.forms[0].txtIDTo.value))
			{
				alert(strMsg5);
				eval(document.forms[0].txtIDFrom).focus();
				return false;	
			}
		
		}
	}
	return;
}

function ValidDel(strMsg,strMsg2){
	var strVal;
	strVal=document.forms[0].ddlGroup.options[document.forms[0].ddlGroup.options.selectedIndex].value;
	if (strVal==0){
		alert(strMsg);
		return false;
	}else{
		if (confirm(strMsg2)){
			return true;
		}else{
			return false;
		}
	}
}

function ValidView(strMsg){
	var strVal;
	strVal=document.forms[0].ddlGroup.options[document.forms[0].ddlGroup.options.selectedIndex].value;
	if (strVal==0){
		alert(strMsg);
		return false;
	}else{
		return true;
	}		
}

