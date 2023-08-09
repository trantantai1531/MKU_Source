// CheckOptionsNull function - Alert when no option is checked
function CheckOptionsNull(strDtgName, strOptionName, intStart, intMax, strMsg){	
	var intCounter;	          			
	var intCount;          
	
	intCount = 0;
	
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked)
		{
			intCount = intCount + 1		
		}			
	}
	
	if (intCount != 0) {
		return true;
	}
	else
	{
		alert(strMsg);
		return false;
	}
}


// If find an check object, check, if not, through away

function CheckAllItems(strDtgName, strOptionName, intStart){	
	var intCounter;	
	var blnStatus;
	var intMax;
	intMax = eval('document.forms[0].hidRecordNum').value;	
	document.forms[0].hidTotal.value = 0;
	
	if (eval('document.forms[0].CheckAll').checked) 
	{
		blnStatus = true;
		}
	else
	{
		blnStatus = false;		
		}
		
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName))
		{
			eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked = !blnStatus;			
			eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).click();
		}			
	}
	if (parseFloat(document.forms[0].hidTotal.value) < 0 )
		document.forms[0].hidTotal.value = 0;
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

function Replace(Str, FindChar, ReplaceChar) {
	while (Str.indexOf(FindChar) !=-1){
		offset = Str.indexOf(FindChar);
		First = Str.substring(0, offset);
		First += ReplaceChar;
		Last = Str.substring(offset + FindChar.length, Str.length);
		Str = First + Last;
	}
	return Str;
}

function CheckBoxClick(strDtgName, strOptionName, intCounter, Value, Price, Name, Size, Currency)
{
	var intCount;          
	
	intCount = 0;
		
	if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked) 
	{
		document.forms[0].hidIDs.value = document.forms[0].hidIDs.value + Value + ',';
		document.forms[0].hidTotal.value = Math.round(parseFloat(document.forms[0].hidTotal.value) + parseFloat(Price))
		document.forms[0].hidFiles.value = document.forms[0].hidFiles.value + Name + ' (' + Size + ' bytes' + ', ' + Price + ' ' + Currency + ')' + Value + '#';
	}	
	else
	{
		document.forms[0].hidIDs.value = Replace(document.forms[0].hidIDs.value,Value + ',','')
		document.forms[0].hidTotal.value = Math.round(parseFloat(document.forms[0].hidTotal.value) - parseFloat(Price))
		document.forms[0].hidFiles.value = Replace(document.forms[0].hidFiles.value,Name + ' (' + Size + ' bytes' + ', ' + Price + ' ' + Currency + ')' + Value + '#','');
	}	
}

// PostBackData fucntion
function PostBackData(val)
{
var arrNotes;
var intCount;
var strNotes;
	strNotes = document.forms[0].hidFiles.value;
	arrNotes = strNotes.split("#");
	opener.document.forms[0].txtReason.value = val;
	for(intCounter = 0; intCounter < arrNotes.length - 1; intCounter++) {				  
		opener.document.forms[0].txtReason.value = opener.document.forms[0].txtReason.value + '\n' + '  ' + (parseFloat(intCounter)+ 1)  + '. ' + Left(arrNotes[intCounter], arrNotes[intCounter].indexOf(")") + 1);
	}
	opener.document.forms[0].txtAmount.value = document.forms[0].hidTotal.value;
	opener.document.forms[0].hidIDs.value = Left(document.forms[0].hidIDs.value,document.forms[0].hidIDs.value.length - 1);
	self.close();
}

// Left function
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

// Right function
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