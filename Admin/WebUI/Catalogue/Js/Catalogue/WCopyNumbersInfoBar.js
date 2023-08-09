function OnLoad() {
    parent.document.getElementById('frmMain').setAttribute('rows', '*,28');
}

function Next(strMsg1, strMsg2, strMsg3, intReCount, strMsg4) {
    var intItemID;
    var intTopNumber;
    var arrIDs;
    if (eval(document.forms[0].txtReNum).value != "") {
        if (document.forms[0].hidIDs.value == "") {
            if (parseFloat(document.forms[0].txtReNum.value) == parseFloat(document.forms[0].txtMaxReNum.value)) {
                alert(strMsg1);
                return false;
            }

            if (parseFloat(document.forms[0].txtReNum.value) < 1) {
                alert(strMsg2);
                document.forms[0].txtReNum.value = 1
                intTopNumber = 1
                OpenFormSequency(intTopNumber);
                return false;
            }

            if (parseFloat(document.forms[0].txtReNum.value) > parseFloat(document.forms[0].txtMaxReNum.value)) {
                alert(strMsg3);
                intTopNumber = parseFloat(document.forms[0].txtMaxReNum.value)
                document.forms[0].txtReNum.value = intTopNumber
                OpenFormSequency(intTopNumber);
                return false;
            }

            document.forms[0].txtReNum.value = parseFloat(document.forms[0].txtReNum.value) + 1;
            intTopNumber = parseFloat(document.forms[0].txtReNum.value)
            OpenFormSequency(intTopNumber);

        } else {
            if (parseFloat(document.forms[0].txtReNum.value) == intReCount) {
                alert(strMsg1);
                return false;
            }

            if (parseFloat(document.forms[0].txtReNum.value) < 1) {
                alert(strMsg2);
                document.forms[0].txtReNum.value = 1
                arrIDs = document.forms[0].hidIDs.value.split(",");
                intItemID = arrIDs[parseFloat(document.forms[0].txtReNum.value) - 1]
                OpenForm(intItemID);
                return false;
            }

            if (parseFloat(document.forms[0].txtReNum.value) > intReCount) {
                alert(strMsg3);
                document.forms[0].txtReNum.value = intReCount;
                arrIDs = document.forms[0].hidIDs.value.split(",");
                intItemID = arrIDs[intReCount - 1]
                OpenForm(intItemID);
                return false;
            }

            arrIDs = document.forms[0].hidIDs.value.split(",");
            intItemID = arrIDs[parseFloat(document.forms[0].txtReNum.value)]
            document.forms[0].txtReNum.value = parseFloat(document.forms[0].txtReNum.value) + 1;
            OpenForm(intItemID);
        }
    }
    else {
        alert(strMsg4)
    }
}

// Prev function - Move to the previous record
function Prev(strMsg1, strMsg2, strMsg3, intReCount, strMsg4) {
    var intItemID;
    var intTopNumber;
    var arrIDs;

    if (eval(document.forms[0].txtReNum).value != "") {
        if (document.forms[0].hidIDs.value == "") {
            if (parseFloat(document.forms[0].txtReNum.value) == 1) {
                alert(strMsg1);
                return false;
            }

            if (parseFloat(document.forms[0].txtReNum.value) < 1) {
                alert(strMsg2);
                document.forms[0].txtReNum.value = 1
                intTopNumber = 1
                OpenFormSequency(intTopNumber);
                return false;
            }

            if (parseFloat(document.forms[0].txtReNum.value) > parseFloat(document.forms[0].txtMaxReNum.value)) {
                alert(strMsg3);
                intTopNumber = parseFloat(document.forms[0].txtMaxReNum.value)
                document.forms[0].txtReNum.value = intTopNumber
                OpenFormSequency(intTopNumber);
                return false;
            }

            document.forms[0].txtReNum.value = parseFloat(document.forms[0].txtReNum.value) - 1;
            intTopNumber = parseFloat(document.forms[0].txtReNum.value)
            OpenFormSequency(intTopNumber);
        }
        else {
            if (parseFloat(document.forms[0].txtReNum.value) == 1) {
                alert(strMsg1);
                return false;
            }
            if (parseFloat(document.forms[0].txtReNum.value) < 1) {
                alert(strMsg2);
                document.forms[0].txtReNum.value = 1
                arrIDs = document.forms[0].hidIDs.value.split(",");
                intItemID = arrIDs[parseFloat(document.forms[0].txtReNum.value) - 1]
                OpenForm(intItemID);
                return false;
            }
            if (parseFloat(document.forms[0].txtReNum.value) > intReCount) {
                alert(strMsg3);
                document.forms[0].txtReNum.value = intReCount;
                arrIDs = document.forms[0].hidIDs.value.split(",");
                intItemID = arrIDs[intReCount - 1]
                OpenForm(intItemID);
                return false;
            }

            arrIDs = document.forms[0].hidIDs.value.split(",");
            intItemID = arrIDs[parseFloat(document.forms[0].txtReNum.value) - 2]
            document.forms[0].txtReNum.value = parseFloat(document.forms[0].txtReNum.value) - 1;
            OpenForm(intItemID);
        }
    }
    else {
        alert(strMsg4)
    }
}

