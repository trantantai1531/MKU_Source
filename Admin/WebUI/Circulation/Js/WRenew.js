//Creator by HieuNT on 19/8/2004

function SetChecked(val) {	
	if (val == 0) 
		checked=false; 
	else checked = true;
	frmUDT=document.forms[0];
	len = frmUDT.elements.length;
	var i=0;
	for( i=0 ; i<len ; i++){
		if (frmUDT.elements[i].name=='LoanID'){
		frmUDT.elements[i].checked=checked;
		}
	}
}
//Check  Date
function CheckDate(f){
	val = f.value;
	if (val == "") return;
	iday = val.substring(0, val.indexOf("/"));
	imon = val.substring(val.indexOf("/") + 1, val.lastIndexOf("/"));
	iyear = val.substring(val.lastIndexOf("/") + 1, val.length);
	mDate = new Date(imon + "/" + iday + "/" + iyear);
	if (mDate.getDate() != iday || mDate.getMonth() != imon - 1) {
		alert("<%=LabelStr(17)%>");
		f.value = "";
	}
} 
//Show Page
function ShowCalendar (sourcefield) {
   CalenWin =  window.open("WCalendar.aspx?Source=" + Esc(sourcefield),"CalenWin", "height=170,width=250,resizable,top=50,left=50,screenX=50,screenY=50");
   CalenWin.focus();
}
//Use for WCalander.aspx Page

function DateCompare(ValDate1,ValDate2)
{ // Ngay_thang_1
   if (ValDate2 == "") {
		return false;
   }
   i = ValDate1.indexOf('/',0);
   j = ValDate1.indexOf('/',i+1);
   var nDay = ValDate1.substring(0, i);
   var nMonth = ValDate1.substring(i+1,j);
   var nYear = ValDate1.substring(j+1);
   var str1=nMonth+'/'+nDay+'/'+nYear;
   // Ngay_thang 2
   i=0;
   j=0;
   i = ValDate2.indexOf('/',0);
   j = ValDate2.indexOf('/',i+1);
   var Day = ValDate2.substring(0, i);
   var Month = ValDate2.substring(i+1,j);
   var Year = ValDate2.substring(j+1);
   var str2=Month+'/'+Day+'/'+Year;	
   var tt =	Date.parse(str2) - Date.parse(str1);
   if(tt >= 0){ 
		return true; 
  }
   else {
		alert("<%=LabelStr(1)%>");
		return false;
   }
}

function CheckNullInput(msg){
	var chk;
	chk =	CheckNull(document.forms[0].txtTitle) && 	
			CheckNull(document.forms[0].txtCopyNumber) && 	
			CheckNull(document.forms[0].txtISBN) && 
			CheckNull(document.forms[0].txtAuthor) &&	
			CheckNull(document.forms[0].txtPublisher) &&
			CheckNull(document.forms[0].txtYear)
	if (chk){
		alert(msg);
		eval(document.forms[0].txtTitle).focus();
		return false;
	}else{
		return true;
	}
}

//Use for WRenew.aspx
function rdoEvent(val,iRow)
{
	//chkChoice
	eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked = blnStatus;			
	eval('document.forms[0].chkChoice'+ val).checked=!eval('document.forms[0].chkChoice' + val).checked;
	//rdoChoice		
	for(var i = 0; i < document.forms[0].rdoChoice.length; i++)
	{
		if (i==iRow)
			document.forms[0].rdoChoice[i].checked=true; 
		else
			document.forms[0].rdoChoice[i].checked=false; 
	}	
	GetCheckboxValue();
}


// CheckOptionsNull function - Alert when no option is checked
function CheckOptionsNull(strDtgName, strOptionName, intStart, intMax, strMsg){	
	var intCounter;	          			
	var intCount;          
	
	intCount = 0;
	
	for(intCounter = intStart; intCounter <= intMax + intStart - 1; intCounter++) {				  
	  if (eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName) && eval('document.forms[0].' + strDtgName + '__ctl' + intCounter + '_' + strOptionName).checked)
		{
			intCount = intCount + 1		
		}			
	}
	
	if (intCount != 0) {
		return true;
	}
	else
	{
		alert(strMsg);
		return false;
	}
}

// Confirm the delete (YES = Do action, NO = Cancel)
function ConfirmDelete(msg)
{
var truthBeTold = window.confirm(msg);
if (truthBeTold) {
return true;
}  else  {
			return false;
}
}


// If find an check object, check, if not, through away

function CheckOptionVisible(strDtgName, strOptionName, intvalue){	
	var blnStatus;						
	
	if (eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName))
	{
	if (eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName).checked) 
	{
		blnStatus = false;
	}
	else
	{
		blnStatus = true;	
	}	
	eval('document.forms[0].' + strDtgName + '__ctl' + intvalue + '_' + strOptionName).checked = blnStatus;			
	}			
	
}
//
function chkEvent(val)
{
	eval('document.forms[0].DgrResult__ctl' + val + 'CheckItemID').checked=!eval('document.forms[0].DgrResult__ctl' + val + 'CheckItemID').checked;
	//GetCheckboxValue();
}

