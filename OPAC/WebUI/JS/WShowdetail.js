// If find an check object, check, if not, through away

function CheckAllItems(strDtgName, strOptionName, intStart){	
	var intCounter;	
	var blnStatus;
	var intMax;
	intMax = eval('document.forms[0].hidRecordNum').value;	
	
	if (eval('document.forms[0].CheckAll').checked) 
		blnStatus = true;
	else
		blnStatus = false;		
		
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName))
		{
			eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked = !blnStatus;			
			eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).click();
		}			
	}
}

// If find an check object, check, if not, through away

function CheckOptionVisible(strDtgName, strOptionName, intvalue){	
	var blnStatus;						
	
	if (eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName))
	{
	if (eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName).checked) 
	{
		blnStatus = false;
	}
	else
	{
		blnStatus = true;	
	}	
		eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName).checked = !blnStatus;			
		eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName).click();
	}			
	
}

function ValidInput(strMsg, strDateMsg, strDateFormat,strInvalidate,strToday){
	if (trim(document.forms[0].txtCardNo.value)==''){
		alert(strMsg);
		document.forms[0].txtCardNo.focus();
		return false;
	}else{
		if (trim(document.forms[0].txtPassWord.value)==''){
			alert(strMsg);
			document.forms[0].txtPassWord.focus();		
			return false;
		}else{
			if (trim(document.forms[0].txtValidDate.value)=="") {
				alert(strDateMsg + ' (' + strDateFormat + ')');
				document.forms[0].txtValidDate.focus();
				return false;
			}
			if (CheckDate(document.forms[0].txtValidDate,strDateFormat,strDateMsg + ' (' + strDateFormat + ')'))
			{
				if (CompareDate(document.forms[0].txtValidDate.value,strToday,strDateFormat)!=1)
					return true;
				else
				{
					alert(strInvalidate);
					document.forms[0].txtValidDate.focus();
					return false;
				}
			}
			else
			{
				document.forms[0].txtValidDate.focus();
				return false;
			}
		}
	}
}

//function NextRecord(strItemIDs,strStyle){
function NextRecord(intItemID,strStyle){
	var intCur;
	var intSum;
	/*
	arr=strItemIDs.split(",");
	intCur=parseInt(document.forms[0].txtCurrent.value);
	intSum=parseInt(document.forms[0].txtTotal.value);
	intCur=intCur + 1 ;
	if (intCur>=intSum){
		document.forms[0].txtCurrent.value=intSum;
		intCur=intSum;
	}else{
		document.forms[0].txtCurrent.value=intCur;
	}*/
	// self.location.href='WShowDetail.aspx?intItemID=' + arr[intCur-1] + '&style=' + strStyle;
	self.location.href='WShowDetail.aspx?intItemID=' + intItemID + '&style=' + strStyle;
	return false;
}

function PreRecord(intItemID,strStyle){
//function PreRecord(strItemIDs,strStyle){
	var intCur;
	var intSum;
	/*
	arr=strItemIDs.split(",");
	intCur=parseInt(document.forms[0].txtCurrent.value);
	intCur=intCur - 1 ;
	if (intCur<=1){
		document.forms[0].txtCurrent.value=1;
		intCur=1;
	}else{
		document.forms[0].txtCurrent.value=intCur;
	}
	*/
	self.location.href='WShowDetail.aspx?intItemID=' + intItemID + '&style=' + strStyle;
	return false;
}

function ChgRecord(strStyle){
	var intCur;
	var intSum;
	// arr=strItemIDs.split(",");
	if (! isNaN(document.forms[0].txtCurrent.value)){
		intCur=parseInt(document.forms[0].txtCurrent.value);
		intSum=parseInt(document.forms[0].txtTotal.value);
		if (intCur>=intSum){
			document.forms[0].txtCurrent.value=intSum;
			intCur=intSum;
		}else{
			if (intCur<=0){
				document.forms[0].txtCurrent.value=0;
				intCur=1;
			}
		}
		self.location.href='WShowDetail.aspx?ItemIndex=' + intCur + '&style=' + strStyle;		
		//self.location.href='WShowDetail.aspx?intItemID=' + arr[intCur-1] + '&style=' + strStyle;		
	}
	return false;
}

function MarkRecord(MaxToCheck, DocID,strMSG) {
	var SavedIDs = "" + parent.HiddenSaveIDs.document.forms[0].txtSaveID.value + "";
	var DocIDTemps = parseInt(parent.HiddenSaveIDs.document.forms[0].txtDocIDTemps.value,10);
	// add prefix ","
	if (SavedIDs.substring(0,1)!=','){
		SavedIDs=',' + SavedIDs;
	}
	// add suffix ","
	if (SavedIDs.substring(SavedIDs.length-1,1)!=','){
		SavedIDs=SavedIDs + ',';
	}	
	// check ID is existing in Hidden
	if (SavedIDs.indexOf(',' + DocID + ',') == -1)  {
		if(parseInt(10,10)> DocIDTemps){	
			DocIDTemps = DocIDTemps + 1;
			SavedIDs = SavedIDs + DocID + ',';
			}
		else{
				alert(strMSG);
			}
	}
	// remove prefix ","
	if (SavedIDs.substring(0,1)==','){
		SavedIDs=SavedIDs.substring(1,SavedIDs.length-1);
	}
	// remove suffix ","
	if (SavedIDs.substring(SavedIDs.length-1,1)==','){
		SavedIDs=SavedIDs.substring(0,SavedIDs.length-1);
	}	
	// assign to hiddden
	parent.HiddenSaveIDs.document.forms[0].txtDocIDTemps.value = DocIDTemps;
	parent.HiddenSaveIDs.document.forms[0].txtSaveID.value = SavedIDs;
	return false;
}

function ReturnShowResult(strStyle,strPg){
	parent.HiddenSaveIDs.document.forms[0].submit();
	self.location.href='WShowresult.aspx?intPg=' + strPg + '&style=' + strStyle;
	return false;
}
function ChangeClick(intmenu){
	if (intmenu==5) {
		MarkRecord(document.forms[0].hidMaxDown.value,document.forms[0].hidItemID.value,document.forms[0].hidMessage.value);
	}
	else {
		if (intmenu==6) {
			ReturnShowResult(document.forms[0].hidStyle.value,document.forms[0].hidCurPage.value);
		}
		else {
			document.forms[0].hidmenu.value=intmenu;
			document.forms[0].submit();
		}
	}
}
