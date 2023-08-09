/*
	ChangeWorkSheet function
	Purpose: Allow user change suite Marc WorkSheet
*/
function ChangeWorkSheet() {
		if (top.main.Sentform.location.href.indexOf("WCataSent.aspx") >= 0) {
			top.main.Sentform.document.forms[0].action = "WCataSent.aspx";
			top.main.Sentform.document.forms[0].target = "Sentform";
			top.main.Sentform.document.forms[0].txtFormID.value = document.forms[0].ddlMarcForm.options[document.forms[0].ddlMarcForm.options.selectedIndex].value;
			top.main.Sentform.document.forms[0].txtAddedFieldCodes.value='';
			top.main.Sentform.document.forms[0].submit();
		}
		if (top.main.Sentform.location.href.indexOf("WCataModify.aspx") >= 0) {
			top.main.Sentform.document.forms[0].action = "WCataModify.aspx";
			top.main.Sentform.document.forms[0].target = "Sentform";
			//top.main.Sentform.document.forms[0].ChangeWS.value = 1;
			top.main.Sentform.document.forms[0].txtFormID.value = document.forms[0].ddlMarcForm.options[document.forms[0].ddlMarcForm.options.selectedIndex].value;
			top.main.Sentform.document.forms[0].submit();
		}
}

function mOvr(src,clrOver) { 
		//if (!src.contains(event.fromElement)) { 
		//	src.style.cursor = 'default'; 
		//	src.bgColor = clrOver; 
		//}
}
function mOut(src,clrIn) { 
		//if (!src.contains(event.toElement)) { 
		//	src.style.cursor = 'default';
		//	src.bgColor = clrIn; 
		//}
}

/*
	PopUpLeaderHelp function
	Purpose: popup leaderhelp window
*/
function PopUpLeaderHelp(intIsAuthority) {
	if (parseFloat(intIsAuthority) == 1) {
		OpenWindow('WLeaderHelpAuthority.aspx','LeaderWin',540,380,100,100);
	} else {
		OpenWindow('WLeaderHelp.aspx','LeaderWin',540,380,100,100);
	}
}

/*
	Gen001 function
	Purpose: generate ItemCode
*/
function Gen001() {
	u("001");
	parent.Hiddenbase.location.href='WGenItemCode.aspx';
}

/*
	u function
	Purpose: check input field which is in Sentform. if not, add in ModifiedFieldCodes
*/
function u(strFieldCode) {
	if (parent.Sentform.document.forms[0].txtModifiedFieldCodes.value.indexOf(strFieldCode) < 0) {
		parent.Sentform.document.forms[0].txtModifiedFieldCodes.value = parent.Sentform.document.forms[0].txtModifiedFieldCodes.value + strFieldCode + ",";		
	}
}

/*
	u function
	Purpose: check input field which is in Sentform. if not, add in ModifiedFieldCodes
*/
function ud(strFieldCode) {
	if (top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value.indexOf(strFieldCode) < 0) {
		top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value = top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value + strFieldCode + ",";
	}
}

/*
	ShowFieldProperties function
*/
function ShowFieldProperties(strFieldCode) {
	OpenWindow('../BibliographyTemplate/WMarcFieldProperties.aspx?FieldCode=' + strFieldCode,'MarcFieldProperty',700,360,50,100);
}

/*
	function: Search
*/	
function Search(strFieldCode)
{
	OpenWindow('WSearchItemID.aspx?FieldCode=' + strFieldCode,'SearchItem',450,450,100,100);
}

/*
	function: SearchMaga
*/
function SearchMaga(strFieldCode)
{
	OpenWindow('WSerialSearch.aspx?FieldCode=' + strFieldCode,'SearchItem',450,450,100,100);
}

/*
	CheckIt function
	Purpose: check exist of this keyword in the suite dictionary
 */
function CheckIt(strKeyWord, strCallfield, strRepeatable, intIsAuthority) {
    var strURL;
    /*console.log(strCallfield);
	if ((strCallfield != 'tag925') &&  (strCallfield != 'tag927')) {
		if (strKeyWord == ""){
			return;
		}
	}*/
	if (intIsAuthority==1) {
		strURL = "WAuthorityReference.aspx?Bib=" + intIsAuthority + "&Keyword=" + Esc(strKeyWord, intUtf) + "&frame=Workform.document.forms[0]." + strCallfield + "&storeframe=Sentform.document.forms[0]." + strCallfield  + "&Repeatable=" + strRepeatable + "&tag=" + strCallfield;
	} else {
		strURL = "WGetReference.aspx?Keyword=" + Esc(strKeyWord, intUtf) + "&Frame=Workform.document.forms[0]." + strCallfield + "&Storeframe=Sentform.document.forms[0]." + strCallfield  + "&Repeatable=" + strRepeatable + "&tag=" + strCallfield;
	}
	OpenWindow(strURL,'DictionaryWin',540,340,100,100);		
	return;
 }
 
 /*
	AuthorityHelp function
	Purpose: 
 */
 function AuthorityHelp(strKeyWord, strCallfield, strRepeatable, intIsAuthority) {
	var strURL;
	if (strKeyWord == "") {
		return;
	}
	intIsAuthority = intIsAuthority + 1;
	strURL = "WAuthorityReference.aspx?Bib=" + intIsAuthority + "&Keyword=" + Esc(strKeyWord, intUtf) + "&frame=Workform.document.forms[0]." + strCallfield + "&storeframe=Sentform.document.forms[0]." + strCallfield  + "&Repeatable=" + strRepeatable + "&tag=" + strCallfield;
	OpenWindow(strURL,'AuthorityDataWin',540,340,100,100);	
	return;
}

/*
	ClassificationHelp function
	Purpose: show classification search form
 */
 function ClassificationHelp(strKeyWord, strCallfield, strRepeatable) {
	var strURL;
	if (strKeyWord == "") {
		return;
	}
	strURL = "WClassificationReference.aspx?Keyword=" + Esc(strKeyWord, intUtf) + "&frame=Workform.document.forms[0]." + strCallfield + "&storeframe=Sentform.document.forms[0]." + strCallfield  + "&Repeatable=" + strRepeatable + "&tag=" + strCallfield;
	OpenWindow(strURL,'ClassificationDataWin',540,340,100,100);	
	return;
}

