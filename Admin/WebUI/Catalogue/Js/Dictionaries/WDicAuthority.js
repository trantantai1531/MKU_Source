/*
function ShowDic(intID,isCLass){
	var url;
	if (isCLass==1){
		url='WDicIndexClass.aspx?ID=' + intID;
	}else{
		url='WDicIndex.aspx?ID=' + intID;
	}
	//openModal(url,'DicIndex',600,400,100,100,'yes','menubar=yes',0);
	self.location.href=url;
}

function ShowClass(intID){
	var url;
	url='WClassification.aspx?intType=' + intID;
	//openModal(url,'DicIndex',600,400,100,100,'yes','menubar=yes',0);
	self.location.href=url;
}
*/


function ShowMedium(){
	var url;
	url='WDicMedium.aspx';
	self.location.href=url;	
}

function ShowItemType(){
	var url;
	url='WDicItemType.aspx';
	self.location.href=url;	
}

function ShowLib(){
	var url;
	url='WDicItemType.aspx';
	self.location.href=url;	
	//alert('Lib');
}

function ShowDicAuthority(intID){
	var url;
	url='WAuthorityDetail.aspx?intID=' + intID;
	self.location.href=url;
}


function ShowDicSelfMade(intID){
	var url;
	url='WDicSelfMade.aspx?intDicID=' + intID;
	//openModal(url,'DicIndex',600,400,100,100,'yes','menubar=yes',0);
	self.location.href=url;
	
}

function CheckInput(strMsg) {
	var str;
	var arr;
	str=strMsg
	arr=str.split('#')
	if (CheckNull(document.forms[0].txtNameDic)){		
		alert(arr[0]);
		document.forms[0].txtNameDic.focus();
		return false;
	}else{
		if (CheckNum(document.forms[0].txtFieldSizeDic)){
			if ((parseInt(document.forms[0].txtFieldSizeDic.value)>0) && (parseInt(document.forms[0].txtFieldSizeDic.value)<=4000)) {
				return true;
			}				
			else {
				alert(arr[1]);
				document.forms[0].txtFieldSizeDic.focus();
				return false;			
			}
			 
		}else{
			alert(arr[1]);
			document.forms[0].txtFieldSizeDic.focus();
			return false;
		}
	}
}

//By: Tuanhv 
//Date: 12/09/2004
//Purpose: check a variable is number
function CheckValueSize(objDateField,strMsg1,strMsg2) {
	var tempNum;
	tempNum = trim(eval(objDateField).value);		
	if(tempNum=="") {
		alert(strMsg1);
		eval(objDateField).focus();								
		return false;
	}	
	if (isNaN(tempNum)) {
		alert(strMsg1);
		eval(objDateField).focus();
		return false;
	}
	if (parseInt(tempNum) > 4000) {
		alert(strMsg2);
		eval(objDateField).focus();
		return false;
	}
	if (parseInt(tempNum) <= 0) {
		alert(strMsg1);
		eval(objDateField).focus();
		return false;
	}
	
	return true;
}
 

function CheckDicManualUpdate(field,strNote,strNote1,strNote2,strNote3,curSize) {
	if(eval(field+'txtName')) {
		if (trim(eval(field+'txtName').value) =="") {
			alert(strNote);
			eval(field+'txtName').focus();
			return false;	
			}
		if (trim(eval(field+'txtFieldSize').value) =="") {
			alert(strNote1);
			eval(field+'txtFieldSize').focus();
			return false;	
			}
		else {
			if (!CheckNum(field+'txtFieldSize')){			
				alert(strNote1);
				eval(field+'txtFieldSize').focus();
				return false;
			}
			else {
				if (curSize > parseInt(eval(field+'txtFieldSize').value)) {
					alert(strNote2+" " + curSize);
					eval(field+'txtFieldSize').focus();
					return false;			
				}
				if (parseInt(eval(field+'txtFieldSize').value) > 4000) {
					alert(strNote3);
					eval(field+'txtFieldSize').focus();
					return false;			
				}
			}		
		}
	}
	return true;	
}


function ShowDicClass(intType){
	self.location.href='WClassificationDetail.aspx?Type=' + intType;
}