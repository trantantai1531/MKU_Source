

function CheckInput(strMsg1, strMsg2) {
	
	if (CheckNull(document.forms[0].txtEnglishVocabuary)) {
	    alert(strMsg1);
	    console.log(1);
	    document.forms[0].txtEnglishVocabuary.focus();
		return false;
	}else{
	    if (CheckNull(document.forms[0].txtMean)) {
	        alert(strMsg2);
	        console.log(2);
	        document.forms[0].txtMean.focus();
	        return false;
	    }
	}
}
