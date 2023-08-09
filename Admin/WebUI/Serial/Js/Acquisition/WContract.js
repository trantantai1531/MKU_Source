/*
	NewContract function
*/	
function NewContract() {
	parent.workform.location.href='WContractCreate.aspx';
}

/*
	Filter function
*/
function Filter() {
	parent.workform.location.href='WContractFilter.aspx';
}

/*
	Browse function
*/
function Browse() {
	parent.workform.location.href = 'WContractBrowse.aspx?BrowseType=' + document.forms[0].ddlBrowseType.options[document.forms[0].ddlBrowseType.options.selectedIndex].value;
}

/*
	MoveFirst function
*/
function MoveFirst(strMess) {
	if (parseFloat(document.forms[0].txtCurrentID.value) <= 1) {
		alert(strMess);
	} else {
		document.forms[0].txtCurrentID.value = 1;
		parent.workform.location.href = 'WContractDetail.aspx?Pos=1';
	}
}

/*
	MovePrev function
*/
function MovePrev(strMess) {
	if (parseFloat(document.forms[0].txtCurrentID.value) <= 1) {
		alert(strMess);
	} else {
		document.forms[0].txtCurrentID.value = parseFloat(document.forms[0].txtCurrentID.value) - 1;
		parent.workform.location.href = "WContractDetail.aspx?Pos=" + document.forms[0].txtCurrentID.value;
	}
}

/*
	MoveNext function
*/
function MoveNext(strMess) {
	if (parseFloat(document.forms[0].txtCurrentID.value) >= parseFloat(document.forms[0].txtMaxID.value)) {
		alert(strMess);
	} else {
		document.forms[0].txtCurrentID.value = parseFloat(document.forms[0].txtCurrentID.value) + 1;
		parent.workform.location.href = "WContractDetail.aspx?Pos=" + parseFloat(document.forms[0].txtCurrentID.value);
	}
}

/*
	MoveLast function
*/
function MoveLast(strMess) {
	if (parseFloat(document.forms[0].txtCurrentID.value) == parseFloat(document.forms[0].txtMaxID.value)) {
		alert(strMess);
	} else {
		document.forms[0].txtCurrentID.value = parseFloat(document.forms[0].txtMaxID.value);
		parent.workform.location.href = "WContractDetail.aspx?Pos=" + parseFloat(document.forms[0].txtCurrentID.value);
	}
}

/*
	Goto function
*/
function Goto(strMess, strMess1) {
	if (!CheckNum(document.forms[0].txtCurrentID)) {
		alert(strMess1);
		return;
	}
	if ((parseFloat(document.forms[0].txtCurrentID.value) > parseFloat(document.forms[0].txtMaxID.value)) | (parseFloat(document.forms[0].txtCurrentID.value) < 1)) {
		alert(strMess);
	} else {
		parent.workform.location.href = "WContractDetail.aspx?Pos=" + parseFloat(document.forms[0].txtCurrentID.value);
	}
}

/*
	AddThis function
*/
function AddThis(strValue) {
	strItemIDs = document.forms[0].txbItemIDs.value;
	intPosition = strItemIDs.indexOf("," + strValue + ",");
	if (intPosition <= 0) {
		document.forms[0].txbItemIDs.value = strItemIDs + strValue + ",";
	}
}

/*
	AddThis function
*/
function RemoveThis(strValue) {
	strItemIDs = document.forms[0].txbItemIDs.value;
	intPosition = strItemIDs.indexOf("," + strValue + ",");
	if (intPosition >= 0 ) {
		strHeader = strItemIDs.substring(0, intPosition);
		strTrailer = strItemIDs.substring(intPosition + strValue.length + 1, strItemIDs.length);
		document.forms[0].txbItemIDs.value = strHeader + strTrailer;
	}
}