function ChangeMode() {
	var i;
	i=document.forms[0].ddlMode.options[document.forms[0].ddlMode.selectedIndex].value;
	if (i == 0) {
		parent.location.href = 'WReceiveFrame.aspx';
	}
	else if (i == 1) {
		parent.location.href = 'WInvenFrame.aspx';
	}
	else if (i == 2) {
		parent.location.href = 'WLostFrame.aspx';
	}
}