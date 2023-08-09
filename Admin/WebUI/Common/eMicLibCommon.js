//====================================================================
//	eMicLibCommon.js
//	Functions is sorted by function name

//	*Note: After repair or add new functions
//	Everybody need write 2 commends with contents:
//	- Name of repairer or owner of new functions.	  
//	- Date.
//=====================================================================
// Declare variables
var popUp;
var iebrower  = document.all;

// Menu Change function
// Purpose: Display again the button images when click to other menu
function MenuChange(){
if (document.forms[0].hidClick.value!=0)
{
	var intTemp1;
	var intTemp2;	
	intTemp1 = parseFloat(document.forms[0].hidClick.value);
	intTemp2 = parseFloat(document.forms[0].hidClick.value) + 1;
	eval('menu' + document.forms[0].hidClick.value).style.backgroundImage='url(../Images/002_bg.gif)';
	if (document.forms[0].hidClick.value==1)
	{
		eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_002.gif)';
		eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003.gif)';
	}
	else if (document.forms[0].hidClick.value==document.forms[0].hidMaxMenu.value)
	{
		eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003.gif)';
		eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_004.gif)';
	}
	else
	{
		eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003.gif)';
		eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003.gif)';
	}
}
}

// MenuClick
// Purpose: Change the color of the new menu and keep them until other click event handled
function MenuClick(intMenu){
if (intMenu!=0)
{			
	document.forms[0].hidClick.value = intMenu;
	
	var intTemp1;
	var intTemp2;
	
	intTemp1 = intMenu;
	intTemp2 = parseFloat(intMenu) + 1;
	
	eval('menu' + intTemp1).style.backgroundImage='url(../Images/002_bg_b.gif)';			
	if (intMenu==1)
	{
		eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_002_b.gif)';
		eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003_c.gif)';
	}
	else if (document.forms[0].hidClick.value==document.forms[0].hidMaxMenu.value)
	{
		eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003_b.gif)';
		eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_004_b.gif)';
		
	}
	else
	{
		eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003_b.gif)';
		eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003_c.gif)';
	}
}
}

// MenuHover 
// Purpose: Change the color of the button hovered (The click button not have to change)
function MenuHover(intMenu){
if (intMenu!=0 && intMenu!=document.forms[0].hidClick)
{					
	var intTemp1;
	var intTemp2;
	
	intTemp1 = intMenu;
	intTemp2 = parseFloat(intMenu) + 1;
	
	eval('menu' + intTemp1).style.backgroundImage='url(../Images/002_bg_b.gif)';							
	if (intMenu==1)
	{
		if (intMenu == parseFloat(document.forms[0].hidClick.value) - 1)
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_002_b.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003_d.gif)';
		}
		else
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_002_b.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003_c.gif)';
		}
	}
	else if (intMenu==document.forms[0].hidMaxMenu.value)
	{
		if (intMenu == parseFloat(document.forms[0].hidClick.value) + 1)
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003_d.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_004_b.gif)';
		}
		else
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003_b.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_004_b.gif)';
		}					
	}
	else
	{
		if (intMenu == parseFloat(document.forms[0].hidClick.value) - 1)
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003_b.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003_d.gif)';
		}
		else if (intMenu == parseFloat(document.forms[0].hidClick.value) + 1)
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003_d.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003_c.gif)';
		}
		else
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003_b.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003_c.gif)';
		}
	}
}
}

// MenuOut
// Purpose: Clear the color of the button (Change for the UnClick button)
function MenuOut(intMenu){
if(document.forms[0].hidClick.value!=intMenu)
{					
	var intTemp1;
	var intTemp2;
	
	intTemp1 = intMenu;
	intTemp2 = parseFloat(intMenu) + 1;
	
	eval('menu' + intTemp1).style.backgroundImage='url(../Images/002_bg.gif)';			
	if (intMenu==1)
	{
		if (intMenu == parseFloat(document.forms[0].hidClick.value) - 1)
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_002.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003_b.gif)';
		}
		else
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_002.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003.gif)';
		}
	}
	else if (intMenu==document.forms[0].hidMaxMenu.value)
	{
		if (intMenu == parseFloat(document.forms[0].hidClick.value) - 1)
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003_b.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_004.gif)';
		}
		else
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_004.gif)';
		}
		
	}
	else
	{
		if (intMenu == parseFloat(document.forms[0].hidClick.value) + 1)
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003_c.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003.gif)';
		}
		else if(intMenu == parseFloat(document.forms[0].hidClick.value) - 1)
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003_b.gif)';
		}
		else
		{
			eval('menu' + intTemp1 + 'a').style.backgroundImage='url(../Images/002_003.gif)';
			eval('menu' + intTemp2 + 'a').style.backgroundImage='url(../Images/002_003.gif)';
		}
	}
}
}


