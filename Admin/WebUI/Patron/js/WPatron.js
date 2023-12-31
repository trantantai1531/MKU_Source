// Creator: Kiemdv
// Date 11/9/2003

// Check all data input from Form Patron

function CheckAll(strMsg1, strMsg2, strMsg3, strMsg4, strDateFormat, strMsgDate1, strMsgDate2) {
    var e = document.forms[0].ddlPatronGroup;
    var strUser = e.options[e.selectedIndex].value;
    if (strUser == 0) {
        alert("Vui lòng chọn nhóm bạn đọc");
        return false;
    }
    if (CheckNull(document.forms[0].txtFirstName)) {
        alert("Vui lòng nhập Họ và tên lót");
        document.forms[0].txtFirstName.focus();
        return false;
    }
    if (CheckNull(document.forms[0].txtLastName)) {
        alert("Vui lòng nhập Tên");
        document.forms[0].txtLastName.focus();
        return false;
    }
    if (CheckNull(document.forms[0].txtCode)) {
        alert("Vui lòng nhập mã số thẻ");
        document.forms[0].txtCode.focus();
        return false;
    }
    if (CheckNull(document.forms[0].txtValidDate)) {
        alert(strMsg1);
        document.forms[0].txtValidDate.focus();
        return false;
    }
    if (!CheckNull(document.forms[0].txtLastIssuedDate)) {
        if (CompareDate(document.forms[0].txtValidDate, document.forms[0].txtLastIssuedDate, strDateFormat) == 1) {
            alert(strMsgDate1);
            return false;
        }
    }
    if (!CheckNull(document.forms[0].txtExpiredDate)) {
        if (CompareDate(document.forms[0].txtExpiredDate, document.forms[0].txtValidDate, strDateFormat) == 1) {
            alert(strMsgDate2);
            return false;
        }
    }
    // Update patron other address	
    if (document.forms[0].hidAddressInfor.value == '' && document.forms[0].txtTotalRecord.value == 0) AddNewRecord();
    else UpdatePatronAdd(document.forms[0].hidCurrentRecord.value);
    BindingPatronAddress();
  
    return true;
}
// Active address
function ActiveAddress(strActiveAddr) {

    if (document.forms[0].cbxActive.checked == true)
        if ((document.forms[0].hidCheckedID.value != '') && (document.forms[0].hidIsFirstChoiceActiveAddr.value == '1')) {
            alert(strActiveAddr);
        }
        else {
            document.forms[0].hidCheckedID.value = document.forms[0].txtCurrentRecord.value;
        }
    else if (parseFloat(document.forms[0].txtCurrentRecord.value) - 1 == parseFloat(document.forms[0].hidCheckedID.value))
        document.forms[0].hidCheckedID.value = '';
}
function AddRecord() {
    UpdateRecord();
    var intNOR = CountRecord();
    var intIndex = parseFloat(document.forms[0].txtCurrentRecord.value);
    if (intIndex == intNOR) {
        intIndex++;
    }
    document.forms[0].txtCurrentRecord.value = intIndex;
    document.forms[0].txtTotalRecord.value = intIndex;
    document.forms[0].txtAddress.value = '';
    document.forms[0].txtCity.value = '';
    document.forms[0].ddlProvince.options[0].selected = true;
    document.forms[0].ddlCountry.options[0].selected = true;
    document.forms[0].txtZip.value = '';
}

function CountRecord() {
    var intPosition;
    var intCounter = 0;
    var strFieldValue = document.forms[0].hidAddressInfor.value;
    while (strFieldValue.length > 0) {
        intPosition = strFieldValue.indexOf("##");
        if (intPosition >= 0) {
            strFieldValue = strFieldValue.substring(intPosition + 2, strFieldValue.length);
        } else {
            strFieldValue = "";
        }
        intCounter++;
    }
    return intCounter;
}