function CalCutter(intType) {
    var strPhrase;    
	if (document.forms[0].tag082$b) {
	    strPhrase = document.forms[0].tag082$b.value;//document.forms[0].tag082.value.substring(document.forms[0].tag082.value.lastIndexOf("$b") + 2, document.forms[0].tag082.value.length);
	    if (intType == 0) {
	        if (document.forms[0].tag245$a.value != "") {
	            parent.Hiddenbase.location.href = "WGenCutter.aspx?intType=" + intType + "&tag245$a=" + document.forms[0].tag245$a.value;
	        } else {
	            alert("Chưa nhập dữ liệu trường 245$a");
	        }
	    }
	    else {
	        if (document.forms[0].tag100$a.value != "") {
	            parent.Hiddenbase.location.href = "WGenCutter.aspx?intType=" + intType + "&tag100$a=" + document.forms[0].tag100$a.value;
	        } else {
	            alert("Chưa nhập dữ liệu trường 100$a");
	        }
	    }
	}
}

/*
	UpdateLeader function
*/
function UpdateLeader(tagsrc, tagloc, ldrloc1, ldrloc2) {
	if (tagsrc == "") {
		tagsrc = "parent.Sentform.document.forms[0].txtFieldCodes";
	}
	if (tagloc == "") {
		tagloc = "parent.Sentform.document.forms[0].tag";
	}
	if (ldrloc1 == "") {
		ldrloc1 = "parent.Sentform.document.forms[0].txtLeader";
	}
	if (ldrloc2 == "") {
		ldrloc2 = "document.forms[0].txtLeader";
	}
	var ldrstr = eval(ldrloc1 + ".value");
    eval(ldrloc1 + ".value = CalculateRecordLength('" + tagsrc + "', '" + tagloc + "', '" + ldrloc1 + "') + '" + ldrstr.substring(5, 12) + "' + CalculateBaseAdd('"  + tagsrc + "', '" + tagloc + "', '" + ldrloc1 + "') + '"  + ldrstr.substring(17, ldrstr.length) + "'");
    eval(ldrloc2 + ".value = " + ldrloc1 + ".value");
	return;
}

function ReverdValue() {
    for (var i = 0; i < ArrFieldCode.length; i++) {
        if (ArrFieldCode[i]=="245$b") {
            var temp = document.forms[0].elements.namedItem("tag245$b_ss").value;
            if (temp[0] == ':') {
                temp = temp.substring(1, temp.length);
            }
            temp = temp.replace(" .", "");
            temp = temp.replace(" .", "");
            temp = temp.replace("''", "'");
            temp = temp.replace("'''", "'");
            document.forms[0].elements.namedItem("tag245$b_ss").value = temp;

            temp = document.forms[0].elements.namedItem("tag245$b_pd").value;
            if (temp[0] == ':') {
                temp = temp.substring(1, temp.length);
            }
            temp = temp.replace(" .", "");
            temp = temp.replace(" .", "");
            temp = temp.replace("''", "'");
            temp = temp.replace("'''", "'");
            document.forms[0].elements.namedItem("tag245$b_pd").value = temp;
        }
        else {
            var temp = document.forms[0].elements.namedItem("tag" + ArrFieldCode[i]).value;
            if (temp[0] == ':') {
                temp = temp.substring(1, temp.length);
            }
            temp = temp.replace(" .", "");
            temp = temp.replace(" .", "");
            temp = temp.replace("''", "'");
            temp = temp.replace("'''", "'");
            document.forms[0].elements.namedItem("tag" + ArrFieldCode[i]).value = temp;
        }
    }
}

/*
	CodedDataHelp function
*/
function CodedHelp(strFieldCode, intIsAuthority) {
	//var strLeader = parent.Sentform.document.forms[0].txtLeader.value;
	var strLeader = document.forms[0].txtLeader.value;
	var strRecordType = strLeader.substring(6, 7);
	var strDirLevel = strLeader.substring(7, 8);
	var strURL;
	if (parseFloat(intIsAuthority) == 1) {
		strURL = "WField008Authority.aspx";
	} else {
		switch(strFieldCode) {
			case "006":
				switch (strRecordType) {
					case "a": // BOOKS
							if ((strDirLevel == "a") || (strDirLevel == "c") || (strDirLevel == "d") || (strDirLevel == "m")) {
								strURL = "WField006ID4.aspx";
							}	// CONTINUING RESOURCES
							if ((strDirLevel == "b") || (strDirLevel == "s")) {
								strURL = "WField006ID8.aspx";
							}
							break;
					case "t": // BOOKS
						strURL = "WField006ID4.aspx";
						break;
					case "m": //COMPUTER FILES/ELECTRONIC RESOURCES
						strURL = "WField006ID5.aspx";
						break;
					case "e": //MAPS
						strURL = "WField006ID6.aspx";
						break;
					case "f": //MAPS
						strURL = "WField006ID6.aspx";
						break;
					case "c": // MUSIC
						strURL = "WField006ID7.aspx";
						break;                    
					case "d": // MUSIC
						strURL = "WField006ID7.aspx";
						break;						
					case "j": // MUSIC
						strURL = "WField006ID7.aspx";
						break;                    
					case "i": // MUSIC
						strURL = "WField006ID7.aspx";
						break;					
					case "g": // VISUAL MATERIALS
						strURL = "WField006ID9.aspx";
						break;					
					case "o": // VISUAL MATERIALS
						strURL = "WField006ID9.aspx";
						break;
					case "r": // VISUAL MATERIALS
						strURL = "WField006ID9.aspx";
						break;
					case "p": // MIXED MATERIALS
						strURL = "WField006ID10.aspx";
						break;
					default:
						strURL = "WField006ID4.aspx";
						break;
				}
				break;
			case "007":
				switch (strRecordType) {
						case "m": // Electronic resource
							strURL = "WField007ID12.aspx";
							break;
						case "e": // Map
							strURL = "WField007ID11.aspx";
							break;                        
						case "f": // Map
							strURL = "WField007ID11.aspx";
							break; 
						case "c": // Sound recording
							strURL = "WField007ID21.aspx";
							break;                        
						case "d": // Sound recording
							strURL = "WField007ID21.aspx";
							break;     						
						case "i": // Sound recording
							strURL = "WField007ID21.aspx";
							break;                        
						case "j": // Sound recording
							strURL = "WField007ID21.aspx";
							break;    						
						case "g": // Motion picture
							strURL = "WField007ID18.aspx";
							break;                        
						case "o": // Kit
							strURL = "WField007ID19.aspx";
							break;                        
						case "p": // Tactile material
							strURL = "WField007ID14.aspx";
							break;                        
						case "r": // Tactile material
							strURL = "WField007ID14.aspx";
							break; 
						case "k": // Nonprojected graphic
							strURL = "WField007ID17.aspx";
							break;    						
						default: // Text (a,t)
							strURL = "WField007ID22.aspx";
							break;
				}
				break;
			case "008":
				switch (strRecordType) {	
						case "a": // Book
							if ((strDirLevel == "a") || (strDirLevel == "c") || (strDirLevel == "d") || (strDirLevel == "m")) {
								strURL = "WField008ID26.aspx";
							}	// Continuing Resources
							if ((strDirLevel == "b") || (strDirLevel == "s")) {
								strURL = "WField008ID2167.aspx";
							}
							break;
						case "m":  // Computer file
							strURL = "WField008ID27.aspx";
							break;
						case "e": // Maps
							strURL = "WField008ID28.aspx";
							break;                        
						case "f": // Maps
							strURL = "WField008ID28.aspx";
							break;
						case "i": // Music
							strURL = "WField008ID29.aspx";
							break;						
						case "j": // Music
							strURL = "WField008ID29.aspx";
							break;
						case "c": // Music
							strURL = "WField008ID29.aspx";
							break;						
						case "d": // Music
							strURL = "WField008ID29.aspx";
							break;
						case "g": // Visual Materials
							strURL = "WField008ID30.aspx";
							break;
						case "k": // Visual Materials
							strURL = "WField008ID30.aspx";
							break;
						case "o": // Visual Materials
							strURL = "WField008ID30.aspx";
							break;
						case "r": // Visual Materials
							strURL = "WField008ID30.aspx";
							break;
						case "p": // Mixed Materials
							strURL = "WField008ID31.aspx";
							break;	
						default:
							strURL = "WField008ID26.aspx";
							break;
				}
				break;
		}
	}
	strURL = "CodedFields/" + strURL;
	CodedHelpWin = window.open(strURL +"?WorkField=Workform.document.forms[0].tag" + strFieldCode + "&SendField=Sentform.document.forms[0].tag" + strFieldCode, "CodedHelpWin", "height=400,width=700,resizable,scrollbars=yes,toolbar=no,screenX=100,screenY=100,top=100,left=60");
	CodedHelpWin.focus();
}

