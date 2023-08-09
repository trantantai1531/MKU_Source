function UpData(intPOID,intUnitPrice,strTitle,strPubYear,strPublisher,strISSN,strISBN,intTypeID,intMediumID,strAuthor,strEdition,strISOCodeLang,strISOCode,intBookID){
	var lenMedia;
	var lenType;
	parent.main.document.forms[0].txt245_a.value=strTitle;
	parent.main.document.forms[0].txt020_a.value=strISBN;
	parent.main.document.forms[0].txt022_a.value=strISSN;
	parent.main.document.forms[0].txt100_a.value=strAuthor;
	parent.main.document.forms[0].txt260_c.value=strPubYear;
	parent.main.document.forms[0].txt260_b.value=strPublisher;
	parent.main.document.forms[0].txt250_a.value=strEdition;
	lenMedia=parent.main.document.forms[0].ddlItemType.options.length;
	lenType=parent.main.document.forms[0].ddlMedium.options.length;
	for (i=0;i<lenMedia;i++){
		if (parent.main.document.forms[0].ddlMedium.options[i].value ==intMediumID) {
			parent.main.document.forms[0].ddlMedium.options.selectedIndex = i;
		break;
		}
	}
	for (i=0;i<lenType;i++){
		if (parent.main.document.forms[0].ddlItemType.options[i].value ==intTypeID) {
			parent.main.document.forms[0].ddlItemType.options.selectedIndex = i;
		break;
		}
	}
	//parent.hiddenbase.location.href='WCheckcat.aspx?POCode=' + intPOID + '&ID=' + intBookID + '&bold=245&val=' + Esc(strTitle, 1);
	//alert('WCheckcat.aspx?POCode=' + intPOID + '&ID=' + intBookID + '&bold=245&val=' + Esc(strTitle, 1));
}