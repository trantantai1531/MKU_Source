var curtab = 6;
TagArr = new Array(7);
TagArr[0] = "txtCreatedDate";
TagArr[1] = "txtCreatedTime";
TagArr[2] = "txtDueDate";
TagArr[3] = "txtDueTime";
TagArr[4] = "txtPatronCode";
TagArr[5] = "txtCopyNumber";
TagArr[6] = "btnCheckOut";

function microsoftKeyPress(event) 
	{	
    var prefix = '';	
    if (event.keyCode == 13) {
        //console.log("form");
	    return false;
	}	
	//else {
	//	//if (event.keyCode == 13)
	//	//		{	
	//	//		curtab = curtab + 1;
	//	//		if (curtab < TagArr.length) {	
	//	//			eval("document.forms[0]." + TagArr[curtab] + ".focus()");
	//	//			return false;
	//	//		}					
				
	//	//}
	//}    	
	
}

function ChangeTab(tag) 
{	
	//for (i = 0; i < TagArr.length; i++) 
	//{	
	//	if (TagArr[i] == tag){
	//		curtab = i;			
	//		break;
	//	}
		
	//}
}

function CheckTime(f,msg) {
	if (CheckNull(f)) {return true;}
	if (f.value.indexOf(":") <= 0) {
		alert(msg);
	    f.value = "";
		f.blur();
		f.focus();
		return false;
	}
	hh = f.value.substring(0, f.value.indexOf(":"));
	f1 = f.value.substring(f.value.indexOf(":") + 1, f.value.length);
	mm = f1.substring(0, f1.indexOf(":"));
	ss = f1.substring(f1.indexOf(":") + 1, f1.length);
	if (isNaN(hh) || parseFloat(hh) > 23 || isNaN(mm) || parseFloat(mm) > 59 || isNaN(ss) || parseFloat(ss) > 59 || parseFloat(hh) < 0 || parseFloat(mm) < 0 || parseFloat(ss) < 0) {
		alert(msg);
		f.value = ""
		f.blur();
		f.focus();
		return false;
	}
	else {
		return true;
	}
}

/*
function CheckDate(f,msg) {
	iday = f.value.substring(0, f.value.indexOf("/"));
	imon = f.value.substring(f.value.indexOf("/") + 1, f.value.lastIndexOf("/"));
	iyear = f.value.substring(f.value.lastIndexOf("/") + 1, f.value.length);
	mDate = new Date(imon + "/" + iday + "/" + iyear);
	if (mDate.getDate() != iday || mDate.getMonth() != imon - 1) {
		alert(msg);
		f.value = ""
		f.blur();
		f.focus();
		return false;
	}
	return;
}
*/

/*
	chkExemptQuotaEvent function
*/
function chkExemptQuotaEvent() {
	if(document.forms[0].chkExemptQuota.checked) {
		document.forms[0].hidLoanMode.value=3;
		document.forms[0].hidContinue.value=1;
	} else {
		document.forms[0].hidLoanMode.value=1;
	}
	document.forms[0].txtPatronCode.focus();
}