/*
	FieldHelp function
*/
function FieldHelp(intFormID, strFieldCode) {
	var strIndicators = "";
	if (eval("document.forms[0].ind" + strFieldCode)) {
		strIndicators = eval("document.forms[0].ind" + strFieldCode + ".value");
	}
	//eval("Tag" + strFieldCode + "Win = window.open('WMarcFieldHelp.aspx?Indicator=' + strIndicators + '&Val=' + Esc(document.forms[0].tag" + strFieldCode + ".value, " + intUtf + ") + '&FormID=" + intFormID + "&FieldCode=" + strFieldCode + "', 'Tag" + strFieldCode + "Win', 'width=700, height=400,resizable,scrollbars=yes,screenX=50,screenY=100,top=100,left=50')");
	//val("Tag" + strFieldCode + "Win.focus()");
	top.showDialogContent("Catalogue/Catalogue/WMarcFieldHelp.aspx?Indicator=" + strIndicators + "&Val=" + Esc("document.forms[0].tag" + strFieldCode + ".value, " + intUtf) + "&FormID=" + intFormID + "&FieldCode=" + strFieldCode, true, '', 0, 0);
}

/*
	CalculateRecordLength function
	Purpose: calculate length of the current record
*/
function CalculateRecordLength(tagsrc, tagloc, ldrloc) {
	var intIndex;
	var intRecordLength = 1;
	var strZeroPad = "00000";
	var strLeaderValue = eval(ldrloc + ".value");
	intRecordLength = intRecordLength + strLeaderValue.length;
	var rlkept = intRecordLength;
	var strFieldCodes = eval(tagsrc + ".value");
	var strFieldValue;
	while (strFieldCodes.length > 0) {
		intIndex = strFieldCodes.indexOf(",")
		if (intIndex >=0) {
			strFieldCode = strFieldCodes.substring(0, intIndex);
			strFieldCodes = strFieldCodes.substring(intIndex + 1, strFieldCodes.length);
		} else {
			strFieldCode = strFieldCodes;
			strFieldCodes = "";
		}
		intRecordLength = intRecordLength + CalculateFieldLength(eval(tagloc + strFieldCode + ".value"));
	}
	if (intRecordLength > rlkept) {
		intRecordLength++;
	}
	intRecordLength = "" + intRecordLength;
	return strZeroPad.substring(0, 5 - intRecordLength.length) + intRecordLength;
}

/*
	CalculateFieldLength function
	Purpose: caculate the length of the current field
*/
function CalculateFieldLength(strValue) {
	var intFieldLenth = 0;
	var intIndex;
	var strRecord;
	while (strValue.length > 0) {
		intIndex = strValue.indexOf("$&");
		if (intIndex >= 0) {
			strRecord = strValue.substring(0, intIndex);
			strValue = strValue.substring(intIndex + 2, strValue.length);
		} else {
			strRecord = strValue;
			strValue = "";
		}
		if (strRecord != "::" && strRecord.length > 0) {
			var colonp = strRecord.indexOf("::");
			if (colonp >= 0 && colonp <=2) {
				strRecord = "  " + strRecord.substring(colonp + 2, strRecord.length);
			}
			intFieldLenth = intFieldLenth + 12 + strRecord.length + 1;
		}
	}
	return intFieldLenth;
}

/*
	CalculateBaseAdd function
	Purpose: caculate the BaseAddress of the current record
*/
function CalculateBaseAdd (tagsrc, tagloc, ldrloc) {
	var lngIndex;
	var strFieldCode;
	var lngBaseLength = 24;
	var strZeroPad = "00000";	
	var lngBaseLengthKept = lngBaseLength;
	var strFieldCodes = eval(tagsrc + ".value");

	while (strFieldCodes.length > 0) {
		lngIndex = strFieldCodes.indexOf(",")
		if (lngIndex >=0) {
			strFieldCode = strFieldCodes.substring(0, lngIndex);
			strFieldCodes = strFieldCodes.substring(lngIndex + 1, strFieldCodes.length);
		} else {
			strFieldCode = strFieldCodes;
			strFieldCodes = "";
		}
		lngBaseLength = lngBaseLength + CalculateTagDirLength(eval(tagloc + strFieldCode + ".value"));
	}
	if (lngBaseLength > lngBaseLengthKept)
	{
		lngBaseLength++;
	}
	lngBaseLength = "" + lngBaseLength;
	return strZeroPad.substring(0, 5 - lngBaseLength.length) + lngBaseLength;
}

