function OAIConnect(verb,msg){
	var val;
	val=document.forms[0].txtURLReSource.value
	if (trim(val)==''){
		alert(msg);
		document.forms[0].txtURLReSource.focus();
	}else{
		document.forms[0].txtVerb.value=verb;
		document.forms[0].submit();	
	}
}

function SelectList(){
	var val;
	val=document.forms[0].lstURLResource.options[document.forms[0].lstURLResource.selectedIndex].value;
	document.forms[0].txtURLReSource.value=val;
}

function ListSet(val){
	document.forms[0].txtVerb.value='ListSets';
	document.forms[0].txtSET.value=val;
	document.forms[0].action = document.forms[0].action + '#' + val;
	document.forms[0].submit();
}

function GetRecord(val){
	document.forms[0].txtVerb.value='GetRecord';
	document.forms[0].txtidentifier.value=val;
	document.forms[0].txtmetadataPrefix.value='oai_dc';
	document.forms[0].submit();
}

function ListRecordNext(valnext){
	document.forms[0].txtVerb.value='ListRecords';
	document.forms[0].txtresumptionToken.value=valnext;
	document.forms[0].submit();
}

function ListIdentifiersNext(valnext){
	document.forms[0].txtVerb.value='ListIdentifiers';
	document.forms[0].txtresumptionToken.value=valnext;
	document.forms[0].submit();
}