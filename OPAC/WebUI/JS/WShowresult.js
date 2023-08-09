function NextRec(intCurPg,intMaxPg){
	if (intCurPg + 1 >= intMaxPg){
		intCurPg=intMaxPg;
	}else{
		intCurPg=intCurPg + 1;
	}
	document.forms[0].action='WShowResult.aspx?intPg=' + intCurPg;
	document.forms[0].submit();
	//self.location.href="WShowResult.aspx?intPg=" + intCurPg;
	return false;
}

function PreRec(intCurPg){
	if (intCurPg - 1 <= 0){
		intCurPg=1;
	}else{
		intCurPg=intCurPg - 1;
	}
	document.forms[0].action='WShowResult.aspx?intPg=' + intCurPg;
	document.forms[0].submit();
	//self.location.href="WShowResult.aspx?intPg=" + intCurPg;
	return false;
}

//Purpose : Replace all string find int String
//Creator : dgsoft
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

// pupose : Event click( select Item to download)
// Creator : dgsoft
function ImgClick(imgName,MaxToCheck, DocID,strMSG) {
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
	if (SavedIDs.indexOf("," + DocID + ",") == -1)  {
		if(parseInt(10,10)> DocIDTemps){	
			DocIDTemps = DocIDTemps + 1;
			SavedIDs = SavedIDs + DocID + ",";
			eval("document.images[imgName].src = 'images/saved.gif'");
			}
		else{
				alert(strMSG);
			}
	}
	else{		
		SavedIDs  =	Replace(SavedIDs,"," + DocID + ",",",");
		eval("document.images[imgName].src = 'images/unsaved.gif'");
		DocIDTemps = DocIDTemps - 1;
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
}

function DownLoadRec(){
	var strIDs;
	strIDs=parent.HiddenSaveIDs.document.forms[0].txtSaveID.value;
	if (trim(strIDs)==''){
		alert(document.forms[0].txtMsg.value);
	}else{		
		parent.HiddenSaveIDs.document.forms[0].submit();
		self.location.href="ItemSaved/WHiddenItem.aspx";
	}
}

function ChangePage(intPg,intMaxPg){
var strJs;
	strJs='';
	/*
	for(i=1;i<=intMaxPg;i++){		
		if(i==intPg) strJs=strJs + '<B>' + i + '</B>';
		else strJs=strJs + '<a class="lbLinkFunction" href="#" OnClick="javascript:ChangePage(' + i + ',' + intMaxPg +');">' + i +'</a> ';			
	}
	document.forms[0].hidViewPage.value=strJs;	
	*/
	document.forms[0].action='WShowResult.aspx?intPg=' + intPg;
	document.forms[0].submit();
}
function CheckSearch(msg) {
	if (document.forms[0].txtSearch.value==''){
		alert(msg);
		document.forms[0].txtSearch.focus();
		return false;
	}
	else {
		return true;
	}
		
}