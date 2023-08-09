
function MoveFirst(strMess) {
	if (parseFloat(document.forms[0].txtCurrentpage.value) <= 1) {
		alert(strMess);
	} else {
		document.forms[0].txtCurrentpage.value = 1;
		RefreshForm(1)
	}
}

/*
	MovePrev function
*/
function MovePrev(strMess) {
	if (parseFloat(document.forms[0].txtCurrentpage.value) <= 1) {
		alert(strMess);
	} else {
		document.forms[0].txtCurrentpage.value = parseFloat(document.forms[0].txtCurrentpage.value) - 1;
		RefreshForm(document.forms[0].txtCurrentpage.value)
	}
}

/*
	MoveNext function
*/
function MoveNext(strMess) {	
	if (parseFloat(document.forms[0].txtCurrentpage.value) >= parseFloat(document.forms[0].hidMaxId.value)) {
		alert(strMess);
	} else {
		document.forms[0].txtCurrentpage.value = parseFloat(document.forms[0].txtCurrentpage.value) + 1;
		RefreshForm(document.forms[0].txtCurrentpage.value)
	}
}

/*
	MoveLast function
*/
function MoveLast(strMess) {
	if (parseFloat(document.forms[0].txtCurrentpage.value) == parseFloat(document.forms[0].hidMaxId.value)) {
		alert(strMess);
	} else {
		document.forms[0].txtCurrentpage.value = parseFloat(document.forms[0].hidMaxId.value);
		RefreshForm(document.forms[0].txtCurrentpage.value)
	}
}

/*
	Goto function
*/
function Goto(strMess, strMess1) {
	if (!CheckNum(document.forms[0].txtCurrentpage,strMess1)) {
		alert(strMess1);
		document.forms[0].txtCurrentpage.value=document.forms[0].hidMaxId.value;	
	}
	if ((parseFloat(document.forms[0].txtCurrentpage.value) > parseFloat(document.forms[0].hidMaxId.value)) | (parseFloat(document.forms[0].txtCurrentpage.value) < 1)) {
		alert(strMess);
	} else {
		RefreshForm(document.forms[0].txtCurrentpage.value)		
	}
}

// RefreshForm method (By ID)
function RefreshForm(intItemNum) {
	parent.Workform.location.href="WIDXView.aspx?intPg="+intItemNum;
}	