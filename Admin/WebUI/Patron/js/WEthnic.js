function CheckInserUpdate(field,strNote) {
		if (eval(field+'txtdtgEthnic').value =="") {
				alert(strNote);
				eval(field+'txtdtgEthnic').focus();
				return false;
			}
		return true;	
}