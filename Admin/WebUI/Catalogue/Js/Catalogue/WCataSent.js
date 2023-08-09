/*
	CurTime function & its variables
	Purpose: print the current time into txtTime
	CreatedDate: 27/03/2004 by Oanhtn
*/

DOW = new Array (7);
DOW[0] = "Sun";
DOW[1] = "Mon";
DOW[2] = "Tue";
DOW[3] = "Wed";
DOW[4] = "Thu";
DOW[5] = "Fri";
DOW[6] = "Sat";

MOY = new Array (12);
MOY[0] = "Jan";
MOY[1] = "Feb";
MOY[2] = "Mar";
MOY[3] = "Apr";
MOY[4] = "May";
MOY[5] = "Jun";
MOY[6] = "Jul";
MOY[7] = "Aug";
MOY[8] = "Sep";
MOY[9] = "Oct";
MOY[10] = "Nov";
MOY[11] = "Dec";

function CurTime() {
	TheTime = new Date();
	Year = TheTime.getYear();
	DispTime = DOW[parseInt(TheTime.getDay())] + " " + TheTime.getDate() + " " + MOY[parseInt(TheTime.getMonth())] + " " + Year + " " + TheTime.getHours() + ":" + TheTime.getMinutes() + ":" + TheTime.getSeconds();
	document.forms[0].txtTime.value = DispTime;
	TimeID = setTimeout ("CurTime()", 1000);
}

/*
	CheckNullValue function
	Purpose: Check null value of the selected form' control 
	CreatedDate: 27/03/2004 by Oanhtn
*/

function CheckNullValue(objField, strFieldName, strMess1, strMess2) {
	var strValue;
	strValue = objField.value;
    for (i = 0; i < strValue.length; i++) {
         if (objField.value.charAt(i) != " ") {
	         return false;
         }
    }
    alert (strMess1 + ": " + strFieldName + ".\n" + strMess2 + ".")    
    parent.Workform.focus();
	eval("parent.Workform.document.forms[0]." + objField.name + ".focus()");
    return true;
}

/*
	CheckAll function
	Purpose: Check null value of all form' controls
	CreatedDate: 27/03/2004 by Oanhtn

function CheckAll1(strMess1, strMess2, strMess3, strCheckValue) {
		parent.Workform.focus();
		self.focus();
		//if (CheckNullValue(document.forms[0].txtLeader, strMess3, strMess1, strMess2)) { return; }
		//strCheckValue
		ValidateMARC(1, 0);
}

/*
	ValidateMARC function
	Purpose: validate all value of form' controls
	CreatedDate: 27/03/2004 by Oanhtn
*/
function getUrlVars() {
    var vars = {};
    var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi,
    function (m, key, value) {
        vars[key] = value;
    });
    return vars;
}

function ValidateMARC(intUpdate, intIsUpdate) {
	parent.Workform.focus();
	self.focus();
	document.forms[0].txtUpdateNow.value = intUpdate;
	document.forms[0].target = "Hiddenbase";
	document.forms[0].action = "WMarcValid.aspx";	
	document.forms[0].submit();	
	document.forms[0].target = "Workform";
	var isCopy = getUrlVars()["IsCopy"];
	if (intIsUpdate === 0) {

		document.forms[0].action = "WCataPut.aspx";
	} else {
	    document.forms[0].action = "WCataUpdate.aspx?Holding=1&IsCopy=" + isCopy; // if holdding == 1 redirect xep gia

	}
	console.log(intIsUpdate);
	console.log(document.forms[0].action);
}

/*
	AddField function
	Purpose: open new window to add some more field
	CreatedDate: 27/03/2004 by Oanhtn
*/
function AddFields() {	
	parent.Workform.focus();
	self.focus();
	OpenWindow('WAddField.aspx','AddFieldsWin',600,300,100,100);
}

/*
	LoadFromCMS function
	Purpose: Open new window to load available data from CMS
	CreatedDate: 27/03/2004 by Oanhtn
*/
function LoadFromCMS() {
	//parent.Workform.focus();
	//self.focus();
	OpenWindow('WCataLoadCMS.aspx','CMSWin',600,300,100,100);	
}

