/**********************************************************************************/
/*******************		WAcqReportTemplate Js file		***********************/
/**********************************************************************************/
// Method: replaceSubstring
// Purpose: Replate String
// In: string source, string find, string replace
// Out: string source
// Creator: sondp
// CreatedDate: 25/09/2004
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
// Replace < or > by &lt; or &gt;
function EncryptionTags(obj){
	eval(obj).value=replaceSubstring(eval(obj).value,'<','&lt;');
	eval(obj).value=replaceSubstring(eval(obj).value,'>','&gt;');	
}			
// Replace &lt; or &gt; by < or >
function DecryptionTags(obj){
	eval(obj).value=replaceSubstring(eval(obj).value,'&lt;','<');
	eval(obj).value=replaceSubstring(eval(obj).value,'&gt;','>');	
}
// Add Item in ListBox function
function AddItem(){
var k = 0, bolCheck = true;
var strCollum='';	
	for (i=0; i<document.forms[0].lsbCollum.length; i++){
		if(document.forms[0].lsbCollum.options[i].selected) {
			document.forms[0].lsbCollum.options[i].selected =  false;
			bolCheck = false;
		}
	}
	if (bolCheck==false) {
			return false;
	}
	document.forms[0].hdCollumCaptionText.value='';
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
		}
	}
	k=0;
	for (i = 0; i < document.forms[0].lsbAllCollums.length; i++) {
		if(document.forms[0].lsbAllCollums.options[i].selected) {
			document.forms[0].lsbCollum.length++;
			document.forms[0].lsbCollum.options[(document.forms[0].lsbCollum.length)- 1].value = document.forms[0].lsbAllCollums.options[i].value;
			document.forms[0].lsbCollum.options[(document.forms[0].lsbCollum.length)- 1].text = document.forms[0].lsbAllCollums.options[i].text;
		document.forms[0].hdCollumCaptionText.value=document.forms[0].hdCollumCaptionText.value  + document.forms[0].lsbAllCollums.options[i].text + '<~>';
		}
		else {document.forms[0].lsbAllCollums.options[k].value =document.forms[0].lsbAllCollums.options[i].value;
			document.forms[0].lsbAllCollums.options[k].text =document.forms[0].lsbAllCollums.options[i].text;
			document.forms[0].lsbAllCollums.options[k].selected = false;
            k = k + 1;
		}		
	}
	document.forms[0].lsbAllCollums.length = k;
	document.forms[0].hdMax.value=document.forms[0].lsbCollum.length;

	for (i=0;i<document.forms[0].lsbCollum.length;i++){
		strCollum+=document.forms[0].lsbCollum.options[i].value + '<~>';
	}
	if (strCollum.length>0)	document.forms[0].txtCollum.value=strCollum.substring(0,(strCollum.length)-3);
	else document.forms[0].txtCollum.value='';	
}
// Remove Item from ListBox function
function RemoveItem(){
var k=0;              
var arrCaption, arrWidth, arrAlign, arrFormat, bolCheck;
var strCollumCaption, strCollumWidth, strCollumAlign, strCollumFormat, strCollum;
	strCollumCaption='';
	strCollumWidth=''
	strCollumAlign='';
	strCollumFormat='';
	strCollum='';
	bolCheck= true;
	for (i=0; i<document.forms[0].lsbAllCollums.length; i++){
		if(document.forms[0].lsbAllCollums.options[i].selected) {
			document.forms[0].lsbAllCollums.options[i].selected = false;
			bolCheck = false;
		}
	}
	if (bolCheck==false) {
			return false;
	}
	document.forms[0].hdCollumCaptionText.value='';
	arrCaption=document.forms[0].txtCollumCaption.value.split('\n');
	arrWidth=document.forms[0].txtCollumWidth.value.split('\n');
	arrAlign=document.forms[0].txtAlign.value.split('\n');
	arrFormat=document.forms[0].txtFormat.value.split('\n');
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
		strCollumCaption = strCollumCaption + arrCaption[i] + '\n';
		strCollumWidth = strCollumWidth + arrWidth[i] + '\n';
		strCollumAlign = strCollumAlign + arrAlign[i] + '\n';
		strCollumFormat = strCollumFormat + arrFormat[i] + '\n';
		strCollum+=document.forms[0].lsbCollum.options[i].value + '<~>';
		}
	}			
	document.forms[0].lsbCollum.length = k;
	if(strCollum.length>0)	document.forms[0].txtCollum.value=strCollum.substring(0,(strCollum.length)-3);
	else document.forms[0].txtCollum.value='';
	document.forms[0].txtCollumCaption.value=strCollumCaption;
	document.forms[0].txtCollumWidth.value = strCollumWidth;
	document.forms[0].txtAlign.value = strCollumAlign;
	document.forms[0].txtFormat.value= strCollumFormat;
}

