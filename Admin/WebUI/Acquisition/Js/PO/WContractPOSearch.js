/*
	reset value of all form's controls
*/
function Reset() {
	document.forms[0].txtReceiptNo.value = '';
	document.forms[0].txtValidDateFrom.value = '';
	document.forms[0].txtPoName.value = '';
	document.forms[0].txtValidDateTo.value = '';
	document.forms[0].txtAmountTo.value = '';
	document.forms[0].txtTitle.value = '';
	document.forms[0].txtAuthor.value = '';
	document.forms[0].txtPublisher.value = '';
	document.forms[0].txtPubYear.value = '';
	document.forms[0].txtISBN.value = '';
	document.forms[0].txtAmountFrom.value = '';
	document.forms[0].ddlVendor.options[0].selected=true;      
	document.forms[0].ddlCurrency.options[0].selected=true;
	document.forms[0].ddlBudget.options[0].selected=true;
}

/*
	Submit to WPoTaskbar.aspx on taskbar
*/
function Filter(){
	document.forms[0].action='WContractTaskbar.aspx';
	document.forms[0].target='taskbar';
	document.forms[0].submit();
}



/*
	Code not in form, because they in to 
 */

/*
	Functions below used to move to the selected contract	
	- MoveFirst: Move to the first contract
	- MoveLast: Move to the last contract
	- MoveNext: Move to the next contract of the current contract
	- MovePrev: Move to the prev contract of the current contract	
	- MoveTo: Move to the selected contract
	- NewContract: Create a new contract
*/

function NewContract() {
	parent.workwin.location.href='WPoCreate.aspx';
}

function Filter() {
	parent.workwin.location.href='WContractPOSearch.aspx';
}

function Go(i, k) {
	if (isNaN(document.forms[0].txtCurrentID.value) || (parseFloat(document.forms[0].txtCurrentID.value) != parseFloat(document.forms[0].txtCurrentID.value))) {
		i = 0;
	}
	if ((parseFloat(document.forms[0].txtCurrentID.value) > k + 1 && i != 0 && i != 3) || (parseFloat(document.forms[0].txtCurrentID.value) == k + 1 && i == 2)) {
		i = 3;
	}
	if ((parseFloat(document.forms[0].txtCurrentID.value) < 1 && i != 0 && i != 3) || (parseFloat(document.forms[0].txtCurrentID.value) == 1 && i == 1)) {
		i = 0;
	}	
	if (i == 0) {
		parent.workwin.location.href = "WProcessContract.aspx?FilterOn=1&PoID=" + arrPoID[0];
		document.forms[0].txtCurrentID.value = 1;
	} else if (i == 3) {
		parent.workwin.location.href = "WProcessContract.aspx?FilterOn=1&PoID=" + arrPoID[k];
		document.forms[0].txtCurrentID.value = k + 1;
	} else if (i == 1) {
		parent.workwin.location.href = "WProcessContract.aspx?FilterOn=1&PoID=" + arrPoID[parseFloat(document.forms[0].txtCurrentID.value) - 2];
		document.forms[0].txtCurrentID.value = parseFloat(document.forms[0].txtCurrentID.value) - 1;
	} else if (i == 2) {
		parent.workwin.location.href = "WProcessContract.aspx?FilterOn=1&PoID=" + arrPoID[parseFloat(document.forms[0].txtCurrentID.value)];
		document.forms[0].txtCurrentID.value = parseFloat(document.forms[0].txtCurrentID.value) + 1;
	} else if (i == 4) {
		parent.workwin.location.href = "WProcessContract.aspx?FilterOn=1&PoID=" + arrPoID[parseFloat(document.forms[0].txtCurrentID.value) - 1];
	}
}

function GoTo(i) {
	parent.workwin.location.href = "WProcessContract.aspx?direction=" + i + "&PoID=" + document.forms[0].txtCurrentID.value;
}

function Browse() {
	parent.workwin.location.href = "WContractPOBrowse.aspx.aspx?BrowseType=" + document.forms[0].ddlBrowseType.options[document.forms[0].ddlBrowseType.options.selectedIndex].value;
}
