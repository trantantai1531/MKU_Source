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

function trim(str){
	return 	str.replace(/^\s*|\s*$/g,"");
}

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
	//User:NVK
	//Date:29/8/2003
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
					if ((parseFloat(mday) != parseFloat(cday)) || (parseFloat(mmonth) != parseFloat(cmonth))|| (isNaN(myear)) || (myear.length < 4) || (myear.length>4) || (myear<1753)) 
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
    objEmail.focus(); 
    objEmail.select(); 
    return false; 
  } else { 
    if(str.indexOf("@") >= 0) 
      return true;     
    objEmail.focus(); 
    objEmail.select(); 
    return false; 
  } 
} 

/* Check value is empty
	if obj's value is null return true 
	else return false
*/
function CheckNull(obj){			
    strValue=eval(obj).value;
    if (strValue == "") {
		this.value = '';
		this.focus();
		return true;
    }
    else {
      Status = 0;
      for (i = 0; i < strValue.length; i++) {
        if (strValue.charAt(i) != " ") {
           Status = 1;
           break;                      
        }
      }         
      if (Status == 0) {          
	      return true;
      }
      else {
		this.value = '';
		this.focus();      
		return false;
      }
    }
}


function OpenWindow(strUrl,strWinname,intWidth,intHeight,intLeft,intTop){
		popUp = window.open(strUrl,strWinname, "width=" + intWidth + ",height=" + intHeight + ",left=" + intLeft+ ",top=" + intTop+ ",menubar=yes,resizable=no,scrollbars=yes");
		popUp.focus();
}
//====================================================================
//Used to remove old item in SelectBox..
//User:DPS
//Date:30/8/2003
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

function  SetFocus(control)
{
    control.focus();
}
    
function CheckNumBer(objDateField,strMsg) {
	var tempNum;
	tempNum = eval(objDateField).value;
	if ((isNaN(tempNum)) || (CheckNull(objDateField))) {
		alert(strMsg);
		eval(objDateField).value = "";
		eval(objDateField).focus();
		return false;
	}
	return true;
}

//By: Hungdp
//Date: 11/09/2003
//Purpose: check a variable is number
function CheckNum(obj) {
	var tempNum;
	tempNum = eval(obj).value;
	if ((isNaN(tempNum)) || (CheckNull(obj))) {
		eval(obj).focus();
		eval(obj).value='';
		return false;
	} else {
		return true;
	}
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
// Created by: Oanhtn
// Created date: 3/10/2003
// Last modified date: 3/10/2003
// Input: 
//		- strDtgName: name of datagrid 
//		- strOptionName: name of checkbox
//		- intMax: number of checkboxs on this form
// Output: no
function CheckAllOption(strDtgName, strOptionName, intMax){
	var intCounter;
	var blnStatus;
	alert(intMax);
	blnStatus = eval('document.forms[0].' + strOptionName).checked;
	//blnStatus = eval('document.forms[0].' + strDtgName + '__ctl3_' + strOptionName).checked;
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

// If find an check object, check, if not, through away

function CheckAllOptionsVisible(strDtgName, strOptionName, intStart, intMax){	
	var intCounter;	
	var blnStatus;					
	
	if (eval('document.forms[0].CheckAll').checked) 
		blnStatus = true;
	else
		blnStatus = false;		
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName))
		{
			eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked = blnStatus;			
		}			
	}
}

// This function used to check any checkbox on this form have been selected
// Created by: Oanhtn
// Created date: 3/10/2003
// Last modified date: 3/10/2003
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

// Created date: 29/10/2003
// Last modified date: 29/10/2003
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
// Creator: dgsoft2016
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
// Creator: dgsoft2016
// Hoan doi mau nen cho mot object, co the la mot dong trong Datagrid
function swapBG(btn, BG2) {		
		tmp=btn.parentElement.parentElement.style.backgroundColor;		
		if (BG2!=tmp) 
			BG1=btn.parentElement.parentElement.style.backgroundColor;
		btn.parentElement.parentElement.style.backgroundColor=(btn.parentElement.parentElement.style.backgroundColor==BG2) ?   BG1 : BG2 ;
}
function SetBG(obj, BG) {		
		obj.parentElement.parentElement.style.backgroundColor=BG ;
	}
	
