//parent.main.
function GetLengthIDs() {
	if (document.forms[0].arrlistsaved.value==''){
		return 0;
	}
	var arrList=document.forms[0].arrlistsaved.value.split(",");
	return arrList.length;
}
/// submit form 
function CheckEmptyValue(strNote) {
	if(document.forms[0].arrlistsaved.value=="") {		
		alert(strNote);
		return false;
	}
	return true;
}

function FormSubmit(strNote,strNote1){
	if (!CheckEmptyValue(strNote1)) return false;
	var Index=GetLengthIDs();
	var SavedIDs = "";
	
	if (Index == 1){
			if (document.forms[0].ListSaved.checked){
				document.forms[0].arrlistsaved.value =document.forms[0].ListSaved.value;				
				document.forms[0].action="WSavedFormat.aspx";
				document.forms[0].submit();
				}
			else{								
				alert(strNote);
				}
		}
	else{
		
		for(i=0;i<Index;i++){
			if (document.forms[0].ListSaved[i].checked){
				SavedIDs = SavedIDs  + document.forms[0].ListSaved[i].value + ",";
			}//If
		} //For		
		if(SavedIDs!= ""){
			document.forms[0].arrlistsaved.value=SavedIDs.substr(0,SavedIDs.length-1);		
			document.forms[0].action="WSavedFormat.aspx";
			document.forms[0].submit();
			}//IF
		else{
			alert(strNote);
			}//Else
	}//Else	
	return false;
}//Function

//This function use to continue looking documents
function BackToSelect(){
	self.location.href="../WShowresult.aspx";
	return false;	
}//Function

//This function use for deleting items from selected set
function Reload(strNote,strNote1){
	if (!CheckEmptyValue(strNote1)) return false;
	var Index=GetLengthIDs();
	var HaveChecked=0;
	var havesubmit=0;		
	var strIDs="";
	var i;
	i=0;
	if (Index == 1){
 			if (document.forms[0].ListSaved.checked){ 	
 				document.forms[0].arrlistsaved.value="";				
 					havesubmit=1;						
				}//if
			else{					
					alert(strNote);
				}//else
			}//if
	else{			
			for(i=0;i<Index;i++){
				if (document.forms[0].ListSaved[i].checked){
						HaveChecked  = 1;
				}//if
				else
					{
						strIDs = strIDs  +  document.forms[0].ListSaved[i].value + ",";	
				}//else
			 }//For			 
			document.forms[0].arrlistsaved.value=strIDs.substr(0,strIDs.length-1);				
			if (HaveChecked == 1){								
				havesubmit=1;
			}//if
			else{	
				alert(strNote);			
			}//else			
		
	}//Else		
	if(havesubmit==1) {
		parent.HiddenSaveIDs.document.forms[0].txtSaveID.value = document.forms[0].arrlistsaved.value;
		parent.HiddenSaveIDs.document.forms[0].txtDocIDTemps.value = GetLengthIDs();	
		return true;
	}
	return false;
}//Function

//This function use for checking all checkbox
function SetCheckAll(){
		var Index=GetLengthIDs();	
		if (Index == 1){
				if	(document.forms[0].CheckAll.checked	){
					document.forms[0].ListSaved.checked = 1;
					}
				else{
					document.forms[0].ListSaved.checked = 0;
					}				
			}//if
		else{
				for(i=0;i<Index;i++){
					if	(document.forms[0].CheckAll.checked	){
							document.forms[0].ListSaved[i].checked = 1;
						}//if
					else{
							document.forms[0].ListSaved[i].checked = 0;	
						}//else								
			 	}//For
			 }//Else
}//Function
