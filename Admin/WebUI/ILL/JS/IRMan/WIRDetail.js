// LoadToSentForm function
function LoadToSentForm(strRequestID, StatusID)
{	
	parent.Sentform.document.forms[0].hidRequestID.value=strRequestID;						
	ActFiltering(StatusID);
}

// ActFiltering funciton
function ActFiltering(stat) {
	if (stat ==	 1) {
		LoadAct(",15,20,21,");
	}
	if (stat == 3) {
		LoadAct(",2,3,4,5,6,8,15,16,18,19,");
	}
	if (stat == 5) {
		LoadAct(",4,5,15,16,18,19,");
	}
	if (stat == 6) {
		LoadAct(",9,15,16,18,19,");
	}
	if (stat == 7) {
		LoadAct(",15,18,20,21,");
	}
	if (stat == 8) {
		LoadAct(",11,12,13,15,16,17,18,19,");
	}
	if (stat == 9) {
		LoadAct(",11,12,13,15,16,17,18,19,");
	}
	if (stat == 10) {
		LoadAct(",10,11,15,16,18,19,");
	}
	if (stat ==	11) {
		LoadAct(",11,12,13,15,16,17,18,19,");
	}
	if (stat == 12) {
		LoadAct(",11,12,13,15,16,17,18,19,");
	}
	if (stat == 13) {
		LoadAct(",11,12,13,15,16,17,18,19,");
	}
	if (stat == 14) {
		LoadAct(",13,15,16,17,18,19,");
	}
	if (stat == 15) {
		LoadAct(",15,16,18,19,");
	}
	if (stat == 16) {
		LoadAct(",11,13,15,16,17,18,19,");
	}
	if (stat == 17) {
		LoadAct(",15,16,18,19,20,21,");
	}
	if (stat == 21) {
		LoadAct(",1,2,3,4,5,6,7,8,15,16,18,19,");
	}
	if (stat == 22) {
		LoadAct(",15,20,21,");
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