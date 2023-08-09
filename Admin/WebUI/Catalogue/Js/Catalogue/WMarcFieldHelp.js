var curtab = 1;
var maxtab = 1;

function AddTag(n) {
	document.forms[0].txtFieldCount.value = parseFloat(document.forms[0].txtFieldCount.value) + 1;
	document.forms[0].txtBreakType.value = "add";
	document.forms[0].txtBreakPoint.value = n;
	document.forms[0].action = 'WMarcFieldHelp.aspx';
	document.forms[0].submit();
}

function RemoveTag(n) {
	document.forms[0].txtFieldCount.value = parseFloat(document.forms[0].txtFieldCount.value) - 1;
	document.forms[0].txtBreakType.value = "rem";
	document.forms[0].txtBreakPoint.value = n;
	document.forms[0].action = 'WMarcFieldHelp.aspx';
	document.forms[0].submit();
}

function mOvr(src,clrOver) { 
	if (!src.contains(event.fromElement)) { 
		src.style.cursor = 'default'; 
		src.bgColor = clrOver; 
	}
}

function mOut(src,clrIn) { 
	if (!src.contains(event.toElement)) { 
		src.style.cursor = 'default';
		src.bgColor = clrIn; 
	}
}

function PickTag(a, k, v, strMsg) {
	var intCounter;
	var strUsedTags = "";
	var intTagCount = parseFloat(document.forms[0].txtFieldCount.value);
	for (intCounter = 1; intCounter <= intTagCount; intCounter++) {
		if (intCounter != k) {
			strUsedTags = strUsedTags + eval("document.forms[0].TPick" + intCounter + ".options[document.forms[0].TPick" + intCounter + ".selectedIndex].value") + ",";
		}
	}
	for (intCounter = 0; intCounter < Tags.length; intCounter++) {
		if (Tags[intCounter].taglabel == a) {
			if (Tags[intCounter].tagrepeat == 1 || (Tags[intCounter].tagrepeat == 0 && strUsedTags.indexOf(a + ",") < 0)) {
				eval("document.forms[0].TName" + k + ".value = '" + Tags[intCounter].tagname + "';");
				if (v != '') {
					eval("document.forms[0].TSign" + k + ".value = '" + v + "'");
				} else {
					AddSign(document.forms[0].txtFieldCode.value + a, k)
				}
			} else {
				alert(a + ": " + strMsg);
				eval("document.forms[0].TPick" + k + ".selectedIndex = 0;");
			}
			break;
		}
	}
}

function AddSign (strSubField, intIndex) {
	if (strSubField == "245$b") 
		eval("document.forms[0].TSign" + intIndex + ".value = ':';");
	else if (strSubField == "245$c") 
		eval("document.forms[0].TSign" + intIndex + ".value = '/';");
	else if (strSubField == "245$n") 
		eval("document.forms[0].TSign" + intIndex + ".value = '.';");
	else if (strSubField == "245$p") 
		eval("document.forms[0].TSign" + intIndex + ".value = ',';");
	else if (strSubField == "020$c") 
		eval("document.forms[0].TSign" + intIndex + ".value = ':';");
	else if (strSubField == "100$b") 
		eval("document.forms[0].TSign" + intIndex + ".value = ',';");
	else if (strSubField == "100$c") 
		eval("document.forms[0].TSign" + intIndex + ".value = ',';");
	else if (strSubField == "100$d") 
		eval("document.forms[0].TSign" + intIndex + ".value = ',';");
	else if (strSubField == "110$b") 
		eval("document.forms[0].TSign" + intIndex + ".value = '.';");
	else if (strSubField == "020$c") 
		eval("document.forms[0].TSign" + intIndex + ".value = ':';");
	else if (strSubField == "250$b") 
		eval("document.forms[0].TSign" + intIndex + ".value = '/';");
	else if (strSubField == "260$b") 
		eval("document.forms[0].TSign" + intIndex + ".value = ':';");
	else if (strSubField == "260$c") 
		eval("document.forms[0].TSign" + intIndex + ".value = ',';");
	else if (strSubField == "300$b") 
		eval("document.forms[0].TSign" + intIndex + ".value = ':';");
	else if (strSubField == "300$c") 
		eval("document.forms[0].TSign" + intIndex + ".value = ';';");
	else if (strSubField == "300$e") 
		eval("document.forms[0].TSign" + intIndex + ".value = '+';");
	else if (strSubField == "440$b") 
		eval("document.forms[0].TSign" + intIndex + ".value = ':';");
	else if (strSubField == "440$v") 
		eval("document.forms[0].TSign" + intIndex + ".value = ';';");
	else if (strSubField == "440$n") 
		eval("document.forms[0].TSign" + intIndex + ".value = '.';");
	else if (strSubField == "440$p") 
		eval("document.forms[0].TSign" + intIndex + ".value = ',';");
	else if (strSubField == "440$x") 
		eval("document.forms[0].TSign" + intIndex + ".value = ',';");
}

function thisMicrosoftKeyPress() {
	if (window.event.keyCode == 13) {
		if (eval("document.forms[0].TPick" + (curtab + 1))) {
			eval("document.forms[0].TPick" + (curtab + 1) + ".focus()");
		}
		window.event.keyCode = 27;
	}
}