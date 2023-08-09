// Next function - Purpose: Move to the next record

function OnLoad() {
		parent.document.getElementById('frmMain').setAttribute('rows','*,28');
	}

	
function Next(strMsg1, strMsg2, strMsg3, intReCount, strMsg4){
var intItemID;
var intTopNumber;
var arrIDs;
if (eval(document.forms[0].txtReNum).value != "") 
{
if (document.forms[0].hidIDs.value == "") {
	if (parseFloat(document.forms[0].txtReNum.value) == parseFloat(document.forms[0].txtMaxReNum.value)) {
		alert (strMsg1);
		return false;
	}
		
	if (parseFloat(document.forms[0].txtReNum.value) < 1) {
		alert (strMsg2);
		document.forms[0].txtReNum.value = 1
        intTopNumber = 1
		OpenFormSequency(intTopNumber);
		return false;
	}
	
	if (parseFloat(document.forms[0].txtReNum.value) > parseFloat(document.forms[0].txtMaxReNum.value)) {
		alert (strMsg3);
		intTopNumber = parseFloat(document.forms[0].txtMaxReNum.value)
		document.forms[0].txtReNum.value = intTopNumber		
		OpenFormSequency(intTopNumber);
		return false;	   
	}
	
	document.forms[0].txtReNum.value = parseFloat(document.forms[0].txtReNum.value) + 1;     
	intTopNumber = parseFloat(document.forms[0].txtReNum.value)
    OpenFormSequency(intTopNumber);	

}else{	
	if (parseFloat(document.forms[0].txtReNum.value) == intReCount) {
		   alert (strMsg1);
		   return false;
	}           
		
	if (parseFloat(document.forms[0].txtReNum.value) < 1) {
           alert (strMsg2);
           document.forms[0].txtReNum.value = 1           
           arrIDs = document.forms[0].hidIDs.value.split(",");
		   intItemID = arrIDs[parseFloat(document.forms[0].txtReNum.value)-1]
		   OpenForm(intItemID);
           return false;	   
    }
    	
	if (parseFloat(document.forms[0].txtReNum.value) > intReCount) {
		   alert (strMsg3);
		   document.forms[0].txtReNum.value = intReCount;		   
		   arrIDs = document.forms[0].hidIDs.value.split(",");
		   intItemID = arrIDs[intReCount-1]
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
function Prev(strMsg1, strMsg2, strMsg3, intReCount, strMsg4){
var intItemID;
var intTopNumber;
var arrIDs;

if (eval(document.forms[0].txtReNum).value != "") 
{
if (document.forms[0].hidIDs.value == "") {
	if (parseFloat(document.forms[0].txtReNum.value) == 1) {
		alert (strMsg1);
		return false;
		}
		
	if (parseFloat(document.forms[0].txtReNum.value) < 1) {
		alert (strMsg2);		
		document.forms[0].txtReNum.value = 1
        intTopNumber = 1
		OpenFormSequency(intTopNumber);
		return false;
		}	
		
	if (parseFloat(document.forms[0].txtReNum.value) > parseFloat(document.forms[0].txtMaxReNum.value)) {
		alert (strMsg3);		
		intTopNumber = parseFloat(document.forms[0].txtMaxReNum.value)
		document.forms[0].txtReNum.value = intTopNumber
		OpenFormSequency(intTopNumber);
		return false;
		}
	
	document.forms[0].txtReNum.value = parseFloat(document.forms[0].txtReNum.value) - 1;     
	intTopNumber = parseFloat(document.forms[0].txtReNum.value)
    OpenFormSequency(intTopNumber);
	}
else
{
	if (parseFloat(document.forms[0].txtReNum.value) == 1) {
           alert (strMsg1);
           return false;
    }
    if (parseFloat(document.forms[0].txtReNum.value) < 1) {
           alert (strMsg2);           
           document.forms[0].txtReNum.value = 1
           arrIDs = document.forms[0].hidIDs.value.split(",");
		   intItemID = arrIDs[parseFloat(document.forms[0].txtReNum.value)-1]
		   OpenForm(intItemID);
           return false;
    }
	if (parseFloat(document.forms[0].txtReNum.value) > intReCount) {
		   alert (strMsg3);
		   document.forms[0].txtReNum.value = intReCount;
		   arrIDs = document.forms[0].hidIDs.value.split(",");
		   intItemID = arrIDs[intReCount-1]
		   OpenForm(intItemID);
		   return false;
	}           
	
	arrIDs = document.forms[0].hidIDs.value.split(",");
	intItemID = arrIDs[parseFloat(document.forms[0].txtReNum.value)-2]
    document.forms[0].txtReNum.value = parseFloat(document.forms[0].txtReNum.value) - 1;         
    OpenForm(intItemID);
}        
}
else {
alert(strMsg4)
}
}

// Bind data for the first time form loaded
function StartBindData(intMinNum){	
	if (document.forms[0].hidIDs.value=="")
		parent.Workform.location.href = "WCatalogueProperty.aspx?Action=View&intTopNum=" + intMinNum + "&intType=" + document.forms[0].ddlView.options.selectedIndex;
	else {
		var arrIDs;
		arrIDs = document.forms[0].hidIDs.value.split(",");
		intItemID = arrIDs[intMinNum-1]
		document.forms[0].ItemID.value = intItemID;
		parent.Workform.location.href = "WCatalogueProperty.aspx?Action=View&intItemID=" + intItemID + "&intType=" + document.forms[0].ddlView.options.selectedIndex;
	}
		
}

// Go to the last record
function End(intReCount,intMaxNum) {
	if (intReCount==parseInt(document.forms[0].txtReNum.value))
		return false;
	document.forms[0].txtReNum.value = intReCount;
	document.forms[0].ItemID.value = intMaxNum;

	if (document.forms[0].hidIDs.value=="") {
		OpenFormSequency(intMaxNum);
		}
	else {
		var arrIDs;
		arrIDs = document.forms[0].hidIDs.value.split(",");
		intItemID = arrIDs[intMaxNum-1];
		OpenForm(intItemID)
	}		
}

// Go to the first record
function Home(intMinNum) {
	if (1==parseInt(document.forms[0].txtReNum.value))
		return false;
	document.forms[0].txtReNum.value = 1;
	document.forms[0].ItemID.value = intMinNum;
	if (document.forms[0].hidIDs.value=="") {
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
function ChangeRecNum(strMsg1, strMsg2, strMsg3, intReCount, strMsg4){
var intItemID;
var intTopNumber;
var arrIDs;

if (eval(document.forms[0].txtReNum).value != "") 
{
if (document.forms[0].hidIDs.value == "") {
			
	if (parseFloat(document.forms[0].txtReNum.value) < 1) {
		alert (strMsg2);
		document.forms[0].txtReNum.value = 1
        intTopNumber = 1
		OpenFormSequency(intTopNumber);
        return;	   
	}
	
	if (parseFloat(document.forms[0].txtReNum.value) > parseFloat(document.forms[0].txtMaxReNum.value)) {
		alert (strMsg3);
		intTopNumber = parseFloat(document.forms[0].txtMaxReNum.value)
		document.forms[0].txtReNum.value = intTopNumber
		OpenFormSequency(intTopNumber);
		return;	   
	}
	
	intTopNumber = parseFloat(document.forms[0].txtReNum.value)
    OpenFormSequency(intTopNumber);	

}else{

	if (parseFloat(document.forms[0].txtReNum.value) < 1) {
           alert (strMsg2);
           document.forms[0].txtReNum.value = 1
           arrIDs = document.forms[0].hidIDs.value.split(",");
		   intItemID = arrIDs[parseFloat(document.forms[0].txtReNum.value)-1]
		   OpenForm(intItemID);
           return;	   
    }
    	
	if (parseFloat(document.forms[0].txtReNum.value) > intReCount) {
		   alert (strMsg3);
		   document.forms[0].txtReNum.value = intReCount;
		   arrIDs = document.forms[0].hidIDs.value.split(",");
		   intItemID = arrIDs[intReCount-1]
		   OpenForm(intItemID);
		   return;	   
	}           
	
	arrIDs = document.forms[0].hidIDs.value.split(",");
	intItemID = arrIDs[parseFloat(document.forms[0].txtReNum.value)-1]    
    OpenForm(intItemID);
}
}
else {
alert(strMsg4)
}
}

// OpenForm method (By ID)
function OpenForm(intItemNum) {
	document.forms[0].ItemID.value = intItemNum;
	parent.Workform.location.href = "WCatalogueProperty.aspx?Action=View&intItemID=" + intItemNum + "&intType=" + document.forms[0].ddlView.options.selectedIndex;
}	

// OpenFormSequency method (By TopNum)
function OpenFormSequency(intTopNumber) {
     parent.Workform.location.href = "WCatalogueProperty.aspx?Action=View&intTopNum=" + intTopNumber + "&intType=" + document.forms[0].ddlView.options.selectedIndex;
     if (document.forms[0].ddlView.options.selectedIndex == 2 || document.forms[0].ddlView.options.selectedIndex == 3) 
     {
		parent.Hiddenbase.location.href = "WLoadData.aspx?intTopNum=" + intTopNumber + "&intType=" + document.forms[0].ddlView.options.selectedIndex;						
     }
}	

// OpenCreateNewForm method (Create new)
function OpenCreateNewForm() {
     parent.Workform.location.href = "WMarcFormSelect.aspx";
}	

// CheckNumber method
function CheckNumber(obj,msg) {
	var tempNum;
	tempNum = trim(eval(obj).value);
	if(tempNum=="") {
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

// DeleteRecord function
// Purpose: delete the selected record
function DeleteRecord() {
	var strURL;
	strURL = "WCatalogueProperty.aspx?Action=Delete&intType=0&intItemID=" + document.forms[0].ItemID.value;
	parent.Workform.location.href = strURL;
}

// ChangeRecordView function
// Purpose: Change the way to view a record
function ChangeRecordView() {
	var strURL;
	strURL = "WCatalogueProperty.aspx?Action=View&intType=" + document.forms[0].ddlView.options.selectedIndex + "&intItemID=" + document.forms[0].ItemID.value;
	parent.Workform.location.href = strURL;
	return false;
}

// ChangeToModify function
// Purpose: Change to the modify page
function ChangeToModifyPage() {
	var strURL;
	strURL = "WCataModify.aspx?CurrentID=" + document.forms[0].txtReNum.value + "&ItemID=" + document.forms[0].ItemID.value + "&FormID=" + document.forms[0].hidFormID.value;
	self.location.href = strURL;
}

// ChangeToModify function
// Purpose: Change to reuse page
function ChangeToReusePage() {
	var strURL;
	strURL = "WCataModify.aspx?Reuse=1&CurrentID=" + document.forms[0].txtReNum.value + "&ItemID=" + document.forms[0].ItemID.value + "&FormID=" + document.forms[0].hidFormID.value + "&IsCopy=1";
	self.location.href = strURL;
}