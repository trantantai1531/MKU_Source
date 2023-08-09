//Trim string in javascript.
//Creater: PhuongTT
//Date: 2014.10.12
function trim(str){
	return 	str.replace(/^\s*|\s*$/g,"");
}
// Check for update patron
function CheckForUpdate(strEmtyPassword,strComparePassword,strEmail){
	var pass=trim(document.forms[0].txtPassword.value);
	if (pass.length<4) {
		alert(strEmtyPassword);
		document.forms[0].txtPassword.focus();
		return false;
	}
	// Compare Password
	if(document.forms[0].txtPassword.value!=document.forms[0].txtConfirmPassword.value){
		alert(strComparePassword);
		document.forms[0].txtConfirmPassword.focus();
		return false;
	}
	if (!CheckValidEmail(document.forms[0].txtEmail.value)){
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
    if(str.indexOf("@") >= 0) 
      return true;     
    return false; 
  } 
} 