/*
	NewContract function
*/
function NewContract() {
	parent.workwin.location.href='WContractCreate.aspx';
}

/*
	Filter function
*/
function Filter() {
	parent.workwin.location.href='WContractPOSearch.aspx';
}

/*
	Browse function
*/
function Browse() {
	parent.workwin.location.href = "WContractPOBrowse.aspx?BrowseType=" + document.forms[0].ddlBrowseType.options[document.forms[0].ddlBrowseType.options.selectedIndex].value;
}

/*
	MoveFirst function
*/
function MoveNext(strMess) {
	if (parseFloat(document.forms[0].txtCurrentID.value) <= 1) {
		alert(strMess);
	} else {
		parent.workwin.location.href = "WContractDetail.aspx?Pos=1"
	}
}

/*
	MovePrev function
*/
function MovePrev(strMess) {
	if (parseFloat(document.forms[0].txtCurrentID.value) <= 1) {
		alert(strMess);
	} else {
		parent.workwin.location.href = "WContractDetail.aspx?Pos=" + parseFloat(document.forms[0].txtCurrentID.value) - 1;
	}
}

/*
	MoveNext function
*/
function MoveNext(strMess) {
	if (parseFloat(document.forms[0].txtCurrentID.value) >= parseFloat(document.forms[0].txtMaxID.value)) {
		alert(strMess);
	} else {
		parent.workwin.location.href = "WContractDetail.aspx?Pos=" + parseFloat(document.forms[0].txtCurrentID.value) + 1;
	}
}

/*
	MoveLast function
*/
function MoveLast(strMess) {
	if (parseFloat(document.forms[0].txtCurrentID.value) = parseFloat(document.forms[0].txtMaxID.value)) {
		alert(strMess);
	} else {
		parent.workwin.location.href = "WContractDetail.aspx?Pos=" + parseFloat(document.forms[0].txtMaxID.value);
	}
}

/*
	Goto function
*/
function Goto(strMess, strMess1)() {		
	if (!CheckNumber('document.forms[0].txtCurrentID',strMess1,'1')) {		
		alert(strMess1);
		document.forms[0].txtCurrentID.value=document.forms[0].txtMaxID.value;		
	}
	if ((parseFloat(document.forms[0].txtCurrentID.value) > parseFloat(document.forms[0].txtMaxID.value)) | (parseFloat(document.forms[0].txtCurrentID.value) < 1)) {
		alert(strMess);
	} else {
		parent.workwin.location.href = "WContractDetail.aspx?Pos=" + parseFloat(document.forms[0].txtCurrentID.value);
	}
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