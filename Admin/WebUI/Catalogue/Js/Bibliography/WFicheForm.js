/*
	FilterLocation function
*/

function FilterLocation() {
	var intLibID;
	
	intLibID=document.forms[0].ddlLib.options[document.forms[0].ddlLib.options.selectedIndex].value;
	document.forms[0].ddlLoc.options.length = 0;
	
	for (j = 0; j < LibID.length; j++) {
		if (LibID[j] == intLibID) {
			document.forms[0].ddlLoc.options.length = document.forms[0].ddlLoc.options.length + 1;
			document.forms[0].ddlLoc.options[document.forms[0].ddlLoc.options.length - 1].value = LocID[j];
			document.forms[0].ddlLoc.options[document.forms[0].ddlLoc.options.length - 1].text = Location[j];
		}
	}
	document.forms[0].ddlLoc.options.selectedIndex = 0
	document.forms[0].txtLocID.value = document.forms[0].ddlLoc.options[document.forms[0].ddlLoc.options.selectedIndex].value;
}

/*
	SetHidVal function
*/
function SetHidVal(){
	document.forms[0].txtLocID.value = document.forms[0].ddlLoc.options[document.forms[0].ddlLoc.options.selectedIndex].value;

}

function FichePrint(msg){
	//if (CheckNull(document.forms[0].txtItemIDFrom)){
	//	//if (!CheckNum(document.forms[0].txtItemIDFrom)){
	//	//	document.forms[0].txtItemIDFrom.focus();
	//	//	alert(msg);
	//	//	return false;
	//    //}	
	//    alert(msg)
	//    return false;
	//}
	//if (CheckNull(document.forms[0].txtItemIDTo)){
	//	//if (!CheckNum(document.forms[0].txtItemIDTo)){
	//	//	document.forms[0].txtItemIDTo.focus();
	//	//	alert(msg);
	//	//	return false;
	//    //}		
	//    alert(msg);
	//    return false;
	//}
	if (document.forms[0].ddlItemType.options[document.forms[0].ddlItemType.selectedIndex].text == "--"){
		alert(msg);
		document.forms[0].ddlItemType.focus();
		return false;
	}
	return true;
}

function ResetAll(){
	document.forms[0].reset();
	return false;
}

