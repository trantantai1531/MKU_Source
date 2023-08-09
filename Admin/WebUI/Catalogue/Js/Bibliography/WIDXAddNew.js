function ValidAddNew(strMsg) {
    if (CheckNull(document.forms[0].txtTitle)) {
        alert(strMsg);
        document.forms[0].txtTitle.focus();
        return false;
    } else {
        if (CheckNull(document.forms[0].txtGroupBy)) {
            alert(strMsg);
            document.forms[0].txtGroupBy.focus();
            return false;
        } else {
            return true;
        }
    }

}

function ValidDel(strMsgConfirm) {
    // form IDs check
    var strIDs;
    var len;
    var i;
    strIDs = '';
    if (document.forms[0].chkIDs.length) {
       
        len = document.forms[0].chkIDs.length;
        for (i = 0; i < len; i++) {
            if (document.forms[0].chkIDs[i].checked) {
                strIDs = strIDs + document.forms[0].chkIDs[i].value + ',';
            }
        }
        if (strIDs.length > 0) {
            strIDs = strIDs.substring(0, strIDs.length - 1);
        }
        document.forms[0].txtHidIDs.value = strIDs;
        if (strIDs.length > 0) {
            if (confirm(strMsgConfirm)) {
                return true;
            } else {
                //alert("Chưa chọn danh mục cần xóa");
                return false;
            }
        } else {
            alert("Chưa chọn danh mục cần xóa");
            return false;
        }
    } else {
        console.log(2);
        if (document.forms[0].chkIDs.checked) {
            strIDs = document.forms[0].chkIDs.value;
            console.log(3);
        }
        document.forms[0].txtHidIDs.value = strIDs;
        if (strIDs.length > 0) {
            if (confirm(strMsgConfirm)) {
                return true;
            } else {
               // alert("Chưa chọn danh mục cần xóa");
                return false;
            }
        } else {
            alert("Chưa chọn danh mục cần xóa");
            return false;
        }
    }
    return false;
}

function ValidUpdate(strMsg) {
    var strIDs;
    var len;
    var i;
    strIDs = '';
    if (document.forms[0].chkIDs.length) {
        len = document.forms[0].chkIDs.length;
        for (i = 0; i < len; i++) {
            if (document.forms[0].chkIDs[i].checked) {
                strIDs = document.forms[0].chkIDs[i].value;
                break;
            }
        }
        if (strIDs == '') {
            alert(strMsg);
            return false;
        } else {
            document.forms[0].txtHidIDs.value = strIDs;
            return true;
        }
    } else {
        if (document.forms[0].chkIDs.value) {
            strIDs = document.forms[0].chkIDs.value;
            document.forms[0].txtHidIDs.value = strIDs;
            return true;
        } else {
            return false;
        }
    }
}

function ValidView(strMsg) {
    var strIDs;
    var len;
    var i;
    strIDs = '';
    if (document.forms[0].chkIDs.length) {
        len = document.forms[0].chkIDs.length;
        for (i = 0; i < len; i++) {
            if (document.forms[0].chkIDs[i].checked) {
                strIDs = document.forms[0].chkIDs[i].value;
                break;
            }
        }
        if (strIDs == '') {
            alert(strMsg);
            console.log("1-1");
            return false;
        } else {
            console.log("1-2");
            document.forms[0].txtHidIDs.value = strIDs;
            return true;
        }
    } else {
        if (document.forms[0].chkIDs.value) {
            console.log("2-1");
            strIDs = document.forms[0].chkIDs.value;
            document.forms[0].txtHidIDs.value = strIDs;
            return true;
        } else {
            console.log("2-2");
            return false;
        }
    }
}

function ShowDetail(val) {
    var URL;
    URL = 'WShowGroup.aspx?intID=' + val;
    //openModal(URL,'ShowGrp',wWidth,wHeight,wLeft,wTop,wScrollbar,strOthers,Modal);
    openModal(URL, 'ShowGrp', 600, 350, 100, 100, 'no', '', 0);
}