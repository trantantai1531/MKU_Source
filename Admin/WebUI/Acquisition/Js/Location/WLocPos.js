function CheckRatio(f,field,strNote1,strNote2,strNote3) {
	var h=eval(field+'txtdtgImgHeightMetter').value;
	h=replaceSubstring(h,',','.')
	var w=eval(field+'txtdtgImgWidthMetter').value;	
	w=replaceSubstring(w,',','.')
		
	if ((! isNaN(document.forms[0].hidImgHeight.value)) && (! isNaN(document.forms[0].hidImgWidth.value))) {	
		if (f == 0) {
			var h1 = w*parseInt(document.forms[0].hidImgHeight.value)/parseInt(document.forms[0].hidImgWidth.value);
			if ((h1-h)/h > 0.02 || (h1-h)/h < -0.02) {
				if (confirm(strNote1 + Math.round(h1*100)/100 + strNote2)) {					
					eval(field+'txtdtgImgHeightMetter').value = Math.round(h1*100)/100;
					eval(field+'txtdtgImgHeightMetter').value=replaceSubstring(eval(field+'txtdtgImgHeightMetter').value,'.',',')
				}
			}	
		}
		else {
			var w1 = h*parseInt(document.forms[0].hidImgWidth.value)/parseInt(document.forms[0].hidImgHeight.value);
			if ((w1-w)/w > 0.02 || (w1-w)/w < -0.02) {
				if (confirm(strNote3 + Math.round(w1*100)/100 + strNote2)) {										
					eval(field+'txtdtgImgWidthMetter').value = Math.round(w1*100)/100;
					eval(field+'txtdtgImgWidthMetter').value=replaceSubstring(eval(field+'txtdtgImgWidthMetter').value,'.',',')
				}
			}	
		}
	}
}

function CheckValue(field,strNote,strNumErr) {
	if(eval(field).value=="") {
		alert(strNote);		
		eval(field).focus(); 
		return false;		
	}
	tempNum = replaceSubstring(eval(field).value,',','.')
	if (isNaN(tempNum) || parseFloat(tempNum) < 0) { 
		alert(strNumErr);		
		eval(field).focus(); 
		return false;
		} 	 
	return true;	
}


function CheckSizeValue(field,strNote,strNumErr) {
	
	if(eval(field).value=="") {
		alert(strNote);		
		eval(field).focus(); 
		return false;		
	}
	tempNum = replaceSubstring(eval(field).value,',','.')
	if (isNaN(tempNum) || parseFloat(tempNum) <= 0) { 
		alert(strNumErr);		
		eval(field).focus(); 
		return false;
		}
	return true;	
	
}

	
function CheckInserUpdate(val,field,strNote,strNote1) {
	if (val==0) 
		if (eval(field+'fldtgImageUpload').value =="") {
			alert(strNote);
			eval(field+'fldtgImageUpload').focus();
			return false;
			}
	if (eval(field+'txtdtgImgWidthMetter').value =="") {
		alert(strNote);
		eval(field+'txtdtgImgWidthMetter').focus();
		return false;	
		}
	else {
		if(!CheckSizeValue(field+'txtdtgImgWidthMetter',strNote,strNote1)) 
			return false;
	}
	if (eval(field+'txtdtgImgHeightMetter').value =="") {
		alert(strNote);
		eval(field+'txtdtgImgHeightMetter').focus();
		return false;	
		}
	else {
		if(!CheckSizeValue(field+'txtdtgImgHeightMetter',strNote,strNote1)) 
			return false;	
	}
	if (eval(field+'txtdtgTopCoor').value =="") {
		alert(strNote);
		eval(field+'txtdtgTopCoor').focus();
		return false;	
		}
	else {
		if(!CheckValue(field+'txtdtgTopCoor',strNote,strNote1)) 
			return false;	
	}
	if (eval(field+'txtdtgLeftCoor').value =="") {
		alert(strNote);
		eval(field+'txtdtgLeftCoor').focus();
		return false;	
		}
	else {
		if(!CheckValue(field+'txtdtgLeftCoor',strNote,strNote1)) 
			return false;	
	}		
	return true;	
}

function SetLeftTopCoor(index,strOnlyShow) {	
	if (eval('opener.document.forms[0].dtgContent__ctl'+index+'_txtdtgLeftCoor')) {
		var strxy=location.search;				
		strxy=strxy.substring(1,strxy.length);
		var pos=strxy.indexOf("?");		
		if ((strxy !="")&&(pos>0)) {			
			strxy=strxy.substring(pos+1,strxy.length);						
			pos=strxy.indexOf(",");
			eval('opener.document.forms[0].dtgContent__ctl'+index+'_txtdtgLeftCoor').value=strxy.substring(0,pos);
			eval('opener.document.forms[0].dtgContent__ctl'+index+'_txtdtgTopCoor').value=strxy.substring(pos+1,strxy.length);
		}
	}
	else {		
		lnkShowImage.outerHTML=strOnlyShow;						
	}
}

function ShowImg(intLocID) {	
	OpenWindow('WShowSchema.aspx?LocID='+intLocID,'ShowSchema',750,500,20,50);
	return false;
}

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
