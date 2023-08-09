function Continue (strMsg5) {
	if (confirm(strMsg5)) {
		parent.CheckOut.document.forms[0].hidLoanMode.value=3; 
		parent.CheckOut.document.forms[0].hidContinue.value=1;
		//parent.CheckOut.document.forms[0].btnCheckOut.disabled = true;
		console.log(parent);
		parent.CheckOut.document.forms[0].btnCheckOut.click();
		//parent.CheckOut.document.forms[0].submit();
	}
	else {
		parent.CheckOut.document.forms[0].btnCheckOut.disabled=true;
		parent.CheckOut.document.forms[0].txtCopyNumber.value='';		
		parent.CheckOut.document.forms[0].txtCopyNumber.focus();
	}
}
function CheckPatronCode(strMsg3, fltNumber, patronCode,loanMode) {
    console.log(patronCode);
    parent.CheckOutMain.location.href = '../WCheckPatronCode.aspx?x=' + fltNumber + '&PatronCode=' + patronCode + '&LoanMode=' + loanMode;
}