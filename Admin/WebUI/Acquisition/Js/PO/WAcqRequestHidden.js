// LoadItemInfor function (Load the Item details to the main frame)
function LoadItemInfor(ISBN,ISSN,Author,Title,Edition,Publisher,PubYear)
{
	if (ISBN != "")
		{
			if (eval(parent.mainacq.document.forms[0].txtISBN))
			{
				parent.mainacq.document.forms[0].txtISBN.value = ISBN;
			}
		}
	if (ISSN != "")
		{
			if (eval(parent.mainacq.document.forms[0].ISSN))
			{
				parent.mainacq.document.forms[0].txtISSN.value = ISSN ;
			}
		}
	if (Author != "")
		{
		parent.mainacq.document.forms[0].txtAuthor.value = Author;
		}
	if (Title != "")
		{
		parent.mainacq.document.forms[0].txtTitle.value = Title;
		}
	if (Edition != "")
		{
		parent.mainacq.document.forms[0].txtEdition.value = Edition;
		}
	if (Publisher != "")
		{
		parent.mainacq.document.forms[0].txtPublisher.value = Publisher;
		}
	if (PubYear != "")
		{
		parent.mainacq.document.forms[0].txtPubYear.value = PubYear;
		}
}