//=====================================================================
// End of Menu process
//
//
//=====================================================================

//
//=====================================================================
//
//	Used to add new item for SelectBox, DropDownList.
function AddItem(obj,texts,val) {    
	eval(obj).length++;
	eval(obj).options[eval(obj).options.length-1].value = val;
	eval(obj).options[eval(obj).options.length-1].text = texts;	
	eval(obj).options[eval(obj).options.length-1].selected=true;
	self.close();	 
}

//Trim string in javascript.
function trim(str){
	return 	str.replace(/^\s*|\s*$/g,"");
}
// Add item for dropdownlist and mark add data by javascript for dropdownlist
// By set value for objtxt 
function AddItemPatron(objddl,texts,val,objtxt) {
    eval(objddl).length++;
	eval(objddl).options[eval(objddl).options.length-1].value = val;
	eval(objddl).options[eval(objddl).options.length-1].text = texts;	
	eval(objddl).options[eval(objddl).options.length-1].selectedIndex = eval(objddl).length;
	eval(objddl).options[eval(objddl).options.length-1].selected=true;		
	eval(objtxt).value=eval(objddl).length-1;	
	if (eval(objddl).name=='ddlCollege'){	   
	   opener.document.forms[0].ddlFaculty.length=1;
	}
	self.close();
}

// Load data to dropdownlist and textbox
function AddDdlItem(objddl,text,val,objtxt) {
    eval(objddl).length++;
	eval(objddl).options[eval(objddl).options.length-1].value = val;
	eval(objddl).options[eval(objddl).options.length-1].text = text;
	eval(objddl).options[eval(objddl).options.length-1].selectedIndex = eval(objddl).length;
	eval(objddl).options[eval(objddl).options.length-1].selected=true;
	eval(objtxt).value=eval(objddl).length-1;
	self.close();
}

// Used to remove item for SelectBox, DropDownList.
function RemoveItem(obj) {
	eval(obj).length++;
	eval(obj).options[eval(obj).options.length-1].value = val;
	eval(obj).options[eval(obj).options.length-1].text = texts;	
}

function CheckDate(objDateField,strDateFormat,strMsg){
	//Check Date of dateobjects.
	strDateFormat = strDateFormat.toLowerCase();
	mdateval = eval(objDateField).value;	
	switch(strDateFormat){
		case 'dd/mm/yyyy':
				if (mdateval != "") {
					mday = mdateval.substring(0, mdateval.indexOf("/"));
					mmonth = mdateval.substring(mdateval.indexOf("/") + 1, mdateval.lastIndexOf("/"));
					myear = mdateval.substring(mdateval.lastIndexOf("/") + 1, mdateval.length);
					mdate = new Date (mmonth + "/" + mday + "/" + myear);
					cday = mdate.getDate();
					cmonth = mdate.getMonth() + 1;
					cyear = mdate.getYear();
					if ((parseFloat(mday) != parseFloat(cday)) || (parseFloat(mmonth) != parseFloat(cmonth)) || (isNaN(myear)) || (myear.length < 4) || (myear.length>4) || (myear<1753)) 
						{
							alert(strMsg);							
							eval(objDateField).value = "";							
							eval(objDateField).focus();							
							return false;
						}
					break;
				}	
		case 'mm/dd/yyyy':
				if (mdateval != "") {
					mmonth = mdateval.substring(0, mdateval.indexOf("/"));
					mday = mdateval.substring(mdateval.indexOf("/") + 1, mdateval.lastIndexOf("/"))
					myear = mdateval.substring(mdateval.lastIndexOf("/") + 1, mdateval.length);
					mdate = new Date (mmonth + "/" + mday + "/" + myear);
					cday = mdate.getDate();
					cmonth = mdate.getMonth() + 1;
					cyear = mdate.getYear();
					if (parseFloat(mday) != parseFloat(cday) || parseFloat(mmonth) != parseFloat(cmonth)|| (myear != cyear) || (myear.length !=4) || (myear<1753)) {
						alert(strMsg);
						eval(objDateField).value = "";
						eval(objDateField).focus();
						return  false;
					}		
					break;
				}
	}
	return true;
}
// Check Email Address
function CheckValidEmail(objEmail) { 
  var str = eval(objEmail).value; 
  if (window.RegExp) { 
    var reg1str = "(@.*@)|(\\.\\.)|(@\\.)|(\\.@)|(^\\.)";
    var reg2str = "^.+\\@(\\[?)[a-zA-Z0-9\\-\\.]+\\.([a-zA-Z]{2,3}|[0-9]{1,3})(\\]?)$";
    var reg1 = new RegExp(reg1str);
    var reg2 = new RegExp(reg2str);
    if (!reg1.test(str) && reg2.test(str)) { 
      return true; 
    } 
    objEmail.value=""
    objEmail.focus(); 
    objEmail.select(); 
    return false; 
  } else { 
    if(str.indexOf("@") >= 0) 
      return true; 
    objEmail.value=""
    objEmail.focus(); 
    objEmail.select(); 
    return false; 
  } 
} 

