// LoadItemInfor function (Load the Item details to the main frame)
function LoadItemInfor(ISBN,ISSN,Author,Title,Edition,Publisher,PubYear,Language,Country)
{
	if (ISBN != "")
		{
			if (eval(parent.Workform.document.forms[0].txtISBN))
			{
				parent.Workform.document.forms[0].txtISBN.value = ISBN;
			}
		}
	if (ISSN != "")
		{
			if (eval(parent.Workform.document.forms[0].ISSN))
			{
				parent.Workform.document.forms[0].txtISSN.value = ISSN ;
			}
		}
	if (Author != "")
		{
		parent.Workform.document.forms[0].txtAuthor.value = Author;
		}
	if (Title != "")
		{
		parent.Workform.document.forms[0].txtTitle.value = Title;
		}
	//if (Edition != "")
		//{
		//parent.Workform.document.forms[0].txtEdition.value = Edition;
		//}
	if (Publisher != "")
		{
		parent.Workform.document.forms[0].txtPublisher.value = Publisher;
		}
	if (PubYear != "")
		{
		parent.Workform.document.forms[0].txtPubYear.value = PubYear;
		}
	if (Language != "")
		{
		parent.Workform.document.forms[0].hidLanguageISOCode.value = Language;
		}
	if (Country !="")
		{
		parent.Workform.document.forms[0].hidCountryISOCode.value = Country;
		}
}