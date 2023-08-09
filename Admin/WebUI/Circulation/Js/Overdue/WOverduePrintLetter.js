//creator: sondp
//createdate: 27/08/2004
//method Add Item from Source listbox to Destion listbox
function AddItem(){
var k = 0;
	for (i = 0; i < document.forms[0].lsbAllOverduePatron.length; i++) {
		if(document.forms[0].lsbAllOverduePatron.options[i].selected) {
			document.forms[0].lsbPickPatron.length++;
			document.forms[0].lsbPickPatron.options[(document.forms[0].lsbPickPatron.length)- 1].value = document.forms[0].lsbAllOverduePatron.options[i].value;
			document.forms[0].lsbPickPatron.options[(document.forms[0].lsbPickPatron.length)- 1].text = document.forms[0].lsbAllOverduePatron.options[i].text;
		}
		else {document.forms[0].lsbAllOverduePatron.options[k].value =document.forms[0].lsbAllOverduePatron.options[i].value;
			document.forms[0].lsbAllOverduePatron.options[k].text =document.forms[0].lsbAllOverduePatron.options[i].text;
			document.forms[0].lsbAllOverduePatron.options[k].selected = false;
            k = k + 1;
		}
	}
	document.forms[0].lsbAllOverduePatron.length = k;
var strCollum='';	
	for (i=0;i<document.forms[0].lsbPickPatron.length;i++){
		strCollum+=document.forms[0].lsbPickPatron.options[i].value + ',';
	}
	if (strCollum.length>0)	document.forms[0].txtPickPatron.value=strCollum.substring(0,(strCollum.length)-1);
	else document.forms[0].txtPickPatron.value='';	
	return(true);
}
//method Remove Item 
function RemoveItem(){
var k=0;              
var strCollum='';
	for (i = 0; i < document.forms[0].lsbPickPatron.length; i++) {	
		if(document.forms[0].lsbPickPatron.options[i].selected) {
			document.forms[0].lsbAllOverduePatron.length++;
			document.forms[0].lsbAllOverduePatron.options[(document.forms[0].lsbAllOverduePatron.length)- 1].value = document.forms[0].lsbPickPatron.options[i].value;
			document.forms[0].lsbAllOverduePatron.options[(document.forms[0].lsbAllOverduePatron.length)- 1].text = document.forms[0].lsbPickPatron.options[i].text;

		}
		else {document.forms[0].lsbPickPatron.options[k].value =document.forms[0].lsbPickPatron.options[i].value;
		document.forms[0].lsbPickPatron.options[k].text =document.forms[0].lsbPickPatron.options[i].text;
		document.forms[0].lsbPickPatron.options[k].selected = false;
		k = k + 1;
		strCollum+=document.forms[0].lsbPickPatron.options[i].value + ',';
		}
}		
	document.forms[0].lsbPickPatron.length = k;
	if(strCollum.length>0)	document.forms[0].txtPickPatron.value=strCollum.substring(0,(strCollum.length)-1);
	else document.forms[0].txtPickPatron.value='';
	return(true);
}
// method print letter
function PrintLetter(strSelectPatron,strSelectTemplate){
	if((document.forms[0].txtPickPatron.value=='') && (document.forms[0].txtOverduePrintMode.value == 2 )){
		alert(strSelectPatron);
		document.forms[0].lsbAllOverduePatron.focus();
		return(false);
	}
	if(document.forms[0].ddlOverdueTemplate.options[document.forms[0].ddlOverdueTemplate.options.selectedIndex].value==0){
		alert(strSelectTemplate);
		document.forms[0].ddlOverdueTemplate.focus();
		return(false);
	}
	document.forms[0].action='WOrverduePrintLetterResult.aspx';
	document.forms[0].method='post';
	document.forms[0].submit();	
	return(true);
}


// reset form
function ResetForm(){
	document.forms[0].reset();
	for (i = 0; i < document.forms[0].lsbPickPatron.length; i++) {	
			document.forms[0].lsbAllOverduePatron.length++;
			document.forms[0].lsbAllOverduePatron.options[(document.forms[0].lsbAllOverduePatron.length)- 1].value = document.forms[0].lsbPickPatron.options[i].value;
			document.forms[0].lsbAllOverduePatron.options[(document.forms[0].lsbAllOverduePatron.length)- 1].text = document.forms[0].lsbPickPatron.options[i].text;

		}
	document.forms[0].lsbPickPatron.length = 0;
	document.forms[0].txtPickPatron.value='';	
	return(false);
}