function Print(){
	self.focus();
    setTimeout('self.print()', 1);
}

//COPY from eMicLibcommon 5.5
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
// add by lent: these function support to loading searched
function GetValueField(objField,strParameter) {
	var str=strParameter+"=";
	if(eval("document.forms[0]."+objField)) {
		if(eval("document.forms[0]."+objField).value!="") 
			str=str+replaceSubstring(eval("document.forms[0]."+objField).value,'&','^');
	}
	str=str+"&";
	return str;	
}
function GetValueFieldAdvance(intid) {
	var str="";
	var idSelected=0;
	var intPrefix=1;	
	if(intid!="5") {		
		if (eval("document.forms[0].ddlPrefix"+intid)) {
			intPrefix = eval("document.forms[0].ddlPrefix"+intid).selectedIndex;
			}
		if(eval("document.forms[0].txtFieldValue"+intid).value!="") {
			idSelected=eval("document.forms[0].ddlFieldName"+intid).selectedIndex;
			str=str+eval("document.forms[0].ddlFieldName"+intid+".options["+idSelected+"]").value+"&";
			switch (intPrefix) {
				case 0:
					str=str+eval("document.forms[0].ddlFieldName"+intid+".options["+idSelected+"]").text+"=%"+eval("document.forms[0].txtFieldValue"+intid).value+"%&";
					break;
				case 1:
					str=str+eval("document.forms[0].ddlFieldName"+intid+".options["+idSelected+"]").text+"="+eval("document.forms[0].txtFieldValue"+intid).value+"&";
					break;
				case 2:
					str=str+eval("document.forms[0].ddlFieldName"+intid+".options["+idSelected+"]").text+"="+eval("document.forms[0].txtFieldValue"+intid).value+"%&";
					break;
				case 3:
					str=str+eval("document.forms[0].ddlFieldName"+intid+".options["+idSelected+"]").text+"=%"+eval("document.forms[0].txtFieldValue"+intid).value+"&";
					break;
				case 4:
					str=str+eval("document.forms[0].ddlFieldName"+intid+".options["+idSelected+"]").text+"=>="+eval("document.forms[0].txtFieldValue"+intid).value+"&";
					break;
				case 5:
					str=str+eval("document.forms[0].ddlFieldName"+intid+".options["+idSelected+"]").text+"=<="+eval("document.forms[0].txtFieldValue"+intid).value+"&";
					break;
				case 6:
					str=str+eval("document.forms[0].ddlFieldName"+intid+".options["+idSelected+"]").text+"=>="+eval("document.forms[0].txtFieldValue"+intid).value+"&";
					break;
				case 7:
					str=str+eval("document.forms[0].ddlFieldName"+intid+".options["+idSelected+"]").text+"=<="+eval("document.forms[0].txtFieldValue"+intid).value+"&";
					break;
				}
			if(intid=="1") str=str+"AND&";
			else {
				idSelected=eval("document.forms[0].ddlOperator"+intid).selectedIndex;
				str=str+eval("document.forms[0].ddlOperator"+intid+".options["+idSelected+"]").value+"&";
				}		
			}
		}		
	else {					
			if (document.forms[0].ddlFormat.selectedIndex>0) {
				str=str+"ItemType&ItemType="+document.forms[0].ddlFormat.options[document.forms[0].ddlFormat.selectedIndex].value+"&AND&";		
				}								
			}
	return str;	
}

