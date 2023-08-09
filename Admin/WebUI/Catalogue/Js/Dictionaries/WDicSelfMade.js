var inti;
var inti5;
ProgImg = new Array(20);
int5=0;
for(inti=0; inti<=20; inti++){
	ProgImg[inti] = new Image(600,30);
	inti5=inti*5;
	ProgImg[inti].src='../../images/bar/' + inti5 + '.gif';
	//alert(ProgImg[inti].src);
}
	
function CreateIDs(){
	var strIDs;
	strIDs='';
	document.forms[0].txtIDs.value='';
	//alert(document.forms[0].chkIDs.length);
	if ( ! document.forms[0].chkIDs.length){
		if (document.forms[0].chkIDs.value){
			if (document.forms[0].chkIDs.checked){
				strIDs=document.forms[0].chkIDs.value;
			}
		}
	}else{
		for (i=0;i<document.forms[0].chkIDs.length;i++){
			if (document.forms[0].chkIDs[i].checked){
				strIDs = strIDs + document.forms[0].chkIDs[i].value + ',';
			}
		}	
	}
	if (strIDs.substring(strIDs.length-1,strIDs.length)== ','){
		document.forms[0].txtIDs.value=strIDs.substring(0,strIDs.length-1);
	}else{
		document.forms[0].txtIDs.value=strIDs;
	}
}

function CheckInput(strMsg){
	if (CheckNull(document.forms[0].txtNewDictionary)){
		alert(strMsg);
		document.forms[0].txtNewDictionary.focus();
		return false;
	}else{
		return true;
	}
}

function CheckNameField(strMsg){
	if (CheckNull(document.forms[0].txtFieldCode)){
		alert(strMsg);
		document.forms[0].txtFieldCode.value = '';
		document.forms[0].txtFieldCode.focus();
		return false;
	}else{
		return true;
	}
}