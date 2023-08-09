//check patron information before submit form
function SubmitToPatronPage(strCardNumberAlert){	
	if(document.forms[0].txtCardNumber.value=='') {
		alert(strCardNumberAlert);
		document.forms[0].txtCardNumber.focus();
		return(false);//can't submit
	}
	return(true);
}
//check search
function CheckSearch(strSearchAlert){
	if(document.forms[0].txtSearch.value==''){	
		document.forms[0].txtSearch.focus();
		return(false);//can't search
	}
	//to do here
	// FullText Search
	if(document.forms[0].optItemILL.checked==true){
		if(document.forms[0].txtSearch.value.length > 1024){ // search query so long
			alert('length must <= 1024 characters');
			document.forms[0].txtSearch.focus();
			return(false);
		}
	}
	return(true);	
}
function OpenDictionary(dicId,ControlName){
	DicWin = window.open('WDictionary.aspx?pattern=' + Esc(eval('document.forms[0].' + ControlName + '.value'), 1) + '&dicId=' + dicId + '&ControlName=' + ControlName, 'DicWin', 'top=70,left=250,width=340,height=350,resizable,scrollbars=yes');
	DicWin.focus();
}
//add by lent : get value dropdownlist
function GetValueDDL(ddlname) {
	var idx=document.getElementById(ddlname);
	return idx.options[idx.selectedIndex].value;	
}
//add by lent: Go to URL For search Advance and simple
function GotoURL(val) {	
	var linkUrl=""
	switch (val) {
		case 0:
			linkUrl="WSimple.aspx";
			if(document.forms[0].ValDocType.value!='0') 
				linkUrl=linkUrl+'?DocType='+document.forms[0].ValDocType.value;					
			break;
		case 1:
			linkUrl="WAdvance.aspx";
			if(document.forms[0].ValDocType.value!='0') 
				linkUrl=linkUrl+'?DocType='+document.forms[0].ValDocType.value;					
			break;
		case 2:	
			linkUrl="WAllType.aspx";
			switch (document.forms[0].ValDocType.value) {
				case "1":
					linkUrl="WBook.aspx";	
					break;			
				case "2":
					linkUrl="WArticles.aspx";
					break;
				case "3":
					linkUrl="WMagazine.aspx";					
					break;
				case "4":
					linkUrl="WBook.aspx?DocType=4";	
					break;
				case "5":
					linkUrl="WFilms.aspx";
					break;
				case "6":
					linkUrl="WBook.aspx?DocType=6";
					break;
				case "7":
					linkUrl="WBook.aspx?DocType=7";
					break;
				case "8":
					linkUrl="WBook.aspx?DocType=8";
					break;
				case "9":
					linkUrl="WMaps.aspx";
					break;
				case "10":
					linkUrl="WBook.aspx?DocType=10";
					break;					
				case "11":
					linkUrl="WGraph.aspx";
					break;					
				case "12":
					linkUrl="WTheses.aspx";
					break;					
				case "13":
					linkUrl="WBook.aspx?DocType=13";
					break;					
				case "14":
					linkUrl="WBook.aspx?DocType=14";
					break;					
				case "15":
					linkUrl="WBook.aspx?DocType=15";
					break;					
			}
			break;
	}	
	window.location.href=linkUrl;	
	return true;
}

function ResetForm(){
	document.forms[0].reset();
	return false;
}