function DeleteRecord(recno) {
    var intPosition;
    var intNOR;
    var intCounter;
    var records = new Array();
    var currentRecord;
    var strFieldValue = document.forms[0].hidAddressInfor.value;
    if (strFieldValue == "") {
        return;
    }
    intNOR = 0;
    intCounter = 0;
    while (strFieldValue.length > 0) {
        intPosition = strFieldValue.indexOf("##");
        if (intPosition >= 0) {
            records[intCounter] = strFieldValue.substring(0, intPosition);
            strFieldValue = strFieldValue.substring(intPosition + 2, strFieldValue.length);
        } else {
            records[intCounter] = strFieldValue;
            strFieldValue = "";
        }
        intCounter++;
    }

    intNOR = intCounter;
    if (intNOR == 0) { return; }
    currentRecord = recno - 1;
    records[currentRecord] = "";

    for (intCounter = 0; intCounter <= intNOR; intCounter++) {
        if (records[intCounter]) {
            strFieldValue = strFieldValue + records[intCounter] + "##";
        }
    }

    strFieldValue = EscapeSingleQuote(strFieldValue);
    document.forms[0].hidAddressInfor.value = strFieldValue;

    intNOR--;
    document.forms[0].txtTotalRecord.value = intNOR;

    if (intNOR > 0) {
        ViewRecord(1);
    } else {
        document.forms[0].txtTotalRecord.value = intNOR;
        document.forms[0].txtAddress.value = '';
        document.forms[0].txtCity.value = '';
        document.forms[0].ddlProvince.options[0].selected = true;
        document.forms[0].ddlCountry.options[0].selected = true;
        document.forms[0].txtZip.value = '';
    }
}


/*
ViewRecord function
Purpose: Restore all field value of cataloguing form
Creator: Oanhtn
CreatedDate: 19/05/2004
*/
function ViewRecord(intRecordNumber, strMess1, strMess2) {
    var intMaxRecord;
    var intPosition;
    var thisField;
    var intIndex;
    var intCounter;
    var arrRecord = new Array();
    var strStoreValue = document.forms[0].hidAddressInfor.value;
    if (strStoreValue == "") {
        return;
    }
    intMaxRecord = document.forms[0].txtTotalRecord.value;
    if (intRecordNumber < 1) {
        alert(strMess1);
        return;
    }

    if (intRecordNumber > intMaxRecord) {
        alert(strMess2);
        return;
    }
    // Update status address
    UpdateRecord();
    intCounter = intRecordNumber - 1;
    document.forms[0].txtCurrentRecord.value = intRecordNumber;
    arrRecord = strStoreValue.split("##"); // Split each record
    intIndex = arrRecord.length - 1;
    if (intCounter == intIndex) {
        intCounter--;
        document.forms[0].txtCurrentRecord.value = intIndex;
    }
    // Show data now
    ParseRecordContent(arrRecord[intCounter]);
}

/*
ParseRecordContent function	
*/
function ParseRecordContent(strValue) {
    if (strValue != '') {
        intPosition = strValue.indexOf("$&");
        if (intPosition >= 0) { // Get address
            document.forms[0].txtAddress.value = strValue.substring(0, intPosition);
            strValue = strValue.substring(intPosition + 2, strValue.length);
        }
        intPosition = strValue.indexOf("$&");
        if (intPosition >= 0) { // Get city
            document.forms[0].txtCity.value = strValue.substring(0, intPosition);
            strValue = strValue.substring(intPosition + 2, strValue.length);
        }
        intPosition = strValue.indexOf("$&");
        if (intPosition >= 0) { // Get province
            intProvince = parseFloat(strValue.substring(0, intPosition));
            for (intCounter = 0; intCounter < document.forms[0].ddlProvince.options.length - 1; intCounter++) {
                if (intProvince == document.forms[0].ddlProvince.options[intCounter].value) {
                    document.forms[0].ddlProvince.options[intCounter].selected = true;
                    break;
                }
            }
            strValue = strValue.substring(intPosition + 2, strValue.length);
        }
        intPosition = strValue.indexOf("$&");
        if (intPosition >= 0) { // Get country
            intCountry = parseFloat(strValue.substring(0, intPosition));
            for (intCounter = 0; intCounter < document.forms[0].ddlCountry.options.length - 1; intCounter++) {
                if (intCountry == document.forms[0].ddlCountry.options[intCounter].value) {
                    document.forms[0].ddlCountry.options[intCounter].selected = true;
                    break;
                }
            }
            strValue = strValue.substring(intPosition + 2, strValue.length);
        }
        intPosition = strValue.indexOf("$&");
        if (intPosition >= 0) { // Get Zip
            document.forms[0].txtZip.value = strValue.substring(0, intPosition);
            strValue = strValue.substring(intPosition + 2, strValue.length);
        }
        // Get Active address
        if (parseFloat(strValue.substring(0, 1)) == 1) document.forms[0].cbxActive.checked = true;
        else document.forms[0].cbxActive.checked = false;
    }
}

