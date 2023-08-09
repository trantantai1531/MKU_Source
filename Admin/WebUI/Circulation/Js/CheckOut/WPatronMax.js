/*
	GenRanNum function
	Purpose: Generate random number
*/
function GenRanNum(intNumber) {
	var str = '';
	var intCount;
	for(intCount = 1; intCount<=intNumber;intCount++){ 
		str=str + (String)(parseInt(9 * Math.random()+48));
	}
	
	return(str);
}

/*
	GenURLImg function
	Purpose: set image source	
*/
function GenURLImg(intNumber) {
  
	if(document.forms[0].hidHave.value>0) {
		document.images["anh1"].src='../../Common/WChartDir.aspx?i=1&x='+GenRanNum(intNumber);
		document.images["anh2"].src='../../Common/WChartDir.aspx?i=2&x='+GenRanNum(intNumber);	
	}
}


function GenURLImg1(intNumber){
	if(document.forms[0].hidHave.value>0) {
		document.images["Image1"].src='../../Common/WChartDir.aspx?i=1&x='+GenRanNum(intNumber);
		document.images["Image2"].src='../../Common/WChartDir.aspx?i=2&x='+GenRanNum(intNumber);	
	}
}

function LoadStatMonth() {
	parent.Main.location.href='WStatisticMonth.aspx?Year=' + intYear;
}

function LoadStatDay() {
	parent.Main.location.href='WStatisticDay.aspx?Year=' + intYear + ',' + 'Month=' + intMonth;
}
function SetLibIDs() {
	var i;
	var strIDs="";	
	for(i=0;i<document.forms[0].lstLib.length;i++) {
		if (document.forms[0].lstLib.options[i].selected) {
			strIDs=strIDs+document.forms[0].lstLib.options[i].value;
		}
	}
	document.forms[0].hidIDs.value=strIDs;
}
function btnReportCheckDate(objDateField1,objDateField2,strDateFormat,strMsg)
{	
	strDateFormat = strDateFormat.toLowerCase();
	mdateval = eval(objDateField1).value;	
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
					if ((parseFloat(mday) != parseFloat(cday)) || (parseFloat(mmonth) != parseFloat(cmonth)) || (isNaN(myear)) || (myear.length < 4)) 
						{
							alert(strMsg);							
							eval(objDateField1).value = "";							
							eval(objDateField1).focus();							
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
					if (parseFloat(mday) != parseFloat(cday) || parseFloat(mmonth) != parseFloat(cmonth)|| (myear != cyear)) {
						alert(strMsg);
						eval(objDateField1).value = "";
						eval(objDateField1).focus();
						return  false;
					}		
					break;
				}
	}
	mdateval = eval(objDateField2).value;	
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
					if ((parseFloat(mday) != parseFloat(cday)) || (parseFloat(mmonth) != parseFloat(cmonth)) || (isNaN(myear)) || (myear.length < 4)) 
						{
							alert(strMsg);							
							eval(objDateField2).value = "";							
							eval(objDateField2).focus();							
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
					if (parseFloat(mday) != parseFloat(cday) || parseFloat(mmonth) != parseFloat(cmonth)|| (myear != cyear)) {
						alert(strMsg);
						eval(objDateField2).value = "";
						eval(objDateField2).focus();
						return  false;
					}		
					break;
				}
	}
	return true;

}
//Check Number
//Created by: Tuannv
//Create date: 23/09/2006
function btnInputCheckNum(obj1,obj2,strMsg)
{
	var tempNum;
	tempNum= trim(eval(obj1).value);
	if(tempNum=="") {
		alert(strMsg);
		eval(obj1).value = "";	
		eval(obj1).focus();								
		return false;
	}	
	if (isNaN(tempNum)) {
		alert(strMsg);
		eval(obj1).value = "";	
		eval(obj1).focus();
		return false;
	}
	tempNum=trim(eval(obj2).value);
	if(tempNum==""){
		alert(strMsg);
		eval(obj2).value = "";	
		eval(obj2).focus();
		return false;
	}
	if(isNaN(tempNum)){
		alert(strMsg);
		eval(obj2).value = "";	
		eval(obj2).focus();
		return false;
	}
	return true;
}
function Compare(msg) {
	if ((document.forms[0].txtFromDate.value !='') && (document.forms[0].txtToDate.value !='') && (CompareDate(document.forms[0].txtFromDate,document.forms[0].txtToDate,'dd/mm/yyyy')==0)) {
			alert(msg);
			document.forms[0].txtToDate.focus();
			return false;
		}
	return true;
}