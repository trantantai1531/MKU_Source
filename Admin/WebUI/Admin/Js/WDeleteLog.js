function CheckTimeOfDate(strDate) {
	var intpos=0;
	var strTemp=strDate;
	var strHH="";
	var strMi="";
	var strSS="";
	var intTemp=0;
	intpos=strTemp.indexOf(":");
	if (intpos==-1){
		// hour
		strHH=trim(strTemp);
		if (strHH=="")return "";	
		if (isNaN(strHH))return "";
		
		intTemp=parseInt(strHH);
		if ((intTemp>23)||(intTemp<0))return "";		
		if (intTemp<10) strHH="0" + intTemp;
		else
			strHH=intTemp;
		return strHH + ":00:00";
	}
	// hour
	strHH=trim(strTemp.substr(0,intpos));
	if (strHH=="")return "";	
	strTemp=strTemp.substr(intpos+1,strTemp.length);
	if (isNaN(strHH)){
		return "";		
	}
	// reformat
	intTemp=parseInt(strHH);
	if ((intTemp>23)||(intTemp<0))return "";		
	if (intTemp<10) strHH="0" + intTemp;
	else
		strHH=intTemp;

	// minute
	intpos=strTemp.indexOf(":");
	if (intpos==-1){
		strMI=trim(strTemp);
		if (strMI=="")return "";	
		if (isNaN(strMI)) return "";
		
		intTemp=parseInt(strMI);
		if ((intTemp>59)||(intTemp<0)) return "";
		if (intTemp<10) strMI="0" + intTemp;
		else
			strMI=intTemp;
		return strHH + ":" + strMI + ":00";
	}
	strMI=trim(strTemp.substr(0,intpos));	
	if (strMI=="")return "";	
	strTemp=strTemp.substr(intpos+1,strTemp.length);
	if (isNaN(strMI)){
		return "";		
	}
	intTemp=parseInt(strMI);
	if ((intTemp>59)||(intTemp<0)) return "";
	if (intTemp<10) strMI="0" + intTemp;
	else
		strMI=intTemp;
	// second
	strSS=trim(strTemp);	
	if (strSS=="")return "";
	if (isNaN(strSS)){
		return "";		
	}
	intTemp=parseInt(strSS);
	if ((intTemp>99)||(intTemp<0)) return "";
	if (intTemp<10) strSS="0" + intTemp;
	else
		strSS=intTemp;
	return strHH + ":" + strMI + ":" + strSS;
}

// CheckAllInput function
function CheckAllInput(msg1,msg2,msg3,msg4,strDateFormat)
{		
	if (CheckNull(document.forms[0].txtFromDate) && CheckNull(document.forms[0].txtToDate))
	{
		alert(msg1);
		return false;
	}
	var strTempTime="";
	if ((trim(document.forms[0].txtFromDate.value)!="")&&(trim(document.forms[0].txtFromTime.value)!="")) {	
		strTempTime=CheckTimeOfDate(document.forms[0].txtFromTime.value);
		if (strTempTime=="") {
			alert(msg3);
			document.forms[0].txtFromTime.focus();
			return false;
		}
		document.forms[0].txtFromTime.value=strTempTime;
	}
	
	if ((trim(document.forms[0].txtToDate.value)!="")&&(trim(document.forms[0].txtToTime.value))!="") {	
		strTempTime=CheckTimeOfDate(document.forms[0].txtToTime.value);
		if (strTempTime=="") {
			alert(msg3);
			document.forms[0].txtToTime.focus();
			return false;
		}
		document.forms[0].txtToTime.value=strTempTime;
	}
	if ((trim(document.forms[0].txtFromDate.value)!="")&&(trim(document.forms[0].txtToDate.value)!="")) {
		var intCompare=CompareDate('document.forms[0].txtFromDate','document.forms[0].txtToDate',strDateFormat);
		if(intCompare==0) {
			alert(msg4);
			document.forms[0].txtToDate.focus();
			return false;
			}
		if(intCompare==2) {
			if ((trim(document.forms[0].txtToTime.value)!="")&&(trim(document.forms[0].txtFromTime.value)!="")) {
				if (document.forms[0].txtToTime.value < document.forms[0].txtFromTime.value) {
					alert(msg4);
					document.forms[0].txtToTime.focus();
					return false;
				}	
			}
		}		
	}	
	return confirm(msg2);
}

