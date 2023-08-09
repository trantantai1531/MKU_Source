/*function ShowHideCatTable() {
	if(tblCatalogue.style.display=="none") {
		tblCatalogue.style.display="";
		lnkCatalogSearch.outerHTML="<a class='lbLinkFunction' id='lnkCatalogSearch' href='javascript:ShowHideCatTable();'>" + msg1 + "</a>"
		}
	else { 
		tblCatalogue.style.display="none";
		lnkCatalogSearch.outerHTML="<a class='lbLinkFunction' id='lnkCatalogSearch' href='javascript:ShowHideCatTable();'>" + msg2 + "</a>"
		}
}*/

function HideAllAttributesTable()
{
	tblAllAtributes.style.display="none";
	tblImageAtributes.style.display="none";
	tblVideoAtributes.style.display="none";
	tblSoundAtributes.style.display="none";
	tblDocumentAtributes.style.display="none";
	tblExeAtributes.style.display="none";
	tblOtherAtributes.style.display="none";
	tblImageType.style.display="none";
}

function ShowHideTable(idTable) {
	HideAllAttributesTable();
	idTable.style.display="";
	if (idTable==tblImageAtributes)
	{
		tblImageType.style.display="";
	}
}