function CheckValidEmails(str) {   
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

/*
check patron number
*/
function validatePatronCode(value) {
    console.log(value);
    return !isNaN(value) &&
         parseInt(Number(value)) == value &&
         !isNaN(parseInt(value, 10)) && value.length == 16;
}

/* Check value is empty
	if obj's value is null return true 
	else return false
*/
function CheckNull(obj){	
	var strValue;
    strValue=trim(eval(obj).value);
    if (strValue == "") {
       return true;
    }
}


// Open Window 
// By: 
function OpenWindow(strUrl,strWinname,intWidth,intHeight,intLeft,intTop){
		popUp = window.open(strUrl,strWinname, "width=" + intWidth + ",height=" + intHeight + ",left=" + intLeft+ ",top=" + intTop+ ",menubar=no,resizable=no,scrollbars=yes");
		popUp.focus()
}
// Open Window Calendar
// By: 
function OpenWindowCalendar(strUrl){
		popUp = window.open(strUrl,"Calendar", "width=255,height=220,left=200,top=250,menubar=no,resizable=no,scrollbars=no");
		popUp.focus()
}

//====================================================================
//Used to remove old item in SelectBox..
function RemoveItems(obj){
	var k = 0;
	for(var i = 0; i < eval(obj).length; i++) {
		if (eval(obj).options[i].selected == true){             
			eval(obj).options[k].value = eval(obj).options[i].value;
			eval(obj).options[k].text = eval(obj).options[i].text;
			eval(obj).options[k].selected = false;
			k = k + 1;
			alert( i + '=' + k)
		}
		eval(obj).length = k;
		}
}

// Set text
//=====================================================================
// 
//	Used to add new item for SelectBox.
function SetText(texts,obj) {
	eval(obj).value = texts;
	eval(obj).focus();
	self.close();
}
//Set fous for Control Object.
function  SetFocus(control)
{
    control.focus();
}
    
//Purpose: check a variable is number
//Modify by lent 2/4/2007
function isNumBer(objDateField) {
	var tempNum;
	tempNum = trim(eval(objDateField).value);		
	if(tempNum=="") {
		return false;
	}	
	if (isNaN(tempNum)) {
		return false;
	}
	return true;
}

function CheckAge(objDateField,strMsg){
	var tempNum;
	tempNum=trim(eval(objDateField).value);
	if(tempNum==""){
		alert(strMsg);
		return false;
	}
	if (isNaN(tempNum)){
		alert(strMsg);
		return false;
	}
	if ((tempNum<7) || (tempNum>200)){
		alert(strMsg);
		return false;
	}
	if (!isInteger(tempNum))
	{
		alert(strMsg);
		return false;
	}
	return true;
}
function CheckYear(objDateField,strMsg){
	var tempNum;
	tempNum = trim(eval(objDateField).value);
	if(tempNum=="") {
		alert(strMsg);
		eval(objDateField).focus();								
		return false;
	}
	if (isNaN(tempNum)) {
		alert(strMsg);
		eval(objDateField).focus();
		return false;
	}
	if (tempNum<0)
	{
		alert(strMsg);
		eval(objDateField).focus();
		return false;
	}
	if (!isInteger(tempNum))
	{
		alert(strMsg);
		eval(objDateField).focus();
		return false;
	}
	if (tempNum.length!=4)
	{
		alert(strMsg);
		eval(objDateField).focus();
		return false;
	}
	if (tempNum<1900)
	{
		alert(strMsg);
		eval(objDateField).focus();
		return false;
	}
	return true;
}
//Purpose: check a variable is integer
function CheckInt(objDateField,strMsg)
{
	var tempNum;
	tempNum = trim(eval(objDateField).value);		
	if(tempNum=="") {
		alert(strMsg);
		eval(objDateField).focus();								
		return false;
	}	
	if (isNaN(tempNum)) {
		alert(strMsg);
		eval(objDateField).focus();
		return false;
	}
	if (tempNum<0)
	{
		alert(strMsg);
		eval(objDateField).focus();
		return false;
	}
	if (!isInteger(tempNum))
	{
		alert(strMsg);
		eval(objDateField).focus();
		return false;
	}
	return true;
}
function isInteger(s)
{   var i;
    for (i = 0; i < s.length; i++)
    {   
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}

//Purpose: check a variable is number
function CheckNumBer(objDateField,strMsg,valDefault) {
	var tempNum;
	// if valDefault=null 
	if ((!valDefault)&&(valDefault!=0)) valDefault='';	
	tempNum = trim(eval(objDateField).value);		
	// if valdefault='' or ='>0' and objDateField.value='' is not check
	if (((valDefault=='')||(valDefault=='>0'))&& (tempNum=="")) {
		eval(objDateField).value='';
		return true;
		}
		
	if(tempNum=="") {
		alert(strMsg);
		eval(objDateField).value=valDefault;
		return false;
	}		
	//PhuongTT 20081009
	//B1
	var _signcomm,_tempNum,_signques;
	_signcomm = tempNum.split(",");	
	_tempNum = tempNum.replace(',','');
	_signques = tempNum.indexOf(".");	
	if (isNaN(_tempNum) || _signcomm.length>2 || _signques>0) {	
	//E1
		alert(strMsg);
		if (valDefault=='>0') 
			eval(objDateField).value='';
		else 
			eval(objDateField).value=valDefault;
		return false;
	}
	if ((valDefault!='')||(valDefault=='0')) {
		var valDef=0;
		//if ((valDefault!='>0')&&(valDefault!='')) valDef=valDefault;
		if (parseInt(tempNum)<parseInt(valDef)) {
			alert(strMsg);
			if (valDefault=='>0') 
				eval(objDateField).value='';
			else 
				eval(objDateField).value=valDefault;
			return false;
		}
	}
	return true;
}
//Purpose: check a variable is positive number
function CheckPosNumBer(objDateField, strMsg) {
	var tempNum;
	tempNum = eval(objDateField).value;
	if ((isNaN(tempNum)) || (CheckNull(objDateField))) {
		alert(strMsg);
		eval(objDateField).value = "";
		eval(objDateField).focus();
		return false;
	}
	if (parseFloat(tempNum) <= 0) {
		return false;
	}
	return true;
}
   
//Purpose: check a variable is number
function CheckNum(obj) {
	var tempNum;
	tempNum = trim(eval(obj).value);
	if (tempNum=="") {
		eval(obj).focus();
		return false;
		}
	if (isNaN(tempNum)) {
		eval(obj).focus();
		return false;
	}	
	return true;	
}

function CheckNumAcceptNull(obj) {
    var tempNum;
    tempNum = trim(eval(obj).value);
    if (tempNum == "") {
        eval(obj).focus();
        return true;
    }
    if (isNaN(tempNum)) {
        eval(obj).focus();
        return false;
    }
    return true;
}

function GenRanNum(strIdlength)
{
var str;
str='';
for(i = 1;i<=strIdlength;i++){ 
	str=str + (String)(parseInt(9 * Math.random()+48));		
      } 
 return(str);
}

function GenURL(strIdlength){
	document.images["anh1"].src='../WChartDir.aspx?i=1&x='+GenRanNum(strIdlength);
	document.images["anh2"].src='../WChartDir.aspx?i=2&x='+GenRanNum(strIdlength);
}

function GenURL1(strIdlength){	
	document.images["anh1"].src='../Common/WChartDir.aspx?i=1&x='+GenRanNum(strIdlength);
}

function ReText(strin){
	if (strin.length>0){		
		strin=strin.replace('<U>','');
		strin=strin.replace('</U>','');
		strin=strin.replace('<u>','');
		strin=strin.replace('</u>','');		
	}
	return strin;
}

// This function used to check (uncheck) all checkBox on form
// Input: 
//		- strDtgName: name of datagrid 
//		- strOptionName: name of checkbox
//		- intMax: number of checkboxs on this form
// Output: no
function CheckAllOption(strDtgName, strOptionName, intMax){
	var intCounter;
	var blnStatus;
	blnStatus = eval('document.forms[0].' + strDtgName + '__ctl3_' + strOptionName).checked;
	if (blnStatus) {
		blnStatus = false;
	} else {
		blnStatus = true;
	}
    for(intCounter = 3; intCounter <= intMax + 2; intCounter++) {
		eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked = blnStatus;
    }
}

function CheckAllOptions(strDtgName, strOptionName, intStart, intMax){
	var intCounter;
	var blnStatus;
	blnStatus = eval('document.forms[0].' + strDtgName + '__ctl' + intStart + '_' + strOptionName).checked;
	if (blnStatus) {
		blnStatus = false;
	} else {
		blnStatus = true;
	}

    for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {
		eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked = blnStatus;
    }
}

function CheckAllOptions(strDtgName, strOptionName, strOptionCheckAll, intMax){	
	var intCounter;	
	var blnStatus;						
	if (eval('document.forms[0].'+ strOptionCheckAll).checked) 
		blnStatus = true;
	else
		blnStatus = false;		
	for(intCounter = 2; intCounter <= intMax + 1 ; intCounter++) {				  		
  		eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked = blnStatus;
  	}
}

// If find an check object, check, if not, through away

function CheckAllOptionsVisible(strDtgName, strOptionName, intStart, intMax) {
	var intCounter;	
	var blnStatus;	
	blnStatus = false;
					
	if (eval('document.forms[0].CheckAll')) {
		if (eval('document.forms[0].CheckAll').checked)
			blnStatus = true;
	}
	else {
		if (eval('document.forms[0].chkCheckAll')) {
			if (eval('document.forms[0].chkCheckAll').checked)
				blnStatus = true;
		}
	}	
		
	for (intCounter = intStart; intCounter <= intMax + intStart - 2; intCounter++) {
	    console.log(('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName));
	     if (intCounter < 10) {
	         if (eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName)) {

	             eval('document.forms[0].' + strDtgName + '_ctl0' + intCounter + '_' + strOptionName).checked = blnStatus;
	        }
	    } else {
	         if (eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName)) {

	             eval('document.forms[0].' + strDtgName + '_ctl' + intCounter + '_' + strOptionName).checked = blnStatus;
	        }
	    }
	}
}

function CheckAllOptionsVisibleByCssClass(cssClass, strOptionName, intStart, intMax) {
    var intCounter;
    var blnStatus;
    blnStatus = false;

    if (eval('document.forms[0].CheckAll')) {
        if (eval('document.forms[0].CheckAll').checked)
            blnStatus = true;
    }
    else {
        if (eval('document.forms[0].chkCheckAll')) {
            if (eval('document.forms[0].chkCheckAll').checked)
                blnStatus = true;
        }
    }
    $("." + cssClass).prop('checked', blnStatus);
   
}

function CheckOptionsNullByCssClass(cssClass, strOptionName, intStart, intMax, strMsg) {
    
    var intCount;

    intCount = 0;

    $("." + cssClass).each(function () {
        if ($(this).is(':checked')) {
            intCount += 1;
        }
    });
    if (intCount != 0) {
        return true;
    }
    else {
        alert(strMsg);
        return false;
    }
}

// This function used to check any checkbox on this form have been selected
// Input: 
//		- strDtgName: name of datagrid 
//		- strOptionName: name of checkbox
//		- intMax: number of checkboxs on this form
// Output: Boolean value
//		- true if atlease one checkbox selected
function CheckSelectedItemsOLD(strDtgName, strOptionName, intMax){
	var intCounter;
	var blnStatus;
	blnStatus = false;
	for(intCounter = 3; intCounter <= intMax + 2; intCounter++) {
		if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked) {
			blnStatus = true;
			break;
		}
    }
    return blnStatus;
}

function CheckSelectedItems(strDtgName, strOptionName, intStart, intMax){
	var intCounter;
	var blnStatus;
	blnStatus = false;
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {
		if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked) {
			blnStatus = true;
			break;
		}
    }
    return blnStatus;
}

