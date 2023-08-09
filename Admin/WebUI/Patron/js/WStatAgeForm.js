/**************************************************************************
************************ Statistic Age Js file ****************************
**************************************************************************/
// Check from age function
function CheckFromAge(intVal){
	if (isNaN(intVal)){
		if ((parseFloat(intVal)>7)&&(parseFloat(intVal)<200)){
			return true;	
		}else{
			return false;
		}
	}
	return(false);
}

// Check to age function
function CheckToAge(toAge,fromAge){
	alert(fromAge);
	alert(toAge);
	if (isNaN(toAge)){
		if ((parseFloat(toAge)<=parseFloat(fromAge))&&(parseFloat(toAge)<200)){
			return true;
		}else{
			return false;
		}		
	}
	return(false);
}

// Check valid data
function CheckAll1(strMsg1, strMsg2){
	if(document.forms[0].hidAllAge.value=='1'){
		//if(!CheckFromAge(document.forms[0].txtFromAge.value)){
		//	alert(strMsg1);
		//	document.forms[0].txtFromAge.focus();
		//	return(false);
		//}
		if (!CheckToAge(document.forms[0].txtToAge.value,document.forms[0].txtFromAge.value)){
			alert(strMsg2);
			document.forms[0].txtToAge.value='';
			document.forms[0].txtToAge.focus();
			return false;
		}
	}
	return(true);
}
function CheckAll(strMsg1, strMsg2){
	if(document.forms[0].hidAllAge.value=='1'){
		if(document.forms[0].txtFromAge.value!=''){
			if(document.forms[0].txtToAge.value!=''){
				if(parseFloat(document.forms[0].txtToAge.value)<=parseFloat(document.forms[0].txtFromAge.value)) {
					alert(strMsg2);
					document.forms[0].txtToAge.value='';
					document.forms[0].txtToAge.focus();
					return false;
				}
			}
		}
	}
	return(true);
}
// Check data
function CheckValueIt(obj,strMsg1,strMsg2){
	if(eval(obj).value!=''){
		if(isNaN(eval(obj).value)){
			alert(strMsg1);
			eval(obj).focus();
			return(false);
		}
		if(parseFloat(eval(obj).value)<=0){
			alert(strMsg2);
			eval(obj).focus();
			return(false);
		}
	}
	return(true);
}
