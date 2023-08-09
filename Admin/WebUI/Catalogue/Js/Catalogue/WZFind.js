/*
	AddThis function
	Purpose: Add index, value of the selected objcheckbox in to 2 hidden fields
*/
function AddThis(intPOC) {
	var intIndex1;
	var strPickedIDs;
	
	strPickedIDs = document.forms[0].txtImportedID.value;
	intIndex1 = strPickedIDs.indexOf("," + intPOC + ",");
	if (intIndex1 < 0) {
		document.forms[0].txtImportedID.value = document.forms[0].txtImportedID.value + intPOC + ",";
	} else {
		//objCheckBox.checked = false;
		RemoveThis(intPOC);
	}
}

/*
	RemoveThis function
	Purpose: Remove the selected item 
*/
function RemoveThis(intPOC) {
	var intIndex1;
	var strID;
	var strPickedIDs;
	var strTrailer;
	var strHeader;
	strID = String(intPOC);
	strPickedIDs = document.forms[0].txtImportedID.value;
	intIndex1 = strPickedIDs.indexOf(',' + strID + ',');	
	alert(intIndex1);
	if (intIndex1 >=0) {
		strHeader = strPickedIDs.substring(0, intIndex1);	
		strTrailer = strPickedIDs.substring(intIndex1 + strID.length + 1, strPickedIDs.length);
		document.forms[0].txtImportedID.value = strHeader + strTrailer;
	}
}

/*
	LoadBack function
*/
function LoadBack(val){
	var pos;
	var Server;
	var Port;
	var db;
	var temp = val;
	if (val!=''){
		pos = temp.indexOf(":");
		Server = temp.substring(0,pos);
		temp = temp.substring(pos + 1);
			
		pos = temp.indexOf("#");
		Port = temp.substring(0,pos);
		temp = temp.substring(pos + 1);
		
		db = temp;
		
		opener.document.forms[0].txtzServer.value = Server;
		opener.document.forms[0].txtZPort.value = Port;
		opener.document.forms[0].txtZDatabase.value = db;
	}
	self.close();
}

function chkEvent(val)
{	
	if (document.forms[0].txtImportedID.value=="") {
		document.forms[0].txtImportedID.value=val;
	}
	else {
		var strIDs="," + document.forms[0].txtImportedID.value+",";
		var intPos=strIDs.indexOf(","+val+",");
		//removed
		if (intPos>-1) {
			strIDs=strIDs.replace(","+val+",",",");						
			if (strIDs==",")
				document.forms[0].txtImportedID.value="";
			else
			document.forms[0].txtImportedID.value=strIDs.substring(1,strIDs.length-1);
		}
		//add
		else {
			document.forms[0].txtImportedID.value=document.forms[0].txtImportedID.value + "," + val;
		}
	}	
}
function ViewRecord(strErrMsg) {	
	var strNext=document.forms[0].txtStart.value;
		if (strNext=="") {
			alert(strErrMsg);
			document.forms[0].txtStart.focus();
			return false;
		}
		if (isNaN(strNext)) {
			alert(strErrMsg);
			document.forms[0].txtStart.focus();
			return false;
		}
		document.forms[0].submit();
		return true;
	
}
function ViewRecord(val,strErrMsg1,strErrMsg2,strErrMsg3) {	
	if (document.forms[0].hidCountRec.value > 9) {
	var strNext=trim(document.forms[0].txtStart.value);
		if (strNext=="") {
			alert(strErrMsg1);
			document.forms[0].txtStart.focus();
			return false;
		}
		if (isNaN(strNext)) {
			alert(strErrMsg2);
			document.forms[0].txtStart.focus();
			return false;
		}
		var intNext=parseInt(strNext);
		var intCount=parseInt(document.forms[0].hidCountRec.value)	
		if ((intNext<1) || (intNext>intCount)) {
			alert(strErrMsg3);
			document.forms[0].txtStart.focus();
			return false;
		}	
	}
	document.forms[0].hidAction.value=val;
	if (val!=1) {
		document.forms[0].submit();
	}
	return true;
	
}