// Purpose: Tao Popupwindow
// Input: 
//		- Url: dia chi trang			[string]
//		- Winname: ten cua so			[string]
//		- wWidth: do rong cua cua so	[number]
//		- wHeigth: chieu cao cua co so	[number]
//		- wTop:							[number]
//		- wLeft:						[number]
//		- wScrollbar:('yes','no')		[string]
//		- strOthers: cac tham so khac (chu y cac tham so cach nhau bang dau ";")
//				  menubar,status,resizable,center
//		- Modal: (1:dung ShowModal; 0: dung open) [number]
function openModal(Url,Winname,wWidth,wHeight,wLeft,wTop,wScrollbar,strOthers,Modal){
	if (Modal==1){
		// read name browser
		if (navigator.appName.toLowerCase().indexOf('microsoft internet explorer')>=0 || navigator.appName.toLowerCase().indexOf('internet explorer')>=0){ 
			// IE Browser
			if (strOthers.length>0)	
					strOthers=';' + strOthers;	
			if (wScrollbar.toLowerCase()=='no')
					strOthers=strOthers + ';scroll=no'; 
			if (Url.indexOf("?") >= 0) 
					Url = Url + "&modal=1"; 
			else 
					Url = Url + "?modal=1"	;
			dialogWindow = window.showModalDialog(Url,top,'dialogWidth=' + wWidth + 'px;dialogHeight=' + wHeight + 'px' + ';dialogLeft=' + wLeft + ';dialogTop=' + wTop + strOthers); 
		}else{ 
			// Any other browsers 
			if (Url.indexOf("?") >= 0) 
				Url = Url + "&modal=0";
			else 
				Url = Url + "?modal=0";
			if (strOthers.length>0){
				strOthers.replace(';',',');
				strOthers=',' + strOthers;
			}
			if (wScrollbar.toLowerCase()=='no')
				strOthers=strOthers + ',scrollbars=no';
			else
				strOthers=strOthers + ',scrollbars=yes';
			dialogWindow=window.open(Url,Winname,'height=' + wHeight +',width=' + wWidth + ',screenX=' + wLeft + ',screenY=' + wTop + strOthers);
		}
	}else{
			if (Url.indexOf("?") >= 0) 
				Url = Url + "&modal=0";
			else 
				Url = Url + "?modal=0";
		if (strOthers.length>0){
			strOthers =strOthers.replace(';',',');
			strOthers=',' + strOthers;
		}		
		if (wScrollbar.toLowerCase()=='no')
			strOthers=strOthers + ',scrollbars=no';
		else
			strOthers=strOthers + ',scrollbars=yes';
		dialogWindow=window.open(Url,Winname,'height=' + wHeight + ',width=' + wWidth + ',top=' + wTop + ',left=' + wLeft + ',screenX=' + wLeft + ',screenY=' + wTop + strOthers);
	}
}