function UpdateRecord() {
    var intCounter;
    var intCounter1 = 0;
    var intPosition;
    var arrFieldValues = new Array();
    var strStoreValue;

    strStoreValue = document.forms[0].hidAddressInfor.value;

    while (strStoreValue.length > 0) {
        intPosition = strStoreValue.indexOf("##");
        if (intPosition >= 0) {
            arrFieldValues[intCounter1] = strStoreValue.substring(0, intPosition);
            strStoreValue = strStoreValue.substring(intPosition + 2, strStoreValue.length);
        } else {
            arrFieldValues[intCounter1] = strStoreValue;
            strStoreValue = "";
        }
        intCounter1++;
    }

    var currentRecord = parseInt(document.forms[0].txtCurrentRecord.value);
    if (currentRecord == 0) {
        document.forms[0].txtCurrentRecord.value = 1;
        document.forms[0].txtTotalRecord.value = 1;
    } else {
        currentRecord--;
        if (currentRecord > intCounter1) {
            intCounter1 = currentRecord;
        }
    }

    arrFieldValues[currentRecord] = SaveRecord();

    strStoreValue = "";
    for (intCounter = 0; intCounter <= intCounter1; intCounter++) {
        if (arrFieldValues[intCounter]) {
            strStoreValue = strStoreValue + arrFieldValues[intCounter] + "##";
        }
    }
    strStoreValue = EscapeSingleQuote(strStoreValue);
    document.forms[0].hidAddressInfor.value = strStoreValue;
}

function SaveRecord() {
    strData = '';
    if (!CheckNull(document.forms[0].txtAddress)) {
        strAddress = document.forms[0].txtAddress.value;
        strCity = document.forms[0].txtCity.value;
        strProvince = document.forms[0].ddlProvince.options[document.forms[0].ddlProvince.options.selectedIndex].value;
        strCountry = document.forms[0].ddlCountry.options[document.forms[0].ddlCountry.options.selectedIndex].value;
        strZip = document.forms[0].txtZip.value;
        if (document.forms[0].cbxActive.checked) {
            strOption = 1;
            document.forms[0].hidCheckedID.value = document.forms[0].txtCurrentRecord.value;
            document.forms[0].hidIsFirstChoiceActiveAddr.value = '1';
        } else {
            strOption = 0;
        }
        strData = strAddress + "$&" + strCity + "$&" + strProvince + "$&" + strCountry + "$&" + strZip + "$&" + strOption;
    }
    document.forms[0].cbxActive.checked = false;
    return strData;
}


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
Move to first record
*/
function MoveFirst(strMess1, strMess2) {
    ViewRecord(1, strMess1, strMess2);

}

/*
Move to previous record
*/
function MovePrev(strMess1, strMess2) {
    ViewRecord(parseInt(document.forms[0].txtCurrentRecord.value) - 1, strMess1, strMess2);
}

/*
Move to first record
*/
function MoveNext(strMess1, strMess2) {

    ViewRecord(parseInt(document.forms[0].txtCurrentRecord.value) + 1, strMess1, strMess2)
}

/*
Move to last record
*/
function MoveLast(strMess1, strMess2) {
    ViewRecord(parseFloat(document.forms[0].txtTotalRecord.value), strMess1, strMess2);
}