// Bind data for the first time form loaded
function StartBindData(index) {
    parent.Workform.location.href = "WCopyNumbersInfo.aspx?action=View&index=" + index;
}

// Go to the last record
function End(intReCount, intMaxNum) {
    if (intReCount == parseInt(document.forms[0].txtReNum.value))
        return false;
    document.forms[0].txtReNum.value = intReCount;
    document.forms[0].ItemID.value = intMaxNum;

    if (document.forms[0].hidIDs.value == "") {
        OpenFormSequency(intMaxNum);
    }
    else {
        var arrIDs;
        arrIDs = document.forms[0].hidIDs.value.split(",");
        intItemID = arrIDs[intMaxNum - 1];
        OpenForm(intItemID)
    }
}

// Go to the first record
function Home(intMinNum) {
    if (1 == parseInt(document.forms[0].txtReNum.value))
        return false;
    document.forms[0].txtReNum.value = 1;
    document.forms[0].ItemID.value = intMinNum;
    if (document.forms[0].hidIDs.value == "") {
        OpenFormSequency(intMinNum);
    }
    else {
        var arrIDs;
        arrIDs = document.forms[0].hidIDs.value.split(",");
        intItemID = arrIDs[intMinNum];
        OpenForm(intItemID)
    }

}

// ChangRecNum method - Change the record number
function ChangeRecNum(strMsg1, strMsg2, strMsg3, intReCount, strMsg4) {
    var intItemID;
    var intTopNumber;
    var arrIDs;

    if (eval(document.forms[0].txtReNum).value != "") {
        if (document.forms[0].hidIDs.value == "") {

            if (parseFloat(document.forms[0].txtReNum.value) < 1) {
                alert(strMsg2);
                document.forms[0].txtReNum.value = 1
                intTopNumber = 1
                OpenFormSequency(intTopNumber);
                return;
            }

            if (parseFloat(document.forms[0].txtReNum.value) > parseFloat(document.forms[0].txtMaxReNum.value)) {
                alert(strMsg3);
                intTopNumber = parseFloat(document.forms[0].txtMaxReNum.value)
                document.forms[0].txtReNum.value = intTopNumber
                OpenFormSequency(intTopNumber);
                return;
            }

            intTopNumber = parseFloat(document.forms[0].txtReNum.value)
            OpenFormSequency(intTopNumber);

        } else {

            if (parseFloat(document.forms[0].txtReNum.value) < 1) {
                alert(strMsg2);
                document.forms[0].txtReNum.value = 1
                arrIDs = document.forms[0].hidIDs.value.split(",");
                intItemID = arrIDs[parseFloat(document.forms[0].txtReNum.value) - 1]
                OpenForm(intItemID);
                return;
            }

            if (parseFloat(document.forms[0].txtReNum.value) > intReCount) {
                alert(strMsg3);
                document.forms[0].txtReNum.value = intReCount;
                arrIDs = document.forms[0].hidIDs.value.split(",");
                intItemID = arrIDs[intReCount - 1]
                OpenForm(intItemID);
                return;
            }

            arrIDs = document.forms[0].hidIDs.value.split(",");
            intItemID = arrIDs[parseFloat(document.forms[0].txtReNum.value) - 1]
            OpenForm(intItemID);
        }
    }
    else {
        alert(strMsg4)
    }
}

// OpenForm method (By ID)
function OpenForm(index) {
    document.forms[0].ItemID.value = index;
    parent.Workform.location.href = "WCopyNumbersInfo.aspx?action=View&index=" + index;
}	

// CheckNumber method
function CheckNumber(obj, msg) {
    var tempNum;
    tempNum = trim(eval(obj).value);
    if (tempNum == "") {
        alert(msg);
        eval(obj).focus();
        eval(obj).select();
        return false;
    }
    if (isNaN(tempNum)) {
        alert(msg);
        eval(obj).focus();
        eval(obj).select();
        return false;
    }
    return true;
}

// OpenFormSequency method (By TopNum)
function OpenFormSequency(index) {
    parent.Workform.location.href = "WCopyNumbersInfo.aspx?action=View&index=" + index;
}