function chkIndefiniteDueEvent() {
	if (document.forms[0].chkIndefiniteDue.checked)
		document.forms[0].hidOpen.value=1;
	else
		document.forms[0].hidOpen.value=0;
	//document.forms[0].hidOpen.value=1;
}
/*
	CheckOut function
	Purpose: check out now
*/
function CheckOut(strMsg1, strMsg2, strMsg3, strMsg4, strMsg5, strMsg6, fltNumber) {
   // txtPatronCodeEvent(strMsg3, fltNumber);
	if (!CheckDate(document.forms[0].txtCreatedDate, 'dd/mm/yyyy', strMsg1)) {
		alert(strMsg1);
		document.forms[0].txtCreatedDate.value='';
		document.forms[0].txtCreatedDate.focus();
		return;
	} else if (!CheckDate(document.forms[0].txtDueDate, 'dd/mm/yyyy', strMsg1)) {
		alert(strMsg1);
		document.forms[0].txtDueDate.value='';
		document.forms[0].txtDueDate.focus();
		return;
	}
	 else if(CompareDate(document.forms[0].txtCreatedDate,document.forms[0].txtDueDate,'dd/mm/yyyy') == 0){
		alert(strMsg6);
		document.forms[0].txtDueDate.value='';
		document.forms[0].txtDueDate.focus();
		return;
	 }
	 else if (!CheckTime(document.forms[0].txtCreatedTime, strMsg2)) {
		document.forms[0].txtCreatedTime.value='';
		document.forms[0].txtCreatedTime.focus();
		return;
	} else if (!CheckTime(document.forms[0].txtDueTime, strMsg2)) {
		document.forms[0].txtDueTime.value='';
		document.forms[0].txtDueTime.focus();
		return;
	}else if(CheckNull(document.forms[0].txtPatronCode)) {
		alert(strMsg3);
		document.forms[0].txtPatronCode.focus();
		return;
	} else if (CheckNull(document.forms[0].txtCopyNumber)) {
		alert(strMsg4);
		document.forms[0].txtCopyNumber.focus();
		return;
    }
	console.log(document.forms[0]);
	if(document.forms[0].hidContinue.value==1) {
		//document.forms[0].btnCheckOut.disabled=true;
		/*document.forms[0].target='CheckOutMain';
		document.forms[0].action='WCheckOutResult.aspx';
		document.forms[0].submit();*/

	    let strCopyNumber = document.forms[0].txtCopyNumber.value;
	    let strLoanMode = document.forms[0].hidLoanMode.value;
	    let strDueDate = document.forms[0].txtDueDate.value;
	    let strCreatedDate = document.forms[0].txtCreatedDate.value;
	    let strDueTime = document.forms[0].txtDueTime.value;
	    if (strCopyNumber.substring(0, 2) === "TD")
	    {
	        strLoanMode = 2;
	        strDueDate = strCreatedDate;
	        strDueTime = "22:00:00";
	    }
	    else
	    {
	        if (strCopyNumber.substring(0, 2) === "TÐ")
	        {
	            strLoanMode = 2;
	            strDueDate = strCreatedDate;
	            strDueTime = "22:00:00";
	        }
	        else
	        {
	            if (strCopyNumber.substring(0, 1) === "D") {
	                strLoanMode = 2;
	                strDueDate = strCreatedDate;
	                strDueTime = "22:00:00";
	            }
	            else {
	                if ((strCopyNumber.substring(0, 1) === "A") || (strCopyNumber.substring(0, 1) === "B")) {
	                    strLoanMode = 1;
	                }
	            }
	        }
	    }
       
	    var radLoanType = document.getElementsByName("radLoanType");
        if (radLoanType == null)            
        {
            if (strLoanMode == 1) {
                if (document.getElementById("chkDeposit").checked) {
                    parent.CheckOutMain.location.href = 'WCheckOutAddDeposit.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + strDueDate + '&txtDueTime=' + strDueTime + '&hidLoanMode=' + strLoanMode;

                } else {
                    parent.CheckOutMain.location.href = 'WCheckOutResult.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + strDueDate + '&txtDueTime=' + strDueTime + '&hidLoanMode=' + strLoanMode;
                }
            }else if (strLoanMode == 2) {
                parent.CheckOutMain.location.href = 'WCheckOutResult.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + strDueDate + '&txtDueTime=' + strDueTime + '&hidLoanMode=' + strLoanMode;

            }

        }
	    else
	    {
	        var valueRadLoanType = 0;
	        for (var i = 0, len = radLoanType.length; i < len; i++) {
	            if (radLoanType[i].checked) {
	                valueRadLoanType = radLoanType[i].value;
	                break;
	            }
            }
	        if (strLoanMode == 1) {
                if (document.getElementById("chkDeposit").checked) {
                    parent.CheckOutMain.location.href = 'WCheckOutAddDeposit.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + strDueDate + '&txtDueTime=' + strDueTime + '&hidLoanMode=' + strLoanMode + "&radLoanType=" + valueRadLoanType;

                } else {
                    parent.CheckOutMain.location.href = 'WCheckOutResult.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + strDueDate + '&txtDueTime=' + strDueTime + '&hidLoanMode=' + strLoanMode + "&radLoanType=" + valueRadLoanType;
                }
            }else if (strLoanMode == 2) {
                parent.CheckOutMain.location.href = 'WCheckOutResult.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + strDueDate + '&txtDueTime=' + strDueTime + '&hidLoanMode=' + strLoanMode + "&radLoanType=" + valueRadLoanType;

            }

        }

	    
	} else {
		//alert(strMsg4);
		document.forms[0].txtCopyNumber.value='';		
		//document.forms[0].txtCopyNumber.focus();
	}
}


