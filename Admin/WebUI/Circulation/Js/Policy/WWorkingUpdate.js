function CheckHour(objtxt,msg){
	if (CheckNull(objtxt)) {
		eval(objtxt).value = '';
	}
	eval(objtxt).value = trim(eval(objtxt).value);
	if ((isNaN(eval(objtxt).value)) || (eval(objtxt).value.length > 2 ) || (eval(objtxt).value < 0) || (eval(objtxt).value > 23)){		
		alert(msg);
		eval(objtxt).value = '';
		eval(objtxt).focus();
		return false;
	 }
	 return true;
}
function CheckMinus(objtxt,msg){
	if (CheckNull(objtxt)) {
		eval(objtxt).value = '';
	}
	eval(objtxt).value = trim(eval(objtxt).value);
	if ((isNaN(eval(objtxt).value)) || (eval(objtxt).value.length > 2 ) || (eval(objtxt).value < 0) || (eval(objtxt).value > 59)){
		alert(msg);
		eval(objtxt).value = '';
		eval(objtxt).focus();
		return false;
	 }	 
	 return true;
}
function Compare(objtxt1,objtxt2){
	if(eval(objtxt1).value <= eval(objtxt2).value)
	{
		eval(objtxt1).value = '';
		eval(objtxt1).focus();
		return false;
	}
	return true;
}