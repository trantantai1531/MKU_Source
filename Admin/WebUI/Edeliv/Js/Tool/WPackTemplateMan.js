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
	//Content
	document.forms[0].txtContents.value=xreplace(document.forms[0].txtContents.value,'<','&lt;');
	document.forms[0].txtContents.value=xreplace(document.forms[0].txtContents.value,'>','&gt;');
}


//Decryption tags from "<" to "gl;" so on...
function DecryptionTags(){
	//Title
	document.forms[0].txtTitle.value=xreplace(document.forms[0].txtTitle.value,'&lt;','<');	
	document.forms[0].txtTitle.value=xreplace(document.forms[0].txtTitle.value,'&gt;','>');	
	//Content
	document.forms[0].txtContents.value=xreplace(document.forms[0].txtContents.value,'&lt;','<');	
	document.forms[0].txtContents.value=xreplace(document.forms[0].txtContents.value,'&gt;','>');	
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
	parent.Workform.document.forms[0].action='WTemplatePreview.aspx?SelectPackTemplateMan=1';
	parent.Workform.document.forms[0].method='post';
	parent.Workform.document.forms[0].target='PreviewWin';
	parent.Workform.document.forms[0].submit();			
	DecryptionTags();
	parent.Workform.document.forms[0].action='WPackTemplateMan.aspx';
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

/*
	function ClearContent
*/
function ClearContent() {
	document.forms[0].ddlFormatName.selectedIndex = 0;
	document.forms[0].txtTitle.value='';
	document.forms[0].txtContents.value='';
	document.forms[0].ddlLocation.selectedIndex = 0;
	document.forms[0].ddlRequestInfo.selectedIndex = 0;
	document.forms[0].ddlOther.selectedIndex = 0;
	document.forms[0].txtTitle.focus();
}