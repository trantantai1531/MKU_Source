//method: ReplaceSubstring
//Purpose: Replate String
//In: string source, string find, string replate
//Out: string source
//Creator: Tuanhv
//CreatedDate: 07/11/2004

//xreplace relpale function in .NET
//Creater: Tuanhv
function xreplace(inputString,fromString,toString){
	var temp = inputString;
	var i = temp.indexOf(fromString);
while(i > -1){
	temp = temp.replace(fromString, toString);
	i = temp.indexOf(fromString, i + toString.length + 1);
}
	return temp;
}

function ReplaceSubstring(inputString, fromString, toString) {
// Goes through the inputString and replaces every occurrence of fromString with toString
temp = inputString;
	if(fromString == "") {
		return(inputString);
	}
		if(toString.indexOf(fromString) == -1) {// If the string being replaced is not a part of the replacement string (normal situation)
			while(temp.indexOf(fromString) != -1){
				var toTheLeft = temp.substring(0,temp.indexOf(fromString));
				var toTheRight = temp.substring(temp.indexOf(fromString)+fromString.length,temp.length);
				temp = toTheLeft + toString + toTheRight;
			}
	}else {// String being replaced is part of replacement string (like "+" being replaced with "++") - prevent aninfinite loop
		var midStrings = Array("~","`","_", "^","#");
		var midStringLen = 1;
		var midString = "";// Find a string that doesn't exist in the inputString to be usedas an "inbetween" string
		while (midString == "") {
			for (var i=0; i < midStrings.length; i++) {
				var tempMidString = "";
					for (var j=0; j < midStringLen; j++) { 
						tempMidString += midStrings[i]; }
					if (fromString.indexOf(tempMidString) == -1) {
						midString = tempMidString;
						i = midStrings.length + 1;
					}
			}
		}

		// Keep on going until we build an "inbetween" string that doesn't exist
		// Now go through and do two replaces - first, replace the "fromString" with the "inbetween" string
		while (temp.indexOf(fromString) != -1) {
			var toTheLeft = temp.substring(0, temp.indexOf(fromString));
			var toTheRight =temp.substring(temp.indexOf(fromString)+fromString.length,temp.length);
			temp = toTheLeft + midString + toTheRight;
		}

	// Next, replace the "inbetween" string with the "toString"
		while (temp.indexOf(midString) != -1) {
			var toTheLeft = temp.substring(0,temp.indexOf(midString));
			var toTheRight = temp.substring(temp.indexOf(midString)+midString.length,temp.length);
			temp = toTheLeft + toString + toTheRight;
		}
	}
// Ends the check to see if the string being replaced is part of the replacement string or not
	return temp;
	// Send the updated string back to the user
}
	// Ends the "replaceSubstring" function									

//Get information when onchange ddl
function UsePatronInfo(textEl,source) {
	var text;
	text =source.options[source.selectedIndex].value;
	if (textEl.createTextRange && textEl.caretPos){
		var caretPos = textEl.caretPos;
		caretPos.text = caretPos.text.charAt(caretPos.text.length - 1) == ' ' ? text + ' ' : text;
	} else {		
		textEl.value  = text;
	}
	textEl.caretPos = caretPos + text.length;	
	textEl.focus();
}

//creator: Tuanhv
//createdate: 06/11/2004
//Encryption tags as "<" or ">"
function EncryptionTags(){	
	//Title
	document.forms[0].txtTitle.value=xreplace(document.forms[0].txtTitle.value,'<','&lt;');	
	document.forms[0].txtTitle.value=xreplace(document.forms[0].txtTitle.value,'>','&gt;');	
	//Header
	document.forms[0].txtHeader.value=xreplace(document.forms[0].txtHeader.value,'<','&lt;');
	document.forms[0].txtHeader.value=xreplace(document.forms[0].txtHeader.value,'>','&gt;');
	//txtCollumCaption
	document.forms[0].txtCollumCaption.value=xreplace(document.forms[0].txtCollumCaption.value,'<','&lt;');
	document.forms[0].txtCollumCaption.value=xreplace(document.forms[0].txtCollumCaption.value,'>','&gt;');
	//txtCollumWidth
	document.forms[0].txtCollumWidth.value=xreplace(document.forms[0].txtCollumWidth.value,'<','&lt;');
	document.forms[0].txtCollumWidth.value=xreplace(document.forms[0].txtCollumWidth.value,'>','&gt;');
	//Align
	document.forms[0].txtAlign.value=xreplace(document.forms[0].txtAlign.value,'<','&lt;');
	document.forms[0].txtAlign.value=xreplace(document.forms[0].txtAlign.value,'>','&gt;');
	//Format
	document.forms[0].txtFormat.value=xreplace(document.forms[0].txtFormat.value,'<','&lt;');
	document.forms[0].txtFormat.value=xreplace(document.forms[0].txtFormat.value,'>','&gt;');
	//Footer
	document.forms[0].txtFooter.value=xreplace(document.forms[0].txtFooter.value,'<','&lt;');
	document.forms[0].txtFooter.value=xreplace(document.forms[0].txtFooter.value,'>','&gt;');
}

