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


// ActFiltering function
function ActFiltering(stat) {
	// New
	if (stat == 1) {
		LoadAct(",1,2,3,4,7,9,");
	}
	// Denied
	if (stat == 2) {
		LoadAct(",1,9,");
	}
	// Canceled
	if (stat == 3) {
		LoadAct(",1,2,9,");
	}
	// Cancell Pending
	if (stat == 4) {
		LoadAct(",1,2,9,10,");
	}
	// Shipped
	if (stat == 5) {
		LoadAct(",1,2,3,5,6,7,8,9,");
	}
	// Completed
	if (stat == 6) {
		LoadAct(",1,2,9,10,");
	}
	// Paid
	if (stat == 7) {
		LoadAct(",1,2,6,9,");
	}
}

// LoadAct funciton
function LoadAct(str) {	
	k = 0;
	parent.Sentform.document.forms[0].ddlAction.options.length = 0;
	for (j = 0; j <= 10 ; j++) {
		if (str.indexOf("," + ActID[j] + ",") >= 0) {
			parent.Sentform.document.forms[0].ddlAction.options.length = k + 1;
			parent.Sentform.document.forms[0].ddlAction.options[k].value = ActID[j];
			parent.Sentform.document.forms[0].ddlAction.options[k].text = ActName[j];
			k = k + 1;
		}	
	}
}