// Find out b in array if find return(this index in array) else return(-1)
function FindIndexRequest(b) {
// Array search
    var a = new Array('<$SEQUENCY$>', '<$DKCB$>', '<$TITLE$>', '<$PLACE$>', '<$YEAR$>', '<$ISSUEPRICE$>', '<$ACQUISITIONDATE$>', '<$NOTE$>', '<$ISBN$>', '<$SOHD$>', '<$AUTHOR$>','<$DDC$>');
	for (k = 0; k < a.length; k++) {
		if (a[k] == b) {
			return k;
		}	
	}
	return - 1;
}
// Clear all controls
function ClearData(){
	top.main.mainacq.document.forms[0].txtHeader.value='';
	top.main.mainacq.document.forms[0].txtPageHeader.value='';
	top.main.mainacq.document.forms[0].txtCaption.value='';
	top.main.mainacq.document.forms[0].txtCollumCaption.value='';
	top.main.mainacq.document.forms[0].txtCollumWidth.value='';
	top.main.mainacq.document.forms[0].txtAlign.value='';
	top.main.mainacq.document.forms[0].txtFormat.value='';
	top.main.mainacq.document.forms[0].txtTableColor.value='';
	top.main.mainacq.document.forms[0].txtEventColor.value='';
	top.main.mainacq.document.forms[0].txtOddColor.value='';
	top.main.mainacq.document.forms[0].txtPageFooter.value='';		
	top.main.mainacq.document.forms[0].txtFooter.value='';
	top.main.mainacq.document.forms[0].lsbCollum.options.length=0;	
	top.main.mainacq.document.forms[0].txtCollum.value='';
	for(i=0;i<top.main.mainacq.document.forms[0].lsbTemp.options.length;i++){
		top.main.mainacq.document.forms[0].lsbAllCollums.length=i+1;
		top.main.mainacq.document.forms[0].lsbAllCollums.options[i].value=top.main.mainacq.document.forms[0].lsbTemp.options[i].value;
		top.main.mainacq.document.forms[0].lsbAllCollums.options[i].text=top.main.mainacq.document.forms[0].lsbTemp.options[i].text;
	}
	top.main.mainacq.document.forms[0].txtCaption.focus();
}
// Change Template function
function ChangeTemplate(){
	if(document.forms[0].ddlID.options[document.forms[0].ddlID.options.selectedIndex].value==0){
		ClearData();
		return false;
	}
	top.main.hiddenbase.location.href='WAcqReportTemplateHidden.aspx?TemplateID='+ document.forms[0].ddlID.options[document.forms[0].ddlID.options.selectedIndex].value;	
	return false;
}
// Load BackData method
function LoadBackData(strHeader,strPageHeader,strCollum,strCollumCaption,strCollumWidth,strAlign,strFormat,strTableColor,strEventColor,strOddColor,strPageFooter,strFooter,strTitle){
		top.main.mainacq.document.forms[0].txtCaption.value=strTitle;
		top.main.mainacq.document.forms[0].txtHeader.value=strHeader;
		top.main.mainacq.document.forms[0].txtPageHeader.value=strPageHeader;
		top.main.mainacq.document.forms[0].txtCollum.value=strCollum;
		top.main.mainacq.document.forms[0].txtCollumCaption.value=strCollumCaption;
		top.main.mainacq.document.forms[0].txtCollumWidth.value=strCollumWidth;
		top.main.mainacq.document.forms[0].txtAlign.value=strAlign;
		top.main.mainacq.document.forms[0].txtFormat.value=strFormat;
		top.main.mainacq.document.forms[0].txtTableColor.value=strTableColor;
		top.main.mainacq.document.forms[0].txtEventColor.value=strEventColor;
		top.main.mainacq.document.forms[0].txtOddColor.value=strOddColor;
		top.main.mainacq.document.forms[0].txtPageFooter.value=strPageFooter;		
		top.main.mainacq.document.forms[0].txtFooter.value=strFooter;		
	for(i=0;i<top.main.mainacq.document.forms[0].lsbTemp.options.length;i++){
	top.main.mainacq.document.forms[0].lsbAllCollums.options.length=i+1;
	top.main.mainacq.document.forms[0].lsbAllCollums.options[i].value=top.main.mainacq.document.forms[0].lsbTemp.options[i].value;
	top.main.mainacq.document.forms[0].lsbAllCollums.options[i].text=top.main.mainacq.document.forms[0].lsbTemp.options[i].text;
	}
	top.main.mainacq.document.forms[0].lsbCollum.options.length=0;
	if(strCollum.length>0){
		var ArrStrSelectCollum;
		ArrStrSelectCollum=strCollum.split('<~>');
		for(i = 0;i<ArrStrSelectCollum.length;i++){
		var index;
			index=-1;
			index=FindIndexRequest(ArrStrSelectCollum[i]);
			if(index>=0){
				top.main.mainacq.document.forms[0].lsbCollum.options.length++;
				top.main.mainacq.document.forms[0].lsbCollum.options[top.main.mainacq.document.forms[0].lsbCollum.options.length-1].value=top.main.mainacq.document.forms[0].lsbTemp.options[index].value;
				top.main.mainacq.document.forms[0].lsbCollum.options[top.main.mainacq.document.forms[0].lsbCollum.options.length-1].text=top.main.mainacq.document.forms[0].lsbTemp.options[index].text;
				top.main.mainacq.document.forms[0].lsbAllCollums.options[index].value='--';
			}				
		}
		for(i=0,k=0;i<top.main.mainacq.document.forms[0].lsbAllCollums.options.length;i++){
			if(top.main.mainacq.document.forms[0].lsbAllCollums.options[i].value!='--'){
				top.main.mainacq.document.forms[0].lsbAllCollums.options[k].value=top.main.mainacq.document.forms[0].lsbAllCollums.options[i].value;
				top.main.mainacq.document.forms[0].lsbAllCollums.options[k].text=top.main.mainacq.document.forms[0].lsbAllCollums.options[i].text;
				k = k + 1 ;
				}
		}
		top.main.mainacq.document.forms[0].lsbAllCollums.options.length=k;		
	}
}
// Preview Template function
function PreviewTemplate(){	
	PreviewTemplateWin = window.open('','PreviewTemplateWin','height=200,width=770,resizable,menubar=yes,scrollbars=yes,screenX=0,screenY=0,top=10,left=10');		
	document.forms[0].action='WAcqReportTemplatePreview.aspx';
	document.forms[0].target='PreviewTemplateWin';
	document.forms[0].submit();			
	document.forms[0].action='WAcqReportTemplateDisplay.aspx';
	document.forms[0].target= self.name;
	PreviewTemplateWin.focus();	
	return true;
}
// Confirm delete function
function AskDelete(strMess1, strMess2){
	if (document.forms[0].ddlID.options[document.forms[0].ddlID.options.selectedIndex].value == '0') {
		alert(strMess2);
		return false;		
	}
	if(!confirm(strMess1)) {
		return false; // Don't delete
	} else {
		return true; // Delete
	}
}

// Check ValidData
function CheckValidData(strEmtyTitle){
    if (document.forms[0].txtCaption.value.trim() == '') {
        document.forms[0].txtCaption.value = '';
		alert(strEmtyTitle);
		document.forms[0].txtCaption.focus();	
		return false;
	}
	return true;	
}
// Encryption controls
function Encryption(){
	EncryptionTags('document.forms[0].txtHeader');
	EncryptionTags('document.forms[0].txtPageHeader');
	EncryptionTags('document.forms[0].txtCollumCaption');
	EncryptionTags('document.forms[0].txtCollum');
	EncryptionTags('document.forms[0].txtFormat');
	EncryptionTags('document.forms[0].txtPageFooter');
	EncryptionTags('document.forms[0].txtFooter');
	return true;
}
// Decryption controls
function Decryption(){
	DecryptionTags('document.forms[0].txtHeader');
	DecryptionTags('document.forms[0].txtPageHeader');
	DecryptionTags('document.forms[0].txtCollumCaption');
	DecryptionTags('document.forms[0].txtCollum');
	DecryptionTags('document.forms[0].txtFormat');
	DecryptionTags('document.forms[0].txtPageFooter');
	DecryptionTags('document.forms[0].txtFooter');
	return true;
}