//Decryption tags from "<" to "gl;" so on...
function DecryptionTags(){
//Title
	document.forms[0].txtTitle.value=xreplace(document.forms[0].txtTitle.value,'&lt;','<');	
	document.forms[0].txtTitle.value=xreplace(document.forms[0].txtTitle.value,'&gt;','>');	
	//Header
	document.forms[0].txtHeader.value=xreplace(document.forms[0].txtHeader.value,'&lt;','<');	
	document.forms[0].txtHeader.value=xreplace(document.forms[0].txtHeader.value,'&gt;','>');	
	//txtCollumCaption
	document.forms[0].txtCollumCaption.value=xreplace(document.forms[0].txtCollumCaption.value,'&lt;','<');	
	document.forms[0].txtCollumCaption.value=xreplace(document.forms[0].txtCollumCaption.value,'&gt;','>');	
	//txtCollumWidth
	document.forms[0].txtCollumWidth.value=xreplace(document.forms[0].txtCollumWidth.value,'&lt;','<');	
	document.forms[0].txtCollumWidth.value=xreplace(document.forms[0].txtCollumWidth.value,'&gt;','>');	
	//Align
	document.forms[0].txtAlign.value=xreplace(document.forms[0].txtAlign.value,'&lt;','<');	
	document.forms[0].txtAlign.value=xreplace(document.forms[0].txtAlign.value,'&gt;','>');	
	//Format
	document.forms[0].txtFormat.value=xreplace(document.forms[0].txtFormat.value,'&lt;','<');	
	document.forms[0].txtFormat.value=xreplace(document.forms[0].txtFormat.value,'&gt;','>');	
	//Footer
	document.forms[0].txtFooter.value=xreplace(document.forms[0].txtFooter.value,'&lt;','<');	
	document.forms[0].txtFooter.value=xreplace(document.forms[0].txtFooter.value,'&gt;','>');	
}

// Called when add Item from lisbox lsbAllCollums to lisbox lsbCollum
function AddItem(){
var k = 0, bolCheck = true;
var strCollum='';	
	k=0;
	for (i = 0; i < document.forms[0].lsbAllCollums.length; i++) {
		if(document.forms[0].lsbAllCollums.options[i].selected) {
			document.forms[0].lsbCollum.length++;
			document.forms[0].lsbCollum.options[(document.forms[0].lsbCollum.length)- 1].value = document.forms[0].lsbAllCollums.options[i].value;
			document.forms[0].lsbCollum.options[(document.forms[0].lsbCollum.length)- 1].text = document.forms[0].lsbAllCollums.options[i].text;		
		}
		else {document.forms[0].lsbAllCollums.options[k].value =document.forms[0].lsbAllCollums.options[i].value;
			document.forms[0].lsbAllCollums.options[k].text =document.forms[0].lsbAllCollums.options[i].text;
			document.forms[0].lsbAllCollums.options[k].selected = false;
            k = k + 1;
		}		
	}
	document.forms[0].lsbAllCollums.length = k;

	for (i=0;i<document.forms[0].lsbCollum.length;i++){
		strCollum+=document.forms[0].lsbCollum.options[i].value + '<~>';
	}
	if (strCollum.length>0)	document.forms[0].txtCollum.value=strCollum.substring(0,(strCollum.length)-3);
	else document.forms[0].txtCollum.value='';	
}