/*
	CalculateTagDirLength function
	Purpose: caculate the BaseAddress of the current record
*/
function CalculateTagDirLength(strValue) {
	var lngDirLength = 0;
	var lngIndex;
	while (strValue.length > 0 && strValue != "::"){
		lngIndex = strValue.indexOf("$&");
		if (lngIndex >= 0) {
			lngDirLength = lngDirLength + 12;
			strValue = strValue.substring(lngIndex + 2, strValue.length);
		} else {
			lngDirLength = lngDirLength + 12;
			strValue = "";
		}
	}
	return lngDirLength;
}

/*
	RestoreValue function
	Purpose: Restore all field value of cataloguing form
	Creator: Oanhtn
	CreatedDate: 19/05/2004
*/
function RestoreValue() {
	var intCounter;
	var strDeliminator;
	var lngIndex;
	var strFieldCode;
    document.forms[0].txtLeader.value = parent.Sentform.document.forms[0].txtLeader.value;
    if (eval("parent.Sentform.document.forms[0].tag900")) {
		if (parent.Sentform.document.forms[0].tag900.value == '1' || parent.Sentform.document.forms[0].tag900.value != 'True') {
			document.forms[0].optNew.checked = true;
        }
        else {
			document.forms[0].optRenew.checked = true;
		}
	    
		if  (document.forms[0].optNew.checked == true)  {
			parent.Sentform.document.forms[0].tag900.value ='1';
		} else {
			parent.Sentform.document.forms[0].tag900.value ='0';
		}
    }    


	if(strRepeatFieldValue.length > 1) {
		while (strRepeatFieldValue.length > 0){
			lngIndex = strRepeatFieldValue.indexOf(",");
			if (lngIndex > 0) {
				strFieldCode = strRepeatFieldValue.substring(0, lngIndex);
				strRepeatFieldValue = strRepeatFieldValue.substring(lngIndex + 1, strRepeatFieldValue.length);
			} else {
				strFieldCode = strRepeatFieldValue;
				strRepeatFieldValue = "";
			}
			LoadRecNo(strFieldCode);
		}
    }

    for (intCounter = 0; intCounter < ArrFieldCode.length; intCounter++) {
        try {
		    TagArr[intCounter] = ArrFieldCode[intCounter];
			if (ArrFieldRep[intCounter] == "1") {
			    ViewRecord(ArrFieldCode[intCounter], 1, document.forms[0].txtJsmsg3.value, document.forms[0].txtJsmsg4.value)
            }
            else {
                if (ArrFieldCode[intCounter] == "245$b") {
                    let value = parent.Sentform.document.forms[0].tag245$b.value;
                    if (value.length > 0) {
                        let idx = value.indexOf("##");
                        if (idx >= 0) {
                            document.forms[0].tag245$b_ss.value = value.substring(0, idx);
                            document.forms[0].tag245$b_pd.value = value.substring(idx+2,value.length);
                        }
                        else {
                            document.forms[0].tag245$b_ss.value = "";
                            document.forms[0].tag245$b_pd.value = value;
                            parent.Sentform.document.forms[0].tag245$b.value = "##" + value;
                        }
                    }
                    else {
                        document.forms[0].tag245$b_ss.value = "";
                        document.forms[0].tag245$b_pd.value = "";
                    }
                }
                else if (ArrFieldCode[intCounter].substring(0, 2) != "00") {
                    strDeliminator = eval("parent.Sentform.document.forms[0].tag" + ArrFieldCode[intCounter] + ".value.indexOf('::')");
                    if (strDeliminator >= 0 && strDeliminator <= 2 && eval("document.forms[0].ind" + ArrFieldCode[intCounter])) {
                        eval("document.forms[0].tag" + ArrFieldCode[intCounter] + ".value = parent.Sentform.document.forms[0].tag" + ArrFieldCode[intCounter] + ".value.substring("+(strDeliminator + 2)+", parent.Sentform.document.forms[0].tag" + ArrFieldCode[intCounter] + ".value.length)");
                        eval("document.forms[0].ind" + ArrFieldCode[intCounter] + ".value = parent.Sentform.document.forms[0].tag" + ArrFieldCode[intCounter] + ".value.substring(0, "+strDeliminator+")");
                    }
                    else {
                        eval("document.forms[0].tag" + ArrFieldCode[intCounter] + ".value = parent.Sentform.document.forms[0].tag" + ArrFieldCode[intCounter] + ".value");
                    }
                }
                else {
                    eval("document.forms[0].tag" + ArrFieldCode[intCounter] + ".value = parent.Sentform.document.forms[0].tag" + ArrFieldCode[intCounter] + ".value");
                }
            }
        } catch (except) {

        }
	}
	
	if (document.forms[0].tag001) {
	    document.forms[0].tag001.focus();
	}
}


/*
	ViewRecord function
	Purpose: Restore all field value of cataloguing form
	Creator: Oanhtn
	CreatedDate: 19/05/2004
*/	
function ViewRecord(strStoreField, intRecordNumber, strMess1, strMess2) {
	var intMaxRecord;
	var intPosition;
	var thisField;
	var intIndex;
	var intCounter;
	var arrRecord = new Array();	
	var strStoreValue = eval("parent.Sentform.document.forms[0].tag" + strStoreField + ".value");
	if (strStoreValue == "") {
		return;
	}

	intMaxRecord = eval("parseFloat(document.forms[0].nr" + strStoreField + "2.value)");
	if (intRecordNumber < 1) {
		alert(strMess1);
		return;
	}

	if (intRecordNumber > intMaxRecord) {
		alert(strMess2);
		return;
	}

	eval("document.forms[0].nr" + strStoreField + "1.value=" + intRecordNumber);
	intCounter = intRecordNumber - 1;
	intIndex = 0;
	while (strStoreValue.length > 0) {
		intPosition = strStoreValue.indexOf("$&");
		if (intPosition >= 0) {
			arrRecord[intIndex] = strStoreValue.substring(0, intPosition);
			strStoreValue = strStoreValue.substring(intPosition + 2, strStoreValue.length);
		} else {
			arrRecord[intIndex]= strStoreValue;
			strStoreValue = "";
		}
		intIndex++;
	}

	if (intCounter == intIndex) {
		intCounter--;
		eval("document.forms[0].nr" + strStoreField + "1.value=" + intIndex);
	}

	intPosition = arrRecord[intCounter].indexOf("::");
	arrRecord[intCounter] = EscapeSingleQuote(arrRecord[intCounter]);
	if (intPosition >= 0 && intPosition <= 2 && eval("document.forms[0].ind" + strStoreField)) {
		eval("document.forms[0].tag" + strStoreField + ".value = '" + arrRecord[intCounter].substring(intPosition + 2, arrRecord[intCounter].length) + "'");
		eval("document.forms[0].ind" + strStoreField + ".value = '" + arrRecord[intCounter].substring(0, intPosition) + "'");
    } else {
        if (intPosition >= 0 && intPosition <= 2) {
            eval("document.forms[0].tag" + strStoreField + ".value = '" + arrRecord[intCounter].substring(intPosition + 2, arrRecord[intCounter].length) + "'");
        }
        else {
            eval("document.forms[0].tag" + strStoreField + ".value = '" + arrRecord[intCounter] + "'");
        }
	}	
	
	if (eval("document.forms[0].ind" + strStoreField)) {
		eval("document.forms[0].ind" + strStoreField + ".focus()");
	} else {
		eval("document.forms[0].tag" + strStoreField + ".focus()");
	}
}