function OnSuccess(response) {
    //parent.CheckOut.document.forms[0].hidenDeposit.value = response.d;
    $("#hidenDeposit").val(response.d);
}
/*
	txtPatronCodeEvent function
	Purpose: write onchange event for txtPatronCode
*/
function txtPatronCodeEvent(strMsg3, fltNumber) {
	if (CheckNull(document.forms[0].txtPatronCode)) {
		alert(strMsg3);
		document.forms[0].txtPatronCode.blur;
		document.forms[0].txtPatronCode.focus();
		return;
	}
	if (!document.forms[0].chkExemptQuota.checked) {
		document.forms[0].hidContinue.value=1;
		document.forms[0].hidLoanMode.value=1;
	}
    
	parent.CheckOutMain.location.href='../WCheckPatronCode.aspx?x=' + fltNumber + '&PatronCode=' + document.forms[0].txtPatronCode.value + '&LoanMode=' + document.forms[0].hidLoanMode.value;
}
/*
	txtPatronCodeEvent function
	Purpose: write keypress event for txtPatronCode
*/
function txtPatronCodeEventkeypress(strMsg3, fltNumber,event) {
    var evt = (event == null) ? window.event : event;

    if (event.keyCode == 13 || event.keyCode == 27) {
        if (CheckNull(document.forms[0].txtPatronCode)) {
          
            alert(strMsg3);
            document.forms[0].txtPatronCode.blur();
            document.forms[0].txtPatronCode.focus();
            return;
        }
        console.log('../WCheckPatronCode.aspx?x=' + fltNumber + '&PatronCode=' + document.forms[0].txtPatronCode.value + '&LoanMode=2');
        parent.CheckOutMain.location.href = '../WCheckPatronCode.aspx?x=' + fltNumber + '&PatronCode=' + document.forms[0].txtPatronCode.value + '&LoanMode=2';
      
        return false;
    }
    
}

/*
	txtPatronCodeInLibEvent function
	Purpose: write onchange event for txtPatronCode
*/
function txtPatronCodeInLibEvent(strMsg3, fltNumber, event) {
    console.log("txtPatronCodeInLibEvent");
    if (CheckNull(document.forms[0].txtPatronCode)) {
        console.log("txtPatronCodeInLibEvent");
		alert(strMsg3);
		document.forms[0].txtPatronCode.blur();
		document.forms[0].txtPatronCode.focus();
		return;
	}
	parent.CheckOutMain.location.href = '../WCheckPatronCode.aspx?x=' + fltNumber + '&PatronCode=' + document.forms[0].txtPatronCode.value + '&LoanMode=2';
    return false;
}

