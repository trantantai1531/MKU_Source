function trim(str) {
    return str.replace(/^\s*|\s*$/g, "");
}

// Check for Request Cataloger
function CheckForRequest(strMsg, strEmail) {
    var input = trim(document.forms[0].txtFullName.value);
    if (input.length = 0) {
        alert(strMsg);
        document.forms[0].txtFullName.focus();
        return false;
    }

    input = trim(document.forms[0].txtPatronCode.value);
    if (input.length = 0) {
        alert(strMsg);
        document.forms[0].txtPatronCode.focus();
        return false;
    }

    input = trim(document.forms[0].txtEmail.value);
    if (input.length = 0) {
        alert(strMsg);
        document.forms[0].txtEmail.focus();
        return false;
    }

    input = trim(document.forms[0].txtPhone.value);
    if (input.length = 0) {
        alert(strMsg);
        document.forms[0].txtPhone.focus();
        return false;
    }

    input = trim(document.forms[0].txtTitle.value);
    if (input.length = 0) {
        alert(strMsg);
        document.forms[0].txtTitle.focus();
        return false;
    }

    if (!CheckValidEmail(document.forms[0].txtEmail.value)) {
        alert(strEmail);
        document.forms[0].txtEmail.focus();
        return false;
    }
    return true;
}

// Check Email Address
function CheckValidEmail(objEmail) {
    var str = objEmail;
    if (window.RegExp) {
        var reg1str = "(@.*@)|(\\.\\.)|(@\\.)|(\\.@)|(^\\.)";
        var reg2str = "^.+\\@(\\[?)[a-zA-Z0-9\\-\\.]+\\.([a-zA-Z]{2,3}|[0-9]{1,3})(\\]?)$";
        var reg1 = new RegExp(reg1str);
        var reg2 = new RegExp(reg2str);
        if (!reg1.test(str) && reg2.test(str)) {
            return true;
        }
        return false;
    } else {
        if (str.indexOf("@") >= 0)
            return true;
        return false;
    }
}