/*
	EscapeSingleQuote function
	Purpose: escape single quote
	Creator: Oanhtn
	CreatedDate: 19/05/2004
*/
function EscapeSingleQuote(strInput) {
    var strOutput = "";
    var intCounter;
	for (intCounter = 0; intCounter < strInput.length; intCounter++) {
	   if (strInput.charAt(intCounter) == "'") {
	        strOutput = strOutput + "\\'";
	   } else {
	        strOutput = strOutput + strInput.charAt(intCounter);
	   }
	}
	return strOutput;
}

/*
	UpdateRecord function
	Purpose: UpdateRecord (repeatable fields)
	Creator: Oanhtn
	CreatedDate: 19/05/2004
	Input: - intOption (0: from cataloguing form, 1: from new window)
		   - strFieldCode: string of fielcode
*/
function UpdateRecord(strFieldCode, intOption) {
	if (strFieldCode == "") {
		return; 
	}
	var intCounter;
	var intCounter1 = 0;
	var intPosition;
	var arrFieldValues = new Array();
	var strStoreValue;
	
	if (intOption == 0) {
		u(strFieldCode);
	} else {
		ud(strFieldCode);
	}	

	if (intOption == 0 ) {
		strStoreValue = eval("parent.Sentform.document.forms[0].tag" + strFieldCode + ".value");
	} else {
		strStoreValue = eval("top.main.Sentform.document.forms[0].tag" + strFieldCode + ".value");
	}

	while (strStoreValue.length > 0) {
		intPosition = strStoreValue.indexOf("$&");
		if (intPosition >= 0) {
			arrFieldValues[intCounter1] = strStoreValue.substring(0, intPosition);
			strStoreValue = strStoreValue.substring(intPosition + 2, strStoreValue.length);
		} else {
			arrFieldValues[intCounter1]= strStoreValue;
			strStoreValue = "";
		}
		intCounter1++;
	}

	if (intOption == 0 ) {
		var currentRecord = eval("parseFloat(document.forms[0].nr" + strFieldCode + "1.value)");
		if (currentRecord == 0) {
			eval("document.forms[0].nr" + strFieldCode + "1.value = 1");
			eval("document.forms[0].nr" + strFieldCode + "2.value = 1");
		} else {
			currentRecord--;
			if (currentRecord > intCounter1) {
				intCounter1 = currentRecord;
			}
		}
		if (eval("document.forms[0].ind" + strFieldCode)) {
			arrFieldValues[currentRecord] = eval("document.forms[0].ind" + strFieldCode + ".value") + "::" + eval("document.forms[0].tag" + strFieldCode + ".value"); 
		} else {
			arrFieldValues[currentRecord] = eval("document.forms[0].tag" + strFieldCode + ".value"); 
		}
	} else {
		var currentRecord = eval("parseFloat(top.main.Workform.document.forms[0].nr" + strFieldCode + "1.value)");
		if (currentRecord == 0) {
			eval("top.main.Workform.document.forms[0].nr" + strFieldCode + "1.value = 1");
			eval("top.main.Workform.document.forms[0].nr" + strFieldCode + "2.value = 1");
		} else {
			currentRecord--;
			if (currentRecord > intCounter1) {
				intCounter1 = currentRecord;
			}
		}
		if (eval("top.main.Workform.document.forms[0].ind" + strFieldCode)) {
			arrFieldValues[currentRecord] = eval("top.main.Workform.document.forms[0].ind" + strFieldCode + ".value") + "::" + eval("top.main.Workform.document.forms[0].tag" + strFieldCode + ".value"); 
		} else {
			arrFieldValues[currentRecord] = eval("top.main.Workform.document.forms[0].tag" + strFieldCode + ".value"); 
		}	
	}

	strStoreValue = "";
	for (intCounter = 0; intCounter <= intCounter1; intCounter++) {
		if (arrFieldValues[intCounter]) {
			strStoreValue = strStoreValue + arrFieldValues[intCounter] + "$&";
		}
	}
	strStoreValue = EscapeSingleQuote(strStoreValue);
	if (intOption == 0) {
		eval("parent.Sentform.document.forms[0].tag" + strFieldCode + ".value = '" + strStoreValue + "'");
		UpdateLeader('', '', '', '');
	} else {
		eval("top.main.Sentform.document.forms[0].tag" + strFieldCode + ".value = '" + strStoreValue + "'");
		UpdateLeader("top.main.Sentform.document.forms[0].txtFieldCodes", "top.main.Sentform.document.forms[0].tag", "top.main.Sentform.document.forms[0].txtLeader", "top.main.Workform.document.forms[0].txtLeader");
	}	
}

function UpdateRecord245(strFieldCode) {
    let value = parent.Sentform.document.forms[0].tag245$b.value;
    if (value.length > 0) {
        let delim = value.indexOf("##");
        if (delim >= 0) {
            if (strFieldCode == "245$b_ss") {
                let right = value.substring(delim + 2, value.length);
                value = document.forms[0].tag245$b_ss.value + "##" + right;
                parent.Sentform.document.forms[0].tag245$b.value = value;
            }
            else {
                let left = value.substring(0, delim);
                value = left + "##" + document.forms[0].tag245$b_pd.value;
                parent.Sentform.document.forms[0].tag245$b.value = value;
            }
        }
        else {
            if (strFieldCode == "245$b_ss") {
                parent.Sentform.document.forms[0].tag245$b.value = document.forms[0].tag245$b_ss.value+"##";
            }
            else {
                parent.Sentform.document.forms[0].tag245$b.value = "##" + document.forms[0].tag245$b_pd.value;
            }
        }
    }
    else {
        if (strFieldCode == "245$b_ss") {
            value = document.forms[0].tag245$b_ss.value + "##";
            parent.Sentform.document.forms[0].tag245$b.value = value;
        }
        else {
            value = "##" + document.forms[0].tag245$b_pd.value;
            parent.Sentform.document.forms[0].tag245$b.value = value;
        }
    }
}