var arrControls = new Array(20);
arrControls[0] = 'txtFirstName';
arrControls[1] = 'txtLastName';
arrControls[2] = 'optMale';
arrControls[3] = 'optFeMale';
arrControls[4] = 'txtDOB';
arrControls[5] = 'ddlEthnic';
arrControls[6] = 'txtCode';
arrControls[7] = 'ddlPatronGroup';
arrControls[8] = 'txtLastIssuedDate';
arrControls[9] = 'txtValidDate';
arrControls[10] = 'txtExpiredDate';
arrControls[11] = 'ddlEducation';
arrControls[12] = 'ddlOccupation';
arrControls[13] = 'txtWorkPlace';
arrControls[14] = 'ddlCollege';
arrControls[15] = 'ddlFaculty';
arrControls[16] = 'txtGrade';
arrControls[17] = 'txtClass';
arrControls[18] = 'txtAddress';
arrControls[19] = 'txtCity';
arrControls[20] = 'ddlProvince';
arrControls[21] = 'ddlCountry';
arrControls[22] = 'txtZip';
arrControls[23] = 'cbxActive';
arrControls[24] = 'txtTelephone';
arrControls[25] = 'txtMobile';
arrControls[26] = 'txtEmail';
arrControls[27] = 'txtNote';


function microsoftKeyPress() {
    var strCurrentValue;
    var strPrefix = '';
    if (window.event.keyCode == 13) {
        curtab = curtab + 1;
        if (curtab < arrControls.length) {
            if (arrControls[curtab] == 'txtTelephone') {
                if (!CheckNull(document.forms[0].txtAddress)) {
                    document.forms[0].btnNew.click();
                    eval('document.forms[0].txtAddress.focus()');
                } else {
                    eval('document.forms[0].' + arrControls[curtab] + '.focus()');
                }
            } else {
                eval('document.forms[0].' + arrControls[curtab] + '.focus()');
            }
        }
        window.event.keyCode = 27;
    }
    if (window.event.ctrlKey) {
        strPrefix += 'c';
        if (window.event.shiftKey) strPrefix += 's';
    }
    if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csp") {
        document.forms[0].btnPrevious.click();
    } else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csn") {
        document.forms[0].btnNext.click();
    } else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csf") {
        document.forms[0].btnFirst.click();
    } else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csl") {
        document.forms[0].btnLast.click();
    } else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csd") {
        document.forms[0].btnDelete.click();
    } else if (strPrefix + String.fromCharCode(window.event.keyCode + 96) == "csa") {
        if (!CheckNull(document.forms[0].txtAddress)) {
            document.forms[0].btnNew.click();
            eval('document.forms[0].txtAddress.focus()');
        } else {
            eval('document.forms[0].txtAddress.focus()');
        }
    }
}

/*
AddImage function
*/
function AddImage(strMsg) {
    if (CheckNull(document.forms[0].txtCode)) {
        alert(strMsg)
    } else {
        OpenWindow('WUpLoad.aspx?Code=' + document.forms[0].txtCode.value, 'PatronImage', 340, 60, 50, 050);
    }
}

/*
FilterFaculty function
*/
function FilterFaculty(intCollegeID, strText) {
    document.forms[0].ddlFaculty.options.length = 1;
    
    document.forms[0].ddlFaculty[0].value = "";
    document.forms[0].ddlFaculty[0].text = strText;
    if (intCollegeID == "0") {
        document.getElementById("hidFaculty").value = "";
    }
    for (j = 0; j < CollegeID.length; j++) {
        if (CollegeID[j] == intCollegeID) {
            document.forms[0].ddlFaculty.options.length = document.forms[0].ddlFaculty.options.length + 1;
            document.forms[0].ddlFaculty.options[document.forms[0].ddlFaculty.options.length - 1].value = FacultyID[j];
            document.forms[0].ddlFaculty.options[document.forms[0].ddlFaculty.options.length - 1].text = FacultyName[j];
        }
    }
}

