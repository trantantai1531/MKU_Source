//Use for WCatalogueDetail.aspx
function rdoEvent(val,iRow)
{	
	//chkChoice
	//eval('document.forms[0].chkChoice'+ val).checked=!eval('document.forms[0].chkChoice' + val).checked;
	
	//rdoChoice			
	
	if (eval(document.forms[0].rdoChoice[0]))
	{
		for(var i = 0; i < document.forms[0].rdoChoice.length; i++)
		{
			if (i==iRow)
			{
				document.forms[0].rdoChoice[i].checked=true; 
				document.forms[0].hidID.value=val;
			}	
			else
				document.forms[0].rdoChoice[i].checked=false; 
		}	
	}
	else
	{
		if (eval(document.forms[0].rdoChoice))
		{
			document.forms[0].rdoChoice.checked=true; 
			document.forms[0].hidID.value=val;
		}
	}
	//GetCheckboxValue();		
}
//Use for WCatalogueDetail.aspx
function chkEvent(val)
{	
	
	if (document.forms[0].hidIDs.value=="") {
		document.forms[0].hidIDs.value=val;
	}
	else {
		var strIDs="," + document.forms[0].hidIDs.value+",";
		var intPos=strIDs.indexOf(","+val+",");
		//removed
		if (intPos>-1) {
			strIDs=strIDs.replace(","+val+",",",");						
			if (strIDs==",")
				document.forms[0].hidIDs.value="";
			else
			document.forms[0].hidIDs.value=strIDs.substring(1,strIDs.length-1);
		}
		//add
		else {
			document.forms[0].hidIDs.value=document.forms[0].hidIDs.value + "," + val;
		}
	}	
}
function ReCheckbox() {
	if (document.forms[0].hidIDs.value!="") {		
		var strIDs=","+document.forms[0].hidIDs.value+","
		var val="";
		if(eval(document.forms[0].Choice[0])) {
			var i;
			for( i= 0; i < document.forms[0].Choice.length; i++)
			{
				val=","+document.forms[0].Choice[i].value + ",";
				if (strIDs.indexOf(val)>-1) document.forms[0].Choice[i].checked=true;
			}		
		}
		else {		
			val=","+document.forms[0].Choice.value + ",";
			if (strIDs.indexOf(val)>-1) 
				document.forms[0].Choice.checked=true;
		}		
	}	
}
function GetCheckboxValue() {

	var str="";
	
	for(var i = 0; i < document.forms[0].Choice.length; i++)
	{
		if (document.forms[0].Choice[i].checked==true)
			str=str + document.forms[0].Choice[i].value + ","; 			
	}		
	str=str.substring(0,str.length-1);
	document.forms[0].hidIDs.value=str;	
}
//Use for WCataRecordDelete.aspx
/*function CheckAll(msg){
/*	var chk;
	chk=CheckNull(document.forms[0].txtTitle) && CheckNull(document.forms[0].txtCopyNumber) && CheckNull(document.forms[0].txtAuthor) && CheckNull(document.forms[0].txtPublisher) && CheckNull(document.forms[0].txtYear) && CheckNull(document.forms[0].txtISBN)
	if (chk){
		alert(msg);
		return false;
	}else{
		return true;
	}
	alert('Hi');
	return true;
}*/