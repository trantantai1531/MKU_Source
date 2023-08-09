function AutoPaidFees() {
	if (parent.CheckIn.document.forms[0].chkAutoPaidFees.checked) {
		document.forms[0].hidAutoPaidFees.value=1;
	} else {
		document.forms[0].hidAutoPaidFees.value=0;
	}
}