function ValidData(strForm){
	var blnOK;
	var Msg=document.forms[0].txtMsg.value;
	switch (strForm){
		case "advance":
			blnOK=CheckNull(document.forms[0].txtFieldValue1);
			blnOK=blnOK && CheckNull(document.forms[0].txtFieldValue2);
			blnOK=blnOK && CheckNull(document.forms[0].txtFieldValue3);
			blnOK=blnOK && CheckNull(document.forms[0].txtFieldValue4);
			break;
		case "simple":			
			blnOK=CheckNull(document.forms[0].txtTitle);
			blnOK=blnOK && CheckNull(document.forms[0].txtAuthor);
			blnOK=blnOK && CheckNull(document.forms[0].txtIndexDDC);
			blnOK=blnOK && CheckNull(document.forms[0].txtKeyword);	
			break;
		case "alltype":
			blnOK=CheckNull(document.forms[0].txtTitle);
			blnOK=blnOK && CheckNull(document.forms[0].txtAuthor);
			blnOK=blnOK && CheckNull(document.forms[0].txtPublisher);
			blnOK=blnOK && CheckNull(document.forms[0].txtIndexDDC);
			blnOK=blnOK && CheckNull(document.forms[0].txtLangague);
			blnOK=blnOK && CheckNull(document.forms[0].txtKeyWord);
			break;
		case "articles":
			blnOK=CheckNull(document.forms[0].txtTitle);
			blnOK=blnOK && CheckNull(document.forms[0].txtAuthor);
			blnOK=blnOK && CheckNull(document.forms[0].txtPubYear);
			blnOK=blnOK && CheckNull(document.forms[0].txtIndexDDC);
			blnOK=blnOK && CheckNull(document.forms[0].txtLangague);
			blnOK=blnOK && CheckNull(document.forms[0].txtKeyWord)	;	
			break;
		case "book":
			blnOK=CheckNull(document.forms[0].txtTitle);
			blnOK=blnOK && CheckNull(document.forms[0].txtAuthor);
			blnOK=blnOK && CheckNull(document.forms[0].txtPublisher);
			blnOK=blnOK && CheckNull(document.forms[0].txtPubYear);
			blnOK=blnOK && CheckNull(document.forms[0].txtIndexDDC);
			blnOK=blnOK && CheckNull(document.forms[0].txtLangague)	;	
			blnOK=blnOK && CheckNull(document.forms[0].txtKeyWord)	;
			break;
		case "films":
			blnOK=CheckNull(document.forms[0].txtTitle);
			blnOK=blnOK && CheckNull(document.forms[0].txtAuthor);
			blnOK=blnOK && CheckNull(document.forms[0].txtPublisher);
			blnOK=blnOK && CheckNull(document.forms[0].txtPubYear);
			blnOK=blnOK && CheckNull(document.forms[0].txtIndexDDC);
			blnOK=blnOK && CheckNull(document.forms[0].txtLangague)	;	
			blnOK=blnOK && CheckNull(document.forms[0].txtKeyWord)	;	
			break;
		case "graph":
			blnOK=CheckNull(document.forms[0].txtTitle);
			blnOK=blnOK && CheckNull(document.forms[0].txtAuthor);
			blnOK=blnOK && CheckNull(document.forms[0].txtKeyWord);
			/*
			if (document.forms[0].ddlColor.selectedIndex==0){
				blnOK=blnOK && true;
			}else{
				blnOK=blnOK && false;
			}
			if (document.forms[0].ddlTypeColor.selectedIndex==0){
				blnOK=blnOK && true;
			}else{
				blnOK=blnOK && false;
			}
			
			//blnOK=blnOK && CheckNull(document.forms[0].ddlColor)
			//blnOK=blnOK && CheckNull(document.forms[0].ddlTypeColor)
			blnOK=blnOK && CheckNull(document.forms[0].txtWidthFrom);
			blnOK=blnOK && CheckNull(document.forms[0].txtWidthTo);
			blnOK=blnOK && CheckNull(document.forms[0].txtHeightFrom);
			blnOK=blnOK && CheckNull(document.forms[0].txtHeightTo);
			blnOK=blnOK && CheckNull(document.forms[0].txtMaxResFrom);
			blnOK=blnOK && CheckNull(document.forms[0].txtMaxResTo);
			blnOK=blnOK && CheckNull(document.forms[0].txtMaxSizeFrom);
			blnOK=blnOK && CheckNull(document.forms[0].txtMaxSizeTo);
			*/
			break;
		case "magazine":
			blnOK=CheckNull(document.forms[0].txtTitle);
			blnOK=blnOK && CheckNull(document.forms[0].txtList);
			blnOK=blnOK && CheckNull(document.forms[0].txtFromDate);
			blnOK=blnOK && CheckNull(document.forms[0].txtIssue);		
			blnOK=blnOK && CheckNull(document.forms[0].txtToDate);		
			blnOK=blnOK && CheckNull(document.forms[0].txtVolumn);
			blnOK=blnOK && CheckNull(document.forms[0].txtIndexDDC);
			blnOK=blnOK && CheckNull(document.forms[0].txtLangague);
			blnOK=blnOK && CheckNull(document.forms[0].txtKeyWord);
			break;
		case "maps":
			blnOK=CheckNull(document.forms[0].txtTitle);
			blnOK=blnOK && CheckNull(document.forms[0].txtISBN);
			blnOK=blnOK && CheckNull(document.forms[0].txtPublisher);
			blnOK=blnOK && CheckNull(document.forms[0].txtPubYear)	;	
			blnOK=blnOK && CheckNull(document.forms[0].txtIndexDDC)	;	
			blnOK=blnOK && CheckNull(document.forms[0].txtLangague);
			blnOK=blnOK && CheckNull(document.forms[0].txtKeyWord);
			break;
		case "theses":
			blnOK=CheckNull(document.forms[0].txtTitle);
			blnOK=blnOK && CheckNull(document.forms[0].txtAuthor);
			blnOK=blnOK && CheckNull(document.forms[0].txtSpeciality);
			blnOK=blnOK && CheckNull(document.forms[0].txtPubYear)	;	
			blnOK=blnOK && CheckNull(document.forms[0].txtIndexDDC)	;	
			blnOK=blnOK && CheckNull(document.forms[0].txtLangague);
			blnOK=blnOK && CheckNull(document.forms[0].txtKeyWord);
			break;																		
	}
	if (blnOK){
		alert(Msg);
		return false;	
	}else{
		return true;
	}
}