function SetArrSearchedSymbol(ContentType,ItemType,FieldName,FieldValue,SortBy,Display,SelectTop) {	
	var strtemp="Content="+ContentType+"&";
	var intCount=0;
	var strtmp="";

	strtemp=strtemp + "ItemType=" + ItemType +"&";
	strtemp=strtemp + "SearchMode=single&";	
		
	if (FieldName == 'Author')
	{
		strtemp=strtemp + "DDC_BBK=&";
		strtemp=strtemp + "UDC=&";
		strtemp=strtemp + "NSC=&";
		strtemp=strtemp + "KeyWord=&";
		strtemp=strtemp + "SubjectHeading=&";
	}
	else if (FieldName == 'DDC_BBK')
	{
		strtemp=strtemp + "Author=&";
		strtemp=strtemp + "UDC=&";
		strtemp=strtemp + "NSC=&";
		strtemp=strtemp + "KeyWord=&";
		strtemp=strtemp + "SubjectHeading=&";
	}
	else if (FieldName == 'UDC')
	{
		strtemp=strtemp + "DDC_BBK=&";
		strtemp=strtemp + "Author=&";
		strtemp=strtemp + "NSC=&";
		strtemp=strtemp + "KeyWord=&";
		strtemp=strtemp + "SubjectHeading=&";
	}
	else if (FieldName == 'NSC')
	{
		strtemp=strtemp + "DDC_BBK=&";
		strtemp=strtemp + "UDC=&";
		strtemp=strtemp + "Author=&";
		strtemp=strtemp + "KeyWord=&";
		strtemp=strtemp + "SubjectHeading=&";
	}
	else if (FieldName == 'KeyWord')
	{
		strtemp=strtemp + "DDC_BBK=&";
		strtemp=strtemp + "UDC=&";
		strtemp=strtemp + "NSC=&";
		strtemp=strtemp + "Author=&";
		strtemp=strtemp + "SubjectHeading=&";
	}
	else if (FieldName == 'SubjectHeading')
	{
		strtemp=strtemp + "KeyWord=&";
		strtemp=strtemp + "DDC_BBK=&";
		strtemp=strtemp + "UDC=&";
		strtemp=strtemp + "NSC=&";
		strtemp=strtemp + "Author=&";
	}
	
	strtemp=strtemp + FieldName + "=" + FieldValue +"&";
	strtemp=strtemp + "SortBy=" + SortBy +"&";
	strtemp=strtemp + "SelectTop=" + SelectTop + "&";
	strtemp=strtemp+ "Display="+Display;
	
	///////////////////////////////////////////////////////////////////	
	if(parent.HiddenSaveIDs.document.forms[0].txtArrSearched.value!="") 
		parent.HiddenSaveIDs.document.forms[0].txtArrSearched.value=parent.HiddenSaveIDs.document.forms[0].txtArrSearched.value+"|"+strtemp;
	else parent.HiddenSaveIDs.document.forms[0].txtArrSearched.value=strtemp;
	
	parent.HiddenSaveIDs.document.forms[0].submit();
}

