/**************************************************************************
************************ WSimple Search Js file ***************************
**************************************************************************/
function PickPatronGroup() {
var strIDs="";
var i;	
	for(i=0;i<document.forms[0].lstGroupID.length;i++){
		if(document.forms[0].lstGroupID.options[i].selected) {
			strIDs=strIDs + document.forms[0].lstGroupID.options[i].value+",";
		}
	}
	document.forms[0].hidPatronGroupIDs.value=strIDs;
	return true;
}
function Check_All(strMsg,strDateFormat){	
	if (!CheckDate(document.forms[0].txtDOB,strDateFormat,strMsg)){
		return false;
	}else{
		if (!CheckDate(document.forms[0].txtValidDate,strDateFormat,strMsg)){
			return false;
		}else{
			if (!CheckDate(document.forms[0].txtExpiredDate,strDateFormat,strMsg)){
				return false;
			}else{
				// pick patron group ids
				PickPatronGroup();
				return true;
			}
		}
	}
}
function SetFieldShow(st){
	if (document.forms[0].ddlTypeShow.value==1){
		window.open('WSetFieldShow.aspx?show=' + document.forms[0].txtFieldShow.value + '&pgsize=' + document.forms[0].txtPageSize.value,'new_win',200,100,50,150,'no','resizable=yes',1);
	}else{
		alert(st); 
	}
}

function microsoftKeyPress() {
	if (window.event.keyCode == 13) {
		document.forms[0].btnSearch.click();
		window.event.keyCode = 27;
	}
}

function ClearAll() {
	document.forms[0].txtCode.focus();
	document.forms[0].txtCode.value = '';
	document.forms[0].txtFullName.value = '';
	document.forms[0].ddlSex.options.selectedIndex = 0;
	document.forms[0].lstGroupID.options.selectedIndex = 0;
	document.forms[0].ddlFaculty.options.selectedIndex = 0;
	document.forms[0].ddlOccupation.options.selectedIndex = 0;
	document.forms[0].ddlSelectTop.options.selectedIndex = 0;
	document.forms[0].ddlOrderBy.options.selectedIndex = 0;
	document.forms[0].ddlTypeShow.options.selectedIndex = 0;
	document.forms[0].txtDOB.value = '';
	document.forms[0].txtValidDate.value = '';
	document.forms[0].txtExpiredDate.value = '';
	document.forms[0].txtClass.value = '';
	document.forms[0].txtGrade.value = '';
}