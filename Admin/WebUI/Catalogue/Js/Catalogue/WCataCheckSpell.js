var spellCheckURL="WCataCheckSpellResult.aspx"; // change to point to the JSpell Spell Check Servlet
var styleSheetURL=""; //"jspell.css";
var imagePath="/images"; // relative URL to JSpell button images directory
var ww;	// holds reference to popup
var disableLearn=false; // set to true, to remove the Learn words capability
var forceUpperCase=false; // force suggestions and spell checker to use upper case
var ignoreIrregularCaps=false;	// ignore lower case sentence beginnings, etc.
var ignoreFirstCaps=false;	// ignore if first character in a field is lowercase
var ignoreNumbers=false; // ignore words with embedded numbers
var ignoreUpper=false; // ignore words in upper case
var ignoreDouble=false; // ignore repeated words
var confirmAfterLearn=false; // show warning before user 'learns' a word
var confirmAfterReplace=true; // show warning when replacing using a word not in the suggestions list.
var supplementalDictionary=""; // optional supplemental word list kept at server.
var hidePreviewPanel=false; // You can use this to hide the preview panel when running in directEdit mode in IE
var directMode=false; // is highlighting done in original text control or is there a preview panel (IE Windows only)

function update() {
	lines = new Array();
	contents = document.forms[0].txtMyField.value;
	lines = split(contents, "\r\n");
	curVal = ""
	curTag = ""
	for (i = 0; i < lines.length; i++) {
		if (lines[i] == "") {
			curVal = curVal + "$&";
			if (curTag != "") {
				formVal = eval("opener.top.main.Sentform.document.forms[0].tag" + curTag + ".value");
				if (formVal != curVal) {
					u(curTag);
				}
				eval("opener.top.main.Sentform.document.forms[0].tag" + curTag + ".value = \"" + curVal + "\"");
			}
		}
		else {
			thisTag = lines[i].substring(0, 3);
			thisVal = lines[i].substring(4, lines[i].length);
			if (thisTag != curTag) {
				if (curTag != "") {
					formVal = eval("opener.top.main.Sentform.document.forms[0].tag" + curTag + ".value");
					if (formVal != curVal) {
						u(curTag);
					}
					eval("opener.top.main.Sentform.document.forms[0].tag" + curTag + ".value = \"" + curVal + "\"");
				}
				curTag = thisTag;
				curVal = thisVal;
			}
			else {
				curVal = curVal + "$&" + thisVal;
			}
		}
	}
	if (curTag != "") {
			formVal = eval("opener.top.main.Sentform.document.forms[0].tag" + curTag + ".value");
			if (formVal != curVal) {
				u(curTag);
			}
			eval("opener.top.main.Sentform.document.forms[0].tag" + curTag + ".value = \"" + curVal + "\"");
	}
	opener.top.main.Workform.UpdateLeader("", "", "", "");
	opener.top.main.Workform.location.href = opener.top.main.Workform.location.href;
	self.close();
}

function split(str, deli) {
	myarr = new Array();
	j = 0
	while (str.length > 0) {
		idx = str.indexOf(deli);
		if (idx >= 0) {
			myarr[j] = str.substring(0, idx);
			str = str.substring(idx + deli.length, str.length);
			j++;
		}
		else {
			myarr[j] = str;
			str = "";
		}
	}
	return myarr;
}

function getSpellCheckItem(jspell_n) {
	var fieldsToCheck=getSpellCheckArray();
	return fieldsToCheck[jspell_n];
}

function getSpellCheckArray() {
	var fieldsToCheck=new Array();

	// make sure to enclose form/field object reference in quotes!
	fieldsToCheck[fieldsToCheck.length]='document.forms[0].txtMyField';
	return fieldsToCheck;
}

function spellcheck() {
	var width=450;
	var height=215;
	if (navigator.appName == 'Microsoft Internet Explorer' && navigator.userAgent.toLowerCase().indexOf("opera")==-1 && hidePreviewPanel==false) {	
		directmode=true; width=280;
	}

	if(hidePreviewPanel==true) {
		width=280;
	}

	var w = 1024;
	var h = 768;
	if (document.all || document.layers) {
		w=eval("scre"+"en.availWidth"); 
		h=eval("scre"+"en.availHeight");
	}

	var leftPos = (w/2-width/2), topPos = (h/2-height/2);
	
	// need to check if window is already open.
	ww=window.open("WSpelling.aspx", "Checker", "width="+width+",height="+height+",top="+topPos+",left="+leftPos+",toolbar=no,status=no,menubar=no,directories=no,resizable=yes");
	ww.focus();
}

function updateForm(jspell_m,newvalue) {
	eval(getSpellCheckItemValue(jspell_m)+"=newvalue"); 
}

function getSpellCheckItemValue(jspell_j) {
	return getSpellCheckItem(jspell_j)+".value";
}

function getSpellCheckItemValueValue(jspell_k) { 
	return eval(getSpellCheckItemValue(jspell_k)); 
}

function u(tag) {
	/*if (opener.top.main.Sentform.document.forms[0].ModifiedTags.value.indexOf(tag) < 0) 
	{
		opener.top.main.Sentform.document.forms[0].ModifiedTags.value = opener.top.main.Sentform.document.forms[0].ModifiedTags.value + tag + ",";
	}
	*/
}
