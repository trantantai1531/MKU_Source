/***************************************************************************************
*									WORCreateTaskBar									*
****************************************************************************************/
function Submitform(strLibName,strEmailIP,strPaymentType,strItemType,strTitle,strPatronCode,strDate,strDateFormat){
	var flage;
	flage=true;	
	// LibName 
	if(parent.Workform.document.forms[0].ddlSymbol.options[parent.Workform.document.forms[0].ddlSymbol.options.selectedIndex].value==0){
		flage=false;
		alert(strLibName);
		parent.Workform.document.forms[0].ddlSymbol.focus();
		return(false);
	}
	// Email or IP
	if(trim(parent.Workform.document.forms[0].txtEmailIP.value)==''){
		flage=false;
		alert(strEmailIP);
		parent.Workform.document.forms[0].txtEmailIP.focus();
		return(false);
	}
	// ItemType
	if(parent.Workform.document.forms[0].ddlItemType.options[parent.Workform.document.forms[0].ddlItemType.options.selectedIndex].value==0){
		flage=false;
		alert(strItemType);
		parent.Workform.document.forms[0].ddlItemType.focus();
		return(false);
	}
	// Title
	if(parent.Workform.document.forms[0].txtTitle.value==''){
		flage=false;
		alert(strTitle);
		parent.Workform.document.forms[0].txtTitle.focus();
		return(false);
	}
	// PatronCode
	if(parent.Workform.document.forms[0].txtPatronCode.value==''){
		flage=false;
		alert(strPatronCode);
		parent.Workform.document.forms[0].txtPatronCode.focus();
		return(false);
	}
	// Check NeedBeforeDate type
	flage=CheckDate(parent.Workform.document.forms[0].txtNeedBeforeDate,strDateFormat,strDate);
	if (flage==false){	
		parent.Workform.document.forms[0].txtNeedBeforeDate.focus();
		return(false);
	 }
	falge=CheckDate(parent.Workform.document.forms[0].txtExpiredDate,strDateFormat,strDate);
	if(!falge){
		parent.Workform.document.forms[0].txtExpiredDate.focus();
		return(false);
	}
	falge=CheckDate(parent.Workform.document.forms[0].txtComponentPubDate,strDateFormat,strDate);
	if(!flage){
		parent.Workform.document.forms[0].txtComponentPubDate.focus();
		return(false);		
	}
	falge=CheckDate(parent.Workform.document.forms[0].txtPubDate,strDateFormat,strDate);	
	if(!flage){
		parent.Workform.document.forms[0].txtPubDate.focus();
		return(false);	
	}
	// Submit here
	if(!flage)return(false);		
	else{
		if(parent.Workform.document.forms[0].hdILLID.value>0){//upate
			parent.Workform.document.forms[0].hdUpdateFlage.value=1;
			parent.Workform.document.forms[0].action='WORCreate.aspx?Update=1';			
			parent.Workform.document.forms[0].submit();
		}
		else{// Create new
			parent.Workform.document.forms[0].hdUpdateFlage.value=0;
			parent.Workform.document.forms[0].action='WORCreate.aspx?Create=1';
			parent.Workform.document.forms[0].submit();
		}
		return(false);
	}	
}
// reset parent.Workform
function Resetform(){
	parent.Workform.document.forms[0].reset();
	return(false);
}
// Set Status
function SetStatus(){
	if(document.forms[0].ckbReview.checked==true){
		parent.Workform.document.forms[0].hdReview.value=1;
	}
	else{
		parent.Workform.document.forms[0].hdReview.value=0;
	}
}
