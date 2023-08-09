// LoadToSentForm function
function LoadToSentForm(strRequestID, StatusID)
{	
	parent.Sentform.document.forms[0].hidRequestID.value=strRequestID;						
	ActFiltering(StatusID);
}

// ActFiltering function
function ActFiltering(stat) {
	if (stat == 1) {
		LoadAct(",1,2,3,4,7,");
	}
	if (stat == 2) {
		LoadAct(",1,9,");
	}
	if (stat == 3) {
		LoadAct(",1,2,9,");
	}
	if (stat == 4) {
		LoadAct(",1,2,9,10,");
	}
	if (stat == 5) {
		LoadAct(",1,2,3,5,6,7,8,");
	}
	if (stat == 6) {
		LoadAct(",1,2,10,");
	}
	if (stat == 7) {
		LoadAct(",1,2,6,");
	}
}

// LoadAct funciton
function LoadAct(str) {	
	k = 0;
	parent.Sentform.document.forms[0].ddlAction.options.length = 0;
	for (j = 0; j <= 10; j++) {
		if (str.indexOf("," + ActID[j] + ",") >= 0) {
			parent.Sentform.document.forms[0].ddlAction.options.length = k + 1;
			parent.Sentform.document.forms[0].ddlAction.options[k].value = ActID[j];
			parent.Sentform.document.forms[0].ddlAction.options[k].text = ActName[j];
			k = k + 1;
		}	
	}
}