function setOpener(){
	if (self.location.href.toLowerCase().indexOf("modal=1") >= 0){
		opener = window.dialogArguments;
	}	
}

function swapBG(btn, BG2) {
		if (iebrower) {		
		tmp=btn.parentElement.parentElement.style.backgroundColor;				
		if (BG2!=tmp) 
			BG1=btn.parentElement.parentElement.style.backgroundColor;
		btn.parentElement.parentElement.style.backgroundColor=(btn.parentElement.parentElement.style.backgroundColor==BG2) ?   BG1 : BG2 ;
		}
}
function SetBG(obj, BG) {		
		obj.parentElement.parentElement.style.backgroundColor=BG ;
	}
	
function Print(){
	self.focus();
    setTimeout('self.print()', 1);
}

//COPY from libolcommon 5.5
function Esc(inval, utf) {
	inval = escape(inval);
	if (utf == 0) 	{
		return inval;
	}
	outval = "";
	while (inval.length > 0) {
		p = inval.indexOf("%"); 
		if (p >= 0) {
			if (inval.charAt(p + 1) == "u") {
				outval = outval + inval.substring(0, p) + JStoURLEncode(eval("0x" + inval.substring(p + 2, p + 6)));
				inval = inval.substring(p +6, inval.length);
			} else {
				outval = outval + inval.substring(0, p) + JStoURLEncode(eval("0x" + inval.substring(p + 1, p + 3)));
				inval = inval.substring(p + 3, inval.length);
			}
		} else {
			outval = outval + inval;
			inval = "";
		}
	}
	return outval;
}
function JStoURLEncode(c) {
	if (c < 0x80) {
	    return Hexamize(c);
	} else if (c	< 0x800) {
		return Hexamize(0xC0 | c>>6) + Hexamize(0x80 | c & 0x3F);
    } else if (c < 0x10000) {
		return Hexamize(0xE0 | c>>12) + Hexamize(0x80 | c>>6 & 0x3F) + Hexamize(0x80 | c & 0x3F);
    } else if  (c < 0x200000) {
		return Hexamize(0xF0 | c>>18) + Hexamize(0x80 | c>>12 & 0x3F) + Hexamize(0x80 | c>>6 & 0x3F) + Hexamize(0x80 | c & 0x3F);
    } else {
		return '?'		// Invalid character
    }
}