/*
	AddNewRecord function
	Purpose: Add new value for repeatable field
	Creator: Oanhtn
	CreatedDate: 21/05/2004
*/
function AddNewRecord(strFieldCode, strControl1, strControl2) {
	var intNOR;
	var intIndex;
	eval("document.forms[0].tag" + strFieldCode + ".value = ''");
	if (eval("document.forms[0].ind" + strFieldCode)) {
		eval("document.forms[0].ind" + strFieldCode + ".value = ''");
	}
	var intNOR = CountRecord(strFieldCode);
	var intIndex = parseFloat(strControl2.value);
	if (intIndex == intNOR) {
		intIndex++;
	}
	strControl1.value = intIndex;
	strControl2.value = intIndex;
	if (eval("document.forms[0].ind" + strFieldCode)) {
		eval("document.forms[0].ind" + strFieldCode + ".focus()");
	} else {
		eval("document.forms[0].tag" + strFieldCode + ".focus()");
	}
}

/*
	DeleteRecord function
	Purpose: delete current value for repeatable field
	Creator: Oanhtn
	CreatedDate: 21/05/2004
*/
function DeleteRecord(strFieldCode, recno) {
	var intPosition;
	var intNOR;
	var intCounter;
	var records = new Array();
	var currentRecord;
	u(strFieldCode);
	var strFieldValue = eval("parent.Sentform.document.forms[0].tag" + strFieldCode + ".value");
	if (strFieldValue == "") {
		return;
	}
	intNOR = 0;
	intCounter = 0;
	while (strFieldValue.length > 0) {
		intPosition = strFieldValue.indexOf("$&");
		if (intPosition >= 0) {
			records[intCounter] = strFieldValue.substring(0, intPosition);
			strFieldValue = strFieldValue.substring(intPosition + 2, strFieldValue.length);
        }
        else {
			records[intCounter]= strFieldValue;
			strFieldValue = "";
		}
		intCounter++;
	}
	
	intNOR = intCounter;
	if (intNOR==0) {return;}
	currentRecord = recno - 1;
	records[currentRecord] = "";

	for (intCounter = 0; intCounter <= intNOR; intCounter++) {
		if (records[intCounter]) {
			strFieldValue = strFieldValue + records[intCounter] + "$&";
		}
	}
	
	strFieldValue = EscapeSingleQuote(strFieldValue);
	eval("parent.Sentform.document.forms[0].tag" + strFieldCode + ".value='" + strFieldValue + "'");

	intNOR--;
	eval("document.forms[0].nr" + strFieldCode + "2.value=" + intNOR);
	if (intNOR > 0) {
		ViewRecord(strFieldCode, 1);
	} else {
		eval("document.forms[0].nr" + strFieldCode + "1.value=" + intNOR);
		eval ("document.forms[0].tag" + strFieldCode + ".value = ''");
		if (eval("document.forms[0].ind" + strFieldCode)) {
			eval("document.forms[0].ind" + strFieldCode + ".value = ''");
		}
	}
	UpdateLeader('', '', '', '');

	if (strFieldCode=='856$f'){
	    removeFileCallbackk(recno-1);
	}
}

/*
	CountRecord function
	Purpose: Count number of value for repeatable field
	Creator: Oanhtn
	CreatedDate: 21/05/2004
*/
function CountRecord(strFieldCode) {
	var intPosition;
	var intCounter = 0;	
	if (eval("parent.Sentform.document.forms[0].tag" + strFieldCode)) {
		var strFieldValue = eval("parent.Sentform.document.forms[0].tag" + strFieldCode + ".value");
		while (strFieldValue.length > 0) {
			intPosition = strFieldValue.indexOf("$&");
			if (intPosition >= 0) {
				strFieldValue = strFieldValue.substring(intPosition + 2, strFieldValue.length);
            }
            else {
				strFieldValue = "";
			}
			intCounter++;
		}
	}

	return intCounter;	
}

