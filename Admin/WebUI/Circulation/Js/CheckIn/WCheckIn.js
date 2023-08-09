var curtab = 4;
TagArr = new Array(5);
TagArr[0] = "txtCheckInDate";
TagArr[1] = "txtCheckInTime";
TagArr[2] = "txtPatronCode";
TagArr[3] = "txtCopyNumber";
TagArr[4] = "btnCheckIn";

function microsoftKeyPress(event) 
{
    var prefix = '';
    if (event.keyCode == 13) {
        //console.log("form");
        return false;
    }
    //var prefix = '';	
	//if (window.event.keyCode == 27) {
	//}	
	//else {
	//	if (window.event.keyCode == 13)
	//			{	
	//			curtab = curtab + 1;
	//			if (curtab < TagArr.length) {	
	//				eval("document.forms[0]." + TagArr[curtab] + ".focus()");
	//				return false;
	//			}					
				
	//	}
	//}    	
	//return true;
}

/*
	ChangeTab function
*/
function ChangeTab(tag) 
{	
	for (i = 0; i < TagArr.length; i++) 
	{	
		if (TagArr[i] == tag){
			curtab = i;			
			break;
		}
		
	}
}

function CheckTime(f,msg) {	
	if (CheckNull(f)) {return true;}
	if (f.value.indexOf(":") <= 0) {
		alert(msg);
		f.value = ""
		f.blur();
		f.focus();
		return false;
	}
	hh = f.value.substring(0, f.value.indexOf(":"));
	mm = f.value.substring(f.value.indexOf(":") + 1, f.value.length);
	if (isNaN(hh) || parseFloat(hh) > 23 || isNaN(mm) || parseFloat(mm) > 59 || parseFloat(hh) < 0 || parseFloat(mm) < 0) {
		alert(msg);
		f.value = ""
		f.blur();
		f.focus();
	}
	alert(f.value);
}


/*
	SubmitForm function
	Purpose: submit current form
*/
function SubmitForm(strURL) {
	/*document.forms[0].target = 'CheckInMain'
	document.forms[0].action = strURL;
	document.forms[0].submit();*/
    parent.CheckInMain.location.href = 'WCheckInResult.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCheckInDate=' + document.forms[0].txtCheckInDate.value + '&txtCheckInTime=' + document.forms[0].txtCheckInTime.value + '&hidAutoPaidFees=' + document.forms[0].hidAutoPaidFees.value;
}


function OpenResForm() {
}

/*
	CheckIn function
	Purpose: checkin
*/
function CheckIn(strMsg1, strMsg2, strMsg3, strMsg4, fltNumber)
{
    var strCopyNumver = document.forms[0].txtCopyNumber.value;
	if (CheckNull(document.forms[0].txtPatronCode) & (document.forms[0].chkPatronCode.checked)) {
		alert(strMsg1);
		document.forms[0].txtPatronCode.focus();
	} else if (CheckNull(document.forms[0].txtCopyNumber))
	{
		alert(strMsg2);
		document.forms[0].txtCopyNumber.focus();
	}else if (!CheckDate(document.forms[0].txtCheckInDate, 'dd/mm/yyyy', strMsg3)) {
		document.forms[0].txtCheckInDate.value='';
		document.forms[0].txtCheckInDate.focus();
	}else if (!CheckTime(document.forms[0].txtCheckInTime, strMsg4)) {
		document.forms[0].txtCheckInTime.value='';
		document.forms[0].txtCheckInTime.focus();
	} else
	{
	    document.forms[0].txtCopyNumber.value = '';
		//SubmitForm('WCheckCopyNumberCI.aspx?x=' + fltNumber);
	    //SubmitForm('WCheckInResult.aspx');
	    parent.CheckInMain.location.href = 'WCheckInResult.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + strCopyNumver + '&txtCheckInDate=' + document.forms[0].txtCheckInDate.value + '&txtCheckInTime=' + document.forms[0].txtCheckInTime.value + '&hidAutoPaidFees=' + document.forms[0].hidAutoPaidFees.value;
	}
    return false;
}

/*
	chkCopyNumberEvent function
	Purpose: write event for change CopyNumber
*/
function chkCopyNumberEvent() {
	if (document.forms[0].chkPatronCode.checked & CheckNull(document.forms[0].txtPatronCode)) {
		document.forms[0].txtPatronCode.focus();
	} else {
		document.forms[0].txtCopyNumber.focus();
	}
}

/*
	chkPatronCodeEvent function
	Purpose: write event for change PatronCode
*/
function chkPatronCodeEvent() {
	if (document.forms[0].chkPatronCode.checked) {
		document.forms[0].txtPatronCode.focus();
	} else {
		document.forms[0].txtCopyNumber.focus();
	}
}

/*
	chkAutoPaidEvent function
	Purpose: write event for change AutoPaidFees
*/

function chkAutoPaidEvent() {
	if (document.forms[0].chkAutoPaidFees.checked) {
		document.forms[0].hidAutoPaidFees.value=1;
	} else {
		document.forms[0].hidAutoPaidFees.value=0;
	}
}


/*
	txtPatronCodeEvent function
	Purpose: write event for change txtPatronCode
*/
function txtPatronCodeEvent(strMsg3, fltNumber) {
	if (CheckNull(document.forms[0].txtPatronCode)) {
		alert(strMsg3);
		document.forms[0].txtPatronCode.blur;
		document.forms[0].txtPatronCode.focus();
	} else {
		//SubmitForm('WCheckPatronCodeCI.aspx?x=' + fltNumber);
		SubmitForm('WCheckInResult.aspx');
	}
}

/*
	txtPatronCodeEvent function
	Purpose: write keypress event for txtPatronCode
*/
function txtPatronCodeEventkeypress(strMsg3, fltNumber, event) {
   
    if (event.keyCode == 13 || event.keyCode == 27) {
        if (CheckNull(document.forms[0].txtPatronCode)) {
            alert(strMsg3);
            document.forms[0].txtPatronCode.blur();
            document.forms[0].txtPatronCode.focus();
        } else {
            //SubmitForm('WCheckPatronCodeCI.aspx?x=' + fltNumber);
            SubmitForm('WCheckInResult.aspx');
        }
    }

}


/*
	txtCopyNumberEvent function
	Purpose: write event for change txtCopyNumber
*/
function txtCopyNumberEvent(strMsg4, fltNumber) {
    if (event.keyCode == 13 || event.keyCode == 27) {
        if (CheckNull(document.forms[0].txtCopyNumber)) {
            alert(strMsg4);
            document.forms[0].txtCopyNumber.blur;
            document.forms[0].txtCopyNumber.focus();
        } else {
            var strCopyNumver = document.forms[0].txtCopyNumber.value;
            document.forms[0].txtCopyNumber.value = '';
            //SubmitForm('WCheckCopyNumberCI.aspx?x=' + fltNumber);
            //SubmitForm('WCheckInResult.aspx');
            parent.CheckInMain.location.href = 'WCheckInResult.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + strCopyNumver + '&txtCheckInDate=' + document.forms[0].txtCheckInDate.value + '&txtCheckInTime=' + document.forms[0].txtCheckInTime.value + '&hidAutoPaidFees=' + document.forms[0].hidAutoPaidFees.value;
            //document.forms[0].btnCheckIn.click();
            //SubmitForm('WCheckPatronCodeCI.aspx?x=' + fltNumber);
        }
    }

	
}
