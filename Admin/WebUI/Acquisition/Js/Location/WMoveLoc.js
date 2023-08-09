function ShowHideTable(val) {
	if (val==0) {
		tblCodeDoc.style.display="";
		tblCopyNumber.style.display="none";
	}
	else {
		tblCopyNumber.style.display="";
		tblCodeDoc.style.display="none";	
	}
}
function SwitchEnable(val) {
	if (val==0) {
		document.forms[0].txtCopyNumManual.disabled=true;	
		document.forms[0].FileCopyNum.disabled=false;		
		document.forms[0].FileCopyNum.focus();		
	}
	else {
		document.forms[0].txtCopyNumManual.disabled=false;		
		document.forms[0].FileCopyNum.disabled=true;	
		document.forms[0].txtCopyNumManual.focus();
	}
}
function CheckMoveLocation(strNote,strNote1) {
	if (document.forms[0].rdbCodeDoc.checked) {
		if (document.forms[0].txtCodeDoc.value=="") {
			alert(strNote);			
			document.forms[0].txtCodeDoc.focus();			
			return false;
		}
	}	
	else {
		if (document.forms[0].rdbCopyNumFile.checked) {
			if (document.forms[0].FileCopyNum.value=="") {
				alert(strNote);
				document.forms[0].FileCopyNum.focus();
				return false;
			}
		}
		else {
			if (document.forms[0].txtCopyNumManual.value=="") {
				alert(strNote);
				document.forms[0].txtCopyNumManual.focus();
				return false;
			}		
		}
	}
	if (document.forms[0].ddlLibSource.selectedIndex-1==document.forms[0].ddlLibDestination.selectedIndex) {
		if (document.forms[0].ddlLocSource.selectedIndex==document.forms[0].ddlLocDestination.selectedIndex) {
			if (document.forms[0].txtShelfSource.value==document.forms[0].txtShelfDestination.value)
				alert(strNote1);
				return false;
		}		
	}	
	document.forms[0].hidLocSourceID.value=document.forms[0].ddlLocSource.options[document.forms[0].ddlLocSource.options.selectedIndex].value;
	document.forms[0].hidLocDesID.value=document.forms[0].ddlLocDestination.options[document.forms[0].ddlLocDestination.options.selectedIndex].value;
	return true;		
}
function LoadLocation(val){
	if (val==0)	
		if(document.forms[0].ddlLibSource.options[document.forms[0].ddlLibSource.options.selectedIndex].value==0) {
			document.forms[0].ddlLocSource.options.length=1;
			document.forms[0].ddlLocSource.options[0].value=0;
			document.forms[0].ddlLocSource.options[0].text=" ";
		}
		else 			
			parent.hiddenbase.location='WMoveLocationHidden.aspx?Action=Source&LibID=' + document.forms[0].ddlLibSource.options[document.forms[0].ddlLibSource.options.selectedIndex].value;
	else
		parent.hiddenbase.location='WMoveLocationHidden.aspx?Action=Dest&LibID=' + document.forms[0].ddlLibDestination.options[document.forms[0].ddlLibDestination.options.selectedIndex].value;	
	return false;
}
function OpenSearchForm() {
	var url;
	url='../ACQ/WSearchItem.aspx?ControlName=txtCodeDoc';
	openModal(url,'SearchItemID',500,350,150,100,'yes','',0);
	return false;
}
function ShowCopyNumber(strNote) {
	SwitchEnable(1);		
	document.forms[0].rdbCopyNumManual.checked=true;
	if (document.forms[0].ddlLibSource.options[document.forms[0].ddlLibSource.options.selectedIndex].value==0) {
		alert(strNote);
		return false;
		}
	var LibID=document.forms[0].ddlLibSource.options[document.forms[0].ddlLibSource.options.selectedIndex].value;
	var LocID=document.forms[0].ddlLocSource.options[document.forms[0].ddlLocSource.options.selectedIndex].value;
	var LibName=Esc(document.forms[0].ddlLibSource.options[document.forms[0].ddlLibSource.options.selectedIndex].text,1);
	var LocName=Esc(document.forms[0].ddlLocSource.options[document.forms[0].ddlLocSource.options.selectedIndex].text,1);
	var Shelf=document.forms[0].txtShelfSource.value;
	var strURL='WListCopyNumber.aspx?LibID='+LibID+'&LocID='+LocID+'&Shelf='+Shelf+'&LibName='+LibName+'&LocName='+LocName;
	OpenWindow(strURL,'ListCopyNumber',500,400,50,50);	
	return false;
}