// modify by lent 9-4-2005
// support more for create acqrequest form
function ImportToCataForm(){
	// Title
	if (eval('opener.document.forms[0].txt245_a')) {
		opener.document.forms[0].txt245_a.value=document.forms[0].txtHidTitle.value;
	}
	if (eval('opener.document.forms[0].txtTitle')) {
		opener.document.forms[0].txtTitle.value=document.forms[0].txtHidTitle.value;
	}
	// Author
	if (eval('opener.document.forms[0].txt100_a')) {
		opener.document.forms[0].txt100_a.value=document.forms[0].txtHidAuthor.value;
	}
	if (eval('opener.document.forms[0].txtAuthor')) {
		opener.document.forms[0].txtAuthor.value=document.forms[0].txtHidAuthor.value;
	}
	// ISBN
	if (eval('opener.document.forms[0].txt020_a')) {
		opener.document.forms[0].txt020_a.value=document.forms[0].txtHidISBN.value;
	}
	if (eval('opener.document.forms[0].txtISBN')) {
		opener.document.forms[0].txtISBN.value=document.forms[0].txtHidISBN.value;
	}

	// ISSN
	if (eval('opener.document.forms[0].txt022_a')) {
		opener.document.forms[0].txt022_a.value=document.forms[0].txtHidISSN.value;
	}
	if (eval('opener.document.forms[0].txtISSN')) {
		opener.document.forms[0].txtISSN.value=document.forms[0].txtHidISSN.value;
	}

	// Publisher
	if (eval('opener.document.forms[0].txt260_b')) {
		opener.document.forms[0].txt260_b.value=document.forms[0].txtHidPublisher.value;
	}
	if (eval('opener.document.forms[0].txtPublisher')) {
		opener.document.forms[0].txtPublisher.value=document.forms[0].txtHidPublisher.value;
	}

	// PublishYear
	if (eval('opener.document.forms[0].txt260_c')) {
			opener.document.forms[0].txt260_c.value=document.forms[0].txtHidPublishYear.value;
	}
	if (eval('opener.document.forms[0].txtPubYear')) {
		opener.document.forms[0].txtPubYear.value=document.forms[0].txtHidPublishYear.value;
	}

	// PublishOrder
	if (eval('opener.document.forms[0].txt250_a')) {
		opener.document.forms[0].txt250_a.value=document.forms[0].txtHidPublishOrder.value;
	}
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
