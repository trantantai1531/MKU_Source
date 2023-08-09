//creator: sondp
//createdate: 20/08/2004
function replaceSubstring(inputString, fromString, toString) {
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
//Encryption tags as "<" or ">"
function EncryptionTags(){
	//Title
	document.forms[0].txtCaption.value=replaceSubstring(document.forms[0].txtCaption.value,'<','&lt;');	
	document.forms[0].txtCaption.value=replaceSubstring(document.forms[0].txtCaption.value,'>','&gt;');	
	//Header
	document.forms[0].txtHeader.value=replaceSubstring(document.forms[0].txtHeader.value,'<','&lt;');
	document.forms[0].txtHeader.value=replaceSubstring(document.forms[0].txtHeader.value,'>','&gt;');
	//Collum
	document.forms[0].txtCollum.value=replaceSubstring(document.forms[0].txtCollum.value,'<','&lt;');
	document.forms[0].txtCollum.value=replaceSubstring(document.forms[0].txtCollum.value,'>','&gt;');
	//Align
	document.forms[0].txtAlign.value=replaceSubstring(document.forms[0].txtAlign.value,'<','&lt;');
	document.forms[0].txtAlign.value=replaceSubstring(document.forms[0].txtAlign.value,'>','&gt;');
	//Format
	document.forms[0].txtWord.value=replaceSubstring(document.forms[0].txtWord.value,'<','&lt;');
	document.forms[0].txtWord.value=replaceSubstring(document.forms[0].txtWord.value,'>','&gt;');
	//Footer
	document.forms[0].txtFooter.value=replaceSubstring(document.forms[0].txtFooter.value,'<','&lt;');
	document.forms[0].txtFooter.value=replaceSubstring(document.forms[0].txtFooter.value,'>','&gt;');
}
//Decryption tags from "<" to "gl;" so on...
function DecryptionTags(){
	//Title
	document.forms[0].txtCaption.value=replaceSubstring(document.forms[0].txtCaption.value,'&lt;','<');	
	document.forms[0].txtCaption.value=replaceSubstring(document.forms[0].txtCaption.value,'&gt;','>');	
	//Header
	document.forms[0].txtHeader.value=replaceSubstring(document.forms[0].txtHeader.value,'&lt;','<');
	document.forms[0].txtHeader.value=replaceSubstring(document.forms[0].txtHeader.value,'&gt;','>');
	//Collum
	document.forms[0].txtCollum.value=replaceSubstring(document.forms[0].txtCollum.value,'&lt;','<');
	document.forms[0].txtCollum.value=replaceSubstring(document.forms[0].txtCollum.value,'&gt;','>');
	//Align
	document.forms[0].txtAlign.value=replaceSubstring(document.forms[0].txtAlign.value,'&lt;','<');
	document.forms[0].txtAlign.value=replaceSubstring(document.forms[0].txtAlign.value,'&gt;','>');
	//Format
	document.forms[0].txtWord.value=replaceSubstring(document.forms[0].txtWord.value,'&lt;','<');
	document.forms[0].txtWord.value=replaceSubstring(document.forms[0].txtWord.value,'&gt;','>');
	//Footer
	document.forms[0].txtFooter.value=replaceSubstring(document.forms[0].txtFooter.value,'&lt;','<');
	document.forms[0].txtFooter.value=replaceSubstring(document.forms[0].txtFooter.value,'&gt;','>');
}
function storeCaret(textEl) {
	if (textEl.createTextRange)	{
		textEl.caretPos = document.selection.createRange().duplicate();
	}
}
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
function AddItem(){
var k = 0;
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
var strCollum='';	
	for (i=0;i<document.forms[0].lsbCollum.length;i++){
		strCollum+=document.forms[0].lsbCollum.options[i].value + '<~>';
	}
	if (strCollum.length>0)	document.forms[0].txtCollum.value=strCollum.substring(0,(strCollum.length)-3);
	else document.forms[0].txtCollum.value='';
}
function RemoveItem(){
var k=0;              
var strCollum='';
	for (i = 0; i < document.forms[0].lsbCollum.length; i++) {	
		if(document.forms[0].lsbCollum.options[i].selected) {
			document.forms[0].lsbAllCollums.length++;
			document.forms[0].lsbAllCollums.options[(document.forms[0].lsbAllCollums.length)- 1].value = document.forms[0].lsbCollum.options[i].value;
			document.forms[0].lsbAllCollums.options[(document.forms[0].lsbAllCollums.length)- 1].text = document.forms[0].lsbCollum.options[i].text;

		}
		else {document.forms[0].lsbCollum.options[k].value =document.forms[0].lsbCollum.options[i].value;
		document.forms[0].lsbCollum.options[k].text =document.forms[0].lsbCollum.options[i].text;
		document.forms[0].lsbCollum.options[k].selected = false;
		k = k + 1;
		strCollum+=document.forms[0].lsbCollum.options[i].value + '<~>';
		}
}		
	document.forms[0].lsbCollum.length = k;
	if(strCollum.length>0)	document.forms[0].txtCollum.value=strCollum.substring(0,(strCollum.length)-3);
	else document.forms[0].txtCollum.value='';
}
//tim ra vi tri cua chuoi, phuc vu cho form WOverdueTemplate.aspx, tra ve vi tri cua xau tim duoc, con khong se tra ve gia tri -1 neu khong tim thay
function FindIndex(b) {
var a=new Array('<$SEQUENCY$>','<$ITEMCODE$>','<$COPYNUMBER$>','<$ITEMTITLE$>','<$CHECKOUTDATE$>','<$CHECKINDATE$>','<$OVERDUEDATE$>','<$PENATI$>','<$LIBRARY$>','<$STORE$>',"<$NOTE$>");
	for (k = 0; k < a.length; k++) {
		if (a[k] == b) {
			return k;
		}	
	}
	return - 1;
}
//upload data to form WOverdueTemplate
function LoadBackData(strTitle,strHeader,strCollums,strCollumCaption,strCollumWidth,strCollumAlign,strWord,strFooter){
		//DecryptionTags();
		parent.Workform.document.forms[0].txtCaption.value=strTitle;
		parent.Workform.document.forms[0].txtHeader.value=strHeader;
		parent.Workform.document.forms[0].txtCollum.value=strCollums;
		parent.Workform.document.forms[0].txtCollumCaption.value=strCollumCaption;
		parent.Workform.document.forms[0].txtCollumWidth.value=strCollumWidth;
		parent.Workform.document.forms[0].txtAlign.value=strCollumAlign;
		parent.Workform.document.forms[0].txtWord.value=strWord;
		parent.Workform.document.forms[0].txtFooter.value=strFooter;
	for(i=0;i<parent.Workform.document.forms[0].lsbTemp.options.length;i++){
	parent.Workform.document.forms[0].lsbAllCollums.options.length=i+1;
	parent.Workform.document.forms[0].lsbAllCollums.options[i].value=parent.Workform.document.forms[0].lsbTemp.options[i].value;
	parent.Workform.document.forms[0].lsbAllCollums.options[i].text=parent.Workform.document.forms[0].lsbTemp.options[i].text;
	}
	parent.Workform.document.forms[0].lsbCollum.options.length=0;
	if(strCollums.length>0){
		var ArrStrSelectCollum;
		ArrStrSelectCollum=strCollums.split('<~>');
		for(i = 0;i<ArrStrSelectCollum.length;i++){
		var index;
			index=-1;
			index=FindIndex(ArrStrSelectCollum[i]);
			if(index>=0){
				parent.Workform.document.forms[0].lsbCollum.options.length++;
				parent.Workform.document.forms[0].lsbCollum.options[parent.Workform.document.forms[0].lsbCollum.options.length-1].value=parent.Workform.document.forms[0].lsbTemp.options[index].value;
				parent.Workform.document.forms[0].lsbCollum.options[parent.Workform.document.forms[0].lsbCollum.options.length-1].text=parent.Workform.document.forms[0].lsbTemp.options[index].text;
				parent.Workform.document.forms[0].lsbAllCollums.options[index].value='--';
			}				
		}
		for(i=0,k=0;i<parent.Workform.document.forms[0].lsbAllCollums.options.length;i++){
			if(parent.Workform.document.forms[0].lsbAllCollums.options[i].value!='--'){
				parent.Workform.document.forms[0].lsbAllCollums.options[k].value=parent.Workform.document.forms[0].lsbAllCollums.options[i].value;
				parent.Workform.document.forms[0].lsbAllCollums.options[k].text=parent.Workform.document.forms[0].lsbAllCollums.options[i].text;
				k = k + 1 ;
				}
		}
		parent.Workform.document.forms[0].lsbAllCollums.options.length=k;		
	}
}
//refesh all controls on WOverdueTemplate.aspx
function RefeshPage()
{	
	parent.Workform.document.forms[0].txtCaption.value='';
	parent.Workform.document.forms[0].txtHeader.value='';
	parent.Workform.document.forms[0].txtCollumCaption.value='';
	parent.Workform.document.forms[0].txtCollumWidth.value='';
	parent.Workform.document.forms[0].txtAlign.value='';
	parent.Workform.document.forms[0].txtWord.value='';
	parent.Workform.document.forms[0].txtFooter.value='';
	parent.Workform.document.forms[0].lsbCollum.options.length=0;	
	parent.Workform.document.forms[0].txtCollum.value='';
	for(i=0;i<parent.Workform.document.forms[0].lsbTemp.options.length;i++){
		parent.Workform.document.forms[0].lsbAllCollums.length=i+1;
		parent.Workform.document.forms[0].lsbAllCollums.options[i].value=parent.Workform.document.forms[0].lsbTemp.options[i].value;
		parent.Workform.document.forms[0].lsbAllCollums.options[i].text=parent.Workform.document.forms[0].lsbTemp.options[i].text;
	}
	parent.Workform.document.forms[0].txtCaption.focus();
}
//Preview Template
function Preview(){
	PreviewWin = window.open('','PreviewWin','height=200,width=770,resizable,menubar=no,scrollbars=yes,screenX=0,screenY=0,top=10,left=10');		
	document.forms[0].action='WOverdueTemplatePreview.aspx';
	document.forms[0].method='post';
	EncryptionTags();
	document.forms[0].target='PreviewWin';
	document.forms[0].submit();			
	DecryptionTags();
	document.forms[0].action='WOverdueTemplate.aspx';
	document.forms[0].target= self.name;
	PreviewWin.focus();	
}
function CheckExitName(val) {
    var ddl = document.forms[0].ddlTemplate;
    for (var  i = 0; i < ddl.options.length; i++) {
        if (ddl.options[i].text == val) {
            alert("Tồn tại mẫu thư quá hạn");
            document.forms[0].txtCaption.value = "";
            return false;
        } 
    }
}