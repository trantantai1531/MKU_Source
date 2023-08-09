// modify by lent 9-4-2005
// support more for create acqrequest form
function ImportToCataForm(){
	// Title
	if (eval('opener.document.forms[0].txtTitle')) {
		opener.document.forms[0].txtTitle.value=document.forms[0].txtHidTitle.value;
	}
	// Author
	if (eval('opener.document.forms[0].txtAuthor')) {
		opener.document.forms[0].txtAuthor.value=document.forms[0].txtHidAuthor.value;
	}
	// ISBN
	if (eval('opener.document.forms[0].txtISBN')) {
		opener.document.forms[0].txtISBN.value=document.forms[0].txtHidISBN.value;
	}

	// ISSN
	if (eval('opener.document.forms[0].txtISSN')) {
		opener.document.forms[0].txtISSN.value=document.forms[0].txtHidISSN.value;
	}

	// PlaceOfPub
	if (eval('opener.document.forms[0].txtPlaceOfPub')) {
		opener.document.forms[0].txtPlaceOfPub.value=document.forms[0].txtHidPlaceOfPub.value;
	}
	
	// Publisher
	if (eval('opener.document.forms[0].txtPublisher')) {
		opener.document.forms[0].txtPublisher.value=document.forms[0].txtHidPublisher.value;
	}

	// PublishYear
	if (eval('opener.document.forms[0].txtPubDate')) {
		opener.document.forms[0].txtPubDate.value=document.forms[0].txtHidPublishYear.value;
	}

	// PublishOrder
	if (eval('opener.document.forms[0].txtEdition')) {
		opener.document.forms[0].txtEdition.value=document.forms[0].txtHidPublishOrder.value;
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
