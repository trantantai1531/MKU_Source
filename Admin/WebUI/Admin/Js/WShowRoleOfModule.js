// Add ca'c ID va`o ID quye^`n cu?a ngu+o+`i du`ng
function AddItems(){
	var k = 0;
	for (i = 0; i < document.forms[0].lstDeny.length; i++) {
		if (document.forms[0].lstDeny.options[i].selected) {
			document.forms[0].lstAccept.options.length++;
			document.forms[0].lstAccept.options[document.forms[0].lstAccept.options.length- 1].value = document.forms[0].lstDeny.options[i].value;
			document.forms[0].lstAccept.options[document.forms[0].lstAccept.options.length- 1].text = document.forms[0].lstDeny.options[i].text;
			opener.document.forms[0].hidRights.value += document.forms[0].lstDeny.options[i].value + ',';
		} else {
			document.forms[0].lstDeny.options[k].value =document.forms[0].lstDeny.options[i].value;
			document.forms[0].lstDeny.options[k].text =document.forms[0].lstDeny.options[i].text;
			document.forms[0].lstDeny.options[k].selected = false;
			k = k + 1;
		}
	}
	document.forms[0].lstDeny.options.length = k;
}

//  Remove ca'c ID ra kho?i ca'c ID quye^`n cu?a ngu+o+`i du`ng
function RemoveItems(){
	var k = 0;
	for (i = 0; i < document.forms[0].lstAccept.length; i++) {
		if (document.forms[0].lstAccept.options[i].selected) {
			document.forms[0].lstDeny.options.length++;
			document.forms[0].lstDeny.options[document.forms[0].lstDeny.options.length- 1].value = document.forms[0].lstAccept.options[i].value;
			document.forms[0].lstDeny.options[document.forms[0].lstDeny.options.length- 1].text = document.forms[0].lstAccept.options[i].text;
			RemoveItem(document.forms[0].lstAccept.options[i].value);
		} else {
			document.forms[0].lstAccept.options[k].value =document.forms[0].lstAccept.options[i].value;
			document.forms[0].lstAccept.options[k].text =document.forms[0].lstAccept.options[i].text;
			document.forms[0].lstAccept.options[k].selected = false;
			k = k + 1;
		}
	}
	document.forms[0].lstAccept.options.length = k;
//	alert(opener.document.forms[0].Rights.value);
}


// Remove 1 Item ra kho?i mo^.t xa^u
function RemoveItem(Item){
	Item = Item + ',';
	Str = opener.document.forms[0].hidRights.value;
	if (Str.indexOf(Item) != -1) {
		Str = Str.replace(Item, '')
	}
	opener.document.forms[0].hidRights.value = Str;
}


function AddLocs(Loc){
	var k = 0;
	for (i = 0; i < document.forms[0].lstLocDeny.length; i++) {
		if (document.forms[0].lstLocDeny.options[i].selected) {
			document.forms[0].lstLocAccept.options.length++;
			document.forms[0].lstLocAccept.options[document.forms[0].lstLocAccept.options.length- 1].value = document.forms[0].lstLocDeny.options[i].value;
			document.forms[0].lstLocAccept.options[document.forms[0].lstLocAccept.options.length- 1].text = document.forms[0].lstLocDeny.options[i].text;
			eval(Loc).value += document.forms[0].lstLocDeny.options[i].value + ',';
		} else {
			document.forms[0].lstLocDeny.options[k].value =document.forms[0].lstLocDeny.options[i].value;
			document.forms[0].lstLocDeny.options[k].text =document.forms[0].lstLocDeny.options[i].text;
			document.forms[0].lstLocDeny.options[k].selected = false;
			k = k + 1;
		}
	}
	document.forms[0].lstLocDeny.options.length = k;
}
function RemoveLocs(Loc){
	var k = 0;
	for (i = 0; i < document.forms[0].lstLocAccept.length; i++) {
		if (document.forms[0].lstLocAccept.options[i].selected) {
			document.forms[0].lstLocDeny.options.length++;
			document.forms[0].lstLocDeny.options[document.forms[0].lstLocDeny.options.length- 1].value = document.forms[0].lstLocAccept.options[i].value;
			document.forms[0].lstLocDeny.options[document.forms[0].lstLocDeny.options.length- 1].text = document.forms[0].lstLocAccept.options[i].text;
			RemLoc(document.forms[0].lstLocAccept.options[i].value, Loc);
		} else {
			document.forms[0].lstLocAccept.options[k].value =document.forms[0].lstLocAccept.options[i].value;
			document.forms[0].lstLocAccept.options[k].text =document.forms[0].lstLocAccept.options[i].text;
			document.forms[0].lstLocAccept.options[k].selected = false;
			k = k + 1;
		}
	}
	document.forms[0].lstLocAccept.options.length = k;
}

function RemLoc(Item, Loc){
	Item = Item + ',';
	Str = eval(Loc).value;
	if (Str.indexOf(Item) != -1) {
		Str = Str.replace(Item, '')
	}
	eval(Loc).value = Str;
}