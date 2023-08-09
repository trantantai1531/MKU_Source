function CheckInserUpdate(field,strNote) {
		if (trim(eval(field+'txtHostNamedtg').value =="")) {
				alert(strNote);
				eval(field+'txtHostNamedtg').focus();
				return false;
			}
		return true;	
}
