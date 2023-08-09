// modify by lent 9-4-2005
// support more for create acqrequest form
function ImportToCataForm(){
	// Title
	
	if (eval('opener.document.forms[0].txt245_a')) {
		opener.document.forms[0].txt245_a.value=document.forms[0].hidTag245a.value;
	}
	if (eval('opener.document.forms[0].txtTitle')) {
		opener.document.forms[0].txtTitle.value=document.forms[0].hidTag245a.value;
	}
	// Author
	if (eval('opener.document.forms[0].txt100_a')) {
		opener.document.forms[0].txt100_a.value=document.forms[0].hidTag100.value;
	}
    if (eval('opener.document.forms[0].txt110_a')) {
        opener.document.forms[0].txt110_a.value = document.forms[0].hidTag110.value;
    }
	if (eval('opener.document.forms[0].txtAuthor')) {
		opener.document.forms[0].txtAuthor.value=document.forms[0].hidTag100.value;
    }
    //082
    if (eval('opener.document.forms[0].txt082_a')) {
         opener.document.forms[0].txt082_a.value = document.forms[0].hidTag082.value;
    }

	// ISBN
	if (eval('opener.document.forms[0].txt020_a')) {
		opener.document.forms[0].txt020_a.value=document.forms[0].hidTag020.value;
	}
	if (eval('opener.document.forms[0].txtISBN')) {
		opener.document.forms[0].txtISBN.value=document.forms[0].hidTag020.value;
	}

	// ISSN
	if (eval('opener.document.forms[0].txt022_a')) {
		opener.document.forms[0].txt022_a.value=document.forms[0].hidTag022.value;
	}
	if (eval('opener.document.forms[0].txtISSN')) {
		opener.document.forms[0].txtISSN.value=document.forms[0].hidTag022.value;
	}

    if (eval('opener.document.forms[0].txt260_a')) {
        opener.document.forms[0].txt260_a.value = document.forms[0].hidTag260a.value;
    }
	// Publisher
	if (eval('opener.document.forms[0].txt260_b')) {
		opener.document.forms[0].txt260_b.value=document.forms[0].hidTag260b.value;
	}
	if (eval('opener.document.forms[0].txtPublisher')) {
		opener.document.forms[0].txtPublisher.value=document.forms[0].hidTag260b.value;
	}

	// PublishYear
	if (eval('opener.document.forms[0].txt260_c')) {
			opener.document.forms[0].txt260_c.value=document.forms[0].hidTag260c.value;
	}
	if (eval('opener.document.forms[0].txtPubYear')) {
		opener.document.forms[0].txtPubYear.value=document.forms[0].hidTag260c.value;
	}

	// PublishOrder
	if (eval('opener.document.forms[0].txt250_a')) {
		opener.document.forms[0].txt250_a.value=document.forms[0].hidTag250.value;
	}
	if (eval('opener.document.forms[0].txtEdition')) {
		opener.document.forms[0].txtEdition.value=document.forms[0].hidTag250.value;
	}	
	
	// Content
	if (eval('opener.document.forms[0].txtContent')) {
		opener.document.forms[0].tag.checked=true;
		opener.document.forms[0].txtContent.value=document.forms[0].hidContent.value;
	}
	self.close();
}
function LoadBack(val){
	var pos;
	var Server;
	var Port;
	var db;
	var temp = val;
	if (val!=''){
		pos = temp.indexOf(":");
		Server = temp.substring(0,pos);
		temp = temp.substring(pos + 1);
			
		pos = temp.indexOf("#");
		Port = temp.substring(0,pos);
		temp = temp.substring(pos + 1);
		
		db = temp;
		
		opener.document.forms[0].txtzServer.value = Server;
		opener.document.forms[0].txtZPort.value = Port;
		opener.document.forms[0].txtZDatabase.value = db;
	}
	self.close();
}
function ViewRecord(val,strErrMsg1,strErrMsg2,strErrMsg3) {	
	if (document.forms[0].hidCountRec.value > 9) {
	var strNext=trim(document.forms[0].txtNext.value);
		if (strNext=="") {
			alert(strErrMsg1);
			document.forms[0].txtNext.focus();
			return false;
		}
		if (isNaN(strNext)) {
			alert(strErrMsg2);
			document.forms[0].txtNext.focus();
			return false;
		}
		var intNext=parseInt(strNext);
		var intCount=parseInt(document.forms[0].hidCountRec.value)	
		/*
		if (intCount > 9){
			intCount = intCount - 9
		}
		*/
		if ((intNext<1) || (intNext>intCount)) {
			alert(strErrMsg3);
			document.forms[0].txtNext.focus();
			return false;
		}	
	}
	document.forms[0].hidAction.value=val;
	if (val!=1) {
		document.forms[0].submit();
	}
	return true;
	
}
function CataSubmit(intID, intImport) {
	document.forms[0].hidImport.value=intImport;
	document.forms[0].hidImportID.value=intID;
	document.forms[0].submit();
}