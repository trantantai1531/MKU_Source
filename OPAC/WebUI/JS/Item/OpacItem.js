// function show or hide a table
function ShowHideTable(idtable,show) {
	if(show) {
		idtable.style.display="";
	}
	else {
		idtable.style.display="none";
	}
}
// function: go to form submit
function GoSubmit(lnkURL) {
	document.forms[0].action=lnkURL;
	document.forms[0].submit();
}

function CheckEmail(strNote,strErrEmail) {	
	if (document.forms[0].optDesEmail.checked) {
		if(document.forms[0].txtEmail.value=="") {
			alert(strNote);
			document.forms[0].txtEmail.focus();
			return false;
		}
		if (!CheckValidEmail('document.forms[0].txtEmail')) {
			alert(strErrEmail);
			document.forms[0].txtEmail.focus();
			return false;	
		}
	}
	return true;	
}

function ComeBack() {
	window.location="WHiddenItem.aspx";
}

function ShowHideTableAction(val) {
	if (val==0) {
		tblSavedFile.style.display="";
		tblShow.style.display="none";
	}
	else {
		tblSavedFile.style.display="none";
		tblShow.style.display="";					
	}
}
