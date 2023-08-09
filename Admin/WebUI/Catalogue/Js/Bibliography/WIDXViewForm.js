function ValidView(strMsg){
	var len;
	var i;
	var val;
	var strValue;
	var blnRet;
	var intPos;
	blnRet=false;
	len=document.forms[0].ddlTypeView.options.length;
	for (i=0; i<3; i++){
		if (document.forms[0].ddlTypeView.options[i].selected){
			val=document.forms[0].ddlTypeView.options[i].value;
			break;
		}
	}
	switch (val){
		case 1: //AllGrp
			break;
		case 2: // GrpName
			if (CheckNull(document.forms[0].txtTypeViewID)){
				alert(strMsg);
				document.forms[0].txtTypeViewID.focus();
			}else{
				blnRet=true;
			}
			break;
		case 3: //GrpID
			if (CheckNull(document.forms[0].txtTypeViewID)){
				alert(strMsg);
				document.forms[0].txtTypeViewID.focus();
			}else{
				strValue=document.forms[0].txtTypeViewID.value;
				if (isNaN(strValue)){
					intPos=strValue.indexOf('-');
					if (intPos >= 0){
						blnRet=true;
					}else{
						alert(strMsg);
						document.forms[0].txtTypeViewID.focus();					
					}
				}else{
					blnRet=true;
				}
			}		
			break;
	}
	if (CheckNum(document.forms[0].txtPageSize)){
		blnRet=true;
	}else{
		alert(strMsg);
		document.forms[0].txtPageSize.focus();	
		blnRet=false;
	}
	return blnRet;
}

function ResetForm(){
	if(document.forms[0].ddlTemplate.length>0)	document.forms[0].ddlTemplate.options[0].selected=true;
	document.forms[0].txtPageSize.value=20;
	return false;
}