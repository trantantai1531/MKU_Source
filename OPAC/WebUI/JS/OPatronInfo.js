// check all CheckBox in a Datagrid
// now uesed for only dgrReservation
function CheckAll(strDtgName, strOptionName,strOptionCheckAll, intMax){
	var intCounter;
	var blnStatus;	
	if (document.forms[0].ckbCheckAll.checked==false) {
		blnStatus = false;
	} else {
		blnStatus = true;
	}	
    for(intCounter = 2; intCounter < intMax + 2; intCounter++) {
		eval('document.forms[0].dgrReservation__ctl' + intCounter + '_ckbItemID').checked = blnStatus;
    }
}
function CheckAllReserve(intMax) {
    var intCounter;
    var blnStatus;
    if (document.forms[0].ckbReserveCheckAll.checked == false) {
        blnStatus = false;
    } else {
        blnStatus = true;
    }
    for (intCounter = 2; intCounter < intMax + 2; intCounter++) {
        eval('document.forms[0].dgrReserve__ctl' + intCounter + '_ckbItemID').checked = blnStatus;
    }
}
function Left(str, n){
	if (n <= 0){
		return("");
	}
	else{
		if (n > String(str).length){
			return str;
		}
		else{
			return String(str).substring(0,n);
		}
	}
}
function Right(str, n){
    if (n <= 0){ return("");
    }
    else{ 
		if (n > str.length){
			return str;
		}
		else {
			var iLen = str.length;
			return str.substring(iLen, iLen - n);
		}
	}
}
// pick Reservation ItemIDs 
function CheckReservationSelected(intReservationMax){
	var inti;
	var strReservationItemIDs;
		strReservationItemIDs='';
	if(intReservationMax <=0){
		return(false);//don't have any ItemIDs
	}
	for(inti=2;inti < intReservationMax + 2; inti++){
		if(eval('document.forms[0].dgrReservation__ctl' + inti + '_ckbItemID').checked == true){			
			strReservationItemIDs = strReservationItemIDs + eval('document.forms[0].dgrReservation__ctl' + inti + '_ckbItemID').value + ',';
		}
	}
	if(strReservationItemIDs.length > 0) return(true);
	else return(false);
}
function CheckReserveSelected(intReserveMax) {
    var inti;
    var strReserveItemIDs;
    strReserveItemIDs = '';
    if (intReserveMax <= 0) {
        return (false);//don't have any ItemIDs
    }
    for (inti = 2; inti < intReserveMax + 2; inti++) {
        if (eval('document.forms[0].dgrReserve__ctl' + inti + '_ckbItemID').checked == true) {
            strReserveItemIDs = strReserveItemIDs + eval('document.forms[0].dgrReserve__ctl' + inti + '_ckbItemID').value + ',';
        }
    }
    if (strReserveItemIDs.length > 0) return (true);
    else return (false);
}
function SubmitForm() {	
    /*
	document.forms[0].action='WInterestItem.aspx';
	document.forms[0].method='post';
	document.forms[0].submit();
    */
    location.href = 'WInterestItem.aspx?hdInheritanceMap=' + document.forms[0].hdInheritanceMap.value + '&hdOpenedParentIDs=' + document.forms[0].hdOpenedParentIDs.value + '&hdAllwaysChecking=' + document.forms[0].hdAllwaysChecking.value + '&hdUpdateFlag=' + document.forms[0].hdUpdateFlag.value + '&hdScrollTop=' + document.forms[0].hdScrollTop.value;
	return(true);
}