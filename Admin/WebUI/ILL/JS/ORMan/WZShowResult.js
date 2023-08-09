	/*
	AddThis function
	Purpose: Add index, value of the selected objcheckbox in to 2 hidden fields
*/
function AddThis(objCheckBox) {
	var intIndex1;
	var strPickedIDs;
	//alert('Leham');
	strPickedIDs = document.forms[0].txtImportedID.value;
	
	intIndex1 = strPickedIDs.indexOf("," + eval(objCheckBox).value + ",");
	if (intIndex1 < 0) {
		document.forms[0].txtImportedID.value = document.forms[0].txtImportedID.value + eval(objCheckBox).value + ",";
	} else {
		objCheckBox.checked = false;
	}
}

/*
	RemoveThis function
	Purpose: Remove the selected item 
*/
function RemoveThis(objCheckBox) {
	var intIndex1;
	var strID;
	var strPickedIDs;
	var strTrailer;
	var strHeader;
	strID = eval(objCheckBox).value;
	strPickedIDs = document.forms[0].txtImportedID.value;
	intIndex1 = strPickedIDs.indexOf("," + strID + ",");
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