/*
	microsoftKeyPress
	Purpose: create some 
*/
function microsoftKeyPress() {
	var strCurrentValue;
	var strPrefix = '';
	if (window.event.keyCode == 13) {
		strCurrentValue = eval("document.forms[0].tag" + TagArr[curtab] + ".value");
		if (strCurrentValue != "") {
			if (eval("document.forms[0].nr" + TagArr[curtab] + "1")) {
				eval("document.forms[0].tag" + TagArr[curtab] + ".blur()");
				eval("document.forms[0].btn" + TagArr[curtab] + "5.click()");
			} else {
				curtab = curtab + 1;
				if (curtab < TagArr.length) {
					if (eval("document.forms[0].ind" + TagArr[curtab])) {
						eval("document.forms[0].ind" + TagArr[curtab] + ".focus()");
			        } else if (eval("document.forms[0].tag" + TagArr[curtab])) {
						eval("document.forms[0].tag" + TagArr[curtab] + ".focus()");
					}
				} else {
					eval("document.forms[0].tag" + TagArr[curtab - 1] + ".blur()");
					parent.Sentform.document.forms[0].btnUpdate.focus()
				}
			}
		} else {
			curtab = curtab + 1;
			if (curtab < TagArr.length) {
				if (eval("document.forms[0].ind" + TagArr[curtab])) {
					eval("document.forms[0].ind" + TagArr[curtab] + ".focus()");
				} else if (eval("document.forms[0].tag" + TagArr[curtab])) {
					eval("document.forms[0].tag" + TagArr[curtab] + ".focus()");
				}
			} else {
				eval("document.forms[0].tag" + TagArr[curtab - 1] + ".blur()");
				parent.Sentform.document.forms[0].btnUpdate.focus();
			}
		}
		window.event.keyCode = 27;
		//return false;
	}
    if (window.event.ctrlKey) {
		strPrefix += 'c';
		if (window.event.shiftKey) strPrefix += 's';
	}
	if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csu") {
		parent.Sentform.document.forms[0].btnUpdate.click();
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "css") {
		parent.Sentform.document.forms[0].btnSpellCheck.click();
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csm") {
		parent.Sentform.document.forms[0].btnValidate.click();
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csy") {
		//parent.Sentform.document.forms[0].importbutt.click();
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "cso") {
		//parent.Sentform.document.forms[0].holdingbutt.click();
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csv") {
		parent.Sentform.document.forms[0].btnPreview.click();
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csf") {
		parent.Sentform.document.forms[0].btnAddFields.click();
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csl") {
		if (eval("document.forms[0].nr" + TagArr[curtab] + "1"))
			eval("document.forms[0].tag" + TagArr[curtab] + ".blur()");
			eval("document.forms[0].btn" + TagArr[curtab] + "2.click()");
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csr") {
		if (eval("document.forms[0].nr" + TagArr[curtab] + "1"))
			eval("document.forms[0].tag" + TagArr[curtab] + ".blur()");
			eval("document.forms[0].btn" + TagArr[curtab] + "3.click()");
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csb") {
		if (eval("document.forms[0].nr" + TagArr[curtab] + "1"))
			eval("document.forms[0].tag" + TagArr[curtab] + ".blur()");
			eval("document.forms[0].btn" + TagArr[curtab] + "1.click()");
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "cse") {
		if (eval("document.forms[0].nr" + TagArr[curtab] + "1"))
			eval("document.forms[0].tag" + TagArr[curtab] + ".blur()");
			eval("document.forms[0].btn" + TagArr[curtab] + "4.click()");
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csd") {
		if (eval("document.forms[0].nr" + TagArr[curtab] + "1"))
			eval("document.forms[0].btn" + TagArr[curtab] + "6.click()");
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csn") {
		if (eval("document.forms[0].nr" + TagArr[curtab] + "1"))
			eval("document.forms[0].tag" + TagArr[curtab] + ".blur()");
			eval("document.forms[0].btn" + TagArr[curtab] + "5.click()");
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csp") {
			eval(eval("p" + TagArr[curtab] + ".href"));
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csk") {
			eval(eval("k" + TagArr[curtab] + ".href"));
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csi") {
			eval(eval("d" + TagArr[curtab] + ".href"));
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csa") {
			eval(eval("a" + TagArr[curtab] + ".href"));
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csh") {
			eval(eval("h" + TagArr[curtab] + ".href"));
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csc") {
			CalCutter(1);
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csq") {
			CalCutter(0);
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csz") {
			eval(eval("y" + TagArr[curtab] + ".href"));
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csa") {
			eval(eval("a" + TagArr[curtab] + ".href"));			
	} else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "cst") {
		tag = prompt(strLabel38 + ":", "");
		if (eval("document.forms[0].ind" + tag))
			eval("document.forms[0].ind" + tag + ".focus()");
		else if (eval("document.forms[0].tag" + tag))
			eval("document.forms[0].tag" + tag + ".focus()");
	}
}

/*
	ChangeTab function
*/
function ChangeTab(tag) {
	var intCounter;
	for (intCounter = 0; intCounter < TagArr.length; intCounter++) {
		if (TagArr[intCounter] == tag) {
			curtab = intCounter;
			break;
		}
	}
}

/*
	LoadRecNo function
	Purpose: Load record number
*/
function LoadRecNo(strFieldCode) {
    var intCount;
    intCount = CountRecord(strFieldCode);
    eval("document.forms[0].nr" + strFieldCode + "1.value=" + intCount);
    eval("document.forms[0].nr" + strFieldCode + "2.value=" + intCount);
}

/*
	newMergeRecord function
	Purpose: Load field value from helpform
	Creator: Oanhtn
	CreatedDate: 08/06/2004
*/
function newMergeRecord(strStoreFieldCode, intTagCount) {
	if (top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value.indexOf(strStoreFieldCode) < 0) {
		top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value = top.main.Sentform.document.forms[0].txtModifiedFieldCodes.value + strStoreFieldCode + ",";
	}
	var strIndicator = "";
	var strTagValue = "";
	var intCounter;
	if (strStoreFieldCode.substring(0,2) != "00") {
		strIndicator = document.forms[0].txtIndicator.value;
	}
	for (intCounter = 1; intCounter <= intTagCount; intCounter++) {
		if (eval("document.forms[0].TPick" + intCounter + ".options[document.forms[0].TPick" + intCounter + ".selectedIndex].value != ''")) {
			if (eval("document.forms[0].TSign" + intCounter + ".value != ' ' && document.forms[0].TSign" + intCounter + ".value != ''"))  {
				if (eval("document.forms[0].TSign" + intCounter + ".value != '.' && document.forms[0].TSign" + intCounter + ".value != ','")) {
					strTagValue = strTagValue + ' ' + eval("document.forms[0].TSign" + intCounter + ".value");
				} else {
					strTagValue = strTagValue  + eval("document.forms[0].TSign" + intCounter + ".value");
				}
			}
			strTagValue = strTagValue + eval("document.forms[0].TPick" + intCounter + ".options[document.forms[0].TPick" + intCounter + ".selectedIndex].value") + eval("document.forms[0].TVal" + intCounter + ".value");
		}
	}
	strTagValue = EscapeSingleQuote(strTagValue);
	if (eval("top.main.Workform.document.forms[0].ind" + strStoreFieldCode)) {
		eval("top.main.Workform.document.forms[0].ind" + strStoreFieldCode + ".value = '" + strIndicator + "'");
	}
	eval("top.main.Workform.document.forms[0].tag" + strStoreFieldCode + ".value = '" + strTagValue + "'");
	if (!eval("top.main.Workform.document.forms[0].nr" + strStoreFieldCode + "1")) {
		if (strIndicator != "") {
			strIndicator = strIndicator + "::";
		}
		eval("top.main.Sentform.document.forms[0].tag" + strStoreFieldCode + ".value = '" + strIndicator + strTagValue + "'");
	} else {
		UpdateRecord(strStoreFieldCode, 1);
	}
	eval("top.main.Workform.document.forms[0].tag" + strStoreFieldCode + ".focus()");
	UpdateLeader("top.main.Sentform.document.forms[0].txtFieldCodes", "top.main.Sentform.document.forms[0].tag", "top.main.Sentform.document.forms[0].txtLeader", "top.main.Workform.document.forms[0].txtLeader");
}