/*
	SpellCheck function
	Purpose: Open new window to check spelling for values of all form' control
	CreatedDate: 27/03/2004 by Oanhtn
	
*/
function SpellCheck() {
	parent.Workform.focus();
	self.focus();
	OpenWindow('','SpellCheckWin',600,340,100,100);
	document.forms[0].target = "SpellCheckWin";
	document.forms[0].action = "WCataCheckSpell.aspx";
	document.forms[0].submit();
	document.forms[0].target = "Workform";
	document.forms[0].action = "WCataPut.aspx";
	//SpellCheckWin = window.open("", "SpellCheckWin", "width=600,height=340,resizable,menubar=yes,scrollbars=yes,screenX=100,screenY=100,top=100,left=100");
	//SpellCheckWin.focus();
}
function ResetForm(strMsg)
{	
	
	 if ( confirm (strMsg)) 
	 {
		parent.Workform.document.forms[0].reset();
		for (intCounter = 1; intCounter < arrFieldCode.length; intCounter++) {											
			if ((arrFieldCode[intCounter]!='900') && (arrFieldCode[intCounter]!='911') )
			{				
				eval("document.forms[0].tag" + arrFieldCode[intCounter]).value='';		
				arrFieldValue[intCounter] = '';
			}
			//else
			//{				
			//	eval("parent.Workform.document.forms[0].tag" + arrFieldCode[intCounter]).value=1;		
			//}
			//if (arrFieldCode[intCounter]='911')				
			//{
			//	eval("parent.Workform.document.forms[0].tag" + arrFieldCode[intCounter]).value='';		
			//}
		}		
		return false;
	} 
	else 
	{ 
		return false;
	} 
}
/*
	Preview function
	Purpose: display preview windows
	Creator: Oanhtn
	CreatedDate: 26/05/2004	
*/
function Preview() {
	// Declare variables
	var intCounter;
	var intNOR;
	var intSubIndex;
	var intPosition;
	var strIndicators;
	var strFieldValue;
	var strFieldCode;
	var records = new Array();
	arrFieldCode[0] = "Ldr";
    arrFieldValue[0] = document.forms[0].txtLeader.value;
    for (intCounter = 1; intCounter < arrFieldCode.length; intCounter++) {
		arrFieldValue[intCounter] = eval("document.forms[0].tag" + arrFieldCode[intCounter]).value;				
    }
	// Write windows
	parent.Workform.focus();
	self.focus();
	PrevieWin = window.open("", "PrevieWin", "width=600,height=380,resizable,scrollbars=yes,menubar=yes,screenX=100,screenY=60,top=60,left=100");
	PrevieWin.focus();
	PrevieWin.document.open();
	PrevieWin.document.write("<HTML>");
	PrevieWin.document.write("<HEAD>");
	//PrevieWin.document.write("<%=Replace(ContentType, """", "'")%>");
	PrevieWin.document.write("<TITLE>" + strLabel5 + "</TITLE>");
    PrevieWin.document.write("<script language = 'javascript' src = '../../Common/eMicLibCommon.js?t=" +new Date().getTime()+ "'></script>");
	PrevieWin.document.write("	<link href='../../Resources/StyleSheet/default.css' rel='stylesheet' type='text/css' />");

	PrevieWin.document.write("	<link href='../../Resources/StyleSheet/main.css' rel='stylesheet' type='text/css' />");
	PrevieWin.document.write("	<link href='/Resources/style.css' rel='stylesheet' type='text/css' />");
	PrevieWin.document.write("</HEAD>");
	PrevieWin.document.write("<BODY BGCOLOR='' TOPMARGIN=0 LEFTMARGIN=0 MARGINWIDTH=0 MARGINHEIGHT=0 onBlur='self.focus()'>");
	//PrevieWin.document.write(varStyleStheet);

	PrevieWin.document.write("<div class='ClearFix table-form'>");
	PrevieWin.document.write("<TABLE CELLPADDING=3 CELLSPACING=0 BORDER=0 WIDTH=100% class='lbGrid'> ");
	PrevieWin.document.write("<TR>");
	PrevieWin.document.write("<TD VALIGN='TOP' COLSPAN=3 Class='lbPageTitle'>");
	PrevieWin.document.write("<SPAN id='lblMainTitle' class='main-group-form'>" + strLabel6 + "</SPAN>");
	PrevieWin.document.write("</TD>");
	PrevieWin.document.write("</TR>");

	PrevieWin.document.write("<TR class='lbGridHeader'>");
	PrevieWin.document.write("<TD > Tên trường</TD>");
	PrevieWin.document.write("<TD >Chỉ thị</TD>");
	PrevieWin.document.write("<TD >Nội dung trường</TD>");
	PrevieWin.document.write("</TR>");
	for (intCounter = 0; intCounter < arrFieldCode.length; intCounter++) {
		intNOR = -1;
		while (arrFieldValue[intCounter].length > 0) {
			intNOR++;
			intPosition = arrFieldValue[intCounter].indexOf("$&");
			if (intPosition >= 0) {
				records[intNOR] = arrFieldValue[intCounter].substring(0, intPosition);
				arrFieldValue[intCounter] = arrFieldValue[intCounter].substring(intPosition + 2, arrFieldValue[intCounter].length);
			} else {
				records[intNOR]= arrFieldValue[intCounter];
				arrFieldValue[intCounter] = "";
			}
		}
		//alert(arrFieldValue[intCounter]);
		for (intSubIndex = 0; intSubIndex <= intNOR; intSubIndex++) {
			intPosition = records[intSubIndex].indexOf("::");
			if (intPosition >= 0 && intPosition <=2) {
				strIndicators = records[intSubIndex].substring(0, intPosition);
				strFieldValue = records[intSubIndex].substring(intPosition + 2, records[intSubIndex].length);
				for (intPosition = 0; intPosition <= strIndicators.length; intPosition++) {
					if (strIndicators.charAt(intPosition) == " ") {
						strIndicators = strIndicators.substring(0, intPosition) + "#" + strIndicators.substring(intPosition + 1, strIndicators.length);
					}
				} 
			} else {
				strIndicators = "&nbsp;&nbsp;"; 
				strFieldValue = records[intSubIndex];
			}
			PrevieWin.document.write("<TR>");
			PrevieWin.document.write("<TD VALIGN=TOP WIDTH='15%'><SPAN class='lbLabel'>" + arrFieldCode[intCounter] + "</SPAN></TD>");
			PrevieWin.document.write("<TD VALIGN=TOP WIDTH='5%'><SPAN class='lbLabel'>" + strIndicators + "</SPAN></TD>");
			PrevieWin.document.write("<TD VALIGN=TOP><SPAN class='lbLabel'>"+ strFieldValue + "</SPAN></TD>");
			PrevieWin.document.write("</TR>");
		}
	}
	PrevieWin.document.write("</TABLE>");
	PrevieWin.document.write("</div>");
	PrevieWin.document.write("<CENTER><FORM><INPUT TYPE='button' onClick='self.close()' class='lbButton' VALUE='" + strLabel10 + "'></CENTER></FORM>");
	PrevieWin.document.write("</BODY>");
	PrevieWin.document.write("</HTML>");
	PrevieWin.document.write("");
	PrevieWin.document.close();
}

function OnLoad() {
	parent.document.getElementById('frmMain').setAttribute('rows','*,28');
	document.forms[0].target='Workform';
	document.forms[0].action='WCataPut.aspx';
	CurTime();
}

function LoadFormAddnew() {
    //self.location.href='WCata.aspx?FormID=' + document.forms[0].lstMarcForm.options[document.forms[0].lstMarcForm.options.selectedIndex].value;
    var hidFileIds;
    var strFileIds = '';
    hidFileIds = document.forms[0].hidFileIds;
    if (hidFileIds) {
        strFileIds = hidFileIds.value;
    }
	self.location.href='WNothing.htm';
	parent.Sentform.location.href = 'WCataSent.aspx?FileIds=' + strFileIds + '&FormID=' + document.forms[0].lstMarcForm.options[document.forms[0].lstMarcForm.options.selectedIndex].value;
	

	/*document.forms[0].target = 'Sentform'; 
	document.forms[0].action = 'WCataSent.aspx';
	document.forms[0].submit();
	*/
	
}