/*
LoadDefaultValue function
*/
function LoadDefaultValue(strText, strValidDate, strExpiredDate, strLastIssuedDate, strWorkPlace, intEthnicID, intEducationID, intCollegeID, intFacultyID, intOccupationID, intPatronGroupID, strGrade, strClass) {
    var intIndex;
    document.forms[0].txtValidDate.value = strValidDate;
    document.forms[0].txtExpiredDate.value = strExpiredDate;
    document.forms[0].txtLastIssuedDate.value = strLastIssuedDate;
    document.forms[0].txtWorkPlace.value = strWorkPlace;
    document.forms[0].txtGrade.value = strGrade;
    document.forms[0].txtClass.value = strClass;
    document.forms[0].hidEthnic.value = intEthnicID;
    for (intIndex = 0; intIndex < document.forms[0].ddlEthnic.options.length; intIndex++) {
        if (document.forms[0].ddlEthnic.options[intIndex].value == intEthnicID) {
            document.forms[0].ddlEthnic.options[intIndex].selected = true;
            break;
        }
    }
    document.forms[0].hidEducation.value = intEducationID;
    for (intIndex = 0; intIndex < document.forms[0].ddlEducation.options.length; intIndex++) {
        if (document.forms[0].ddlEducation.options[intIndex].value == intEducationID) {
            document.forms[0].ddlEducation.options[intIndex].selected = true;
            break;
        }
    }
    document.forms[0].hidCollege.value = intCollegeID;
    for (intIndex = 0; intIndex < document.forms[0].ddlCollege.options.length; intIndex++) {
        if (document.forms[0].ddlCollege.options[intIndex].value == intCollegeID) {
            document.forms[0].ddlCollege.options[intIndex].selected = true;
            break;
        }
    }
    document.forms[0].hidFaculty.value = intFacultyID;
    document.forms[0].hidOccupation.value = intOccupationID;
    for (intIndex = 0; intIndex < document.forms[0].ddlOccupation.options.length; intIndex++) {
        if (document.forms[0].ddlOccupation.options[intIndex].value == intOccupationID) {
            document.forms[0].ddlOccupation.options[intIndex].selected = true;
            break;
        }
    }
    document.forms[0].hidPatronGroup.value = intPatronGroupID;
    for (intIndex = 0; intIndex < document.forms[0].ddlPatronGroup.options.length; intIndex++) {
        if (document.forms[0].ddlPatronGroup.options[intIndex].value == intPatronGroupID) {
            document.forms[0].ddlPatronGroup.options[intIndex].selected = true;
            break;
        }
    }
    FilterFaculty(intCollegeID, strText);
    for (intIndex = 0; intIndex < document.forms[0].ddlFaculty.options.length; intIndex++) {
        if (document.forms[0].ddlFaculty.options[intIndex].value == intFacultyID) {
            document.forms[0].ddlFaculty.options[intIndex].selected = true;
            break;
        }
    }
}
// don't do anything, but must have
function ChangeTab(val) {
}
//---------- define object patron's address for multi address action-----------
//------------------- by sondp ------------------------------------------------
//------------------- 18/03/2006  ---------------------------------------------

// define a structure patron's address
function PatronAddress(intID, strAddress, strCity, intProvinceID, intCountryID, strZip, isAddActive) {
    this.ID = intID;
    this.Address = strAddress;
    this.City = strCity;
    this.ProvinceID = intProvinceID;
    this.CountryID = intCountryID;
    this.Zip = strZip;
    this.isAddActive = isAddActive;
    return this;
}
// addnew record
function AddNewRecord() {
    var inti;
    var intj;
    var intID;
    var strAddress;
    var strCity;
    var intProvinceID;
    var intCountryID;
    var strZip;
    var intIsAddActive;
    // inti variable
    inti = PatronAdd.length;
    intID = 0;
    strAddress = document.forms[0].txtAddress.value;
    strCity = document.forms[0].txtCity.value;
    intProvinceID = document.forms[0].ddlProvince.options[document.forms[0].ddlProvince.selectedIndex].value;
    intCountryID = document.forms[0].ddlCountry.options[document.forms[0].ddlCountry.selectedIndex].value;
    strZip = document.forms[0].txtZip.value;
    if (document.forms[0].cbxActive.checked) {
        for (intj = 0; intj < PatronAdd.length; intj++) {
            if (parseInt(PatronAdd[intj].isAddActive) == 1)
                PatronAdd[intj].isAddActive = 0;
        }
        intIsAddActive = 1;
    }
    else intIsAddActive = 0;
    PatronAdd[inti] = new PatronAddress(intID, strAddress, strCity, intProvinceID, intCountryID, strZip, intIsAddActive);
    // update string address
    BindingPatronAddress();
    document.forms[0].txtCurrentRecord.value = PatronAdd.length
    document.forms[0].txtTotalRecord.value = PatronAdd.length;
    document.forms[0].hidCurrentRecord.value = PatronAdd.length - 1;
    // reset address control
    document.forms[0].txtAddress.value = '';
    document.forms[0].txtCity.value = '';
    document.forms[0].ddlProvince.options[0].checked;
    document.forms[0].ddlCountry.options[0].checked;
    document.forms[0].txtZip.value = '';
    document.forms[0].cbxActive.checked = false;
}

