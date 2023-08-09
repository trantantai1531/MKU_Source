function FilterLocation(f) {
	var libraryid;
	libraryid=document.forms[0].ddlLibrary.options[document.forms[0].ddlLibrary.options.selectedIndex].value;
	eval ("document.forms[0]." + f + ".options.length = 0;");
	for (j = 0; j < LibID.length; j++) {
		if (LibID[j] == libraryid) {
			eval("document.forms[0]." + f + ".options.length = document.forms[0]." + f + ".options.length + 1;");
			eval("document.forms[0]." + f + ".options[document.forms[0]." + f + ".options.length - 1].value = LocID[j];");
			eval("document.forms[0]." + f + ".options[document.forms[0]." + f + ".options.length - 1].text = Location[j];");
		}
	}
}

function SetHidVal(){
	document.forms[0].txtLocID.value=document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.selectedIndex].value;
}

function GenHolding(){
	var url;
	url='WGenCopyNumber.aspx?x=' + GenRanNum(20) + '&caller=parent.main.document.forms[0].txtHolding&LocID=' + document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.selectedIndex].value;
	parent.hiddenbase.location.href = url;
	return false;
}

function ChangeCode(){
	var code;
	code=document.forms[0].txtCode.value;
	self.location.href='WUpdate.aspx?Code=' + code;
}

//function CheckedAll(val){
	//var len;
	//var i;
	
	//len=document.forms[0].chkCopyID.length;
	//for(i=0;i<=10;i++){
	//	if (eval('document.forms[0].dtgHoldingInfo__ctl' + 3 + i + '_chkCopyID')){
	//		eval('document.forms[0].dtgHoldingInfo__ctl' + 3 + i + '_chkCopyID').checked=val;
//		}
//	}
//}

function CheckedAllOpt(strDtgName, strOptionName, intMax,val){
	var intCounter;
    for(intCounter = 3; intCounter <= intMax + 3  ; intCounter++) {
		if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName)){
			eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked =val;
		}
    }
}


function OpenSearchItemID(){
	var url;
	url='WSearchItemID.aspx';
	openModal(url,'SearchItemID',500,350,150,100,'yes','',0);
}

function OpenSearchPO(){
	var url;
	url='WSearchCodeByPO.aspx';
	openModal(url,'SearchPO',500,250,150,100,'yes','',0);
}

function ActionUpdate(msg){
	var arrMsg;
	arrMsg=msg.split(';'); 
	if (CheckNull(document.forms[0].txtCode)){
		alert(arrMsg[0]);
		document.forms[0].txtCode.focus();
		return false;
	}else{
		if (CheckNull(document.forms[0].txtHolding)){
			alert(arrMsg[1]);
			document.forms[0].txtHolding.focus();
			return false;			
		}else{
			return true;
		}
	}
}

function ShowCalendar(val){
	var url;
	if (val){
		val=val+3;
	}else{
		val=3;
	}
	url='../../Patron/WCalendar.aspx?id=opener.document.Form1.dtgHoldingInfo__ctl' + val + '_txtAcquiredDate';
	openModal(url,'Calendar',165,220,200,250,'no','',0);
}

function ViewCanlendar(){
	var url;
	url='../../Patron/WCalendar.aspx?id=opener.document.Form1.txtDateChng';
	openModal(url,'Calendar',165,220,200,250,'no','',0);
}

function OpenLabel(){
	var url;
	url='WAcqPrintLabel.aspx?Code='+ document.forms[0].txtCode.value;
	openModal(url,'LabelWin',700,450,50,50,'yes','',0);
	return false;
}

function OpenBarCode(){
	var url;
	url='WAcqBarcode.aspx?Code=' + document.forms[0].txtCode.value;
	openModal(url,'BarcodeWin',700,450,50,50,'yes','',0);
	return false;
}