/*
	txtCopyNumberEvent function
	Purpose: write onchange event for txtCopyNumber
*/
function txtCopyNumberEvent(strMsg3, strMsg4, strMsg5, strMsg6, fltNumber) {
    var evt = (event == null) ? window.event : event;

    if (event.keyCode == 13 || event.keyCode == 27) {
        if (CheckNull(document.forms[0].txtPatronCode)) {
            alert(strMsg3);
            document.forms[0].txtPatronCode.focus();
            return;
        }
        if (CheckNull(document.forms[0].txtCopyNumber)) {
            alert(strMsg4);
            document.forms[0].txtCopyNumber.blur();
            document.forms[0].txtCopyNumber.focus();
            return;
        }

        if (document.forms[0].hidContinue.value == 1) {
            //document.forms[0].btnCheckOut.disabled=true;
            /*document.forms[0].target='CheckOutMain';
            document.forms[0].action='WCheckOutResult.aspx';
            document.forms[0].submit();*/

            console.log(1);
            //parent.CheckOutMain.location.href = 'WCheckOutResult.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + document.forms[0].txtDueDate.value + '&txtDueTime=' + document.forms[0].txtDueTime.value + '&hidLoanMode=' + document.forms[0].hidLoanMode.value;

            let strCopyNumber = document.forms[0].txtCopyNumber.value;
            let strLoanMode = document.forms[0].hidLoanMode.value;
            let strDueDate = document.forms[0].txtDueDate.value;
            let strCreatedDate = document.forms[0].txtCreatedDate.value;
            let strDueTime = document.forms[0].txtDueTime.value;
            if (strCopyNumber.substring(0, 2) === "TD") {
                strLoanMode = 2;
                strDueDate = strCreatedDate;
                strDueTime = "22:00:00";
            }
            else {
                if (strCopyNumber.substring(0, 2) === "TÐ") {
                    strLoanMode = 2;
                    strDueDate = strCreatedDate;
                    strDueTime = "22:00:00";
                }
                else {
                    if (strCopyNumber.substring(0, 1) === "D") {
                        strLoanMode = 2;
                        strDueDate = strCreatedDate;
                        strDueTime = "22:00:00";
                    }
                    else {
                        if ((strCopyNumber.substring(0, 1) === "A") || (strCopyNumber.substring(0, 1) === "B")) {
                            strLoanMode = 1;
                        }
                    }
                }
            }

            var radLoanType = document.getElementsByName("radLoanType");
            if (radLoanType == null) {
                if (strLoanMode == 1) { //muon ve nha
                    if (document.getElementById("chkDeposit").checked) {
                        parent.CheckOutMain.location.href = 'WCheckOutAddDeposit.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + strDueDate + '&txtDueTime=' + strDueTime + '&hidLoanMode=' + strLoanMode;

                    } else {
                        parent.CheckOutMain.location.href = 'WCheckOutResult.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + strDueDate + '&txtDueTime=' + strDueTime + '&hidLoanMode=' + strLoanMode;

                    }
                }else if (strLoanMode == 2) { // muon tai cho
                    parent.CheckOutMain.location.href = 'WCheckOutResult.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + strDueDate + '&txtDueTime=' + strDueTime + '&hidLoanMode=' + strLoanMode;
                }
                
                //parent.CheckOutMain.location.href = 'WCheckOutResult.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + strDueDate + '&txtDueTime=' + strDueTime + '&hidLoanMode=' + strLoanMode;
            }
            else {
                var valueRadLoanType = 0;
                for (var i = 0, len = radLoanType.length; i < len; i++) {
                    if (radLoanType[i].checked) {
                        valueRadLoanType = radLoanType[i].value;
                        break;
                    }
                }

                if (strLoanMode == 1) {
                    if (document.getElementById("chkDeposit").checked) {
                        parent.CheckOutMain.location.href = 'WCheckOutAddDeposit.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + strDueDate + '&txtDueTime=' + strDueTime + '&hidLoanMode=' + strLoanMode + "&radLoanType=" + valueRadLoanType;

                    } else {
                        parent.CheckOutMain.location.href = 'WCheckOutResult.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + strDueDate + '&txtDueTime=' + strDueTime + '&hidLoanMode=' + strLoanMode + "&radLoanType=" + valueRadLoanType;

                    }
                }else if (strLoanMode == 2) {
                    parent.CheckOutMain.location.href = 'WCheckOutResult.aspx?txtPatronCode=' + document.forms[0].txtPatronCode.value + '&txtCopyNumber=' + document.forms[0].txtCopyNumber.value + '&txtCreatedDate=' + document.forms[0].txtCreatedDate.value + '&txtCreatedTime=' + document.forms[0].txtCreatedTime.value + '&hidOpen=' + document.forms[0].hidOpen.value + '&txtDueDate=' + strDueDate + '&txtDueTime=' + strDueTime + '&hidLoanMode=' + strLoanMode + "&radLoanType=" + valueRadLoanType;

                }

            }

        }
        else {
            if (document.forms[0].hidError.value == 1) {
                alert(strMsg6);
                console.log(2);
            }
            else {
                if (confirm(strMsg5)) {
                    document.forms[0].hidLoanMode.value = 3;
                    document.forms[0].hidContinue.value = 1;
                    //document.forms[0].btnCheckOut.click();
                    console.log(3);
                }
                else {
                    document.forms[0].txtCopyNumber.value = '';
                    //document.forms[0].btnCheckOut.disabled = true;
                    console.log(4);
                }
            }

        }
    }

	
}