// delete a patron's address
function DeleteRecord() {
    DeleteAction(document.forms[0].hidCurrentRecord.value);
}
// action delete a patron's address
function DeleteAction(intIndex) {
    var inti;
    if (!isNaN(intIndex)) {
        if (intIndex < PatronAdd.length - 1) {
            for (inti = 0; inti < PatronAdd.length - 1; inti++) {
                PatronAdd[inti] = PatronAdd[inti + 1];
            }
        }
        PatronAdd.length = PatronAdd.length - 1;
        // update string address
        BindingPatronAddress();
        // update view screen
        document.forms[0].txtTotalRecord.value = PatronAdd.length;
        // focus at first record
        document.forms[0].txtCurrentRecord.value = 1;
        document.forms[0].hidCurrentRecord.value = 0;
        GetRecord(parseInt(document.forms[0].hidCurrentRecord.value));
    }
}
// Get record 
function GetRecord(intPos) {
    var inti;
    if (intPos >= 0 && intPos <= PatronAdd.length - 1) {
        document.forms[0].txtAddress.value = PatronAdd[intPos].Address;
        document.forms[0].txtCity.value = PatronAdd[intPos].City;
        // Provice
        for (inti = 0; inti < document.forms[0].ddlProvince.length; inti++) {
            if (parseInt(document.forms[0].ddlProvince.options[inti].value) == parseInt(PatronAdd[intPos].ProvinceID)) {
                document.forms[0].ddlProvince.selectedIndex = inti;
                inti = document.forms[0].ddlProvince.length;
            }
        }
        // Country
        for (inti = 0; inti < document.forms[0].ddlCountry.length; inti++) {
            if (parseInt(document.forms[0].ddlCountry.options[inti].value) == parseInt(PatronAdd[intPos].CountryID)) {
                document.forms[0].ddlCountry.selectedIndex = inti;
                inti = document.forms[0].ddlCountry.length;
            }
        }
        document.forms[0].txtZip.value = PatronAdd[intPos].Zip;
        if (parseInt(PatronAdd[intPos].isAddActive) == 1) document.forms[0].cbxActive.checked = true;
        else document.forms[0].cbxActive.checked = false;
    }
    return true;
}
// move last record
function MoveLastRecord() {
    if (PatronAdd.length >= 0) {
        UpdatePatronAdd(document.forms[0].hidCurrentRecord.value);
        document.forms[0].txtCurrentRecord.value = PatronAdd.length;
        document.forms[0].hidCurrentRecord.value = PatronAdd.length - 1;
        GetRecord(parseInt(document.forms[0].hidCurrentRecord.value));
    }
}
// move next record
function MoveNextRecord(strLastRecord) {
    var intPos;
    intPos = parseInt(document.forms[0].hidCurrentRecord.value) + 1;
    if (intPos >= PatronAdd.length) {
        alert(strLastRecord);
        document.forms[0].txtCurrentRecord.value = PatronAdd.length;
        document.forms[0].hidCurrentRecord.value = PatronAdd.length - 1;
        return false;
    }
    UpdatePatronAdd(document.forms[0].hidCurrentRecord.value);
    GetRecord(intPos);
    document.forms[0].txtCurrentRecord.value = intPos + 1;
    document.forms[0].hidCurrentRecord.value = intPos;
    return true;
}
// move first record
function MoveFirstRecord() {
    if (PatronAdd.length >= 0) {
        UpdatePatronAdd(document.forms[0].hidCurrentRecord.value);
        document.forms[0].hidCurrentRecord.value = 0;
        document.forms[0].txtCurrentRecord.value = 1;
        GetRecord(parseInt(document.forms[0].hidCurrentRecord.value));
    }
}
// move previous record
function MovePreviousRecord(strFirstRecord) {
    var intPos;
    intPos = parseInt(document.forms[0].hidCurrentRecord.value) - 1;
    if (intPos < 0) {
        alert(strFirstRecord);
        document.forms[0].txtCurrentRecord.value = 1;
        document.forms[0].hidCurrentRecord.value = 0;
        return false;
    }
    UpdatePatronAdd(document.forms[0].hidCurrentRecord.value);
    GetRecord(intPos);
    document.forms[0].txtCurrentRecord.value = intPos + 1;
    document.forms[0].hidCurrentRecord.value = intPos;
    return true;
}
// Update patron other address
function UpdatePatronAdd(intPos) {
    strAddress = document.forms[0].txtAddress.value;
    strCity = document.forms[0].txtCity.value;
    intProvinceID = document.forms[0].ddlProvince.options[document.forms[0].ddlProvince.selectedIndex].value;
    intCountryID = document.forms[0].ddlCountry.options[document.forms[0].ddlCountry.selectedIndex].value;
    strZip = document.forms[0].txtZip.value;
    if (document.forms[0].cbxActive.checked) {
        for (intj = 0; intj < PatronAdd.length; intj++) {
            if (parseInt(PatronAdd[intj].isAddActive) == 1)
                PatronAdd[intj].isAddActive = 0;
        }
        intIsAddActive = 1;
    }
    else intIsAddActive = 0;
    PatronAdd[intPos].Address = strAddress;
    PatronAdd[intPos].City = strCity;
    PatronAdd[intPos].ProvinceID = intProvinceID;
    PatronAdd[intPos].CountryID = intCountryID;
    PatronAdd[intPos].Zip = strZip;
    PatronAdd[intPos].isAddActive = intIsAddActive;
}