/*
	AttachFile function
	Purpose: allow attach file
*/
function AttachFile(intItemID,strWorkField, strSentField, strFieldCode, strRepeatable) {
    if ((strRepeatable.toLowerCase() == "true") || (strRepeatable.toLowerCase() == "1")) {
        strRepeatable = 1;
    } else {
        strRepeatable = 0;
    }
    var strURL = "WCataAttachFile.aspx?intItemID=" + intItemID.toString() + "&sfile=";
    if (strFieldCode == '907') {
        strURL = "Catalogue/Catalogue/AcqAttachFileCover.aspx?intItemID=" + intItemID.toString() + "&sfile=";
    }
    if (strFieldCode == '956$a') {
        strURL = "Catalogue/Catalogue/AcqAttachFileCategory.aspx?intItemID=" + intItemID.toString() + "&sfile=";
    }
    else if (strFieldCode == '856$f') {
        strURL = "Catalogue/Catalogue/AcqAttachFile.aspx?intItemID=" + intItemID.toString() + "&sfile=";
    }
    //Catalogue/Catalogue/
    var span_title_form;
    span_title_form = document.getElementById('span_title_form');
    if (strFieldCode == '956$a') {
        var temp = eval("top.main." + strSentField + ".value");
        temp = temp.split('$&').join('::');
        top.showDialogContent(strURL + temp + "&repeatable=" + strRepeatable + "&wfield=" + strWorkField + "&sfield=" + strSentField + "&FieldCode=" + strFieldCode, true, '', 0, 0);
    }
    else
    {
        top.showDialogContent(strURL + Esc(eval("parent." + strWorkField + ".value"), intUtf) + "&repeatable=" + strRepeatable + "&wfield=" + strWorkField + "&sfield=" + strSentField + "&FieldCode=" + strFieldCode, true, '', 0, 0);
    }
    
    //var AttachFileWin = window.open(strURL + Esc(eval("parent." + strWorkField + ".value"), intUtf) + "&repeatable=" + strRepeatable + "&wfield=" + strWorkField + "&sfield=" + strSentField + "&FieldCode=" + strFieldCode, "AttachFileWin", "width=750,height=350,resizable,screenX=100,screenY=100,top=100,left=100");
	//AttachFileWin.focus();
}

/*
	SelectFile function
	Purpose: allow select file
*/
function SelectFile(intItemID, strWorkField, strSentField, strFieldCode, strRepeatable) {
	if ((strRepeatable.toLowerCase() == "true") || (strRepeatable.toLowerCase() == "1")) {
		strRepeatable = 1;
	} else {
		strRepeatable = 0;
    }
    var strURL = "Edeliv/EData/AcqDisplayChooseFilesFrame.aspx?intItemID=" + intItemID.toString() + "&sfile=" + Esc(eval("parent." + strWorkField + ".value"), intUtf) + "&repeatable=" + strRepeatable + "&wfield=" + strWorkField + "&sfield=" + strSentField + "&FieldCode=" + strFieldCode;
    var span_title_form;
    span_title_form = document.getElementById('span_title_form');
    top.showDialogContent(strURL, true, '', 0, 0);
    //alert(strURL);
    //SelectFileWin = window.open(strURL, "AttachFileWin", "width=700,height=500,resizable,screenX=100,screenY=100,top=100,left=100");
	//SelectFileWin.focus();
}

function chooseAddfiles(hidWFieldValue, hidFieldCodeValue, valFiles) {
    eval("top.main.Sentform.document.forms[0].tag" + hidFieldCodeValue + ".value = '" + valFiles.toString() + "'");
    myUpdateRecordByAddFiles(hidFieldCodeValue);
    if (hidFieldCodeValue == '907') {
        top.closeDialog('Dialog_content');
    }
}

function myUpdateRecordByAddFiles(strFieldCode) {
    if (strFieldCode == "") {
        return;
    }
    var intCounter;
    var intCounter1 = 0;
    var intPosition;
    var arrFieldValues = new Array();
    var strStoreValue;

    ud(strFieldCode);

    strStoreValue = eval("top.main.Sentform.document.forms[0].tag" + strFieldCode + ".value");
    while (strStoreValue.length > 0) {
        intPosition = strStoreValue.indexOf("$&");
        if (intPosition >= 0) {
            arrFieldValues[intCounter1] = strStoreValue.substring(0, intPosition);
            strStoreValue = strStoreValue.substring(intPosition + 2, strStoreValue.length);
        } else {
            arrFieldValues[intCounter1] = strStoreValue;
            strStoreValue = "";
        }
        intCounter1++;
    }
    //Kiem tra la truong MARC
    //2016.05.05 B1
    if (eval("top.main.Workform.document.forms[0].nr" + strFieldCode + "1")) {
        var currentRecord = eval("parseFloat(top.main.Workform.document.forms[0].nr" + strFieldCode + "1.value)");

        if (currentRecord == 0) {
            eval("top.main.Workform.document.forms[0].nr" + strFieldCode + "1.value = 1");
            //eval("top.main.Workform.document.forms[0].nr" + strFieldCode + "2.value = 1");
            intCounter1--;
        } else {
            currentRecord--;
            if (currentRecord > intCounter1) {
                intCounter1 = currentRecord;
            }
        }
        eval("top.main.Workform.document.forms[0].nr" + strFieldCode + "2.value = " + intCounter1.toString());
    }
    //2016.05.05 E1
    
    if (eval("top.main.Workform.document.forms[0].ind" + strFieldCode)) {
        arrFieldValues[currentRecord] = eval("top.main.Workform.document.forms[0].ind" + strFieldCode + ".value") + "::" + eval("top.main.Workform.document.forms[0].tag" + strFieldCode + ".value");
    } else {
        arrFieldValues[currentRecord] = eval("top.main.Workform.document.forms[0].tag" + strFieldCode + ".value");
    }

    strStoreValue = "";
    for (intCounter = 0; intCounter <= intCounter1; intCounter++) {
        if (arrFieldValues[intCounter]) {
            strStoreValue = strStoreValue + arrFieldValues[intCounter] + "$&";
        }
    }
    strStoreValue = EscapeSingleQuote(strStoreValue);
    eval("top.main.Sentform.document.forms[0].tag" + strFieldCode + ".value = '" + strStoreValue + "'");
    if (strFieldCode == '907') {
        var val907 = eval("top.main.Workform.document.forms[0].tag" + strFieldCode + ".value");
        eval("top.main.Sentform.document.forms[0].tag" + strFieldCode + ".value = '" + val907 + "'");
    }
    UpdateLeader("top.main.Sentform.document.forms[0].txtFieldCodes", "top.main.Sentform.document.forms[0].tag", "top.main.Sentform.document.forms[0].txtLeader", "top.main.Workform.document.forms[0].txtLeader");
}