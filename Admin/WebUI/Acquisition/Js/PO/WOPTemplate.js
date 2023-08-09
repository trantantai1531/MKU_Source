/**********************************************************************************/
/***********************		WOPTemplate Js file		***************************/
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
}// Ends the "replaceSubstring" function		

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
// Encryption controls
function Encryption(){
	EncryptionTags('document.forms[0].txtHeader');
	EncryptionTags('document.forms[0].txtPageHeader');
	EncryptionTags('document.forms[0].txtCollumCaption');
	EncryptionTags('document.forms[0].txtCollum');
	EncryptionTags('document.forms[0].txtFormat');
	EncryptionTags('document.forms[0].txtPageFooter');
	EncryptionTags('document.forms[0].txtFooter');
	return(true);
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
	return(true);
}
function AddItem() {
    var checkSelected = false;
  
var k = 0;
	for (i = 0; i < document.forms[0].lsbAllCollums.length; i++) {
	    if (document.forms[0].lsbAllCollums.options[i].selected) {
	        checkSelected = true;
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

    if (checkSelected == false)
        alert("vui lòng chọn thông tin hiện thị");
	document.forms[0].lsbAllCollums.length = k;
var strCollum='';	
	for (i=0;i<document.forms[0].lsbCollum.length;i++){
		strCollum+=document.forms[0].lsbCollum.options[i].value + '<~>';
	}
	if (strCollum.length>0)	document.forms[0].txtCollum.value=strCollum.substring(0,(strCollum.length)-3);
	else document.forms[0].txtCollum.value='';
}
function RemoveItem() {
    var checkSelected = false;
var k=0;              
var strCollum='';
	for (i = 0; i < document.forms[0].lsbCollum.length; i++) {	
	    if (document.forms[0].lsbCollum.options[i].selected) {
	        checkSelected = true;
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
	
	if (checkSelected == false)
	    alert("vui lòng chọn thông tin hiện thị");
	document.forms[0].lsbCollum.length = k;
	if(strCollum.length>0)	document.forms[0].txtCollum.value=strCollum.substring(0,(strCollum.length)-3);
	else document.forms[0].txtCollum.value='';
}
// LoadTemplate function
function LoadTemplate(intTemplateID, intTemplateType){
	parent.hiddenbase.location.href='WOPTemplateH.aspx?TemplateID=' + intTemplateID + '&TemplateType=' + intTemplateType;
	return false;
}
// Confirm Delete function
function ConfirmDelete(strMess1, strMess2){
	if(document.forms[0].ddlID.options[document.forms[0].ddlID.options.selectedIndex].value==0){
		alert(strMess2);
		return false;
	}
	if(confirm(strMess1)==false){
		return false;					
	}else{
		return true;// Delete
	}	
}
// CheckValidData function
function CheckValidData(strMssg){	
	if (!CheckNull(document.forms[0].txtCaption)) {
		return true;
	} else {
		alert(strMssg);
		return false;
	}
}
// FindIndex function
function FindIndex(b,intTemplateType) {
	switch(intTemplateType){
		case '7': // Post Template
			var a=new Array('<$TITLE$>','<$SERIACODE$>','<$AUTHOR$>','<$EDITION$>','<$PUBLISHER$>','<$YEAR$>','<$ISBN$>','<$LANGUAGE$>','<$COUNTRY$>','<$ISSN$>','<$VALDSUBSCRIBEDDATE$>','<$FREQCODE$>','<$EXPIRESUBSCRIBEDDATE$>','<$ISSUES$>','<$REQUESTEDCOPIES$>');
			break;
		case '8': // Complaint Template
			var a=new Array('<$TITLE$>','<$AUTHOR$>','<$EDITION$>','<$PUBLISHER$>','<$YEAR$>','<$ISBN$>','<$ISSN$>','<$REQUESTEDCOPIES$>','<$RETRIEVEDCOPIES$>','<$ERRONEUOS$>');
			break;
		case '9': //Request Template
			var a=new Array('<$SEQUENCY$>','<$SERIACODE$>','<$TITLE$>','<$AUTHOR$>','<$EDITION$>','<$PUBLISHER$>','<$YEAR$>','<$ISBN$>','<$LANGUAGE$>','<$COUNTRY$>','<$DOCUMENTTYPE$>','<$MEDIUM$>','<$ISSN$>','<$VALDSUBSCRIBEDDATE$>','<$FREQCODE$>','<$EXPIRESUBSCRIBEDDATE$>','<$ISSUES$>','<$ISSUEPRICE$>','<$UNITPRICE$>','<$CURRENCY$>','<$REQUESTEDCOPIES$>','<$ACCEPTEDCOPIES$>','<$MONEY$>','<$NOTE$>','<$REQUESTER$>','<$URGENCY$>');
			break;
		default: ///Separated Template
			var a=new Array('<$SEQUENCY$>','<$SERIACODE$>','<$TITLE$>','<$AUTHOR$>','<$EDITION$>','<$PUBLISHER$>','<$YEAR$>','<$ISBN$>','<$UNITPRICE$>','<$LANGUAGE$>','<$COUNTRY$>','<$DOCUMENTTYPE$>','<$MEDIUM$>','<$ISSN$>','<$VALDSUBSCRIBEDDATE$>','<$FREQCODE$>','<$EXPIRESUBSCRIBEDDATE$>','<$ISSUES$>','<$CURRENCY$>','<$REQUESTER$>','<$REQUESTEDCOPIES$>','<$URGENCY$>','<$NOTE$>');
	}
	for (k = 0; k < a.length; k++) {		
		if (a[k] == b) {
			return k;
		}	
	}
	return - 1;
}

// LoadBackData function
 function LoadBackData(strHeader,strPageHeader,strCollum,strCollumCaption,strCollumWidth,strAlign,strFormat,strTableColor,strEventColor,strOddColor,strPageFooter,strFooter,strTitle,intTemplateType){
		parent.mainacq.document.forms[0].txtCaption.value=strTitle;
		parent.mainacq.document.forms[0].txtHeader.value=strHeader;
		parent.mainacq.document.forms[0].txtPageHeader.value=strPageHeader;
		parent.mainacq.document.forms[0].txtCollum.value=strCollum;
		parent.mainacq.document.forms[0].txtCollumCaption.value=strCollumCaption;
		parent.mainacq.document.forms[0].txtCollumWidth.value=strCollumWidth;
		parent.mainacq.document.forms[0].txtAlign.value=strAlign;
		parent.mainacq.document.forms[0].txtFormat.value=strFormat;
		parent.mainacq.document.forms[0].txtTableColor.value=strTableColor;
		parent.mainacq.document.forms[0].txtEventColor.value=strEventColor;
		parent.mainacq.document.forms[0].txtOddColor.value=strOddColor;
		parent.mainacq.document.forms[0].txtPageFooter.value=strPageFooter;		
		parent.mainacq.document.forms[0].txtFooter.value=strFooter;		
	for(i=0;i<parent.mainacq.document.forms[0].lsbTemp.options.length;i++){
	parent.mainacq.document.forms[0].lsbAllCollums.options.length=i+1;
	parent.mainacq.document.forms[0].lsbAllCollums.options[i].value=parent.mainacq.document.forms[0].lsbTemp.options[i].value;
	parent.mainacq.document.forms[0].lsbAllCollums.options[i].text=parent.mainacq.document.forms[0].lsbTemp.options[i].text;
	}
	parent.mainacq.document.forms[0].lsbCollum.options.length=0;
	if(strCollum.length>0){
		var ArrStrSelectCollum;
		ArrStrSelectCollum=strCollum.split('<~>');
		for(i = 0;i<ArrStrSelectCollum.length;i++){			
		var index;
			index=-1;
			index=FindIndex(ArrStrSelectCollum[i],intTemplateType);
			if(index>=0){
				parent.mainacq.document.forms[0].lsbCollum.options.length++;
				parent.mainacq.document.forms[0].lsbCollum.options[parent.mainacq.document.forms[0].lsbCollum.options.length-1].value=parent.mainacq.document.forms[0].lsbTemp.options[index].value;
				parent.mainacq.document.forms[0].lsbCollum.options[parent.mainacq.document.forms[0].lsbCollum.options.length-1].text=parent.mainacq.document.forms[0].lsbTemp.options[index].text;
				parent.mainacq.document.forms[0].lsbAllCollums.options[index].value='--';
			}				
		}
		for(i=0,k=0;i<parent.mainacq.document.forms[0].lsbAllCollums.options.length;i++){
			if(parent.mainacq.document.forms[0].lsbAllCollums.options[i].value!='--'){
				parent.mainacq.document.forms[0].lsbAllCollums.options[k].value=parent.mainacq.document.forms[0].lsbAllCollums.options[i].value;
				parent.mainacq.document.forms[0].lsbAllCollums.options[k].text=parent.mainacq.document.forms[0].lsbAllCollums.options[i].text;
				k = k + 1 ;
				}
		}
		parent.mainacq.document.forms[0].lsbAllCollums.options.length=k;		
	}
}
// PreviewForm function
function PreviewForm(intTemplateType){
	PreviewFormWin = window.open('','PreviewFormWin','height=200,width=770,resizable,menubar=yes,scrollbars=yes,screenX=0,screenY=0,top=10,left=10');		
	document.forms[0].action='WPOTemplateP.aspx?TemplateType=' + intTemplateType;
	document.forms[0].target='PreviewFormWin';
	document.forms[0].submit();			
	document.forms[0].action='WPOTemplate.aspx';
	document.forms[0].target= self.name;
	PreviewFormWin.focus();
	Decryption();
}

// Reset form
function ClearData()
{
	parent.mainacq.document.forms[0].reset();
	parent.mainacq.document.forms[0].lsbCollum.options.length=0;	
	for(i=0;i<parent.mainacq.document.forms[0].lsbTemp.options.length;i++){
		parent.mainacq.document.forms[0].lsbAllCollums.length=i+1;
		parent.mainacq.document.forms[0].lsbAllCollums.options[i].value=parent.mainacq.document.forms[0].lsbTemp.options[i].value;
		parent.mainacq.document.forms[0].lsbAllCollums.options[i].text=parent.mainacq.document.forms[0].lsbTemp.options[i].text;
	}
	parent.mainacq.document.forms[0].txtCaption.focus();
}