// get string patron's address
// each address seperate by \n, and each item(in a address) seperate by \t(tab)
function BindingPatronAddress() {
    var inti;
    var strPatronAdd;
    var boolHaveActiveAdd;
    strPatronAdd = '';
    boolHaveActiveAdd = false;
    if (PatronAdd.length >= 0) {
        // check is have active addrress
        for (inti = 0; inti < PatronAdd.length && !boolHaveActiveAdd; inti++) {
            if (PatronAdd[inti].isAddActive == 1) boolHaveActiveAdd = true;
        }
        if (!boolHaveActiveAdd) PatronAdd[0].isAddActive = 1; // default first record is active address
        for (inti = 0; inti < PatronAdd.length; inti++) {
            //strPatronAdd=strPatronAdd + PatronAdd[inti].ID + '\t' + PatronAdd[inti].Address + '\t' + PatronAdd[inti].City + '\t' + PatronAdd[inti].ProvinceID + '\t' + PatronAdd[inti].CountryID + '\t' + PatronAdd[inti].Zip + '\t' + PatronAdd[inti].isAddActive + '\n';
            strPatronAdd = strPatronAdd + 'vbCrLf' + PatronAdd[inti].ID + '\t' + PatronAdd[inti].Address + '\t' + PatronAdd[inti].City + '\t' + PatronAdd[inti].ProvinceID + '\t' + PatronAdd[inti].CountryID + '\t' + PatronAdd[inti].Zip + '\t' + PatronAdd[inti].isAddActive + '\n';
        }
    }
    document.forms[0].hidAddressInfor.value = strPatronAdd;
}

/* 
// this code download from http://www.devx.com
*/
function Left(str, n) {
    if (n <= 0)
        return '';
    else if (n > String(str).length)
        return str;
    else
        return String(str).substring(0, n);
}
function Right(str, n) {
    if (n <= 0)
        return '';
    else if (n > String(str).length)
        return str;
    else {
        var iLen = String(str).length;
        return String(str).substring(iLen, iLen - n);
    }
}
function CheckSymbol(objField, strMsg) {
    var temp;
    var len;
    var symbol;
    var i;
    var j;
    temp = trim(eval(objField).value);
    if (temp == '') {
        alert(strMsg);
        return false;
    }
    symbol = "!@#$%^&*()_-+=|\':;?/>.<,";
    for (i = 0; i < temp.length; i++) {
        var c = temp.charAt(i);
        for (j = 0; j < symbol.length; j++) {
            var d = symbol.charAt(j);
            if (d == c) {
                alert(strMsg);
                return false;
            }
        }
    }
    return true;
}