function rdoEvent(intCurrentIndex){
	//rdoRequest
	var intIndex = 0;
	for(var intIndex = 0; intIndex < document.forms[0].rdoRequest.length; intIndex++) {
		if (intIndex==intCurrentIndex) {
			document.forms[0].rdoRequest[intIndex].checked = true; 
			document.forms[0].rdoRequest[intIndex].click();			
		} else {
			document.forms[0].rdoRequest[intIndex].checked = false;
		}
	}		
}

// rdoClick function
var intOld = -1;
function rdoClick(strRequestID, StatusID)
{	
	if (document.forms[0].rdoRequest.length > 1) 
	{
	for(var intIndex = 0; intIndex < document.forms[0].rdoRequest.length; intIndex++) {
		if (document.forms[0].rdoRequest[intIndex].checked == true) {			
			if (intOld != -1)
				swapBG(eval('dgtRequest__ctl' + eval(intOld + 3) + '_lnkTitle'),'#95b9c7');			
			swapBG(eval('dgtRequest__ctl' + eval(intIndex + 3) + '_lnkTitle'),'#95b9c7');
			intOld = intIndex;			
		}		
	}
	}
	document.forms[0].hidRequestID.value=strRequestID;			
	parent.Sentform.document.forms[0].hidRequestID.value=strRequestID;						
	ActFiltering(StatusID);
}

// microsoftKeyPress function (UP, DOWN, LEFT, RIGHT)
function microsoftKeyPress() 
	{		
	var intCheck;	
	if (window.event.keyCode == 38) {
		if (eval(document.forms[0].rdoRequest[0]))
		{
			for(var intIndex = 0; intIndex < document.forms[0].rdoRequest.length; intIndex++) {
				if (document.forms[0].rdoRequest[intIndex].checked == true) {			
					intCheck = intIndex - 1;
				}		
			}			
		}
	}	
	
	if (window.event.keyCode == 40) {
		if (eval(document.forms[0].rdoRequest[0]))
		{
			for(var intIndex = 0; intIndex < document.forms[0].rdoRequest.length; intIndex++) {
				if (document.forms[0].rdoRequest[intIndex].checked == true) {			
					intCheck = intIndex + 1;
				}		
			}			
		}	
	}
	
	if (window.event.keyCode == 37)
	{
		if (eval(document.forms[0].rdoRequest[0]))
		{
			intCheck = 0;
		}
	}
	
	if (window.event.keyCode == 39)
	{
		if (eval(document.forms[0].rdoRequest[0]))
		{
			intCheck = document.forms[0].rdoRequest.length - 1;
		}
	}	
	if (eval(document.forms[0].rdoRequest[intCheck])){
		document.forms[0].rdoRequest[intCheck].click();
	}
	return true;
}

// ActFiltering funciton
function ActFiltering(stat) {
	if (stat ==	 1) {
		LoadAct(",2,6,7,18,19,");
	}
	if (stat == 2) {
		LoadAct(",2,5,4,6,7,10,12,16,17,");
	}
	if (stat == 5) {
		LoadAct(",2,4,5,6,8,12,16,17,");
	}
	if (stat == 6) {
		LoadAct(",2,5,6,7,12,16,17,");
	}
	if (stat == 7) {
		LoadAct(",2,6,18,19,");
	}
	if (stat == 8) {
		LoadAct(",2,5,6,10,12,13,16,17,");
	}
	if (stat == 9) {
		LoadAct(",2,5,6,11,13,14,15,16,17,");
	}
	if (stat == 10) {
		LoadAct(",2,5,6,7,12,14,15,16,17,");
	}
	if (stat == 11) {
		LoadAct(",2,5,6,11,12,14,15,16,17,");
	}
	if (stat == 12) {
		LoadAct(",2,5,6,11,12,14,15,16,17,");
	}
	if (stat == 13) {
		LoadAct(",2,5,6,11,12,14,15,16,17,21,");
	}
	if (stat == 14) {
		LoadAct(",2,5,6,12,16,17,");
	}
	if (stat == 15) {
		LoadAct(",2,6,12,16,17,");
	}
	if (stat == 16) {
		LoadAct(",2,5,6,14,15,16,17,");
	}
	if (stat == 17) {
		LoadAct(",2,5,6,16,18,19,");
	}
	if (stat == 19) {
		LoadAct(",1,19,20,");
	}
	if (stat == 20) {
		LoadAct(",1,7,18,20,");
	}
	if (stat == 21) {
		LoadAct(",1,2,3,18,20,");
	}
	if (stat == 22) {
		LoadAct(",2,6,18,19,");
	}
}

// LoadAct funciton
function LoadAct(str) {	
	k = 0;
	parent.Sentform.document.forms[0].ddlAction.options.length = 0;
	for (j = 0; j <= 20; j++) {
		if (str.indexOf("," + ActID[j] + ",") >= 0) {
			parent.Sentform.document.forms[0].ddlAction.options.length = k + 1;
			parent.Sentform.document.forms[0].ddlAction.options[k].value = ActID[j];
			parent.Sentform.document.forms[0].ddlAction.options[k].text = ActName[j];
			k = k + 1;
		}	
	}
}
// Open Search Patron form
function OpenPatron() {
  SearchPatronWin =  window.open("WSearchPatron.aspx","SearchPatronWin", "height=350,width=600,resizable,scrollbars=yes");
   SearchPatronWin.focus();
}
// Open Calendar
function OpenCalendar(ControlName){
	Calendar=window.open('../../Common/WCalendar.aspx?id=' + ControlName,'Calendar',200,256,220,100)
	Calendar.focus();
}
function OpenZ3950Find(){
Z3950ILLWin = window.open("WZForm.aspx?ILLNewQuery=0", "Z3950ILLWin",  "width=700,height=360,resizable,menubar=yes,scrollbars=yes");
Z3950ILLWin.focus();
}
function ResetSymbol() {
	document.forms[0].txtLibName.value = '';
	document.forms[0].txtEmailIP.value = '';
	return false;
}
function ResetDelivMode2() {
	document.forms[0].txtPostDelivName.value = '';
	document.forms[0].txtPostDelivAddr.value = '';
	document.forms[0].txtPostDelivStreet.value = '';
	document.forms[0].txtPostDelivBox.value = '';
	document.forms[0].txtPostDelivCity.value = '';
	document.forms[0].txtPostDelivRegion.value = '';
	document.forms[0].txtPostDelivCode.value = '';
	return false;
}
function ResetBillDelivName() {
	document.forms[0].txtBillDelivAddr.value = '';
	document.forms[0].txtBillDelivStreet.value = '';
	document.forms[0].txtBillDelivBox.value = '';
	document.forms[0].txtBillDelivCity.value = '';
	document.forms[0].txtBillDelivRegion.value = '';
	document.forms[0].txtBillDelivCode.value = '';
	return false;
}