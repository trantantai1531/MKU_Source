/************************************************************************
*			Search Patron and Load Back Patron Informations				*
************************************************************************/
// Load back Patron informations
function LoadBackPatron(GroupID,FullName,Code){
	opener.document.forms[0].txtPatronName.value=FullName;
	opener.document.forms[0].txtPatronCode.value=Code;
	for(i=0;i<opener.document.forms[0].ddlPatronGroup.options.length;i++){
		if(opener.document.forms[0].ddlPatronGroup.options[i].value==GroupID){
			opener.document.forms[0].ddlPatronGroup.selectedIndex=i;
			break;
		}
	}
	self.close();
}