function Hexamize(n) {
	hexstr = "0123456789ABCDEF";
	return "%" + hexstr.charAt(parseInt(n/16)) + hexstr.charAt(n%16);
}


function setPgb(pgbID, pgbValue) {	
	if (pgbObj = document.getElementById(pgbID))
		pgbObj.width = pgbValue + '%'; // increase the progression by changing the width of the table
	if (lblObj = document.getElementById(pgbID+'_label'))
		lblObj.innerHTML = pgbValue + '%'; // change the label value
}

/*
	CompareDate function
*/
function CompareDate(objDateField1, objDateField2, strDateFormat){
	//Return 0 if objDateField1 > objDateField2, 2 objDateField1 = objDateField2, 1: objDateField1 < objDateField2
	strDateFormat = strDateFormat.toLowerCase();	
	var mdateval1 = eval(objDateField1).value;	
	var mdateval2 = eval(objDateField2).value;
	switch(strDateFormat){
		case 'dd/mm/yyyy':
				if (mdateval1 != "") {
					mday = mdateval1.substring(0, mdateval1.indexOf("/"));
					mmonth = mdateval1.substring(mdateval1.indexOf("/") + 1, mdateval1.lastIndexOf("/"));
					myear = mdateval1.substring(mdateval1.lastIndexOf("/") + 1, mdateval1.length);
					mdate1 = new Date (mmonth + "/" + mday + "/" + myear);
					
					mday = mdateval2.substring(0, mdateval2.indexOf("/"));
					mmonth = mdateval2.substring(mdateval2.indexOf("/") + 1, mdateval2.lastIndexOf("/"));
					myear = mdateval2.substring(mdateval2.lastIndexOf("/") + 1, mdateval2.length);
					mdate2 = new Date (mmonth + "/" + mday + "/" + myear);					
					if (mdate1.getTime() > mdate2.getTime()) {
						return 0;
					}
					else
					{
						if (mdate1.getTime() == mdate2.getTime()) return 2;
					}					
				}
				break;
		case 'mm/dd/yyyy':
				if (mdateval1 != "") {
					mmonth = mdateval1.substring(0, mdateval1.indexOf("/"));
					mday = mdateval1.substring(mdateval1.indexOf("/") + 1, mdateval1.lastIndexOf("/"));
					myear = mdateval1.substring(mdateval1.lastIndexOf("/") + 1, mdateval1.length);
					mdate1 = new Date (mmonth + "/" + mday + "/" + myear);
					
					mmonth = mdateval2.substring(0, mdateval2.indexOf("/"));
					mday = mdateval2.substring(mdateval2.indexOf("/") + 1, mdateval2.lastIndexOf("/"));
					myear = mdateval2.substring(mdateval2.lastIndexOf("/") + 1, mdateval2.length);
					mdate2 = new Date (mmonth + "/" + mday + "/" + myear);
					if (mdate1.getTime() > mdate2.getTime()) {
						return 0;
					}
					else
					{
						if (mdate1.getTime() == mdate2.getTime()) return 2;
					}					

				}
				break;
	}
	return 1;
}	

