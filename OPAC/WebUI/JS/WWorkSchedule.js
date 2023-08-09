function CheckHour(objtxt,msg){			
	if (CheckNull(objtxt)) 
	{
		eval(objtxt).value = '';				
		if (eval(objtxt).name.substring(eval(objtxt).name.length - 1 ) !=  '1'){
			alert(msg);
			eval(objtxt).value = '';
			eval(objtxt).focus();
			return false;
		}
		else
			return true;
	}
	if ((isNaN(eval(objtxt).value)) || (eval(objtxt).value.length > 2 ) || (eval(objtxt).value < 0) || (eval(objtxt).value > 23)){		
		alert(msg);
		eval(objtxt).value = '';
		eval(objtxt).focus();
		return false;
	 }	 
	 return true;
}
function CheckMinus(objtxt,msg){
	if (CheckNull(objtxt)) 
	{
		eval(objtxt).value = '';				
		if (eval(objtxt).name.substring(eval(objtxt).name.length - 1 ) !=  '1'){			
			alert(msg);
			eval(objtxt).value = '';
			eval(objtxt).focus();
			return false;
		}
		else
			return true;
	}
	if ((isNaN(eval(objtxt).value)) || (eval(objtxt).value.length > 2 ) || (eval(objtxt).value < 0) || (eval(objtxt).value > 59)){
		alert(msg);
		eval(objtxt).value = '';
		eval(objtxt).focus();
		return false;
	 }	 
	 return true;
}
function CheckAll(msg){
	return true;
}