function SetArrSearched(ContentType,ItemType,SearchMode) {	
	var strtemp="Content="+ContentType+"&";
	var intCount=0;
	var strtmp="";

	switch (SearchMode.toLowerCase()) {
		case "detail":
			strtemp=strtemp+"ItemType="+ItemType+"&";
			strtemp=strtemp+"SearchMode="+SearchMode+"&";		
			strtemp=strtemp+GetValueField("txtTitle","Title");
			strtemp=strtemp+GetValueField("txtAuthor","Author");
			strtemp=strtemp+GetValueField("txtIndexDDC","DDC_BBK");
			strtemp=strtemp+GetValueField("txtPublisher","Publisher");
			strtemp=strtemp+GetValueField("txtLangague","Language");
			strtemp=strtemp+GetValueField("txtKeyWord","KeyWord");
			strtemp=strtemp+GetValueField("txtPubYear","PublishYear");	
			strtemp=strtemp+GetValueField("txtSpeciality","ThesisSubject");
			strtemp=strtemp+GetValueField("txtHeightFrom","MinHeigthImage");
			strtemp=strtemp+GetValueField("txtHeightTo","MaxHeigthImage");	
			strtemp=strtemp+GetValueField("txtWidthFrom","MinWidthImage");
			strtemp=strtemp+GetValueField("txtWidthTo","MaxWidthImage");
			strtemp=strtemp+GetValueField("txtMaxSizeFrom","MinSizeImage");
			strtemp=strtemp+GetValueField("txtMaxSizeTo","MaxSizeImage");
			strtemp=strtemp+GetValueField("txtMaxResFrom","MinResImage");
			strtemp=strtemp+GetValueField("txtMaxResTo","MaxResImage");
			strtemp=strtemp+GetValueField("txtList","TabOfContents");
			strtemp=strtemp+GetValueField("txtIssue","IssueNo");
			strtemp=strtemp+GetValueField("txtVolumn","Vol");
			strtemp=strtemp+GetValueField("txtFromDate","FromEdeliveryDate");
			strtemp=strtemp+GetValueField("txtToDate","ToEdeliveryDate");
			strtemp=strtemp+GetValueField("txtISBN","ISBN");
			strtemp=strtemp+GetValueField("txtISSN","ISSN");			
	
			strtemp=strtemp+"BitmapType=";
			if(eval('document.forms[0].ddlColor'))
				if(document.forms[0].ddlColor.selectedIndex>0)
					strtemp=strtemp+document.forms[0].ddlColor.options[document.forms[0].ddlColor.selectedIndex].value;
			strtemp=strtemp+"&";
		
			strtemp=strtemp+"ColorMode="
			if(eval('document.forms[0].ddlTypeColor'))
				if(document.forms[0].ddlTypeColor.selectedIndex>0)
					strtemp=strtemp+document.forms[0].ddlTypeColor.options[document.forms[0].ddlTypeColor.selectedIndex].value;
			strtemp=strtemp+"&";	
		
			strtemp=strtemp+"SortBy=";
			if(eval('document.forms[0].ddlSort'))
				if(document.forms[0].ddlSort.selectedIndex>0)
					strtemp=strtemp+document.forms[0].ddlSort.options[document.forms[0].ddlSort.selectedIndex].value;
			strtemp=strtemp+"&";

			if(eval('document.forms[0].ddlLimit')){
				if(document.forms[0].ddlLimit.selectedIndex>0)
					strtemp=strtemp+"SelectTop="+document.forms[0].ddlLimit.options[document.forms[0].ddlLimit.selectedIndex].value+"&";
				else 
					strtemp=strtemp+"SelectTop=1000&";
				}						
			break;
		case "advance":
			intCount=0;
			strtmp= GetValueFieldAdvance("1");
			if(strtmp!="") {
				intCount=intCount+1;
				strtemp=strtemp+strtmp;			
				}
			strtmp= GetValueFieldAdvance("2");
			if(strtmp!="") {
				intCount=intCount+1;
				strtemp=strtemp+strtmp;			
				}
			strtmp= GetValueFieldAdvance("3");
			if(strtmp!="") {
				intCount=intCount+1;
				strtemp=strtemp+strtmp;			
				}
			strtmp= GetValueFieldAdvance("4");
			if(strtmp!="") {
				intCount=intCount+1;
				strtemp=strtemp+strtmp;			
				}

			strtmp= GetValueFieldAdvance("5");		
			if(strtmp!="") {
				intCount=intCount+1;
				strtemp=strtemp+strtmp;			
				}
			strtemp="adv&"+intCount+"&"+strtemp;
			strtemp=strtemp+"SortBy=";
			if(eval('document.forms[0].ddlSort'))
				if(document.forms[0].ddlSort.selectedIndex>0)
					strtemp=strtemp+document.forms[0].ddlSort.options[document.forms[0].ddlSort.selectedIndex].value;
			strtemp=strtemp+"&";			
			break;
		case "z3950":
			intCount=0;
			strtemp=strtemp+GetValueField("txtzServer","Host");
			strtemp=strtemp+GetValueField("txtZPort","Port");
			strtemp=strtemp+GetValueField("txtZDatabase","Database");
			if (eval('document.forms[0].chkVietUSMARC').checked) 
				strtemp=strtemp+"VietUSMARC=True&";
			else
				strtemp=strtemp+"VietUSMARC=False&";

			strtmp= GetValueFieldAdvance("1");
			if(strtmp!="") {
				intCount=intCount+1;
				strtemp=strtemp+strtmp;			
				}
			strtmp= GetValueFieldAdvance("2");
			if(strtmp!="") {
				intCount=intCount+1;
				strtemp=strtemp+strtmp;			
				}
			strtmp= GetValueFieldAdvance("3");
			if(strtmp!="") {
				intCount=intCount+1;
				strtemp=strtemp+strtmp;			
				}
			strtemp="z3950&"+intCount+"&"+strtemp;
			break;
		case "fulltext":
			strtemp="fulltext&"+strtemp+GetValueField("txtSearch","Keyword");
			break;
	}	
	
	//process drop down list		
	if (eval('document.forms[0].optISBD')) {
		if (eval('document.forms[0].optISBD').checked) {
			strtemp=strtemp+"Display=ISBD";
		}
		else {
			if (eval('document.forms[0].optSimple').checked)
				strtemp=strtemp+"Display=Simple";
			else 
				strtemp=strtemp+"Display=MARC";
			}
		}
	///////////////////////////////////////////////////////////////////	
	if(parent.HiddenSaveIDs.document.forms[0].txtArrSearched.value!="") 
		parent.HiddenSaveIDs.document.forms[0].txtArrSearched.value=parent.HiddenSaveIDs.document.forms[0].txtArrSearched.value+"|"+strtemp;
	else parent.HiddenSaveIDs.document.forms[0].txtArrSearched.value=strtemp;
	//alert(parent.HiddenSaveIDs.document.forms[0].txtArrSearched.value);	
	parent.HiddenSaveIDs.document.forms[0].submit();
}
function SetOnSimpleAdvance(SearchMode) {
	var content="";
	var ItemType="";
	content=document.forms[0].ddlFormat.options[document.forms[0].ddlFormat.selectedIndex].text;
	if (document.forms[0].ddlFormat.selectedIndex>0)
		ItemType=document.forms[0].ddlFormat.options[document.forms[0].ddlFormat.selectedIndex].value;
	SetArrSearched(content,ItemType,SearchMode);
}