function CheckformZ3950(strServer,strPort,strDatabase,strEmpty,strErrNum) {	
	if(trim(document.forms[0].txtzServer.value)=="") {
		alert(strServer);
		document.forms[0].txtzServer.focus();			
		return false;
		}
	if(trim(document.forms[0].txtZPort.value)=="") {
		alert(strPort);
		document.forms[0].txtZPort.focus();			
		return false;
		}
	if (isNaN(document.forms[0].txtZPort.value)) {
		alert(strErrNum);
		document.forms[0].txtZPort.focus();			
		return false;
	}
	if(trim(document.forms[0].txtZDatabase.value)=="") {
		alert(strDatabase);
		document.forms[0].txtZDatabase.focus();			
		return false;
		}
	if(trim(document.forms[0].txtFieldValue1.value + ' ' + document.forms[0].txtFieldValue2.value + ' ' + document.forms[0].txtFieldValue3.value)=="") {
		alert(strEmpty);
		document.forms[0].txtFieldValue1.focus();			
		return false;
		}
	return true;
}
function CheckForSubmit(strNote,strErrNum) {
		if(document.forms[0].txtzServer.value=="") {
			alert(strNote);
			document.forms[0].txtzServer.focus();	
			return false;		
			}
		else 
		if(document.forms[0].txtZPort.value=="") {
			alert(strNote);
			document.forms[0].txtZPort.focus();	
			return false;		
			}
		else 
		if(document.forms[0].txtZDatabase.value=="") {
			alert(strNote);
			document.forms[0].txtZDatabase.focus();	
			return false;		
			}
		else 		
		if(document.forms[0].txtFieldValue1.value=="") {
			alert(strNote);
			document.forms[0].txtFieldValue1.focus();	
			return false;		
			}		
	return true;
}	
function BackPage() {
	top.history.back();
}
function ForwardPage() {
	top.history.forward();
}
function Comma(Num) { //function to add commas to textboxes
    Num += '';
    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
    x = Num.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1))
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    return x1 + x2;
}
function CheckNumBerCurrency(objDateField, strMsg, valDefault) {
    var tempNum;
    // if valDefault=null 
    if ((!valDefault) && (valDefault != 0)) valDefault = '';
    tempNum = trim(eval(objDateField).value);
    // if valdefault='' or ='>0' and objDateField.value='' is not check
    if (((valDefault == '') || (valDefault == '>0')) && (tempNum == "")) {
        eval(objDateField).value = '';
        return true;
    }

    if (tempNum == "") {
        alert(strMsg);
        eval(objDateField).value = valDefault;
        return false;
    }
    //PhuongTT 20081009
    //B1
    var _signcomm, _tempNum;
    _signcomm = tempNum.split(",");
    _tempNum = tempNum.replace('.', '');
    //_signques = tempNum.indexOf(".");
    if (isNaN(_tempNum) || _signcomm.length > 2) {
        //E1
        alert(strMsg);
        if (valDefault == '>0')
            eval(objDateField).value = '';
        else
            eval(objDateField).value = valDefault;
        return false;
    }
    if ((valDefault != '') || (valDefault == '0')) {
        var valDef = 0;
        //if ((valDefault!='>0')&&(valDefault!='')) valDef=valDefault;
        if (parseInt(tempNum) < parseInt(valDef)) {
            alert(strMsg);
            if (valDefault == '>0')
                eval(objDateField).value = '';
            else
                eval(objDateField).value = valDefault;
            return false;
        }
    }
    return true;
}