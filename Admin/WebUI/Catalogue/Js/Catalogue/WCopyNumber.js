function FilterLocation(f) {
    var libraryid;
	libraryid=document.forms[0].ddlLibrary.options[document.forms[0].ddlLibrary.options.selectedIndex].value;
    eval("document.forms[0]." + f + ".options.length = 0;");
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
	//url='WGenCopyNumber.aspx?x=' + GenRanNum(20) + '&caller=parent.mainacq.document.forms[0].txtHolding&LocID=' + document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.selectedIndex].value + '&Shelf=' + document.forms[0].txtShelf.value;
	url = '../../Acquisition/ACQ/WGenCopyNumber.aspx?x=' + GenRanNum(20) + '&caller=parent.Workform.document.forms[0].txtHolding&LocID=' + document.forms[0].ddlLocation.options[document.forms[0].ddlLocation.options.selectedIndex].value + '&Shelf=' + document.forms[0].txtShelf.value;
	parent.Hiddenbase.location.href = url;
	return false;
}

function ChangeCode(){
	var code;
	code=document.forms[0].txtCode.value;
	self.location.href='WCopyNumber.aspx?Code=' + code;
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

function CheckedAllOpt(strDtgName, strOptionName, intMax, val) {
    var intCounter;
    for (intCounter = 3; intCounter <= intMax + 3; intCounter++) {
        if (intCounter > 9) {
            if (eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName)) {
               
                eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName).checked = val;
            }
        } else {
            if (eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName)) {
                
                eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName).checked = val;
            }
        }

    }
}


function OpenSearchItemID(){
	var url;
	url='WSearchItem.aspx?ControlName=txtCode';
	openModal(url,'SearchItemID',650,350,150,100,'yes','',0);
	return false;
}

function OpenSearchPO(){
	var url;
	url='WSearchItemByPO.aspx';
	openModal(url,'SearchPO',500,250,150,100,'yes','',0);
	return false;
}

function CheckNumberCopies(msg)
{
    if(!document.forms[0].txtNumberCopiesStart)
    {
        let valObj = document.forms[0].txtNumberCopiesStart.value;
        if (parseInt(valObj.substring(2, valObj.length))) {
            return true;
        }
        else {
            return false;
        }
    }
    return true;
}

function ActionUpdate(msg,msg1,msg2){
	var arrMsg;
	arrMsg=msg.split(';'); 
	if (CheckNull(document.forms[0].txtCode)){
		alert(msg);
		document.forms[0].txtCode.focus();
		return false;
	}
	if (CheckNull(document.forms[0].txtHolding)){
		alert(msg);
		document.forms[0].txtHolding.focus();
		return false;
	}
	if (!document.forms[0].ddlLoanType.options.length) {
		alert(msg);
		document.forms[0].ddlLoanType.focus();
		return false;
	}
	if (!document.forms[0].ddlACQSource.options.length) {
		alert(msg);
		document.forms[0].ddlACQSource.focus();
		return false;
	}
	if (CheckNull(document.forms[0].txtDateChng)){
		alert(msg);
		document.forms[0].txtDateChng.focus();
		return false;
    } 
    if (CheckNull(document.getElementById("txtQuantity").value)) {
        alert(msg);
        document.getElementById("txtQuantity").focus();
        return false;
    }
	return true;
}

function ShowCalendar(val){
	var url;
	if (val){
		val=val+3;
	}else{
		val=3;
	}
    var finalVar = '';
    if (val < 10) {
        finalVar = '0' + val;
    } else
        finalVar = val;
    url = '../../Common/WCalendar.aspx?id=opener.document.Form1.dtgHoldingInfo_ctl' + finalVar + '_txtAcquiredDate';
	openModal(url,'Calendar',165,220,200,250,'no','',0);
}

function ViewCanlendar(){
	var url;
	url='../../Common/WCalendar.aspx?id=opener.document.forms[0].txtDateChng';
	openModal(url,'Calendar',165,220,200,250,'no','',0);
}

function OpenLabel(){
	var url;
	url='WLabelPrintSearch.aspx?ItemCode='+ document.forms[0].txtCode.value;
	openModal(url,'LabelWin',700,450,50,50,'yes','',0);
	return false;
}

function OpenBarCode(){
	var url;
	url='WBarcodeForm.aspx?ItemCode=' + document.forms[0].txtCode.value;
	openModal(url,'BarcodeWin',700,450,50,50,'yes','',0);
	return false;
}