function replaceSubstring(inputString, fromString, toString) {
// Goes through the inputString and replaces every occurrence of fromString with toString
temp = inputString;
	if(fromString == "") {
		return(inputString);
	}
		if(toString.indexOf(fromString) == -1) {// If the string being replaced is not a part of the replacement string (normal situation)
			while(temp.indexOf(fromString) != -1){
				var toTheLeft = temp.substring(0,temp.indexOf(fromString));
				var toTheRight = temp.substring(temp.indexOf(fromString)+fromString.length,temp.length);
				temp = toTheLeft + toString + toTheRight;
			}
	}else {// String being replaced is part of replacement string (like "+" being replaced with "++") - prevent aninfinite loop
		var midStrings = Array("~","`","_", "^","#");
		var midStringLen = 1;
		var midString = "";// Find a string that doesn't exist in the inputString to be usedas an "inbetween" string
		while (midString == "") {
			for (var i=0; i < midStrings.length; i++) {
				var tempMidString = "";
					for (var j=0; j < midStringLen; j++) { 
						tempMidString += midStrings[i]; }
					if (fromString.indexOf(tempMidString) == -1) {
						midString = tempMidString;
						i = midStrings.length + 1;
					}
			}
		}
		// Keep on going until we build an "inbetween" string that doesn't exist
		// Now go through and do two replaces - first, replace the "fromString" with the "inbetween" string
		while (temp.indexOf(fromString) != -1) {
			var toTheLeft = temp.substring(0, temp.indexOf(fromString));
			var toTheRight =temp.substring(temp.indexOf(fromString)+fromString.length,temp.length);
			temp = toTheLeft + midString + toTheRight;
		}
	// Next, replace the "inbetween" string with the "toString"
		while (temp.indexOf(midString) != -1) {
			var toTheLeft = temp.substring(0,temp.indexOf(midString));
			var toTheRight = temp.substring(temp.indexOf(midString)+midString.length,temp.length);
			temp = toTheLeft + toString + toTheRight;
		}
	}
// Ends the check to see if the string being replaced is part of the replacement string or not
	return temp;
	// Send the updated string back to the user
}
/*
	CompareDate function
*/
function CompareDate(mdateval1, mdateval2, strDateFormat){
	strDateFormat = strDateFormat.toLowerCase();	
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
