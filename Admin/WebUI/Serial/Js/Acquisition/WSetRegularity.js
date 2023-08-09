function AllDays(blnStatus) {
    document.forms[0].chkSunday.checked = blnStatus;
    document.forms[0].chkMonday.checked = blnStatus;
    document.forms[0].chkTuesday.checked = blnStatus;
    document.forms[0].chkWednesday.checked = blnStatus;
    document.forms[0].chkThursday.checked = blnStatus;
    document.forms[0].chkFriday.checked = blnStatus;
    document.forms[0].chkSaturday.checked = blnStatus;
}

function AllWeeks(blnStatus) {
    document.forms[0].chkFirstWeek.checked = blnStatus;
    document.forms[0].chkSecondWeek.checked = blnStatus;
    document.forms[0].chkThirdWeek.checked = blnStatus;
    document.forms[0].chkFourthWeek.checked = blnStatus;
    document.forms[0].chkLastWeek.checked = blnStatus;
}

function AllMonths(blnStatus) {
    document.forms[0].chkJanuary.checked = blnStatus;
    document.forms[0].chkFebruary.checked = blnStatus;
    document.forms[0].chkMarch.checked = blnStatus;
    document.forms[0].chkApril.checked = blnStatus;
    document.forms[0].chkMay.checked = blnStatus;
    document.forms[0].chkJune.checked = blnStatus;
    document.forms[0].chkJuly.checked = blnStatus;
    document.forms[0].chkAugust.checked = blnStatus;
    document.forms[0].chkSeptember.checked = blnStatus;
    document.forms[0].chkOctober.checked = blnStatus;
    document.forms[0].chkNovember.checked = blnStatus;
    document.forms[0].chkDecember.checked = blnStatus;
}

function CheckAllInPut(msg1, msg2) {

    if (eval(document.forms[0].rdoRegularity3).checked && !eval(document.forms[0].chkSunday).checked &&
	 !eval(document.forms[0].chkMonday).checked && !eval(document.forms[0].chkTuesday).checked &&
	 !eval(document.forms[0].chkWednesday).checked && !eval(document.forms[0].chkThursday).checked &&
	 !eval(document.forms[0].chkFriday).checked && !eval(document.forms[0].chkSaturday).checked) {
        alert(msg1);
        return false;
    }
    else if (eval(document.forms[0].rdoRegularity4).checked && !eval(document.forms[0].chkJanuary).checked &&
	!eval(document.forms[0].chkFebruary).checked && !eval(document.forms[0].chkMarch).checked &&
	!eval(document.forms[0].chkApril).checked && !eval(document.forms[0].chkMay).checked &&
	!eval(document.forms[0].chkJune).checked && !eval(document.forms[0].chkJuly).checked &&
	!eval(document.forms[0].chkAugust).checked && !eval(document.forms[0].chkSeptember).checked &&
	!eval(document.forms[0].chkOctober).checked && !eval(document.forms[0].chkNovember).checked &&
	!eval(document.forms[0].chkDecember).checked) {
        alert(msg2);
        return false;
    }
    else return;
}
function rdoRegularity1Click(blnStatus) {
    disabledDiv("weekList", true);
    disabledDiv("monthList", true);
    AllWeeks(false);
    AllMonths(false);
    AllDays(false);
    document.forms[0].cbxAllWeek.checked = false;
    document.forms[0].cbxAllMonth.checked = false;
    document.forms[0].cbxAllDay.checked = false;
}
function rdoRegularity2Click(blnStatus) {
    disabledDiv("weekList", true);
    disabledDiv("monthList", true);
    AllWeeks(false);
    AllMonths(false);
    AllDays(false);
    document.forms[0].cbxAllWeek.checked = false;
    document.forms[0].cbxAllMonth.checked = false;
    document.forms[0].cbxAllDay.checked = false;
}
function rdoRegularity3Click(blnStatus) {
    disabledDiv("weekList", false);
    disabledDiv("monthList", true);
   
    AllMonths(false);
    AllWeeks(false);
    document.forms[0].cbxAllWeek.checked = false;
    document.forms[0].cbxAllMonth.checked = false;
  
}
function rdoRegularity4Click(blnStatus) {
    disabledDiv("weekList", true);
    disabledDiv("monthList", false);
    AllDays(false);
    document.forms[0].cbxAllDay.checked = false;
}

function disabledDiv(divId, blnStatus) {
    var nodes = document.getElementById(divId).getElementsByTagName('*');
    for (var i = 0; i < nodes.length; i++) {
        nodes[i].disabled = blnStatus;
    }
}