// Called when remove Item from listbox lsbCollum
function RemoveItem(){
var k=0;           
var strCollum;
strCollum='';   
	for (i = 0; i < document.forms[0].lsbCollum.length; i++) {	
		if(document.forms[0].lsbCollum.options[i].selected) {
			document.forms[0].lsbAllCollums.length++;
			document.forms[0].lsbAllCollums.options[(document.forms[0].lsbAllCollums.length)- 1].value = document.forms[0].lsbCollum.options[i].value;
			document.forms[0].lsbAllCollums.options[(document.forms[0].lsbAllCollums.length)- 1].text = document.forms[0].lsbCollum.options[i].text;	
		}
		else {document.forms[0].lsbCollum.options[k].value =document.forms[0].lsbCollum.options[i].value;
		document.forms[0].lsbCollum.options[k].text =document.forms[0].lsbCollum.options[i].text;
		document.forms[0].lsbCollum.options[k].selected = false;
		document.forms[0].hdCollumCaptionText.value= document.forms[0].hdCollumCaptionText.value + document.forms[0].lsbCollum.options[i].text + '<~>';
		k = k + 1;
		strCollum+=document.forms[0].lsbCollum.options[i].value + '<~>';
		}
	}			
	document.forms[0].lsbCollum.length = k;
	if(strCollum.length>0)	document.forms[0].txtCollum.value=strCollum.substring(0,(strCollum.length)-3);
	else document.forms[0].txtCollum.value='';
}

function storeCaret(textEl) {
	if (textEl.createTextRange)	{
		textEl.caretPos = document.selection.createRange().duplicate();
	}
}


//string location, if find return index of string, else return -1
function FindIndex(b) {
var a=new Array('<$NO>', '<$NOTE>','<$FILESIZE>', '<$PRICE>', '<$CURRENCY>');
	for (k = 0; k < a.length; k++) {
		if (a[k] == b) {
			return k;
		}	
	}
	return - 1;
}

//Preview Template
function Preview(){
	PreviewWin = window.open('','PreviewWin','height=350,width=600,resizable,menubar=no,scrollbars=yes,screenX=0,screenY=0,top=10,left=10');
	parent.Workform.document.forms[0].action='WTemplatePreview.aspx';
	parent.Workform.document.forms[0].method='post';
	parent.Workform.document.forms[0].target='PreviewWin';
	parent.Workform.document.forms[0].submit();			
	DecryptionTags();
	parent.Workform.document.forms[0].action='WBillTemplateMan.aspx';
	parent.Workform.document.forms[0].target= self.name;
	PreviewWin.focus();	
}

function MoveUp(combo_name)
{
	var combo=document.getElementById("lsbCollum").getAttribute('id');	
	var a=eval('document.forms[0].' + combo);	
	var k,j,i,strCollum, temp;
	strCollum='';
	j=a.options.selectedIndex;		
	if (j>0)
	{
		swap(a,j,j-1);
		a.options[j-1].selected=true;
		a.options[j].selected=false;		
	}		
	k=0;
	for(k=0;k < a.length;k++){
		strCollum = strCollum + a.options[k].value + '<~>'
	}
	if (strCollum.length>0)	document.forms[0].txtCollum.value=strCollum.substring(0,(strCollum.length)-3);
	else document.forms[0].txtCollum.value='';	
}

function MoveDown(combo_name)
{
	var strCollum,k,i;
	var combo=document.getElementById("lsbCollum").getAttribute('id');
	var a=eval('document.forms[0].' + combo);	
	strCollum='';
	i=eval('document.forms[0].' + combo).options.selectedIndex;	
	if (i<a.length-1 && i>-1)
	{
		swap(a,i+1,i);
		a.options[i+1].selected=true;
		a.options[i].selected=false;
	}
	k=0;
	for(k=0;k < a.length;k++){
		strCollum = strCollum + a.options[k].value + '<~>';
	}
	if (strCollum.length>0)	document.forms[0].txtCollum.value=strCollum.substring(0,(strCollum.length)-3);
	else document.forms[0].txtCollum.value='';	
}

//this function is used to swap between elements
function swap(combo,index1, index2)
{
	var savedValue=combo.options[index1].value;
	var savedText=combo.options[index1].text;

	combo.options[index1].value=combo.options[index2].value;
	combo.options[index1].text=combo.options[index2].text;

	combo.options[index2].value=savedValue;
	combo.options[index2].text=savedText;
}

function MoveToTop(combo_name)
{
	var combo=document.getElementById(combo_name);
	i=combo.selectedIndex;
	
	for (;i>0;i--)
	{
		swap(combo,i,i-1);
		combo.options[i-1].selected=true;
		combo.options[i].selected=false;
	}
}

function MoveToBottom(combo_name)
{
	var combo=document.getElementById(combo_name);
	i=combo.selectedIndex;
	
	if (i>-1)
	{
		for (;i<combo.length-1;i++)
		{
			swap(combo,i+1,i);
			combo.options[i+1].selected=true;
			combo.options[i].selected=false;
		}
	}
}

