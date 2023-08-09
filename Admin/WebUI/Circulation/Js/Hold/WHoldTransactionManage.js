function rdoReservEvent() {
	if (document.forms[0].rdoOutTurn.checked) {
		document.forms[0].txtFrom.focus();
		document.forms[0].rdoOutTurn.checked = false;
		document.forms[0].hidReserv.value = "0";
	} else {
		document.forms[0].txtFrom.focus();
		document.forms[0].hidReserv.value = "0";
	}
}

function rdoOutTurnEvent() {
	if (document.forms[0].rdoResrv.checked) {
		document.forms[0].txtFrom.focus();
		document.forms[0].rdoResrv.checked = false;
		document.forms[0].hidReserv.value = "1";
	} else {
		document.forms[0].txtFrom.focus();
		document.forms[0].hidReserv.value = "1";
	}
}

function rdoTitleEvent() 
{
	if (document.forms[0].rdoPatron.checked) {
		document.forms[0].txtTitlePatron.focus();
		document.forms[0].rdoPatron.checked = false;
		document.forms[0].hidTitlePatron.value = "0";
	} else {
		document.forms[0].txtTitlePatron.focus();
		document.forms[0].hidTitlePatron.value = "0";
	}
}

function rdoPatronEvent()
{
	if (document.forms[0].rdoTitle.checked) {
		document.forms[0].txtTitlePatron.focus();
		document.forms[0].rdoTitle.checked = false;
		document.forms[0].hidTitlePatron.value = "1"
	} else {
		document.forms[0].txtTitlePatron.focus();
		document.forms[0].hidTitlePatron.value = "1"
	}
}

function OutTurn(val)
{
	document.forms[0].hidOutTurn.value = val;
}

function ChangeTurn(val)
{
	document.forms[0].hidChangeTurn.value = val;
}




